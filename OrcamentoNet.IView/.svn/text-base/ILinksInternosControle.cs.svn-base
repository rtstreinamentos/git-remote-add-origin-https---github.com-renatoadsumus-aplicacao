using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface ILinksInternosControle
    {
        int IdCategoria { get; }
        int IdCidade { get; }
        int IdBairro { get; }       
        void GerarHeaderHTML(Categoria categoria, string nomeEstadoCidade);
        void MontarLinksInternosDeEstado(IList<LinkInterno> linksInternosEstadosCidade);
        void MontarLinksInternosTermo(IList<LinkInterno> linksInternosTermo);

        void MontarLinksInternosDeEstadoParceiros(IList<LinkInterno> linksInternosEstadoParceiros);
    }
}
