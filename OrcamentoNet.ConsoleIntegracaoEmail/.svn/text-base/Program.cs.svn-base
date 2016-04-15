using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.ConsoleIntegracaoEmail
{
    class Program
    {
        static void Main(string[] args) {
            NHibernate.Burrow.BurrowFramework nhibernate = new NHibernate.Burrow.BurrowFramework();
            nhibernate.InitWorkSpace();

            ServicoIntegracoesEmailPresenter presenter = new ServicoIntegracoesEmailPresenter();
            presenter.OnViewInitialized();
            nhibernate.CloseWorkSpace();
        }
    }
}
