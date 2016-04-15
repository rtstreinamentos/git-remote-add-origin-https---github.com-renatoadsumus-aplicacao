using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Common;

namespace OrcamentoNet.Entity
{
    [Serializable]
    public class Cidade
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual UF Uf { get; set; }
        public virtual double Peso { get; set; }
        public virtual string Url { get { return Common.UtilString.GerarUrlParaSeo(Nome); } }
        public virtual IList<Bairro> Bairros { get; set; }
        public virtual Boolean EhCapital { get; set; }
      
    }
}
