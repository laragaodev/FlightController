namespace FlightController
{
    partial class frRegFlight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDepart = new System.Windows.Forms.MaskedTextBox();
            this.txtArrive = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdAircraft = new System.Windows.Forms.TextBox();
            this.txtIdDepart = new System.Windows.Forms.TextBox();
            this.txtIdArrive = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtPilotId = new System.Windows.Forms.TextBox();
            this.txtCoPilotId = new System.Windows.Forms.TextBox();
            this.rbInRoute = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(32, 159);
            this.txtDepart.Mask = "00/00/0000 90:00";
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(125, 20);
            this.txtDepart.TabIndex = 14;
            this.txtDepart.ValidatingType = typeof(System.DateTime);
            // 
            // txtArrive
            // 
            this.txtArrive.Location = new System.Drawing.Point(32, 207);
            this.txtArrive.Mask = "00/00/0000 90:00";
            this.txtArrive.Name = "txtArrive";
            this.txtArrive.Size = new System.Drawing.Size(125, 20);
            this.txtArrive.TabIndex = 15;
            this.txtArrive.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Saída";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Chegada";
            // 
            // txtIdAircraft
            // 
            this.txtIdAircraft.Location = new System.Drawing.Point(254, 103);
            this.txtIdAircraft.Multiline = true;
            this.txtIdAircraft.Name = "txtIdAircraft";
            this.txtIdAircraft.Size = new System.Drawing.Size(173, 24);
            this.txtIdAircraft.TabIndex = 18;
            // 
            // txtIdDepart
            // 
            this.txtIdDepart.Location = new System.Drawing.Point(254, 155);
            this.txtIdDepart.Multiline = true;
            this.txtIdDepart.Name = "txtIdDepart";
            this.txtIdDepart.Size = new System.Drawing.Size(173, 24);
            this.txtIdDepart.TabIndex = 19;
            // 
            // txtIdArrive
            // 
            this.txtIdArrive.Location = new System.Drawing.Point(254, 207);
            this.txtIdArrive.Multiline = true;
            this.txtIdArrive.Name = "txtIdArrive";
            this.txtIdArrive.Size = new System.Drawing.Size(173, 24);
            this.txtIdArrive.TabIndex = 20;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(470, 103);
            this.txtDuration.Multiline = true;
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(173, 24);
            this.txtDuration.TabIndex = 21;
            // 
            // txtPilotId
            // 
            this.txtPilotId.Location = new System.Drawing.Point(470, 155);
            this.txtPilotId.Multiline = true;
            this.txtPilotId.Name = "txtPilotId";
            this.txtPilotId.Size = new System.Drawing.Size(173, 24);
            this.txtPilotId.TabIndex = 22;
            // 
            // txtCoPilotId
            // 
            this.txtCoPilotId.Location = new System.Drawing.Point(470, 207);
            this.txtCoPilotId.Multiline = true;
            this.txtCoPilotId.Name = "txtCoPilotId";
            this.txtCoPilotId.Size = new System.Drawing.Size(173, 24);
            this.txtCoPilotId.TabIndex = 23;
            // 
            // rbInRoute
            // 
            this.rbInRoute.AutoSize = true;
            this.rbInRoute.Location = new System.Drawing.Point(32, 262);
            this.rbInRoute.Name = "rbInRoute";
            this.rbInRoute.Size = new System.Drawing.Size(66, 17);
            this.rbInRoute.TabIndex = 24;
            this.rbInRoute.TabStop = true;
            this.rbInRoute.Text = "Em Rota";
            this.rbInRoute.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Id Aeronave";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(467, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Duração (min)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Saída de";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(467, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Piloto (Id)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Chegada em";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(467, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Co Piloto (Id)";
            // 
            // frRegFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbInRoute);
            this.Controls.Add(this.txtCoPilotId);
            this.Controls.Add(this.txtPilotId);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtIdArrive);
            this.Controls.Add(this.txtIdDepart);
            this.Controls.Add(this.txtIdAircraft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtArrive);
            this.Controls.Add(this.txtDepart);
            this.Name = "frRegFlight";
            this.Text = "frRegFlight";
            this.Controls.SetChildIndex(this.btnPrimeiro, 0);
            this.Controls.SetChildIndex(this.btnProximo, 0);
            this.Controls.SetChildIndex(this.btnAnterior, 0);
            this.Controls.SetChildIndex(this.btnUltimo, 0);
            this.Controls.SetChildIndex(this.btnPesquisa, 0);
            this.Controls.SetChildIndex(this.btnGravar, 0);
            this.Controls.SetChildIndex(this.txtId, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtDepart, 0);
            this.Controls.SetChildIndex(this.txtArrive, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtIdAircraft, 0);
            this.Controls.SetChildIndex(this.txtIdDepart, 0);
            this.Controls.SetChildIndex(this.txtIdArrive, 0);
            this.Controls.SetChildIndex(this.txtDuration, 0);
            this.Controls.SetChildIndex(this.txtPilotId, 0);
            this.Controls.SetChildIndex(this.txtCoPilotId, 0);
            this.Controls.SetChildIndex(this.rbInRoute, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtDepart;
        private System.Windows.Forms.MaskedTextBox txtArrive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdAircraft;
        private System.Windows.Forms.TextBox txtIdDepart;
        private System.Windows.Forms.TextBox txtIdArrive;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtPilotId;
        private System.Windows.Forms.TextBox txtCoPilotId;
        private System.Windows.Forms.RadioButton rbInRoute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}