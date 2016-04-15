using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.Entity
{
    [Serializable]
    public class PedidoOrcamentoFornecedor
    {
        public virtual int Id { get; set; }
        public virtual int IdInteresse { get; set; }
        public virtual int IdMotivo { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual PedidoOrcamento PedidoOrcamento { get; set; }
        public virtual DateTime Data { get; set; }
    }
}
