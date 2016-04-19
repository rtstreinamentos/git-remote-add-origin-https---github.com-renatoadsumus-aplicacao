using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Common;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class ServicoNotificarFornecedorPresenter
    {
        #region Propriedades

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public IFornecedorCategoriaService fornecedorCategoriaService { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

        [Inject]
        public ICompraAvulsaService compraAvulsaService { get; set; }

        [Inject]
        public ISiteMapService siteMapService { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IPedidoEstatisticaService pedidoEstatisticaService { get; set; }

        [Inject]
        public IPedidoOrcamentoFornecedorService pedidoOrcamentoFornecedorService { get; set; }

        public log4net.ILog Log4Net { get; set; }
        #endregion

        #region Métodos Públicos
        public void InicializarServico()
        {
            this.Log4Net.Debug("Início");
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void AtualizarSiteMap()
        {
            this.Log4Net.Debug("Início");
            try
            {
                IList<Categoria> listaCategorias = new List<Categoria>();
                siteMapService.Gravar(listaCategorias);
            }
            catch (Exception e)
            {
                Erro.Logar(e);
            }
        }



        public ServicoNotificarFornecedorPresenter()
        {
            log4net.Config.XmlConfigurator.Configure();
            this.Log4Net = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void OnViewInitialized()
        {
            try
            {
                this.Log4Net.Debug("Início");
                this.InicializarServico();

               


                //TODO: está travando a geração do sitemap. Fazer refactoring
                // às 5h da manhã roda os serviços de frequência diária
                if (DateTime.Now.Hour == 19)
                {
                    //Envia Email Cobrando dos Fornecedores Explicação Por Que Não Teve Interesse
                    EnviarEmailParaForncedoresQueNaoResponderamOsPedidos();

                    // Atualiza as URLs das categorias
                    //this.AtualizarUrlCategoriasParaSeo();

                    //Atualiza o SiteMap
                   this.AtualizarSiteMap();
                }              

                if (DateTime.Now.Hour == 19)
                {
                  

                    //Envia email para os compradores com emails nao validados
                    DateTime dataDeOtem = DateTime.Now.AddDays(-1);
                    this.EnviarEmailCompradoresComEmailsNaoValidados(dataDeOtem);

                    DateTime dataDe3DiasAtras = DateTime.Now.AddDays(-3);
                    this.EnviarEmailCompradoresComEmailsNaoValidados(dataDe3DiasAtras);

                    //Envia email para os fornecedores com Status do Pedido Baseda na Pesquisa Satisfação
                    this.EnviarEmailStatusPedido();

                    //Envia um Email para Fornecedor não identificando o pagamento e desativa
                    this.EnviarEmailPagamentoNaoIdentificado();

                    //Envia um Email para Renato  com os indicadores de negocio da Semana
                    this.EnviarEmailIndicadoresNegocio();
                }

                // às 9h da manhã roda os serviços de frequência diária
                if (DateTime.Now.Hour == 19)
                {
                    this.EnviarEmailPesquisaSatisfacaoComprador();
                    //Envia um Email de Pesquisa de Satisfação para fornecedores cadastrados há 7, 37, 97 e 187 dias
                    // this.EnviarEmailPesquisaSatisfacaoFornecedor(DateTime.Now.AddDays(-7));
                    // this.EnviarEmailPesquisaSatisfacaoFornecedor(DateTime.Now.AddDays(-37));
                    // this.EnviarEmailPesquisaSatisfacaoFornecedor(DateTime.Now.AddDays(-97));
                    //  this.EnviarEmailPesquisaSatisfacaoFornecedor(DateTime.Now.AddDays(-187));
                    //Envia um Email de Lembrança com 7 dias antencedência
                    this.EnviarEmailLembreteVencimentoFornecedor(DateTime.Now.AddDays(7));
                    //Envia um Email de Lembrança com 2 dias antencedência
                    this.EnviarEmailLembreteVencimentoFornecedor(DateTime.Now.AddDays(2));
                }

                // estes são rodados de acordo com o agendamento do serviço
                this.EnviarIntegracoesEmail();
                //this.GravarEstatisticas();

                this.EnviarPedidosQueNaoForamDeInteresseParaOutrosFornecedores();
            }
            catch (Exception e)
            {
                Erro.Logar(e);
            }
        }

        private void EnviarPedidosQueNaoForamDeInteresseParaOutrosFornecedores()
        {
            IList<PedidoOrcamentoFornecedor> pedidosSemInteresse = pedidoOrcamentoFornecedorService.ObterPedidosDeFornecedoresQueNaoTiveramInteresse();

            foreach (PedidoOrcamentoFornecedor pedido in pedidosSemInteresse)
            {                

                pedidoOrcamentoService.NotificarFornecedorClientePorEmailNovoPedidoOrcamento(pedido.PedidoOrcamento, pedido.Fornecedor);
            }
        }

        private void EnviarEmailCompradoresComEmailsNaoValidados(DateTime dataPedido)
        {
            try
            {
                this.Log4Net.Debug("Início");
                IList<PedidoOrcamento> pedidosComEmailsNaoValidados = pedidoOrcamentoService.ObterPedidosOrcamentoPorDataStatus(dataPedido, PedidoStatus.EmailNaoValidado);

                foreach (PedidoOrcamento pedidoOrcamento in pedidosComEmailsNaoValidados)
                {
                    Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                    chavesValores.Add("<!--URL-->", Config.UrlSite + "ConfirmacaoEmail.aspx?email=" + pedidoOrcamento.Email + "&id=" + pedidoOrcamento.Id.ToString());
                    chavesValores.Add("<!--NOME_COMPRADOR-->", pedidoOrcamento.NomeComprador);
                    chavesValores.Add("<!--TELEFONE-->", pedidoOrcamento.Telefone);
                    chavesValores.Add("<!--CIDADE-->", pedidoOrcamento.Cidade.Nome);
                    chavesValores.Add("<!--UF-->", pedidoOrcamento.Cidade.Uf.ToString());
                    chavesValores.Add("<!--OBSERVACAO-->", pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />"));

                    string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailEmailNaoValidado);

                    Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, pedidoOrcamento.Email, htmlEmail, "Mensagem Importante - Pedido Aguardando sua Confirmação", false, false, null, "");
                }
            }
            catch (Exception e)
            {
                Erro.Logar(e);
            }
        }


        private void EnviarEmailParaForncedoresQueNaoResponderamOsPedidos()
        {

            fornecedorService.EnviarEmailParaForncedoresQueNaoResponderamOsPedidos();

        }

        private void EnviarEmailStatusPedido()
        {
            try
            {
                this.Log4Net.Debug("Início");

                IList<PedidoOrcamento> pedidosParaInformarStatus = pedidoOrcamentoService.ObterPedidosOrcamentoParaInformarStatusAosFornecedores();

                foreach (PedidoOrcamento pedidoOrcamento in pedidosParaInformarStatus)
                {
                    IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresParaUmPedidoDeOrcamento(pedidoOrcamento);

                    foreach (Fornecedor fornecedor in fornecedores)
                    {
                        string htmlStatusPedido = "";
                        Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                        chavesValores.Add("<!--NOME-->", fornecedor.Nome);
                        chavesValores.Add("<!--NOME_COMPRADOR-->", pedidoOrcamento.NomeComprador);
                        chavesValores.Add("<!--TITULO-->", pedidoOrcamento.Titulo);
                        chavesValores.Add("<!--CIDADE-->", pedidoOrcamento.Cidade.Nome);
                        chavesValores.Add("<!--UF-->", pedidoOrcamento.Cidade.Uf.ToString());
                        chavesValores.Add("<!--OBSERVACAO-->", pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />"));

                        if (pedidoOrcamento.StatusPedidoComprador == PedidoCompradorStatus.NaoRecebiOrcamento)
                            htmlStatusPedido = "Não recebeu orçamentos.<br />(É uma ótima oportunidade para você procurar o cliente e participar da cotação.)";

                        if (pedidoOrcamento.StatusPedidoComprador == PedidoCompradorStatus.JaFechei)
                            htmlStatusPedido = "Já fechou o orçamento.";

                        if (pedidoOrcamento.StatusPedidoComprador == PedidoCompradorStatus.Analisando)
                            htmlStatusPedido = "Está analisando os orçamentos recebidos.<br />(É uma ótima oportunidade para você fazer um novo contato e acompanhar a cotação.)";

                        if (pedidoOrcamento.StatusPedidoComprador == PedidoCompradorStatus.Desisti)
                            htmlStatusPedido = "Desistiu, não vai mais contratar.";

                        chavesValores.Add("<!--STATUS_PEDIDO-->", htmlStatusPedido);
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

                        if (fornecedor.Status == Status.Cliente)
                        {
                            chavesValores.Add("<!--DADOS_CONTATO-->", "<strong>Telefone</strong>: " + pedidoOrcamento.Telefone + " - <strong>E-mail</strong>: " + pedidoOrcamento.Email);
                        }

                        if (fornecedor.Status == Status.Degustacao && pedidoOrcamento.StatusPedidoComprador == PedidoCompradorStatus.NaoRecebiOrcamento)
                        {
                            string valorAvuslo = String.Format("{0:#0.00}", (fornecedor.ValorMensalidade / 10) + 1);

                            string htmlFormaPagamento = "<h2> Aproveite essa oportunidade!!!</h2>" +
                    "<p> Você pode ser um <strong>mensalista (R$ " + fornecedor.ValorMensalidade + ",00 )</strong>" +
                    ", ou participar <strong>somente desta cotação (R$ " + valorAvuslo.Replace(".", ",") + " )</strong>.</p>" +
                    "<p>Seguem abaixo as opções de pagamento disponíveis:</p>" +
                    "<p> <strong>Cartão de Crédito, Boleto ou Transferência Bancária - PagSeguro:</strong></p>" +
                    "<h3><a href='" + Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + fornecedor.ValorMensalidade + "&id=" + fornecedor.Id + "'>Quero ser mensalista</a></h3>" +
                    "<h3><a href='" + Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorAvuslo.Replace(".", ",") + "&id=" + fornecedor.Id + "&idPedido=" + pedidoOrcamento.Id + "'>Quero participar somente desta cotação</a></h3>";

                            chavesValores.Add("<!--DEGUSTACAO_FORMA_PAGAMENTO-->", htmlFormaPagamento);

                        }
                        string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailInformativoFornecedorStatusPedido);
                        Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Saiba se a venda ainda pode ser sua - pedido " + pedidoOrcamento.Id.ToString(), false, false, null, "");
                    }
                }
            }
            catch (Exception e)
            {
                Erro.Logar(e);
            }
        }

        private void EnviarEmailIndicadoresNegocio()
        {
            IList<Fornecedor> fornecedoresAtivos = fornecedorService.ObterFornecedoresAtivos();

            IList<Fornecedor> fornecedoresClientes = fornecedoresAtivos.Where(x => x.Status == Status.Cliente).ToList();

            double quantidadeClientes20Porcento = fornecedoresClientes.Count() * 0.20;
            IList<Fornecedor> clientes20Porcento = fornecedoresClientes.OrderByDescending(x => x.ValorMensalidade).Take(Convert.ToInt32(quantidadeClientes20Porcento)).ToList();
            string htmlCliente20Porcento = "<ul>";

            foreach (Fornecedor fornecedor in clientes20Porcento)
            {
                htmlCliente20Porcento = htmlCliente20Porcento + "<li>" + fornecedor.Nome + "- R$ " + fornecedor.ValorMensalidade + " - " + fornecedor.DataAlteracao + "</li>";
            }
            htmlCliente20Porcento = htmlCliente20Porcento + "</ul>";

            int quantidadeClientes = fornecedoresClientes.Count();
            double valor = fornecedoresClientes.Sum(y => y.ValorMensalidade);
            double valorFestasEventos = ObterValorPorTema(52, fornecedoresClientes);
            double valorObrasReformas = ObterValorPorTema(27, fornecedoresClientes);
            double valorJapones = ObterValorCategoria(54, fornecedoresClientes);
            double valorBuffet = ObterValorCategoria(123, fornecedoresClientes);
            double valorMoveisPlanejados = ObterValorCategoria(28, fornecedoresClientes);
            double valorCFTV = ObterValorCategoria(169, fornecedoresClientes);
            //double valorVendaAvulsa = compraAvulsaService.ObterPorData(DateTime.Now).Sum(x=>x.
            Dictionary<string, string> chavesValores = new Dictionary<string, string>();
            chavesValores.Add("<!--QUANTIDADE_CLIENTE-->", quantidadeClientes.ToString());
            chavesValores.Add("<!--VALOR-->", valor.ToString());

            string htmlEmail = "<p>Relatório Negócio</p><ul><li>Quantidade Cliente:" + quantidadeClientes.ToString() + "</li>" +
                               "<li>Faturamento:" + valor.ToString() + "</li>" +
                               "<li>Faturamento Festas Eventos:" + valorFestasEventos.ToString() + "</li>" +
                               "<li>Faturamento Obras Reformas:" + valorObrasReformas.ToString() + "</li>" +
                               "<li>Faturamento Japonês:" + valorJapones.ToString() + "</li>" +
                               "<li>Faturamento Buffet:" + valorBuffet.ToString() + "</li>" +
                               "<li>Faturamento Moveis Planejados:" + valorMoveisPlanejados.ToString() + "</li>" +
                               "<li>Faturamento CFTV:" + valorCFTV.ToString() + "</li>" +
                               "</ul>" +
                               "<p>Principais Clientes - 20%</p>" +
                               htmlCliente20Porcento;

            Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, "renatoadsumus@gmail.com", htmlEmail, "Relatório Indicadores de Negócio", true, false, null, "");
        }

        private double ObterValorCategoria(int idCategoria, IList<Fornecedor> fornecedoresAtivos)
        {
            double valorCategoria = 0;
            IList<Fornecedor> fornecedoresEventos = new List<Fornecedor>();
            Categoria categoria = categoriaService.Obter(idCategoria, false);

            foreach (Fornecedor fornecedor in fornecedoresAtivos.Where(x => x.Status == Status.Cliente).ToList())
            {
                if (fornecedor.SubCategorias.Contains(categoria) && !fornecedoresEventos.Contains(fornecedor))
                {
                    valorCategoria += fornecedor.ValorMensalidade;
                    fornecedoresEventos.Add(fornecedor);
                }
            }

            return valorCategoria;
        }

        private double ObterValorPorTema(int idTema, IList<Fornecedor> fornecedoresAtivos)
        {
            double valorDoTema = 0;
            IList<Fornecedor> fornecedoresEventos = new List<Fornecedor>();
            Categoria categoriaDoTema = categoriaService.Obter(idTema, false);

            foreach (Fornecedor fornecedor in fornecedoresAtivos.Where(x => x.Status == Status.Cliente).ToList())
            {
                foreach (Categoria categoria in categoriaDoTema.SubCategorias)
                {
                    if (fornecedor.SubCategorias.Contains(categoria) && !fornecedoresEventos.Contains(fornecedor))
                    {
                        valorDoTema += fornecedor.ValorMensalidade;
                        fornecedoresEventos.Add(fornecedor);
                    }
                }
            }

            return valorDoTema;
        }

        public void EnviarEmailPagamentoNaoIdentificado()
        {
            IList<Fornecedor> fornecedoresQueNaoPagaram = fornecedorService.ObterFornecedoresQueNaoPagaram(2);

            foreach (Fornecedor fornecedor in fornecedoresQueNaoPagaram)
            {
                try
                {
                    string valorMensalidade = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao).Replace(".", ",");
                    string valorMensalidade3Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao * 3).Replace(".", ",");
                    string valorMensalidade8Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao * 8).Replace(".", ",");


                    fornecedor.Status = Status.Degustacao;
                    fornecedorService.Alterar(fornecedor);
                    Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                    chavesValores.Add("<!--NOME-->", fornecedor.Nome);
                    chavesValores.Add("<!--VALOR_MENSALIDADE-->", valorMensalidade);
                    chavesValores.Add("<!--VALOR_3MESES-->", valorMensalidade3Meses);
                    chavesValores.Add("<!--VALOR_8MESES-->", valorMensalidade8Meses);
                    chavesValores.Add("<!--DATA_RENOVACAO-->", fornecedor.DataAlteracao.ToString("dd/MM/yyyy"));
                    chavesValores.Add("<!--URL-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade + "&id=" + fornecedor.Id + "&plano=1");
                    chavesValores.Add("<!--URL_3MESES-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade3Meses + "&id=" + fornecedor.Id + "&plano=3");
                    chavesValores.Add("<!--URL_8MESES-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade8Meses + "&id=" + fornecedor.Id + "&plano=8");

                    string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailPagamentoFornecedorNaoIdentificado);

                    Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Pagamento não identificado do serviço Orçamento Online", true, true, null, "");

                }
                catch (Exception e)
                {
                    Erro.Logar(e);
                }
            }
        }

        public void EnviarEmailLembreteVencimentoFornecedor(DateTime dataVencimento)
        {
            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresPorDataVencimento(dataVencimento);
            int quantidade = fornecedores.Count;
            foreach (Fornecedor fornecedor in fornecedores)
            {
                try
                {
                    IList<PedidoOrcamento> pedidoOrcamentoComDepoimento = pedidoOrcamentoService.ObterComComentarios(7, fornecedor.SubCategorias[0].Pai.Id);

                    string htmlOpiniao = "";

                    foreach (PedidoOrcamento pedido in pedidoOrcamentoComDepoimento)
                    {
                        htmlOpiniao += "Solicitante:<b>" + pedido.NomeComprador + "</b><br/> O que foi bom?<br/>" +
                                       pedido.OpiniaoComprador.Replace(Environment.NewLine, "<br />") + "<br /><br />";
                    }

                    string valorMensalidade = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao).Replace(".", ",");
                    string valorMensalidade3Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao * 3).Replace(".", ",");
                    string valorMensalidade8Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao * 8).Replace(".", ",");

                    Dictionary<string, string> chavesValores = new Dictionary<string, string>();

                    chavesValores.Add("<!--NOME-->", fornecedor.Nome);
                    chavesValores.Add("<!--OPINIAO_CLIENTE-->", htmlOpiniao);
                    chavesValores.Add("<!--VALOR_MENSALIDADE-->", valorMensalidade);
                    chavesValores.Add("<!--VALOR_3MESES-->", valorMensalidade3Meses);
                    chavesValores.Add("<!--VALOR_8MESES-->", valorMensalidade8Meses);
                    chavesValores.Add("<!--DATA_RENOVACAO-->", fornecedor.DataAlteracao.ToString("dd/MM/yyyy"));
                    chavesValores.Add("<!--URL-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade + "&id=" + fornecedor.Id + "&plano=1");
                    chavesValores.Add("<!--URL_3MESES-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade3Meses + "&id=" + fornecedor.Id + "&plano=3");
                    chavesValores.Add("<!--URL_8MESES-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade8Meses + "&id=" + fornecedor.Id + "&plano=8");
                    string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailLembreteVencimentoFornecedor);

                    Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Lembrete de renovação do serviço Orçamento Online", true, false, null, "");
                }
                catch (Exception e)
                {
                    Erro.Logar(e);
                }
            }
        }

        public void EnviarEmailPesquisaSatisfacaoFornecedor(DateTime dataCadastro)
        {
            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresPorDataCriacao(dataCadastro);
            int quantidade = fornecedores.Count;
            foreach (Fornecedor fornecedor in fornecedores)
            {
                try
                {
                    Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                    chavesValores.Add("<!--NOME-->", fornecedor.Nome);
                    chavesValores.Add("<!--DATA_CADASTRO-->", fornecedor.DataCadastro.ToString("dd/MM/yyyy"));
                    string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailPesquisaSatisfacaoFornecedor);

                    Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "O que tem achado do Orçamento Online?", false, false, null, "");
                }
                catch (Exception e)
                {
                    Erro.Logar(e);
                }
            }
        }

        /// <summary>
        /// Envia um email explicando o funcionamento do serviço do Orçamento
        /// </summary>
        public void EnviarEmailInformativoNovosFornecedores()
        {
            try
            {
                IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresPorDataCriacao(DateTime.Now.AddDays(-1));
                int quantidade = fornecedores.Count;
                foreach (Fornecedor fornecedor in fornecedores)
                {
                    try
                    {
                        IList<CategoriaPrioridade> categoriaPrioridade = fornecedorCategoriaService.Obter(fornecedor.Id);


                        int mesAtual = DateTime.Now.Month;

                        List<PedidoOrcamento> ultimosPedidosPerfilDoFornecedor = new List<PedidoOrcamento>();
                        foreach (Cidade cidade in fornecedor.Cidades)
                        {
                            if (ultimosPedidosPerfilDoFornecedor.Count < 10)
                                ultimosPedidosPerfilDoFornecedor.AddRange(pedidoOrcamentoService.ObterUltimosPedidosOrcamentoPorCategoriaMes(3, categoriaPrioridade[0].IdCategoria, mesAtual, cidade.Id));
                        }

                        string valorAvulso = "";

                        if (fornecedor.ValorMensalidade < 29)
                        {
                            valorAvulso = "4,90";
                        }
                        else
                        {
                            valorAvulso = String.Format("{0:#0.00}", (fornecedor.ValorMensalidade / 10) + 1).Replace(".", ",");
                        }

                        string listaHtmlDePedidosParaCompraAvulsa = "";

                        foreach (PedidoOrcamento pedidoOrcamento in ultimosPedidosPerfilDoFornecedor.OrderByDescending(x => x.Data).ToList())
                        {
                            if (pedidoOrcamento.Status == PedidoStatus.EmailValidado)
                            {
                                string dataPedidoOrcamento = String.Format("{0:dd/MM/yyyy}", pedidoOrcamento.Data);

                                listaHtmlDePedidosParaCompraAvulsa = listaHtmlDePedidosParaCompraAvulsa
                                    + "<p><b>Data Solicitação: </b>" + dataPedidoOrcamento
                                    + "<br/><b>Nome: </b>" + pedidoOrcamento.NomeComprador
                                    + "<br/><b>Cidade/UF: </b>" + pedidoOrcamento.Cidade.Nome + "/" + pedidoOrcamento.Cidade.Uf
                                    + "<br/><b>Serviço Solicitado: </b>" + categoriaPrioridade[0].IdCategoria.Nome
                                    + "<br/><b>Descrição: </b>" + pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />")
                                    + "<br/><strong>Aproveite e já participe dessa cotação avulsa</strong>: <a href='" + Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorAvulso.Replace(".", ",") + "&id=" + fornecedor.Id + "&idPedido=" + pedidoOrcamento.Id + "'>R$" + valorAvulso + "</a></p><br/>";
                            }
                        }

                        //Titulo do H3 no Box de Compra Avulsa
                        string tituloBoxCompraAvulva = "";
                        if (listaHtmlDePedidosParaCompraAvulsa != "")
                        {
                            tituloBoxCompraAvulva = "Abaixo pedidos que podem ser do seu interesse:";
                        }

                        string listaHtmlDeCategorias = "";
                        //Montando uma lista HTML li para enviar por email do fornecedor
                        foreach (Categoria categoria in fornecedor.SubCategorias)
                        {
                            listaHtmlDeCategorias = listaHtmlDeCategorias + "<li>" + categoria.Nome + "</li>";
                        }

                        listaHtmlDeCategorias = "<ul>" + listaHtmlDeCategorias + "</ul>";

                        string valorMensalidade = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao).Replace(".", ",");
                        string valorMensalidade3Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao * 3).Replace(".", ",");
                        string valorMensalidade8Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao * 8).Replace(".", ",");

                        Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                        chavesValores.Add("<!--NOME-->", fornecedor.Nome);
                        chavesValores.Add("<!--TELEFONE-->", fornecedor.Telefone);
                        chavesValores.Add("<!--H3_PEDIDOS_COMPRA_AVULSA-->", tituloBoxCompraAvulva);
                        chavesValores.Add("<!--BOX_PEDIDOS_COMPRA_AVULSA-->", listaHtmlDePedidosParaCompraAvulsa);
                        chavesValores.Add("<!--VALOR_MENSALIDADE-->", valorMensalidade);
                        chavesValores.Add("<!--DATA_RENOVACAO-->", fornecedor.DataAlteracao.ToString("dd/MM/yyyy"));
                        chavesValores.Add("<!--CATEGORIAS-->", listaHtmlDeCategorias);
                        chavesValores.Add("<!--VALOR_3MESES-->", valorMensalidade3Meses);
                        chavesValores.Add("<!--VALOR_8MESES-->", valorMensalidade8Meses);
                        chavesValores.Add("<!--ID-->", fornecedor.Id.ToString());
                        chavesValores.Add("<!--FICHA_TECNICA-->", fornecedor.UrlFichaTecnica);
                        string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailInformativoNovosFornecedores);

                        Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Mensagem Importante - instruções do Orçamento Online", true, false, null, "");
                        pedidoOrcamentoService.AssinarLista(fornecedor.Nome, fornecedor.Email);
                    }
                    catch (Exception e)
                    {
                        Erro.Logar(e);
                    }
                }
            }
            catch (Exception e)
            {
                Erro.Logar(e);
            }
        }

        public void EnviarEmailPesquisaSatisfacaoComprador()
        {
            try
            {
                this.Log4Net.Debug("Início");
                DateTime dataCriacaoPedido = DateTime.Today.AddDays(-10);

                IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorData(dataCriacaoPedido);

                int quantidade = pedidosOrcamento.Count;

                foreach (PedidoOrcamento pedidoOrcamento in pedidosOrcamento)
                {
                    try
                    {
                        Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                        chavesValores.Add("<!--NOME-->", pedidoOrcamento.NomeComprador);
                        chavesValores.Add("<!--URL-->", Config.UrlSite + "PesquisaSatisfacaoComprador.aspx?email=" + pedidoOrcamento.Email + "&id=" + pedidoOrcamento.Id.ToString());
                        string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailPesquisaSatisfacaoComprador);

                        Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, pedidoOrcamento.Email, htmlEmail, "O que achou do Orçamento Online (" + pedidoOrcamento.Id.ToString() + ")?", false, false, null, "");

                    }
                    catch (Exception e)
                    {
                        Erro.Logar(e);
                    }
                }
            }
            catch (Exception e)
            {
                Erro.Logar(e);
            }
        }

        public void EnviarIntegracoesEmail()
        {
            DateTime agora = DateTime.Now;
            IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoUltimaHora(agora);
            int quantidade = pedidosOrcamento.Count;

            foreach (PedidoOrcamento pedidoOrcamento in pedidosOrcamento)
            {
                try
                {
                    bool possuiFornecedorCadastrado = pedidoOrcamentoService.NotificarFornecedorClientePorEmailNovoPedidoOrcamento(pedidoOrcamento, null);

                    pedidoOrcamentoService.NotificarFornecedorEmDegustacaoPorEmailNovoPedidoOrcamento(pedidoOrcamento, possuiFornecedorCadastrado);

                }
                catch (Exception e)
                {
                    Erro.Logar(e);
                }
            }
        }

        public void EnviarEmailClientesAtivos()
        {
            IList<Fornecedor> fornecedoresAtivos = fornecedorService.ObterFornecedoresAtivos();

            foreach (Fornecedor fornecedor in fornecedoresAtivos)
            {
                Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                chavesValores.Add("<!--NOME-->", fornecedor.Nome);
                chavesValores.Add("<!--EMAIL-->", fornecedor.Email);
                string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailPesquisaOpiniaoFornecedorAtivo);
                // Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Mensagem Importante Orçamento Online", false, true, null, "");
            }

        }
        #endregion

        private void GravarEstatisticas()
        {
            pedidoEstatisticaService.GerarEstatistica();
        }
    }
}
