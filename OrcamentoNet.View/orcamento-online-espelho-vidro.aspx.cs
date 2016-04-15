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
    public partial class orcamento_online_espelho : System.Web.UI.Page, ICadastroPedidoOrcamentoSimples2
    {
        CadastroPedidoOrcamentoSimplesPresenter2 presenter;
        IList<string> subcategoriaId;
        private int idCategoriaRecebida;
        private int idTipoOrcamento;
        string termoPesquisa;
        private int idCidadeRecebida;
        private int idBairro;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CadastroPedidoOrcamentoSimplesPresenter2();
            presenter.View = this;
            presenter.OnViewInitialized();

            idBairro = (Request.Params["bairro"] != null) ? Int32.Parse(Request.Params["bairro"]) : 0;
            idCidadeRecebida = (Request.Params["cidade"] != null) ? Int32.Parse(Request.Params["cidade"]) : 0;
            idTipoOrcamento = (Request.Params["idTipoOrcamento"] != null) ? Int32.Parse(Request.Params["idTipoOrcamento"]) : 0;
            idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
            termoPesquisa = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString().Replace("-", " ") : String.Empty;

            if (!IsPostBack)
            {
                this.InicializarTela();
                presenter.CarregarSubCategorias();
            }


        }

        #region Propriedades



        public int IdBairroRecebido
        {
            get { return idBairro; }
        }

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

        public int IdPretensao
        {
            get { return 10; }
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

        public IList<Termo> Termos
        {
            get { return new List<Termo>(); }
        }

        public string Email
        {
            get { return uxtxtEmail.Text; }
        }

        public int IdCategoriaRecebida
        {
            get { return idCategoriaRecebida; }
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
                string htmlLigacao = "Prefere ligações no período: " + uxddlLigacao.SelectedValue + ";" + Environment.NewLine;
                string htmlTipo = "Tipo: " + uxddlTipo.SelectedValue + ";" + Environment.NewLine;
                string htmlObservacao = "Descrição:" + uxtxtObservacao.Text + ";" + Environment.NewLine + Environment.NewLine;
                string htmlLarguraAltura = "Largura (aproximada): " + uxtxtLargura.Text + ";" + Environment.NewLine + "Altura (aproximada): " + uxtxtAltura.Text + ";" + Environment.NewLine;
                string htmlGerado = htmlTipo + htmlObservacao + htmlLarguraAltura + htmlLigacao;

                if (!String.IsNullOrEmpty(uxtxtLocalObra.Text.Trim()))
                {
                    return "Bairro, região ou local: " + uxtxtLocalObra.Text + ";" + Environment.NewLine + htmlTipo + htmlObservacao + htmlLarguraAltura + htmlLigacao;
                }

                return htmlGerado;
            }
        }

        public int IdCidadeRecebida
        {
            get { return idCidadeRecebida; }
        }

        public bool PalavraEhCorreta
        {
            get { return true; }
        }

        public IList<string> SubCategorias
        {
            get
            {
                subcategoriaId = new List<string>();
                subcategoriaId.Add(idCategoriaRecebida.ToString());

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
            presenter.Salvar();
        }

        protected void uxbtnFoto_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();

                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };

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
                else
                {
                    uxlblMensagemFoto.Text = "Ops, sua foto é maior que 2 MB!";
                }
            }
            else
            {
                uxlblMensagemFoto.Text = "Ops, nenhuma foto foi adicionada!";
            }
        }

        #endregion

        #region Metodos

        public void ExibirMensagem(string mensagem)
        {
        }

        public void InicializarTela()
        {
        }

        public void LimparTela()
        {
            uxtxtNome.Text = "";
            uxtxtEmail.Text = "";
            uxtxtTitulo.Text = "";
            uxtxtObservacao.Text = "";
        }

        public void RedirecionarPaginaSucesso()
        {
            Response.Redirect("DefaultSucesso.aspx");
        }
        #endregion

        public void CarregarSubCategorias(IList<global::OrcamentoNet.Entity.Categoria> subCategorias)
        {

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
    }

}
