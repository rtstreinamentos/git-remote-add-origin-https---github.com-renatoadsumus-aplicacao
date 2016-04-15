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
using OrcamentoNet.Entity._enum;
using System.Web.UI.HtmlControls;

namespace OrcamentoNet.View
{
    public partial class orcamento_online_obras_reformas : System.Web.UI.Page, ICadastroPedidoOrcamentoSimples2
    {
        CadastroPedidoOrcamentoSimplesPresenter2 presenter;
        private int idCategoriaRecebida;
        private List<Termo> termos;
        private int idTipoOrcamento;
        string termoPesquisa;
        private int idCidadeRecebida;
        private int idBairro;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CadastroPedidoOrcamentoSimplesPresenter2();
            presenter.View = this;
            presenter.OnViewInitialized();

            idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
            idBairro = (Request.Params["bairro"] != null) ? Int32.Parse(Request.Params["bairro"]) : 0;
            idCidadeRecebida = (Request.Params["cidade"] != null) ? Int32.Parse(Request.Params["cidade"]) : 0;
            idTipoOrcamento = (Request.Params["idTipoOrcamento"] != null) ? Int32.Parse(Request.Params["idTipoOrcamento"]) : 0;
            termoPesquisa = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString().Replace("-", " ") : String.Empty;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script type='text/javascript'>var loadingdiv = document.getElementById('loading'); loadingdiv.style.display = block';</script>", false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "temp", "<script language='javascript'>var loadingdiv = document.getElementById('loading'); loadingdiv.style.display = block';</script>", false);

            if (!IsPostBack)
            {
                presenter.CarregarSubCategorias();
                uxtxtTitulo.Text = termoPesquisa.ToUpper();
            }
        }

        #region Propriedades


        public PessoaTipo PessoaTipo
        {
            get
            {
                return (PessoaTipo)Enum.Parse(typeof(PessoaTipo), uxddlTipoPessoa.SelectedValue);
            }
        }

        public int IdTipoServicoOrcamento
        {
            get { return idTipoOrcamento; }
        }

        public IList<string> Fotos
        {
            get
            {
                if (uxlblFotos.Text != "")
                    return uxlblFotosGuids.Text.Split(',');
                else
                    return null;
            }
        }

        public int IdPretensao
        {
            get { return int.Parse(uxddlPretensao.SelectedValue); }
        }

        public string Email
        {
            get { return uxtxtEmail.Text; }
        }

        public string Nome
        {
            get { return uxtxtNome.Text; }
        }

        public int IdCidadePedidoOrcamento
        {
            get { return CidadeDropDownControle1.ObterIdCidadeSelecionada(); }
        }

        public string Observacao
        {
            get
            {
                string htmlTipoPessoa = Environment.NewLine + "Contratante: " + uxddlTipoPessoa.SelectedItem + ";";
                string htmlLigacao = Environment.NewLine + "Prefere ligações no período: " + uxddlLigacao.SelectedValue + ";";
                string htmlVisitaTecnica = Environment.NewLine + ObterHtmlVisita() + ";";
                string hmtlObservacao = Environment.NewLine + "Descrição: " + uxtxtObservacao.Text + ";" + Environment.NewLine + Environment.NewLine;
                string htmlMaterias = "Materiais: " + uxddlMaterias.SelectedValue + ";" + Environment.NewLine;
                string htmlHabitado = Environment.NewLine + "Imóvel habitado:" + uxddlHabitado.SelectedValue + ";";
                string htmlTipoImovel = "Tipo de imóvel: " + uxddlTipoImovel.SelectedValue + ";" + Environment.NewLine;
                string htmlMetrosQuadrados = "Metros quadrados (aproximado): " + uxtxtTamanho.Text + ";";

                string htmlBairro = Environment.NewLine + "Bairro, região ou local: " + uxtxtLocalObra.Text + ";" + Environment.NewLine;
                string htmlResultado = htmlTipoPessoa + hmtlObservacao + htmlMaterias + htmlTipoImovel + htmlMetrosQuadrados + htmlHabitado + htmlLigacao + htmlVisitaTecnica;

                if (!String.IsNullOrEmpty(uxtxtLocalObra.Text.Trim()))
                {

                    htmlResultado = htmlResultado + htmlBairro;

                }
                return htmlResultado;

            }
        }

