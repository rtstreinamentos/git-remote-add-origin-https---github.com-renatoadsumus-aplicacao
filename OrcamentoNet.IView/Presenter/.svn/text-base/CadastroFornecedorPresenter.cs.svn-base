using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.ILocalService;
using System.IO;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class CadastroFornecedorPresenter
    {
        public ICadastroFornecedor View { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

        [Inject]
        public IFornecedorCategoriaService fornecedorCategoriaService { get; set; }

        [Inject]
        public IMensalidadeService mensalidadeService
        { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarCategoria()
        {
            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();
            View.CarregarCategoria(categorias);
        }

        public void Salvar()
        {
            IList<string> camposInvalidos = new List<string>();

            Fornecedor fornecedor = fornecedorService.ObterPorEmail(View.Email);

            if (fornecedor != null)
            {

                IList<Cidade> cidades = new List<Cidade>();

                foreach (int idCidade in View.CidadesDeAtuacao)
                {
                    cidades.Add(cidadeService.Obter(idCidade));
                }

                fornecedor.DataAlteracao = View.DataVencimento;
                fornecedor.WebSite = View.WebSite;
                fornecedor.Telefone = View.Telefone;
                fornecedor.Nome = View.Nome;
                fornecedor.Descricao = View.Descricao;
                fornecedor.ValorMensalidade = View.ValorMensalidade;
                fornecedor.Cidades = cidades;
                fornecedor.Status = (Status)Enum.Parse(typeof(Status), View.Status);

                Categoria categoria;
                IList<Categoria> subCategorias = new List<Categoria>();
                foreach (string categoriaItem in View.Categorias)
                {
                    categoria = categoriaService.Obter(int.Parse(categoriaItem), false);

                    subCategorias.Add(categoria);
                }

                fornecedor.SubCategorias = subCategorias;

                fornecedorCategoriaService.Excluir(fornecedor.Id);

                foreach (CategoriaPrioridade item in View.CategoriasPrioridades)
                {
                    item.Fornecedor = fornecedor;
                    fornecedorCategoriaService.Inserir(item);
                }
            }
        }

        public void CarregarFornecedor()
        {
            Fornecedor fornecedor = null;
            if (View.Email != "")
            {
                fornecedor = fornecedorService.ObterPorEmail(View.Email);
            }

            if (View.IdFornecedor != 0)
            {
                fornecedor = fornecedorService.ObterPorId(View.IdFornecedor);
            }

            if (View.Nome != "")
            {
                fornecedor = fornecedorService.ObterPorNome(View.Nome);
            }

            if (fornecedor != null)
            {
                fornecedor.CategoriasPrioridade = fornecedorCategoriaService.Obter(fornecedor.Id);

                View.CarregarFornecedor(fornecedor);
            }
        }

        public void EnviarEmailConfirmandoPagamento()
        {
            Fornecedor fornecedor = fornecedorService.ObterPorEmail(View.Email);

            if (fornecedor != null)
            {
                Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                chavesValores.Add("<!--NOME-->", fornecedor.Nome);
                chavesValores.Add("<!--FICHA_TECNICA-->", fornecedor.UrlFichaTecnica);
                chavesValores.Add("<!--VALOR_MENSALIDADE-->", String.Format("{0:0.00}", fornecedor.ValorMensalidade));
                chavesValores.Add("<!--DATA_VENCIMENTO-->", fornecedor.DataAlteracao.ToString("dd/MM/yyyy"));

                string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailConfirmandoPagamento);

                fornecedor.Status = Status.Cliente;

                Mensalidade mensalidade = new Mensalidade();
                mensalidade.Fornecedor = fornecedor.Id;
                mensalidade.Data = DateTime.Now;
                mensalidadeService.Inserir(mensalidade);

                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, Config.NomeAplicacao + " - Confirmação Pagamento", true, true, null, "");
            }
        }

        public void EnviarUltimosPedidos(bool truncado)
        {
            Fornecedor fornecedor = fornecedorService.ObterPorEmail(View.Email);
            DateTime dataInicio = DateTime.Now.AddDays(-View.DiasUltimosPedidos);
            DateTime dataFim = DateTime.Now;
            IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorIntervaloDeData(dataInicio, dataFim);
            List<PedidoOrcamento> pedidosOrcamentoResultado = new List<PedidoOrcamento>();

            foreach (Cidade cidade in fornecedor.Cidades)
            {
                pedidosOrcamentoResultado.AddRange(pedidosOrcamento.Where(x => x.Cidade == cidade).ToList());
            }

            string pedidoHtml = "";
            string htmlEmail = "";
            string solicitante = "";
            string categoriaPedido = "";
            string cabecalho = "Olá, " + fornecedor.Nome + "!<br /><br /><b>Seguem abaixo os últimos pedidos recebidos em nosso sistema:</b><br /><br />";

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

                        string telefone = pedidoOrcamento.Telefone;
                        string telefoneOperadora = pedidoOrcamento.TelefoneOperadora;
                        string email = pedidoOrcamento.Email;

                        if (truncado)
                        {
                            email = pedidoOrcamento.Email.Substring(0, 6) + "...@XXX.com";
                            telefone = pedidoOrcamento.Telefone.Substring(0, 7) + "-XXXX";
                            telefoneOperadora = "";
                        }

                        solicitante = "<br />Solicitante: " + pedidoOrcamento.NomeComprador +
                                     "<br />Telefone: " + telefone + " Operadora: " + telefoneOperadora +
                                     "<br />Email: " + email + emailValidado +
                                     "<br />Serviços solicitados:<br />" + pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />") +
                                     "<br />Cidade: " + pedidoOrcamento.Cidade.Nome +
                                     "<br /><br />";
                    }
                }

                if (solicitante != "")
                {
                    pedidoHtml = pedidoHtml + "<h3>Número do Pedido: " + pedidoOrcamento.Id.ToString() + "</h3><br/><b>Título: </b>" + pedidoOrcamento.Titulo + "<br>" + solicitante;
                }

                solicitante = "";
                categoriaPedido = "";
            }

            if (pedidoHtml != "")
            {
                htmlEmail = cabecalho + pedidoHtml;

                if (truncado)
                {
                    string valorMensalidade = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao).Replace(".", ",");

                    Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                    chavesValores.Add("<!--NOME_FORNECEDOR-->", fornecedor.Nome);
                    chavesValores.Add("<!--VALOR_MENSALIDADE-->", valorMensalidade);
                    chavesValores.Add("<!--PEDIDOS-->", pedidoHtml);
                    chavesValores.Add("<!--URL-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade + "&id=" + fornecedor.Id + "&plano=1");
                    htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateUltimosPedidosDegustacao);
                }

                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Mensagem Importante - Últimos Pedidos de Orçamento Recebidos", true, true, null, "");
            }
        }

        public void CarregarFornecedoresNovos()
        {
            IList<Fornecedor> fornecedoresNovos = fornecedorService.ObterUltimosFornecedoresCadastrados(5, 0, "");

            View.CarregarFornecedoresNovos(fornecedoresNovos);
        }
    }
}

