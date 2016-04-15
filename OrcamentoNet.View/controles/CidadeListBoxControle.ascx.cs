using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.Entity;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.IView;

namespace OrcamentoNet.View.controles
{
    public partial class CidadeListBoxControle : System.Web.UI.UserControl, ICidadeListBoxControle
    {
        CidadeListBoxControlePresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CidadeListBoxControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
                presenter.CarregarEstados();
            }
        }

        #region Propriedades

        public string Estado
        {
            get { return uxddlEstado.SelectedValue; }
        }

        public IList<int> CidadesDeAtuacao
        {
            get
            {
                List<int> listaIdsCidadesAtuacao = new List<int>();

                foreach (ListItem categoria in uxchkCidades.Items)
                {
                    if (categoria.Selected)
                        listaIdsCidadesAtuacao.Add(Convert.ToInt32(categoria.Value));
                }

                return listaIdsCidadesAtuacao;
            }
        }

        #endregion

        #region Metodos

        public void CarregarCidades(IList<Cidade> cidades)
        {
            uxlblCidade.Visible = true;
            uxchkCidades.DataTextField = "Nome";
            uxchkCidades.DataValueField = "Id";
            uxchkCidades.DataSource = cidades;
            uxchkCidades.DataBind();

        }

        public void CarregarEstados(IList<string> ufs)
        {
            uxddlEstado.DataSource = ufs;
            uxddlEstado.DataBind();
        }


        public void SelecionarEstadoCidade(IList<Cidade> cidadesFornecedor)
        {
            presenter = new CidadeListBoxControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            presenter.CarregarEstados();

            presenter.CarregarCidades();

            int contador = 0;
            foreach (ListItem cidadeDropDown in uxchkCidades.Items)
            {
                foreach (Cidade cidadeFornecedor in cidadesFornecedor)
                {
                    if (cidadeDropDown.Value == cidadeFornecedor.Id.ToString())
                    {
                        uxchkCidades.Items[contador].Selected = true;
                    }
                    contador++;
                }
            }

        }
        #endregion

        protected void uxDdlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.CarregarCidades();
        }

        internal void SelecionarAreaAtuacao(IList<Cidade> cidades)
        {
            uxddlEstado.SelectedValue = cidades[0].Uf.ToString();

            presenter = new CidadeListBoxControlePresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            presenter.CarregarCidades();

            foreach (ListItem item in uxchkCidades.Items)
            {
                foreach (Cidade cidade in cidades)
                {

                    if (item.Value == cidade.Id.ToString())
                    {
                        item.Selected = true;
                    }
                }
            }
        }
    }
}