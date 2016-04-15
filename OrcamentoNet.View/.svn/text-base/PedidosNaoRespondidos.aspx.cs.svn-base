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
using OrcamentoNet.Entity._enum;
using OrcamentoNet.Common;

namespace OrcamentoNet.View
{
    public partial class PedidosNaoRespondidos : System.Web.UI.Page, IPedidosNaoRespondidos
    {
        PedidosNaoRespondidosPresenter presenter;
        FornecedorLogado fornecedorLogado;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new PedidosNaoRespondidosPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            fornecedorLogado = new FornecedorLogado();

            if (!IsPostBack)
            {
                if (fornecedorLogado.Fornecedor == null)
                    Response.Redirect(Config.UrlSite + "/LoginNovo.aspx");

                presenter.CarregarPedidosOrcamentos();
            }
        }

        #region Propriedades

        public Fornecedor Fornecedor
        {
            get { return fornecedorLogado.Fornecedor; }
        }

        #endregion

        public void CarregarPedidosOrcamentos(IList<PedidoOrcamento> pedidosOrcamentos, Fornecedor fornecedor, string fraseFornecedor)
        {
            h3NomeFornecedor.InnerText = "Olá " + fornecedor.Nome;

            if (pedidosOrcamentos.Count > 0)
                h4.InnerText = fraseFornecedor;
            else
                h4.InnerText = "Nenhum pedido foi encontrado!";

            if (fornecedor.Status == Status.Degustacao)
            {
                uxrptPedidosOrcamentosDegustacao.DataSource = pedidosOrcamentos;
                uxrptPedidosOrcamentosDegustacao.DataBind();
            }

            if (fornecedor.Status == Status.Cliente || fornecedor.Status == Status.Cortesia)
            {
                uxrptPedidosOrcamentosClienteCortesia.DataSource = pedidosOrcamentos;
                uxrptPedidosOrcamentosClienteCortesia.DataBind();
            }
        }

        protected void uxddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.CarregarPedidosOrcamentos();
        }

        public PedidoCompradorStatus PedidoCompradorStatus
        {

            get
            {
                string pedidoCompradorStatus = Enum.GetName(typeof(PedidoCompradorStatus), int.Parse(uxddlStatus.SelectedValue));

                return (PedidoCompradorStatus)Enum.Parse(typeof(PedidoCompradorStatus), pedidoCompradorStatus);
            }
        }
    }
}
