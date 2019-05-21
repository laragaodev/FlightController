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
using System.Data.SqlClient;

namespace FlightController
{
    public partial class frPadrao : Form
    {
        protected PadraoDAO cadastroDAO;

        public bool SugereProximoId { get; set; } = false;

        public frPadrao()
        {
            InitializeComponent();
        }

        protected virtual void PreencheTela(PadraoVO o)
        {
            //preencher nos filhos
        }

        protected void TrataErro(Exception erro)
        {
            if (erro is FormatException)
            {
               // Metodos.Mensagem("Campo numérico inválido!", TipoMensagemEnum.erro);
            }
            else if (erro is SqlException)
            {
                //Metodos.Mensagem("Ocorreu um erro no banco de dados.", TipoMensagemEnum.erro);
            }
            else if (erro is Exception)
            {
                //Metodos.Mensagem(erro.Message, TipoMensagemEnum.erro);
            }
        }

        protected bool EstaEmModoDev()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }

        private void AlteraParaModo(EnumModoOperacao modo)
        {
            btnInclui.Enabled = (modo == EnumModoOperacao.Navegacao);
            btnAltera.Enabled = (modo == EnumModoOperacao.Navegacao);
            btnExclui.Enabled = (modo == EnumModoOperacao.Navegacao) && txtId.Text.Length > 0;
            btnProximo.Enabled = (modo == EnumModoOperacao.Navegacao);
            btnAnterior.Enabled = (modo == EnumModoOperacao.Navegacao) && int.Parse(txtId.Text) > 0;
            btnProximo.Enabled = (modo == EnumModoOperacao.Navegacao) && int.Parse(txtId.Text) > 0;
            btnUltimo.Enabled = (modo == EnumModoOperacao.Navegacao);
            btnGravar.Enabled = (modo != EnumModoOperacao.Navegacao);
            btnCancelar.Enabled = (modo != EnumModoOperacao.Navegacao);
            btnPesquisa.Enabled = (modo == EnumModoOperacao.Navegacao);
            if (modo == EnumModoOperacao.Inclusao)
            {
                txtId.Enabled = true;
                LimpaCampos(this);
                txtId.Focus();
            }
            else
                txtId.Enabled = false;
            ControlaCamposTela(modo); // propositalmente no final para que se possa alterar alguns
                                      //dos comportamentos acima nos descendentes
        }

        protected virtual void ControlaCamposTela(EnumModoOperacao modo)
        {
            // deve ser sobrescrito
        }

        protected virtual PadraoVO PreencheObj()
        {
            return null; // é necessário ter algo .. não é void! Programar nos descendentes
        }

        protected void LimpaCampos(Control objeto)
        {
            if (objeto is TextBox ||
            objeto is MaskedTextBox)
                objeto.Text = "";
            else if (objeto is NumericUpDown)
                (objeto as NumericUpDown).Value = 0;
            else
            {
                foreach (Control o in objeto.Controls)
                    LimpaCampos(o);
            }
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            AlteraParaModo(EnumModoOperacao.Alteracao);
        }

        private void btnInclui_Click(object sender, EventArgs e)
        {
            AlteraParaModo(EnumModoOperacao.Inclusao);
            //if (SugereProximoId)
                //txtId.Text = cadastroDAO.ProximoId("nomeSP");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frMenu m = new frMenu();
            m.Show();
            this.Close();
        }
    }
}
