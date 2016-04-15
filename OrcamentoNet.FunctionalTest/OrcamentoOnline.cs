using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OrcamentoNet.Common;

namespace OrcamentoNet.FunctionalTest
{
    public class OrcamentoOnline : Base
    {
		public OrcamentoOnline(IWebDriver driver) : base(driver) {
			base.driver.Navigate().GoToUrl(Config.UrlSite + Config.UrlHomeOrcamentos);

            if (!"Orçamento Online - Grátis".Equals(driver.Title))
            {
                throw new Exception("Título da página não confere");
            }
        }

		public IList<IWebElement> ObterListaCategorias() {
			IList<IWebElement> temas = base.driver.FindElements(By.ClassName("checkList"));
			IList<IWebElement> categorias = new List<IWebElement>();

			foreach (IWebElement tema in temas)
			{
				IList<IWebElement> categoriasDoTema = tema.FindElements(By.TagName("li"));
				foreach (IWebElement categoria in categoriasDoTema)
				{
					categorias.Add(categoria);
				}
			}

			return categorias;
		}

		public string ObterUrlDaCategoria(IWebElement linkCategoria) {
			return linkCategoria.FindElement(By.TagName("a")).GetAttribute("href");
		}
	}
}
