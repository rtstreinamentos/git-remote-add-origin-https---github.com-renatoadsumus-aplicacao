using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace OrcamentoNet.LocalServiceTest.BaseDados
{
    public class BaseDados
    {
        private string connString;
        private string caminhoProjeto;
        private SqlConnection credencialConexao;
        private Server servidorBancoDados;

        public BaseDados()
        {
            caminhoProjeto = ConfigurationSettings.AppSettings["caminhoProjeto"];
            connString = ConfigurationManager.ConnectionStrings["ConexaoBancoDados"].ConnectionString;
            //credencialConexao = new SqlConnection(connString);
            //servidorBancoDados = new Server(new ServerConnection(credencialConexao));
        }

        /// <summary>
        /// Cria a base de dados com as tabelas que estão dentro de um script SQL
        /// </summary>
        public void CriarBaseDados()
        {
            FileInfo arquivoScriptCriacaoBase = new FileInfo(caminhoProjeto + "CreateTables.sql");

            string srciptCriacaoBase = arquivoScriptCriacaoBase.OpenText().ReadToEnd();

            servidorBancoDados.ConnectionContext.ExecuteNonQuery(srciptCriacaoBase);
        }

        /// <summary>
        /// Exclui as tabelas da base de dados
        /// </summary>
        public void ExcluirBaseDados()
        {
            FileInfo arquivoScriptCriacaoBase = new FileInfo(caminhoProjeto + "DeleteTables.sql");

            string srciptCriacaoBase = arquivoScriptCriacaoBase.OpenText().ReadToEnd();

            servidorBancoDados.ConnectionContext.ExecuteNonQuery(srciptCriacaoBase);
        }

        public void ExcluirDados()
        {
            MySqlConnection conexao = new MySqlConnection(connString);
            conexao.Open();

            MySqlCommand comandoExcluir = new MySqlCommand("CALL Sp_Excluir_Dados_Banco();", conexao);
            comandoExcluir.ExecuteNonQuery();

            conexao.Close();
        }

        [Test]
        public void PrepararBase()
        {
            //NDbUnit.Core.INDbUnitTest mySqlDatabase = new NDbUnit.Core.SqlClient.SqlDbUnitTest(connString);
            //mySqlDatabase.ReadXmlSchema(@"..\..\BaseDados\Model.xsd");
            //mySqlDatabase.ReadXml(@"..\..\BaseDados\Regiao.xml");
            
            //mySqlDatabase.PerformDbOperation(NDbUnit.Core.DbOperationFlag.CleanInsertIdentity);

        }
    }
}