        public bool PalavraEhCorreta
        {
            get { return true; }
        }

        public IList<string> SubCategorias
        {
            get
            {
                return ObterCategorias();
            }
        }

        public int IdCategoriaRecebida
        {
            get { return idCategoriaRecebida; }
        }

        public int IdCidadeRecebida
        {
            get { return idCidadeRecebida; }
        }

        public int IdBairroRecebido
        {
            get { return idBairro; }
        }

        public IList<Termo> Termos
        {
            get { return termos; }
        }

        public string Titulo
        {
            get { return uxtxtTitulo.Text; }
        }

        public string Telefone
        {
            get { return uxtxtDDD.Text + "-" + uxtxtTelefone.Text; }
        }


        public string TelefoneOperadora
        {
            get
            {
                return uxtxtTelefoneOperadora.Text;
            }
        }

        #endregion

        #region Eventos Tela

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            if (Session["PedidoGravado"] == null)
            {
                presenter.Salvar();
            }
        }

        protected void uxbtnFoto_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();

                String[] allowedExtensions = UtilString.ObterExtensoesArquivosValidos();

                int fileSize = FileUpload1.PostedFile.ContentLength;

                if (allowedExtensions.Contains(fileExtension) && fileSize < 2100000)
                {
                    uxlblMensagemFoto.Text = "";

                    try
                    {
                        Guid guid = Guid.NewGuid();

                        string nomeArquivo = guid.ToString() + fileExtension;
                        FileUpload1.SaveAs(Config.CaminhoFisico + "\\FotosComprador\\" + nomeArquivo);


                        if (uxlblFotos.Text != "")
                        {
                            uxlblFotos.Text = uxlblFotos.Text + "," + FileUpload1.FileName;
                        }
                        else
                        {
                            uxlblFotos.Text = FileUpload1.FileName;
                        }

                        if (uxlblFotosGuids.Text != "")
                        {
                            uxlblFotosGuids.Text = uxlblFotosGuids.Text + "," + nomeArquivo;
                        }
                        else
                        {
                            uxlblFotosGuids.Text = nomeArquivo;
                        }

                    }
                    catch
                    {
                        uxlblMensagemFoto.Text = "Ops! Ocorreu uma falha." + Environment.NewLine + Environment.NewLine + "Favor enviar as fotos para orcamentos.net@gmail.com";
                    }
                }
            }
            else
            {
                uxlblMensagemFoto.Text = "Ops, nenhuma foto foi adicionada!";
            }
        }

        #endregion

        #region Metodos

        private IList<string> ObterCategorias()
        {
            IList<string> categorias = new List<string>();
            termos = new List<Termo>();
            string idCategoriaNoTermo = "";

            foreach (RepeaterItem itemSubCategoria in uxrptCategorias.Items)
            {
                Repeater uxrptTermos = new Repeater();
                uxrptTermos = ((Repeater)itemSubCategoria.FindControl("uxrptTermos"));

                idCategoriaNoTermo = ((Label)itemSubCategoria.FindControl("uxlblIdCategoria")).Text;

                foreach (RepeaterItem itemTermo in uxrptTermos.Items)
                {
                    //idCategoriaNoTermo = ((Label)itemTermo.FindControl("uxlblIdCategoriaTermo")).Text;

                    if (((CheckBox)itemTermo.FindControl("uxchkTermo")).Checked)
                    {
                        string termoSelecionado = ((Label)itemTermo.FindControl("uxlblTermo")).Text;

                        Termo termo = new Termo();
                        termo.IdCategoria = int.Parse(idCategoriaNoTermo);
                        termo.Nome = termoSelecionado;

                        termos.Add(termo);

                        if (!categorias.Contains(idCategoriaNoTermo))
                        {
                            categorias.Add(idCategoriaNoTermo);
                        }
                    }
                }

                string outroTermo = ((TextBox)uxrptTermos.Controls[uxrptTermos.Controls.Count - 1].FindControl("uxtxtOutroTermo")).Text;

                //Se usuário digitou a Textbox de Outros
                if (outroTermo != "")
                {
                    Termo termo = new Termo();
                    termo.IdCategoria = int.Parse(idCategoriaNoTermo);
                    termo.Nome = outroTermo;

                    termos.Add(termo);

                    if (!categorias.Contains(idCategoriaNoTermo))
                    {
                        categorias.Add(idCategoriaNoTermo);
                    }
                }
            }

            return categorias;

        }

        public void CarregarSubCategorias(IList<Categoria> subCategorias)
        {
            if (subCategorias.Count > 0)
            {
                uxlblMensagem.Text = "";

                uxrptCategorias.DataSource = subCategorias;
                uxrptCategorias.DataBind();
            }
        }

        public void ExibirMensagem(string mensagem)
        {
            uxlblMensagem.Text = mensagem;
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
                        diaSemana = diaSemana + ", " + item.Text;
                }
            }

            if (diaSemana.Length > 2)
                return "Prefere receber visita técnica no(s) dia(s):" + diaSemana;
            else
                return "Prefere receber visita técnica no(s) dia(s): não informado";

        }


        public void RedirecionarPaginaSucesso()
        {
            Session["PedidoGravado"] = "GRAVADO";

            Session.Timeout = 2;

            Response.Redirect("DefaultSucesso.aspx");
        }

        public void CarregarCategoria(string nomeCategoria, string nomeCidade, Categoria categoria)
        {
            uxlblExplicacao.Text = categoria.DetalheExplicativo;
            GerarHeaderHTML(nomeCategoria, nomeCidade, categoria.Termo);
        }

        private void GerarHeaderHTML(string nomeCategoria, string nomeCidade, string keywords)
        {
            string titleDaPagina = nomeCategoria;

            if (!String.IsNullOrEmpty(termoPesquisa)) titleDaPagina = titleDaPagina + " - " + termoPesquisa;

            if (!String.IsNullOrEmpty(nomeCidade)) titleDaPagina = titleDaPagina + " - " + nomeCidade;

            if (titleDaPagina != "Orçamento Online") titleDaPagina = "Orçamento Online Grátis para " + titleDaPagina;

            Page.Title = titleDaPagina;
            uxTituloH1.InnerText = titleDaPagina;

            string conteudoTexto = nomeCategoria.ToLower();
            if (!String.IsNullOrEmpty(termoPesquisa)) conteudoTexto = conteudoTexto + " para " + termoPesquisa.ToLower();
            if (!String.IsNullOrEmpty(nomeCidade)) conteudoTexto = conteudoTexto + " em " + nomeCidade;
            if (conteudoTexto == "orçamento online") conteudoTexto = "diversos serviços e produtos";

            string descricao = "Solicite orçamento online grátis de " + conteudoTexto + ". Receba cotação de preços de " + conteudoTexto + " de vários fornecedores. Prático, simples, eficaz e grátis!";
            HtmlMeta metaHtml = new HtmlMeta();
            metaHtml.Name = "description";
            metaHtml.Content = descricao;
            Page.Header.Controls.Add(metaHtml);

            HtmlMeta ogTitle = new HtmlMeta();
            ogTitle.Attributes.Add("property", "og:title");
            ogTitle.Content = titleDaPagina;
            Page.Header.Controls.Add(ogTitle);

            HtmlMeta ogDescription = new HtmlMeta();
            ogDescription.Attributes.Add("property", "og:description");
            ogDescription.Content = descricao;
            Page.Header.Controls.Add(ogDescription);

            if (!String.IsNullOrEmpty(keywords))
            {
                keywords = keywords + ", " + titleDaPagina.Replace("-", ",");
            }
            else
            {
                keywords = titleDaPagina.Replace("-", ",");
            }

            //metaHtml = new HtmlMeta();
            //metaHtml.Name = "keywords";
            //metaHtml.Content = keywords;
            //Page.Header.Controls.Add(metaHtml);

            ExibirMensagem("<p class='productDescription'>Faça sua cotação de preços de <strong>" + conteudoTexto + "</strong> no Orçamento Online. Seu <strong>pedido de orçamento</strong> será enviado aos nossos fornecedores, que enviarão as cotações de preços diretamente para você. De graça!</p>");
        }
        #endregion
    }

}
