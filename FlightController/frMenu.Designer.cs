namespace FlightController
{
    partial class frMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frMenu));
            this.btnRegAircraft = new System.Windows.Forms.Button();
            this.btnRegFlight = new System.Windows.Forms.Button();
            this.btnRegPilot = new System.Windows.Forms.Button();
            this.btnMasterDetails = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnAbout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegAircraft
            // 
            this.btnRegAircraft.Location = new System.Drawing.Point(411, 148);
            this.btnRegAircraft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegAircraft.Name = "btnRegAircraft";
            this.btnRegAircraft.Size = new System.Drawing.Size(212, 50);
            this.btnRegAircraft.TabIndex = 0;
            this.btnRegAircraft.Text = "Register Aircraft";
            this.btnRegAircraft.UseVisualStyleBackColor = true;
            this.btnRegAircraft.Click += new System.EventHandler(this.btnRegAircraft_Click);
            // 
            // btnRegFlight
            // 
            this.btnRegFlight.Location = new System.Drawing.Point(411, 206);
            this.btnRegFlight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegFlight.Name = "btnRegFlight";
            this.btnRegFlight.Size = new System.Drawing.Size(212, 44);
            this.btnRegFlight.TabIndex = 1;
            this.btnRegFlight.Text = "Register Flight";
            this.btnRegFlight.UseVisualStyleBackColor = true;
            this.btnRegFlight.Click += new System.EventHandler(this.btnRegFlight_Click);
            // 
            // btnRegPilot
            // 
            this.btnRegPilot.Location = new System.Drawing.Point(411, 257);
            this.btnRegPilot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegPilot.Name = "btnRegPilot";
            this.btnRegPilot.Size = new System.Drawing.Size(212, 44);
            this.btnRegPilot.TabIndex = 3;
            this.btnRegPilot.Text = "Register Pilot";
            this.btnRegPilot.UseVisualStyleBackColor = true;
            this.btnRegPilot.Click += new System.EventHandler(this.btnRegPilot_Click);
            // 
            // btnMasterDetails
            // 
            this.btnMasterDetails.Location = new System.Drawing.Point(411, 309);
            this.btnMasterDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMasterDetails.Name = "btnMasterDetails";
            this.btnMasterDetails.Size = new System.Drawing.Size(212, 50);
            this.btnMasterDetails.TabIndex = 2;
            this.btnMasterDetails.Text = "Air Traffic";
            this.btnMasterDetails.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(991, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 42);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(411, 367);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(212, 50);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // frMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRegPilot);
            this.Controls.Add(this.btnMasterDetails);
            this.Controls.Add(this.btnRegFlight);
            this.Controls.Add(this.btnRegAircraft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frMenu";
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegAircraft;
        private System.Windows.Forms.Button btnRegFlight;
        private System.Windows.Forms.Button btnRegPilot;
        private System.Windows.Forms.Button btnMasterDetails;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Button btnAbout;
    }
}