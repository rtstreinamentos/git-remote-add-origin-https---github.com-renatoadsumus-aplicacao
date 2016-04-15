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

namespace OrcamentoNet.View
{
    public partial class orcamento_online_mapa_site : System.Web.UI.Page, IOrcamento_Online_Mapa_Site
    {
        Orcamento_Online_Mapa_SitePresenter presenter;
          

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new Orcamento_Online_Mapa_SitePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {               
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
            string titleDaPagina = "Empresas e negócios do Orçamento Online";
            Page.Title = titleDaPagina;
            uxTituloH1.InnerText = titleDaPagina;

            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = "Últimas empresas e profissionais cadastrados, e oportunidades de negócio geradas pelo Orçamento Online.";
            Page.Header.Controls.Add(metaHtml);

            ExibirMensagem("<p class='productDescription'>Conheça as mais recentes <strong>empresas e profissionais</strong> cadastrados, as últimas <strong>oportunidades de negócio</strong> geradas pelo Orçamento Online e os <strong>depoimentos dos clientes</strong> que usaram os nossos serviços.</p>");
        }

        public void CarregarCategorias(IList<Categoria> categorias)
        {
            uxrptCategoriasColuna1.DataSource = categorias;
            uxrptCategoriasColuna1.DataBind();
        }
        #endregion
    }
}
