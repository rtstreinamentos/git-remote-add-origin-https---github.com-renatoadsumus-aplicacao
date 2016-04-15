using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using PortalEscolar.Data;

namespace OrcamentoNet.LocalService
{
    public class OpiniaoService : IOpiniaoService
    {
        private IDataContext context;

        public OpiniaoService(IDataContext contextData)
        {
            context = contextData;
        }

        public void Inserir(Opiniao opiniao)
        {
            opiniao.DataCadastro = DateTime.Now;
            opiniao.Status = 0;

            context.Insert(opiniao);
        }

        public IList<Opiniao> ObterPorFornecedor(int idFornecedor)
        {
            return context.Repository<Opiniao>().Where(x => x.Fornecedor.Id == idFornecedor && x.Status == 1).ToList();
        }

        public Opiniao Obter(int idOpiniao)
        {
            return context.Repository<Opiniao>().Where(x => x.Id == idOpiniao).FirstOrDefault();
        }
    }
}
