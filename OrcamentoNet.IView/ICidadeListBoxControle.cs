using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface ICidadeListBoxControle
    {
        string Estado { get; }        
        void CarregarEstados(IList<string> estados);
        void CarregarCidades(IList<Cidade> cidades);        
    }
}
