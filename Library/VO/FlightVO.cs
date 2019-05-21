using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.VO
{
    public class FlightVO : PadraoVO
    {
        private int aircraft_id, depart_from_id, arrive_at_id, duration, pilot_id, co_pilot_id;
        private bool in_route;
        private DateTime depart, arrive;
        

        public int Aircraft_Id
        {
            get { return aircraft_id; }
            set
            {
                if (value > 0)
                    aircraft_id = value;
                else
                    throw new Exception("Id inválido");
            }
        }

        public int Depart_Id
        {
            get { return depart_from_id; }
            set
            {
                if (value > 0)
                    depart_from_id = value;
                else
                    throw new Exception("Id inválido");
            }
        }

        public int Arrive_Id
        {
            get { return arrive_at_id; }
            set
            {
                if (value > 0)
                    arrive_at_id = value;
                else
                    throw new Exception("Id inválido");
            }
        }

        public int Duration
        {
            get { return duration; }
            set
            {
                if (value > 0)
                    duration = value;
                else
                    throw new Exception("Id inválido");
            }
        }

        public int Pilot_Id
        {
            get { return pilot_id; }
            set
            {
                if (value > 0)
                    pilot_id = value;
                else
                    throw new Exception("Id inválido");
            }
        }

        public int Co_Pilot_Id
        {
            get { return co_pilot_id; }
            set
            {
                if (value > 0)
                    co_pilot_id = value;
                else
                    throw new Exception("Id inválido");
            }
        }


        public DateTime Depart
        {
            get { return depart; }
            set
            {
                if (value > arrive)
                    throw new Exception("Data inválida");
                else
                    depart = value;
            }
        }

        public DateTime Arrive
        {
            get { return arrive; }
            set
            {
                if (value < depart)
                    throw new Exception("Data inválida");
                else
                    arrive = value;
            }
        }

        public bool In_Route
        {
            get { return in_route; }
            set { in_route = value; }
        }






    }
}
