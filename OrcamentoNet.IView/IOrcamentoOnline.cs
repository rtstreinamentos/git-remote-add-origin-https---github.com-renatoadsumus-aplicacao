using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IOrcamentoOnline
    {
        void CarregarCategoria(string nomeCategoria, string nomeCidade,Categoria categoria);
        int IdCategoria { get; }
        int IdCidade { get; }
        int IdBairro { get; }
        int IdServico { get; }
        void HabilitarFormularioVidroEspelho();
        void HabilitarFormularioConstrucao();
        void HabilitarFormularioEventosFestas();        
        void HabilitarFormularioCamerasMonitoradasCFTV();
        void HabilitarFormularioGenerico();
        void HabilitarFormularioMudanca();
        void HabilitarFormularioCasaDecoracao();
        void DesabilitarListaDeCategorias();
        void HabilitarFormularioFachadasPredias();

        void GerarFacebook(string p);
    }
}
