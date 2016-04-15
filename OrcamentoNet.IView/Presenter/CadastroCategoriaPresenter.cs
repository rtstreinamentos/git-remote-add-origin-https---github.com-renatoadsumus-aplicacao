using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class CadastroCategoriaPresenter
    {
        public ICadastroCategoria View { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarCategoria()
        {
            Categoria categoria = categoriaService.Obter(View.IdCategoria,false);
            View.CarregarCategoria(categoria);
        }

        public void Salvar()
        {
            Categoria categoria = categoriaService.Obter(View.IdCategoria,false);

            if (categoria == null || categoria.Id == 0)
            {
                categoria = new Categoria();
            }

            categoria.UrlTitle = View.UrlTitle;   
            categoria.Nome = View.Nome;
            categoria.UrlMappings = View.UrlMappings;
            categoria.DetalheExplicativo = View.DetalheExplicativo;
            categoria.Termo = View.Termo;

            if (categoria.Id == 0)
            {
                Categoria categoriaPai = categoriaService.Obter(198,false);
                categoria.Pai = categoriaPai;
                categoriaService.Inserir(categoria);
            }
        }
    }
}
