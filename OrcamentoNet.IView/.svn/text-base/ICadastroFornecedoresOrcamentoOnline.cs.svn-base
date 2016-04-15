using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface ICadastroFornecedoresOrcamentoOnline
    {
        void GerarHeaderHTML(string nomeCategoria, string nomeCidade, string keywords);        
        int IdCategoria { get; }
        int IdCidade { get; }
        int IdCategoriaPrincipal { get; }       
		bool PalavraEhCorreta { get; }
        IList<string> Categorias { get; }
        string Descricao { get; }
        string Email { get; }
        Fornecedor Fornecedor { get; }
        IList<string> Fotos { get; }        
        IList<int> CidadesDeAtuacao { get; }        
        string WebSite { get; }
        string Nome { get; }       
        string Telefone { get; }
        string Indicacao { get; }
        double ValorMensalidade { get; }
        void CarregarCategoria(IList<OrcamentoNet.Entity.Categoria> categorias);
        void LimparTela();

        void ExibirMensagemParteInferior(string mensagem);
		void RedirecionarPaginaSucesso();       

        void ViewPasso3();

        void GuardarFornecedorNaSessao(OrcamentoNet.Entity.Fornecedor fornecedor);

        void CarregarCategoriasSelecionadas(IList<Categoria> categoriasSelecionadas);

        void MontarLinksInternosTermos(IList<LinkInterno> linksInternosTermo);

        void ApresentarValoresPlanos(string plano1, string plano2);

        void ViewEscolhaDoPlano();
    }
}
