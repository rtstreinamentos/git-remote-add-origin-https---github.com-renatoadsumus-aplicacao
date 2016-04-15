using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using log4net;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.ILocalService;
using OrcamentoNet.LocalService;
using Owasp.Esapi;

namespace OrcamentoNet.IView.Presenter
{
    public class CadastroDadosBasicosPresenter
    {
        public ICadastroDadosBasicos View { get; set; }
       

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        #region "Métodos Privados"
        private void InicializarServico() {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }
        #endregion

        #region "Métodos Públicos"
        public void OnViewInitialized() {
            InicializarServico();
        }

        public void Alterar() {
            Fornecedor comprador = new Fornecedor();
            //string camposInvalidos = String.Empty;
            //comprador = fornecedorService.Alterar(ref camposInvalidos
            //    , View.Nome
            //    , View.Email
            //    , View.Senha
            //    , View.Telefone
            //    , View.CnpjCpf
            //    , View.Endereco
            //    , cidadeService.Obter(View.Cidade)
            //    , View.Bairro
            //    , View.WebSite
            //    , View.IdComprador,null,null);

            if (comprador == null)
            {
                //View.ExibirMensagem("<div class='alert alert_red' id='uxdivAlerta' runat='server'><img height='24' width='24' src='/images/icons/small/white/Alarm%20Bell.png'>Não foi possível salvar os dados. " + camposInvalidos + ".<br />Por favor, corrija e salve novamente.</div>");
            }
            else
            {
                View.ExibirMensagem("<div class='alert alert_blue'><img height='24' width='24' src='/images/icons/small/white/Alert%202.png'>Seus dados foram gravados com sucesso. Para ativar seu cadastro, siga as instruções do e-mail que foi enviado para sua caixa postal. Caso não o receba, verifique se a mensagem está em sua caixa de SPAM e autorize o envio de mensagens a partir de webmaster@orcamentos.net.br.</div>");
            }
        }

        public void CarregarCidades() {
            UF uf = ((UF)Enum.Parse(typeof(UF), View.Estado));

            IList<Cidade> cidades = cidadeService.ObterCidades(uf);

            View.CarregarCidades(cidades);
        }

        public void CarregarDadosBasicosPessoa() {
            Fornecedor comprador = fornecedorService.ObterPorId(View.IdComprador);
            View.CarregarDadosBasicosPessoa(comprador);
        }

        public void CarregarEstados() {
            IList<string> estados = Enum.GetNames(typeof(OrcamentoNet.Entity.Enum.UF));

            View.CarregarEstados(estados);
        }    


        
        #endregion
    }
}