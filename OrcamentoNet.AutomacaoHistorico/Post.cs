using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace OrcamentoNet.AutomacaoHistorico
{
    public class Post
    {
        private IWebDriver driver;

        public Post(IWebDriver driver) {
            this.driver = driver;

            if (!"Editar Post ‹ Preços e Cotações - Orçamento Online — WordPress".Equals(driver.Title))
            {
                throw new Exception("Título da página não confere");
            }
        }

        public void AdicionarTag(string tag) {
            this.driver.FindElement(By.Id("new-tag-post_tag")).SendKeys(tag);
            this.driver.FindElement(By.CssSelector("input.button.tagadd")).Click();
        }

        public string ObterMensagemStatus() {
            string mensagem = this.driver.FindElement(By.CssSelector("div#message.updated.below-h2")).FindElement(By.TagName("p")).Text;
            return mensagem;
        }

        public string ObterTag() {
            string tagBruta = this.driver.FindElement(By.ClassName("tagchecklist")).FindElement(By.TagName("span")).Text;
            return tagBruta.Replace("X\r\n", String.Empty);
        }

        public void Publicar() {
            this.driver.FindElement(By.Id("publish")).Click();
            // para garantir que a página carregou antes de retornar;
            Thread.Sleep(3000);
        }

        public void RemoverTag() {
			Thread.Sleep(1000);
			this.driver.FindElement(By.Id("post_tag-check-num-0")).Click();
        }
    }
}
