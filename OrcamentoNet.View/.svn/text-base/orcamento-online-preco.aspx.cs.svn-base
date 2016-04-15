using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.IView;
using OrcamentoNet.Entity;
using System.Web.UI.HtmlControls;

namespace OrcamentoNet.View
{
    public partial class orcamento_online_preco : System.Web.UI.Page, Iorcamento_online_preco
    {
        orcamento_online_precoPresenter presenter;

        int idPedidoOrcamento = 0;
        int idCategoria = 0;
        int idCidade = 0;
        int ano = 0;
        int mes = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new orcamento_online_precoPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                idCategoria = (Request.QueryString["idCategoria"] != null) ? Convert.ToInt32(Request.QueryString["idCategoria"].ToString()) : 0;
                idCidade = (Request.QueryString["idCidade"] != null) ? Convert.ToInt32(Request.QueryString["idCidade"].ToString()) : 0;
                idPedidoOrcamento = (Request.QueryString["idPedidoOrcamento"] != null) ? Convert.ToInt32(Request.QueryString["idPedidoOrcamento"].ToString()) : 0;
                ano = (Request.QueryString["ano"] != null) ? Convert.ToInt32(Request.QueryString["ano"].ToString()) : 0;
                mes = (Request.QueryString["mes"] != null) ? Convert.ToInt32(Request.QueryString["mes"].ToString()) : 0;
                presenter.CarregarCategorias();
                presenter.CarregarPedidos();
                presenter.MontarLinksInternos();

            }
        }

        #region Metodos

        public void CarregarCategoriasPai(IList<Categoria> categorias)
        {
            uxrptLinksCategoria.DataSource = categorias;
            uxrptLinksCategoria.DataBind();
        }

        public void CarregarPedidosOrcamentos(IList<PedidoOrcamento> pedidosOrcamentos)
        {
            uxrptPedidosOrcamentos.DataSource = pedidosOrcamentos;
            uxrptPedidosOrcamentos.DataBind();
        }

        public void GerarHeaderHTML(string tituloPedido, string nomeCidade, string h3LinkInterno)
        {
            string titleDaPagina = tituloPedido;

            Page.Title = titleDaPagina;
            uxTituloH1.InnerText = titleDaPagina;

            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = "Receba orçamentos e compare de preço de várias empresas para " + tituloPedido + " " + nomeCidade + ". Solicite um orçamento grátis!";

            Page.Header.Controls.Add(metaHtml);

            metaHtml = new HtmlMeta();
            metaHtml.Name = "keywords";
            metaHtml.Content = tituloPedido + "," + nomeCidade;
            Page.Header.Controls.Add(metaHtml);

            //ExibirMensagem("<p class='productDescription'>Faça sua cotação de preços de <strong>" + tipoServico + "</strong> no Orçamento Online. Seu <strong>pedido de orçamento</strong> será enviado aos nossos fornecedores, que enviarão as cotações de preços diretamente para você. De graça!</p>");
        }

        public void CarregarPedido(PedidoOrcamento pedidoOrcamento)
        {
            uxllblObservacao.Text = pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />");
            uxllblCidade.Text = pedidoOrcamento.Cidade.Nome;
            uxrptFotos.DataSource = pedidoOrcamento.Fotos;
            uxrptFotos.DataBind();
        }

        public void MontarLinksInternosEstadoCidade(IList<LinkInterno> linksInternosEstadosCidade)
        {
            uxrptLinksEstadoCidade.DataSource = linksInternosEstadosCidade;
            uxrptLinksEstadoCidade.DataBind();
        }

        public void MontarLinksInternosAnoMes(IList<LinkInterno> linksInternosAnoMes)
        {
            uxrptAnoMes.DataSource = linksInternosAnoMes;
            uxrptAnoMes.DataBind();
        }

        #endregion

        #region Propriedades
        public int IdPedidoOrcamento
        {
            get { return idPedidoOrcamento; }
        }

        public int IdCategoria
        {
            get { return idCategoria; }
        }
        public int IdCidade
        {
            get { return idCidade; }
        }

        public int Ano
        {
            get { return ano; }
        }

        public int Mes
        {
            get { return mes; }
        }
        #endregion

        #region EventosTela




        #endregion

    }
}
