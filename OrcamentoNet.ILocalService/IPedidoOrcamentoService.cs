using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.ILocalService
{
    public interface IPedidoOrcamentoService
    {
        bool AutorizarAcesso(int idPedido, string email);
        void NotificarFornecedorEmDegustacaoPorEmailNovoPedidoOrcamento(PedidoOrcamento pedidoOrcamento, bool possuiFornecedorCadastrado);
        bool NotificarFornecedorClientePorEmailNovoPedidoOrcamento(PedidoOrcamento pedidoOrcamento, Fornecedor fornecedor);
        bool EnviarEmailPedidoOrcamentoSimplificado(PedidoOrcamento pedidoOrcamento);
        void EnviarEmailPedidoOrcamentoParaWordPress(PedidoOrcamento pedidoOrcamento);
        void AssinarLista(string nome, string email);
        string CategoriasDoPedidoSeparadasPorVirgula(PedidoOrcamento pedidoOrcamento);

		string GerarHTMLUltimosPedidos(int quantidadeRegistros, string termoPesquisa);

        PedidoOrcamento Inserir(ref string camposInvalidos, PedidoOrcamento pedidoOrcamento);
        PedidoOrcamento InserirPedido(PedidoOrcamento pedidoOrcamento);
        PedidoOrcamento Obter(int id);
       

        IList<PedidoOrcamento> ObterPedidosOrcamentoParaInformarStatusAosFornecedores();
        IList<PedidoOrcamento> ObterPedidosOrcamentoPorData(DateTime dataPedidoOrcamento);
        PedidoOrcamento ObterPedidoOrcamentoPorEmail(string email);
        PedidoOrcamento ObterPedidoOrcamentoPorEmailId(string email, int idPedido);
        IList<PedidoOrcamento> ObterPedidosOrcamentoUltimaHora(DateTime dataHoraReferencia);
        IList<PedidoOrcamento> ObterUltimosPedidosOrcamento(int quantidadeRegistros, string termoPesquisa);
        IList<PedidoOrcamento> ObterUltimosPedidosOrcamentoPorCategoriaOuTema(int quantidadeRegistros, int idCategoria, string termoPesquisa);
        IList<PedidoOrcamento> ObterUltimosPedidosOrcamentoPorCategoriaPorCidadeOuEstado(int quantidadeRegistros, int idCategoria, int idCidade, string termoPesquisa);
        IList<PedidoOrcamento> ObterUltimosPedidosOrcamentoPorCategoriaMes(int quantidadeRegistros, Categoria categoria, int idMes, int idCidade);
        void RemoverPedidosOrcamentoDuplicados();
        bool ResponderPesquisaSatisfacao(ref string camposInvalidos, string email, int idPedidoOrcamento, int idStatus, string opiniaoComprador, string pontosMelhoria, int gostou, bool pesquisaRevisada);

        IList<PedidoOrcamento> ObterPedidosOrcamentoPorIntervaloDeData(DateTime dataIncio, DateTime dataFim);

        IList<PedidoOrcamento> ObterPedidosOrcamentoPorDataAlteracao(DateTime dateTime);

        PedidoOrcamento Inserir(PedidoOrcamento pedidoOrcamento);

        IList<PedidoOrcamento> ObterComComentarios(int quantidadeDePedidos, int idCategoria);
        IList<PedidoOrcamento> ObterComComentariosEstadoCidadePorCategoria(int quantidadeDePedidos, int idCategoria, int idCidade, int idMes);
        PedidoOrcamento ObterUltimoPedidoDoEmail(string emailComprador);
        IList<PedidoOrcamento> ObterUltimosPesquisaRespondidaPedidosDasCidadesDoFornecedor(int quantidadeDePedidos, Categoria categoria, Fornecedor fornecedor, PedidoCompradorStatus pedidoCompradorStatus);
        IList<PedidoOrcamento> ObterPedidosOrcamentoPorDataStatus(DateTime dateTime, PedidoStatus status);
        IList<PedidoOrcamento> ObterUltimosPedidosPorEstado(int quantidadeDePedidos, Categoria categoria, UF uf);
        IList<PedidoOrcamento> ObterPedidosPorCategoriaCidade(int idMes, IList<Categoria> categorias, int idCidade);
        IList<PedidoOrcamento> ObterUltimosPedidosPorCategoriaComImagem(int idCategoria);
        IList<PedidoOrcamento> ObterUltimosPedidosOrcamentoPorCategoriaPorCidadePorAnoMes(int quantidade, int mes, int ano, int cidade, Categoria categoria);

        IList<PedidoOrcamento> ObterUltimosComentariosQueGostaram();
        ClassificacaoPedido ObterClassificacaoPedido(PedidoOrcamento pedidoOrcamento);
    }
}
