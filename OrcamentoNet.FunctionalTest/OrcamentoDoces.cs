﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OrcamentoNet.Common;

namespace OrcamentoNet.FunctionalTest
{
    [TestFixture]
    public class OrcamentoDoces : OrcamentoBase
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupTest() {
            driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl(Config.UrlSite + Config.UrlFormularioDocesChocolatesSalgados);
        }

        [TearDown]
        public void TeardownTest() {
            try
            {
                driver.Close();
                driver.Dispose();
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        #region Métodos Privados
        private void LinksInternosCorretos() {
            IWebElement divLinksInternos = driver.FindElement(By.ClassName("tipos-orcamentos"));
            IWebElement listaPrincipal = divLinksInternos.FindElement(By.ClassName("checkList"));
            IList<IWebElement> itensDaLista = listaPrincipal.FindElements(By.TagName("li"));
            IWebElement itemDaLista;
            IWebElement linkDaLista;
            string textoExibicaoLink = String.Empty;
            string tooltipLink = String.Empty;
            string urlLink = String.Empty;

            for (int i = 0; i <= 1; i++)
            {
                itemDaLista = itensDaLista[i];
                linkDaLista = itensDaLista[i].FindElement(By.TagName("a"));

                switch (i)
                {
                    case 0:
                        textoExibicaoLink = "Todos";
                        tooltipLink = "Solicite orçamento online grátis de doces, chocolates e salgados para casamentos, festas, eventos e aniversários. Receba cotação de preços de doces, chocolates e salgados para casamentos, festas, eventos e aniversários de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = Config.UrlFormularioDocesChocolatesSalgados;
                        break;
                    case 1:
                        textoExibicaoLink = "Outros orçamentos";
                        tooltipLink = "Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores de diversos produtos e serviços. Prático, simples, eficaz e grátis!";
                        urlLink = Config.UrlFormularioGenerico;
                        break;
                }

                urlLink = Config.UrlSite + urlLink;

                Assert.AreEqual(textoExibicaoLink, itemDaLista.Text, "Verifico que o link interno " + i.ToString() + " está correto.");
                Assert.AreEqual(tooltipLink, linkDaLista.GetAttribute("title"), "Verifico que o TITLE do link interno " + i.ToString() + " está correto.");
                Assert.AreEqual(urlLink, linkDaLista.GetAttribute("href"), "Verifico que o HREF do link interno " + i.ToString() + " está correto.");
            }
        }

        private void RodapeHistoricoCorreto() {
            IWebElement divHistorico = driver.FindElement(By.Id("contactInformation"));
            Assert.AreEqual("Preços e Cotações de Doces, Chocolates e Salgados",
                divHistorico.FindElement(By.TagName("h3")).Text);

            IWebElement linkRodapeHistorico = divHistorico.FindElement(By.TagName("a"));
            Assert.AreEqual("preços e cotações de doces, chocolates e salgados para casamentos, festas, eventos e aniversários", linkRodapeHistorico.Text, "Verifico que o TEXT do link de histórico está correto.");
            Assert.AreEqual("http://preco.orcamentos.net.br/cotacao/doce-chocolate-salgado", linkRodapeHistorico.GetAttribute("href"), "Verifico que a URL do link de histórico está correta.");
            Assert.AreEqual("_blank", linkRodapeHistorico.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual("Preço e cotação de doces, chocolates e salgados para casamentos, festas, eventos e aniversários, através de solicitação de orçamento online. Melhor preço e cotação para suas compras.", linkRodapeHistorico.GetAttribute("title"), "Verifico que o TITLE do link de cadastro está correto.");
        }

        private void RodapeVoceConheceCorreto() {
            Assert.AreEqual("Nossos fornecedores de Doces, Chocolates e Salgados",
                driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_uxTituloH3RodapeVoceConhece")).Text,
                "Verifico que o título do rodapé Você Conhece está correto.");

            IWebElement linkRodapeVoceConhece = driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_hplLink"));
            Assert.AreEqual("fornecedores premium de doces, chocolates e salgados", linkRodapeVoceConhece.Text, "Verifico que o TEXT do link de cadastro está correto.");
            Assert.AreEqual("http://voceconhece.com/indicacao/doce-festa-mesa-chocolate/", linkRodapeVoceConhece.GetAttribute("href"), "Verifico que a URL do link de cadastro está correta.");
            Assert.AreEqual("_blank", linkRodapeVoceConhece.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual("Você Conhece? Indicação de culinaristas para doces, chocolates e salgados em todo o Brasil.", linkRodapeVoceConhece.GetAttribute("title"), "Verifico que o TITLE do link de cadastro está correto.");
        }

        private void SEOCorretos() {
            Assert.AreEqual("Orçamento de Doces, Chocolates e Salgados - Grátis", driver.Title, "Verifico que o TITLE da página está correto.");
            Assert.AreEqual("Orçamento de Doces, Chocolates e Salgados - Grátis", driver.FindElement(By.TagName("h1")).Text, "Verifico que o H1 da página está correto.");

            IWebElement tituloH2Especifico = driver.FindElement(By.Id("ctl00_cpObjetivoSecundarioPagina_LinksInternosControle1_uxTituloH2"));
            Assert.AreEqual("Outros Pedidos de Doces, Chocolates e Salgados", tituloH2Especifico.Text, "Verifico que o H2 específico da página está correto.");
        }
        #endregion

        [Test]
        public void ElementosNavegacaoSucesso() {
            this.LinksInternosCorretos();
            this.RodapeHistoricoCorreto();
            this.RodapeVoceConheceCorreto();
            this.SEOCorretos();
            base.TrocarFormularioCorreto(driver);
        }
    }
}