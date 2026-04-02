using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2
{
    public partial class FormBresenham : Form
    {
        Bitmap myBitmap;
        Color circleColor = Color.Red;

        public FormBresenham()
        {
            InitializeComponent();
            CreateWhiteBitmap();
        }

        private void CreateWhiteBitmap()
        {
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(myBitmap))
            {
                g.Clear(Color.White);
            }
            pictureBox1.Image = myBitmap;
        }

        private void DrawBresenhamCircle(int xc, int yc, int r)
        {
            int x = 0;
            int y = r;
            int d = 3 - 2 * r;
            DrawCirclePoints(xc, yc, x, y);
            while (y >= x)
            {
                x++;
                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }
                DrawCirclePoints(xc, yc, x, y);
            }
        }

        private void DrawCirclePoints(int xc, int yc, int x, int y)
        {
            SetPixelSafe(xc + x, yc + y);
            SetPixelSafe(xc - x, yc + y);
            SetPixelSafe(xc + x, yc - y);
            SetPixelSafe(xc - x, yc - y);
            SetPixelSafe(xc + y, yc + x);
            SetPixelSafe(xc - y, yc + x);
            SetPixelSafe(xc + y, yc - x);
            SetPixelSafe(xc - y, yc - x);
        }

        private void SetPixelSafe(int x, int y)
        {
            if (x >= 0 && x < myBitmap.Width && y >= 0 && y < myBitmap.Height)
            {
                myBitmap.SetPixel(x, y, circleColor);
            }
        }

        // КНОПКА "ОЧИСТИТЬ"
        private void button2_Click(object sender, EventArgs e)
        {
            CreateWhiteBitmap();
        }

        // КНОПКА "НАЗАД" 
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // РИСОВАНИЕ ПО КЛИКУ МЫШИ
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int centerX = e.X;
            int centerY = e.Y;
            int radius = (int)numericUpDown1.Value / 2;

            if (radius > 0)
            {
                DrawBresenhamCircle(centerX, centerY, radius);
                pictureBox1.Image = myBitmap;
                pictureBox1.Refresh();
            }
        }

        // ПУСТЫЕ ОБРАБОТЧИКИ 
        private void pictureBox1_Click(object sender, EventArgs e) 
        {
        
        }
        private void pictureBox1_Click_1(object sender, EventArgs e) 
        {
        
        }
        private void FormBresenham_MouseDown(object sender, MouseEventArgs e) 
        {
        
        }
        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }
}