using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace Minecraft_Fishing
{

    public class ScreenProcessing
    {

        Size size;
        Bitmap bitmap;
        private Form1 form;
        bool achouPixel = false;
        bool run = true;


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;


        public ScreenProcessing(Form1 form)
        {
            this.form = form;
            bitmap = new Bitmap(300, 300);
            size = new Size(300, 300);
        }

        public void Run()
        {

            while (run)
            {

                int A = int.Parse(Cursor.Position.X.ToString()) - 200;
                int B = int.Parse(Cursor.Position.Y.ToString()) - 111;

                using (Graphics gr = Graphics.FromImage(bitmap))
                {
                    gr.CopyFromScreen(A, B, 0, 0, size);
                }

                form.setText(A.ToString() + " " + B.ToString());


                for (int i = 0; i < 300; i++)
                {
                    for (int j = 0; j < 300; j++)
                    {

                        if (((int.Parse(bitmap.GetPixel(j, i).R.ToString()) > 180) && (int.Parse(bitmap.GetPixel(j, i).R.ToString()) < 230)) && ((int.Parse(bitmap.GetPixel(j, i).G.ToString()) > 35) && (int.Parse(bitmap.GetPixel(j, i).G.ToString()) < 50)) && ((int.Parse(bitmap.GetPixel(j, i).B.ToString()) > 35) && (int.Parse(bitmap.GetPixel(j, i).B.ToString()) < 50)))
                        {
                            achouPixel = true;
                            i = j = 299;
                            break;
                        }
                        else
                        {
                            achouPixel = false;
                        }

                    }

                }


                //se achou, mouseclick ou outracoisa
                if (!achouPixel)
                {
                    DoMouseClick();
                }

                //form.invalidate();

                Thread.Sleep(900);
            }

        }

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
        }


        public void PressKey()
        {
            SendKeys.SendWait("E");
        }


        public void Start()
        {
            this.run = true;
        }


        public void Stop()
        {
            this.run = false;
        }


    }
}
