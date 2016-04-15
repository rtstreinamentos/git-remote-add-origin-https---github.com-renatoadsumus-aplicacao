using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
   public interface ICusto_Anunciar_Parceiro
    {
       IList<int> CidadesDeAtuacao { get; }
       IList<string> Categorias { get; }
       bool PalavraEhCorreta { get; }
       int TipoPessoaAtendimento { get; }
       void CalcularValorMensalidade(double valorMensalidade);
       void ExibirMensagemParteInferior(string mensagem);

       void CarregarCategoria(IList<Categoria> categorias);
    }
}
