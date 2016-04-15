using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.IView
{
    public interface IOrcamento_Online_Temas
    {
		string Ano { get; }
		int IdCategoria { get; }
        int IdCidade { get; }
        int IdBairro { get; }
		string Mes { get; }
		string NomeCategoria { get; }
		string NomeEstado { get; }
		string UrlSolicitarOrcamento { get; set; }
        void GerarHeaderHTML(string nomeCategoria, string nomeCidade);
    }
}
