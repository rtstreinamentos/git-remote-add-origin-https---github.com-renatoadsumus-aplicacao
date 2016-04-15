using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class CategoriasTemaCheckBoxControlePresenter
    {
        public ICategoriasTemaCheckBoxControle View { get; set; }

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

        public void CarregarCategoriasDoTema()
        {
            if (View.IdCategoria > 0)
            {
                Categoria categoriaSelecionada = categoriaService.Obter(View.IdCategoria,false);

                Categoria categoriaPai;

                if (categoriaSelecionada.Pai.Id != 0)
                    categoriaPai = categoriaService.Obter(categoriaSelecionada.Pai.Id,false);
                else
                    categoriaPai = categoriaSelecionada;

                View.CarregarCategoriasDoTema(categoriaPai);
            }
        }
    }
}
