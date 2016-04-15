using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using PortalEscolar.Data;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Common;
using System.Xml.Linq;
using OrcamentoNet.Entity.Enum;
using System.Data;

namespace OrcamentoNet.LocalService
{
    public class CategoriaService : ICategoriaService
    {
        private IDataContext context;


        #region "Métodos Privados"

        private IList<LinkInterno> ObterLinksCidades(Categoria categoria)
        {
            IList<LinkInterno> listaLinksCidades = new List<LinkInterno>();

            try
            {
                IList<Cidade> listaCidades = context.Repository<Cidade>().Where(x => x.Uf == UF.RJ || x.Uf == UF.SP || x.Uf == UF.PR || x.Uf == UF.MG || x.Uf == UF.BA).OrderBy(x => x.Uf).ToList();

                foreach (Cidade cidade in listaCidades)
                {
                    LinkInterno linkInterno = new LinkInterno();
                    linkInterno.Nome = cidade.Nome + " - " + cidade.Uf.ToString();
                    linkInterno.ToolTip = "Solicite orçamento online grátis de " + categoria.Nome + " em " + cidade.Nome + " (" + cidade.Uf.ToString() + ").";
                    linkInterno.UrlAmigavel = "/orcamento-online-" + Common.UtilString.GerarUrlParaSeo(categoria.UrlMappings) + "-" + Common.UtilString.GerarUrlParaSeo(cidade.Nome) + "-" + cidade.Uf.ToString().ToLower() + "-" + categoria.Id.ToString() + "-" + cidade.Id.ToString() + ".aspx";
                    listaLinksCidades.Add(linkInterno);
                }
                listaLinksCidades = listaLinksCidades.OrderBy(l => l.Nome).ToList();
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return listaLinksCidades;
        }

        private IList<LinkInterno> ObterLinksTermos(Categoria categoria)
        {
            IList<LinkInterno> listaLinksTermos = new List<LinkInterno>();

            try
            {
                IList<string> listaTermos = categoria.Termo.Split(',');
                foreach (string termo in listaTermos)
                {
                    string termoSemEspacosAoRedor = termo.Trim();
                    LinkInterno linkInterno = new LinkInterno();
                    linkInterno.Nome = termoSemEspacosAoRedor;
                    linkInterno.ToolTip = "Solicite orçamento online grátis de " + categoria.Nome + " para " + termoSemEspacosAoRedor + ".";
                    linkInterno.UrlAmigavel = "/" + Common.UtilString.GerarUrlParaSeo(categoria.UrlMappings) + "-" + categoria.Id.ToString() + "/" + Common.UtilString.GerarUrlParaSeo(termoSemEspacosAoRedor) + ".aspx";
                    listaLinksTermos.Add(linkInterno);
                }
                listaLinksTermos = listaLinksTermos.OrderBy(l => l.Nome).ToList();
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return listaLinksTermos;
        }
        #endregion

        #region "Métodos Públicos"
        public CategoriaService(IDataContext contextData)
        {
            context = contextData;
        }


        public Categoria Obter(int id, bool montarLinkInterno)
        {
            Categoria categoria = new Categoria();

            try
            {
                categoria = context.Repository<Categoria>().Where(x => x.Id == id).FirstOrDefault();

                //if (montarLinkInterno)
                //categoria.LinksInternos = this.ObterLinksCidades(categoria).Concat(this.ObterLinksTermos(categoria)).ToList();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return categoria;
        }

        public IList<Categoria> ObterCategoriasAtivas()
        {
            IList<Categoria> subCategorias = new List<Categoria>();

            try
            {
                subCategorias = context.Repository<Categoria>().ToList();
                subCategorias = subCategorias.Where(x => x.Pai.Id == 0 && x.Ativo == true).OrderBy(y => y.Nome).ToList();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return subCategorias;
        }

        public IList<Categoria> ObterSubCategoriasDeUmaCategoria(IList<string> categorias)
        {
            IList<Categoria> subCategoriasResultado = new List<Categoria>();

            foreach (string categoria in categorias)
            {
                subCategoriasResultado.Add(Obter(Convert.ToInt32(categoria), false));
            }
            return subCategoriasResultado;

        }

        public string MontarHTMLDeTermo(IList<string> categorias, IList<Termo> termos)
        {
            string htmlRetorno = String.Empty;

            foreach (string itemCategoria in categorias)
            {
                Categoria categoria = Obter(int.Parse(itemCategoria), false);

                string termaCategoriaHtml = categoria.Nome;

                string termoHtml = String.Empty;
                foreach (Termo itemTermo in termos.Where(x => x.IdCategoria == categoria.Id).ToList())
                {
                    if (!String.IsNullOrEmpty(termoHtml))
                    {
                        termoHtml += ", " + itemTermo.Nome;
                    }
                    else
                    {
                        termoHtml = itemTermo.Nome;
                    }
                }

                htmlRetorno += "- " + termaCategoriaHtml + ": " + termoHtml +";" + Environment.NewLine;
            }

            return htmlRetorno;
        }

        public IList<Categoria> ObterSubCategorias()
        {
            IList<Categoria> subCategorias = new List<Categoria>();

            try
            {
                subCategorias = context.Repository<Categoria>().ToList();
                subCategorias.Where(x => x.Pai.Id != 0).OrderBy(y => y.Nome).ToList();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return subCategorias;
        }

        public IList<Categoria> ObterSubCategoriasAtivas()
        {
            IList<Categoria> subCategorias = new List<Categoria>();

            try
            {
                subCategorias = context.Repository<Categoria>()
                    .Where(x => x.Pai.Id != 0 && x.Ativo == true)
                    .OrderBy(y => y.Nome).ToList();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return subCategorias;
        }

        public IList<Categoria> ObterTemasAtivos()
        {
            IList<Categoria> subCategorias = new List<Categoria>();

            try
            {
                subCategorias = context.Repository<Categoria>()
                    .Where(x => x.Pai.Id == 0 && x.Ativo == true)
                    .OrderBy(y => y.Nome).ToList();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return subCategorias;
        }

        public IList<Categoria> ObterCategoriasComFornecedoresCadastrados()
        {
            IList<Categoria> subCategorias = new List<Categoria>();
            IList<Categoria> resultado = new List<Categoria>();
            IList<Categoria> resultadoFilhos = new List<Categoria>();

            try
            {
                subCategorias = context.Repository<Categoria>().ToList();
                subCategorias = subCategorias.Where(x => x.Pai.Id == 0).OrderBy(y => y.Nome).ToList();

                Categoria pai;
                Categoria filho;

                foreach (Categoria item in subCategorias)
                {
                    pai = new Categoria();
                    pai = item;
                    resultadoFilhos = new List<Categoria>();

                    foreach (Categoria item2 in item.SubCategorias)
                    {
                        if (item2.Ativo)
                        {
                            filho = new Categoria();
                            filho = item2;
                            resultadoFilhos.Add(filho);
                        }
                    }
                    pai.SubCategorias = resultadoFilhos;
                    resultado.Add(pai);
                }
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return resultado;
        }

        public IEnumerable<XElement> ObterXMLCategoria(int idCategoria)
        {
            XElement xml = XElement.Load(Config.CaminhoFisico + "Categoria.xml");

            var categoria = from p in xml.Elements("categoria")
                            where (int)p.Element("id") == idCategoria
                            select p;
            return categoria;
        }


        public void Inserir(Categoria categoria)
        {
            categoria.Ativo = true;
            context.Insert(categoria);
        }
        #endregion

        /// <summary>
        /// Retorna todas as subcategorias de uma categoria que tenha fornecedor cadastrado
        /// /// </summary>
        /// <param name="cidade"></param>
        /// <param name="categoriaPai"></param>
        /// <returns></returns>
        public IList<Categoria> ObterSubCategoriasComFornecedorPorCidade(Cidade cidade, int categoriaPai)
        {
            IList<Categoria> categoriasComFornecedor = new List<Categoria>();

            IList<Fornecedor> fornecedoresCidade = context.Repository<Fornecedor>().Where(x => x.Cidades.Contains(cidade) && x.Status != Status.Inativo).ToList();

            var categorias = (from c in fornecedoresCidade select c.SubCategorias).Distinct();

            foreach (var item in categorias)
            {
                for (int i = 0; i < item.Count(); i++)
                {
                    if (item[i].Pai.Id == categoriaPai && !categoriasComFornecedor.Contains(item[i]))
                    {
                        item[i].Termos = ObterTermos(item[i].Id);

                        if (item[i].Ativo)
                            categoriasComFornecedor.Add(item[i]);
                    }
                }
            }

            return categoriasComFornecedor.OrderBy(x => x.Nome).ToList(); ;
        }


        public IList<Categoria> ObterCategoriasDeUmTema(int idCategoriaPai)
        {
            Categoria categoria = context.Repository<Categoria>().Where(x => x.Id == idCategoriaPai).FirstOrDefault();

            IList<Categoria> categoriasComFornecedor = new List<Categoria>();

            if (categoria != null)
            {
                if (categoria.Pai.Id == 0)
                {
                    idCategoriaPai = categoria.Id;
                }
                else
                {
                    idCategoriaPai = categoria.Pai.Id;
                    //Isso vai deixar a categoria recebida na primeira posição no formulario
                    //independente da ordem alfabetica
                    categoria.Termos = ObterTermos(categoria.Id);
                    categoriasComFornecedor.Add(categoria);

                }
            }
            IList<Categoria> subCategorias = new List<Categoria>();

            try
            {
                subCategorias = context.Repository<Categoria>().ToList();
                subCategorias = subCategorias.Where(x => x.Pai.Id == idCategoriaPai && x.Ativo == true).OrderBy(y => y.Nome).ToList();

                foreach (var categoriaItem in subCategorias)
                {
                    if (categoria.Ativo && categoriaItem.Id != categoria.Id)
                    {
                        categoriaItem.Termos = ObterTermos(categoriaItem.Id);
                        categoriasComFornecedor.Add(categoriaItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }

            return categoriasComFornecedor;
        }

        public IList<Termo> ObterTermosFornecedor(int idCategoria)
        {
            IList<string> listaTermos = new List<string>();

            #region Casa e Decoracao

            if (idCategoria == 22)
            {
                listaTermos.Add("fachadas");
                listaTermos.Add("pias e bancadas");
                listaTermos.Add("pisos internos ou externos");
                listaTermos.Add("revestimento jazigos e mausoléus");
                listaTermos.Add("restauração e recuperação");
                listaTermos.Add("soleiras e rodapés");

            }

            if (idCategoria == 28)
            {
                listaTermos.Add("armário embutido");
                listaTermos.Add("banheiros sobmedida");
                //listaTermos.Add("carpintaria");
                listaTermos.Add("cozinhas sob medida");
                listaTermos.Add("dormitórios planejados");
                listaTermos.Add("móveis escritórios empresariais");
                listaTermos.Add("móveis sobmedida");
                listaTermos.Add("loja de móveis planejados");
                listaTermos.Add("porta de correr");
                listaTermos.Add("prateleira");

            }
            #endregion

            #region Festas e Eventos

            if (idCategoria == 53)
            {
                listaTermos.Add("auditórios");
                listaTermos.Add("salas para eventos");
                listaTermos.Add("espaço para eventos");
                listaTermos.Add("sítio ou pousada");
            }

            if (idCategoria == 54)
            {
                listaTermos.Add("buffet japonês");
                listaTermos.Add("culinária japonesa");
                listaTermos.Add("buffet japonês casamento");
                listaTermos.Add("sushiman");
            }

            if (idCategoria == 58)
            {
                listaTermos.Add("lembranças para casamento");
                listaTermos.Add("chinelos personalizados");
                listaTermos.Add("lembrancinhas para casamento");
                listaTermos.Add("lembrancinhas festa infantil");
                listaTermos.Add("porta-retratos");
                listaTermos.Add("porta-recados");
                listaTermos.Add("tema infantil");
            }

            if (idCategoria == 143)
            {
                listaTermos.Add("aluguel de cadeiras e mesas");
                listaTermos.Add("aluguel de cadeiras e mesas para casamento");
                listaTermos.Add("aluguel de cadeiras e mesas eventos");
                listaTermos.Add("aluguel de cadeiras e mesas aniversário");
                listaTermos.Add("aluguel de cadeiras e mesas para festas");
            }

            if (idCategoria == 55)
            {
                listaTermos.Add("decoração em festas de casamento");
                listaTermos.Add("decoração em festas de aniversários");

            }

            if (idCategoria == 174)
            {
                listaTermos.Add("cabeleireiro infantil e salão fashion");
                listaTermos.Add("contador de histórias");
                listaTermos.Add("escultura de balões");
                listaTermos.Add("penteados radicais");
                listaTermos.Add("personagem vivo");
                listaTermos.Add("pintura de unha");
                listaTermos.Add("mágica e ilusionismo");
                listaTermos.Add("maquiagem artística");
                listaTermos.Add("show de palhaços");
                listaTermos.Add("teatro de fantoches e ventríloqua");
            }
            if (idCategoria == 181)
            {
                listaTermos.Add("assessoria completa para casamento");
                listaTermos.Add("assessoria planejamento de cronograma para casamento");
                listaTermos.Add("assessoria elaboração de orçamento para casamento");
                listaTermos.Add("assessoria parcial para casamento");
                listaTermos.Add("assessoria para eventos corporativos e empresariais");
                listaTermos.Add("assessoria para confraternizações");
                listaTermos.Add("assessoria para cursos, festas, treinamentos, shows, workshops");

            }

            if (idCategoria == 213)
            {
                listaTermos.Add("curso de maquiagem");
                listaTermos.Add("maquiagem madrinha");
                listaTermos.Add("maquiagem noiva");
                listaTermos.Add("maquiagem social");
            }
            #endregion

            #region Obras e Reformas

            if (idCategoria == 33)
            {
                listaTermos.Add("conserto ar-condicionado");
                listaTermos.Add("manutenção ar-condicionado");
                listaTermos.Add("manutenção elétrica");
                listaTermos.Add("instalação elétrica");
                listaTermos.Add("manutenção de máquinas industriais");
            }

            if (idCategoria == 40)
            {
                listaTermos.Add("grafiato");
                listaTermos.Add("pintura");
                listaTermos.Add("pintura em prédio");
                listaTermos.Add("pintura em casa");
                listaTermos.Add("profissional pintor de apartamento");
            }

            if (idCategoria == 186)
            {
                listaTermos.Add("construção ou reformas em geral");
                listaTermos.Add("demolição");
                listaTermos.Add("gerenciamento de obras");
                listaTermos.Add("inspeções prediais");
                listaTermos.Add("projetos de acessibilidade");
                listaTermos.Add("recuperação estrutural ou fachada");
                listaTermos.Add("retirada entulho e bota fora");
                listaTermos.Add("terraplenagem");
            }

            if (idCategoria == 186)
            {
                listaTermos.Add("bob cat");                
                listaTermos.Add("caminhão basculante");
                listaTermos.Add("caminhão pipa");
                listaTermos.Add("escavadeira");
                listaTermos.Add("retroescavadeira");
                listaTermos.Add("rolos-compactadores");
            }


            #endregion

            IList<Termo> termos = new List<Termo>();
            Termo termo;

            foreach (String item in listaTermos)
            {
                termo = new Termo();
                termo.IdCategoria = idCategoria;
                termo.Nome = item;
                termos.Add(termo);
            }
            return termos;

        }

        public IList<Termo> ObterTermos(int idCategoria)
        {

            IList<string> listaTermos = new List<string>();

            #region Casa e Decoração

            if (idCategoria == 19)
            {
                listaTermos.Add("box");
                listaTermos.Add("espelho");
                listaTermos.Add("vidros");
            }

            if (idCategoria == 22)
            {
                listaTermos.Add("fachadas");
                listaTermos.Add("pias e bancadas");
                listaTermos.Add("pisos internos");
                listaTermos.Add("pisos externos");
                listaTermos.Add("revestimento jazigos e mausoléus");
                listaTermos.Add("soleiras e rodapés");
            }

            if (idCategoria == 28)
            {
                listaTermos.Add("armário embutido");
                listaTermos.Add("bancada");
                listaTermos.Add("móveis planejados banheiros");
                listaTermos.Add("móveis planejados cozinha e sob medida");
                listaTermos.Add("móveis planejados dormitórios");
                listaTermos.Add("móveis planejados escritórios");
                listaTermos.Add("móveis modulados e sob medida");
                listaTermos.Add("móveis planejados home office");
                listaTermos.Add("móveis planejados home theater");
                listaTermos.Add("móveis planejados lavanderias");
                listaTermos.Add("móveis planejados para sala");
            }

            if (idCategoria == 30)
            {
                listaTermos.Add("cobertura para garagem");
                listaTermos.Add("cobertura em lona com cortina");
                listaTermos.Add("cobertura policabornato");
                listaTermos.Add("cobertura túnel passarela");
                listaTermos.Add("toldo articulado");
                listaTermos.Add("toldo cabana");
                listaTermos.Add("toldo janela, porta e varanda");
                listaTermos.Add("toldo retratil");
                listaTermos.Add("toldo trilho");

            }

            if (idCategoria == 41)
            {
                listaTermos.Add("conserto e instalação de bombas");
                listaTermos.Add("limpeza de piscina");
                listaTermos.Add("instalação piscina de fibra");
                listaTermos.Add("reforma piscinas azulejo");
                listaTermos.Add("reforma piscinas fibra");
                listaTermos.Add("tratamento de água");
            }

            if (idCategoria == 133)
            {
                listaTermos.Add("janelas, sacadas e varandas");
                listaTermos.Add("piscinas");
                listaTermos.Add("quadras esportivas");
                listaTermos.Add("tela para insetos");
            }

            if (idCategoria == 36)
            {
                listaTermos.Add("aluguel de plantas");
                listaTermos.Add("implantação de jardim");
                listaTermos.Add("manutenção de jardim");
                listaTermos.Add("poda");
                listaTermos.Add("projeto comercial/residencial");
                listaTermos.Add("pulverização");


            }

            #endregion

            #region Festas e Eventos

            if (idCategoria == 53)
            {
                listaTermos.Add("auditórios, centro de convenções ou salas para palestras");
                listaTermos.Add("churrasqueira");
                listaTermos.Add("espaço aberto (ambiente externo)");
                listaTermos.Add("espaço fechado (ambiente interno)");
                listaTermos.Add("palco para banda ou músicos");
                listaTermos.Add("piscina, quadras de esportes ou salão de jogos");
                listaTermos.Add("sítio ou pousada");
            }
            if (idCategoria == 54)
            {
                listaTermos.Add("decoração típica japonesa (barcos, pontes, etc.)");
                listaTermos.Add("entradas (gyoza, harumaki, etc.)");
                listaTermos.Add("pratos quentes (tempura, yakisoba, etc.)");
                listaTermos.Add("sashimi (peixe crú)");
                listaTermos.Add("sushi com peixe (atum, salmão, etc.)");
                listaTermos.Add("sushi enrolado (california, makimono, etc.)");
                listaTermos.Add("sushi hot roll ou hot filadelfia (sushi frito)");
                listaTermos.Add("sushiman no local");
                listaTermos.Add("temaki (cones)");
            }
            if (idCategoria == 55)
            {
                listaTermos.Add("eventos corporativos");
                listaTermos.Add("eventos sociais (casamentos, bodas, aniversários, etc.)");
                listaTermos.Add("paisagismo");
            }
            if (idCategoria == 56)
            {
                listaTermos.Add("brigadeiro");
            }

            if (idCategoria == 58)
            {
                listaTermos.Add("champanhe e vinho com rótulos personalizados");
                listaTermos.Add("chinelos personalizados");
                listaTermos.Add("porta-jóias");
                listaTermos.Add("porta-retratos");
                listaTermos.Add("porta-recados");
                listaTermos.Add("tema infantil");
            }

            if (idCategoria == 123)
            {
                listaTermos.Add("bebidas alcóolicas (cerveja, vinho, drinks e whisky)");
                listaTermos.Add("bebidas não-alcóolicas (água, sucos e refrigerantes)");
                listaTermos.Add("almoço (entrada, prato principal e sobremesa)");
                listaTermos.Add("brunch");
                listaTermos.Add("chá da tarde");
                listaTermos.Add("café da manhã / coffee break");
                listaTermos.Add("coquetel / cocktail");
                listaTermos.Add("jantar (entrada, prato principal e sobremesa)");
                listaTermos.Add("carnes (escalopinho, molho madeira, etc.)");
                listaTermos.Add("ceia de natal ou ceia natalina");
                listaTermos.Add("crepes (salgados e doces)");
                listaTermos.Add("feijoada");
                listaTermos.Add("kit festa");
                listaTermos.Add("massas (farfale, penne, raviolli, etc.)");
                listaTermos.Add("mesa de sustentação");
                listaTermos.Add("peixes");
                listaTermos.Add("salada");
                listaTermos.Add("salgadinhos");
                listaTermos.Add("strogonoff (carne, frango, camarão)");
            }
            if (idCategoria == 126)
            {
                listaTermos.Add("book");
                listaTermos.Add("com o making of");
                listaTermos.Add("somente o evento");
                listaTermos.Add("fotojornalismo");
                listaTermos.Add("tema adulto");
                listaTermos.Add("tema infantil");
            }
            if (idCategoria == 128)
            {
                listaTermos.Add("anos 70 ou disco music");
                listaTermos.Add("anos 80 ou festa ploc");
                listaTermos.Add("axé");
                listaTermos.Add("bossa nova ou jazz");
                listaTermos.Add("forró");
                listaTermos.Add("funk");
                listaTermos.Add("mpb");
                listaTermos.Add("pop rock nacional");
                listaTermos.Add("pop rock internacional");
                listaTermos.Add("samba e pagode");
                listaTermos.Add("sertanejo");
            }
            if (idCategoria == 129)
            {
                listaTermos.Add("anos 70 ou disco music");
                listaTermos.Add("anos 80 ou festa ploc");
                listaTermos.Add("axé");
                listaTermos.Add("bossa nova ou jazz");
                listaTermos.Add("forró");
                listaTermos.Add("funk");
                listaTermos.Add("mpb");
                listaTermos.Add("música clássica, orquestra ou instrumentistas");
                listaTermos.Add("pop rock nacional");
                listaTermos.Add("pop rock internacional");
                listaTermos.Add("samba e pagode");
                listaTermos.Add("sertanejo");
            }
            if (idCategoria == 130)
            {
                listaTermos.Add("tema adulto");
                listaTermos.Add("tema infantil");
            }
            if (idCategoria == 142)
            {
                listaTermos.Add("com o making of");
                listaTermos.Add("somente o evento");
                listaTermos.Add("somente 1 câmera");
                listaTermos.Add("mais de 1 câmera");
                listaTermos.Add("tema adulto");
                listaTermos.Add("tema infantil");
            }
            if (idCategoria == 143)
            {
                listaTermos.Add("aço ou ferro");
                listaTermos.Add("madeira");
                listaTermos.Add("plástico");
            }
            if (idCategoria == 145)
            {
                listaTermos.Add("igreja");
                listaTermos.Add("salão");
            }
            if (idCategoria == 171)
            {
                listaTermos.Add("batata frita");
                listaTermos.Add("bebidas");
                listaTermos.Add("docinhos");
                listaTermos.Add("mini cachorro quente");
                listaTermos.Add("mini churros");
                listaTermos.Add("mini hamburguer");
                listaTermos.Add("mini pizza");
                listaTermos.Add("pão de queijo");
                listaTermos.Add("pipoca");
                listaTermos.Add("salgadinhos");
                listaTermos.Add("sorvete");
            }
            if (idCategoria == 172)
            {
                listaTermos.Add("barbie");
                listaTermos.Add("ben 10");
                listaTermos.Add("branca de neve");
                listaTermos.Add("cinderela");
                listaTermos.Add("fadas");
                listaTermos.Add("fazendinha");
                listaTermos.Add("galinha pintadinha");
                listaTermos.Add("hello kitty");
                listaTermos.Add("madagascar");
                listaTermos.Add("patati patata");
                listaTermos.Add("super heróis (batman, homem aranha, super homem, etc.)");
                listaTermos.Add("times de futebol");
            }

            if (idCategoria == 174)
            {
                listaTermos.Add("cabeleireiro infantil e salão fashion");
                listaTermos.Add("contador de histórias");
                listaTermos.Add("escultura de balões");
                listaTermos.Add("penteados radicais (meninos) e fashion (meninas)");
                listaTermos.Add("personagem vivo");
                listaTermos.Add("pintura de unha");
                listaTermos.Add("mágica e ilusionismo");
                listaTermos.Add("maquiagem artística");
                listaTermos.Add("show de palhaços");
                listaTermos.Add("teatro de fantoches e ventríloqua");
            }
            if (idCategoria == 175)
            {
                listaTermos.Add("área baby, espaço baby, baby park ou kit baby");
                listaTermos.Add("air game, ping pong, sinuca ou totó");
                listaTermos.Add("cama elástica, pula pula ou super jumbo");
                listaTermos.Add("flipper, fliperama, máquina de dança ou simuladores");
                listaTermos.Add("futebol de sabão");
                listaTermos.Add("ioiô humano ou high jump");
                listaTermos.Add("piscina de bolas ou piscina de bolinhas");
                listaTermos.Add("tobogã");
                listaTermos.Add("touro ou surf mecânico");
                listaTermos.Add("videokê");
            }
            if (idCategoria == 176)
            {
                listaTermos.Add("espaço aberto (ambiente externo)");
                listaTermos.Add("espaço fechado (ambiente interno)");
                listaTermos.Add("pacote completo (buffet, bebidas, doces, animação, equipe, jogos, DJ, etc.)");
            }
            if (idCategoria == 181)
            {
                listaTermos.Add("assessoria completa (planejamento de cronograma, elaboração de orçamento, indicação de fornecedores, seleção, gestão e acompanhamento)");
                listaTermos.Add("assessoria parcial (planejamento do dia do evento, gestão e acompanhamento de fornecedores)");
                listaTermos.Add("corporativos e empresariais (confraternizações, cursos, festas, treinamentos, shows, workshops, etc.)");
                listaTermos.Add("negócios (desfiles, exposições, feiras, inaugurações, lançamentos, mostras, salões, etc.)");
                listaTermos.Add("sociais (aniversários, bat ou bar mitzvah, batizados, bodas, casamentos, chás, debutantes, festas de 15 anos, formaturas, recepções, RSVP, etc.)");
                listaTermos.Add("técnicos e científicos (conferências, congressos, convenções, palestras, seminários, etc.)");
                listaTermos.Add("cerimonialistas");
                listaTermos.Add("equipes de apoio e staff (atendentes, manobristas, modelos, recepcionistas, seguranças, etc.)");
            }
            if (idCategoria == 194)
            {
                listaTermos.Add("aniversários ou bodas (bem-vividos)");
                listaTermos.Add("batizados ou nascimentos (bem-nascidos)");
                listaTermos.Add("casamentos (bem-casados)");
            }
            if (idCategoria == 195)
            {
                listaTermos.Add("tema adulto");
                listaTermos.Add("tema infantil");
            }
            if (idCategoria == 197)
            {
                listaTermos.Add("entradas (pão de alho, caldinho de feijão, etc.)");
                listaTermos.Add("guarnições (arroz, batata frita, etc.)");
                listaTermos.Add("carnes bovinas");
                listaTermos.Add("carnes suínas");
                listaTermos.Add("frango");
                listaTermos.Add("saladas (salada verde, maionese, etc.)");
                listaTermos.Add("sobremesas (banana, abacaxi, etc.)");
            }

            if (idCategoria == 213)
            {
                listaTermos.Add("curso de maquiagem");
                listaTermos.Add("maquiagem madrinha");
                listaTermos.Add("maquiagem noiva");
                listaTermos.Add("maquiagem social");
            }
            #endregion

            #region Obras e Reformas
            if (idCategoria == 25)
            {
                listaTermos.Add("cimento queimado");
                listaTermos.Add("pastilhas ou ladrilhos");
                listaTermos.Add("pisos de madeira (assoalho, taboão, taco, parquet)");
                listaTermos.Add("pisos elevados / flutuantes (carpete, carpete de madeira, fórmica, laminado, tábua corrida)");
                listaTermos.Add("pisos frios (cerâmica, granito, mármore, porcelanato ou pisos de pedra)");
                listaTermos.Add("pisos vinílicos / PVC (borracha)");
                listaTermos.Add("rejunte");
                listaTermos.Add("synteko");
            }
            if (idCategoria == 33)
            {
                listaTermos.Add("ar-condicionado (troca ou instalação)");
                listaTermos.Add("carga elétrica (aumento ou distribuição)");
                listaTermos.Add("fiação elétrica (troca ou manutenção)");
                listaTermos.Add("máquinas industriais e equipamentos elétricos (instalação ou manutenção)");
                listaTermos.Add("relógios, quadros elétricos, fusíveis ou disjuntores (troca ou manutenção)");
                listaTermos.Add("tomadas, interruptores, luminárias ou lustres (troca ou instalação)");
            }
            if (idCategoria == 34)
            {
                listaTermos.Add("conserto de vazamento (água, esgoto ou gás)");
                listaTermos.Add("instalar ou trocar banheira ou chuveiro");
                listaTermos.Add("troca de tubulação (água, esgoto ou gás)");

            }
            if (idCategoria == 39)
            {
                listaTermos.Add("calçadas");
                listaTermos.Add("manilhas");
                listaTermos.Add("muros, paredes ou lajes");
                listaTermos.Add("pias ou louças de banheiro");
            }
            if (idCategoria == 40)
            {
                listaTermos.Add("argamassa de reboco");
                listaTermos.Add("grafiato ou textura");
                listaTermos.Add("pintura externa");
                listaTermos.Add("pintura interna comum");

            }
            if (idCategoria == 155 || idCategoria == 36)
            {
                listaTermos.Add("design e decoração de interiores");
                listaTermos.Add("projeto comercial");
                listaTermos.Add("projeto residencial");
                listaTermos.Add("paisagismo ou urbanismo");
            }
            if (idCategoria == 165)
            {
                listaTermos.Add("corrimão");
                listaTermos.Add("escadas");
                listaTermos.Add("ferragens");
                listaTermos.Add("para peito");
                listaTermos.Add("portão de alumínio");                         
                listaTermos.Add("portão de correr automático");
                listaTermos.Add("porta deslizante");
                listaTermos.Add("portão de ferro");
                listaTermos.Add("portão de subir");
                listaTermos.Add("porta social");
                listaTermos.Add("grades");
                listaTermos.Add("serralheria");

            }
            if (idCategoria == 168)
            {
                listaTermos.Add("dry wall (paredes, divisórias, etc.)");
                listaTermos.Add("forro comum ou removível");
                listaTermos.Add("molduras");
                listaTermos.Add("revestimentos (gesso liso)");
                listaTermos.Add("sancas");
                listaTermos.Add("teto rebaixado");
            }
            if (idCategoria == 182)
            {
                listaTermos.Add("concreto ou tijolo aparente");
                listaTermos.Add("pastilhas, ladrilhos ou mármores (limpeza, polimento, restauração ou troca)");
                listaTermos.Add("vidros");
                listaTermos.Add("lavagem com hidrojateamento (baixa ou alta pressão)");
                listaTermos.Add("lavagem de fachadas");
                listaTermos.Add("pintura em altura, alpinismo industrial ou rapel");
                listaTermos.Add("pintura predial ou fachada");
                listaTermos.Add("rejuntamento, trincas, fissuras, tratamento de concreto ou impermeabilização");

            }

            if (idCategoria == 186)
            {
                listaTermos.Add("construção ou reformas em geral");
                listaTermos.Add("demolição");
                listaTermos.Add("galpão (construção ou reforma)");
                listaTermos.Add("gerenciamento de obras");
                listaTermos.Add("inspeção e vistoria predial");
                listaTermos.Add("laudos periciais");
                listaTermos.Add("licitações");
                listaTermos.Add("projetos de acessibilidade");
                listaTermos.Add("recuperação estrutural/fachada");
                listaTermos.Add("retirada de entulho e bota fora");
                listaTermos.Add("reformas de telhados ou telhas");
                listaTermos.Add("terraplenagem");
            }

            if (idCategoria == 218)
            {
                listaTermos.Add("bob cat");               
                listaTermos.Add("caminhão basculante");
                listaTermos.Add("caminhão pipa");
                listaTermos.Add("escavadeira");
                listaTermos.Add("pá carregadeira");
                listaTermos.Add("retroescavadeira");
                listaTermos.Add("rolos-compactadores");
            }

            if (idCategoria == 219)
            {
                listaTermos.Add("argamassa");
                listaTermos.Add("cerâmicas");
                listaTermos.Add("granitos");
                listaTermos.Add("pastilhas");
                listaTermos.Add("pedras");

            }
            #endregion

            #region Serviços Prediais
            if (idCategoria == 37)
            {
                //listaTermos.Add("carpetes, estofados ou tecidos");
                listaTermos.Add("entulhos e demolições");
                //listaTermos.Add("eventos, feiras ou congressos");
                listaTermos.Add("jardinagem, paisagismo e manutenção de áreas verdes");
                listaTermos.Add("lavagem e impermeabilização de caixa d'água e reservatório de água");
                listaTermos.Add("limpeza pós-obra");
                listaTermos.Add("serviços gerais e de limpeza");
                listaTermos.Add("telhados");
                listaTermos.Add("tratamento de pisos");
                listaTermos.Add("vidros, janelas ou divisórias");
            }

            if (idCategoria == 187)
            {
                listaTermos.Add("alvenaria");
                listaTermos.Add("caixa d'água, reservatório e bombas");
                listaTermos.Add("elétrica");
                listaTermos.Add("elevadores");
                listaTermos.Add("equipamentos de segurança e incêndio");
                listaTermos.Add("gás");
                listaTermos.Add("hidráulica");
                listaTermos.Add("pintura");
                listaTermos.Add("piscinas e áreas de lazer");
                listaTermos.Add("portões, interfones, sistemas de alarme e CFTV");
                listaTermos.Add("sistemas de refrigeração e ar-condicionado central");

               
            }
            #endregion

            #region Sistema de Segurança

            if (idCategoria == 29)
            {
                listaTermos.Add("Alambrados");
                listaTermos.Add("Convencional com hastes de alumínio");
                listaTermos.Add("Com Espetante (um fio por dentro do rolo e o restante acima do rolo com uma haste única)");
                listaTermos.Add("Conjugada com a Rede Navalhada");
            }

            if (idCategoria == 169)
            {
                listaTermos.Add("Câmeras IP");
                listaTermos.Add("Câmera PTZ");
                listaTermos.Add("Circuito Fechado de Televisão");
                listaTermos.Add("Interfone");
                listaTermos.Add("Monitoração em Tempo Real");
            }

            if (idCategoria == 215)
            {
                listaTermos.Add("Alarme");
                listaTermos.Add("Alarme Incêndio");
                listaTermos.Add("Catraca Eletrônica");
                listaTermos.Add("Controle de Acesso Biométrico");
                listaTermos.Add("Controle de Acesso Eletrônico");                
                listaTermos.Add("Detecção de Intrusão");
                listaTermos.Add("Sistema Integrado de Segurança");
            }

            if (idCategoria == 217)
            {
                listaTermos.Add("Copeira");
                listaTermos.Add("Camareira ");
                listaTermos.Add("Garagista/Manobrista");
                listaTermos.Add("Limpeza");
                listaTermos.Add("Portaria");
                listaTermos.Add("Vigilância");
                listaTermos.Add("Zeladoria");
            }

            #endregion

            IList<Termo> termos = new List<Termo>();
            Termo termo;

            foreach (String item in listaTermos)
            {
                termo = new Termo();
                termo.IdCategoria = idCategoria;
                termo.Nome = item;
                termos.Add(termo);
            }
            return termos;
        }

        private string ObterTootip(int idCategoria)
        {
            string tooltip = "";

            if (idCategoria == 25)
            {
                tooltip = "colocação de azulejos mármores ardósia porcelanato banheiros, cozinha, área de serviço área de lazer azulejos";

            }

            if (idCategoria == 33)
            {

            }

            if (idCategoria == 34)
            {

            }

            if (idCategoria == 39)
            {

            }

            if (idCategoria == 40)
            {

            }

            if (idCategoria == 155)
            {

            }
            if (idCategoria == 168)
            {

            }

            if (idCategoria == 186)
            {

            }
            return tooltip;
        }

        public string ObterFaixaCategoria(int idCategoria)
        {
            string faixaCategoria = "A";

            IList<int> categoriasFaixaA = new List<int>();
            categoriasFaixaA.Add(175); //Aluguel de brinquedo
            categoriasFaixaA.Add(174);// Animação e recreação
            categoriasFaixaA.Add(194);
            categoriasFaixaA.Add(129); // Banda ou músicos
            categoriasFaixaA.Add(194);//Bem casados
            categoriasFaixaA.Add(130);//bolo de festas
            categoriasFaixaA.Add(144);//caligrafas           
            categoriasFaixaA.Add(55); // decoração de salão
            categoriasFaixaA.Add(172); // decoração tema infantil
            categoriasFaixaA.Add(128); // dj 
            categoriasFaixaA.Add(56); // doces
            categoriasFaixaA.Add(142); // filmagem
            categoriasFaixaA.Add(145); // flores e arranjos
            categoriasFaixaA.Add(126); // fotografos
            categoriasFaixaA.Add(58); // lembracinhas
            categoriasFaixaA.Add(213); // maquiagem e penteado
            categoriasFaixaA.Add(143); // mesas e cadeiras
            categoriasFaixaA.Add(195); // topos de bolo
            categoriasFaixaA.Add(201); // adesivos
            categoriasFaixaA.Add(205); // banners
            categoriasFaixaA.Add(200); // cartao de visita
            categoriasFaixaA.Add(199); // folheto            
            categoriasFaixaA.Add(204); // panfletos
            categoriasFaixaA.Add(22); //marmores granitos
            categoriasFaixaA.Add(207); //Bandejas e Caixas Plásticas
            categoriasFaixaA.Add(209); //Cartuchos, Toner e Suprimentos de Informática

            IList<int> categoriasFaixaB = new List<int>();
            categoriasFaixaB.Add(19); //box, vidros
            categoriasFaixaB.Add(36); //Jardinagem e Paisagismo
            categoriasFaixaB.Add(30); //cobertura e toldo            
            categoriasFaixaB.Add(176); // casa de festa infantil
            categoriasFaixaB.Add(53); // casa ou salao de festas
            categoriasFaixaB.Add(208); //pintura artistica
            categoriasFaixaB.Add(41); // limpeza piscina
            categoriasFaixaB.Add(203); // letreiros
            categoriasFaixaB.Add(63); // paneis
            categoriasFaixaB.Add(133); // redes de proteção
            categoriasFaixaB.Add(197); // buffet churrasco
            categoriasFaixaB.Add(123); // buffet
            categoriasFaixaB.Add(171); // buffet infantil
            categoriasFaixaB.Add(155); // arquitetos
            categoriasFaixaB.Add(34); // bombeiros
            categoriasFaixaB.Add(168); //Gesso e Gesseiro Profissional
            categoriasFaixaB.Add(33); //Instalação e Manutenção Elétrica
            categoriasFaixaB.Add(39); //Pedreiro
            categoriasFaixaB.Add(25); //Pisos e Azulejos
            categoriasFaixaB.Add(165); //Serralheria, Grades, Portões e Ferragens
            categoriasFaixaB.Add(37); //Limpeza, Conservação e Higienização
            categoriasFaixaB.Add(187); //Manutenção Predial e Industrial           
            categoriasFaixaB.Add(29); //Cercas Elétricas e Telas
            categoriasFaixaB.Add(209); //Criação de Sites e Desenvolvimento Web
            categoriasFaixaB.Add(31); //Dedetização e Desratização
            categoriasFaixaB.Add(32);//Desentupidora
            categoriasFaixaB.Add(97);//Informática
            categoriasFaixaB.Add(92);//Instalação e Manutenção de Ar-Condicionado, Dutos e Coifas
            categoriasFaixaB.Add(169); //Circuito Fechado de Televisão (CFTV) e Sistemas de Segurança
            categoriasFaixaB.Add(217);//Terceirização de Serviços
            categoriasFaixaB.Add(216);//Design e Decoração de Interiores
            categoriasFaixaB.Add(215);//Alarme, Segurança e Catraca Eletrônica 

            IList<int> categoriasFaixaC = new List<int>();
            categoriasFaixaC.Add(186); //Construtoras e Engenharia Civil
            categoriasFaixaC.Add(182);//Pintura e Limpeza de Fachadas Prediais
            categoriasFaixaC.Add(40);//Pintura e Pintor Profissional
            categoriasFaixaC.Add(54); // buffet japones
            categoriasFaixaC.Add(218); // Locação de Equipamentos
            categoriasFaixaC.Add(219); // Locação de Equipamentos



            if (categoriasFaixaA.Contains(idCategoria))
                faixaCategoria = "A";

            if (categoriasFaixaB.Contains(idCategoria))
                faixaCategoria = "B";

            if (categoriasFaixaC.Contains(idCategoria))
                faixaCategoria = "C";

            return faixaCategoria;
        }

        public IList<int> ObterIdsCategoriasPai(int idCategoria)
        {

            IList<int> categorias = new List<int>();
            categorias.Add(175); //Aluguel de brinquedo
            categorias.Add(174);// Animação e recreação
            categorias.Add(194);
            categorias.Add(129); // Banda ou músicos
            categorias.Add(194);//Bem casados
            categorias.Add(130);//bolo de festas
            categorias.Add(144);//caligrafas           
            categorias.Add(55); // decoração de salão
            categorias.Add(172); // decoração tema infantil
            categorias.Add(128); // dj 
            categorias.Add(56); // doces
            categorias.Add(142); // filmagem
            categorias.Add(145); // flores e arranjos
            categorias.Add(126); // fotografos
            categorias.Add(58); // lembracinhas
            categorias.Add(213); // maquiagem e penteado
            categorias.Add(143); // mesas e cadeiras
            categorias.Add(195); // topos de bolo
            categorias.Add(172);
            categorias.Add(197); // buffet churrasco
            categorias.Add(123); // buffet
            categorias.Add(171); // buffet infantil
            
            return categorias;
        }
    }
}
