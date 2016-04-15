using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Common;
using OrcamentoNet.Entity._enum;

namespace OrcamentoNet.IView.Presenter
{
    public class GuiaTemasPresenter
    {
        public IGuiaTemas View { get; set; }

        [Inject]
        public ICategoriaService categoriaService { get; set; }

        [Inject]
        public ICidadeService cidadeService { get; set; }

        [Inject]
        public IEstadoService estadoService { get; set; }

        [Inject]
        public IFornecedorService fornecedorService { get; set; }

        [Inject]
        public ILinkInternoService linkInternoService { get; set; }


        private void InicializarServico()
        {
            StandardKernel k = new StandardKernel(new CustomModule());
            k.Inject(this);
        }

        public void OnViewInitialized()
        {
            InicializarServico();
        }

        public void CarregarFornecedores()
        {
            Categoria categoria = categoriaService.Obter(View.IdCategoria, false);
            
            string nomeCidade = "";
            IList<Fornecedor> fornecedores;

            //IdCidade == 0 é Estado
            if (View.IdCidade == 0)
                fornecedores = fornecedorService.ObterClientesPorTema(categoria).Take(15).ToList();
            else
            {
                Cidade cidade = cidadeService.Obter(View.IdCidade);
                fornecedores = fornecedorService.ObterClientesPorCategoriaCidade(categoria, cidade);
                nomeCidade = " - " + cidade.Nome;
            }

            View.CarregarFornecedores(fornecedores);
            View.GerarHeaderHTML(categoria.Nome, categoria.Url, nomeCidade);
        }

        public void CarregarCidadesDoEstado()
        {
            List<Estado> estados = new List<Estado>();
            Estado estado;

            Categoria categoria = categoriaService.Obter(View.IdCategoria, false);

            foreach (UF uf in Enum.GetValues(typeof(UF)))
            {               
                    estado = new Estado();
                    estado.Uf = uf;
                    int idUF = (int)Enum.Parse(typeof(UF), Enum.GetName(typeof(UF), uf));
                    estado.Nome = estadoService.ObterEstado(idUF).Nome;
                    estado.LinksInternos = linkInternoService.MontarLinksInternosCidadesCategoria(cidadeService.ObterCidades(uf), categoria);

                    estados.Add(estado);               
            }

            View.CarregarCidadesDoEstado(estados);
        }        

        public void MontarLinksInternos()
        {
            Categoria categoria = categoriaService.Obter(View.IdCategoria, false);

            IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();
            IList<LinkInterno> linksInternosTermo = linkInternoService.MontarLinksInternosTermo(categoria, View.IdCidade, Persona.Comprador,0);

            View.MontarLinksInternosTermo(linksInternosTermo);
            View.MontarArvoreDeLinksInternos(categorias);
        }     

    }
}
