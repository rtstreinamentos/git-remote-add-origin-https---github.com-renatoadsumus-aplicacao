using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.IView;

namespace OrcamentoNet.View
{
    public partial class ConfirmacaoEmail : System.Web.UI.Page, IConfirmacaoEmail
    {
        ConfirmacaoEmailPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new ConfirmacaoEmailPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (Request.QueryString["email"].ToString() != null)
            {
                presenter.ValidarEmail();
            }
        }        

        #region Propriedades

        public string Email
        {
            get { return Request.QueryString["email"].ToString(); }
        }

        public int IdPedidoOrcamento
        {
            get { return int.Parse(Request.QueryString["id"].ToString()); }
        }

        #endregion
    }
}
