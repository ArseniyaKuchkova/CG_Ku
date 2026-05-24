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
    public partial class Form14 : Form
    {
        // ========== 1. МАТРИЦА ТЕЛА (5 вершин × 4 координаты: X, Y, Z, 1) ==========
        double[,] figure = new double[5, 4];      // 5 вершин
        double[,] transformed = new double[5, 4]; // преобразованные вершины
        double[,] matr_transform = new double[4, 4]; // МАТРИЦА ПРЕОБРАЗОВАНИЯ 4×4

        // ========== ДЛЯ ФУНКЦИИ (вариант 7) ==========
        double[,] functionPoints;                   // массив точек для поверхности
        int gridSize = 20;                          // размер сетки (20×20 точек)
        int totalPoints;                            // общее количество точек
        bool showFunction = false;                  // флаг: показывать функцию или фигуру
        double[,] funcTransform = new double[4, 4]; // матрица для функции

        // Параметры для построения матрицы
        double posX = 0, posY = 0, posZ = 0;      // перемещение
        double rotX = 0, rotY = 0, rotZ = 0;      // вращение (градусы)
        double scaleX = 1, scaleY = 1, scaleZ = 1; // масштаб
        bool reflectX = false, reflectY = false, reflectZ = false; // отражение

        // Центр экрана
        int k, l;

        // Рёбра фигуры (5 вершин → 9 рёбер)
        int[,] edges = new int[,]
        {
            {0,1}, {1,2}, {2,0},           // основание (треугольник)
            {0,3}, {1,3}, {2,3},           // к верхней вершине
            {0,4}, {1,4}, {2,4}            // к нижней вершине
        };

        // Анимация
        bool f = true;

        public Form14()
        {
            InitializeComponent();
            InitFigure();
            InitFunction();
        }

        // ========== ИНИЦИАЛИЗАЦИЯ ФИГУРЫ (5 вершин) ==========
        private void InitFigure()
        {
            // Вершины в однородных координатах (x, y, z, 1)
            // Основание (треугольник)
            figure[0, 0] = -100; figure[0, 1] = -50; figure[0, 2] = 0; figure[0, 3] = 1;
            figure[1, 0] = 100; figure[1, 1] = -50; figure[1, 2] = 0; figure[1, 3] = 1;
            figure[2, 0] = 0; figure[2, 1] = 50; figure[2, 2] = 0; figure[2, 3] = 1;
            // Верхняя вершина
            figure[3, 0] = 0; figure[3, 1] = 0; figure[3, 2] = -100; figure[3, 3] = 1;
            // Нижняя вершина
            figure[4, 0] = 0; figure[4, 1] = 0; figure[4, 2] = 100; figure[4, 3] = 1;
        }

        // ========== 2. ПОСТРОЕНИЕ МАТРИЦЫ ПРЕОБРАЗОВАНИЯ 4×4 ==========
        private void Init_matr_preob()
        {
            // Начинаем с единичной матрицы
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matr_transform[i, j] = (i == j) ? 1 : 0;

            // 1. МАТРИЦА МАСШТАБИРОВАНИЯ 
            double[,] scaleMat = {
                {scaleX, 0, 0, 0},
                {0, scaleY, 0, 0},
                {0, 0, scaleZ, 0},
                {0, 0, 0, 1}
            };
            // 2. МАТРИЦА ОТРАЖЕНИЯ 
            double[,] reflectXMat = {
                {reflectX ? -1 : 1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            };
            double[,] reflectYMat = {
                {1, 0, 0, 0},
                {0, reflectY ? -1 : 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            };
            double[,] reflectZMat = {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, reflectZ ? -1 : 1, 0},
                {0, 0, 0, 1}
            };

            // 3. ВРАЩЕНИЕ ВОКРУГ ОСИ X
            double radX = rotX * Math.PI / 180;
            double[,] rotXMat = {
                {1, 0, 0, 0},
                {0, Math.Cos(radX), -Math.Sin(radX), 0},
                {0, Math.Sin(radX), Math.Cos(radX), 0},
                {0, 0, 0, 1}
            };

            // 4. ВРАЩЕНИЕ ВОКРУГ ОСИ Y
            double radY = rotY * Math.PI / 180;
            double[,] rotYMat = {
                {Math.Cos(radY), 0, Math.Sin(radY), 0},
                {0, 1, 0, 0},
                {-Math.Sin(radY), 0, Math.Cos(radY), 0},
                {0, 0, 0, 1}
            };

            // 5. ВРАЩЕНИЕ ВОКРУГ ОСИ Z
            double radZ = rotZ * Math.PI / 180;
            double[,] rotZMat = {
                {Math.Cos(radZ), -Math.Sin(radZ), 0, 0},
                {Math.Sin(radZ), Math.Cos(radZ), 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            };

            // 6. ПЕРЕМЕЩЕНИЕ (СДВИГ) в центр экрана
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            double[,] translateMat = {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {posX + centerX, posY + centerY, posZ, 1}
            };

            // КОМПОЗИЦИЯ: Масштаб → Вращение X → Вращение Y → Вращение Z → Сдвиг
            matr_transform = MultiplyMatrices(matr_transform, scaleMat);
            matr_transform = MultiplyMatrices(matr_transform, reflectXMat);
            matr_transform = MultiplyMatrices(matr_transform, reflectYMat);
            matr_transform = MultiplyMatrices(matr_transform, reflectZMat);
            matr_transform = MultiplyMatrices(matr_transform, rotXMat);
            matr_transform = MultiplyMatrices(matr_transform, rotYMat);
            matr_transform = MultiplyMatrices(matr_transform, rotZMat);
            matr_transform = MultiplyMatrices(matr_transform, translateMat);
        }

        // ========== 3. УМНОЖЕНИЕ ДВУХ МАТРИЦ 4×4 ==========
        private double[,] MultiplyMatrices(double[,] a, double[,] b)
        {
            double[,] result = new double[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < 4; k++)
                        sum += a[i, k] * b[k, j];
                    result[i, j] = sum;
                }
            return result;
        }

        // ========== 4. УМНОЖЕНИЕ ВСЕЙ ФИГУРЫ НА МАТРИЦУ ПРЕОБРАЗОВАНИЯ ==========
        private double[,] MultiplyFigureByMatrix()
        {
            double[,] result = new double[5, 4];
            for (int i = 0; i < 5; i++)           // по всем вершинам
                for (int j = 0; j < 4; j++)       // по всем координатам
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 4; k++)   // умножаем строку на столбец
                        result[i, j] += figure[i, k] * matr_transform[k, j];
                }
            return result;
        }

        // ========== РИСОВАНИЕ ОСЕЙ ==========
        private void Draw_osi()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
                g.Clear(Color.White);

            Pen myPen = new Pen(Color.Red, 1);
            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawLine(myPen, 0, cy, pictureBox1.Width, cy);
                g.DrawLine(myPen, cx, 0, cx, pictureBox1.Height);
            }

            myPen.Dispose();
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        // ========== РИСОВАНИЕ ФИГУРЫ (9 линий) ==========
        private void Draw_Kv()
        {
            // Строим матрицу преобразования
            Init_matr_preob();

            // Умножаем фигуру на матрицу
            double[,] transformed = MultiplyFigureByMatrix();

            Pen myPen = new Pen(Color.Blue, 2);
            if (pictureBox1.Image != null)
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    // Рисуем 9 рёбер
                    for (int i = 0; i < edges.GetLength(0); i++)
                    {
                        int v1 = edges[i, 0];
                        int v2 = edges[i, 1];

                        float x1 = (float)transformed[v1, 0];
                        float y1 = (float)transformed[v1, 1];
                        float x2 = (float)transformed[v2, 0];
                        float y2 = (float)transformed[v2, 1];

                        g.DrawLine(myPen, x1, y1, x2, y2);
                    }
                }
            }

            myPen.Dispose();
            pictureBox1.Refresh();
        }

        // ========== ОСНОВНАЯ ОТРИСОВКА (ОСИ + ФИГУРА) ==========
        private void RefreshDrawing()
        {
            Draw_osi();
            if (showFunction)
                DrawFunction();
            else
                Draw_Kv();
        }

        // =========== КНОПКИ ===========

        private void btnDrawOsi_Click(object sender, EventArgs e)
        {
            Draw_osi();
        }

        private void btnDrawFigure_Click(object sender, EventArgs e)
        {
            // Сбрасываем все TrackBar
            trackBarMoveX.Value = 0;
            trackBarMoveY.Value = 0;
            trackBarMoveZ.Value = 0;
            trackBarRotX.Value = 0;
            trackBarRotY.Value = 0;
            trackBarRotZ.Value = 0;

            // Сбрасываем все преобразования в центр
            posX = 0; posY = 0; posZ = 0;
            rotX = 0; rotY = 0; rotZ = 0;
            scaleX = 1; scaleY = 1; scaleZ = 1;
            reflectX = false; reflectY = false; reflectZ = false;

            // Если показывали функцию, возвращаемся к фигуре
            if (showFunction)
            {
                showFunction = false;
                btnFunction.Text = "Вариант 2.7";
            }

            RefreshDrawing();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Сбрасываем все TrackBar
            trackBarMoveX.Value = 0;
            trackBarMoveY.Value = 0;
            trackBarMoveZ.Value = 0;
            trackBarRotX.Value = 0;
            trackBarRotY.Value = 0;
            trackBarRotZ.Value = 0;

            // Сбрасываем все преобразования
            posX = 0; posY = 0; posZ = 0;
            rotX = 0; rotY = 0; rotZ = 0;
            scaleX = 1; scaleY = 1; scaleZ = 1;
            reflectX = false; reflectY = false; reflectZ = false;

            // Возвращаем всё в начальное положение (оси + фигура)
            RefreshDrawing();
        }

        // Перемещение
        private void trackBarMoveX_Scroll(object sender, EventArgs e)
        {
            posX = trackBarMoveX.Value * 10.0;
            RefreshDrawing();
        }

        private void trackBarMoveY_Scroll(object sender, EventArgs e)
        {
            posY = trackBarMoveY.Value * 10.0;
            RefreshDrawing();
        }

        private void trackBarMoveZ_Scroll(object sender, EventArgs e)
        {
            posZ = trackBarMoveZ.Value * 10.0;
            RefreshDrawing();
        }


        // Отражение
        private void btnReflectX_Click(object sender, EventArgs e) { reflectX = !reflectX; RefreshDrawing(); }

        private void btnReflectY_Click(object sender, EventArgs e) { reflectY = !reflectY; RefreshDrawing(); }
        private void btnReflectZ_Click(object sender, EventArgs e) { reflectZ = !reflectZ; RefreshDrawing(); }

        // Масштаб
        private void btnScaleUp_Click(object sender, EventArgs e) { scaleX += 0.1; scaleY += 0.1; scaleZ += 0.1; RefreshDrawing(); }
        private void btnScaleDown_Click(object sender, EventArgs e) { scaleX -= 0.1; scaleY -= 0.1; scaleZ -= 0.1; RefreshDrawing(); }

        // Вращение
        private void trackBarRotX_Scroll(object sender, EventArgs e)
        {
            rotX = trackBarRotX.Value * 10;
            RefreshDrawing();
        }

        private void trackBarRotY_Scroll(object sender, EventArgs e)
        {
            rotY = trackBarRotY.Value * 10;
            RefreshDrawing();
        }

        private void trackBarRotZ_Scroll(object sender, EventArgs e)
        {
            rotZ = trackBarRotZ.Value * 10;
            RefreshDrawing();
        }


        // Непрерывное преобразование
        private void btnAnimation_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            btnAnimation.Text = "Стоп";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                btnAnimation.Text = "Старт";
            }
            f = !f;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioMove.Checked)
            {
                posX++;
            }
            else if (radioScale.Checked)
            {
                scaleX += 0.05; scaleY += 0.05; scaleZ += 0.05;
                if (scaleX > 3.0) scaleX = 3.0;
                if (scaleY > 3.0) scaleY = 3.0;
                if (scaleZ > 3.0) scaleZ = 3.0;
            }
            else if (radioRotate.Checked)
            {
                rotY += 3;
            }
            RefreshDrawing();
        }

        private void btnFunction_Click(object sender, EventArgs e)
        {
            showFunction = !showFunction;  // переключаем режим

            if (showFunction)
                btnFunction.Text = "Фигура";
            else
                btnFunction.Text = "Вариант 2.7";

            // Сбрасываем преобразования
            posX = 0; posY = 0; posZ = 0;
            rotX = 0; rotY = 0; rotZ = 0;
            scaleX = 1; scaleY = 1; scaleZ = 1;
            reflectX = false; reflectY = false; reflectZ = false;

            // Сбрасываем TrackBar
            trackBarMoveX.Value = 0;
            trackBarMoveY.Value = 0;
            trackBarMoveZ.Value = 0;
            trackBarRotX.Value = 0;
            trackBarRotY.Value = 0;
            trackBarRotZ.Value = 0;

            RefreshDrawing();
        }

        // ========== ФУНКЦИЯ ВАРИАНТ 7: Z = e^(sin(x) - y²) ==========
        private void InitFunction()
        {
            totalPoints = gridSize * gridSize;
            functionPoints = new double[totalPoints, 4];

            // Диапазон изменения x и y: [-3; 3]
            double min = -3.0;
            double max = 3.0;
            double step = (max - min) / (gridSize - 1);

            int index = 0;
            for (int i = 0; i < gridSize; i++)
            {
                double x = min + i * step;
                for (int j = 0; j < gridSize; j++)
                {
                    double y = min + j * step;

                    // Z = e^(sin(x) - y²)
                    double z = Math.Exp(Math.Sin(x) - y * y);

                    // Масштабируем координаты для отображения на экране
                    functionPoints[index, 0] = x * 30;    // X
                    functionPoints[index, 1] = y * 30;    // Y
                    functionPoints[index, 2] = z * 30;    // Z (умножаем для наглядности)
                    functionPoints[index, 3] = 1;         // однородная координата

                    index++;
                }
            }
        }

        // ========== УМНОЖЕНИЕ ФУНКЦИИ НА МАТРИЦУ ПРЕОБРАЗОВАНИЯ ==========
        private double[,] MultiplyFunctionByMatrix()
        {
            double[,] result = new double[totalPoints, 4];
            for (int i = 0; i < totalPoints; i++)
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 4; k++)
                        result[i, j] += functionPoints[i, k] * matr_transform[k, j];
                }
            return result;
        }

        // ========== РИСОВАНИЕ ПОВЕРХНОСТИ ФУНКЦИИ (СПЛОШНАЯ ЗАЛИВКА) ==========
        private void DrawFunction()
        {
            Init_matr_preob();
            double[,] transformed = MultiplyFunctionByMatrix();

            if (pictureBox1.Image != null)
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    // Сплошная заливка синим цветом
                    Brush brush = new SolidBrush(Color.FromArgb(100, 0, 0, 255)); // полупрозрачный синий
                    Pen pen = new Pen(Color.Blue, 1.5f);

                    // Рисуем залитые треугольники
                    for (int i = 0; i < gridSize - 1; i++)
                    {
                        for (int j = 0; j < gridSize - 1; j++)
                        {
                            int idx1 = i * gridSize + j;
                            int idx2 = i * gridSize + j + 1;
                            int idx3 = (i + 1) * gridSize + j;
                            int idx4 = (i + 1) * gridSize + j + 1;

                            float x1 = (float)transformed[idx1, 0];
                            float y1 = (float)transformed[idx1, 1];
                            float x2 = (float)transformed[idx2, 0];
                            float y2 = (float)transformed[idx2, 1];
                            float x3 = (float)transformed[idx3, 0];
                            float y3 = (float)transformed[idx3, 1];
                            float x4 = (float)transformed[idx4, 0];
                            float y4 = (float)transformed[idx4, 1];

                            PointF p1 = new PointF(x1, y1);
                            PointF p2 = new PointF(x2, y2);
                            PointF p3 = new PointF(x3, y3);
                            PointF p4 = new PointF(x4, y4);

                            // Заливаем два треугольника
                            g.FillPolygon(brush, new PointF[] { p1, p2, p3 });
                            g.FillPolygon(brush, new PointF[] { p2, p4, p3 });
                        }
                    }

                    // Рисуем контуры
                    for (int i = 0; i < gridSize; i++)
                    {
                        for (int j = 0; j < gridSize - 1; j++)
                        {
                            int idx1 = i * gridSize + j;
                            int idx2 = i * gridSize + j + 1;

                            float x1 = (float)transformed[idx1, 0];
                            float y1 = (float)transformed[idx1, 1];
                            float x2 = (float)transformed[idx2, 0];
                            float y2 = (float)transformed[idx2, 1];

                            g.DrawLine(pen, x1, y1, x2, y2);
                        }
                    }

                    for (int j = 0; j < gridSize; j++)
                    {
                        for (int i = 0; i < gridSize - 1; i++)
                        {
                            int idx1 = i * gridSize + j;
                            int idx2 = (i + 1) * gridSize + j;

                            float x1 = (float)transformed[idx1, 0];
                            float y1 = (float)transformed[idx1, 1];
                            float x2 = (float)transformed[idx2, 0];
                            float y2 = (float)transformed[idx2, 1];

                            g.DrawLine(pen, x1, y1, x2, y2);
                        }
                    }

                    brush.Dispose();
                    pen.Dispose();
                }
            }
            pictureBox1.Refresh();
        }
    }
}
