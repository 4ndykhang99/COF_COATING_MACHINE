namespace COF_MACHINE.User_Controller
{
    partial class coating
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gBoxCOATING = new Guna.UI2.WinForms.Guna2GroupBox();
            this.tBoxSPEED = new System.Windows.Forms.TextBox();
            this.btnSPEEDSET = new System.Windows.Forms.Button();
            this.lbSPEEDUNIT = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbSPEED = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnRUNBWD = new Guna.UI2.WinForms.Guna2Button();
            this.btnSTOP = new Guna.UI2.WinForms.Guna2Button();
            this.btnRUNFWD = new Guna.UI2.WinForms.Guna2Button();
            this.gBoxCOATING.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxCOATING
            // 
            this.gBoxCOATING.Controls.Add(this.tBoxSPEED);
            this.gBoxCOATING.Controls.Add(this.btnSPEEDSET);
            this.gBoxCOATING.Controls.Add(this.lbSPEEDUNIT);
            this.gBoxCOATING.Controls.Add(this.lbSPEED);
            this.gBoxCOATING.Controls.Add(this.btnRUNBWD);
            this.gBoxCOATING.Controls.Add(this.btnSTOP);
            this.gBoxCOATING.Controls.Add(this.btnRUNFWD);
            this.gBoxCOATING.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxCOATING.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gBoxCOATING.Location = new System.Drawing.Point(45, 49);
            this.gBoxCOATING.Name = "gBoxCOATING";
            this.gBoxCOATING.Size = new System.Drawing.Size(604, 408);
            this.gBoxCOATING.TabIndex = 0;
            this.gBoxCOATING.Text = "Coating_Control";
            // 
            // tBoxSPEED
            // 
            this.tBoxSPEED.Location = new System.Drawing.Point(108, 235);
            this.tBoxSPEED.Name = "tBoxSPEED";
            this.tBoxSPEED.Size = new System.Drawing.Size(145, 27);
            this.tBoxSPEED.TabIndex = 8;
            // 
            // btnSPEEDSET
            // 
            this.btnSPEEDSET.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSPEEDSET.Location = new System.Drawing.Point(403, 227);
            this.btnSPEEDSET.Name = "btnSPEEDSET";
            this.btnSPEEDSET.Size = new System.Drawing.Size(141, 40);
            this.btnSPEEDSET.TabIndex = 7;
            this.btnSPEEDSET.Text = "&SET";
            this.btnSPEEDSET.UseVisualStyleBackColor = true;
            this.btnSPEEDSET.Click += new System.EventHandler(this.btnSPEEDSET_Click);
            this.btnSPEEDSET.Enter += new System.EventHandler(this.btnSPEEDSET_Click);
            // 
            // lbSPEEDUNIT
            // 
            this.lbSPEEDUNIT.BackColor = System.Drawing.Color.Transparent;
            this.lbSPEEDUNIT.Location = new System.Drawing.Point(285, 241);
            this.lbSPEEDUNIT.Name = "lbSPEEDUNIT";
            this.lbSPEEDUNIT.Size = new System.Drawing.Size(55, 15);
            this.lbSPEEDUNIT.TabIndex = 6;
            this.lbSPEEDUNIT.Text = "mm/minute";
            // 
            // lbSPEED
            // 
            this.lbSPEED.BackColor = System.Drawing.Color.Transparent;
            this.lbSPEED.Location = new System.Drawing.Point(41, 242);
            this.lbSPEED.Name = "lbSPEED";
            this.lbSPEED.Size = new System.Drawing.Size(39, 15);
            this.lbSPEED.TabIndex = 5;
            this.lbSPEED.Text = "SPEED";
            // 
            // btnRUNBWD
            // 
            this.btnRUNBWD.AutoRoundedCorners = true;
            this.btnRUNBWD.BackColor = System.Drawing.Color.White;
            this.btnRUNBWD.BorderRadius = 32;
            this.btnRUNBWD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRUNBWD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRUNBWD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRUNBWD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRUNBWD.FillColor = System.Drawing.Color.LightSlateGray;
            this.btnRUNBWD.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRUNBWD.ForeColor = System.Drawing.Color.White;
            this.btnRUNBWD.Location = new System.Drawing.Point(407, 69);
            this.btnRUNBWD.Name = "btnRUNBWD";
            this.btnRUNBWD.Size = new System.Drawing.Size(131, 66);
            this.btnRUNBWD.TabIndex = 2;
            this.btnRUNBWD.Text = "RUN BACKWARD";
            this.btnRUNBWD.Click += new System.EventHandler(this.btnRUNBWD_Click);
            // 
            // btnSTOP
            // 
            this.btnSTOP.AutoRoundedCorners = true;
            this.btnSTOP.BackColor = System.Drawing.Color.White;
            this.btnSTOP.BorderRadius = 32;
            this.btnSTOP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSTOP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSTOP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSTOP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSTOP.FillColor = System.Drawing.Color.LightSlateGray;
            this.btnSTOP.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTOP.ForeColor = System.Drawing.Color.White;
            this.btnSTOP.Location = new System.Drawing.Point(234, 69);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(131, 66);
            this.btnSTOP.TabIndex = 1;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // btnRUNFWD
            // 
            this.btnRUNFWD.AutoRoundedCorners = true;
            this.btnRUNFWD.BackColor = System.Drawing.Color.White;
            this.btnRUNFWD.BorderRadius = 32;
            this.btnRUNFWD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRUNFWD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRUNFWD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRUNFWD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRUNFWD.FillColor = System.Drawing.Color.LightSlateGray;
            this.btnRUNFWD.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRUNFWD.ForeColor = System.Drawing.Color.White;
            this.btnRUNFWD.Location = new System.Drawing.Point(61, 69);
            this.btnRUNFWD.Name = "btnRUNFWD";
            this.btnRUNFWD.Size = new System.Drawing.Size(131, 66);
            this.btnRUNFWD.TabIndex = 0;
            this.btnRUNFWD.Text = "RUN FORWARD";
            this.btnRUNFWD.Click += new System.EventHandler(this.btnRUNFWD_Click);
            // 
            // coating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gBoxCOATING);
            this.Name = "coating";
            this.Size = new System.Drawing.Size(1250, 531);
            this.gBoxCOATING.ResumeLayout(false);
            this.gBoxCOATING.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gBoxCOATING;
        private Guna.UI2.WinForms.Guna2Button btnRUNFWD;
        private Guna.UI2.WinForms.Guna2Button btnSTOP;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbSPEED;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbSPEEDUNIT;
        private System.Windows.Forms.Button btnSPEEDSET;
        public System.Windows.Forms.TextBox tBoxSPEED;
        public Guna.UI2.WinForms.Guna2Button btnRUNBWD;
    }
}
