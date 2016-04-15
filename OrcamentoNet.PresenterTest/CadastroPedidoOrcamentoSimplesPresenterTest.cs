using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using NMock2;
using NMock2.Actions;
using NUnit.Framework;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.ILocalService;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.PresenterTest
{
    [TestFixture]
    public class CadastroPedidoOrcamentoSimplesPresenterTest
    {
        private Mockery mocks;
        private ICadastroPedidoOrcamentoSimples mockView;
        private IFornecedorService mockCompradorService;
        private ICidadeService mockCidadeService;
        private IPedidoOrcamentoService mockPedidoOrcamentoService;
        private ICategoriaService mockCategoriaService;
        private CadastroPedidoOrcamentoSimplesPresenter presenter;

        [SetUp]
        public void SetUp() {
            mocks = new Mockery();

            presenter = new CadastroPedidoOrcamentoSimplesPresenter();

            mockView = mocks.NewMock<ICadastroPedidoOrcamentoSimples>();
            presenter.View = mockView;

            mockCidadeService = mocks.NewMock<ICidadeService>();
            presenter.cidadeService = mockCidadeService;           

            mockPedidoOrcamentoService = mocks.NewMock<IPedidoOrcamentoService>();
            presenter.pedidoOrcamentoService = mockPedidoOrcamentoService;

            mockCategoriaService = mocks.NewMock<ICategoriaService>();
            presenter.categoriaService = mockCategoriaService;
        }

        [TearDown]
        public void TearDown() {
            mocks.VerifyAllExpectationsHaveBeenMet();
            mocks.Dispose();
        }

        [Test]
        public void SalvarPedidoOrcamentoErro() {
            try
            {

                Cidade cidadeComprador = new Cidade();
                Cidade cidadePedidoOrcamento = new Cidade();
                Fornecedor comprador = new Fornecedor();
                comprador.Nome = "Nome de Teste";
                comprador.Email = "email@orcamentos.net.br";

                Expect.Once.On(mockView).GetProperty("IdCidadeComprador").Will(Return.Value(1));
                Expect.Once.On(mockView).GetProperty("IdCidadeComprador").Will(Return.Value(1));
                Expect.Once.On(mockCidadeService).Method("Obter").Will(Return.Value(cidadeComprador));

                // como no presenter.Salvar() há uma condição booleana OR envolvendo as propriedades View.IdCidadeComprador e
                // View.IdCidadePedidoOrcamento, somente a primeira condição booleana (de View.IdCidadeComprador) é verificada
                // em tempo de execução.
                Expect.Once.On(mockView).GetProperty("IdCidadePedidoOrcamento").Will(Return.Value(1));
                Expect.Once.On(mockCidadeService).Method("Obter").Will(Return.Value(cidadePedidoOrcamento));

                IList<string> categoriasSelecionadas = new List<string>();
                categoriasSelecionadas.Add("1");
                categoriasSelecionadas.Add("2");
                Expect.Once.On(mockView).GetProperty("SubCategorias").Will(Return.Value(categoriasSelecionadas));

                IList<Categoria> subCategorias = new List<Categoria>();
                Categoria categoria = new Categoria();
                categoria.Id = 1;
                categoria.Nome = "Animais";
                subCategorias.Add(categoria);
                categoria = new Categoria();
                categoria.Id = 2;
                categoria.Nome = "SubAnimais";
                subCategorias.Add(categoria);
                Expect.Once.On(mockCategoriaService).Method("ObterSubCategoriasDeUmaCategoria").Will(Return.Value(subCategorias));

                Expect.Once.On(mockView).GetProperty("Email").Will(Return.Value(comprador.Email));
                Expect.Once.On(mockView).GetProperty("Nome").Will(Return.Value(comprador.Nome));
                Expect.Once.On(mockView).GetProperty("Titulo").Will(Return.Value("Título do pedido de orçamento de teste"));
                Expect.Once.On(mockView).GetProperty("Observacao").Will(Return.Value("Descrição do pedido de orçamento de teste"));

                Expect.Once.On(mockPedidoOrcamentoService).Method("InserirSimplificado").WithAnyArguments().Will(Return.Value(null));

                string camposInvalidos = String.Empty;
                Expect.Once.On(mockView)
                    .Method("ExibirMensagem")
                    .With("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. " + camposInvalidos + ".<br />Por favor, corrija e salve novamente.</div>");

                //presenter.Salvar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }

        [Test]
        public void SalvarPedidoOrcamentoSemCategoria() {
            try
            {

                Cidade cidadeComprador = new Cidade();
                Cidade cidadePedidoOrcamento = new Cidade();
                Fornecedor comprador = new Fornecedor();
                comprador.Nome = "Nome de Teste";
                comprador.Email = "email@orcamentos.net.br";

                Expect.Once.On(mockView).GetProperty("IdCidadeComprador").Will(Return.Value(1));
                Expect.Once.On(mockView).GetProperty("IdCidadeComprador").Will(Return.Value(1));
                Expect.Once.On(mockCidadeService).Method("Obter").Will(Return.Value(cidadeComprador));

                // como no presenter.Salvar() há uma condição booleana OR envolvendo as propriedades View.IdCidadeComprador e
                // View.IdCidadePedidoOrcamento, somente a primeira condição booleana (de View.IdCidadeComprador) é verificada
                // em tempo de execução.
                Expect.Once.On(mockView).GetProperty("IdCidadePedidoOrcamento").Will(Return.Value(1));
                Expect.Once.On(mockCidadeService).Method("Obter").Will(Return.Value(cidadePedidoOrcamento));

                IList<string> categoriasSelecionadas = new List<string>();
                categoriasSelecionadas.Add("1");
                categoriasSelecionadas.Add("2");
                Expect.Once.On(mockView).GetProperty("SubCategorias").Will(Return.Value(categoriasSelecionadas));

                IList<Categoria> subCategorias = new List<Categoria>();
                Expect.Once.On(mockCategoriaService).Method("ObterSubCategoriasDeUmaCategoria").Will(Return.Value(subCategorias));

                Expect.Once.On(mockView)
                    .Method("ExibirMensagem")
                    .With("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. Preenchimento inválido: Ramo de Atividade.<br />Por favor, corrija e salve novamente.</div>");

                presenter.Salvar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }

        [Test]
        public void SalvarPedidoOrcamentoSucesso() {
            try
            {

                Cidade cidadeComprador = new Cidade();
                Cidade cidadePedidoOrcamento = new Cidade();
                Fornecedor comprador = new Fornecedor();
                comprador.Nome = "Nome de Teste";
                comprador.Email = "email@orcamentos.net.br";

                Expect.Once.On(mockView).GetProperty("IdCidadeComprador").Will(Return.Value(1));
                Expect.Once.On(mockView).GetProperty("IdCidadeComprador").Will(Return.Value(1));
                Expect.Once.On(mockCidadeService).Method("Obter").Will(Return.Value(cidadeComprador));

                // como no presenter.Salvar() há uma condição booleana OR envolvendo as propriedades View.IdCidadeComprador e
                // View.IdCidadePedidoOrcamento, somente a primeira condição booleana (de View.IdCidadeComprador) é verificada
                // em tempo de execução.
                Expect.Once.On(mockView).GetProperty("IdCidadePedidoOrcamento").Will(Return.Value(1));
                Expect.Once.On(mockCidadeService).Method("Obter").Will(Return.Value(cidadePedidoOrcamento));

                IList<string> categoriasSelecionadas = new List<string>();
                categoriasSelecionadas.Add("1");
                categoriasSelecionadas.Add("2");
                Expect.Once.On(mockView).GetProperty("SubCategorias").Will(Return.Value(categoriasSelecionadas));

                IList<Categoria> subCategorias = new List<Categoria>();
                Categoria categoria = new Categoria();
                categoria.Id = 1;
                categoria.Nome = "Animais";
                subCategorias.Add(categoria);
                categoria = new Categoria();
                categoria.Id = 2;
                categoria.Nome = "SubAnimais";
                subCategorias.Add(categoria);
                Expect.Once.On(mockCategoriaService).Method("ObterSubCategoriasDeUmaCategoria").Will(Return.Value(subCategorias));
                
                Expect.Once.On(mockView).GetProperty("Email").Will(Return.Value(comprador.Email));
                Expect.Once.On(mockView).GetProperty("Nome").Will(Return.Value(comprador.Nome));
                Expect.Once.On(mockView).GetProperty("Titulo").Will(Return.Value("Título do pedido de orçamento de teste"));
                Expect.Once.On(mockView).GetProperty("Observacao").Will(Return.Value("Descrição do pedido de orçamento de teste"));

                PedidoOrcamento pedidoOrcamento = new PedidoOrcamento();
                Expect.Once.On(mockPedidoOrcamentoService).Method("InserirSimplificado").WithAnyArguments().Will(Return.Value(pedidoOrcamento));
                Expect.Once.On(mockView)
                    .Method("RedirecionarPaginaSucesso");

                presenter.Salvar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }
    }
}
