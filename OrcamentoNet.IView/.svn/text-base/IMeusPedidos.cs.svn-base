using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IMeusPedidos
    {
        void VisualizarDetalheDoPedido(OrcamentoFornecedor orcamentoFornecedor);        
        string InformacoesAdicionais { get; }
        int IdPedidoOrcamento { get; }
        Fornecedor Fornecedor { get; }
        string PedidoStatusFornecedor { get; }
        string PedidoStatusFornecedorUpdate { get; }

        void CarregarPedidosDeOrcamentoNoStatus(IList<OrcamentoFornecedor> orcamentosFornecedorComStatus);
    }
}
