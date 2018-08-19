//Miguel Pulido - Systems Architect

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace SlideShow
{
    public partial class Form1 : Form
    {
        int filemax = 0;            // intialize count to 0
        int filecount = 0;          // initialize count to 0
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filemax = 0;                //initialize file max to 0
                panel1.Controls.Clear();    // panel control used to encapsulate more controls
                foreach (String a in Directory.GetFiles(dlg.SelectedPath))
                {
                    if ((a.EndsWith(".jpg")) || (a.EndsWith(".jpeg")) || (a.EndsWith(".png")) || (a.EndsWith(".gif")) || (a.EndsWith(".bmp")))
                    {
                        PictureBox pb = new PictureBox();
                        Image im = Image.FromFile(a);
                        pb.Image = im;
                        panel1.Controls.Add(pb);
                        filemax++;          //increment file 
                    }
                }
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (filecount == filemax) { filecount = 0; }
            PictureBox p = (PictureBox)panel1.Controls[filecount];
            pictureBox1.Image = p.Image;
            filecount++;
        }
    }
}