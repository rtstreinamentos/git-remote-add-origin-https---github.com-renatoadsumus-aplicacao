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
    public class OrcamentoBuffetJapones : OrcamentoBase
    {
        private IWebDriver driver;

        [SetUp]
        public void SetupTest() {
            driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl(Config.UrlSite + Config.UrlFormularioBuffetJapones);
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

            for (int i = 0; i <= 16; i++)
            {
                itemDaLista = itensDaLista[i];
                linkDaLista = itensDaLista[i].FindElement(By.TagName("a"));

                switch (i)
                {
                    case 0:
                        textoExibicaoLink = "Aniversário";
                        tooltipLink = "Solicite orçamento grátis de buffet japonês para aniversário. Receba cotação de preços de buffet japonês para aniversário de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "buffet-japones-aniversario-54.aspx";
                        break;
                    case 1:
                        textoExibicaoLink = "Casamento";
                        tooltipLink = "Solicite orçamento grátis de buffet japonês para casamento. Receba cotação de preços de buffet japonês para casamento de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "buffet-japones-casamento-54.aspx";
                        break;
                    case 2:
                        textoExibicaoLink = "Delivery";
                        tooltipLink = "Solicite orçamento grátis de buffet japonês para delivery. Receba cotação de preços de buffet japonês para delivery de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "buffet-japones-delivery-54.aspx";
                        break;
                    case 3:
                        textoExibicaoLink = "Domicílio";
                        tooltipLink = "Solicite orçamento grátis de buffet japonês em domicílio. Receba cotação de preços de buffet japonês em domicílio de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "buffet-japones-domicilio-54.aspx";
                        break;
                    case 4:
                        textoExibicaoLink = "Eventos";
                        tooltipLink = "Solicite orçamento grátis de buffet japonês para eventos. Receba cotação de preços de buffet japonês para eventos de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "buffet-japones-eventos-54.aspx";
                        break;
                    case 5:
                        textoExibicaoLink = "Festas";
                        tooltipLink = "Solicite orçamento grátis de buffet japonês para festas. Receba cotação de preços de buffet japonês para festas de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "buffet-japones-festas-54.aspx";
                        break;
                    case 6:
                        textoExibicaoLink = "Sushi";
                        tooltipLink = "Solicite orçamento grátis de buffet japonês com sushi. Receba cotação de preços de buffet japonês com sushi de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "buffet-japones-sushi-54.aspx";
                        break;
                    case 7:
                        textoExibicaoLink = "Sushiman";
                        tooltipLink = "Solicite orçamento grátis de buffet japonês com sushiman. Receba cotação de preços de buffet japonês com sushiman de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "buffet-japones-sushiman-54.aspx";
                        break;
                    case 8:
                        textoExibicaoLink = "Belo Horizonte";
                        tooltipLink = "Solicite orçamento online grátis de buffet japonês em Belo Horizonte. Receba cotação de preços de buffet japonês em Belo Horizonte de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-buffet-japones-belo-horizonte-54-1606.aspx";
                        break;
                    case 9:
                        textoExibicaoLink = "Brasília";
                        tooltipLink = "Solicite orçamento online grátis de buffet japonês em Brasília. Receba cotação de preços de buffet japonês em Brasília de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-buffet-japones-brasilia-54-801.aspx";
                        break;
                    case 10:
                        textoExibicaoLink = "Curitiba";
                        tooltipLink = "Solicite orçamento online grátis de buffet japonês em Curitiba. Receba cotação de preços de buffet japonês em Curitiba de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-buffet-japones-curitiba-54-2853.aspx";
                        break;
                    case 11:
                        textoExibicaoLink = "Niterói";
                        tooltipLink = "Solicite orçamento online grátis de buffet japonês em Niterói. Receba cotação de preços de buffet japonês em Niterói de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-buffet-japones-niteroi-54-3611.aspx";
                        break;
                    case 12:
                        textoExibicaoLink = "Rio de Janeiro";
                        tooltipLink = "Solicite orçamento online grátis de buffet japonês no Rio de Janeiro. Receba cotação de preços de buffet japonês no Rio de Janeiro de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-buffet-japones-rio-de-janeiro-54-3631.aspx";
                        break;
                    case 13:
                        textoExibicaoLink = "Salvador";
                        tooltipLink = "Solicite orçamento online grátis de buffet japonês em Salvador. Receba cotação de preços de buffet japonês em Salvador de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-buffet-japones-salvador-54-535.aspx";
                        break;
                    case 14:
                        textoExibicaoLink = "São Paulo";
                        tooltipLink = "Solicite orçamento online grátis de buffet japonês em São Paulo. Receba cotação de preços de buffet japonês em São Paulo de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-buffet-japones-sao-paulo-54-5213.aspx";
                        break;
                    case 15:
                        textoExibicaoLink = "Todos";
                        tooltipLink = "Solicite orçamento online grátis de buffet japonês e comida japonesa. Receba cotação de preços de buffet japonês de vários fornecedores. Prático, simples, eficaz e grátis!";
                        urlLink = Config.UrlFormularioBuffetJapones;
                        break;
                    case 16:
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
            Assert.AreEqual("Preços e Cotações de Buffet Japonês Premium",
                divHistorico.FindElement(By.TagName("h3")).Text);

            IWebElement linkRodapeHistorico = divHistorico.FindElement(By.TagName("a"));
            Assert.AreEqual("preços e cotações de buffet de comida japonesa", linkRodapeHistorico.Text, "Verifico que o TEXT do link de histórico está correto.");
            Assert.AreEqual("http://preco.orcamentos.net.br/cotacao/buffet-comida-japonesa", linkRodapeHistorico.GetAttribute("href"), "Verifico que a URL do link de histórico está correta.");
            Assert.AreEqual("_blank", linkRodapeHistorico.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual("Preço e cotação de buffet de comida japonesa através de solicitação de orçamento online de buffet de comida japonesa.", linkRodapeHistorico.GetAttribute("title"), "Verifico que o TITLE do link de cadastro está correto.");
        }

        private void RodapeVoceConheceCorreto() {
            Assert.AreEqual("Nossos fornecedores de Buffet Japonês Premium",
                driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_uxTituloH3RodapeVoceConhece")).Text,
                "Verifico que o título do rodapé Você Conhece está correto.");

            IWebElement linkRodapeVoceConhece = driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_hplLink"));
            Assert.AreEqual("buffet japonês premium", linkRodapeVoceConhece.Text, "Verifico que o TEXT do link de cadastro está correto.");
            Assert.AreEqual("http://cozinhajaponesa.com.br/comida-japonesa/restaurantes-japoneses-buffet-japones/buffet-japones-domicilio-premium/", linkRodapeVoceConhece.GetAttribute("href"), "Verifico que a URL do link de cadastro está correta.");
            Assert.AreEqual("_blank", linkRodapeVoceConhece.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual("Buffet Japonês Premium: comida japonesa em domicílio, para festas, casamentos, aniversários e eventos.", linkRodapeVoceConhece.GetAttribute("title"), "Verifico que o TITLE do link de cadastro está correto.");
        }

        private void SEOCorretos() {
            Assert.AreEqual("Orçamento de Buffet Japonês Premium - Grátis", driver.Title, "Verifico que o TITLE da página está correto.");
            Assert.AreEqual("Orçamento de Buffet Japonês Premium - Grátis", driver.FindElement(By.TagName("h1")).Text, "Verifico que o H1 da página está correto.");

            IWebElement tituloH2Especifico = driver.FindElement(By.Id("ctl00_cpObjetivoSecundarioPagina_LinksInternosControle1_uxTituloH2"));
            Assert.AreEqual("Outros Pedidos de Buffet Japonês Premium", tituloH2Especifico.Text, "Verifico que o H2 específico da página está correto.");
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
        public void OrcamentoMultiploAniversarioSucesso() {
            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtNome"));
            campoFormulario.SendKeys("Fabrício Yutaka Fujikawa");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtEmail"));
            campoFormulario.SendKeys("fabriciofuji@yahoo.com.br");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtDDD"));
            campoFormulario.SendKeys("21");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtTelefone"));
            campoFormulario.SendKeys("8124-9484");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CaptchaControle1$uxtxtCaptcha"));
            campoFormulario.SendKeys(driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioEvento_CaptchaControle1_uxlblCaptcha")).Text);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxddlTipoEvento"));
            var comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("Aniversário");
            string tituloOrcamento = "Aniversário - " + base.DataHoraOrcamento;

            for (int i = 0; i <= 8; i++)
            {
                campoFormulario = driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioEvento_uxchkTemaAniversario_" + i.ToString()));
                campoFormulario.Click();
            }

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtDataEvento"));
            campoFormulario.SendKeys("31/12/2016");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtNumeroConvidados"));
            campoFormulario.SendKeys("40");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CidadeDropDownControle1$uxddlEstado"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("RJ");
            Thread.Sleep(Config.PausaTestesMilissegundos);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CidadeDropDownControle1$uxddlCidade"));
            var comboCidades = new SelectElement(campoFormulario);
            comboCidades.SelectByValue("3631");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtObservacao"));
            campoFormulario.SendKeys(@"Trata-se de uma comemoração de aniversário de 56 anos.

Desejamos os tradicionais sushi e sashimi, além de yakisoba e teppan de frango e carne.

Bebidas: refrigerantes, cervejas e sakês.

Aceitamos sugestões. " + tituloOrcamento);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxbtnSalvar"));
            campoFormulario.Click();
            Thread.Sleep(Config.PausaTestesMilissegundos);

            Assert.IsTrue(driver.Url.IndexOf("DefaultSucesso.aspx") > 0, "Verifico que a página de confirmação é exibida com sucesso.");

            driver.Navigate().GoToUrl(Config.UrlSite);
			Thread.Sleep(Config.PausaTestesMilissegundos);
            IList<IWebElement> listaDeOrcamentos = driver.FindElement(By.CssSelector("ul.iconBulletList")).FindElements(By.TagName("li"));

            for (int i = 0; i <= 7; i++)
            {
                Assert.IsTrue(listaDeOrcamentos[i].Text.IndexOf(tituloOrcamento) > 0,
                    "Verifico que o Orçamento aparece gravado no histórico dos orçamentos. Índice de categoria: " + i.ToString());
            }
        }

        [Test]
        public void OrcamentoMultiploCasamentoSucesso() {
            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtNome"));
            campoFormulario.SendKeys("Fabrício Yutaka Fujikawa");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtEmail"));
            campoFormulario.SendKeys("fabriciofuji@yahoo.com.br");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtDDD"));
            campoFormulario.SendKeys("21");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtTelefone"));
            campoFormulario.SendKeys("8124-9484");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CaptchaControle1$uxtxtCaptcha"));
            campoFormulario.SendKeys(driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioEvento_CaptchaControle1_uxlblCaptcha")).Text);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxddlTipoEvento"));
            var comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("Casamento");
            string tituloOrcamento = "Casamento - " + base.DataHoraOrcamento;

            for (int i = 0; i <= 11; i++)
            {
                campoFormulario = driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioEvento_uxchkTemaCasamento_" + i.ToString()));
                campoFormulario.Click();
            }

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtDataEvento"));
            campoFormulario.SendKeys("31/12/2016");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtNumeroConvidados"));
            campoFormulario.SendKeys("40");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CidadeDropDownControle1$uxddlEstado"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("RJ");
            Thread.Sleep(Config.PausaTestesMilissegundos);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CidadeDropDownControle1$uxddlCidade"));
            var comboCidades = new SelectElement(campoFormulario);
            comboCidades.SelectByValue("3631");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtObservacao"));
            campoFormulario.SendKeys(@"Trata-se de uma comemoração de casamento civil seguida de buffet.

Desejamos os tradicionais sushi e sashimi, além de yakisoba e teppan de frango e carne.

Bebidas: refrigerantes, cervejas e sakês.

Aceitamos sugestões. " + tituloOrcamento);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxbtnSalvar"));
            campoFormulario.Click();
            Thread.Sleep(Config.PausaTestesMilissegundos);

            Assert.IsTrue(driver.Url.IndexOf("DefaultSucesso.aspx") > 0, "Verifico que a página de confirmação é exibida com sucesso.");

            driver.Navigate().GoToUrl(Config.UrlSite);
			Thread.Sleep(Config.PausaTestesMilissegundos);

            IList<IWebElement> listaDeOrcamentos = driver.FindElement(By.CssSelector("ul.iconBulletList")).FindElements(By.TagName("li"));

            for (int i = 0; i <= 9; i++)
            {
                Assert.IsTrue(listaDeOrcamentos[i].Text.IndexOf(tituloOrcamento) > 0,
                    "Verifico que o Orçamento aparece gravado no histórico dos orçamentos. Índice de categoria: " + i.ToString());
            }
        }

        [Test]
        public void OrcamentoMultiploConfraternizacaoSucesso() {
            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtNome"));
            campoFormulario.SendKeys("Fabrício Yutaka Fujikawa");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtEmail"));
            campoFormulario.SendKeys("fabriciofuji@yahoo.com.br");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtDDD"));
            campoFormulario.SendKeys("21");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtTelefone"));
            campoFormulario.SendKeys("8124-9484");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CaptchaControle1$uxtxtCaptcha"));
            campoFormulario.SendKeys(driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioEvento_CaptchaControle1_uxlblCaptcha")).Text);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxddlTipoEvento"));
            var comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("Confraternização");
            string tituloOrcamento = "Confraternização - " + base.DataHoraOrcamento;

            for (int i = 0; i <= 3; i++)
            {
                campoFormulario = driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioEvento_uxchkTemaConfraternizacao_" + i.ToString()));
                campoFormulario.Click();
            }

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtDataEvento"));
            campoFormulario.SendKeys("31/12/2016");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtNumeroConvidados"));
            campoFormulario.SendKeys("40");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CidadeDropDownControle1$uxddlEstado"));
            comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("RJ");
            Thread.Sleep(Config.PausaTestesMilissegundos);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CidadeDropDownControle1$uxddlCidade"));
            var comboCidades = new SelectElement(campoFormulario);
            comboCidades.SelectByValue("3631");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtObservacao"));
            campoFormulario.SendKeys(@"Trata-se de uma comemoração de evento corporativo.

Desejamos os tradicionais sushi e sashimi, além de yakisoba e teppan de frango e carne.

Bebidas: refrigerantes, cervejas e sakês.

Aceitamos sugestões. " + tituloOrcamento);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxbtnSalvar"));
            campoFormulario.Click();
            Thread.Sleep(Config.PausaTestesMilissegundos);

            Assert.IsTrue(driver.Url.IndexOf("DefaultSucesso.aspx") > 0, "Verifico que a página de confirmação é exibida com sucesso.");

            driver.Navigate().GoToUrl(Config.UrlSite);
			Thread.Sleep(Config.PausaTestesMilissegundos);

            IList<IWebElement> listaDeOrcamentos = driver.FindElement(By.CssSelector("ul.iconBulletList")).FindElements(By.TagName("li"));

            for (int i = 0; i <= 3; i++)
            {
                Assert.IsTrue(listaDeOrcamentos[i].Text.IndexOf(tituloOrcamento) > 0,
                    "Verifico que o Orçamento aparece gravado no histórico dos orçamentos. Índice de categoria: " + i.ToString());
            }
        }
    }
}
