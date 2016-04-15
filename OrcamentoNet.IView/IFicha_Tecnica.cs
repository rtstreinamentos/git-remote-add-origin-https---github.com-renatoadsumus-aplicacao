using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface IFicha_Tecnica
    {
        int IdFornecedor { get; }
        string Descricao { get; }
        string Titulo { get; }
        string Nome { get; }
        string Email { get; }
        string Satisfacao { get; }
        void CarregarFornecedor(Fornecedor fornecedor);
        void CarregarOpinioes(IList<Opiniao> opinioes);

        void LimparTela();

        void ExibirMensagem();

        void MontarHeadPagina(Fornecedor fornecedor);

        void CarregarFornecedoresRelacionados(IList<Fornecedor> fornecedoresRelacionados);

        void MontarLinksInternosDeEstado(IList<LinkInterno> linksInternosEstadosCidade);

        void GerarFacebook(string p);
    }
}
