using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate.Burrow;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.LocalServiceTest
{
    [TestFixture]
    public class OpiniaoServiceTest
    {
        private StandardKernel injectionService;

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public IOpiniaoService opiniaoService { get; set; }

        BaseFornecedor baseFornecedor;
        Fornecedor fornecedorSP;

        [SetUp]
        public void Setup()
        {
            //Preparando Base de Dados
            BaseDados.BaseDados baseDados = new BaseDados.BaseDados();
            baseDados.ExcluirDados();

            this.injectionService = new StandardKernel(new CustomModule());
            this.injectionService.Inject(this);

            baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
        }

        [TearDown]
        public void TearDown()
        {
            new BurrowFramework().CloseWorkSpace();
        }

        private void InserirFornecedor()
        {
            int idSaoPaulo = 6072;
            int idBuffetJapones = 54;

            fornecedorSP = baseFornecedor.InserirFornecedor("renato@rcmsolucoes.com", idSaoPaulo, idBuffetJapones);
        }
        private void InserirOpiniao()
        {          

            Opiniao opiniao = new Opiniao();
            opiniao.Titulo = "Satistação na Qualidade";
            opiniao.Descricao = "Equipe super eficaz e eficiente";
            opiniao.Fornecedor = fornecedorSP;
            opiniao.Satisfacao = "Muito Satisfeita";
            opiniao.Nome = "Nome Crítico";
            opiniao.Email = "renato@rcmsolucoes.com";
            opiniaoService.Inserir(opiniao);
        }

        [Test]
        public void VisualizarTodasOpinioesDeUmFornecedor()
        {
            //Dado que entro na ficha técnica do Fornecedor renato@rcmsolucoes.com
            //Quando clico em vizualizar opiniões
            //Então verifico que:
            //                  Existe uma opinião cadastrada

            InserirFornecedor();
            InserirOpiniao();
            Opiniao opiniao = opiniaoService.Obter(1);
            opiniao.Status = 1;

            IList<Opiniao> opinioesDeFornecedor = opiniaoService.ObterPorFornecedor(1);
            Assert.IsTrue(opinioesDeFornecedor.Count == 1);
        }

        [Test]
        public void ObterTodasOpinioesDoDiaAnterior()
        {
            //Dado que o Fornecedor renato@rcmsolucoes.com possui 2 opiniões do mesmo dia
            InserirFornecedor();
            InserirOpiniao();
            InserirOpiniao();
        }
    }
}
