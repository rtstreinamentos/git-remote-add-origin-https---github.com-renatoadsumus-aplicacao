using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;

namespace OrcamentoNet.IView.Presenter
{
    public class AdminAlterarDadosPresenter
    {
        public IAdminAlterarDados View { get; set; }

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

        public void Salvar()
        {
            IList<string> camposInvalidos = new List<string>();

            IList<Cidade> cidades = new List<Cidade>();

            foreach (int idCidade in View.CidadesDeAtuacao)
            {
                cidades.Add(cidadeService.Obter(idCidade));
            }

            IList<Categoria> subCategorias = new List<Categoria>();

            foreach (string categoria in View.Categorias)
            {
                subCategorias.Add(categoriaService.Obter(Convert.ToInt32(categoria), false));
            }

            Fornecedor fornecedor = fornecedorService.ObterPorEmail(View.Email);

            if (fornecedor != null)
            {
                double valorMensalidade = fornecedorService.CalcularValorMensalidade(cidades, subCategorias);

                fornecedor.WebSite = View.WebSite;
                fornecedor.Telefone = View.Telefone;
                fornecedor.Nome = View.Nome;
                fornecedor.Descricao = View.Descricao;
                fornecedor.ValorMensalidade = valorMensalidade;
                fornecedor.SubCategorias = subCategorias;
                fornecedor.Cidades = cidades;
                fornecedorService.Alterar(fornecedor);
            }

        }

        public void CarregarFornecedor()
        {
            Fornecedor fornecedor = fornecedor = fornecedorService.ObterPorEmail(View.Email);

            if (fornecedor != null)
            {
                View.CarregarFornecedor(fornecedor);
            }
        }

        public void CalcularValorMensalidade()
        {
            IList<Categoria> subCategorias = new List<Categoria>();

            foreach (string categoria in View.Categorias)
            {
                subCategorias.Add(categoriaService.Obter(Convert.ToInt32(categoria), false));
            }

            IList<Cidade> cidades = new List<Cidade>();


            foreach (int idCidade in View.CidadesDeAtuacao)
            {
                cidades.Add(cidadeService.Obter(idCidade));
            }

            if (subCategorias.Count > 0 && cidades.Count > 0)
            {
                double valorMensalidade = fornecedorService.CalcularValorMensalidade(cidades, subCategorias);
                View.CalcularValorMensalidade(valorMensalidade);
            }
        }
    }
}
