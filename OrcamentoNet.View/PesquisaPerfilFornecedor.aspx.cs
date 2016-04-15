using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.View
{
    public partial class PesquisaPerfilFornecedor : System.Web.UI.Page, IPesquisaPerfilFornecedor
    {
        int idFornecedor;
        int idPedido;
        int idInteresse;
        int idMotivo;
        PesquisaPerfilFornecedorPresenter presenter;


        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new PesquisaPerfilFornecedorPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            idFornecedor = (Request.Params["idFornecedor"] != null) ? Int32.Parse(Request.Params["idFornecedor"]) : 0;
            idPedido = (Request.Params["idPedido"] != null) ? Int32.Parse(Request.Params["idPedido"]) : 0;
            idInteresse = (Request.Params["interesse"] != null) ? Int32.Parse(Request.Params["interesse"]) : 0;

            if (!IsPostBack)
            {
                if (idInteresse == 1)
                {
                    h1.InnerText = "Obrigado por Responder!!!";
                    uxrptMotivo.Visible = false;
                    presenter.AtualizarInteresseNoPedido();
                    uxbtnEnviar.Visible = false;
                    uxlblMsgObrigado.Visible = true;
                }
            }
        }

        #region Propriedade

        public int IdFornecedor
        {
            get { return idFornecedor; }
        }

        public int IdPedido
        {
            get { return idPedido; }
        }

        public int IdInteresse
        {
            get { return idInteresse; }
        }
        public int IdMotivo
        {
            get { return idMotivo; }
        }
        #endregion

        protected void uxbtnEnviar_Click(object sender, EventArgs e)
        {
            idMotivo = int.Parse(uxrptMotivo.SelectedValue);
            presenter.AtualizarInteresseNoPedido();

            uxlblMsgObrigado.Visible = true;
            uxrptMotivo.Visible = false;
            uxbtnEnviar.Visible = false;
            h1.InnerText = "Obrigado por Responder!!!";
        }
    }
}
