using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.IView.Presenter
{
    public class CidadeListBoxControlePresenter
    {

        public ICidadeListBoxControle View { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }


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

            IList<Cidade> cidades = cidadeService.ObterCidades(uf);

            View.CarregarCidades(cidades);
        }

        public void CarregarEstados()
        {
            IList<string> estados = new List<string>();

            estados = Enum.GetNames(typeof(OrcamentoNet.Entity.Enum.UF));

            View.CarregarEstados(estados);
        }       
    }
}
