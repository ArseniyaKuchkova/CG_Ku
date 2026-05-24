using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            InitCube(); // Инициализация куба
            UpdateTransform(); // Первое обновление
        }
        // ================= ПОЛЯ КЛАССА =================
        private Point3D[] originalVertices;  // Исходные вершины куба
        private Point3D[] transformedVertices; // Преобразованные вершины
        private int[][] faces; // Грани куба

        // Параметры трансформации
        private double transX = 0, transY = 0, transZ = 0;
        private double rotX = 0, rotY = 0, rotZ = 0;
        private double scaleX = 1, scaleY = 1, scaleZ = 1;
        private bool autoRotate = false;
        private double speed = 0.05;

        // Структура для 3D точки
        public struct Point3D
        {
            public double X, Y, Z;
            public Point3D(double x, double y, double z) { X = x; Y = y; Z = z; }
        }

        // Матрица 4x4
        public class Matrix4x4
        {
            public double[,] M = new double[4, 4];
            public Matrix4x4()
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        M[i, j] = (i == j) ? 1 : 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Сброс всех параметров
            transX = transY = transZ = 0;
            rotX = rotY = rotZ = 0;
            scaleX = scaleY = scaleZ = 1;
            autoRotate = false;
            timer1.Stop();

            // Сброс трекбаров
            trackBar1.Value = 0; trackBar2.Value = 0; trackBar3.Value = 0;
            trackBar4.Value = 0; trackBar5.Value = 0; trackBar6.Value = 0;
            trackBar7.Value = 100; trackBar8.Value = 100; trackBar9.Value = 100;

            UpdateTransform();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            autoRotate = !autoRotate;
            if (autoRotate)
            {
                timer1.Start();
                button2.Text = "Автовращение ВЫКЛ";
            }
            else
            {
                timer1.Stop();
                button2.Text = "Автовращение ВКЛ";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            scaleY *= -1; // Отражение относительно XY (инверсия Y)
            UpdateTransform();
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            scaleX *= -1; // Отражение относительно XZ (инверсия X)
            UpdateTransform();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            transY = trackBar2.Value / 50.0;
            UpdateTransform();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            transZ = trackBar3.Value / 50.0;
            UpdateTransform();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            rotX = trackBar4.Value;
            UpdateTransform();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            rotY = trackBar5.Value;
            UpdateTransform();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            rotZ = trackBar6.Value;
            UpdateTransform();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            scaleX = trackBar7.Value / 100.0;
            UpdateTransform();
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            scaleY = trackBar8.Value / 100.0;
            UpdateTransform();
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            scaleZ = trackBar9.Value / 100.0;
            UpdateTransform();
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            speed = trackBar10.Value / 100.0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rotY += speed * 5; // Вращение вокруг оси Y
            if (rotY > 360) rotY -= 360;

            trackBar5.Value = (int)rotY; // Обновление трекбара
            UpdateTransform();
        }

        private void InitCube()
        {
            // Инициализация вершин куба (Гексаэдр, вариант 10)
            originalVertices = new Point3D[]
            {
        new Point3D(-1, -1, -1), new Point3D( 1, -1, -1),
        new Point3D( 1,  1, -1), new Point3D(-1,  1, -1),
        new Point3D(-1, -1,  1), new Point3D( 1, -1,  1),
        new Point3D( 1,  1,  1), new Point3D(-1,  1,  1)
            };

            transformedVertices = new Point3D[8];

            // Грани куба (индексы вершин)
            faces = new int[][]
            {
        new int[] {0, 1, 2, 3}, // Задняя грань
        new int[] {4, 5, 6, 7}, // Передняя грань
        new int[] {0, 4, 7, 3}, // Левая грань
        new int[] {1, 5, 6, 2}, // Правая грань
        new int[] {3, 2, 6, 7}, // Верхняя грань
        new int[] {0, 1, 5, 4}  // Нижняя грань
            };
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            scaleZ *= -1; // Отражение относительно YZ (инверсия Z)
            UpdateTransform();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            transX = trackBar1.Value / 50.0;
            UpdateTransform();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int W = pictureBox1.Width;
            int H = pictureBox1.Height;
            double K = 80; // Коэффициент масштаба
            double CX = W / 2.0;
            double CY = H / 2.0;

            // Функция ортогональной проекции
            PointF Project(Point3D p) => new PointF(
                (float)(CX + p.X * K),
                (float)(CY - p.Y * K)
            );

            // Рисуем оси координат (Задание 2)
            Pen axisPen = new Pen(Color.Gray, 1);
            g.DrawLine(axisPen, Project(new Point3D(-3, 0, 0)), Project(new Point3D(3, 0, 0)));
            g.DrawString("X", Font, Brushes.Gray, Project(new Point3D(3.1, 0, 0)));

            g.DrawLine(axisPen, Project(new Point3D(0, -3, 0)), Project(new Point3D(0, 3, 0)));
            g.DrawString("Y", Font, Brushes.Gray, Project(new Point3D(0, 3.1, 0)));

            g.DrawLine(axisPen, Project(new Point3D(0, 0, -3)), Project(new Point3D(0, 0, 3)));
            g.DrawString("Z", Font, Brushes.Gray, Project(new Point3D(0, 0, 3.1)));

            // Рисуем рёбра куба
            Pen edgePen = new Pen(Color.Blue, 2);
            foreach (var face in faces)
            {
                List<PointF> points = new List<PointF>();
                foreach (int idx in face)
                    points.Add(Project(transformedVertices[idx]));
                points.Add(points[0]); // Замыкаем контур
                g.DrawLines(edgePen, points.ToArray());
            }

            // Рисуем вершины
            foreach (var v in transformedVertices)
            {
                PointF p = Project(v);
                g.FillEllipse(Brushes.Red, p.X - 3, p.Y - 3, 6, 6);
            }

            // Вычисляем мин/макс координаты (Задание для самостоятельного выполнения)
            double minX = double.MaxValue, maxX = double.MinValue;
            double minY = double.MaxValue, maxY = double.MinValue;
            double minZ = double.MaxValue, maxZ = double.MinValue;

            foreach (var v in transformedVertices)
            {
                if (v.X < minX) minX = v.X;
                if (v.X > maxX) maxX = v.X;
                if (v.Y < minY) minY = v.Y;
                if (v.Y > maxY) maxY = v.Y;
                if (v.Z < minZ) minZ = v.Z;
                if (v.Z > maxZ) maxZ = v.Z;
            }

            // Отображаем мин/макс на экране
            string coordsText = $"Мин: ({minX:F2}, {minY:F2}, {minZ:F2})\n" +
                                $"Макс: ({maxX:F2}, {maxY:F2}, {maxZ:F2})";
            g.DrawString(coordsText, new Font("Arial", 10), Brushes.Black, new PointF(10, 10));

            // Фраза про ТУСУР (Задание для самостоятельного выполнения)
            string tusurText = "ТУСУР - 1962 года. ТУСУР – Чемпион!";
            g.DrawString(tusurText, new Font("Arial", 12, FontStyle.Bold),
                         Brushes.DarkRed, new PointF(10, H - 30));
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void UpdateTransform()
        {
            // Создаём матрицы преобразований
            Matrix4x4 S = new Matrix4x4();
            S.M[0, 0] = scaleX; S.M[1, 1] = scaleY; S.M[2, 2] = scaleZ;

            double cx = Math.Cos(rotX * Math.PI / 180.0);
            double sx = Math.Sin(rotX * Math.PI / 180.0);
            Matrix4x4 Rx = new Matrix4x4();
            Rx.M[1, 1] = cx; Rx.M[1, 2] = -sx;
            Rx.M[2, 1] = sx; Rx.M[2, 2] = cx;

            double cy = Math.Cos(rotY * Math.PI / 180.0);
            double sy = Math.Sin(rotY * Math.PI / 180.0);
            Matrix4x4 Ry = new Matrix4x4();
            Ry.M[0, 0] = cy; Ry.M[0, 2] = sy;
            Ry.M[2, 0] = -sy; Ry.M[2, 2] = cy;

            double cz = Math.Cos(rotZ * Math.PI / 180.0);
            double sz = Math.Sin(rotZ * Math.PI / 180.0);
            Matrix4x4 Rz = new Matrix4x4();
            Rz.M[0, 0] = cz; Rz.M[0, 1] = -sz;
            Rz.M[1, 0] = sz; Rz.M[1, 1] = cz;

            Matrix4x4 T = new Matrix4x4();
            T.M[0, 3] = transX; T.M[1, 3] = transY; T.M[2, 3] = transZ;

            // Объединяем матрицы: T * Rz * Ry * Rx * S
            Matrix4x4 M = MatrixMultiply(T, MatrixMultiply(Rz, MatrixMultiply(Ry, MatrixMultiply(Rx, S))));

            // Применяем матрицу ко всем вершинам
            for (int i = 0; i < 8; i++)
                transformedVertices[i] = TransformPoint(M, originalVertices[i]);

            pictureBox1.Invalidate(); // Перерисовка
        }
        private Matrix4x4 MatrixMultiply(Matrix4x4 A, Matrix4x4 B)
        {
            Matrix4x4 C = new Matrix4x4();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        C.M[i, j] += A.M[i, k] * B.M[k, j];
            return C;
        }

        private Point3D TransformPoint(Matrix4x4 M, Point3D p)
        {
            double w = M.M[3, 0] * p.X + M.M[3, 1] * p.Y + M.M[3, 2] * p.Z + M.M[3, 3];
            double x = (M.M[0, 0] * p.X + M.M[0, 1] * p.Y + M.M[0, 2] * p.Z + M.M[0, 3]) / w;
            double y = (M.M[1, 0] * p.X + M.M[1, 1] * p.Y + M.M[1, 2] * p.Z + M.M[1, 3]) / w;
            double z = (M.M[2, 0] * p.X + M.M[2, 1] * p.Y + M.M[2, 2] * p.Z + M.M[2, 3]) / w;
            return new Point3D(x, y, z);
        }
    }
}
