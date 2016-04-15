using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OrcamentoNet.Common;

namespace OrcamentoNet.FunctionalTest
{
    public class Base
    {
        public IWebDriver driver;

        public Base(IWebDriver driver) 
        {
            this.driver = driver;
        }

        protected void DefinirCampoNome(string nomeFormulario, string valorNome) {
            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$" + nomeFormulario + "$uxtxtNome"));
            campoFormulario.SendKeys(valorNome);
        }

        protected void DefinirCaptcha(string nomeFormulario) {
            IWebElement campoFormulario = this.driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$" +nomeFormulario+ "$CaptchaControle1$uxtxtCaptcha"));
            campoFormulario.SendKeys(driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_" + nomeFormulario + "_CaptchaControle1_uxlblCaptcha")).Text);
        }

        public void IrPagina(string urlDesejada) {
            this.driver.Navigate().GoToUrl(urlDesejada);
        }

        public IWebElement ObterBotaoCadastroFornecedor() {
            IWebElement divCadastro = this.driver.FindElement(By.ClassName("bigBuyButton"));
            IWebElement botaoCadastro = divCadastro.FindElement(By.ClassName("buttonLinkWithImage"));
            return botaoCadastro;
        }

        public string ObterCategoriaPedidoOrcamentoRecente(int posicao) {
            IWebElement divOrcamentos = this.driver.FindElement(By.Id("PedidosOrcamentoRecentes"));
            IList<IWebElement> listaPedidosOrcamento = divOrcamentos.FindElements(By.TagName("li"));
            return listaPedidosOrcamento[posicao].FindElement(By.TagName("h2")).Text;
        }

        public string ObterDescricao() {
            return this.driver.FindElements(By.ClassName("productDescription"))[1].Text;
        }

		public string ObterNomeFornecedorRecente(int posicao) {
			IWebElement divFornecedores = this.driver.FindElement(By.ClassName("FornecedoresRecentes"));
			IList<IWebElement> listaFornecedores = divFornecedores.FindElements(By.TagName("li"));
			return listaFornecedores[posicao].FindElement(By.TagName("h2")).Text;
		}

		public IList<IWebElement> ObterFornecedoresRecentes() {
			IWebElement divFornecedores = this.driver.FindElement(By.ClassName("FornecedoresRecentes"));
			IList<IWebElement> listaFornecedores = divFornecedores.FindElements(By.TagName("li"));
			return listaFornecedores;
		}

		public IWebElement ObterLinkInterno(int posicaoLink) {
            IWebElement divLinksInternos = this.driver.FindElement(By.ClassName("tipos-orcamentos"));
            IWebElement listaPrincipal = divLinksInternos.FindElement(By.ClassName("checkList"));
            IList<IWebElement> itensDaLista = listaPrincipal.FindElements(By.TagName("li"));
            IWebElement itemDaLista = itensDaLista[posicaoLink];
            IWebElement linkDaLista = itensDaLista[posicaoLink].FindElement(By.TagName("a"));

            return linkDaLista;
        }

        public IList<IWebElement> ObterPedidosOrcamentoRecentes() {
            IWebElement divOrcamentos = this.driver.FindElement(By.Id("PedidosOrcamentoRecentes"));
            IList<IWebElement> listaPedidosOrcamento = divOrcamentos.FindElements(By.TagName("li"));
            return listaPedidosOrcamento;
        }

        public IWebElement ObterRodapeHistoricoLink() {
            IWebElement divHistorico = this.driver.FindElement(By.Id("contactInformation"));
            IWebElement linkRodapeHistorico = divHistorico.FindElement(By.TagName("a"));
            return linkRodapeHistorico;
        }

        public string ObterRodapeHistoricoTitulo() {
            IWebElement divHistorico = this.driver.FindElement(By.Id("contactInformation"));
            return divHistorico.FindElement(By.TagName("h3")).Text;
        }

        public IList<IWebElement> ObterRodapeInstitucional() {
            IWebElement divRodape = this.driver.FindElement(By.Id("footerInformation"));
            IList<IWebElement> linksRodape = divRodape.FindElements(By.TagName("a"));
            return linksRodape;
        }

        public IWebElement ObterRodapeVoceConheceLink() {
            IWebElement linkRodapeVoceConhece = this.driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_hplLink"));
            return linkRodapeVoceConhece;
        }

        public string ObterRodapeVoceConheceTitulo() {
            return this.driver.FindElement(By.Id("ctl00_cpObjetivoTerciarioPagina_RodapeControle1_uxTituloH3RodapeVoceConhece")).Text;
        }

		public string ObterTitle() {
			return this.driver.Title;
		}

		public string ObterTituloH1() {
            return this.driver.FindElement(By.TagName("h1")).Text;
        }

        public string ObterTituloH2() {
            return this.driver.FindElement(By.Id("PedidosEspecificos")).Text;
        }

        public string ObterTituloH3() {
            return this.driver.FindElement(By.Id("boxHeading")).Text;
        }
    }
}
