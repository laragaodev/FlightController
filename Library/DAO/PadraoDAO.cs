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
        protected string ProcInsert { get; set; }
        protected string ProcUpdate { get; set; }
        protected string ProcProximoId { get; set; }
        protected string ProcDelete { get; set; }
        protected string ProcConsulta { get; set; }
        protected string ProcPrimeiro { get; set; }
        protected string ProcUltimo { get; set; }
        protected string ProcAnterior { get; set; }
        protected string ProcProximo { get; set; }


        protected abstract SqlParameter[] CriaParametros(PadraoVO o);

        protected abstract PadraoVO MontaVO(DataRow dr);

        

        public virtual void Inserir(PadraoVO o)
        {
            if (Consulta(o.Id) != null)
                throw new Exception("Este código já está sendo utilizado!");

            string sql = ProcInsert;
            MetodosBD.ExecutaProcedure(sql, CriaParametros(o));
        }

        public virtual void Alterar(PadraoVO o)
        {
            string sql = ProcUpdate;
            MetodosBD.ExecutaProcedure(sql, CriaParametros(o));
        }

        public virtual void Excluir(int Id)
        {
            string sql = ProcDelete;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", Id);
            MetodosBD.ExecutaProcedure(sql, parametros);
        }

        public PadraoVO Consulta(int id)
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                string sql = ProcConsulta;
                SqlParameter[] parametros =
                {
                    new SqlParameter("@id", id)
                };

                return ExecutaSqlLocal(sql, parametros);

            }
        }

        public virtual int ProximoId()
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand(ProcProximoId, cx))
                {
                    object valor = cmd.ExecuteScalar();
                    return Convert.ToInt32(valor) + 1;
                }
            }
        }

        protected PadraoVO ExecutaSqlLocal(string sql, SqlParameter[] parametros)
        {
            DataTable tabela = MetodosBD.ExecutaSelectProc(sql, parametros);

            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaVO(tabela.Rows[0]);
        }


        public virtual PadraoVO Primeiro()
        {
            return ExecutaSqlLocal(ProcPrimeiro, null);
        }

        public virtual PadraoVO Ultimo()
        {
            return ExecutaSqlLocal(ProcUltimo, null);
        }

        public virtual PadraoVO Anterior(int atual)
        {
            SqlParameter[] p =
            {
                new SqlParameter("current", atual)
            };
            return ExecutaSqlLocal(ProcAnterior, p);
        }

        public virtual PadraoVO Proximo(int atual)
        {
            SqlParameter[] p =
            {
                new SqlParameter("current", atual)
            };
            return ExecutaSqlLocal(ProcProximo, p);
        }            

    }
}

