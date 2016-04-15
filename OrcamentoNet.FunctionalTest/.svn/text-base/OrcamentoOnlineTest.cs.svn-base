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
    public class OrcamentoOnlineTest : BaseTest
    {
        private OrcamentoOnline orcamentoOnline;

		public OrcamentoOnlineTest() {
			orcamentoOnline = new OrcamentoOnline(base.driver);
        }

        [SetUp]
        public void SetupTest() {
        }

        [TearDown]
        public void TeardownTest() {
        }

		[Test]
		public void NavegarPelaListaDeCategoriasComSucesso() {
			IWebDriver webDriverLocal = new InternetExplorerDriver();
			Base paginaBaseLocal = new Base(webDriverLocal);

			try
			{
				IList<IWebElement> listaCategorias = orcamentoOnline.ObterListaCategorias();
				foreach (IWebElement categoria in listaCategorias)
				{
					paginaBaseLocal.IrPagina(orcamentoOnline.ObterUrlDaCategoria(categoria));
					// por enquanto, inspeção visual - Fabrício
					// Assert.AreEqual("Orçamento de " + categoria.Text + " - Grátis", paginaBaseLocal.ObterTitle(), "Verifico que o TITLE da categoria " + categoria.Text + " está correto.");
				}
			}
			finally
			{
				webDriverLocal.Quit();
			}

		}
    }
}
