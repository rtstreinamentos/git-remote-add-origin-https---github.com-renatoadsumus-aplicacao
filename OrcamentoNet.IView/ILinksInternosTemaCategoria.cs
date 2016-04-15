using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface ILinksInternosTemaCategoria
    {
        int IdCategoria { get; }
        int IdCidade { get; }
        string TermoPesquisa { get; }
        int IdBairro { get; }
        void MontarArvoreDeLinksInternos(IList<Categoria> categorias);
        void MontarLinksInternosDeEstado(IList<LinkInterno> linksInternosEstadoCidade);
        void MontarLinksInternosMesAno(IList<LinkInterno> linksInternosMesAno);
        void MontarLinksInternosTermo(IList<LinkInterno> linksInternosTermo);
    }
}
