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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Management;

namespace COF_MACHINE.User_Controller
{
    public partial class connection : UserControl
    {
        //public string SpeedRecieve;
        public string DataRecieve;
        public string SpeedRecieve;
        public string COFSpeed;
        public string COFD;
        public int HomeState;
        public float SF;
        public float KF;
        public float StdDev;
        public int PosLegend = 0;


        private static connection connectioninstance; //singleton solution
        public static connection Connectioninstance
        {
            get
            {
                if (connectioninstance == null) connectioninstance = new connection();
                return connection.connectioninstance;
            }
            set
            {
                connection.Connectioninstance = value;
            }
        }
        public delegate void Stopstate(bool _bool);
        public event Stopstate stopvent;
        public connection()
        {
            InitializeComponent();

        }
        public delegate void deleset(bool _bool);
        public event deleset delevent;
        private void connection_Load(object sender, EventArgs e)
        {

            if (!serialUSB.IsOpen)
            {
                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    cBoxCOMPORTS.Items.Add(port);
                }
                cBoxCOMPORTS.StartIndex = 7;
            }

        }


        private void btnSTART_Click(object sender, EventArgs e)
        {
            try
            {
                serialUSB.PortName = cBoxCOMPORTS.Text;
                serialUSB.BaudRate = Convert.ToInt32(cBoxBAUDRATE.Text); // Do combox.text dang o dinh dang string --> chuyen sang int
                serialUSB.DataBits = Convert.ToInt32(cBoxDATABITS.Text);
                serialUSB.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxPARITYBITS.Text);
                serialUSB.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxSTOPBITS.Text);


                serialUSB.Open();


