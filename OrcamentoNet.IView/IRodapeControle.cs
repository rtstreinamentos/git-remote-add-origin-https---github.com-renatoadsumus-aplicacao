using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.IView
{
    public interface IRodapeControle
    {
        void CarregarInformacoesRodape(string categoria, 
            string urlVoceConhece, 
            string nomeExibicaoVoceConhece,
            string toolTipVoceConhece,
            string urlHistorico,
            string nomeExibicaoHistorico,
            string toolTipHistorico);
        Int32 IdCategoria { get; }
    }
}
