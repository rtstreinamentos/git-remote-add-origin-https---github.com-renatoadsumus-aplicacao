using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IOrcamento_Online_Mapa_Site
    {      
        void CarregarCategorias(IList<Categoria> categorias);
    }
}
