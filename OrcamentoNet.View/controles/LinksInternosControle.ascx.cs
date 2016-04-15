using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.View.controles
{
    public partial class LinksInternosControle : System.Web.UI.UserControl, ILinksInternosControle
    {
        private int idCategoriaRecebida;
        private int idCidadeRecebida;
        private int idBairroRecebido;
        private string termoRecebido;
        public string NomeCategoria { set; get; }
        public string UrlCategoria { set; get; }
        LinksInternosControlePresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new LinksInternosControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
            idCidadeRecebida = (Request.Params["cidade"] != null) ? Int32.Parse(Request.Params["cidade"]) : 0;
            idBairroRecebido = (Request.Params["bairro"] != null) ? Int32.Parse(Request.Params["bairro"]) : 0;

            if (!IsPostBack)
            {
                presenter.MontarLinksInternos();
            }
        }       

        public void GerarHeaderHTML(Categoria categoria, string nomeEstadoCidade)
        {
            string nomeCidadeExibicao = "";
            if (nomeEstadoCidade != "")
                nomeCidadeExibicao = " - " + nomeEstadoCidade;

            if (categoria != null)
            {
                uxTituloH2.InnerText = "Orçamento Online de " + categoria.Nome + nomeCidadeExibicao;
                uxlnkTodos.ToolTip = "Solicite orçamento online grátis de " + categoria.Nome + nomeCidadeExibicao;
            }
            else
            {
                uxTituloH2.InnerText = "Orçamento Online";
                uxlnkTodos.ToolTip = "Solicite orçamento online grátis";
            }
            
            uxlnkTodos.NavigateUrl = "/" + UrlCategoria;

        }

        public void MontarLinksInternosDeEstado(IList<LinkInterno> linksInternosEstadoCidade)
        {
            uxrptLinksEstadoCidade.DataSource = linksInternosEstadoCidade;
            uxrptLinksEstadoCidade.DataBind();
        }

        public void MontarLinksInternosDeEstadoParceiros(IList<LinkInterno> linksInternosEstadoParceiros)
        {
            uxrptLinksEstadoCidadeParceiros.DataSource = linksInternosEstadoParceiros;
            uxrptLinksEstadoCidadeParceiros.DataBind();
        }

        public void MontarLinksInternosTermo(IList<LinkInterno> linksInternosTermo)
        {
            uxrptLinks.DataSource = linksInternosTermo;
            uxrptLinks.DataBind();
        }

        #region Propriedades

        public int IdCategoria
        {
            get { return idCategoriaRecebida; }
        }

        public int IdCidade
        {
            get { return idCidadeRecebida; }
        }

        public int IdBairro
        {
            get { return idBairroRecebido; }
        }

        #endregion
    }
}