using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using PortalEscolar.Data;
using OrcamentoNet.Entity;

namespace OrcamentoNet.LocalService
{
    public class FornecedorAtributoService : IFornecedorAtributoService
    {

        private IDataContext context;

        public FornecedorAtributoService(IDataContext contextData)
        {
            context = contextData;
        }

        public void Salvar(FornecedorAtributo fornecedorAtributo)
        {

            FornecedorAtributo fornecedorAtributoResultado = context.Repository<FornecedorAtributo>()
                .Where(x => x.Fornecedor == fornecedorAtributo.Fornecedor).FirstOrDefault();

            if (fornecedorAtributoResultado == null)
                context.Insert(fornecedorAtributo);
            else
            {
                fornecedorAtributoResultado.Condicao = fornecedorAtributo.Condicao;
                context.Commit();

            }
        }
    }
}
