using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class Orcamento_Online_TemasPresenter
    {
        public IOrcamento_Online_Temas View { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public IEstadoService estadoService
        { get; set; }

        [Inject]
        public ICidadeService cidadeService
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

        public void GerarHeaderHTML()
        {
            Estado estado = estadoService.ObterEstado(View.IdCidade);
            string nomeEstado = "";

            if (estado.Nome != null)
            {
                nomeEstado = estado.Nome;
            }
            else
            {
                Cidade cidade = cidadeService.Obter(View.IdCidade);
                if (cidade != null && estado.Nome == null)
                    nomeEstado = cidade.Nome;

                if (View.IdBairro != 0)
                {
                    nomeEstado = cidade.Bairros.Where(x => x.Id == View.IdBairro).First().Nome + "-" + cidade.Nome;
                }
            }

            Categoria categoria = categoriaService.Obter(View.IdCategoria, false);

            if (categoria != null)
            {
                View.GerarHeaderHTML(categoria.Nome, nomeEstado);
            }
        }
    }
}
