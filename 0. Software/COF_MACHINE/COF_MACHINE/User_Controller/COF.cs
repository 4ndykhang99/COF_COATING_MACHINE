using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TheArtOfDevHtmlRenderer.Adapters;

namespace COF_MACHINE.User_Controller
{
    public partial class COF : UserControl
    {
        String[] TxData = new string[8];
        public int idx = 0;
        public bool savesate = true;
        public bool AutoSave = false;
        public string seriesname;
        public string TestDate;
        public string TestDT;

        private static COF cofinstance;
        public static COF COFinstance
        {
            get
            {
                if (cofinstance == null) cofinstance = new COF();
                return COF.cofinstance;
            }
            set
            {
                COF.cofinstance = value;
            }
        }
        public COF()
        {
            InitializeComponent();

            chartCOF.Width = 800;
            chartCOF.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Number;
            chartCOF.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chartCOF.ChartAreas["ChartArea1"].AxisX.Maximum = 3000;
            chartCOF.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            chartCOF.ChartAreas["ChartArea1"].AxisY.Maximum = 1;
            chartCOF.ChartAreas["ChartArea1"].AxisX.Interval = 200;
            chartCOF.ChartAreas["ChartArea1"].AxisY.Interval = 0.1;
            chartCOF.ChartAreas["ChartArea1"].AxisX.LineColor = Color.LightGray;
            chartCOF.ChartAreas["ChartArea1"].AxisY.LineColor = Color.LightGray;
            chartCOF.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartCOF.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chartCOF.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.LightGray;
            chartCOF.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;
            chartCOF.Series.Add(SeriesName(0, "initial"));
            chartCOF.Series["initial0"].Points.AddXY(0, 0);
            chartCOF.Series["initial0"].IsVisibleInLegend = false;

            btnSAVE.Enabled = false;
            btnSTOP.Enabled = false;



        }
        public delegate void COFdeligate();
        public event COFdeligate COFvent;

