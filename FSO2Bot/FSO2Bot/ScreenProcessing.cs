using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSO2Bot
{

    public class ScreenProcessing
    {


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;


        private bool run = true;
        private Bitmap bitmap;
        private Size size;
        private Form1 form1;


        public ScreenProcessing(Form1 form)
        {

            bitmap = new Bitmap(1, 1);
            size = new Size(1, 1);
            this.form1 = form;


            /*

            arvores = new Coords[3];
            machados = new Coords[5];
            machadosEquipados = new Coords[5];

            bitmap1 = new Bitmap(800, 590);
            size1 = new Size(800, 590);

            //tres arvores
            arvores[0].x = 369;
            arvores[0].y = 292;
            arvores[1].x = 337;
            arvores[1].y = 325;
            arvores[2].x = 400;
            arvores[2].y = 326;


            // machados mapeados
            machados[0].x = 587;
            machados[0].y = 533;
            machados[1].x = 630;
            machados[1].y = 533;
            machados[2].x = 673;
            machados[2].y = 533;
            machados[3].x = 716;
            machados[3].y = 533;
            machados[4].x = 759;
            machados[4].y = 533;


            //machado equipado
            machadosEquipados[0].x = 587;
            machadosEquipados[0].y = 537;
            machadosEquipados[1].x = 630;
            machadosEquipados[1].y = 537;
            machadosEquipados[2].x = 673;
            machadosEquipados[2].y = 537;
            machadosEquipados[3].x = 716;
            machadosEquipados[3].y = 537;
            machadosEquipados[4].x = 759;
            machadosEquipados[4].y = 537;




            /* arvores da trilha mapeadas
            coordenadas[0].x = 304;
            coordenadas[0].y = 133;
            coordenadas[1].x = 370;
            coordenadas[1].y = 134;
            coordenadas[2].x = 304;
            coordenadas[2].y = 197;
            coordenadas[3].x = 370;
            coordenadas[3].y = 198;
            coordenadas[4].x = 465;
            coordenadas[4].y = 230;
            coordenadas[5].x = 400;
            coordenadas[5].y = 262;
            coordenadas[6].x = 400;
            coordenadas[6].y = 294;
            coordenadas[7].x = 464;
            coordenadas[7].y = 295;
            coordenadas[8].x = 402;
            coordenadas[8].y = 326;
            coordenadas[9].x = 465;
            coordenadas[9].y = 327;
            coordenadas[10].x = 465;
            coordenadas[10].y = 360;
            coordenadas[11].x = 468;
            coordenadas[11].y = 390;
            */

        }



        public void Run()
        {

            while (run)
            {
               
                using (Graphics gr = Graphics.FromImage(bitmap))
                {
                    gr.CopyFromScreen(696, 312, 0, 0, size);
                }

                if (!(int.Parse(bitmap.GetPixel(0, 0).R.ToString()) >= 250) && !(int.Parse(bitmap.GetPixel(0, 0).G.ToString()) >= 250) && !(int.Parse(bitmap.GetPixel(0, 0).B.ToString()) >= 250))
                {
                    Thread.Sleep(1000);

                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    Thread.Sleep(1000);

                    MoveCursor(993, 660);
                    DoMouseClickLeftDown();
                    MoveCursor(614, 213);
                    DoMouseClickLeftUp();
                    Thread.Sleep(1000);

                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    Thread.Sleep(1000);

                    MoveCursor(864, 627);
                    DoMouseClickLeftDown();
                    MoveCursor(614, 213);
                    DoMouseClickLeftUp();
                    Thread.Sleep(1000);

                    DoMouseClick();
                    Thread.Sleep(1000);
                    MoveCursor(752, 363);
                    DoMouseClick();
                    Thread.Sleep(1000);

                }

                //25 colunas, 14 linhas

                // 800/25 = 32 nas colunas       e       448/14 = 32 nas linhas
                // cada quadrado tem 32x32

                //cor cabelo vermelho:  176, 0, 0

                //form.invalidate();

            }

        }


        public void RunPC()
        {

            while (run)
            {

                using (Graphics gr = Graphics.FromImage(bitmap))
                {
                    gr.CopyFromScreen(973, 468, 0, 0, size);
                }

                if (!(int.Parse(bitmap.GetPixel(0, 0).R.ToString()) >= 250) && !(int.Parse(bitmap.GetPixel(0, 0).G.ToString()) >= 250) && !(int.Parse(bitmap.GetPixel(0, 0).B.ToString()) >= 250))
                {
                    Thread.Sleep(1000);

                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    SendKeys.SendWait("{LEFT}");
                    Thread.Sleep(1000);

                    MoveCursor(1270, 817);
                    DoMouseClickLeftDown();
                    MoveCursor(887, 370);
                    DoMouseClickLeftUp();
                    Thread.Sleep(1000);

                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    SendKeys.SendWait("{RIGHT}");
                    Thread.Sleep(1000);

                    MoveCursor(1140, 782);
                    DoMouseClickLeftDown();
                    MoveCursor(887, 370);
                    DoMouseClickLeftUp();
                    Thread.Sleep(1000);

                    DoMouseClick();
                    Thread.Sleep(1000);
                    MoveCursor(1028, 519);
                    DoMouseClick();
                    Thread.Sleep(1000);

                }

                //25 colunas, 14 linhas

                // 800/25 = 32 nas colunas       e       448/14 = 32 nas linhas
                // cada quadrado tem 32x32

                //cor cabelo vermelho:  176, 0, 0

                //form.invalidate();

            }

        }



        private void MoveCursor(int X, int Y)
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form.

            //form1.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(X,Y);
        }


        public void DoMouseClickLeftDown()
        {
            //Call the imported function with the cursor's current position
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        }

        public void DoMouseClickLeftUp()
        {
            //Call the imported function with the cursor's current position
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
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
