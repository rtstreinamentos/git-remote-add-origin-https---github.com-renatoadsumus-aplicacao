using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;

namespace OrcamentoNet.View.controles
{
    public partial class CategoriaListaFornecedoresControle : System.Web.UI.UserControl, ICategoriaListaControle
    {
        CategoriaListaControlePresenter presenter;
        int contador = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CategoriaListaControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                presenter.CarregarCategorias();
            }
        }

        public int CategoriaRecebida { get; set; }

        #region Metodos

        public void CarregarCategorias(IList<Categoria> categorias)
        {
            uxrptCategoriasColuna1.DataSource = categorias;
            uxrptCategoriasColuna1.DataBind();
        }

        protected string DefinirAlinhamento()
        {
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