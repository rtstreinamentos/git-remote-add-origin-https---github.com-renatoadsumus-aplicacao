using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class PesquisaPerfilFornecedorPresenter
    {
        public IPesquisaPerfilFornecedor View { get; set; }

        [Inject]
        public IPedidoOrcamentoFornecedorService pedidoOrcamentoFornecedorService { get; set; }

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

        public void AtualizarInteresseNoPedido()
        {
            if (View.IdInteresse == 1 || View.IdInteresse == 2)
                pedidoOrcamentoFornecedorService.AtualizarPorFornecedorEPedido(View.IdFornecedor, View.IdPedido, View.IdInteresse, View.IdMotivo);
        }
    }
}
