using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using OrcamentoNet.Common;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.View.controles
{
    public partial class RodapeControle : System.Web.UI.UserControl, IRodapeControle
    {
        RodapeControlePresenter presenter;
        int idCategoriaRecebida;

        protected void Page_Load(object sender, EventArgs e)
        {

            presenter = new RodapeControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
                //presenter.CarregarInformacoesRodape();
            }
        }

        #region Metodos

        public void CarregarInformacoesRodape(string categoria, 
            string urlVoceConhece, 
            string nomeExibicaoVoceConhece,
            string toolTipVoceConhece,
            string urlHistorico,
            string nomeExibicaoHistorico,
            string toolTipHistorico)
        {
            uxTituloH3RodapeVoceConhece.InnerText = "Nossos fornecedores de " + categoria;
            hplLink.NavigateUrl = "#";
            hplLink.Text = nomeExibicaoVoceConhece;
            hplLink.ToolTip = toolTipVoceConhece;

            uxTituloH3RodapeHistorico.InnerHtml = "Preços e Cotações de " + categoria;
            hplLinkHistorico.NavigateUrl = urlHistorico;
            hplLinkHistorico.Text = nomeExibicaoHistorico;
            hplLinkHistorico.ToolTip = toolTipHistorico;
        }
        #endregion

        public int IdCategoria
        {
            get { return idCategoriaRecebida; }
        }
    }
}