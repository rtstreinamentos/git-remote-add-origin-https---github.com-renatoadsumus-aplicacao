using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.Entity
{
    [Serializable]
    public class PedidoEstatistica
    {
        public virtual int Id { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual decimal QuantidadeFornecedores { get; set; }
        public virtual decimal QuantidadePedidos { get; set; }
        public virtual int Mes { get; set; }
        public virtual int Ano { get; set; }
        public virtual string Estatistica
        {
            get
            {
                if (QuantidadeFornecedores != 0)
                {
                    return String.Format("{0:#0.##}", (QuantidadePedidos / QuantidadeFornecedores));
                }
                else
                    return QuantidadePedidos.ToString() + "(<b>Ótima Oportunidade - Ainda não temos fornecedor cadastrado</b>)";

            }
        }

    }
}
