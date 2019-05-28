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
    public partial class frRegFlight : frPadrao
    {
        public frRegFlight()
        {
            cadastroDAO = new FlightDAO();
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
                txtArrive.Text = (o as FlightVO).Arrive.ToString("dd/MM/yyyy HH:mm:ss");
                txtIdArrive.Text = (o as FlightVO).Arrive_Id.ToString();
                txtCoPilotId.Text = (o as FlightVO).Co_Pilot_Id.ToString();
                txtDepart.Text = (o as FlightVO).Depart.ToString("dd/MM/yyyy HH:mm:ss");
                txtDuration.Text = (o as FlightVO).Duration.ToString();
                txtIdAircraft.Text = (o as FlightVO).Aircraft_Id.ToString();
                txtIdArrive.Text = (o as FlightVO).Arrive_Id.ToString();
                txtIdDepart.Text = (o as FlightVO).Depart_Id.ToString();
                txtPilotId.Text = (o as FlightVO).Pilot_Id.ToString();
            }
        }


        protected override void ControlaCamposTela(EnumModoOperacao modo)
        {
            txtArrive.Enabled = 
            txtIdArrive.Enabled = 
            txtCoPilotId.Enabled = 
            txtDepart.Enabled = 
            txtDuration.Enabled = 
            txtIdAircraft.Enabled = 
            txtIdArrive.Enabled = 
            txtIdDepart.Enabled = 
            txtPilotId.Enabled = modo != EnumModoOperacao.Navegacao;
        }


        protected override PadraoVO PreencheObj()
        {
            FlightVO f = new FlightVO();
            f.Id = Convert.ToInt32(txtId.Text);
            f.Aircraft_Id = Convert.ToInt32(txtIdAircraft.Text);
            f.Arrive = Convert.ToDateTime(txtArrive.Text);
            f.Arrive_Id = Convert.ToInt32(txtIdArrive.Text);
            f.Co_Pilot_Id = Convert.ToInt32(txtCoPilotId.Text);
            f.Pilot_Id = Convert.ToInt32(txtPilotId.Text);
            f.Depart = Convert.ToDateTime(txtDepart.Text);
            f.Depart_Id = Convert.ToInt32(txtIdDepart.Text);
            f.Duration = Convert.ToInt32(txtDuration.Text);
            f.In_Route = rbInRoute.Checked;           
            return f;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            frRegFlight form = new frRegFlight();
            form.ShowDialog();
        }
    }
}
