using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Lab2
{
    public partial class Form7 : Form
    {
        // ========== Для индивидуального задания (полёт кораблей) ==========
        int[,] shipBody = new int[6, 3]; // Матрица тела корабля (6 вершин)
        private double shipAngle1 = 0;     // угол первого корабля (радианы)
        private double shipAngle2 = Math.PI; // угол второго корабля (начинает с противоположной стороны)
        private double shipSpeed1 = 0.02;  // скорость первого корабля
        private double shipSpeed2 = 0.05;  // скорость второго корабля
        private bool isShipAnimation = false; // флаг анимации

        public Form7()
        {
            InitializeComponent();
            Init_Ship();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Если запущена анимация кораблей
            if (isShipAnimation)
            {
                shipAngle1 += shipSpeed1;
                shipAngle2 += shipSpeed2;
                if (shipAngle1 > Math.PI * 2) shipAngle1 -= Math.PI * 2;
                if (shipAngle2 > Math.PI * 2) shipAngle2 -= Math.PI * 2;
                DrawEarthAndShips();
            }
        }

        // Инициализация матрицы тела корабля
        private void Init_Ship()
        {
            // Вершины корабля (центр в точке 0,0)
            // Нос
            shipBody[0, 0] = 0; shipBody[0, 1] = -15; shipBody[0, 2] = 1;
            // Правое крыло
            shipBody[1, 0] = 12; shipBody[1, 1] = 0; shipBody[1, 2] = 1;
            // Правый хвост
            shipBody[2, 0] = 8; shipBody[2, 1] = 10; shipBody[2, 2] = 1;
            // Центр (впадина)
            shipBody[3, 0] = 0; shipBody[3, 1] = 5; shipBody[3, 2] = 1;
            // Левый хвост
            shipBody[4, 0] = -8; shipBody[4, 1] = 10; shipBody[4, 2] = 1;
            // Левое крыло
            shipBody[5, 0] = -12; shipBody[5, 1] = 0; shipBody[5, 2] = 1;
        }

        // Рисование корабля через матричные преобразования
        private void DrawShipMatrix(Graphics g, int centerX, int centerY, double angleRad, int size, Brush color)
        {
            double scaleFactor = size / 15.0;  // базовый размер 15

            // Поворот корабля (нос по направлению движения)
            double rotAngle = angleRad + Math.PI / 2;

            double[,] temp = new double[6, 3];

            for (int i = 0; i < 6; i++)
            {
                double x = shipBody[i, 0];
                double y = shipBody[i, 1];

                // Масштабирование
                x = x * scaleFactor;
                y = y * scaleFactor;

                // Поворот
                double newX = x * Math.Cos(rotAngle) - y * Math.Sin(rotAngle);
                double newY = x * Math.Sin(rotAngle) + y * Math.Cos(rotAngle);

                temp[i, 0] = newX;
                temp[i, 1] = newY;
                temp[i, 2] = 1;
            }

            // Сдвиг в нужную позицию и рисование
            Point[] points = new Point[6];
            for (int i = 0; i < 6; i++)
            {
                points[i] = new Point(centerX + (int)temp[i, 0], centerY + (int)temp[i, 1]);
            }

            g.FillPolygon(color, points);
        }

        // Рисование Земли и кораблей
        private void DrawEarthAndShips()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);

                int cx = pictureBox1.Width / 2;
                int cy = pictureBox1.Height / 2;

                // Орбиты (пунктирные)
                Pen orbitPen = new Pen(Color.Gray, 1);
                orbitPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                int orbit1Radius = 60;
                int orbit2Radius = 120;
                g.DrawEllipse(orbitPen, cx - orbit1Radius, cy - orbit1Radius, orbit1Radius * 2, orbit1Radius * 2);
                g.DrawEllipse(orbitPen, cx - orbit2Radius, cy - orbit2Radius, orbit2Radius * 2, orbit2Radius * 2);

                // Земля
                int earthRadius = 10;
                g.FillEllipse(Brushes.Blue, cx - earthRadius, cy - earthRadius, earthRadius * 2, earthRadius * 2);

                // Позиции кораблей
                int ship1X = cx + (int)(orbit1Radius * Math.Cos(shipAngle1));
                int ship1Y = cy + (int)(orbit1Radius * Math.Sin(shipAngle1));
                int ship2X = cx + (int)(orbit2Radius * Math.Cos(shipAngle2));
                int ship2Y = cy + (int)(orbit2Radius * Math.Sin(shipAngle2));

                // Размер кораблей от Y
                int ship1Size = CalculateShipSize(ship1Y);
                int ship2Size = CalculateShipSize(ship2Y);

                // Рисуем корабли
                DrawShipMatrix(g, ship1X, ship1Y, shipAngle1, ship1Size, Brushes.Red);
                DrawShipMatrix(g, ship2X, ship2Y, shipAngle2, ship2Size, Brushes.Green);

                // Подписи
                Font font = new Font("Arial", 10);
                g.DrawString("Земля", font, Brushes.White, cx - 20, cy + 15);
            }

            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        private int CalculateShipSize(int y)
        {
            float normalizedY = (float)y / pictureBox1.Height;
            int minSize = 8;
            int maxSize = 25;
            return minSize + (int)((maxSize - minSize) * normalizedY);
        }

        private void btnShip1Faster_Click(object sender, EventArgs e)
        {
            shipSpeed1 += 0.005;
        }

        private void btnShip1Slower_Click(object sender, EventArgs e)
        {
            shipSpeed1 -= 0.005;
            if (shipSpeed1 < 0.005) shipSpeed1 = 0.005;
        }

        private void btnShip2Faster_Click(object sender, EventArgs e)
        {
            shipSpeed2 += 0.005;
        }

        private void btnShip2Slower_Click(object sender, EventArgs e)
        {
            shipSpeed2 -= 0.005;
            if (shipSpeed2 < 0.005) shipSpeed2 = 0.005;
        }

        private void btnStartShips_Click(object sender, EventArgs e)
        {
            if (!isShipAnimation)
            {
                isShipAnimation = true;
                timer1.Start();
                btnStartShips.Text = "Остановить анимацию";
            }
            else
            {
                isShipAnimation = false;
                timer1.Stop();
                btnStartShips.Text = "Старт анимацию";
            }
        }
    }
}
