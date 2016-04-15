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
    public class OrcamentoBuffetTest : BaseTest
    {
        private OrcamentoBuffet orcamentoBuffetInfantil;

        public OrcamentoBuffetTest() {
            orcamentoBuffetInfantil = new OrcamentoBuffet(base.driver);
        }

        [SetUp]
        public void SetupTest() {
            //retorna à página base
            orcamentoBuffetInfantil.IrPaginaBase();
        }

        [TearDown]
        public void TeardownTest() {
        }

        [Test]
        public void LinksInternosCorretos() {
            string textoExibicaoLink = String.Empty;
            string tooltipLink = String.Empty;
            string urlLink = String.Empty;

            for (int i = 0; i <= 1; i++)
            {
                IWebElement linkDaLista = orcamentoBuffetInfantil.ObterLinkInterno(i);

                switch (i)
                {
                    case 0:
                        textoExibicaoLink = "Todos";
                        tooltipLink = "Solicite orçamento grátis de festa e buffet infantil. Receba cotação de preços de buffet e festa infantil. Prático, simples, eficaz e grátis!";
                        urlLink = Config.UrlFormularioBuffetInfantil;
                        break;
                    case 1:
                        textoExibicaoLink = "Outros orçamentos";
                        tooltipLink = "Solicite orçamento online grátis de diversos produtos e serviços. Receba cotação de preços de vários fornecedores de diversos produtos e serviços. Prático, simples, eficaz e grátis!";
                        urlLink = Config.UrlFormularioGenerico;
                        break;
                }

                urlLink = Config.UrlSite + urlLink;

                Assert.AreEqual(textoExibicaoLink, linkDaLista.Text, "Verifico que o link interno " + i.ToString() + " está correto.");
                Assert.AreEqual(tooltipLink, linkDaLista.GetAttribute("title"), "Verifico que o TITLE do link interno " + i.ToString() + " está correto.");
                Assert.AreEqual(urlLink, linkDaLista.GetAttribute("href"), "Verifico que o HREF do link interno " + i.ToString() + " está correto.");
            }
        }

        [Test]
        public void OrcamentoMultiploSucesso() {
            orcamentoBuffetInfantil.DefinirNomeCliente("Fabrício Yutaka Fujikawa");
            orcamentoBuffetInfantil.DefinirEmailCliente("fabriciofuji@yahoo.com.br");
            orcamentoBuffetInfantil.DefinirTelefone("21", "8124-9484");
            orcamentoBuffetInfantil.DefinirCaptcha();
            orcamentoBuffetInfantil.DefinirNomeEvento("Aniversário de 1 ano - "+ base.DataHoraOrcamento);
            orcamentoBuffetInfantil.SelecionarTodosTiposOrcamento();
            orcamentoBuffetInfantil.DefinirDataEvento(DateTime.Parse("2012/12/31"));
            orcamentoBuffetInfantil.DefinirNumeroConvidados(100);
            orcamentoBuffetInfantil.DefinirCidadeEstadoRio();
            orcamentoBuffetInfantil.DefinirDescricaoEvento(@"Trata-se de uma comemoração de um ano de nosso primeiro filho. Desejamos uma festa bem aconchegante, simples porém marcante.

Aceitamos sugestões de cardápio.");
            orcamentoBuffetInfantil.EnviarFormulario();
            Assert.IsTrue(driver.Url.IndexOf("DefaultSucesso.aspx") > 0, "Verifico que a página de confirmação é exibida com sucesso.");
        }

        [Test]
        public void PedidosOrcamentoRecentesCorreto() {
            bool encontreiDiferente = false;

            IList<IWebElement> listaPedidosOrcamento = orcamentoBuffetInfantil.ObterPedidosOrcamentoRecentes();
            string primeiroTipoOrcamento = orcamentoBuffetInfantil.ObterCategoriaPedidoOrcamentoRecente(0);

            // não devem existir tipos diferentes de orçamento
            for (int i = 1; i < listaPedidosOrcamento.Count; i++)
            {
                if (orcamentoBuffetInfantil.ObterCategoriaPedidoOrcamentoRecente(i) != primeiroTipoOrcamento)
                {
                    encontreiDiferente = true;
                    break;
                }

                Assert.IsFalse(encontreiDiferente, "Verifico que não existem diferentes de orçamentos mais recentes na página.");
            }
        }

        [Test]
        public void RodapeHistoricoCorreto() {
            IWebElement linkRodapeHistorico = orcamentoBuffetInfantil.ObterRodapeHistoricoLink();

            Assert.AreEqual("Preços e Cotações de Festas e Buffet Infantis", orcamentoBuffetInfantil.ObterRodapeHistoricoTitulo());
			Assert.AreEqual("preços e cotações de festa e buffet infantil", linkRodapeHistorico.Text, "Verifico que o TEXT do link de histórico está correto.");
			Assert.AreEqual("http://preco.orcamentos.net.br/cotacao/buffet-infantil", linkRodapeHistorico.GetAttribute("href"), "Verifico que a URL do link de histórico está correta.");
			Assert.AreEqual("_blank", linkRodapeHistorico.GetAttribute("target"), "Verifico que o TARGET do link de cadastro está correto.");
			Assert.AreEqual("Preço e cotação de festa e buffet infantil através de solicitação de orçamento online. Melhor preço e cotação para suas compras.", linkRodapeHistorico.GetAttribute("title"), "Verifico que o TITLE do link de cadastro está correto.");
        }

        [Test]
        public void RodapeVoceConheceCorreto() {
            IWebElement linkRodapeVoceConhece = orcamentoBuffetInfantil.ObterRodapeVoceConheceLink();
            Assert.AreEqual(orcamentoBuffetInfantil.ObterRodapeVoceConheceTitulo(), "Nossos fornecedores de Festas e Buffet Infantis", "Verifico que o título do rodapé Você Conhece está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.Text, "fornecedores premium de Festas e Buffet Infantis", "Verifico que o TEXT do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("href"), "http://voceconhece.com/", "Verifico que a URL do link de cadastro está correta.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("target"), "_blank", "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("title"), "Você Conhece? Uma rede de indicação de profissionais e empresas em todo o Brasil. Um grupo selecionado dos melhores fornecedores para prestação de serviços, oportunidades de negócio ou busca de parcerias.", "Verifico que o TITLE do link de cadastro está correto.");
        }

        [Test]
        public void SEOCorretos() {
            Assert.AreEqual("Orçamento de Festas e Buffet Infantis - Grátis", base.driver.Title, "Verifico que o TITLE da página está correto.");
            Assert.AreEqual("Orçamento de Festas e Buffet Infantis - Grátis", orcamentoBuffetInfantil.ObterTituloH1(), "Verifico que o H1 da página está correto.");

            string descricao = orcamentoBuffetInfantil.ObterDescricao(); 
            Assert.IsNotEmpty(descricao, "Verifico que a descrição não está vazia.");
            Assert.IsTrue(descricao.ToLower().IndexOf("festas e buffet infantis") > 0, "Verifico que o nome da categoria aparece na descrição.");
        }

    }
}
