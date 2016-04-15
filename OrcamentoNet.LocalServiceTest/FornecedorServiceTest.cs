using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using InfoGlobo.InjectionFramework.Core;
using NHibernate.Burrow;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.LocalServiceTest
{
    [TestFixture]
    public class FornecedorServiceTest
    {
        private StandardKernel injectionService;

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public IFornecedorCategoriaService fornecedorCategoriaService { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }


        private string email1 = "renatoadsumus@gmail.com";
        private string email2 = "renato@rcmsolucoes.com";
        private string email3 = "contato@rcmsolucoes.com";
        private string email4 = "fabriciofuji@yahoo.com.br";
        private string email5 = "FornecedorInativo@voceconhece.com";

        private int idCidadeAngraDosReis = 3565;
        private int idCidadeRioDeJaneiro = 6005;
        private int idCidadeSaoPaulo = 6072;

        private int idBoxVidrosEspelhos = 19;
        private int idEletricista = 33;
        private int idRamoAnimais = 7;
        BasePedidoOrcamento basePedidoOrcamento;

        [SetUp]
        public void Setup()
        {
            //Preparando Base de Dados
            BaseDados.BaseDados baseDados = new BaseDados.BaseDados();
            baseDados.ExcluirDados();

            injectionService = new StandardKernel(new CustomModule());
            injectionService.Inject(this);

            basePedidoOrcamento = new BasePedidoOrcamento(pedidoOrcamentoService);
            baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);

        }

        BaseFornecedor baseFornecedor;

        [TearDown]
        public void TearDown()
        {
            new BurrowFramework().CloseWorkSpace();
        }

        [Test]
        public void InserirSimplificadoSucesso()
        {
            //Dado que o forncedor não existe
            //Quando recebo objeto fornecedor de retorno do metodo inserir
            //Então verifico que não é null           

            baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
            Fornecedor fornecedor = fornecedorService.ObterPorEmail(email1);
            Assert.IsNotNull(fornecedor, "Comprador foi inserido com sucesso.");
        }

        [Test]
        public void ObterFornecedoresParaUmPedidoDeOrcamento()
        {
            try
            {
                List<int> categorias = new List<int>();
                categorias.Add(idEletricista);
                categorias.Add(idBoxVidrosEspelhos);

                IList<Categoria> categoriasOBJ = new List<Categoria>();
                categoriasOBJ.Add(categoriaService.Obter(idEletricista, false));
                categoriasOBJ.Add(categoriaService.Obter(idBoxVidrosEspelhos, false));

                baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
                baseFornecedor.InserirFornecedor(email2, idCidadeRioDeJaneiro, idEletricista);
                baseFornecedor.InserirFornecedor(email3, idCidadeSaoPaulo, idBoxVidrosEspelhos);
                baseFornecedor.InserirFornecedorMultiplasCategorias(email4, idCidadeRioDeJaneiro, categorias);

                //este fornecedor não deve ser retornado
                baseFornecedor.InserirFornecedor(email5, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
                Fornecedor fornecedor = fornecedorService.ObterPorEmail(email5);
                fornecedor.Status = Status.Inativo;


                PedidoOrcamento pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categoriasOBJ[0], cidadeService.Obter(idCidadeRioDeJaneiro));
                Assert.IsTrue(pedidoOrcamento.Id > 0, "Verifica se criou pedido de orçamento com sucesso.");

                IList<Fornecedor> fornecedores;

                fornecedores = fornecedorService.ObterFornecedoresParaUmPedidoDeOrcamento(pedidoOrcamento);
                Assert.IsTrue(fornecedores.Count == 3, "Deve retornar a quantidade de fornecedores para o critério do filtro.");
                Assert.AreEqual(1, fornecedores.ElementAt(0).Id, "Deve retornar os fornecedores corretos para os critérios do filtro");
                Assert.AreEqual(2, fornecedores.ElementAt(1).Id, "Deve retornar os fornecedores corretos para os critérios do filtro");
                Assert.AreEqual(4, fornecedores.ElementAt(2).Id, "Deve retornar os fornecedores corretos para os critérios do filtro");

                pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categoriasOBJ[0], cidadeService.Obter(idCidadeSaoPaulo));
                Assert.IsTrue(pedidoOrcamento.Id > 0, "Verifica se criou pedido de orçamento com sucesso.");

                fornecedores = fornecedorService.ObterFornecedoresParaUmPedidoDeOrcamento(pedidoOrcamento);
                Assert.IsTrue(fornecedores.Count == 1, "Deve retornar apenas 1 fornecedor para os critérios do filtro");
                Assert.AreEqual(3, fornecedores.First().Id, "Deve retornar o fornecedor correto para os critérios do filtro");

                pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categoriasOBJ[0], cidadeService.Obter(idCidadeAngraDosReis));
                Assert.IsTrue(pedidoOrcamento.Id > 0, "Verifica se criou pedido de orçamento com sucesso.");

                fornecedores = fornecedorService.ObterFornecedoresParaUmPedidoDeOrcamento(pedidoOrcamento);
                Assert.IsTrue(fornecedores.Count == 0, "Deve retornar 0 fornecedores para os critérios do filtro");
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }


        /// <summary>
        /// Dado que tenho 
        /// - 1 fornecedor da cidade do Rio de Janeiro na categoria Buffet Japonês e Academias
        /// - 1 fornecedor da cidade do Rio de Janeiro na categoria Buffet Japonês com status inativo
        /// - 1 fornecedor da cidade de Angra dos Reis na categoria Buffet Japonês
        /// - 1 fornecedor da cidade de São Paulo na categoria Buffet Japonês
        /// - 1 fornecedor da cidade de São Paulo e do Rio de Janeiro na categoria Academias
        /// 
        /// Quando recebo um pedido de orçamento de Buffet Japonês na cidade do Rio de Janeiro
        /// Então posso notificar todos os fornecedores da categoria no ESTADO do Rio de Janeiro
        ///
        /// Quando recebo um pedido de orçamento de Buffet Japonês na cidade de São Paulo
        /// Então posso notificar todos os fornecedores da categoria no ESTADO de São Paulo
        /// </summary>


        [Test]
        public void ObterFornecedoresPorCategoria()
        {
            baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email2, idCidadeRioDeJaneiro, idEletricista);
            baseFornecedor.InserirFornecedor(email3, idCidadeSaoPaulo, idBoxVidrosEspelhos);

            //este fornecedor não deve ser retornado
            baseFornecedor.InserirFornecedor(email4, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
            Fornecedor fornecedor = fornecedorService.ObterPorEmail(email4);
            fornecedor.Status = Status.Inativo;

            Categoria categoria = categoriaService.Obter(idBoxVidrosEspelhos, false);

            IList<Fornecedor> fornecedoresPorCategoria = fornecedorService.ObterFornecedoresAtivosPorCategoria(categoria);

            Assert.IsTrue(fornecedoresPorCategoria.Count == 2);
        }

        [Test]
        public void ObterFornecedoresParaExplicarServicoOrcamento()
        {
            baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email2, idCidadeRioDeJaneiro, idEletricista);
            baseFornecedor.InserirFornecedor(email3, idCidadeSaoPaulo, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email4, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);

            Fornecedor fornecedor = fornecedorService.ObterPorEmail(email1);
            fornecedor.DataCadastro = DateTime.Now.AddDays(-12);

            // desativa um dos fornecedores para confirmar que ele não será retornado
            fornecedor = fornecedorService.ObterPorEmail(email2);
            fornecedor.Status = Status.Inativo;

            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresPorDataCriacao(DateTime.Now);

            Assert.IsTrue(fornecedores.Count == 2, "Deve retornar 2 fornecedores para explicar serviço");
        }

        [Test]
        public void ObterFornecedoresPorDataVencimento()
        {
            baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email2, idCidadeRioDeJaneiro, idEletricista);
            baseFornecedor.InserirFornecedor(email3, idCidadeSaoPaulo, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email4, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);

            DateTime diaVencimento = DateTime.Now.AddDays(10);
            DateTime diaSeguinteAoVencimento = DateTime.Now.AddDays(11);

            Fornecedor fornecedor = fornecedorService.ObterPorEmail(email1);
            fornecedor.DataAlteracao = diaVencimento;

            // desativa um dos fornecedores para confirmar que ele não será retornado
            fornecedor = fornecedorService.ObterPorEmail(email2);
            fornecedor.DataAlteracao = diaVencimento;
            fornecedor.Status = Status.Inativo;

            fornecedor = fornecedorService.ObterPorEmail(email3);
            fornecedor.DataAlteracao = diaSeguinteAoVencimento;

            fornecedor = fornecedorService.ObterPorEmail(email4);
            fornecedor.DataAlteracao = diaSeguinteAoVencimento;

            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresPorDataVencimento(diaVencimento);

            Assert.IsTrue(fornecedores.Count == 1, "Verifico que apenas 1 fornecedor é retornado.");
        }

        [Test]
        public void ObterFornecedoresQueNaoEfetuaram_O_Pagamento()
        {
            baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email2, idCidadeRioDeJaneiro, idEletricista);
            baseFornecedor.InserirFornecedor(email3, idCidadeSaoPaulo, idBoxVidrosEspelhos);
            //este fornecedor não deve ser retornado
            baseFornecedor.InserirFornecedor(email4, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
            Fornecedor fornecedor = fornecedorService.ObterPorEmail(email4);
            fornecedor.Status = Status.Inativo;
            fornecedor.DataAlteracao = DateTime.Now.AddDays(-2);

            fornecedor = fornecedorService.ObterPorEmail(email1);
            fornecedor.DataAlteracao = DateTime.Now.AddDays(-4);

            IList<Fornecedor> fornecedoresQueNaoPagaram = fornecedorService.ObterFornecedoresQueNaoPagaram(2);
            Assert.IsTrue(fornecedoresQueNaoPagaram.Count == 1, "Verifico que somente 1 fornecedor é retornado.");
        }

        [Test]
        public void AlterarFornecedor()
        {
            //Dado tenho 1 fornecedor da cidade do Rio de Janeiro na categoria Academias

            baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);

            //Quando Altero:
            //              data vencimento do fornecedor
            //              website
            //              descrição
            string descricaoEsperada = "Empresa com mais de 5 anos de experiência no mercado nacional";
            Fornecedor fornecedor = fornecedorService.ObterPorEmail(email1);
            fornecedor.DataAlteracao = DateTime.Now.AddDays(2);
            fornecedor.Descricao = descricaoEsperada;
            fornecedor.WebSite = "www.sitealterado.com.br";

            fornecedorService.Alterar(fornecedor);

            //Entao verifico que:
            //                  data de vencimento foi alterada
            //                  webiste é igual www.sitealterado.com.br
            //                 descricao é igual Empresa com mais de 5 anos de experiência no mercado nacional
            Assert.IsTrue(fornecedor.DataAlteracao.DayOfYear == DateTime.Now.AddDays(2).DayOfYear);
            Assert.AreEqual("www.sitealterado.com.br", fornecedor.WebSite);
            Assert.AreEqual(descricaoEsperada, fornecedor.Descricao);
        }

        [Test]
        public void ObterFornecedoresComStatusAtivo()
        {
            //Dado que insiro 4 fornecedores 
            baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email2, idCidadeRioDeJaneiro, idEletricista);
            baseFornecedor.InserirFornecedor(email3, idCidadeSaoPaulo, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email4, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);

            //Quando altero o status do fornecedor Email4 para Inativo
            Fornecedor fornecedor = fornecedorService.ObterPorEmail(email4);
            fornecedor.Status = Status.Inativo;

            //Então verifico que:
            //                   3 fornecedores são retornados

            IList<Fornecedor> fornecedoresAtivos = fornecedorService.ObterFornecedoresAtivos();

            Assert.IsTrue(fornecedoresAtivos.Count == 3);
        }

        [Test]
        public void ObterFornecedorPorNome()
        {
            //Dado que insiro 4 fornecedores
            //Quando Busco o fornecedor chamado renatoadsumus
            //Então verifico que:
            //                  somente fornecedor é retornado
            baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email2, idCidadeRioDeJaneiro, idEletricista);
            baseFornecedor.InserirFornecedor(email3, idCidadeSaoPaulo, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email4, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);

            Fornecedor fornecedor = fornecedorService.ObterPorNome("Fornecedor -SP");

            Assert.IsTrue(fornecedor != null);
        }

        [Test]
        public void ObterFornecedoresPorData()
        {
            //Dado que tenho 4 fornecedores sendo que um com data de cadastro dia atual -2 e outro dia atual menos -3
            //Então verifico que somente 2 fornecedores são retornados
            baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email2, idCidadeRioDeJaneiro, idEletricista);
            baseFornecedor.InserirFornecedor(email3, idCidadeSaoPaulo, idBoxVidrosEspelhos);
            baseFornecedor.InserirFornecedor(email4, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);

            Fornecedor fornecedor = fornecedorService.ObterPorEmail(email1);
            fornecedor.DataCadastro = DateTime.Now.AddDays(-2);

            fornecedor = fornecedorService.ObterPorEmail(email3);
            fornecedor.DataCadastro = DateTime.Now.AddDays(-3);

            DateTime dataFim = new DateTime(DateTime.Now.Year, DateTime.Now.AddDays(-2).Month, DateTime.Now.AddDays(-2).Day, 23, 59, 59);

            DateTime dataIncio = new DateTime(DateTime.Now.Year, DateTime.Now.AddDays(-8).Month, DateTime.Now.AddDays(-8).Day, 00, 00, 00);

            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresPorIntervaloDeData(dataIncio, DateTime.Now.AddDays(-2));

            Assert.IsTrue(fornecedores.Count == 2);
        }

        [Test]
        public void CalcularMensalidadeDeUmaCidadeComPeso1Outra1_5ValorCategoriaEh2RetornaValor4()
        {
            double valorEsperado = 5.0;
            IList<Cidade> cidadesAtuacao = new List<Cidade>();
            IList<Categoria> categoriasAtuacao = new List<Categoria>();

            Cidade cidadePeso1_5 = new Cidade();
            cidadePeso1_5.Peso = 1.5;
            cidadesAtuacao.Add(cidadePeso1_5);

            Cidade cidadePeso1 = new Cidade();
            cidadePeso1.Peso = 1;
            cidadesAtuacao.Add(cidadePeso1);

            Categoria categoria = new Categoria();
            categoria.Valor = 2;
            categoriasAtuacao.Add(categoria);

            double valorAtual = fornecedorService.CalcularValorMensalidade(cidadesAtuacao, categoriasAtuacao);

            Assert.AreEqual(valorEsperado, valorAtual);
        }

        [Test]
        public void AlterarPrioridadesDasCategoriasDoFornecedor()
        {
            //Dado tenho 1 fornecedor da cidade do Rio de Janeiro na categoria Academias

            baseFornecedor.InserirFornecedor(email1, idCidadeRioDeJaneiro, idBoxVidrosEspelhos);

            //Quando Altero a prioridade das categorias

            Fornecedor fornecedor = fornecedorService.ObterPorEmail(email1);

            int prioridade = 0;

            foreach (Categoria item in fornecedor.SubCategorias)
            {
                prioridade = prioridade + 1;
                CategoriaPrioridade categoriaPrioridade = new CategoriaPrioridade(); ;
                categoriaPrioridade.Prioridade = prioridade;
                categoriaPrioridade.IdCategoria = item;
                categoriaPrioridade.Fornecedor = fornecedor;
                fornecedorCategoriaService.Inserir(categoriaPrioridade);
            }                       
        }
    }
}



