﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.Entity
{
    [Serializable]
    public class PedidoOrcamento
    {
        public virtual int Id { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual string Email { get; set; }
        public virtual string Observacao { get; set; }
        public virtual string OpiniaoComprador { get; set; }
        public virtual string PontosMelhoria { get; set; }
        public virtual string NomeComprador { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string TelefoneOperadora { get; set; }
        public virtual string Titulo { get; set; }
        public virtual IList<Categoria> Categorias { get; set; }
        public virtual PedidoCompradorStatus StatusPedidoComprador { get; set; }
        public virtual DateTime DataAlteracao { get; set; }
        public virtual bool Gostou { get; set; }
        public virtual PedidoStatus Status { get; set; }
        public virtual bool PesquisaRespondida { get; set; }
        public virtual bool PesquisaRevisada { get; set; }
        public virtual int PretensaoServico { get; set; }
        public virtual int Ano { get; set; }       
        public virtual int Mes { get; set; }        
        public virtual IList<string> Fotos { get; set; }
        public virtual string FotoPrincipal { get; set; }
        public virtual ClassificacaoPedido ClassificacaoPedido { get; set; }
        public virtual bool AprovadoParaSite { get; set; }
        public virtual string StatusPedidoCompradorTitulo
        {
            get
            {
                string status = "";

                if (StatusPedidoComprador == PedidoCompradorStatus.NaoRecebiOrcamento)
                {
                    status = "Não recebi orçamentos.";
                }

                if (StatusPedidoComprador == PedidoCompradorStatus.JaFechei)
                {
                    status = "Já fechei.";
                }

                if (StatusPedidoComprador == PedidoCompradorStatus.Analisando)
                {
                    status = "Estou analisando os orçamentos.";
                }

                if (StatusPedidoComprador == PedidoCompradorStatus.Desisti)
                {
                    status = "Desisti, não vou contratar.";
                }

                return status;
            }
        }
        public virtual string TituloPreco
        {
            get
            {
                return "Preço " + Titulo;
            }
        }
        public virtual PessoaTipo PessoaTipo { get; set; }
    }
}
