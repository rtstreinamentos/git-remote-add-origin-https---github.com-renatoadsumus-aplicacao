using System;
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
    public class OrcamentoCFTV : OrcamentoBase
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupTest() {
            driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl(Config.UrlSite + Config.UrlFormularioCFTV);
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

            for (int i = 0; i <= 2; i++)
            {
                itemDaLista = itensDaLista[i];
                linkDaLista = itensDaLista[i].FindElement(By.TagName("a"));

                switch (i)
                {
                    case 0:
                        textoExibicaoLink = "São Paulo";
                        tooltipLink = "Solicite orçamento online grátis de CFTV (Circuito Fechado de Televisão) em São Paulo (SP). Receba cotação de preços de circuito fechado de TV (CFTV) de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-circuito-fechado-televisao-CFTV-169-5213.aspx";
                        break;
                    case 1:
                        textoExibicaoLink = "Todos";
                        tooltipLink = "Solicite orçamento grátis de CFTV (Circuito Fechado de Televisão). Receba cotação de preços de circuito fechado de TV (CFTV) de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = Config.UrlFormularioCFTV;
                        break;
                    case 2:
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
            Assert.AreEqual("Preços e Cotações de Circuito Fechado de Televisão (CFTV)",
                divHistorico.FindElement(By.TagName("h3")).Text);

            IWebElement linkRodapeHistorico = divHistorico.FindElement(By.TagName("a"));
            Assert.AreEqual("preços e cotações de circuito fechado de TV (CFTV)", linkRodapeHistorico.Text, "Verifico que o TEXT do link de histórico está correto.");
            Assert.AreEqual("http://preco.orcamentos.net.br/cotacao/cftv-circuito-fechado-televisao", linkRodapeHistorico.GetAttribute("href"), "Verifico que a URL do link de histórico está correta.");
            Assert.AreEqual("_blank", linkRodapeHistorico.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual("Preço e cotação de CFTV (Circuito Fechado de TV) através de solicitação de orçamento online de CFTV para sua segurança.", linkRodapeHistorico.GetAttribute("title"), "Verifico que o TITLE do link de cadastro está correto.");
        }

        private void RodapeVoceConheceCorreto() {
            Assert.AreEqual("Nossos fornecedores de Circuito Fechado de Televisão (CFTV)",
                driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_uxTituloH3RodapeVoceConhece")).Text,
                "Verifico que o título do rodapé Você Conhece está correto.");

            IWebElement linkRodapeVoceConhece = driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_hplLink"));
            Assert.AreEqual("fornecedores premium de CFTV", linkRodapeVoceConhece.Text, "Verifico que o TEXT do link de cadastro está correto.");
            Assert.AreEqual("http://voceconhece.com/", linkRodapeVoceConhece.GetAttribute("href"), "Verifico que a URL do link de cadastro está correta.");
            Assert.AreEqual("_blank", linkRodapeVoceConhece.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual("Você Conhece? Uma rede de indicação de profissionais e empresas em todo o Brasil. Um grupo selecionado dos melhores fornecedores para prestação de serviços, oportunidades de negócio ou busca de parcerias.", linkRodapeVoceConhece.GetAttribute("title"), "Verifico que o TITLE do link de cadastro está correto.");
        }

        private void SEOCorretos() {
            Assert.AreEqual("Orçamento de Circuito Fechado de Televisão (CFTV) - Grátis", driver.Title, "Verifico que o TITLE da página está correto.");
            Assert.AreEqual("Orçamento de Circuito Fechado de Televisão (CFTV) - Grátis", driver.FindElement(By.TagName("h1")).Text, "Verifico que o H1 da página está correto.");

            IWebElement tituloH2Especifico = driver.FindElement(By.Id("ctl00_cpObjetivoSecundarioPagina_LinksInternosControle1_uxTituloH2"));
            Assert.AreEqual("Outros Pedidos de Circuito Fechado de Televisão (CFTV)", tituloH2Especifico.Text, "Verifico que o H2 específico da página está correto.");
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

        [Test]
        public void OrcamentoSucesso() {
            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxtxtNome"));
            campoFormulario.SendKeys("Fabrício Yutaka Fujikawa");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxtxtEmail"));
            campoFormulario.SendKeys("fabriciofuji@yahoo.com.br");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxtxtDDD"));
            campoFormulario.SendKeys("21");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxtxtTelefone"));
            campoFormulario.SendKeys("8124-9484");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$CaptchaControle1$uxtxtCaptcha"));
            campoFormulario.SendKeys(driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioCFTV1_CaptchaControle1_uxlblCaptcha")).Text);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxtxtTitulo"));
            string tituloOrcamento = "Casa de praia - " + base.DataHoraOrcamento;
            campoFormulario.SendKeys(tituloOrcamento);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxtxtQuantidadeCamerasExterna"));
            campoFormulario.SendKeys("6");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxddlAlcanceMaximoCameraExterna"));
            SelectElement comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("15 metros");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxtxtQuantidadeCamerasInterna"));
            campoFormulario.SendKeys("4");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxddlAlcanceMaximoCameraInterna"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("5 metros");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxddlMarca"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("Sony");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxtxtTamanho"));
            campoFormulario.SendKeys("200");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$CidadeDropDownControle1$uxddlEstado"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("RJ");
            Thread.Sleep(Config.PausaTestesMilissegundos);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$CidadeDropDownControle1$uxddlCidade"));
            var comboCidades = new SelectElement(campoFormulario);
            comboCidades.SelectByValue("3631");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxtxtObservacao"));
            campoFormulario.SendKeys(@"Trata-se de uma casa de praia na região oceânica em condomínio fechado.

Desejo poder monitorar a residência via internet também.");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioCFTV1$uxbtnSalvar"));
            campoFormulario.Click();
            Thread.Sleep(Config.PausaTestesMilissegundos);

            Assert.IsTrue(driver.Url.IndexOf("DefaultSucesso.aspx") > 0, "Verifico que a página de confirmação é exibida com sucesso.");

            driver.Navigate().GoToUrl(Config.UrlSite);
			Thread.Sleep(Config.PausaTestesMilissegundos);

            string conteudoPagina = driver.PageSource;
            Assert.IsTrue(driver.PageSource.IndexOf(tituloOrcamento) > 0,
                "Verifico que o título do Orçamento gravado aparece no histórico dos orçamentos.");
        }
    }
}
