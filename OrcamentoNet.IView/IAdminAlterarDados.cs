using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.IView
{
    public interface IAdminAlterarDados
    {
        string BairroAreaAtuacao { get; } 
        IList<string> Categorias { get; }
        string Descricao { get; }
        string Email { get; }        
        IList<int> CidadesDeAtuacao { get; }
        string WebSite { get; }
        string Nome { get; }
        string Telefone { get; }

        void CarregarCategoria(IList<OrcamentoNet.Entity.Categoria> categorias);
        void LimparTela();
        void CalcularValorMensalidade(double valorMensalidade);

        void CarregarFornecedor(OrcamentoNet.Entity.Fornecedor fornecedor);
    }
}
