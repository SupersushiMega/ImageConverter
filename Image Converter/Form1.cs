using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Converter
{
    public partial class Form1 : Form
    {
        Point relativePos;
        Pen pen;
        Int32 x;
        Int32 y;
        Graphics Original;
        Graphics Preview;
        Image original;
        Bitmap MapOriginal;
        Bitmap MapPreview;

        Rectangle Selection;

        public Form1()
        {
            InitializeComponent();
            Original = pictureBox1.CreateGraphics();
            Preview = pictureBoxPreview.CreateGraphics();
            x = relativePos.X;
            y = relativePos.Y;

            Brush brush = new SolidBrush(Color.Black);
            pen = new Pen(brush);
            pen.Width = 4;

            Selection = new Rectangle();
            Selection.Width = 100;
            Selection.Height = 100;
            Selection.X = 100;
            Selection.Y = 100;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MapOriginal != null)
            {
                DrawPreview();
                //pictureBox1.DrawToBitmap(MapOriginal, Selection);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Position.Offset(pictureBox1.Location);
            relativePos = pictureBox1.PointToClient(MousePosition);
            OriginalRes.Text = relativePos.X + ":" + relativePos.Y;
            Selection.Location = relativePos;
            Original.DrawRectangle(pen, Selection);
            Preview.DrawRectangle(pen, Selection);
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
                pictureBoxPreview.Image = original;
                MapOriginal = new Bitmap(pictureBox1.Image);
                MapPreview = new Bitmap(pictureBoxPreview.Image);
                OriginalRes.Text = original.Width + " : " + original.Height;
            }
        }

        private void DrawPreview()
        {
            Int32 X = 0;
            Int32 Y = 0;
            Int32 x = 0;
            Int32 y = 0;
            Preview.Clear(Color.Black);
            for (X = Selection.X; X < Selection.Width + Selection.X; X++)
            {
                for (Y = Selection.Y; Y < Selection.Height + Selection.Y; Y++)
                {
                    MapPreview.SetPixel(X - Selection.X, Y - Selection.Y, MapOriginal.GetPixel(X,Y));
                    Debug.WriteLine(MapOriginal.GetPixel(X, Y));
                }
            }
            Preview.DrawImage(MapPreview, Point.Empty);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void OriginHeight_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxPreview_Click(object sender, EventArgs e)
        {

        }
    }
}
