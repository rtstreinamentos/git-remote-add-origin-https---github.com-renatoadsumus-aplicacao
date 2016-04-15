using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OrcamentoNet.Common;

namespace OrcamentoNet.FunctionalTest
{
    public class OrcamentoGenerico : Base
    {
        private string nomeFormulario = "OrcamentoFormularioGenerico";

        public OrcamentoGenerico(IWebDriver driver) : base (driver) {
            base.driver = driver;
            base.driver.Navigate().GoToUrl(Config.UrlSite + "orcamento-online.aspx#listaOrcamentos");

            if (!"Orçamento Online - Grátis".Equals(driver.Title))
            {
                throw new Exception("Título da página não confere");
            }
        }

        public void DefinirCampoNome(string valorNome) {
            base.DefinirCampoNome(nomeFormulario, valorNome);
        }

        public void DefinirCaptcha() {
            base.DefinirCaptcha("OrcamentoFormularioGenerico");
        }

        public void IrParaPaginaSemFormulario() {
            base.driver.Navigate().GoToUrl(Config.UrlSite + "orcamento-online.aspx");
        }

        public void IrParaPaginaComFormularioMudancaResidencial() {
            base.driver.Navigate().GoToUrl(Config.UrlSite + "orcamento-online.aspx?categoria=180");
        }

        public IWebElement ObterDivOrcamentosMaisPopulares() {
            try
            {
                return base.driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_uxOrcamentosMaisPopulares"));
            }
            catch (NoSuchElementException ex)
            {
                return null;
            }
        }

        public IWebElement ObterFormSolicitacaoOrcamento() {
            return base.driver.FindElement(By.ClassName("frm-solicitar-orcamento"));
        }

        public IWebElement ObterLinkTrocarTipoOrcamento() {
            try
            {
                return base.driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_uxTrocarFormulario"));
            }
            catch (NoSuchElementException ex)
            {
                return null;
            }
        }

        public IWebElement ObterTabelaTiposOrcamento() {
            try
            {
                return base.driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_CategoriaListaControle1_uxrptCategoriasColuna1"));
            }
            catch (NoSuchElementException ex)
            {
                return null;
            }
        }

        public string ObterTituloH2SemFormulario() {
            return this.driver.FindElement(By.Id("listaOrcamentosH2")).Text;
        }
    }
}
