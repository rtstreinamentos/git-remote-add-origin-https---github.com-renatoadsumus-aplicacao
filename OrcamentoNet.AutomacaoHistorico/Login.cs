using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace OrcamentoNet.AutomacaoHistorico
{
    public class Login
    {
        private IWebDriver driver;

        public Login(IWebDriver driver) {
            this.driver = driver;
            driver.Navigate().GoToUrl(Config.UrlBase + "wp-login.php");

            if (!"Preços e Cotações – Orçamento Online › Login".Equals(driver.Title))
            {
                throw new Exception("Título da página não confere");
            }
        }

        public Dashboard Logar(string usuario, string senha) {
            driver.FindElement(By.Name("log")).SendKeys("admin");
            driver.FindElement(By.Name("pwd")).SendKeys("4dm1n@");
            driver.FindElement(By.Name("loginform")).Submit();
            return new Dashboard(driver);
        }
    }
}
