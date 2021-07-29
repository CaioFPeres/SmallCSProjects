using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TirarPrintdeLivro
{

    public struct Coords
    {
        public int x, y;
    }


    public partial class Form1 : Form
    {

        static Size size = new Size(1168, 929);
        int i=0;


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            int interval = 5000;
            timer1.Interval = interval;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            Bitmap bitmap1 = new Bitmap(1168, 929, PixelFormat.Format32bppRgb);
            Graphics g = Graphics.FromImage(bitmap1);
            g.CopyFromScreen(376, 61, 0, 0, size);


            bitmap1.Save(@"livro"+ i + ".jpg");


            SendKeys.Send("{RIGHT}");


            //pictureBox1.Image = bitmap1;


            i++;

            g.Dispose();
            bitmap1.Dispose();
            GC.SuppressFinalize(this);
        }


    }


}
