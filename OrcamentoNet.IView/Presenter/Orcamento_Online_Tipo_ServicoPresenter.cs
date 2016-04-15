using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class Orcamento_Online_Tipo_ServicoPresenter
    {
        public IOrcamento_Online_Tipo_Servico View { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public IOrcamentoService orcamentoService
        { get; set; }

        [Inject]
        public IEstadoService estadoService
        { get; set; }

        [Inject]
        public ILinkInternoService linkInternoService
        { get; set; }


        [Inject]
        public IPedidoOrcamentoService pedidoOrcamentoService
        { get; set; }


        public void OnViewInitialized()
        {
            InicializarServico();
        }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }


        public void HabilitarFormulario()
        {
            if (View.IdTipoServicoOrcamento < 10)
            {
                View.HabilitarFormularioEventosFestas();
            }
            else
            {
                View.HabilitarFormularioConstrucao();
            }
        }

        public void MontarLinksInternos()
        {
            Estado estado = estadoService.ObterEstado(View.IdCidadeRecebida);
            Orcamento orcamento = orcamentoService.Obter(View.IdTipoServicoOrcamento);

            if (orcamento != null)
            {
                IList<LinkInterno> linksInternosEstadosCidade;
                IList<LinkInterno> linksInternosTermo = null;
                IList<LinkInterno> linksInternosTipoServico = null;

                Cidade cidade = cidadeService.Obter(View.IdCidadeRecebida);

                if (cidade != null && estado.Nome == null)
                {
                    //Carrega todos as bairros da Cidade
                    linksInternosEstadosCidade = linkInternoService.MontarLinksInternosBairroTipoServico(orcamento, cidade);
                }
                else
                {
                    if (estado.Nome != null)
                    {
                        //Carrega todas as cidades do UF
                        linksInternosEstadosCidade = linkInternoService.MontarLinksInternosCidadeTipoServico(orcamento, estado.Uf);
                    }
                    else
                    {
                        //Carrega todos UF
                        linksInternosEstadosCidade = linkInternoService.MontarLinksInternosDeEstadoTipoServico(orcamento);

                    }
                }

                Categoria categoria = categoriaService.Obter(View.IdCategoriaRecebida, false);

                //Monta links intenos com as categorias ou com os termos de uma categoria
                if (categoria == null)
                    linksInternosTermo = linkInternoService.MontarLinksInternosTermoTipoServico(orcamento, View.IdCidadeRecebida, View.IdBairroRecebido);
                else
                    linksInternosTermo = linkInternoService.MontarLinksInternosTipoServicoPorCategoria(categoria, orcamento);

                IList<Orcamento> orcamentos = orcamentoService.ObterPorTipo(orcamento.TipoServico);

                linksInternosTipoServico = linkInternoService.MontarLinksInternosTipoServico(orcamentos);

                View.MontarLinksInternosDeEstado(linksInternosEstadosCidade);
                View.MontarLinksInternosTermo(linksInternosTermo);
                View.MontarLinksInternosTipoServico(linksInternosTipoServico);
            }
        }
        public void GerarHeaderHTML()
        {
            string h3LinkInterno = "Estado";
            string nomeCidade = "";

            if (View.IdCidadeRecebida > 0)
            {
                Estado estado = estadoService.ObterEstado(View.IdCidadeRecebida);

                if (estado.Nome != null)
                {
                    nomeCidade = estado.Nome;
                    h3LinkInterno = "Cidades e Regiões " + estado.Uf;
                }

                if (estado.Nome == null && View.IdCidadeRecebida != 0)
                {
                    Cidade cidade = cidadeService.Obter(View.IdCidadeRecebida);
                    h3LinkInterno = cidade.Nome;

                    if (View.IdBairroRecebido != 0)
                    {
                        nomeCidade = cidade.Bairros.Where(x => x.Id == View.IdBairroRecebido).First().Nome + " " + cidade.Nome;
                    }
                    else
                    {
                        nomeCidade = cidade.Nome + " " + cidade.Uf;
                    }
                }
            }

            Orcamento orcamento = orcamentoService.Obter(View.IdTipoServicoOrcamento);
            Categoria categoria = categoriaService.Obter(View.IdCategoriaRecebida, false);

            string nomeExibicao = "";

            if (categoria != null)
            {
                nomeExibicao = View.TermoRecebido + " - " + categoria.Nome;
            }

            if (orcamento != null)
            {
                nomeExibicao = orcamento.Nome;

                if (categoria != null)
                {
                    nomeExibicao = categoria.Nome;
                }

                if (DateTime.Now.Minute > 30)
                {
                    nomeExibicao = "Festa de " + orcamento.Nome;
                }

                if (categoria != null && categoria.Pai.Id == 52)
                    nomeExibicao = categoria.Nome + " para " + orcamento.Nome;
            }

            View.GerarHeaderHTML(nomeExibicao, nomeCidade, h3LinkInterno);
        }
    }
}
