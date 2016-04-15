using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UOL.PagSeguro;

namespace OrcamentoNet.View
{
    public partial class orcamento_online_pagamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                double valor = (Request.QueryString["valor"] != null) ? double.Parse(Request.QueryString["valor"].ToString()) : 120;
                string idPedido = (Request.QueryString["idPedido"] != null) ? Request.QueryString["idPedido"].ToString() : "";
                string idFornecedor = (Request.QueryString["id"] != null) ? Request.QueryString["id"].ToString() : "";
                string plano = (Request.QueryString["plano"] != null) ? Request.QueryString["plano"].ToString() : "";

                string descricao = "";

                if (plano == "")
                {
                    descricao = "Compra Avulsa do Orçamento Online - Pedido:" + idPedido + " /" + idFornecedor;
                }

                if (plano == "1")
                {
                    idPedido = "01";
                    descricao = "Mensalidade do Orçamento Online - " + idFornecedor;
                }

                if (plano == "3")
                {
                    idPedido = "03";
                    descricao = "Plano Trimestral do Orçamento Online - " + idFornecedor;
                }

                if (plano == "8")
                {
                    idPedido = "08";
                    descricao = "Plano Anual do Orçamento Online - " + idFornecedor;
                }

                if (plano == "10")
                {
                    idPedido = "01";
                    descricao = "Desconto de 50% na Mensalidade do Orçamento Online - " + idFornecedor;
                }

                Produto produto = new Produto();
                produto.Codigo = idPedido;
                produto.Descricao = descricao;
                produto.Quantidade = 1;
                produto.Valor = valor;

                this.VendaPagSeguro1.Produtos.Add(produto);
                this.VendaPagSeguro1.Executar(this.Response);
            }
        }
    }
}
