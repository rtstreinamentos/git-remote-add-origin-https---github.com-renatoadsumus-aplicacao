using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.Entity
{
    [Serializable]
    public class Termo
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual int IdCategoria { get; set; }
    }
}
