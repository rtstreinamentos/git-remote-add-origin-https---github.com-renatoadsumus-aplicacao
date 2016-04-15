using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using OrcamentoNet.Common;

namespace OrcamentoNet.IView.Presenter
{
    public class MalaDiretaPresenter
    {
        public void EnviarEmailMalaDireta()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Config.CaminhoFisico + "MalaDireta\\MalaDiretaPromocaoDeCarnaval.xml");

            XmlNodeList dataNodes = xmlDoc.SelectNodes("//row");

            foreach (XmlNode node in dataNodes)
            {
                string nome = node.ChildNodes[0].InnerText.ToString();
                string email = node.ChildNodes[1].InnerText.ToString();
                string id = node.ChildNodes[2].InnerText.ToString();
                                
                Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                chavesValores.Add("<!--NOME-->", nome);
                chavesValores.Add("<!--URL-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=9,90&id=" + id + "&plano=1");
                

                string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailMalaDireta);

                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, email, htmlEmail, "URGENTE - Promoção de Carnaval no valor da Mensalidade!!!", false, false, null, "");
            }
        }

    }
}
