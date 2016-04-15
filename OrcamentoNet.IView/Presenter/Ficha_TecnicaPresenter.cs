using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Entity._enum;
using OrcamentoNet.Common;

namespace OrcamentoNet.IView.Presenter
{
    public class Ficha_TecnicaPresenter
    {
        public IFicha_Tecnica View { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public IOpiniaoService opiniaoService { get; set; }

        [Inject]
        public ILinkInternoService linkInternoService { get; set; }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void CarregarFornecedor()
        {
            Fornecedor fornecedor = fornecedorService.ObterPorId(View.IdFornecedor);

            if (fornecedor != null && fornecedor.Status != Status.Inativo)
            {
                IList<Fornecedor> fornecedoresRelacionados = fornecedorService.ObterUltimosFornecedoresCadastradosDoTemaOuCategoriaPorEstadoCidade(6, fornecedor.SubCategorias[0].Pai.Id, (int)fornecedor.Cidades[0].Uf, DateTime.Now.Month, "");

                if (fornecedoresRelacionados.Count < 1)
                    fornecedoresRelacionados = fornecedorService.ObterUltimosFornecedoresCadastradosDoTemaOuCategoriaPorEstadoCidade(6, fornecedor.SubCategorias[0].Pai.Id, (int)fornecedor.Cidades[0].Uf, DateTime.Now.Month - 1, "");

                fornecedoresRelacionados.Remove(fornecedor);

                View.CarregarFornecedor(fornecedor);
                View.CarregarOpinioes(opiniaoService.ObterPorFornecedor(View.IdFornecedor));
                View.MontarHeadPagina(fornecedor);
                // View.CarregarFornecedoresRelacionados(fornecedoresRelacionados);
                View.GerarFacebook(fornecedor.UrlFichaTecnica);

                IList<LinkInterno> linksInternosEstadosCidade = linkInternoService.MontarLinksInternosDeEstado(fornecedor.SubCategorias[0].Pai, "", Persona.Fornecedor);
                View.MontarLinksInternosDeEstado(linksInternosEstadosCidade);
            }
        }

        public void SalvarOpiniao()
        {
            Fornecedor fornecedor = fornecedorService.ObterPorId(View.IdFornecedor);

            if (fornecedor != null)
            {
                View.CarregarFornecedor(fornecedor);

                Opiniao opiniao = new Opiniao();
                opiniao.Fornecedor = fornecedor;
                opiniao.Descricao = View.Descricao;
                opiniao.Titulo = View.Titulo;
                opiniao.Nome = View.Nome;
                opiniao.Email = View.Email;
                opiniao.Satisfacao = View.Satisfacao;
                opiniaoService.Inserir(opiniao);
                View.LimparTela();
                View.ExibirMensagem();
                Email.EnviarEmail(Common.Config.EmailAdministrador, "", Common.Config.EmailAdministrador, "Comentário - " + opiniao.Fornecedor.Nome, "Comentário - " + opiniao.Fornecedor.Nome, false, false, null, "");

            }
        }
    }
}
