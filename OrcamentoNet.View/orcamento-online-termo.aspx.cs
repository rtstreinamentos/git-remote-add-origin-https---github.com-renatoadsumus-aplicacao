using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;

namespace OrcamentoNet.View
{
    public partial class orcamento_online_termo : System.Web.UI.Page, Iorcamento_online_termo
    {
        orcamento_online_termoPresenter presenter;        
        string termoPesquisa;

        private void IniciarPresent()
        {
            presenter = new orcamento_online_termoPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IniciarPresent();

            if (!IsPostBack)
            {
                termoPesquisa = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString().Replace("-", " ") : String.Empty;
                presenter.CarregarTermos();
            }
        }

        #region Metodo

        public void CarregarTermos(Categoria categoria)
        {
            uxrptTermos.DataSource = categoria.LinksInternos;
            uxrptTermos.DataBind();
        }

        #endregion
    }
}
