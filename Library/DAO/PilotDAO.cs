using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.VO;

namespace Library.DAO
{
    public class PilotDAO : PadraoDAO
    {
        public PilotDAO()
        {
            Tabela = "pilots";
        }
        protected override SqlParameter[] CriaParametros(PadraoVO o)
        {
            PilotVO p = o as PilotVO;
            SqlParameter[] parametros =
            {
                new SqlParameter("id", p.Id),
                new SqlParameter("name", p.Name),
                new SqlParameter("license_id", p.License_Id),
                new SqlParameter("gender", p.Gender),
                new SqlParameter("birth_date", p.BirthDate)
            };
            return parametros;
        }

        protected override PadraoVO MontaVO(DataRow dr)
        {
            PilotVO p = new PilotVO();
            p.Id = Convert.ToInt32(dr["id"]);
            p.Name = dr["name"].ToString();
            p.License_Id = Convert.ToInt32(dr["license_id"]);
            p.Gender = Convert.ToChar(dr["gender"]);
            p.BirthDate = Convert.ToDateTime(dr["birth_date"]);
            return p;
        }
    }
}
