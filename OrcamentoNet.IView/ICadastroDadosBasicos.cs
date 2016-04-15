using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface ICadastroDadosBasicos
    {
        string Bairro { get; }
        int Cidade { get; }
        string CnpjCpf { get; }
        string Email { get; }
        string Endereco { get; }
        string Estado { get; }
        string Nome { get; }
        string Senha { get; }
        string Telefone { get; }
        string TipoPessoa { get; }
        int IdComprador { get; }
        string WebSite { get; }
        void CarregarCidades(IList<Cidade> cidades);
        void CarregarEstados(IList<string> ufs);
        void CarregarDadosBasicosPessoa(Fornecedor comprador);      
        void ExibirMensagem(string mensagem);
        void LimparTela();
    }
}
