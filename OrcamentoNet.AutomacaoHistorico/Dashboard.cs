using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace OrcamentoNet.AutomacaoHistorico
{
    public class Dashboard
    {
        private IWebDriver driver;

        public Dashboard(IWebDriver driver) {
            this.driver = driver;

            if (!"Painel ‹ Preços e Cotações - Orçamento Online — WordPress".Equals(driver.Title))
            {
                throw new Exception("Título da página não confere");
            }
        }

        public ListaPosts ListarPosts() {
            this.driver.Navigate().GoToUrl(Config.UrlBase + "wp-admin/edit.php");
            return new ListaPosts(driver);
        }
    }
}
