using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.IView;
using OrcamentoNet.Entity;

namespace OrcamentoNet.View.controles
{
    public partial class CategoriasTemaCheckBoxControle : System.Web.UI.UserControl, ICategoriasTemaCheckBoxControle
    {
        CategoriasTemaCheckBoxControlePresenter presenter;
        int idCategoriaRecebida;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CategoriasTemaCheckBoxControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
                presenter.CarregarCategoriasDoTema();
            }

        }

        public void CarregarCategoriasDoTema(Categoria categoria)
        {
            uxchkCategoriasTema.DataValueField = "Id";
            uxchkCategoriasTema.DataTextField = "Nome";
            uxchkCategoriasTema.DataSource = categoria.SubCategorias;
            uxchkCategoriasTema.DataBind();


            int y = 0;
            //Marca na Checkbox a categoria
            foreach (ListItem item in uxchkCategoriasTema.Items)
            {
                if (item.Value == idCategoriaRecebida.ToString())
                {
                    uxchkCategoriasTema.Items[y].Selected = true;
                }
                y++;
            }
        }

        #region Propriedades

        public IList<string> SubCategorias
        {
            get
            {
                List<string>  subcategoriaId = new List<string>();
               
                foreach (ListItem categoria in uxchkCategoriasTema.Items)
                {
                    if (categoria.Selected)
                        subcategoriaId.Add(categoria.Value);
                }

                return subcategoriaId;
            }
        }     

        public int IdCategoria
        {
            get { return idCategoriaRecebida; }
        }

        #endregion
    }

}