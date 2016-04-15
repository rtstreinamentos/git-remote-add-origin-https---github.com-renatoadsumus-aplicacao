using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.IView
{
    public interface IOrcamento_Online_Opiniao
    {
        string Opiniao { get; }
        int IdStatusPedido { get; }
        string Email { get; }

        void ExibirMensagemSucesso();
    }
}
