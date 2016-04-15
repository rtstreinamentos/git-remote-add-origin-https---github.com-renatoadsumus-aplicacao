using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OrcamentoNet.AutomacaoHistorico
{
    class Program
    {
        static void Main(string[] args) {
            IWebDriver driver = new ChromeDriver();
            Login login = new Login(driver);
            Dashboard dashboard = login.Logar("admin", "4dm1n");
            ListaPosts listaPosts = dashboard.ListarPosts();
            listaPosts = listaPosts.ListarPostsPendentes();

            int i = 0;
            while (listaPosts.PossuiPostsPendentes() && i < 500)
            {
                Console.WriteLine(i.ToString());

                Post post = listaPosts.EditarPrimeiroPost();
                string nomeCidade = post.ObterTag();

                if (!EhCapitalOuRelevante(ref nomeCidade))
                {
                    post.RemoverTag();
                    post.AdicionarTag(nomeCidade);
                }

                post.Publicar();

                if (post.ObterMensagemStatus() != "Post publicado. Ver post")
                {
                    throw new Exception("Status de publicação desconhecido!");
                }

                listaPosts = listaPosts.ListarPostsPendentes();
                i++;
            }

            Console.WriteLine("Processamento encerrado. Pressione ENTER para continuar...");
            Console.ReadLine();

            driver.Quit();
            driver.Dispose();
        }

        static bool EhCapitalOuRelevante(ref string nomeCidade) {
            bool cidadeEhCapitalOuRelevante = false;

            switch (nomeCidade)
            {
                case "Adamantina":
                    nomeCidade = "São Paulo";
                    break;
				case "Água Boa":
					nomeCidade = "Mato Grosso";
					break;
				case "Alto Alegre":
                    nomeCidade = "Roraima";
                    break;
				case "Amargosa":
					nomeCidade = "Bahia";
					break;
				case "Americana":
                    nomeCidade = "São Paulo";
                    break;
                case "Angra dos Reis":
                    nomeCidade = "Rio de Janeiro";
                    break;
				case "Aparecida de Goiânia":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Aracaju":
                    cidadeEhCapitalOuRelevante = true;
                    break;
				case "Araruama":
					nomeCidade = "Rio de Janeiro";
					break;
				case "Armação dos Búzios":
					nomeCidade = "Rio de Janeiro";
					break;
				case "Arujá":
					nomeCidade = "São Paulo";
					break;
				case "Atibaia":
                    nomeCidade = "São Paulo";
                    break;
				case "Avaré":
					nomeCidade = "São Paulo";
					break;
				case "Barra Mansa":
                    nomeCidade = "Rio de Janeiro";
                    break;
                case "Barueri":
                    nomeCidade = "São Paulo";
                    break;
				case "Belém":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Belford Roxo":
                    nomeCidade = "Rio de Janeiro";
                    break;
                case "Belo Horizonte":
                    cidadeEhCapitalOuRelevante = true;
                    break;
				case "Benevides":
					nomeCidade = "Pará";
					break;
				case "Blumenau":
					nomeCidade = "Santa Catarina";
					break;
				case "Boa Vista":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Borborema":
                    nomeCidade = "São Paulo";
                    break;
				case "Botucatu":
					nomeCidade = "São Paulo";
					break;
				case "Bragança Paulista":
					nomeCidade = "São Paulo";
					break;
				case "Brasília":
                    cidadeEhCapitalOuRelevante = true;
                    break;
				case "Cabo Frio":
					nomeCidade = "Rio de Janeiro";
					break;
				case "Cajamar":
					nomeCidade = "São Paulo";
					break;
				case "Camaçari":
					nomeCidade = "Bahia";
					break;
				case "Campinas":
                    cidadeEhCapitalOuRelevante = true;
                    break;
                case "Campo Grande":
                    cidadeEhCapitalOuRelevante = true;
                    break;
                case "Campos dos Goytacazes":
                    nomeCidade = "Rio de Janeiro";
                    break;
                case "Carapicuíba":
                    nomeCidade = "São Paulo";
                    break;
				case "Caravelas":
					nomeCidade = "Bahia";
					break;
				case "Carlópolis":
					nomeCidade = "Paraná";
					break;
				case "Cascavel":
                    nomeCidade = "Paraná";
                    break;
                case "Caxias do Sul":
                    cidadeEhCapitalOuRelevante = true;
                    break;
				case "Cesário Lange":
					nomeCidade = "São Paulo";
					break;
				case "Cocalzinho de Goiás":
					nomeCidade = "Goiás";
					break;
				case "Colina":
                    nomeCidade = "São Paulo";
                    break;
                case "Colombo":
                    nomeCidade = "Paraná";
                    break;
				case "Conselheiro Lafaiete":
					nomeCidade = "Minas Gerais";
					break;
				case "Contagem":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Cotia":
                    nomeCidade = "São Paulo";
                    break;
                case "Criciúma":
                    nomeCidade = "Santa Catarina";
                    break;
				case "Cristalina":
					nomeCidade = "Goiás";
					break;
				case "Cubatão":
                    nomeCidade = "São Paulo";
                    break;
                case "Cuiabá":
                    cidadeEhCapitalOuRelevante = true;
                    break;
                case "Curitiba":
                    cidadeEhCapitalOuRelevante = true;
                    break;
                case "Descalvado":
                    nomeCidade = "São Paulo";
                    break;
				case "Divino":
					nomeCidade = "Minas Gerais";
					break;
				case "Dourados":
                    nomeCidade = "Mato Grosso do Sul";
                    break;
                case "Duque de Caxias":
                    nomeCidade = "Rio de Janeiro";
                    break;
                case "Embu":
                    nomeCidade = "São Paulo";
                    break;
				case "Embu-Guaçu":
					nomeCidade = "São Paulo";
					break;
				case "Estância":
                    nomeCidade = "Sergipe";
                    break;
				case "Feira de Santana":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Florianópolis":
                    cidadeEhCapitalOuRelevante = true;
                    break;
                case "Fortaleza":
                    cidadeEhCapitalOuRelevante = true;
                    break;
				case "Garopaba":
					nomeCidade = "Santa Catarina";
					break;
				case "Gravataí":
					nomeCidade = "Rio Grande do Sul";
					break;
				case "Goiânia":
                    cidadeEhCapitalOuRelevante = true;
                    break;
                case "Guapimirim":
                    nomeCidade = "Rio de Janeiro";
                    break;
                case "Guarulhos":
                    nomeCidade = "São Paulo";
                    break;
				case "Ilhéus":
					nomeCidade = "Bahia";
					break;
				case "Ipatinga":
					nomeCidade = "Minas Gerais";
					break;
				case "Irati":
                    nomeCidade = "Paraná";
                    break;
                case "Itaboraí":
                    nomeCidade = "Rio de Janeiro";
                    break;
                case "Itaipulândia":
                    nomeCidade = "Paraná";
                    break;
                case "Itaperuna":
                    nomeCidade = "Rio de Janeiro";
                    break;
				case "Itapetininga":
					nomeCidade = "São Paulo";
					break;
				case "Itapevi":
                    nomeCidade = "São Paulo";
                    break;
                case "Itu":
                    nomeCidade = "São Paulo";
                    break;
                case "Jacarezinho":
                    nomeCidade = "Paraná";
                    break;
				case "Jequié":
					nomeCidade = "Bahia";
					break;
				case "Joinville":
                    nomeCidade = "Santa Catarina";
                    break;
				case "Juazeiro":
					nomeCidade = "Bahia";
					break;
				case "Juazeiro do Norte":
                    cidadeEhCapitalOuRelevante = true;
                    break;
				case "Juiz de Fora":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Jundiaí":
					nomeCidade = "São Paulo";
					break;
				case "Lajeado":
					nomeCidade = "Rio Grande do Sul";
					break;
				case "Lauro de Freitas":
                    nomeCidade = "Bahia";
                    break;
                case "Leme":
                    nomeCidade = "São Paulo";
                    break;
                case "Londrina":
                    nomeCidade = "Paraná";
                    break;
                case "Luziânia":
                    nomeCidade = "Goiás";
                    break;
                case "Maceió":
                    cidadeEhCapitalOuRelevante = true;
                    break;
				case "Mairiporã":
					nomeCidade = "São Paulo";
					break;
				case "Mangaratiba":
					nomeCidade = "Rio de Janeiro";
					break;
				case "Marília":
                    nomeCidade = "São Paulo";
                    break;
                case "Magé":
                    nomeCidade = "Rio de Janeiro";
                    break;
				case "Manaus":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Marechal Deodoro":
                    nomeCidade = "Alagoas";
                    break;
                case "Maricá":
                    nomeCidade = "Rio de Janeiro";
                    break;
                case "Matinhos":
                    nomeCidade = "Paraná";
                    break;
				case "Mauá":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Mogi das Cruzes":
                    nomeCidade = "São Paulo";
                    break;
				case "Mongaguá":
					nomeCidade = "São Paulo";
					break;
				case "Montes Claros":
					nomeCidade = "Minas Gerais";
					break;
				case "Moreno":
					nomeCidade = "Pernambuco";
					break;
				case "Natal":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Nilópolis":
                    nomeCidade = "Rio de Janeiro";
                    break;
                case "Niterói":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Nova Andradina":
                    nomeCidade = "Mato Grosso do Sul";
                    break;
                case "Nova Iguaçu":
                    nomeCidade = "Rio de Janeiro";
                    break;
                case "Osasco":
                    nomeCidade = "São Paulo";
                    break;
				case "Ouro Preto":
					nomeCidade = "Minas Gerais";
					break;
				case "Padre Bernardo":
					nomeCidade = "Goiás";
					break;
				case "Paraíba do Sul":
					nomeCidade = "Rio de Janeiro";
					break;
				case "Paranaguá":
                    nomeCidade = "Paraná";
                    break;
                case "Parintins":
                    nomeCidade = "Amazonas";
                    break;
				case "Passos":
					nomeCidade = "Minas Gerais";
					break;
				case "Paty do Alferes":
					nomeCidade = "Rio de Janeiro";
					break;
				case "Penápolis":
					nomeCidade = "São Paulo";
					break;
				case "Petrópolis":
					nomeCidade = "Rio de Janeiro";
					break;
				case "Pirassununga":
                    nomeCidade = "São Paulo";
                    break;
				case "Poços de Caldas":
					nomeCidade = "Minas Gerais";
					break;
				case "Porto Alegre":
                    cidadeEhCapitalOuRelevante = true;
                    break;
                case "Porto União":
                    nomeCidade = "Santa Catarina";
                    break;
				case "Recife":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Ribeirão das Neves":
					nomeCidade = "Minas Gerais";
					break;
				case "Ribeirão Preto":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Rincão":
					nomeCidade = "São Paulo";
					break;
				case "Rio das Ostras":
					nomeCidade = "Rio de Janeiro";
					break;
				case "Rio de Janeiro":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Sabará":
					nomeCidade = "Minas Gerais";
					break;
				case "Salinas da Margarida":
					nomeCidade = "Bahia";
					break;
				case "Salvador":
                    cidadeEhCapitalOuRelevante = true;
                    break;
				case "Santa Cruz":
                    nomeCidade = "Rio Grande do Norte";
                    break;
				case "Santa Luzia":
					nomeCidade = "Minas Gerais";
					break;
				case "Santo Amaro":
                    nomeCidade = "Bahia";
                    break;
                case "Santo André":
                    nomeCidade = "São Paulo";
                    break;
				case "Santos":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "São Bernardo do Campo":
                    nomeCidade = "São Paulo";
                    break;
                case "São Caetano do Sul":
                    nomeCidade = "São Paulo";
                    break;
                case "São Gonçalo":
                    nomeCidade = "Rio de Janeiro";
                    break;
				case "São João de Meriti":
					nomeCidade = "Rio de Janeiro";
					break;
				case "São José do Rio Preto":
                    nomeCidade = "São Paulo";
                    break;
                case "São José dos Pinhais":
                    nomeCidade = "Paraná";
                    break;
				case "São Lourenço da Serra":
					nomeCidade = "São Paulo";
					break;
				case "São Luís":
                    cidadeEhCapitalOuRelevante = true;
                    break;
                case "São Miguel do Anta":
                    nomeCidade = "Minas Gerais";
                    break;
                case "São Paulo":
                    cidadeEhCapitalOuRelevante = true;
                    break;
                case "São Pedro":
                    nomeCidade = "São Paulo";
                    break;
                case "São Sebastião":
                    nomeCidade = "São Paulo";
                    break;
                case "São Vicente":
                    nomeCidade = "São Paulo";
                    break;
                case "Seropédica":
                    nomeCidade = "Rio de Janeiro";
                    break;
				case "Serra":
					cidadeEhCapitalOuRelevante = true;
					break;
				case "Serra Negra":
                    nomeCidade = "São Paulo";
                    break;
				case "Serrana":
					nomeCidade = "São Paulo";
					break;
				case "Sete Lagoas":
					nomeCidade = "Minas Gerais";
					break;
				case "Simões Filho":
                    nomeCidade = "Bahia";
                    break;
				case "Siqueira Campos":
					nomeCidade = "Paraná";
					break;
                case "Sorocaba":
                    nomeCidade = "São Paulo";
                    break;
				case "Suzano":
					nomeCidade = "São Paulo";
					break;
				case "Tapes":
					nomeCidade = "Rio Grande do Sul";
					break;
				case "Tarumã":
                    nomeCidade = "São Paulo";
                    break;
				case "Tatuí":
					nomeCidade = "São Paulo";
					break;
				case "Taubaté":
                    nomeCidade = "São Paulo";
                    break;
                case "Tianguá":
                    nomeCidade = "Ceará";
                    break;
                case "Toledo":
                    nomeCidade = "Paraná";
                    break;
				case "Três Rios":
					nomeCidade = "Rio de Janeiro";
					break;
				case "Ubatuba":
					nomeCidade = "São Paulo";
					break;
				case "União Paulista":
					nomeCidade = "São Paulo";
					break;
				case "Varginha":
                    nomeCidade = "Minas Gerais";
                    break;
                case "Vila Velha":
                    nomeCidade = "Espírito Santo";
                    break;
				case "Vinhedo":
					nomeCidade = "São Paulo";
					break;
				case "Vitória":
                    cidadeEhCapitalOuRelevante = true;
                    break;
				case "Volta Grande":
					nomeCidade = "Minas Gerais";
					break;
				case "Volta Redonda":
					nomeCidade = "Rio de Janeiro";
					break;
				case "Votorantim":
					nomeCidade = "São Paulo";
					break;
				default:
                    throw new Exception("Cidade não mapeada!");
            }

            return cidadeEhCapitalOuRelevante;
        }
    }
}
