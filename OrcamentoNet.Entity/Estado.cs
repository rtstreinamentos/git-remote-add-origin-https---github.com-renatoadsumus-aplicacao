using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Common;

namespace OrcamentoNet.Entity
{
    public class Estado
    {
        public int Id { get; set; }
        public UF Uf { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public IList<Cidade> Cidades { get; set; }
        public IList<LinkInterno> LinksInternos {get; set;}
    }
}
