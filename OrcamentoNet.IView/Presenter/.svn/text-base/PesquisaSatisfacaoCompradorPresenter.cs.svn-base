using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.IView.Presenter
{
	public class PesquisaSatisfacaoCompradorPresenter
	{
		public IPesquisaSatisfacaoComprador View { get; set; }

		[Inject]
		public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

		#region Métodos Privados
		private bool DadosValidos() {
			bool dadosValidos = false;
			int tamanhoMaximoEmail = 100;
			ValidadorDados validador = new ValidadorDados();
			dadosValidos = validador.ValidarEmail(View.Email, tamanhoMaximoEmail);
			if (!dadosValidos) return false;

			dadosValidos = pedidoOrcamentoService.AutorizarAcesso(View.IdPedidoOrcamento, View.Email);
			return dadosValidos;
		}
		#endregion

		private void InicializarServico() {
			StandardKernel k = new StandardKernel(new CustomModule());
			k.Inject(this);
		}

		public void OnViewInitialized() {
			InicializarServico();
		}

		public void AutorizarAcesso() {
			if (!this.DadosValidos())
			{
				View.ExibirMensagem(View.MensagemErroValidacaoDados);
				return;
			}

			// verifica se já foi respondida
			PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.ObterPedidoOrcamentoPorEmailId(View.Email, View.IdPedidoOrcamento);
			if (pedidoOrcamento.PesquisaRespondida)
			{
				View.ExibirMensagem(View.MensagemErroPesquisaRespondida);
				return;
			}

			View.ExibirFormulario();
		}

		public void Salvar() {
			if (!this.DadosValidos())
			{
				View.ExibirMensagem(View.MensagemErroValidacaoDados);
				return;
			}

			string camposInvalidos = String.Empty;
            
			bool gravouComSucesso = pedidoOrcamentoService.ResponderPesquisaSatisfacao(ref camposInvalidos, 
				View.Email, 
				View.IdPedidoOrcamento, 
				View.Status, 
				View.OpiniaoComprador, 
				View.PontosMelhoria, 
				View.Gostou,
                View.PesquisaRevisada);

			if (!gravouComSucesso)
			{
				View.ExibirMensagem("Erro na gravação!<br />" + camposInvalidos);
			}
			else
			{
				View.RedirecionarPaginaSucesso();				
			}

		}

	}
}
