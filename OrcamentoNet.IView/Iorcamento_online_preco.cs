using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface Iorcamento_online_preco
    {
        int IdPedidoOrcamento { get; }
        int IdCategoria { get; }
        int IdCidade { get; }
        int Ano { get; }
        int Mes { get; }
        void CarregarPedidosOrcamentos(IList<PedidoOrcamento> pedidosOrcamentos);
        void CarregarCategoriasPai(IList<Categoria> categorias);
        void GerarHeaderHTML(string tituloPedido, string nomeCidade, string h3LinkInterno);
        void CarregarPedido(PedidoOrcamento pedidoOrcamento);
        void MontarLinksInternosEstadoCidade(IList<LinkInterno> linksInternosEstadosCidade);
        void MontarLinksInternosAnoMes(IList<LinkInterno> linksInternosAnoMes);
    }
}
