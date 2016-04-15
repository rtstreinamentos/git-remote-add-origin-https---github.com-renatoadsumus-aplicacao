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
    public class OrcamentoPintorPintura : OrcamentoBase
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupTest() {
            driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl(Config.UrlSite + Config.UrlFormularioPinturaPintor);
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
                        textoExibicaoLink = "Curitiba";
                        tooltipLink = "Solicite orçamento online grátis de pintura e pintor profissional em Curitiba. Receba cotação de preços de pintura e pintor profissional em Curitiba de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-pintura-pintor-curitiba-40-2853.aspx";
                        break;
                    case 1:
                        textoExibicaoLink = "Rio de Janeiro";
                        tooltipLink = "Solicite orçamento online grátis de pintura e pintor profissional no Rio de Janeiro. Receba cotação de preços de pintura e pintor profissional no Rio de Janeiro de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-pintura-pintor-rio-de-janeiro-40-3631.aspx";
                        break;
                    case 2:
                        textoExibicaoLink = "São Paulo";
                        tooltipLink = "Solicite orçamento online grátis de pintura e pintor profissional em São Paulo. Receba cotação de preços de pintura e pintor profissional em São Paulo de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-pintura-pintor-sao-paulo-40-5213.aspx";
                        break;
                    case 3:
                        textoExibicaoLink = "Todos";
                        tooltipLink = "Solicite orçamento online grátis de pintura e pintor profissional. Receba cotação de preços de pintura e pintor profissional de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = Config.UrlFormularioPinturaPintor;
                        break;
                    case 4:
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
            Assert.AreEqual("Histórico de Preços e Cotações", divHistorico.FindElement(By.TagName("h3")).Text);

            IWebElement linkRodapeHistorico = divHistorico.FindElement(By.TagName("a"));
            Assert.AreEqual("preços e cotações de pintura e pintor profissional", linkRodapeHistorico.Text, "Verifico que o TEXT do link de histórico está correto.");
            Assert.AreEqual("http://preco.orcamentos.net.br/cotacao/pintura-pintor-profissional-19", linkRodapeHistorico.GetAttribute("href"), "Verifico que a URL do link de histórico está correta.");
            Assert.AreEqual("_blank", linkRodapeHistorico.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual("Preço e cotação de serviços de pintura através de solicitação de orçamento online. Melhor preço e cotação para suas compras.", linkRodapeHistorico.GetAttribute("title"), "Verifico que o TITLE do link de cadastro está correto.");
        }

        private void RodapeVoceConheceCorreto() {
            Assert.AreEqual("Nossos fornecedores de Pintura e Pintor Profissional",
                driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_uxTituloH3RodapeVoceConhece")).Text,
                "Verifico que o título do rodapé Você Conhece está correto.");

            IWebElement linkRodapeVoceConhece = driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_hplLink"));
            Assert.AreEqual("pintores e empresas de pintura premium", linkRodapeVoceConhece.Text, "Verifico que o TEXT do link de cadastro está correto.");
            Assert.AreEqual("http://voceconhece.com/indicacao/pinturas-pintores/", linkRodapeVoceConhece.GetAttribute("href"), "Verifico que a URL do link de cadastro está correta.");
            Assert.AreEqual("_blank", linkRodapeVoceConhece.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual("Você Conhece? Indicação de empresas de pintura e pintores profissionais em todo o Brasil.", 
                linkRodapeVoceConhece.GetAttribute("title"), 
                "Verifico que o TITLE do link de cadastro está correto.");
        }

        private void SEOCorretos() {
            Assert.AreEqual("Orçamento de Pintura e Pintor Profissional - Grátis", driver.Title, "Verifico que o TITLE da página está correto.");
            Assert.AreEqual("Orçamento de Pintura e Pintor Profissional - Grátis", driver.FindElement(By.TagName("h1")).Text, "Verifico que o H1 da página está correto.");

            IWebElement tituloH2Especifico = driver.FindElement(By.Id("ctl00_cpObjetivoSecundarioPagina_LinksInternosControle1_uxTituloH2"));
            Assert.AreEqual("Outros Pedidos de Pintura e Pintor Profissional", tituloH2Especifico.Text, "Verifico que o H2 específico da página está correto.");
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
        public void OrcamentoMultiploSucesso() {
            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtNome"));
            campoFormulario.SendKeys("Fabrício Yutaka Fujikawa");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtEmail"));
            campoFormulario.SendKeys("fabriciofuji@yahoo.com.br");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtDDD"));
            campoFormulario.SendKeys("21");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtTelefone"));
            campoFormulario.SendKeys("8124-9484");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$CaptchaControle1$uxtxtCaptcha"));
            campoFormulario.SendKeys(driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioConstrucao_CaptchaControle1_uxlblCaptcha")).Text);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtTitulo"));
            string tituloOrcamento = "Orçamento para pintura de parede - " + base.DataHoraOrcamento;
            campoFormulario.SendKeys(tituloOrcamento);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxddlMaterias"));
            var comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("Eu fornecerei os materiais");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxddlTipoImovel"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("Apartamento");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtTamanho"));
            campoFormulario.SendKeys("130");

            campoFormulario = driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioConstrucao_uxchkTemaObrasReformas_0"));
            campoFormulario.Click();

            campoFormulario = driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioConstrucao_uxchkTemaObrasReformas_1"));
            campoFormulario.Click();

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$CidadeDropDownControle1$uxddlEstado"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("RJ");
            Thread.Sleep(Config.PausaTestesMilissegundos);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$CidadeDropDownControle1$uxddlCidade"));
            var comboCidades = new SelectElement(campoFormulario);
            comboCidades.SelectByValue("3631");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtObservacao"));
            campoFormulario.SendKeys(@"Necessito de pintura em branco gelo de teto e paredes de apartamento de 3 quartos (1 suíte), sala, banheiro, cozinha e dependências, devido a entrega do apartamento (alugado). Obrigado.");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxbtnSalvar"));
            campoFormulario.Click();
            Thread.Sleep(Config.PausaTestesMilissegundos);

            Assert.IsTrue(driver.Url.IndexOf("DefaultSucesso.aspx") > 0, "Verifico que a página de confirmação é exibida com sucesso.");

            driver.Navigate().GoToUrl(Config.UrlSite);
            IList<IWebElement> listaDeOrcamentos = driver.FindElement(By.CssSelector("ul.iconBulletList")).FindElements(By.TagName("li"));
            for (int i = 0; i <= 2; i++)
            {
                Assert.IsTrue(listaDeOrcamentos[i].Text.IndexOf(tituloOrcamento) > 0,
                    "Verifico que o Orçamento aparece gravado no histórico dos orçamentos. Índice de categoria: " + i.ToString());
            }
        }

        [Test]
        public void OrcamentoSucesso() {
            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtNome"));
            campoFormulario.SendKeys("Fabrício Yutaka Fujikawa");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtEmail"));
            campoFormulario.SendKeys("fabriciofuji@yahoo.com.br");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtDDD"));
            campoFormulario.SendKeys("21");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtTelefone"));
            campoFormulario.SendKeys("8124-9484");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$CaptchaControle1$uxtxtCaptcha"));
            campoFormulario.SendKeys(driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioConstrucao_CaptchaControle1_uxlblCaptcha")).Text);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtTitulo"));
            string tituloOrcamento = "Orçamento para pintura de parede - " + base.DataHoraOrcamento;
            campoFormulario.SendKeys(tituloOrcamento);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxddlMaterias"));
            var comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("Eu fornecerei os materiais");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxddlTipoImovel"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("Apartamento");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtTamanho"));
            campoFormulario.SendKeys("130");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$CidadeDropDownControle1$uxddlEstado"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("RJ");
            Thread.Sleep(Config.PausaTestesMilissegundos);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$CidadeDropDownControle1$uxddlCidade"));
            var comboCidades = new SelectElement(campoFormulario);
            comboCidades.SelectByValue("3631");
                
            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxtxtObservacao"));
            campoFormulario.SendKeys(@"Necessito de pintura em branco gelo de teto e paredes de apartamento de 3 quartos (1 suíte), sala, banheiro, cozinha e dependências, devido a entrega do apartamento (alugado). Obrigado.");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioConstrucao$uxbtnSalvar"));
            campoFormulario.Click();
            Thread.Sleep(Config.PausaTestesMilissegundos);

            Assert.IsTrue(driver.Url.IndexOf("DefaultSucesso.aspx") > 0, "Verifico que a página de confirmação é exibida com sucesso.");

            driver.Navigate().GoToUrl(Config.UrlSite);
            string conteudoPagina = driver.PageSource;
            Assert.IsTrue(driver.PageSource.IndexOf(tituloOrcamento) > 0,
                "Verifico que o título do Orçamento gravado aparece no histórico dos orçamentos.");
        }
    }
}
