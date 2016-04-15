using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class FornecedorPorCategoriaControlePresenter
    {
        public IFornecedorPorCategoriaControle View { get; set; }

        [Inject]
        public IFornecedorService fornecedorService
        { get; set; }

        [Inject]
        public ICategoriaService categoriaService
        { get; set; }

        [Inject]
        public ICidadeService cidadeService
        { get; set; }

        [Inject]
        public IEstadoService estadoService
        { get; set; }


        [Inject]
        public ILinkInternoService linkInternoService
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

        private void CarregarFornecedores(Categoria categoria)
        {
            IList<Fornecedor> fornecedores = new List<Fornecedor>();
            string nomeEstado = "";

            if (View.IdCidade > 0)
            {
                Cidade cidade;

                if (View.IdCidade > 27)
                {
                    cidade = cidadeService.Obter(View.IdCidade);
                    if (cidade != null)
                    {
                        nomeEstado = " - " + cidade.Nome;
                        fornecedores = fornecedorService.ObterClientesPorCategoriaCidade(categoria, cidade);
                    }
                }
                else
                {
                    Estado estado = estadoService.ObterEstado(View.IdCidade);
                    nomeEstado = " - " + estado.Nome;
                    fornecedores = fornecedorService.ObterFornecedoresAtivosPorEstado(categoria, estado.Uf);
                }



            }
            else
            {
                fornecedores = fornecedorService.ObterFornecedoresAtivosPorCategoria(categoria);
            }

            View.CarregarFornecedores(fornecedores);
            View.CarregarCategoria(categoria, nomeEstado);

        }

        private void MontarLinksInternos(Categoria categoria)
        {
            IList<LinkInterno> linksInternosEstadosCidade = new List<LinkInterno>();

            if (View.IdCidade == 0 || View.IdCidade > 30)
            {
                linksInternosEstadosCidade = linkInternoService.MontarLinksInternosDeEstado(categoria, "", Persona.Fornecedor);
            }
            else
            {
                Estado estado = estadoService.ObterEstado(View.IdCidade);
                linksInternosEstadosCidade = linkInternoService.MontarLinksInternosCidades(categoria, estado.Uf, Persona.Fornecedor);
            }

            View.MontarLinksInternosEstadoCidade(linksInternosEstadosCidade);
        }


        public void CarregarTelaInicial()
        {
            Categoria categoria = categoriaService.Obter(View.IdCategoria, false);

            if (View.IdCategoria > 0)
            {
                MontarLinksInternos(categoria);
                CarregarFornecedores(categoria);
            }
        }
    }
}
