using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using InfoGlobo.InjectionFramework.Core;
using System.Collections;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class Orcamento_Online_Mapa_SitePresenter
    {
        public IOrcamento_Online_Mapa_Site View { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }    


        public void OnViewInitialized()
        {
            InicializarServico();
        }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }       

        public void CarregarCategorias()
        {
            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();           

            View.CarregarCategorias(categorias);
        }
    }
}
