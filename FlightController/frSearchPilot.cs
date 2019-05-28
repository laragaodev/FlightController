using Library.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightController
{
    public partial class frSearchPilot : frSearchPadrao
    {
        public frSearchPilot()
        {
            InitializeComponent();
        }

        protected override PadraoVO PreencheObj()
        {
            PilotVO p = new PilotVO();
            p.Id = (int)nudId.Value;
            p.Name = txtNome.Text;
            p.License_Id = int.Parse(txtLicenseId.Text);
            return p;
        }
    }
}
