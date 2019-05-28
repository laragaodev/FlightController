using Library.DAO;
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
    public partial class frSearchPadrao : Form
    {
        protected PadraoDAO cadastroDAO;

        public frSearchPadrao()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                PadraoVO obj = PreencheObj();
                DataTable dt = cadastroDAO.Pesquisa(obj);
                dataGridView1.DataSource = dt;
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message);
            }

        }

        protected virtual PadraoVO PreencheObj()
        {
            return null; //override
        }
    }
}
