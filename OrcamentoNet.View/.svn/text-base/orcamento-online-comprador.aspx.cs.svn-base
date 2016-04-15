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
    public partial class orcamento_online_comprador : System.Web.UI.Page, Iorcamento_online_comprador
    {
        orcamento_online_compradorPresenter presenter;      

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new orcamento_online_compradorPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                presenter.CarregarAreaDeAtuacaoPorEstado();
            }
        }

        #region Metodos

        public void CarregarAreaDeAtuacaoPorEstado(IList<orcamento_online_compradorPresenter.Estado> cidades)
        {
            uxrptAreasDeRegiao.DataSource = cidades;
            uxrptAreasDeRegiao.DataBind();
        }

        #endregion
    }
}
