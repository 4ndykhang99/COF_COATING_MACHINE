namespace COF_MACHINE.User_Controller
{
    partial class result
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
            this.listViewRESULT = new System.Windows.Forms.ListView();
            this.colNO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSAMPLE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNOTE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLOT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSTDDEV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDATETIME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctexMENU = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctexMENU.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewRESULT
            // 
            this.listViewRESULT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNO,
            this.colSAMPLE,
            this.colNOTE,
            this.colLOT,
            this.colSF,
            this.colKF,
            this.colSTDDEV,
            this.colDATETIME});
            this.listViewRESULT.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewRESULT.FullRowSelect = true;
            this.listViewRESULT.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewRESULT.HideSelection = false;
            this.listViewRESULT.Location = new System.Drawing.Point(16, 12);
            this.listViewRESULT.Name = "listViewRESULT";
            this.listViewRESULT.Size = new System.Drawing.Size(1212, 501);
            this.listViewRESULT.TabIndex = 0;
            this.listViewRESULT.UseCompatibleStateImageBehavior = false;
            this.listViewRESULT.View = System.Windows.Forms.View.Details;
            // 
            // colNO
            // 
            this.colNO.Text = "NO.";
            this.colNO.Width = 52;
            // 
            // colSAMPLE
            // 
            this.colSAMPLE.Text = "SAMPLE";
            this.colSAMPLE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSAMPLE.Width = 120;
            // 
            // colNOTE
            // 
            this.colNOTE.Text = "NOTE";
            this.colNOTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNOTE.Width = 85;
            // 
            // colLOT
            // 
            this.colLOT.Text = "LoT";
            this.colLOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colSF
            // 
            this.colSF.Text = "SF";
            this.colSF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colKF
            // 
            this.colKF.Text = "KF";
            this.colKF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colSTDDEV
            // 
            this.colSTDDEV.Text = "Std_Dev";
            this.colSTDDEV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colDATETIME
            // 
            this.colDATETIME.Text = "TIME";
            this.colDATETIME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDATETIME.Width = 100;
            // 
            // ctexMENU
            // 
            this.ctexMENU.AllowDrop = true;
            this.ctexMENU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.ctexMENU.Name = "ctexMENU";
            this.ctexMENU.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.ctexMENU.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.ctexMENU.RenderStyle.ColorTable = null;
            this.ctexMENU.RenderStyle.RoundedEdges = true;
            this.ctexMENU.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.ctexMENU.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.ctexMENU.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.ctexMENU.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.ctexMENU.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ctexMENU.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewRESULT);
            this.Name = "result";
            this.Size = new System.Drawing.Size(1250, 531);
            this.Load += new System.EventHandler(this.result_Load);
            this.ctexMENU.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ListView listViewRESULT;
        public System.Windows.Forms.ColumnHeader colNO;
        public System.Windows.Forms.ColumnHeader colSAMPLE;
        public System.Windows.Forms.ColumnHeader colNOTE;
        public System.Windows.Forms.ColumnHeader colLOT;
        public System.Windows.Forms.ColumnHeader colSF;
        public System.Windows.Forms.ColumnHeader colKF;
        public System.Windows.Forms.ColumnHeader colSTDDEV;
        public Guna.UI2.WinForms.Guna2ContextMenuStrip ctexMENU;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colDATETIME;
    }
}
