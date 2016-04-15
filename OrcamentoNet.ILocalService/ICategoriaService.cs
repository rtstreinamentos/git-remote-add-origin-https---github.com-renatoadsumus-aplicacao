using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using System.Xml.Linq;

namespace OrcamentoNet.ILocalService
{
    public interface ICategoriaService
    {
		        Categoria Obter(int id, bool montarLinkInterno);
		IList<Categoria> ObterCategoriasAtivas();
        IList<Categoria> ObterSubCategoriasDeUmaCategoria(IList<string> categorias);
        IList<Categoria> ObterSubCategorias();
		IList<Categoria> ObterSubCategoriasAtivas();
		IList<Categoria> ObterTemasAtivos();
        IEnumerable<XElement> ObterXMLCategoria(int idCategoria);
        IList<Categoria> ObterCategoriasComFornecedoresCadastrados();
        void Inserir(Categoria categoria);

        IList<Categoria> ObterSubCategoriasComFornecedorPorCidade(Cidade cidade, int categoriaPai);

        IList<Categoria> ObterCategoriasDeUmTema(int idCategoriaPai);

        string MontarHTMLDeTermo(IList<string> categorias, IList<Termo> termos);
        IList<Termo> ObterTermos(int idCategoria);
        IList<Termo> ObterTermosFornecedor(int idCategoria);
        string ObterFaixaCategoria(int idCategoria);
        IList<int> ObterIdsCategoriasPai(int idCategoria);
    }
}
