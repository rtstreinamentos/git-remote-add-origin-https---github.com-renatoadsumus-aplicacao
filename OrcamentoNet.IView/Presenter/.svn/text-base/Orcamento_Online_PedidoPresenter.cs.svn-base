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
    public class Orcamento_Online_PedidoPresenter
    {
        public IOrcamento_Online_Pedido View { get; set; }

        [Inject]
        public IFornecedorService fornecedorService
        { get; set; }

        [Inject]
        public ICidadeService cidadeService
        { get; set; }

        [Inject]
        public ICategoriaService categoriaService
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

        public void CarregarFornecedoresPorTema()
        {
            Cidade cidade = cidadeService.Obter(View.IdCidadePedidoOrcamento);

            IList<Fornecedor> fornecedoresResultado = new List<Fornecedor>();

            if (View.SubCategorias.Count > 0)
            {
                foreach (int idCategoria in View.SubCategorias)
                {
                    Categoria categoria = categoriaService.Obter(idCategoria, false);

                    IList<Fornecedor> fornecedores = fornecedorService.ObterClientesPorCategoriaCidade(categoria, cidade);

                    foreach (Fornecedor fornecedor in fornecedores)
                    {
                        if (!fornecedoresResultado.Contains(fornecedor))
                        {
                            fornecedoresResultado.Add(fornecedor);
                        }
                    }
                }

                View.GerarHeaderHTML(categoriaService.Obter(View.IdCategoriaRecebida, false), cidade.Nome);
                View.CarregarFornecedoresPorTema(fornecedoresResultado.OrderBy(x => x.Nome).ToList());
            }
        }


        public void CarregarEstado()
        {
            IList<string> estados = new List<string>();

            //if (View.IdCategoriaRecebida != 0)
            //{
            //    Categoria categoria = categoriaService.Obter(View.IdCategoriaRecebida);
            //    estados = cidadeService.ObterEstadosComFornecedorPorCategoria(categoria);
            //}

            estados.Add("Selecione");
            estados.Add("RJ");
            estados.Add("SP");

            View.CarregarEstados(estados);
        }

        public void CarregarCidadesComFornecedor()
        {
            UF uf = ((UF)Enum.Parse(typeof(UF), View.Estado));

            //Categoria categoria = categoriaService.Obter(View.IdCategoriaRecebida,false);

            //IList<Cidade> cidades = cidadeService.ObterCidadesComFornecedoresPorTema(uf, categoria);

            IList<Cidade> cidades = cidadeService.ObterCidades(uf);

            View.CarregarCidades(cidades);
        }

        public void SalvarPedido()
        {
            if (View.IdCidadePedidoOrcamento != 0 && View.PalavraEhCorreta && View.FornecedoresSelecionados.Count > 0)
            {
                Cidade cidadePedidoOrcamento = cidadeService.Obter(View.IdCidadePedidoOrcamento);

                IList<Fornecedor> fornecedores = new List<Fornecedor>();

                foreach (int id in View.FornecedoresSelecionados)
                {
                    fornecedores.Add(fornecedorService.ObterPorId(id));
                }

                IList<Categoria> categorias = ObterCategoriasSelecionadas();

                PedidoOrcamento pedidoOrcamento = new PedidoOrcamento();
                pedidoOrcamento.NomeComprador = View.Nome;
                pedidoOrcamento.Email = View.Email;
                pedidoOrcamento.Cidade = cidadePedidoOrcamento;
                pedidoOrcamento.Telefone = View.Telefone;
                pedidoOrcamento.PretensaoServico = View.IdPretensao;
                pedidoOrcamento.Observacao = View.Observacao;
                pedidoOrcamento.Titulo = View.Titulo;
                //pedidoOrcamento.Fornecedores = fornecedores;
                pedidoOrcamento.Categorias = categorias;

                pedidoOrcamentoService.Inserir(pedidoOrcamento);

                pedidoOrcamentoService.EnviarEmailPedidoOrcamentoSimplificado(pedidoOrcamento);

                View.RedirecionarPaginaSucesso();
            }
        }

        private IList<Categoria> ObterCategoriasSelecionadas()
        {
            IList<Categoria> categorias = new List<Categoria>();

            foreach (int idCategoria in View.SubCategorias)
            {
                Categoria categoria = categoriaService.Obter(idCategoria, false);
                categorias.Add(categoria);
            }
            return categorias;
        }

        public void CarregarCategoriasDoTema()
        {
            Categoria categoria = categoriaService.Obter(52, false);
            View.CarregarCategoriasDoTema(categoria);
        }
    }
}
