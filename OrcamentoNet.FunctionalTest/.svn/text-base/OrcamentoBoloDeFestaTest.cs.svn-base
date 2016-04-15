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
    public class OrcamentoBoloDeFestaTest : BaseTest
    {
        private OrcamentoBoloDeFesta orcamentoBoloDeFesta;

        public OrcamentoBoloDeFestaTest() {
            orcamentoBoloDeFesta = new OrcamentoBoloDeFesta(base.driver);
        }

        [SetUp]
        public void SetupTest() {
            //retorna à página base
            orcamentoBoloDeFesta.IrPaginaBase();
        }

        [TearDown]
        public void TeardownTest() {
        }

        [Test]
        public void LinksInternosCorretos() {
            string textoExibicaoLink = String.Empty;
            string tooltipLink = String.Empty;
            string urlLink = String.Empty;

            for (int i = 0; i <= 3; i++)
            {
                IWebElement linkDaLista = orcamentoBoloDeFesta.ObterLinkInterno(i);

                switch (i)
                {
                    case 0:
                        textoExibicaoLink = "Rio de Janeiro";
                        tooltipLink = "Solicite orçamento grátis de bolo de festa para aniversários, casamentos e eventos no Rio de Janeiro. Receba cotação de bolo de festa para aniversários, casamentos e eventos de fornecedores premium do Rio de Janeiro. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-Bolo-Festa-rio-de-janeiro-130-3631.aspx";
                        break;
                    case 1:
                        textoExibicaoLink = "Salvador";
                        tooltipLink = "Solicite orçamento grátis de bolo de festa para aniversários, casamentos e eventos em Salvador. Receba cotação de preços de bolo de festa de fornecedores premium em Salvador. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-Bolo-Festa-salvador-130-535.aspx";
                        break;
                    case 2:
                        textoExibicaoLink = "Todos";
                        tooltipLink = "Solicite orçamento grátis de bolo de festa para aniversários, casamentos e eventos. Receba cotação de preços de bolo de festa de fornecedores premium. Prático, simples, eficaz e grátis!";
                        urlLink = "orcamento-online-Bolo-Festa-130.aspx";
                        break;
                    case 3:
                        textoExibicaoLink = "Outros orçamentos";
                        tooltipLink = "Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores de diversos produtos e serviços. Prático, simples, eficaz e grátis!";
                        urlLink = Config.UrlFormularioGenerico;
                        break;
                }

                urlLink = Config.UrlSite + urlLink;

                Assert.AreEqual(textoExibicaoLink, linkDaLista.Text, "Verifico que o link interno " + i.ToString() + " está correto.");
                Assert.AreEqual(tooltipLink, linkDaLista.GetAttribute("title"), "Verifico que o TITLE do link interno " + i.ToString() + " está correto.");
                Assert.AreEqual(urlLink, linkDaLista.GetAttribute("href"), "Verifico que o HREF do link interno " + i.ToString() + " está correto.");

                orcamentoBoloDeFesta.IrPagina(urlLink);
                Assert.IsTrue(this.driver.PageSource.IndexOf("Server Error in '/' Application") < 0, "Verifico que o link " + i.ToString() + " aberto não gerou erro no servidor.");
                orcamentoBoloDeFesta.IrPaginaBase();
            }
        }

        [Test]
        public void RodapeHistoricoCorreto() {
            IWebElement linkRodapeHistorico = orcamentoBoloDeFesta.ObterRodapeHistoricoLink();

            Assert.AreEqual("Preços e Cotações de Bolo de Festa", orcamentoBoloDeFesta.ObterRodapeHistoricoTitulo());
            Assert.AreEqual("preços e cotações de bolo de festa", linkRodapeHistorico.Text, "Verifico que o TEXT do link de histórico está correto.");
            Assert.AreEqual("http://preco.orcamentos.net.br/cotacao/bolo-festa", linkRodapeHistorico.GetAttribute("href"), "Verifico que a URL do link de histórico está correta.");
            Assert.AreEqual("_blank", linkRodapeHistorico.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual("Preço e cotação de bolo de festa através de solicitação de orçamento online. Melhor preço e cotação para suas compras.", linkRodapeHistorico.GetAttribute("title"), "Verifico que o TITLE do link de cadastro está correto.");
        }

        [Test]
        public void RodapeVoceConheceCorreto() {
            IWebElement linkRodapeVoceConhece = orcamentoBoloDeFesta.ObterRodapeVoceConheceLink();
            Assert.AreEqual("Nossos fornecedores de Bolo de Festa", orcamentoBoloDeFesta.ObterRodapeVoceConheceTitulo(), "Verifico que o título do rodapé Você Conhece está correto.");
            Assert.AreEqual("fornecedores premium de bolo de festa", linkRodapeVoceConhece.Text, "Verifico que o TEXT do link de cadastro está correto.");
            Assert.AreEqual("http://voceconhece.com/", linkRodapeVoceConhece.GetAttribute("href"), "Verifico que a URL do link de cadastro está correta.");
            Assert.AreEqual("_blank", linkRodapeVoceConhece.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual("Você Conhece? Uma rede de indicação de profissionais e empresas em todo o Brasil. Um grupo selecionado dos melhores fornecedores para prestação de serviços, oportunidades de negócio ou busca de parcerias.", linkRodapeVoceConhece.GetAttribute("title"), "Verifico que o TITLE do link de cadastro está correto.");
        }

        [Test]
        public void SEOCorretos() {
            Assert.AreEqual("Orçamento de Bolo de Festa - Grátis", base.driver.Title, "Verifico que o TITLE da página está correto.");
            Assert.AreEqual("Orçamento de Bolo de Festa - Grátis", orcamentoBoloDeFesta.ObterTituloH1(), "Verifico que o H1 da página está correto.");

            string descricao = orcamentoBoloDeFesta.ObterDescricao(); 
            Assert.IsNotEmpty(descricao, "Verifico que a descrição não está vazia.");
            Assert.IsTrue(descricao.ToLower().IndexOf("bolo de festa") > 0, "Verifico que o nome da categoria aparece na descrição.");
        }

    }
}
