using Library.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO
{
    public abstract class PadraoDAO
    {
        protected string Tabela { get; set; }
        protected string Chave { get; set; } = "id"; // valor default
        protected abstract SqlParameter[] CriaParametros(PadraoVO o);
        protected abstract PadraoVO MontaVO(DataRow dr);


        protected virtual string MontaSQLDelete()
        {
            return $"delete {Tabela} where {Chave} = @id";
        }
        protected virtual string MontaSQLConsulta()
        {
            return $"select * from {Tabela} where {Chave} = @id";
        }
        
        //public virtual void Inserir(PadraoVO o)
        //{
        //    if (Consulta(o.Id) != null)
        //        throw new Exception("Este código já está sendo utilizado!");
        //    string sql = MontaSQLInsert();
        //    MetodosBD.ExecutaSQL(sql, CriaParametros(o));
        //}
       
        //public virtual void Alterar(PadraoVO o)
        //{
        //    string sql = MontaSQLUpdate();
        //    MetodosBD.ExecutaSQL(sql, CriaParametros(o));
        //}


        //public virtual void Excluir(int Id)
        //{
        //    string sql = MontaSQLDelete();
        //    SqlParameter[] parametros = new SqlParameter[1];
        //    parametros[0] = new SqlParameter(Chave, Id);
        //    MetodosBD.ExecutaSQL(sql, parametros);
        //}       
        
       
        //public virtual int ProximoId()
        //{
        //    string sql = $"select isnull(max({Chave})+1,1) from {Tabela}";
        //    using (SqlConnection cx = ConexaoBD.GetConexao())
        //    {
        //        SqlCommand cmd = new SqlCommand(sql, cx);
        //        return Convert.ToInt32(cmd.ExecuteScalar());
        //    }
        //}
        
        //public virtual PadraoVO Primeiro()
        //{
        //    string sql = $"select top 1 * from {Tabela} order by {Chave}";
        //    return ExecutaSqlLocal(sql, null);
        //}


        //public virtual PadraoVO Ultimo()
        //{
        //    string sql = $"select top 1 * from {Tabela} order by {Chave} desc";
        //    DataTable tabela = MetodosBD.ExecutaSelect(sql, null);
        //    return ExecutaSqlLocal(sql, null);
        //}
        
        //public virtual PadraoVO Proximo(int atual)
        //{
        //    string sql = $"select top 1 * from {Tabela} where {Chave} > @Atual order by {Chave} ";
        //    SqlParameter[] p =
        //    {
        //        new SqlParameter("Atual", atual)
        //    };
        //    return ExecutaSqlLocal(sql, p);
        //}
        
        //public virtual PadraoVO Anterior(int atual)
        //{
        //    string sql = $"select top 1 * from {Tabela} where {Chave} < @Atual order by {Chave} desc";
        //    SqlParameter[] p =
        //    {
        //        new SqlParameter("Atual", atual)
        //    };
        //    return ExecutaSqlLocal(sql, p);
        //}
       
        //protected PadraoVO ExecutaSqlLocal(string sql, SqlParameter[] parametros)
        //{
        //    DataTable tabela = MetodosBD.ExecutaSelect(sql, parametros);
        //    if (tabela.Rows.Count == 0)
        //        return null;
        //    else
        //        return MontaVO(tabela.Rows[0]);
        //}

        public PadraoVO Consulta(int id, string procName)
        {
            SqlParameter[] parametros = { new SqlParameter("id", id) };
            DataTable tabela = MetodosBD.ExecutaProcResultSet(procName, parametros);
            return ObjetoOuNull(tabela);
        }

        public void Incluir(PadraoVO p, string procName)
        {
            MetodosBD.ExecutaProcedure(procName, CriaParametros(p));
        }

        public void Alterar(PadraoVO p, string procName)
        {
            MetodosBD.ExecutaProcedure(procName, CriaParametros(p));
        }

        public void Excluir(int id, string procName)
        {
            SqlParameter[] parametro = { new SqlParameter("id", id) };
            MetodosBD.ExecutaProcedure(procName, parametro);
        }  


        public PadraoVO Primeiro(string procName)
        {
            DataTable tabela = MetodosBD.ExecutaProcResultSet(procName, null);
            return ObjetoOuNull(tabela);
        }

        public PadraoVO Ultimo(string procName)
        {
            DataTable tabela = MetodosBD.ExecutaProcResultSet(procName, null);
            return ObjetoOuNull(tabela);
        }


        public PadraoVO Anterior(int atual, string procName)
        {
            SqlParameter[] parametros = { new SqlParameter("@idAtual", atual) };
            DataTable tabela = MetodosBD.ExecutaProcResultSet(procName, parametros);
            return ObjetoOuNull(tabela);
        }

        public PadraoVO Proximo(int atual, string procName)
        {
            SqlParameter[] parametros = { new SqlParameter("@idAtual", atual) };
            DataTable tabela = MetodosBD.ExecutaProcResultSet(procName, parametros);
            return ObjetoOuNull(tabela);
        }


        private PadraoVO ObjetoOuNull(DataTable tabela)
        {
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaVO(tabela.Rows[0]);
        }


        public static int ProximoId(string procName)
        {
            string resposta = MetodosBD.ExecutaProcedureComRetorno(procName, null);
            return Convert.ToInt32(resposta);
        }


        /*public static DataTable Consulta()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("descricao", descricao.Trim()));

            if (data.Replace("/", "").Trim().Length > 0)
                parametros.Add(new SqlParameter("@data", data));
            else
                parametros.Add(new SqlParameter("@data", DBNull.Value));

            if (preco.Trim().Length > 0)
                parametros.Add(new SqlParameter("@preco", Convert.ToDouble(preco)));
            else
                parametros.Add(new SqlParameter("@preco", DBNull.Value));

            if (jogoId.Trim().Length > 0)
                parametros.Add(new SqlParameter("@id", Convert.ToInt32(jogoId)));
            else
                parametros.Add(new SqlParameter("@id", DBNull.Value));

            if (categoria > 0)
                parametros.Add(new SqlParameter("@categoria", categoria));
            else
                parametros.Add(new SqlParameter("@categoria", DBNull.Value));

            return Metodos.ExecutaProcResultSet("spConsultaAvancada", parametros.ToArray());
        }*/

    }
}

