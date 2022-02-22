using ClassLibrary1;
using FiScnUtildN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScannerApplication
{
    public partial class Form1 : Form
    {
        ScannerConnection sc;
        public Form1()
        {
            InitializeComponent();
            sc= new ScannerConnection();
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            sc.axFiScn1.ScanToRawEx += AxFiScn1_ScanToRawEx;
            sc.ScanDocument(Handle.ToInt32());
        }

        private void AxFiScn1_ScanToRawEx(object sender, AxFiScnLib._DFiScnEvents_ScanToRawExEvent e)
        {
            Bitmap bitmap;
            ConvH2BM Conv = new ConvH2BM();
            bitmap = Conv.GetBitmapFromRAW(e.resolution, e.imageWidth, e.imageLength, e.bitPerPixel, e.compressionType, e.size, e.raw);
            pictureBox1.Image = bitmap;
        }

        public String strFileName; //Holds scanned file name

        
        
        private void axFiScn1_DetectBarcode(object sender, AxFiScnLib._DFiScnEvents_DetectBarcodeEvent e)
        {
            MessageBox.Show("DetectBarcode event is detected.\nNumber of scanned pages: " + e.readCount + "  page(s)" + "\nFile name: " + strFileName + "\nRecognized characters: " + e.barcodeText);
        }
    }
}
