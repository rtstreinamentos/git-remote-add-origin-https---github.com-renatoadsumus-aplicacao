using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class ResultadoPesquisaSatisfcaoPresenter
    {
        public IResultadoPesquisaSatisfcao View { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarOpiniao()
        {
            IList<PedidoOrcamento> pedidos = pedidoOrcamentoService.ObterUltimosComentariosQueGostaram();
            View.CarregarOpiniao(pedidos);
        }
    }
}
