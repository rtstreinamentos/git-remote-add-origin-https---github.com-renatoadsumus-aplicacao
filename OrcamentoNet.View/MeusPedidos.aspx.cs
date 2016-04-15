using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.Entity;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Common;

namespace OrcamentoNet.View
{
    public partial class MeusPedidos : System.Web.UI.Page, IMeusPedidos
    {
        MeusPedidosPresenter presenter;
        FornecedorLogado fornecedorLogado;

        int idPedidoOrcamento = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new MeusPedidosPresenter();
            fornecedorLogado = new FornecedorLogado();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (fornecedorLogado.Fornecedor == null)
                Response.Redirect(Config.UrlSite + "LoginNovo.aspx");

            if (fornecedorLogado.Fornecedor.Status != Entity.Enum.Status.Cliente)
            {
                uxbtnCriarPedido.Enabled = false;
                uxbtnCriarPedido.ToolTip = "Controle de Pedidos - Somente para Clientes.";
            }

            if (!IsPostBack)
            {
                presenter.CarregarPedidosDeOrcamentoNoStatus();
            }

        }

        protected void uxgrdPedidos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int linha = e.NewSelectedIndex;
            idPedidoOrcamento = Convert.ToInt32(uxgrdPedidos.DataKeys[linha].Value.ToString());
            ViewState["idPedidoOrcamento"] = int.Parse(((Label)uxgrdPedidos.Rows[linha].FindControl("TextBoxId")).Text);
            presenter.CarregarPedidoOrcamento();
            multiview01.SetActiveView(viewDetalhePedido);
        }

        #region Metodos

        public void VisualizarDetalheDoPedido(OrcamentoFornecedor orcamentoFornecedor)
        {
            uxlblId.Text = orcamentoFornecedor.PedidoOrcamento.Id.ToString();
            uxtxtMaisInformacoesPedido.Text = orcamentoFornecedor.InformacoesAdicionais;
            uxlblEmail.Text = orcamentoFornecedor.PedidoOrcamento.Email;
            uxlblNome.Text = orcamentoFornecedor.PedidoOrcamento.NomeComprador;
            uxtxtObservacao.Text = orcamentoFornecedor.PedidoOrcamento.Observacao;
            uxtxtTitulo.Text = orcamentoFornecedor.PedidoOrcamento.Titulo;
            uxtxtTelefone.Text = orcamentoFornecedor.PedidoOrcamento.Telefone;
            uxddlStatusPedido2.SelectedValue = orcamentoFornecedor.PedidoStatusFornecedor.ToString();
        }

        public void CarregarPedidosDeOrcamentoNoStatus(IList<OrcamentoFornecedor> orcamentosFornecedorComStatus)
        {
            if (orcamentosFornecedorComStatus.Count > 0)
            {
                uxH2.Visible = false;

                uxgrdPedidos.DataSource = orcamentosFornecedorComStatus;
                uxgrdPedidos.DataBind();
            }
            else
            {
                uxgrdPedidos.DataSource = null;
                uxgrdPedidos.DataBind();
            }
        }

        #endregion

        #region Propriedades

        public string InformacoesAdicionais
        {
            get { return uxtxtMaisInformacoesPedido.Text; }
        }

        public Fornecedor Fornecedor
        {
            get { return fornecedorLogado.Fornecedor; }
        }

        public int IdPedidoOrcamento
        {
            get { return Int32.Parse(ViewState["idPedidoOrcamento"].ToString()); }
        }

        public string PedidoStatusFornecedor
        {
            get { return uxddlStatusPedido.SelectedItem.Value; }
        }

        public string PedidoStatusFornecedorUpdate
        {
            get { return uxddlStatusPedido2.SelectedItem.Value; }
        }
        #endregion

        protected void uxddlStatusPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.CarregarPedidosDeOrcamentoNoStatus();
        }

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            presenter.Salvar();
        }

        protected void uxbtnCriarPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect(Config.UrlSite + "CriarPedido.aspx");
        }


        #region IMeusPedidos Members




        #endregion
    }
}
