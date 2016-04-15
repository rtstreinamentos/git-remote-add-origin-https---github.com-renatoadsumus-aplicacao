using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.IView.Presenter
{
    public class DepoimentoOrcamentoOnlineSitePresenter
    {
        public IDepoimentoOrcamentoOnlineSite View { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }


        public void OnViewInitialized()
        {
            InicializarServico();
        }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void CarregarDepoimentos()
        {
            int quantidadePedidos = 10;
            IList<PedidoOrcamento> pedidosQueGostaramDoOrcamento = new List<PedidoOrcamento>();

            //Carrega ultimos depoimentos de um Mes ou de um estado/cidade
            if (View.Mes != 0 || View.IdCidade != 0)
            {
                pedidosQueGostaramDoOrcamento = pedidoOrcamentoService.ObterComComentariosEstadoCidadePorCategoria(quantidadePedidos, View.IdCategoria, View.IdCidade, View.Mes);
            }
            //Carrega ultimos depoimentos da Categoria ou Tema
            else
            {
                pedidosQueGostaramDoOrcamento = pedidoOrcamentoService.ObterComComentarios(quantidadePedidos, View.IdCategoria);
            }

            View.CarregarDepoimentos(pedidosQueGostaramDoOrcamento);
        }
    }
}
