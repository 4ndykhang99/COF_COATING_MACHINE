namespace COF_MACHINE.User_Controller
{
    partial class COF
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.gBoxINFO = new Guna.UI2.WinForms.Guna2GroupBox();
            this.checkBoxAUTOSAVE = new System.Windows.Forms.CheckBox();
            this.tboxNOTICE = new Guna.UI2.WinForms.Guna2TextBox();
            this.tBoxLOT = new Guna.UI2.WinForms.Guna2TextBox();
            this.tBoxNOTE = new Guna.UI2.WinForms.Guna2TextBox();
            this.tBoxNAME = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbLOT = new System.Windows.Forms.Label();
            this.lbNOTE = new System.Windows.Forms.Label();
            this.btnSAVE = new Guna.UI2.WinForms.Guna2Button();
            this.btnNEW = new Guna.UI2.WinForms.Guna2Button();
            this.lbSAMPLENAME = new System.Windows.Forms.Label();
            this.chartCOF = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnSETHOME = new Guna.UI2.WinForms.Guna2Button();
            this.btnRUN = new Guna.UI2.WinForms.Guna2Button();
            this.btnSTOP = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.gBoxINFO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCOF)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxINFO
            // 
            this.gBoxINFO.Controls.Add(this.checkBoxAUTOSAVE);
            this.gBoxINFO.Controls.Add(this.tboxNOTICE);
            this.gBoxINFO.Controls.Add(this.tBoxLOT);
            this.gBoxINFO.Controls.Add(this.tBoxNOTE);
            this.gBoxINFO.Controls.Add(this.tBoxNAME);
            this.gBoxINFO.Controls.Add(this.lbLOT);
            this.gBoxINFO.Controls.Add(this.lbNOTE);
            this.gBoxINFO.Controls.Add(this.btnSAVE);
            this.gBoxINFO.Controls.Add(this.btnNEW);
            this.gBoxINFO.Controls.Add(this.lbSAMPLENAME);
            this.gBoxINFO.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxINFO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gBoxINFO.Location = new System.Drawing.Point(38, 22);
            this.gBoxINFO.Name = "gBoxINFO";
            this.gBoxINFO.Size = new System.Drawing.Size(342, 383);
            this.gBoxINFO.TabIndex = 0;
            this.gBoxINFO.Text = "Test_Information";
            // 
            // checkBoxAUTOSAVE
            // 
            this.checkBoxAUTOSAVE.AutoSize = true;
            this.checkBoxAUTOSAVE.BackColor = System.Drawing.Color.White;
            this.checkBoxAUTOSAVE.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAUTOSAVE.Location = new System.Drawing.Point(41, 318);
            this.checkBoxAUTOSAVE.Name = "checkBoxAUTOSAVE";
            this.checkBoxAUTOSAVE.Size = new System.Drawing.Size(87, 20);
            this.checkBoxAUTOSAVE.TabIndex = 18;
            this.checkBoxAUTOSAVE.Text = "AutoSave";
            this.checkBoxAUTOSAVE.UseVisualStyleBackColor = false;
            this.checkBoxAUTOSAVE.CheckedChanged += new System.EventHandler(this.checkBoxAUTOSAVE_CheckedChanged);
            // 
            // tboxNOTICE
            // 
            this.tboxNOTICE.BackColor = System.Drawing.SystemColors.Control;
            this.tboxNOTICE.BorderColor = System.Drawing.SystemColors.Control;
            this.tboxNOTICE.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tboxNOTICE.DefaultText = "";
            this.tboxNOTICE.DisabledState.BorderColor = System.Drawing.Color.White;
            this.tboxNOTICE.DisabledState.FillColor = System.Drawing.Color.White;
            this.tboxNOTICE.DisabledState.ForeColor = System.Drawing.Color.White;
            this.tboxNOTICE.DisabledState.PlaceholderForeColor = System.Drawing.Color.White;
            this.tboxNOTICE.Enabled = false;
            this.tboxNOTICE.FillColor = System.Drawing.Color.PaleGreen;
            this.tboxNOTICE.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tboxNOTICE.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tboxNOTICE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tboxNOTICE.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tboxNOTICE.Location = new System.Drawing.Point(3, 358);
            this.tboxNOTICE.Name = "tboxNOTICE";
            this.tboxNOTICE.PasswordChar = '\0';
            this.tboxNOTICE.PlaceholderText = "";
            this.tboxNOTICE.SelectedText = "";
            this.tboxNOTICE.Size = new System.Drawing.Size(125, 22);
            this.tboxNOTICE.TabIndex = 17;
            // 
            // tBoxLOT
            // 
            this.tBoxLOT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBoxLOT.DefaultText = "";
            this.tBoxLOT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tBoxLOT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tBoxLOT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tBoxLOT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tBoxLOT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tBoxLOT.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxLOT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tBoxLOT.Location = new System.Drawing.Point(148, 196);
            this.tBoxLOT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBoxLOT.Name = "tBoxLOT";
            this.tBoxLOT.PasswordChar = '\0';
            this.tBoxLOT.PlaceholderText = "";
            this.tBoxLOT.SelectedText = "";
            this.tBoxLOT.Size = new System.Drawing.Size(174, 23);
            this.tBoxLOT.TabIndex = 7;
            // 
            // tBoxNOTE
            // 
            this.tBoxNOTE.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBoxNOTE.DefaultText = "";
            this.tBoxNOTE.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tBoxNOTE.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tBoxNOTE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tBoxNOTE.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tBoxNOTE.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tBoxNOTE.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Bold);
            this.tBoxNOTE.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tBoxNOTE.Location = new System.Drawing.Point(148, 112);
            this.tBoxNOTE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBoxNOTE.Multiline = true;
            this.tBoxNOTE.Name = "tBoxNOTE";
            this.tBoxNOTE.PasswordChar = '\0';
            this.tBoxNOTE.PlaceholderText = "";
            this.tBoxNOTE.SelectedText = "";
            this.tBoxNOTE.Size = new System.Drawing.Size(174, 55);
            this.tBoxNOTE.TabIndex = 6;
            // 
            // tBoxNAME
            // 
            this.tBoxNAME.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tBoxNAME.DefaultText = "";
            this.tBoxNAME.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tBoxNAME.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tBoxNAME.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tBoxNAME.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tBoxNAME.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tBoxNAME.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxNAME.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tBoxNAME.Location = new System.Drawing.Point(148, 65);
            this.tBoxNAME.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBoxNAME.Name = "tBoxNAME";
            this.tBoxNAME.PasswordChar = '\0';
            this.tBoxNAME.PlaceholderText = "";
            this.tBoxNAME.SelectedText = "";
            this.tBoxNAME.Size = new System.Drawing.Size(174, 23);
            this.tBoxNAME.TabIndex = 5;
            // 
            // lbLOT
            // 
            this.lbLOT.AutoSize = true;
            this.lbLOT.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLOT.Location = new System.Drawing.Point(12, 199);
            this.lbLOT.Name = "lbLOT";
            this.lbLOT.Size = new System.Drawing.Size(34, 18);
            this.lbLOT.TabIndex = 2;
            this.lbLOT.Text = "LOT";
            // 
            // lbNOTE
            // 
            this.lbNOTE.AutoSize = true;
            this.lbNOTE.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNOTE.Location = new System.Drawing.Point(12, 112);
            this.lbNOTE.Name = "lbNOTE";
            this.lbNOTE.Size = new System.Drawing.Size(46, 18);
            this.lbNOTE.TabIndex = 1;
            this.lbNOTE.Text = "NOTE";
            // 
            // btnSAVE
            // 
            this.btnSAVE.AutoRoundedCorners = true;
            this.btnSAVE.BackColor = System.Drawing.Color.White;
            this.btnSAVE.BorderRadius = 18;
            this.btnSAVE.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSAVE.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSAVE.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSAVE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSAVE.FillColor = System.Drawing.Color.SlateGray;
            this.btnSAVE.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.ForeColor = System.Drawing.Color.White;
            this.btnSAVE.Location = new System.Drawing.Point(36, 263);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(102, 39);
            this.btnSAVE.TabIndex = 2;
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // btnNEW
            // 
            this.btnNEW.AutoRoundedCorners = true;
            this.btnNEW.BackColor = System.Drawing.Color.White;
            this.btnNEW.BorderRadius = 18;
            this.btnNEW.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNEW.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNEW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNEW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNEW.FillColor = System.Drawing.Color.SteelBlue;
            this.btnNEW.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNEW.ForeColor = System.Drawing.Color.White;
            this.btnNEW.Location = new System.Drawing.Point(199, 263);
            this.btnNEW.Name = "btnNEW";
            this.btnNEW.Size = new System.Drawing.Size(102, 39);
            this.btnNEW.TabIndex = 3;
            this.btnNEW.Text = "NEW";
            this.btnNEW.Click += new System.EventHandler(this.btnNEW_Click);
            // 
            // lbSAMPLENAME
            // 
            this.lbSAMPLENAME.AutoSize = true;
            this.lbSAMPLENAME.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSAMPLENAME.Location = new System.Drawing.Point(12, 65);
            this.lbSAMPLENAME.Name = "lbSAMPLENAME";
            this.lbSAMPLENAME.Size = new System.Drawing.Size(116, 18);
            this.lbSAMPLENAME.TabIndex = 0;
            this.lbSAMPLENAME.Text = "SAMPLE_NAME";
            // 
            // chartCOF
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCOF.ChartAreas.Add(chartArea2);
            this.chartCOF.Location = new System.Drawing.Point(406, 22);
            this.chartCOF.Name = "chartCOF";
            this.chartCOF.Size = new System.Drawing.Size(810, 476);
            this.chartCOF.TabIndex = 4;
            this.chartCOF.Text = "COF";
            this.chartCOF.Click += new System.EventHandler(this.chartCOF_Click);
            // 
            // btnSETHOME
            // 
            this.btnSETHOME.AutoRoundedCorners = true;
            this.btnSETHOME.BorderRadius = 18;
            this.btnSETHOME.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSETHOME.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSETHOME.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSETHOME.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSETHOME.FillColor = System.Drawing.Color.SlateGray;
            this.btnSETHOME.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSETHOME.ForeColor = System.Drawing.Color.White;
            this.btnSETHOME.Location = new System.Drawing.Point(38, 439);
            this.btnSETHOME.Name = "btnSETHOME";
            this.btnSETHOME.Size = new System.Drawing.Size(102, 39);
            this.btnSETHOME.TabIndex = 5;
            this.btnSETHOME.Text = "SETHOME";
            this.btnSETHOME.Click += new System.EventHandler(this.btnSETHOME_Click);
            // 
            // btnRUN
            // 
            this.btnRUN.AutoRoundedCorners = true;
            this.btnRUN.BorderRadius = 18;
            this.btnRUN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRUN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRUN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRUN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRUN.FillColor = System.Drawing.Color.SteelBlue;
            this.btnRUN.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRUN.ForeColor = System.Drawing.Color.White;
            this.btnRUN.Location = new System.Drawing.Point(159, 439);
            this.btnRUN.Name = "btnRUN";
            this.btnRUN.Size = new System.Drawing.Size(102, 39);
            this.btnRUN.TabIndex = 6;
            this.btnRUN.Text = "RUN";
            this.btnRUN.Click += new System.EventHandler(this.btnRUN_Click);
            // 
            // btnSTOP
            // 
            this.btnSTOP.AutoRoundedCorners = true;
            this.btnSTOP.BorderRadius = 18;
            this.btnSTOP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSTOP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSTOP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSTOP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSTOP.FillColor = System.Drawing.Color.SteelBlue;
            this.btnSTOP.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTOP.ForeColor = System.Drawing.Color.White;
            this.btnSTOP.Location = new System.Drawing.Point(278, 439);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(102, 39);
            this.btnSTOP.TabIndex = 16;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // COF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnSTOP);
            this.Controls.Add(this.btnRUN);
            this.Controls.Add(this.btnSETHOME);
            this.Controls.Add(this.chartCOF);
            this.Controls.Add(this.gBoxINFO);
            this.Name = "COF";
            this.Size = new System.Drawing.Size(1250, 531);
            this.gBoxINFO.ResumeLayout(false);
            this.gBoxINFO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCOF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gBoxINFO;
        private System.Windows.Forms.Label lbLOT;
        private System.Windows.Forms.Label lbNOTE;
        private System.Windows.Forms.Label lbSAMPLENAME;
        public Guna.UI2.WinForms.Guna2Button btnSAVE;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartCOF;
        public Guna.UI2.WinForms.Guna2Button btnRUN;
        public Guna.UI2.WinForms.Guna2TextBox tBoxNAME;
        public Guna.UI2.WinForms.Guna2Button btnNEW;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ToolTip toolTip2;
        public System.Windows.Forms.ToolTip toolTip3;
        public System.Windows.Forms.CheckBox checkBoxAUTOSAVE;
        public Guna.UI2.WinForms.Guna2TextBox tboxNOTICE;
        public Guna.UI2.WinForms.Guna2TextBox tBoxLOT;
        public Guna.UI2.WinForms.Guna2TextBox tBoxNOTE;
        public Guna.UI2.WinForms.Guna2Button btnSTOP;
        public Guna.UI2.WinForms.Guna2Button btnSETHOME;
    }
}
