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

namespace OrcamentoNet.View.controles
{
    public partial class OrcamentoFormularioGenerico : System.Web.UI.UserControl, ICadastroPedidoOrcamentoSimples
    {
        CadastroPedidoOrcamentoSimplesPresenter presenter;
        IList<string> subcategoriaId;
        int idCategoriaRecebida;
        private int idTipoOrcamento;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CadastroPedidoOrcamentoSimplesPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            idTipoOrcamento = (Request.Params["idTipoOrcamento"] != null) ? Int32.Parse(Request.Params["idTipoOrcamento"]) : 0;

            if (!IsPostBack)
            {
                this.InicializarTela();
            }

            idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
        }

        #region Propriedades
        public PessoaTipo PessoaTipo
        {
            get
            {
                string tipoPessoa = Enum.GetName(typeof(PessoaTipo), uxddlTipoPessoa.SelectedValue);
                return (PessoaTipo)Enum.Parse(typeof(PessoaTipo), tipoPessoa);
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
            get { return 10; }
        }

        public IList<Termo> Termos
        {
            get { return new List<Termo>(); }
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
                return uxtxtObservacao.Text + Environment.NewLine + Environment.NewLine
                  + "Prefere ligações no período: " + uxddlLigacao.SelectedValue;
            }
        }

        public bool PalavraEhCorreta
        {
            get { return CaptchaControle1.PalavraEhCorreta; }
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

        public int IdCategoriaRecebida
        {
            get { return idCategoriaRecebida; }
        }

        #endregion

        #region Eventos Tela

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

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            presenter.Salvar();
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

        public void CarregarSubCategorias(IList<Categoria> subCategorias)
        {
            throw new NotImplementedException();
        }
    }
}
