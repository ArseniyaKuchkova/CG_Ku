using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Lab2
{
    public partial class Form8 : Form
    {
        int[,] body;           // рама велосипеда
        int[,] wheelLeft;      // левое колесо
        int[,] wheelRight;     // правое колесо
        int[,] pedal;          // педали
        int[,] pedal2;         // вторые педали для тандема

        int[,] matr_sdv = new int[3, 3];  // матрица сдвига
        int k, l;                         // параметры сдвига (центр pictureBox)

        // Параметры положения и вращения
        int bikeX = 0;          // смещение по X
        int bikeY = 0;          // смещение по Y
        double wheelAngle = 0;  // угол поворота колёс (в радианах)
        double pedalAngle = 0;  // угол поворота педалей (в радианах)

        bool isTandem = false;  // режим тандема
        bool isMoving = false;  // флаг непрерывного движения

      
 
        public Form8()
        {
            InitializeComponent();
        }

        private void Init_matr_preob(int k1, int l1)
        {
            matr_sdv[0, 0] = 1;
            matr_sdv[0, 1] = 0;
            matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0;
            matr_sdv[1, 1] = 1;
            matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1;
            matr_sdv[2, 1] = l1;
            matr_sdv[2, 2] = 1;
        }
        private int[,] Multiply_matrix(int[,] a, int[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int[,] r = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }
            return r;
        }
        private int[,] RotatePoints(int[,] points, double angle, int centerX, int centerY)
        {
            int n = points.GetLength(0);
            int[,] result = new int[n, 3];

            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);

            for (int i = 0; i < n; i++)
            {
                // Перемещаем в начало координат
                int x = points[i, 0] - centerX;
                int y = points[i, 1] - centerY;

                // Поворачиваем
                int newX = (int)(x * cos - y * sin);
                int newY = (int)(x * sin + y * cos);

                // Возвращаем обратно
                result[i, 0] = newX + centerX;
                result[i, 1] = newY + centerY;
                result[i, 2] = 1;
            }
            return result;
        }

        private int[,] CreateCircle(int cx, int cy, int r, int segments)
        {
            int[,] points = new int[segments + 1, 3];
            for (int i = 0; i <= segments; i++)
            {
                double angle = i * 2 * Math.PI / segments;
                points[i, 0] = cx + (int)(r * Math.Cos(angle));
                points[i, 1] = cy + (int)(r * Math.Sin(angle));
                points[i, 2] = 1;
            }
            return points;
        }
        private void Init_bicycle()
        {
            // РАМА (5 точек: задняя ось, каретка, передняя ось, сиденье, руль)
            body = new int[5, 3];
            body[0, 0] = -30; body[0, 1] = 0; body[0, 2] = 1;  // задняя ось (колесо)
            body[1, 0] = 0; body[1, 1] = 12; body[1, 2] = 1;  // каретка (педали) - ВНИЗУ
            body[2, 0] = 30; body[2, 1] = 0; body[2, 2] = 1;  // передняя ось (колесо)
            body[3, 0] = 0; body[3, 1] = -15; body[3, 2] = 1; // сиденье - ВВЕРХУ
            body[4, 0] = 25; body[4, 1] = -15; body[4, 2] = 1; // руль - ВВЕРХУ

            // КОЛЁСА (центры на одной линии Y=0)
            wheelLeft = CreateCircle(-30, 0, 18, 16);   // заднее
            wheelRight = CreateCircle(30, 0, 18, 16);   // переднее

            // ПЕДАЛИ (от каретки вниз и вверх, но каретка уже внизу)
            pedal = new int[2, 3];
            pedal[0, 0] = 0; pedal[0, 1] = 12; pedal[0, 2] = 1;   // центр каретки
            pedal[1, 0] = 0; pedal[1, 1] = 25; pedal[1, 2] = 1;   // педаль вниз (ещё ниже)

            // ВТОРЫЕ ПЕДАЛИ ДЛЯ ТАНДЕМА (позади)
            pedal2 = new int[2, 3];
            pedal2[0, 0] = -20; pedal2[0, 1] = 10; pedal2[0, 2] = 1;
            pedal2[1, 0] = -20; pedal2[1, 1] = 23; pedal2[1, 2] = 1;
        }
        private void Draw_Bicycle()
        {
            // Очищаем pictureBox
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);

            // Инициализируем координаты велосипеда
            Init_bicycle();

            // Матрица сдвига (центр pictureBox + смещение велосипеда)
            Init_matr_preob(k + bikeX, l + bikeY);

            // Применяем сдвиг ко всем частям
            int[,] body1 = Multiply_matrix(body, matr_sdv);

            // КОЛЁСА с поворотом
            int[,] wheelLeftRotated = RotatePoints(wheelLeft, wheelAngle, -30, 0);
            int[,] wheelRightRotated = RotatePoints(wheelRight, wheelAngle, 30, 0);

            int[,] wheelLeft1 = Multiply_matrix(wheelLeftRotated, matr_sdv);
            int[,] wheelRight1 = Multiply_matrix(wheelRightRotated, matr_sdv);

            // ПЕДАЛИ с поворотом
            int[,] pedalRotated = RotatePoints(pedal, pedalAngle, 0, 12);
            int[,] pedal1 = Multiply_matrix(pedalRotated, matr_sdv);

            // Настройка пера
            Pen blackPen = new Pen(Color.Black, 2);
            Pen bluePen = new Pen(Color.Blue, 2);
            Pen redPen = new Pen(Color.Red, 2);

            // === 1. Рисуем раму (чёрным) ===
            g.DrawLine(blackPen, body1[0, 0], body1[0, 1], body1[1, 0], body1[1, 1]); // задняя ось - каретка
            g.DrawLine(blackPen, body1[1, 0], body1[1, 1], body1[2, 0], body1[2, 1]); // каретка - передняя ось
            g.DrawLine(blackPen, body1[0, 0], body1[0, 1], body1[3, 0], body1[3, 1]); // задняя ось - сиденье
            g.DrawLine(blackPen, body1[3, 0], body1[3, 1], body1[4, 0], body1[4, 1]); // сиденье - руль
            g.DrawLine(blackPen, body1[2, 0], body1[2, 1], body1[4, 0], body1[4, 1]); // передняя ось - руль

            // Дополнительная линия рамы
            g.DrawLine(blackPen, body1[1, 0], body1[1, 1], body1[3, 0], body1[3, 1]);  // руль-задняя ось

            // === 2. Рисуем колёса (синим) ===
            for (int i = 0; i < wheelLeft1.GetLength(0) - 1; i++)
            {
                g.DrawLine(bluePen, wheelLeft1[i, 0], wheelLeft1[i, 1],
                                   wheelLeft1[i + 1, 0], wheelLeft1[i + 1, 1]);
                g.DrawLine(bluePen, wheelRight1[i, 0], wheelRight1[i, 1],
                                   wheelRight1[i + 1, 0], wheelRight1[i + 1, 1]);
            }

            // === 3. Рисуем спицы колёс ===
            g.DrawLine(bluePen, wheelLeft1[0, 0], wheelLeft1[0, 1],
                               wheelLeft1[8, 0], wheelLeft1[8, 1]);
            g.DrawLine(bluePen, wheelLeft1[4, 0], wheelLeft1[4, 1],
                               wheelLeft1[12, 0], wheelLeft1[12, 1]);
            g.DrawLine(bluePen, wheelRight1[0, 0], wheelRight1[0, 1],
                               wheelRight1[8, 0], wheelRight1[8, 1]);
            g.DrawLine(bluePen, wheelRight1[4, 0], wheelRight1[4, 1],
                               wheelRight1[12, 0], wheelRight1[12, 1]);

            // === 4. Рисуем педали (красным) ===
            g.DrawLine(redPen, pedal1[0, 0], pedal1[0, 1], pedal1[1, 0], pedal1[1, 1]);

            // РИСУЕМ ОСНОВНОЕ СИДЕНЬЕ (между колёсами, сверху)
            int seatX = body1[3, 0];
            int seatY = body1[3, 1];
            g.DrawEllipse(blackPen, seatX - 8, seatY - 3, 16, 8);

            // Если тандем - рисуем ВТОРОЕ СИДЕНЬЕ (тоже между колёсами, но сзади)
            if (isTandem)
            {
                // Второе сиденье позади основного (например, на 20 пикселей левее)
                int secondSeatX = seatX - 20;
                int secondSeatY = seatY;
                g.DrawEllipse(blackPen, secondSeatX - 8, secondSeatY - 3, 16, 8);

                // Вторые педали (уже есть в твоём коде, оставляем)
                int[,] pedal2Rotated = RotatePoints(pedal2, pedalAngle, -20, 10);
                int[,] pedal2_1 = Multiply_matrix(pedal2Rotated, matr_sdv);
                g.DrawLine(redPen, pedal2_1[0, 0], pedal2_1[0, 1], pedal2_1[1, 0], pedal2_1[1, 1]);
            }
            // Очищаем ресурсы
            g.Dispose();
            blackPen.Dispose();
            bluePen.Dispose();
            redPen.Dispose();
        }
        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2+50;
            bikeX = 0;
            bikeY = 0;
            wheelAngle = 0;
            pedalAngle = 0;
            Draw_Bicycle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bikeX += 15;
            Draw_Bicycle();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bikeX -= 15;
            Draw_Bicycle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isTandem = !isTandem;
            Draw_Bicycle();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bikeX += 8;                    // движение вправо
            wheelAngle += 0.25;            // вращение колёс
            pedalAngle += 0.35;            // вращение педалей

            // Сброс при достижении края (имитация бесконечного движения)
            if (bikeX > pictureBox1.Width)
            {
                bikeX = -200;
            }

            Draw_Bicycle();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isMoving)
            {
                timer1.Start();
                button1.Text = "Стоп";
                isMoving = true;
            }
            else
            {
                timer1.Stop();
                button1.Text = "Старт";
                isMoving = false;
            }
        }
    }
}
