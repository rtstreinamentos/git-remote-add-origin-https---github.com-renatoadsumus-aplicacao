using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using InfoGlobo.InjectionFramework.Core;
using NHibernate.Burrow;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.LocalServiceTest
{
	[TestFixture]
	public class CidadeServiceTest
	{
		private StandardKernel injectionService;

		[Inject]
		public ICidadeService cidadeService { get; set; }

		[SetUp]
		public void Setup() {
			injectionService = new StandardKernel(new CustomModule());
			injectionService.Inject(this);
		}

		[TearDown]
		public void TearDown() {
			new BurrowFramework().CloseWorkSpace();
		}

		[Test]
		public void ObterCidadesTest() {
			IList<Cidade> cidades = cidadeService.ObterCidades(UF.RJ);

			Assert.IsTrue(cidades.Count > 0);
		}

		[Test]
		public void ObterCidadeTest() {
			Cidade cidade = cidadeService.Obter(6005);

			Assert.IsTrue(cidade.Id != 0);
		}
	}
}
