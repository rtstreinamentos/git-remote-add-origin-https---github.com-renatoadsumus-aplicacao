using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.Entity;
using OrcamentoNet.IView.Presenter;
using System.Collections.Specialized;

namespace OrcamentoNet.View.controles
{
	public partial class FornecedoresControle : System.Web.UI.UserControl, IFornecedoresControle
	{
		FornecedoresControlePresenter presenter;
		public int quantidadeFornecedores = 20;
		int idCategoria = 0;
		int idCidade = 0;

		protected void Page_Load(object sender, EventArgs e) {
			presenter = new FornecedoresControlePresenter();
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
				}
				presenter.CarregarUltimosFornecedoresCadastrados();
			}
		}

		#region Metodos

		public void CarregarUltimosFornecedoresCadastrados(IList<Fornecedor> fornecedores) {
			if ((fornecedores == null) || (fornecedores.Count == 0))
			{
				mensagemVazio.InnerText = "Nenhuma empresa ou profissional localizado.";
			}
			else
			{
				uxrptFornecedores.DataSource = fornecedores;
				uxrptFornecedores.DataBind();
			}
		}

		#endregion

		#region Propriedades
		public int IdCategoria {
			get { return idCategoria; }
		}

		public int QuantidadeFornecedores {
			get { return quantidadeFornecedores; }
		}

		public int IdCidade {
			get { return idCidade; }
		}

        public string TermoPesquisa
        {
            get { return ""; }
        }
        public int Mes
        {
            get { return 0; }
        }
		#endregion      


       
    }
}