using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IGuiaTemas
    {
        int IdCategoria { get; }
        int IdCidade { get; }

        void GerarHeaderHTML(string categoria, string URLDaCategoria, string nomeCidade);

        void CarregarCidadesDoEstado(List<Estado> estados);

        void MontarArvoreDeLinksInternos(IList<Categoria> categorias);

        void MontarLinksInternosTermo(IList<LinkInterno> linksInternosTermo);

        void CarregarFornecedores(IList<Fornecedor> fornecedores);
    }
}
