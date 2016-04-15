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
    public class OrcamentoMesasCadeirasToalhas : Base
    {
        public OrcamentoMesasCadeirasToalhas(IWebDriver driver) : base(driver) {
            this.IrPaginaBase();
        }

        public void IrPaginaBase() {
            base.driver.Navigate().GoToUrl(Config.UrlSite + Config.UrlFormularioMesasCadeirasToalhas);

            if (!"Orçamento de Mesas, Cadeiras e Toalhas - Grátis".Equals(driver.Title))
            {
                throw new Exception("Título da página não confere");
            }
        }

    }
}
