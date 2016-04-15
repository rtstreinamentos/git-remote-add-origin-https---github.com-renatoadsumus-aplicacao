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
    public partial class AdminAlterarDados : System.Web.UI.Page, IAdminAlterarDados
    {
        AdminAlterarDadosPresenter presenter;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            IniciarPresent();
            if (!IsPostBack)
            {
                presenter.CarregarCategoria();
                presenter.CarregarFornecedor();
            }

        }

        #region Propriedade

        public string BairroAreaAtuacao
        {
            get { return uxtxtAreaAtuacao.Text; }
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

                        if (rdbSubCategoria.Checked)
                        {
                            categorias.Add(((Label)subcategoria.FindControl("uxlblIdCategoria")).Text);
                        }
                    }
                }

                return categorias;
            }
        }
       
        public IList<int> CidadesDeAtuacao
        {
            get { return CidadeListBoxControle1.CidadesDeAtuacao; }
        }

        public string Descricao
        {
            get { return uxtxtDescricao.Text; }
        }

        public string Email
        {
            get { return Session["Email"].ToString(); }
        }

        public string WebSite
        {
            get { return uxtxtSite.Text; }
        }

        public string Nome
        {
            get { return uxtxtNome.Text; }
        }

        public string Telefone
        {
            get { return uxtxtDDD.Text + "-" + uxtxtTelefone.Text; }
        }


        #endregion

        #region Métodos
        private void IniciarPresent()
        {
            presenter = new AdminAlterarDadosPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();
        }

        public void CarregarCategoria(IList<Categoria> categorias)
        {
            uxrptCategorias.DataSource = categorias;
            uxrptCategorias.DataBind();
        }

        public void CarregarFornecedor(Fornecedor fornecedor)
        {
            uxtxtNome.Text = fornecedor.Nome;
            uxtxtTelefone.Text = fornecedor.Telefone;
            uxtxtSite.Text = fornecedor.WebSite;
            uxtxtDescricao.Text = fornecedor.Descricao;
            uxtxtEmail.Text = fornecedor.Email;
            CidadeListBoxControle1.SelecionarEstadoCidade(fornecedor.Cidades);

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
                        }
                    }
                }
            }
        }

        public void CalcularValorMensalidade(double valorMensalidade)
        {
            uxlblValorMensalidade.Text = "Valor da Mensalidade:R$ " + valorMensalidade.ToString() + ",00";
        }

        public void LimparTela()
        {
            uxtxtNome.Text = "";
            uxtxtEmail.Text = "";
            uxtxtDDD.Text = "";
            uxtxtTelefone.Text = "";
            uxtxtSite.Text = "";
            uxtxtDescricao.Text = "";
            uxlblMensagemInferior.Text = "";
        }
        #endregion

        protected void uxbtnCalcularValor_Click(object sender, EventArgs e)
        {
            presenter.CalcularValorMensalidade();
        }

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {

        }        
    }
}
