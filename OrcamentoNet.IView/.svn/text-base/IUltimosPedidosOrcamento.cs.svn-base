using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IUltimosPedidosOrcamento
    {
        int IdCidade { get; }

        Fornecedor Fornecedor { get; }
        
        int IdPedidoOrcamento { get; }

        void CarregarPedidosOrcamento(IList<PedidoOrcamento> pedidosOrcamentoResultado, Fornecedor fornecedor);

        void CarregarBoxCompraAvulsa(Fornecedor fornecedor);

        void CarregarCidades(IList<Cidade> cidades);        
    }
}
