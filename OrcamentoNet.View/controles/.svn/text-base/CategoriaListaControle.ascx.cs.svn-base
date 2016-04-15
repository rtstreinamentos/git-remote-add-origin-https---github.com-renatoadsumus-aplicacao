using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.Entity;
using OrcamentoNet.IView.Presenter;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

namespace OrcamentoNet.View.controles
{
    public partial class CategoriaListaControle : System.Web.UI.UserControl, ICategoriaListaControle
    {
        CategoriaListaControlePresenter presenter;
        int contador = 0;
        int idCategoria = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CategoriaListaControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                NameValueCollection queryString = Request.QueryString;
                String[] array = queryString.AllKeys;

                if (array.Length > 0)
                {
                    idCategoria = (Request.QueryString["categoria"] != null) ? Convert.ToInt32(Request.QueryString["categoria"].ToString()) : 0;
                }

                presenter.CarregarCategorias();               
            }
        }

        public int CategoriaRecebida
        {
            get { return idCategoria; }

        }       

        #region Metodos

        public void CarregarCategorias(IList<Categoria> categorias)
        { 
            uxrptCategoriasColuna1.DataSource = categorias;
            uxrptCategoriasColuna1.DataBind();            
        }

        protected string DefinirAlinhamento() {
            if (contador++ % 2 == 0)
            {
                return "right";
            }
            else
            {
                return "left";
            }
        }       

        #endregion
    }
}