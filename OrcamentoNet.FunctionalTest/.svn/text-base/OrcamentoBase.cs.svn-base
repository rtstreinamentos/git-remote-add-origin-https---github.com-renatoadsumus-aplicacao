using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OrcamentoNet.Common;

namespace OrcamentoNet.FunctionalTest
{
    public class OrcamentoBase
    {
        public string DataHoraOrcamento { get { return DateTime.Now.ToLongTimeString(); } }

        public void TrocarFormularioCorreto(IWebDriver driver) {
            IWebElement linkTrocaFormulario = driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_uxTrocarFormulario"));
            Assert.IsNotNull(linkTrocaFormulario,
                "Verifico que o link para troca de formulário está presente.");
            
            if (linkTrocaFormulario != null) {
                Assert.AreEqual(Config.UrlSite + Config.UrlFormularioGenerico,
                    linkTrocaFormulario.FindElement(By.TagName("a")).GetAttribute("href"),
                    "Verifico que o HREF do link para troca de formulário está correto.");
            }
        }
    }
}
