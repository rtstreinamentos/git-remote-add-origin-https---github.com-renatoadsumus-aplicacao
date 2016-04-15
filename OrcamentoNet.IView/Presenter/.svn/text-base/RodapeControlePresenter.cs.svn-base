using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.IView.Presenter
{
    public class RodapeControlePresenter
    {
         public IRodapeControle View { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarInformacoesRodape()
        {
            var categoria = categoriaService.ObterXMLCategoria(View.IdCategoria);

            var nomeCategoria = from p in categoria
                                select p;

            foreach (var registro in categoria)
            {
                //View.CarregarInformacoesRodape(registro.Element("nome").Value.Trim(), 
                //    registro.Element("urlVoceConhece").Value.Trim(),
                //    registro.Element("nomeExibicaoVoceConhece").Value.Trim(),
                //    registro.Element("tooltipVoceConhece").Value.Trim(),
                //    registro.Element("urlHistorico").Value.Trim(),
                //    registro.Element("nomeExibicaoHistorico").Value.Trim(),
                //    registro.Element("tooltipHistorico").Value.Trim());
            }
        }

    }
}
