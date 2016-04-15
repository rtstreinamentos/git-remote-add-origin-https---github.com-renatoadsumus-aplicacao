using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;

namespace OrcamentoNet.IView.Presenter
{
    public class Custo_Anunciar_ParceiroPresenter
    {
        public ICusto_Anunciar_Parceiro View { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }
        
        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarCategoria()
        {
            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();
            View.CarregarCategoria(categorias);
        }

        public void CalcularValorMensalidade()
        {
            if (!View.PalavraEhCorreta)
            {
                View.ExibirMensagemParteInferior("Código de segurança inválido!");
                return;
            }

            IList<Categoria> subCategorias = new List<Categoria>();

            foreach (string categoria in View.Categorias)
            {
                subCategorias.Add(categoriaService.Obter(Convert.ToInt32(categoria),false));
            }

            IList<Cidade> cidades = new List<Cidade>();


            foreach (int idCidade in View.CidadesDeAtuacao)
            {
                cidades.Add(cidadeService.Obter(idCidade));
            }

            if (subCategorias.Count > 0 && cidades.Count > 0)
            {
                double valorMensalidade = fornecedorService.CalcularValorMensalidade(cidades, subCategorias);

                if (View.TipoPessoaAtendimento == 1)
                {
                    valorMensalidade = valorMensalidade / 2;
                }

                View.CalcularValorMensalidade(valorMensalidade);

                
            }
        }

    }
}
