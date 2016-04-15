using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.ILocalService
{
    public interface IPedidoOrcamentoFornecedorService
    {
        IList<Fornecedor> Obter(IList<int> idFornecedores);
        void AtualizarPorFornecedorEPedido(int idFornecedor, int idPedido, int idInteresse, int idMotivo);
        void Inserir(PedidoOrcamentoFornecedor pedidoOrcamentoFornecedor);
        IList<PedidoOrcamentoFornecedor> ObterPedidosDeFornecedoresQueNaoTiveramInteresse();

        IList<PedidoOrcamentoFornecedor> ObterPorPedido(int idPedidoOrcamento);
    }
}
