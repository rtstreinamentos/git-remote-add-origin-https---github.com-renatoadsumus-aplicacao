using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrcamentoNet.View
{
    public partial class GerarPalavrasChave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void uxbtnGerar_Click(object sender, EventArgs e) {
            string[] listaPrefixos = uxtxtPrefixos.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
            string[] listaSufixos = uxtxtSufixos.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);

            uxtxtPalavrasChave.Text = "";
            foreach (string prefixo in listaPrefixos)
            {
                foreach (string sufixo in listaSufixos)
                {
                    uxtxtPalavrasChave.Text = uxtxtPalavrasChave.Text + prefixo + " " + sufixo + Environment.NewLine;
                }
            }

        }
    }
}
