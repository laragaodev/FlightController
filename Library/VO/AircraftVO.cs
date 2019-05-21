using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.VO
{
    public class AircraftVO : PadraoVO
    {        
        private int model_id;
        private int type_id;        

        public int Model_Id
        {
            get { return model_id; }
            set
            {
                if (value > 0)
                    model_id = value;
                else
                    throw new Exception("Id inválido");
            }
        }

        public int type_Id
        {
            get { return type_id; }
            set
            {
                if (value > 0)
                    type_id = value;
                else
                    throw new Exception("Id inválido");
            }
        }
    }
}
