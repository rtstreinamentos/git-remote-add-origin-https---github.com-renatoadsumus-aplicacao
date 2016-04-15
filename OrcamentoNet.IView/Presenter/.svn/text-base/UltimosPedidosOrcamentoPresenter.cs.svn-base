using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Common;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class UltimosPedidosOrcamentoPresenter
    {
        public IUltimosPedidosOrcamento View { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

        [Inject]
        public IOrcamentoFornecedorService orcamentoFornecedorService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarUltimosPedidos()
        {
            Fornecedor fornecedor = View.Fornecedor;
            DateTime dataInicio = DateTime.Now.AddDays(-15);
            DateTime dataFim = DateTime.Now;
            IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorIntervaloDeData(dataInicio, dataFim);
            List<PedidoOrcamento> pedidosOrcamentoResultado = new List<PedidoOrcamento>();
            List<PedidoOrcamento> pedidosOrcamentoCidades = new List<PedidoOrcamento>();

            foreach (Cidade cidade in fornecedor.Cidades)
            {
                pedidosOrcamentoCidades.AddRange(pedidosOrcamento.Where(x => x.Cidade.Id == cidade.Id).ToList());
            }

            foreach (PedidoOrcamento pedidoOrcamento in pedidosOrcamentoCidades)
            {
                foreach (Categoria categoriaPedido in pedidoOrcamento.Categorias)
                {
                    foreach (Categoria categoriaFornecedor in fornecedor.SubCategorias)
                    {
                        if (categoriaPedido.Id == categoriaFornecedor.Id && !pedidosOrcamentoResultado.Contains(pedidoOrcamento))
                            pedidosOrcamentoResultado.Add(pedidoOrcamento);
                    }
                }
            }




            //foreach (Categoria categoriaFornecedor in fornecedor.SubCategorias)
            //{
            //    foreach (PedidoOrcamento pedidoOrcamento in pedidosOrcamentoCidades)
            //    {
            //        foreach (Categoria categoriaPedido in pedidoOrcamento.Categorias)
            //        {
            //            if (categoriaPedido.Id == categoriaFornecedor.Id && !pedidosOrcamentoResultado.Contains(pedidoOrcamento))
            //                pedidosOrcamentoResultado.Add(pedidoOrcamento);
            //        }
            //    }
            //}

            View.CarregarPedidosOrcamento(pedidosOrcamentoResultado.OrderByDescending(x => x.Data).ToList(), fornecedor);
            View.CarregarCidades(fornecedor.Cidades);
        }

        public void CarregarBoxCompraAvulsa()
        {
            Fornecedor fornecedor = View.Fornecedor;

            if (fornecedor != null)
                View.CarregarBoxCompraAvulsa(fornecedor);
        }

        public void CarregarPedidosOutrasAreas()
        {
            Fornecedor fornecedor = View.Fornecedor;

            if (View.IdCidade != 0)
            {
                IList<PedidoOrcamento> pedidosOutrasAreas = pedidoOrcamentoService.ObterPedidosPorCategoriaCidade(DateTime.Now.Month, fornecedor.SubCategorias, View.IdCidade);

                View.CarregarPedidosOrcamento(pedidosOutrasAreas, View.Fornecedor);
            }
        }

        public void Salvar()
        {
            OrcamentoFornecedor orcamentoFornecedor;

            orcamentoFornecedor = orcamentoFornecedorService.Obter(View.IdPedidoOrcamento);

            if (orcamentoFornecedor == null && View.Fornecedor != null)
            {

                DateTime dataAlteracao = DateTime.Now;

                PedidoStatusFornecedor pedidoStatusFornecedor = ((PedidoStatusFornecedor)Enum.Parse(typeof(PedidoStatusFornecedor), "NaoEnviado"));
                PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Obter(View.IdPedidoOrcamento);

                orcamentoFornecedor = new OrcamentoFornecedor();
                orcamentoFornecedor.DataAltercao = dataAlteracao;
                orcamentoFornecedor.Fornecedor = View.Fornecedor;
                orcamentoFornecedor.PedidoOrcamento = pedidoOrcamento;
                orcamentoFornecedor.PedidoStatusFornecedor = PedidoStatusFornecedor.NaoEnviado;

                orcamentoFornecedorService.Salvar(orcamentoFornecedor);
            }
        }
    }
}
