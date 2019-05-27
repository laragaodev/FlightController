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
    public class AircraftDAO : PadraoDAO
    {
        public AircraftDAO()
        {
            ProcInsert = "spIncluiOuAteratbFornecedor";
            ProcUpdate = "spIncluiOuAteratbFornecedor";
            ProcProximoId = "spProximoIdFornecedor";
            ProcDelete = "spApagaFornecedor";
            ProcConsulta = "spConsultaFornecedor";
            ProcPrimeiro = "spNavegaPrimeiroFornedor";
            ProcUltimo = "spNavegaUltimofornecedor";
            ProcAnterior = "spNavegaFornecedorAnterior";
            ProcProximo = "spNavegaProximoFornecedor";
        }

        protected override SqlParameter[] CriaParametros(PadraoVO o)
        {
            AircraftVO a = o as AircraftVO;
            SqlParameter[] parametros =
            {
                new SqlParameter("id", a.Id),
                new SqlParameter("model_id", a.Model_Id),
                new SqlParameter("type_id", a.type_Id)
            };
            return parametros;
        }

        protected override PadraoVO MontaVO(DataRow dr)
        {
            AircraftVO a = new AircraftVO();
            a.Id = Convert.ToInt32(dr["id"]);
            a.Model_Id = Convert.ToInt32(dr["model_id"]);
            a.type_Id = Convert.ToInt32(dr["type_id"]);
            return a;
        }
    }
}
