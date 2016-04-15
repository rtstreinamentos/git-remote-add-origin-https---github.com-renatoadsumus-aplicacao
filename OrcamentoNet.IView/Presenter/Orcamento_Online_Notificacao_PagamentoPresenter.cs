using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Common;
using OrcamentoNet.Entity._enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;

namespace OrcamentoNet.IView.Presenter
{
    public class Orcamento_Online_Notificacao_PagamentoPresenter
    {
        public IOrcamento_Online_Notificacao_Pagamento View { get; set; }

        [Inject]
        public IFornecedorService fornecedorService
        { get; set; }

        [Inject]
        public ICompraAvulsaService compraAvulsaService
        { get; set; }

        [Inject]
        public IMensalidadeService mensalidadeService
        { get; set; }


        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void ConfirmarPagamento()
        {
            bool ehCompraAvulsa = true;
            int dias = 0;

            if (View.IdPedidoOrcamento == 1)
            {
                dias = 31;
                ehCompraAvulsa = false;
            }

            if (View.IdPedidoOrcamento == 3)
            {
                dias = 121;
                ehCompraAvulsa = false;
            }

            if (View.IdPedidoOrcamento == 8)
            {
                dias = 365;
                ehCompraAvulsa = false;
            }

            Fornecedor fornecedor = fornecedorService.ObterPorEmail(View.EmailComprador);           

            if (!ehCompraAvulsa)
            {
                if (fornecedor != null)
                {
                    if (fornecedor.DataAlteracao > DateTime.Now && fornecedor.Status == Status.Cliente)
                        fornecedor.DataAlteracao = fornecedor.DataAlteracao.AddDays(dias);
                    else
                        fornecedor.DataAlteracao = DateTime.Now.AddDays(dias);

                    fornecedor.Status = Status.Cliente;
                    fornecedor.ValorMensalidade = fornecedor.ValorMensalidadeAlteracao;
                    fornecedor.TipoPessoaAtendimento = fornecedor.TipoPessoaAtendimentoAlteracao;

                    EnviarEmailConfirmacaoPagamento(fornecedor);
                    EnviarUltimosPedidos(fornecedor);

                    Mensalidade mensalidade = new Mensalidade();
                    mensalidade.Fornecedor = fornecedor.Id;
                    mensalidade.Data = DateTime.Now;
                    mensalidadeService.Inserir(mensalidade);
                }
                else
                {
                    NotificarFornecedorEmailNaoIdentificado();
                }
            }
            else
            {
                NotificarFornecedorCompraAvulsa();

                if (fornecedor != null)
                {
                    NotificarCompradorPedidoFoiLidoPorUmFornecedor(fornecedor);
                    NotificarFornecedorDescontoPorTerFeitoCompraAvulsa(fornecedor);
                }

                CompraAvulsa compraAvulsa = new CompraAvulsa();
                compraAvulsa.Fornecedor = fornecedor.Id;
                compraAvulsa.Data = DateTime.Now;

                compraAvulsaService.Inserir(compraAvulsa);
            }

            //notificar RD Station
            if (fornecedor != null)
            {
                //this.NotificarRDStation(fornecedor.Nome, fornecedor.Email, ehCompraAvulsa);
            }
        }

        private void NotificarFornecedorDescontoPorTerFeitoCompraAvulsa(Fornecedor fornecedor)
        {
            IList<CompraAvulsa> comprasAvulsas = compraAvulsaService.ObterPorId(fornecedor.Id);

            if (comprasAvulsas.Count() == 2)
            {
                double mensalidadComDesconto = fornecedor.ValorMensalidade / 2;
                Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                chavesValores.Add("<!--NOME-->", fornecedor.Nome);
                chavesValores.Add("<!--VALOR_MENSALIDADE_DESCONTO-->", String.Format("{0:0.00}", mensalidadComDesconto));
                chavesValores.Add("<!--URL-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + mensalidadComDesconto + "&id=" + fornecedor.Id + "&plano=1");

                string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailFornecedorPromocaoCompraAvulsa);

                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Mensagem Importante - Aproveite essa opotunidade! ", true, true, null, "");
            }

        }

