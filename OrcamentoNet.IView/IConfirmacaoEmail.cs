using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.IView
{
   public interface IConfirmacaoEmail
    {
       string Email { get; }
       int IdPedidoOrcamento { get; }
    }
}
