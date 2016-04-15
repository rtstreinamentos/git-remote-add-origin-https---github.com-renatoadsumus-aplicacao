using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class Orcamento_Online_PagamentoPresenter
    {
        public IOrcamento_Online_Pagamento View { get; set; }

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

        public void ValidarMensalidadeFornecedor()
        {
            Fornecedor fornecedor = fornecedorService.ObterPorId(View.IdFornecedor);

            if (fornecedor != null)
            {
                View.RedirecionarPagSeguro();
            }
        }
    }
}
