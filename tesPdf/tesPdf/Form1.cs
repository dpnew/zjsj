using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace tesPdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 
        private AxAcroPDFLib.AxAcroPDF pdfviewer;

        [DllImport("ole32.dll")]
        static extern void CoFreeUnusedLibraries();

        [DllImport("ole32.dll")]
        static extern void CoUninitialize();

        private void Form1_Load(object sender, EventArgs e)
        {
            //initP();
        }

        private void initP()
        { 

            pdfviewer = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(pdfviewer)).BeginInit();
            pdfviewer.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(pdfviewer);
            ((System.ComponentModel.ISupportInitialize)(pdfviewer)).EndInit();
            pdfviewer.LoadFile(Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "pdf-test.pdf"));
            pdfviewer.setShowToolbar(false);
            pdfviewer.setShowScrollbars(false);
            //pdfviewer.Show();
            //pdfviewer.Refresh();
        }

        private void aslk()
        {
            pdfviewer.Dispose();
            pdfviewer = null; 
            // http://forums.adobe.com/thread/487023
            CoFreeUnusedLibraries();
            CoUninitialize();
            Thread.Sleep(1000);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //PDFGenerator.Mai();
            initP();
            //salk();
        }

        private string MyOpenFileDialog()
         {
            OpenFileDialog ofd = new OpenFileDialog();
             ofd.Filter = "PDF文档(*.pdf)|*.pdf";

            if (ofd.ShowDialog() == DialogResult.OK)
             {
                return ofd.FileName;
             }
            else
             {
                return null;
             }
         }

        private void salk()
        {

            string fileName = MyOpenFileDialog();
            AxAcroPDFLib.AxAcroPDF axAcroPDF = pdfviewer;// new AxAcroPDFLib.AxAcroPDF();
            axAcroPDF.Location = new System.Drawing.Point(0, 24);
            axAcroPDF.Size = new System.Drawing.Size(292, 242);
            axAcroPDF.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(axAcroPDF);
            //axAcroPDF.LoadFile(fileName);
            axAcroPDF.LoadFile(Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "pdf-test.pdf"));
            axAcroPDF.setShowToolbar(false);
            axAcroPDF.setShowScrollbars(false);

        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "pdf-test.pdf")); 
            
        }
        /*
         using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Title = "另存为";
                saveFileDialog1.InitialDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);// @"C:\";
                saveFileDialog1.Filter = "PDF文档(*.pdf)|*.pdf";
                saveFileDialog1.AddExtension = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    saveFileDialog1.FileName = "pdf-test.pdf"; 
                }
            }
         */
    }
}
