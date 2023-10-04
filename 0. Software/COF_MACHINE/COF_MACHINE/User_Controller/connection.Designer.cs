namespace COF_MACHINE.User_Controller
{
    partial class connection
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
            this.lbSTATUS = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gBoxCONNECTION = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cBoxCOMPORTS = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbSTOPBITS = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbPARITYBITS = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbDATABITS = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbCOMBOX = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbBAURATE = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cBoxSTOPBITS = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cBoxPARITYBITS = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cBoxDATABITS = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cBoxBAUDRATE = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gBoxCONTROL = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnREFRESH = new Guna.UI2.WinForms.Guna2Button();
            this.pBarSTATUS = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.btnSTOP = new Guna.UI2.WinForms.Guna2Button();
            this.btnSTART = new Guna.UI2.WinForms.Guna2Button();
            this.serialUSB = new System.IO.Ports.SerialPort(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.gBoxCONNECTION.SuspendLayout();
            this.gBoxCONTROL.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSTATUS
            // 
            this.lbSTATUS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.lbSTATUS.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSTATUS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbSTATUS.Location = new System.Drawing.Point(109, 335);
            this.lbSTATUS.Name = "lbSTATUS";
            this.lbSTATUS.Size = new System.Drawing.Size(52, 20);
            this.lbSTATUS.TabIndex = 8;
            this.lbSTATUS.Text = "STATUS";
            this.lbSTATUS.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gBoxCONNECTION
            // 
            this.gBoxCONNECTION.Controls.Add(this.cBoxCOMPORTS);
            this.gBoxCONNECTION.Controls.Add(this.lbSTOPBITS);
            this.gBoxCONNECTION.Controls.Add(this.lbPARITYBITS);
            this.gBoxCONNECTION.Controls.Add(this.lbDATABITS);
            this.gBoxCONNECTION.Controls.Add(this.lbCOMBOX);
            this.gBoxCONNECTION.Controls.Add(this.lbBAURATE);
            this.gBoxCONNECTION.Controls.Add(this.cBoxSTOPBITS);
            this.gBoxCONNECTION.Controls.Add(this.cBoxPARITYBITS);
            this.gBoxCONNECTION.Controls.Add(this.cBoxDATABITS);
            this.gBoxCONNECTION.Controls.Add(this.cBoxBAUDRATE);
            this.gBoxCONNECTION.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxCONNECTION.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gBoxCONNECTION.Location = new System.Drawing.Point(45, 49);
            this.gBoxCONNECTION.Name = "gBoxCONNECTION";
            this.gBoxCONNECTION.Size = new System.Drawing.Size(437, 408);
            this.gBoxCONNECTION.TabIndex = 0;
            this.gBoxCONNECTION.Text = "Serial_Connection";
            // 
            // cBoxCOMPORTS
            // 
            this.cBoxCOMPORTS.BackColor = System.Drawing.Color.Transparent;
            this.cBoxCOMPORTS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cBoxCOMPORTS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCOMPORTS.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cBoxCOMPORTS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cBoxCOMPORTS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBoxCOMPORTS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cBoxCOMPORTS.ItemHeight = 30;
            this.cBoxCOMPORTS.Items.AddRange(new object[] {
            "-- Choose --"});
            this.cBoxCOMPORTS.Location = new System.Drawing.Point(183, 71);
            this.cBoxCOMPORTS.Name = "cBoxCOMPORTS";
            this.cBoxCOMPORTS.Size = new System.Drawing.Size(231, 36);
            this.cBoxCOMPORTS.StartIndex = 0;
            this.cBoxCOMPORTS.TabIndex = 11;
            // 
            // lbSTOPBITS
            // 
            this.lbSTOPBITS.BackColor = System.Drawing.Color.Transparent;
            this.lbSTOPBITS.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSTOPBITS.ForeColor = System.Drawing.Color.Gray;
            this.lbSTOPBITS.Location = new System.Drawing.Point(31, 330);
            this.lbSTOPBITS.Name = "lbSTOPBITS";
            this.lbSTOPBITS.Size = new System.Drawing.Size(65, 20);
            this.lbSTOPBITS.TabIndex = 10;
            this.lbSTOPBITS.Text = "STOPBITS";
            // 
            // lbPARITYBITS
            // 
            this.lbPARITYBITS.BackColor = System.Drawing.Color.Transparent;
            this.lbPARITYBITS.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPARITYBITS.ForeColor = System.Drawing.Color.Gray;
            this.lbPARITYBITS.Location = new System.Drawing.Point(31, 267);
            this.lbPARITYBITS.Name = "lbPARITYBITS";
            this.lbPARITYBITS.Size = new System.Drawing.Size(81, 20);
            this.lbPARITYBITS.TabIndex = 9;
            this.lbPARITYBITS.Text = "PARITY BITS";
            // 
            // lbDATABITS
            // 
            this.lbDATABITS.BackColor = System.Drawing.Color.Transparent;
            this.lbDATABITS.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDATABITS.ForeColor = System.Drawing.Color.Gray;
            this.lbDATABITS.Location = new System.Drawing.Point(31, 204);
            this.lbDATABITS.Name = "lbDATABITS";
            this.lbDATABITS.Size = new System.Drawing.Size(73, 20);
            this.lbDATABITS.TabIndex = 8;
            this.lbDATABITS.Text = "DATA BITS";
            // 
            // lbCOMBOX
            // 
            this.lbCOMBOX.BackColor = System.Drawing.Color.Transparent;
            this.lbCOMBOX.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCOMBOX.ForeColor = System.Drawing.Color.Gray;
            this.lbCOMBOX.Location = new System.Drawing.Point(31, 78);
            this.lbCOMBOX.Name = "lbCOMBOX";
            this.lbCOMBOX.Size = new System.Drawing.Size(90, 20);
            this.lbCOMBOX.TabIndex = 7;
            this.lbCOMBOX.Text = "COM PORTS";
            // 
            // lbBAURATE
            // 
            this.lbBAURATE.BackColor = System.Drawing.Color.Transparent;
            this.lbBAURATE.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBAURATE.ForeColor = System.Drawing.Color.Gray;
            this.lbBAURATE.Location = new System.Drawing.Point(31, 141);
            this.lbBAURATE.Name = "lbBAURATE";
            this.lbBAURATE.Size = new System.Drawing.Size(78, 20);
            this.lbBAURATE.TabIndex = 6;
            this.lbBAURATE.Text = "BAUDRATE";
            // 
            // cBoxSTOPBITS
            // 
            this.cBoxSTOPBITS.BackColor = System.Drawing.Color.Transparent;
            this.cBoxSTOPBITS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cBoxSTOPBITS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSTOPBITS.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cBoxSTOPBITS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cBoxSTOPBITS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBoxSTOPBITS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cBoxSTOPBITS.ItemHeight = 30;
            this.cBoxSTOPBITS.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.cBoxSTOPBITS.Location = new System.Drawing.Point(183, 323);
            this.cBoxSTOPBITS.Name = "cBoxSTOPBITS";
            this.cBoxSTOPBITS.Size = new System.Drawing.Size(231, 36);
            this.cBoxSTOPBITS.StartIndex = 0;
            this.cBoxSTOPBITS.TabIndex = 4;
            // 
            // cBoxPARITYBITS
            // 
            this.cBoxPARITYBITS.BackColor = System.Drawing.Color.Transparent;
            this.cBoxPARITYBITS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cBoxPARITYBITS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxPARITYBITS.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cBoxPARITYBITS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cBoxPARITYBITS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBoxPARITYBITS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cBoxPARITYBITS.ItemHeight = 30;
            this.cBoxPARITYBITS.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cBoxPARITYBITS.Location = new System.Drawing.Point(183, 260);
            this.cBoxPARITYBITS.Name = "cBoxPARITYBITS";
            this.cBoxPARITYBITS.Size = new System.Drawing.Size(231, 36);
            this.cBoxPARITYBITS.StartIndex = 0;
            this.cBoxPARITYBITS.TabIndex = 3;
            // 
            // cBoxDATABITS
            // 
            this.cBoxDATABITS.BackColor = System.Drawing.Color.Transparent;
            this.cBoxDATABITS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cBoxDATABITS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxDATABITS.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cBoxDATABITS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cBoxDATABITS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBoxDATABITS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cBoxDATABITS.ItemHeight = 30;
            this.cBoxDATABITS.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cBoxDATABITS.Location = new System.Drawing.Point(183, 197);
            this.cBoxDATABITS.Name = "cBoxDATABITS";
            this.cBoxDATABITS.Size = new System.Drawing.Size(231, 36);
            this.cBoxDATABITS.StartIndex = 3;
            this.cBoxDATABITS.TabIndex = 2;
            // 
            // cBoxBAUDRATE
            // 
            this.cBoxBAUDRATE.BackColor = System.Drawing.Color.Transparent;
            this.cBoxBAUDRATE.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cBoxBAUDRATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxBAUDRATE.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cBoxBAUDRATE.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cBoxBAUDRATE.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cBoxBAUDRATE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cBoxBAUDRATE.ItemHeight = 30;
            this.cBoxBAUDRATE.Items.AddRange(new object[] {
            "9600",
            "115200"});
            this.cBoxBAUDRATE.Location = new System.Drawing.Point(183, 134);
            this.cBoxBAUDRATE.Name = "cBoxBAUDRATE";
            this.cBoxBAUDRATE.Size = new System.Drawing.Size(231, 36);
            this.cBoxBAUDRATE.StartIndex = 0;
            this.cBoxBAUDRATE.TabIndex = 1;
            // 
            // gBoxCONTROL
            // 
            this.gBoxCONTROL.Controls.Add(this.btnREFRESH);
            this.gBoxCONTROL.Controls.Add(this.lbSTATUS);
            this.gBoxCONTROL.Controls.Add(this.pBarSTATUS);
            this.gBoxCONTROL.Controls.Add(this.btnSTOP);
            this.gBoxCONTROL.Controls.Add(this.btnSTART);
            this.gBoxCONTROL.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxCONTROL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gBoxCONTROL.Location = new System.Drawing.Point(510, 49);
            this.gBoxCONTROL.Name = "gBoxCONTROL";
            this.gBoxCONTROL.Size = new System.Drawing.Size(260, 408);
            this.gBoxCONTROL.TabIndex = 0;
            this.gBoxCONTROL.Text = "Control";
            // 
            // btnREFRESH
            // 
            this.btnREFRESH.AutoRoundedCorners = true;
            this.btnREFRESH.BackColor = System.Drawing.Color.Transparent;
            this.btnREFRESH.BorderRadius = 24;
            this.btnREFRESH.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnREFRESH.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnREFRESH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnREFRESH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnREFRESH.FillColor = System.Drawing.Color.NavajoWhite;
            this.btnREFRESH.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnREFRESH.ForeColor = System.Drawing.Color.Black;
            this.btnREFRESH.Location = new System.Drawing.Point(44, 197);
            this.btnREFRESH.Name = "btnREFRESH";
            this.btnREFRESH.Size = new System.Drawing.Size(178, 51);
            this.btnREFRESH.TabIndex = 1;
            this.btnREFRESH.Text = "REFRESH";
            this.btnREFRESH.Click += new System.EventHandler(this.btnREFRESH_Click);
            // 
            // pBarSTATUS
            // 
            this.pBarSTATUS.AutoRoundedCorners = true;
            this.pBarSTATUS.BackColor = System.Drawing.Color.Transparent;
            this.pBarSTATUS.BorderRadius = 20;
            this.pBarSTATUS.Location = new System.Drawing.Point(20, 323);
            this.pBarSTATUS.Name = "pBarSTATUS";
            this.pBarSTATUS.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            this.pBarSTATUS.ProgressColor = System.Drawing.Color.SkyBlue;
            this.pBarSTATUS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pBarSTATUS.Size = new System.Drawing.Size(223, 43);
            this.pBarSTATUS.TabIndex = 2;
            this.pBarSTATUS.Text = "guna2ProgressBar1";
            this.pBarSTATUS.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnSTOP
            // 
            this.btnSTOP.AutoRoundedCorners = true;
            this.btnSTOP.BackColor = System.Drawing.Color.Transparent;
            this.btnSTOP.BorderRadius = 24;
            this.btnSTOP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSTOP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSTOP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSTOP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSTOP.FillColor = System.Drawing.Color.LightSlateGray;
            this.btnSTOP.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTOP.ForeColor = System.Drawing.Color.White;
            this.btnSTOP.Location = new System.Drawing.Point(44, 134);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(178, 51);
            this.btnSTOP.TabIndex = 1;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // btnSTART
            // 
            this.btnSTART.AutoRoundedCorners = true;
            this.btnSTART.BackColor = System.Drawing.Color.Transparent;
            this.btnSTART.BorderRadius = 24;
            this.btnSTART.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSTART.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSTART.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSTART.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSTART.FillColor = System.Drawing.Color.LightSlateGray;
            this.btnSTART.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTART.ForeColor = System.Drawing.Color.White;
            this.btnSTART.Location = new System.Drawing.Point(44, 71);
            this.btnSTART.Name = "btnSTART";
            this.btnSTART.Size = new System.Drawing.Size(178, 51);
            this.btnSTART.TabIndex = 0;
            this.btnSTART.Text = "START";
            this.btnSTART.Click += new System.EventHandler(this.btnSTART_Click);
            // 
            // serialUSB
            // 
            this.serialUSB.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialUSB_DataReceived);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkCyan;
            this.button1.Location = new System.Drawing.Point(782, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click); 
            // 
            // connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBoxCONTROL);
            this.Controls.Add(this.gBoxCONNECTION);
            this.Name = "connection";
            this.Size = new System.Drawing.Size(1250, 531);
            this.Load += new System.EventHandler(this.connection_Load);
            this.gBoxCONNECTION.ResumeLayout(false);
            this.gBoxCONNECTION.PerformLayout();
            this.gBoxCONTROL.ResumeLayout(false);
            this.gBoxCONTROL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gBoxCONNECTION;
        private Guna.UI2.WinForms.Guna2ComboBox cBoxSTOPBITS;
        private Guna.UI2.WinForms.Guna2ComboBox cBoxPARITYBITS;
        private Guna.UI2.WinForms.Guna2ComboBox cBoxDATABITS;
        private Guna.UI2.WinForms.Guna2ComboBox cBoxBAUDRATE;
        private Guna.UI2.WinForms.Guna2GroupBox gBoxCONTROL;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbSTOPBITS;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbPARITYBITS;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbDATABITS;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbCOMBOX;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbBAURATE;
        private Guna.UI2.WinForms.Guna2Button btnSTOP;
        private Guna.UI2.WinForms.Guna2Button btnSTART;
        public System.IO.Ports.SerialPort serialUSB;
        private Guna.UI2.WinForms.Guna2ComboBox cBoxCOMPORTS;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbSTATUS;
        public Guna.UI2.WinForms.Guna2ProgressBar pBarSTATUS;
        private Guna.UI2.WinForms.Guna2Button btnREFRESH;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
    }
}
