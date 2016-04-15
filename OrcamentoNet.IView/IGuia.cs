using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.IView
{
    public interface IGuia
    {
        int IdCategoria { get; }

        void CarregarCategorias(IList<OrcamentoNet.Entity.Categoria> categorias);
    }
}
