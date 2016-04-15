using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.IView
{
    public interface IOrcamento_Online_Notificacao_Pagamento
    {
        int IdPedidoOrcamento { get; }
        string EmailComprador{ get; }
        string NomeComprador { get; }
    }
}
