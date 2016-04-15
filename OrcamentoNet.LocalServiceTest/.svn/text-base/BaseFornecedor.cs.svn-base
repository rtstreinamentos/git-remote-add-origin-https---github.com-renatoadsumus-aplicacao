using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.LocalServiceTest
{
    public class BaseFornecedor
    {
        private IFornecedorService fornecedorService;
        private ICidadeService cidadeService;
        private ICategoriaService categoriaService;


        public BaseFornecedor(IFornecedorService fornecedorService, ICidadeService cidadeService, ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
            this.cidadeService = cidadeService;
            this.fornecedorService = fornecedorService;
        }

        public Fornecedor IncluirFornecedorValido(List<int> idCidades, string email, List<int> idCategoria)
        {
            if (String.IsNullOrEmpty(email))
                email = "renatoadsumus@gmail.com";

            IList<Categoria> resultadoCategoria = new List<Categoria>();
            IList<CategoriaPrioridade> categoriasPrioridade = new List<CategoriaPrioridade>();

            for (int x = 0; x < idCategoria.Count; x++)
            {
                Categoria categoria = categoriaService.Obter(idCategoria[x], false);
                CategoriaPrioridade categoriaPrioridade = new CategoriaPrioridade();
                categoriaPrioridade.Prioridade = x + 1;
                categoriaPrioridade.IdCategoria = categoria;
                categoriasPrioridade.Add(categoriaPrioridade);
                resultadoCategoria.Add(categoria);
            }

            IList<Cidade> cidadesAtuacao = new List<Cidade>();

            for (int x = 0; x < idCidades.Count; x++)
            {
                cidadesAtuacao.Add(cidadeService.Obter(idCidades[x]));
            }

            IList<string> camposInvalidos = new List<string>();

            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Fornecedor -";
            fornecedor.Email = email;
            fornecedor.SubCategorias = resultadoCategoria;
            fornecedor.Telefone = "21-22555290";
            fornecedor.CategoriasPrioridade = categoriasPrioridade;
            fornecedor.Cidades = cidadesAtuacao;
            fornecedor.Descricao = "Empresa especializada em todos os tipos de eventos. Atendemos vários públicos de clientes de forma bem segmentada. Veja nosso eventos www.google.com.br";
            fornecedor.ValorMensalidade = 65.7;
            fornecedor.TipoPessoaAtendimento = PessoaTipo.Fisica;

            return fornecedorService.Inserir(ref camposInvalidos, fornecedor, "www.google.com.br");
        }

        public Fornecedor InserirFornecedorClienteComAutoResposta(List<int> idCidades, string email, List<int> idCategoria)
        {
            IList<Categoria> resultadoCategoria = new List<Categoria>();

            for (int x = 0; x < idCategoria.Count; x++)
            {
                resultadoCategoria.Add(categoriaService.Obter(idCategoria[x], false));
            }

            IList<Cidade> cidadesAtuacao = new List<Cidade>();

            for (int x = 0; x < idCidades.Count; x++)
            {
                cidadesAtuacao.Add(cidadeService.Obter(idCidades[x]));
            }

            IList<string> camposInvalidos = new List<string>();

            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Nome = "Fornecedor -";
            fornecedor.Email = email;
            fornecedor.SubCategorias = resultadoCategoria;
            fornecedor.Telefone = "21-22555290";

            fornecedor.Cidades = cidadesAtuacao;
            fornecedor.Status = Status.Cliente;
            fornecedor.MensagemAutoResposta = "Obrigado pelo Contato!!!";
            fornecedor.Descricao = "Empresa especializada em todos os tipos de eventos. Atendemos vários públicos de clientes de forma bem segmentada. Veja nosso eventos www.google.com.br";
            fornecedor.ValorMensalidade = 65.7;
            fornecedor.TipoPessoaAtendimento = PessoaTipo.Fisica; 
            return fornecedorService.Inserir(ref camposInvalidos, fornecedor, "www.google.com.br");

        }
        public Fornecedor InserirFornecedor(string email, int idCidadeAtuacao, int idCategoria)
        {
            List<int> cidades = new List<int>();
            cidades.Add(idCidadeAtuacao);

            List<int> categorias = new List<int>();
            categorias.Add(idCategoria);

            return this.IncluirFornecedorValido(cidades, email, categorias);
        }

        public void InserirFornecedorMultiplasCidades(string email, int idBoxVidrosEspelhos, List<int> cidades)
        {

            List<int> categorias = new List<int>();
            categorias.Add(idBoxVidrosEspelhos);

            IncluirFornecedorValido(cidades, email, categorias);
        }

        public void InserirFornecedorMultiplasCategorias(string email, int idCidadeAtuacao, List<int> categorias)
        {
            List<int> cidades = new List<int>();
            cidades.Add(idCidadeAtuacao);

            IncluirFornecedorValido(cidades, email, categorias);
        }
    }
}
