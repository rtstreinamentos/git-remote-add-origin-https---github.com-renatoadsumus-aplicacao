using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Common;
using OrcamentoNet.Entity;
using OrcamentoNet.Entity.Enum;
using OrcamentoNet.ILocalService;
using PortalEscolar.Data;

namespace OrcamentoNet.LocalService
{
    public class CidadeService : ICidadeService
    {
        private IDataContext context;

        public CidadeService(IDataContext contextData)
        {
            context = contextData;
        }

        public Cidade Obter(int id)
        {
            return context.Repository<Cidade>().Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<Cidade> ObterCidades(UF uf)
        {
            return context.Repository<Cidade>().Where(x => x.Uf == uf).OrderBy(y => y.Nome).ToList();
        }

        public IList<Cidade> ObterCidadesComFornecedores(UF uf, Categoria categoria)
        {
            IList<Fornecedor> fornecedoresDaCategoria = context.Repository<Fornecedor>().Where(x => x.SubCategorias.Contains(categoria) && x.Status != Status.Inativo).ToList();

            IList<Cidade> cidadesComFornecedor = new List<Cidade>();

            foreach (Fornecedor fornecedor in fornecedoresDaCategoria)
            {
                foreach (Cidade cidade in fornecedor.Cidades)
                {
                    if (cidade.Uf == uf && !cidadesComFornecedor.Contains(cidade))
                    {
                        cidadesComFornecedor.Add(cidade);
                    }
                }
            }

            return cidadesComFornecedor.OrderBy(x => x.Nome).ToList();
        }

        public IList<string> ObterEstadosComFornecedorPorCategoria(Categoria categoria)
        {
            List<string> estadosComFornecedores = new List<string>();
            estadosComFornecedores.Add("Selecione");

            //Verifica se a Categoria é um Tema
            if (categoria.Pai.Id == 0)
            {
                estadosComFornecedores.AddRange(ObterEstadoComFornecedorPorTema(categoria));
            }
            else
            {
                estadosComFornecedores.AddRange(ObterEstadosComFornecerPorCategoria(categoria));
            }
            return estadosComFornecedores;
        }

        private IList<string> ObterEstadosComFornecerPorCategoria(Categoria categoria)
        {
            IList<string> estadosComFornecedores = new List<string>();

            foreach (string estado in Enum.GetNames(typeof(OrcamentoNet.Entity.Enum.UF)))
            {
                UF uf = (UF)Enum.Parse(typeof(UF), estado);

                IList<Fornecedor> fornecedoresCidade = context.Repository<Fornecedor>().Where(x => x.SubCategorias.Contains(categoria) && x.Status != Status.Inativo).ToList();

                foreach (Fornecedor fornecedor in fornecedoresCidade)
                {
                    foreach (Cidade cidade in fornecedor.Cidades)
                    {
                        if (cidade.Uf == uf && !estadosComFornecedores.Contains(estado))
                        {
                            estadosComFornecedores.Add(estado);
                        }
                    }
                }
            }

            return estadosComFornecedores;
        }

        private IList<string> ObterEstadoComFornecedorPorTema(Categoria categoria)
        {
            IList<string> estadosComFornecedores = new List<string>();

            foreach (string estado in Enum.GetNames(typeof(OrcamentoNet.Entity.Enum.UF)))
            {
                UF uf = (UF)Enum.Parse(typeof(UF), estado);

                IList<Fornecedor> fornecedoresAtivos = context.Repository<Fornecedor>().Where(x => x.Status != Status.Inativo).ToList();

                IList<Fornecedor> fornecedoresDoEstado = new List<Fornecedor>();

                foreach (Fornecedor fornecedor in fornecedoresAtivos)
                {
                    foreach (Cidade cidade in fornecedor.Cidades)
                    {
                        if (cidade.Uf == uf && !fornecedoresDoEstado.Contains(fornecedor))
                        {
                            fornecedoresDoEstado.Add(fornecedor);
                        }
                    }

                }

                foreach (Fornecedor fornecedor in fornecedoresDoEstado)
                {
                    foreach (Categoria categoriaItem in fornecedor.SubCategorias)
                    {

                        if (categoriaItem.Pai.Id == categoria.Id && !estadosComFornecedores.Contains(estado))
                        {
                            estadosComFornecedores.Add(estado);
                        }
                    }
                }
            }
            return estadosComFornecedores;
        }

        public IList<Cidade> ObterCidades()
        {
            return context.Repository<Cidade>().OrderBy(y => y.Nome).ToList();
        }
    }
}
