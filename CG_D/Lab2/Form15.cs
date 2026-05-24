using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab2.Form10;

namespace Lab2
{
    public partial class Form15 : Form
    {
        // --- Переменные для 3D-графики ---
        private List<Point3D> vertices = new List<Point3D>();
        private int steps = 40;

        // Параметры трансформации
        private double angleX = 0.3, angleY = 0.5, angleZ = 0;
        private double moveX = 0, moveY = 0, moveZ = 0;
        private double scale = 50.0;
        private bool autoRotate = true;
        private int rotDirection = 1;
        private double rotSpeed = 0.02;

        // Перья для рисования
        private Pen mainPen = new Pen(Color.Blue, 2) { DashStyle = DashStyle.Solid };
        private Pen hiddenPen = new Pen(Color.Gray, 1.5f) { DashStyle = DashStyle.Dash };

        public Form15()
        {
            InitializeComponent();

            this.Text = "ЛР4: Руководитель + Вариант 3";
            this.DoubleBuffered = true;

            // Генерируем поверхность
            GenerateSurface();

            // 1. Изначально отключаем авто-вращение
            autoRotate = false;

            // 2. Если есть чекбокс авто-вращения, снимаем с него галочку
            if (checkBox2 != null) checkBox2.Checked = false;

            // 3. Настраиваем таймер, но НЕ запускаем его сразу
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            timer1.Stop(); // <--- ВАЖНО: Таймер остановлен

            // Убедимся, что panel2 поверх panel1
            if (panel2 != null)
                panel2.BringToFront();
        

        }

        // --- ГЕНЕРАЦИЯ ПОВЕРХНОСТИ (Вариант 3) ---
        // Формула: Z = (sin(x) + cos(y))^2
        private void GenerateSurface()
        {
            vertices.Clear();
            // Диапазон [-3; 3] для X и Y, как в таблице
            double xMin = -3, xMax = 3;
            double yMin = -3, yMax = 3;

            double dx = (xMax - xMin) / steps;
            double dy = (yMax - yMin) / steps;

            for (int i = 0; i <= steps; i++)
            {
                for (int j = 0; j <= steps; j++)
                {
                    double x = xMin + i * dx;
                    double y = yMin + j * dy;

                    // Новая формула: Z = (sin(x) + cos(y))^2
                    // 1. Считаем сумму синуса от x и косинуса от y
                    double sum = Math.Sin(x) + Math.Cos(y);
                    // 2. Возводим результат в квадрат
                    double z = sum * sum;

                    vertices.Add(new Point3D(x, y, z));
                }
            }
        }
        // --- МАТЕМАТИКА ПРЕОБРАЗОВАНИЙ ---
        private Point3D Transform(Point3D p)
        {
            // Масштаб
            double sx = p.X * scale;
            double sy = p.Y * scale;
            double sz = p.Z * scale;

            // Перемещение
            double tx = sx + moveX;
            double ty = sy + moveY;
            double tz = sz + moveZ;
            // Вращение
            double cosX = Math.Cos(angleX), sinX = Math.Sin(angleX);
            double cosY = Math.Cos(angleY), sinY = Math.Sin(angleY);
            double cosZ = Math.Cos(angleZ), sinZ = Math.Sin(angleZ);

            double y1 = ty * cosX - tz * sinX;
            double z1 = ty * sinX + tz * cosX;
            double x2 = tx * cosY + z1 * sinY;
            double z2 = -tx * sinY + z1 * cosY;
            double x3 = x2 * cosZ - y1 * sinZ;
            double y3 = x2 * sinZ + y1 * cosZ;

            return new Point3D(x3, y3, z2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (autoRotate)
            {
                // ВАЖНО: rotDirection должен быть здесь!
                angleY += rotSpeed * rotDirection;
                panel2.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    mainPen.Color = cd.Color;
                    hiddenPen.Color = Color.FromArgb(100, cd.Color);
                    panel2.Invalidate();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Меняем направление на противоположное
            rotDirection = -rotDirection;

            // Обновляем текст кнопки
            if (rotDirection == 1)
                button2.Text = "Против часовой";
            else
                button2.Text = "По часовой";

            // Принудительно перерисовываем
            panel2.Invalidate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2 != null && comboBox1 != null && comboBox1.SelectedIndex != 0)
            {
                float step = (float)numericUpDown2.Value;
                mainPen.DashPattern = new float[] { step, step };
                hiddenPen.DashPattern = new float[] { step, step };
                panel2.Invalidate();
            }
        }
       
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1 != null)
            {
                mainPen.Width = (float)numericUpDown1.Value;
                hiddenPen.Width = (float)numericUpDown1.Value / 1.5f;
                panel2.Invalidate();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1 != null)
            {
                if (numericUpDown2 != null)
                    numericUpDown2.Enabled = (comboBox1.SelectedIndex != 0);

                switch (comboBox1.SelectedIndex)
                {
                    case 0: mainPen.DashStyle = DashStyle.Solid; break;
                    case 1: mainPen.DashStyle = DashStyle.Dash; break;
                    case 2: mainPen.DashStyle = DashStyle.DashDot; break;
                }
                panel2.Invalidate();
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3 != null)
                rotSpeed = (double)numericUpDown3.Value / 200.0;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2 != null)
            {
                autoRotate = checkBox2.Checked;
                if (timer1 != null) timer1.Enabled = autoRotate;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Invalidate();
        }

