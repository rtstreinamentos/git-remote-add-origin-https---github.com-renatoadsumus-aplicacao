using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using Owasp.Esapi;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Common;


namespace OrcamentoNet.IView.Presenter
{
    public class LoginPresenter
    {
        public ILogin View { get; set; }

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

        public void ValidarAcesso()
        {
            //string senhaDigitada = Owasp.Esapi.Esapi.Encryptor.Encrypt(View.Senha);

            Fornecedor fornecedor = fornecedorService.ObterPorEmail(View.Email);

            if (fornecedor != null && int.Parse(fornecedor.Senha) == int.Parse(View.Senha) && fornecedor.Status != Status.Inativo)
                View.CriarSessao(fornecedor);
            else
                View.ExibirMensagem("Usuário ou Senha Inválidos");
        }

        public void RecuperarSenha()
        {
            Fornecedor fornecedor = fornecedorService.ObterPorEmail(View.EmailRecuperarSenha);

            if (fornecedor != null)
            {
                Dictionary<string, string> chavesValores = new Dictionary<string, string>();
                chavesValores.Add("<!--NOME_FORNECEDOR-->", fornecedor.Nome);
                chavesValores.Add("<!--SENHA_FORNECEDOR-->", fornecedor.Senha);
                chavesValores.Add("<!--EMAIL_FORNECEDOR-->", fornecedor.Email);

                string htmlEmail = Email.ObterHTML(chavesValores, Config.TemplateEmailRecuperarSenha);

                Email.EnviarEmail(Config.EmailAdministrador, Config.EmailAdministrador, fornecedor.Email, htmlEmail, "Mensagem Importante - Recuperação de Senha", true, true, null, "");

                View.ExibirMensagem("Sua senha foi enviada para seu email!");
            }
            else
            {
                View.ExibirMensagem("Email não cadastrado!");

            }
        }
    }
}
