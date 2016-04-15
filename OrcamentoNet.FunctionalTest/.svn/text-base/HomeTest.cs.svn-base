using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OrcamentoNet.Common;

namespace OrcamentoNet.FunctionalTest
{
    [TestFixture]
    public class HomeTest : BaseTest
    {
        private Home home;

        public HomeTest() {
            home = new Home(base.driver);
        }

        [SetUp]
        public void SetupTest() {
        }

        [TearDown]
        public void TeardownTest() {
        }

		[Test]
		public void FornecedoresRecentesCorreto() {
		    bool encontreiDiferente = false;

		    IList<IWebElement> listaFornecedores = home.ObterFornecedoresRecentes();
		    string primeiroFornecedor = home.ObterNomeFornecedorRecente(0);

		    // devem existir pelo menos 2 fornecedores diferentes
		    for (int i = 1; i < listaFornecedores.Count; i++)
			{
		        if (home.ObterNomeFornecedorRecente(i) != primeiroFornecedor)
		        {
		            encontreiDiferente = true;
		            break;
		        }

		        Assert.IsTrue(encontreiDiferente, "Verifico que existem pelo menos 2 fornecedores diferentes mais recentes na Home.");
		    }
		}

		[Test]
		public void LinksPrincipaisAbremComSucesso() {
			IWebDriver webDriverLocal = new InternetExplorerDriver();
			Base paginaBaseLocal = new Base(webDriverLocal);

			try
			{
				IList<IWebElement> linksPrincipais = home.ObterLinksPrincipais();
				foreach (IWebElement linkPrincipal in linksPrincipais)
				{
					paginaBaseLocal.IrPagina(home.ObterUrlDoLinkPrincipal(linkPrincipal));
					if (linkPrincipal.Text != "Outros orçamentos")
					{
						Assert.AreEqual("Orçamento de " + linkPrincipal.Text + " - Grátis", paginaBaseLocal.ObterTitle(), "Verifico que o TITLE do link interno " + linkPrincipal.Text + " está correto.");
					}
					else
					{
						Assert.AreEqual("Orçamento Online - Grátis", paginaBaseLocal.ObterTitle(), "Verifico que o TITLE do link interno " + linkPrincipal.Text + " está correto.");
					}
				}
			}
			finally 
			{
				webDriverLocal.Quit();
			}
		}


		[Test]
        public void PedidosOrcamentoRecentesCorreto() {
            bool encontreiDiferente = false;

            IList<IWebElement> listaPedidosOrcamento = home.ObterPedidosOrcamentoRecentes();
            string primeiroTipoOrcamento = home.ObterCategoriaPedidoOrcamentoRecente(0);

            // devem existir pelo menos 2 tipos diferentes de orçamento
            for (int i = 1; i < listaPedidosOrcamento.Count; i++)
            {
                if (home.ObterCategoriaPedidoOrcamentoRecente(i) != primeiroTipoOrcamento)
                {
                    encontreiDiferente = true;
                    break;
                }

                Assert.IsTrue(encontreiDiferente, "Verifico que existem pelo menos 2 tipos diferentes de orçamentos mais recentes na Home.");
            }
        }

		[Test]
		public void PrimeiroDepoimentoCorreto() {
			IWebElement primeiroDepoimento = home.ObterPrimeiroDepoimento();
			Assert.AreEqual(primeiroDepoimento.Text, "Achei a criatividade de criação desse site muito boa. Não recebi muitas respostas de orçamento, apenas 5, esperava receber um pouco mais. Mas achei super interessante o site e prático. Estão de parabéns!\r\n\r\nVictor Barros - Orçamento de Buffet - RJ");
		}

		[Test]
        public void RodapeHistoricoCorreto() {
            IWebElement linkRodapeHistorico = home.ObterRodapeHistoricoLink();

            Assert.AreEqual(home.ObterRodapeHistoricoTitulo(), "Preços e Cotações de Orçamento Online");
            Assert.AreEqual(linkRodapeHistorico.Text, "preços e cotações feitas através do Orçamento Online", "Verifico que o TEXT do link de histórico está correto.");
            Assert.AreEqual(linkRodapeHistorico.GetAttribute("href"), "http://preco.orcamentos.net.br/", "Verifico que a URL do link de histórico está correta.");
            Assert.AreEqual(linkRodapeHistorico.GetAttribute("target"), "_blank", "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeHistorico.GetAttribute("title"), "Preço e cotação de produtos e serviços através de solicitação de orçamento online. Melhor preço e cotação para suas compras.", "Verifico que o TITLE do link de cadastro está correto.");
        }

        [Test]
        public void RodapeInstitucionalCorreto() {
            IList<IWebElement> linksRodape = home.ObterRodapeInstitucional();
            Assert.AreEqual(linksRodape[0].Text, "Orçamento Online", "Verifico que o TEXT do link de rodapé institucional está correto.");
            Assert.AreEqual(linksRodape[0].GetAttribute("href"), "http://orcamentos.net.br/", "Verifico que a URL do link de rodapé institucional está correta.");
            Assert.AreEqual(linksRodape[0].GetAttribute("target"), "_blank", "Verifico que o TARGET do link de rodapé institucional está correto.");
            Assert.AreEqual(linksRodape[0].GetAttribute("title"), "Orçamento Online", "Verifico que o TITLE do link de rodapé institucional está correto.");
            Assert.AreEqual(linksRodape[1].Text, "Fale conosco", "Verifico que o TEXT do link de rodapé institucional está correto.");
            Assert.AreEqual(linksRodape[1].GetAttribute("href"), "http://orcamentos.net.br/fale-conosco/", "Verifico que a URL do link de rodapé institucional está correta.");
            Assert.AreEqual(linksRodape[1].GetAttribute("target"), "_blank", "Verifico que o TARGET do link de rodapé institucional está correto.");
            Assert.AreEqual(linksRodape[1].GetAttribute("rel"), "nofollow", "Verifico que o REL do link de rodapé institucional está correto.");
        }

        [Test]
        public void RodapeVoceConheceCorreto() {
            IWebElement linkRodapeVoceConhece = home.ObterRodapeVoceConheceLink();
            Assert.AreEqual(home.ObterRodapeVoceConheceTitulo(), "Nossos fornecedores de Orçamento Online", "Verifico que o título do rodapé Você Conhece está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.Text, "fornecedores premium", "Verifico que o TEXT do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("href"), "http://voceconhece.com/", "Verifico que a URL do link de cadastro está correta.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("target"), "_blank", "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("title"), "Você Conhece? Uma rede de indicação de profissionais e empresas em todo o Brasil. Um grupo selecionado dos melhores fornecedores para prestação de serviços, oportunidades de negócio ou busca de parcerias.", "Verifico que o TITLE do link de cadastro está correto.");
        }

        [Test]
        public void SEOCorretos() {
            Assert.AreEqual("Orçamento Online - Cotação de Preços", base.driver.Title, "Verifico que o TITLE da página está correto.");
            Assert.AreEqual("Orçamento Online - Cotação de Preços", home.ObterTituloH1(), "Verifico que o H1 da página está correto.");
            Assert.AreEqual("Que Orçamento Online você deseja?", home.ObterTituloH2(), "Verifico que o H2 correto é exibido.");
            Assert.AreEqual("Depoimentos de Clientes sobre o Orçamento Online", home.ObterTituloH3(), "Verifico que o H3 correto é exibido.");
        }

    }
}
