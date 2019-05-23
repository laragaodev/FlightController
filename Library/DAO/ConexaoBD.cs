using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO
{
    class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            string strCon;
            if (!File.Exists("credenciais-db.txt"))
                strCon = @"Server=DESKTOP-6KD8JJ5\SQLEXPRESS;Integrated security=SSPI;database=master";
            else
            {
                string[] parameters = File.ReadAllLines("credenciais-db.txt");
                if (string.IsNullOrEmpty(parameters[1]) && string.IsNullOrEmpty(parameters[2]))
                    strCon = $@"Data Source={parameters[0]};Initial Catalog=aircraft_system_control;Integrated Security=True";
                else
                    strCon = $"Data Source={parameters[0]};Initial Catalog=air_system_control;user id={parameters[1]}; password={parameters[2]}";
            }
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }

        public static SqlConnection GetCreationConnection()
        {
            string strCon = @"Data Source=DESKTOP-6KD8JJ5\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
