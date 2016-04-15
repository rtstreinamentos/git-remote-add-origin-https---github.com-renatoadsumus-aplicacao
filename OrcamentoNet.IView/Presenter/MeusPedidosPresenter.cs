using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class MeusPedidosPresenter
    {
        public IMeusPedidos View { get; set; }

        [Inject]
        public IOrcamentoFornecedorService orcamentoFornecedorService { get; set; }

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

        public void Salvar()
        {
            string informacoesAdicionais = View.InformacoesAdicionais;
            DateTime dataAlteracao = DateTime.Now;

            PedidoStatusFornecedor pedidoStatusFornecedor = ((PedidoStatusFornecedor)Enum.Parse(typeof(PedidoStatusFornecedor), View.PedidoStatusFornecedorUpdate));

            OrcamentoFornecedor orcamentoFornecedor = orcamentoFornecedorService.Obter(View.IdPedidoOrcamento);
            orcamentoFornecedor.DataAltercao = dataAlteracao;
            orcamentoFornecedor.PedidoStatusFornecedor = pedidoStatusFornecedor;
            orcamentoFornecedor.InformacoesAdicionais = informacoesAdicionais;
        }

        public void CarregarPedidosDeOrcamentoNoStatus()
        {
            string statusPedido = View.PedidoStatusFornecedor;

            if (statusPedido != "Selecione")
            {
                PedidoStatusFornecedor pedidoStatusFornecedor = ((PedidoStatusFornecedor)Enum.Parse(typeof(PedidoStatusFornecedor), statusPedido));

                IList<OrcamentoFornecedor> orcamentosFornecedorComStatus = orcamentoFornecedorService.Obter(pedidoStatusFornecedor, View.Fornecedor.Id);

                View.CarregarPedidosDeOrcamentoNoStatus(orcamentosFornecedorComStatus);
            }
        }

        public void CarregarPedidoOrcamento()
        {
            OrcamentoFornecedor orcamentoFornecedor = orcamentoFornecedorService.Obter(View.IdPedidoOrcamento);

            if (orcamentoFornecedor != null)
            {
                View.VisualizarDetalheDoPedido(orcamentoFornecedor);
            }
        }
    }
}
