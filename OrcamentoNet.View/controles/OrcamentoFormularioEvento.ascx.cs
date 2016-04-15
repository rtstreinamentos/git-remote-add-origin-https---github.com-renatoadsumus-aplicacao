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
    public partial class OrcamentoFormularioEvento : System.Web.UI.UserControl, ICadastroPedidoOrcamentoSimples
    {
        CadastroPedidoOrcamentoSimplesPresenter presenter;
        private List<Termo> termos;
        int idCategoriaRecebida;
        private int idTipoOrcamento;
        private string tema;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CadastroPedidoOrcamentoSimplesPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            tema = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString() : String.Empty;
            idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
            idTipoOrcamento = (Request.Params["idTipoOrcamento"] != null) ? Int32.Parse(Request.Params["idTipoOrcamento"]) : 0;


            if (!IsPostBack)
            {

                this.InicializarTela();


                if (tema == "Casamento")
                {
                    uxddlTipoEvento.SelectedValue = "Casamento";
                }

                if (tema == "Festa de 15 anos (debutante)")
                {
                    uxddlTipoEvento.SelectedValue = "Festa de 15 anos (debutante)";
                }

                if (tema == "aniversario")
                {
                    uxddlTipoEvento.SelectedValue = "Aniversário";
                }
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

        public IList<Termo> Termos
        {
            get { return termos; }
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
                string htmlLigacao = "Prefere ligações no período: " + uxddlLigacao.SelectedValue;
                string bairro = "Bairro, região ou local: " + uxtxtAreaAtuacao.Text;
                return uxtxtObservacao.Text + Environment.NewLine + Environment.NewLine + "Data do evento ou festa: " + uxtxtDataEvento.Text + Environment.NewLine + bairro + Environment.NewLine + "Número de convidados: " + uxtxtNumeroConvidados.Text + Environment.NewLine + "Hora de início: " + uxtxtHoraInicio.Text + Environment.NewLine + "Duração do evento: " + uxddlDuracaoFesta.SelectedItem + Environment.NewLine + htmlLigacao;
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

        public string Titulo
        {
            get
            {
                return uxddlTipoEvento.SelectedValue;
            }
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
            if (Session["PedidoGravado"] == null)
            {
                Session["PedidoGravado"] = "GRAVADO";

                Session.Timeout = 2;

                presenter.Salvar();
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
            uxtxtObservacao.Text = "";
        }

        public void RedirecionarPaginaSucesso()
        {
            Response.Redirect("DefaultSucesso.aspx");
        }

        #endregion

    }
}