using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class orcamento_online_precoPresenter
    {
        public Iorcamento_online_preco View { get; set; }

        [Inject]
        public ICategoriaService categoriaService
        { get; set; }

        [Inject]
        public ILinkInternoService linkInternoService
        { get; set; }

        [Inject]
        public ICidadeService cidadeService
        { get; set; }

        [Inject]
        public IEstadoService estadoService
        { get; set; }


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

        public void CarregarCategorias()
        {
            IList<Categoria> categorias;

            //Carrega os ultimos pedidos de um Tema ou Categoria
            if (View.IdCategoria > 0)
            {
                categorias = categoriaService.ObterCategoriasDeUmTema(View.IdCategoria);
            }
            else
            {

                categorias = categoriaService.ObterCategoriasAtivas();
            }

            View.CarregarCategoriasPai(categorias);
        }

        public void CarregarPedidos()
        {
            string tituloPedido = "Orçamento Online - Cotação de Preços Grátis";
            string nomeCidade = "";

            if (View.IdPedidoOrcamento > 0)
            {
                PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Obter(View.IdPedidoOrcamento);
                //tituloPedido = "Preço de " + pedidoOrcamento.Titulo + " " + pedidoOrcamento.Categorias[0].Nome + " em " + pedidoOrcamento.Cidade.Nome + "-" + pedidoOrcamento.Cidade.Uf.ToString();
                tituloPedido = "Preço de " + pedidoOrcamento.Categorias[0].Nome + " " + pedidoOrcamento.Titulo + " em " + pedidoOrcamento.Cidade.Nome + "-" + pedidoOrcamento.Cidade.Uf.ToString();
                nomeCidade = " em " + pedidoOrcamento.Cidade.Nome;
                View.CarregarPedido(pedidoOrcamento);               
            }
            else
            {
                IList<PedidoOrcamento> pedidosOrcamentos = new List<PedidoOrcamento>();

                if (View.IdCategoria > 0)
                {
                    Categoria categoria = categoriaService.Obter(View.IdCategoria, false);

                    //Carrega os ultimos pedidos de um Tema ou Categoria
                    CarregaUltimosPedidosDeUmTemaCategoria(categoria);

                    //Carrega os ultimos pedidos de um Tema ou Categoria e de Uma Cidade                    
                    CarregaUltimosPedidosDeUmTemaCategoriaPorCidade(categoria);

                    CarregarUltimosPedidosDeUmaCategoriaUmaCidadePorAnoMes(categoria);
                }
                else
                {
                    pedidosOrcamentos = pedidoOrcamentoService.ObterUltimosPedidosOrcamento(15, "");
                    View.CarregarPedidosOrcamentos(pedidosOrcamentos);
                }
            }

            View.GerarHeaderHTML(tituloPedido, nomeCidade, "");
        }

        private void CarregaUltimosPedidosDeUmTemaCategoria(Categoria categoria)
        {
            if (View.IdCategoria > 0 && View.Ano == 0)
            {
                IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterUltimosPedidosOrcamentoPorCategoriaOuTema(30, View.IdCategoria, "");
                string tituloPedido = "Preço de " + categoria.Nome;
                View.GerarHeaderHTML(tituloPedido, "", "");
                View.CarregarPedidosOrcamentos(pedidosOrcamentos);
            }
        }

        private void CarregaUltimosPedidosDeUmTemaCategoriaPorCidade(Categoria categoria)
        {
            if (View.IdCidade > 0)
            {
                Estado estado = estadoService.ObterEstado(View.IdCidade);
                IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterUltimosPedidosOrcamentoPorCategoriaPorCidadeOuEstado(30, View.IdCategoria, View.IdCidade, "");
                string tituloPedido = "Preço de " + categoria.Nome + " em " + estado.Nome;
                View.GerarHeaderHTML(tituloPedido, estado.Nome, "");
                View.CarregarPedidosOrcamentos(pedidosOrcamentos);
            }
        }

        private void CarregarUltimosPedidosDeUmaCategoriaUmaCidadePorAnoMes(Categoria categoria)
        {
            if (View.IdCategoria > 0 && View.Mes > 0 && View.Ano > 0)
            {
                IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterUltimosPedidosOrcamentoPorCategoriaPorCidadePorAnoMes(30, View.Mes, View.Ano, View.IdCidade, categoria);
                View.CarregarPedidosOrcamentos(pedidosOrcamentos);
                string tituloPedido = "Preço de " + categoria.Nome ;
                View.GerarHeaderHTML(tituloPedido, "", "");
            }

        }
        public void MontarLinksInternos()
        {
            IList<LinkInterno> linksInternosEstadosCidade = new List<LinkInterno>();
            Categoria categoria = categoriaService.Obter(View.IdCategoria, false);
            linksInternosEstadosCidade = linkInternoService.MontarLinksInternosDeEstado(categoria, "orcamento-preco-");
            View.MontarLinksInternosEstadoCidade(linksInternosEstadosCidade);

            IList<LinkInterno> linksInternosAnoMes = new List<LinkInterno>();
            linksInternosAnoMes = linkInternoService.MontarLinksInternosMesAnoPreco(categoria, View.IdCidade, "");
            View.MontarLinksInternosAnoMes(linksInternosAnoMes);
        }

    }
}
