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
    public partial class frRegPilot : frPadrao
    {
        public frRegPilot()
        {
            InitializeComponent();
            cadastroDAO = new PilotDAO();
            SugereProximoId = true;            
        }

        string filename = "";

        protected override void PreencheTela(PadraoVO o)
        {
            try
            {
                if (o != null)
                {
                    txtId.Text = (o as PilotVO).Id.ToString();
                    txtName.Text = (o as PilotVO).Name;
                    txtLicenseId.Text = (o as PilotVO).License_Id.ToString();
                    dtpBirthDate.Value = (o as PilotVO).BirthDate;
                    pictureBox1.Image = Image.FromFile((o as PilotVO).image_path);
                    if ((o as PilotVO).Gender == 'M')
                        rbMale.Checked = true;
                    else
                        rbFemale.Checked = true;
                }
                else
                {
                    LimpaCampos(this);
                }
            }
            catch (Exception erro)
            {
                TrataErro(erro);
            }
        }

        protected override void ControlaCamposTela(EnumModoOperacao modo)
        {
            txtName.Enabled = txtLicenseId.Enabled = dtpBirthDate.Enabled = rbMale.Enabled = rbFemale.Enabled = modo != EnumModoOperacao.Navegacao;
        }

        protected override PadraoVO PreencheObj()
        {
            PilotVO p = new PilotVO();
            p.Id = Convert.ToInt32(txtId.Text);
            p.Name = txtName.Text;
            p.License_Id = Convert.ToInt32(txtLicenseId.Text);
            p.Gender = rbMale.Checked == true ? 'M' : 'F';
            p.BirthDate = dtpBirthDate.Value;
            p.image_path = filename;
            return p;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            frSearchPilot sp = new frSearchPilot();
            sp.ShowDialog();
        }

        private void btnGetImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(filename);
                }
            }
        }
    }
    
    
}
