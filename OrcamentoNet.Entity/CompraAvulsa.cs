using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.Entity
{
   public class CompraAvulsa
    {
       public virtual int Id { get; set; }
       public virtual DateTime Data { get; set; }
       public virtual int Fornecedor { get; set; }
    }
}
