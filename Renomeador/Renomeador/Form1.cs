using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Diagnostics;

namespace Renomeador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            string filepath;

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                filepath = dlg.SelectedPath;

                int fCount = Directory.GetFiles(filepath, "*", SearchOption.TopDirectoryOnly).Length;
                String[] paths = Directory.GetFiles(filepath, "*", SearchOption.TopDirectoryOnly);
                
                for (int i = 0; i < fCount; i++)
                {

                    try
                    {
                        File.Move(paths[i], filepath + @"\" + this.textBox1.Text + i + ".txt");
                    }
                    catch(Exception ex) when (ex is IOException || ex is FileNotFoundException || ex is ArgumentNullException || ex is ArgumentException ||
                    ex is UnauthorizedAccessException || ex is PathTooLongException || ex is DirectoryNotFoundException || ex is NotSupportedException)
                    {
                        MessageBox.Show("Algo deu errado.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                FileInfo directory = new FileInfo(filepath);

                string parent = directory.DirectoryName;

                string zipPath = parent + @"\" + this.textBox1.Text + ".zip";

                ZipFile.CreateFromDirectory(filepath, zipPath);

                Directory.Delete(filepath, true);



            }


        }




    }
}
