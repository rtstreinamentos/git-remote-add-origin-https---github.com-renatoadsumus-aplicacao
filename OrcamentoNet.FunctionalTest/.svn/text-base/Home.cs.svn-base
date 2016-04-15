using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OrcamentoNet.Common;

namespace OrcamentoNet.FunctionalTest
{
    public class Home : Base
    {
        public Home(IWebDriver driver) : base(driver) {
            base.driver.Navigate().GoToUrl(Config.UrlSite);

            if (!"Orçamento Online - Cotação de Preços".Equals(driver.Title))
            {
                throw new Exception("Título da página não confere");
            }
        }

		public IList<IWebElement> ObterLinksPrincipais() {
			IWebElement divLinksInternos = base.driver.FindElement(By.ClassName("productHeadingType1"));
			IWebElement listaPrincipal = divLinksInternos.FindElement(By.ClassName("checkList"));
			return listaPrincipal.FindElements(By.TagName("li"));
		}

        public IWebElement ObterPrimeiroDepoimento() {
            IWebElement listaDepoimentos = base.driver.FindElement(By.ClassName("testimonials"));
            IList<IWebElement> itensDaLista = listaDepoimentos.FindElements(By.TagName("li"));
            return itensDaLista[0];
        }

		public string ObterUrlDoLinkPrincipal(IWebElement linkPrincipal) {
			return linkPrincipal.FindElement(By.TagName("a")).GetAttribute("href");
		}
	}
}
