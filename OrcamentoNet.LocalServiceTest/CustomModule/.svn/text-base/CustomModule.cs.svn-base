using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.LocalService;
using NHibernate.Burrow;
using PortalEscolar.Data;

namespace OrcamentoNet.LocalServiceTest
{
    public class CustomModule : StandardModule
    {
        public override void Load()
        {
            new BurrowFramework().InitWorkSpace();

            Bind<IDataContext>().To<NHibernateContext>();
            Bind<ICategoriaService>().To<CategoriaService>();
            Bind<ICidadeService>().To<CidadeService>();
            Bind<IFornecedorService>().To<FornecedorService>();
            Bind<IPedidoOrcamentoService>().To<PedidoOrcamentoService>();
            Bind<ISiteMapService>().To<SiteMapService>();
            Bind<IOpiniaoService>().To<OpiniaoService>();
            Bind<IFotoService>().To<FotoService>();
            Bind<ILinkInternoService>().To<LinkInternoService>();
            Bind<IFornecedorCategoriaService>().To<FornecedorCategoriaService>();
            Bind<IOrcamentoService>().To<OrcamentoService>();
            Bind<IMensalidadeService>().To<MensalidadeService>();
        }
    }
}
