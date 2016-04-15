using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IPedidosOrcamentoControle
    {
        int QuantidadePedidos { get;}
        int Mes { get; }
        int IdCategoria { get; }
        int IdTipoOrcamento { get; }
        int IdCidade { get; }
        int IdBairro { get; }
        string TermoPesquisa { get; }
        void CarregarPedidosOrcamentos(IList<PedidoOrcamento> pedidosOrcamentos);
        void CarregarPedidosOrcamentoComFoto(IList<PedidoOrcamento> pedidosOrcamentosComFoto);
    }
}
