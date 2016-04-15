using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.IView.Presenter
{
    public class orcamento_online_compradorPresenter
    {
        public Iorcamento_online_comprador View { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarAreaDeAtuacaoPorEstado()
        {
            Estado estado;
            IList<Estado> estados = new List<Estado>();

            foreach (string item in Enum.GetNames(typeof(OrcamentoNet.Entity.Enum.UF)))
            {
                estado = new Estado();
                estado.Uf = item;
                UF uf = (UF)Enum.Parse(typeof(UF), item);
                estado.Cidades = cidadeService.ObterCidades(uf);

                if (estado.Cidades.Count > 1)
                    estados.Add(estado);
            }

            View.CarregarAreaDeAtuacaoPorEstado(estados);
        }

        public class Estado
        {
            public IList<Cidade> Cidades { get; set; }
            public string Uf { get; set; }
        }
    }
}
