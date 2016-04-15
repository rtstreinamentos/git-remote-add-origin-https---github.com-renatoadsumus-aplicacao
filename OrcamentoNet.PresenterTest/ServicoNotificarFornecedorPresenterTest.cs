using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using NHibernate.Burrow;
using NUnit.Framework;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.LocalServiceTest;
using OrcamentoNet.LocalServiceTest.BaseDados;
using OrcamentoNet.ILocalService;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.PresenterTest
{
    [TestFixture]
    public class ServicoNotificarFornecedorPresenterTest
    {
        private StandardKernel injectionService;
        private Categoria categoria;
        private ServicoNotificarFornecedorPresenter presenter;
        BasePedidoOrcamento basePedidoOrcamento;

        private void PrepararTest()
        {
        }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

        public void Inicializar()
        {
            injectionService = new StandardKernel(new CustomModule());
            injectionService.Inject(this);
        }

        [SetUp]
        public void SetUp()
        {
            basePedidoOrcamento = new BasePedidoOrcamento(pedidoOrcamentoService);
            BaseDados baseDados = new BaseDados();
            baseDados.ExcluirDados();
            Inicializar();
            presenter = new ServicoNotificarFornecedorPresenter();
            presenter.InicializarServico();
            PrepararTest();
        }

        [TearDown]
        public void TearDown()
        {
            new BurrowFramework().CloseWorkSpace();
        }

        /// <summary>
        /// Dado que cadastrei dois novos fornecedores:
        /// - um com data de ontem
        /// - outro com data de 2 dias atrás
        /// - ambos com data de renovação para daqui a 90 dias
        /// 
        /// Quando o informativo para novos fornecedores é enviado
        /// 
        /// Então:
        /// - somente 1 informativo deve ser enviada (para o primeiro fornecedor
        /// - o período de cortesia é indicado no e-mail
        /// 
        /// Verificar no e-mail orcamentos.net@gmail.com.
        /// </summary>
        [Test]
        public void EnviarEmailInformativoNovoFornecedorSucesso()
        {
            int idCidadeRioDeJaneiro = 3631;
            int idRamoAcademias = 2;
            string email1 = "fabriciofuji@yahoo.com.br";
            string email2 = "orcamentos.net@gmail.com";

            List<int> cidades = new List<int>();
            cidades.Add(idCidadeRioDeJaneiro);

            List<int> categorias = new List<int>();
            categorias.Add(idRamoAcademias);

            BaseFornecedor baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
            Fornecedor fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, email1, categorias);



            fornecedor.DataCadastro = DateTime.Now.AddDays(-2);
            fornecedor.DataAlteracao = DateTime.Now.AddDays(90);


            fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, email2, categorias);
            fornecedor.DataCadastro = DateTime.Now.AddDays(-1);
            fornecedor.DataAlteracao = DateTime.Now.AddDays(90);

            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresPorDataCriacao(DateTime.Now.AddDays(-1));
            Assert.IsTrue(fornecedores.Count == 1, "Verifico que somente 1 fornecedor é retornado");
            Assert.IsTrue(fornecedores[0].Email == email2, "Verifico que o fornecedor correto é retornado");

            presenter.EnviarEmailInformativoNovosFornecedores();
        }

        /// <summary>
        /// Dado que cadastrei dois novos fornecedores:
        /// - um com data de vencimento de 2 dias atrás
        /// - outro com data de vencimento de 7 dias atrás
        /// 
        /// Quando o email de pagamento não identificado é enviado
        /// 
        /// Então:
        /// - somente 1 email deve ser enviado (para o segundo fornecedor)
        /// 
        /// Verificar no e-mail orcamentos.net@gmail.com.
        /// </summary>
        [Test]
        public void EnviarEmailPagamentoNaoIdentificadoSucesso()
        {
            int idCidadeRioDeJaneiro = 3631;
            int idRamoAcademias = 2;
            string email1 = "fabriciofuji@yahoo.com.br";
            string email2 = "orcamentos.net@gmail.com";

            List<int> cidades = new List<int>();
            cidades.Add(idCidadeRioDeJaneiro);

            List<int> categorias = new List<int>();
            categorias.Add(idRamoAcademias);

            BaseFornecedor baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
            Fornecedor fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, email1, categorias);
            fornecedor.DataAlteracao = DateTime.Now.AddDays(-2);



            fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, email2, categorias);
            fornecedor.DataAlteracao = DateTime.Now.AddDays(-7);

            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresQueNaoPagaram(7);
            Assert.IsTrue(fornecedores.Count == 1, "Verifico que somente 1 fornecedor é retornado");
            Assert.IsTrue(fornecedores[0].Email == email2, "Verifico que o fornecedor correto é retornado");

            presenter.EnviarEmailPagamentoNaoIdentificado();
        }

        /// <summary>
        /// Dado que criei três pedidos de orçamento:
        /// - dois com data de 10 dias atrás
        /// - outro com data de 9 dias atrás
        /// 
        /// Quando a pesquisa de satisfação é enviada
        /// 
        /// Então somente 1 pesquisa de satisfação deve ser enviada. Verificar no e-mail orcamentos.net@gmail.com.
        /// </summary>
        [Test]
        public void EnviarEmailPesquisaSatisfacaoCompradorSucesso()
        {
            Fornecedor comprador = new Fornecedor();
            comprador.Nome = "Comprador para pesquisa de satisfação - 10 dias";
            comprador.Email = "orcamentos.net@gmail.com";
            comprador.Telefone = "21-226776912";
            categoria = categoriaService.Obter(54, false);

            IList<Categoria> categorias = new List<Categoria>();
            categorias.Add(categoria);

            string camposInvalidos = String.Empty;
            PedidoOrcamento pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categorias[0], cidadeService.Obter(3631));
            Assert.IsTrue(pedidoOrcamento.Id == 1, "Verifica se criou primeiro pedido de orçamento com sucesso.");
            pedidoOrcamento.Data = DateTime.Now.AddDays(-10);

            pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categorias[0], cidadeService.Obter(3631));
            Assert.IsTrue(pedidoOrcamento.Id == 2, "Verifica se criou segundo pedido de orçamento com sucesso.");
            pedidoOrcamento.Data = DateTime.Now.AddDays(-10);

            comprador.Nome = "Comprador para pesquisa de satisfação - 9 dias";
            pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categorias[0], cidadeService.Obter(3631));
            Assert.IsTrue(pedidoOrcamento.Id == 3, "Verifica se criou terceiro pedido de orçamento com sucesso.");
            pedidoOrcamento.Data = DateTime.Now.AddDays(-9);

            presenter.EnviarEmailPesquisaSatisfacaoComprador();
        }

        /// <summary>
        /// Dado que cadastrei quatro novos fornecedores:
        /// - um com data de ontem
        /// - outro com data de 7 dias atrás
        /// - outro com data de 45 dias atrás
        /// - outro com data de 120 dias atrás
        /// 
        /// Quando a pesquisa de satisfação para novos fornecedores é enviada
        /// 
        /// Então:
        /// - 3 pesquisas devem ser enviadas (só o primeiro fornecedor NÃO recebe)
        /// 
        /// Verificar no e-mail orcamentos.net@gmail.com.
        /// </summary>
        [Test]
        public void EnviarEmailPesquisaSatisfacaoFornecedorSucesso()
        {
            int idCidadeRioDeJaneiro = 3631;
            int idRamoAcademias = 2;
            string email1 = "buffet@voceconhece.com";
            string email2 = "orcamentos.net@gmail.com";
            string email3 = "fabriciofuji@gmail.com";
            string email4 = "fabriciofuji@yahoo.com.br";

            List<int> cidades = new List<int>();
            cidades.Add(idCidadeRioDeJaneiro);

            List<int> categorias = new List<int>();
            categorias.Add(idRamoAcademias);

            BaseFornecedor baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
            Fornecedor fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, email1, categorias);

            fornecedor.DataCadastro = DateTime.Now.AddDays(-7);


            fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, email3, categorias);

            fornecedor.DataCadastro = DateTime.Now.AddDays(-45);

            fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, email4, categorias);           
            fornecedor.DataCadastro = DateTime.Now.AddDays(-120);

            DateTime dataBasePesquisa = DateTime.Now.AddDays(-7);

            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresPorDataCriacao(dataBasePesquisa);
            Assert.IsTrue(fornecedores.Count == 1, "Verifico que somente 1 fornecedor é retornado");
            Assert.IsTrue(fornecedores[0].Email == email2, "Verifico que o fornecedor correto é retornado");
            presenter.EnviarEmailPesquisaSatisfacaoFornecedor(dataBasePesquisa);

            dataBasePesquisa = DateTime.Now.AddDays(-45);
            fornecedores = fornecedorService.ObterFornecedoresPorDataCriacao(dataBasePesquisa);
            Assert.IsTrue(fornecedores.Count == 1, "Verifico que somente 1 fornecedor é retornado");
            Assert.IsTrue(fornecedores[0].Email == email3, "Verifico que o fornecedor correto é retornado");
            presenter.EnviarEmailPesquisaSatisfacaoFornecedor(dataBasePesquisa);

            dataBasePesquisa = DateTime.Now.AddDays(-120);
            fornecedores = fornecedorService.ObterFornecedoresPorDataCriacao(dataBasePesquisa);
            Assert.IsTrue(fornecedores.Count == 1, "Verifico que somente 1 fornecedor é retornado");
            Assert.IsTrue(fornecedores[0].Email == email4, "Verifico que o fornecedor correto é retornado");
            presenter.EnviarEmailPesquisaSatisfacaoFornecedor(dataBasePesquisa);
        }

        /// <summary>
        /// Dado que cadastrei dois novos fornecedores:
        /// - um com data de vencimento daqui a 10 dias
        /// - outro com data de vencimento daqui a 7 dias
        /// 
        /// Quando o lembrete de vencimento para fornecedores é enviado
        /// 
        /// Então:
        /// - somente 1 lembrete deve ser enviado (para o segundo fornecedor)
        /// 
        /// Verificar no e-mail orcamentos.net@gmail.com.
        /// </summary>
        [Test]
        public void EnviarEmailLembreteVencimentoFornecedorSucesso()
        {
            int idCidadeRioDeJaneiro = 3631;
            int idRamoAcademias = 2;
            string email1 = "fabriciofuji@yahoo.com.br";
            string email2 = "orcamentos.net@gmail.com";

            List<int> cidades = new List<int>();
            cidades.Add(idCidadeRioDeJaneiro);

            List<int> categorias = new List<int>();
            categorias.Add(idRamoAcademias);

            BaseFornecedor baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
            Fornecedor fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, email1, categorias);

            fornecedor.DataAlteracao = DateTime.Now.AddDays(10);

            fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, email2, categorias);

            fornecedor.DataAlteracao = DateTime.Now.AddDays(7);

            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresPorDataVencimento(DateTime.Now.AddDays(7));
            Assert.IsTrue(fornecedores.Count == 1, "Verifico que somente 1 fornecedor é retornado");
            Assert.IsTrue(fornecedores[0].Email == email2, "Verifico que o fornecedor correto é retornado");

            presenter.EnviarEmailLembreteVencimentoFornecedor(DateTime.Now.AddDays(7));
        }

        /// <summary>
        /// Dado que cadastrei dois novos fornecedores:
        /// - um de de buffet e buffet japonês para Aperibé (RJ)
        /// - outro de academias, das cidades de São Paulo e de Aperibé
        /// 
        /// Dado que cadastrei quatro novos pedidos de orçamento:
        /// - um de buffet e buffet japonês para a cidade do Rio de Janeiro
        /// - outro também de buffet japonês para a cidade do Rio de Janeiro
        /// - outro de buffet japonês para a cidade de Aguaí (SP)
        /// 
        /// Então na próxima rodada do serviço:
        /// - o fornecedor de buffet e buffet japonês para a cidade de Aperibé recebe os pedidos de orçamento do Rio de Janeiro 
        /// (somente 2 e-mails)
        /// - a administração recebe uma notificação de que os pedidos de buffet japonês para Aguaí 
        ///   e de buffet para Rio de Janeiro não possui fornecedores
        /// Verificar no e-mail orcamentos.net@gmail.com.
        /// 
        /// - os dois compradores recebem a confirmação de que seu pedido foi cadastrado com sucesso (apenas 1 vez cada)
        /// Verificar no e-mail fabriciofuji@yahoo.com.br e fabriciofuji@gmail.com.
        /// 
        /// - os dois compradores recebem o e-mail de cadastramento na newsletter (apenas 1 vez cada)
        /// Verificar no e-mail fabriciofuji@yahoo.com.br e fabriciofuji@gmail.com.
        ///
        /// - os quatro pedidos de orçamento são enviados para o histórico de cotações
        /// Verificar em http://preco.orcamentos.net.br/wp-admin/.
        /// </summary>
        //[Test]
        //public void EnviarIntegracoesEmailSucesso()
        //{
        //    /// Dado que cadastrei dois novos fornecedores:
        //    /// - um de buffet japonês para Aperibé (RJ)
        //    int idCidadeAperibe = 3566;
        //    int idRamoBuffetJapones = 54;
        //    int idRamoBuffet = 123;
        //    string emailFornecedor1 = "orcamentos.net@gmail.com";

        //    List<int> cidades = new List<int>();
        //    cidades.Add(idCidadeAperibe);

        //    List<int> categorias = new List<int>();
        //    categorias.Add(idRamoBuffetJapones);

        //    BaseFornecedor baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
        //    Fornecedor fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, emailFornecedor1, categorias);

        //    Cidade cidade = new Cidade();
        //    cidade = cidadeService.Obter(idCidadeAperibe);

        //    IList<Categoria> resultadoCategoria = new List<Categoria>();
        //    resultadoCategoria.Add(categoriaService.Obter(idRamoBuffetJapones, false));

        //    IList<Cidade> cidadesAtuacao = new List<Cidade>();
        //    cidadesAtuacao.Add(cidadeService.Obter(idCidadeAperibe));




        //    Assert.IsTrue(fornecedor.Id == 1, "Verifica que criou o primeiro fornecedor com sucesso");

        //    /// - outro de academias, das cidades de São Paulo e de Aperibé
        //    int idCidadeSaoPaulo = 5213;
        //    int idRamoAcademias = 2;
        //    resultadoCategoria = new List<Categoria>();
        //    resultadoCategoria.Add(categoriaService.Obter(idRamoAcademias, false));

        //    cidadesAtuacao = new List<Cidade>();
        //    cidadesAtuacao.Add(cidadeService.Obter(idCidadeSaoPaulo));
        //    cidadesAtuacao.Add(cidadeService.Obter(idCidadeAperibe));


        //    string emailFornecedor2 = "quem@voceconhece.com";
        //    fornecedor = baseFornecedor.IncluirFornecedorValido(cidades, emailFornecedor2, categorias);
        //    Assert.IsTrue(fornecedor.Id == 2, "Verifica que criou o segundo fornecedor com sucesso");

        //    /// Dado que cadastrei quatro novos pedidos de orçamento:
        //    /// - um de buffet e buffet japonês para a cidade do Rio de Janeiro
        //    int idCidadeRioDeJaneiro = 3631;
        //    string emailComprador1 = "fabriciofuji@yahoo.com.br";

        //    Fornecedor comprador = new Fornecedor();
        //    comprador.Nome = "Comprador do pedido de orçamento";
        //    comprador.Email = emailComprador1;
        //    comprador.Telefone = "99-99999999";
        //    categoria = categoriaService.Obter(idRamoBuffetJapones, false);

        //    IList<Categoria> categoriasOBJ = new List<Categoria>();
        //    categoriasOBJ.Add(categoria);

        //    string retorno = String.Empty;
        //    PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Inserir(comprador, categoriasOBJ, "observação", "título do pedido de orçamento que possui fornecedor", ref retorno, cidadeService.Obter(idCidadeRioDeJaneiro));
        //    pedidoOrcamento.Data = DateTime.Now.AddMinutes(-1);
        //    Assert.IsTrue(pedidoOrcamento.Id == 1, "Verifica que criou o primeiro pedido de orçamento com sucesso");
        //    categoria = categoriaService.Obter(idRamoBuffet, false);
        //    pedidoOrcamento = pedidoOrcamentoService.Inserir(comprador, categorias, "observação", "título do pedido de orçamento que possui fornecedor", ref retorno, cidadeService.Obter(idCidadeRioDeJaneiro));
        //    pedidoOrcamento.Data = DateTime.Now.AddMinutes(-1);
        //    Assert.IsTrue(pedidoOrcamento.Id == 2, "Verifica que criou o segundo pedido de orçamento com sucesso");

        //    /// - outro também de buffet japonês para a cidade do Rio de Janeiro
        //    categoria = categoriaService.Obter(idRamoBuffetJapones, false);
        //    pedidoOrcamento = pedidoOrcamentoService.Inserir(comprador, categorias, "observação", "título do pedido de orçamento diferente que possui fornecedor", ref retorno, cidadeService.Obter(idCidadeRioDeJaneiro));
        //    pedidoOrcamento.Data = DateTime.Now.AddMinutes(-1);
        //    Assert.IsTrue(pedidoOrcamento.Id == 3, "Verifica que criou o terceiro pedido de orçamento com sucesso");

        //    /// - outro de buffet japonês para a cidade de Aguaí
        //    int idCidadeAguai = 4651;
        //    string emailComprador2 = "fabriciofuji@gmail.com";
        //    comprador = new Fornecedor();
        //    comprador.Nome = "Comprador do pedido de orçamento que NÃO possui fornecedor";
        //    comprador.Email = emailComprador2;
        //    comprador.Telefone = "99-99999999";
        //    categoria = categoriaService.Obter(idRamoBuffetJapones, false);
        //    retorno = String.Empty;
        //    pedidoOrcamento = pedidoOrcamentoService.Inserir(comprador, categorias, "observação", "título do pedido de orçamento que NÃO possui fornecedor", ref retorno, cidadeService.Obter(idCidadeAguai));
        //    pedidoOrcamento.Data = DateTime.Now.AddMinutes(-1);
        //    Assert.IsTrue(pedidoOrcamento.Id == 4, "Verifica que criou o quarto pedido de orçamento com sucesso");

        //    presenter.EnviarIntegracoesEmail();
        //}

        /// <summary>
        /// Dado que criei três pedidos de orçamento:
        /// - dois duplicados
        /// - e um diferente
        /// 
        /// Quando a exclusão de pedidos de orçamento duplicados é executada
        /// 
        /// Então permanecem 2 pedidos de orçamento na base (1 duplicado é removido).
        /// 
        /// Este teste teve que ser dividido em 2 partes, devido ao lock de transação do NHibernate
        /// TODO: 13/12/2011 - não está funcionando, verificar (Fabrício)
        /// </summary>
        [Test]
        public void RemoverPedidosOrcamentoDuplicadosSucesso()
        {
            this.RemoverPedidosOrcamentoDuplicadosSucesso1();
            this.RemoverPedidosOrcamentoDuplicadosSucesso2();
        }
        private void RemoverPedidosOrcamentoDuplicadosSucesso1()
        {
            IList<Categoria> categorias = new List<Categoria>();
            categorias.Add(categoria);

            PedidoOrcamento pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categorias[0], cidadeService.Obter(3631));
            Assert.IsTrue(pedidoOrcamento.Id == 1, "Verifica se criou primeiro pedido de orçamento com sucesso.");

            pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categorias[0], cidadeService.Obter(3631));
            Assert.IsTrue(pedidoOrcamento.Id == 2, "Verifica se criou segundo pedido de orçamento com sucesso.");

            pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categorias[0], cidadeService.Obter(3631));
            Assert.IsTrue(pedidoOrcamento.Id == 3, "Verifica se criou terceiro pedido de orçamento com sucesso.");
        }
        private void RemoverPedidosOrcamentoDuplicadosSucesso2()
        {
            //presenter.RemoverPedidosOrcamentoDuplicados();

            IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorData(DateTime.Today);
            Assert.IsTrue(pedidosOrcamento.Count == 2, "Verifico que permanecem 2 pedidos de orçamento.");
            Assert.IsTrue(pedidosOrcamento[0].Id == 2, "Verifico que permanece o pedido de orçamento correto.");
            Assert.IsTrue(pedidosOrcamento[1].Id == 3, "Verifico que permanece o pedido de orçamento correto.");
        }

    }
}
