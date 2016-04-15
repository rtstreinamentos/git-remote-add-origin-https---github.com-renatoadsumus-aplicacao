using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IOrcamento_Online_Pedido
    {
        string Email { get; }
        int IdPretensao { get; }
        string Estado { get; }
        int IdCidadePedidoOrcamento { get; }
        int IdCategoriaRecebida { get; }
        IList<int> FornecedoresSelecionados { get; }
        string Nome { get; }
        bool PalavraEhCorreta { get; }
        string Observacao { get; }
        string Titulo { get; }
        string Telefone { get; }
        IList<int> SubCategorias { get; }      

        void CarregarFornecedoresPorTema(IList<Fornecedor> fornecedores);
        void CarregarEstados(IList<string> estados);
        void CarregarCidades(IList<Cidade> cidades);
        void GerarHeaderHTML(Categoria categoria, string nomeCidade);
        void CarregarCategoriasDoTema(Categoria categoria);

        void RedirecionarPaginaSucesso();

    }
}
