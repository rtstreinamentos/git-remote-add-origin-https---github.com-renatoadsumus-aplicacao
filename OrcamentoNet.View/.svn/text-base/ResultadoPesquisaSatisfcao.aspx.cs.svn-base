using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.Entity;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.View
{
    public partial class ResultadoPesquisaSatisfcao : System.Web.UI.Page, IResultadoPesquisaSatisfcao
    {
        ResultadoPesquisaSatisfcaoPresenter presenter;        

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new ResultadoPesquisaSatisfcaoPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
                presenter.CarregarOpiniao();
        }

        #region Metodos

        public void CarregarOpiniao(IList<PedidoOrcamento> pedidos)
        {
            uxrptOpiniao.DataSource = pedidos;
            uxrptOpiniao.DataBind();
        }

        #endregion
    }
}
