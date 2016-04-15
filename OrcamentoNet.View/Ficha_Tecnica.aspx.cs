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
    public partial class Ficha_Tecnica : System.Web.UI.Page, IFicha_Tecnica
    {
        Ficha_TecnicaPresenter presenter;
        int idFornecedor = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new Ficha_TecnicaPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (Request.QueryString["n"] != null)
            {
                try
                {
                    idFornecedor = Convert.ToInt32(Request.QueryString["n"]);
                }
                catch (Exception ex)
                {

                }
                presenter.CarregarFornecedor();
            }

        }

        #region Propriedades

        public int IdFornecedor
        {
            get { return this.idFornecedor; }
        }

        public string Descricao
        {
            get { return uxtxtDescricao.Text; }
        }

        public string Satisfacao
        {
            get { return uxddlSatisfacao.SelectedValue; }
        }

        public string Titulo
        {
            get { return uxtxtTitulo.Text; }
        }

        public string Nome
        {
            get { return uxtxtNome.Text; }
        }

        public string Email
        {
            get { return uxtxtEmail.Text; }
        }

        #endregion

        #region Metodos

        public void GerarFacebook(string url)
        {
            uxlblFacebook.Text = "<div class='fb-like' data-href='http://orcamentosgratis.net.br/" + url + "' data-layout='standard'" +
                        " data-action='like' data-show-faces='true' data-share='true'>    </div>";
        }
        public void CarregarFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor.Fotos == null)
            {
                divFotos.Visible = false;
            }
            else
            {
                if (fornecedor.Fotos.Count == 0)
                {
                    divFotos.Visible = false;
                }
            }


            if (!String.IsNullOrEmpty(fornecedor.Descricao))
            {
                uxlblDescricao.Text = fornecedor.Descricao.Replace(Environment.NewLine, "<br />");
            }
            uxH3Opiniao.InnerText = "Depoimentos de clientes sobre " + fornecedor.Nome;
            uxH1OpineFornecedor.InnerText = "Opine sobre " + fornecedor.Nome;

            string cidadesDeAtuacao = MontarUnicaLinhaDeAreaDeAtuacao(fornecedor);

            string ramosDeAtividade = MontarUnicaLinhaDeCategorias(fornecedor);

            uxlblTelefone.Text = fornecedor.Telefone;
            uxlblSite.NavigateUrl = fornecedor.WebSite;
            uxlblSite.Text = fornecedor.WebSite;
            uxlblSite.Target = "blank";
            uxlblEmail.Text = fornecedor.Email;
            uxlblCidadesAtuacao.Text = cidadesDeAtuacao;
            uxlblRamosAtividade.Text = ramosDeAtividade;

            uxdltFotos.DataSource = fornecedor.Fotos;
            uxdltFotos.DataBind();
        }

        private static string MontarUnicaLinhaDeAreaDeAtuacao(Fornecedor fornecedor)
        {
            string cidadesDeAtuacao = "";

            foreach (Cidade cidade in fornecedor.Cidades)
            {
                if (cidadesDeAtuacao == "")
                    cidadesDeAtuacao = cidade.Nome;
                else
                    cidadesDeAtuacao = cidadesDeAtuacao + ", " + cidade.Nome;
            }
            return cidadesDeAtuacao;
        }

        private string MontarUnicaLinhaDeCategorias(Fornecedor fornecedor)
        {
            string ramosDeAtividade = "";
            foreach (Categoria categoria in fornecedor.SubCategorias)
            {
                if (ramosDeAtividade == "")
                    ramosDeAtividade = categoria.Nome;
                else
                    ramosDeAtividade = categoria.Nome + ", " + ramosDeAtividade;
            }
            return ramosDeAtividade;
        }

        public void MontarLinksInternosDeEstado(IList<LinkInterno> linksInternosEstadoCidade)
        {
            uxrptLinksEstadoCidade.DataSource = linksInternosEstadoCidade;
            uxrptLinksEstadoCidade.DataBind();
        }

        public void CarregarFornecedoresRelacionados(IList<Fornecedor> fornecedoresRelacionados)
        {
            uxrptEmpresasRelacionadas.DataSource = fornecedoresRelacionados;
            uxrptEmpresasRelacionadas.DataBind();
        }


        public void CarregarOpinioes(IList<Opiniao> opinioes)
        {
            if (opinioes == null || opinioes.Count == 0)
            {
                divDepoimentos.Visible = false;
            }

            uxrptFornecedores.DataSource = opinioes;
            uxrptFornecedores.DataBind();
        }

        public void ExibirMensagem()
        {
            uxlblMensagemInferior.Text = "Após ser aprovada sua opinião será publicada!";
        }

        public void LimparTela()
        {
            uxtxtEmail.Text = "";
            uxtxtNome.Text = "";
            uxtxtTitulo.Text = "";
            uxtxtDescricao.Text = "";
            uxddlSatisfacao.SelectedIndex = 0;
        }

        public void MontarHeadPagina(Fornecedor fornecedor)
        {
            string categorias = MontarUnicaLinhaDeCategorias(fornecedor);
            string cidadesDeAtuacao = MontarUnicaLinhaDeAreaDeAtuacao(fornecedor);
            //string temaDoFornecedor = fornecedor.SubCategorias[0].Pai.Nome;
            
            string titulo = fornecedor.Nome + " - Orçamentos Grátis";
            uxH1NomeFornecedor.InnerText = titulo;

            string descricao = fornecedor.Nome + " oferece serviço de " + categorias + " em " + cidadesDeAtuacao + ". Faça um orçamento sem compromisso!";
            Page.Title = titulo;
            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = descricao;

            Page.Header.Controls.Add(metaHtml);

          
            HtmlMeta ogTitle = new HtmlMeta();
            ogTitle.Attributes.Add("property", "og:title");
            ogTitle.Content = titulo;
            Page.Header.Controls.Add(ogTitle);

            HtmlMeta ogDescription = new HtmlMeta();
            ogDescription.Attributes.Add("property", "og:description");
            ogDescription.Content = descricao;
            Page.Header.Controls.Add(ogDescription);
        }

        #endregion

        #region Eventos Tela

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            if (CaptchaControle1.PalavraEhCorreta)
            {
                presenter.SalvarOpiniao();
            }
        }

        #endregion


    }
}
