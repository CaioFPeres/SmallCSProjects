using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_FSO2
{
    public partial class Form1 : Form
    {

        Bitmap bitmap1;
        static Size sizeTela = new Size(800, 448);
        List<int> KL1 = new List<int>();
        int somaMod;


        public Form1()
        {
            InitializeComponent();
        }





        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            int interval = 25;
            timer1.Interval = interval;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            KL1 = EncontrarPosicoes();


            if (KL1.ElementAt(2) == 1 && KL1.ElementAt(3) == 0)
            {
                SendKeys.Send("{LEFT}");
                timer1.Enabled = false;
                atacar(KL1.ElementAt(0), KL1.ElementAt(1));
            }

            caminharLinha(KL1.ElementAt(2), KL1.ElementAt(3));
        }


        void atacar(int i, int j)
        {
            bitmap1 = new Bitmap(800, 448);
            Graphics g = Graphics.FromImage(bitmap1);
            g.CopyFromScreen(560, 255, 0, 0, sizeTela);

            while ( (bitmap1.GetPixel(i, j).R == 16 && bitmap1.GetPixel(i, j).G == 107 && bitmap1.GetPixel(i, j).B == 0) )
                SendKeys.Send("%");

            g.Dispose();
            bitmap1.Dispose();
            GC.SuppressFinalize(this);
        }



        List<int> EncontrarPosicoes()
        {

            List<int> vetor = new List<int>();
            bitmap1 = new Bitmap(800, 448);
            Graphics g = Graphics.FromImage(bitmap1);
            g.CopyFromScreen(560, 255, 0, 0, sizeTela);


            int colObj = 0;
            int linhaObj = 0;

            int playerPosX = 0;
            int playerPosY = 0;



            //encontrar arvore
            for (int j = 1; j < 448; j++)
            {
                for (int i = 1; i < 800; i++)
                {
                    if ( (bitmap1.GetPixel(i, j).R == 16 && bitmap1.GetPixel(i, j).G == 107 && bitmap1.GetPixel(i, j).B == 0) )
                    {
                        colObj = i;
                        linhaObj = j;
                        goto EndOfLoop;
                    }
                }
            }

        EndOfLoop:;



            vetor.Add(colObj);
            vetor.Add(linhaObj);


            colObj = (colObj / 32) + 1;
            linhaObj = (linhaObj / 32) + 1;



            //encontrar player
            for (int j = 1; j < 448; j++)
            {
                for (int i = 1; i < 800; i++)
                {
                    if ((bitmap1.GetPixel(i, j).R == 247 && bitmap1.GetPixel(i, j).G == 190 && bitmap1.GetPixel(i, j).B == 74))
                    {
                        playerPosX = i;
                        playerPosY = j + 20;
                        goto EndOfLoop2;
                    }
                }
            }

        EndOfLoop2: ;




            playerPosX = (playerPosX / 32) + 1;
            playerPosY = (playerPosY / 32) + 1;


            int k = playerPosX - colObj;
            int l = playerPosY - linhaObj;


            Tuple<int, int> KL = Tuple.Create(k, l);

            textBox1.Text = KL.ToString();

            vetor.Add(k);
            vetor.Add(l);



            g.Dispose();
            bitmap1.Dispose();
            GC.SuppressFinalize(this);



            return vetor;

        }




        void caminharLinha(int k, int l)
        {
            List<int> KL = new List<int>();
            int dist = Math.Abs(k) + Math.Abs(l);



            for (int j = 0; j < dist; j++)
            {
                if (l < 0)
                {
                    SendKeys.Send("{DOWN}");
                    PutTaskDelay();

                    KL = EncontrarPosicoes();

                    if (KL.ElementAt(3) == l)
                        caminharColuna(k, l);

                    if (KL.ElementAt(3) == 0)
                        break;
                }

                else
                {
                    SendKeys.Send("{UP}");
                    PutTaskDelay();

                    KL = EncontrarPosicoes();

                    if (KL.ElementAt(3) == l)
                        caminharColuna(k, l);

                    if (KL.ElementAt(3) == 0)
                        break;
                }
            }
            caminharColuna(k, l);
        }




        void caminharColuna(int k, int l)
        {

                if (k > 0)
                {
                    SendKeys.Send("{LEFT}");
                    PutTaskDelay();
                }

                else
                {
                    SendKeys.Send("{RIGHT}");
                    PutTaskDelay();
                }

        }



        async Task PutTaskDelay()
        {
            await Task.Delay(2000);
        }



    }
}
