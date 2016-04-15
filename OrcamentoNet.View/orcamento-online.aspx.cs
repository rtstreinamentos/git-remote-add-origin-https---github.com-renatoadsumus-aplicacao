using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using System.Web.UI.HtmlControls;

namespace OrcamentoNet.View
{
    public partial class OrcamentoOnline : System.Web.UI.Page, IOrcamentoOnline
    {
        OrcamentoOnlinePresenter presenter;
        int idCategoriaRecebida;
        int idBairroRecebido;
        int idCidade;
        string termoPesquisa;
        int idServico;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new OrcamentoOnlinePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                idServico = (Request.Params["servico"] != null) ? Int32.Parse(Request.Params["servico"]) : 0;
                idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
                idCidade = (Request.Params["cidade"] != null) ? Int32.Parse(Request.Params["cidade"]) : 0;
                termoPesquisa = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString().Replace("-", " ") : String.Empty;
                idBairroRecebido = (Request.Params["bairro"] != null) ? Int32.Parse(Request.Params["bairro"]) : 0;
                presenter.CarregarFormularioSolicitarPedidoOrcamento();

            }
        }


        #region Metodos
        public void GerarFacebook(string url)
        {
            uxlblFacebook.Text = "<div class='fb-like' data-href='http://orcamentosgratis.net.br/" + url + "' data-layout='standard'" +
                        " data-action='like' data-show-faces='true' data-share='true'>    </div>";
        }

        public void ExibirMensagem(string mensagem)
        {
            MensagemSuperiorControle1.ExibirMensagem(mensagem);
        }

        public void CarregarCategoria(string nomeCategoria, string nomeCidade, Categoria categoria)
        {
            uxlblExplicacao.Text = categoria.DetalheExplicativo;
            GerarHeaderHTML(nomeCategoria, nomeCidade, categoria.Termo);
        }

        public void DesabilitarListaDeCategorias()
        {
            CategoriaListaControle1.Visible = false;
        }

        public void HabilitarFormularioCamerasMonitoradasCFTV()
        {
            Response.Redirect("/orcamento-online-cftv.aspx?categoria=" + idCategoriaRecebida + "&cidade=" + idCidade + "&termo=" + termoPesquisa + "&bairro=" + idBairroRecebido);

            OrcamentoFormularioGenerico.Visible = false;
            OrcamentoFormularioCFTV1.Visible = true;
            uxTrocarFormulario.Visible = true;
            uxOrcamentosMaisPopulares.Visible = false;
            OrcamentoFormularioCasaDecoracao1.Visible = false;
        }

        public void HabilitarFormularioEventosFestas()
        {
            Response.Redirect("/orcamento-online-evento.aspx?categoria=" + idCategoriaRecebida + "&cidade=" + idCidade + "&termo=" + termoPesquisa + "&bairro=" + idBairroRecebido);

            //OrcamentoFormularioGenerico.Visible = false;
            //OrcamentoFormularioEvento.Visible = true;
            //uxTrocarFormulario.Visible = true;
            //uxOrcamentosMaisPopulares.Visible = false;
            //OrcamentoFormularioCasaDecoracao1.Visible = false;
        }

        public void HabilitarFormularioConstrucao()
        {
            Response.Redirect("/orcamento-online-obras-reformas.aspx?categoria=" + idCategoriaRecebida + "&cidade=" + idCidade + "&termo=" + termoPesquisa + "&bairro=" + idBairroRecebido);

            //OrcamentoFormularioGenerico.Visible = false;
            //OrcamentoFormularioConstrucao.Visible = true;
            //uxTrocarFormulario.Visible = true;
            //uxOrcamentosMaisPopulares.Visible = false;
            //OrcamentoFormularioCasaDecoracao1.Visible = false;
        }

        public void HabilitarFormularioGenerico()
        {
            if (idCategoriaRecebida == 0)
            {
                OrcamentoFormularioGenerico.Visible = false;
                uxOrcamentosMaisPopulares.Visible = true;
                OrcamentoFormularioCasaDecoracao1.Visible = false;
            }
            else
            {
                Response.Redirect("/orcamento-online-generico.aspx?categoria=" + idCategoriaRecebida + "&cidade=" + idCidade + "&termo=" + termoPesquisa + "&bairro=" + idBairroRecebido);

                OrcamentoFormularioGenerico.Visible = true;
                uxOrcamentosMaisPopulares.Visible = false;
                uxTrocarFormulario.Visible = true;
                OrcamentoFormularioCasaDecoracao1.Visible = false;
            }
        }

        public void HabilitarFormularioFachadasPredias()
        {
            Response.Redirect("/orcamento-online-limpeza-fachada.aspx?categoria=" + idCategoriaRecebida + "&cidade=" + idCidade + "&termo=" + termoPesquisa + "&bairro=" + idBairroRecebido);
            //OrcamentoFormularioFachadaPredial1.Visible = true;
            //OrcamentoFormularioGenerico.Visible = false;
            //OrcamentoFormularioEspelhoVidro1.Visible = false;
            //uxTrocarFormulario.Visible = true;
            //uxOrcamentosMaisPopulares.Visible = false;
            //OrcamentoFormularioCasaDecoracao1.Visible = false;
        }

        public void HabilitarFormularioMudanca()
        {
            OrcamentoFormularioGenerico.Visible = false;
            OrcamentoFormularioMudanca1.Visible = true;
            uxTrocarFormulario.Visible = true;
            uxOrcamentosMaisPopulares.Visible = false;
            OrcamentoFormularioCasaDecoracao1.Visible = false;
        }

        public void HabilitarFormularioVidroEspelho()
        {
            Response.Redirect("/orcamento-online-espelho-vidro.aspx?categoria=" + idCategoriaRecebida + "&cidade=" + idCidade + "&termo=" + termoPesquisa + "&bairro=" + idBairroRecebido);

            //OrcamentoFormularioGenerico.Visible = false;
            //OrcamentoFormularioEspelhoVidro1.Visible = true;
            //uxTrocarFormulario.Visible = true;
            //uxOrcamentosMaisPopulares.Visible = false;
            //OrcamentoFormularioCasaDecoracao1.Visible = false;
        }

        public void HabilitarFormularioCasaDecoracao()
        {
            Response.Redirect("/orcamento-online-casa-decoracao.aspx?categoria=" + idCategoriaRecebida + "&cidade=" + idCidade + "&termo=" + termoPesquisa + "&bairro=" + idBairroRecebido);

            OrcamentoFormularioGenerico.Visible = false;
            OrcamentoFormularioEspelhoVidro1.Visible = false;
            uxTrocarFormulario.Visible = true;
            uxOrcamentosMaisPopulares.Visible = false;
            OrcamentoFormularioCasaDecoracao1.Visible = true;
        }

        private void GerarHeaderHTML(string nomeCategoria, string nomeCidade, string keywords)
        {
            string titleDaPagina = nomeCategoria;

            if (!String.IsNullOrEmpty(termoPesquisa)) titleDaPagina = titleDaPagina + " - " + termoPesquisa;

            if (!String.IsNullOrEmpty(nomeCidade)) titleDaPagina = titleDaPagina + " - " + nomeCidade;

            if (titleDaPagina != "Orçamento Online") titleDaPagina = "Orçamento Online Grátis para " + titleDaPagina;

            Page.Title = titleDaPagina;
            uxTituloH1.InnerText = titleDaPagina;

            string conteudoTexto = nomeCategoria.ToLower();
            if (!String.IsNullOrEmpty(termoPesquisa)) conteudoTexto = conteudoTexto + " para " + termoPesquisa.ToLower();
            if (!String.IsNullOrEmpty(nomeCidade)) conteudoTexto = conteudoTexto + " em " + nomeCidade;
            if (conteudoTexto == "orçamento online") conteudoTexto = "diversos serviços e produtos";

            string descricao = "Solicite orçamento online grátis de " + conteudoTexto + ". Receba cotação de preços de " + conteudoTexto + " de vários fornecedores. Prático, simples, eficaz e grátis!";
            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = descricao;
            Page.Header.Controls.Add(metaHtml);

            HtmlMeta ogTitle = new HtmlMeta();
            ogTitle.Attributes.Add("property", "og:title");
            ogTitle.Content = titleDaPagina;
            Page.Header.Controls.Add(ogTitle);

            HtmlMeta ogDescription = new HtmlMeta();
            ogDescription.Attributes.Add("property", "og:description");
            ogDescription.Content = descricao;
            Page.Header.Controls.Add(ogDescription);

            if (!String.IsNullOrEmpty(keywords))
            {
                keywords = keywords + ", " + titleDaPagina.Replace("-", ",");
            }
            else
            {
                keywords = titleDaPagina.Replace("-", ",");
            }

            //metaHtml = new HtmlMeta();
            //metaHtml.Name = "keywords";
            //metaHtml.Content = keywords;
            //Page.Header.Controls.Add(metaHtml);

            ExibirMensagem("<p class='productDescription'>Faça sua cotação de preços de <strong>" + conteudoTexto + "</strong> no Orçamento Online. Seu <strong>pedido de orçamento</strong> será enviado aos nossos fornecedores, que enviarão as cotações de preços diretamente para você. De graça!</p>");
        }

        #endregion

        #region Propriedade


        public int IdCategoria
        {
            get { return idCategoriaRecebida; }
        }

        public int IdCidade
        {
            get { return idCidade; }
        }

        public int IdBairro
        {
            get { return idBairroRecebido; }
        }

        public int IdServico
        {
            get { return idServico; }
        }
        #endregion
    }
}
