using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.Entity
{
    [Serializable]
    public class PostBlog
    {
        public virtual int Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual string FotoPrincipal { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
