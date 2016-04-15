using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.IView.Presenter
{
    public class CategoriasControlePresenter
    {
        public ICategoriasControle View { get; set; }

        [Inject]
        public ICategoriaService categoriaService
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
            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();

            View.CarregarCategorias(categorias);
        }
        
    }
}
