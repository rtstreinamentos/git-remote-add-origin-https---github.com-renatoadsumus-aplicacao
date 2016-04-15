using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using NMock2;
using NMock2.Actions;
using NUnit.Framework;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.ILocalService;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.PresenterTest
{
    [TestFixture]
    public class CadastroFornecedorPresenterTest
    {
        private Mockery mocks;
        private ICadastroFornecedor mockView;
        private ICategoriaService mockCategoriaService;
        private ICidadeService mockCidadeService;
        private IFornecedorService mockCompradorService;
        private IFornecedorService mockFornecedorService;
        private CadastroFornecedorPresenter presenter;

        private IList<string> categorias;
        private IList<Categoria> categoriasDoBanco;
        private Categoria categoriaDoBanco;
        private IList<string> cidades;
        private IList<Cidade> cidadesDoBanco;
        private Cidade cidadeDoBanco;
        private Fornecedor comprador;
        private Fornecedor fornecedor;

        #region Metodos Privados
        private void PrepararFornecedorSimplificado() {
            try
            {
                comprador = new Fornecedor();
                comprador.Id = 1;               
                comprador.Nome = "Nome de Teste";
                comprador.Email = "email@orcamentos.net.br";

                cidades = new List<string>();
                cidades.Add("3631");        //Rio de Janeiro
                cidades.Add("5213");        //São Paulo
                cidadesDoBanco = new List<Cidade>();
                cidadeDoBanco = new Cidade();
                cidadeDoBanco.Id = 3631;
                cidadeDoBanco.Nome = "Rio de Janeiro";
                cidadeDoBanco.Uf = UF.RJ;
                cidadesDoBanco.Add(cidadeDoBanco);
                cidadeDoBanco = new Cidade();
                cidadeDoBanco.Id = 5213;
                cidadeDoBanco.Nome = "São Paulo";
                cidadeDoBanco.Uf = UF.SP;
                cidadesDoBanco.Add(cidadeDoBanco);

                categorias = new List<string>();
                categorias.Add("2");        //Academias
                categorias.Add("3");        //Cursos Esportivos
                categoriasDoBanco = new List<Categoria>();
                categoriaDoBanco = new Categoria();
                categoriaDoBanco.Id = 2;
                categoriaDoBanco.Nome = "Academias";
                categoriasDoBanco.Add(categoriaDoBanco);
                categoriaDoBanco = new Categoria();
                categoriaDoBanco.Id = 3;
                categoriaDoBanco.Nome = "Cursos Esportivos";
                categoriasDoBanco.Add(categoriaDoBanco);

                fornecedor = new Fornecedor();
                fornecedor.Id = comprador.Id;
                fornecedor.Nome = comprador.Nome;
                fornecedor.Email = comprador.Email;
                fornecedor.Cidades = cidadesDoBanco;
                fornecedor.SubCategorias = categoriasDoBanco;
            }

            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }
        #endregion


        #region Metodos Publicos
        [SetUp]
        public void SetUp() {
            mocks = new Mockery();

            presenter = new CadastroFornecedorPresenter();

            mockView = mocks.NewMock<ICadastroFornecedor>();
            presenter.View = mockView;

            mockCategoriaService = mocks.NewMock<ICategoriaService>();
            presenter.categoriaService = mockCategoriaService;
            mockCidadeService = mocks.NewMock<ICidadeService>();
            presenter.cidadeService = mockCidadeService;
            mockCompradorService = mocks.NewMock<IFornecedorService>();
            presenter.fornecedorService = mockCompradorService;
            mockFornecedorService = mocks.NewMock<IFornecedorService>();
            presenter.fornecedorService = mockFornecedorService;
        }

        [TearDown]
        public void TearDown() {
            mocks.VerifyAllExpectationsHaveBeenMet();
            mocks.Dispose();
        }

        [Test]
        public void SalvarComErroSemCategorias() {
            try
            {
                this.PrepararFornecedorSimplificado();
                IList<string> categoriasVazia = new List<string>();
                Expect.Once.On(mockView).GetProperty("Categorias").Will(Return.Value(categoriasVazia));
                Expect.Once.On(mockView).GetProperty("Cidades").Will(Return.Value(cidades));
                Expect.Once.On(mockView)
                    .Method("ExibirMensagem")
                    .With("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. Preenchimento inválido: Ramos de Atividade!</div>");
                presenter.Salvar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }

        [Test]
        public void SalvarComErroSemCidades() {
            try
            {
                this.PrepararFornecedorSimplificado();
                Expect.Once.On(mockView).GetProperty("Categorias").Will(Return.Value(categorias));
                IList<string> cidadesVazia = new List<string>();
                Expect.Once.On(mockView).GetProperty("Cidades").Will(Return.Value(cidadesVazia));
                Expect.Once.On(mockView)
                    .Method("ExibirMensagem")
                    .With("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. Preenchimento inválido: Região de Atuação!</div>");
                presenter.Salvar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }

        [Test]
        public void SalvarComErroEmailExistente() {
            try
            {
                this.PrepararFornecedorSimplificado();
                Expect.Once.On(mockView).GetProperty("Categorias").Will(Return.Value(categorias));
                Expect.Once.On(mockView).GetProperty("Cidades").Will(Return.Value(cidades));
                Expect.Once.On(mockView).GetProperty("Categorias").Will(Return.Value(categorias));
                Expect.Once.On(mockCategoriaService).Method("ObterSubCategoriasDeUmaCategoria").With(categorias).Will(Return.Value(categoriasDoBanco));
                Expect.Once.On(mockView).GetProperty("Cidades").Will(Return.Value(cidades));
                Expect.Once.On(mockCidadeService).Method("Obter").With(Int32.Parse(cidades[0])).Will(Return.Value(cidadesDoBanco[0]));
                Expect.Once.On(mockCidadeService).Method("Obter").With(Int32.Parse(cidades[1])).Will(Return.Value(cidadesDoBanco[1]));
                Expect.Once.On(mockView).GetProperty("Nome").Will(Return.Value(comprador.Nome));
                Expect.Once.On(mockView).GetProperty("Email").Will(Return.Value(comprador.Email));
                Expect.Once.On(mockView).GetProperty("TipoPessoa").Will(Return.Value("Fisica"));
                IList<string> camposInvalidos = new List<string>();
                camposInvalidos.Add("E-mail");
                Expect.Once.On(mockCompradorService)
                    .Method("InserirSimplificado")
                    .WithAnyArguments()
                    .Will(new SetNamedParameterAction("camposInvalidos", camposInvalidos),
                          Return.Value(null));

                Expect.Once.On(mockView)
                    .Method("ExibirMensagem")
                    .With("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. Preenchimento inválido: E-mail!</div>");
                presenter.Salvar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }

        [Test]
        public void SalvarComErroNomeComXSS() {
            try
            {
                this.PrepararFornecedorSimplificado();
                Expect.Once.On(mockView).GetProperty("TipoPessoa").Will(Return.Value("Fisica"));
                Expect.Once.On(mockView).GetProperty("Nome").Will(Return.Value(comprador.Nome));
                Expect.Once.On(mockView).GetProperty("Email").Will(Return.Value(comprador.Email));
                Expect.Once.On(mockView).GetProperty("Cidades").Will(Return.Value(cidades));
                Expect.Once.On(mockView).GetProperty("Cidades").Will(Return.Value(cidades));
                Expect.Once.On(mockCidadeService).Method("Obter").With(Int32.Parse(cidades[0])).Will(Return.Value(cidadesDoBanco[0]));
                Expect.Once.On(mockCidadeService).Method("Obter").With(Int32.Parse(cidades[1])).Will(Return.Value(cidadesDoBanco[1]));
                Expect.Once.On(mockView).GetProperty("Categorias").Will(Return.Value(categorias));
                Expect.Once.On(mockView).GetProperty("Categorias").Will(Return.Value(categorias));
                Expect.Once.On(mockCategoriaService).Method("ObterSubCategoriasDeUmaCategoria").With(categorias).Will(Return.Value(categoriasDoBanco));
                IList<string> camposInvalidos = new List<string>();
                camposInvalidos.Add("Nome");
                Expect.Once.On(mockCompradorService)
                    .Method("InserirSimplificado")
                    .WithAnyArguments()
                    .Will(new SetNamedParameterAction("camposInvalidos", camposInvalidos),
                          Return.Value(null));
                Expect.Once.On(mockView)
                    .Method("ExibirMensagem")
                    .With("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. Preenchimento inválido: Nome!</div>");
                presenter.Salvar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }

        [Test]
        public void SalvarComSucesso() {
            try
            {
                this.PrepararFornecedorSimplificado();
                Expect.Once.On(mockView).GetProperty("TipoPessoa").Will(Return.Value("Fisica"));
                Expect.Once.On(mockView).GetProperty("Nome").Will(Return.Value(comprador.Nome));
                Expect.Once.On(mockView).GetProperty("Email").Will(Return.Value(comprador.Email));
                Expect.Once.On(mockView).GetProperty("Cidades").Will(Return.Value(cidades));
                Expect.Once.On(mockView).GetProperty("Cidades").Will(Return.Value(cidades));
                Expect.Once.On(mockCidadeService).Method("Obter").With(Int32.Parse(cidades[0])).Will(Return.Value(cidadesDoBanco[0]));
                Expect.Once.On(mockCidadeService).Method("Obter").With(Int32.Parse(cidades[1])).Will(Return.Value(cidadesDoBanco[1]));
                Expect.Once.On(mockView).GetProperty("Categorias").Will(Return.Value(categorias));
                Expect.Once.On(mockView).GetProperty("Categorias").Will(Return.Value(categorias));
                Expect.Once.On(mockCategoriaService).Method("ObterSubCategoriasDeUmaCategoria").With(categorias).Will(Return.Value(categoriasDoBanco));
                Expect.Once.On(mockCompradorService).Method("InserirSimplificado").WithAnyArguments().Will(Return.Value(comprador));
                Expect.Once.On(mockFornecedorService).Method("Inserir").With(comprador.Id, cidadesDoBanco, categoriasDoBanco).Will(Return.Value(fornecedor));
                Expect.Once.On(mockView).Method("RedirecionarPaginaSucesso");
                presenter.Salvar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }
        #endregion
    }
}
