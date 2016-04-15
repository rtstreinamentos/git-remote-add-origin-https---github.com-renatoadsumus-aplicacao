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
    public class CadastroDadosBasicosPresenterTest
    {
        private Mockery mocks;
        private ICadastroDadosBasicos mockView;
        private IFornecedorService mockCompradorService;
        private ICidadeService mockCidadeService;
        private CadastroDadosBasicosPresenter presenter;
        private Cidade cidade;
        private Fornecedor compradorGravado;
        private Fornecedor comprador;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();

            presenter = new CadastroDadosBasicosPresenter();

            mockView = mocks.NewMock<ICadastroDadosBasicos>();
            presenter.View = mockView;

            mockCidadeService = mocks.NewMock<ICidadeService>();
            presenter.cidadeService = mockCidadeService;

            mockCompradorService = mocks.NewMock<IFornecedorService>();
            presenter.fornecedorService = mockCompradorService;

            cidade = new Cidade();

            compradorGravado = new Fornecedor();
            comprador = new Fornecedor();
        }

        [TearDown]
        public void TearDown()
        {
            mocks.VerifyAllExpectationsHaveBeenMet();
            mocks.Dispose();
        }

        /// <summary>
        /// Inicializa expect padrão para os testes
        /// </summary>
        private void DefinirExpectsPadrao()
        {
            Expect.Once.On(mockView).GetProperty("Nome").Will(Return.Value(comprador.Nome));

            Expect.Once.On(mockView).GetProperty("Email").Will(Return.Value(comprador.Email));
            Expect.Once.On(mockView).GetProperty("Telefone").Will(Return.Value(comprador.Telefone));

            Expect.Once.On(mockView).GetProperty("WebSite").Will(Return.Value(comprador.WebSite));

        }

        /// <summary>
        /// Inicializa objeto válido padrão para os testes
        /// </summary>
        private void DefinirPropriedadesPadrao()
        {
            cidade.Id = 3631;
            cidade.Nome = "Rio de Janeiro";
            cidade.Uf = UF.RJ;

            comprador.Id = 1;
            comprador.Nome = "Fabrício Fujikawa";
            comprador.Email = "fabriciofuji@yahoo.com.br";
            comprador.Telefone = "21-8124-9484";
            comprador.WebSite = "http://orcamentos.net.br/";            
        }

        [Test]
        public void AlterarObjetoValido()
        {
            try
            {
                this.DefinirPropriedadesPadrao();
                this.DefinirExpectsPadrao();
                Expect.Once.On(mockView).GetProperty("IdComprador").Will(Return.Value(comprador.Id));

                Expect.Once.On(mockCompradorService)
                    .Method("Alterar")
                    .WithAnyArguments()
                    .Will(Return.Value(comprador));
                Expect.Once.On(mockView)
                    .Method("ExibirMensagem")
                    .With("<div class='alert alert_blue'><img height='24' width='24' src='/images/icons/small/white/Alert%202.png'>Seus dados foram gravados com sucesso. Para ativar seu cadastro, siga as instruções do e-mail que foi enviado para sua caixa postal. Caso não o receba, verifique se a mensagem está em sua caixa de SPAM e autorize o envio de mensagens a partir de webmaster@orcamentos.net.br.</div>");

                presenter.Alterar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }

        [Test]
        public void AlterarObjetoNaoValido()
        {
            try
            {
                this.DefinirPropriedadesPadrao();
                this.DefinirExpectsPadrao();
                Expect.Once.On(mockView).GetProperty("IdComprador").Will(Return.Value(comprador.Id));

                string camposInvalidos = "CAMPOS INVÁLIDOS";
                Expect.Once.On(mockCompradorService)
                    .Method("Alterar")
                    .WithAnyArguments()
                    .Will(new SetNamedParameterAction("camposInvalidos", camposInvalidos),
                          Return.Value(null));
                Expect.Once.On(mockView).Method("ExibirMensagem").With("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. " + camposInvalidos + ".<br />Por favor, corrija e salve novamente.</div>");

                presenter.Alterar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }

        [Test]
        public void SalvarObjetoValido()
        {
            try
            {
                this.DefinirPropriedadesPadrao();
                this.DefinirExpectsPadrao();

                Expect.Once.On(mockCompradorService)
                    .Method("Inserir")
                    .WithAnyArguments()
                    .Will(Return.Value(comprador));
                Expect.Once.On(mockView)
                    .Method("LimparTela")
                    .WithNoArguments();
                Expect.Once.On(mockView)
                    .Method("ExibirMensagem")
                    .With("<div class='alert alert_blue'><img height='24' width='24' src='/images/icons/small/white/Alert%202.png'>Seus dados foram gravados com sucesso. Para ativar seu cadastro, siga as instruções do e-mail que foi enviado para sua caixa postal. Caso não o receba, verifique se a mensagem está em sua caixa de SPAM e autorize o envio de mensagens a partir de webmaster@orcamentos.net.br.</div>");

                //presenter.Salvar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }

        [Test]
        public void SalvarObjetoNaoValido()
        {
            try
            {
                this.DefinirPropriedadesPadrao();
                this.DefinirExpectsPadrao();

                string camposInvalidos = "CAMPOS INVÁLIDOS";
                Expect.Once.On(mockCompradorService)
                    .Method("Inserir")
                    .WithAnyArguments()
                    .Will(new SetNamedParameterAction("camposInvalidos", camposInvalidos),
                          Return.Value(null));
                Expect.Once.On(mockView).Method("ExibirMensagem").With("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. " + camposInvalidos + ".<br />Por favor, corrija e salve novamente.</div>");

                // presenter.Salvar();
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }
    }
}