                if (serialUSB.IsOpen)
                {
                    DataRecieve = "/0";
                    serialUSB.Write("I");
                    pBarSTATUS.Value = 100;
                    lbSTATUS.BackColor = Color.SkyBlue;

                }
                if (!serialUSB.IsOpen)
                {
                    pBarSTATUS.Value = 0;
                }
            }
            catch (Exception err)

            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSTOP_Click(object sender, EventArgs e)
        {
            if (serialUSB.IsOpen)
            {
                serialUSB.Close();

                //Form1.Form1Instance.btnCOATING.Enabled = false;
                //Form1.Form1Instance.btnCOF.Enabled = false;
                //Form1.Form1Instance.btnRESULT.Enabled = false;

                pBarSTATUS.Value = 0;
                lbSTATUS.BackColor = System.Drawing.ColorTranslator.FromHtml("#D5DADF");
            }
            else if (!serialUSB.IsOpen)
            {
                MessageBox.Show("Serial has already closed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void serialUSB_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataRecieve = serialUSB.ReadExisting(); // Đọc dữ liệu nhận được từ cổng COM            

            this.Invoke(new EventHandler(DataCallBack));

            // Process received data
        }

        //
        // Hàm dùng để trả về các giá trị ban đầu từ máy COF sang winform
        //
        public void DataCallBack(object sender, EventArgs e)
        {

            //coating.Coatinginstance.tBoxSPEED.Text;
            if (DataRecieve[0] == 'L') // L = loading
            {
                // Nhận dữ liệu Speed
                string charArray;// chuyển  string thành array để có thể modify
                charArray = string.Concat(DataRecieve[1], DataRecieve[2], DataRecieve[3], DataRecieve[4]);
                int result = Convert.ToInt32(charArray, 16); // Chuyển Hex sang numberic int                            
                coating.Coatinginstance.tBoxSPEED.Text = result.ToString();

                // Nhận dữ liệu COFSpeed
                charArray = string.Concat(DataRecieve[5], DataRecieve[6], DataRecieve[7], DataRecieve[8]);
                result = Convert.ToInt32(charArray, 16);
                submit.SubmitInstance.cBoxCOFSPEED.Text = result.ToString();

                // Nhận dữ liệu COFDistance
                charArray = string.Concat(DataRecieve[9], DataRecieve[10], DataRecieve[11], DataRecieve[12]);
                result = Convert.ToInt32(charArray, 16);
                submit.SubmitInstance.cBoxCOFDISTANCE.Text = result.ToString();
                // Nhận dữ liệu COFBeing_Home
                charArray = string.Concat(DataRecieve[13], DataRecieve[14], DataRecieve[15], DataRecieve[16]);
                result = Convert.ToInt32(charArray, 16);
                if (result == 1) HomeState = 1;
                else if (result == 0) HomeState = 0;

            }
            if (DataRecieve[0] == 'S') // S = Status
            {
                if (DataRecieve[1] == 'H') // H = Home ?
                {
                    if (DataRecieve[2] == '1')
                    {
                        COF.COFinstance.btnRUN.Enabled = true;
                        COF.COFinstance.btnSTOP.Enabled = false;
                        COF.COFinstance.btnSETHOME.Enabled = false;
                        HomeState = 1;
                    }    
                        
                    if (DataRecieve[2] == '0') HomeState = 0;
                }
                if (DataRecieve[1] == 'I') // I = Index
                {
                    //COF.COFinstance.btnRUN.PerformClick();
                    COF.COFinstance.idx = COF.COFinstance.idx + 1;
                    COF.COFinstance.chartCOF.Series.Add(COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF"));
           
                    COF.COFinstance.chartCOF.Series[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].ChartType = SeriesChartType.Line;               
                    COF.COFinstance.chartCOF.Legends.Add(COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF"));

                    COF.COFinstance.chartCOF.Legends[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].Position.Auto = true;
                    



                    COF.COFinstance.chartCOF.Legends[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].BackColor = Color.Transparent;
                    COF.COFinstance.chartCOF.Legends[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].Docking = Docking.Left;
                    COF.COFinstance.chartCOF.Legends[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].IsDockedInsideChartArea = true;
                    COF.COFinstance.chartCOF.Legends[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].Position.Auto = true;

                    float x = 20f;
                    float y = 10f;
                    COF.COFinstance.chartCOF.Legends[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].Position.X = x;
                    COF.COFinstance.chartCOF.Legends[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].Position.Y = y;
                    COF.COFinstance.chartCOF.Legends[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].Position.Width = 80f;
                    COF.COFinstance.chartCOF.Legends[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].Position.Height = 10f;
                }

                if (DataRecieve[1] == 'S') //trạng thái hoạt động của công tắc hành trình trên tab Coating
                {
                    stopvent(true); // cong tac hành trình trên máy COF đang được kích hoạt

                }
            }
            if (DataRecieve[0] == 'R') // R = Run
            {
                //COF.COFinstance.btnSAVE.Enabled = false;
                string charArray;// chuyển  string thành array để có thể modify
                charArray = string.Concat(DataRecieve[1], DataRecieve[2], DataRecieve[3], DataRecieve[4]);
                float result = Convert.ToInt32(charArray, 16); // Chuyển Hex sang numberic int
                COF.COFinstance.btnSAVE.Enabled = false;
                COF.COFinstance.btnNEW.Enabled = false;
                COF.COFinstance.btnRUN.Enabled = false;
                delevent(false);              
                COF.COFinstance.chartCOF.Series[COF.COFinstance.SeriesName(COF.COFinstance.idx, "COF")].Points.AddY((result / 200) / 100);
                    
                
              
                DataRecieve = "/0";


            }
            if (DataRecieve[0] == 'O') //O = Output
            {
                string charArray;// chuyển  string thành array để có thể modify
                charArray = string.Concat(DataRecieve[1], DataRecieve[2], DataRecieve[3], DataRecieve[4]);
                float result = Convert.ToInt32(charArray, 16); // Chuyển Hex sang numberic int                            
                SF = result / 1000;

                // Nhận dữ liệu COFSpeed
                charArray = string.Concat(DataRecieve[5], DataRecieve[6], DataRecieve[7], DataRecieve[8]);
                result = Convert.ToInt32(charArray, 16);
                KF = result / 1000;

                // Nhận dữ liệu COFDistance
                charArray = string.Concat(DataRecieve[9], DataRecieve[10], DataRecieve[11], DataRecieve[12]);
                result = Convert.ToInt32(charArray, 16);
                StdDev = result / 100;

                if(COF.COFinstance.AutoSave)
                {

                    COF.COFinstance.SaveToTable(true);

                    COF.COFinstance.btnNEW.Enabled = true;
                    COF.COFinstance.btnSETHOME.Enabled = true;
                    COF.COFinstance.savesate = true;

                    COF.COFinstance.timer1.Start();
                    COF.COFinstance.tboxNOTICE.Enabled = true;                   
                    COF.COFinstance.tboxNOTICE.Text = "Saved";

                }
                else
                {
                    COF.COFinstance.btnNEW.Enabled = true;
                    COF.COFinstance.btnSAVE.Enabled = true;
                    COF.COFinstance.btnSETHOME.Enabled = true;

                }
                delevent(true);

            }


        }
        private string FindMicrocontrollerDevice() // Tìm tên của Port trùng với name driver "STMicroelectronics Virtual COM Port"
        {
            string deviceName = "";
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
            {
                collection = searcher.Get();
            }

            foreach (var device in collection)
            {
                if (device != null && device["Name"] != null && (device["Name"].ToString().Contains("STMicroelectronics Virtual COM Port") || device["Name"].ToString().Contains("USB Serial Device"))  )              
                    {
                    deviceName = device["Name"].ToString();
                    break;
                }
            }

            return deviceName;
        }
        private void btnREFRESH_Click(object sender, EventArgs e)
        {
            if (!serialUSB.IsOpen)
            {
                cBoxCOMPORTS.Items.Clear();
                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    cBoxCOMPORTS.Items.Add(port);
                }
                string deviceName = FindMicrocontrollerDevice();
                if (!string.IsNullOrEmpty(deviceName))
                {
                    serialUSB.PortName = deviceName.Substring(deviceName.IndexOf("(COM")).Replace("(", string.Empty).Replace(")", string.Empty);
                    cBoxCOMPORTS.Text = serialUSB.PortName;
                }
            }
            else { MessageBox.Show("Port is still Opened", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string help = "1. press REFRESH button to automatically find\n   available port for SERIAL connection.\r\n2. Press START button to connect to SERIAL\n   port.\r\n3. If you want to disconnect with SERIAL\n     port, PRESS STOP\r\n4. STATUS bar will turn blue in case\n     successfull.\r\n" ;
            toolTip1.Show(help,gBoxCONTROL,300,70);
        }
    }
    
}

