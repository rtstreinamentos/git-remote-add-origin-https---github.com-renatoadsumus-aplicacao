using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;

namespace OrcamentoNet.View
{
    public partial class CriarPedido : System.Web.UI.Page, ICriarPedido
    {
        CriarPedidoPresenter presenter;
        FornecedorLogado fornecedorLogado;        

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CriarPedidoPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            fornecedorLogado = new FornecedorLogado();

            if (!IsPostBack)
            {
                if (fornecedorLogado.Fornecedor == null)
                    Response.Redirect(Config.UrlSite + "LoginNovo.aspx");
            }

        }

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            presenter.Salvar();
            LimparTela();
        }

        #region Propriedades
        public string Telefone
        {
            get { return uxtxtDDD.Text + "-" + uxtxtTelefone.Text; }
        }

        public string Email
        {
            get { return uxtxtEmail.Text; }
        }

        public string Nome
        {
            get { return uxtxtNome.Text; }
        }

        public string Titulo
        {
            get { return uxtxtTitulo.Text; }
        }

        public string Observacao
        {
            get
            {
                string htmlTipoPessoa = Environment.NewLine + "Contratante: " + uxddlTipoPessoa.SelectedItem;
                string htmlLigacao = Environment.NewLine + "Prefere ligações no período: " + uxddlLigacao.SelectedValue;
                //string htmlVisitaTecnica = Environment.NewLine + ObterHtmlVisita();
                string hmtlObservacao = Environment.NewLine + uxtxtObservacao.Text + Environment.NewLine + Environment.NewLine;
                return hmtlObservacao + htmlTipoPessoa + htmlLigacao;
            }
        }

        public int IdCidadePedidoOrcamento
        {
            get { return CidadeDropDownControle1.ObterIdCidadeSelecionada(); }
        }

        public string TelefoneOperadora
        {
            get
            {
                return uxtxtTelefoneOperadora.Text;
            }
        }

        public Fornecedor Fornecedor
        {
            get { return fornecedorLogado.Fornecedor; }
        }
        #endregion

        public void LimparTela()
        {
            uxtxtNome.Text = "";
            uxtxtEmail.Text = "";
            uxtxtTitulo.Text = "";
            uxtxtObservacao.Text = "";
            uxtxtDDD.Text = "";
            uxtxtTelefoneOperadora.Text = "";
            uxtxtTelefone.Text = "";
        }
    }
}
