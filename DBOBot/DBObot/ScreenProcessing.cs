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

namespace DBOBot
{

    public class ScreenProcessing
    {

        Size size1;
        Size size2;
        int r1;
        int g1;
        int b1;
        int r2;
        int g2;
        int b2;
        Bitmap bitmap1;
        Bitmap bitmap2;
        bool run = true;


        public ScreenProcessing()
        {
            bitmap1 = new Bitmap(88, 1);
            bitmap2 = new Bitmap(1, 1);
            size1 = new Size(88, 1);
            size2 = new Size(1, 1);
        }

        public void Run()
        {
            
            while (run)
            {
                
                using (Graphics gr = Graphics.FromImage(bitmap1))
                {
                    gr.CopyFromScreen(134, 68, 0, 0, size1);
                }

                using (Graphics gr2 = Graphics.FromImage(bitmap2))
                {
                    gr2.CopyFromScreen(1040, 30, 0, 0, size2);
                }
                

                
                r1 = bitmap1.GetPixel(60, 0).R;
                g1 = bitmap1.GetPixel(60, 0).G;
                b1 = bitmap1.GetPixel(60, 0).B;

                r2 = bitmap2.GetPixel(0, 0).R;
                g2 = bitmap2.GetPixel(0, 0).G;
                b2 = bitmap2.GetPixel(0, 0).B;

                
                
                if ( (r1 > 190 && r1 < 210 && g1 > 100 && g1 < 120 && b1 > 115 && b1 < 150 ) && !( r2 > 128 && r2 < 134 && g2 > 145 && g2 < 151 && b2 > 154 && b2 < 160 ) )
                {
                    comVidaSemTarget();
                }
                else if ( (r1 > 190 && r1 < 210 && g1 > 100 && g1 < 120 && b1 > 115 && b1 < 150) && (r2 > 128 && r2 < 134 && g2 > 145 && g2 < 151 && b2 > 154 && b2 < 160))
                {
                    comVidaComTarget();
                }
                else if ( !(r1 > 190 && r1 < 210 && g1 > 100 && g1 < 120 && b1 > 115 && b1 < 150) && (r2 > 128 && r2 < 134 && g2 > 145 && g2 < 151 && b2 > 154 && b2 < 160))
                {
                    semVidaComTarget();
                }
                else if ( !(r1 > 190 && r1 < 210 && g1 > 100 && g1 < 120 && b1 > 115 && b1 < 150) && !(r2 > 128 && r2 < 134 && g2 > 145 && g2 < 151 && b2 > 154 && b2 < 160))
                {
                    semVidaSemTarget();
                    Thread.Sleep(10000);
                }
                
                //form.invalidate();               

                Thread.Sleep(500);
            
            }

        }


        public void comVidaSemTarget()
        {
            for(int i = 0; i < 15; i++)
            {
                SendKeys.SendWait("V");
            }
            SendKeys.SendWait("D");
            SendKeys.SendWait("{TAB}");
        }


        public void comVidaComTarget()
        {
            SendKeys.SendWait("D");
            SendKeys.SendWait("1");
            SendKeys.SendWait("2");
            SendKeys.SendWait("3");
            SendKeys.SendWait("4");
            SendKeys.SendWait("5");
            SendKeys.SendWait("6");
            SendKeys.SendWait("7");
        }


        public void semVidaComTarget()
        {
            SendKeys.SendWait("{F9}");
            SendKeys.SendWait("1");
            SendKeys.SendWait("2");
            SendKeys.SendWait("3");
            SendKeys.SendWait("4");
            SendKeys.SendWait("5");
            SendKeys.SendWait("6");
            SendKeys.SendWait("7");
        }


        public void semVidaSemTarget()
        {
            SendKeys.SendWait("{F11}");
            SendKeys.SendWait("{F12}");
            SendKeys.SendWait("{F12}");
            SendKeys.SendWait("{F12}");
            SendKeys.SendWait("{F12}");
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
