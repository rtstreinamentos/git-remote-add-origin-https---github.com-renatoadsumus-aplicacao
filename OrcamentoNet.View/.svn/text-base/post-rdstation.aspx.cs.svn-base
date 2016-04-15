using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

namespace OrcamentoNet.View
{
    public partial class post_rdstation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nome = Request.QueryString["nome"].ToString();
            string email = Request.QueryString["email"].ToString();
            string identificador = Request.QueryString["identificador"].ToString();

            string url = "http://www.rdstation.com.br/api/1.2/conversions";

            string parametro = "token_rdstation=a37b4425b5786360fa585f681fd0ff78&identificador=" + identificador + "&nome=" + nome + "&email_lead=" + email;
                        
            GetPage(url, parametro);
        }

        private void GetPage(String url, String query)
        {

            // Declarações necessárias

            Stream requestStream = null;

            WebResponse response = null;

            StreamReader reader = null;



            try
            {

                WebRequest request = WebRequest.Create(url);

                request.Method = WebRequestMethods.Http.Post;



                // Neste ponto, você está setando a propriedade ContentType da página

                // para urlencoded para que o comando POST seja enviado corretamente

                request.ContentType = "application/x-www-form-urlencoded";



                StringBuilder urlEncoded = new StringBuilder();



                // Separando cada parâmetro

                Char[] reserved = { '?', '=', '&' };



                // alocando o bytebuffer

                byte[] byteBuffer = null;



                // caso a URL seja preenchida

                if (query != null)
                {

                    int i = 0, j;

                    // percorre cada caractere da url atraz das palavras reservadas para separação

                    // dos parâmetros

                    while (i < query.Length)
                    {

                        j = query.IndexOfAny(reserved, i);

                        if (j == -1)
                        {

                            urlEncoded.Append(query.Substring(i, query.Length - i));

                            break;

                        }

                        urlEncoded.Append(query.Substring(i, j - i));

                        urlEncoded.Append(query.Substring(j, 1));

                        i = j + 1;

                    }

                    // codificando em UTF8 (evita que sejam mostrados códigos malucos em caracteres especiais

                    byteBuffer = Encoding.UTF8.GetBytes(urlEncoded.ToString());



                    request.ContentLength = byteBuffer.Length;

                    requestStream = request.GetRequestStream();

                    requestStream.Write(byteBuffer, 0, byteBuffer.Length);

                    requestStream.Close();

                }

                else
                {

                    request.ContentLength = 0;

                }



                // Dados recebidos

                response = request.GetResponse();

                Stream responseStream = response.GetResponseStream();



                // Codifica os caracteres especiais para que possam ser exibidos corretamente

                System.Text.Encoding encoding = System.Text.Encoding.Default;



                // Preenche o reader

                reader = new StreamReader(responseStream, encoding);



                Char[] charBuffer = new Char[256];

                int count = reader.Read(charBuffer, 0, charBuffer.Length);



                StringBuilder Dados = new StringBuilder();



                // Lê cada byte para preencher meu stringbuilder

                while (count > 0)
                {

                    Dados.Append(new String(charBuffer, 0, count));

                    count = reader.Read(charBuffer, 0, charBuffer.Length);

                }



                // Imprimo o que recebi

                Console.Write(Dados);

            }

            catch (Exception e)
            {

                // Ocorreu algum erro

                Console.Write("Erro: " + e.Message);

            }

            finally
            {

                // Fecha tudo

                if (requestStream != null)

                    requestStream.Close();

                if (response != null)

                    response.Close();

                if (reader != null)

                    reader.Close();

            }

        }

    }

}

