using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using NHibernate.Burrow;
using NUnit.Framework;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;
using PerceptiveMCAPI;
using PerceptiveMCAPI.Types;
using PerceptiveMCAPI.Methods;

namespace OrcamentoNet.LocalServiceTest
{
    [TestFixture]
    public class NewsletterServiceTest
    {
        public INewsletterService newsletterService { get; set; }

        listBatchSubscribeInput input = new listBatchSubscribeInput();

        [SetUp]
        public void Setup()
        {
            this.newsletterService = new OrcamentoNet.LocalService.NewsletterService();

            // any directive overrides
            input.api_Validate = true;
            input.api_AccessType = EnumValues.AccessType.Serial;
            input.api_OutputType = EnumValues.OutputType.JSON;
            // method parameters
            input.parms.apikey = "5bd4b073902ccb6e5a93a7c4f75206bd-us2";
            input.parms.id = "4c85bff9bd";
            input.parms.double_optin = true;
            input.parms.update_existing = true;
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        // Verificar o resultado deste teste na caixa postal do e-mail que assinou a lista 
        // antes de rodar este teste, remover o e-mail da lista
        // (deve chegar uma mensagem pedindo confirmação da assinatura)
        public void AssinarListaSucesso()
        {
            newsletterService.AssinarLista("Fabrício Yutaka Fujikawa", "fabriciofuji@yahoo.com.br");
        }

        [Test]
        // Verificar o resultado deste teste na caixa postal de administração do site (deve chegar um relatório de erro)
        public void AssinarListaErro() {
            input.parms.apikey = "umaAPIinvalida";
            this.newsletterService = new OrcamentoNet.LocalService.NewsletterService(input);
            newsletterService.AssinarLista("Fabrício Yutaka Fujikawa", "fabriciofuji@yahoo.com.br");
        }
    }
}
