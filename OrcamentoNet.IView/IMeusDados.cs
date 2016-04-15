﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView
{
    public interface IMeusDados
    {
        string WebSite { get; }
        string Nome { get; }
        string Telefone { get; }
        string Descricao { get; }
        string Email { get; }
        int AreaServico { get; }
        IList<string> Fotos { get; }
        double ValorMensalidade { get; }
        void CarregarFornecedor(Fornecedor fornecedor);
        PessoaTipo PessoaTipo { get; }
        void ApresentarValoresPlanos(string plano1, string plano2);
    }
}