using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class FornecedoresControlePresenter
    {
        public IFornecedoresControle View { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarUltimosFornecedoresCadastrados()
        {
            string termoPesquisa = Common.UtilString.GerarPalavraTermoPesquisa(View.TermoPesquisa);

            IList<Fornecedor> fornecedores = fornecedorService.ObterUltimosFornecedoresCadastradosDoTemaOuCategoriaPorEstadoCidade(View.QuantidadeFornecedores, View.IdCategoria, View.IdCidade, View.Mes, termoPesquisa);
            View.CarregarUltimosFornecedoresCadastrados(fornecedores);
        }
    }
}
