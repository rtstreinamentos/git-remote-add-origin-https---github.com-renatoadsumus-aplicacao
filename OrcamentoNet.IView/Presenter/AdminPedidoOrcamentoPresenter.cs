using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Common;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class AdminPedidoOrcamentoPresenter
    {
        public IAdminPedidoOrcamento View { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService { get; set; }


        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarCategoria()
        {
            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();
            View.CarregarCategoria(categorias);
        }

        public void CarregarPedidoOrcamento()
        {
            PedidoOrcamento pedido = pedidoOrcamentoService.Obter(View.IdPedidoOrcamento);

            if (pedido != null)
                View.CarregarPedidoOrçamento(pedido);
        }

        public void Salvar()
        {
            Cidade cidade = cidadeService.Obter(View.IdCidade);

            PedidoOrcamento pedido = pedidoOrcamentoService.ObterUltimoPedidoDoEmail(View.Email);
            pedido.Email = View.Email;
            //pedido.DataAlteracao = DateTime.Now;
            pedido.Titulo = View.Titulo;
            pedido.Observacao = View.Observacao;
            pedido.Cidade = cidade;
            pedido.Categorias = MontarListaCategorias();
            pedido.FotoPrincipal = View.FotoPrincipal;
            pedido.ClassificacaoPedido = View.ClassificacaoPedido;
            pedido.AprovadoParaSite = bool.Parse(View.ApareceNoSite);

        }

        private IList<Categoria> MontarListaCategorias()
        {
            IList<Categoria> categorias = new List<Categoria>();

            foreach (string item in View.Categorias)
            {
                Categoria categoria = categoriaService.Obter(Convert.ToInt32(item), false);
                categorias.Add(categoria);
            }

            return categorias;
        }

        public void SolicitarMaisInformacao()
        {
            PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Obter(View.IdPedidoOrcamento);

            Dictionary<string, string> chavesValores = GerarHtmlPedido(pedidoOrcamento);


            string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailPedidoOrcamentoIncompleto);

            Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, pedidoOrcamento.Email, htmlEmail, "Mensagem Importante - Seu Pedido de orçamento contém pouca informação!", true, false, null, "");

        }

        public void CarregarPerguntasCompletarPedido()
        {
            IList<string> listaPerguntas = new List<string>();
            listaPerguntas.Add("O que você gostaria que fosse servido no buffet?");
            listaPerguntas.Add("O buffet terá bebida alcoólica? Quais?");
            listaPerguntas.Add("Qual é o tema da festa?");
            listaPerguntas.Add("Que tipos de doces você gostaria?");
            listaPerguntas.Add("Que tipo de lembrança você gostaria?");
            listaPerguntas.Add("Quais os tipos de música você gostaria?");
            listaPerguntas.Add("Gostaria de exibir um vídeo no telão durante o evento?");
            listaPerguntas.Add("Precisa de Sushiman no local?");
            listaPerguntas.Add("Quantas pessoas do evento gostam de comida japonesa?");

            string perguntas = "";

            foreach (String pergunta in listaPerguntas)
            {
                perguntas = perguntas + pergunta + Environment.NewLine + Environment.NewLine;
            }

           // View.CarregarPerguntasCompletarPedido(perguntas);
        }

        public void CarregarUltimosPedidos()
        {
            //DateTime dataDosPedidos = DateTime.Now.AddDays(View.DiaPedido);
            //IList<PedidoOrcamento> pedidosOrcamento = pedidoOrcamentoService.ObterPedidosOrcamentoPorDataStatus(dataDosPedidos, PedidoStatus.EmailNaoValidado);
            //View.CarregarUltimosPedidos(pedidosOrcamento);
        }

        public void AprovarPedido()
        {
            PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Obter(View.IdPedidoOrcamento);
            pedidoOrcamento.Data = DateTime.Now;
            pedidoOrcamento.Status = PedidoStatus.EmailValidado;

            CarregarUltimosPedidos();

        }

        public void NotificarFornecedorCompraAvulsa()
        {
            PedidoOrcamento pedidoOrcamento = pedidoOrcamentoService.Obter(View.IdPedidoOrcamento);

            Dictionary<string, string> chavesValores = GerarHtmlPedido(pedidoOrcamento);

            chavesValores.Add("<!--NOME_FORNECEDOR-->", View.NomeFornecedorAvulso);

            string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailCompraAvulsa);

            Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, View.EmailFornecedorAvulso, htmlEmail, "Mensagem Importante - Compra Avulsa Pedido - " + pedidoOrcamento.Id, true, false, null, "");
        }

        private Dictionary<string, string> GerarHtmlPedido(PedidoOrcamento pedidoOrcamento)
        {
            string statusEmail = "(<strong>Email Validado!</strong>)";
            Dictionary<string, string> chavesValores = new Dictionary<string, string>();

            if (pedidoOrcamento.Status == PedidoStatus.EmailValidado)
            {
                chavesValores.Add("<!--STATUS_EMAIL-->", statusEmail);
            }

            chavesValores.Add("<!--NOME_COMPRADOR-->", pedidoOrcamento.NomeComprador);
            chavesValores.Add("<!--PEDIDO_ID-->", pedidoOrcamento.Id.ToString());
            chavesValores.Add("<!--EMAIL_COMPRADOR-->", pedidoOrcamento.Email);
            chavesValores.Add("<!--TELEFONE_COMPRADOR-->", pedidoOrcamento.Telefone);
            chavesValores.Add("<!--CIDADE-->", pedidoOrcamento.Cidade.Nome);
            chavesValores.Add("<!--UF-->", pedidoOrcamento.Cidade.Uf.ToString());
            chavesValores.Add("<!--SERVICOS_SOLICITADOS-->", pedidoOrcamentoService.CategoriasDoPedidoSeparadasPorVirgula(pedidoOrcamento));
            chavesValores.Add("<!--DUVIDAS-->", View.Perguntas.Replace(Environment.NewLine, "<br />"));
            chavesValores.Add("<!--TITULO-->", pedidoOrcamento.Titulo);
            chavesValores.Add("<!--OBSERVACAO-->", pedidoOrcamento.Observacao.Replace(Environment.NewLine, "<br />"));

            return chavesValores;
        }
    }
}
