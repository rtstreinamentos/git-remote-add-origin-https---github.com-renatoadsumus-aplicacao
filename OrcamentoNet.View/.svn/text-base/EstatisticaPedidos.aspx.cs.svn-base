using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using System.Collections.Specialized;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;
using System.Web.UI.HtmlControls;

namespace OrcamentoNet.View
{
    public partial class EstatisticaPedidos : System.Web.UI.Page, IEstatisticaPedidos
    {
        EstatisticaPedidosPresenter presenter;
        int idCategoria = 0;
        string uf = "";
        int mes = DateTime.Now.Month - 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new EstatisticaPedidosPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {       

                idCategoria = (Request.QueryString["categoria"] != null) ? Convert.ToInt32(Request.QueryString["categoria"].ToString()) : 0;
                uf = (Request.QueryString["uf"] != null) ? Request.QueryString["uf"].ToString() : "";

                if (idCategoria == 0)
                {
                    presenter.CarregarCategorias();
                }
                else
                {
                    presenter.CarregarEstatisticaPorCategoria();
                }
            }
        }

        #region Propriedade

        public string Uf
        {
            get
            {
                return "";
            }
        }

        public int IdCategoria
        {
            get
            {
                return idCategoria;
            }
        }

        public int Mes
        {
            get
            {
                return mes;
            }
        }

        #endregion

        #region Metodos
        public void CarregarEstatisticaPorCategoria(IList<PedidoEstatistica> estatisticasDeUmaCategoria)
        {
            multiview.SetActiveView(viewPasso2);
            uxrptEstatistica.DataSource = estatisticasDeUmaCategoria;
            uxrptEstatistica.DataBind();
        }

        public void CarregarCategorias(IList<Categoria> categorias)
        {
            multiview.SetActiveView(viewPasso1);

            uxrptCategoriasColuna1.DataSource = categorias;
            uxrptCategoriasColuna1.DataBind();
        }

        public void GerarHeaderHTML(Categoria categoria, string totalPedidos)
        {
            string titleDaPagina = "Estatistica de Março do Orçamento Online - " + categoria.Nome;

            uxTituloH2.InnerText = titleDaPagina + " - Total: " + totalPedidos;

            Page.Title = titleDaPagina;
            uxTituloH1.InnerText = titleDaPagina;

            string descriptionDaPagina = categoria.Nome;
            descriptionDaPagina = "Guia de " + descriptionDaPagina + ": empresas e profissionais cadastrados no Orçamento Online e depoimentos de clientes.";
            HtmlMeta metaDescription = new HtmlMeta();
            metaDescription.Name = "description";
            metaDescription.Content = descriptionDaPagina;
            Page.Header.Controls.Add(metaDescription);

            string textoIntroducaoDaPagina = categoria.Nome;
            //this.ExibirMensagem("<p class='productDescription'>Conheça as <strong>empresas e profissionais cadastrados em " + textoIntroducaoDaPagina + "</strong> na cidade de seu interesse, os últimos fornecedores cadastrados no Orçamento Online e os <strong>depoimentos dos clientes</strong> que usaram os nossos serviços.</p>");

            string tituloH2PeloBrasil = "Guia de " + categoria.Nome + ": empresas e profissionais pelo Brasil";

        }

        public void CarregarEstados(IList<string> estados)
        {
            uxrptLinksEstado.DataSource = estados;
            uxrptLinksEstado.DataBind();
        }

        #endregion
    }
}
