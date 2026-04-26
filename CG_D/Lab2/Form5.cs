using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form5 : Form
    {
        // матрица
        float[,] matr = new float[3, 3];

        // парам
        float dx = 0;
        float dy = 0;
        float scale = 1;
        float angle = 0;

        int reflectX = 1;
        int reflectY = 1;

        bool isFigure = false;   // бантик или квадрат
        bool showAxes = false;   // показывать оси
        bool showShape = false;  // показывать фигуру

        // стиль линии
        float penWidth = 2;
        DashStyle penStyle = DashStyle.Solid;
        Color penColor = Color.Blue;
        float dashStep = 5;

        public Form5()
        {
            InitializeComponent();
        }

        // умножение матриц
        float[,] Multiply(float[,] a, float[,] b)
        {
            float[,] r = new float[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        r[i, j] += a[i, k] * b[k, j];

            return r;
        }

        // создание матрицы
        void BuildMatrix()
        {
            // единичная
            float[,] m = {
                {1,0,0},
                {0,1,0},
                {0,0,1}
            };

            // отражение
            float[,] refl = {
                {reflectX,0,0},
                {0,reflectY,0},
                {0,0,1}
            };

            // масштаб
            float[,] sc = {
                {scale,0,0},
                {0,scale,0},
                {0,0,1}
            };

            // поворот
            float[,] rot = {
                {(float)Math.Cos(angle),(float)Math.Sin(angle),0},
                {-(float)Math.Sin(angle),(float)Math.Cos(angle),0},
                {0,0,1}
            };

            // сдвиг
            float[,] tr = {
                {1,0,0},
                {0,1,0},
                {dx,dy,1}
            };

            matr = Multiply(m, refl);
            matr = Multiply(matr, sc);
            matr = Multiply(matr, rot);
            matr = Multiply(matr, tr);
        }

        // применение матрицы
        PointF Transform(PointF p)
        {
            float x = p.X * matr[0, 0] + p.Y * matr[1, 0] + matr[2, 0];
            float y = p.X * matr[0, 1] + p.Y * matr[1, 1] + matr[2, 1];

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            return new PointF(cx + x, cy + y);
        }

        // оси
        void DrawAxes(Graphics g)
        {
            using (Pen pen = new Pen(Color.Red, 1))
            {
                int cx = pictureBox1.Width / 2;
                int cy = pictureBox1.Height / 2;

                g.DrawLine(pen, cx - 200, cy, cx + 200, cy);
                g.DrawLine(pen, cx, cy - 200, cx, cy + 200);
            }
        }

        // перо
        Pen CreatePen()
        {
            Pen pen = new Pen(penColor, penWidth);

            if (penStyle == DashStyle.Dash)
                pen.DashPattern = new float[] { dashStep, dashStep };
            else
                pen.DashStyle = DashStyle.Solid;

            return pen;
        }

        // квадрат
        void DrawKv(Graphics g)
        {
            using (Pen pen = CreatePen())
            {
                PointF[] pts = {
                    new PointF(-50,0),
                    new PointF(0,50),
                    new PointF(50,0),
                    new PointF(0,-50)
                };

                PointF[] res = new PointF[4];

                for (int i = 0; i < 4; i++)
                    res[i] = Transform(pts[i]);

                g.DrawPolygon(pen, res);
            }
        }

        // бантик!
        void DrawFigure(Graphics g)
        {
            using (Pen pen = CreatePen())
            {
                PointF[] pts = {
                    new PointF(-60,-50),
                    new PointF(0,-20),
                    new PointF(60,-50),
                    new PointF(60,50),
                    new PointF(0,20),
                    new PointF(-60,50)
                };

                PointF[] res = new PointF[6];

                for (int i = 0; i < 6; i++)
                    res[i] = Transform(pts[i]);

                g.DrawPolygon(pen, res);
            }
        }

        // отрисовка
        void DrawAll()
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);

            BuildMatrix();

            if (showAxes)
                DrawAxes(g);

            if (showShape)
            {
                if (isFigure)
                    DrawFigure(g);
                else
                    DrawKv(g);
            }

            g.Dispose();
        }

        // ОСИ
        private void button1_Click(object sender, EventArgs e)
        {
            showAxes = !showAxes;
            DrawAll();
        }

        // КВАДРАТ
        private void button2_Click(object sender, EventArgs e)
        {
            isFigure = false;
            showShape = true;
            DrawAll();
        }

        // БАНТИК
        private void button13_Click(object sender, EventArgs e)
        {
            isFigure = true;
            showShape = true;
            DrawAll();
        }

        // ОЧИСТИТЬ
        private void button3_Click(object sender, EventArgs e)
        {
            showAxes = false;
            showShape = false;

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            g.Dispose();
        }

        // СДВИГ
        private void button4_Click(object sender, EventArgs e) { dx += 10; DrawAll(); }
        private void button5_Click(object sender, EventArgs e) { dx -= 10; DrawAll(); }
        private void button6_Click(object sender, EventArgs e) { dy += 10; DrawAll(); }
        private void button7_Click(object sender, EventArgs e) { dy -= 10; DrawAll(); }

        // МАСШТАБ
        private void button8_Click(object sender, EventArgs e) { scale += 0.1f; DrawAll(); }
        private void button9_Click(object sender, EventArgs e) { scale -= 0.1f; DrawAll(); }

        // ПОВОРОТ
        private void button10_Click(object sender, EventArgs e) { angle += 0.2f; DrawAll(); }
        private void button16_Click(object sender, EventArgs e) { angle -= 0.2f; DrawAll(); }

        // ОТРАЖЕНИЕ
        private void button11_Click(object sender, EventArgs e)
        {
            reflectY *= -1;
            DrawAll();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            reflectX *= -1;
            DrawAll();
        }

        // ТОЛСТАЯ
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                penWidth = 4;
                DrawAll();
            }
        }

        // ТОНКАЯ
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                penWidth = 1;
                DrawAll();
            }
        }

        // ПУНКТИРНАЯ
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                penStyle = DashStyle.Dash;
                DrawAll();
            }
        }

        // СПЛОШНАЯ
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                penStyle = DashStyle.Solid;
                DrawAll();
            }
        }

        // РАЗМЕР ПУНКТИРА
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float val;
            if (float.TryParse(textBox1.Text, out val))
            {
                dashStep = val;
                DrawAll();
            }
        }

        // ЦВЕТ
        private void button15_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                penColor = dlg.Color;
                DrawAll();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                button12.Text = "Старт";
            }
            else
            {
                timer1.Start();
                button12.Text = "Стоп";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }
        private void btnSpaceship_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dx += 2;
            DrawAll();
        }

        // ПУСТЫЕ
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void Form5_Load(object sender, EventArgs e) { }

        private void button18_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.ShowDialog();
        }
    }
}