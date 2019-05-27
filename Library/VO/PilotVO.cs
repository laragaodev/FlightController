using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.VO
{
    public class PilotVO : PadraoVO
    {        
        private string name;
        private int license_id;
        private char gender;
        private DateTime birth_date;
        public string image_path { get; set; }
        

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 0 && value.IndexOf(' ') != -1)
                    name = value;
                else
                    throw new Exception("Nome inválido ou incompleto");
            }
        }

        public int License_Id
        {
            get { return license_id; }
            set
            {
                if (value > 0)
                    license_id = value;
                else
                    throw new Exception("Licença inválida");
            }

        }

        public char Gender
        {
            get { return gender; }
            set
            {
                if (value != 'M' && value != 'F')
                    throw new Exception("Sexo inválido");
                else
                    gender = value;
            }
        }

        public DateTime BirthDate
        {
            get { return birth_date; }
            set
            {
                if (value > DateTime.Now)
                    throw new Exception("Data inválida");
                else
                    birth_date = value;
            }
        }
    }
}
