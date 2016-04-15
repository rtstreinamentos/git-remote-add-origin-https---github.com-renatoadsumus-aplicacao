using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView
{
    public interface IAdminPedidoOrcamento
    {
        IList<string> Categorias { get; }
        int IdPedidoOrcamento { get; }
        int DiaPedido { get; }
        ClassificacaoPedido ClassificacaoPedido { get; }
        string Email { get; }
        string EmailFornecedorAvulso { get; }
        string NomeFornecedorAvulso { get; }
        string Observacao { get; }
        string Perguntas { get; }
        int IdCidade { get; }        
        string Titulo { get; }
        string FotoPrincipal { get; }
        string ApareceNoSite { get; }
        void CarregarCategoria(IList<Categoria> categorias);
        void CarregarPedidoOrçamento(PedidoOrcamento pedido);

        void CarregarPerguntasCompletarPedido(string perguntas);

        void CarregarUltimosPedidos(IList<PedidoOrcamento> pedidosOrcamento);
    }
}
