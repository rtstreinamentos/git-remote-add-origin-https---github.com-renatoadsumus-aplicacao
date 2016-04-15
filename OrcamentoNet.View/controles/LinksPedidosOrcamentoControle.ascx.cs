using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrcamentoNet.View.controles
{
    public partial class LinksPedidosOrcamentoControle : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) {
            int idCategoriaRecebida = 0;
            string linkHistoricoPrecos = String.Empty;
            string hrefDoLink = String.Empty;
            string titleDoLink = String.Empty;
            string textoDoLink = String.Empty;

            idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;

            switch (idCategoriaRecebida)
            {
                case 54:
                    hrefDoLink = "http://preco.rcmsolucoes.com/cotacao/buffet-japones";
                    titleDoLink = "Cotação de preço de buffet japonês em casa (em domicílio) através do Orçamento Online. Cotações de preços com buffet japonês premium.";
                    textoDoLink = "buffet japonês";
                    linkHistoricoPrecos = "Veja todo o histórico de <a href='" + hrefDoLink + "' target='_blank' title='" + titleDoLink + "'>cotação de preço de " + textoDoLink + "</a>.";
                    break;
            }

            uxlblLinkPrecos.Text = linkHistoricoPrecos;
        }
    }
}