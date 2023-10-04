using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.ObjectModel;
using System.Threading;
using Org.BouncyCastle.Utilities;
using System.Drawing.Text;
using System.Data.Common;
using System.Drawing.Imaging;

namespace COF_MACHINE.User_Controller
{
    public partial class result : UserControl
    {
        private static result resultinstance;
        public static result ResultInstance

        
        {
            get
            {
                if (resultinstance == null) resultinstance = new result();
                return resultinstance;
            }
            set
            {
                result.ResultInstance = value;
            }
        }
        private float Y = 842f;
        private float YR = 842f;
        private float YL = 842f;
        private float X = 596f;
        public result()
        {
            InitializeComponent();
            listViewRESULT.Columns[0].Width = 50;
            listViewRESULT.Columns[1].Width = 200;
            listViewRESULT.Columns[2].Width = 150;
            listViewRESULT.Columns[3].Width = 200;
            listViewRESULT.Columns[4].Width = 80;
            listViewRESULT.Columns[5].Width = 80;
            listViewRESULT.Columns[6].Width = 115;          
            listViewRESULT.Columns[7].Width = 200;


        }
        private void Listview_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (ListViewItem item in listViewRESULT.Items)
                {
                    if (item.Bounds.Contains(new Point(e.X, e.Y))) // kiểm tra con trỏ chuột có nằm trong phạm vi cần chọn hay không
                    {
                        ctexMENU.Show(listViewRESULT,e.X, e.Y);
                    }
                }

            }
        }

        private void result_Load(object sender, EventArgs e)
        {
            listViewRESULT.MouseUp += new MouseEventHandler(Listview_MouseClick);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You are going to remove a COF result, keep going ?","Caution",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if(result == DialogResult.OK)
            {
                if (listViewRESULT.SelectedItems.Count > 0)
                {
                    // Lặp qua các mục đã chọn để xóa
                    for (int i = 0; i < listViewRESULT.SelectedItems.Count; i++)
                    {
                        // Xóa mục khỏi ListView
                        COF.COFinstance.chartCOF.Legends[listViewRESULT.SelectedItems[i].Text].Enabled = false;
                        COF.COFinstance.chartCOF.Series[listViewRESULT.SelectedItems[i].Text].Points.Clear();
                        COF.COFinstance.chartCOF.Series[listViewRESULT.SelectedItems[i].Text]["linelabel"] = "Disabled";
                        listViewRESULT.Items.Remove(listViewRESULT.SelectedItems[i]);
                        
                    }
                    
                }
            }    
            
            
        }
        private void YRcalculate(float f)
        {

        }

        public void PDF_Save(object sender, EventArgs e)
        {
           float Y = 842f;
           float YR = 842f;
           float YL = 842f;
           float X = 596f;
            if(listViewRESULT.Items.Count > 0)
            {
                DateTime date = DateTime.Now;
                
                string TestDT = date.ToString("yyyyMMdd");

                SaveFileDialog save = new SaveFileDialog();
                
                save.Filter = "PDF (*.PDF)|*.PDF";
                save.FileName = TestDT+"_COFResult.pdf";
                bool erroMessage = false;
                if(save.ShowDialog() == DialogResult.OK)
                {
                    if(File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            erroMessage = true;
                            MessageBox.Show("không thể lưu");
                        }
                    }    
                    if(!erroMessage)
                    {
                        try 
                        {
                          

                            PdfPTable pdfPTable = new PdfPTable(listViewRESULT.Columns.Count);
                            pdfPTable.DefaultCell.Padding = 2;
                            pdfPTable.WidthPercentage = 100;
                            pdfPTable.HorizontalAlignment = Element.ALIGN_CENTER;
                            foreach (ColumnHeader column in listViewRESULT.Columns)
                            {
                                BaseFont customfont = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                                //BaseFont customfont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.EMBEDDED);
                                iTextSharp.text.Font font = new iTextSharp.text.Font(customfont, 8, iTextSharp.text.Font.BOLD);


                                PdfPCell pdfPCell = new PdfPCell(new Phrase(column.Text,font));
                             

                                int count = listViewRESULT.Columns.Count;
                                float[] columnWidths = new float[count];
                                for (int i = 0; i < count; i++)
                                {
                                    if (i == 0) // NO.
                                    {
                                        columnWidths[i] = 15f;
                                    }
                                    else if (i == 1) // Name
                                    {
                                        columnWidths[i] = 40f;
                                    }
                                    else if (i == 2) //NOTE
                                    {
                                        columnWidths[i] = 40f;
                                    }
                                    else if (i == 3) // LoT
                                    {
                                        columnWidths[i] = 40f;
                                    }
                                    else if (i == 4 || i == 5 || i == 6) //Result
                                    {
                                        columnWidths[i] = 15f;
                                    } 
                                    else if (i == 7) // Username
                                    {
                                        columnWidths[i] = 15f;
                                    }
                                    else //Date
                                    {
                                        columnWidths[i] = 30f;
                                    }
                                }

                                pdfPTable.SetWidths(columnWidths);
                                
                                pdfPTable.AddCell(pdfPCell);
                            }
                            foreach (ListViewItem item in listViewRESULT.Items)
                            {
                                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                                {
                                    //BaseFont customfont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.EMBEDDED);
                                    BaseFont customfont = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                                    iTextSharp.text.Font font = new iTextSharp.text.Font(customfont, 8);

                                    PdfPCell pdfsubitem = new PdfPCell(new Phrase(subItem.Text, font));

                                    pdfPTable.AddCell(pdfsubitem);
                                }
                            }


                            string textHEADER = "MYLAN GROUP";
                            string textHEADER1 = "Longduc Industrial Park";
                            string textHEADER2 = "Travinh City, Travinh Province, Vietnam";
                            string textHEADER3 = "Tel : +84 294 3846 997 – ext: 3501";
                            string textHEADER4 = "Fax: +84 294 3846 998";

                            //LEFT
                            string textINFOLEFT1 = "OPERATOR:";
                            string textINFOLEFT2 = "DATE:";

                            string textINFOLEFT3 = submit.SubmitInstance.tBoxOPERATOR.Text;
                            string textINFOLEFT4 = COF.COFinstance.TestDate;


                            //RIGHT
                            string textINFORIGHT1 = "COF SPEED:";
                            string textINFORIGHT2 = "COF DISTANCE:";
                            string textINFORIGHT3 = "TEMPERATURE:";
                            string textINFORIGHT4 = "HUMIDITY:";
                            string textINFORIGHT5 = "COF METHOD:";

                            string textINFORIGHT6 = submit.SubmitInstance.cBoxCOFSPEED.Text + " mm/min";
                            string textINFORIGHT7 = submit.SubmitInstance.cBoxCOFDISTANCE.Text + " mm";
                            string textINFORIGHT8 = submit.SubmitInstance.tBoxTEMP.Text + " C";
                            string textINFORIGHT9 = submit.SubmitInstance.tBoxHUMIDITY.Text + " %";
                            string textINFORIGHT10 = "1";


                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                
                                
                                
                                

                                pdfPTable.TotalWidth = 580f;
                                pdfPTable.LockedWidth = true;
                                Document document = new Document(PageSize.A4, 2f, 2f, 2f, 2f);
                                PdfWriter write = PdfWriter.GetInstance(document, fileStream);
                                
                                document.Open();
                                PdfContentByte cb = write.DirectContent;

                                BaseFont bf = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                                //BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);



                                cb.BeginText();
                                //Header show company information
                                font.SetStyle(iTextSharp.text.Font.BOLD);
                                cb.SetFontAndSize(font.BaseFont, 12f);                                
                                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, textHEADER, X / 2, Y = Y - 20f, 0f);

                                cb.SetFontAndSize(font.BaseFont, 8f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, textHEADER1, X / 2, Y = Y - 10f, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, textHEADER2, X / 2, Y = Y - 10f, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, textHEADER3, X / 2, Y = Y - 10f, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, textHEADER4, X / 2, Y = Y - 10f, 0f);

                                //Header for test defatult condition
                                BaseFont bf1 = BaseFont.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                                //BaseFont bf1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                iTextSharp.text.Font font1 = new iTextSharp.text.Font(bf1, 12, iTextSharp.text.Font.BOLD);
                                //LEFT side
                                cb.SetFontAndSize(font1.BaseFont, 8f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, textINFOLEFT1, 20f , YL - 90, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, textINFOLEFT2, 20f, YL - 100, 0f);
                                //RIGHT side
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, textINFORIGHT1, X - 200f, Y = YR - 90, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, textINFORIGHT2, X - 200f, Y = YR - 100, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, textINFORIGHT3, X - 200f, Y = YR - 110, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, textINFORIGHT4, X - 200f, Y = YR - 120, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, textINFORIGHT5, X - 200f, Y = YR - 130, 0f);
                                //Header for result showing
                                cb.SetFontAndSize(font.BaseFont, 8f);
                                //LEFT
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, textINFOLEFT3, 200f, YL - 90, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, textINFOLEFT4, 200f, YL - 100, 0f);
                                //RIGHT
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, textINFORIGHT6, X - 20f, Y = YR - 90, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, textINFORIGHT7, X - 20f, Y = YR - 100, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, textINFORIGHT8, X - 20f, Y = YR - 110, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, textINFORIGHT9, X - 20f, Y = YR - 120, 0f);
                                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, textINFORIGHT10, X - 20f, Y = YR - 130, 0f);


                                cb.EndText();
                                //TABLE
                                pdfPTable.WriteSelectedRows(0, -1, 0 + 2f, Y = Y - 40f, write.DirectContent);

                                float tableHeight = pdfPTable.TotalHeight;
                                
                                Y = Y - tableHeight; // Y pointer

                                //Show CHART
                                // Create a new bitmap to hold the chart image
                                Bitmap chartImage = new Bitmap(COF.COFinstance.chartCOF.Width, COF.COFinstance.chartCOF.Height); ;

                                // Draw the chart to the bitmap
                                COF.COFinstance.chartCOF.DrawToBitmap(chartImage, new System.Drawing.Rectangle(0, 0, COF.COFinstance.chartCOF.Width, COF.COFinstance.chartCOF.Height));

                                //Create a new iTextSharp Image object from the chart image
                                iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(chartImage, ImageFormat.Bmp);
                               
                                pdfImage.ScalePercent(75);
                                pdfImage.ScaleToFitHeight = false;

                                ;

                                if (Y < pdfImage.ScaledHeight)
                                {
                                    // Add a new page to the document
                                    document.NewPage();

                                    // Reset the Y position
                                    Y = document.PageSize.Height - pdfImage.ScaledHeight; 
                                }
                                else Y = Y - pdfImage.ScaledHeight;
                                

                                pdfImage.SetAbsolutePosition(2f, Y);

                                document.Add(pdfImage);





                               

                                //document.Add(pdfPTable);
                                document.Close();
                                fileStream.Close();
                                MessageBox.Show("Sussessfull");
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while Exporting data \n"+ ex.Message);
                        }
                        
                    }    
                }    
            }    
        }       
    }
    
}
