using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OrcamentoNet.Common;

namespace OrcamentoNet.FunctionalTest
{
    [TestFixture]
    public class OrcamentoGenericoTest : BaseTest
    {
        private OrcamentoGenerico orcamentoGenerico;

        public OrcamentoGenericoTest() {
            orcamentoGenerico = new OrcamentoGenerico(base.driver);
        }

        [SetUp]
        public void SetupTest() {
        }

        [TearDown]
        public void TeardownTest() {
        }

        [Test]
        // Dado que acessei a página com algum formulário (orcamento-online.aspx?categoria=180)
        // Quando visualizo a página
        // Então:
        //      não vejo a lista de orçamentos mais populares
        //      não vejo a lista de todos os tipos de orçamento
        //      vejo o formulário de pedido de orçamento
        //      vejo o link para troca de tipo de orçamento
        public void PaginaComFomularioCorreta() {
            orcamentoGenerico.IrParaPaginaComFormularioMudancaResidencial();
            IWebElement divOrcamentosPopulares = orcamentoGenerico.ObterDivOrcamentosMaisPopulares();
            Assert.IsNull(divOrcamentosPopulares, "Não vejo a lista de orçamentos mais populares");

            IWebElement tabelaTiposOrcamento = orcamentoGenerico.ObterTabelaTiposOrcamento();
            Assert.IsNull(tabelaTiposOrcamento, "Não vejo a lista de todos os tipos de orçamento");

            IWebElement formSolicitacaoOrcamento = orcamentoGenerico.ObterFormSolicitacaoOrcamento();
            Assert.IsNotEmpty(formSolicitacaoOrcamento.Text.Trim(), "Vejo o formulário de pedido de orçamento");

            IWebElement linkTrocarTipoOrcamento = orcamentoGenerico.ObterLinkTrocarTipoOrcamento();
            Assert.IsNotNull(linkTrocarTipoOrcamento, "Vejo o link de troca de tipo de pedido de orçamento");
        }

        [Test]
        // Dado que acessei a página diretamente (orcamento-online.aspx ou orcamento-online.aspx#listaOrcamentos)
        // Quando visualizo a página
        // Então:
        //      vejo a lista de orçamentos mais populares
        //      vejo a lista de todos os tipos de orçamento
        //      não vejo o formulário de pedido de orçamento
        public void PaginaSemFomularioCorreta() {
            orcamentoGenerico.IrParaPaginaSemFormulario();
            IWebElement divOrcamentosPopulares = orcamentoGenerico.ObterDivOrcamentosMaisPopulares();
            Assert.IsNotNull(divOrcamentosPopulares, "Vejo a lista de orçamentos mais populares");

            IWebElement tabelaTiposOrcamento = orcamentoGenerico.ObterTabelaTiposOrcamento();
            Assert.IsNotNull(tabelaTiposOrcamento, "Vejo a lista de todos os tipos de orçamento");

            IWebElement formSolicitacaoOrcamento = orcamentoGenerico.ObterFormSolicitacaoOrcamento();
            Assert.IsEmpty(formSolicitacaoOrcamento.Text.Trim(), "Não vejo o formulário de pedido de orçamento");
        }

        [Test]
        public void PedidosOrcamentoRecentesCorreto() {
            bool encontreiDiferente = false;

            IList<IWebElement> listaPedidosOrcamento = orcamentoGenerico.ObterPedidosOrcamentoRecentes();
            string primeiroTipoOrcamento = orcamentoGenerico.ObterCategoriaPedidoOrcamentoRecente(0);

            // devem existir pelo menos 2 tipos diferentes de orçamento
            for (int i = 1; i < listaPedidosOrcamento.Count; i++)
            {
                if (orcamentoGenerico.ObterCategoriaPedidoOrcamentoRecente(i) != primeiroTipoOrcamento)
                {
                    encontreiDiferente = true;
                    break;
                }

                Assert.IsTrue(encontreiDiferente, "Verifico que existem pelo menos 2 tipos diferentes de orçamentos mais recentes.");
            }
        }

