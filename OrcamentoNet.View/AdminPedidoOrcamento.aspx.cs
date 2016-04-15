using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.View
{
    public partial class AdminPedidoOrcamento : System.Web.UI.Page, IAdminPedidoOrcamento
    {
        AdminPedidoOrcamentoPresenter presenter;

        private void IniciarPresent()
        {
            presenter = new AdminPedidoOrcamentoPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IniciarPresent();
            if (!IsPostBack)
            {
                presenter.CarregarCategoria();
                presenter.CarregarPerguntasCompletarPedido();
                CidadeDropDownControle1.CarregarTodosEstados();
            }

        }

        #region Propriedades


        public ClassificacaoPedido ClassificacaoPedido
        {
            get { return (ClassificacaoPedido)Enum.Parse(typeof(ClassificacaoPedido), uxddlClassificaoPedido.SelectedValue); }
        }


        public string EmailFornecedorAvulso
        {
            get { return uxtxtEmailFornecedorAvulso.Text; }
        }

        public string NomeFornecedorAvulso
        {
            get { return uxtxtNomeFornecedor.Text; }
        }
        public string FotoPrincipal
        {
            get { return uxtxtFotoPrincipal.Text; }
        }

        public string ApareceNoSite
        {
            get { return uxApareceNoSite.SelectedValue; }
        }

        public int DiaPedido
        {
            get { return Int32.Parse(uxddlDias.SelectedValue); }
        }

        public int IdPedidoOrcamento
        {
            get
            {
                int idPedido = 0;

                if (ViewState["IdPedido"] == null)
                    idPedido = int.Parse(uxtxtId.Text);
                else
                    idPedido = int.Parse(ViewState["IdPedido"].ToString());
                
                return idPedido;
            }
        }

        public string Email
        {
            get { return uxtxtEmail.Text; }
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

        public int IdCidade
        {
            get { return CidadeDropDownControle1.ObterIdCidadeSelecionada(); }
        }

        public string Observacao
        {
            get { return uxtxtObservacao.Text; }
        }
        public string Perguntas
        {
            get { return uxtxtMaisInformacoesPedido.Text; }
        }

        public string Titulo
        {
            get { return uxtxtTitulo.Text; }
        }
        #endregion

        #region Metodos

        public void CarregarCategoria(IList<Categoria> categorias)
        {
            uxrptCategorias.DataSource = categorias;
            uxrptCategorias.DataBind();
        }

        public void CarregarPedidoOrçamento(PedidoOrcamento pedidoOrcamento)
        {
            multiview01.SetActiveView(viewCadastro);
            uxddlEmailValidado.SelectedValue = ((int)pedidoOrcamento.Status).ToString();
            uxtxtEmail.Text = pedidoOrcamento.Email;
            uxlblNome.Text = pedidoOrcamento.NomeComprador;
            uxtxtObservacao.Text = pedidoOrcamento.Observacao;
            uxtxtTitulo.Text = pedidoOrcamento.Titulo;
            uxtxtTelefone.Text = pedidoOrcamento.Telefone;
            uxtxtFotoPrincipal.Text = pedidoOrcamento.FotoPrincipal;
            uxddlClassificaoPedido.SelectedValue = ((int)pedidoOrcamento.ClassificacaoPedido).ToString();
            uxrptFotos.DataSource = pedidoOrcamento.Fotos;
            uxrptFotos.DataBind();

            CidadeDropDownControle1.MarcarCidadeEstado(pedidoOrcamento.Cidade.Uf.ToString(), pedidoOrcamento.Cidade.Id.ToString());

            foreach (RepeaterItem rptCategoria in uxrptCategorias.Items)
            {
                Repeater rptSubCategoria = new Repeater();

                rptSubCategoria = ((Repeater)rptCategoria.FindControl("uxrptSubCategorias"));

                foreach (RepeaterItem subcategoria in rptSubCategoria.Items)
                {
                    foreach (Categoria categoria in pedidoOrcamento.Categorias)
                    {
                        if (categoria.Id == Convert.ToInt32((((Label)subcategoria.FindControl("uxlblIdCategoria")).Text)))
                        {
                            ((CheckBox)subcategoria.FindControl("uxchkSubCategoria")).Checked = true;
                        }
                    }

                }
            }
        }

        public void CarregarPerguntasCompletarPedido(string perguntas)
        {
            uxtxtMaisInformacoesPedido.Text = perguntas;

        }
        #endregion

        #region Eventos Tela

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            presenter.Salvar();
        }

        protected void uxbtnBuscar_Click(object sender, EventArgs e)
        {
            presenter.CarregarPedidoOrcamento();
        }

        protected void uxbtnEnviar_Click(object sender, EventArgs e)
        {
            if (uxtxtEmailLogin.Text == "orcamentos.net@gmail.com" && uxtxtSenhaLogin.Text == "orcamentos@2011")
            {
                presenter.CarregarUltimosPedidos();
                multiview01.SetActiveView(viewCadastro);
            }
        }

        protected void uxbtnSolicitarMaisInformacao_Click(object sender, EventArgs e)
        {
            presenter.SolicitarMaisInformacao();
        }

        #endregion

        protected void uxgrdPedidos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int linha = e.NewSelectedIndex;
            ViewState["IdPedido"] = uxgrdPedidos.DataKeys[linha].Value.ToString();
            presenter.CarregarPedidoOrcamento();
        }


        public void CarregarUltimosPedidos(IList<PedidoOrcamento> pedidosOrcamento)
        {
           // uxgrdPedidos.DataSource = pedidosOrcamento;
            //uxgrdPedidos.DataBind();
        }


        protected void uxgrdPedidos_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Aprovar")
            {
                int linha = Convert.ToInt32(e.CommandArgument);
                ViewState["IdPedido"] = uxgrdPedidos.DataKeys[linha].Value.ToString();
                presenter.AprovarPedido();
            }
        }

        protected void uxddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.CarregarUltimosPedidos();
        }

        protected void uxbtnCompraAvulsa_Click(object sender, EventArgs e)
        {
            presenter.NotificarFornecedorCompraAvulsa();
        }
    }
}
