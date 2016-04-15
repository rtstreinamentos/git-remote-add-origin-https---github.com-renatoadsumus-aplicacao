using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.ILocalService
{
    public interface IPedidoOrcamentoService
    {
        bool AutorizarAcesso(int idPedido, string email);
        void NotificarFornecedorPorEmailNovoPedidoOrcamento(PedidoOrcamento pedidoOrcamento);
        bool EnviarEmailPedidoOrcamentoSimplificado(PedidoOrcamento pedidoOrcamento);
        void EnviarEmailPedidoOrcamentoParaWordPress(PedidoOrcamento pedidoOrcamento);
        void AssinarLista(string nome, string email);

        PedidoOrcamento Inserir(Pessoa comprador, IList<Categoria> categorias, string observacao, string titulo, ref string camposInvalidos, Cidade cidadePedidoOrcamento);

        PedidoOrcamento Obter(int id);

        IList<PedidoOrcamento> ObterPedidosOrcamentoParaInformarStatusAosFornecedores();
        IList<PedidoOrcamento> ObterPedidosOrcamentoPorData(DateTime dataPedidoOrcamento);
        PedidoOrcamento ObterPedidoOrcamentoPorEmail(string email);
        PedidoOrcamento ObterPedidoOrcamentoPorEmailId(string email, int idPedido);
        IList<PedidoOrcamento> ObterPedidosOrcamentoUltimaHora(DateTime dataHoraReferencia);
        IList<PedidoOrcamento> ObterUltimosPedidosOrcamento(int quantidadeRegistros, string termoPesquisa);
        IList<PedidoOrcamento> ObterUltimosPedidosOrcamentoPorCategoria(int quantidadeRegistros, int idCategoria, string termoPesquisa);
        IList<PedidoOrcamento> ObterUltimosPedidosOrcamentoPorCategoriaPorCidade(int quantidadeRegistros, int idCategoria, int idCidade, string termoPesquisa);

        void RemoverPedidosOrcamentoDuplicados();
        bool ResponderPesquisaSatisfacao(ref string camposInvalidos, string email, int idPedidoOrcamento, int idStatus, string opiniaoComprador, string pontosMelhoria, int gostou);

        IList<PedidoOrcamento> ObterPedidosOrcamentoPorIntervaloDeData(DateTime dataIncio, DateTime dataFim);

        IList<PedidoOrcamento> ObterPedidosOrcamentoPorDataAlteracao(DateTime dateTime);

        PedidoOrcamento Inserir(PedidoOrcamento pedidoOrcamento);

        IList<PedidoOrcamento> ObterComComentarios(int quantidadeDePedidos);
        PedidoOrcamento ObterUltimoPedidoDoEmail(string emailComprador);
    }
}
