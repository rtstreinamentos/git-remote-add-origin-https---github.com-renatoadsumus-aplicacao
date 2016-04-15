using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IFornecedorPorCategoriaControle
    {
        int IdCategoria { get; }
        int IdCidade { get; }
        void CarregarFornecedores(IList<Fornecedor> fornecedores);

        void CarregarCategoria(Categoria categoria, string nomeEstado);

        void MontarLinksInternosEstadoCidade(IList<LinkInterno> linksInternosEstadosCidade);
    }
}
