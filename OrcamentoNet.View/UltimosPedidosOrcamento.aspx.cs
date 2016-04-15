using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Common;

namespace OrcamentoNet.View
{
    public partial class UltimosPedidosOrcamento : System.Web.UI.Page, IUltimosPedidosOrcamento
    {
        UltimosPedidosOrcamentoPresenter presenter;
        private int idPedidoOrcamento = 0;
        FornecedorLogado fornecedorLogado;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new UltimosPedidosOrcamentoPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            idPedidoOrcamento = (Request.Params["idPedido"] != null) ? Int32.Parse(Request.Params["idPedido"]) : 0;
            fornecedorLogado = new FornecedorLogado();

            if (fornecedorLogado.Fornecedor == null)
                Response.Redirect(Config.UrlSite + "/LoginNovo.aspx");

            if (!IsPostBack)
            {
                if (idPedidoOrcamento == 0)
                    presenter.CarregarUltimosPedidos();
                else
                    presenter.CarregarBoxCompraAvulsa();
            }
        }
        public int IdCidade
        {
            get { return int.Parse(uxddlCidades.SelectedValue); }
        }

        public Fornecedor Fornecedor
        {
            get { return fornecedorLogado.Fornecedor; }
        }

        public int IdPedidoOrcamento
        {
            get { return idPedidoOrcamento; }
        }

        #region Metodos

        protected void Repeater1_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                idPedidoOrcamento = int.Parse(((Label)e.Item.FindControl("key1Label")).Text);
                presenter.Salvar();
            }

        }

        public void CarregarPedidosOrcamento(IList<PedidoOrcamento> pedidosOrcamentoResultado, Fornecedor fornecedor)
        {
            h3NomeFornecedor.InnerText = "Olá " + fornecedor.Nome;

            if (fornecedor.Status == Status.Degustacao)
            {
                uxrptPedidosOrcamentosDegustacao.DataSource = pedidosOrcamentoResultado;
                uxrptPedidosOrcamentosDegustacao.DataBind();
            }

            if (fornecedor.Status == Status.Cliente || fornecedor.Status == Status.Cortesia)
            {
                uxrptPedidosOrcamentosClienteCortesia.DataSource = pedidosOrcamentoResultado;
                uxrptPedidosOrcamentosClienteCortesia.DataBind();
            }
        }        

        public void CarregarCidades(IList<Cidade> cidades)
        {
            uxddlCidades.DataValueField = "Id";
            uxddlCidades.DataTextField = "Nome";
            uxddlCidades.DataSource = cidades;
            uxddlCidades.DataBind();
        }

        public void CarregarBoxCompraAvulsa(Fornecedor fornecedor)
        {
            multiview01.SetActiveView(viewBoxCompraAvulsa);
            uxhplPagSeguro.Text = "Efetuar compra do Pedido - R$" + fornecedor.ValorAvulso;
            uxhplPagSeguro.NavigateUrl = "/orcamento-online-pagamento.aspx?valor=" + fornecedor.ValorAvulso + "&id=" + fornecedor.Id + "&idPedido=" + this.idPedidoOrcamento.ToString();
        }

        #endregion

        protected void uxddlCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.CarregarPedidosOutrasAreas();
        }
    }
}
