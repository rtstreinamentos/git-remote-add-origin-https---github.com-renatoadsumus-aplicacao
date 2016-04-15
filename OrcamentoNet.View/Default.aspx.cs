using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrcamentoNet.View
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				Fornecedores1.quantidadeFornecedores = 6;
                ultimosPedidosOrcamento.quantidadePedidos = 6;
            }
        }
    }
}
