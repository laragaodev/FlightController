using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.DAO;
using Library.VO;
using Library.Enums;

namespace FlightController
{
    public partial class frRegAircraft : frPadrao
    {
        public frRegAircraft()
        {
            cadastroDAO = new AircraftDAO();
            SugereProximoId = true;
            InitializeComponent();
        }

        protected override void PreencheTela(PadraoVO o)
        {
            if (o == null)
                LimpaCampos(this);
            else
            {
                txtId.Text = o.Id.ToString();
                txtModelo.Text = (o as AircraftVO).Model_Id.ToString();
                txtTipo.Text = (o as AircraftVO).type_Id.ToString();
            }
        }


        protected override void ControlaCamposTela(EnumModoOperacao modo)
        {
            txtTipo.Enabled = txtModelo.Enabled = modo != EnumModoOperacao.Navegacao;
        }


        protected override PadraoVO PreencheObj()
        {
            AircraftVO a = new AircraftVO();
            a.Id = Convert.ToInt32(txtId.Text);
            a.Model_Id = Convert.ToInt32(txtModelo.Text);
            a.type_Id = Convert.ToInt32(txtTipo.Text);
            return a;
        }
    }
}
