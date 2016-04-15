using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using PortalEscolar.Data;

namespace OrcamentoNet.LocalService
{
    public class PedidoOrcamentoFornecedorService : IPedidoOrcamentoFornecedorService
    {
        private IDataContext context;

        public PedidoOrcamentoFornecedorService(IDataContext contextData)
        {
            context = contextData;
        }

        public IList<Fornecedor> Obter(IList<int> idFornecedores)
        {

            IList<PedidoOrcamentoFornecedor> fornecedores = context.Repository<PedidoOrcamentoFornecedor>().ToList();


            var fornecedoresResult = from f in fornecedores.AsQueryable<PedidoOrcamentoFornecedor>()
                                     where idFornecedores.Any(x => f.Fornecedor.Id.Equals(x))
                                     select f.Fornecedor;

            var fornecedoresOrdenados = fornecedoresResult.GroupBy(i => i)
                           .Select(i => new { Fornecedor = i.Key, Count = i.Count() })
                           .OrderBy(i => i.Count);

            IList<Fornecedor> fornecedoresResultado = new List<Fornecedor>();

            foreach (var item in fornecedoresOrdenados)
            {
                fornecedoresResultado.Add(item.Fornecedor);
            }

            return fornecedoresResultado;
        }

        public void Inserir(PedidoOrcamentoFornecedor pedidoOrcamentoFornecedor)
        {
            pedidoOrcamentoFornecedor.IdInteresse = 0;
            pedidoOrcamentoFornecedor.Data = DateTime.Now;
            context.Insert(pedidoOrcamentoFornecedor);
            context.Commit();
        }

        public void AtualizarPorFornecedorEPedido(int idFornecedor, int idPedido, int idInteresse, int idMotivo)
        {
            PedidoOrcamentoFornecedor pedidoOrcamentoFornecedor = context.Repository<PedidoOrcamentoFornecedor>().
                                                                  Where(x => x.Fornecedor.Id == idFornecedor && x.PedidoOrcamento.Id == idPedido).FirstOrDefault();

            if (pedidoOrcamentoFornecedor != null)
            {
                pedidoOrcamentoFornecedor.IdInteresse = idInteresse;
                pedidoOrcamentoFornecedor.IdMotivo = idMotivo;
                pedidoOrcamentoFornecedor.Data = DateTime.Now;
                context.Commit();
            }
        }

        public IList<PedidoOrcamentoFornecedor> ObterPedidosDeFornecedoresQueNaoTiveramInteresse()
        {
            DateTime dataHoraInicio = DateTime.Now.AddHours(-1);
            DateTime dataHoraFim = DateTime.Now;

            IList<PedidoOrcamentoFornecedor> pedidosSemInteresse = context.Repository<PedidoOrcamentoFornecedor>()
                .Where(x => x.IdInteresse == 2 &&
                       x.Data >= dataHoraInicio &&
                       x.Data < dataHoraFim).ToList();
            return pedidosSemInteresse;
        }

        public IList<PedidoOrcamentoFornecedor> ObterPorPedido(int idPedidoOrcamento)
        {
            IList<PedidoOrcamentoFornecedor> fornecedoresDeUmPedido = context.Repository<PedidoOrcamentoFornecedor>()
              .Where(x => x.PedidoOrcamento.Id == idPedidoOrcamento).ToList();

            return fornecedoresDeUmPedido;
        }
    }
}
