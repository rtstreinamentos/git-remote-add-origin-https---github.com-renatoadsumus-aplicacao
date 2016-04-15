using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using PortalEscolar.Data;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.LocalService
{
    public class OrcamentoService : IOrcamentoService
    {
        private IDataContext context;

        public OrcamentoService(IDataContext contextData)
        {
            context = contextData;
        }
        public IList<Orcamento> Obter()
        {
            return context.Repository<Orcamento>().ToList();
        }

        public Orcamento Obter(int idOrcamento)
        {
            Orcamento orcamento = context.Repository<Orcamento>().Where(x => x.Id == idOrcamento).FirstOrDefault();

            Orcamento orcamentoResultado = new Orcamento();
            orcamentoResultado = orcamento;

            IList<Categoria> categorias = new List<Categoria>();

            if (orcamento != null)
            {
                foreach (Categoria categoria in orcamento.Categorias)
                {
                    categoria.Termos = ObterTermos(categoria.Id, orcamento.Id);
                    categorias.Add(categoria);
                }

                orcamentoResultado.Categorias = categorias.OrderBy(x => x.Nome).ToList();
            }

            return orcamentoResultado;
        }

        public IList<Termo> ObterTermos(int idCategoria, int idTipoOrcamento)
        {

            IList<string> listaTermos = new List<string>();

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

                listaTermos.Add("eventos sociais (casamentos, bodas, aniversários, etc.)");
                listaTermos.Add("eventos corporativos");
                listaTermos.Add("paisagismo");
            }
            if (idCategoria == 56)
            {
                listaTermos.Add("brigadeiro");
            }
            if (idCategoria == 58)
            {
                listaTermos.Add("chinelos personalizados");

                if (idTipoOrcamento == 1)
                {
                    listaTermos.Add("porta-jóias");
                    listaTermos.Add("porta-retratos");
                    listaTermos.Add("porta-recados");
                    listaTermos.Add("champanhe e vinho com rótulos personalizados");
                }
                else
                {
                    listaTermos.Add("tema infantil");
                }
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

                if (idTipoOrcamento == 1)
                {
                    listaTermos.Add("tema infantil");
                }
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

                if (idTipoOrcamento == 5)
                {
                    listaTermos.Add("tema infantil");
                }
                else
                {
                    listaTermos.Add("tema adulto");
                }
            }
            if (idCategoria == 142)
            {
                listaTermos.Add("com o making of");
                listaTermos.Add("somente o evento");
                listaTermos.Add("somente 1 câmera");
                listaTermos.Add("mais de 1 câmera");

                if (idTipoOrcamento == 5)
                {
                    listaTermos.Add("tema infantil");
                }
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
                if (idTipoOrcamento == 5)
                {
                    listaTermos.Add("tema infantil");
                }
                else
                {
                    listaTermos.Add("tema adulto");
                }
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
                listaTermos.Add("grafiato ou textura");
                listaTermos.Add("pintura externa");
                listaTermos.Add("pintura interna comum");
            }
            if (idCategoria == 155)
            {
                listaTermos.Add("design e decoração de interiores");
                listaTermos.Add("projeto comercial");
                listaTermos.Add("projeto residencial");
                listaTermos.Add("paisagismo ou urbanismo");
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
                listaTermos.Add("pintura em altura, alpinismo industrial ou rapel");
                listaTermos.Add("rejuntamento, trincas, fissuras, tratamento de concreto ou impermeabilização");
            }
            if (idCategoria == 186)
            {
                listaTermos.Add("construção ou reformas em geral");
                listaTermos.Add("galpão (construção ou reforma)");
                listaTermos.Add("gerenciamento de obras");
                listaTermos.Add("licitações");
                listaTermos.Add("telhas ou telhados");
            }
            #endregion

            #region Serviços Prediais
            if (idCategoria == 37)
            {
                listaTermos.Add("carpetes, estofados ou tecidos");
                listaTermos.Add("entulhos e demolições");
                listaTermos.Add("eventos, feiras ou congressos");
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

            IList<Termo> termos = new List<Termo>();
            Termo termo;

            foreach (String item in listaTermos)
            {
                termo = new Termo();
                termo.IdCategoria = idCategoria;
                termo.Nome = item;
                termos.Add(termo);
            }
            return termos.OrderBy(x => x.Nome).ToList();
        }

        public IList<Orcamento> ObterPorTipo(TipoServico tipoServico)
        {
            return context.Repository<Orcamento>().Where(x => x.TipoServico == tipoServico).ToList();
        }
    }
}
