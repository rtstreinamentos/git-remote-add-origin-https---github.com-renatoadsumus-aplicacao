using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using NHibernate.Burrow;
using NUnit.Framework;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;
using OrcamentoNet.LocalService;

namespace OrcamentoNet.LocalServiceTest
{
    [TestFixture]
    public class SiteMapServiceTest
    {
        private StandardKernel injectionService;

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public ISiteMapService siteMapService { get; set; }

        [SetUp]
        public void Setup()
        {
            injectionService = new StandardKernel(new CustomModule());
            injectionService.Inject(this);
        }

        [TearDown]
        public void TearDown()
        {
            new BurrowFramework().CloseWorkSpace();
        }

        [Test]
        public void GravarSiteMapSucesso()
        {
            // Apaga o SiteMap existente
            File.Delete(Config.NomeArquivoSiteMap);

            IList<Categoria> listaCategorias = new List<Categoria>();
            siteMapService.Gravar(listaCategorias);

            // Lê o novo SiteMap
            string conteudoArquivo = String.Empty;
            using (StreamReader arquivo = new StreamReader(Config.NomeArquivoSiteMap))
            {
                conteudoArquivo = arquivo.ReadToEnd();
            }

            Assert.IsTrue(conteudoArquivo != String.Empty);
        }

        [Test]
        public void ObterFimSucesso()
        {
            string retornoEsperado = "</urlset>";

            string retorno = siteMapService.ObterFim();
            Assert.AreEqual(retornoEsperado, retorno);
        }

		[Test]
		public void ObterGuiaTemasSucesso() {
			int idCategoriaFestasEventos = 52;
			int idCategoriaObrasReformas = 27;
			IList<Categoria> listaTemas = new List<Categoria>();
			listaTemas.Add(categoriaService.Obter(idCategoriaFestasEventos, false));
			listaTemas.Add(categoriaService.Obter(idCategoriaObrasReformas, false));

			string retornoEsperado = "<url><loc>" + Config.UrlSite + "guia-festas-eventos-52.aspx</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "guia-obras-reformas-construcao-27.aspx</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine;
			string retorno = siteMapService.ObterGuiaTemas(listaTemas);
			Assert.AreEqual(retornoEsperado, retorno);
		}

		[Test]
        public void ObterHomeCadastroFornecedorSucesso()
        {
            string retornoEsperado = "<url><loc>" + Config.UrlSite + "cadastro-fornecedores-orcamento-online.aspx</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine;

            string retorno = siteMapService.ObterHomeCadastroFornecedor();
            Assert.AreEqual(retornoEsperado, retorno);
        }

		[Test]
		public void ObterHomeGuiaSucesso() {
			string retornoEsperado = "<url><loc>" + Config.UrlSite + "guia-empresas-profissionais.aspx</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine;
			string retorno = siteMapService.ObterHomeGuia();
			Assert.AreEqual(retornoEsperado, retorno);
		}

		[Test]
        public void ObterHomeMapaSucesso()
        {
            string retornoEsperado = "<url><loc>" + Config.UrlSite + "mapa.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine;

            string retorno = siteMapService.ObterHomeMapa();
            Assert.AreEqual(retornoEsperado, retorno);
        }

        [Test]
        public void ObterHomePedidoOrcamentoSucesso()
        {
            string retornoEsperado = "<url><loc>" + Config.UrlSite + "orcamento-online.aspx</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine;

            string retorno = siteMapService.ObterHomePedidoOrcamento();
            Assert.AreEqual(retornoEsperado, retorno);
        }

        [Test]
        public void ObterHomeSiteSucesso()
        {
            string retornoEsperado = "<url><loc>" + Config.UrlSite + "</loc><changefreq>daily</changefreq><priority>1.00</priority></url>" + Environment.NewLine;

            string retorno = siteMapService.ObterHomeSite();
            Assert.AreEqual(retornoEsperado, retorno);
        }

        [Test]
        public void ObterInicioSucesso()
        {
            string retornoEsperado = "<?xml version='1.0' encoding='UTF-8'?>" + Environment.NewLine +
                                     "<urlset xmlns='http://www.sitemaps.org/schemas/sitemap/0.9'>" + Environment.NewLine;

            string retorno = siteMapService.ObterInicio();
            Assert.AreEqual(retornoEsperado, retorno);
        }

