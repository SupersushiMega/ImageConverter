using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Converter
{
    public partial class Form1 : Form
    {
        Graphics Display;
        Image original;

        public Form1()
        {
            InitializeComponent();
            Display = pictureBox1.CreateGraphics();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            Debug.WriteLine(sender.GetType());
            /*if(sender.GetType() == 1)
            {

            }*/
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog Browser = new OpenFileDialog();
            Browser.Title = "open Image";
            Browser.Filter = "PNG file|*.png|JPG file|*.jpg";
            if (Browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                original = Image.FromFile(Browser.FileName);
                pictureBox1.Image = original;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
