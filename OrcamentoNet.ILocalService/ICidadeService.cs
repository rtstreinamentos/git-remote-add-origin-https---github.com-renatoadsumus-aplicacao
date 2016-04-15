using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.ILocalService
{
    public interface ICidadeService
    {
        Cidade Obter(int id);
        IList<Cidade> ObterCidades(UF uf);
        IList<Cidade> ObterCidadesComFornecedores(UF uf, Categoria categoria);
        IList<string> ObterEstadosComFornecedorPorCategoria(Categoria categoria);

        IList<Cidade> ObterCidades();
    }
}
