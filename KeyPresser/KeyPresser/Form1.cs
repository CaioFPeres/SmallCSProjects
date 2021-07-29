using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyPresser
{

    public partial class Form1 : Form
    {

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        void FindWindow()
        {
            Process p = Process.GetProcessesByName("notepad").FirstOrDefault();
            IntPtr h = p.MainWindowHandle;
            SetForegroundWindow(h);
        }

        public Form1()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            switch (keyData)
            {
                case Keys.F1:
                    F1Start();
                    break;
                case Keys.F2:
                    F2Stop();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.SendWait(textBox2.Text);
        }

        void F1Start()
        {
            timer1.Enabled = true;
            int interval = int.Parse(textBox1.Text);
            timer1.Interval = interval;
        }

        void F2Stop()
        {
            timer1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

