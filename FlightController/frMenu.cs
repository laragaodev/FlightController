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
    public partial class frMenu : Form
    {
        public frMenu()
        {
            InitializeComponent();
        }

        private void btnRegAircraft_Click(object sender, EventArgs e)
        {
            frRegAircraft a = new frRegAircraft();
            a.Show();
            this.Hide();
        }

        private void btnRegFlight_Click(object sender, EventArgs e)
        {
            frRegFlight f = new frRegFlight();
            f.Show();
            this.Hide();
        }

        private void btnRegPilot_Click(object sender, EventArgs e)
        {
            frRegPilot p = new frRegPilot();
            p.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja realmente fechar?", "Atenção!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
                Application.Exit();
                
            }            
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by: \nLeonardo Aragão 081170011\nLucas Boulle 081170012", "About");
        }
    }
}
