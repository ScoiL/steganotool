using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Steganography
{
    public partial class Form1 : Form
    {
        private Bitmap bmpImageSource;
        private Bitmap bmpImageResult;
        private Bitmap bmpExtractImage;
        private String txtMessage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                 bmpImageSource = new Bitmap(Image.FromFile(dlgOpen.FileName));
                 pbSourceImg.Image = bmpImageSource;
                 btnHide.Enabled = true;
                
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                txtMessage = textBox1.Text;
                
                bmpImageResult = SteganoLIB.HideText(bmpImageSource, txtMessage);

                pbResultImage.Image = bmpImageResult;
                btnSave.Enabled = true;
            }
            else
            {
                MessageBox.Show("Message text is empty");
            }
        }

        private void pbResultImage_BackgroundImageChanged(object sender, EventArgs e)
        {
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
                
                bmpImageResult.Save(dlgSaveFile.FileName, System.Drawing.Imaging.ImageFormat.Bmp);

                
            }
        }

        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if(pbExtractImage.Image==null)
                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {

                    Image img = Image.FromFile(dlgOpen.FileName);
                    bmpExtractImage = new Bitmap(img);
                   pbExtractImage.Image = bmpExtractImage;
                   btnExtract.Enabled = true;

                }
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            try
            {
                textBox2.Text = SteganoLIB.ExtractText(bmpExtractImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while extracting message, or no message is hidden");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {

                Image img = Image.FromFile(dlgOpen.FileName);
                bmpExtractImage = new Bitmap(img);
                pbExtractImage.Image = bmpExtractImage;
                btnExtract.Enabled = true;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
                    }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore", " http://msp-egypt09.blogspot.com");
        }
    }
}