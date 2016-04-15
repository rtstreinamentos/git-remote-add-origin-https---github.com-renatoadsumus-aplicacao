using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;
using System.Web.UI.HtmlControls;

namespace OrcamentoNet.View
{
    public partial class Orcamento_Online_Pedido : System.Web.UI.Page, IOrcamento_Online_Pedido
    {
        Orcamento_Online_PedidoPresenter presenter;
        int idCategoriaRecebida;
        int idCidade;
        string termoPesquisa;

        private void IniciarPresent()
        {
            presenter = new Orcamento_Online_PedidoPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IniciarPresent();

            if (!IsPostBack)
            {
                idCategoriaRecebida = 52;// (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
                idCidade = (Request.Params["cidade"] != null) ? Int32.Parse(Request.Params["cidade"]) : 0;
                termoPesquisa = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString().Replace("-", " ") : String.Empty;

                presenter.CarregarEstado();

                Page.Title = "Orçamento para Festas e Eventos";
            }
        }

        #region Propriedades

        public int IdPretensao
        {
            get { return int.Parse(uxddlPretensao.SelectedValue); }

        }

        public IList<int> FornecedoresSelecionados
        {
            get
            {
                IList<Int32> idsFornecedoresSelecionados = new List<Int32>();

                for (int x = 0; x < uxrptFornecedores.Items.Count; x++)
                {
                    if (((CheckBox)uxrptFornecedores.Items[x].FindControl("uxchkFornecedor")).Checked)
                    {
                        int idFornecedor = int.Parse(((Label)uxrptFornecedores.Items[x].FindControl("lblIdFornecedor")).Text);

                        idsFornecedoresSelecionados.Add(idFornecedor);
                    }
                }

                return idsFornecedoresSelecionados;
            }
        }

        public string Email
        {
            get { return uxtxtEmail.Text; }
        }

        public string Estado
        {
            get { return uxddlEstado.SelectedValue; }
        }

        public string Nome
        {
            get { return uxtxtNome.Text; }
        }

        public int IdCidadePedidoOrcamento
        {
            get { return int.Parse(uxddlCidade.SelectedValue); }
        }

        public int IdCategoriaRecebida
        {
            get { return 52; }
        }


        public string Observacao
        {
            get
            {
                string htmlLigacao = "Prefere ligações no período: " + uxddlLigacao.SelectedValue;
                string htmlVisitaTecnica = Environment.NewLine + ObterHtmlVisita();



                if (String.IsNullOrEmpty(uxtxtLocalObra.Text.Trim()))
                {
                    return uxtxtObservacao.Text + Environment.NewLine + Environment.NewLine + "Materiais: " + uxddlMaterias.SelectedValue + Environment.NewLine + "Tipo de imóvel: " + uxddlTipoImovel.SelectedValue + Environment.NewLine + "Metros quadrados (aproximado): " + uxtxtTamanho.Text + Environment.NewLine + htmlLigacao + htmlVisitaTecnica;
                }
                else
                {
                    return uxtxtObservacao.Text + Environment.NewLine + Environment.NewLine + "Bairro, região ou local: " + uxtxtLocalObra.Text + Environment.NewLine + "Materiais: " + uxddlMaterias.SelectedValue + Environment.NewLine + "Tipo de imóvel: " + uxddlTipoImovel.SelectedValue + Environment.NewLine + "Metros quadrados (aproximado): " + uxtxtTamanho.Text + Environment.NewLine + htmlLigacao + htmlVisitaTecnica;
                }
            }
        }

        public bool PalavraEhCorreta
        {
            get { return CaptchaControle1.PalavraEhCorreta; }
        }

