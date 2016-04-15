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
    public class CriarPedidoPresenter
    {
        public ICriarPedido View { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService
        { get; set; }

        [Inject]
        public IOrcamentoFornecedorService orcamentoFornecedorService { get; set; }

        [Inject]
        public ICidadeService cidadeService
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

        public void Salvar()
        {
            Cidade cidadePedidoOrcamento = cidadeService.Obter(View.IdCidadePedidoOrcamento);           

            PedidoOrcamento pedidoOrcamento = new PedidoOrcamento();
            pedidoOrcamento.NomeComprador = View.Nome;
            pedidoOrcamento.Email = View.Email;
            pedidoOrcamento.Telefone = View.Telefone;
            pedidoOrcamento.Titulo = View.Titulo;
            pedidoOrcamento.Cidade = cidadePedidoOrcamento;
            pedidoOrcamento.TelefoneOperadora = View.TelefoneOperadora;
            pedidoOrcamento.Observacao = View.Observacao;

            pedidoOrcamento = pedidoOrcamentoService.InserirPedido(pedidoOrcamento);

            if (pedidoOrcamento.Id > 0)
            {
                OrcamentoFornecedor orcamentoFornecedor;

                DateTime dataAlteracao = DateTime.Now;

                PedidoStatusFornecedor pedidoStatusFornecedor = ((PedidoStatusFornecedor)Enum.Parse(typeof(PedidoStatusFornecedor), "NaoEnviado"));
                
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
