using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Common;

namespace OrcamentoNet.IView.Presenter
{
    public class CadastroPedidoOrcamentoSimplesPresenter
    {
        public ICadastroPedidoOrcamentoSimples View { get; set; }

        [Inject]
        public ICategoriaService categoriaService
        { get; set; }

        [Inject]
        public IFornecedorService fornecedorService
        { get; set; }

        [Inject]
        public ICidadeService cidadeService
        { get; set; }

        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService
        { get; set; }

        [Inject]
        public IOrcamentoService orcamentoService
        { get; set; }


        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void Salvar()
        {
            if (View.IdCidadePedidoOrcamento != 0 && View.SubCategorias.Count >= 0)
            {
                Cidade cidadePedidoOrcamento = cidadeService.Obter(View.IdCidadePedidoOrcamento);

                IList<Categoria> categoriasSelecionadas = categoriaService.ObterSubCategoriasDeUmaCategoria(View.SubCategorias);

                string camposInvalidos = String.Empty;

                if (View.PalavraEhCorreta &&
                    (categoriasSelecionadas.Count > 0 ||
                    View.Termos.Count > 0) &&
                    cidadePedidoOrcamento != null)
                {
                    string tituloOrcamento=View.Titulo;

                    if (View.IdTipoServicoOrcamento > 0)
                    {
                        Orcamento orcamento = orcamentoService.Obter(View.IdTipoServicoOrcamento);

                        if (orcamento != null)
                            tituloOrcamento = orcamento.Nome;
                    }

                    PedidoOrcamento pedidoOrcamento = new PedidoOrcamento();
                    pedidoOrcamento.NomeComprador = View.Nome;
                    pedidoOrcamento.Email = View.Email;
                    pedidoOrcamento.Telefone = View.Telefone;
                    pedidoOrcamento.PretensaoServico = View.IdPretensao;
                    pedidoOrcamento.Categorias = categoriasSelecionadas;
                    pedidoOrcamento.Cidade = cidadePedidoOrcamento;
                    pedidoOrcamento.Titulo = tituloOrcamento;
                    pedidoOrcamento.TelefoneOperadora = View.TelefoneOperadora;
                    pedidoOrcamento.Fotos = View.Fotos;
                    pedidoOrcamento.FotoPrincipal = Config.UrlSite;
                    pedidoOrcamento.Ano = DateTime.Now.Year;
                    pedidoOrcamento.Mes = DateTime.Now.Month;

                    string termo = categoriaService.MontarHTMLDeTermo(View.SubCategorias, View.Termos);

                    pedidoOrcamento.Observacao = termo + Environment.NewLine + View.Observacao;

                    pedidoOrcamento = pedidoOrcamentoService.Inserir(ref camposInvalidos, pedidoOrcamento);

                    //Só envia email se conseguir gravar o pedido
                    if (pedidoOrcamento != null)
                    {
                        pedidoOrcamentoService.EnviarEmailPedidoOrcamentoSimplificado(pedidoOrcamento);
                        
                        View.RedirecionarPaginaSucesso();
                    }
                    else
                    {
                        View.ExibirMensagem("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. " + camposInvalidos + ".<br />Por favor, corrija e salve novamente.</div>");
                    }
                }
                else
                {
                    camposInvalidos = "Preenchimento inválido: Ramo de Atividade";
                    View.ExibirMensagem("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. " + camposInvalidos + ".<br />Por favor, corrija e salve novamente.</div>");
                }
            }
            else
            {
                View.ExibirMensagem("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. Cidade <br />Por favor, corrija e salve novamente.</div>");
            }
        }

        public void CarregarSubCategorias()
        {

            if (View.IdCategoriaRecebida > 0)
            {
                IList<Categoria> subCategorias = categoriaService.ObterCategoriasDeUmTema(View.IdCategoriaRecebida);

                View.CarregarSubCategorias(subCategorias);
            }

            if (View.IdTipoServicoOrcamento > 0)
            {
                Orcamento orcamento = orcamentoService.Obter(View.IdTipoServicoOrcamento);

                if (orcamento != null)
                {
                    IList<Categoria> categorias = new List<Categoria>();
                    
                    foreach (Categoria categoria in orcamento.Categorias)
                    {
                        categoria.Termos = categoriaService.ObterTermos(categoria.Id);
                        categorias.Add(categoria);
                    }

                    View.CarregarSubCategorias(categorias);
                }
            }
        }

    }
}
