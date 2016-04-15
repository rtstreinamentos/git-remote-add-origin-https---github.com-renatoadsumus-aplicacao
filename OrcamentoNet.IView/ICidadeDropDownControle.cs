using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface ICidadeDropDownControle
    {
        string Estado { get; }
        int IdCategoria { get; }
        int IdCidade { get; }

        void CarregarEstados(IList<string> estados);

        void CarregarCidades(IList<Cidade> cidades);

        void ExibirMensagem(string mensagem);       
    }
}
