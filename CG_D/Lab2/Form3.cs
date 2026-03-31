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

        public Form3()
        {
            InitializeComponent();
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
    }
}
