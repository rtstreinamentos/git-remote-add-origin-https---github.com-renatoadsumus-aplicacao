using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoGlobo.InjectionFramework.Core;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.Common;

namespace OrcamentoNet.IView.Presenter
{
    public class GuiaPresenter
    {

        public IGuia View { get; set; }

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
        

        private IList<LinkInterno> GerarLinksInternosFornecedorCidadesCategoria(IList<Cidade> cidades)
        {
            IList<LinkInterno> linksInternos = new List<LinkInterno>();
            LinkInterno linkInterno;
            Categoria categoria = categoriaService.Obter(View.IdCategoria, false);

            foreach (Cidade cidade in cidades)
            {
                linkInterno = new LinkInterno();
                linkInterno.Nome = cidade.Nome;
                linkInterno.UrlAmigavel = GerarUrlParaSeo(categoria.Nome) + "-" +
                                          GerarUrlParaSeo(cidade.Nome) + "-" +
                                          "-" + categoria.Id +
                                          "-" + cidade.Id +
                                          ".aspx";
                linksInternos.Add(linkInterno);
            }

            return linksInternos;
        }

        public void CarregarCategorias()
        {
			IList<Categoria> categorias = categoriaService.ObterCategoriasAtivas();           
            View.CarregarCategorias(categorias);
        }

        public string GerarUrlParaSeo(string nomeSemTratamento)
        {
            if (String.IsNullOrEmpty(nomeSemTratamento)) return String.Empty;

            string nomeAmigavel = nomeSemTratamento.Replace(",", String.Empty);

            nomeAmigavel = nomeAmigavel.Replace("(", String.Empty);
            nomeAmigavel = nomeAmigavel.Replace("...", String.Empty);
            nomeAmigavel = nomeAmigavel.Replace(")", String.Empty);

            string[] listaNomesCategorias = nomeAmigavel.Split(' ');

            List<string> listaNomesCategoriasModificadas = new List<string>();
            for (int i = 0; i < listaNomesCategorias.Length; i++)
            {
                if (listaNomesCategorias[i].Length > 1) listaNomesCategoriasModificadas.Add(listaNomesCategorias[i]);
            }

            nomeAmigavel = String.Join("-", listaNomesCategoriasModificadas.ToArray());
            nomeAmigavel = nomeAmigavel.ToLower();
            nomeAmigavel = UtilString.RemoverAcentos(nomeAmigavel);

            return nomeAmigavel;
        }
    }
}
