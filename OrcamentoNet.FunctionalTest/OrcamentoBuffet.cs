using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrcamentoNet.Common;

namespace OrcamentoNet.FunctionalTest
{
    public class OrcamentoBuffet : Base
    {
        public OrcamentoBuffet(IWebDriver driver) : base(driver) {
            this.IrPaginaBase();
        }

        public void DefinirCaptcha() {
            base.DefinirCaptcha("OrcamentoFormularioEvento");
        }

        public void DefinirCidadeEstadoRio() {
            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CidadeDropDownControle1$uxddlEstado"));
            var comboFormulario = new SelectElement(campoFormulario);
            comboFormulario.SelectByValue("RJ");
            Thread.Sleep(Config.PausaTestesMilissegundos);

            campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$CidadeDropDownControle1$uxddlCidade"));
            var comboCidades = new SelectElement(campoFormulario);
            comboCidades.SelectByValue("3631");
        }

        public void DefinirDataEvento(DateTime dataEvento) {
            IWebElement campoFormulario = base.driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtDataEvento"));
            campoFormulario.SendKeys(dataEvento.ToString("dd/mm/yyyy"));
        }

        public void DefinirDescricaoEvento(string descricao) {
            IWebElement campoFormulario = base.driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtObservacao"));
            campoFormulario.SendKeys(descricao);
        }

        public void DefinirEmailCliente(string emailCliente) {
            IWebElement campoFormulario = base.driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtEmail"));
            campoFormulario.SendKeys(emailCliente);
        }

        public void DefinirNomeEvento(string evento) {
            IWebElement campoFormulario = base.driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtTitulo"));
            campoFormulario.SendKeys(evento);
        }

        public void DefinirNomeCliente(string nomeCliente) {
            IWebElement campoFormulario = base.driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtNome"));
            campoFormulario.SendKeys(nomeCliente);
        }

        public void DefinirNumeroConvidados(int numeroConvidados) {
            IWebElement campoFormulario = base.driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtNumeroConvidados"));
            campoFormulario.SendKeys(numeroConvidados.ToString());
        }

        public void DefinirTelefone(string ddd, string telefone) {
            IWebElement campoFormulario = base.driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtDDD"));
            campoFormulario.SendKeys(ddd);
            campoFormulario = base.driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxtxtTelefone"));
            campoFormulario.SendKeys(telefone);
        }

        public void EnviarFormulario() {
            IWebElement campoFormulario = driver.FindElement(By.Name("ctl00$cpObjetivoPrincipalPagina$OrcamentoFormularioEvento$uxbtnSalvar"));
            campoFormulario.Click();
            Thread.Sleep(Config.PausaTestesMilissegundos);
        }

        public void IrPaginaBase() {
            base.driver.Navigate().GoToUrl(Config.UrlSite + Config.UrlFormularioBuffetInfantil);
			Thread.Sleep(Config.PausaTestesMilissegundos);

            if (!"Orçamento de Festas e Buffet Infantis - Grátis".Equals(driver.Title))
            {
                throw new Exception("Título da página não confere");
            }
        }

        public void SelecionarTodosTiposOrcamento() {
            for (int i = 0; i <= 12; i++)
            {
                IWebElement campoFormulario = driver.FindElement(By.Id("ctl00_cpObjetivoPrincipalPagina_OrcamentoFormularioEvento_uxchkTemaCasamento_" + i.ToString()));
                if (!campoFormulario.Selected)
                {
                    campoFormulario.Click();
                }
            }
        }
    }
}
