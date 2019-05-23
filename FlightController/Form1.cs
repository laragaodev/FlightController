using Library;
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
    public partial class frLogin : Form
    {
        public frLogin()
        {
            InitializeComponent();            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            InitDB inicializador = new InitDB();
            if (string.IsNullOrEmpty(txtServidor.Text))
                MessageBox.Show("Informe pelo menos o server!");
            else
            {
                inicializador.CriarDB(txtServidor.Text, txtUsuario.Text, txtSenha.Text);
                frMenu m = new frMenu();
                m.Show();
                this.Hide();
            }
        }
    }
}
