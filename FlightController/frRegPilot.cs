﻿using System;
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
            return p;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            frSearchPilot sp = new frSearchPilot();
            sp.ShowDialog();
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            PilotDAO p = new PilotDAO();
            p.Primeiro("spBuscaPrimeiro");
        }


    }
    
    
}
