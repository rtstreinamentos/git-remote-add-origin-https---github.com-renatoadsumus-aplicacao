using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;

namespace OrcamentoNet.View
{
    public partial class orcamento_online_pedido_historico : System.Web.UI.Page, Iorcamento_online_pedido_historico
    {
        Orcamento_Online_Pedido_HistoricoPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                presenter = new Orcamento_Online_Pedido_HistoricoPresenter();
                presenter.View = this;
                presenter.OnViewInitialized();

                NameValueCollection queryString = Request.QueryString;
                String[] array = queryString.AllKeys;

                if (array.Length > 0)
                {
                    presenter.CarregarPedidosOrcamentos();
                }
            }
        }

        #region Metodos
        public void CarregarPedidosOrcamentos(IList<PedidoOrcamento> pedidosOrcamentos)
        {
            if ((pedidosOrcamentos == null) || (pedidosOrcamentos.Count == 0))
            {
                //mensagemVazio.InnerText = "Nenhuma oportunidade de negócio localizada.";
            }
            else
            {
                uxrptPedidosOrcamentos.DataSource = pedidosOrcamentos;
                uxrptPedidosOrcamentos.DataBind();
            }
        }
        #endregion
    }
}
