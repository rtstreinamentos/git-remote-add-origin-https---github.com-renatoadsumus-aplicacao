using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class LinksInternosTemaCategoriaPresenter
    {
        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public ILinkInternoService linkInternoService { get; set; }

        [Inject]
        public IEstadoService estadoService
        { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        public ILinksInternosTemaCategoria View { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void MontarArvoreDeLinksInternos()
        {
            Categoria categoria = categoriaService.Obter(View.IdCategoria, false);
            string termoPesquisa = Common.UtilString.GerarPalavraTermoPesquisa(View.TermoPesquisa);

            IList<LinkInterno> linksInternosEstadosCidade = new List<LinkInterno>();

            Estado estado = estadoService.ObterEstado(View.IdCidade);

            Cidade cidade = cidadeService.Obter(View.IdCidade);

            if (cidade != null && estado.Nome == null)
            {
                linksInternosEstadosCidade = linkInternoService.MontarLinksInternosBairro(cidade, categoria, Persona.MotorBusca);
            }
            else
            {
                if (estado.Nome != null)
                {
                    linksInternosEstadosCidade = linkInternoService.MontarLinksInternosCidades(categoria, estado.Uf, Persona.MotorBusca);
                }
                else
                {
                    linksInternosEstadosCidade = linkInternoService.MontarLinksInternosDeEstado(categoria, termoPesquisa, Persona.MotorBusca);
                }
            }

            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();

            IList<LinkInterno> linksInternosMesAno = linkInternoService.MontarLinksInternosMesAno(categoria, View.IdCidade, termoPesquisa);
            IList<LinkInterno> linksInternosTermo = linkInternoService.MontarLinksInternosTermo(categoria, View.IdCidade, Persona.MotorBusca,View.IdBairro);
            View.MontarArvoreDeLinksInternos(categorias);
            View.MontarLinksInternosDeEstado(linksInternosEstadosCidade);
            View.MontarLinksInternosMesAno(linksInternosMesAno);
            View.MontarLinksInternosTermo(linksInternosTermo);
        }
    }
}
