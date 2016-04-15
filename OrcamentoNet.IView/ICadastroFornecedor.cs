using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface ICadastroFornecedor
    {
        IList<string> Categorias { get; }
        IList<CategoriaPrioridade> CategoriasPrioridades { get; }
        IList<int> CidadesDeAtuacao { get; }  
        string Descricao { get; }
        int DiasUltimosPedidos { get; }
        string Email { get; }      
        double ValorMensalidade { get; }
        string WebSite { get; }
        string Nome { get; }
        string Status { get; }
        string Telefone { get; }
        int IdFornecedor { get; }
        DateTime DataVencimento { get; }

        void CarregarFornecedor(Fornecedor fornecedor);

        void CarregarCategoria(IList<Categoria> categorias);

        void CarregarFornecedoresNovos(IList<Fornecedor> fornecedoresNovos);
    }
}
