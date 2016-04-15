using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using log4net;
using MySql.Data.MySqlClient;

namespace OrcamentoNet.ConviteInicialFornecedores
{
    public class Program
    {
        private static log4net.ILog Log4Net { get; set; }
        private static string strConexao = ConfigurationManager.ConnectionStrings["ConexaoBancoDados"].ConnectionString;
        private static MySqlConnection conexao;

        static void Main(string[] args) {

            log4net.Config.XmlConfigurator.Configure();
            Log4Net = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                Log4Net.Debug("Início");

                conexao = new MySqlConnection(strConexao);
                conexao.Open();

                StreamReader sr = new StreamReader(@"D:\sandbox\OrcamentoNet\ListaFornecedoresOrcamentoOnline.txt");
                string email;
                do
                {
                    email = sr.ReadLine();
                    if (!String.IsNullOrEmpty(email))
                    {
                        string resultado = email;

                        string cmd = " SELECT Cd_Pessoa FROM Pessoa WHERE Email='" + email + "'";
                        MySqlCommand aCommand = new MySqlCommand(cmd, conexao);
                        aCommand.ExecuteNonQuery();
                        DataSet ds = new DataSet();
                        MySqlDataAdapter adp = new MySqlDataAdapter(aCommand);
                        adp.Fill(ds, "Pessoa");
                        if (ds.Tables[0].Rows.Count <= 0)
                        {
                            resultado = resultado + " - não localizado na tabela Pessoa";
                        }
                        else
                        {
                            int codigoPessoa = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());

                            cmd = @"SELECT		CONCAT(Nm_Cidade, '/', Sg_Estado)
                                    FROM 		Fornecedor_Cidade FOCI
                                    INNER JOIN	Cidade CIDA
	                                    ON	    CIDA.Cd_Cidade = FOCI.Cd_Cidade
                                    INNER JOIN	Estado ESTA
	                                    ON	    ESTA.Cd_Estado = CIDA.Cd_Estado
                                    WHERE 		FOCI.Cd_Pessoa = " + codigoPessoa.ToString() +
                                    " LIMIT		1";
                            MySqlCommand cmdCidade = new MySqlCommand(cmd, conexao);
                            cmdCidade.ExecuteNonQuery();
                            DataSet dsCidade = new DataSet();
                            MySqlDataAdapter adpCidade = new MySqlDataAdapter(cmdCidade);
                            adpCidade.Fill(dsCidade, "Cidade");

                            if (dsCidade.Tables[0].Rows.Count <= 0)
                            {
                                resultado = resultado + " - não localizado na tabela Fornecedor_Cidade";
                            }
                            else
                            {
                                string cidade = dsCidade.Tables[0].Rows[0][0].ToString();

                                cmd = @"SELECT		Nm_Categoria
                                        FROM 		Fornecedor_Categoria FOCA
                                        INNER JOIN	Categoria CATE
	                                        ON	    CATE.Cd_Categoria = FOCA.Cd_Categoria
                                        WHERE 		FOCA.Cd_Pessoa = " + codigoPessoa.ToString() +
                                         " AND 		CATE.Cd_Categoria NOT IN (54, 124, 125) LIMIT	1"; //buffet, curso e restaurante japonês

                                MySqlCommand cmdCategoria = new MySqlCommand(cmd, conexao);
                                cmdCategoria.ExecuteNonQuery();
                                DataSet dsCategoria = new DataSet();
                                MySqlDataAdapter adpCategoria = new MySqlDataAdapter(cmdCategoria);
                                adpCategoria.Fill(dsCategoria, "Categoria");

                                if (dsCategoria.Tables[0].Rows.Count <= 0)
                                {
                                    resultado = resultado + " - não localizado na tabela Fornecedor_Categoria";
                                }
                                else
                                {
                                    string categoria = dsCategoria.Tables[0].Rows[0][0].ToString();

                                    Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                                    chavesValores.Add("<!-- RAMOS_ATIVIDADE -->", categoria);
                                    chavesValores.Add("<!-- REGIAO_ATUACAO -->", cidade);
                                    chavesValores.Add("<!-- EMAIL -->", email);

                                    string mensagem = ObterHTML(chavesValores, @"C:\Projeto\OrcamentoNet\trunk\OrcamentoNet.View\templateEmail\NotificarInclusaoAutomatica.htm");

                                    AlternateView view = AlternateView.CreateAlternateViewFromString(mensagem, null, MediaTypeNames.Text.Html);
                                    try
                                    {
                                        MailMessage _email = new MailMessage();
                                        _email.From = new MailAddress("orcamentos.net@gmail.com");

                                        if (mensagem.StartsWith("<!DOCTYPE"))
                                        {
                                            _email.AlternateViews.Add(view);
                                        }
                                        else
                                        {
                                            _email.Body = mensagem;
                                        }

                                        _email.Subject = "Orçamento Online - oportunidades de negócio";
                                        _email.IsBodyHtml = true;

                                        _email.To.Add(email);

                                        Console.WriteLine(email);
                                        System.Threading.Thread.Sleep(2500);
                                        SmtpClient SmtpServer = new SmtpClient();
                                        SmtpServer.Host = "smtpout.orcamentos.net.br";
                                        SmtpServer.Port = 25;
                                        SmtpServer.Credentials = new System.Net.NetworkCredential("webmaster@orcamentos.net.br", "w3bm4st3r@");
                                        SmtpServer.Send(_email);
                                        SmtpServer = null;
                                    }
                                    catch (Exception e)
                                    {
                                        Logar(e);
                                    }
                                }

                                dsCategoria.Dispose();
                                adpCategoria.Dispose();
                                cmdCategoria.Dispose();
                            }

                            dsCidade.Dispose();
                            adpCidade.Dispose();
                            cmdCidade.Dispose();
                        }

                        //registra o resultado do processamento
                        StreamWriter sw = new StreamWriter(@"D:\sandbox\OrcamentoNet\ListaFornecedoresOrcamentoOnlineProcessados.txt", true);
                        sw.WriteLine(resultado);
                        sw.Close();
                        sw.Dispose();
                    }
                }
                while (email != null);

                sr.Close();
                sr.Dispose();
            }
            catch (Exception e)
            {
                Logar(e);
            }
            finally
            {
                if (conexao != null)
                {
                    if (conexao.State == ConnectionState.Open) conexao.Close();
                    conexao.Dispose();
                }
            }

        }

        private static void Logar(Exception e) {
            log4net.Config.XmlConfigurator.Configure();
            Log4Net = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            string erroInterno = string.Empty;
            if (e.InnerException != null)
            {
                erroInterno = e.InnerException.ToString();
            }

            Log4Net.Error(e.Message +
                           " - Detalhamento: " + erroInterno +
                           " - Origem: " + e.Source +
                           " - Pilha: " + e.StackTrace);
        }

        public static string ObterHTML(Dictionary<string, string> chavesValores, string caminhoHTML) {
            StreamReader sr = new StreamReader(caminhoHTML);
            string linha = string.Empty;
            string htmlEmail = string.Empty;
            while ((linha = sr.ReadLine()) != null)
            {
                htmlEmail = htmlEmail + linha;
            }

            foreach (KeyValuePair<string, string> item in chavesValores)
            {
                htmlEmail = htmlEmail.Replace(item.Key, item.Value);
            }

            return htmlEmail;
        }

    }
}
