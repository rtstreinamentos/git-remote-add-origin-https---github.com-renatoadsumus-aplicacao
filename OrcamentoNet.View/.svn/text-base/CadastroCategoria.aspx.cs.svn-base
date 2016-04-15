using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.Entity;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.View
{
    public partial class CadastroCategoria : System.Web.UI.Page, ICadastroCategoria
    {
        CadastroCategoriaPresenter presenter;

        private void IniciarPresent()
        {
            presenter = new CadastroCategoriaPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IniciarPresent();
        }

        #region Propriedade

        public int IdCategoria
        {
            get { return Convert.ToInt32(uxtxtIdCategoria.Text); }
        }

        public string DetalheExplicativo
        {
            get { return FreeTextBox1.Text; }
        }

        public string UrlTitle
        {
            get { return uxtxtUrlCategoriaTitle.Text; }
        }

        public string Nome
        {
            get { return uxtxtNomeCategoria.Text; }
        }

        public string Termo
        {
            get { return uxtxtTermo.Text; }
        }

        public string UrlMappings
        {
            get { return uxtxtUrlMappigns.Text; }
        }

        #endregion

        #region Metodos
        public void CarregarCategoria(Categoria categoria)
        {
            uxtxtUrlCategoriaFornecedores.Text = categoria.UrlFornecedores;
            uxtxtNomeCategoria.Text = categoria.Nome;
            uxtxtUrlCategoria.Text = categoria.Url;
            FreeTextBox1.Text = categoria.DetalheExplicativo;
            string title = "Solicite orçamento online " + categoria.Nome + ". Receba cotação de preços de vários fornecedores de " + categoria.Nome + ". Prático, simples, eficaz e grátis!";

            uxtxtUrlCategoriaTitle.Text = title;
            uxtxtUrlMappigns.Text = categoria.UrlMappings;
            uxtxtTermo.Text = categoria.Termo;
        }

        #endregion

        #region Eventos Tela
        protected void uxtbtnBuscar_Click(object sender, EventArgs e)
        {
            presenter.CarregarCategoria();
        }

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            presenter.Salvar();
            uxtxtNomeCategoria.Text = "";
            uxtxtUrlCategoria.Text = "";
            uxtxtUrlCategoriaTitle.Text = "";
            uxtxtUrlCategoriaFornecedores.Text = "";
            uxtxtUrlMappigns.Text = "";
            uxtxtTermo.Text = "";
        }
        #endregion
    }
}
