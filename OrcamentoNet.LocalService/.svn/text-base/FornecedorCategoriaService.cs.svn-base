using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalEscolar.Data;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.LocalService
{
    public class FornecedorCategoriaService : IFornecedorCategoriaService
    {
        private IDataContext context;

        public FornecedorCategoriaService(IDataContext contextData)
        {
            context = contextData;
        }

        public void Inserir(CategoriaPrioridade categoriaPrioridade)
        {
            context.Insert(categoriaPrioridade);
        }

        public IList<CategoriaPrioridade> Obter(int idFornecedor)
        {
            return  context.Repository<CategoriaPrioridade>().Where(x => x.Fornecedor.Id == idFornecedor).ToList();
        }

        public IList<CategoriaPrioridade> ObterPorEmail(string  emailFornecedor)
        {
            return context.Repository<CategoriaPrioridade>().Where(x => x.Fornecedor.Email == emailFornecedor).ToList();
        }

        public void Excluir(int idFornecedor)
        {
            IList<CategoriaPrioridade> lista = Obter(idFornecedor);
            
            foreach (CategoriaPrioridade item in lista)
            {
                context.Delete(item);
            }
        }
    }
}
