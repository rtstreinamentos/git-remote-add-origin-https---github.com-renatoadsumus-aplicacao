using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.Entity;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity._enum;
using OrcamentoNet.Common;

namespace OrcamentoNet.View
{
    public partial class MeusDados : System.Web.UI.Page, IMeusDados
    {
        MeusDadosPresenter presenter;
        FornecedorLogado fornecedorLogado;
        PessoaTipo pessoaTipo;
        List<string> fotos;
        List<string> fotosGravadas;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new MeusDadosPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            fornecedorLogado = new FornecedorLogado();

            if (!IsPostBack)
            {
                fotos = new List<string>();
                fotosGravadas = new List<string>();
                Session["Fotos"] = fotos;
                Session["FotosGravadas"] = fotosGravadas;

                if (fornecedorLogado.Fornecedor == null)
                    Response.Redirect(Config.UrlSite + "/LoginNovo.aspx");

                uxtxtEmail.Text = fornecedorLogado.Fornecedor.Email;


                if (Request.Params["plano"] == null)
                {
                    presenter.CarregarFornecedor();
                }
                else
                {
                    presenter.CalcularPlano();
                }
            }

        }

        #region Propriedades

        public int AreaServico
        {
            get
            {
                int areaServico = 0;

                bool res = int.TryParse(txtConfiguracaoArea.Text, out areaServico);

                return areaServico;
            }
        }

        public PessoaTipo PessoaTipo
        {
            get { return pessoaTipo; }
        }

        public string Descricao
        {
            get { return uxtxtDescricao.Text; }
        }

        public IList<string> Fotos
        {
            get
            { return ((List<string>)(Session["FotosGravadas"])); }

        }

        public string Email
        {
            get { return uxtxtEmail.Text; }
        }

        public string WebSite
        {
            get { return uxtxtSite.Text; }
        }

        public string Telefone
        {
            get { return uxtxtDDD.Text + "-" + uxtxtTelefone.Text; }
        }

        public string Nome
        {
            get { return uxtxtNome.Text; }
        }

        public double ValorMensalidade
        {
            get { return double.Parse(ViewState["valorMensalidade"].ToString()); }
        }

        #endregion

        #region Metodos

        public void ApresentarValoresPlanos(string plano1, string plano2)
        {
            uxbtnPlano1.Text = plano1;
            uxbtnPlano2.Text = plano2;
            multiview01.SetActiveView(viewMeuPlano);
        }

        public void CarregarFornecedor(Fornecedor fornecedor)
        {
            string valorMensalidade = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao).Replace(".", ",");

            hypLinkPagamento.NavigateUrl = Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade + "&id=" + fornecedor.Id + "&plano=1";
            uxtxtNome.Text = fornecedor.Nome;
            uxtxtDDD.Text = fornecedor.Telefone.Substring(0, 2);
            uxtxtTelefone.Text = fornecedor.Telefone.Substring(3, fornecedor.Telefone.Length - 3);
            uxtxtSite.Text = fornecedor.WebSite;
            uxtxtValorMensalidade.Text = String.Format("{0:#0.00}", fornecedor.ValorMensalidade).Replace(".", ",");
            uxtxtDataCobranca.Text = fornecedor.DataAlteracao.ToShortDateString();
            uxtxtDescricao.Text = fornecedor.Descricao;
            uxtxtEmail.Text = fornecedor.Email;
            hpyFichaTecnica.NavigateUrl = fornecedor.UrlFichaTecnica;
        }
        #endregion

        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            presenter.Salvar();
        }

        protected void uxbtnPlano1_Click(object sender, EventArgs e)
        {
            ViewState["valorMensalidade"] = uxbtnPlano1.Text;
            pessoaTipo = PessoaTipo.Fisica;
            presenter.AtualizarValorMensalidade();
            multiview01.SetActiveView(viewSucesso);
        }

        protected void uxbtnPlano2_Click(object sender, EventArgs e)
        {
            ViewState["valorMensalidade"] = uxbtnPlano2.Text;
            pessoaTipo = PessoaTipo.Juridica;
            presenter.AtualizarValorMensalidade();
            multiview01.SetActiveView(viewSucesso);
        }

        protected void uxbtnFoto_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();

                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };

                int fileSize = FileUpload1.PostedFile.ContentLength;

                if (allowedExtensions.Contains(fileExtension) && fileSize < 1100000)
                {

                    try
                    {
                        string nomeArquivo = fornecedorLogado.Fornecedor.Id.ToString() + "-" + DateTime.Now.Month + "-" + ((List<string>)(Session["FotosGravadas"])).Count() + fileExtension;
                        //string nomeArquivo = fornecedorLogado.Fornecedor.Id.ToString() + "-" + DateTime.Now.Month + "-" + fileExtension;
                        FileUpload1.SaveAs(Config.CaminhoFisico + "\\FotosFornecedor\\" + nomeArquivo);

                        ((List<string>)(Session["Fotos"])).Add(FileUpload1.FileName);
                        ((List<string>)(Session["FotosGravadas"])).Add(nomeArquivo);

                        uxrptFotos.DataSource = ((List<string>)(Session["Fotos"]));
                        uxrptFotos.DataBind();
                    }
                    catch (Exception ex)
                    {
                        uxlblMensagemFoto.Text = "Ops! Ocorreu uma falha." + Environment.NewLine + Environment.NewLine + "Favor enviar as fotos para orcamentos.net@gmail.com";
                    }
                }
            }
        }


    }
}
