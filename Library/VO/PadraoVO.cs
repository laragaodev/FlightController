using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.VO
{
    public abstract class PadraoVO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                if (value > 0)
                    id = value;
                else
                    throw new Exception("Id inválido");
            }
        }
    }
}
