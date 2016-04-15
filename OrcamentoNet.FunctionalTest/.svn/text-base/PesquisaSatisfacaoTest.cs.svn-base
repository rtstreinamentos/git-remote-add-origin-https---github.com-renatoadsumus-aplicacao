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
	public class PesquisaSatisfacaoTest
	{
		private PesquisaSatisfacao pesquisaSatisfacao;
		private IWebDriver driver;

		public PesquisaSatisfacaoTest() {
			this.driver = new InternetExplorerDriver();
			pesquisaSatisfacao = new PesquisaSatisfacao(this.driver);
		}

		~PesquisaSatisfacaoTest() {
			try
			{
				this.driver.Close();
				this.driver.Quit();
			}
			catch (Exception)
			{
				// Ignore errors if unable to close the browser
			}
		}

		[SetUp]
		public void SetupTest() {
		}

		[TearDown]
		public void TeardownTest() {
		}

		[Test]
		public void GravarPesquisaSucesso() {
			this.driver.Navigate().GoToUrl(Config.UrlSite + "PesquisaSatisfacaoComprador.aspx?email=fabriciofuji@yahoo.com.br&id=1");
			pesquisaSatisfacao.DefinirStatus("2");
			pesquisaSatisfacao.DefinirOpiniao();
			pesquisaSatisfacao.DefinirPontosMelhoria();
			pesquisaSatisfacao.DefinirGostei();
			pesquisaSatisfacao.EnviarFormulario();
			Assert.IsTrue(driver.Url.IndexOf("PesquisaSatisfacaoCompradorSucesso.aspx") > 0, "Verifico que a página de confirmação é exibida com sucesso.");
		}

		[Test]
		public void ValidarParametrosNaoInformados() {
			this.driver.Navigate().GoToUrl(Config.UrlSite + "PesquisaSatisfacaoComprador.aspx");
			Assert.AreEqual("Pedido de orçamento não identificado.", pesquisaSatisfacao.ObterMensagemErro());
		}

		[Test]
		public void ValidarParametrosEmailInvalido() {
			this.driver.Navigate().GoToUrl(Config.UrlSite + "PesquisaSatisfacaoComprador.aspx?email=fabricioyahoo.com.br&id=10");
			Assert.AreEqual("Pedido de orçamento não identificado.", pesquisaSatisfacao.ObterMensagemErro());
		}

		[Test]
		public void ValidarParametrosSucesso() {
			this.driver.Navigate().GoToUrl(Config.UrlSite + "PesquisaSatisfacaoComprador.aspx?email=fabriciofuji@yahoo.com.br&id=1");
			Assert.AreEqual(String.Empty, pesquisaSatisfacao.ObterMensagemErro(), "Nenhuma mensagem de erro é exibida.");
			Assert.IsTrue(pesquisaSatisfacao.StatusFormularioVisivel(), "Formulário de pedido de orçamento está visível.");
		}

		[Test]
		public void ValidarPedidoOrcamentoNaoIdentificadoOuNaoAutorizado() {
			this.driver.Navigate().GoToUrl(Config.UrlSite + "PesquisaSatisfacaoComprador.aspx?email=fabricio@yahoo.com.br&id=10");
			Assert.AreEqual("Pedido de orçamento não identificado.", pesquisaSatisfacao.ObterMensagemErro());
		}

		[Test]
		public void ValidarPesquisaJaRespondida() {
			this.driver.Navigate().GoToUrl(Config.UrlSite + "PesquisaSatisfacaoComprador.aspx?email=fabriciofuji@yahoo.com.br&id=1");
			Assert.AreEqual("Pesquisa de satisfação já respondida. Em caso de dúvidas ou necessidade de orientação, fale conosco.", pesquisaSatisfacao.ObterMensagemErro());
		}
	}
}
