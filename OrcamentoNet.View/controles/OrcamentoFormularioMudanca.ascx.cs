using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.IView;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.View.controles
{
    public partial class OrcamentoFormularioMudanca : System.Web.UI.UserControl, ICadastroPedidoOrcamentoSimples
    {
        CadastroPedidoOrcamentoSimplesPresenter presenter;
        IList<string> subcategoriaId;
        private int idCategoriaRecebida;
        private int idTipoOrcamento;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CadastroPedidoOrcamentoSimplesPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            idTipoOrcamento = (Request.Params["idTipoOrcamento"] != null) ? Int32.Parse(Request.Params["idTipoOrcamento"]) : 0;
            idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;

            if (!IsPostBack)
            {
                this.InicializarTela();
            }
            
        }

        #region Propriedades

        public PessoaTipo PessoaTipo
        {
            get
            {
                //string tipoPessoa = Enum.GetName(typeof(PessoaTipo), uxddlTipoPessoa.SelectedValue);
                return (PessoaTipo)Enum.Parse(typeof(PessoaTipo), "");
            }
        }


        public int IdTipoServicoOrcamento
        {
            get { return idTipoOrcamento; }
        }

        public IList<string> Fotos
        {
            get { return null; }
        }

        public IList<Termo> Termos
        {
            get { return new List<Termo>(); }
        }

        public int IdPretensao
        {
            get { return 10; }

        }

        public string TelefoneOperadora
        {
            get
            {
                return uxtxtTelefoneOperadora.Text;
            }
        }

        public string Email
        {
            get { return uxtxtEmail.Text; }
        }

        public string Nome
        {
            get { return uxtxtNome.Text; }
        }


        public int IdCategoriaRecebida
        {
            get { return idCategoriaRecebida; }
        }

        public int IdCidadePedidoOrcamento
        {
            get { return CidadeDropDownControle1.ObterIdCidadeSelecionada(); }
        }

        public string Observacao
        {
            get
            {
                return uxtxtObservacao.Text + Environment.NewLine + Environment.NewLine
                    + "Bairro Origem: " + uxtxtCidadeBairroOrigem.Text + Environment.NewLine
                    + "UF / Cidade / Bairro - DESTINO " + uxtxtCidadeBairroDestino.Text + Environment.NewLine
                    ;
            }
        }

        public bool PalavraEhCorreta
        {
            get { return CaptchaControle1.PalavraEhCorreta; }
        }        

        public IList<string> SubCategorias
        {
            get
            {
                subcategoriaId = new List<string>();
                subcategoriaId.Add(ViewState["IdCategoria"].ToString());

                return subcategoriaId;
            }
        }

        public string Titulo
        {
            get { return uxtxtTitulo.Text; }
        }

        public string Telefone
        {
            get { return uxtxtDDD.Text + "-" + uxtxtTelefone.Text; }
        }

        #endregion

        #region Eventos Tela

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            presenter.Salvar();
        }

        #endregion

        #region Metodos

        public void ExibirMensagem(string mensagem)
        {

        }

        public void InicializarTela()
        {
        }

        public void LimparTela()
        {
            uxtxtNome.Text = "";
            uxtxtEmail.Text = "";
            uxtxtTitulo.Text = "";
            uxtxtObservacao.Text = "";
        }

        public void RedirecionarPaginaSucesso()
        {
            Response.Redirect("DefaultSucesso.aspx");
        }
        #endregion

       
       
        public void CarregarSubCategorias(IList<global::OrcamentoNet.Entity.Categoria> subCategorias)
        {
            throw new NotImplementedException();
        }
    }
}