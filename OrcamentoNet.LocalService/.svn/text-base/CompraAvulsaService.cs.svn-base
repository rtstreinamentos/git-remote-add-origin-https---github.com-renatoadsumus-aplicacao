using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using PortalEscolar.Data;

namespace OrcamentoNet.LocalService
{
    public class CompraAvulsaService : ICompraAvulsaService
    {
        private IDataContext context;

        public CompraAvulsaService(IDataContext contextData)
        {
            context = contextData;
        }
        
        public void Inserir(CompraAvulsa compraAvulsa)
        {
            context.Insert(compraAvulsa);
        }

        public IList<CompraAvulsa> ObterPorData(DateTime dataCompra)
        {
            return context.Repository<CompraAvulsa>().Where(x => x.Data == dataCompra).ToList();
        }

        public IList<CompraAvulsa> ObterPorId(int idFornecedor)
        {
            return context.Repository<CompraAvulsa>().Where(x => x.Id == idFornecedor).ToList();
        }
    }
}
