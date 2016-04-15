using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalEscolar.Data;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.LocalService
{
    public class OrcamentoFornecedorService : IOrcamentoFornecedorService
    {
        private IDataContext context;

        public OrcamentoFornecedorService(IDataContext contextData)
        {
            context = contextData;
        }

        public OrcamentoFornecedor Obter(int idPedidoOrcamento)
        {
            OrcamentoFornecedor orcamentoFornecedor = context.Repository<OrcamentoFornecedor>().Where(x => x.PedidoOrcamento.Id == idPedidoOrcamento).FirstOrDefault();

            return orcamentoFornecedor;
        }

        public void Salvar(OrcamentoFornecedor orcamentoFornecedor)
        {
            context.Insert(orcamentoFornecedor);
            context.Commit();
        }

        public IList<OrcamentoFornecedor> Obter(PedidoStatusFornecedor pedidoStatusFornecedor, int idFornecedor)
        {
            return context.Repository<OrcamentoFornecedor>().Where(x => x.PedidoStatusFornecedor == pedidoStatusFornecedor && x.Fornecedor.Id == idFornecedor).ToList();
        }

        public IList<OrcamentoFornecedor> ObterFornecedoresDoPedido(int idPedidoOrcamento)
        {
           
            return context.Repository<OrcamentoFornecedor>().Where(x => x.PedidoOrcamento.Id == idPedidoOrcamento ).ToList();
        }



    }
}
