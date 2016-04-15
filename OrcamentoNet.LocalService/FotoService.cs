using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using PortalEscolar.Data;

namespace OrcamentoNet.LocalService
{
    public class FotoService : IFotoService
    {
        private IDataContext context;

        public FotoService(IDataContext contextData)
        {
            context = contextData;
        }

        public void Inserir(Foto foto)
        {
            context.Insert(foto);
        }       
    }
}
