using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tesseract;

namespace OCR_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png"; 
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
               ImagePath.Text = open.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* IronTesseract IronOcr = new IronTesseract();
            IronOcr.Configuration.EngineMode = TesseractEngineMode.LstmOnly;
            IronOcr.Language = OcrLanguage.RussianBest;
            var Result = IronOcr.Read(ImagePath.Text);
            richTextBox1.Text = Result.Text;*/
            var ocrengine = new TesseractEngine(@".\tessdata", "rus+eng", EngineMode.Default);
            var img = Pix.LoadFromFile("Screen.png");
            var res = ocrengine.Process(img);
            richTextBox1.Text = res.GetText();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
