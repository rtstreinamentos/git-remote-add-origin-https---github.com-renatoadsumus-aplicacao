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
    public class OrcamentoBoxVidrosEspelhos : OrcamentoBase
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupTest() {
            driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl(Config.UrlSite + Config.UrlFormularioBoxVidrosEspelhos);
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
                        textoExibicaoLink = "Brasília";
                        tooltipLink = "Solicite orçamento grátis de box, vidros e espelhos em Brasília (DF). Receba cotação de preços de box, vidros e espelhos em Brasília (DF). Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-box-vidros-espelhos-brasilia-19-801.aspx";
                        break;
                    case 1:
                        textoExibicaoLink = "Todos";
                        tooltipLink = "Solicite orçamento grátis de box, vidros e espelhos. Receba cotação de preços de box, vidros e espelhos. Prático, simples, eficaz e grátis!";
                        urlLink = Config.UrlFormularioBoxVidrosEspelhos;
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
            Assert.AreEqual("Preços e Cotações de Box, Vidros e Espelhos", 
				divHistorico.FindElement(By.TagName("h3")).Text);

            IWebElement linkRodapeHistorico = divHistorico.FindElement(By.TagName("a"));
            Assert.AreEqual(linkRodapeHistorico.Text, "preços e cotações de box, vidros e espelhos", "Verifico que o TEXT do link de histórico está correto.");
            Assert.AreEqual(linkRodapeHistorico.GetAttribute("href"), "http://preco.orcamentos.net.br/cotacao/box-vidros-espelhos", "Verifico que a URL do link de histórico está correta.");
            Assert.AreEqual(linkRodapeHistorico.GetAttribute("target"), "_blank", "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeHistorico.GetAttribute("title"), "Preço e cotação de box, vidros e espelhos através de solicitação de orçamento online. Melhor preço e cotação para suas compras.", "Verifico que o TITLE do link de cadastro está correto.");
        }

        private void RodapeVoceConheceCorreto() {
            Assert.AreEqual(driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_uxTituloH3RodapeVoceConhece")).Text,
                "Nossos fornecedores de Box, Vidros e Espelhos", "Verifico que o título do rodapé Você Conhece está correto.");

            IWebElement linkRodapeVoceConhece = driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_hplLink"));
            Assert.AreEqual(linkRodapeVoceConhece.Text, "fornecedores premium de Box, Vidros e Espelhos", "Verifico que o TEXT do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("href"), "http://voceconhece.com/", "Verifico que a URL do link de cadastro está correta.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("target"), "_blank", "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("title"), "Você Conhece? Uma rede de indicação de profissionais e empresas em todo o Brasil. Um grupo selecionado dos melhores fornecedores para prestação de serviços, oportunidades de negócio ou busca de parcerias.", "Verifico que o TITLE do link de cadastro está correto.");
        }

        private void SEOCorretos() {
            Assert.AreEqual(driver.Title, "Orçamento de Box, Vidros e Espelhos - Grátis", "Verifico que o TITLE da página está correto.");
            Assert.AreEqual(driver.FindElement(By.TagName("h1")).Text, "Orçamento de Box, Vidros e Espelhos - Grátis", "Verifico que o H1 da página está correto.");

            IWebElement tituloH2Especifico = driver.FindElement(By.Id("ctl00_cpObjetivoSecundarioPagina_LinksInternosControle1_uxTituloH2"));
            Assert.AreEqual("Outros Pedidos de Box, Vidros e Espelhos", tituloH2Especifico.Text, "Verifico que o H2 específico da página está correto.");
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
            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$uxtxtNome"));
            campoFormulario.SendKeys("Fabrício Yutaka Fujikawa");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$uxtxtEmail"));
            campoFormulario.SendKeys("fabriciofuji@yahoo.com.br");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$uxtxtDDD"));
            campoFormulario.SendKeys("21");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$uxtxtTelefone"));
            campoFormulario.SendKeys("8124-9484");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$CaptchaControle1$uxtxtCaptcha"));
            campoFormulario.SendKeys(driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioEspelhoVidro1_CaptchaControle1_uxlblCaptcha")).Text);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$uxtxtTitulo"));
            string tituloOrcamento = "Orçamento para espelho de parede - " + base.DataHoraOrcamento;
            campoFormulario.SendKeys(tituloOrcamento);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$uxddlTipo"));
            var comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("Espelho");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$uxtxtLargura"));
            campoFormulario.SendKeys("2,77");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$uxtxtAltura"));
            campoFormulario.SendKeys("1,05");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$CidadeDropDownControle1$uxddlEstado"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("RJ");
            Thread.Sleep(Config.PausaTestesMilissegundos);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$CidadeDropDownControle1$uxddlCidade"));
            var comboCidades = new SelectElement(campoFormulario);
            comboCidades.SelectByValue("3631");
                
            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$uxtxtObservacao"));
            campoFormulario.SendKeys(@"Necessito valor de espelho para colar na parede da sala, com moldura em madeira escura de aproximadamente 8cm. A moldura já deve estar incluída nas medidas informadas. Obrigado.");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEspelhoVidro1$uxbtnSalvar"));
            campoFormulario.Click();
            Thread.Sleep(Config.PausaTestesMilissegundos);

            Assert.IsTrue(driver.Url.IndexOf("DefaultSucesso.aspx") > 0, "Verifico que a página de confirmação é exibida com sucesso.");

            driver.Navigate().GoToUrl(Config.UrlSite);
			Thread.Sleep(Config.PausaTestesMilissegundos);
            string conteudoPagina = driver.PageSource;
            Assert.IsTrue(conteudoPagina.IndexOf(tituloOrcamento) > 0,
                "Verifico que o título do Orçamento gravado aparece no histórico dos orçamentos.");
        }
    }
}
