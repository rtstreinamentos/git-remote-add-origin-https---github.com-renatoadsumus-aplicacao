﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Common;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class CadastroFornecedoresOrcamentoOnlinePresenter
    {
        private string plano1;

        public ICadastroFornecedoresOrcamentoOnline View { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public IFornecedorCategoriaService fornecedorCategoriaService { get; set; }

        [Inject]
        public ILinkInternoService linkInternoService { get; set; }

        [Inject]
        public IEstadoService estadoService { get; set; }


        [Inject]
        public IFotoService fotoService { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void AssinarBoletimFornecedores(string nomeFornecedor, string emailFornecedor)
        {
            try
            {
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create("http://orcamentos.us5.list-manage1.com/subscribe/post?u=4c98dbfae1be41163d7e88131&amp;id=2f88b69315");
                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                string postData = "FNAME=" + nomeFornecedor + "&EMAIL=" + emailFornecedor;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
        }

        public void GerarHeaderHTML()
        {
            string nomeCidade = "";

            if (View.IdCidade > 27)
            {
                Cidade cidade = cidadeService.Obter(View.IdCidade);
                nomeCidade = cidade.Nome;
            }

            if (View.IdCidade > 0 && View.IdCidade < 28)
            {
                Estado estado = estadoService.ObterEstado(View.IdCidade);
                nomeCidade = estado.Nome;
            }

            Categoria categoria = categoriaService.Obter(View.IdCategoria, false);
            if (categoria != null)
            {
                View.GerarHeaderHTML(categoria.Nome, nomeCidade, categoria.Termo);
                this.MontarLinksInternos(categoria);
            }
        }

        public void Salvar()
        {
            //if (!View.PalavraEhCorreta)
            //{
            //    View.ExibirMensagemParteInferior("Código de segurança inválido!");
            //    return;
            //}

            Fornecedor fornecedor = fornecedorService.ObterPorEmail(View.Email);

           // Common.Email.EnviarEmail("orcamentos.net@gmail.com", "orcamentos.net@gmail.com", "orcamentos.net@gmail.com", "Categoria Principal:" + View.IdCategoriaPrincipal.ToString() + "Email:" + View.Email.ToLower(), "Categoria Principal", false, true, null, "");

            if (fornecedor == null)
            {
                IList<string> camposInvalidos = new List<string>();

                IList<Cidade> cidades = new List<Cidade>();

                foreach (int idCidade in View.CidadesDeAtuacao)
                {
                    cidades.Add(cidadeService.Obter(idCidade));
                }

                IList<Categoria> subCategorias = MontarListaDeCategoriasSelecionadas();

                Fornecedor fornecedorCadastrado = new Fornecedor();
                fornecedorCadastrado.Nome = View.Nome;
                fornecedorCadastrado.Email = View.Email.ToLower();
                fornecedorCadastrado.EnviadoPorUltimo = false;
                fornecedorCadastrado.EmailSecundario = View.Email.ToLower();
                fornecedorCadastrado.Telefone = View.Telefone;
                fornecedorCadastrado.Cidades = cidades;
                fornecedorCadastrado.SubCategorias = subCategorias;
                fornecedorCadastrado.ValorMensalidade = View.ValorMensalidade;
                //fornecedorCadastrado.ValorMensalidade = double.Parse(plano1);
                fornecedorCadastrado.ValorMensalidadeAlteracao = View.ValorMensalidade;
                fornecedorCadastrado.Descricao = View.Descricao;
                fornecedorCadastrado.WebSite = View.WebSite.ToLower();
                fornecedorCadastrado.Indicacao = View.Indicacao;
                fornecedorCadastrado.TipoPessoaAtendimento = PessoaTipo.Fisica;
                fornecedorCadastrado.TipoPessoaAtendimentoAlteracao = PessoaTipo.Fisica;


                //    //AssinarBoletimFornecedores(fornecedorCadastrado.Nome, fornecedorCadastrado.Email);

                fornecedor = fornecedorService.Inserir(ref camposInvalidos,
                                                           fornecedorCadastrado,
                                                           View.WebSite);



                //    if (fornecedor != null && fornecedor.Id != 0)
                //    {
                //        CategoriaPrioridade categoriaPrioridade = new CategoriaPrioridade();
                //        categoriaPrioridade.Fornecedor = fornecedor;
                //        categoriaPrioridade.IdCategoria = categoriaService.Obter(View.IdCategoriaPrincipal, false);
                //        categoriaPrioridade.Prioridade = 1;

                //        //fornecedorCategoriaService.Inserir(categoriaPrioridade);
                //    }


                fornecedorService.EnviarEmailConfirmacaoCadastro(fornecedor);
                EnviarUltimosPedidos(fornecedor);

                //    if (camposInvalidos.Count() > 0)
                //    {
                //        View.ExibirMensagemParteInferior("Preenchimento inválido!");
                //    }
                //    else
                //    {

                //        View.GuardarFornecedorNaSessao(fornecedor);
                //        View.ViewEscolhaDoPlano();
                //    }
                //}
                //else
                //{
                //    View.ExibirMensagemParteInferior("Fornecedor já cadastrado!");
            }
        }

        public void EnviarUltimosPedidos(Fornecedor fornecedor)
        {
            DateTime dataInicio = DateTime.Now.AddDays(-7);
            DateTime dataFim = DateTime.Now;
            IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorIntervaloDeData(dataInicio, dataFim);
            List<PedidoOrcamento> pedidosOrcamentoResultado = new List<PedidoOrcamento>();

            foreach (Cidade cidade in fornecedor.Cidades)
            {
                pedidosOrcamentoResultado.AddRange(pedidosOrcamento.Where(x => x.Cidade == cidade).ToList());
            }

            string pedidoHtml = "";
            string htmlEmail = "";
            string solicitante = "";
            string categoriaPedido = "";
            string cabecalho = "Olá, " + fornecedor.Nome + "!<br /><br /><b>Seguem abaixo os últimos pedidos recebidos em nosso sistema:</b><br /><br />";

            foreach (PedidoOrcamento pedidoOrcamento in pedidosOrcamentoResultado)
            {
                foreach (Categoria categoria in fornecedor.SubCategorias)
                {
                    if (pedidoOrcamento.Categorias.Contains(categoria))
                    {
                        categoriaPedido = categoriaPedido + categoria.Nome + ", ";

                        string emailValidado = "";

                        if (pedidoOrcamento.Status == PedidoStatus.EmailValidado)
                        {
                            emailValidado = " (<b>e-mail validado!</b>)";
                        }

                        string email = pedidoOrcamento.Email.Substring(0, 6) + "...@XXX.com";
                        string telefone = pedidoOrcamento.Telefone.Substring(0, 7) + "-XXXX";
                        string telefoneOperadora = "";


                        solicitante = "<br />Solicitante: " + pedidoOrcamento.NomeComprador +
                                     "<br />Telefone: " + telefone + " Operadora: " + telefoneOperadora +
                                     "<br />Email: " + email + emailValidado +
                                     "<br />Serviços solicitados:<br />" + pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />") +
                                     "<br />Cidade: " + pedidoOrcamento.Cidade.Nome +
                                     "<br /><br />";
                    }
                }

                if (solicitante != "")
                {
                    pedidoHtml = pedidoHtml + "<h3>Número do Pedido: " + pedidoOrcamento.Id.ToString() + "</h3><br/><b>Título: </b>" + pedidoOrcamento.Titulo + "<br>" + solicitante;
                }

                solicitante = "";
                categoriaPedido = "";
            }

            if (pedidoHtml != "")
            {
                htmlEmail = cabecalho + pedidoHtml;

                string valorMensalidade = String.Format("{0:#0.00}", fornecedor.ValorMensalidadeAlteracao).Replace(".", ",");

                Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                chavesValores.Add("<!--NOME_FORNECEDOR-->", fornecedor.Nome);
                chavesValores.Add("<!--VALOR_MENSALIDADE-->", valorMensalidade);
                chavesValores.Add("<!--PEDIDOS-->", pedidoHtml);
                chavesValores.Add("<!--URL-->", Config.UrlSite + "orcamento-online-pagamento.aspx?valor=" + valorMensalidade + "&id=" + fornecedor.Id + "&plano=1");
                htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateUltimosPedidosDegustacao);

                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Mensagem Importante - Últimos Pedidos de Orçamento Recebidos", true, true, null, "");
            }
        }

        public void CarregarCategoria()
        {
            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();
            View.CarregarCategoria(categorias);
        }

        public void SalvarFotos()
        {
            Fornecedor fornecedor = View.Fornecedor;
            Foto foto;

            foreach (string item in View.Fotos)
            {
                foto = new Foto();
                foto.Caminho = item;
                foto.Nome = fornecedor.Nome;
                foto.Titulo = fornecedor.Nome;
                foto.Fornecedor = fornecedor;
                fotoService.Inserir(foto);
            }
        }

        public void CarregarCategoriasSelecionadas()
        {
            IList<Categoria> subCategorias = MontarListaDeCategoriasSelecionadas();

            View.CarregarCategoriasSelecionadas(subCategorias.OrderBy(x => x.Nome).ToList());
        }

        private IList<Categoria> MontarListaDeCategoriasSelecionadas()
        {
            IList<Categoria> subCategorias = new List<Categoria>();

            foreach (string categoria in View.Categorias)
            {
                Categoria categoriaFornecedor = categoriaService.Obter(Convert.ToInt32(categoria), false);

                subCategorias.Add(categoriaFornecedor);
            }

            return subCategorias;
        }

        public void MontarLinksInternos(Categoria categoria)
        {
            IList<LinkInterno> linksInternosTermo = linkInternoService.MontarLinksInternosTermoFornecedor(categoria);
            View.MontarLinksInternosTermos(linksInternosTermo);
        }

        public void CalcularPlano()
        {
            string faixaCategoria = categoriaService.ObterFaixaCategoria(View.IdCategoriaPrincipal);

            IList<Cidade> cidades = new List<Cidade>();

            string plano1 = "";
            string plano2 = "";
            Boolean ehCapital = false;

            foreach (int idCidade in View.CidadesDeAtuacao)
            {
                if (cidadeService.Obter(idCidade).EhCapital)
                {
                    ehCapital = true;
                    break;
                }
            }

            if (ehCapital)
            {
                if (faixaCategoria == "A")
                {
                    plano1 = "11,00";
                    plano2 = "19,00";
                }

                if (faixaCategoria == "B")
                {
                    plano1 = "19,00";
                    plano2 = "57,00";
                }

                if (faixaCategoria == "C")
                {
                    plano1 = "57,00";
                    plano2 = "87,00";
                }
            }
            else
            {
                if (faixaCategoria == "A")
                {
                    plano1 = "5,00";
                    plano2 = "7,00";
                }

                if (faixaCategoria == "B")
                {
                    plano1 = "7,00";
                    plano2 = "17,00";
                }

                if (faixaCategoria == "C")
                {
                    plano1 = "17,00";
                    plano2 = "57,00";
                }
            }

            this.plano1 = plano1;
            View.ApresentarValoresPlanos(plano1, plano2);
        }

        public void AtualizarValorMensalidade()
        {
            Fornecedor fornecedor = fornecedorService.ObterPorId(View.Fornecedor.Id);

            if (fornecedor != null)
            {
                fornecedor.ValorMensalidade = View.ValorMensalidade;
                fornecedor.TipoPessoaAtendimento = PessoaTipo.Juridica;
                fornecedor.ValorMensalidadeAlteracao = View.ValorMensalidade;
                fornecedor.TipoPessoaAtendimentoAlteracao = PessoaTipo.Juridica;
            }
        }
    }
}
