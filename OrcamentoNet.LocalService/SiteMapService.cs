using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Common;
using PortalEscolar.Data;
using OrcamentoNet.Entity._enum;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.LocalService
{
    public class SiteMapService : ISiteMapService
    {
        private IDataContext context;

        #region "Métodos Públicos"
        public SiteMapService(IDataContext contextData)
        {
            context = contextData;
        }

        public void Gravar(IList<Categoria> listaCategorias)
        {
            try
            {
                //string siteMapTemas = this.Obter(listaCategorias);
                //string siteMapCategoriasTermo = this.ObterUrlsCategoria();
                //string siteMapCategoriasEstado = this.ObterUrlsCategoriaEstado();
                //string siteMap = ObterInicio() + siteMapTemas + siteMapCategoriasEstado + siteMapCategoriasTermo + ObterFim();
                //File.WriteAllText(Config.NomeArquivoSiteMap, siteMap);

                string siteMapCategoriasCidade = ObterInicio() + this.ObterUrlsCategoriaCidade() + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"sitemapCategoriaCidade.xml", siteMapCategoriasCidade);

                string siteMapCategoriasBairroObrasReformas = ObterInicio() + this.ObterUrlsCategoriasBairros(27) + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"sitemapCategoriaBairroObrasReformas.xml", siteMapCategoriasBairroObrasReformas);

                string siteMapCategoriasBairroFestasEventos = ObterInicio() + this.ObterUrlsCategoriasBairros(52) + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"sitemapCategoriaBairroFestasEventos.xml", siteMapCategoriasBairroFestasEventos);

                string siteMapCategoriasBairroCasaDecoracao = ObterInicio() + this.ObterUrlsCategoriasBairros(18) + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"sitemapCategoriaBairroCasaDecoracao.xml", siteMapCategoriasBairroCasaDecoracao);

                string siteMapCategoriasBairroSistemaSeguranca = ObterInicio() + this.ObterUrlsCategoriasBairros(214) + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"sitemapCategoriaBairroSistemaSeguranca.xml", siteMapCategoriasBairroSistemaSeguranca);


                //TERMOS
                string siteMapCategoriasBairroObrasReformasComTermos = ObterInicio() + this.ObterUrlsCategoriaBairrosComTermos(27) + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"siteMapCategoriasBairroObrasReformasComTermos.xml", siteMapCategoriasBairroObrasReformasComTermos);

                string siteMapCategoriasBairroObrasFestasEventos = ObterInicio() + this.ObterUrlsCategoriaBairrosComTermos(52) + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"siteMapCategoriasBairroFestasEventosComTermos.xml", siteMapCategoriasBairroObrasFestasEventos);

                string siteMapCategoriasBairroCasaDecoracaoComTermos = ObterInicio() + this.ObterUrlsCategoriaBairrosComTermos(18) + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"siteMapCategoriasBairroCasaDecoracaoComTermos.xml", siteMapCategoriasBairroCasaDecoracaoComTermos);

                string siteMapCategoriasBairroSistemaSegurancaComTermos = ObterInicio() + this.ObterUrlsCategoriaBairrosComTermos(214) + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"siteMapCategoriasBairroSistemaSegurancaComTermos.xml", siteMapCategoriasBairroSistemaSegurancaComTermos);

                string siteMapMesAnoPreco = ObterInicio() + this.ObterAnoMesPreco() + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"siteMapCategoriasAnoMesPreco.xml", siteMapMesAnoPreco);

                string siteMapCadastroFornecedor = ObterInicio() + this.ObterCadastroFornecedores() + ObterFim();
                File.WriteAllText(Config.CaminhoFisico + @"siteMapCadastroFornecedor.xml", siteMapCadastroFornecedor);

            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                Email.NotificarAdministracao("erro na geração de sitemap", ex.Message);
            }
        }

        public string ObterAnoMesPreco()
        {
            StringBuilder retorno = new StringBuilder(String.Empty);
            CategoriaService categoriaService = new CategoriaService(context);
            LinkInternoService linkInternoService = new LinkInternoService(context);

            IList<Categoria> listaCategorias = categoriaService.ObterCategoriasAtivas();

            foreach (Categoria categoriaItem in listaCategorias)
            {
                IList<LinkInterno> linksInternos;

                linksInternos = linkInternoService.MontarLinksInternosMesAnoPreco(categoriaItem, 0, "");

                //orcamento-online-preco.aspx?ano=2014&mes=2
                foreach (LinkInterno linkInterno in linksInternos)
                {
                    retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                }
            }

            return retorno.ToString();

        }

        public string ObterCadastroFornecedores()
        {
            StringBuilder retorno = new StringBuilder(String.Empty);
            CategoriaService categoriaService = new CategoriaService(context);
            LinkInternoService linkInternoService = new LinkInternoService(context);

            IList<Categoria> listaCategorias = categoriaService.ObterCategoriasAtivas();

            foreach (Categoria categoria in listaCategorias)
            {
                foreach (Categoria categoriaItem in categoria.SubCategorias)
                {
                    IList<LinkInterno> linksInternos;

                    linksInternos = linkInternoService.MontarLinksInternosTermoFornecedor(categoriaItem);

                    //cadastro-empresa-profissional-
                    foreach (LinkInterno linkInterno in linksInternos)
                    {
                        retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                    }

                    foreach (string estado in Enum.GetNames(typeof(UF)))
                    {
                        linksInternos = new List<LinkInterno>();

                        UF uf = (UF)Enum.Parse(typeof(UF), estado);
                        linksInternos = linkInternoService.MontarLinksInternosCidades(categoriaItem, uf, Persona.Fornecedor);

                        //orcamento-online-categoria-cidades
                        foreach (LinkInterno linkInterno in linksInternos)
                        {
                            retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                        }
                    }
                }
            }

            return retorno.ToString();
        }

        public string Obter(IList<Categoria> listaCategorias)
        {
            StringBuilder retorno = new StringBuilder(String.Empty);
            CategoriaService categoriaService = new CategoriaService(context);

            try
            {
                if (listaCategorias.Count == 0)
                {
                    listaCategorias = categoriaService.ObterSubCategoriasAtivas();
                }

                IList<Categoria> listaTemas = categoriaService.ObterCategoriasAtivas();


                retorno.Append(this.ObterHomeSite());
                retorno.Append(this.ObterHomePedidoOrcamento());
                retorno.Append(this.ObterHomeCadastroFornecedor());
                retorno.Append(this.ObterHomeGuia());
                retorno.Append(this.ObterHomeMapa());
                retorno.Append(this.ObterLinksInternosTipoServico());
                retorno.Append(this.ObterGuiaTemas(listaTemas));
                retorno.Append(this.ObterMapaTemas(listaTemas));
                retorno.Append(this.ObterPreco(listaTemas));


            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return retorno.ToString();
        }

        private string ObterPreco(IList<Categoria> listaTemas)
        {
            StringBuilder retorno = new StringBuilder(String.Empty);

            foreach (Categoria temaDaLista in listaTemas)
            {
                foreach (Categoria categoria in temaDaLista.SubCategorias)
                {
                    retorno.Append("<url><loc>" + Config.UrlSite + categoria.UrlPreco + "</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine);
                }

                retorno.Append("<url><loc>" + Config.UrlSite + temaDaLista.UrlPreco + "</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine);
            }

            return retorno.ToString();
        }

        public string ObterFim()
        {
            return "</urlset>";
        }

        public string ObterGuiaTemas(IList<Categoria> listaTemas)
        {
            StringBuilder retorno = new StringBuilder(String.Empty);

            try
            {
                foreach (Categoria temaDaLista in listaTemas)
                {
                    retorno.Append("<url><loc>" + Config.UrlSite + "guia-" + temaDaLista.Url + "</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine);
                }

            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return retorno.ToString();
        }

        public string ObterHomeCadastroFornecedor()
        {
            return "<url><loc>" + Config.UrlSite + "cadastro-fornecedores-orcamento-online.aspx</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine;
        }

        public string ObterHomeGuia()
        {
            return "<url><loc>" + Config.UrlSite + "guia-empresas-profissionais.aspx</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine;
        }

        public string ObterHomeMapa()
        {
            return "<url><loc>" + Config.UrlSite + "mapa.aspx</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine;
        }

        public string ObterHomePedidoOrcamento()
        {
            return "<url><loc>" + Config.UrlSite + "orcamento-online.aspx</loc><changefreq>daily</changefreq><priority>0.90</priority></url>" + Environment.NewLine;
        }

        public string ObterHomeSite()
        {
            return "<url><loc>" + Config.UrlSite + "</loc><changefreq>daily</changefreq><priority>1.00</priority></url>" + Environment.NewLine;
        }

        public string ObterInicio()
        {
            return "<?xml version='1.0' encoding='UTF-8'?>" + Environment.NewLine +
                   "<urlset xmlns='http://www.sitemaps.org/schemas/sitemap/0.9'>" + Environment.NewLine;
        }

        public string ObterLinksInternosTipoServico()
        {
            LinkInternoService linkInternoService = new LinkInternoService(context);
            StringBuilder retorno = new StringBuilder(String.Empty);
            OrcamentoService orcamentoService = new OrcamentoService(context);
            CidadeService cidadeService = new CidadeService(context);
            IList<Orcamento> orcamentosTipoServico = orcamentoService.Obter();

            foreach (Orcamento orcamento in orcamentosTipoServico)
            {
                IList<LinkInterno> linksInternos;

                linksInternos = linkInternoService.MontarLinksInternosTermoTipoServico(orcamento, 0, 0);

                //MONTAR TIPO SERVICO ESTADO - preco-casamento-1-123/buffet.aspx
                foreach (LinkInterno linkInterno in linksInternos)
                {
                    retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                }

                linksInternos = linkInternoService.MontarLinksInternosDeEstadoTipoServico(orcamento);

                //MONTAR TIPO SERVICO ESTADO - preco-casamento-minas-gerais-mg-1-13.aspx
                foreach (LinkInterno linkInterno in linksInternos)
                {
                    retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                }

                foreach (string estado in Enum.GetNames(typeof(OrcamentoNet.Entity.Enum.UF)))
                {
                    UF uf = (UF)Enum.Parse(typeof(UF), estado);
                    linksInternos = linkInternoService.MontarLinksInternosCidadeTipoServico(orcamento, uf);

                    //MONTAR TIPO SERVICO CIDADE - preco-casamento-sao-paulo-zona-leste-mooca-penha-adjacencias-SP-1-6070.aspx
                    foreach (LinkInterno linkInterno in linksInternos)
                    {
                        retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                    }

                    linksInternos = linkInternoService.MontarLinksInternosTermoTipoServico(orcamento, (int)uf, 0);
                    //MONTAR TIPO SERVICO ESTADO CATEGORIA - preco-casamento-minas-gerais-mg-1-13-123/buffet-catering.aspx
                    foreach (LinkInterno linkInterno in linksInternos)
                    {
                        retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                    }
                }

                foreach (string estado in Enum.GetNames(typeof(OrcamentoNet.Entity.Enum.UF)))
                {
                    UF uf = (UF)Enum.Parse(typeof(UF), estado);
                    IList<Cidade> cidadesDoEstado = cidadeService.ObterCidades(uf);

                    foreach (Cidade cidade in cidadesDoEstado)
                    {
                        linksInternos = linkInternoService.MontarLinksInternosBairroTipoServico(orcamento, cidade);

                        //MONTAR TIPO SERVICO BAIRRO - preco-aniversario-jardim-primavera-rio-de-janeiro-zona-oeste-3-20-6008.aspx
                        foreach (LinkInterno linkInterno in linksInternos)
                        {
                            retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                        }

                        linksInternos = linkInternoService.MontarLinksInternosTermoTipoServico(orcamento, cidade.Id, 0);
                        //MONTAR TIPO SERVICO CIDADE CATEGORIA- preco-festa-infantil-grande-sao-paulo-regiao-oeste-barueri-osasco-adjacencias-5-6059-142/filmagens.aspx
                        foreach (LinkInterno linkInterno in linksInternos)
                        {
                            retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                        }

                        foreach (Bairro bairro in cidade.Bairros)
                        {
                            linksInternos = linkInternoService.MontarLinksInternosTermoTipoServico(orcamento, cidade.Id, bairro.Id);
                            //MONTAR TIPO SERVICO BAIRRO CATEGORIA- preco-festa-infantil-grande-sao-paulo-regiao-oeste-barueri-osasco-adjacencias-5-6059-142/filmagens.aspx
                            foreach (LinkInterno linkInterno in linksInternos)
                            {
                                retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                            }

                        }
                    }
                }
            }

            return retorno.ToString();
        }

        public string ObterLinksInternosTemas()
        {
            StringBuilder retorno = new StringBuilder(String.Empty);
            CategoriaService categoriaService = new CategoriaService(context);

            IList<Categoria> listaDeTemas = categoriaService.ObterCategoriasAtivas();

            try
            {
                ILinkInternoService linkInternoService = new LinkInternoService(context);

                foreach (Categoria temaDaLista in listaDeTemas)
                {
                    IList<LinkInterno> listaLinksInternos = linkInternoService.MontarLinksInternosDeEstado(temaDaLista, "", Persona.MotorBusca);

                    foreach (LinkInterno linkInterno in listaLinksInternos)
                    {
                        retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>daily</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return retorno.ToString();
        }

        public string ObterUrlsCategoria()
        {
            CidadeService cidadeService = new CidadeService(context);

            LinkInternoService linkInternoService = new LinkInternoService(context);
            StringBuilder retorno = new StringBuilder(String.Empty);

            CategoriaService categoriaService = new CategoriaService(context);
            IList<Categoria> listaCategorias = categoriaService.ObterSubCategoriasAtivas();

            try
            {
                foreach (Categoria categoriaItem in listaCategorias)
                {
                    //orcamento-online-categorias
                    retorno.Append("<url><loc>" + Config.UrlSite + categoriaItem.Url + "</loc><changefreq>weekly</changefreq><priority>0.70</priority></url>" + Environment.NewLine +
                                   "<url><loc>" + Config.UrlSite + categoriaItem.UrlFornecedores + "</loc><changefreq>weekly</changefreq><priority>0.70</priority></url>" + Environment.NewLine);

                    IList<LinkInterno> linksInternos = linkInternoService.MontarLinksInternosTermosDaCategoria(categoriaItem, 0, null, null);
                    //orcamento-online-categorias/TERMO
                    foreach (LinkInterno linkInterno in linksInternos)
                    {
                        retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                    }

                }

            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return retorno.ToString();
        }

        public string ObterUrlsCategoriaEstado()
        {
            CidadeService cidadeService = new CidadeService(context);
            LinkInternoService linkInternoService = new LinkInternoService(context);
            StringBuilder retorno = new StringBuilder(String.Empty);

            CategoriaService categoriaService = new CategoriaService(context);
            IList<Categoria> listaCategorias = categoriaService.ObterSubCategoriasAtivas();


            foreach (Categoria categoriaItem in listaCategorias)
            {
                IList<LinkInterno> linksInternos = new List<LinkInterno>();

                linksInternos = linkInternoService.MontarLinksInternosDeEstado(categoriaItem, "", Persona.Comprador);

                //orcamento-online-categoria-estados
                foreach (LinkInterno linkInterno in linksInternos)
                {
                    retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                }

                //orcamento-online-categoria-estado/TERMO
                foreach (int estado in Enum.GetValues(typeof(UF)))
                {
                    linksInternos = linkInternoService.MontarLinksInternosTermosDaCategoria(categoriaItem, estado, null, null);
                    foreach (LinkInterno linkInterno in linksInternos)
                    {
                        retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                    }
                }
            }
            return retorno.ToString();
        }

        public string ObterUrlsCategoriaCidade()
        {
            LinkInternoService linkInternoService = new LinkInternoService(context);
            StringBuilder retorno = new StringBuilder(String.Empty);

            CategoriaService categoriaService = new CategoriaService(context);
            IList<Categoria> listaCategorias = categoriaService.ObterSubCategoriasAtivas();
            foreach (Categoria categoriaItem in listaCategorias)
            {
                foreach (string estado in Enum.GetNames(typeof(UF)))
                {
                    IList<LinkInterno> linksInternos = new List<LinkInterno>();

                    UF uf = (UF)Enum.Parse(typeof(UF), estado);
                    linksInternos = linkInternoService.MontarLinksInternosCidades(categoriaItem, uf, Persona.Comprador);

                    //orcamento-online-categoria-cidades
                    foreach (LinkInterno linkInterno in linksInternos)
                    {
                        retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                    }
                }
            }
            return retorno.ToString();
        }

        public string ObterUrlsCategoriasBairros(int idCategoriaPai)
        {
            CidadeService cidadeService = new CidadeService(context);
            LinkInternoService linkInternoService = new LinkInternoService(context);
            StringBuilder retorno = new StringBuilder(String.Empty);

            CategoriaService categoriaService = new CategoriaService(context);
            IList<Categoria> listaCategorias = categoriaService.ObterCategoriasDeUmTema(idCategoriaPai);
            foreach (Categoria categoriaItem in listaCategorias)
            {
                foreach (string estado in Enum.GetNames(typeof(UF)))
                {
                    IList<LinkInterno> linksInternos = new List<LinkInterno>();

                    UF uf = (UF)Enum.Parse(typeof(UF), estado);
                    IList<Cidade> cidades = cidadeService.ObterCidades(uf);
                    foreach (Cidade cidade in cidades)
                    {
                        foreach (Bairro bairro in cidade.Bairros)
                        {
                            linksInternos = linkInternoService.MontarLinksInternosBairro(cidade, categoriaItem, Persona.Comprador);
                            //orcamento-online-categoria-cidade-bairros
                            foreach (LinkInterno linkInterno in linksInternos)
                            {
                                retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                            }
                        }
                    }
                }
            }

            return retorno.ToString();
        }


        public string ObterUrlsCategoriaBairrosComTermos(int idCategoriaPai)
        {
            CidadeService cidadeService = new CidadeService(context);
            LinkInternoService linkInternoService = new LinkInternoService(context);
            StringBuilder retorno = new StringBuilder(String.Empty);

            CategoriaService categoriaService = new CategoriaService(context);
            IList<Categoria> listaCategorias = categoriaService.ObterCategoriasDeUmTema(idCategoriaPai);
            foreach (Categoria categoriaItem in listaCategorias)
            {
                foreach (string estado in Enum.GetNames(typeof(UF)))
                {
                    IList<LinkInterno> linksInternos = new List<LinkInterno>();

                    UF uf = (UF)Enum.Parse(typeof(UF), estado);
                    IList<Cidade> cidades = cidadeService.ObterCidades(uf);
                    foreach (Cidade cidade in cidades)
                    {
                        foreach (Bairro bairro in cidade.Bairros)
                        {
                            linksInternos = linkInternoService.MontarLinksInternosTermosDaCategoria(categoriaItem, 0, bairro, cidade);
                            //orcamento-online-categoria-cidades-bairros/TERMO
                            foreach (LinkInterno linkInterno in linksInternos)
                            {
                                retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                            }
                        }

                        linksInternos = linkInternoService.MontarLinksInternosTermosDaCategoria(categoriaItem, 0, null, cidade);
                        //orcamento-online-categoria-cidades/TERMO
                        foreach (LinkInterno linkInterno in linksInternos)
                        {
                            retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>weekly</changefreq><priority>0.60</priority></url>" + Environment.NewLine);
                        }
                    }
                }
            }
            return retorno.ToString();
        }

        public string ObterMapaTemas(IList<Categoria> listaTemas)
        {
            StringBuilder retorno = new StringBuilder(String.Empty);
            CategoriaService categoriaService = new CategoriaService(context);
            LinkInternoService linkInternoService = new LinkInternoService(context);

            try
            {
                foreach (Categoria temaDaLista in listaTemas)
                {
                    retorno.Append("<url><loc>" + Config.UrlSite + "mapa-" + temaDaLista.Url + "</loc><changefreq>weekly</changefreq><priority>0.50</priority></url>" + Environment.NewLine);

                    IList<LinkInterno> linksInternos = linkInternoService.MontarLinksInternosDeEstado(temaDaLista, "", Persona.MotorBusca);
                    foreach (LinkInterno linkInterno in linksInternos)
                    {
                        retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>monthly</changefreq><priority>0.40</priority></url>" + Environment.NewLine);
                    }

                    linksInternos = linkInternoService.MontarLinksInternosMesAno(temaDaLista, 0, "");
                    foreach (LinkInterno linkInterno in linksInternos)
                    {
                        retorno.Append("<url><loc>" + Config.UrlSite + linkInterno.UrlAmigavel + "</loc><changefreq>monthly</changefreq><priority>0.40</priority></url>" + Environment.NewLine);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return retorno.ToString();
        }

        #endregion
    }
}