        [Test]
        public void ObterMapaLinksInternosSucesso()
        {
            string retornoEsperado = "<url><loc>" + Config.UrlSite + "mapa-casa-decoracao-bahia-ba-18-5.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-casa-decoracao-brasilia-df-18-7.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-casa-decoracao-minas-gerais-mg-18-13.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-casa-decoracao-parana-pr-18-16.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-casa-decoracao-rio-de-janeiro-rj-18-19.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-casa-decoracao-sao-paulo-sp-18-25.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-festas-casamentos-eventos-bahia-ba-52-5.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-festas-casamentos-eventos-brasilia-df-52-7.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-festas-casamentos-eventos-minas-gerais-mg-52-13.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-festas-casamentos-eventos-parana-pr-52-16.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-festas-casamentos-eventos-rio-de-janeiro-rj-52-19.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-festas-casamentos-eventos-sao-paulo-sp-52-25.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-graficas-impressao-bahia-ba-198-5.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-graficas-impressao-brasilia-df-198-7.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-graficas-impressao-minas-gerais-mg-198-13.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-graficas-impressao-parana-pr-198-16.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-graficas-impressao-rio-de-janeiro-rj-198-19.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-graficas-impressao-sao-paulo-sp-198-25.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-obras-reformas-construcao-bahia-ba-27-5.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-obras-reformas-construcao-brasilia-df-27-7.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-obras-reformas-construcao-minas-gerais-mg-27-13.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-obras-reformas-construcao-parana-pr-27-16.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-obras-reformas-construcao-rio-de-janeiro-rj-27-19.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-obras-reformas-construcao-sao-paulo-sp-27-25.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-produtos-bahia-ba-206-5.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-produtos-brasilia-df-206-7.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-produtos-minas-gerais-mg-206-13.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-produtos-parana-pr-206-16.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-produtos-rio-de-janeiro-rj-206-19.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-produtos-sao-paulo-sp-206-25.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-suporte-tecnicos-bahia-ba-91-5.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-suporte-tecnicos-brasilia-df-91-7.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-suporte-tecnicos-minas-gerais-mg-91-13.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-suporte-tecnicos-parana-pr-91-16.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-suporte-tecnicos-rio-de-janeiro-rj-91-19.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-suporte-tecnicos-sao-paulo-sp-91-25.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-prediais-bahia-ba-196-5.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-prediais-brasilia-df-196-7.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-prediais-minas-gerais-mg-196-13.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-prediais-parana-pr-196-16.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-prediais-rio-de-janeiro-rj-196-19.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
                "<url><loc>" + Config.UrlSite + "mapa-servicos-prediais-sao-paulo-sp-196-25.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine;

            string retorno = siteMapService.ObterLinksInternosTemas();
            Assert.AreEqual(retornoEsperado, retorno);
        }


