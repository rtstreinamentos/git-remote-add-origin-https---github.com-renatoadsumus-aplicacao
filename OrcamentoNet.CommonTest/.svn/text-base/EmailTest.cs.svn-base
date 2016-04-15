using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OrcamentoNet.Common;

namespace OrcamentoNet.CommonTest
{
    [TestFixture]
    public class EmailTest
    {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void EnviarMensagemPorSmtpDefault() {
            Email.EnviarEmail("webmaster@orcamentos.net.br", "webmaster@orcamentos.net.br", "orcamentos.net@gmail.com", String.Empty, "teste do Método EnviarMensagemPorSmtpDefault", false, true, null, "");
            //o assert deve ser feito através da análise do Log e da caixa de entrada
        }

        [Test]
        public void EnviarMensagemPorTodosSmtp() {
            //verifique em Config quantos são os servidores SMTP configurados e ajuste esta variável
            int quantidadeServidoresSMTP = 2;
            for (int i = 0; i < quantidadeServidoresSMTP; i++)
            {
                Email.EnviarEmail("webmaster@orcamentos.net.br", "webmaster@orcamentos.net.br", "orcamentos.net@gmail.com", String.Empty, "teste do Método EnviarMensagemPorTodosSMTP " + i.ToString() + "/" + (quantidadeServidoresSMTP - 1).ToString(), false, false, null, "");
            }
            //o assert deve ser feito através da análise do Log e da caixa de entrada
        }
    }
}
