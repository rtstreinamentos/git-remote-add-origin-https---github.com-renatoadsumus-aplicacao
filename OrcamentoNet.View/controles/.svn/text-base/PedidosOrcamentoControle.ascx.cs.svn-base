using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;
using System.Collections.Specialized;

namespace OrcamentoNet.View.controles
{
    public partial class PedidosOrcamentoControle : System.Web.UI.UserControl, IPedidosOrcamentoControle
    {
        PedidosOrcamentoControlePresenter presenter;
        int idCategoria = 0;
        int idCidade = 0;
        int idMes = 0;
        int ano = 0;
        int idTipoOrcamento = 0;
        string termoPesquisa = String.Empty;
        public int quantidadePedidos = 20;
        private int idBairro;

        private void IniciarPresent()
        {
            presenter = new PedidosOrcamentoControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IniciarPresent();

            idCategoria = (Request.QueryString["categoria"] != null) ? Convert.ToInt32(Request.QueryString["categoria"].ToString()) : 0;
            idCidade = (Request.QueryString["cidade"] != null) ? Convert.ToInt32(Request.QueryString["cidade"].ToString()) : 0;
            idTipoOrcamento = (Request.QueryString["idTipoOrcamento"] != null) ? Convert.ToInt32(Request.QueryString["idTipoOrcamento"].ToString()) : 0;
            idMes = (Request.QueryString["mes"] != null) ? Convert.ToInt32(Request.QueryString["mes"].ToString()) : 0;
            ano = (Request.QueryString["ano"] != null) ? Convert.ToInt32(Request.QueryString["ano"].ToString()) : 0;
            termoPesquisa = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString().Replace("-", " ") : String.Empty;
            idBairro = (Request.Params["bairro"] != null) ? Int32.Parse(Request.Params["bairro"]) : 0;

            if (!IsPostBack)
            {
                presenter.CarregarPedidosOrcamentos();
                presenter.CarregarPedidosOrcamentosComFoto();
            }
        }

        #region Propriedades
        public int IdPretensao
        {
            get { return 10; }
        }

        public int IdTipoOrcamento
        {
            get { return idTipoOrcamento; }
        }

        public int Mes
        {
            get { return idMes; }
        }

        public int IdCategoria
        {
            get { return idCategoria; }
        }
        public int IdCidade
        {
            get { return idCidade; }
        }

        public int IdBairro
        {
            get { return idBairro; }
        }

        public string TermoPesquisa
        {
            get { return termoPesquisa; }
        }

        public int QuantidadePedidos
        {

            get { return quantidadePedidos; }

        }
        #endregion

        #region Metodos
        public void CarregarPedidosOrcamentos(IList<PedidoOrcamento> pedidosOrcamentos)
        {
            if ((pedidosOrcamentos == null) || (pedidosOrcamentos.Count == 0))
            {
                mensagemVazio.InnerText = "Nenhuma oportunidade de negócio localizada.";
            }
            else
            {
                uxrptPedidosOrcamentos.DataSource = pedidosOrcamentos;
                uxrptPedidosOrcamentos.DataBind();

                //if (IdTipoOrcamento == 0)
                //{
                //    uxrptPedidosOrcamentosPreco.Visible = false;
                //    uxrptPedidosOrcamentos.Visible = true;
                //    uxrptPedidosOrcamentos.DataSource = pedidosOrcamentos;
                //    uxrptPedidosOrcamentos.DataBind();
                //}
                //else
                //{
                //    uxrptPedidosOrcamentos.Visible = false;
                //    uxrptPedidosOrcamentosPreco.Visible = true;
                //    uxrptPedidosOrcamentosPreco.DataSource = pedidosOrcamentos;
                //    uxrptPedidosOrcamentosPreco.DataBind();
                //}
            }
        }

        public void CarregarPedidosOrcamentoComFoto(IList<PedidoOrcamento> pedidosOrcamentosComFoto)
        {
            uxrptPedidosOrcamentosComImagem.DataSource = pedidosOrcamentosComFoto;
            uxrptPedidosOrcamentosComImagem.DataBind();
        }
        #endregion
    }
}