        private void NotificarCompradorPedidoFoiLidoPorUmFornecedor(Fornecedor fornecedor)
        {
            PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Obter(View.IdPedidoOrcamento);

            if (pedidoOrcamento != null)
            {
                Dictionary<string, string> chavesValores = GerarHtmlPedido(pedidoOrcamento);

                chavesValores.Add("<!--NOME_FORNECEDOR-->", fornecedor.Nome);
                chavesValores.Add("<!--FICHA_TECNICA-->", fornecedor.UrlFichaTecnica);

                string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailInformativoCompradorPedidoComprado);

                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, pedidoOrcamento.Email, htmlEmail, "Mensagem Importante - Seu Pedido de Orçamento foi Visualizado", true, true, null, "");
            }

        }

        public void NotificarRDStation(string nomeFornecedor, string emailFornecedor, bool ehCompraAvulsa)
        {
            try
            {
                string identificador;
                if (ehCompraAvulsa)
                {
                    identificador = "avulso";
                }
                else
                {
                    identificador = "eh-cliente";
                }

                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create("http://www.rdstation.com.br/api/1.2/conversions");
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                string postData = "token_rdstation=a37b4425b5786360fa585f681fd0ff78&identificador=" + identificador + "&nome=" + nomeFornecedor + "&email_lead=" + emailFornecedor;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
        }

        public void RecuperarFornecedor()
        {
            //só envia se for mensalidade ou plano; 
            //avulso => sai do método
            if (!(View.IdPedidoOrcamento == 1 || View.IdPedidoOrcamento == 3 || View.IdPedidoOrcamento == 8)) return;

            Fornecedor fornecedor = fornecedorService.ObterPorEmail(View.EmailComprador);

            if (fornecedor != null)
            {
                IList<PedidoOrcamento> pedidoOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorData(DateTime.Now);

                IList<PedidoOrcamento> pedidoOrcamentoComDepoimento = pedidoOrcamentoService.ObterComComentarios(7, fornecedor.SubCategorias[0].Pai.Id);

                string htmlOpiniao = "";

                foreach (PedidoOrcamento pedido in pedidoOrcamentoComDepoimento)
                {
                    htmlOpiniao += "Solicitante:<b>" + pedido.NomeComprador + "</b><br/> O que foi bom?<br/>" +
                                   pedido.OpiniaoComprador.Replace(Environment.NewLine, "<br />") + "<br /><br />";
                }

                string valorMensalidade = String.Format("{0:#0.00}", fornecedor.ValorMensalidade).Replace(".", ",");
                string valorMensalidade3Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidade * 3).Replace(".", ",");
                string valorMensalidade8Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidade * 8).Replace(".", ",");

                Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                chavesValores.Add("<!--NOME-->", View.NomeComprador);
                chavesValores.Add("<!--OPINIAO_CLIENTE-->", htmlOpiniao);
                chavesValores.Add("<!--QTD_PEDIDOS-->", pedidoOrcamento.Count().ToString());
                chavesValores.Add("<!--VALOR_MENSALIDADE-->", valorMensalidade);
                chavesValores.Add("<!--VALOR_3MESES-->", valorMensalidade3Meses);
                chavesValores.Add("<!--VALOR_8MESES-->", valorMensalidade8Meses);
                chavesValores.Add("<!--URL-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + fornecedor.ValorMensalidade + "&id=" + fornecedor.Id + "&plano=1");
                chavesValores.Add("<!--URL_3MESES-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade3Meses + "&id=" + fornecedor.Id + "&plano=3");
                chavesValores.Add("<!--URL_8MESES-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade8Meses + "&id=" + fornecedor.Id + "&plano=8");

                string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailRecuperarPagamentoNaoRealizado);

                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, View.EmailComprador, htmlEmail, "Mensagem Importante - Orçamento Online", true, false, null, "");
            }
        }

        private void NotificarFornecedorEmailNaoIdentificado()
        {
            string htmlEmail = "Renato favor atualizar o fornecedor " + View.NomeComprador +
                " manualmente no sistema!";

            Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, Config.EmailAdministrador, htmlEmail, Config.NomeAplicacao + " - Cadastro Não Identificado", true, true, null, "");
        }

        private void NotificarFornecedorCompraAvulsa()
        {
            PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Obter(View.IdPedidoOrcamento);

            Dictionary<string, string> chavesValores = GerarHtmlPedido(pedidoOrcamento);

            chavesValores.Add("<!--NOME_FORNECEDOR-->", View.NomeComprador);

            string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailCompraAvulsa);

            Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, View.EmailComprador, htmlEmail, "Mensagem Importante - Compra Avulsa Pedido - " + pedidoOrcamento.Id, true, true, null, "");
        }

        private Dictionary<string, string> GerarHtmlPedido(PedidoOrcamento pedidoOrcamento)
        {
            string statusEmail = "(<strong>Email Validado!</strong>)";
            Dictionary<string, string> chavesValores = new Dictionary<string, string>();

            string htmlFoto = "";

            if (pedidoOrcamento.Fotos != null)
            {
                foreach (string foto in pedidoOrcamento.Fotos)
                {
                    htmlFoto = htmlFoto + "<li><a href='" + Config.UrlSite + "FotosComprador/" + foto + "'>" + foto + "</a></li>";
                }
                if (htmlFoto != "")
                {
                    htmlFoto = "<b>Fotos ou arquivos enviados:</b><br/><ul>" + htmlFoto + "</ul>";
                }
            }

            if (pedidoOrcamento.Status == PedidoStatus.EmailValidado)
            {
                chavesValores.Add("<!--STATUS_EMAIL-->", statusEmail);
            }

            string telefone = pedidoOrcamento.Telefone + " <b>Operadora:</b>" + pedidoOrcamento.TelefoneOperadora.ToUpper();

            chavesValores.Add("<!--NOME_COMPRADOR-->", pedidoOrcamento.NomeComprador);
            chavesValores.Add("<!--PEDIDO_ID-->", pedidoOrcamento.Id.ToString());
            chavesValores.Add("<!--EMAIL_COMPRADOR-->", pedidoOrcamento.Email);
            chavesValores.Add("<!--TELEFONE_COMPRADOR-->", telefone);
            chavesValores.Add("<!--CIDADE-->", pedidoOrcamento.Cidade.Nome);
            chavesValores.Add("<!--UF-->", pedidoOrcamento.Cidade.Uf.ToString());
            chavesValores.Add("<!--SERVICOS_SOLICITADOS-->", pedidoOrcamentoService.CategoriasDoPedidoSeparadasPorVirgula(pedidoOrcamento));
            chavesValores.Add("<!--TITULO-->", pedidoOrcamento.Titulo);
            chavesValores.Add("<!--OBSERVACAO-->", pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />"));
            chavesValores.Add("<!--ARQUIVOS_ENVIADOS-->", htmlFoto);

            return chavesValores;
        }

        private void EnviarEmailConfirmacaoPagamento(Fornecedor fornecedor)
        {
            Dictionary<string, string> chavesValores = new Dictionary<string, string>();
            chavesValores.Add("<!--NOME-->", fornecedor.Nome);
            chavesValores.Add("<!--VALOR_MENSALIDADE-->", String.Format("{0:0.00}", fornecedor.ValorMensalidade));
            chavesValores.Add("<!--DATA_VENCIMENTO-->", fornecedor.DataAlteracao.ToString("dd/MM/yyyy"));

            string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailConfirmandoPagamento);

            Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, Config.NomeAplicacao + " - Confirmação Pagamento", true, true, null, "");
        }

        private void EnviarUltimosPedidos(Fornecedor fornecedor)
        {
            string htmlEmail = "";
            string cabecalho = "Olá, " + fornecedor.Nome + "!<br /><br /><b>Seguem abaixo os últimos pedidos recebidos em nosso sistema:</b><br /><br />";
            string pedidoHtml = ObterHTMLUltimosPedidos(fornecedor, false);

            if (pedidoHtml != "")
            {
                htmlEmail = cabecalho + pedidoHtml;

                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "últimos pedidos de orçamento recebidos", true, true, null, "");
            }
        }

        private string ObterHTMLUltimosPedidos(Fornecedor fornecedor, bool truncaDados)
        {
            DateTime dataInicio = DateTime.Now.AddDays(-3);
            DateTime dataFim = DateTime.Now;
            IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorIntervaloDeData(dataInicio, dataFim);
            List<PedidoOrcamento> pedidosOrcamentoResultado = new List<PedidoOrcamento>();

            foreach (Cidade cidade in fornecedor.Cidades)
            {
                pedidosOrcamentoResultado.AddRange(pedidosOrcamento.Where(x => x.Cidade == cidade).ToList());
            }

            string pedidoHtml = "";
            string solicitante = "";
            string categoriaPedido = "";


            foreach (PedidoOrcamento pedidoOrcamento in pedidosOrcamentoResultado)
            {
                foreach (Categoria categoria in fornecedor.SubCategorias)
                {
                    if (pedidoOrcamento.Categorias.Contains(categoria))
                    {
                        categoriaPedido = categoriaPedido + categoria.Nome + ", ";

                        string emailValidado = "";

                        if (pedidoOrcamento.Status == PedidoStatus.EmailValidado)
                        {
                            emailValidado = " (<b>e-mail validado!</b>)";
                        }

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
                                htmlFoto = "<br /><b>Fotos enviadas pelo solicitante:</b><br/><ul>" + htmlFoto + "</ul>";
                            }
                        }

                        string telefone = pedidoOrcamento.Telefone + " <b>Operadora:</b>" + pedidoOrcamento.TelefoneOperadora.ToUpper();
                        string email = pedidoOrcamento.Email + emailValidado;

                        if (truncaDados)
                        {
                            telefone = pedidoOrcamento.Telefone.Substring(0, 7) + "-XXXX";
                            email = pedidoOrcamento.Email.Substring(0, 6) + "...@XXX.com";
                        }


                        solicitante = "Solicitante: " + pedidoOrcamento.NomeComprador +
                                     "<br />Telefone: " + telefone +
                                     "<br />Email: " + email +
                                     "<br />Cidade: " + pedidoOrcamento.Cidade.Nome +
                                     "<br />Titulo: " + pedidoOrcamento.Titulo +
                                     "<br />Observação: " + pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />") +
                                      htmlFoto +
                                     "<br /><br />";

                    }
                }

                if (solicitante != "")
                {
                    pedidoHtml = pedidoHtml + "<b>Pedido de Orçamento: </b>" + categoriaPedido + "<br>" + solicitante;
                }

                solicitante = "";
                categoriaPedido = "";
            }

            return pedidoHtml;

        }

        public void PedidoDePagamentoSolicitado()
        {
            Fornecedor fornecedor = fornecedorService.ObterPorEmail(View.EmailComprador);

            if (fornecedor != null)
            {
                string ultimosPedidoHtml = ObterHTMLUltimosPedidos(fornecedor, true);

                Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                chavesValores.Add("<!--NOME-->", fornecedor.Nome);
                chavesValores.Add("<!--ULTIMOS_PEDIDOS-->", ultimosPedidoHtml);

                string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailSolicitacaoPagamento);
                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Mensagem Importante - Pedidos para você Responder!", true, false, null, "");
            }
        }
    }
}
