using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.IView.Presenter
{
    public class EstatisticaPedidosPresenter
    {
        public IEstatisticaPedidos View { get; set; }

        [Inject]
        public IPedidoEstatisticaService pedidoEstatisticaService { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IEstadoService estadoService { get; set; }


        public void OnViewInitialized()
        {
            InicializarServico();
        }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }


        public class PedidoEstado
        {
            public string Cidade { get; set; }
            public IList<PedidoEstatistica> Pedidos { get; set; }

        }

        public void CarregarCategorias()
        {
            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();

            View.CarregarCategorias(categorias);
        }

        public void CarregarEstatisticaPorCategoria()
        {
            IList<PedidoEstatistica> estatisticasDeUmaCategoria = pedidoEstatisticaService.ObterEstatisticaPorCategoriaCidadeMes(View.IdCategoria, 3, 2014);

            if (estatisticasDeUmaCategoria.Count > 0)
            {
                View.CarregarEstatisticaPorCategoria(estatisticasDeUmaCategoria);

                string totalPedidos = estatisticasDeUmaCategoria.Sum(x => x.QuantidadePedidos).ToString();

                View.GerarHeaderHTML(estatisticasDeUmaCategoria[0].Categoria, totalPedidos);
            }
        }

        public void CarregarEstados()
        {
            IList<string> estados = new List<string>();         

            foreach (string estado in Enum.GetNames(typeof(UF)))
            {
                UF uf = (UF)Enum.Parse(typeof(UF), estado);
                estados.Add(estado);
            }

            View.CarregarEstados(estados);
        }
    }
}
