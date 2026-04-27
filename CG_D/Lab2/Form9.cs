using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form9 : Form
    {
        // Позиция и размер самолётика
        float planeX = 0;      // X от окна замка
        float planeY = 0;      // Y от окна замка
        float planeSize = 0.3f; // размер (0.3 = маленький)

        Timer timer = new Timer();
        bool isAnimating = false;

        public Form9()
        {
            InitializeComponent();
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
        }

        // Рисование всего
        private void DrawAll()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.SkyBlue);

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            // === ЗАМОК (слева от центра) ===
            // Стена замка
            g.FillRectangle(Brushes.Gray, cx - 130, cy - 80, 50, 160);

            // Окно замка
            g.FillRectangle(Brushes.Yellow, cx - 120, cy - 30, 30, 60);
            g.DrawRectangle(Pens.Black, cx - 120, cy - 30, 30, 60);

            // Крыша замка
            Point[] roof = { new Point(cx - 130, cy - 80), new Point(cx - 105, cy - 110), new Point(cx - 80, cy - 80) };
            g.FillPolygon(Brushes.DarkRed, roof);

            // === САМОЛЁТИК ===
            // Координаты центра самолётика (вылетает из окна)
            float centerX = cx - 105 + planeX;
            float centerY = cy + planeY;

            // Размер самолётика
            float size = 20 * planeSize;

            // Вершины треугольника (самолётик)
            PointF[] plane = new PointF[3];
            plane[0] = new PointF(centerX, centerY - size);      // нос (вверх)
            plane[1] = new PointF(centerX - size, centerY + size); // левое крыло
            plane[2] = new PointF(centerX + size, centerY + size); // правое крыло

            // Рисуем самолётик
            g.FillPolygon(Brushes.White, plane);
            g.DrawPolygon(Pens.Black, plane);

            // Текст "62 года ТУСУР"
            Font fTitle = new Font("Arial", 16, FontStyle.Bold);
            g.DrawString("62 года ТУСУР", fTitle, Brushes.DarkBlue, 15, 15);
            fTitle.Dispose();

            g.Dispose();
        }

        // Таймер - обновляет положение и размер самолётика
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Самолётик летит вправо и вверх, увеличивается
            planeX += 3;       // летит вправо
            planeY -= 1.5f;    // летит вверх
            planeSize += 0.02f; // увеличивается (приближается)

            // Если улетел далеко или стал слишком большим - начинаем заново
            if (planeX > 300 || planeSize > 1.5f)
            {
                planeX = 0;
                planeY = 0;
                planeSize = 0.3f;
            }

            DrawAll();
        }

        // ================= ОБРАБОТЧИКИ КНОПОК =================

        // button1 - Оси
        private void button1_Click(object sender, EventArgs e) { DrawAll(); }

        // button2 - Квадрат (ничего не делает)
        private void button2_Click(object sender, EventArgs e) { DrawAll(); }

        // button3 - Очистить (останавливает анимацию)
        private void button3_Click(object sender, EventArgs e)
        {
            timer.Stop();
            isAnimating = false;
            DrawAll();
        }

        // button4 - Сдвиг вправо
        private void button4_Click(object sender, EventArgs e) { DrawAll(); }

        // button5 - Сдвиг влево
        private void button5_Click(object sender, EventArgs e) { DrawAll(); }

        // button6 - Сдвиг вниз
        private void button6_Click(object sender, EventArgs e) { DrawAll(); }

        // button7 - Сдвиг вверх
        private void button7_Click(object sender, EventArgs e) { DrawAll(); }

        // button8 - Старт/Стоп для обычных фигур
        private void button8_Click(object sender, EventArgs e) { }

        // button9 - Увеличить
        private void button9_Click(object sender, EventArgs e) { DrawAll(); }

        // button10 - Уменьшить
        private void button10_Click(object sender, EventArgs e) { DrawAll(); }

        // button11 - Поворот влево
        private void button11_Click(object sender, EventArgs e) { DrawAll(); }

        // button12 - Поворот вправо
        private void button12_Click(object sender, EventArgs e) { DrawAll(); }

        // button13 - Отражение по X
        private void button13_Click(object sender, EventArgs e) { DrawAll(); }

        // button14 - Отражение по Y
        private void button14_Click(object sender, EventArgs e) { DrawAll(); }

        // button15 - Фигура 10
        private void button15_Click(object sender, EventArgs e) { DrawAll(); }

        // button16 - САМОЛЁТИК (старт/стоп)
        private void button16_Click(object sender, EventArgs e)
        {
            if (!isAnimating)
            {
                // Сброс параметров
                planeX = 0;
                planeY = 0;
                planeSize = 0.3f;

                // Запуск анимации
                isAnimating = true;
                timer.Start();
                button16.Text = "Стоп";
                DrawAll();
            }
            else
            {
                // Остановка анимации
                timer.Stop();
                isAnimating = false;
                button16.Text = "Самолётик";
                DrawAll();
            }
        }

        // button17 - Выход
        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            DrawAll();
        }

        // Пустые обработчики
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void timer1_Tick(object sender, EventArgs e) { }
    }
}