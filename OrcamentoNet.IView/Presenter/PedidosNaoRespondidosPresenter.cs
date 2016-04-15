using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class PedidosNaoRespondidosPresenter
    {
        public IPedidosNaoRespondidos View { get; set; }


        [Inject]
        public IFornecedorService fornecedorService { get; set; }

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

        public void CarregarPedidosOrcamentos()
        {
            string fraseParaFornecedor = "";

            if (View.PedidoCompradorStatus == PedidoCompradorStatus.NaoRecebiOrcamento)
            {
                fraseParaFornecedor = "É uma ótima oportunidade para você procurar o cliente e participar da cotação!!!";
            }

            if (View.PedidoCompradorStatus == PedidoCompradorStatus.Analisando)
            {
                fraseParaFornecedor = "É uma ótima oportunidade para você fazer um novo contato e acompanhar a cotação!!!";
            }

            IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterUltimosPesquisaRespondidaPedidosDasCidadesDoFornecedor(20, View.Fornecedor.SubCategorias[0], View.Fornecedor, View.PedidoCompradorStatus);
            View.CarregarPedidosOrcamentos(pedidosOrcamentos , View.Fornecedor, fraseParaFornecedor);
        }
    }
}
