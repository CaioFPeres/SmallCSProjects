using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBOBot
{
    public partial class Form1 : Form
    {

        Thread t1;
        Thread t2;
        InterceptKeys iK;
        ScreenProcessing sc;



        public Form1()
        {
            InitializeComponent();
            iK = new InterceptKeys(this);
            sc = new ScreenProcessing();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            t1 = new Thread(new ThreadStart(runListener));
            t1.Start();
            

            t2 = new Thread(new ThreadStart(processImage));
            t2.Start();

            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);

        }


        public void setPictureBox1(Bitmap bitmap)
        {
            this.pictureBox1.Image = bitmap;
        }


        public void invalidate()
        {
            this.pictureBox1.Invalidate();
        }


        public void setText(String text)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {  });
                return;
            }
        }

        public void F1Start()
        {
            if (!t2.IsAlive)
            {
                sc.Start();
                t2 = new Thread(new ThreadStart(processImage));
                t2.Start();
            }
        }

        public void F2Stop()
        {
            sc.Stop();
        }


        private void runListener()
        {
            iK.Run();
        }


        private void processImage()
        {
            sc.Run();
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            iK.Stop();
            sc.Stop();
        }



        /*
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            switch (keyData)
            {
                case Keys.F1:
                    Console.WriteLine("F1 apertado");
                    break;
                case Keys.F2:
                    Console.WriteLine("F2 apertado");
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        */

    }
}
