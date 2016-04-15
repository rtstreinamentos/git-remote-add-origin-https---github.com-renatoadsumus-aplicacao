using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrcamentoNet.View.controles
{
    public partial class CaptchaControle : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            uxlblCaptcha.Text = "1985";// DateTime.Now.ToShortDateString().Substring(0, 1) + "98" + DateTime.Now.Second.ToString().Substring(0, 1);
        }

        public bool PalavraEhCorreta
        {
            get
            {
                bool palavraEhCorreta = false;

                if (uxtxtCaptcha.Text == uxlblCaptcha.Text)
                    palavraEhCorreta = true;

                return palavraEhCorreta;
            }
        }
    }
}