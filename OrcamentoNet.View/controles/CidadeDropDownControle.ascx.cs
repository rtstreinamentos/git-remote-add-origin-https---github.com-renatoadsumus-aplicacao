using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;

namespace OrcamentoNet.View.controles
{
    public partial class CidadeDropDownControle : System.Web.UI.UserControl, ICidadeDropDownControle
    {
        CidadeDropDownControlePresenter presenter;
        private int idCategoria;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CidadeDropDownControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            idCategoria = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;

            if (!IsPostBack)
            {
                presenter.CarregarTodosEstados();
            }
        }
        #region Propriedades

        public int IdCidade
        {
            get { return int.Parse(uxddlCidade.SelectedValue); }
        } 

        public string Estado
        {
            get { return uxddlEstado.SelectedValue; }
        }
        
        public int IdCategoria
        {
            get
            {
                return idCategoria;
            }
        }
        #endregion

        #region Metodos       

        public void CarregarCidades(IList<Cidade> cidades)
        {
            Cidade cidade = new Cidade();
            cidade.Id = 0;
            cidade.Nome = "Selecione";

            cidades.Add(cidade);
            uxddlCidade.SelectedValue = "0";
            uxddlCidade.DataTextField = "Nome";
            uxddlCidade.DataValueField = "Id";
            uxddlCidade.DataSource = cidades;
            uxddlCidade.DataBind();
        }

        public void CarregarTodosEstados()
        {
            presenter = new CidadeDropDownControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();
            presenter.CarregarTodosEstados();
        }

        public void CarregarEstados(IList<string> ufs)
        {
            uxddlEstado.DataSource = ufs;
            uxddlEstado.DataBind();
        }

        public int ObterIdCidadeSelecionada()
        {
            int idCidadeSelecionada = 0;

            if (uxddlCidade.SelectedValue != "")
                idCidadeSelecionada = Convert.ToInt32(uxddlCidade.SelectedValue);
            return idCidadeSelecionada;

        }

        public void MarcarCidadeEstado(string uf, string idCidade)
        {
            presenter = new CidadeDropDownControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();
            presenter.CarregarTodosEstados();
            uxddlEstado.SelectedValue = uf;
            presenter.CarregarCidades();
            uxddlCidade.SelectedValue = idCidade;

        }

        public void ExibirMensagem(string mensagem)
        {
            uxlblMensagem.Text = mensagem;
        }

        #endregion             

        #region Eventos Tela

        protected void uxDdlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {           
                presenter.CarregarCidades();            
        }  
             

        #endregion
    }
}