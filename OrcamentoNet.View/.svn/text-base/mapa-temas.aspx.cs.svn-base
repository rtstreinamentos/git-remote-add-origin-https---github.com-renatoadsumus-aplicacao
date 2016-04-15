using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using OrcamentoNet.IView.Presenter;
using OrcamentoNet.IView;

namespace OrcamentoNet.View
{
    public partial class orcamento_online_temas : System.Web.UI.Page, IOrcamento_Online_Temas
    {
        int idCategoriaRecebida;
        int idCidade = 0;
		string nomeDaCategoria = String.Empty;
		string nomeDoEstado = String.Empty;
        string urlSolicitarOrcamento;
        string termoPesquisa = String.Empty;
		string mes = String.Empty;
		string ano = String.Empty;
        private int idBairro;

        Orcamento_Online_TemasPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new Orcamento_Online_TemasPresenter();
            presenter.View = this;
            presenter.OnViewInitialized();
            if (!IsPostBack)
            {
                idCidade = (Request.QueryString["cidade"] != null) ? Convert.ToInt32(Request.QueryString["cidade"].ToString()) : 0;
                idCategoriaRecebida = (Request.Params["categoria"] != null) ? Int32.Parse(Request.Params["categoria"]) : 0;
				termoPesquisa = (Request.Params["termo"] != null) ? Request.Params["termo"].ToString().Replace("-", " ") : String.Empty;
				ano = (Request.QueryString["ano"] != null) ? Request.QueryString["ano"].ToString() : String.Empty;
				mes = (Request.QueryString["mes"] != null) ? Request.QueryString["mes"].ToString() : String.Empty;
                idBairro = (Request.Params["bairro"] != null) ? Int32.Parse(Request.Params["bairro"]) : 0;

				switch (mes)
				{
					case "01" :
						mes = "Janeiro";
						break;
					case "02":
						mes = "Fevereiro";
						break;
					case "03":
						mes = "Março";
						break;
					case "04":
						mes = "Abril";
						break;
					case "05":
						mes = "Maio";
						break;
					case "06":
						mes = "Junho";
						break;
					case "07":
						mes = "Julho";
						break;
					case "08":
						mes = "Agosto";
						break;
					case "09":
						mes = "Setembro";
						break;
					case "10":
						mes = "Outubro";
						break;
					case "11":
						mes = "Novembro";
						break;
					case "12":
						mes = "Dezembro";
						break;
				}
				presenter.GerarHeaderHTML();
            }
        }

        #region Propriedades
		public string Ano {
			get { return mes; }
		}

        public int IdBairro
        {
            get { return idBairro; }
        }

		public int IdCategoria
        {
            get { return idCategoriaRecebida; }
        }

        public int IdCidade
        {
            get { return idCidade; }
        }

		public string Mes {
			get { return mes; }
		}

		public string NomeCategoria {
			get { return nomeDaCategoria; }
		}

		public string NomeEstado {
			get { return nomeDoEstado; }
		}

		public string UrlSolicitarOrcamento
        {
            get { return urlSolicitarOrcamento; }
            set { }
        }
        #endregion

