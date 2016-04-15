using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity._enum;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.IView.Presenter
{
    public class LinksInternosControlePresenter
    {
        #region Propriedades

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public ILinkInternoService linkInternoService { get; set; }

        [Inject]
        public IEstadoService estadoService { get; set; }

        public ILinksInternosControle View { get; set; }

        #endregion

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void MontarLinksInternos()
        {
            Categoria categoria = categoriaService.Obter(View.IdCategoria, false);

            IList<LinkInterno> linksInternosEstadosCidade = new List<LinkInterno>();

            Estado estado = estadoService.ObterEstado(View.IdCidade);
            string nomeCidadeEstado = "";
            int idUltimoEstadoDoEnum = 27;
            Bairro bairro = null;
            Cidade cidade = null;

            //Carrega Todos Estados
            if (View.IdCidade == 0)
            {
                linksInternosEstadosCidade = linkInternoService.MontarLinksInternosDeEstado(categoria, "", Persona.Comprador);
            }


            //Carrega Todas Cidades
            if (View.IdCidade > 0 && View.IdCidade < idUltimoEstadoDoEnum)
            {
                UF uf = ((UF)Enum.Parse(typeof(UF), View.IdCidade.ToString()));
                nomeCidadeEstado = estado.Nome;
                linksInternosEstadosCidade = linkInternoService.MontarLinksInternosCidades(categoria, uf, Persona.Comprador);
            }

            //Carrega Todas as Regioes de uma cidade
            if (View.IdCidade > idUltimoEstadoDoEnum)
            {
                cidade = cidadeService.Obter(View.IdCidade);

                if (View.IdBairro != 0)
                {
                    bairro = cidade.Bairros.Where(x => x.Id == View.IdBairro).FirstOrDefault();
                    nomeCidadeEstado = cidade.Nome + " - " + cidade.Bairros.Where(x => x.Id == View.IdBairro).FirstOrDefault().Nome;
                }
                else
                {
                    nomeCidadeEstado = cidade.Nome;
                }

                linksInternosEstadosCidade = linkInternoService.MontarLinksInternosBairro(cidade, categoria, Persona.Comprador);
            }

            IList<LinkInterno> linksInternosTermosCategoria = linkInternoService.MontarLinksInternosTermosDaCategoria(categoria, View.IdCidade, bairro, cidade);
            IList<LinkInterno> linksInternosEstadoParceiros = linkInternoService.MontarLinksInternosDeEstado(categoria, "", Persona.Fornecedor);

            View.MontarLinksInternosTermo(linksInternosTermosCategoria);
            View.MontarLinksInternosDeEstado(linksInternosEstadosCidade);
            View.MontarLinksInternosDeEstadoParceiros(linksInternosEstadoParceiros);
            View.GerarHeaderHTML(categoria, nomeCidadeEstado);
        }
    }
}
