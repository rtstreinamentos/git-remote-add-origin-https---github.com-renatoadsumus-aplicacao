using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IOrcamento_Online_Comentarios
    {
        void CarregarComentarios(IList<PedidoOrcamento> pedidosComComentarios);
    }
}