        [Test]
        public void ObterUrlsCategoriaSucesso()
        {
            int idCategoriaBuffetJapones = 54;
            int idCategoriaEquipamentoEsportivo = 4;
            int idCategoriaFestasEventos = 52;
            string retornoEsperado = "<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-54.aspx</loc><changefreq>weekly</changefreq><priority>0.70</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "cadastro-buffet-japones-54.aspx</loc><changefreq>weekly</changefreq><priority>0.70</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-alcantara-sao-goncalo-itaborai-adjacencias-rj-54-6000.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-alto-paranaiba-patos-de-minas-araxa-patrocinio-regiao-mg-54-7000.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-aracatuba-regiao-sp-54-6050.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-araraquara-regiao-sp-54-6051.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-assis-regiao-sp-54-6052.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-baixada-fluminense-adjacencias-rj-54-6001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-baixada-santista-sp-54-6053.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-bauru-regiao-sp-54-6054.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-belo-horizonte-mg-54-1606.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-campinas-regiao-sp-54-6055.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-centro-sul-baiano-vitoria-da-conquista-ilheus-itabuna-jequie-regiao-ba-54-8001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-curitiba-pr-54-2853.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-feira-de-santana-ba-54-330.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-grande-belo-horizonte-contagem-betim-ribeirao-das-neves-regiao-mg-54-7003.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-grande-curitiba-sao-jose-dos-pinhais-colombo-araucaria-regiao-pr-54-9001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-grande-salvador-camacari-lauro-de-freitas-simoes-filho-regiao-ba-54-8000.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-grande-sao-paulo-regiao-do-abcd-sp-54-6060.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-grande-sao-paulo-regiao-leste-mogi-das-cruzes-adjacencias-sp-54-6056.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-grande-sao-paulo-regiao-nordeste-guarulhos-adjacencias-sp-54-6057.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-grande-sao-paulo-regiao-norte-caieiras-adjacencias-sp-54-6058.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-grande-sao-paulo-regiao-oeste-barueri-osasco-adjacencias-sp-54-6059.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-grande-sao-paulo-regiao-sudoeste-embu-adjacencias-sp-54-6061.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-interior-sul-fluminense-rj-54-6010.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-itapetininga-regiao-sp-54-6062.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-litoral-norte-regiao-dos-lagos-rj-54-6011.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-litoral-sul-costa-verde-rj-54-6012.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-litoral-sul-regiao-sp-54-6063.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-marilia-regiao-sp-54-6064.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-niteroi-adjacencias-rj-54-6013.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-noroeste-de-minas-paracatu-unai-joao-pinheiro-regiao-mg-54-7005.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-norte-central-londrina-maringa-apucarana-regiao-pr-54-9002.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-norte-de-minas-montes-claros-diamantina-janauba-januaria-regiao-mg-54-7004.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-oeste-de-minas-divinopolis-campo-belo-regiao-mg-54-7001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-piracicaba-regiao-sp-54-6065.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-ponta-grossa-pr-54-9003.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-presidente-prudente-regiao-sp-54-6066.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-ribeirao-preto-regiao-sp-54-6067.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-rio-de-janeiro-barra-recreio-adjacencias-rj-54-6002.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-rio-de-janeiro-centro-rj-54-6003.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-rio-de-janeiro-ilha-do-governador-rj-54-6004.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-rio-de-janeiro-jacarepagua-freguesia-adjacencias-rj-54-6005.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-rio-de-janeiro-tijuca-grajau-vila-isabel-adjacencias-rj-54-6006.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-rio-de-janeiro-zona-norte-rj-54-6007.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-rio-de-janeiro-zona-oeste-rj-54-6008.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-rio-de-janeiro-zona-sul-rj-54-6009.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-rio-doce-aimores-caratinga-coronel-fabriciano-governador-valadares-regiao-mg-54-7006.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-salvador-ba-54-535.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-sao-jose-do-rio-preto-regiao-sp-54-6068.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-sao-jose-dos-campos-regiao-vale-do-paraiba-litoral-norte-sp-54-6075.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-sao-paulo-zona-centro-se-adjacencias-sp-54-6069.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-sao-paulo-zona-leste-mooca-penha-adjacencias-sp-54-6070.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-sao-paulo-zona-norte-freguesia-santana-adjacencias-sp-54-6071.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-sao-paulo-zona-oeste-lapa-pinheiros-adjacencias-sp-54-6072.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-sao-paulo-zona-sul-ipiranga-moema-santo-amaro-adjacencias-sp-54-6073.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-serras-rj-54-6014.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-sorocaba-jundiai-regiao-sp-54-6074.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-sul-de-minas-pocos-de-caldas-pouso-alegre-varginha-passos-itajuba-regiao-mg-54-7007.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-triangulo-mineiro-uberlandia-uberaba-araguari-regiao-mg-54-7008.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-vale-do-jequitinhonha-regiao-mg-54-7002.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-valenca-ba-54-604.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-buffet-japones-zona-da-mata-juiz-de-fora-uba-muriae-manhuacu-vicosa-regiao-mg-54-7009.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/aniversario.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/casamento.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/comida-japonesa.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/debutante.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/delivery.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/domicilio.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/eventos.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/festa-de-15-anos.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/festa-japonesa.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/festas.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/sushi.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "buffet-japones-54/sushiman.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-4.aspx</loc><changefreq>weekly</changefreq><priority>0.70</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "cadastro-equipamento-esportivo-4.aspx</loc><changefreq>weekly</changefreq><priority>0.70</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-alcantara-sao-goncalo-itaborai-adjacencias-rj-4-6000.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-alto-paranaiba-patos-de-minas-araxa-patrocinio-regiao-mg-4-7000.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-aracatuba-regiao-sp-4-6050.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-araraquara-regiao-sp-4-6051.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-assis-regiao-sp-4-6052.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-baixada-fluminense-adjacencias-rj-4-6001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-baixada-santista-sp-4-6053.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-bauru-regiao-sp-4-6054.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-belo-horizonte-mg-4-1606.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-campinas-regiao-sp-4-6055.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-centro-sul-baiano-vitoria-da-conquista-ilheus-itabuna-jequie-regiao-ba-4-8001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-curitiba-pr-4-2853.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-feira-de-santana-ba-4-330.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-grande-belo-horizonte-contagem-betim-ribeirao-das-neves-regiao-mg-4-7003.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-grande-curitiba-sao-jose-dos-pinhais-colombo-araucaria-regiao-pr-4-9001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-grande-salvador-camacari-lauro-de-freitas-simoes-filho-regiao-ba-4-8000.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-grande-sao-paulo-regiao-do-abcd-sp-4-6060.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-grande-sao-paulo-regiao-leste-mogi-das-cruzes-adjacencias-sp-4-6056.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-grande-sao-paulo-regiao-nordeste-guarulhos-adjacencias-sp-4-6057.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-grande-sao-paulo-regiao-norte-caieiras-adjacencias-sp-4-6058.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-grande-sao-paulo-regiao-oeste-barueri-osasco-adjacencias-sp-4-6059.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-grande-sao-paulo-regiao-sudoeste-embu-adjacencias-sp-4-6061.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-interior-sul-fluminense-rj-4-6010.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-itapetininga-regiao-sp-4-6062.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-litoral-norte-regiao-dos-lagos-rj-4-6011.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-litoral-sul-costa-verde-rj-4-6012.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-litoral-sul-regiao-sp-4-6063.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-marilia-regiao-sp-4-6064.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-niteroi-adjacencias-rj-4-6013.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-noroeste-de-minas-paracatu-unai-joao-pinheiro-regiao-mg-4-7005.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-norte-central-londrina-maringa-apucarana-regiao-pr-4-9002.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-norte-de-minas-montes-claros-diamantina-janauba-januaria-regiao-mg-4-7004.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-oeste-de-minas-divinopolis-campo-belo-regiao-mg-4-7001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-piracicaba-regiao-sp-4-6065.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-ponta-grossa-pr-4-9003.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-presidente-prudente-regiao-sp-4-6066.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-ribeirao-preto-regiao-sp-4-6067.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-rio-de-janeiro-barra-recreio-adjacencias-rj-4-6002.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-rio-de-janeiro-centro-rj-4-6003.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-rio-de-janeiro-ilha-do-governador-rj-4-6004.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-rio-de-janeiro-jacarepagua-freguesia-adjacencias-rj-4-6005.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-rio-de-janeiro-tijuca-grajau-vila-isabel-adjacencias-rj-4-6006.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-rio-de-janeiro-zona-norte-rj-4-6007.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-rio-de-janeiro-zona-oeste-rj-4-6008.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-rio-de-janeiro-zona-sul-rj-4-6009.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-rio-doce-aimores-caratinga-coronel-fabriciano-governador-valadares-regiao-mg-4-7006.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-salvador-ba-4-535.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-sao-jose-do-rio-preto-regiao-sp-4-6068.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-sao-jose-dos-campos-regiao-vale-do-paraiba-litoral-norte-sp-4-6075.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-sao-paulo-zona-centro-se-adjacencias-sp-4-6069.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-sao-paulo-zona-leste-mooca-penha-adjacencias-sp-4-6070.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-sao-paulo-zona-norte-freguesia-santana-adjacencias-sp-4-6071.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-sao-paulo-zona-oeste-lapa-pinheiros-adjacencias-sp-4-6072.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-sao-paulo-zona-sul-ipiranga-moema-santo-amaro-adjacencias-sp-4-6073.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-serras-rj-4-6014.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-sorocaba-jundiai-regiao-sp-4-6074.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-sul-de-minas-pocos-de-caldas-pouso-alegre-varginha-passos-itajuba-regiao-mg-4-7007.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-triangulo-mineiro-uberlandia-uberaba-araguari-regiao-mg-4-7008.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-vale-do-jequitinhonha-regiao-mg-4-7002.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-valenca-ba-4-604.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-equipamento-esportivo-zona-da-mata-juiz-de-fora-uba-muriae-manhuacu-vicosa-regiao-mg-4-7009.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-eventos-restaurantes-52.aspx</loc><changefreq>weekly</changefreq><priority>0.70</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "cadastro-fornecedor-festas-eventos-restaurantes-52.aspx</loc><changefreq>weekly</changefreq><priority>0.70</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "mapa-festas-eventos-52.aspx</loc><changefreq>weekly</changefreq><priority>0.50</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-alcantara-sao-goncalo-itaborai-adjacencias-rj-52-6000.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-alto-paranaiba-patos-de-minas-araxa-patrocinio-regiao-mg-52-7000.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-aracatuba-regiao-sp-52-6050.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-araraquara-regiao-sp-52-6051.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-assis-regiao-sp-52-6052.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-baixada-fluminense-adjacencias-rj-52-6001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-baixada-santista-sp-52-6053.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-bauru-regiao-sp-52-6054.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-belo-horizonte-mg-52-1606.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-campinas-regiao-sp-52-6055.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-centro-sul-baiano-vitoria-da-conquista-ilheus-itabuna-jequie-regiao-ba-52-8001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-curitiba-pr-52-2853.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-feira-de-santana-ba-52-330.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-grande-belo-horizonte-contagem-betim-ribeirao-das-neves-regiao-mg-52-7003.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-grande-curitiba-sao-jose-dos-pinhais-colombo-araucaria-regiao-pr-52-9001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-grande-salvador-camacari-lauro-de-freitas-simoes-filho-regiao-ba-52-8000.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-grande-sao-paulo-regiao-do-abcd-sp-52-6060.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-grande-sao-paulo-regiao-leste-mogi-das-cruzes-adjacencias-sp-52-6056.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-grande-sao-paulo-regiao-nordeste-guarulhos-adjacencias-sp-52-6057.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-grande-sao-paulo-regiao-norte-caieiras-adjacencias-sp-52-6058.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-grande-sao-paulo-regiao-oeste-barueri-osasco-adjacencias-sp-52-6059.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-grande-sao-paulo-regiao-sudoeste-embu-adjacencias-sp-52-6061.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-interior-sul-fluminense-rj-52-6010.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-itapetininga-regiao-sp-52-6062.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-litoral-norte-regiao-dos-lagos-rj-52-6011.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-litoral-sul-costa-verde-rj-52-6012.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-litoral-sul-regiao-sp-52-6063.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-marilia-regiao-sp-52-6064.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-niteroi-adjacencias-rj-52-6013.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-noroeste-de-minas-paracatu-unai-joao-pinheiro-regiao-mg-52-7005.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-norte-central-londrina-maringa-apucarana-regiao-pr-52-9002.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-norte-de-minas-montes-claros-diamantina-janauba-januaria-regiao-mg-52-7004.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-oeste-de-minas-divinopolis-campo-belo-regiao-mg-52-7001.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-piracicaba-regiao-sp-52-6065.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-ponta-grossa-pr-52-9003.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-presidente-prudente-regiao-sp-52-6066.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-ribeirao-preto-regiao-sp-52-6067.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-rio-de-janeiro-barra-recreio-adjacencias-rj-52-6002.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-rio-de-janeiro-centro-rj-52-6003.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-rio-de-janeiro-ilha-do-governador-rj-52-6004.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-rio-de-janeiro-jacarepagua-freguesia-adjacencias-rj-52-6005.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-rio-de-janeiro-tijuca-grajau-vila-isabel-adjacencias-rj-52-6006.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-rio-de-janeiro-zona-norte-rj-52-6007.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-rio-de-janeiro-zona-oeste-rj-52-6008.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-rio-de-janeiro-zona-sul-rj-52-6009.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-rio-doce-aimores-caratinga-coronel-fabriciano-governador-valadares-regiao-mg-52-7006.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-salvador-ba-52-535.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-sao-jose-do-rio-preto-regiao-sp-52-6068.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-sao-jose-dos-campos-regiao-vale-do-paraiba-litoral-norte-sp-52-6075.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-sao-paulo-zona-centro-se-adjacencias-sp-52-6069.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-sao-paulo-zona-leste-mooca-penha-adjacencias-sp-52-6070.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-sao-paulo-zona-norte-freguesia-santana-adjacencias-sp-52-6071.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-sao-paulo-zona-oeste-lapa-pinheiros-adjacencias-sp-52-6072.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-sao-paulo-zona-sul-ipiranga-moema-santo-amaro-adjacencias-sp-52-6073.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-serras-rj-52-6014.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-sorocaba-jundiai-regiao-sp-52-6074.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-sul-de-minas-pocos-de-caldas-pouso-alegre-varginha-passos-itajuba-regiao-mg-52-7007.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-triangulo-mineiro-uberlandia-uberaba-araguari-regiao-mg-52-7008.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-vale-do-jequitinhonha-regiao-mg-52-7002.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-valenca-ba-52-604.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "orcamento-online-festas-casamentos-eventos-zona-da-mata-juiz-de-fora-uba-muriae-manhuacu-vicosa-regiao-mg-52-7009.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "festas-casamentos-eventos-52/aniversario.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "festas-casamentos-eventos-52/batizado.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "festas-casamentos-eventos-52/festa-infantil.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine +
				"<url><loc>" + Config.UrlSite + "festas-casamentos-eventos-52/festa-teen.aspx</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine;

            IList<Categoria> listaCategorias = new List<Categoria>();
            listaCategorias.Add(categoriaService.Obter(idCategoriaBuffetJapones, false));
            listaCategorias.Add(categoriaService.Obter(idCategoriaEquipamentoEsportivo, false));
            listaCategorias.Add(categoriaService.Obter(idCategoriaFestasEventos, false));
            string retorno = siteMapService.ObterUrlsCategoria();
            Assert.AreEqual(retornoEsperado, retorno);
        }

    }
}
