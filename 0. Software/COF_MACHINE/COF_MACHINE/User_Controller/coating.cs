using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COF_MACHINE.User_Controller
{
    public partial class coating : UserControl
    {
        String[] TxData = new string[8];
        private static coating coatinginstance;
        public static coating Coatinginstance
        {
            get
            {
                if (coatinginstance == null) coatinginstance = new coating();
                return coating.coatinginstance;     
            }
            set
            {
                if (coatinginstance == null)  coating.coatinginstance = value;
            }
        }
        public coating()
        {
            InitializeComponent();
            tBoxSPEED.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) btnSPEEDSET.PerformClick(); };
        }
        public delegate void Runstate(bool _bool);
        public event Runstate Runvent;
        private void btnRUNFWD_Click(object sender, EventArgs e)
        {
            if(connection.Connectioninstance.serialUSB.IsOpen)
            {
                Runvent(false);
                TxData[0] = "H";
                TxData[1] = "1";
                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
                TxData[0] = "F";
                TxData[1] = "1";
                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
            }
            else
            {
                MessageBox.Show("Check your Serial Connection !!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnRUNBWD_Click(object sender, EventArgs e)
        {
            if (connection.Connectioninstance.serialUSB.IsOpen)
            {
                Runvent(false);
                TxData[0] = "H";
                TxData[1] = "1";
                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
                TxData[0] = "F";
                TxData[1] = "2";
                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
            }
            else
            {
                MessageBox.Show("Check your Serial Connection !!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSTOP_Click(object sender, EventArgs e)
        {
            if (connection.Connectioninstance.serialUSB.IsOpen)
            {
                Runvent(true);
                TxData[0] = "H";
                TxData[1] = "1";
                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
                TxData[0] = "F";
                TxData[1] = "3";
                connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + TxData[2] + TxData[3] + TxData[4] + TxData[5] + TxData[6] + TxData[7]);
            }
            else
            {
                MessageBox.Show("Check your Serial Connection !!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSPEEDSET_Click(object sender, EventArgs e)
        {
            if (connection.Connectioninstance.serialUSB.IsOpen)
            {
                string numSpeed = tBoxSPEED.Text;
                int result;

                TxData[0] = "S";
                TxData[1] = "S";

                if (int.TryParse(numSpeed, out result))
                {
                    if(result >= 100 && result <= 4000)
                    {
                        
                        connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + result.ToString());
                        TxData[0] = "\0";
                        TxData[1] = "\0";
                    }
                    else 
                    {
                        MessageBox.Show("typing number within 100 to 4000 !!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    // use the integer value in some way
                    
                }
                else
                {
                    // handle the case where the input is not a valid integer
                    MessageBox.Show("Number only !!");
                }
         
            }
        }
    }
}
