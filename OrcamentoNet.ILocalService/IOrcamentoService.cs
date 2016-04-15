using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.ILocalService
{
    public interface IOrcamentoService
    {
        Orcamento Obter(int idOrcamento);
        IList<Orcamento> Obter();
        IList<Orcamento> ObterPorTipo(TipoServico tipoServico);
    }
}
