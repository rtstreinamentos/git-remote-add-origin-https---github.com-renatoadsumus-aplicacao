using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using NMock2;
using NMock2.Actions;
using NUnit.Framework;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.ILocalService;
using OrcamentoNet.IView;
using OrcamentoNet.IView.Presenter;

namespace OrcamentoNet.PresenterTest
{
    [TestFixture]
    public class LinksInternosControlePresenterTest
    {
        private Mockery mocks;
		private ILinksInternosControle mockView;
        private LinksInternosControlePresenter presenter;

        [SetUp]
        public void SetUp() {
            mocks = new Mockery();

			presenter = new LinksInternosControlePresenter();
        }

        [TearDown]
        public void TearDown() {
            mocks.VerifyAllExpectationsHaveBeenMet();
            mocks.Dispose();
        }
    }
}