        private void btnSETHOME_Click(object sender, EventArgs e)
        {
            if (connection.Connectioninstance.serialUSB.IsOpen)
            {
                if (connection.Connectioninstance.HomeState == 1)
                {
                    MessageBox.Show("You have already at Home and able to run COF now ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (connection.Connectioninstance.HomeState == 0)
                {
                    btnSTOP.Enabled = true;
                    btnSETHOME.Enabled = false;
                    TxData[0] = "H";
                    TxData[1] = "3";
                    connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
                    TxData[0] = "F";
                    TxData[1] = "1";
                    connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
                    btnRUN.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Complete the connection first", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void btnRUN_Click(object sender, EventArgs e)
        {

            if (connection.Connectioninstance.serialUSB.IsOpen)
            {
                if (connection.Connectioninstance.HomeState == 1)
                {
                    if (string.IsNullOrEmpty(tBoxNAME.Text) || string.IsNullOrEmpty(tBoxLOT.Text))
                    {
                        if (string.IsNullOrEmpty(tBoxNAME.Text)) toolTip1.Show("SampleName cannot be empty", tBoxNAME, 130, 10, 2000);
                        if (string.IsNullOrEmpty(tBoxLOT.Text)) toolTip3.Show("LoT cannot be empty", tBoxLOT, 130, 10, 2000);
                    }
                    else
                    {
                        if (!savesate) //Nếu dữ liệu trước đo chưa được lưu, sẽ có bảng thông báo được đẩy lên !
                        {
                            DialogResult result = MessageBox.Show("Your previous Data have not saved Yet, keep going ?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK) // NẾu bấm ok trong bảng thông báo, chương trình sẽ chạy mà không lưu dữ liệu cũ.
                            {
                                DateTime date = DateTime.Now;
                                TestDate = date.ToShortDateString();
                                TestDT = date.ToString("yyyy-MM-dd HH:mm:ss");

                                TxData[0] = "H";
                                TxData[1] = "3";
                                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
                                TxData[0] = "F";
                                TxData[1] = "2";
                                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);

                                savesate = false;
                            }
                        }
                        else if (savesate) // nếu bấm run mà dữ liệu đã được lưu, run bình thường.
                        {
                            btnSTOP.Enabled = true;
                            btnSETHOME.Enabled = false;
                            DateTime date = DateTime.Now;

                            TestDate = date.ToShortDateString();
                            TestDT = date.ToString("dd-MM-yy HH:mm:ss");

                            TxData[0] = "H";
                            TxData[1] = "3";
                            connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
                            TxData[0] = "F";
                            TxData[1] = "2";
                            connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);

                            savesate = false;
                        }

                    }


                }
                else if (connection.Connectioninstance.HomeState == 0)
                {
                    MessageBox.Show("Set Home First", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            else
            {
                MessageBox.Show("Complete the connection first", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSTOP_Click(object sender, EventArgs e)
        {
            if (connection.Connectioninstance.serialUSB.IsOpen)
            {
                btnSTOP.Enabled = false;
                btnSETHOME.Enabled = true;
                TxData[0] = "H";
                TxData[1] = "3";
                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
                TxData[0] = "F";
                TxData[1] = "3";
                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
                TxData[0] = "H";
                TxData[1] = "3";
                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
            }
            else
            {
                MessageBox.Show("Complete the connection first", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string SeriesName(int idx, string name)
        {
            string index = idx.ToString();
            string seriesname = string.Concat(name + index);
            return seriesname;
        }

        //SAVE
        public void btnSAVE_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tBoxNAME.Text) || string.IsNullOrEmpty(tBoxLOT.Text))
            {
                if (string.IsNullOrEmpty(tBoxNAME.Text)) toolTip1.Show("SampleName cannot be empty", tBoxNAME, 130, 10, 2000);
                if (string.IsNullOrEmpty(tBoxLOT.Text)) toolTip3.Show("LoT cannot be empty", tBoxLOT, 130, 10, 2000);
            }
            else if (!savesate)
            {
                SaveToTable(true);
            }

            else { MessageBox.Show("You have already saved this result !", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning); }


        }

        private void timer1_Tick(object sender, EventArgs e) // sự kiện khi timer 1 off 
        {
            timer1.Stop();
            tboxNOTICE.Enabled = false;
        }

        private void chartCOF_Click(object sender, EventArgs e)
        {

        }
        // create new profile, delete all tested data
        private void btnNEW_Click(object sender, EventArgs e)
        {            
                DialogResult result = MessageBox.Show("This action will Delete all your Tested Data, keep going ?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) // NẾu bấm ok trong bảng thông báo, chương trình sẽ chạy mà không lưu dữ liệu cũ.
                {
                    idx = 0;
                    savesate = true;
                    ClearData();


                    foreach (var series in chartCOF.Series)
                    {
                        // Đặt lại màu sắc mặc định của dòng
                        series.Color = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    }

                    chartCOF.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Number;
                    chartCOF.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
                    chartCOF.ChartAreas["ChartArea1"].AxisX.Maximum = 3000;
                    chartCOF.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
                    chartCOF.ChartAreas["ChartArea1"].AxisY.Maximum = 1;
                    chartCOF.ChartAreas["ChartArea1"].AxisX.Interval = 200;
                    chartCOF.ChartAreas["ChartArea1"].AxisY.Interval = 0.1;
                    chartCOF.ChartAreas["ChartArea1"].AxisX.LineColor = Color.LightGray;
                    chartCOF.ChartAreas["ChartArea1"].AxisY.LineColor = Color.LightGray;
                    chartCOF.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightGray;
                    chartCOF.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightGray;
                    chartCOF.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.LightGray;
                    chartCOF.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.LightGray;
                    chartCOF.Series.Add(SeriesName(0, "initial"));
                    chartCOF.Series["initial0"].Points.AddXY(0, 0);
                    chartCOF.Series["initial0"].IsVisibleInLegend = false;

                    COFvent();
                    submit.SubmitInstance.tBoxOPERATOR.Text = "";
                    submit.SubmitInstance.tBoxTEMP.Text = "";
                    submit.SubmitInstance.tBoxHUMIDITY.Text = "";
                    tBoxNAME.Text = tBoxLOT.Text = tBoxNOTE.Text = "";
               
            }
        }
        public void SaveToTable(bool savestate)
        {
            result.ResultInstance.listViewRESULT.Items.Add(SeriesName(idx, "COF"));
            result.ResultInstance.listViewRESULT.Items[result.ResultInstance.listViewRESULT.Items.Count - 1].Font = new Font("Century Gothic", 10, FontStyle.Regular);
            result.ResultInstance.listViewRESULT.Items[result.ResultInstance.listViewRESULT.Items.Count - 1].SubItems.Add(tBoxNAME.Text);
            result.ResultInstance.listViewRESULT.Items[result.ResultInstance.listViewRESULT.Items.Count - 1].SubItems.Add(tBoxNOTE.Text);
            result.ResultInstance.listViewRESULT.Items[result.ResultInstance.listViewRESULT.Items.Count - 1].SubItems.Add(tBoxLOT.Text);
            result.ResultInstance.listViewRESULT.Items[result.ResultInstance.listViewRESULT.Items.Count - 1].SubItems.Add(connection.Connectioninstance.SF.ToString()); ;
            result.ResultInstance.listViewRESULT.Items[result.ResultInstance.listViewRESULT.Items.Count - 1].SubItems.Add(connection.Connectioninstance.KF.ToString());
            result.ResultInstance.listViewRESULT.Items[result.ResultInstance.listViewRESULT.Items.Count - 1].SubItems.Add(connection.Connectioninstance.StdDev.ToString());
            result.ResultInstance.listViewRESULT.Items[result.ResultInstance.listViewRESULT.Items.Count - 1].SubItems.Add(TestDT);

            savesate = savestate;

            timer1.Start();
            tboxNOTICE.Enabled = savestate;
            tboxNOTICE.Text = "Saved";
        }
        private void checkBoxAUTOSAVE_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAUTOSAVE.Checked == true)
            {
                AutoSave = true;

                btnSAVE.Enabled = false;

            }
            else if (checkBoxAUTOSAVE.Checked == false)
            {
                AutoSave = false;
                btnSAVE.Enabled = true;
                if (idx == 0) btnSAVE.Enabled = false;
                else btnSAVE.Enabled = true;
            }

        }

        private void ClearData()
        {
            result.ResultInstance.listViewRESULT.Items.Clear();
            chartCOF.Series.Clear();
            chartCOF.Legends.Clear();
        }
    }
}
