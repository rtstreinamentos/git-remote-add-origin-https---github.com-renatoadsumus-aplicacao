using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.LocalServiceTest
{
    public class BasePedidoOrcamento
    {
        private IPedidoOrcamentoService pedidoOrcamentoService;

        public BasePedidoOrcamento(IPedidoOrcamentoService pedidoOrcamentoService)
        {
            this.pedidoOrcamentoService = pedidoOrcamentoService;
        }

        public PedidoOrcamento IncluirPedidoOrcamentoValido(Categoria categoria, Cidade cidade)
        {
            string camposInvalidos = String.Empty;           

            IList<Categoria> categorias = new List<Categoria>();
            categorias.Add(categoria);

            PedidoOrcamento pedidoOrcamento = new PedidoOrcamento();
            pedidoOrcamento.NomeComprador= "novo comprador - " + cidade.Uf;
            pedidoOrcamento.Email = "renatoadsumus@gmail.com";
            pedidoOrcamento.Telefone = "21-226776912";
            pedidoOrcamento.Categorias =categorias;
            pedidoOrcamento.Observacao="Solicito um orcamento para o Rio";
            pedidoOrcamento.Titulo="Titulo Novo Pedido";
            pedidoOrcamento.PretensaoServico = 10;
            pedidoOrcamento.Cidade = cidade;

            pedidoOrcamento = pedidoOrcamentoService.Inserir(ref camposInvalidos, pedidoOrcamento);

            return pedidoOrcamento;
        }

        public PedidoOrcamento IncluirPedidoOrcamentoValidoComFornecedoresSelecionados(Categoria categoria, Cidade cidade, Fornecedor fornecedor)
        {         

            IList<Categoria> categorias = new List<Categoria>();
            categorias.Add(categoria);

            IList<Fornecedor> fornecedores = new List<Fornecedor>();
            fornecedores.Add(fornecedor);

            PedidoOrcamento pedidoOrcamento = new PedidoOrcamento();
            pedidoOrcamento.NomeComprador = "novo comprador";
            pedidoOrcamento.Email = "renatoadsumus@gmail.com";
            pedidoOrcamento.Telefone = "21-226776912";
            pedidoOrcamento.Categorias = categorias;
            pedidoOrcamento.Cidade = cidade;
            pedidoOrcamento.Fornecedores = fornecedores;
            pedidoOrcamento.Titulo = "Novo Pedido Orcamento Teste";
            pedidoOrcamento.Observacao = "Teste conteudo novo pedido de orçamento";

            return pedidoOrcamentoService.Inserir(pedidoOrcamento); ;
        }
    }
}
