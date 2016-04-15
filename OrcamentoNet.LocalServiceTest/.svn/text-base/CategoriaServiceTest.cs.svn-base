using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using NHibernate.Burrow;
using NUnit.Framework;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.LocalServiceTest
{
    [TestFixture]
    public class CategoriaServiceTest
    {
        private StandardKernel injectionService;

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }


        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

        BaseFornecedor baseFornecedor;
        BasePedidoOrcamento basePedidoOrcamento;

        [SetUp]
        public void Setup()
        {

            //Preparando Base de Dados
            BaseDados.BaseDados baseDados = new BaseDados.BaseDados();
            // baseDados.ExcluirDados();

            injectionService = new StandardKernel(new CustomModule());
            injectionService.Inject(this);
            basePedidoOrcamento = new BasePedidoOrcamento(pedidoOrcamentoService);
            baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
        }

        [TearDown]
        public void TearDown()
        {
            new BurrowFramework().CloseWorkSpace();
        }

       
        [Test]
        public void GerarUrlParaSeoTest()
        {
            string urlParaSeo = String.Empty;
            string nomeCategoria = String.Empty;

            nomeCategoria = "Academia e Esportes";
            urlParaSeo = Common.UtilString.GerarUrlParaSeo(nomeCategoria);
            Assert.AreEqual("academia-esportes", urlParaSeo, "Verifico que as letras estão todas em minúsculas.");

            nomeCategoria = "Casa e Decoração";
            urlParaSeo = Common.UtilString.GerarUrlParaSeo(nomeCategoria);
            Assert.AreEqual("casa-decoracao", urlParaSeo, "Verifico que as letras acentuadas são removidas.");

            nomeCategoria = "Tapetes, Cortinas e Persianas";
            urlParaSeo = Common.UtilString.GerarUrlParaSeo(nomeCategoria);
            Assert.AreEqual("tapetes-cortinas-persianas", urlParaSeo, "Verifico que as vírgulas são removidas.");

            nomeCategoria = "DJ, Som, Iluminação e Efeitos Especiais";
            urlParaSeo = Common.UtilString.GerarUrlParaSeo(nomeCategoria);
            Assert.AreEqual("dj-som-iluminacao-efeitos-especiais", urlParaSeo, "Verifico que palavras de tamanho <=1 são removidas.");

            nomeCategoria = "Tradução";
            urlParaSeo = Common.UtilString.GerarUrlParaSeo(nomeCategoria);
            Assert.AreEqual("traducao", urlParaSeo, "Verifico que nomes de categorias de 1 palavra são convertidas corretamente.");
        }

        [Ignore]
        public void ObterCategoriaTest()
        {
            Categoria categoria = categoriaService.Obter(1, false);

            IList<Categoria> categorias = new List<Categoria>();
            categorias.Add(categoria);

            Assert.IsTrue(categoria.Id == 1);
            Assert.AreEqual("Academia e Esportes", categoria.Nome);
            Assert.AreEqual("Academias", categoria.SubCategorias[0].Nome);

            // 6 pedidos de orçamento de Academia e Esportes no Rio de Janeiro
            // 5 pedidos de orçamento de Academia e Esportes em São Paulo
            Fornecedor comprador = new Fornecedor();
            comprador.Nome = "Nome Comprador";
            comprador.Email = "fabriciofuji@yahoo.com.br";
            comprador.Telefone = "21-81249484";

            string camposInvalidos = String.Empty;

            int idCidadeRioDeJaneiro = 6005;
            Cidade cidade = cidadeService.Obter(idCidadeRioDeJaneiro);

            for (int contador = 0; contador < 6; contador++)
            {
                PedidoOrcamento pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categorias[0], cidade);
                Assert.IsTrue(pedidoOrcamento.Id > 0, "Verifica se criou pedido de orçamento com sucesso.");
            }

            int idCidadeSaoPaulo = 6072;
            cidade = cidadeService.Obter(idCidadeSaoPaulo);

            for (int contador = 0; contador < 5; contador++)
            {
                PedidoOrcamento pedidoOrcamento = basePedidoOrcamento.IncluirPedidoOrcamentoValido(categorias[0], cidade);
                Assert.IsTrue(pedidoOrcamento.Id > 0, "Verifica se criou pedido de orçamento com sucesso.");
            }

            IList<LinkInterno> linksInternos = new List<LinkInterno>();
            LinkInterno linkInterno = new LinkInterno();
            linkInterno.Nome = "Rio de Janeiro - RJ";
            linkInterno.ToolTip = "Solicite orçamento online grátis de " + categoria.Nome + " em Rio de Janeiro (RJ).";
            linkInterno.UrlAmigavel = "/orcamento-online-academia-esportes-rio-de-janeiro-rj-1-6005.aspx";
            linksInternos.Add(linkInterno);

            linkInterno = new LinkInterno();
            linkInterno.Nome = "São Paulo - SP";
            linkInterno.ToolTip = "Solicite orçamento online grátis de " + categoria.Nome + " em São Paulo (SP).";
            linkInterno.UrlAmigavel = "/orcamento-online-academia-esportes-sao-paulo-sp-1-6072.aspx";
            linksInternos.Add(linkInterno);

            linkInterno = new LinkInterno();
            linkInterno.Nome = "aniversário";
            linkInterno.ToolTip = "Solicite orçamento online grátis de " + categoria.Nome + " para " + linkInterno.Nome + ".";
            linkInterno.UrlAmigavel = "/academia-esportes-1/aniversario.aspx";
            linksInternos.Add(linkInterno);

            linkInterno = new LinkInterno();
            linkInterno.Nome = "casamento";
            linkInterno.ToolTip = "Solicite orçamento online grátis de " + categoria.Nome + " para " + linkInterno.Nome + ".";
            linkInterno.UrlAmigavel = "/academia-esportes-1/casamento.aspx";
            linksInternos.Add(linkInterno);

            linkInterno = new LinkInterno();
            linkInterno.Nome = "festa de 15 anos";
            linkInterno.ToolTip = "Solicite orçamento online grátis de " + categoria.Nome + " para " + linkInterno.Nome + ".";
            linkInterno.UrlAmigavel = "/academia-esportes-1/festa-de-15-anos.aspx";
            linksInternos.Add(linkInterno);

            categoria = categoriaService.Obter(1, false);
            for (int i = 0; i < linksInternos.Count(); i++)
            {
                Assert.AreEqual(linksInternos[i].Nome, categoria.LinksInternos[i].Nome, "Verifico que o nome do termo " + i.ToString() + " está correto.");
                Assert.AreEqual(linksInternos[i].ToolTip, categoria.LinksInternos[i].ToolTip, "Verifico que o ToolTip do termo " + i.ToString() + " está correto.");
                Assert.AreEqual(linksInternos[i].UrlAmigavel, categoria.LinksInternos[i].UrlAmigavel, "Verifico que a UrlAmigável do termo " + i.ToString() + " está correto.");
            }

            categoria = categoriaService.Obter(2, false);
            linksInternos = new List<LinkInterno>();
            linkInterno = new LinkInterno();
            linkInterno.Nome = "esporte";
            linkInterno.ToolTip = "Solicite orçamento online grátis de " + categoria.Nome + " para " + linkInterno.Nome + ".";
            linkInterno.UrlAmigavel = "/academias-2/esporte.aspx";
            linksInternos.Add(linkInterno);
            for (int i = 0; i < linksInternos.Count(); i++)
            {
                Assert.AreEqual(linksInternos[i].Nome, categoria.LinksInternos[i].Nome, "Verifico que o nome do termo " + i.ToString() + " está correto.");
                Assert.AreEqual(linksInternos[i].ToolTip, categoria.LinksInternos[i].ToolTip, "Verifico que o ToolTip do termo " + i.ToString() + " está correto.");
                Assert.AreEqual(linksInternos[i].UrlAmigavel, categoria.LinksInternos[i].UrlAmigavel, "Verifico que a UrlAmigável do termo " + i.ToString() + " está correto.");
            }
        }

        [Test]
        public void ObterSomenteCategoriasAtivasTest()
        {
            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();

            foreach (Categoria categoria in categorias)
            {
                Assert.IsTrue(categoria.Ativo);
            }
        }

        [Test]
        public void ObterSubCategoriasAtivasTest()
        {
            IList<Categoria> categorias = categoriaService.ObterSubCategoriasAtivas();
            foreach (Categoria categoria in categorias)
            {
                Assert.IsTrue(categoria.Ativo == true, "Verifico que a categoria " + categoria.Nome + " está ativa.");
                Assert.IsTrue(categoria.Pai.Id != 0, "Verifico que a categoria " + categoria.Nome + " não é raiz.");
                Assert.IsTrue(categoria.Pai.Id != 9999, "Verifico que a categoria " + categoria.Nome + " não é raiz.");
            }
        }

        [Test]
        public void ObterTemasAtivosTest()
        {
            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();
            foreach (Categoria categoria in categorias)
            {
                Assert.IsTrue(categoria.Ativo == true, "Verifico que o tema " + categoria.Nome + " está ativo.");
                Assert.IsTrue(categoria.Pai.Id == 0, "Verifico que a categoria " + categoria.Nome + " é um tema.");
                Assert.IsTrue(categoria.Pai.Id != 9999, "Verifico que a categoria " + categoria.Nome + " é um tema válido.");
            }
        }

        [Test]
        public void ObterCategoriasComForncedoresCadastradosTest()
        {

            IList<Categoria> categorias = categoriaService.ObterCategoriasComFornecedoresCadastrados();

            Assert.IsTrue(categorias.Count > 0);
        }

        [Test]
        public void ObterXML()
        {
            var xml = categoriaService.ObterXMLCategoria(54);

            var categoria = from p in xml
                            select p;

            foreach (var registro in categoria)
            {
                string nome = registro.Element("nome").Value.Trim();
            }
        }

        [Test]
        public void ObterCategoriasComFornecedoresExistentesPorCidadeTest()
        {
            int idCidadeRioDeJaneiro = 6005;
            int idCidadeSaoPaulo = 6072;
            int idCidadeAngraDosReis = 3565;

            //Dado que tenho:
            //              01 fornecedor cadastrado no RJ em Buffet e Buffet Japones
            //              01 fornecedor cadastrado no RJ em Buffet
            //              01 fornecedor cadastrado no RJ em Pintura
            //              01 fornecedor cadastrado no SP em Cursos de Culinária Japonesa
            //              01 fornecedor cadastrado no ANGRA em Pintura
            //Quando seleciono a cidade RJ
            //Então verifico que a lista contém o tamanho de 2

            List<int> categoriasDoFornecedorRJ = new List<int>();
            categoriasDoFornecedorRJ.Add(123);
            categoriasDoFornecedorRJ.Add(54);

            this.InserirFornecedorMultiplasCategorias("renatoadsumus@gmail.com", idCidadeRioDeJaneiro, categoriasDoFornecedorRJ);
            this.InserirFornecedor("suporte1@gmail.com", idCidadeRioDeJaneiro, 123);
            this.InserirFornecedor("suporte@gmail.com", idCidadeRioDeJaneiro, 40);
            this.InserirFornecedor("renato@rcmsolucoes.com", idCidadeSaoPaulo, 124);
            this.InserirFornecedor("contato@rcmsolucoes.com", idCidadeAngraDosReis, 40);

            Cidade cidadeRioDeJaneiro = cidadeService.Obter(idCidadeRioDeJaneiro);

            IList<Categoria> categorias = categoriaService.ObterSubCategoriasComFornecedorPorCidade(cidadeRioDeJaneiro, 52);

            Assert.IsTrue(categorias.Count == 2);
        }

        [Test]
        public void MontarHTMLDeTermo()
        {
            IList<string> categorias = new List<string>();
            categorias.Add("39");
            categorias.Add("40");

            IList<Termo> termos = categoriaService.ObterTermos(39);

            Termo termo = new Termo();
            termo.Nome = "pintura interna";
            termo.IdCategoria = 40;
            termos.Add(termo);

            string htmlAtual = categoriaService.MontarHTMLDeTermo(categorias, termos);
            string htmlEsperado = "Pedreiro: calçadas; manilhas; muros, paredes ou lajes; pias ou louças de banheiro" + Environment.NewLine +
                                  "Pintura e Pintor Profissional: pintura interna" + Environment.NewLine;

            Assert.AreEqual(htmlEsperado, htmlAtual);
        }


        private void InserirFornecedor(string email, int idCidadeAtuacao, int idCategoria)
        {
            BaseFornecedor baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
            List<int> cidades = new List<int>();
            cidades.Add(idCidadeAtuacao);

            List<int> categorias = new List<int>();
            categorias.Add(idCategoria);

            baseFornecedor.IncluirFornecedorValido(cidades, email, categorias);
        }

        private void InserirFornecedorMultiplasCategorias(string email, int idCidadeFornecedor, List<int> categorias)
        {
            BaseFornecedor baseFornecedor = new BaseFornecedor(fornecedorService, cidadeService, categoriaService);
            List<int> cidades = new List<int>();
            cidades.Add(idCidadeFornecedor);

            baseFornecedor.IncluirFornecedorValido(cidades, email, categorias);

        }
    }
}
