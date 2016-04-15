using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IEstatisticaPedidos
    {
        int IdCategoria { get; }
        int Mes { get; }

        void GerarHeaderHTML(Categoria categoria, string totalPedidos);

        void CarregarCategorias(IList<Categoria> categorias);

        void CarregarEstados(IList<string> estados);

        void CarregarEstatisticaPorCategoria(IList<PedidoEstatistica> estatisticasDeUmaCategoria);
    }
}