        [Test]
        public void RodapeHistoricoCorreto() {
            IWebElement linkRodapeHistorico = orcamentoGenerico.ObterRodapeHistoricoLink();

            Assert.AreEqual(orcamentoGenerico.ObterRodapeHistoricoTitulo(), "Histórico de Preços e Cotações");
            Assert.AreEqual(linkRodapeHistorico.Text, "preços e cotações feitas através do Orçamento Online", "Verifico que o TEXT do link de histórico está correto.");
            Assert.AreEqual(linkRodapeHistorico.GetAttribute("href"), "http://preco.orcamentos.net.br/", "Verifico que a URL do link de histórico está correta.");
            Assert.AreEqual(linkRodapeHistorico.GetAttribute("target"), "_blank", "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeHistorico.GetAttribute("title"), "Preço e cotação de produtos e serviços através de solicitação de orçamento online. Melhor preço e cotação para suas compras.", "Verifico que o TITLE do link de cadastro está correto.");
        }

        [Test]
        public void RodapeInstitucionalCorreto() {
            IList<IWebElement> linksRodape = orcamentoGenerico.ObterRodapeInstitucional();
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
            IWebElement linkRodapeVoceConhece = orcamentoGenerico.ObterRodapeVoceConheceLink();
            Assert.AreEqual(orcamentoGenerico.ObterRodapeVoceConheceTitulo(), "Nossos fornecedores de Orçamento Online", "Verifico que o título do rodapé Você Conhece está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.Text, "fornecedores premium", "Verifico que o TEXT do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("href"), "http://voceconhece.com/", "Verifico que a URL do link de cadastro está correta.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("target"), "_blank", "Verifico que o TARGET do link de cadastro está correto.");
            Assert.AreEqual(linkRodapeVoceConhece.GetAttribute("title"), "Você Conhece? Uma rede de indicação de profissionais e empresas em todo o Brasil. Um grupo selecionado dos melhores fornecedores para prestação de serviços, oportunidades de negócio ou busca de parcerias.", "Verifico que o TITLE do link de cadastro está correto.");
        }

        [Test]
        public void SEOCorretos() {
            Assert.AreEqual("Orçamento Online - Grátis", base.driver.Title, "Verifico que o TITLE da página está correto.");
            Assert.AreEqual("Orçamento Online - Grátis", orcamentoGenerico.ObterTituloH1(), "Verifico que o H1 da página está correto.");
            Assert.AreEqual("Que orçamentos posso solicitar?", orcamentoGenerico.ObterTituloH2SemFormulario(), "Verifico que o H2 correto é exibido.");
        }

        [Test]
        public void OrcamentoSucesso() {
            orcamentoGenerico.IrParaPaginaComFormularioMudancaResidencial();
            orcamentoGenerico.DefinirCampoNome("Fabrício Yutaka Fujikawa");

            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioGenerico$uxtxtEmail"));
            campoFormulario.SendKeys("fabriciofuji@yahoo.com.br");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioGenerico$uxtxtDDD"));
            campoFormulario.SendKeys("21");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioGenerico$uxtxtTelefone"));
            campoFormulario.SendKeys("8124-9484");

            orcamentoGenerico.DefinirCaptcha();

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioGenerico$CidadeDropDownControle1$uxddlEstado"));
            var comboEstados = new SelectElement(campoFormulario);
            comboEstados.SelectByValue("RJ");
            Thread.Sleep(Config.PausaTestesMilissegundos);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioGenerico$CidadeDropDownControle1$uxddlCidade"));
            var comboCidades = new SelectElement(campoFormulario);
            comboCidades.SelectByValue("3631");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioGenerico$uxtxtTitulo"));
            string tituloOrcamento = "Mudança da Tijuca para Barra da Tijuca - " + base.DataHoraOrcamento;
            campoFormulario.SendKeys(tituloOrcamento);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioGenerico$uxtxtObservacao"));
            campoFormulario.SendKeys(@"Solicito o orçamento de mudança de móveis e eletrodomesticos DE um apartamento e uma casa na Tijuca, Rio de Janeiro, PARA uma casa na Barra da Tijuca, também no Rio de Janeiro.

Seguem os itens e quantidades a serem transportados:

2 Fogão
3 Geladeira
2 Maq de Lav Louça pequena
1 Maq Lav Roupas 6K
1 Fruteira
4 Bancos pequenos de Cozinha
1 Tabua de passar roupa
2 Sofá 3 lugares
2 Sofá 2 lugares
3 Poltronas pequenas

1 Puff
4 Mesinha de canto
1 Mesinha de centro bem pequena
1 Aparador
2 Rack baixo de TV LCD
4 Cadeiras/Poltrona
1 Mesa de Jantar com 6 cadeiras
2 Banqueta
1 Armário de ferro (prateleitas)
2 Cama Casal

3 Cama Solteiro
1 Berço
5 Mesa de Cabeceira
1 Mesa de madeira leve com dois bancos
1 Porta com Cavalete
2 Gaveteiro de palha
2 Gaveteiro de plástico
2 Gaveteiros MDF pequenos
3 Escrivaninha Infantil

1 Mesa de computador
1 Bar
2 Ar Refrigerado
1 Estante pequena de mandeira
2 Caixas de som
1 Viveiro
2 Bicicleta

OBS: NÃO tem armários para serem desmontados e montados e nem instalações nas paredes para serem retiradas e colocadas.
");

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioGenerico$uxbtnSalvar"));
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
