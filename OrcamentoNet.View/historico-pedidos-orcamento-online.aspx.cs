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
    public partial class PedidosOrcamentoOnline : System.Web.UI.Page, IHistoricoPedidosOrcamentoOnline
    {
        HistoricoPedidosOrcamentoOnlinePresenter presenter;
        int idCategoriaRecebida;
        int idBairroRecebido;
        int idCidade;
        string termoPesquisa;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new HistoricoPedidosOrcamentoOnlinePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
                idCidade = (Request.Params["cidade"] != null) ? Int32.Parse(Request.Params["cidade"]) : 0;
                termoPesquisa = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString().Replace("-", " ") : String.Empty;
                idBairroRecebido = (Request.Params["bairro"] != null) ? Int32.Parse(Request.Params["bairro"]) : 0;
                presenter.CarregarFormularioSolicitarPedidoOrcamento();

            }
        }


        #region Metodos
        public void ExibirMensagem(string mensagem)
        {
            MensagemSuperiorControle1.ExibirMensagem(mensagem);
        }

        public void CarregarCategoria(string nomeCategoria, string nomeCidade, Categoria categoria)
        {
            GerarHeaderHTML(nomeCategoria, nomeCidade, categoria.Termo);
        }

        public void DesabilitarListaDeCategorias()
        {
            CategoriaListaControle1.Visible = false;
        }

        public void HabilitarFormularioCamerasMonitoradasCFTV()
        {
            OrcamentoFormularioGenerico.Visible = false;
            OrcamentoFormularioCFTV1.Visible = true;
            uxTrocarFormulario.Visible = true;
            uxOrcamentosMaisPopulares.Visible = false;
            OrcamentoFormularioCasaDecoracao1.Visible = false;
        }

        public void HabilitarFormularioEventosFestas()
        {
            OrcamentoFormularioGenerico.Visible = false;
            OrcamentoFormularioEvento.Visible = true;
            uxTrocarFormulario.Visible = true;
            uxOrcamentosMaisPopulares.Visible = false;
            OrcamentoFormularioCasaDecoracao1.Visible = false;
        }

        public void HabilitarFormularioConstrucao()
        {
            OrcamentoFormularioGenerico.Visible = false;
            OrcamentoFormularioConstrucao.Visible = true;
            uxTrocarFormulario.Visible = true;
            uxOrcamentosMaisPopulares.Visible = false;
            OrcamentoFormularioCasaDecoracao1.Visible = false;
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
                OrcamentoFormularioGenerico.Visible = true;
                uxOrcamentosMaisPopulares.Visible = false;
                uxTrocarFormulario.Visible = true;
                OrcamentoFormularioCasaDecoracao1.Visible = false;
            }
        }

        public void HabilitarFormularioFachadasPredias()
        {
            OrcamentoFormularioFachadaPredial1.Visible = true;
            OrcamentoFormularioGenerico.Visible = false;
            OrcamentoFormularioEspelhoVidro1.Visible = false;
            uxTrocarFormulario.Visible = true;
            uxOrcamentosMaisPopulares.Visible = false;
            OrcamentoFormularioCasaDecoracao1.Visible = false;
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
            OrcamentoFormularioGenerico.Visible = false;
            OrcamentoFormularioEspelhoVidro1.Visible = true;
            uxTrocarFormulario.Visible = true;
            uxOrcamentosMaisPopulares.Visible = false;
            OrcamentoFormularioCasaDecoracao1.Visible = false;
        }

        public void HabilitarFormularioCasaDecoracao()
        {
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
            if (titleDaPagina != "Orçamento Online") titleDaPagina = "Orçamento para " + titleDaPagina;
            Page.Title = titleDaPagina;
            uxTituloH1.InnerText = titleDaPagina;

            string conteudoTexto = nomeCategoria.ToLower();
            if (!String.IsNullOrEmpty(termoPesquisa)) conteudoTexto = conteudoTexto + " para " + termoPesquisa.ToLower();
            if (!String.IsNullOrEmpty(nomeCidade)) conteudoTexto = conteudoTexto + " em " + nomeCidade;
            if (conteudoTexto == "orçamento online") conteudoTexto = "diversos serviços e produtos";
            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = "Solicite orçamento online grátis de " + conteudoTexto + ". Receba cotação de preços de " + conteudoTexto + " de vários fornecedores. Prático, simples, eficaz e grátis!";
            Page.Header.Controls.Add(metaHtml);

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
        #endregion
    }
}
