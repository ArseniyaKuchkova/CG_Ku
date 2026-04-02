using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab2
{
    public partial class Form3 : Form
    {
        // Координаты точек
        public int xn, yn, xk, yk;

        // Для работы с растром
        Bitmap myBitmap;

        // Цвет текущей линии и заливки
        Color currentBorderColor;
        Color fillColor = Color.Green;

        bool thickLine = false;

        bool isDashed = false;  // флаг пунктирной линии
        int dashStep = 5;       // шаг пунктира
        int lineThickness = 1;  // толщина линии
        bool useBresenham = false;

        public Form3()
        {
            InitializeComponent();
        }
        // Отсечение Коэна-Сазерленда
        private bool ClipLine(ref double x1, ref double y1, ref double x2, ref double y2,
                             double xmin, double ymin, double xmax, double ymax)
        {
            const int INSIDE = 0b0000;
            const int LEFT = 0b0001;   
            const int RIGHT = 0b0010;   
            const int BOTTOM = 0b0100;
            const int TOP = 0b1000;   

            // Локальная функция вычисления кода точки
            int ComputeCode(double x, double y)
            {
                int code = INSIDE;
                if (x < xmin) code |= LEFT;
                else if (x > xmax) code |= RIGHT;
                if (y < ymin) code |= BOTTOM;
                else if (y > ymax) code |= TOP;
                return code;
            }

            int code1 = ComputeCode(x1, y1);
            int code2 = ComputeCode(x2, y2);

            while (true)
            {
                if ((code1 | code2) == INSIDE)  // оба внутри
                    return true;
                if ((code1 & code2) != 0)       // оба снаружи с одной стороны
                    return false;

                // Выбираем внешнюю точку
                int codeOut = (code1 != 0) ? code1 : code2;
                double x = 0, y = 0;

                // Определяем пересечение с границей
                if ((codeOut & LEFT) != 0)
                {
                    y = y1 + (y2 - y1) * (xmin - x1) / (x2 - x1);
                    x = xmin;
                }
                else if ((codeOut & RIGHT) != 0)
                {
                    y = y1 + (y2 - y1) * (xmax - x1) / (x2 - x1);
                    x = xmax;
                }
                else if ((codeOut & BOTTOM) != 0)
                {
                    x = x1 + (x2 - x1) * (ymin - y1) / (y2 - y1);
                    y = ymin;
                }
                else if ((codeOut & TOP) != 0)
                {
                    x = x1 + (x2 - x1) * (ymax - y1) / (y2 - y1);
                    y = ymax;
                }

                // Заменяем точку
                if (codeOut == code1)
                {
                    x1 = x; y1 = y;
                    code1 = ComputeCode(x1, y1);
                }
                else
                {
                    x2 = x; y2 = y;
                    code2 = ComputeCode(x2, y2);
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Если выбран режим рисования отрезков (Обычный ЦДА)
            if (radioButton1.Checked == true)
            {
                xn = e.X;
                yn = e.Y;
            }
            // Если выбран режим заливки
            else if (radioButton2.Checked == true)  
            {
                xn = e.X;
                yn = e.Y;  // Запоминаем координаты для заливки
            }
            else if (radioButton3.Checked == true)
            {
                xn = e.X;
                yn = e.Y;  
            }
            else if (radioButtonBresenham.Checked == true)  // 🔹 ДОБАВЛЕНО
            {
                xn = e.X;
                yn = e.Y;
            }
            else
            {
                MessageBox.Show("Вы не выбрали алгоритм вывода фигуры!");
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //numberNodes – переменная, задающая количество узлов для
                //аппроксимации отрезка
                //xOutput – x-координата очередного узла
                //yOutput – y-координата очередного узла
                int index, numberNodes;
                double xOutput, yOutput, dx, dy;

                //Объявляем объект "myPen", задающий цвет и толщину пера
                Pen myPen = new Pen(currentBorderColor, 1);

                //Объявляем объект "g" класса Graphics и предоставляем
                //ему возможность рисования на pictureBox1:
                Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

                //реализация обычного алгоритма ЦДА
                xk = e.X;
                yk = e.Y;

                dx = xk - xn;
                dy = yk - yn;
                numberNodes = 200;
                xOutput = xn;
                yOutput = yn;

                for (index = 1; index <= numberNodes; index++)
                {
                    int centerX = (int)xOutput;
                    int centerY = (int)yOutput;

                    if (isDashed)
                    {
                        // Рисуем пунктирную линию
                        int stepCounter = index % (dashStep * 2);
                        if (stepCounter < dashStep)
                        {
                            if (thickLine) // Толстая пунктирная
                            {
                                for (int i = -1; i <= 1; i++)
                                {
                                    for (int j = -1; j <= 1; j++)
                                    {
                                        g.DrawRectangle(myPen, centerX + i, centerY + j, 1, 1);
                                    }
                                }
                            }
                            else
                            {
                                g.DrawRectangle(myPen, centerX, centerY, 1, 1);
                            }
                        }
                    }
                    else if (thickLine) // Толстая сплошная
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                g.DrawRectangle(myPen, centerX + i, centerY + j, 1, 1);
                            }
                        }
                    }
                    else // Тонкая линия
                    {
                        g.DrawRectangle(myPen, centerX, centerY, 1, 1);
                    }
                    xOutput = xOutput + dx / numberNodes;
                    yOutput = yOutput + dy / numberNodes;

                }
            }
            else if (radioButtonBresenham.Checked == true)  // 🔹 НОВЫЙ БЛОК
            {
                if (myBitmap == null)
                {
                    myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(myBitmap))
                    {
                        g.Clear(Color.White);
                    }
                    pictureBox1.Image = myBitmap;
                }

                xk = e.X;
                yk = e.Y;
                DrawBresenham(xn, yn, xk, yk);
                pictureBox1.Image = myBitmap;
                pictureBox1.Refresh();
            }
            else if (radioButton2.Checked == true)
            {
                if (currentBorderColor == Color.Empty)
                {
                    MessageBox.Show("Сначала выберите цвет границы!");
                    return;
                }

                // Получаем текущее изображение в растр
                myBitmap = pictureBox1.Image as Bitmap;
                if (myBitmap == null)
                {
                    myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(myBitmap))
                    {
                        g.Clear(Color.White);
                    }
                    pictureBox1.Image = myBitmap;
                }

                // Вызываем заливку с выбором алгоритма
                FloodFill(xn, yn);
                pictureBox1.Refresh();
            }

            else if (radioButton3.Checked == true)
            {
                double winLeft = 10;    
                double winBottom = 100;
                double winRight = 300;
                double winTop = 300;
                double x1 = xn;
                double y1 = yn;
                double x2 = e.X;
                double y2 = e.Y;

                bool visible = ClipLine(ref x1, ref y1, ref x2, ref y2,
                                winLeft, winBottom, winRight, winTop);
                if (!visible) return;
                
                xn = (int)x1;
                yn = (int)y1;
                xk = (int)x2;
                yk = (int)y2;

                int index, numberNodes;
                double xOutput, yOutput, dx, dy;

                //Объявляем объект "myPen", задающий цвет и толщину пера
                Pen myPen = new Pen(currentBorderColor, 1);

                //Объявляем объект "g" класса Graphics и предоставляем
                //ему возможность рисования на pictureBox1:
                Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
                Pen windowPen = new Pen(Color.Blue, 2);  // цвет и толщина рамки
                g.DrawRectangle(windowPen,
                                (int)winLeft, (int)winBottom,
                                (int)(winRight - winLeft), (int)(winTop - winBottom));
                windowPen.Dispose();

                //реализация обычного алгоритма ЦДА
                

                dx = xk - xn;
                dy = yk - yn;
                numberNodes = 200;
                xOutput = xn;
                yOutput = yn;

                for (index = 1; index <= numberNodes; index++)
                {
                    int centerX = (int)xOutput;
                    int centerY = (int)yOutput;

                    g.DrawRectangle(myPen, centerX, centerY, 2, 2);
                    
                    xOutput = xOutput + dx / numberNodes;
                    yOutput = yOutput + dy / numberNodes;

                }
            }

        }
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            thickLine = cb.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK && radioButton1.Checked)
            {
                currentBorderColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //отключаем кнопки
            button1.Enabled = false;
            button2.Enabled = false;
            

            //создаем новый экземпляр Bitmap размером с элемент
            //pictureBox1 (myBitmap)
            //на нем выводим попиксельно отрезок
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromHwnd(pictureBox1.Handle))
            {
                if (radioButton1.Checked == true)
                {
                    //рисуем прямоугольник
                    CDA(10, 10, 10, 110);
                    CDA(10, 10, 110, 10);
                    CDA(10, 110, 110, 110);
                    CDA(110, 10, 110, 110);
                    //рисуем треугольник
                    CDA(150, 10, 150, 200);
                    CDA(250, 50, 150, 200);
                    CDA(150, 10, 250, 150);
                }
                else if (radioButtonBresenham.Checked == true)  // 🔹 АЛГОРИТМ БРЕЗЕНХЕМА
                {
                    DrawBresenham(10, 10, 10, 110);
                    DrawBresenham(10, 10, 110, 10);
                    DrawBresenham(10, 110, 110, 110);
                    DrawBresenham(110, 10, 110, 110);
                    DrawBresenham(150, 10, 150, 200);
                    DrawBresenham(150, 200, 250, 50);
                    DrawBresenham(250, 50, 150, 10);
                }
                else if (radioButton2.Checked == true)  // Заливка
                {
                    myBitmap = pictureBox1.Image as Bitmap;
                    if (myBitmap == null)
                    {
                        myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        Graphics g2 = Graphics.FromImage(myBitmap);
                        g2.Clear(Color.White);
                    }

                    xn = 160;
                    yn = 40;

                    // Выбор типа заливки
                    if (radioButtonRecursive.Checked)
                    {
                        FloodFillRecursive(xn, yn);
                    }
                    else if (radioButtonIterative.Checked)
                    {
                        FloodFillIterative(xn, yn);
                    }
                }
            }
            pictureBox1.Image = myBitmap;
            pictureBox1.Refresh();
            button1.Enabled = true;
            button2.Enabled = true;
        

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                fillColor = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }


        private void CDA(int xStart, int yStart, int xEnd, int yEnd)
        {
            int index, numberNodes;
            double xOutput, yOutput, dx, dy;

            xn = xStart;
            yn = yStart;
            xk = xEnd;
            yk = yEnd;

            dx = xk - xn;
            dy = yk - yn;
            numberNodes = 200;
            xOutput = xn;
            yOutput = yn;

            for (index = 1; index <= numberNodes; index++)
            {
                int centerX = (int)xOutput;
                int centerY = (int)yOutput;

                bool shouldDraw = true;

                // Для пунктирной линии
                if (isDashed)
                {
                    int stepCounter = index % (dashStep * 2);
                    shouldDraw = (stepCounter < dashStep);
                }

                if (shouldDraw)
                {
                    if (thickLine) // Толстая линия
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if (centerX + i >= 0 && centerX + i < myBitmap.Width &&
                                    centerY + j >= 0 && centerY + j < myBitmap.Height)
                                {
                                    myBitmap.SetPixel(centerX + i, centerY + j, currentBorderColor);
                                }
                            }
                        }
                    }

                    else // Тонкая линия
                    {
                        if (centerX >= 0 && centerX < myBitmap.Width &&
                            centerY >= 0 && centerY < myBitmap.Height)
                        {
                            myBitmap.SetPixel(centerX, centerY, currentBorderColor);
                        }
                    }
                }
                xOutput = xOutput + dx / numberNodes;
                yOutput = yOutput + dy / numberNodes;
            }
        }

        private void FloodFill(int startX, int startY)
        {
            if (radioButtonRecursive.Checked)
                FloodFillRecursive(startX, startY);
            else if (radioButtonIterative.Checked)
                FloodFillIterative(startX, startY);
        }

        private void FloodFillRecursive(int x1, int y1)
        {
            // Ghjdthrf ds[jlf pf uhfybws
            if (x1 < 0 || x1 >= myBitmap.Width || y1 < 0 || y1 >= myBitmap.Height)
                return;

            // получаем цвет текущего пикселя с координатами x1, y1
            Color oldPixelColor = myBitmap.GetPixel(x1, y1);

            // сравнение цветов происходит в формате RGB
            // для этого используем метод ToArgb объекта Color
            if ((oldPixelColor.ToArgb() != currentBorderColor.ToArgb())
            && (oldPixelColor.ToArgb() != fillColor.ToArgb()))
            {
                //перекрашиваем пиксель
                myBitmap.SetPixel(x1, y1, fillColor);

                //вызываем метод для 4-х соседних пикселей
                FloodFillRecursive(x1 + 1, y1);
                FloodFillRecursive(x1 - 1, y1);
                FloodFillRecursive(x1, y1 + 1);
                FloodFillRecursive(x1, y1 - 1);
            }
            else
            {
                //выходим из метода
                return;
            }
        }

        private void FloodFillIterative(int startX, int startY)
        {
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(startX, startY));

            while (stack.Count > 0)
            {
                Point p = stack.Pop();

                if (p.X < 0 || p.X >= myBitmap.Width ||
                    p.Y < 0 || p.Y >= myBitmap.Height)
                    continue;

                Color currentPixelColor = myBitmap.GetPixel(p.X, p.Y);

                if ((currentPixelColor.ToArgb() != currentBorderColor.ToArgb()) &&
                    (currentPixelColor.ToArgb() != fillColor.ToArgb()))
                {
                    myBitmap.SetPixel(p.X, p.Y, fillColor);

                    stack.Push(new Point(p.X + 1, p.Y));
                    stack.Push(new Point(p.X - 1, p.Y));
                    stack.Push(new Point(p.X, p.Y + 1));
                    stack.Push(new Point(p.X, p.Y - 1));
                }
            }
        }

        private void radioButtonSolid_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSolid.Checked)
            {
                isDashed = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormBresenham formBresenham = new FormBresenham();
            formBresenham.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли алгоритм ЦДА
            if (!radioButton1.Checked)
            {
                MessageBox.Show("Для рисования отрезка выберите алгоритм 'Обычный ЦДА'");
                return;
            }

            // Проверяем, выбран ли цвет
            if (currentBorderColor == Color.Empty)
            {
                MessageBox.Show("Сначала выберите цвет линии!");
                return;
            }

            try
            {
                // Считываем координаты из текстовых полей
                int x1 = int.Parse(textBoxX1.Text);
                int y1 = int.Parse(textBoxY1.Text);
                int x2 = int.Parse(textBoxX2.Text);
                int y2 = int.Parse(textBoxY2.Text);

                // Создаем Graphics для рисования
                Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
                Pen myPen = new Pen(currentBorderColor, 1);

                // Рассчитываем параметры для ЦДА
                int index, numberNodes;
                double xOutput, yOutput, dx, dy;

                dx = x2 - x1;
                dy = y2 - y1;
                numberNodes = 200;
                xOutput = x1;
                yOutput = y1;

                for (index = 1; index <= numberNodes; index++)
                {
                    int centerX = (int)xOutput;
                    int centerY = (int)yOutput;

                    // Проверка для пунктирной линии
                    bool shouldDraw = true;
                    if (radioButtonDashed.Checked)
                    {
                        int dashStepValue = 5;
                        try
                        {
                            dashStepValue = int.Parse(textBoxDashStep.Text);
                        }
                        catch { }

                        int stepCounter = index % (dashStepValue * 2);
                        shouldDraw = (stepCounter < dashStepValue);
                    }

                    if (shouldDraw)
                    {
                        // Проверка для толстой линии
                        if (checkBox1.Checked) // Толстая линия
                        {
                            for (int i = -1; i <= 1; i++)
                            {
                                for (int j = -1; j <= 1; j++)
                                {
                                    g.DrawRectangle(myPen, centerX + i, centerY + j, 1, 1);
                                }
                            }
                        }
                        else // Тонкая линия
                        {
                            g.DrawRectangle(myPen, centerX, centerY, 1, 1);
                        }
                    }

                    xOutput = xOutput + dx / numberNodes;
                    yOutput = yOutput + dy / numberNodes;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные целые числа для координат!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void radioButtonDashed_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDashed.Checked)
            {
                isDashed = true;
            }
        }

        private void radioButtonBresenham_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDashStep_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int step = int.Parse(textBoxDashStep.Text);
                if (step > 0 && step <= 50)
                {
                    dashStep = step;
                }
                else
                {
                    MessageBox.Show("Шаг пунктира должен быть от 1 до 50");
                    textBoxDashStep.Text = dashStep.ToString();
                }
            }
            catch
            {
                // Если введено не число, восстанавливаем предыдущее значение
                textBoxDashStep.Text = dashStep.ToString();
            }
        }

        private void DrawBresenhamPixel(int x, int y)
        {
            if (myBitmap == null) return;
            if (x < 0 || x >= myBitmap.Width || y < 0 || y >= myBitmap.Height) return;

            if (thickLine)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int drawX = x + dx;
                        int drawY = y + dy;
                        if (drawX >= 0 && drawX < myBitmap.Width &&
                            drawY >= 0 && drawY < myBitmap.Height)
                        {
                            myBitmap.SetPixel(drawX, drawY, currentBorderColor);
                        }
                    }
                }
            }
            else
            {
                myBitmap.SetPixel(x, y, currentBorderColor);
            }
        }

        private void DrawBresenham(int x0, int y0, int x1, int y1)
        {
            int dx = x1 - x0;
            int dy = y1 - y0;
            int sx = (x0 < x1) ? 1 : -1;
            int sy = (y0 < y1) ? 1 : -1;
            dx = Math.Abs(dx);
            dy = Math.Abs(dy);
            bool steep = dy > dx;

            if (steep)
            {
                int temp = dx;
                dx = dy;
                dy = temp;
            }

            int error = 2 * dy - dx;
            DrawBresenhamPixel(x0, y0);

            int x = x0;
            int y = y0;
            for (int i = 0; i < dx; i++)
            {
                if (steep)
                {
                    if (error > 0)
                    {
                        x += sx;
                        error -= 2 * dx;
                    }
                    y += sy;
                    error += 2 * dy;
                }
                else
                {
                    if (error > 0)
                    {
                        y += sy;
                        error -= 2 * dx;
                    }
                    x += sx;
                    error += 2 * dy;
                }
                DrawBresenhamPixel(x, y);
            }
        }



    }
}
