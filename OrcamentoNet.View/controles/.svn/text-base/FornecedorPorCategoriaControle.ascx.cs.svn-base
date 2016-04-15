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
    public partial class FornecedorPorCategoriaControle : System.Web.UI.UserControl, IFornecedorPorCategoriaControle
    {
        FornecedorPorCategoriaControlePresenter presenter;
        int idCategoriaRecebida;
        int idCidadeRecebida;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new FornecedorPorCategoriaControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
                idCidadeRecebida = (Request.Params["cidade"] != null) ? Int32.Parse(Request.Params["cidade"]) : 0;

                presenter.CarregarTelaInicial();
            }
        }

        #region Metodos

        public void MontarLinksInternosEstadoCidade(IList<LinkInterno> linksInternosEstadosCidade)
        {
            uxrptLinksEstadoCidade.DataSource = linksInternosEstadosCidade;
            uxrptLinksEstadoCidade.DataBind();
        }

        public void CarregarCategoria(Categoria categoria, string nomeEstado)
        {
            htmlCategoriaH2.InnerText = "Parceiros do Orçamento Online - " + categoria.Nome + nomeEstado;
        }

        public void CarregarFornecedores(IList<Fornecedor> fornecedores)
        {
            uxrptFornecedores.DataSource = fornecedores;
            uxrptFornecedores.DataBind();
        }

        #endregion

        #region Propriedade


        public int IdCategoria
        {
            get { return idCategoriaRecebida; }
        }

        public int IdCidade
        {
            get { return idCidadeRecebida; }
        }
        #endregion
    }
}