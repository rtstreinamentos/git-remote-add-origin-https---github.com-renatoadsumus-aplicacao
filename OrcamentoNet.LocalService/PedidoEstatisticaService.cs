using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Entity;
using PortalEscolar.Data;
using MySql.Data.MySqlClient;
using OrcamentoNet.Common;
using OrcamentoNet.Entity.Enum;
using System.Data;

namespace OrcamentoNet.LocalService
{
    public class PedidoEstatisticaService : IPedidoEstatisticaService
    {
        private IDataContext context;

        public PedidoEstatisticaService(IDataContext contextData)
        {
            context = contextData;
        }

        public void Inserir(PedidoEstatistica pedidoEstatistica)
        {
            context.Insert(pedidoEstatistica);
        }

        public IList<PedidoEstatistica> ObterEstatisticaPorCategoriaCidadeMes(int idcategoria, int idMes, int ano)
        {
            return context.Repository<PedidoEstatistica>().Where(x => x.Categoria.Id == idcategoria && x.Mes == idMes).OrderByDescending(x => x.QuantidadePedidos).ToList();
        }

        public void GerarEstatistica()
        {
            MySqlConnection conexao = null;
            MySqlCommand comando = null;
            conexao = new MySqlConnection(Config.ConexaoBanco);
            conexao.Open();

            DataSet dsFornecedor;

            IList<Cidade> cidades = context.Repository<Cidade>().Where(x => x.Uf == UF.RJ).ToList();

            Categoria categoria = context.Repository<Categoria>().Where(x => x.Id == 18).FirstOrDefault();


            foreach (Cidade cidadeItem in cidades)
            {
                foreach (Categoria categoriaItem in categoria.SubCategorias)
                {
                    string sqlQuantidadeFornecedor = "(SELECT count(p.Cd_Pessoa) as QtdFornecedor " +
                        " FROM Pessoa p inner join Fornecedor_Categoria fc on" +
                        " p.Cd_Pessoa = fc.Cd_Pessoa inner join Fornecedor_Cidade fcidade on " +
                        " p.Cd_Pessoa = fcidade.Cd_Pessoa " +
                        " where fc.Cd_Categoria = " + categoriaItem.Id.ToString() +
                        " and fcidade.Cd_Cidade = " + cidadeItem.Id.ToString() +
                        " and p.Cd_Status=3)";


                    comando = new MySqlCommand(sqlQuantidadeFornecedor, conexao);
                    dsFornecedor = new DataSet();

                    MySqlDataAdapter adp = new MySqlDataAdapter(comando);
                    adp.Fill(dsFornecedor, "Fornecedor");
                    comando.ExecuteNonQuery();

                    int quantidadeFornecedor = 0;

                    if (dsFornecedor.Tables[0].Rows.Count > 0)
                    {
                        quantidadeFornecedor = int.Parse(dsFornecedor.Tables[0].Rows[0]["QtdFornecedor"].ToString());
                    }

                    int mesAnterior = DateTime.Now.Month - 1;
                    int anoCorrente = DateTime.Now.Year;

                    string sql = " insert into Pedido_Orcamento_Estatistica(Cd_Categoria,Cd_Cidade,Quantidade_Pedido,Quantidade_Fornecedor,Cd_Mes, Ano)" +
                                " SELECT " + categoriaItem.Id.ToString() + "," +
                                cidadeItem.Id.ToString() + " ," +
                                " count(poc.Cd_Categoria) as QtdPedido," +
                                 quantidadeFornecedor.ToString() +
                                "," + mesAnterior + " as Mes " +
                                "," + anoCorrente + " as Ano " +
                                "FROM Pedido_Orcamento po inner join Pedido_Orcamento_Categoria poc on " +
                                " po.Cd_Pedido_Orcamento = poc.Cd_Pedido_Orcamento " +
                                " where po.Cd_Cidade = " + cidadeItem.Id.ToString() +
                                " and poc.Cd_Categoria = " + categoriaItem.Id.ToString() +
                                " and po.Dt_Cadastro >= '2014-04-01 00:00:00'" +
                                " and po.Dt_Cadastro <= '2014-04-30 00:00:00'";

                    comando = new MySqlCommand(sql, conexao);
                    comando.ExecuteNonQuery();
                }

            }
            conexao.Close();

        }
    }
}
