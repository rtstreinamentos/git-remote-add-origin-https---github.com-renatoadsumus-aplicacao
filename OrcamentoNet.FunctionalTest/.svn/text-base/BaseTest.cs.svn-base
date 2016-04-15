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
    public class BaseTest
    {
        public IWebDriver driver;
        public Base paginaBase;

        public string DataHoraOrcamento { get { return DateTime.Now.ToLongTimeString(); } }

        public BaseTest() {
            this.driver = new InternetExplorerDriver();
            paginaBase = new Base(this.driver);
        }

        ~BaseTest() {
            try
            {
				this.driver.Close();
                this.driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        [Test]
        public void BotaoCadastroFornecedorCorreto() {
            IWebElement botaoCadastroFornecedor = paginaBase.ObterBotaoCadastroFornecedor();
            Assert.AreEqual(botaoCadastroFornecedor.GetAttribute("href"), "http://voceconhece.com/cadastro-de-fornecedor/", "Verifico que a URL do link de cadastro está correta.");
            Assert.AreEqual(botaoCadastroFornecedor.GetAttribute("target"), "_blank", "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual(botaoCadastroFornecedor.GetAttribute("title"), "Cadastro de Fornecedor: participe de cotações e envie orçamentos", "Verifico que o TITLE do link de cadastro está correto.");
        }
    }
}
