using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.ILocalService
{
    public interface IFornecedorService
    {
        Fornecedor Alterar(Fornecedor fornecedor);

        IList<Fornecedor> ObterFornecedoresEmDegustacaoParaUmPedidoDeOrcamento(PedidoOrcamento pedidoOrcamento);
        IList<Fornecedor> ObterFornecedoresParaUmPedidoDeOrcamento(PedidoOrcamento pedidoOrcamento);
        IList<Fornecedor> ObterFornecedoresClientesParaUmPedidoDeOrcamento(PedidoOrcamento pedidoOrcamento);
        
        IList<Fornecedor> ObterFornecedoresAtivosPorCategoria(Categoria categoria);

        Fornecedor ObterPorId(int id);

        Fornecedor Inserir(ref IList<string> camposInvalidos, Fornecedor fornecedor, string webSite);

        Fornecedor ObterPorEmail(string email);

        IList<Fornecedor> ObterFornecedoresPorDataCriacao(DateTime dataCriacao);

        IList<Fornecedor> ObterFornecedoresPorDataVencimento(DateTime dataVencimento);

        IList<Fornecedor> ObterFornecedoresQueNaoPagaram(int numeroDiasAposVencimento);

        IList<Fornecedor> ObterUltimosFornecedoresCadastrados(int quantidadeDeFornecedores, int idCategoria, string termoPesquisa);

        bool ValidarDados(ref string camposInvalidos
            , string nome
            , string email
            , string telefone       
            , ref string website
            , string descricao);

        IList<Fornecedor> ObterFornecedoresAtivos();

        Fornecedor ObterPorNome(string nome);

        double CalcularValorMensalidade(IList<Cidade> cidadesOrcamento, IList<Categoria> subCategorias);

        IList<Fornecedor> ObterFornecedoresPorIntervaloDeData(DateTime dataIncio, DateTime dataFim);
                
        IList<Fornecedor> ObterFornecedoresAtivosPoCategoriaCidade(Categoria categoria, Cidade cidade);
        IList<Fornecedor> ObterClientesPorTema(Categoria categoria);
        IList<Fornecedor> ObterClientesPorCategoriaCidade(Categoria categoria, Cidade cidade);
        IList<Fornecedor> ObterUltimosFornecedoresCadastradosDoTemaOuCategoriaPorEstadoCidade(int quantidadeDeFornecedores, int idCategoria, int idCidade, int idMes, string termoPesquisa);

        IList<Fornecedor> ObterFornecedoresAtivosPorEstado(Categoria categoria, UF uf);
        
        void EnviarEmailConfirmacaoCadastro(Fornecedor fornecedor);

        IList<Fornecedor> ObterFornecedoresComCortesiaVencida(int numeroDiasAposVencimento);
        void EnviarEmailParaForncedoresQueNaoResponderamOsPedidos();
    }
}
