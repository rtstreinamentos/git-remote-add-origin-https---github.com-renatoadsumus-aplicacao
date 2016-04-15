using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using System.Net.Mail;

namespace OrcamentoNet.IView
{
    public interface IConsultaPedidoOrcamento
    {
        int IdComprador { get; }
        int IdPedidoOrcamento { get; }
        double Valor { get; }
        string Observacao { get; }
        DateTime ValidadeOrcamento { get; }
        Attachment AnexoOrcamento { get; }


        void ExibirMensagem(string mensagem);
        void CarregarPedidoOrcamento(PedidoOrcamento pedidoOrcamento);
        void CarregarPedidosOrcamento(IList<PedidoOrcamento> pedidosOrcamento);
        void HabilitarLinkCredito();
        void LimparTela();
        void LimparTelaEnviarOrcamento();
    }
}
