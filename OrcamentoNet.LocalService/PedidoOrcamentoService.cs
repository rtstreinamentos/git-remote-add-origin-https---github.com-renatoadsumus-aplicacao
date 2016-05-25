using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using PortalEscolar.Data;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity._enum;
using System.Xml;

namespace OrcamentoNet.LocalService
{
    public class PedidoOrcamentoService : IPedidoOrcamentoService
    {
        private IDataContext context;

        public PedidoOrcamentoService(IDataContext contextData)
        {
            context = contextData;
        }

        #region Métodos Privados
        private void AdicionarCampoInvalido(ref string camposInvalidos, string novoCampoInvalido)
        {
            if (!String.IsNullOrEmpty(camposInvalidos)) camposInvalidos += ", ";
            camposInvalidos = camposInvalidos + novoCampoInvalido;
        }

        public string CategoriasDoPedidoSeparadasPorVirgula(PedidoOrcamento pedidoOrcamento)
        {
            string categorias = String.Empty;
            try
            {
                foreach (Categoria categoria in pedidoOrcamento.Categorias)
                {
                    if (!String.IsNullOrEmpty(categorias))
                    {
                        categorias += ", " + categoria.Nome;
                    }
                    else
                    {
                        categorias = categoria.Nome;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
            return categorias;
        }

        #endregion

        #region Métodos Públicos

        public void AssinarLista(string nome, string email)
        {
            try
            {
                INewsletterService newsletterService = new NewsletterService();
                newsletterService.AssinarLista(nome, email);
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
        }

        public bool AutorizarAcesso(int idPedido, string email)
        {
            PedidoOrcamento pedidoOrcamento = null;
            try
            {
                pedidoOrcamento = context.Repository<PedidoOrcamento>()
                    .Where(x => x.Id == idPedido &&
                                x.Email == email)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
            return (pedidoOrcamento != null);
        }


        public bool EnviarEmailPedidoOrcamentoSimplificado(PedidoOrcamento pedidoOrcamento)
        {


            try
            {
                //IFornecedorService fornecedorService = new FornecedorService(context);

                //IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresParaUmPedidoDeOrcamento(pedidoOrcamento);

                //string htmlFornecedores = "";

                //foreach (Fornecedor fornecedor in fornecedores)
                //{
                //    htmlFornecedores = htmlFornecedores + "<li><a href='" + fornecedor.UrlFichaTecnica + "'>" + fornecedor.Nome + "</a></li>";
                //}

                //if (htmlFornecedores != "")
                //{
                //    htmlFornecedores = "<h2>Parceiros do Orçamento Online:</h2><ul>" + htmlFornecedores + "</ul>";
                //}

                IPostBlogService postBlogServive = new PostBlogService(context);
                IList<PostBlog> postsTema = postBlogServive.ObterPostsDeUmTema(pedidoOrcamento.Categorias[0].Pai.Id);

                string htmlPost = "";

                foreach (PostBlog item in postsTema)
                {
                    htmlPost = htmlPost + "<li><a href='" + Config.UrlSite + "PostBlogForm.aspx?idPost=" + item.Id + "'>" + item.Titulo + "</a></li>";
                }

                if (htmlPost != "")
                {
                    htmlPost = "<h2>Matérias que podem ser do seu interesse!</h2><ul>" + htmlPost + "</ul>";
                }

                string htmlFoto = "";

                if (pedidoOrcamento.Fotos != null)
                {
                    foreach (string foto in pedidoOrcamento.Fotos)
                    {
                        htmlFoto = htmlFoto + "<li><a href='" + Config.UrlSite + "FotosComprador/" + foto + "'>" + foto + "</a></li>";
                    }
                    if (htmlFoto != "")
                    {
                        htmlFoto = "<b>Fotos enviadas:</b><br/><ul>" + htmlFoto + "</ul>";
                    }
                }

                Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                chavesValores.Add("<!--NOME-->", pedidoOrcamento.NomeComprador);
                chavesValores.Add("<!--TELEFONE-->", pedidoOrcamento.Telefone);
                chavesValores.Add("<!--CIDADE-->", pedidoOrcamento.Cidade.Nome);
                chavesValores.Add("<!--UF-->", pedidoOrcamento.Cidade.Uf.ToString());
                chavesValores.Add("<!--OBSERVACAO-->", pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />"));
                chavesValores.Add("<!--URL-->", Config.UrlSite + "ConfirmacaoEmail.aspx?email=" + pedidoOrcamento.Email + "&id=" + pedidoOrcamento.Id.ToString());
                chavesValores.Add("<!--FOTOS-->", htmlFoto);
                chavesValores.Add("<!--POSTS-->", htmlPost);
                // chavesValores.Add("<!--FORNECEDORES-->", htmlFornecedores);


                string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailNovoPedidoOrcamentoSimplificado);
                return Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, pedidoOrcamento.Email, htmlEmail, Config.NomeAplicacao.ToUpper() + " - NOVO PEDIDO DE ORÇAMENTO", true, true, null, "");
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        public void EnviarEmailPedidoOrcamentoParaWordPress(PedidoOrcamento pedidoOrcamento)
        {
            try
            {
                string backLinkMulticotacao = String.Empty;
                string urlMulticotacao = String.Empty;
                string tooltipMulticotacao = String.Empty;
                string nomeExibicaoMulticotacao = String.Empty;

                string backLinkVoceConhece = String.Empty;
                string urlVoceConhece = String.Empty;
                string tooltipVoceConhece = String.Empty;
                string nomeExibicaoVoceConhece = String.Empty;

                ICategoriaService categoriaService = new CategoriaService(context);

                foreach (Categoria item in pedidoOrcamento.Categorias)
                {
                    var categoria = categoriaService.ObterXMLCategoria(item.Id);

                    foreach (var registro in categoria)
                    {
                        try
                        {
                            urlVoceConhece = registro.Element("urlVoceConhece").Value;
                            tooltipVoceConhece = registro.Element("tooltipVoceConhece").Value;
                            nomeExibicaoVoceConhece = registro.Element("nomeExibicaoVoceConhece").Value;
                            backLinkVoceConhece = "Conheça os <a href='" + urlVoceConhece.Trim() + "' target='_blank' title='" + tooltipVoceConhece.Trim() + "'>" + nomeExibicaoVoceConhece.Trim() + "</a> que participam desta cotação de preços.";

                            urlMulticotacao = registro.Element("urlMulticotacao").Value;
                            tooltipMulticotacao = registro.Element("tooltipMulticotacao").Value;
                            nomeExibicaoMulticotacao = registro.Element("nomeExibicaoMulticotacao").Value;
                            backLinkMulticotacao = "Solicite você também um <a href='" + urlMulticotacao.Trim() + "' target='_blank' title='" + tooltipMulticotacao.Trim() + "'>" + nomeExibicaoMulticotacao.Trim() + "</a>.";
                        }
                        catch (Exception ex)
                        {
                            Log.GravarLog(ex.Message);
                        }
                    }

                    if (String.IsNullOrEmpty(backLinkMulticotacao)) backLinkMulticotacao = "Orçamento Online - <a href='http://orcamentosgratis.net.br/' title='Solicite orçamento online grátis de diversos produtos e serviços em todo o Brasil' target='_blank'>http://orcamentosgratis.net.br/</a>";
                    //if (String.IsNullOrEmpty(backLinkVoceConhece)) backLinkVoceConhece = "Você Conhece - <a href='http://voceconhece.com/' title='Conheça indicação de profissionais e empresas em todo o Brasil' target='_blank'>http://voceconhece.com/</a>";

                    Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                    chavesValores.Add("<!--NOME_COMPRADOR-->", pedidoOrcamento.NomeComprador.Trim());
                    chavesValores.Add("<!--CIDADE-->", pedidoOrcamento.Cidade.Nome.Trim());
                    chavesValores.Add("<!--UF-->", pedidoOrcamento.Cidade.Uf.ToString());
                    chavesValores.Add("<!--OBSERVACAO-->", pedidoOrcamento.Observacao.Trim().Replace(Environment.NewLine, "<br />"));
                    chavesValores.Add("<!--CATEGORIA-->", item.Nome.Trim());
                    chavesValores.Add("<!--TITULO-->", pedidoOrcamento.Titulo.Trim());
                    chavesValores.Add("<!--BACKLINK_MULTICOTACAO-->", backLinkMulticotacao);
                    chavesValores.Add("<!--BACKLINK_VOCECONHECE-->", backLinkVoceConhece);

                    CidadeService cidadeService = new CidadeService(context);
                    string nomeCidade = pedidoOrcamento.Cidade.Nome.Trim();
                    if (!String.IsNullOrEmpty(nomeCidade))
                    {
                        chavesValores.Add("<!--TAGS-->", nomeCidade);
                    }

                    string textoDoPost = Email.ObterHTML(chavesValores, Config.TemplateEmailPedidoOrcamentoParaWordPress);

                    string tituloDoPost = item.Nome.Trim() + ": Preço de " + item.Nome.Trim() + " para " + pedidoOrcamento.Titulo.Trim() + " em " + pedidoOrcamento.Cidade.Nome.Trim() + " (" + pedidoOrcamento.Cidade.Uf.ToString().Trim() + ")";

                    //Fabrício - forçado para "orcamentos.net@gmail.com", devido à necessidade de autenticação no 
                    //domínio @oficial.blog.br quando o destinatário é do SMPT de @oficial.blog.br
                    Email.EnviarEmail("orcamentos.net@gmail.com", "orcamentos.net@gmail.com", Config.EmailPostWordPress, textoDoPost, tituloDoPost, false, true, null, String.Empty);
                }
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

        }

        public void NotificarFornecedorEmDegustacaoPorEmailNovoPedidoOrcamento(PedidoOrcamento pedidoOrcamento, bool possuiFornecedorCadastrado)
        {
            try
            {
                IFornecedorService fornecedorService = new FornecedorService(context);

                IList<Fornecedor> fornecedores =
                    fornecedorService.ObterFornecedoresEmDegustacaoParaUmPedidoDeOrcamento(pedidoOrcamento);

                string htmlOpiniao = String.Empty;
                if (fornecedores.Count > 0)
                    htmlOpiniao = MontarHTMLOpiniao(fornecedores[0].SubCategorias[0].Pai.Id);

                string htmlFoto = "";
                int numeroFoto = 1;

                if (pedidoOrcamento.Fotos != null)
                {
                    foreach (string foto in pedidoOrcamento.Fotos)
                    {
                        htmlFoto = htmlFoto + "<li><a href='" + Config.UrlSite + "FotosComprador/" + foto + "'>Foto local " + numeroFoto.ToString() + "</a></li>";
                        numeroFoto++;
                    }

                    if (htmlFoto != "")
                    {
                        htmlFoto = "<b>Fotos ou arquivos enviados pelo solicitante:</b><br/><ul>" + htmlFoto + "</ul>";
                    }
                }

                foreach (Fornecedor fornecedor in fornecedores)
                {
                    string telefone = pedidoOrcamento.Telefone + " <b>Operadora:</b> " + pedidoOrcamento.TelefoneOperadora.ToUpper();

                    string statusEmail = "(<strong>Email Validado!</strong>)";

                    Dictionary<string, string> chavesValores = new Dictionary<string, string>();

                    chavesValores.Add("<!--NOME_COMPRADOR-->", pedidoOrcamento.NomeComprador);
                    chavesValores.Add("<!--EMAIL_COMPRADOR_TRUNCADO-->", pedidoOrcamento.Email.Substring(0, 6) + "...@XXX.com");
                    chavesValores.Add("<!--EMAIL_FORNECEDOR-->", fornecedor.Email);
                    chavesValores.Add("<!--SENHA_FORNECEDOR-->", fornecedor.Senha);
                    chavesValores.Add("<!--FICHA_TECNICA-->", fornecedor.UrlFichaTecnica);
                    chavesValores.Add("<!--TELEFONE_COMPRADOR_TRUNCADO-->", pedidoOrcamento.Telefone.Substring(0, 7) + "-XXXX");
                    chavesValores.Add("<!--FOTOS-->", htmlFoto);

                    string valorAvulso = "5,90";

                    if (pedidoOrcamento.PessoaTipo == PessoaTipo.Juridica)
                        valorAvulso = "10,90";

                    //string valorPromocao = "9,90";

                    //if (fornecedor.ValorMensalidadeAlteracao > 29)
                    //{
                    //    valorPromocao = "19,90";
                    //}

                    string valorMensalidade = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao).Replace(".", ",");
                    string valorMensalidade3Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao * 3).Replace(".", ",");
                    string valorMensalidade8Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao * 8).Replace(".", ",");

                    if (!possuiFornecedorCadastrado)
                        chavesValores.Add("<!--SEM_FORNECEDOR-->", "Execelente Oportunidade! Ainda não temos nenhum fornecedor cadastrado em nosso sistema para responder esse pedido!");

                    if (pedidoOrcamento.Status == PedidoStatus.EmailValidado)
                    {
                        chavesValores.Add("<!--STATUS_EMAIL-->", statusEmail);
                        chavesValores.Add("<!--EMAIL_VALIDADO-->", "<h2>ATENÇÃO: E-MAIL do cliente foi validado com sucesso!</h2>");
                        string urlAvulso = Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorAvulso.Replace(".", ",") + "&id=" + fornecedor.Id + "&idPedido=" + pedidoOrcamento.Id;
                        string htmlAvulso = "- <strong>Cotação avulsa</strong>: <a href='" + urlAvulso + "'>R$" + valorAvulso + "</a> <br/><br/>";
                        chavesValores.Add("<!--HTML_AVULSO-->", htmlAvulso);

                    }

                    chavesValores.Add("<!--NOME_FORNECEDOR-->", fornecedor.Nome);
                    chavesValores.Add("<!--VALOR_MENSALIDADE-->", valorMensalidade);
                    chavesValores.Add("<!--VALOR_3MESES-->", valorMensalidade3Meses);
                    chavesValores.Add("<!--VALOR_8MESES-->", valorMensalidade8Meses);
                    chavesValores.Add("<!--CIDADE-->", pedidoOrcamento.Cidade.Nome);
                    //chavesValores.Add("<!--VALOR_PROMOCAO-->", valorPromocao);
                    chavesValores.Add("<!--UF-->", pedidoOrcamento.Cidade.Uf.ToString());
                    chavesValores.Add("<!--TITULO-->", pedidoOrcamento.Titulo);
                    chavesValores.Add("<!--OBSERVACAO-->", pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />"));
                    chavesValores.Add("<!--URL-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade + "&id=" + fornecedor.Id + "&plano=1");
                    //chavesValores.Add("<!--URL-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorPromocao + "&id=" + fornecedor.Id + "&plano=1");

                    chavesValores.Add("<!--URL_3MESES-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade3Meses + "&id=" + fornecedor.Id + "&plano=3");
                    chavesValores.Add("<!--URL_8MESES-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade8Meses + "&id=" + fornecedor.Id + "&plano=8");

                    string htmlEmail = "";
                    string emailReply = pedidoOrcamento.Email;

                    chavesValores.Add("<!--OPINIAO_CLIENTE-->", htmlOpiniao);
                    chavesValores.Add("<!--H3_OPINIAO-->", "Veja o que os clientes estão falando do Orçamento Online:");

                    htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailInformativoFornecedorDegustacaoDeNovoPedidoOrcamento);
                    //htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailInformativoFornecedorDegustacaoDeNovoPedidoOrcamentoPromocao);
                    emailReply = Config.EmailAdministrador;

                    Email.EnviarEmail(Config.EmailAdministrador, emailReply, fornecedor.Email, htmlEmail, Config.NomeAplicacao + " - " + pedidoOrcamento.Titulo + " - " + pedidoOrcamento.NomeComprador + " (" + pedidoOrcamento.Id.ToString() + ")", true, false, null, "");

                }
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
        }

        public bool NotificarFornecedorClientePorEmailNovoPedidoOrcamento(PedidoOrcamento pedidoOrcamento, Fornecedor fornecedorNaoInteressou)
        {
            bool possuiFornecedorCadastrado = true;

            try
            {
                IFornecedorService fornecedorService = new FornecedorService(context);
                IPedidoOrcamentoFornecedorService pedidoOrcamentoFornecedorService = new PedidoOrcamentoFornecedorService(context);
                IList<Fornecedor> fornecedores =
                    fornecedorService.ObterFornecedoresClientesParaUmPedidoDeOrcamento(pedidoOrcamento);

                if (fornecedorNaoInteressou != null)
                {
                    IList<Fornecedor> fornecedoresTemp = fornecedores;
                    fornecedores = new List<Fornecedor>();

                    IList<PedidoOrcamentoFornecedor> fornecedoresQueReceberamPedido = pedidoOrcamentoFornecedorService.ObterPorPedido(pedidoOrcamento.Id);

                    foreach (PedidoOrcamentoFornecedor pedidoEnviado in fornecedoresQueReceberamPedido)
                    {
                        fornecedoresTemp.Remove(pedidoEnviado.Fornecedor);
                    }


                    if (fornecedoresTemp.Count > 0)
                    {
                        fornecedores.Add(fornecedoresTemp[0]);
                    }

                }


                string htmlFoto = "";
                int numeroFoto = 1;
                string htmlNomeFornecedores = "";
                if (pedidoOrcamento.Fotos != null)
                {
                    foreach (string foto in pedidoOrcamento.Fotos)
                    {
                        htmlFoto = htmlFoto + "<li><a href='" + Config.UrlSite + "FotosComprador/" + foto + "'>Foto local " + numeroFoto.ToString() + "</a></li>";
                        numeroFoto++;
                    }

                    if (htmlFoto != "")
                    {
                        htmlFoto = "<b>Fotos ou arquivos enviados pelo solicitante:</b><br/><ul>" + htmlFoto + "</ul>";
                    }
                }

                Dictionary<string, string> chavesValores;


                foreach (Fornecedor fornecedor in fornecedores)
                {
                    PedidoOrcamentoFornecedor pedidoOrcamentoFornecedor = new PedidoOrcamentoFornecedor();
                    pedidoOrcamentoFornecedor.PedidoOrcamento = pedidoOrcamento;
                    pedidoOrcamentoFornecedor.Fornecedor = fornecedor;

                    pedidoOrcamentoFornecedorService.Inserir(pedidoOrcamentoFornecedor);

                    chavesValores = new Dictionary<string, string>();
                    htmlNomeFornecedores = htmlNomeFornecedores + "<a href='" + fornecedor.UrlFichaTecnica + "'>" + fornecedor.Nome + "</a><br/>";

                    string telefone = pedidoOrcamento.Telefone + " <b>Operadora:</b> " + pedidoOrcamento.TelefoneOperadora.ToUpper();

                    string statusEmail = "(<strong>Email Validado!</strong>)";

                    if (pedidoOrcamento.PessoaTipo == PessoaTipo.Juridica && fornecedor.TipoPessoaAtendimento == PessoaTipo.Fisica)
                    {
                        chavesValores.Add("<!--EMAIL_COMPRADOR-->", pedidoOrcamento.Email.Substring(0, 6) + "...@XXX.com");
                        chavesValores.Add("<!--TELEFONE_COMPRADOR-->", pedidoOrcamento.Telefone.Substring(0, 7) + "-XXXX");
                    }
                    else
                    {
                        chavesValores.Add("<!--EMAIL_COMPRADOR-->", pedidoOrcamento.Email);
                        chavesValores.Add("<!--TELEFONE_COMPRADOR-->", telefone);
                    }

                    string urlInteressePedido = "http://preco.orcamentosgratis.net.br/PesquisaPerfilFornecedor.aspx?interesse=1&idFornecedor=" + fornecedor.Id + "&idPedido=" + pedidoOrcamento.Id;
                    string urlInteresseNaoPedido = "http://preco.orcamentosgratis.net.br/PesquisaPerfilFornecedor.aspx?interesse=2&idFornecedor=" + fornecedor.Id + "&idPedido=" + pedidoOrcamento.Id;

                    chavesValores.Add("<!--NOME_COMPRADOR-->", pedidoOrcamento.NomeComprador);
                    chavesValores.Add("<!--FICHA_TECNICA-->", fornecedor.UrlFichaTecnica);
                    chavesValores.Add("<!--FOTOS-->", htmlFoto);
                    chavesValores.Add("<!--URL_INTERESSE-->", urlInteressePedido);
                    chavesValores.Add("<!--URL_NAO_INTERESSE-->", urlInteresseNaoPedido);

                    if (pedidoOrcamento.Status == PedidoStatus.EmailValidado)
                    {
                        chavesValores.Add("<!--STATUS_EMAIL-->", statusEmail);
                        chavesValores.Add("<!--EMAIL_VALIDADO-->", "<h2>ATENÇÃO: E-MAIL do cliente foi validado com sucesso!</h2>");
                    }

                    chavesValores.Add("<!--NOME_FORNECEDOR-->", fornecedor.Nome);
                    chavesValores.Add("<!--CIDADE-->", pedidoOrcamento.Cidade.Nome);
                    chavesValores.Add("<!--UF-->", pedidoOrcamento.Cidade.Uf.ToString());
                    chavesValores.Add("<!--TITULO-->", pedidoOrcamento.Titulo);
                    chavesValores.Add("<!--CLASSIFICACAO-->", pedidoOrcamento.ClassificacaoPedido.ToString());
                    chavesValores.Add("<!--OBSERVACAO-->", pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />"));

                    string htmlEmail = "";
                    string emailReply = pedidoOrcamento.Email;

                    chavesValores.Add("<!--ID-->", fornecedor.Id.ToString());
                    htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailInformativoFornecedorDeNovoPedidoOrcamento);

                    if (fornecedor.MensagemAutoResposta != null && fornecedor.MensagemAutoResposta != "")
                    {
                        chavesValores.Add("<!--MENSAGEM-->", fornecedor.MensagemAutoResposta);
                        chavesValores.Add("<!--FORNECEDOR-->", fornecedor.Nome);
                        chavesValores.Add("<!--EMAIL-->", fornecedor.Email);
                        chavesValores.Add("<!--TELEFONE-->", fornecedor.Telefone);
                        string htmlEmailAutoResposta = Email.ObterHTML(chavesValores, Config.TemplateEmailAutoResposta);

                        Email.EnviarEmail(fornecedor.Email, fornecedor.Email, pedidoOrcamento.Email, htmlEmailAutoResposta, "Resposta ao seu pedido de Orçamento de " + pedidoOrcamento.Titulo, false, true, null, fornecedor.Email);
                    }

                    Email.EnviarEmail(Config.EmailAdministrador, emailReply, fornecedor.Email, htmlEmail, Config.NomeAplicacao + " - " + pedidoOrcamento.Titulo + " - " + pedidoOrcamento.NomeComprador + " (" + pedidoOrcamento.Id.ToString() + ")", true, true, null, "");
                }

                if (htmlNomeFornecedores != "")
                {
                    chavesValores = new Dictionary<string, string>();
                    chavesValores.Add("<!--NOME_COMPRADOR-->", pedidoOrcamento.NomeComprador);
                    chavesValores.Add("<!--FORNECEDORES-->", htmlNomeFornecedores);
                    string htmlEmailRespostaComprador = Email.ObterHTML(chavesValores, Config.TemplateInformativoFornecedoresAoComprador);

                    Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, pedidoOrcamento.Email, htmlEmailRespostaComprador, Config.NomeAplicacao + " - " + pedidoOrcamento.Titulo + " - " + pedidoOrcamento.NomeComprador + " (" + pedidoOrcamento.Id.ToString() + ")", true, true, null, "");
                }

                if (fornecedores.Count == 0)
                {
                    possuiFornecedorCadastrado = false;
                    chavesValores = new Dictionary<string, string>();
                    chavesValores.Add("<!--NOME_COMPRADOR-->", pedidoOrcamento.NomeComprador);
                    string htmlEmailRespostaComprador = Email.ObterHTML(chavesValores, Config.TemplatePedidoOrcamentoSemFornecedor);

                    Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, pedidoOrcamento.Email, htmlEmailRespostaComprador, Config.NomeAplicacao + " - " + pedidoOrcamento.Titulo + " - " + pedidoOrcamento.NomeComprador + " (" + pedidoOrcamento.Id.ToString() + ")", false, true, null, "");
                }
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
            return possuiFornecedorCadastrado;
        }

        private string MontarHTMLOpiniao(int idCategoriaPai)
        {
            IList<PedidoOrcamento> pedidoOrcamentoComDepoimento = ObterComComentarios(7, idCategoriaPai);

            string htmlOpiniao = "";

            foreach (PedidoOrcamento pedido in pedidoOrcamentoComDepoimento)
            {
                htmlOpiniao += "Solicitante:<b>" + pedido.NomeComprador + "</b><br/> O que foi bom?<br/>" +
                               pedido.OpiniaoComprador.Replace(Environment.NewLine, "<br />") + "<br /><br />";
            }

            return htmlOpiniao;
        }

        /// <summary>
        /// Retorna uma lista de pedidos de orçamento com status Em Aberto
        /// </summary>
        /// <param name="subCategorias"></param>
        /// <returns></returns>
        public PedidoOrcamento Inserir(ref string camposInvalidos, PedidoOrcamento pedidoOrcamento)
        {
            if (!this.ValidarDados(ref camposInvalidos
                , pedidoOrcamento.Categorias
                , pedidoOrcamento.Titulo
                , pedidoOrcamento.Observacao)) return null;

            try
            {
                pedidoOrcamento.Data = DateTime.Now;
                pedidoOrcamento.StatusPedidoComprador = 0;
                pedidoOrcamento.Status = PedidoStatus.EmailNaoValidado;
                pedidoOrcamento.ClassificacaoPedido = ObterClassificacaoPedido(pedidoOrcamento);
                context.Insert(pedidoOrcamento);
                context.Commit();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return null;
            }

            return pedidoOrcamento;
        }

        public PedidoOrcamento InserirPedido(PedidoOrcamento pedidoOrcamento)
        {

            try
            {
                pedidoOrcamento.Data = DateTime.Now;
                pedidoOrcamento.StatusPedidoComprador = 0;
                pedidoOrcamento.Status = PedidoStatus.EmailNaoValidado;
                context.Insert(pedidoOrcamento);
                context.Commit();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return null;
            }

            return pedidoOrcamento;
        }

        public IList<PedidoOrcamento> ObterPedidosOrcamentoUltimaHora(DateTime dataHoraReferencia)
        {
            IList<PedidoOrcamento> pedidosOrcamento = null;
            try
            {
                DateTime dataHoraInicio = dataHoraReferencia.AddHours(-1);
                DateTime dataHoraFim = dataHoraReferencia;
                pedidosOrcamento = context.Repository<PedidoOrcamento>()
                    .Where(x => x.Data >= dataHoraInicio &&
                                x.Data < dataHoraFim)
                    .ToList();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
            return pedidosOrcamento;
        }


        public PedidoOrcamento Obter(int id)
        {
            PedidoOrcamento pedidoOrcamento = null;
            try
            {
                pedidoOrcamento = new PedidoOrcamento();
                pedidoOrcamento = context.Repository<PedidoOrcamento>().Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return pedidoOrcamento;
        }

        public IList<PedidoOrcamento> ObterPedidosOrcamentoParaInformarStatusAosFornecedores()
        {
            IList<PedidoOrcamento> pedidosOrcamento = null;
            try
            {
                DateTime dataAtualizacao = DateTime.Today.AddDays(-1);
                pedidosOrcamento = context.Repository<PedidoOrcamento>()
                    .Where(x => x.PesquisaRevisada == true &&
                                x.DataAlteracao >= dataAtualizacao)
                    .ToList();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
            return pedidosOrcamento;
        }

        public IList<PedidoOrcamento> ObterPedidosOrcamentoPorData(DateTime dataPedidoOrcamento)
        {
            IList<PedidoOrcamento> pedidos = context.Repository<PedidoOrcamento>().ToList()
                .Where(x => x.Data.DayOfYear == dataPedidoOrcamento.DayOfYear && x.Data.Year == dataPedidoOrcamento.Year).ToList();

            return pedidos;
        }


        public IList<PedidoOrcamento> ObterUltimosPedidosOrcamento(int quantidadeRegistros, string termoPesquisa)
        {
            if (String.IsNullOrEmpty(termoPesquisa))
            {
                return context.Repository<PedidoOrcamento>().Take(quantidadeRegistros).OrderByDescending(x => x.Data).ToList();
            }
            else
            {
                return context.Repository<PedidoOrcamento>().Where(x => x.Observacao.Contains(termoPesquisa) || x.Titulo.Contains(termoPesquisa)).Take(quantidadeRegistros).OrderByDescending(x => x.Data).ToList();
            }
        }


        public IList<PedidoOrcamento> ObterUltimosPedidosOrcamentoPorCategoriaMes(int quantidadeRegistros, Categoria categoria, int idMes, int idCidade)
        {
            //Categoria categoria = context.Repository<Categoria>().Where(x => x.Id == idCategoria).FirstOrDefault();

            IList<PedidoOrcamento> pedidos = new List<PedidoOrcamento>();

            if (idCidade != 0)
            {
                pedidos = context.Repository<PedidoOrcamento>().Where(x => x.Cidade.Id == idCidade && x.Categorias.Contains(categoria)).ToList().Where(y => y.Data.Month == idMes && y.Data.Year == DateTime.Now.Year).Take(quantidadeRegistros).ToList();
            }
            else
            {
                pedidos = context.Repository<PedidoOrcamento>().ToList().Where(y => y.Mes == idMes && y.Ano == DateTime.Now.Year).ToList();
            }

            return pedidos;
        }



        public IList<PedidoOrcamento> ObterUltimosPedidosOrcamentoPorCategoriaOuTema(int quantidadeRegistros, int idCategoria, string termoPesquisa)
        {
            IList<PedidoOrcamento> pedidos = new List<PedidoOrcamento>();
            PedidoOrcamento pedidoOrcamento;

            Categoria categoria = context.Repository<Categoria>().Where(x => x.Id == idCategoria).FirstOrDefault();


            if (categoria.Pai.Id != 0)
            {
                pedidos = context.Repository<PedidoOrcamento>().Take(100).Where(x => x.Categorias.Contains(categoria)).ToList().Take(quantidadeRegistros).ToList();
            }

            //string caminhoArquivo = Config.CaminhoFisico + "UltimosPedidos.xml";

            //IEnumerable<XElement> xmlDocuments = from c in XElement
            //                            .Load(caminhoArquivo)
            //                            .Elements("row")
            //                                     select c;
            //string observacao = "";
            //string dataCadastro = "";
            //string titulo = "";
            //int idCidade = 0;
            //int categoria = 0;

            //foreach (XElement item in xmlDocuments)
            //{
            //    int posicao = 0;
            //    foreach (XElement item2 in item.Elements())
            //    {
            //        if (posicao == 1)
            //            observacao = item2.Value;

            //        if (posicao == 2)
            //            dataCadastro = item2.Value;

            //        if (posicao == 3)
            //            titulo = item2.Value;

            //        if (posicao == 4)
            //            idCidade = int.Parse(item2.Value);

            //        if (posicao == 24)
            //            categoria = int.Parse(item2.Value);

            //        posicao++;
            //    }

            //    if (idCategoria == categoria)
            //    {
            //        CidadeService cidadeServive = new CidadeService(context);
            //        Cidade cidade = cidadeServive.Obter(idCidade);

            //        pedidoOrcamento = new PedidoOrcamento();
            //        pedidoOrcamento.Observacao = observacao;
            //        pedidoOrcamento.Titulo = titulo;
            //        pedidoOrcamento.Data = DateTime.Parse(dataCadastro);
            //        pedidoOrcamento.Cidade = cidade;

            //        if (termoPesquisa == "")
            //            pedidos.Add(pedidoOrcamento);
            //        else
            //            if (titulo.Contains(termoPesquisa) || observacao.Contains(termoPesquisa))
            //                pedidos.Add(pedidoOrcamento);

            //    }

            //  if (pedidos.Count == quantidadeRegistros)
            //    return pedidos;
            //}



            return pedidos;

        }
        /// <summary>
        /// Retorna ultimos pedidos de um Tema e Estado ou Uma Categoria e Uma cidade
        /// </summary>
        /// <param name="quantidadeRegistros"></param>
        /// <param name="idCategoria"></param>
        /// <param name="idCidade"></param>
        /// <param name="termoPesquisa"></param>
        /// <returns></returns>
        public IList<PedidoOrcamento> ObterUltimosPedidosOrcamentoPorCategoriaPorCidadeOuEstado(int quantidadeRegistros, int idCategoria, int idCidade, string termoPesquisa)
        {
            IList<PedidoOrcamento> pedidos = new List<PedidoOrcamento>();
            PedidoOrcamento pedidoOrcamento;

            string caminhoArquivo = Config.CaminhoFisico + "UltimosPedidos.xml";

            IEnumerable<XElement> xmlDocuments = from c in XElement
                                        .Load(caminhoArquivo)
                                        .Elements("row")
                                                 select c;
            IList<Cidade> cidades = new List<Cidade>();
            if (idCidade > 0 && idCidade < 27)
            {
                string uf = Enum.GetName(typeof(UF), idCidade);
                //cidades = context.Repository<Cidade>().Where(x => x.Uf == (UF)Enum.Parse(typeof(UF), uf)).ToList();
            }

            string observacao = "";
            string dataCadastro = "";
            string titulo = "";
            int idCidadeXML = 0;
            int categoria = 0;

            foreach (XElement item in xmlDocuments)
            {
                int posicao = 0;
                foreach (XElement item2 in item.Elements())
                {
                    if (posicao == 1)
                        observacao = item2.Value;

                    if (posicao == 2)
                        dataCadastro = item2.Value;

                    if (posicao == 3)
                        titulo = item2.Value;

                    if (posicao == 4)
                        idCidadeXML = int.Parse(item2.Value);

                    if (posicao == 24)
                        categoria = int.Parse(item2.Value);

                    posicao++;
                }


                if (idCategoria == categoria && idCidadeXML == idCidade)
                {
                    CidadeService cidadeServive = new CidadeService(context);
                    Cidade cidade = cidadeServive.Obter(idCidade);

                    pedidoOrcamento = new PedidoOrcamento();
                    pedidoOrcamento.Observacao = observacao;
                    pedidoOrcamento.Titulo = titulo;
                    pedidoOrcamento.Data = DateTime.Parse(dataCadastro);
                    pedidoOrcamento.Cidade = cidade;

                    if (termoPesquisa == "")
                        pedidos.Add(pedidoOrcamento);
                    else
                        if (titulo.Contains(termoPesquisa) || observacao.Contains(termoPesquisa))
                            pedidos.Add(pedidoOrcamento);

                }

                if (pedidos.Count == quantidadeRegistros)
                    return pedidos;

            }

            return pedidos;
        }

        public IList<PedidoOrcamento> ObterUltimosPedidosOrcamentoPorCategoriaPorCidadePorAnoMes(int quantidade, int mes, int ano, int cidade, Categoria categoria)
        {

            IList<PedidoOrcamento> pedidos = context.Repository<PedidoOrcamento>().Where(y => y.Ano == ano && y.Mes == mes && y.Categorias.Contains(categoria)).OrderByDescending(x => x.Data).ToList();

            return pedidos;
        }

        public void RemoverPedidosOrcamentoDuplicados()
        {
            MySqlConnection conexao = null;
            MySqlCommand comando = null;

            try
            {
                conexao = new MySqlConnection(Config.ConexaoBanco);
                conexao.Open();
                comando = new MySqlCommand(@"DELETE FROM	PEDIDO_ORCAMENTO
											WHERE 		CD_PEDIDO_ORCAMENTO IN
											(
											SELECT 		CD_PEDIDO_ORCAMENTO
											FROM
											(
											SELECT		CD_PEDIDO_ORCAMENTO
											FROM		PEDIDO_ORCAMENTO
											GROUP BY	DATE(DT_CADASTRO)
													, NM_COMPRADOR
													, EMAIL
													, TITULO
													, OBSERVACAO
													, CD_CATEGORIA
											HAVING		COUNT(CD_PEDIDO_ORCAMENTO)>=2
											) AS PEDIDO_ORCAMENTO_TEMP
											);", conexao);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
            finally
            {
                if (comando != null) comando.Dispose();
                if (conexao != null)
                {
                    if (conexao.State == System.Data.ConnectionState.Open) conexao.Close();
                    conexao.Dispose();
                }
            }
        }


        /// <summary>
        /// Valida os campos em server side
        /// </summary>
        /// <param name="camposInvalidos">Nomes dos campos inválidos, concatenados por ','</param>
        /// <returns></returns>
        public bool ValidarDados(ref string camposInvalidos
            , IList<Categoria> subCategorias
            , string titulo
            , string descricao)
        {
            try
            {
                ValidadorDados validador = new ValidadorDados();
                camposInvalidos = String.Empty;

                if (subCategorias == null)
                {
                    this.AdicionarCampoInvalido(ref camposInvalidos, "Ramo de Atividade");
                }

                if (!validador.ValidarTextoLivre(titulo, 5, 100))
                {
                    this.AdicionarCampoInvalido(ref camposInvalidos, "Título");
                }

                if (!validador.ValidarXSS(descricao))
                {
                    this.AdicionarCampoInvalido(ref camposInvalidos, "Descrição");
                }

                if (!String.IsNullOrEmpty(camposInvalidos))
                {
                    camposInvalidos = "Preenchimento inválido: " + camposInvalidos;
                }

                return (camposInvalidos == String.Empty);
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        public PedidoOrcamento ObterPedidoOrcamentoPorEmail(string email)
        {
            return context.Repository<PedidoOrcamento>().Where(x => x.Email == email).OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public PedidoOrcamento ObterPedidoOrcamentoPorEmailId(string email, int idPedido)
        {
            return context.Repository<PedidoOrcamento>().Where(x => x.Email == email && x.Id == idPedido).FirstOrDefault();
        }

        public IList<PedidoOrcamento> ObterPedidosOrcamentoPorIntervaloDeData(DateTime dataIncio, DateTime dataFim)
        {
            return context.Repository<PedidoOrcamento>().Where(x => x.Data >= dataIncio && x.Data <= dataFim).ToList();
        }
        public IList<PedidoOrcamento> ObterPedidosOrcamentoPorDataAlteracao(DateTime dateTime)
        {
            return context.Repository<PedidoOrcamento>().ToList().Where(x => x.DataAlteracao.DayOfYear == dateTime.DayOfYear && x.StatusPedidoComprador != 0).ToList();
        }

        public string GerarHTMLUltimosPedidos(int quantidadeRegistros, string termoPesquisa)
        {
            StringBuilder htmlResultado = new StringBuilder();
            htmlResultado.Append("<ul class='iconBulletList'>");

            IList<PedidoOrcamento> ultimosPedidos = new List<PedidoOrcamento>();
            ultimosPedidos = ObterUltimosPedidosOrcamento(quantidadeRegistros, termoPesquisa);

            foreach (PedidoOrcamento pedido in ultimosPedidos)
            {
                htmlResultado.Append("<li><img src='/img/marcador-orcamento-online.png' alt='Marcador do Orçamento Online' class='fl' />");

                htmlResultado.Append("<h4 style='margin-top: 16px; margin-left: 50px;'>Pedido de Orçamento Online e Cotação de Preço para " + pedido.Titulo + "</h4>");
                htmlResultado.Append("<p>");
                htmlResultado.Append(pedido.Observacao.Replace(Environment.NewLine, "<br />"));
                htmlResultado.Append("Solicitado em " + String.Format("{0:dd/MM/yyyy}", pedido.Data) + "<br />");
                htmlResultado.Append(pedido.Cidade.Nome + " (" + pedido.Cidade.Uf + ") ");
                htmlResultado.Append("</p>");

                htmlResultado.Append("</li>");
            }

            htmlResultado.Append("</ul>");
            return htmlResultado.ToString();
        }

        public PedidoOrcamento Inserir(PedidoOrcamento pedidoOrcamento)
        {
            string camposInvalidos = String.Empty;

            if (!this.ValidarDados(ref camposInvalidos
                , pedidoOrcamento.Categorias
                , pedidoOrcamento.Titulo
                , pedidoOrcamento.Observacao)) return null;

            try
            {
                pedidoOrcamento.Data = DateTime.Now;
                pedidoOrcamento.StatusPedidoComprador = 0;
                pedidoOrcamento.Status = PedidoStatus.EmailNaoValidado;
                context.Insert(pedidoOrcamento);
            }
            catch
            {
                pedidoOrcamento = null;
            }

            return pedidoOrcamento;
        }

        public bool ResponderPesquisaSatisfacao(ref string camposInvalidos, string email, int idPedidoOrcamento, int idStatus, string opiniaoComprador, string pontosMelhoria, int gostou, bool pesquisaRevisada)
        {
            try
            {
                ValidadorDados validador = new ValidadorDados();
                camposInvalidos = String.Empty;

                if (opiniaoComprador.Trim() != String.Empty)
                {
                    if (!validador.ValidarTextoLivre(opiniaoComprador, 8, 500))
                    {
                        this.AdicionarCampoInvalido(ref camposInvalidos, "O que foi bom");
                    }
                }
                if (pontosMelhoria.Trim() != String.Empty)
                {
                    if (!validador.ValidarTextoLivre(pontosMelhoria, 8, 500))
                    {
                        this.AdicionarCampoInvalido(ref camposInvalidos, "O que pode ser melhorado");
                    }
                }
                if (!String.IsNullOrEmpty(camposInvalidos))
                {
                    camposInvalidos = "Preenchimento inválido: " + camposInvalidos;
                    return false;
                }
                else
                {
                    // verifica se já foi respondida
                    PedidoOrcamento pedidoOrcamento = this.ObterPedidoOrcamentoPorEmailId(email, idPedidoOrcamento);
                    if (pedidoOrcamento.PesquisaRespondida)
                    {
                        camposInvalidos = "Pesquisa já respondida.";
                        return false;
                    }

                    string statusComprador = Enum.GetName(typeof(PedidoCompradorStatus), idStatus);

                    pedidoOrcamento.StatusPedidoComprador = (PedidoCompradorStatus)Enum.Parse(typeof(PedidoCompradorStatus), statusComprador);
                    pedidoOrcamento.OpiniaoComprador = opiniaoComprador;
                    pedidoOrcamento.PontosMelhoria = pontosMelhoria;
                    pedidoOrcamento.Gostou = (gostou == 1);
                    pedidoOrcamento.PesquisaRespondida = true;
                    pedidoOrcamento.DataAlteracao = DateTime.Today;
                    pedidoOrcamento.PesquisaRevisada = pesquisaRevisada;

                    Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                    chavesValores.Add("<!--TITULO-->", pedidoOrcamento.Titulo);
                    chavesValores.Add("<!--NOME_COMPRADOR-->", pedidoOrcamento.NomeComprador);
                    chavesValores.Add("<!--EMAIL_COMPRADOR-->", pedidoOrcamento.Email);
                    chavesValores.Add("<!--TELEFONE_COMPRADOR-->", pedidoOrcamento.Telefone);
                    chavesValores.Add("<!--CIDADE-->", pedidoOrcamento.Cidade.Nome);
                    chavesValores.Add("<!--UF-->", pedidoOrcamento.Cidade.Uf.ToString());
                    chavesValores.Add("<!--OBSERVACAO-->", pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />"));
                    chavesValores.Add("<!--STATUS_PEDIDO-->", pedidoOrcamento.StatusPedidoCompradorTitulo);
                    chavesValores.Add("<!--OPINIAO_CLIENTE-->", pedidoOrcamento.OpiniaoComprador.Replace(Environment.NewLine, "<br />"));
                    chavesValores.Add("<!--PONTOS_MELHORIA-->", pedidoOrcamento.PontosMelhoria.Replace(Environment.NewLine, "<br />"));

                    if (pedidoOrcamento.Gostou)
                    {
                        chavesValores.Add("<!--GOSTOU-->", "Sim.");
                    }
                    else
                    {
                        chavesValores.Add("<!--GOSTOU-->", "Não.");
                    }
                    string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailPesquisaSatisfacaoPreenchidaPorComprador);
                    //Fabrício - forçado para "orcamentos.net@gmail.com", devido à necessidade de autenticação no 
                    //domínio @oficial.blog.br quando o destinatário é do SMPT de @oficial.blog.br
                    Email.EnviarEmail("orcamentos.net@gmail.com", "orcamentos.net@gmail.com", Config.EmailAdministrador, htmlEmail, "Pesquisa de Satisfação - Comprador - " + pedidoOrcamento.NomeComprador, false, true, null, String.Empty);
                    return true;
                }
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        public IList<PedidoOrcamento> ObterComComentariosEstadoCidadePorCategoria(int quantidadeDePedidos, int idCategoria, int idCidade, int idMes)
        {
            Categoria categoria = context.Repository<Categoria>().Where(x => x.Id == idCategoria).FirstOrDefault();
            IList<PedidoOrcamento> ultimosPedidosComDepoimento = new List<PedidoOrcamento>();

            string uf = Enum.GetName(typeof(UF), idCidade);

            if (idMes != 0)
            {
                ultimosPedidosComDepoimento = ObterUltimosPedidosDoMes(quantidadeDePedidos, idMes, categoria);
            }

            if (categoria.Pai.Id == 0 && uf != null)
            {
                ultimosPedidosComDepoimento = ObterUltimosPedidosPorEstado(quantidadeDePedidos, categoria, (UF)Enum.Parse(typeof(UF), uf));
            }

            if (uf == null)
            {
                ultimosPedidosComDepoimento = ObterUltimosDepoimentosPorCidade(quantidadeDePedidos, categoria, idCidade);
            }

            return ultimosPedidosComDepoimento.OrderByDescending(x => x.Data).ToList();
        }

        public IList<PedidoOrcamento> ObterUltimosPedidosPorEstado(int quantidadeDePedidos, Categoria categoria, UF uf)
        {
            IList<PedidoOrcamento> ultimosPedidosComDepoimento = new List<PedidoOrcamento>();

            IList<PedidoOrcamento> pedidos = context.Repository<PedidoOrcamento>().Where(x => x.PesquisaRevisada == true && x.OpiniaoComprador != "" && x.Gostou == true).Take(200).ToList();

            IList<Cidade> cidades = context.Repository<Cidade>().Where(x => x.Uf == uf).ToList();

            foreach (PedidoOrcamento pedidoOrcamento in pedidos)
            {
                foreach (Cidade cidade in cidades)
                {
                    foreach (Categoria itemCategoria in categoria.SubCategorias)
                    {
                        if (ultimosPedidosComDepoimento.Count < quantidadeDePedidos && pedidoOrcamento.Cidade == cidade && pedidoOrcamento.Categorias.Contains(itemCategoria) && !ultimosPedidosComDepoimento.Contains(pedidoOrcamento))
                        {
                            ultimosPedidosComDepoimento.Add(pedidoOrcamento);
                        }
                    }
                }
            }

            return ultimosPedidosComDepoimento;
        }

        private IList<PedidoOrcamento> ObterUltimosDepoimentosPorCidade(int quantidadeDePedidos, Categoria categoria, int idCidade)
        {
            IList<PedidoOrcamento> ultimosPedidosComDepoimento = new List<PedidoOrcamento>();

            IList<PedidoOrcamento> pedidos = context.Repository<PedidoOrcamento>().Where(x => x.PesquisaRevisada == true && x.OpiniaoComprador != "" && x.Gostou == true && x.Cidade.Id == idCidade).Take(200).ToList();

            foreach (PedidoOrcamento pedidoOrcamento in pedidos)
            {
                foreach (Categoria itemCategoria in categoria.SubCategorias)
                {
                    if (ultimosPedidosComDepoimento.Count < quantidadeDePedidos && pedidoOrcamento.Categorias.Contains(itemCategoria) && !ultimosPedidosComDepoimento.Contains(pedidoOrcamento))
                    {
                        ultimosPedidosComDepoimento.Add(pedidoOrcamento);
                    }
                }
            }

            return ultimosPedidosComDepoimento;
        }

        public IList<PedidoOrcamento> ObterUltimosPesquisaRespondidaPedidosDasCidadesDoFornecedor(int quantidadeDePedidos, Categoria categoria, Fornecedor fornecedor, PedidoCompradorStatus pedidoCompradorStatus)
        {
            IList<PedidoOrcamento> ultimosPedidosComDepoimento = new List<PedidoOrcamento>();

            IList<PedidoOrcamento> pedidos = context.Repository<PedidoOrcamento>()
                .Where(x => x.PesquisaRevisada == true &&
                x.OpiniaoComprador != "" &&
                x.StatusPedidoComprador == pedidoCompradorStatus)
                .Take(200).ToList();

            foreach (PedidoOrcamento pedidoOrcamento in pedidos)
            {
                foreach (Cidade cidade in fornecedor.Cidades)
                {
                    if (pedidoOrcamento.Cidade.Id == cidade.Id && ultimosPedidosComDepoimento.Count < quantidadeDePedidos && !ultimosPedidosComDepoimento.Contains(pedidoOrcamento))
                    {
                        ultimosPedidosComDepoimento.Add(pedidoOrcamento);
                    }
                    //foreach (Categoria itemCategoria in fornecedor.SubCategorias)
                    //{
                    //    if (ultimosPedidosComDepoimento.Count < quantidadeDePedidos && pedidoOrcamento.Cidade == cidade && pedidoOrcamento.Categorias.Contains(itemCategoria) && !ultimosPedidosComDepoimento.Contains(pedidoOrcamento))
                    //    {
                    //        ultimosPedidosComDepoimento.Add(pedidoOrcamento);
                    //    }
                    //}
                }
            }

            return ultimosPedidosComDepoimento.OrderByDescending(x => x.Data).ToList();
        }

        private IList<PedidoOrcamento> ObterUltimosPedidosDoMes(int quantidadeDePedidos, int idMes, Categoria categoria)
        {
            IList<PedidoOrcamento> ultimosPedidosComDepoimento = new List<PedidoOrcamento>();

            IList<PedidoOrcamento> pedidos;
            pedidos = context.Repository<PedidoOrcamento>().ToList().Where(x => x.Mes == idMes).ToList().Where(x => x.PesquisaRevisada == true && x.OpiniaoComprador != "" && x.Gostou == true).Take(200).ToList();

            foreach (PedidoOrcamento pedidoOrcamento in pedidos)
            {
                foreach (Categoria itemCategoria in categoria.SubCategorias)
                {
                    if (ultimosPedidosComDepoimento.Count < quantidadeDePedidos && pedidoOrcamento.Categorias.Contains(itemCategoria) && !ultimosPedidosComDepoimento.Contains(pedidoOrcamento))
                    {
                        ultimosPedidosComDepoimento.Add(pedidoOrcamento);
                    }
                }
            }
            return pedidos;
        }

        public IList<PedidoOrcamento> ObterComComentarios(int quantidadeDePedidos, int idCategoria)
        {

            Categoria categoria = context.Repository<Categoria>().Where(x => x.Id == idCategoria).FirstOrDefault();

            if (categoria != null)
            {
                IList<PedidoOrcamento> pedidos = context.Repository<PedidoOrcamento>().Where(x => x.PesquisaRevisada == true && x.OpiniaoComprador != "" && x.Gostou == true).Take(200).ToList();

                IList<PedidoOrcamento> ultimosPedidosComDepoimento = new List<PedidoOrcamento>();

                foreach (Categoria itemCategoria in categoria.SubCategorias)
                {
                    foreach (PedidoOrcamento itemPedidoOrcamento in pedidos)
                    {
                        if (ultimosPedidosComDepoimento.Count <= quantidadeDePedidos && itemPedidoOrcamento.Categorias.Contains(itemCategoria) && !ultimosPedidosComDepoimento.Contains(itemPedidoOrcamento))
                        {
                            ultimosPedidosComDepoimento.Add(itemPedidoOrcamento);
                        }
                    }
                }

                if ((ultimosPedidosComDepoimento != null) && (ultimosPedidosComDepoimento.Count > 0))
                {
                    ultimosPedidosComDepoimento = ultimosPedidosComDepoimento.OrderByDescending(x => x.Data).ToList();
                }
                return ultimosPedidosComDepoimento.OrderByDescending(x => x.Data).ToList();
            }
            else
            {

                return context.Repository<PedidoOrcamento>().Where(x => x.PesquisaRevisada == true && x.OpiniaoComprador != "" && x.Gostou == true).Take(quantidadeDePedidos).OrderByDescending(x => x.Data).ToList();
            }
        }

        public PedidoOrcamento ObterUltimoPedidoDoEmail(string emailComprador)
        {
            IList<PedidoOrcamento> pedidos = context.Repository<PedidoOrcamento>().Where(x => x.Email == emailComprador).ToList();

            return pedidos[pedidos.Count - 1];
        }
        public IList<PedidoOrcamento> ObterPedidosOrcamentoPorDataStatus(DateTime dataPedidoOrcamento, PedidoStatus status)
        {
            IList<PedidoOrcamento> pedidos = context.Repository<PedidoOrcamento>().ToList()
               .Where(x => x.Data.DayOfYear == dataPedidoOrcamento.DayOfYear && x.Data.Year == dataPedidoOrcamento.Year && x.Status == status).ToList();

            return pedidos;
        }


        #endregion

        public IList<PedidoOrcamento> ObterPedidosPorCategoriaCidade(int idMes, IList<Categoria> categorias, int idCidade)
        {
            DateTime dataInicio = DateTime.Now.AddDays(-15);
            DateTime dataFim = DateTime.Now;

            IList<PedidoOrcamento> pedidos = ObterPedidosOrcamentoPorIntervaloDeData(dataInicio, dataFim);
            pedidos = pedidos.Where(x => x.Cidade.Id == idCidade).ToList();

            IList<PedidoOrcamento> pedidosResultado = new List<PedidoOrcamento>();

            foreach (Categoria categoria in categorias)
            {
                foreach (PedidoOrcamento pedido in pedidos)
                {
                    foreach (Categoria categoriaPedido in pedido.Categorias)
                    {
                        if (categoriaPedido.Id == categoria.Id && !pedidosResultado.Contains(pedido))
                        {
                            pedidosResultado.Add(pedido);
                        }
                    }
                }

            }
            return pedidosResultado;
        }

        public IList<PedidoOrcamento> ObterUltimosPedidosPorCategoriaComImagem(int idCategoria)
        {
            IList<PedidoOrcamento> pedidosComFoto = new List<PedidoOrcamento>();
            PedidoOrcamento pedidoOrcamento;

            //Pedidos Com Foto da Home
            if (idCategoria == 0)
            {
                pedidoOrcamento = new PedidoOrcamento();
                pedidoOrcamento.Titulo = "Orçamento de Pintura Externa de 38 Sobrados em São Paulo";
                pedidoOrcamento.FotoPrincipal = "e6b158ea-a4f6-492d-9015-dda57da44da6.png";
                pedidoOrcamento.Observacao = "Solicito um orçamento de pintura externa de 38 sobrados (frente, fundos e laterais) em um condomínio localizado no litoral cidade de Mongaguá." +
                " 38 sobrados (frente, fundos e laterais).	Telhas dos sobrados,Área de lazer e portaria. Muros da frente e fundos do Condomínio por dentro e fora. Seguem as medidas 38 Sobrados Área Total de 37,00 M2 - (PAV. TERREO 4 x 9,25 ) Área Total de 37,00 M2 - (PAV. SUPERIOR 4 x 9,25) Total 38 Unidades 2812.00 M2 Área de lazer 127,40 M2 - 13 X 9,80 Guarita (Portaria) 30 M2 - 5 X 6,00 Muros da frente e fundos do Condomínio 50 M2 " +
                 Environment.NewLine +
                "Prefere receber visita técnica no(s) dia(s): Segunda-Feira,  Terça-Feira,  Quarta-Feira";

                pedidosComFoto.Add(pedidoOrcamento);

                pedidoOrcamento = new PedidoOrcamento();
                pedidoOrcamento.FotoPrincipal = "f73e1d45-cc68-4f23-b772-505f869c6596.jpg";
                pedidoOrcamento.Titulo = "Orçamento Pintura e Pintor Profissional 29 prédios em São Paulo";
                pedidoOrcamento.Observacao = "Contratante: pessoa jurídica" +
                     Environment.NewLine +
                " Orçar dividindo por unidade a quantidade de 29 prédios em geral sendo 05 de cinco andares e demais de 06 andares em execução com lavagem externa a base de cloro em geral e aplicação de fundo preparador a base de solvente após secagem e aplicação de látex acr. fosco cor clara (Coral) e pintura interna em ótimo estado detalhes pequenos para correção de massa corrida." +
                 Environment.NewLine +
                " Bairro, região ou local: São Paulo." +
                 Environment.NewLine +
                " Materiais: A empresa deve fornecer os materiais" +
                 Environment.NewLine +
                " Tipo de imóvel: Apartamento padrão" +
                 Environment.NewLine +
                " Metros quadrados (aproximado): 1200" +
                 Environment.NewLine +
                " Prefere ligações no período: Tarde";

                pedidosComFoto.Add(pedidoOrcamento);


                pedidoOrcamento = new PedidoOrcamento();
                pedidoOrcamento.FotoPrincipal = "39ea7cd9-df05-430a-93cf-5053c8468e90.jpg";
                pedidoOrcamento.Titulo = "Orçamento de pintura  interna comum no Rio de Janeiro";
                pedidoOrcamento.Observacao = "Contratante: pessoa física" +
                    Environment.NewLine +
                    "120m2 de paredes com pintura em latex acrílico (corrigir algumas trincas de reboco e danos de vazamento, conforme imagens em anexo) + 38m2 de Tetos em PVA branco fosco. " +
                    Environment.NewLine +
                    "Bairro, região ou local: santa cecília " +
                    Environment.NewLine +
                    "Materiais: A empresa deve fornecer os materiais " +
                        Environment.NewLine +
                    "Tipo de imóvel: Apartamento padrão " +
                        Environment.NewLine +
                    "Metros quadrados (aproximado): 158 " +
                        Environment.NewLine +
                    "Prefere ligações no período: Manhã";
                pedidosComFoto.Add(pedidoOrcamento);


                pedidoOrcamento = new PedidoOrcamento();
                pedidoOrcamento.FotoPrincipal = "faa3562e-54e7-4e31-8fe8-c3975fe468dc.jpg";
                pedidoOrcamento.Titulo = "Preço móveis para escritório no Rio de Janeiro";
                pedidoOrcamento.Observacao = "Móveis Planejados e Sob Medida: móveis planejados escritórios" +
                    Environment.NewLine +
                "Contratante: pessoa jurídica" +
                "NÃO INCLUIR NO ORÇAMENTO OS ARQUIVOS." +
                    Environment.NewLine +
                "Bairro, região ou local: MEIER" +
                    Environment.NewLine +
                "Prefere ligações no período: Manhã" +
                    Environment.NewLine +
                "Prefere receber visita técnica no(s) dia(s): Segunda-Feira,  Terça-Feira,  Quarta-Feira,  Quinta-Feira,  Sexta-Feira,  Sábado,  Domingo";


                pedidosComFoto.Add(pedidoOrcamento);


                pedidoOrcamento = new PedidoOrcamento();
                pedidoOrcamento.Titulo = "Orçamento para limpeza de fachada em São Paulo";
                pedidoOrcamento.FotoPrincipal = "50256559-ecd1-46be-a61d-480abc709fcd.jpg";
                pedidoOrcamento.Observacao = "Pintura e Limpeza de Fachadas Prediais: lavagem de fachadas. Nosso prédio tem 5 andares " +
                Environment.NewLine +
                "Bairro, região ou local: Bairro: Barra Funda- São Paulo capital " +
                Environment.NewLine +
                "Materiais: A empresa deve fornecer os materiais " +
                Environment.NewLine +
                "Tipo de imóvel: Prédio Comercial " +
                Environment.NewLine +
                "Metros quadrados (aproximado): 7.570,18 " +
                Environment.NewLine +
                "Prefere ligações no período: Manhã " +
                Environment.NewLine +
                "Prefere receber visita técnica no(s) dia(s): Segunda-Feira, Terça-Feira, Quarta-Feira, Quinta-Feira"
                + Environment.NewLine;

                pedidosComFoto.Add(pedidoOrcamento);

                pedidoOrcamento = new PedidoOrcamento();
                pedidoOrcamento.FotoPrincipal = "f724b06c-79bb-4710-96d4-71034ecb791b.jpg";
                pedidoOrcamento.Titulo = "Preço móveis planejados reforma banheiro no Rio de Janeiro";
                pedidoOrcamento.Observacao = "Armario p/ banheiro balcão pia: " +
                Environment.NewLine +
                "Profundidades: 0,50 (portas) e 0,25 cm (gavetas)" +
                Environment.NewLine +
                "Largura portas: 0,97" +
                "Largura gavetas: 0,325 cm" +
                "Largura total (atrás) 1,17" +
                "Altura: 0,61" +
                "Armário sobre a pia:" +
                 Environment.NewLine +
                " 2 nichos de 0,25 de largura x 0,21 profundidade x 1,03 de altura" +
                " espelho no meio....largura total: 1,16" +
                " cor branco fosco, posso enviar as fotos por e-mail" +
                 Environment.NewLine +
                " Tipo de imóvel: Apartamento padrão" +
                 Environment.NewLine +
                " Prefere ligações no período: Tarde" +
                 Environment.NewLine +
                " Prefere receber visita técnica no(s) dia(s): Segunda-Feira";

                pedidosComFoto.Add(pedidoOrcamento);


                pedidoOrcamento = new PedidoOrcamento();
                pedidoOrcamento.FotoPrincipal = "c1ea1d00-e176-4e77-83c2-7547dfc825e7.jpg";
                pedidoOrcamento.Titulo = "Preço Pisos e Azulejos: cimento queimado em São Paulo";
                pedidoOrcamento.Observacao = "Contratante: pessoa jurídica" +
                Environment.NewLine +
                "Há um piso existente no local mas vou retirá-lo para ser instalado o cimento queimado." +
                "A foto em anexo é uma referência de como quero o efeito do cimento queimado." +
                 Environment.NewLine +
                 Environment.NewLine +
                "Bairro, região ou local: Santa Terezinha, Santo André" +
                 Environment.NewLine +
                "Materiais: A empresa deve fornecer os materiais" +
                 Environment.NewLine +
                "Tipo de imóvel: Loja ou Comércio" +
                 Environment.NewLine +
                "Metros quadrados (aproximado): 71,36" +
                 Environment.NewLine +
                "Prefere ligações no período: Tarde" +
                 Environment.NewLine +
                "Prefere receber visita técnica no(s) dia(s): Segunda-Feira, Terça-Feira, Quarta-Feira," +
                "Quinta-Feira, Sexta-Feira";

                pedidosComFoto.Add(pedidoOrcamento);

                pedidoOrcamento = new PedidoOrcamento();
                pedidoOrcamento.Titulo = "Orçamento Manutenção Predial - Este orçamento é a base para uma futura licitação em São Paulo";
                pedidoOrcamento.FotoPrincipal = "0a402396-3c9c-4489-ada9-2ba6ee42ec26.jpg";
                pedidoOrcamento.Observacao = "Pintura e Limpeza de Fachadas Prediais: pintura predial ou fachada; rejuntamento, trincas, fissuras, tratamento de concreto ou impermeabilização " +
                " São 8 blocos de 4 pavimentos para tratamento de juntas de dilatação das fachadas (1.425,12 m)e possterior impermeabilização e pintura das fachadas (5.841,25 m2)mais pintura de 1 guarita (82,97 m2), pintura do salão de festas (140,07 m2)e impermeabilização de uma laje do salão de festas (16,26 m2) " +
                Environment.NewLine +
                "Materiais: A empresa deve fornecer os materiais " +
                Environment.NewLine +
                "Tipo de imóvel: Prédio Residencial " +
                Environment.NewLine +
                "Metros quadrados (aproximado): 5841,25 " +
                Environment.NewLine +
                "Prefere ligações no período: Manhã " +
                Environment.NewLine +
                "Prefere receber visita técnica no(s) dia(s): não informado";

                pedidosComFoto.Add(pedidoOrcamento);
            }
            else
            {
                IList<PedidoOrcamento> pedidosComFotosDeTodasCategorias = context.Repository<PedidoOrcamento>().Where(x => x.AprovadoParaSite == true).ToList();

                foreach (PedidoOrcamento item in pedidosComFotosDeTodasCategorias)
                {
                    foreach (Categoria itemCategoria in item.Categorias)
                    {
                        if (itemCategoria.Id == idCategoria)
                        {
                            pedidosComFoto.Add(item);
                        }
                    }
                }
            }
            return pedidosComFoto;
        }

        public IList<PedidoOrcamento> ObterUltimosComentariosQueGostaram()
        {
            return context.Repository<PedidoOrcamento>().Where(x => x.Gostou == true && x.OpiniaoComprador != "").OrderByDescending(x => x.Id).Take(40).ToList();
        }


        public ClassificacaoPedido ObterClassificacaoPedido(PedidoOrcamento pedidoOrcamento)
        {

            if (pedidoOrcamento.Fotos != null ||
                pedidoOrcamento.Status == PedidoStatus.EmailValidado ||
                    (pedidoOrcamento.PretensaoServico != 3 && PassouNaValidacao(pedidoOrcamento.Telefone))
                )
                return ClassificacaoPedido.Prata;

            if (pedidoOrcamento.Status == PedidoStatus.EmailValidado
                && pedidoOrcamento.Fotos != null
                && pedidoOrcamento.PretensaoServico != 3
                && PassouNaValidacao(pedidoOrcamento.Telefone))
                return ClassificacaoPedido.Ouro;

            if (pedidoOrcamento.Status == PedidoStatus.EmailValidado
                && pedidoOrcamento.Fotos != null
                && pedidoOrcamento.PretensaoServico != 3
                && PassouNaValidacao(pedidoOrcamento.Telefone)
                && pedidoOrcamento.PessoaTipo == PessoaTipo.Juridica)
                return ClassificacaoPedido.Diamante;

            return ClassificacaoPedido.Bronze;
        }

        private bool PassouNaValidacao(string telefone)
        {
            if (telefone.Contains("000")) return false;
            if (telefone.Contains("111")) return false;
            if (telefone.Contains("1212")) return false;           
            if (telefone.Contains("222")) return false;
            if (telefone.Contains("333")) return false;
            if (telefone.Contains("444")) return false;
            if (telefone.Contains("555")) return false;
            if (telefone.Contains("666")) return false;
            if (telefone.Contains("777")) return false;
            if (telefone.Contains("888")) return false;
            if (telefone.Contains("999")) return false;
            if (telefone.Contains("1234")) return false;

            return true;

        }

        private string AcertarEmail(string email)
        {
            string emailCorrigido = email;

            string[] emailSplit = email.Split('@');
            string dominioEmail = emailSplit[1];

            if (dominioEmail.Equals("gmil.com") || dominioEmail.Equals("gamil.com") || dominioEmail.Equals("gmail.com.br"))
            {
                emailCorrigido = emailSplit[0] + "@gmail.com";

            }

            if (dominioEmail.Equals("homail.com") || dominioEmail.Equals("hotail.com"))
            {
                emailCorrigido = emailSplit[0] + "@hotmail.com";

            }


            return emailCorrigido;


        }
    }
}


