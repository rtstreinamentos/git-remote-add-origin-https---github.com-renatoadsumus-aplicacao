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
    public class PesquisaSatisfacao
    {
		private IWebDriver driver;

        public PesquisaSatisfacao(IWebDriver driver) {
			this.driver = driver;
		}

		public void DefinirGostei() {
			IWebElement campoFormulario = driver.FindElement(By.Id("uxddlGostou"));
			var comboFormulario = new SelectElement(campoFormulario);
			comboFormulario.SelectByValue("1");
		}

		public void DefinirOpiniao() {
			IWebElement campoFormulario = driver.FindElement(By.Id("uxtxtOqueFoiBom"));
			campoFormulario.SendKeys("Gostei da rapidez de resposta dos orçamentos.");
		}

		public void DefinirPontosMelhoria() {
			IWebElement campoFormulario = driver.FindElement(By.Id("uxtxtOquePodeMelhorar"));
			campoFormulario.SendKeys("Acho que poderia ter mais fornecedores.");
		}

		public void DefinirStatus(string valor) {
			IWebElement campoFormulario = driver.FindElement(By.Id("uxddlStatus"));
			var comboFormulario = new SelectElement(campoFormulario);
			comboFormulario.SelectByValue(valor);
		}

		public void EnviarFormulario() {
			IWebElement campoFormulario = driver.FindElement(By.Name("uxbtnSalvar"));
			campoFormulario.Click();
			Thread.Sleep(Config.PausaTestesMilissegundos);
		}

		public bool StatusFormularioVisivel() {
			return (this.driver.FindElement(By.Id("divFormPesquisaSatisfacao")) != null);
		}

		public string ObterMensagemErro() {
			return this.driver.FindElement(By.Id("MensagemSuperiorControle1_uxlblMensagem")).Text;
		}

	}
}
