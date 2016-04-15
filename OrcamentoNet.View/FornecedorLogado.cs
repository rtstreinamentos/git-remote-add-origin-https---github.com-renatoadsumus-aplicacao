using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrcamentoNet.Entity;

namespace OrcamentoNet.View
{
    public class FornecedorLogado : System.Web.UI.Page
    {
        public Fornecedor Fornecedor { get; set; }

        public FornecedorLogado()
        {

            if (Session["FornecedorLogado"] != null)
            {
                Fornecedor = ((Fornecedor)Session["FornecedorLogado"]);
            }
            else
            {
                Fornecedor = null;                
            }
        }        
    }
}
