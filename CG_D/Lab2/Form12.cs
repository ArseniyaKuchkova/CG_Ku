using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab2
{
    public partial class Form12 : Form
    {
        float angleX = 0;
        float angleY = 0;
        float angleZ = 0;

        float dx = 0;
        float dy = 0;
        float dz = 0;

        float scaleX = 1;
        float scaleY = 1;
        float scaleZ = 1;

        int reflectX = 1;
        int reflectY = 1;
        int reflectZ = 1;

        float speedX = 0.03f;
        float speedY = 0.03f;
        float speedZ = 0.03f;

        float[,] matr = new float[4, 4];

        Color figColor = Color.Blue;

        bool showAxes = false;
        bool isRun = false;

        bool variant4 = false;

        float axisAngle = 0;

        // направляющие косинусы оси вращения
        float dirX = 0.5f;
        float dirY = 0.7f;
        float dirZ = 0.5f;

        float perspectiveD = 500;

        // обычная фигура
        float[,] figure = new float[5, 4];

        int[,] lines =
        {
            {0,1}, {0,2}, {0,3},
            {4,1}, {4,2}, {4,3},
            {1,2}, {2,3}, {3,1}
        };

        // тетраэдр для варианта 4
        float[,] tetra =
        {
            { 0, 80, 0, 1 },
            { -70, -50, -50, 1 },
            { 70, -50, -50, 1 },
            { 0, -50, 80, 1 }
        };

        int[,] tetraEdges =
        {
            {0,1}, {0,2}, {0,3},
            {1,2}, {2,3}, {3,1}
        };

        int[,] tetraFaces =
        {
            {0,1,2},
            {0,2,3},
            {0,3,1},
            {1,3,2}
        };

        public Form12()
        {
            InitializeComponent();

            // обычная фигура
            figure[0, 0] = 0; figure[0, 1] = 80; figure[0, 2] = 0; figure[0, 3] = 1;
            figure[1, 0] = 70; figure[1, 1] = 0; figure[1, 2] = 0; figure[1, 3] = 1;
            figure[2, 0] = -35; figure[2, 1] = 0; figure[2, 2] = 60; figure[2, 3] = 1;
            figure[3, 0] = -35; figure[3, 1] = 0; figure[3, 2] = -60; figure[3, 3] = 1;
            figure[4, 0] = 0; figure[4, 1] = -80; figure[4, 2] = 0; figure[4, 3] = 1;

            timer1.Interval = 30;

            trackBar1.Minimum = -720;
            trackBar1.Maximum = 720;
            trackBar1.Value = 0;

            trackBar2.Minimum = -100;
            trackBar2.Maximum = 100;
            trackBar2.Value = 0;

            trackBar3.Minimum = 1;
            trackBar3.Maximum = 30;
            trackBar3.Value = 10;

            trackBar4.Minimum = 1;
            trackBar4.Maximum = 30;
            trackBar4.Value = 10;

            trackBar5.Minimum = -720;
            trackBar5.Maximum = 720;
            trackBar5.Value = 0;

            trackBar6.Minimum = -720;
            trackBar6.Maximum = 720;
            trackBar6.Value = 0;

            trackBar7.Minimum = -100;
            trackBar7.Maximum = 100;
            trackBar7.Value = 0;

            trackBar8.Minimum = -100;
            trackBar8.Maximum = 100;
            trackBar8.Value = 0;

            trackBar9.Minimum = 1;
            trackBar9.Maximum = 30;
            trackBar9.Value = 10;

            trackBar10.Minimum = 1;
            trackBar10.Maximum = 30;
            trackBar10.Value = 10;
        }

        // рисование без ряби
        Graphics StartDraw(out Bitmap bmp)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            return g;
        }

        void FinishDraw(Graphics g, Bitmap bmp)
        {
            g.Dispose();

            Image oldImage = pictureBox1.Image;
            pictureBox1.Image = bmp;

            if (oldImage != null)
                oldImage.Dispose();
        }

        // умножение матриц
        float[,] Multiply(float[,] a, float[,] b)
        {
            float[,] r = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        r[i, j] += a[i, k] * b[k, j];

            return r;
        }

        // создание матрицы
        void BuildMatrix()
        {
            float[,] m =
            {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,0,1}
            };

            float[,] sc =
            {
                {scaleX,0,0,0},
                {0,scaleY,0,0},
                {0,0,scaleZ,0},
                {0,0,0,1}
            };

            float[,] refl =
            {
                {reflectX,0,0,0},
                {0,reflectY,0,0},
                {0,0,reflectZ,0},
                {0,0,0,1}
            };

            float[,] rx =
            {
                {1,0,0,0},
                {0,(float)Math.Cos(angleX),(float)Math.Sin(angleX),0},
                {0,-(float)Math.Sin(angleX),(float)Math.Cos(angleX),0},
                {0,0,0,1}
            };

            float[,] ry =
            {
                {(float)Math.Cos(angleY),0,-(float)Math.Sin(angleY),0},
                {0,1,0,0},
                {(float)Math.Sin(angleY),0,(float)Math.Cos(angleY),0},
                {0,0,0,1}
            };

            float[,] rz =
            {
                {(float)Math.Cos(angleZ),(float)Math.Sin(angleZ),0,0},
                {-(float)Math.Sin(angleZ),(float)Math.Cos(angleZ),0,0},
                {0,0,1,0},
                {0,0,0,1}
            };

            float[,] tr =
            {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {dx,dy,dz,1}
            };

            matr = Multiply(m, refl);
            matr = Multiply(matr, sc);
            matr = Multiply(matr, rx);
            matr = Multiply(matr, ry);
            matr = Multiply(matr, rz);
            matr = Multiply(matr, tr);
        }

        // обычное преобразование точки
        PointF Transform(float x, float y, float z)
        {
            float newX = x * matr[0, 0] + y * matr[1, 0] + z * matr[2, 0] + matr[3, 0];
            float newY = x * matr[0, 1] + y * matr[1, 1] + z * matr[2, 1] + matr[3, 1];

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            return new PointF(cx + newX, cy - newY);
        }

        // преобразование 3D-точки
        void Transform3D(float x, float y, float z, float[,] m, out float newX, out float newY, out float newZ)
        {
            newX = x * m[0, 0] + y * m[1, 0] + z * m[2, 0] + m[3, 0];
            newY = x * m[0, 1] + y * m[1, 1] + z * m[2, 1] + m[3, 1];
            newZ = x * m[0, 2] + y * m[1, 2] + z * m[2, 2] + m[3, 2];
        }

        // перспектива с одной точкой схода
        PointF Project(float x, float y, float z)
        {
            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            float k = perspectiveD / (perspectiveD - z);

            return new PointF(cx + x * k, cy - y * k);
        }

        // оси координат
        void DrawAxes(Graphics g)
        {
            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            Pen penX = new Pen(Color.Red, 2);
            Pen penY = new Pen(Color.Green, 2);
            Pen penZ = new Pen(Color.Blue, 2);

            Font font = new Font("Arial", 10, FontStyle.Bold);

            g.DrawLine(penX, cx - 200, cy, cx + 200, cy);
            g.DrawString("X", font, Brushes.Red, cx + 205, cy - 15);

            g.DrawLine(penY, cx, cy + 200, cx, cy - 200);
            g.DrawString("Y", font, Brushes.Green, cx + 5, cy - 215);

            g.DrawEllipse(penZ, cx - 12, cy - 12, 24, 24);
            g.FillEllipse(Brushes.Blue, cx - 4, cy - 4, 8, 8);
            g.DrawString("Z", font, Brushes.Blue, cx + 18, cy + 8);

            penX.Dispose();
            penY.Dispose();
            penZ.Dispose();
            font.Dispose();
        }

        void DrawText(Graphics g)
        {
            g.DrawString(
                "ТУСУР - 62 года. ТУСУР – Чемпион!",
                new Font("Arial", 14, FontStyle.Bold),
                Brushes.DarkBlue,
                10,
                10);

            g.DrawString(
                "min = -100   max = 100",
                new Font("Arial", 10),
                Brushes.Black,
                10,
                40);
        }

        // обычная отрисовка
        void DrawAll()
        {
            if (variant4)
            {
                DrawVariant4();
                return;
            }

            Bitmap bmp;
            Graphics g = StartDraw(out bmp);

            BuildMatrix();

            if (showAxes)
                DrawAxes(g);

            PointF[] p2 = new PointF[5];

            for (int i = 0; i < 5; i++)
            {
                p2[i] = Transform(figure[i, 0], figure[i, 1], figure[i, 2]);
            }

            Pen pen = new Pen(figColor, 2);

            for (int i = 0; i < lines.GetLength(0); i++)
            {
                int a = lines[i, 0];
                int b = lines[i, 1];

                g.DrawLine(pen, p2[a], p2[b]);
            }

            DrawText(g);

            pen.Dispose();
            FinishDraw(g, bmp);
        }

        // матрица поворота вокруг заданной оси
        float[,] AxisMatrix()
        {
            float len = (float)Math.Sqrt(dirX * dirX + dirY * dirY + dirZ * dirZ);

            float l = dirX / len;
            float m = dirY / len;
            float n = dirZ / len;

            float c = (float)Math.Cos(axisAngle);
            float s = (float)Math.Sin(axisAngle);
            float t = 1 - c;

            float[,] r =
            {
                {t*l*l + c,     t*l*m + n*s,   t*l*n - m*s,   0},
                {t*l*m - n*s,   t*m*m + c,     t*m*n + l*s,   0},
                {t*l*n + m*s,   t*m*n - l*s,   t*n*n + c,     0},
                {0,             0,             0,             1}
            };

            return r;
        }

        // видимость грани через нормаль
        bool FaceVisible(float[,] p, int a, int b, int c, float ox, float oy, float oz)
        {
            float ux = p[b, 0] - p[a, 0];
            float uy = p[b, 1] - p[a, 1];
            float uz = p[b, 2] - p[a, 2];

            float vx = p[c, 0] - p[a, 0];
            float vy = p[c, 1] - p[a, 1];
            float vz = p[c, 2] - p[a, 2];

            float nx = uy * vz - uz * vy;
            float ny = uz * vx - ux * vz;
            float nz = ux * vy - uy * vx;

            float gx = (p[a, 0] + p[b, 0] + p[c, 0]) / 3;
            float gy = (p[a, 1] + p[b, 1] + p[c, 1]) / 3;
            float gz = (p[a, 2] + p[b, 2] + p[c, 2]) / 3;

            float check = nx * (ox - gx) + ny * (oy - gy) + nz * (oz - gz);

            if (check > 0)
            {
                nx = -nx;
                ny = -ny;
                nz = -nz;
            }

            float visible = nx * (0 - gx) + ny * (0 - gy) + nz * (perspectiveD - gz);

            return visible > 0;
        }

        // ребро видимо когда входит хоть в 1 грань
        bool EdgeVisible(int a, int b, bool[] faceVisible)
        {
            for (int i = 0; i < 4; i++)
            {
                bool hasA = false;
                bool hasB = false;

                for (int j = 0; j < 3; j++)
                {
                    if (tetraFaces[i, j] == a)
                        hasA = true;

                    if (tetraFaces[i, j] == b)
                        hasB = true;
                }

                if (hasA && hasB && faceVisible[i])
                    return true;
            }

            return false;
        }

        // ось вращения
        void DrawRotationAxis(Graphics g, float[,] matrix)
        {
            float len = (float)Math.Sqrt(dirX * dirX + dirY * dirY + dirZ * dirZ);

            float l = dirX / len;
            float m = dirY / len;
            float n = dirZ / len;

            float x1, y1, z1;
            float x2, y2, z2;

            Transform3D(-150 * l, -150 * m, -150 * n, matrix, out x1, out y1, out z1);
            Transform3D(150 * l, 150 * m, 150 * n, matrix, out x2, out y2, out z2);

            PointF p1 = Project(x1, y1, z1);
            PointF p2 = Project(x2, y2, z2);

            Pen pen = new Pen(Color.Purple, 2);
            pen.DashStyle = DashStyle.Dot;

            g.DrawLine(pen, p1, p2);

            pen.Dispose();
        }

        // вариант 4: тетраэдр, перспектива, нормаль грани
        void DrawVariant4()
        {
            Bitmap bmp;
            Graphics g = StartDraw(out bmp);

            BuildMatrix();

            float[,] axis = AxisMatrix();
            float[,] total = Multiply(axis, matr);

            DrawAxes(g);
            DrawRotationAxis(g, total);

            float[,] p3 = new float[4, 3];
            PointF[] p2 = new PointF[4];

            for (int i = 0; i < 4; i++)
            {
                float x, y, z;

                Transform3D(tetra[i, 0], tetra[i, 1], tetra[i, 2], total, out x, out y, out z);

                p3[i, 0] = x;
                p3[i, 1] = y;
                p3[i, 2] = z;

                p2[i] = Project(x, y, z);
            }

            float ox = 0;
            float oy = 0;
            float oz = 0;

            for (int i = 0; i < 4; i++)
            {
                ox += p3[i, 0];
                oy += p3[i, 1];
                oz += p3[i, 2];
            }

            ox = ox / 4;
            oy = oy / 4;
            oz = oz / 4;

            bool[] faceVis = new bool[4];

            for (int i = 0; i < 4; i++)
            {
                faceVis[i] = FaceVisible(
                    p3,
                    tetraFaces[i, 0],
                    tetraFaces[i, 1],
                    tetraFaces[i, 2],
                    ox,
                    oy,
                    oz);
            }

            Pen solidPen = new Pen(figColor, 2);

            Pen dashPen = new Pen(Color.Gray, 2);
            dashPen.DashStyle = DashStyle.Dash;

            //  невидимые ребра пунктиром
            for (int i = 0; i < tetraEdges.GetLength(0); i++)
            {
                int a = tetraEdges[i, 0];
                int b = tetraEdges[i, 1];

                if (!EdgeVisible(a, b, faceVis))
                    g.DrawLine(dashPen, p2[a], p2[b]);
            }

            // видимые ребра сплошной линией
            for (int i = 0; i < tetraEdges.GetLength(0); i++)
            {
                int a = tetraEdges[i, 0];
                int b = tetraEdges[i, 1];

                if (EdgeVisible(a, b, faceVis))
                    g.DrawLine(solidPen, p2[a], p2[b]);
            }

            DrawText(g);

            solidPen.Dispose();
            dashPen.Dispose();

            FinishDraw(g, bmp);
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            scaleZ = trackBar10.Value / 10f;
            DrawAll();
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            scaleY = trackBar9.Value / 10f;
            DrawAll();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showAxes = !showAxes;
            DrawAll();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                figColor = dlg.Color;
                DrawAll();
            }
        }
        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            dz = trackBar8.Value;
            DrawAll();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            dy = trackBar7.Value;
            DrawAll();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            if (variant4)
                axisAngle = trackBar6.Value / 100f;
            else
                angleZ = trackBar6.Value / 100f;

            DrawAll();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            angleY = trackBar5.Value / 100f;
            DrawAll();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            speedX = trackBar4.Value / 100f;
            speedY = trackBar4.Value / 100f;
            speedZ = trackBar4.Value / 100f;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            scaleX = trackBar3.Value / 10f;
            DrawAll();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            dx = trackBar2.Value;
            DrawAll();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            angleX = trackBar1.Value / 100f;
            DrawAll();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            reflectX *= -1;
            DrawAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reflectY *= -1;
            DrawAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reflectZ *= -1;
            DrawAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isRun)
            {
                timer1.Start();
                button3.Text = "Стоп";
            }
            else
            {
                timer1.Stop();
                button3.Text = "Старт";
            }

            isRun = !isRun;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button3.Text = "Старт";
            isRun = false;
            variant4 = false;

            Image oldImage = pictureBox1.Image;
            pictureBox1.Image = null;

            if (oldImage != null)
                oldImage.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            variant4 = false;
            DrawAll();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            variant4 = true;

            angleX = 0.4f;
            angleY = 0.5f;
            angleZ = 0;

            dx = 0;
            dy = 0;
            dz = 0;

            scaleX = 1;
            scaleY = 1;
            scaleZ = 1;

            axisAngle = 0;
            trackBar6.Value = 0;

            DrawAll();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
        //таймер
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (variant4)
            {
                axisAngle += speedX;
            }
            else
            {
                angleX += speedX;
                angleY += speedY;
                angleZ += speedZ;
            }

            DrawAll();
        }
        //пустые
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}