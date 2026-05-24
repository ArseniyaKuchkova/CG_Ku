using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form13 : Form
    {
        // Данные октаэдра
        private Point3D[] vertices;
        private (int, int)[] edges;
        private int[][] faces;
        private float currentAngle = 0;
        private bool isAnimating = false;

        // Коэффициенты диметрии
        private readonly double dimX = 0.935;
        private readonly double dimY = 0.354;

        public Form13()
        {
            InitializeComponent();
            InitializeOctahedron();

            pictureBox1.Paint += PictureBox1_Paint;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            timer1.Tick += Timer1_Tick;
        }

        private void InitializeOctahedron()
        {
            // Вершины октаэдра
            vertices = new Point3D[]
            {
                new Point3D(1.2, 0, 0),    
                new Point3D(-1.2, 0, 0),   
                new Point3D(0, 1.2, 0),    
                new Point3D(0, -1.2, 0),   
                new Point3D(0, 0, 1.2),  
                new Point3D(0, 0, -1.2)   
            };

            // Рёбра
            edges = new (int, int)[]
            {
                (0,2), (0,3), (0,4), (0,5),
                (1,2), (1,3), (1,4), (1,5),
                (2,4), (2,5), (3,4), (3,5)
            };

            // Грани
            faces = new int[][]
            {
                new int[] {0,2,4}, new int[] {0,4,3}, new int[] {0,3,5}, new int[] {0,5,2},
                new int[] {1,4,2}, new int[] {1,3,4}, new int[] {1,5,3}, new int[] {1,2,5}
            };
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;
            float scale = 130;

            Point3D[] rotated = RotateAroundAxis(vertices, currentAngle);
            PointF[] screenPoints = ProjectToDimetric(rotated, scale, cx, cy);
            bool[] visibleEdges = RobertsAlgorithm(rotated);

            // Рисуем оси координат
            DrawAxes(g, cx, cy, scale);

            // Рисуем ось вращения
            DrawRotationAxis(g, cx, cy, scale);

            // Рисуем рёбра
            for (int i = 0; i < edges.Length; i++)
            {
                var edge = edges[i];
                PointF p1 = screenPoints[edge.Item1];
                PointF p2 = screenPoints[edge.Item2];

                if (visibleEdges[i])
                {
                    using (Pen pen = new Pen(Color.Lime, 2))
                    {
                        g.DrawLine(pen, p1, p2);
                    }
                }
                else
                {
                    using (Pen pen = new Pen(Color.Gray, 1.5f))
                    {
                        pen.DashStyle = DashStyle.Dash;
                        g.DrawLine(pen, p1, p2);
                    }
                }
            }

            // Рисуем вершины
            foreach (var p in screenPoints)
            {
                g.FillEllipse(Brushes.Yellow, p.X - 3, p.Y - 3, 6, 6);
            }
        }

        private Point3D[] RotateAroundAxis(Point3D[] verts, float angleDeg)
        {
            double rad = angleDeg * Math.PI / 180.0;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);

            double ux = 1.0 / Math.Sqrt(3);
            double uy = 1.0 / Math.Sqrt(3);
            double uz = 1.0 / Math.Sqrt(3);

            Point3D[] result = new Point3D[verts.Length];
            for (int i = 0; i < verts.Length; i++)
            {
                double x = verts[i].X;
                double y = verts[i].Y;
                double z = verts[i].Z;

                double dot = x * ux + y * uy + z * uz;
                double crossX = uy * z - uz * y;
                double crossY = uz * x - ux * z;
                double crossZ = ux * y - uy * x;

                double rotX = x * cos + crossX * sin + ux * dot * (1 - cos);
                double rotY = y * cos + crossY * sin + uy * dot * (1 - cos);
                double rotZ = z * cos + crossZ * sin + uz * dot * (1 - cos);

                result[i] = new Point3D(rotX, rotY, rotZ);
            }
            return result;
        }

        private PointF[] ProjectToDimetric(Point3D[] points, float scale, int cx, int cy)
        {
            PointF[] result = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                float screenX = (float)(points[i].X * dimX + points[i].Z * dimY) * scale + cx;
                float screenY = (float)(points[i].Y * dimX - points[i].Z * dimY) * scale + cy;
                result[i] = new PointF(screenX, screenY);
            }
            return result;
        }

        private bool[] RobertsAlgorithm(Point3D[] rotatedVerts)
        {
            bool[] edgeVisible = new bool[edges.Length];

            // Барицентр
            Point3D barycenter = new Point3D(0, 0, 0);
            foreach (var v in rotatedVerts)
            {
                barycenter.X += v.X;
                barycenter.Y += v.Y;
                barycenter.Z += v.Z;
            }
            barycenter.X /= rotatedVerts.Length;
            barycenter.Y /= rotatedVerts.Length;
            barycenter.Z /= rotatedVerts.Length;

            // Наблюдатель
            Point3D viewer = new Point3D(0, 0, -1000);
            bool[] faceVisible = new bool[faces.Length];

            for (int f = 0; f < faces.Length; f++)
            {
                Point3D v1 = rotatedVerts[faces[f][0]];
                Point3D v2 = rotatedVerts[faces[f][1]];
                Point3D v3 = rotatedVerts[faces[f][2]];

                double ux = v2.X - v1.X, uy = v2.Y - v1.Y, uz = v2.Z - v1.Z;
                double vx = v3.X - v1.X, vy = v3.Y - v1.Y, vz = v3.Z - v1.Z;

                double nx = uy * vz - uz * vy;
                double ny = uz * vx - ux * vz;
                double nz = ux * vy - uy * vx;

                double A = nx, B = ny, C = nz;
                double D = -(A * v1.X + B * v1.Y + C * v1.Z);

                double valInside = A * barycenter.X + B * barycenter.Y + C * barycenter.Z + D;
                if (valInside < 0)
                {
                    A = -A; B = -B; C = -C; D = -D;
                }

                double viewVal = A * viewer.X + B * viewer.Y + C * viewer.Z + D;
                faceVisible[f] = (viewVal < 0);
            }

            for (int e = 0; e < edges.Length; e++)
            {
                int vA = edges[e].Item1;
                int vB = edges[e].Item2;

                for (int f = 0; f < faces.Length; f++)
                {
                    if (faceVisible[f])
                    {
                        bool hasA = false, hasB = false;
                        foreach (int idx in faces[f])
                        {
                            if (idx == vA) hasA = true;
                            if (idx == vB) hasB = true;
                        }
                        if (hasA && hasB)
                        {
                            edgeVisible[e] = true;
                            break;
                        }
                    }
                }
            }

            return edgeVisible;
        }

        private void DrawAxes(Graphics g, int cx, int cy, float scale)
        {
            Point3D origin = new Point3D(0, 0, 0);
            Point3D axisX = new Point3D(1.5, 0, 0);
            Point3D axisY = new Point3D(0, 1.5, 0);
            Point3D axisZ = new Point3D(0, 0, 1.5);

            Point3D[] pts = { origin, axisX, axisY, axisZ };
            PointF[] screen = ProjectToDimetric(pts, scale, cx, cy);

            using (Pen penX = new Pen(Color.Red, 2))
            using (Pen penY = new Pen(Color.Green, 2))
            using (Pen penZ = new Pen(Color.Blue, 2))
            {
                g.DrawLine(penX, screen[0], screen[1]);
                g.DrawLine(penY, screen[0], screen[2]);
                g.DrawLine(penZ, screen[0], screen[3]);
            }

            Font font = new Font("Arial", 8);
            g.DrawString("X", font, Brushes.Red, screen[1].X + 3, screen[1].Y - 3);
            g.DrawString("Y", font, Brushes.Green, screen[2].X + 3, screen[2].Y - 3);
            g.DrawString("Z", font, Brushes.Blue, screen[3].X + 3, screen[3].Y - 3);
        }

        private void DrawRotationAxis(Graphics g, int cx, int cy, float scale)
        {
            Point3D p1 = new Point3D(-1.8, -1.8, -1.8);
            Point3D p2 = new Point3D(1.8, 1.8, 1.8);

            Point3D[] axisPts = { p1, p2 };
            PointF[] screen = ProjectToDimetric(axisPts, scale, cx, cy);

            using (Pen pen = new Pen(Color.Orange, 2.5f))
            {
                pen.DashStyle = DashStyle.DashDot;
                g.DrawLine(pen, screen[0], screen[1]);
            }
        }

        // Обработчики кнопок
        private void Button1_Click(object sender, EventArgs e)
        {
            isAnimating = true;
            timer1.Start();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            isAnimating = false;
            timer1.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            currentAngle = 0;
            label2.Text = "0°";
            pictureBox1.Invalidate();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (!isAnimating)
            {
                currentAngle += 5;
                if (currentAngle >= 360) currentAngle -= 360;
                label2.Text = ((int)currentAngle) + "°";
                pictureBox1.Invalidate();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (!isAnimating)
            {
                currentAngle -= 5;
                if (currentAngle < 0) currentAngle += 360;
                label2.Text = ((int)currentAngle) + "°";
                pictureBox1.Invalidate();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            currentAngle += 5;
            if (currentAngle >= 360) currentAngle -= 360;
            label2.Text = ((int)currentAngle) + "°";
            pictureBox1.Invalidate();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
        }
    }

    // Класс точки в 3D
    public class Point3D
    {
        public double X, Y, Z;
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
