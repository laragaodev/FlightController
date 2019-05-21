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
    public class FlightDAO : PadraoDAO
    {
        protected override SqlParameter[] CriaParametros(PadraoVO o)
        {
            throw new NotImplementedException();
        }

        protected override PadraoVO MontaVO(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
