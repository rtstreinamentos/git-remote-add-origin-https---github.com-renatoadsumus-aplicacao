using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using OrcamentoNet.Entity;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.View
{
	public partial class Guia : System.Web.UI.Page, IGuia
    {
		GuiaPresenter presenter;
		int idCategoria = 0;
		int idCidade = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
			presenter = new GuiaPresenter();
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
				presenter.CarregarCategorias();
                this.GerarHeaderHTML();
			}
        }

        #region Metodos

        public void ExibirMensagem(string mensagem)
        {
            MensagemSuperiorControle1.ExibirMensagem(mensagem);
        }

        private void GerarHeaderHTML()
        {
            string titleDaPagina = "Guia de Empresas e Profissionais do Orçamento Online";
            Page.Title = titleDaPagina;
            uxTituloH1.InnerText = titleDaPagina;

            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = "Conheça as empresas e profissionais, os tipos de pedido de orçamento online que você pode fazer e os depoimentos de clientes que usaram nossos serviços.";
            Page.Header.Controls.Add(metaHtml);

			ExibirMensagem("<p class='productDescription'>Conheça o <strong>guia de empresas e profissionais</strong> do Orçamento Online, os tipos de pedido de orçamento que você pode fazer e os depoimentos de clientes que usaram nossos serviços. Temos fornecedores nas principais cidades do Brasil.</p>");
        }

		public void CarregarCategorias(IList<Categoria> categorias) {
			uxrptCategorias.DataSource = categorias;
			uxrptCategorias.DataBind();
		}

		#endregion

		#region Propriedades
		public int IdCategoria {
			get { return idCategoria; }
		}
		#endregion
    }
}
