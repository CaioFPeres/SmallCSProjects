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

namespace FSO2Bot
{

    public class ScreenProcessingProcuraArvore
    {

        Size size1;
        int linhaP;
        int colunaP;
        int linhaA;
        int colunaA;
        int distL;
        int distC;
        Bitmap bitmap1;
        bool run = true;


        public ScreenProcessingProcuraArvore(Form1 form)
        {
            bitmap1 = new Bitmap(800, 448);
            size1 = new Size(800, 448);
        }

        public void Run()
        {

            while (run)
            {

                using (Graphics gr = Graphics.FromImage(bitmap1))
                {
                    gr.CopyFromScreen(560, 255, 0, 0, size1);
                }



                //procura player
                for (int i = 260; i < 800; i++)
                {
                    bool breakLoop = false;

                    for (int j = 0; j < 448; j++)
                    {

                        if (bitmap1.GetPixel(i, j).R > 170 && bitmap1.GetPixel(i, j).R <= 255 && bitmap1.GetPixel(i, j).G > 35 && bitmap1.GetPixel(i, j).G < 55 && bitmap1.GetPixel(i, j).B > 35 && bitmap1.GetPixel(i, j).B < 55)
                        {
                            colunaP = ((int)i / 32) + 1;
                            linhaP = ((int)j / 32) + 2;
                            breakLoop = true;
                            break;
                        }

                    }

                    if (breakLoop)
                        break;
                }



                //procura arvore
                for (int i = 260; i < 800; i++)
                {
                    bool breakLoop = false;

                    for (int j = 0; j < 448; j++)
                    {

                        if (bitmap1.GetPixel(i, j).R > 40 && bitmap1.GetPixel(i, j).R < 55 && bitmap1.GetPixel(i, j).G > 130 && bitmap1.GetPixel(i, j).G < 150)
                        {
                            colunaA = ((int)i / 32) + 1;
                            linhaA = ((int)j / 32) + 1;
                            breakLoop = true;
                            break;
                        }

                    }

                    if (breakLoop)
                        break;
                }


                distL = linhaP - linhaA;
                distC = colunaP - colunaA;

                Console.WriteLine(distC + " " + distL);

                Console.WriteLine("ColunaP: " + colunaP + " LinhaP: " + linhaP + " ColunaA: " + colunaA + " LinhaA: " + linhaA);

                
                if(distL == 0 || distC == 0)
                {
                    SendKeys.SendWait("%");
                }


                for (int i = 0; i < Math.Abs(distC); i++)
                {
                    SendKeys.SendWait("+");
                    if (distC > 0)
                        SendKeys.SendWait("{LEFT}");
                    else
                        SendKeys.SendWait("{RIGHT}");
                }


                for (int j = 0; j < Math.Abs(distL); j++)
                {
                    SendKeys.SendWait("+");
                    if (distL > 0)
                        SendKeys.SendWait("{UP}");
                    else
                        SendKeys.SendWait("{DOWN}");
                }

                




                //bitmap1.Save("frame.jpeg");


                //25 colunas, 14 linhas

                // 800/25 = 32 nas colunas       e       448/14 = 32 nas linhas
                // cada quadrado tem 32x32

                //cor cabelo vermelho:  176, 0, 0

                //form.invalidate();               

                Thread.Sleep(200);
            
            }

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
