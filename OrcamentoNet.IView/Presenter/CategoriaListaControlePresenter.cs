using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.IView.Presenter
{
    public class CategoriaListaControlePresenter
    {
        public ICategoriaListaControle View { get; set; }

        [Inject]
        public ICategoriaService categoriaService
        { get; set; }

        [Inject]
        public IFornecedorService fornecedorService 
        { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarCategorias()
        {
            IList<Categoria> categorias = new List<Categoria>();

            if (View.CategoriaRecebida == 0)
                categorias = categoriaService.ObterCategoriasAtivas();
            else
                categorias.Add(categoriaService.Obter(View.CategoriaRecebida,false));

            View.CarregarCategorias(categorias);
        }
    }
}
