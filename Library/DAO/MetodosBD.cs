using Library.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.DAO
{
    public class MetodosBD
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



        public static void ExecutaProcedure(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }



        public static DataTable ExecutaSelectProc(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, cx))
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



        public static bool Mensagem(string mensagem, TipoMensagemEnum tipoDaMensagem)
        {
            if (tipoDaMensagem == TipoMensagemEnum.alerta)
            {
                MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return true;
            }
            else if (tipoDaMensagem == TipoMensagemEnum.erro)
            {
                MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return true;
            }
            else if (tipoDaMensagem == TipoMensagemEnum.informacao)
            {
                MessageBox.Show(mensagem, "Informação", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return true;
            }
            else
            {
                if (MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
        }

        public static bool ValidaInt(string valor)
        {
            try
            {
                Convert.ToInt32(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }



    }
}
