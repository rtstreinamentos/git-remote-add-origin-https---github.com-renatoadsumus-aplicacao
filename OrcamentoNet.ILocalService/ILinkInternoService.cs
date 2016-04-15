using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity._enum;
using OrcamentoNet.Entity.Enum;

namespace OrcamentoNet.ILocalService
{
    public interface ILinkInternoService
    {
        IList<LinkInterno> MontarLinksInternosDeEstado(Categoria categoria, string termo, Persona persona);
        IList<LinkInterno> MontarLinksInternosBairro(Cidade cidade, Categoria categoria, Persona persona);
        IList<LinkInterno> MontarLinksInternosCidades(Categoria categoria, UF uf,Persona persona);
        IList<LinkInterno> MontarLinksInternosMesAno(Categoria categoria, int idCidade, string termo);
        IList<LinkInterno> MontarLinksInternosTermo(Categoria categoria, int idEstado, Persona persona, int idBairro);
        IList<LinkInterno> MontarLinksInternosTermoTipoServico(Orcamento orcamento, int idEstado, int idBairro);
        IList<LinkInterno> MontarLinksInternosTermoFornecedor(Categoria categoria);
        IList<LinkInterno> MontarLinksInternosDeEstadoTipoServico(Orcamento orcamento);
        IList<LinkInterno> MontarLinksInternosTipoServico(IList<Orcamento> orcamentos);
        IList<LinkInterno> MontarLinksInternosBairroTipoServico(Orcamento orcamento, Cidade cidade);
        IList<LinkInterno> MontarLinksInternosCidadeTipoServico(Orcamento orcamento, UF uf);
        IList<LinkInterno> MontarLinksInternosCidadesCategoria(IList<Cidade> cidades, Categoria categoria);
        IList<LinkInterno> MontarLinksInternosTermosDaCategoria(Categoria categoria, int idEstado, Bairro bairro, Cidade cidade);
        IList<LinkInterno> MontarLinksInternosTipoServicoPorCategoria(Categoria categoria, Orcamento orcamento);
        IList<LinkInterno> MontarLinksInternosDeEstado(Categoria categoria, string urlConcatencao);
        IList<LinkInterno> MontarLinksInternosMesAnoPreco(Categoria categoria, int idCidade, string termo);
    }
}
