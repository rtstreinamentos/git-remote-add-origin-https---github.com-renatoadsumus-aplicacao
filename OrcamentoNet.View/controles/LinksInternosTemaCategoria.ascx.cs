using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;
using System.Collections.Specialized;

namespace OrcamentoNet.View.controles
{
    public partial class LinksInternosTemaCategoria : System.Web.UI.UserControl, ILinksInternosTemaCategoria
    {
        LinksInternosTemaCategoriaPresenter presenter;
        int idCategoria = 0;
        int idCidade = 0;
        string termoPesquisa = String.Empty;
        private int idBairro;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new LinksInternosTemaCategoriaPresenter();
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
                    termoPesquisa = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString() : String.Empty;
                    idBairro = (Request.Params["bairro"] != null) ? Int32.Parse(Request.Params["bairro"]) : 0;
                }
                presenter.MontarArvoreDeLinksInternos();
            }
        }

        #region Metodos

        public void MontarArvoreDeLinksInternos(IList<Categoria> categorias)
        {
            uxrptLinksInternos.DataSource = categorias;
            uxrptLinksInternos.DataBind();
        }

        public void MontarLinksInternosDeEstado(IList<LinkInterno> linksInternosEstadoCidade)
        {
            uxrptLinksEstadoCidade.DataSource = linksInternosEstadoCidade;
            uxrptLinksEstadoCidade.DataBind();
        }

        public void MontarLinksInternosMesAno(IList<LinkInterno> linksInternosMesAno)
        {
            uxrptLinksMesAno.DataSource = linksInternosMesAno;
            uxrptLinksMesAno.DataBind();
        }

        public void MontarLinksInternosTermo(IList<LinkInterno> linksInternosTermo)
        {
            uxrptLinksTermo.DataSource = linksInternosTermo;
            uxrptLinksTermo.DataBind();
        }

        #endregion       

        #region Propriedade
        public int IdCategoria
        {
            get { return idCategoria; }
        }

        public int IdCidade
        {
            get { return idCidade; }
        }

        public string TermoPesquisa
        {
            get { return termoPesquisa; }
        }

        public int IdBairro
        {
            get { return idBairro; }
        }
        #endregion
    }
}