using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class Orcamento_Online_OpiniaoPresenter
    {
        public IOrcamento_Online_Opiniao View { get; set; }

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

        public void SalvarOpiniao()
        {
            PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.ObterPedidoOrcamentoPorEmail(View.Email);

            if (pedidoOrcamento != null)
            {
                pedidoOrcamento.DataAlteracao = DateTime.Now;

                string statusComprador = Enum.GetName(typeof(PedidoCompradorStatus), View.IdStatusPedido);

                pedidoOrcamento.StatusPedidoComprador = (PedidoCompradorStatus)Enum.Parse(typeof(PedidoCompradorStatus), statusComprador);

                pedidoOrcamento.OpiniaoComprador = View.Opiniao;
            }

            View.ExibirMensagemSucesso();

        }
    }
}
