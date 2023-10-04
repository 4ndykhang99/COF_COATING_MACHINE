using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COF_MACHINE.User_Controller
{
    public partial class submit : UserControl
    {
        private static submit submitinstance;
        public static submit SubmitInstance
        {
            get
            {
                if (submitinstance == null) submitinstance = new submit();
                return submit.submitinstance;
            }
            set
            {
                submit.submitinstance = value;
            }
        }
        public delegate void ShowCOF();
        public event ShowCOF ShowCOFvent;

        String[] TxData = new string[8];
        public submit()
        {
            InitializeComponent();
        }

        private void btnSUBMIT_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tBoxOPERATOR.Text))
            {
               toolTip1.Show("Operator cannot be empty", tBoxOPERATOR, 130, 5, 2000);
            }   
            else
            {
                if (connection.Connectioninstance.serialUSB.IsOpen)
                {
                    string hexCOFSpeed ;
                    string hexCOFDistance ;
                    int result;
                    int result2;
                    

                    TxData[0] = "S";
                    TxData[1] = "C";

                    if (int.TryParse(cBoxCOFSPEED.Text, out result))
                    {
                        if(int.TryParse(cBoxCOFDISTANCE.Text, out result2))
                        {
                            hexCOFSpeed = result.ToString("X4");
                            hexCOFDistance = result2.ToString("X4");

                            connection.Connectioninstance.serialUSB.Write(TxData[0] + TxData[1] + hexCOFSpeed + hexCOFDistance);
                        }                           
                    }


                }
                ShowCOFvent();
            }    
            
        }

        private void gBoxINITINFO_Click(object sender, EventArgs e)
        {

        }

        private void tBoxTEMP_TextChanged(object sender, EventArgs e)
        {
            int number;
            bool isNumberric = int.TryParse(tBoxTEMP.Text, out number);
            
            if (isNumberric)
            {

            }   
            else if (!isNumberric)
            {
                tBoxTEMP.Text = "";
                toolTip1.Show("Number only", tBoxTEMP, 130, 30, 2000);
            }    

            
        }

        private void tBoxHUMIDITY_TextChanged(object sender, EventArgs e)
        {
            int number;
            bool isNumberric = int.TryParse(tBoxHUMIDITY.Text, out number);

            if (isNumberric)
            {

            }
            else if (!isNumberric)
            {
                tBoxHUMIDITY.Text = "";
                toolTip1.Show("Number only", tBoxHUMIDITY, 130, 30, 2000);
            }


        }
    }
    
}
