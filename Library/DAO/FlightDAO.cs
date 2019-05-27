using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.VO;

namespace Library.DAO
{
    public class FlightDAO : PadraoDAO
    {
        public FlightDAO()
        {
            ProcInsert = "sp_create_flight";
            ProcUpdate = "sp_update_flight";
            ProcProximoId = "sp_next_flight_id";
            ProcDelete = "sp_delete_flights_by_id";
            ProcConsulta = "sp_search_flight";
            ProcPrimeiro = "sp_first_flight";
            ProcUltimo = "sp_last_flight";
            ProcAnterior = "sp_previous_flight_id";
            ProcProximo = "sp_next_flight_id";
        }

        protected override SqlParameter[] CriaParametros(PadraoVO o)
        {
            FlightVO f = o as FlightVO;
            SqlParameter[] parametros =
            {
                new SqlParameter("id", f.Id),
                new SqlParameter("aircraft_id", f.Aircraft_Id),
                new SqlParameter("arrive_date", f.Arrive.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("arrive_at_id", f.Arrive_Id),
                new SqlParameter("depart_date", f.Depart.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("depart_from_id", f.Depart_Id),
                new SqlParameter("co_pilot_id", f.Co_Pilot_Id),
                new SqlParameter("duration", f.Duration),
                new SqlParameter("in_route", f.In_Route),
                new SqlParameter("pilot_id", f.Pilot_Id)
            };
            return parametros;
        }

        protected override PadraoVO MontaVO(DataRow dr)
        {
            FlightVO f = new FlightVO()
            {
                Id = Convert.ToInt32(dr["id"]),
                Aircraft_Id = Convert.ToInt32(dr["aircraft_id"]),
                Arrive = Convert.ToDateTime(dr["arrive_date"], CultureInfo.InvariantCulture),
                Depart = Convert.ToDateTime(dr["depart_date"], CultureInfo.InvariantCulture),
                Depart_Id = Convert.ToInt32(dr["depart_from_id"]),
                Arrive_Id = Convert.ToInt32(dr["arrive_at_id"]),
                Duration = Convert.ToInt32(dr["duration"]),
                In_Route = Convert.ToBoolean(dr["in_route"]),
                Pilot_Id = Convert.ToInt32(dr["pilot_id"]),
                Co_Pilot_Id = Convert.ToInt32(dr["co_pilot_id"])
            };
            return f;
        }
    }
}
