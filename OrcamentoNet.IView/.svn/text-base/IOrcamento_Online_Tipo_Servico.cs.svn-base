using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IOrcamento_Online_Tipo_Servico    {

        void HabilitarFormularioConstrucao();
        void HabilitarFormularioEventosFestas(); 
        int IdCidadeRecebida { get; }
        int IdTipoServicoOrcamento { get; }
        int IdBairroRecebido { get; }
        int IdCategoriaRecebida { get; }
        string TermoRecebido { get; }
        void GerarHeaderHTML(string tipoServico, string nomeCidade, string h3LinkInterno);
        void MontarLinksInternosDeEstado(IList<LinkInterno> linksInternosEstadosCidade);
        void MontarLinksInternosTermo(IList<LinkInterno> linksInternosTermo);

        void MontarLinksInternosTipoServico(IList<LinkInterno> linksInternosTipoServico);

    }
}
