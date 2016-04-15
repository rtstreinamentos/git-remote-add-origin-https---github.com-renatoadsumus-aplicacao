﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView
{
    public interface ICadastroPedidoOrcamentoSimples
    {
        string Email { get; }
        int IdCidadePedidoOrcamento { get; }
        int IdCategoriaRecebida { get; }
        int IdTipoServicoOrcamento { get; }
        string Nome { get; }
        bool PalavraEhCorreta { get; }
        string Observacao { get; }
        string TelefoneOperadora { get; }
        IList<string> SubCategorias { get; }
        IList<string> Fotos { get; }
        IList<Termo> Termos { get; }
        string Titulo { get; }
        string Telefone { get; }
        int IdPretensao { get; }
        void ExibirMensagem(string mensagem);       
        void RedirecionarPaginaSucesso();

        void CarregarSubCategorias(IList<Categoria> subCategorias);
        
    }
}