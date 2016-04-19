using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using PortalEscolar.Data;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Common;
using Owasp.Esapi;
using MySql.Data.MySqlClient;
using System.Data;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.LocalService
{
    public class FornecedorService : IFornecedorService
    {

        private IDataContext context;

        public FornecedorService(IDataContext contextData)
        {
            context = contextData;
        }

        #region "Métodos Privados"
        private void AdicionarCampoInvalido(ref string camposInvalidos, string novoCampoInvalido)
        {
            if (!String.IsNullOrEmpty(camposInvalidos)) camposInvalidos += ", ";
            camposInvalidos = camposInvalidos + novoCampoInvalido;
        }

        #endregion

        /// <summary>
        /// Valida os campos em server side
        /// </summary>
        /// <param name="camposInvalidos">Nomes dos campos inválidos, concatenados por ','</param>
        /// <returns></returns>
        public bool ValidarDados(ref string camposInvalidos
            , string nome
            , string email
            , string telefone
            , ref string website
            , string descricao
            )
        {
            try
            {
                ValidadorDados validador = new ValidadorDados();
                camposInvalidos = String.Empty;

                if (!validador.ValidarTextoLivre(nome, 3, 100))
                {
                    this.AdicionarCampoInvalido(ref camposInvalidos, "Nome");
                }

                if (!validador.ValidarEmail(email, 100))
                {
                    this.AdicionarCampoInvalido(ref camposInvalidos, "E-mail");
                }

                if (!validador.ValidarTelefone(telefone, 15))
                {
                    this.AdicionarCampoInvalido(ref camposInvalidos, "Telefone");
                }

                if (!String.IsNullOrEmpty(website))
                {
                    if (!validador.ValidarTextoLivre(website, 10, 100))
                    {
                        this.AdicionarCampoInvalido(ref camposInvalidos, "Web Site");
                    }
                    if (website.Substring(0, 7).ToLower() != "http://")
                    {
                        website = "http://" + website;
                    }
                }

                if (!String.IsNullOrEmpty(descricao))
                {
                    if (!validador.ValidarXSS(descricao))
                    {
                        this.AdicionarCampoInvalido(ref camposInvalidos, "Descrição");
                    }
                }

                if (!String.IsNullOrEmpty(camposInvalidos))
                {
                    camposInvalidos = "Preenchimento inválido: " + camposInvalidos;
                }

                return (camposInvalidos == String.Empty);
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Retorna fornecedor por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Fornecedor ObterPorId(int id)
        {
            Fornecedor fornecedor = context.Repository<Fornecedor>().Where(x => x.Id == id).FirstOrDefault();


            return fornecedor;
        }

        public IList<Fornecedor> ObterFornecedoresEmDegustacaoParaUmPedidoDeOrcamento(PedidoOrcamento pedidoOrcamento)
        {
            IList<Fornecedor> fornecedores = new List<Fornecedor>();
            IList<Fornecedor> fornecedoresDaCategoria = new List<Fornecedor>();
            try
            {
                fornecedores = context.Repository<Fornecedor>()
                    .Where(f =>
                        f.Cidades.Contains(pedidoOrcamento.Cidade)
                        && f.Status == Status.Degustacao)
                    .ToList();

                foreach (Fornecedor fornecedor in fornecedores)
                {
                    foreach (Categoria categoria in fornecedor.SubCategorias)
                    {
                        if (!fornecedoresDaCategoria.Contains(fornecedor) && pedidoOrcamento.Categorias.Contains(categoria))
                        {
                            fornecedoresDaCategoria.Add(fornecedor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
            return fornecedoresDaCategoria;
        }

        public IList<Fornecedor> ObterFornecedoresParaUmPedidoDeOrcamento(PedidoOrcamento pedidoOrcamento)
        {
            IList<Fornecedor> fornecedores = new List<Fornecedor>();
            IList<Fornecedor> fornecedoresDaCategoria = new List<Fornecedor>();
            try
            {
                fornecedores = context.Repository<Fornecedor>()
                    .Where(f =>
                        f.Cidades.Contains(pedidoOrcamento.Cidade)
                        && f.Status != Status.Inativo)
                    .ToList();

                foreach (Fornecedor fornecedor in fornecedores)
                {
                    foreach (Categoria categoria in fornecedor.SubCategorias)
                    {
                        if (!fornecedoresDaCategoria.Contains(fornecedor) && pedidoOrcamento.Categorias.Contains(categoria))
                        {
                            fornecedoresDaCategoria.Add(fornecedor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
            return fornecedoresDaCategoria;
        }

        public IList<Fornecedor> ObterFornecedoresClientesParaUmPedidoDeOrcamento(PedidoOrcamento pedidoOrcamento)
        {
            IList<Fornecedor> fornecedores = new List<Fornecedor>();
            List<Fornecedor> fornecedoresDaCategoria = new List<Fornecedor>();
            IList<Fornecedor> fornecedoresParaEnviar = new List<Fornecedor>();
            IList<int> idsFornecedores = new List<int>();

            string[] atributos = pedidoOrcamento.Observacao.Split(';');
            int valorAtributoPedido = 0;

            if (atributos.Count() > 1)
            {
                foreach (string atributo in atributos)
                {

                    if (atributo.Contains("Área") || atributo.Contains("Metros"))
                    {
                        string[] atributoArea = atributo.Split(':');
                        valorAtributoPedido = int.Parse(atributoArea[1]);
                    }
                }
            }

            try
            {
                if (pedidoOrcamento.PessoaTipo == PessoaTipo.Juridica)
                {

                    fornecedores = context.Repository<Fornecedor>()
                        .Where(f =>
                            f.Cidades.Contains(pedidoOrcamento.Cidade)
                            && f.Status == Status.Cliente).ToList();
                }
                else
                {
                    fornecedores = context.Repository<Fornecedor>()
                        .Where(f =>
                            f.Cidades.Contains(pedidoOrcamento.Cidade)
                            && f.Status == Status.Cliente && f.TipoPessoaAtendimento == PessoaTipo.Fisica).ToList();
                }


                foreach (Fornecedor fornecedor in fornecedores)
                {
                    List<FornecedorAtributo> atributosFornecedor = context.Repository<FornecedorAtributo>().Where(x => x.Fornecedor == fornecedor.Id).ToList();

                    foreach (Categoria categoria in fornecedor.SubCategorias)
                    {
                        if (pedidoOrcamento.Categorias.Contains(categoria))
                        {
                            if (atributosFornecedor != null && atributosFornecedor.Count > 0)
                            {
                                if (valorAtributoPedido >= atributosFornecedor[0].Condicao)
                                {
                                    fornecedoresDaCategoria.Add(fornecedor);
                                    idsFornecedores.Add(fornecedor.Id);
                                    break;
                                }

                            }
                            else
                            {

                                fornecedoresDaCategoria.Add(fornecedor);
                                idsFornecedores.Add(fornecedor.Id);
                                break;
                            }
                        }

                    }
                }

                //Numero de cliente é menor que 5, nao precisa levar em consideração TRUE ou FALSE
                if (fornecedoresDaCategoria.Count < 5)
                {
                    foreach (Fornecedor fornecedor in fornecedoresDaCategoria)
                    {
                        fornecedor.EnviadoPorUltimo = true;
                        context.Commit();
                        fornecedoresParaEnviar.Add(fornecedor);
                    }
                    return fornecedoresParaEnviar;
                }

                int quantidadeNaoEnviados = fornecedoresDaCategoria.Where(x => x.EnviadoPorUltimo == false).Count();

                int quantidadeDeFornecedoresQueFaltam = 5;

                if (quantidadeNaoEnviados < 5)
                    quantidadeDeFornecedoresQueFaltam = 5 - quantidadeNaoEnviados;

                foreach (Fornecedor fornecedor in fornecedoresDaCategoria.Where(x => x.EnviadoPorUltimo == false).OrderByDescending(y => y.ValorMensalidade).Take(quantidadeDeFornecedoresQueFaltam).ToList())
                {
                    fornecedoresParaEnviar.Add(fornecedor);
                    fornecedor.EnviadoPorUltimo = true;
                    context.Commit();
                }



                IPedidoOrcamentoFornecedorService pedidoOrcamentoFornecedorService = new PedidoOrcamentoFornecedorService(context);
                IList<Fornecedor> fornecedoresOrdenados = pedidoOrcamentoFornecedorService.Obter(idsFornecedores);

                foreach (Fornecedor fornecedor in fornecedoresOrdenados.Take(quantidadeDeFornecedoresQueFaltam).ToList())
                {
                    fornecedoresParaEnviar.Add(fornecedor);
                }

                return fornecedoresParaEnviar;
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
            return fornecedoresParaEnviar;
        }

        public IList<Fornecedor> ObterFornecedoresAtivosPorCategoria(Categoria categoria)
        {
            IList<Fornecedor> fornecedoresResultado = new List<Fornecedor>();

            //Verifica se a Categoria é um Tema
            if (categoria.Pai.Id == 0)
            {
                //Lista todos os fornecedores de cada Categoria
                foreach (Categoria item in categoria.SubCategorias)
                {
                    IList<Fornecedor> fornecedores = ObterFornecedoresAtivosPoCategoria(item);

                    foreach (Fornecedor fornecedor in fornecedores)
                    {
                        //Não permiti duplicação de Fornecedores
                        if (!fornecedoresResultado.Contains(fornecedor))
                        {
                            fornecedoresResultado.Add(fornecedor);
                        }
                    }
                }
            }
            else
            {
                fornecedoresResultado = ObterFornecedoresAtivosPoCategoria(categoria);
            }

            return fornecedoresResultado;
        }

        private IList<Fornecedor> ObterFornecedoresAtivosPoCategoria(Categoria item)
        {
            IList<Fornecedor> fornecedores2 = context.Repository<Fornecedor>()
        .Where(x =>
            x.SubCategorias.Contains(item) &&
            x.Status != Status.Inativo)
        .OrderBy(y => y.Nome).ToList();
            return fornecedores2;
        }

        public Fornecedor Inserir(ref IList<string> camposInvalidos
            , Fornecedor fornecedor
            , string webSite)
        {

            camposInvalidos.Clear();

            string nomesCamposInvalidos = String.Empty;
            this.ValidarDados(ref nomesCamposInvalidos, fornecedor.Nome, fornecedor.Email, fornecedor.Telefone, ref webSite, fornecedor.Descricao);
            if (!String.IsNullOrEmpty(nomesCamposInvalidos))
            {
                camposInvalidos.Add(nomesCamposInvalidos);
                return null;
            }

            try
            {
                if (fornecedor.Cidades.Count > 0 && fornecedor.SubCategorias.Count > 0)
                {
                    fornecedor.Status = Status.Degustacao;
                    fornecedor.DataCadastro = DateTime.Now;
                    fornecedor.DataAlteracao = DateTime.Now.AddDays(Config.QuantidadeDiasPeriodoCortesia);
                    fornecedor.WebSite = webSite;
                    fornecedor.Senha = fornecedor.DataCadastro.Hour.ToString() + fornecedor.DataCadastro.Minute.ToString() + fornecedor.DataCadastro.Millisecond.ToString();
                    context.Insert(fornecedor);
                    context.Commit();
                }
                return fornecedor;
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return null;
            }
        }

        public double CalcularValorMensalidade(IList<Cidade> cidadesOrcamento, IList<Categoria> subCategorias)
        {
            double valorMensalidadeBruto = 0;
            double valorDesconto = 0;


            foreach (Categoria categoria in subCategorias)
            {
                foreach (Cidade cidade in cidadesOrcamento)
                {
                    valorMensalidadeBruto = valorMensalidadeBruto + categoria.Valor * cidade.Peso;
                }
            }

            if (cidadesOrcamento.Count >= 3 || subCategorias.Count >= 3)
            {
                valorDesconto = valorMensalidadeBruto * 0.20;
            }

            if (cidadesOrcamento.Count >= 3 && subCategorias.Count >= 3)
            {
                valorDesconto = valorMensalidadeBruto * 0.30;
            }

            double valorMensalidade = valorMensalidadeBruto - valorDesconto;

            if (valorMensalidade > 120)
            {
                valorMensalidade = 120.00;
            }

            if (valorMensalidade < 12)
            {
                valorMensalidade = 12.00;
            }

            return valorMensalidade;
        }

        /// <summary>
        /// Retorna um comprador por email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Fornecedor ObterPorEmail(string email)
        {
            Fornecedor fornecedor = context.Repository<Fornecedor>().Where(x => x.Email == email || x.EmailSecundario == email).FirstOrDefault();


            return fornecedor;
        }

        public IList<Fornecedor> ObterFornecedoresPorDataCriacao(DateTime dataCriacao)
        {
            IList<Fornecedor> fornecedores = context.Repository<Fornecedor>().ToList();

            return fornecedores.Where(x =>
                x.DataCadastro.DayOfYear == dataCriacao.DayOfYear
                && x.DataCadastro.Year == dataCriacao.Year
                && x.Status != Status.Inativo).ToList();
        }

        //Retorna todos os fornecedores que irão vencer na data passada como parametro
        public IList<Fornecedor> ObterFornecedoresPorDataVencimento(DateTime dataVencimento)
        {
            IList<Fornecedor> fornecedores = context.Repository<Fornecedor>().ToList();

            return fornecedores.Where(x =>
                x.DataAlteracao.DayOfYear == dataVencimento.DayOfYear
                && x.DataAlteracao.Year == dataVencimento.Year
                && (x.Status == Status.Cliente || x.Status == Status.Cortesia)).ToList();
        }

        /// <summary>
        /// Retorna todos os clientes vencidos há mais de N dias
        /// </summary>
        /// <param name="numeroDiasAposVencimento">Quantidade de dias após vencimento</param>
        /// <returns></returns>
        public IList<Fornecedor> ObterFornecedoresQueNaoPagaram(int numeroDiasAposVencimento)
        {
            DateTime dataMaximoCancelaAssinatura = DateTime.Now.AddDays(-numeroDiasAposVencimento);

            IList<Fornecedor> fornecedores = context.Repository<Fornecedor>()
                .Where(x =>
                    x.DataAlteracao <= dataMaximoCancelaAssinatura
                    && (x.Status == Status.Cliente || x.Status == Status.Cortesia)).ToList();

            return fornecedores;
        }

        public IList<Fornecedor> ObterFornecedoresComCortesiaVencida(int numeroDiasAposVencimento)
        {
            DateTime dataMaximoCancelaAssinatura = DateTime.Now.AddDays(-numeroDiasAposVencimento);

            IList<Fornecedor> fornecedores = context.Repository<Fornecedor>()
                .Where(x =>
                    x.DataAlteracao <= dataMaximoCancelaAssinatura
                    && x.Status == Status.Cortesia).ToList();

            return fornecedores;
        }


        public IList<Fornecedor> ObterFornecedoresAtivosPorEstado(Categoria categoria, UF uf)
        {
            IList<Fornecedor> fornecedores = ObterFornecedoresAtivosPoCategoria(categoria);

            IList<Cidade> cidades = context.Repository<Cidade>().Where(x => x.Uf == uf).ToList();

            IList<Fornecedor> fornecedoresDoEstado = new List<Fornecedor>();

            foreach (Fornecedor itemFornecedor in fornecedores)
            {
                foreach (Cidade cidade in cidades)
                {
                    if (itemFornecedor.Cidades.Contains(cidade) && !fornecedoresDoEstado.Contains(itemFornecedor))
                    {
                        fornecedoresDoEstado.Add(itemFornecedor);
                    }
                }
            }

            return fornecedoresDoEstado;
        }

        public Fornecedor Alterar(Fornecedor fornecedor)
        {
            Fornecedor fornecedorBusca = ObterPorId(fornecedor.Id);

            if (fornecedorBusca == null) return null;

            fornecedorBusca.DataAlteracao = fornecedor.DataAlteracao;
            fornecedorBusca.WebSite = fornecedor.WebSite;
            fornecedorBusca.Nome = fornecedor.Nome;
            fornecedorBusca.Telefone = fornecedor.Telefone;
            fornecedorBusca.Descricao = fornecedor.Descricao;
            fornecedorBusca.ValorMensalidade = fornecedor.ValorMensalidade;
            fornecedorBusca.SubCategorias = fornecedor.SubCategorias;
            fornecedorBusca.Status = fornecedor.Status;
            fornecedorBusca.DataAlteracao = fornecedor.DataAlteracao;
            context.Commit();

            return fornecedorBusca;
        }

        /// <summary>
        /// Retorna os ultimos fornecedores cadastrados
        /// </summary>
        /// <param name="quantidadeDeFornecedores">Quantidade de Fornecedores que serão retornados</param>
        /// <returns></returns>
        public IList<Fornecedor> ObterUltimosFornecedoresCadastrados(int quantidadeDeFornecedores, int idCategoria, string termoPesquisa)
        {
            IList<Fornecedor> fornecedores = context.Repository<Fornecedor>().Where(x => x.Status == Status.Degustacao
                || x.Status == Status.Cliente).OrderByDescending(x => x.DataCadastro).ToList();

            Categoria categoria = context.Repository<Categoria>().Where(x => x.Id == idCategoria).FirstOrDefault();

            //Se for o tema retorna ultimos fornecedores do tema
            if (categoria != null && categoria.Pai.Id == 0)
            {
                IList<Fornecedor> ultimosFornecedores = new List<Fornecedor>();

                foreach (Fornecedor itemFornecedor in fornecedores)
                {
                    foreach (Categoria itemCategoria in categoria.SubCategorias)
                    {
                        if (!ultimosFornecedores.Contains(itemFornecedor) && itemFornecedor.SubCategorias.Contains(itemCategoria) && itemFornecedor.Descricao.Contains(termoPesquisa))
                        {
                            if (ultimosFornecedores.Count == quantidadeDeFornecedores)
                                break;

                            ultimosFornecedores.Add(itemFornecedor);
                        }
                    }

                    if (ultimosFornecedores.Count == quantidadeDeFornecedores)
                        break;
                }
                return ultimosFornecedores;
            }

            return fornecedores.Take(quantidadeDeFornecedores).ToList();
        }

        /// <summary>
        /// Retorna os ultimos fornecedores cadastrados
        /// </summary>
        /// <param name="quantidadeDeFornecedores">Quantidade de Fornecedores que serão retornados</param>
        /// <returns></returns>
        public IList<Fornecedor> ObterUltimosFornecedoresCadastradosDoTemaOuCategoriaPorEstadoCidade(int quantidadeDeFornecedores, int idCategoria, int idCidade, int idMes, string termoPesquisa)
        {
            IList<Fornecedor> ultimosFornecedores = new List<Fornecedor>();

            if (idCidade == 0 && idMes == 0)
            {
                ultimosFornecedores = this.ObterUltimosFornecedoresCadastrados(quantidadeDeFornecedores, idCategoria, termoPesquisa);

            }
            else
            {
                IList<Fornecedor> fornecedores = context.Repository<Fornecedor>().Where(x => x.Status == Status.Degustacao
                     || x.Status == Status.Cliente).OrderByDescending(x => x.DataCadastro).ToList();

                if (idMes != 0)
                {
                    fornecedores = fornecedores.Where(x => x.DataCadastro.Month == idMes).ToList();
                }

                Categoria categoria = context.Repository<Categoria>().Where(x => x.Id == idCategoria).FirstOrDefault();
                string uf = Enum.GetName(typeof(UF), idCidade);

                if (categoria != null && categoria.Pai.Id == 0 && uf != null)
                {
                    ultimosFornecedores = ObterUltimosFornecedoresDeUmTemaPorEstado(quantidadeDeFornecedores, fornecedores, categoria, uf);
                }

                if (categoria != null && categoria.Pai.Id != 0)
                {
                    ultimosFornecedores = ObterUltimosFornecedoresDeUmaCategoria(quantidadeDeFornecedores, fornecedores, categoria);
                }

                if (uf == null)
                {
                    ultimosFornecedores = ObterUltimosFornecedoresDeUmaCidade(quantidadeDeFornecedores, fornecedores, categoria, idCidade);
                }

                return ultimosFornecedores;
            }

            return ultimosFornecedores.Take(quantidadeDeFornecedores).ToList();
        }

        private IList<Fornecedor> ObterUltimosFornecedoresDeUmaCidade(int quantidadeDeFornecedores, IList<Fornecedor> fornecedores, Categoria categoria, int idCidade)
        {
            IList<Fornecedor> ultimosFornecedores = new List<Fornecedor>();
            Cidade cidade = context.Repository<Cidade>().Where(x => x.Id == idCidade).FirstOrDefault();

            foreach (Fornecedor itemFornecedor in fornecedores.Where(x => x.Cidades.Contains(cidade)))
            {
                foreach (Categoria itemCategoria in categoria.SubCategorias)
                {
                    if (ultimosFornecedores.Count <= quantidadeDeFornecedores && itemFornecedor.SubCategorias.Contains(itemCategoria) && !ultimosFornecedores.Contains(itemFornecedor))
                    {
                        ultimosFornecedores.Add(itemFornecedor);
                    }
                }
            }

            return ultimosFornecedores;
        }

        private IList<Fornecedor> ObterUltimosFornecedoresDeUmaCategoria(int quantidadeDeFornecedores, IList<Fornecedor> fornecedores, Categoria categoria)
        {
            IList<Fornecedor> ultimosFornecedores = new List<Fornecedor>();

            foreach (Fornecedor itemFornecedor in fornecedores)
            {
                foreach (Categoria itemCategoria in categoria.SubCategorias)
                {
                    if (ultimosFornecedores.Count <= quantidadeDeFornecedores && itemFornecedor.SubCategorias.Contains(itemCategoria) && !ultimosFornecedores.Contains(itemFornecedor))
                    {
                        ultimosFornecedores.Add(itemFornecedor);
                    }
                }
            }

            return ultimosFornecedores;
        }

        private IList<Fornecedor> ObterUltimosFornecedoresDeUmTemaPorEstado(int quantidadeDeFornecedores, IList<Fornecedor> fornecedores, Categoria categoria, string uf)
        {
            IList<Cidade> cidades = context.Repository<Cidade>().Where(x => x.Uf == (UF)Enum.Parse(typeof(UF), uf)).ToList();

            IList<Fornecedor> ultimosFornecedores = new List<Fornecedor>();

            foreach (Fornecedor itemFornecedor in fornecedores)
            {
                foreach (Categoria itemCategoria in categoria.SubCategorias)
                {
                    foreach (Cidade cidade in cidades)
                    {
                        if (ultimosFornecedores.Count <= quantidadeDeFornecedores && itemFornecedor.Cidades.Contains(cidade) && itemFornecedor.SubCategorias.Contains(itemCategoria) && !ultimosFornecedores.Contains(itemFornecedor))
                        {
                            ultimosFornecedores.Add(itemFornecedor);
                        }
                    }
                }
            }

            return ultimosFornecedores;
        }


        /// <summary>
        /// Retorna os Fornecedores Ativos
        /// </summary>
        /// <returns></returns>
        public IList<Fornecedor> ObterFornecedoresAtivos()
        {
            IList<Fornecedor> fornecedores = context.Repository<Fornecedor>().ToList();

            return fornecedores.Where(x => x.Status != Status.Inativo).OrderByDescending(x => x.DataCadastro).ToList();
        }

        /// <summary>
        /// Retorna fornecedor por nome
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Fornecedor ObterPorNome(string nome)
        {
            Fornecedor fornecedor = context.Repository<Fornecedor>().Where(x => x.Nome.Contains(nome)).FirstOrDefault();

            return fornecedor;
        }
        /// <summary>
        /// Retorna fornecedores por um intervalo de data de cadastro
        /// </summary>
        /// <param name="dataIncio"></param>
        /// <param name="dataFim"></param>
        /// <returns></returns>
        public IList<Fornecedor> ObterFornecedoresPorIntervaloDeData(DateTime dataIncio, DateTime dataFim)
        {
            return context.Repository<Fornecedor>().Where(x => x.DataCadastro >= dataIncio && x.DataCadastro <= dataFim).OrderByDescending(x => x.DataCadastro).ToList();
        }


        public IList<Fornecedor> ObterFornecedoresAtivosPoCategoriaCidade(Categoria categoria, Cidade cidade)
        {
            IList<Fornecedor> fornecedores2 = context.Repository<Fornecedor>()
        .Where(x =>
            x.SubCategorias.Contains(categoria) &&
            x.Cidades.Contains(cidade) &&
            x.Status != Status.Inativo)
        .OrderBy(y => y.Nome).ToList();
            return fornecedores2;
        }

        public IList<Fornecedor> ObterClientesPorTema(Categoria categoria)
        {
            IList<Fornecedor> fornecedoresResultado = new List<Fornecedor>();

            IList<Fornecedor> fornecedores = context.Repository<Fornecedor>()
                                            .Where(x =>
                                                   x.Status == Status.Cliente)
                                            .OrderBy(y => y.Nome).ToList();

            foreach (Fornecedor itemFornecedor in fornecedores)
            {
                foreach (Categoria itemCategoria in categoria.SubCategorias)
                {
                    if (!fornecedoresResultado.Contains(itemFornecedor) && itemFornecedor.SubCategorias.Contains(itemCategoria))
                    {
                        fornecedoresResultado.Add(itemFornecedor);
                    }
                }
            }
            return fornecedoresResultado;
        }

        public IList<Fornecedor> ObterClientesPorCategoriaCidade(Categoria categoria, Cidade cidade)
        {
            IList<Fornecedor> fornecedoresResultado = new List<Fornecedor>();

            if (categoria.Pai.Id == 0)
            {
                IList<Fornecedor> fornecedores = context.Repository<Fornecedor>()
                                                .Where(x => x.Cidades.Contains(cidade) &&
                                                       x.Status == Status.Cliente)
                                                .OrderBy(y => y.Nome).ToList();

                foreach (Fornecedor itemFornecedor in fornecedores)
                {
                    foreach (Categoria itemCategoria in categoria.SubCategorias)
                    {
                        if (!fornecedoresResultado.Contains(itemFornecedor) && itemFornecedor.Cidades.Contains(cidade) && itemFornecedor.SubCategorias.Contains(itemCategoria))
                        {
                            fornecedoresResultado.Add(itemFornecedor);
                        }
                    }
                }
            }
            else
            {
                fornecedoresResultado = context.Repository<Fornecedor>()
            .Where(x =>
                x.SubCategorias.Contains(categoria) &&
                x.Cidades.Contains(cidade) &&
                x.Status == Status.Cliente)
            .OrderBy(y => y.Nome).ToList();
            }

            return fornecedoresResultado;
        }

        public void EnviarEmailConfirmacaoCadastro(Fornecedor fornecedor)
        {
            PedidoOrcamentoService pedidoOrcamentoService = new PedidoOrcamentoService(context);

            try
            {

                string listaHtmlDeCategorias = "";
                //Montando uma lista HTML li para enviar por email do fornecedor
                foreach (Categoria categoria in fornecedor.SubCategorias)
                {
                    listaHtmlDeCategorias = listaHtmlDeCategorias + "<li>" + categoria.Nome + "</li>";
                }

                string listaHtmlDeCidades = "";
                //Montando uma lista HTML li para enviar por email do fornecedor
                foreach (Cidade cidade in fornecedor.Cidades)
                {
                    listaHtmlDeCidades = listaHtmlDeCidades + "<li>" + cidade.Nome + "</li>";
                }

                listaHtmlDeCategorias = "<ul>" + listaHtmlDeCategorias + "</ul>";

                string valorMensalidade = String.Format("{0:#0.00}", fornecedor.ValorMensalidade).Replace(".", ",");
                string valorMensalidade3Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidade * 3).Replace(".", ",");
                string valorMensalidade8Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidade * 8).Replace(".", ",");

                Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                chavesValores.Add("<!--NOME-->", fornecedor.Nome);
                chavesValores.Add("<!--DESCRICAO-->", fornecedor.Descricao);
                chavesValores.Add("<!--WEBSITE-->", fornecedor.WebSite);
                chavesValores.Add("<!--TELEFONE-->", fornecedor.Telefone);
                chavesValores.Add("<!--VALOR_MENSALIDADE-->", valorMensalidade);
                chavesValores.Add("<!--DATA_RENOVACAO-->", fornecedor.DataAlteracao.ToString("dd/MM/yyyy"));
                chavesValores.Add("<!--CATEGORIAS-->", listaHtmlDeCategorias);
                chavesValores.Add("<!--CIDADES-->", listaHtmlDeCidades);
                chavesValores.Add("<!--VALOR_3MESES-->", valorMensalidade3Meses);
                chavesValores.Add("<!--VALOR_8MESES-->", valorMensalidade8Meses);
                chavesValores.Add("<!--ID-->", fornecedor.Id.ToString());
                chavesValores.Add("<!--SENHA-->", fornecedor.Senha);
                chavesValores.Add("<!--EMAIL-->", fornecedor.Email);
                chavesValores.Add("<!--FICHA_TECNICA-->", fornecedor.UrlFichaTecnica);
                string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailInformativoNovosFornecedores);

                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Mensagem Importante - Instruções do Orçamento Online", true, true, null, "");
                //pedidoOrcamentoService.AssinarLista(fornecedor.Nome, fornecedor.Email);
            }
            catch (Exception e)
            {
                Erro.Logar(e);
            }
        }

        public void EnviarEmailParaForncedoresQueNaoResponderamOsPedidos()
        {
            DateTime dataDeOtem = DateTime.Now.AddDays(-1);

            IList<PedidoOrcamento> pedidosOrcamento = context.Repository<PedidoOrcamento>().Where(x => x.StatusPedidoComprador == PedidoCompradorStatus.NaoRecebiOrcamento && x.DataAlteracao >= dataDeOtem).ToList();

            IOrcamentoFornecedorService orcamentoFornecedorService = new OrcamentoFornecedorService(context);


            foreach (PedidoOrcamento pedido in pedidosOrcamento)
            {
                IList<OrcamentoFornecedor> fornecedores = orcamentoFornecedorService.ObterFornecedoresDoPedido(pedido.Id);

                if (fornecedores.Count > 0)
                {
                    foreach (OrcamentoFornecedor fornecedor in fornecedores)
                    {
                        Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                        chavesValores.Add("<!--NOME_FORNECEDOR -->", fornecedor.Fornecedor.Nome);
                        chavesValores.Add("<!--NOME_COMPRADOR-->", pedido.NomeComprador);
                        chavesValores.Add("<!--EMAIL_COMPRADOR-->", pedido.Email);
                        chavesValores.Add("<!--TELEFONE_COMPRADOR-->", pedido.Telefone);
                        chavesValores.Add("<!--CIDADE-->", pedido.Cidade.Nome);
                        chavesValores.Add("<!--OBSERVACAO-->", pedido.Observacao);
                        chavesValores.Add("<!--TITULO-->", pedido.Titulo + " - Pedido: " + pedido.Id.ToString());

                        string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateCobrarExplicacaoFornecedorPedidoNaoRespondido);

                        Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Fornecedor.Email, htmlEmail, Config.NomeAplicacao + " - Oportunidade - Pedido Não Respondido", true, false, null, "");
                    }
                }

            }

        }

        //public void EnviarEmailConfirmacaoCadastro(Fornecedor fornecedor)
        //{
        //    IFornecedorCategoriaService fornecedorCategoriaService = new FornecedorCategoriaService(context);
        //    IPedidoOrcamentoService pedidoOrcamentoService = new PedidoOrcamentoService(context);
        //    try
        //    {
        //        IList<CategoriaPrioridade> categoriaPrioridade = fornecedorCategoriaService.Obter(fornecedor.Id);

        //        int mesAtual = DateTime.Now.Month;

        //        List<PedidoOrcamento> ultimosPedidosPerfilDoFornecedor = new List<PedidoOrcamento>();
        //        foreach (Cidade cidade in fornecedor.Cidades)
        //        {
        //            if (ultimosPedidosPerfilDoFornecedor.Count == 10)
        //                break;

        //            ultimosPedidosPerfilDoFornecedor.AddRange(pedidoOrcamentoService.ObterUltimosPedidosOrcamentoPorCategoriaMes(10, categoriaPrioridade[0].IdCategoria, mesAtual, cidade.Id));
        //        }


        //        string listaHtmlDePedidosParaCompraAvulsa = "";

        //        foreach (PedidoOrcamento pedidoOrcamento in ultimosPedidosPerfilDoFornecedor.OrderByDescending(x => x.Data).ToList())
        //        {
        //            if (pedidoOrcamento.Status == PedidoStatus.EmailValidado)
        //            {
        //                string dataPedidoOrcamento = String.Format("{0:dd/MM/yyyy}", pedidoOrcamento.Data);

        //                listaHtmlDePedidosParaCompraAvulsa = listaHtmlDePedidosParaCompraAvulsa
        //                    + "<p><b>Data Solicitação: </b>" + dataPedidoOrcamento
        //                    + "<br/><b>Nome: </b>" + pedidoOrcamento.NomeComprador
        //                    + "<br/><b>Cidade/UF: </b>" + pedidoOrcamento.Cidade.Nome + "/" + pedidoOrcamento.Cidade.Uf
        //                    + "<br/><b>Serviço Solicitado: </b>" + categoriaPrioridade[0].IdCategoria.Nome
        //                    + "<br/><b>Descrição: </b>" + pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />")
        //                    + "<br/><strong>Aproveite e já participe dessa cotação avulsa</strong>: <a href='" + Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + fornecedor.ValorAvulso.Replace(".", ",") + "&id=" + fornecedor.Id + "&idPedido=" + pedidoOrcamento.Id + "'>R$" + fornecedor.ValorAvulso + "</a></p><br/>";
        //            }
        //        }

        //        //Titulo do H3 no Box de Compra Avulsa
        //        string tituloBoxCompraAvulva = "";
        //        if (listaHtmlDePedidosParaCompraAvulsa != "")
        //        {
        //            tituloBoxCompraAvulva = "Abaixo pedidos que podem ser do seu interesse:";
        //        }

        //        string listaHtmlDeCategorias = "";
        //        //Montando uma lista HTML li para enviar por email do fornecedor
        //        foreach (Categoria categoria in fornecedor.SubCategorias)
        //        {
        //            listaHtmlDeCategorias = listaHtmlDeCategorias + "<li>" + categoria.Nome + "</li>";
        //        }

        //        listaHtmlDeCategorias = "<ul>" + listaHtmlDeCategorias + "</ul>";

        //        string valorMensalidade = String.Format("{0:#0.00}", fornecedor.ValorMensalidade).Replace(".", ",");
        //        string valorMensalidade3Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidade * 3).Replace(".", ",");
        //        string valorMensalidade8Meses = String.Format("{0:#0.00}", fornecedor.ValorMensalidade * 8).Replace(".", ",");

        //        Dictionary<string, string> chavesValores = new Dictionary<string, string>();
        //        chavesValores.Add("<!--NOME-->", fornecedor.Nome);
        //        chavesValores.Add("<!--TELEFONE-->", fornecedor.Telefone);
        //        chavesValores.Add("<!--H3_PEDIDOS_COMPRA_AVULSA-->", tituloBoxCompraAvulva);
        //        chavesValores.Add("<!--BOX_PEDIDOS_COMPRA_AVULSA-->", listaHtmlDePedidosParaCompraAvulsa);
        //        chavesValores.Add("<!--VALOR_MENSALIDADE-->", valorMensalidade);
        //        chavesValores.Add("<!--DATA_RENOVACAO-->", fornecedor.DataAlteracao.ToString("dd/MM/yyyy"));
        //        chavesValores.Add("<!--CATEGORIAS-->", listaHtmlDeCategorias);
        //        chavesValores.Add("<!--VALOR_3MESES-->", valorMensalidade3Meses);
        //        chavesValores.Add("<!--VALOR_8MESES-->", valorMensalidade8Meses);
        //        chavesValores.Add("<!--ID-->", fornecedor.Id.ToString());
        //        chavesValores.Add("<!--FICHA_TECNICA-->",  fornecedor.UrlFichaTecnica + "-" + fornecedor.Id.ToString() + ".aspx");
        //        string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailInformativoNovosFornecedores);

        //        Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Mensagem Importante - instruções do Orçamento Online", true, false, null, "");
        //        pedidoOrcamentoService.AssinarLista(fornecedor.Nome, fornecedor.Email);
        //    }
        //    catch (Exception e)
        //    {
        //        Erro.Logar(e);
        //    }
        //}
    }
}

