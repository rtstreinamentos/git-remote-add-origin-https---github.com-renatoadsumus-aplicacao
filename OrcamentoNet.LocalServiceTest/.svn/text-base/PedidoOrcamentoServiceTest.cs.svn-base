using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using NHibernate.Burrow;
using NUnit.Framework;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.LocalServiceTest
{
    public class PedidoOrcamentoServiceTest
    {
        private StandardKernel injectionService;

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

        Categoria categoria;
        IList<Categoria> categorias;
        Fornecedor fornecedorRJ;
        Fornecedor fornecedorDuqueCaxias;
        Fornecedor fornecedorSP;
        Fornecedor fornecedorSantoAndre;
        int idBuffetJapones = 54;
        int idAnimais = 7;
        int idRioDeJaneiro = 6005;
        int idSaoPaulo = 6072;
        BasePedidoOrcamento basePedidoOrcamento;

        public void Inicializar()
        {
            injectionService = new StandardKernel(new CustomModule());
            injectionService.Inject(this);
        }

        [SetUp]
        public void Setup()
        {
            Inicializar();
            //Preparando Base de Dados
            BaseDados.BaseDados baseDados = new BaseDados.BaseDados();
            basePedidoOrcamento = new BasePedidoOrcamento(pedidoOrcamentoService);
            categorias = new List<Categoria>();
            baseDados.ExcluirDados();

            PrepararTest();
        }

        [TearDown]
        public void TearDown()
        {
            new BurrowFramework().CloseWorkSpace();
        }

        [Test]
        public void AutorizarAcesso()
        {
            PedidoOrcamento pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categoriaService.Obter(idBuffetJapones, false), cidadeService.Obter(6072));

            Assert.IsTrue(pedidoOrcamento.Id > 0, "Verifica se criou pedido de orçamento com sucesso.");

            Assert.IsTrue(pedidoOrcamentoService.AutorizarAcesso(pedidoOrcamento.Id, pedidoOrcamento.Email), "O autor do pedido pode acessar.");
            Assert.IsFalse(pedidoOrcamentoService.AutorizarAcesso(pedidoOrcamento.Id, pedidoOrcamento.Email + "string_diferente"), "Pessoas que não sejam o autor do pedido não podem acessar.");

            Assert.AreSame(pedidoOrcamento, pedidoOrcamentoService.ObterPedidoOrcamentoPorEmailId(pedidoOrcamento.Email, pedidoOrcamento.Id), "Verifico que o pedido de orçamento gravado está correto.");
        }
        [Ignore]
        public void C_ConsultarPedidosOrcamentoExistentesParaUmFornecedor()
        {
            //PedidoOrcamento pedidoOrcamento = IncluirPedidoOrcamentoValido(categoria, comprador, 6005);

            //IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorSubCategoria(fornecedorRJ.SubCategorias);
            //Assert.IsTrue(pedidosOrcamento.Count == 1);
        }

        [Ignore]
        public void D_RetornarTodosPedidosOrcamentoParaUmaDataValidaPorCategoria_e_Cidades_de_Atuacao_do_Fornecedor()
        {
            //Dado que tenho os seguintes pedidos
            //                  02 Rio de Janeiro com a data atual
            //                  01 Rio de Janeiro com a data de dois dias atrás
            //                  01
            //Então verifico que existem 02 pedidos do Rio de Janeiro com a data atual

            //IncluirPedidoOrcamentoValido(categoria, comprador, 6005);
            //IncluirPedidoOrcamentoValido(categoria, comprador, 6005);
            //IncluirPedidoOrcamentoValido(categoria, comprador, 1);

            //PedidoOrcamento pedidoForaData = IncluirPedidoOrcamentoValido(categoria, 6005);
            //pedidoForaData.Data = DateTime.Today.AddDays(-2);

            //IList<Categoria> subCategorias = categoriaService.ObterSubCategorias();
            //IList<Cidade> cidades = cidadeService.ObterCidades(OrcamentoNet.Entity.Enum.UF.RJ);

            //IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorSubCategoriaPorDataCriacao(subCategorias, DateTime.Now, cidades);

            //Assert.IsTrue(subCategorias.Count > 0);
            //Assert.IsTrue(pedidosOrcamento.Count == 2);
        }

        [Test]
        public void CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro()
        {
            IList<Categoria> categorias = new List<Categoria>();
            categorias.Add(categoriaService.Obter(idBuffetJapones, false));

            PedidoOrcamento pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categorias[0], cidadeService.Obter(6005));
            Assert.IsTrue(pedidoOrcamento.Id > 0, "Verifica se criou pedido de orçamento com sucesso.");

            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresParaUmPedidoDeOrcamento(pedidoOrcamento);

            Assert.IsTrue(fornecedores.Count == 1);

        }

        [Test]
        public void CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeSaoPaulo()
        {
            Categoria categoriaBuffetJapones = categoriaService.Obter(idBuffetJapones, false);
            categorias.Add(categoriaBuffetJapones);
            PedidoOrcamento pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categorias[0], cidadeService.Obter(6072));
            Assert.IsTrue(pedidoOrcamento.Id > 0, "Verifica se criou pedido de orçamento com sucesso.");

            IList<Fornecedor> fornecedores = fornecedorService.ObterFornecedoresParaUmPedidoDeOrcamento(pedidoOrcamento);

            Assert.IsTrue(fornecedores.Count == 1);
        }


        [Test]
        public void RetornarUltimosPedidosOrcamentos()
        {
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);

            IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterUltimosPedidosOrcamento(2, String.Empty);

            Assert.IsTrue(pedidosOrcamentos.Count == 2);
        }

        [Test]
        public void RetornarUltimosPedidosOrcamentosPorCategoria()
        {
            this.categoria = categoriaService.Obter(idBuffetJapones, false);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);


            this.categoria = categoriaService.Obter(idAnimais, false);

            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);

            IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterUltimosPedidosOrcamentoPorCategoriaOuTema(2, idBuffetJapones, String.Empty);

            Assert.IsTrue(pedidosOrcamentos.Count == 2);
        }

        [Test]
        public void RetornarUltimosPedidosOrcamentosPorCategoria_e_PorCidade()
        {
            this.categoria = categoriaService.Obter(idBuffetJapones, false);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);

            this.categoria = categoriaService.Obter(idAnimais, false);

            IncluirPedidoOrcamentoValido(categoria, 4328);

            IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterUltimosPedidosOrcamentoPorCategoriaPorCidadeOuEstado(2, idAnimais, 4328, String.Empty);

            Assert.IsTrue(pedidosOrcamentos.Count == 1);
        }

        [Test]
        public void RetornarPedidosOrcamentoUltimaHora()
        {

            //criar pedidos de orçamento
            this.CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro();
            this.CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro();
            this.CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro();
            this.CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro();

            DateTime dataHoraExecucaoServico = DateTime.Parse("2011/01/01 14:00:00");

            //Alterar a data do primeiro pedido para ontem (mas fica com a mesma hora)
            PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Obter(1);
            pedidoOrcamento.Data = dataHoraExecucaoServico.AddDays(-1);

            //Alterar a hora do segundo pedido para duas horas atrás (mas fica com o mesmo dia)
            pedidoOrcamento = pedidoOrcamentoService.Obter(2);
            pedidoOrcamento.Data = dataHoraExecucaoServico.AddHours(-2);

            //Alterar a hora do terceiro pedido para 1 hora atrás (mas fica com o mesmo dia)
            pedidoOrcamento = pedidoOrcamentoService.Obter(3);
            pedidoOrcamento.Data = dataHoraExecucaoServico.AddHours(-1);
            pedidoOrcamento.Status = PedidoStatus.EmailValidado;

            //Alterar a hora do quarto pedido para 1 hora atrás (mas fica com o mesmo dia)
            pedidoOrcamento = pedidoOrcamentoService.Obter(4);
            pedidoOrcamento.Data = dataHoraExecucaoServico.AddHours(-1);
            pedidoOrcamento.Status = PedidoStatus.EmailValidado;

            IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterPedidosOrcamentoUltimaHora(dataHoraExecucaoServico);

            Assert.IsTrue(pedidosOrcamentos.Count == 2, "Verifica tamanho da lista retorno");
            Assert.IsTrue(pedidosOrcamentos[0].Data.DayOfYear == dataHoraExecucaoServico.DayOfYear, "Verifica se a data do primeiro pedido da lista de retorno é a data da execução do serviço");
            Assert.IsTrue(pedidosOrcamentos[0].Data.Hour == dataHoraExecucaoServico.AddHours(-1).Hour, "Verifica se a hora do primeiro pedido da lista de retorno é igual a 1 hora antes da hora da execução do serviço");
        }

        [Test]
        public void RetornarPedidosOrcamentoUltimaHoraQuandoForMeiaNoite()
        {

            //criar pedidos de orçamento
            this.CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro();
            this.CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro();
            this.CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro();

            DateTime dataHoraExecucaoServico = DateTime.Parse("2011/01/01 00:00:00");

            //Alterar a data do primeiro pedido para ontem (mas fica com a mesma hora)
            PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Obter(1);
            pedidoOrcamento.Data = dataHoraExecucaoServico.AddDays(-1);

            //Alterar a hora do segundo pedido para duas horas atrás (fica com a data 2010/12/31)
            pedidoOrcamento = pedidoOrcamentoService.Obter(2);
            pedidoOrcamento.Data = dataHoraExecucaoServico.AddHours(-2);

            //Alterar a hora do terceiro pedido para 1 hora atrás (fica com o a data 2010/12/31)
            pedidoOrcamento = pedidoOrcamentoService.Obter(2);
            pedidoOrcamento.Data = dataHoraExecucaoServico.AddHours(-1);
            pedidoOrcamento.Status = PedidoStatus.EmailValidado;

            IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterPedidosOrcamentoUltimaHora(dataHoraExecucaoServico);

            Assert.IsTrue(pedidosOrcamentos.Count == 1, "Verifica tamanho da lista retorno");
            Assert.IsTrue(pedidosOrcamentos[0].Data.DayOfYear == dataHoraExecucaoServico.AddDays(-1).DayOfYear, "Verifica se a data do primeiro pedido da lista de retorno é a 2010/12/31");
            Assert.IsTrue(pedidosOrcamentos[0].Data.Hour == 23, "Verifica se a hora do primeiro pedido da lista de retorno é igual a 23");
        }

        [Test]
        public void RetornarPedidosOrcamentoPorDataCriacaoComEmailValido()
        {

            //criar tres pedidos de orçamento
            this.CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro();
            this.CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro();
            this.CriarPedidoPedidoOrcamentoParaFornecedoresDaCidadeRioDeJaneiro();


            //Alterar a data do primeiro pedido para ontem e coloca os dois ultimos pedidos com email valido
            PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Obter(1);
            pedidoOrcamento.Data = DateTime.Now.AddDays(-1);

            pedidoOrcamento = pedidoOrcamentoService.Obter(2);
            pedidoOrcamento.Status = PedidoStatus.EmailValidado;

            pedidoOrcamento = pedidoOrcamentoService.Obter(3);
            pedidoOrcamento.Status = PedidoStatus.EmailValidado;

            IList<PedidoOrcamento> pedidosOrcamentos = pedidoOrcamentoService.ObterPedidosOrcamentoPorData(DateTime.Now);

            Assert.IsTrue(pedidosOrcamentos.Count == 2, "Verifica tamanho da lista retorno");
            Assert.IsTrue(pedidosOrcamentos[1].Data.DayOfYear == DateTime.Now.DayOfYear, "Verifica se a data do primeiro pedido da lista de retorno é hoje");            
        }

        [Test]
        public void RetornarTodosPedidosOrcamentoParaUmaDataUmaDeAtualizacao()
        {
            //Dado que tenho os seguintes pedidos
            //                  02 Rio de Janeiro com a data atual
            //                  01 Rio de Janeiro com a data de um dia atrás
            //                  01 São Paulo com a data atual
            //Então verifico que existem 01 pedidos do Rio de Janeiro com a data atual
            this.categoria = categoriaService.Obter(idBuffetJapones, false);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);

            PedidoOrcamento pedidoForaData = IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);
            pedidoForaData.DataAlteracao = DateTime.Today.AddDays(-1);
            pedidoForaData.StatusPedidoComprador = PedidoCompradorStatus.NaoRecebiOrcamento;

            IncluirPedidoOrcamentoValido(categoria, 6072);

            IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorDataAlteracao(DateTime.Now.AddDays(-1));

            Assert.IsTrue(pedidosOrcamento.Count == 1);
        }

        [Test]
        public void IncluirPedidoOrcamento()
        {
            IList<Fornecedor> forncedores = new List<Fornecedor>();
            forncedores.Add(this.fornecedorSP);
            forncedores.Add(this.fornecedorSantoAndre);

            this.categoria = categoriaService.Obter(123, false);
            categorias.Add(categoria);

            Cidade cidade = cidadeService.Obter(6005);

            PedidoOrcamento pedidoOrcamento = new PedidoOrcamento();
            pedidoOrcamento.Categorias = categorias;
            pedidoOrcamento.Fornecedores = forncedores;
            pedidoOrcamento.Email = "renatoadsumus@gmail.com";
            pedidoOrcamento.Cidade = cidade;
            pedidoOrcamento.Titulo = "Novo Pedido";
            pedidoOrcamento.Telefone = "21-2222-2222";
            pedidoOrcamento.NomeComprador = "Nome Comprador";
            pedidoOrcamento.Observacao = "Festa de anos a noite";

            Assert.NotNull(pedidoOrcamentoService.Inserir(pedidoOrcamento));
        }

        [Test]
        public void CompradorComDoisPedidos1NoRJ1EmSPRetornaOPedidoDeSP()
        {
            string emailComprador = "renatoadsumus@gmail.com";
            string cidadeEsperada = "São Paulo Zona Oeste - Lapa, Pinheiros e adjacências";

            this.categoria = categoriaService.Obter(idBuffetJapones, false);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);
            IncluirPedidoOrcamentoValido(categoria, idSaoPaulo);
            PedidoOrcamento pedidoAtual = pedidoOrcamentoService.ObterUltimoPedidoDoEmail(emailComprador);

            Assert.AreEqual(cidadeEsperada, pedidoAtual.Cidade.Nome);
        }

        [Test]
        public void SistemaPossui3PedidosDoMesmoDia1ComEmailValido2ComEmailsNaoValidadosRetorna1Pedido()
        {
            string emailComprador = "renatoadsumus@gmail.com";

            this.categoria = categoriaService.Obter(idBuffetJapones, false);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);
            IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);
            IncluirPedidoOrcamentoValido(categoria, idSaoPaulo);

            PedidoOrcamento ultimoPedido = pedidoOrcamentoService.ObterUltimoPedidoDoEmail(emailComprador);
            ultimoPedido.Status = PedidoStatus.EmailValidado;

            IList<PedidoOrcamento> pedidosAprovadosDoDiaAtual = pedidoOrcamentoService.ObterPedidosOrcamentoPorDataStatus(DateTime.Now, PedidoStatus.EmailValidado);

            Assert.IsTrue(pedidosAprovadosDoDiaAtual.Count == 1);
        }

        [Test]
        public void CompradorFazUmPedidoDeBuffetJaponesERecebeUmEmailDeAutoRespostaDoFornecedorDeRJ()
        {
            this.categoria = categoriaService.Obter(idBuffetJapones, false);
            PedidoOrcamento pedidoBuffetJapones = IncluirPedidoOrcamentoValido(categoria, idRioDeJaneiro);

            pedidoOrcamentoService.NotificarFornecedorPorEmailNovoPedidoOrcamento(pedidoBuffetJapones);
        }

        [Test]
        public void CompradorFazUmPedidoDeBuffetJaponesENaoRecebeUmEmailDeAutoRespostaDoFornecedorDeSP()
        {
            this.categoria = categoriaService.Obter(idBuffetJapones, false);
            PedidoOrcamento pedidoBuffetJapones = IncluirPedidoOrcamentoValido(categoria, idSaoPaulo);

            pedidoOrcamentoService.NotificarFornecedorPorEmailNovoPedidoOrcamento(pedidoBuffetJapones);
        }

        [Test]
        public void CompradorSelecionaUmFornecedorDeBuffetJaponesParaReceberOrcamento()
        {
            string emailFornecedorBuffetJapones = "renatoadsumus@gmail.com";
            this.categoria = categoriaService.Obter(idBuffetJapones, false);
            Cidade cidade = cidadeService.Obter(idRioDeJaneiro);

            Fornecedor fornecedorBuffetJapones = fornecedorService.ObterPorEmail(emailFornecedorBuffetJapones);

            PedidoOrcamento pedidoBuffetJapones = basePedidoOrcamento.IncluirPedidoOrcamentoValidoComFornecedoresSelecionados(categoria, cidade, fornecedorBuffetJapones);

            pedidoOrcamentoService.NotificarFornecedorPorEmailNovoPedidoOrcamento(pedidoBuffetJapones);
        }       

        #region Métodos Privados
        private PedidoOrcamento IncluirPedidoOrcamentoValido(Categoria categoria, int idCidade)
        {
            BasePedidoOrcamento basePedidoOrcamento = new BasePedidoOrcamento(pedidoOrcamentoService);

            Cidade cidade = cidadeService.Obter(idCidade);

            return basePedidoOrcamento.IncluirPedidoOrcamentoValido(categoria, cidade);
        }

        private void PrepararTest()
        {
            BaseFornecedor baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
            List<int> cidades = new List<int>();
            cidades.Add(idRioDeJaneiro);

            List<int> categorias = new List<int>();
            categorias.Add(idBuffetJapones);
            this.fornecedorRJ = baseFornecedor.InserirFornecedorClienteComAutoResposta(cidades, "renatoadsumus@gmail.com", categorias);

            cidades = new List<int>();
            cidades.Add(6072);
            this.fornecedorSP = baseFornecedor.IncluirFornecedorValido(cidades, "renato@rcmsolucoes.com", categorias);

            cidades = new List<int>();
            cidades.Add(6014);
            this.fornecedorDuqueCaxias = baseFornecedor.IncluirFornecedorValido(cidades, "emailParaExclusao@orcamentos.net.br", categorias);

            cidades = new List<int>();
            cidades.Add(5185);
            this.fornecedorSantoAndre = baseFornecedor.IncluirFornecedorValido(cidades, "fabriciofuji@yahoo.com.br", categorias);


        }
        #endregion
    }
}
