using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace OrcamentoNet.AutomacaoHistorico
{
    public class ListaPosts
    {
        private IWebDriver driver;

        public ListaPosts(IWebDriver driver) {
            this.driver = driver;

            if (!"Posts ‹ Preços e Cotações - Orçamento Online — WordPress".Equals(driver.Title))
            {
                throw new Exception("Título da página não confere");
            }
        }

        public Post EditarPrimeiroPost() {
			Thread.Sleep(1000);
			this.driver.FindElements(By.ClassName("row-title"))[0].Click();
            return new Post(this.driver);
        }

        public ListaPosts ListarPostsPendentes() {
            this.driver.Navigate().GoToUrl(Config.UrlBase + "wp-admin/edit.php?post_status=pending&post_type=post");
            return this;
        }

        public string ObterTagDoPrimeiroPost() {
            IWebElement tabelaPosts = this.driver.FindElements(By.TagName("table"))[0];
            IWebElement celulaTag = tabelaPosts.FindElements(By.TagName("td"))[3];
            return celulaTag.Text;
        }

        public bool PossuiPostsPendentes() {
            return (IList<IWebElement>)this.driver.FindElement(By.Id("the-list")).FindElements(By.TagName("tr")) != null;
        }
    }
}
