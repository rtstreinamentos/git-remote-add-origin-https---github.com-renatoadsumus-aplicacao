using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.IView
{
	public interface IPesquisaSatisfacaoComprador
	{
		string Email { get; }
		int Gostou { get; }
		int IdPedidoOrcamento { get; }
		string MensagemErroPesquisaRespondida { get; }
		string MensagemErroValidacaoDados { get; }
		string OpiniaoComprador { get; }
		string PontosMelhoria { get; }
        bool PesquisaRevisada { get; }
        int Status { get; }

		void ExibirFormulario();
		void ExibirMensagem(string mensagem);
		void RedirecionarPaginaSucesso();
	}
}
