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
            Selection = new Rectangle();
            Selection.Width = 200;
            Selection.Height = 100;
            Selection.X = 100;
            Selection.Y = 100;

            MapPreview = new Bitmap(Selection.Width, Selection.Height);

            Original = pictureBox1.CreateGraphics();
            Preview = pictureBoxPreview.CreateGraphics();
            x = relativePos.X;
            y = relativePos.Y;

            Brush brush = new SolidBrush(Color.Black);
            pen = new Pen(brush);
            pen.Width = 4;
        }

        private void TargetResOrSize_Changed(object sender, EventArgs e)
        {
            Selection.Width = (Int32)(TargetResW.Value * Scale.Value);
            Selection.Height = (Int32)(TargetResW.Value * Scale.Value);
            MapPreview = new Bitmap(Selection.Width, Selection.Height);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MapOriginal != null)
            {
                relativePos = pictureBox1.PointToClient(MousePosition);
                Selection.Location = relativePos;
                Original.DrawRectangle(pen, Selection);
                MapPreview.SetResolution((float)Selection.Width, (float)Selection.Height);
                pictureBoxPreview.Width = Selection.Width;
                pictureBoxPreview.Height = Selection.Height;
                DrawPreview();
                pictureBoxPreview.Image = MapPreview;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MapOriginal != null)
            {
                //OriginalRes.Text = relativePos.X + ":" + relativePos.Y;
                //pictureBox1.Image = original;
            }
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
                MapOriginal = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(MapOriginal, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                OriginalRes.Text = original.Width + " : " + original.Height;
            }
        }

        private void DrawPreview()
        {
            Int32 X = 0;
            Int32 Y = 0;

            Preview.Clear(Color.Black);
            for (X = Selection.X; (X < (Selection.Width + Selection.X)) && (X < pictureBox1.Width); X++)
            {
                for (Y = Selection.Y; (Y < (Selection.Height + Selection.Y)) && (Y < pictureBox1.Height); Y++)
                {
                    MapPreview.SetPixel((X - Selection.X), (Y - Selection.Y), Color.Black);
                    MapOriginal.GetPixel(X, Y);
                }
            }
            Preview.DrawImage(MapPreview, Point.Empty);
        }
    }
}
