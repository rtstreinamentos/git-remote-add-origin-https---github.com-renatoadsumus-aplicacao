using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.ILocalService
{
    public interface ICompraAvulsaService
    {
        void Inserir(CompraAvulsa compraAvulsa);
        IList<CompraAvulsa> ObterPorData(DateTime dataCompra);
        IList<CompraAvulsa> ObterPorId(int idFornecedor);
    }
}
