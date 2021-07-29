using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Media;
using System.Threading;

namespace Minecraft_Fishing
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;



        static Size size = new Size(300, 300);
        Thread t1;
        Thread t2;
        InterceptKeys iK;
        ScreenProcessing sc;


        public Form1()
        {
            InitializeComponent();
            iK = new InterceptKeys(this);
            sc = new ScreenProcessing(this);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            t1 = new Thread(new ThreadStart(runListener));
            t1.Start();


            t2 = new Thread(new ThreadStart(processImage));
            t2.Start();

            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);

        }

        public void setText(String text)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { label3.Text = text; });
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



    }

}
