using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;
using OrcamentoNet.Common;

namespace OrcamentoNet.View
{
    public partial class AdminCadastroFornecedor : System.Web.UI.Page, ICadastroFornecedor
    {
        CadastroFornecedorPresenter presenter;
        int idFornecedor = 0;
        private IList<CategoriaPrioridade> categoriasPrioridades = new List<CategoriaPrioridade>();

        private void IniciarPresent()
        {
            presenter = new CadastroFornecedorPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IniciarPresent();
            if (!IsPostBack)
            {
                presenter.CarregarCategoria();
            }

        }

        #region Propriedades

        public IList<int> CidadesDeAtuacao
        {
            get { return CidadeListBoxControle1.CidadesDeAtuacao; }
        }

        public IList<CategoriaPrioridade> CategoriasPrioridades
        {
            get { return categoriasPrioridades; }
        }

        public IList<string> Categorias
        {
            get
            {
                IList<string> categorias = new List<string>();

                foreach (RepeaterItem rptCategoria in uxrptCategorias.Items)
                {
                    Repeater rptSubCategoria = new Repeater();

                    rptSubCategoria = ((Repeater)rptCategoria.FindControl("uxrptSubCategorias"));

                    foreach (RepeaterItem subcategoria in rptSubCategoria.Items)
                    {
                        CheckBox rdbSubCategoria = ((CheckBox)subcategoria.FindControl("uxchkSubCategoria"));
                        TextBox txtPrioridade = ((TextBox)subcategoria.FindControl("uxtxtPrioridade"));

                        if (rdbSubCategoria.Checked)
                        {
                            CategoriaPrioridade categoriaPrioridade = new CategoriaPrioridade();

                            categorias.Add(((Label)subcategoria.FindControl("uxlblIdCategoria")).Text);

                            if (txtPrioridade.Text != "")
                            {
                                categoriaPrioridade.Prioridade = int.Parse(txtPrioridade.Text);
                                Categoria categoria = new Categoria();
                                categoria.Id = int.Parse(((Label)subcategoria.FindControl("uxlblIdCategoria")).Text);
                                categoriaPrioridade.IdCategoria = categoria;
                                categoriasPrioridades.Add(categoriaPrioridade);
                            }
                        }
                    }
                }

                return categorias;
            }
        }

        public DateTime DataVencimento
        {
            get
            {
                if (uxtxtDataCobranca.Text != "")
                    return Convert.ToDateTime(uxtxtDataCobranca.Text);
                else
                    return DateTime.Now
                ;
            }
        }

        public int DiasUltimosPedidos
        {
            get
            {
                return Convert.ToInt32(uxtxtDiasUltimosPedidos.Text);
            }
        }

        public int IdFornecedor
        {
            get { return idFornecedor; }
        }

        public string Descricao
        {
            get { return uxtxtDescricao.Text; }
        }

        public string Email
        {
            get { return uxtxtEmail.Text; }
        }

        public string WebSite
        {
            get { return uxtxtSite.Text; }
        }

        public string Nome
        {
            get { return uxtxtNome.Text; }
        }

        public string Status
        {
            get { return uxddlStatus.SelectedValue; }
        }

        public string Telefone
        {
            get { return uxtxtTelefone.Text; }
        }

        public double ValorMensalidade
        {
            get { return double.Parse(uxtxtValorMensalidade.Text); }
        }

        #endregion

        #region Metodos

