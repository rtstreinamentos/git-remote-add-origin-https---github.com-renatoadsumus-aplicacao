using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortalEscolar.Data;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.LocalService
{
    public class MensalidadeService : IMensalidadeService
    {
        private IDataContext context;

        public MensalidadeService(IDataContext contextData)
        {
            context = contextData;
        }

        public void Inserir(Mensalidade mensalidade)
        {
            context.Insert(mensalidade);
        }
    }
}
