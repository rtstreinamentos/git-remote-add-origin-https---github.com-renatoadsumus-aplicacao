using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using System.Collections.Specialized;
using OrcamentoNet.Entity;
using OrcamentoNet.Common;

namespace OrcamentoNet.View
{
    public partial class orcamento_online_parceiro_passo0 : System.Web.UI.Page, ICadastroFornecedoresOrcamentoOnline
    {
        CadastroFornecedoresOrcamentoOnlinePresenter presenter;
        int idCategoriaRecebida;
        int idCidade;
        List<string> fotos;
        List<string> fotosGravadas;
        string termo;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CadastroFornecedoresOrcamentoOnlinePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
                idCidade = (Request.Params["cidade"] != null) ? Int32.Parse(Request.Params["cidade"]) : 0;
                termo = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString().Replace("-", " ") : String.Empty;

                fotos = new List<string>();
                fotosGravadas = new List<string>();
                Session["Fotos"] = fotos;
                Session["FotosGravadas"] = fotosGravadas;

                if (idCategoriaRecebida > 0)
                {
                    FornecedorPorCategoriaControle1.Visible = true;
                    CategoriaListaFornecedoresControle1.Visible = true;
                    presenter.GerarHeaderHTML();
                    multiview.Visible = false;
                }
                else
                {
                    FornecedorPorCategoriaControle1.Visible = false;
                    CategoriaListaFornecedoresControle1.Visible = false;
                    GerarHeaderHTML("Orçamento Online", String.Empty, String.Empty);
                    multiview.Visible = true;
                    presenter.CarregarCategoria();
                }
            }
        }

        #region Propriedade

        public int IdCategoria
        {
            get { return idCategoriaRecebida; }
        }

        public int IdCategoriaPrincipal
        {
            get { return 1; }
        }

        public int IdCidade
        {
            get { return idCidade; }
        }

        public IList<string> Fotos
        {
            get
            { return ((List<string>)(Session["FotosGravadas"])); }

        }

        public IList<string> Categorias
        {
            get
            {
                IList<string> categorias = new List<string>();             
                

                return categorias;
            }
        }

        public IList<int> CidadesDeAtuacao
        {
            get { return null; }
        }

        public string Descricao
        {
            get { return ""; }
        }

        public Fornecedor Fornecedor
        {
            get { return ((Fornecedor)(Session["Fornecedor"])); }
        }
        public string Email
        {
            get { return ""; }
        }

        public bool PalavraEhCorreta
        {
            get { return true; }
        }

        public string WebSite
        {
            get { return ""; }
        }

        public string Nome
        {
            get { return ""; }
        }

        public string Telefone
        {
            get { return ""; }
        }

        public string Indicacao
        {
            get { return ""; }
        }

        public double ValorMensalidade
        {
            get { return double.Parse(ViewState["valorMensalidade"].ToString()); }
        }

        #endregion

        #region Metodos

        public void ViewEscolhaDoPlano()
        {

        }

        public void ExibirMensagem(string mensagem)
        {
            MensagemSuperiorControle1.ExibirMensagem(mensagem);
        }

        public void CarregarCategoria(IList<Categoria> categorias)
        {

        }

        public void GerarHeaderHTML(string nomeCategoria, string nomeCidade, string keywords)
        {
            string titleDaPagina;
            string conteudoTexto;
            string tagContent;

            if (termo != String.Empty)
            {
                titleDaPagina = "Cadastro grátis para empresas e profissionais de " + termo;
                conteudoTexto = termo.ToLower();
                tagContent = "Cadastro grátis para empresas e profissionais de " + conteudoTexto + " no Orçamento Online. Receba pedidos de orçamentos de " + conteudoTexto + " de vários clientes do Brasil. Prático, simples, eficaz e grátis para avaliação!";
            }
            else
            {
                if (!String.IsNullOrEmpty(nomeCidade))
                    titleDaPagina = nomeCategoria + " - " + nomeCidade + " - Cadastro Grátis";
                else
                    titleDaPagina = nomeCategoria + " - Cadastre sua Empresa é Grátis";

                conteudoTexto = nomeCategoria.ToLower();
                tagContent = "Cadastro grátis de empresas e profissionais de " + conteudoTexto + " no Orçamento Online. Receba pedidos de orçamentos de " + conteudoTexto + " de vários clientes do Brasil. Prático, simples, eficaz e grátis para avaliação!";
            }

            Page.Title = titleDaPagina;

            if (conteudoTexto == "orçamento online") conteudoTexto = "diversos serviços e produtos";
            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = tagContent;
            Page.Header.Controls.Add(metaHtml);

            if (!String.IsNullOrEmpty(keywords))
            {
                keywords = keywords + ", " + titleDaPagina.Replace("-", ",");
            }
            else
            {
                keywords = titleDaPagina.Replace("-", ",");
            }
            metaHtml = new HtmlMeta();
            metaHtml.Name = "keywords";
            metaHtml.Content = keywords;
            Page.Header.Controls.Add(metaHtml);

            uxTituloH1.InnerText = titleDaPagina;
            string mensagem = "<p class='productDescription'>O Orçamento Online trabalha para <strong>atrair e conquistar novos clientes para você</strong>. Fazendo seu cadastro, você participa de <strong>cotações por e-mail</strong> — reais oportunidades de negócio para <strong>aumentar suas vendas</strong>.</p>";
            if (idCategoriaRecebida > 0)
                mensagem += "<p class='productDescription'><a href='/cadastro-fornecedores-orcamento-online.aspx?#formulario' title='Faça seu cadastro grátis no Orçamento Online'>Sim, quero me cadastrar no site.</a></p>";

            ExibirMensagem(mensagem);
        }

        public void ViewPasso3()
        {

        }

        public void GuardarFornecedorNaSessao(Fornecedor fornecedor)
        {
            Session["Fornecedor"] = fornecedor;
        }

        public void ExibirMensagemParteInferior(string mensagem)
        {

        }

        public void ApresentarValoresPlanos(string plano1, string plano2)
        {

        }

        public void LimparTela()
        {

        }

        public void MontarLinksInternosTermos(IList<LinkInterno> linksInternosTermo)
        {

        }

        public void RedirecionarPaginaSucesso()
        {
            Response.Redirect("/CadastroFornecedorSucesso.aspx");
        }
        #endregion

        #region Eventos Tela



        protected void uxbtnCalcularValor_Click(object sender, EventArgs e)
        {
            Response.Redirect("custo-anunciar-parceiro.aspx");

        }


        protected void uxbtnNaoEnviarFotos_Click(object sender, EventArgs e)
        {
            RedirecionarPaginaSucesso();
        }

        protected void uxbtnEnviarFoto_Click(object sender, EventArgs e)
        {

        }

        protected void uxbtnFinalizarCadastro_Click(object sender, EventArgs e)
        {
            presenter.SalvarFotos();
            RedirecionarPaginaSucesso();
        }



        protected void uxbtnPasso1_Click(object sender, EventArgs e)
        {

        }

        protected void uxbtnPasso2_Click(object sender, EventArgs e)
        {

        }

        protected void uxbtnPasso2_1_Click(object sender, EventArgs e)
        {

        }

        protected void uxbtnPasso3_Click(object sender, EventArgs e)
        {

        }

        protected void uxbtnPlano1_Click(object sender, EventArgs e)
        {

        }

        protected void uxbtnPlano2_Click(object sender, EventArgs e)
        {


        }
        #endregion

        public void CarregarCategoriasSelecionadas(IList<Categoria> categoriasSelecionadas)
        {

        }

        protected void uxbtnPasso0_Click(object sender, EventArgs e)
        {
            Response.Redirect("/novo-fornecedore-passo1.aspx");
        }
    }
}
