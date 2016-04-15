using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.Entity;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.IView;
using System.Collections.Specialized;

namespace OrcamentoNet.View
{
    public partial class DepoimentoOrcamentoOnline : System.Web.UI.UserControl, IDepoimentoOrcamentoOnlineSite
    {
        DepoimentoOrcamentoOnlineSitePresenter presenter;
        int idCategoria = 0;
        int idCidade = 0;
        int idMes = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new DepoimentoOrcamentoOnlineSitePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                NameValueCollection queryString = Request.QueryString;
                String[] array = queryString.AllKeys;

                if (array.Length > 0)
                {
                    idCategoria = (Request.QueryString["categoria"] != null) ? Convert.ToInt32(Request.QueryString["categoria"].ToString()) : 0;
                    idCidade = (Request.QueryString["cidade"] != null) ? Convert.ToInt32(Request.QueryString["cidade"].ToString()) : 0;
                    idMes = (Request.QueryString["mes"] != null) ? Convert.ToInt32(Request.QueryString["mes"].ToString()) : 0;
                }
                presenter.CarregarDepoimentos();
            }
        }

        public int IdCategoria
        {
            get { return idCategoria; }
        }

        public int IdCidade
        {
            get { return idCidade; }
        }

        public int Mes
        {
            get { return idMes; }
        }

        public void CarregarDepoimentos(IList<PedidoOrcamento> pedidosQueGostaramDoOrcamento)
        {
			if ((pedidosQueGostaramDoOrcamento == null) || (pedidosQueGostaramDoOrcamento.Count == 0))
			{
				mensagemVazio.InnerText = "Nenhum depoimento localizado.";

                uxrptDepoimentos.DataSource = null;
                uxrptDepoimentos.DataBind();
			}
			else
			{
				uxrptDepoimentos.DataSource = pedidosQueGostaramDoOrcamento;
				uxrptDepoimentos.DataBind();
			}
        }
    }
}