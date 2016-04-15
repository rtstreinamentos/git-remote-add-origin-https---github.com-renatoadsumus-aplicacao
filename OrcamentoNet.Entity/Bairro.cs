﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrcamentoNet.Entity
{
    [Serializable]
    public class Bairro
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }       
    }
}
