using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.Common;
using System.Data;
using MySql.Data.MySqlClient;

namespace OrcamentoNet.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MalaDiretaPresenter malaDiretaPresenter = new MalaDiretaPresenter();

            //malaDiretaPresenter.EnviarEmailMalaDireta();

            NHibernate.Burrow.BurrowFramework nhibernate = new NHibernate.Burrow.BurrowFramework();
            nhibernate.InitWorkSpace();

            ServicoNotificarFornecedorPresenter presenter = new ServicoNotificarFornecedorPresenter();
            presenter.OnViewInitialized();
            nhibernate.CloseWorkSpace();
            
        }       

    }    
}
