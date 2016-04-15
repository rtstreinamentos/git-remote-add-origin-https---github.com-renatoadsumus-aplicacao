using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.IView;

namespace OrcamentoNet.View
{
    public partial class PesquisaSatisfacaoComprador : System.Web.UI.Page, IPesquisaSatisfacaoComprador
    {
        PesquisaSatisfacaoCompradorPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new PesquisaSatisfacaoCompradorPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();


            if ((Request.QueryString["email"] == null) ||
                (Request.QueryString["id"] == null))
            {
                this.ExibirMensagem(this.MensagemErroValidacaoDados);
            }
            else
            {
                presenter.AutorizarAcesso();
            }
        }

        #region Propriedades

        public string Email
        {
            get { return Request.QueryString["email"].ToString(); }
        }

        public int Gostou
        {
            get { return int.Parse(uxddlGostou.SelectedValue); }
        }

        public int IdPedidoOrcamento
        {
            get { return int.Parse(Request.QueryString["id"].ToString()); }
        }

        public string MensagemErroPesquisaRespondida
        {
            get { return "Pesquisa de satisfação já respondida. Em caso de dúvidas ou necessidade de orientação, fale conosco."; }
        }

        public string MensagemErroValidacaoDados
        {
            get { return "Pedido de orçamento não identificado."; }
        }

        public string OpiniaoComprador
        {
            get { return uxtxtOqueFoiBom.Text; }
        }

        public bool PesquisaRevisada
        {
            get { return true; }
        }

        public string PontosMelhoria
        {
            get { return uxtxtOquePodeMelhorar.Text; }
        }

        public int Status
        {
            get { return int.Parse(uxddlStatus.SelectedValue); }
        }

        #endregion

        #region Métodos Públicos

        public void ExibirFormulario()
        {
            divFormPesquisaSatisfacao.Visible = true;
        }

        public void ExibirMensagem(string mensagem)
        {
            MensagemSuperiorControle1.ExibirMensagem(mensagem);
        }

        public void RedirecionarPaginaSucesso()
        {
            Response.Redirect("/PesquisaSatisfacaoCompradorSucesso.aspx");
        }
        #endregion

        #region Eventos Tela
        protected void uxbtnSalvar_Click(object sender, EventArgs e)
        {
            presenter.Salvar();
        }
        #endregion       
    }
}
