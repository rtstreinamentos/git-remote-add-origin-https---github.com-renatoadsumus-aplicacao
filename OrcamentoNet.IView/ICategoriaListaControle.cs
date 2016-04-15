using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface ICategoriaListaControle
    {
        void CarregarCategorias(IList<Categoria> categorias);
        int CategoriaRecebida { get; }       
    }
}
