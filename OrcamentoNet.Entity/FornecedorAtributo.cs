using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.Entity
{
    [Serializable]
    public class FornecedorAtributo
    {
        public virtual int Fornecedor { get; set; }
        public virtual int Atributo { get; set; }
        public virtual int Condicao { get; set; }
       
    }
}