        #region Métodos
        public void GerarHeaderHTML(string nomeCategoria, string nomeEstado)
        {
			nomeDaCategoria = nomeCategoria;
			nomeDoEstado = nomeEstado;

            string titleDaPagina = "Empresas e negócios em " + nomeCategoria;
            if (!String.IsNullOrEmpty(nomeEstado))
            {
                titleDaPagina = titleDaPagina + " em " + nomeEstado;
            }
			if (!String.IsNullOrEmpty(termoPesquisa))
			{
				titleDaPagina = titleDaPagina + " - " + termoPesquisa;
			}
			if (!String.IsNullOrEmpty(ano))
			{
				titleDaPagina = titleDaPagina + " - " + mes + "/" + ano;
			}
			Page.Title = titleDaPagina;
            uxTituloH1.InnerText = titleDaPagina;

			string descriptionDaPagina = nomeCategoria;
			if (!String.IsNullOrEmpty(nomeEstado))
			{
				descriptionDaPagina = descriptionDaPagina + " em " + nomeEstado;
			}
			if (!String.IsNullOrEmpty(termoPesquisa))
			{
				descriptionDaPagina = descriptionDaPagina + " - " + termoPesquisa;
			}
			if (!String.IsNullOrEmpty(ano))
			{
				descriptionDaPagina = descriptionDaPagina + " - " + mes + "/" + ano;
			}
			descriptionDaPagina = "Últimas empresas e profissionais cadastrados em " + descriptionDaPagina + ", e oportunidades de negócio geradas pelo Orçamento Online.";
            HtmlMeta metaDescription = new HtmlMeta();
            metaDescription.Name = "description";
            metaDescription.Content = descriptionDaPagina;
            Page.Header.Controls.Add(metaDescription);

			string textoIntroducaoDaPagina = nomeCategoria;
            if (!String.IsNullOrEmpty(nomeEstado))
            {
				textoIntroducaoDaPagina = textoIntroducaoDaPagina + ", em " + nomeEstado;
            }
			if (!String.IsNullOrEmpty(termoPesquisa))
			{
				textoIntroducaoDaPagina = textoIntroducaoDaPagina + " - " + termoPesquisa;
			}
			if (!String.IsNullOrEmpty(ano))
			{
				textoIntroducaoDaPagina = textoIntroducaoDaPagina + " - " + mes + "/" + ano;
			}
			ExibirMensagem("<p class='productDescription'>Conheça as mais recentes <strong>empresas e profissionais cadastrados em " + textoIntroducaoDaPagina + "</strong>, as últimas <strong>oportunidades de negócio</strong> geradas pelo Orçamento Online e os <strong>depoimentos dos clientes</strong> que usaram os nossos serviços.</p>");

			string tituloH2UltimasEmpresasProfissionais = "Últimas Empresas e Profissionais em " + nomeCategoria;
            if (!String.IsNullOrEmpty(nomeEstado))
            {
				tituloH2UltimasEmpresasProfissionais = tituloH2UltimasEmpresasProfissionais + ", em " + nomeEstado;
            }
			if (!String.IsNullOrEmpty(termoPesquisa))
			{
				tituloH2UltimasEmpresasProfissionais = tituloH2UltimasEmpresasProfissionais + " - " + termoPesquisa;
			}
			if (!String.IsNullOrEmpty(ano))
			{
				tituloH2UltimasEmpresasProfissionais = tituloH2UltimasEmpresasProfissionais + " - " + mes + "/" + ano;
			}
			uxTituloH2UltimasEmpresasProfissionais.InnerText = tituloH2UltimasEmpresasProfissionais;

			string tituloH2UltimasOportunidades = "Últimas Oportunidades de Negócio em " + nomeCategoria;
			if (!String.IsNullOrEmpty(nomeEstado))
			{
				tituloH2UltimasOportunidades = tituloH2UltimasOportunidades + ", em " + nomeEstado;
			}
			if (!String.IsNullOrEmpty(termoPesquisa))
			{
				tituloH2UltimasOportunidades = tituloH2UltimasOportunidades + " - " + termoPesquisa;
			}
			if (!String.IsNullOrEmpty(ano))
			{
				tituloH2UltimasOportunidades = tituloH2UltimasOportunidades + " - " + mes + "/" + ano;
			}
			uxTituloH2UltimasOportunidades.InnerText = tituloH2UltimasOportunidades;

			string tituloH2UltimosDepoimentos = "Últimos Depoimentos de Clientes sobre " + nomeCategoria;
			if (!String.IsNullOrEmpty(nomeEstado))
			{
				tituloH2UltimosDepoimentos = tituloH2UltimosDepoimentos + ", em " + nomeEstado;
			}
			if (!String.IsNullOrEmpty(termoPesquisa))
			{
				tituloH2UltimosDepoimentos = tituloH2UltimosDepoimentos + " - " + termoPesquisa;
			}
			if (!String.IsNullOrEmpty(ano))
			{
				tituloH2UltimosDepoimentos = tituloH2UltimosDepoimentos + " - " + mes + "/" + ano;
			}
			uxTituloH2UltimosDepoimentos.InnerText = tituloH2UltimosDepoimentos;
		}

        public void ExibirMensagem(string mensagem)
        {
            MensagemSuperiorControle1.ExibirMensagem(mensagem);
        }
        #endregion

    }
}