        public IList<int> SubCategorias
        {
            get
            {
                List<int> subcategoriaId = new List<int>();
                subcategoriaId.Add(40);
                //foreach (ListItem categoria in uxchkCategoriasTema.Items)
                //{
                //    if (categoria.Selected)
                //        subcategoriaId.Add(int.Parse(categoria.Value));
                //}

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

        #region Metodos

        public void GerarHeaderHTML(Categoria categoria, string nomeCidade)
        {
            string keywords = categoria.Termo;

            string titleDaPagina = categoria.Nome;
            if (!String.IsNullOrEmpty(termoPesquisa)) titleDaPagina = titleDaPagina + " - " + termoPesquisa;
            if (!String.IsNullOrEmpty(nomeCidade)) titleDaPagina = titleDaPagina + " - " + nomeCidade;
            if (titleDaPagina != "Orçamento Online") titleDaPagina = "Orçamento para " + titleDaPagina;
            Page.Title = titleDaPagina;
            //uxTituloH1.InnerText = titleDaPagina;

            string conteudoTexto = categoria.Nome.ToLower();
            if (!String.IsNullOrEmpty(termoPesquisa)) conteudoTexto = conteudoTexto + " para " + termoPesquisa.ToLower();
            if (!String.IsNullOrEmpty(nomeCidade)) conteudoTexto = conteudoTexto + " em " + nomeCidade;
            if (conteudoTexto == "orçamento online") conteudoTexto = "diversos serviços e produtos";
            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = "Solicite orçamento online grátis de " + conteudoTexto + ". Receba cotação de preços de " + conteudoTexto + " de vários fornecedores. Prático, simples, eficaz e grátis!";
            Page.Header.Controls.Add(metaHtml);

            if (!String.IsNullOrEmpty(keywords))
            {
                keywords = keywords + ", " + titleDaPagina.Replace("-", ",");
            }
            else
            {
                keywords = titleDaPagina.Replace("-", ",");
            }
            metaHtml = new HtmlMeta();
            metaHtml.Name = "keywords";
            metaHtml.Content = keywords;
            Page.Header.Controls.Add(metaHtml);
        }

        public void CarregarFornecedoresPorTema(IList<Fornecedor> fornecedores)
        {
            if (fornecedores.Count == 0)
            {
                uxlblMensagemPassoFornecedor.Text = "Não possuímos fornecedor nessa categoria";
            }
            uxrptFornecedores.DataSource = fornecedores;
            uxrptFornecedores.DataBind();
        }

        public void CarregarCategoriasDoTema(Categoria categoria)
        {
            //uxchkCategoriasTema.DataValueField = "Id";
            //uxchkCategoriasTema.DataTextField = "Nome";
            //uxchkCategoriasTema.DataSource = categoria.SubCategorias;
            //uxchkCategoriasTema.DataBind();
        }

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

        public void CarregarEstados(IList<string> estados)
        {
            uxddlEstado.DataSource = estados;
            uxddlEstado.DataBind();
        }


        public void RedirecionarPaginaSucesso()
        {
            Response.Redirect("DefaultSucesso.aspx");
        }

        private string ObterHtmlVisita()
        {
            string diaSemana = "";

            foreach (ListItem item in uxchlDiasSemana.Items)
            {
                if (item.Selected)
                {
                    if (diaSemana == "")
                        diaSemana = item.Text;
                    else
                        diaSemana = diaSemana + "," + item.Text;
                }
            }

            if (diaSemana.Length > 2)
                return "Pefere receber visita técnica no(s) dia(s):" + diaSemana;
            else
                return "Pefere receber visita técnica no(s) dia(s): Não Informado";

        }
        #endregion

        #region Eventos Tela
        protected void uxChkCategoriasTema_SelectedIndexChanged(object sender, EventArgs e)
        {
			//presenter.CarregarFornecedoresPorTema();
		}

        protected void uxDdlCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
			//presenter.CarregarCategoriasDoTema();
            presenter.CarregarFornecedoresPorTema();

		}

        protected void uxDdlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.CarregarCidadesComFornecedor();
        }

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            presenter.SalvarPedido();
        }
        #endregion
    }
}

