using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView
{
    public interface IPedidosNaoRespondidos
    {
        Fornecedor Fornecedor { get; }
        PedidoCompradorStatus PedidoCompradorStatus { get; }
        void CarregarPedidosOrcamentos(IList<PedidoOrcamento> pedidosOrcamentos, Fornecedor fornecedor, string fraseFornecedor);
    }
}
