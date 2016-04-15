using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.IView;

namespace OrcamentoNet.View
{
    public partial class GuiaTemas : System.Web.UI.Page, IGuiaTemas
    {
        GuiaTemasPresenter presenter;
        int idCategoria = 0;
        int idCidade = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new GuiaTemasPresenter();
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

                presenter.CarregarFornecedores();
                presenter.CarregarCidadesDoEstado();
                presenter.MontarLinksInternos();
            }
        }

        #region Propriedades

        public int IdCategoria
        {
            get { return idCategoria; }
        }
        public int IdCidade
        {
            get { return idCidade; }
        }

        #endregion

        #region Metodos

        public void ExibirMensagem(string mensagem)
        {
            MensagemSuperiorControle1.ExibirMensagem(mensagem);
        }

        public void GerarHeaderHTML(string nomeCategoria, string URLDaCategoria, string nomeCidade)
        {
            uxTituloH2Cidade.InnerText = "Guia de Empresas e Profissionais - " + nomeCategoria + " - " + nomeCidade;

            string titleDaPagina = "Guia de " + nomeCategoria + " - " + nomeCidade + " - Orçamento Online";
            Page.Title = titleDaPagina;
            uxTituloH1.InnerText = titleDaPagina;

            string descriptionDaPagina = nomeCategoria;
            descriptionDaPagina = "Guia de " + descriptionDaPagina + nomeCidade + ": empresas e profissionais cadastrados no Orçamento Online e depoimentos de clientes.";
            HtmlMeta metaDescription = new HtmlMeta();
            metaDescription.Name = "description";
            metaDescription.Content = descriptionDaPagina;
            Page.Header.Controls.Add(metaDescription);

            string textoIntroducaoDaPagina = nomeCategoria;
            this.ExibirMensagem("<p class='productDescription'>Conheça as <strong>empresas e profissionais cadastrados em " + textoIntroducaoDaPagina + "</strong> na cidade de seu interesse, os últimos fornecedores cadastrados no Orçamento Online e os <strong>depoimentos dos clientes</strong> que usaram os nossos serviços.</p>");

            string tituloH2PeloBrasil = "Guia de " + nomeCategoria + ": empresas e profissionais pelo Brasil";
            //uxTituloH2PeloBrasil.InnerText = tituloH2PeloBrasil;

            //string tituloH2UltimasEmpresasProfissionais = "Últimas Empresas e Profissionais em " + nomeCategoria;
            //uxTituloH2UltimasEmpresasProfissionais.InnerText = tituloH2UltimasEmpresasProfissionais;

            //string tituloH2UltimasOportunidades = "Últimas Oportunidades de Negócio em " + nomeCategoria;
            //uxTituloH2UltimasOportunidades.InnerText = tituloH2UltimasOportunidades;

            //string tituloH2UltimosDepoimentos = "Últimas Depoimentos de Clientes sobre " + nomeCategoria;
            //uxTituloH2UltimosDepoimentos.InnerText = tituloH2UltimosDepoimentos;

            uxbtnQueroOrcamento.HRef = Config.UrlSite + URLDaCategoria;
        }


        public void CarregarCidadesDoEstado(List<Estado> estados)
        {
            //Carrega Estados no Topo
            if (IdCidade == 0)
            {
                uxrptEstados.DataSource = estados;
                uxrptEstados.DataBind();
            }
            else
            {
                //Carrega Estados no Rodapé
                uxrptEstadosRodape.DataSource = estados;
                uxrptEstadosRodape.DataBind();
            }
        }

        public void CarregarFornecedores(IList<Fornecedor> fornecedores)
        {
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

        public void MontarArvoreDeLinksInternos(IList<Categoria> categorias)
        {
            uxrptLinksInternosTema.DataSource = categorias;
            uxrptLinksInternosTema.DataBind();
        }

        public void MontarLinksInternosTermo(IList<LinkInterno> linksInternosTermo)
        {
            uxrptLinksTermo.DataSource = linksInternosTermo;
            uxrptLinksTermo.DataBind();
        }

        #endregion

    }
}
