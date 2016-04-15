using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.IView;
using System.Threading;

namespace OrcamentoNet.View
{
    public partial class orcamento_online_notificacao_pagamento : System.Web.UI.Page, IOrcamento_Online_Notificacao_Pagamento
    {
        Orcamento_Online_Notificacao_PagamentoPresenter presenter;
        int idPedidoOrcamento = 0;
        string emailComprador;
        string nomeComprador;
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new Orcamento_Online_Notificacao_PagamentoPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();

            if (!IsPostBack)
            {
               
                string notificationCode = Request.Form["notificationCode"];
                string notificationType = Request.Form["notificationType"];

#if DEBUG 
				string urlPagSeguro = "http://localhost:53618/PagSeguro.xml";
#else
                string urlPagSeguro = "https://ws.pagseguro.uol.com.br/v2/transactions/notifications/" +
                                       notificationCode +
                                      "?email=orcamentos.net@gmail.com" +
                                      "&token=A235412F351C46E593505A35B9564E39";
#endif

				XElement xml = XElement.Load(urlPagSeguro);

                var statusTransacao = from p in xml.Elements("status")
                                      select p.Value;

                var nomeComprador = from p in xml.Elements("sender").Elements("name")
                                    select p.Value;

                this.nomeComprador = nomeComprador.SingleOrDefault();


                var emailComprador = from p in xml.Elements("sender").Elements("email")
                                     select p.Value;

                this.emailComprador = emailComprador.SingleOrDefault();

                var idItemCarrinho = from p in xml.Elements("items").Elements("item").Elements("id")
                                     select p.Value;

                idPedidoOrcamento = int.Parse(idItemCarrinho.FirstOrDefault());

                //Aguardando pagamento
                if (statusTransacao.SingleOrDefault() == "1")
                {
                    presenter.PedidoDePagamentoSolicitado();
                }

                //Paga: a transação foi paga pelo comprador e o PagSeguro já recebeu uma confirmação da instituição financeira responsável pelo processamento.
                if (statusTransacao.SingleOrDefault() == "3")
                {
                    presenter.ConfirmarPagamento();
                }

                //Cancelada: o pagamento não foi efetuado no prazo
                if (statusTransacao.SingleOrDefault() == "7")
                {
                    presenter.RecuperarFornecedor();
                }
            }
        }

		public int IdPedidoOrcamento
        {
            get { return idPedidoOrcamento; }
        }

        public string EmailComprador
        {
            get { return emailComprador; }
        }

        public string NomeComprador
        {
            get { return nomeComprador; }
        }
    }
}
