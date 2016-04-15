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
    public partial class OrcamentoFormularioLocacao : System.Web.UI.UserControl, ICadastroPedidoOrcamentoSimples
    {
        CadastroPedidoOrcamentoSimplesPresenter presenter;
        private int idCategoriaRecebida;
        private List<Termo> termos;
        private int idTipoOrcamento;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CadastroPedidoOrcamentoSimplesPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            idTipoOrcamento = (Request.Params["idTipoOrcamento"] != null) ? Int32.Parse(Request.Params["idTipoOrcamento"]) : 0;
            idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
            
            if (!IsPostBack)
            {
                this.InicializarTela();
                presenter.CarregarSubCategorias();
            }
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
                string htmlTipoPessoa = Environment.NewLine + "Contratante: " + uxddlTipoPessoa.SelectedItem;
                string htmlLigacao = Environment.NewLine + "Prefere ligações no período: " + uxddlLigacao.SelectedValue;              
                string hmtlObservacao = Environment.NewLine + uxtxtObservacao.Text + Environment.NewLine + Environment.NewLine;


                return hmtlObservacao;
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
                return ObterCategorias();
            }
        }

        public int IdCategoriaRecebida
        {
            get { return idCategoriaRecebida; }
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
            presenter.Salvar();
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
    }
}