using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Security.Permissions;
using iTextSharp.text.pdf.parser;
using System.IO;

namespace LerPDF
{
    public partial class LerPDF : Form
    {
        public LerPDF()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            string filepath;

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                filepath = dlg.SelectedPath;


                string strText = string.Empty;
                string fragmento = string.Empty;
                int PA = 0;
                int RD = 0;
                try
                {

                    int fCount = Directory.GetFiles(filepath, "*", SearchOption.TopDirectoryOnly).Length;
                    String[] paths = Directory.GetFiles(filepath, "*", SearchOption.TopDirectoryOnly);


                    for (int arq = 0; arq < fCount; arq++)
                    {

                        PdfReader reader = new PdfReader(paths[arq]);

                        for (int page = 1; page <= reader.NumberOfPages; page++)
                        {
                            ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                            String s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                            s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                            strText = strText + s;

                        }

                        strText = strText + "\n \n \n" + "___________________________________________________________________________\n\n";

                        reader.Close();
                    }

                        



                        //procurar palavra
                        for (int i = 0; i < strText.Length -15; i++)
                        {

                            if (strText[i] == 'P' && strText[i + 1] == 'R' && strText[i + 2] == 'O' && strText[i + 3] == 'C' && strText[i + 4] == 'E' && strText[i + 5] == 'S' && strText[i + 6] == 'S' && strText[i + 7] == 'O' && strText[i + 8] == ' ' && strText[i + 9] == 'A' && strText[i + 10] == 'D' && strText[i + 11] == 'M' && strText[i + 12] == 'I' && strText[i + 13] == 'N' && strText[i + 14] == 'I' && strText[i + 15] == 'S')
                            {

                                PA++;
                                        
                                //pesquisar no bloco
                                for (int j = i; j < strText.Length -1; j++)
                                {
                                    if( ( strText[j] == '0' || strText[j] == '1' || strText[j] == '2' || strText[j] == '3' || strText[j] == '4' || strText[j] == '5' || strText[j] == '6' || strText[j] == '7' || strText[j] == '8' || strText[j] == '9' ) && (strText[j+1] == ')' ) )
                                    {
                                        fragmento = fragmento + "\n";
                                        j = strText.Length - 1 - 2;
                                    }

                                    fragmento = fragmento + strText[j];



                                }
                                    

                            }


                            if (strText[i] == 'R' && strText[i + 1] == 'E' && strText[i + 2] == 'C' && strText[i + 3] == 'L' && strText[i + 4] == 'A' && strText[i + 5] == 'M' && strText[i + 6] == 'A' && strText[i + 7] == 'Ç' && strText[i + 8] == 'Ã' && strText[i + 9] == 'O' && strText[i + 10] == ' ' && strText[i + 11] == 'D' && strText[i + 12] == 'I' && strText[i + 13] == 'S' && strText[i + 14] == 'C' && strText[i + 15] == 'I')
                            {

                                RD++;

                                //pesquisar no bloco
                                for (int j = i; j < strText.Length - 1; j++)
                                {
                                    if ((strText[j] == '0' || strText[j] == '1' || strText[j] == '2' || strText[j] == '3' || strText[j] == '4' || strText[j] == '5' || strText[j] == '6' || strText[j] == '7' || strText[j] == '8' || strText[j] == '9') && (strText[j + 1] == ')'))
                                    {
                                        fragmento = fragmento + "\n";
                                        j = strText.Length - 1 - 2;
                                    }

                                    fragmento = fragmento + strText[j];



                                }

                            }


                        }

                        label2.Text = PA.ToString();
                        label6.Text = RD.ToString();

                        File.WriteAllText(@"textoCopiado.txt", fragmento);

                        

                     

                    
                    


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }


    }

}
