using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class Orcamento_Online_Pedido_HistoricoPresenter
    {
        public Iorcamento_online_pedido_historico View { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService
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

        public void CarregarPedidosOrcamentos()
        {

            IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterUltimosPedidosOrcamentoPorCategoriaPorCidadeOuEstado(15, 52, 19, "");

            View.CarregarPedidosOrcamentos(pedidosOrcamentos);
        }
    }
}
