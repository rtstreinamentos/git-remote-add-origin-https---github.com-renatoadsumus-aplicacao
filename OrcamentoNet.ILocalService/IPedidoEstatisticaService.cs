using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.ILocalService
{
    public interface IPedidoEstatisticaService
    {
        void Inserir(PedidoEstatistica pedidoEstatistica);
        IList<PedidoEstatistica> ObterEstatisticaPorCategoriaCidadeMes(int idcategoria, int idMes, int ano);
        void GerarEstatistica();
    }
}
