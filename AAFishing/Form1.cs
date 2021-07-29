using System;
using System.Threading;
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

namespace AAFishing
{

    public struct Coords
    {
        public int x, y;
    }



    public partial class AAFishing : Form
    {
        static Coords[] coordenadas = new Coords[5];
        static int i=0;
        static Color cor;
        static string[] UTGHJ = { "u", "t", "g", "h", "j" };
        static Size size = new Size(40, 1);

        /*
        static Bitmap[] botoesFixos = new Bitmap[5];
        static string path = (Path.Combine(Directory.GetCurrentDirectory(), @"botoes\botao"));
        static Color[] cores = new Color[5];
        static string text;
        */



        public AAFishing()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            coordenadas[0].x = 1464;
            coordenadas[0].y = 990;
            coordenadas[1].x = 1505;
            coordenadas[1].y = 990;
            coordenadas[2].x = 1546;
            coordenadas[2].y = 990;
            coordenadas[3].x = 1382;
            coordenadas[3].y = 1031;
            coordenadas[4].x = 1423;
            coordenadas[4].y = 1031;


            timer1.Enabled = true;
            int interval = 25;
            timer1.Interval = interval;


            //Pegar a cor de cada pixel numero 10

            /*


            botoesFixos[0] = new Bitmap(@"botoes\botoes jpeg\botao0.jpg");
            botoesFixos[1] = new Bitmap(@"botoes\botoes jpeg\botao1.jpg");
            botoesFixos[2] = new Bitmap(@"botoes\botoes jpeg\botao2.jpg");
            botoesFixos[3] = new Bitmap(@"botoes\botoes jpeg\botao3.jpg");
            botoesFixos[4] = new Bitmap(@"botoes\botoes jpeg\botao4.jpg");


            cores[0] = botoesFixos[0].GetPixel(10, 0);
            cores[1] = botoesFixos[1].GetPixel(10, 0);
            cores[2] = botoesFixos[2].GetPixel(10, 0);
            cores[3] = botoesFixos[3].GetPixel(10, 0);
            cores[4] = botoesFixos[4].GetPixel(10, 0);



            Form1.text = cores[0].A.ToString();
            File.WriteAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[0].R.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[0].G.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[0].B.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + "\n");

            Form1.text = cores[1].A.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[1].R.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[1].G.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[1].B.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + "\n");

            Form1.text = cores[2].A.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[2].R.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[2].G.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[2].B.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + "\n");

            Form1.text = cores[3].A.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[3].R.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[3].G.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[3].B.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + "\n");

            Form1.text = cores[4].A.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[4].R.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[4].G.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + " ");

            Form1.text = cores[4].B.ToString();
            File.AppendAllText(@"botoes\cores.txt", Form1.text + "\n");

    */

        }


        /*
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

    */


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i > 4)
                i = 0;
            Bitmap bitmap1 = new Bitmap(40, 1);
            Graphics g = Graphics.FromImage(bitmap1);

            g.CopyFromScreen(coordenadas[i].x, coordenadas[i].y, 0, 0, size);

            cor = bitmap1.GetPixel(10, 0);

            
            if (  ((int.Parse(cor.R.ToString()) > 225) && (int.Parse(cor.R.ToString()) < 260))  &&  ((int.Parse(cor.G.ToString()) > 130) && (int.Parse(cor.G.ToString()) < 160))  )
            {
                SendKeys.Send(UTGHJ[i]);
                timer1.Enabled = false;
                PutTaskDelay();
            }
            

            //bitmap1.Save(path + i + ".jpg");
            //Ativar(bitmap1, botoesFixos[i], i);


            i++;

            
            g.Dispose();
            bitmap1.Dispose();
            GC.SuppressFinalize(this);

        }

        void F1Start()
        {
            timer1.Enabled = true;
            int interval = 25;
            timer1.Interval = interval;
        }

        void F2Stop()
        {
            timer1.Enabled = false;
        }



        private bool ImageCompareString(Bitmap bit1, Bitmap bit2)
        {
            MemoryStream ms = new MemoryStream();
            bit1.Save(ms, ImageFormat.Jpeg);
            string first = Convert.ToBase64String(ms.ToArray());
            ms.Position = 0;

            bit2.Save(ms, ImageFormat.Jpeg);
            string second = Convert.ToBase64String(ms.ToArray());
            if (first.Equals(second))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        async Task PutTaskDelay()
        {
            await Task.Delay(5000);
            timer1.Enabled = true;
        }



        private void WaitNSeconds(int segundos)
        {
            if (segundos < 1) return;
            DateTime _desired = DateTime.Now.AddSeconds(segundos);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

    }
}
