using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OrcamentoNet.Common;

namespace OrcamentoNet.CommonTest
{
  [TestFixture]
  public class ValidadorTest
  {
    private ValidadorDados validador;

    [SetUp]
    public void Setup() {
      validador = new ValidadorDados();
    }

    [Test]
    public void ValidarCNPJInvalidoNumerosLetras() {
      bool passou = validador.ValidarCNPJ("abc");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarCNPJInvalidoSomenteNumeros() {
      bool passou = validador.ValidarCNPJ("50829331000100");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarCNPJValidoNumerosPontos() {
      bool passou = validador.ValidarCNPJ("50.829.331/0001-07");
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarCNPJValidoSomenteNumeros() {
      bool passou = validador.ValidarCNPJ("50829331000107");
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarCNPJVazio() {
      bool passou = validador.ValidarCNPJ("");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarConjuntoObrigatorioInvalido() {
      bool passou = validador.ValidarConjuntoObrigatorio("1", "2|3|4", true);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarConjuntoObrigatorioInvalidoMinusculas() {
      bool passou = validador.ValidarConjuntoObrigatorio("rj", "RJ|SP|MG", false);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarConjuntoObrigatorioSemConjunto() {
      bool passou = validador.ValidarConjuntoObrigatorio("qualquer", "", true);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarConjuntoObrigatorioSemConteudo() {
      bool passou = validador.ValidarConjuntoObrigatorio("", "1|2", true);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarConjuntoObrigatorioSemPipe() {
      bool passou = validador.ValidarConjuntoObrigatorio("qualquer", "texto-sem-pipe", true);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarConjuntoObrigatorioValido() {
      bool passou = validador.ValidarConjuntoObrigatorio("RJ", "RJ|SP|MG", true);
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarCPFInvalidoNumerosLetras() {
      bool passou = validador.ValidarCPF("abc");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarCPFInvalidoSomenteNumeros() {
      bool passou = validador.ValidarCPF("01401969781");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarCPFValidoNumerosPontos() {
      bool passou = validador.ValidarCPF("014.019.697-80");
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarCPFValidoSomenteNumeros() {
      bool passou = validador.ValidarCPF("01401969780");
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarCPFVazio() {
      bool passou = validador.ValidarCPF("");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarEmailFormatoInvalido() {
      bool passou = validador.ValidarEmail("fabriciofuji", 100);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarEmailTamanho() {
      bool passou = validador.ValidarEmail("fabriciofuji@yahoo.com.br", 10);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarEmailValido() {
      bool passou = validador.ValidarEmail("fabriciofuji@yahoo.com.br", 100);
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarEmailVazio() {
      bool passou = validador.ValidarEmail("", 100);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarLetrasInvalido() {
      bool passou = validador.ValidarLetras("AB", 4, 4);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarLetrasValido() {
      bool passou = validador.ValidarLetras("AB", 2, 2);
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarSenhaSemCaracteresEspeciais() {
      bool passou = validador.ValidarSenha("X1234abc");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarSenhaSemLetras() {
      bool passou = validador.ValidarSenha("!1234000");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarSenhaSemNumeros() {
      bool passou = validador.ValidarSenha("!XXXXabc");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarSenhaValida() {
      bool passou = validador.ValidarSenha("!1234abc");
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarSenhaVazio() {
      bool passou = validador.ValidarSenha("");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarTelefoneFormatoInvalido() {
      bool passou = validador.ValidarTelefone("(1234x5678 r.15)", 20);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarTelefoneTamanho() {
      bool passou = validador.ValidarTelefone("12345", 4);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarTelefoneValido() {
      bool passou = validador.ValidarTelefone("(1234-5678 r.15)", 20);
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarTelefoneVazio() {
      bool passou = validador.ValidarTelefone("", 15);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarTextoLivreAntiXSS() {
      bool passou = validador.ValidarTextoLivre("<script>", 1, 100);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarTextoLivreTamanhoMaximo() {
      bool passou = validador.ValidarTextoLivre("12345678901", 1, 10);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarTextoLivreTamanhoMinimo() {
      bool passou = validador.ValidarTextoLivre("1234", 5, 10);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarTextoLivreValido() {
      bool passou = validador.ValidarTextoLivre("Nome válido Joana D'arc", 1, 100);
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarTextoLivreVazio() {
      bool passou = validador.ValidarTextoLivre("", 1, 100);
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarXSSInvalido() {
      bool passou = validador.ValidarXSS("<script>");
      Assert.IsFalse(passou);
    }

    [Test]
    public void ValidarXSSValido() {
      bool passou = validador.ValidarXSS("texto sem xss");
      Assert.IsTrue(passou);
    }

    [Test]
    public void ValidarXSSVazio() {
      bool passou = validador.ValidarXSS("--");
      Assert.IsTrue(passou);
    }
  }
}
