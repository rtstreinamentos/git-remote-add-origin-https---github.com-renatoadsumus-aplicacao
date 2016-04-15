using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;

namespace OrcamentoNet.ILocalService
{
    public interface ISiteMapService
    {
		void Gravar(IList<Categoria> listaCategorias);
		string Obter(IList<Categoria> listaCategorias);
		string ObterFim();
		string ObterGuiaTemas(IList<Categoria> listaCategorias);
		string ObterHomeCadastroFornecedor();
		string ObterHomeGuia();
        string ObterHomeMapa();
		string ObterHomePedidoOrcamento();
		string ObterHomeSite();
		string ObterInicio();
        string ObterLinksInternosTemas();
		string ObterUrlsCategoria();
    }
}
