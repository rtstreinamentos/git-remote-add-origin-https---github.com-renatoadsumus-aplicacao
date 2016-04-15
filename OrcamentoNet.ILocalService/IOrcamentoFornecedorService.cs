﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.ILocalService
{
    public interface IOrcamentoFornecedorService
    {
        void Salvar(OrcamentoFornecedor orcamentoFornecedor);
        OrcamentoFornecedor Obter(int idPedidoOrcamento);
        IList<OrcamentoFornecedor> ObterFornecedoresDoPedido(int idPedidoOrcamento);
        IList<OrcamentoFornecedor> Obter(PedidoStatusFornecedor pedidoStatusFornecedor, int idFornecedor);
    }
}
