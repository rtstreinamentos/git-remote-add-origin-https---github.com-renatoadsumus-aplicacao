using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class orcamento_online_termoPresenter
    {
        public Iorcamento_online_termo View { get; set; }

        [Inject]
        public ICategoriaService categoriaService
        { get; set; }

        [Inject]
        public ILinkInternoService linkInternoService { get; set; }


        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }


        public void CarregarTermos()
        {
            Categoria categoria = categoriaService.Obter(27, true);
            categoria.LinksInternos = linkInternoService.MontarLinksInternosTermosDaCategoria(categoria, 0, null, null);
            View.CarregarTermos(categoria);
        }
    }
}
