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
    public class CidadeDropDownControlePresenter
    {
        public ICidadeDropDownControle View { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IEstadoService estadoService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }


        public void OnViewInitialized()
        {
            InicializarServico();
        }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }


        public void CarregarCidades()
        {
            UF uf = ((UF)Enum.Parse(typeof(UF), View.Estado));

            IList<Cidade> cidades = new List<Cidade>();
            cidades = cidadeService.ObterCidades(uf);

            View.CarregarCidades(cidades);

        }     

        public void CarregarTodosEstados()
        {
            IList<string> estados = estadoService.ObterEstados();

            View.CarregarEstados(estados);
        }
    }
}
