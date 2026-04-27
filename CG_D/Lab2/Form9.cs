using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Lab2
{
    public partial class Form9 : Form
    {
        // ================= ГЛОБАЛЬНЫЕ МАССИВЫ =================
        double[,] kv = new double[4, 3];           // Квадрат (Пример 4.1)
        double[,] fig10 = new double[6, 3];        // Фигура варианта 10
        double[,] osi = new double[4, 3];          // Оси координат
        double[,] matr_sdv = new double[3, 3];     // Матрица преобразования

        // Параметры для обычных фигур
        int k = 0, l = 0;
        double angle = 0;
        double scaleX = 1, scaleY = 1;
        bool refX = false, refY = false;
        bool f = true;
        bool drawVariant10 = false;

        // ================= ПЕРЕМЕННЫЕ ДЛЯ ВАРИАНТА 2 =================
        double[,] castle = new double[4, 3];       // Замок
        double[,] window = new double[4, 3];       // Окно замка
        double[,] paperPlane = new double[3, 3];   // Бумажный самолетик

        double planeK = 0;
        double planeL = 0;
        double planeScale = 0.1;
        bool isVariant2 = false;

        // Флаг для осей
        bool showAxes = false;

        // Логотип
        Image tusurLogo = null;

        public Form9()
        {
            InitializeComponent();
        }

        // ================= ИНИЦИАЛИЗАЦИЯ ФИГУР =================
        private void Init_kvadrat()
        {
            kv[0, 0] = -50; kv[0, 1] = 0; kv[0, 2] = 1;
            kv[1, 0] = 0; kv[1, 1] = 50; kv[1, 2] = 1;
            kv[2, 0] = 50; kv[2, 1] = 0; kv[2, 2] = 1;
            kv[3, 0] = 0; kv[3, 1] = -50; kv[3, 2] = 1;
        }

        private void Init_fig10()
        {
            fig10[0, 0] = -20; fig10[0, 1] = 60; fig10[0, 2] = 1;
            fig10[1, 0] = 50; fig10[1, 1] = 40; fig10[1, 2] = 1;
            fig10[2, 0] = 40; fig10[2, 1] = -50; fig10[2, 2] = 1;
            fig10[3, 0] = 10; fig10[3, 1] = -50; fig10[3, 2] = 1;
            fig10[4, 0] = 10; fig10[4, 1] = -20; fig10[4, 2] = 1;
            fig10[5, 0] = -30; fig10[5, 1] = -60; fig10[5, 2] = 1;
        }

        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;
            osi[2, 0] = 0; osi[2, 1] = 200; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;
        }

        private void Init_Variant2()
        {
            // Замок (серый прямоугольник) - ВИДИМЫЙ!
            castle[0, 0] = -100; castle[0, 1] = -80; castle[0, 2] = 1;
            castle[1, 0] = -50; castle[1, 1] = -80; castle[1, 2] = 1;
            castle[2, 0] = -50; castle[2, 1] = 80; castle[2, 2] = 1;
            castle[3, 0] = -100; castle[3, 1] = 80; castle[3, 2] = 1;

            // Окно (желтое)
            window[0, 0] = -50; window[0, 1] = -30; window[0, 2] = 1;
            window[1, 0] = -20; window[1, 1] = -30; window[1, 2] = 1;
            window[2, 0] = -20; window[2, 1] = 30; window[2, 2] = 1;
            window[3, 0] = -50; window[3, 1] = 30; window[3, 2] = 1;

            // Самолетик (треугольник, нос смотрит ВВЕРХ)
            paperPlane[0, 0] = 0; paperPlane[0, 1] = 15; paperPlane[0, 2] = 1;
            paperPlane[1, 0] = 25; paperPlane[1, 1] = -15; paperPlane[1, 2] = 1;
            paperPlane[2, 0] = -25; paperPlane[2, 1] = -15; paperPlane[2, 2] = 1;
        }

        // ================= МАТРИЧНЫЕ ОПЕРАЦИИ =================
        private double[,] Multiply_matr(double[,] a, double[,] b)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            double[,] r = new double[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    for (int ii = 0; ii < m; ii++)
                        r[i, j] += a[i, ii] * b[ii, j];
            return r;
        }

        private void Init_matr_preob(int k1, int l1, double angleDeg, double sx, double sy, bool rx, bool ry)
        {
            double rad = angleDeg * Math.PI / 180.0;
            double c = Math.Cos(rad), s = Math.Sin(rad);
            double fx = rx ? -1 : 1, fy = ry ? -1 : 1;

            matr_sdv[0, 0] = sx * c * fx; matr_sdv[0, 1] = sx * s * fy; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = -sy * s * fx; matr_sdv[1, 1] = sy * c * fy; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1; matr_sdv[2, 1] = l1; matr_sdv[2, 2] = 1;
        }

        private void Init_ScaleShiftMatrix(double k1, double l1, double s)
        {
            matr_sdv[0, 0] = s; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = s; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1; matr_sdv[2, 1] = l1; matr_sdv[2, 2] = 1;
        }

        // ================= ОТРИСОВКА ОСЕЙ =================
        private void Draw_Axes(Graphics g, int cx, int cy)
        {
            using (Pen axisPen = new Pen(Color.Gray, 1))
            {
                g.DrawLine(axisPen, 0, cy, pictureBox1.Width, cy);
                g.DrawLine(axisPen, cx, 0, cx, pictureBox1.Height);
            }
        }

        // ================= ОТРИСОВКА КВАДРАТА =================
        private void Draw_Kv()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.Black);

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            if (showAxes) Draw_Axes(g, cx, cy);

            Init_kvadrat();
            Init_matr_preob(k, l, angle, scaleX, scaleY, refX, refY);
            double[,] kv1 = Multiply_matr(kv, matr_sdv);

            using (Pen myPen = new Pen(Color.Blue, 2))
            {
                for (int i = 0; i < 4; i++)
                {
                    int j = (i + 1) % 4;
                    int x1 = (int)(kv1[i, 0]) + cx;
                    int y1 = pictureBox1.Height - (int)(kv1[i, 1]) - cy;
                    int x2 = (int)(kv1[j, 0]) + cx;
                    int y2 = pictureBox1.Height - (int)(kv1[j, 1]) - cy;
                    g.DrawLine(myPen, x1, y1, x2, y2);
                }
            }
            g.Dispose();
        }

        // ================= ОТРИСОВКА ФИГУРЫ 10 =================
        private void Draw_Fig10()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.Black);

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            if (showAxes) Draw_Axes(g, cx, cy);

            Init_fig10();
            Init_matr_preob(k, l, angle, scaleX, scaleY, refX, refY);
            double[,] fig1 = Multiply_matr(fig10, matr_sdv);

            using (Pen myPen = new Pen(Color.LimeGreen, 2))
            {
                for (int i = 0; i < 6; i++)
                {
                    int j = (i + 1) % 6;
                    int x1 = (int)(fig1[i, 0]) + cx;
                    int y1 = pictureBox1.Height - (int)(fig1[i, 1]) - cy;
                    int x2 = (int)(fig1[j, 0]) + cx;
                    int y2 = pictureBox1.Height - (int)(fig1[j, 1]) - cy;
                    g.DrawLine(myPen, x1, y1, x2, y2);
                }
            }
            g.Dispose();
        }

        // ================= ОТРИСОВКА ВАРИАНТА 2 =================
        private void Draw_Variant2()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.SkyBlue);

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            // Рисуем оси если нужно
            if (showAxes)
                Draw_Axes(g, cx, cy);

            // --- РИСУЕМ ЗАМОК И ОКНО ---
            Init_ScaleShiftMatrix(cx - 120, cy, 1.0);

            // Замок (серый)
            double[,] castleTrans = Multiply_matr(castle, matr_sdv);
            using (Brush castleBrush = new SolidBrush(Color.Gray))
            {
                Point[] castlePts = new Point[4];
                for (int i = 0; i < 4; i++)
                {
                    castlePts[i].X = (int)castleTrans[i, 0];
                    castlePts[i].Y = pictureBox1.Height - (int)castleTrans[i, 1];
                }
                g.FillPolygon(castleBrush, castlePts);
            }

            // Окно (желтое)
            double[,] windowTrans = Multiply_matr(window, matr_sdv);
            using (Brush windowBrush = new SolidBrush(Color.LightYellow))
            {
                Point[] windowPts = new Point[4];
                for (int i = 0; i < 4; i++)
                {
                    windowPts[i].X = (int)windowTrans[i, 0];
                    windowPts[i].Y = pictureBox1.Height - (int)windowTrans[i, 1];
                }
                g.FillPolygon(windowBrush, windowPts);
            }

            // --- АНИМАЦИЯ САМОЛЕТИКА ---
            planeK += 2.5;
            planeL += 1.5;
            planeScale += 0.008;

            if (planeScale > 3.0)
            {
                planeScale = 0.1;
                planeK = 0;
                planeL = 0;
            }

            // Рисуем САМОЛЕТИК (белый)
            Init_ScaleShiftMatrix(cx - 80 + planeK, cy + planeL, planeScale);
            double[,] planeTrans = Multiply_matr(paperPlane, matr_sdv);

            using (Brush planeBrush = new SolidBrush(Color.White))
            using (Pen planePen = new Pen(Color.Black, 1))
            {
                Point[] pts = new Point[3];
                for (int i = 0; i < 3; i++)
                {
                    pts[i].X = (int)planeTrans[i, 0];
                    pts[i].Y = pictureBox1.Height - (int)planeTrans[i, 1];
                }
                g.FillPolygon(planeBrush, pts);
                g.DrawPolygon(planePen, pts);
            }

            // Текст "62 года ТУСУР"
            Font fTitle = new Font("Arial", 16, FontStyle.Bold);
            g.DrawString("62 года ТУСУР", fTitle, Brushes.DarkBlue, 15, 15);
            fTitle.Dispose();

            // Логотип ТУСУР
            if (tusurLogo != null)
            {
                g.DrawImage(tusurLogo, pictureBox1.Width - 110, 10, 100, 50);
            }

            g.Dispose();
        }

        // ================= ОБЩИЙ МЕТОД ОТРИСОВКИ =================
        private void Draw_Active()
        {
            if (isVariant2)
                Draw_Variant2();
            else if (drawVariant10)
                Draw_Fig10();
            else
                Draw_Kv();
        }

        // ================= ОБРАБОТЧИКИ КНОПОК =================

        // button1 - Нарисовать/скрыть оси
        private void button1_Click(object sender, EventArgs e)
        {
            showAxes = !showAxes;
            Draw_Active();
        }

        // button2 - Квадрат
        private void button2_Click(object sender, EventArgs e)
        {
            isVariant2 = false;
            drawVariant10 = false;
            k = 0; l = 0;
            angle = 0; scaleX = 1; scaleY = 1; refX = false; refY = false;
            Draw_Kv();
        }

        // button3 - Очистить
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.CreateGraphics().Clear(isVariant2 ? Color.SkyBlue : Color.Black);
        }

        // Сдвиги
        private void button4_Click(object sender, EventArgs e) { k += 10; Draw_Active(); }
        private void button5_Click(object sender, EventArgs e) { k -= 10; Draw_Active(); }
        private void button6_Click(object sender, EventArgs e) { l += 10; Draw_Active(); }
        private void button7_Click(object sender, EventArgs e) { l -= 10; Draw_Active(); }

        // button8 - Старт/Стоп
        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "Старт")
            {
                button8.Text = "Стоп";
                timer1.Interval = 30;
                timer1.Start();
            }
            else
            {
                button8.Text = "Старт";
                timer1.Stop();
            }
        }

        // Масштаб и поворот
        private void button9_Click(object sender, EventArgs e) { scaleX *= 1.2; scaleY *= 1.2; Draw_Active(); }
        private void button10_Click(object sender, EventArgs e) { scaleX *= 0.8; scaleY *= 0.8; Draw_Active(); }
        private void button11_Click(object sender, EventArgs e) { angle -= 15; Draw_Active(); }
        private void button12_Click(object sender, EventArgs e) { angle += 15; Draw_Active(); }
        private void button13_Click(object sender, EventArgs e) { refX = !refX; Draw_Active(); }
        private void button14_Click(object sender, EventArgs e) { refY = !refY; Draw_Active(); }

        // button15 - Фигура 10
        private void button15_Click(object sender, EventArgs e)
        {
            isVariant2 = false;
            drawVariant10 = true;
            k = 0; l = 0;
            angle = 0; scaleX = 1; scaleY = 1; refX = false; refY = false;
            Draw_Fig10();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // button16 - Самолетик (Вариант 2)
        private void button16_Click(object sender, EventArgs e)
        {
            isVariant2 = true;
            planeScale = 0.1; planeK = 0; planeL = 0;
            Draw_Variant2();
        }

        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            Init_Variant2();
            try { tusurLogo = Lab2.Properties.Resources.tusur_logo; }
            catch { tusurLogo = null; }
        }

        // Таймер
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isVariant2)
                Draw_Variant2();
            else
            {
                angle += 2;
                Draw_Active();
            }
        }
    }
}