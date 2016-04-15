using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrcamentoNet.Common;

namespace OrcamentoNet.FunctionalTest
{
    public class OrcamentoBoloDeFesta : Base
    {
        public OrcamentoBoloDeFesta(IWebDriver driver)
            : base(driver) {
            this.IrPaginaBase();
        }

        public void IrPaginaBase() {
            base.driver.Navigate().GoToUrl(Config.UrlSite + Config.UrlFormularioBoloDeFesta);

            if (!"Orçamento de Bolo de Festa - Grátis".Equals(driver.Title))
            {
                throw new Exception("Título da página não confere");
            }
        }

    }
}
