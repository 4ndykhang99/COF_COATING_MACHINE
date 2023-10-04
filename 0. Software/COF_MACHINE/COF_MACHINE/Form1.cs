using COF_MACHINE.User_Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.Common;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.DataVisualization.Charting;
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;


namespace COF_MACHINE
{
    public partial class Form1 : Form
    {
        string[] TxData = new string[8];
        public bool initInfo = false;
        private static Form1 Form1instance;       
        public static Form1 Form1Instance       
        { 
            get 
            { 
                if (Form1instance == null) Form1instance = new Form1(); 
                return Form1.Form1instance; 
            } 
            set 
            {                
                Form1.Form1instance = value; 
            } 
        }

        //public static Form1 instance
        //{
        //    get { if (instance == null) instance = new Form1(); return Form1.instance; }
        //    public set { Form1.instance = value; }
        //}
        
        public Form1()
        {            
            
            InitializeComponent();
            addUserControl(connection.Connectioninstance);
            //btnCOATING.Enabled = false;      
            //btnCOF.Enabled = false;
            //btnRESULT.Enabled = false;
            //if(connection.Connectioninstance.serialUSB.IsOpen)
            //{
            //    btnCOATING.Enabled = true;
            //    btnCOF.Enabled = true;
            //    btnRESULT.Enabled = true;
            //}
            //else
            //{
            //    btnCOATING.Enabled = false;
            //    btnCOF.Enabled = false;
            //    btnRESULT.Enabled = false;
            //}
            connection.Connectioninstance.delevent += COF_delevent;
            coating.Coatinginstance.Runvent += Runstate;
            connection.Connectioninstance.stopvent += Stopstate;
            submit.SubmitInstance.ShowCOFvent += ShowCOF;
            COF.COFinstance.COFvent += OpenSubmit;
        }

        private void OpenSubmit()
        {
            addUserControl(submit.SubmitInstance);
            initInfo = false;
        }

        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelCONTAINER.Controls.Clear();
            panelCONTAINER.Controls.Add(userControl);
            userControl.BringToFront();
        }

        public void btnCONNECTION_Click(object sender, EventArgs e)
        {
            addUserControl(connection.Connectioninstance);
            btnPDF.Visible = false;
        }

        private void btnCOATING_Click(object sender, EventArgs e)
        {       
            
            if (connection.Connectioninstance.serialUSB.IsOpen)
            {
                addUserControl(coating.Coatinginstance);
                btnPDF.Visible = false;
                TxData[0] = "H";
                TxData[1] = "1";
                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
            }
            else
            {
                MessageBox.Show("Check your Serial Connection !!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCOF_Click(object sender, EventArgs e)
        {
            
            
            if (connection.Connectioninstance.serialUSB.IsOpen)
            {
                if (initInfo == false)
                {
                    addUserControl(submit.SubmitInstance);
                }
                else if (initInfo == true)
                {
                    addUserControl(COF.COFinstance);
                    btnPDF.Visible = false;
                    COF.COFinstance.chartCOF.ChartAreas["ChartArea1"].AxisY.Title = "COF";
                    COF.COFinstance.chartCOF.ChartAreas["ChartArea1"].AxisX.Title = "Time";
                    TxData[0] = "H";
                    TxData[1] = "2";
                    connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
                }
                                             
            }
            else 
            {
                MessageBox.Show("Check your Serial Connection !!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnRESULT_Click(object sender, EventArgs e)
        {
            addUserControl(result.ResultInstance);
            btnPDF.Visible = true;
        }
        private void COF_delevent(bool _bool)
        {
            btnCOATING.Enabled = _bool;
        }
        private void Runstate(bool _bool)
        {
            btnCOF.Enabled = _bool;
        }
        private void Stopstate(bool _bool)
        {
            btnCOF.Enabled = _bool;
        }
        private void ShowCOF()
        {
            initInfo = true;
            addUserControl(COF.COFinstance);
            btnPDF.Visible = false;
            COF.COFinstance.chartCOF.ChartAreas["ChartArea1"].AxisY.Title = "COF";
            COF.COFinstance.chartCOF.ChartAreas["ChartArea1"].AxisX.Title = "Time (s)";
            TxData[0] = "H";
            TxData[1] = "2";
            connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            result.ResultInstance.PDF_Save(sender,e);
        }
    }
}
