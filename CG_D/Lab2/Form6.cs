using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form6 : Form
    {
        float angle1 = 0;
        float angle2 = 0;

        float speed1 = 0.05f;
        float speed2 = 0.05f;

        int dir1 = 1;
        int dir2 = -1;

        float scale1 = 1.5f;
        float scale2 = 0.5f;

        float maxScale2 = 1.2f;
        float minScale1 = 0.7f;

        // временные значения
        float tempSpeed = 0.05f;
        int tempDir = 1;

        Color color1 = Color.Blue;
        Color color2 = Color.Red;

        Timer timer = new Timer();
        bool isRunning = false;

        float[,] matr = new float[3, 3];

        public Form6()
        {
            InitializeComponent();
            timer.Interval = 30;
            timer.Tick += timer1_Tick;
        }
        //МАТРИЦА
        float[,] Multiply(float[,] a, float[,] b)
        {
            float[,] r = new float[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        r[i, j] += a[i, k] * b[k, j];

            return r;
        }

        void BuildMatrix(float angle, float scale)
        {
            float[,] sc = {
                {scale, 0, 0},
                {0, scale, 0},
                {0, 0, 1}
            };

            float[,] rot = {
                {(float)Math.Cos(angle), (float)Math.Sin(angle), 0},
                {-(float)Math.Sin(angle), (float)Math.Cos(angle), 0},
                {0, 0, 1}
            };

            matr = Multiply(sc, rot);
        }

        PointF Transform(PointF p)
        {
            float x = p.X * matr[0, 0] + p.Y * matr[1, 0] + matr[2, 0];
            float y = p.X * matr[0, 1] + p.Y * matr[1, 1] + matr[2, 1];

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            return new PointF(cx + x, cy + y);
        }

        void DrawTriangle(Graphics g, float angle, float scale, Color color)
        {
            BuildMatrix(angle, scale);

            Pen pen = new Pen(color, 2);

            PointF[] pts =
            {
                new PointF(0, -50),
                new PointF(-43, 25),
                new PointF(43, 25)
            };

            PointF[] res = new PointF[3];

            for (int i = 0; i < 3; i++)
                res[i] = Transform(pts[i]);

            g.DrawPolygon(pen, res);
            pen.Dispose();
        }

        void DrawAll()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            DrawTriangle(g, angle1, scale1, color1);
            DrawTriangle(g, angle2, scale2, color2);

            g.Dispose();
        }
        // ================= КНОПКИ =================

        // НАРИСОВАТЬ
        private void button1_Click(object sender, EventArgs e)
        {
            DrawAll();
        }

        // ЦВЕТ
        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                if (checkBox1.Checked)
                    color1 = cd.Color;

                if (checkBox2.Checked)
                    color2 = cd.Color;
            }

            DrawAll();
        }

        // СКОРОСТТЬ
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float s;
            if (float.TryParse(textBox1.Text, out s))
            {
                tempSpeed = Math.Abs(s);
            }
        }

        // ВПРАВО
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                tempDir = 1;
        }

        // ВЛЕВО
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                tempDir = -1;
        }

        // ПРИМЕНИТЬ
        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                speed1 = tempSpeed;
                dir1 = tempDir;
            }

            if (checkBox2.Checked)
            {
                speed2 = tempSpeed;
                dir2 = tempDir;
            }
        }

        // ОЧИСТИТЬ 
        private void button3_Click(object sender, EventArgs e)
        {
            timer.Stop();
            isRunning = false;
            button5.Text = "Старт";

            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.Dispose();

            angle1 = 0;
            angle2 = 0;
            scale1 = 1.5f;
            scale2 = 0.5f;
        }

        // СТАРТ / СТОП 
        private void button5_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                timer.Start();
                button5.Text = "Стоп";
            }
            else
            {
                timer.Stop();
                button5.Text = "Старт";
            }

            isRunning = !isRunning;
        }
        // НАЗАД
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle1 += speed1 * dir1;
            angle2 += speed2 * dir2;

            scale2 += 0.01f;
            scale1 -= 0.01f;

            if (scale2 > maxScale2)
                scale2 = 0.5f;

            if (scale1 < minScale1)
                scale1 = 1.5f;

            DrawAll();
        }

        // пустые
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) { }
    }
}