using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO
{
    class MetodosBD
    {
        public static void ExecutaSQL(string sql, SqlParameter[] parametros = null)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                    conexao.Close();
                }
            }
        }
        public static DataTable ExecutaSelect(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, cx))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    return tabela;
                }
            }
        }

        public static DataTable ExecutaProcResultSet(string procedure, SqlParameter[] parametros)
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(procedure, cx))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);

                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    return tabela;
                }
            }
        }



        public static void ExecutaProcedure(string procedure, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(procedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
            }
        }



        public static string ExecutaProcedureComRetorno(string procedure, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(procedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);

                    comando.Parameters.Add("retorno", SqlDbType.VarChar);
                    comando.Parameters["retorno"].Direction = ParameterDirection.ReturnValue;
                    comando.ExecuteNonQuery();
                    return comando.Parameters["retorno"].Value.ToString();
                }
            }
        }

        public static void CriaBanco()
        {
            string script = File.ReadAllText("create-database.sql");
            using (SqlConnection cx = ConexaoBD.GetCreationConnection())
            {
                using (SqlCommand comando = new SqlCommand(script, cx))
                {
                    comando.ExecuteNonQuery();
                    cx.Close();
                }
            }
        }



    }
}