        public void CarregarFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor != null)
            {
                multiview01.SetActiveView(viewCadastro);
                uxlblMensagem.Text = "";
                LimparCategoriasSelecionadas();

                uxtxtNome.Text = fornecedor.Nome;
                uxlblSenha.Text = fornecedor.Senha;
                uxtxtTelefone.Text = fornecedor.Telefone;
                uxtxtSite.Text = fornecedor.WebSite;
                uxtxtValorMensalidade.Text = fornecedor.ValorMensalidade.ToString();
                uxtxtDataCobranca.Text = fornecedor.DataAlteracao.ToShortDateString();
                uxtxtDataCadastro.Text = fornecedor.DataCadastro.ToShortDateString();
                uxtxtDescricao.Text = fornecedor.Descricao;
                uxtxtIndicacao.Text = fornecedor.Indicacao;
                uxddlStatus.SelectedValue = fornecedor.Status.ToString();
                uxtxtEmail.Text = fornecedor.Email;
                uxtxtEmailSecundario.Text = fornecedor.EmailSecundario;
                uxtxtTipoPessoa.Text = fornecedor.TipoPessoaAtendimento.ToString();

                hpyFichaTecnica.Text = fornecedor.Id.ToString();
                hpyFichaTecnica.NavigateUrl = Config.UrlSite + "Ficha_Tecnica.aspx?n=" + fornecedor.Id.ToString();

                foreach (RepeaterItem rptCategoria in uxrptCategorias.Items)
                {
                    Repeater rptSubCategoria = new Repeater();

                    rptSubCategoria = ((Repeater)rptCategoria.FindControl("uxrptSubCategorias"));

                    foreach (RepeaterItem subcategoria in rptSubCategoria.Items)
                    {
                        foreach (Categoria item in fornecedor.SubCategorias)
                        {
                            if (item.Id == Convert.ToInt32((((Label)subcategoria.FindControl("uxlblIdCategoria")).Text)))
                            {
                                ((CheckBox)subcategoria.FindControl("uxchkSubCategoria")).Checked = true;
                                TextBox txtPrioridade = ((TextBox)subcategoria.FindControl("uxtxtPrioridade"));

                                if (fornecedor.CategoriasPrioridade.Where(x => x.IdCategoria.Id == item.Id).ToList().Count > 0)
                                {
                                    txtPrioridade.Text = fornecedor.CategoriasPrioridade.Where(x => x.IdCategoria.Id == item.Id).FirstOrDefault().Prioridade.ToString();
                                }
                            }
                        }
                    }
                }

                CidadeListBoxControle1.SelecionarAreaAtuacao(fornecedor.Cidades);
            }
            else
            {
                uxlblMensagem.Text = "Forncedor Não Cadastrado";
            }
        }

        private void LimparTela()
        {
            uxtxtNome.Text = "";
            uxtxtTelefone.Text = "";
            uxtxtSite.Text = "";
            uxtxtValorMensalidade.Text = "";
            uxtxtDataCobranca.Text = "";
            uxtxtDescricao.Text = "";
            uxtxtEmail.Text = "";
            uxtxtDataCadastro.Text = "";
            uxtxtIndicacao.Text = "";
        }

        private void LimparCategoriasSelecionadas()
        {
            foreach (RepeaterItem rptCategoria in uxrptCategorias.Items)
            {
                Repeater rptSubCategoria = new Repeater();

                rptSubCategoria = ((Repeater)rptCategoria.FindControl("uxrptSubCategorias"));

                foreach (RepeaterItem subcategoria in rptSubCategoria.Items)
                {
                    CheckBox rdbSubCategoria = ((CheckBox)subcategoria.FindControl("uxchkSubCategoria"));
                    TextBox txtPrioridade = ((TextBox)subcategoria.FindControl("uxtxtPrioridade"));

                    txtPrioridade.Text = "";
                    rdbSubCategoria.Checked = false;
                }
            }
        }

        public void CarregarFornecedoresNovos(IList<Fornecedor> fornecedoresNovos)
        {
            uxgrdFornecedores.DataSource = fornecedoresNovos;
            uxgrdFornecedores.DataBind();
        }

        public void CarregarCategoria(IList<Categoria> categorias)
        {
            uxrptCategorias.DataSource = categorias;
            uxrptCategorias.DataBind();
        }

        #endregion

        #region Eventos Tela

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            presenter.Salvar();           
        }

        protected void uxbtnBuscar_Click(object sender, EventArgs e)
        {
           // LimparTela();
           // LimparCategoriasSelecionadas();
            presenter.CarregarFornecedor();
        }

        protected void uxbtnEnviar_Click(object sender, EventArgs e)
        {
            if (uxtxtEmailLogin.Text == "orcamentos.net@gmail.com" && uxtxtSenhaLogin.Text == "orcamentos@2011")
                multiview01.SetActiveView(viewCadastro);
        }

        protected void uxbtnEmailPagamento_Click(object sender, EventArgs e)
        {
            presenter.EnviarEmailConfirmandoPagamento();
        }

        protected void uxbtnEnviarUltimosPedidos_Click(object sender, EventArgs e)
        {
            presenter.EnviarUltimosPedidos(false);
        }

        protected void uxgrdFornecedores_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int linha = e.NewSelectedIndex;
            idFornecedor = int.Parse(uxgrdFornecedores.DataKeys[linha].Value.ToString());
            presenter.CarregarFornecedor();
        }

        protected void uxbtnFornecedoresNovos_Click(object sender, EventArgs e)
        {
            multiview01.SetActiveView(viewNovosFornecedores);
            presenter.CarregarFornecedoresNovos();
        }
        #endregion

        protected void uxbtnEnviarUltimosPedidosTruncados_Click(object sender, EventArgs e)
        {
            presenter.EnviarUltimosPedidos(true);
        }

    }
}