        private PointF Project(Point3D p, float cx, float cy)
        {
            float focal = 600f;
            float s = focal / (focal + (float)p.Z + 5f);
            return new PointF(cx + (float)p.X * s, cy - (float)p.Y * s);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1 != null)
            {
                angleX = trackBar1.Value * Math.PI / 180;
                panel2.Invalidate();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2 != null)
            {
                angleY = trackBar2.Value * Math.PI / 180;
                panel2.Invalidate();
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (trackBar3 != null)
            {
                angleZ = trackBar3.Value * Math.PI / 180;
                panel2.Invalidate();
            }
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            if (trackBar4 != null)
            {
                moveX = trackBar4.Value;
                panel2.Invalidate();
            }
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            if (trackBar5 != null)
            {
                moveY = trackBar5.Value;
                panel2.Invalidate();
            }
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            // Умножаем значение трекбара на 0.5
            // Если трекбар на 100, scale будет 50 (нормальный размер)
            // Если трекбар на 20, scale будет 10 (маленький)
            // Если трекбар на 300, scale будет 150 (огромный)
            scale = trackBar6.Value * 0.5;

            panel2.Invalidate();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // --- ОТРИСОВКА ---
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (panel2 == null) return;

            e.Graphics.Clear(Color.WhiteSmoke);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float cx = panel2.Width / 2f;
            float cy = panel2.Height / 2f;

            // Трансформируем вершины
            List<Point3D> transformed = new List<Point3D>();
            double minX = double.MaxValue, maxX = double.MinValue;
            double minY = double.MaxValue, maxY = double.MinValue;
            double minZ = double.MaxValue, maxZ = double.MinValue;
            foreach (var v in vertices)
            {
                var t = Transform(v);
                transformed.Add(t);
                if (t.X < minX) minX = t.X; if (t.X > maxX) maxX = t.X;
                if (t.Y < minY) minY = t.Y; if (t.Y > maxY) maxY = t.Y;
                if (t.Z < minZ) minZ = t.Z; if (t.Z > maxZ) maxZ = t.Z;
            }

            // Вывод координат
            if (label1 != null)
                label1.Text = $"Мировые координаты: X[{minX:F1};{maxX:F1}] Y[{minY:F1};{maxY:F1}] Z[{minZ:F1};{maxZ:F1}]";

            // Фраза ТУСУР (слева вверху panel2)
            e.Graphics.DrawString("ТУСУР- 1962 года. ТУСУР – Чемпион!",
                new Font("Arial", 12, FontStyle.Bold), Brushes.DarkRed, 20, 20);

            // Заглушка логотипа (слева вверху panel2)
            e.Graphics.DrawRectangle(Pens.Gray, 20, 50, 40, 40);
            e.Graphics.DrawString("ТУСУР", new Font("Arial", 8), Brushes.Gray, 25, 65);

            // Ось вращения (Y)
            e.Graphics.DrawLine(new Pen(Color.Red, 2), cx, cy - 300, cx, cy + 300);
            e.Graphics.DrawString("Y", new Font("Arial", 10), Brushes.Red, cx + 5, cy - 300);

            // Отрисовка сетки
            for (int i = 0; i < steps; i++)
            {
                for (int j = 0; j < steps; j++)
                {
                    int idx0 = i * (steps + 1) + j;
                    int idx1 = idx0 + 1;
                    int idx2 = idx0 + steps + 1;
                    int idx3 = idx2 + 1;

                    if (idx3 >= transformed.Count) continue;

                    Point3D a = transformed[idx0];
                    Point3D b = transformed[idx1];
                    Point3D c = transformed[idx2];
                    Point3D d = transformed[idx3];
                    // Нормаль для видимости
                    double abx = b.X - a.X, aby = b.Y - a.Y;
                    double acx = c.X - a.X, acy = c.Y - a.Y;
                    double normalZ = abx * acy - aby * acx;

                    bool isVisible = normalZ > 0;
                    Pen penToUse = mainPen;
                    if (!isVisible && checkBox1 != null && checkBox1.Checked)
                        penToUse = hiddenPen;

                    PointF p0 = Project(a, cx, cy);
                    PointF p1 = Project(b, cx, cy);
                    PointF p2 = Project(c, cx, cy);
                    PointF p3 = Project(d, cx, cy);

                    e.Graphics.DrawLine(penToUse, p0, p1);
                    e.Graphics.DrawLine(penToUse, p1, p3);
                    e.Graphics.DrawLine(penToUse, p3, p2);
                    e.Graphics.DrawLine(penToUse, p2, p0);
                }
            }
        }
        private struct Point3D
        {
            public double X, Y, Z;
            public Point3D(double x, double y, double z) { X = x; Y = y; Z = z; }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
