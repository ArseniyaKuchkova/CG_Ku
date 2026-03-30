using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;


namespace Lab2
{
    public partial class Form1 : Form
    {
        const int MaxN = 10; // максимально допустимая размерность матрицы
        int n = 3; // текущая размерность матрицы
        TextBox[,] MatrText = null;
        TextBox[,] MatrText1 = null;// матрица элементов типа TextBox
        double[,] Matr1 = new double[MaxN, MaxN]; // матрица 1 чисел с плавающей точкой
        double[,] Matr2 = new double[MaxN, MaxN]; // матрица 2 чисел с плавающей точкой
        double[,] Matr3 = new double[MaxN, MaxN]; // матрица результатов
        double scalarValue = 2.0;
        bool f1; // флажок, который указывает о вводе данных в матрицу Matr1
        bool f2; // флажок, который указывает о вводе данных в матрицу Matr2
        int dx = 40, dy = 20; // ширина и высота ячейки в MatrText[,]
        Form2 form2 = null;   // экземпляр (объект) класса формы Form2
        // Вектор (используем первую строку MatrText)
        double[] Vector = new double[MaxN]; // вектор чисел
        double[] VectorResult = new double[MaxN]; // результат умножения
        bool fVector; // флажок ввода вектора
        bool fVector1;

        // Флаг режима ввода (true - вектор, false - матрица)
        bool isVectorMode = false;
        bool isVectorMode1 = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // І. Инициализация элементов управления и внутренних переменных
            textBox1.Text = "";
            f1 = f2 = fVector = fVector1= false; // матрицы еще не заполнены
            label2.Text = "false";
            label3.Text = "false";
            label4.Text = "false";
            label5.Text = "false";

            // ІІ. Выделение памяти и настройка MatrText
            int i, j;

            // 1. Выделение памяти для формы Form2
            form2 = new Form2();

            // 2. Выделение памяти под самую матрицу
            MatrText = new TextBox[MaxN, MaxN];
            MatrText1 = new TextBox[MaxN, MaxN];


            // 3. Выделение памяти для каждой ячейки матрицы и ее настройка
            for (i = 0; i < MaxN; i++)
                for (j = 0; j < MaxN; j++)
                {
                    // 3.1. Выделить память
                    MatrText[i, j] = new TextBox();

                    // 3.2. Обнулить эту ячейку
                    MatrText[i, j].Text = "0";

                    // 3.3. Установить позицию ячейки в форме Form2
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i * dx, 10 + j * dy);

                    // 3.4. Установить размер ячейки
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);

                    // 3.5. Пока что спрятать ячейку
                    MatrText[i, j].Visible = false;

                    // 3.6. Добавить MatrText[i,j] в форму form2
                    form2.Controls.Add(MatrText[i, j]);
                }
            for (i = 0; i < MaxN; i++)
                for (j = 0; j < MaxN; j++)
                {
                    // 3.1. Выделить память
                    MatrText1[i, j] = new TextBox();

                    // 3.2. Обнулить эту ячейку
                    MatrText1[i, j].Text = "0";

                    // 3.3. Установить позицию ячейки в форме Form2
                    MatrText1[i, j].Location = new System.Drawing.Point(10 + i * dx, 10 + j * dy);

                    // 3.4. Установить размер ячейки
                    MatrText1[i, j].Size = new System.Drawing.Size(dx, dy);

                    // 3.5. Пока что спрятать ячейку
                    MatrText1[i, j].Visible = false;

                    // 3.6. Добавить MatrText1
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    // [i,j] в форму form2
                    form2.Controls.Add(MatrText1[i, j]);
                }
        }
        private void Clear_MatrText()
        {
            // Обнуление ячеек MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Text = "0";
        }

        private void Clear_VectorText()
        {
            // Обнуление ячеек вектора (первая строка)
            for (int i = 0; i < n; i++)
            {
                MatrText[i, 0].Text = "0";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Чтение размерности матрицы
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            // 2. Обнулить ячейки MatrText
            Clear_MatrText();

            // 3. Настройка свойств ячеек матрицы MatrText
            //    с привязкой к значению n и форме Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    // 3.2. Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }

            // 4. Корректировка размеров формы
            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + n * dy + form2.button1.Height + 50;

            // 5. Корректировка позиции и размеров кнопки на форме Form2
            form2.button1.Left = 10;
            form2.button1.Top = 10 + n * dy + 10;
            form2.button1.Width = form2.Width - 30;

            // 6. Вызов формы Form2
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // 7. Перенос строк из формы Form2 в матрицу Matr2
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        Matr2[i, j] = Double.Parse(MatrText[i, j].Text);

                // 8. Матрица Matr2 сформирована
                f2 = true;
                label3.Text = "true";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Чтение размерности матрицы
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            // 2. Обнуление ячейки MatrText
            Clear_MatrText();

            // 3. Настройка свойств ячеек матрицы MatrText
            //    с привязкой к значению n и форме Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    // 3.2. Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }

            // 4. Корректировка размеров формы
            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + n * dy + form2.button1.Height + 50;

            // 5. Корректировка позиции и размеров кнопки на форме Form2
            form2.button1.Left = 10;
            form2.button1.Top = 10 + n * dy + 10;
            form2.button1.Width = form2.Width - 30;

            // 6. Вызов формы Form2
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // 7. Перенос строк из формы Form2 в матрицу Matr1
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (MatrText[i, j].Text != "")
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        else
                            Matr1[i, j] = 0;
                // 8. Данные в матрицу Matr1 внесены
                f1 = true;
                label2.Text = "true";
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            int nn;
            nn = Int16.Parse(textBox1.Text);
            if (nn != n)
            {
                f1 = f2 = fVector = false;
                label2.Text = "false";
                label3.Text = "false";
                label4.Text = "false";
                label5.Text = "false";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Проверка, введены ли данные в обеих матрицах
            if (!((f1 == true) && (f2 == true))) return;

            // 2. Вычисление произведения матриц. Результат в Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = 0;
                    for (int k = 0; k < n; k++)
                        Matr3[j, i] = Matr3[j, i] + Matr1[k, i] * Matr2[j, k];
                }

            // 3. Внесение данных в MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    // 3.2. Перевести число в строку
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }

            // 4. Вывод формы
            form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(desktopPath, "Res_Matr.txt");

            using (StreamWriter sw = new StreamWriter(fullPath, false, Encoding.UTF8))
            {
                //  размерность
                sw.WriteLine(n);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sw.Write(Matr3[i, j] + "  ");
                    }
                    sw.WriteLine();
                }
            }

            MessageBox.Show("Файл успешно сохранён на рабочий стол!");
        }
        //сложение матриц
        private void AddMatrices()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = Matr1[i, j] + Matr2[i, j];
                }
        }

        // вычитание матриц
        // вычитание матриц
        private void SubtractMatrices()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = Matr1[i, j] - Matr2[i, j];
                }
        }

        // Метод для ввода константы
        private void SetScalarValue()
        {
            Form inputForm = new Form();
            inputForm.Text = "Ввод константы";
            inputForm.Size = new Size(300, 150);
            inputForm.StartPosition = FormStartPosition.CenterParent;
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.MaximizeBox = false;
            inputForm.MinimizeBox = false;

            Label label = new Label();
            label.Text = "Введите константу для умножения:";
            label.Location = new Point(10, 20);
            label.Size = new Size(260, 20);


            TextBox textBox = new TextBox();
            textBox.Text = scalarValue.ToString();
            textBox.Location = new Point(10, 50);
            textBox.Size = new Size(260, 20);

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Location = new Point(100, 80);
            okButton.Size = new Size(80, 30);
            okButton.DialogResult = DialogResult.OK;

            //inputForm.Controls.Add(label);
            inputForm.Controls.Add(textBox);
            inputForm.Controls.Add(okButton);
            inputForm.AcceptButton = okButton;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                if (double.TryParse(textBox.Text, out double value))
                {
                    scalarValue = value;
                    MessageBox.Show($"Константа установлена: {scalarValue}", "Информация");
                }
                else
                {
                    MessageBox.Show("Некорректное число! Введите число (например: 2,5)", "Ошибка");
                }
            }


        }
        private void MultiplyMatrixByScalar()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = Matr1[i, j] * scalarValue;
                }
        }
        private double ScalarProduct()
        {
            double result = 0;

            // Берем первые строки из Matr1 и Matr2 (индекс строки 0)
            for (int j = 0; j < n; j++)
            {
                result += Matr1[0, j] * Matr2[0, j];
            }

            return result;
        }

        private void DisplayResult()
        {
            // Внесение данных 
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }

            // Вывод формы
            form2.ShowDialog();
        }
        // Сложение
        private void button5_Click(object sender, EventArgs e)
        {
            // введены ли данные?
            if (!(f1 && f2))
            {
                MessageBox.Show("Сначала введите обе матрицы!", "Предупреждение",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddMatrices();
            DisplayResult();
        }

        // Вычитание
        private void button6_Click(object sender, EventArgs e)
        {
            // введены ли данные?
            if (!(f1 && f2))
            {
                MessageBox.Show("Сначала введите обе матрицы!", "Предупреждение",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SubtractMatrices();
            DisplayResult();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!f1)
            {
                MessageBox.Show("Сначала введите матрицу 1!", "Предупреждение",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form inputForm = new Form();
            inputForm.Text = "Ввод константы";
            inputForm.Size = new Size(300, 150);
            inputForm.StartPosition = FormStartPosition.CenterParent;
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.MaximizeBox = false;
            inputForm.MinimizeBox = false;

            Label label = new Label();
            label.Text = "Введите константу для умножения:";
            label.Location = new Point(10, 20);
            label.Size = new Size(260, 20);

            TextBox textBox = new TextBox();
            textBox.Text = scalarValue.ToString();
            textBox.Location = new Point(10, 50);
            textBox.Size = new Size(260, 20);

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Location = new Point(100, 80);
            okButton.Size = new Size(80, 30);
            okButton.DialogResult = DialogResult.OK;

            //inputForm.Controls.Add(label);
            inputForm.Controls.Add(textBox);
            inputForm.Controls.Add(okButton);
            inputForm.AcceptButton = okButton;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                if (double.TryParse(textBox.Text, out double value))
                {
                    scalarValue = value;
                }
                else
                {
                    MessageBox.Show("Некорректное число! Операция отменена.", "Ошибка");
                    return;
                }
            }
            else
            {
                return; 
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = Matr1[i, j] * scalarValue;
                }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }

            form2.ShowDialog();

            MessageBox.Show($"Матрица 1 умножена на константу {scalarValue}", "Готово");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!(f1 && f2))
            {
                MessageBox.Show("Сначала введите обе матрицы!", "Предупреждение",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form choiceForm = new Form();
            choiceForm.Text = "Скалярное произведение";
            choiceForm.Size = new Size(400, 250);
            choiceForm.StartPosition = FormStartPosition.CenterParent;
            choiceForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            choiceForm.MaximizeBox = false;
            choiceForm.MinimizeBox = false;

            Label labelType = new Label();
            labelType.Text = "Что перемножаем:";
            labelType.Location = new Point(20, 20);
            labelType.Size = new Size(150, 20);

            RadioButton rbRows = new RadioButton();
            rbRows.Text = "Строки";
            rbRows.Location = new Point(30, 50);
            rbRows.Size = new Size(100, 20);
            rbRows.Checked = true; 

            RadioButton rbCols = new RadioButton();
            rbCols.Text = "Столбцы";
            rbCols.Location = new Point(150, 50);
            rbCols.Size = new Size(100, 20);

            Label labelNum = new Label();
            labelNum.Text = "Номер строки/столбца (от 0 до n-1):";
            labelNum.Location = new Point(20, 90);
            labelNum.Size = new Size(200, 20);

            NumericUpDown numIndex = new NumericUpDown();
            numIndex.Location = new Point(230, 88);
            numIndex.Size = new Size(60, 20);
            numIndex.Minimum = 0;
            numIndex.Maximum = n - 1;
            numIndex.Value = 0;

            Button okButton = new Button();
            okButton.Text = "Вычислить";
            okButton.Location = new Point(100, 140);
            okButton.Size = new Size(90, 30);
            okButton.DialogResult = DialogResult.OK;

            Button cancelButton = new Button();
            cancelButton.Text = "Отмена";
            cancelButton.Location = new Point(200, 140);
            cancelButton.Size = new Size(90, 30);
            cancelButton.DialogResult = DialogResult.Cancel;

           // choiceForm.Controls.Add(labelType);
            choiceForm.Controls.Add(rbRows);
            choiceForm.Controls.Add(rbCols);
            //choiceForm.Controls.Add(labelNum);
            choiceForm.Controls.Add(numIndex);
            choiceForm.Controls.Add(okButton);
            choiceForm.Controls.Add(cancelButton);
            choiceForm.AcceptButton = okButton;
            choiceForm.CancelButton = cancelButton;

            if (choiceForm.ShowDialog() == DialogResult.OK)
            {
                int index = (int)numIndex.Value;
                double result = 0;

                if (rbRows.Checked) 
                {
                    for (int j = 0; j < n; j++)
                    {
                        result += Matr1[index, j] * Matr2[index, j];
                    }
                    MessageBox.Show($"Скалярное произведение {index}-х строк = {result}",
                                   "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    SaveScalarResultToFile(result, "строки", index);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        result += Matr1[i, index] * Matr2[i, index];
                    }
                    MessageBox.Show($"Скалярное произведение {index}-х столбцов = {result}",
                                   "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SaveScalarResultToFile(result, "столбцы", index);
                }
            }
        }
        private void SaveScalarResultToFile(double result, string type, int index)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(desktopPath, "Res_Matr.txt");

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true, Encoding.UTF8))
                {
                    sw.WriteLine($"\n=== Скалярное произведение {type} ===");
                    sw.WriteLine($"Номер: {index}");
                    sw.WriteLine($"Размерность: {n}");
                    sw.WriteLine($"Результат: {result}");

                    sw.WriteLine($"Матрица 1 ({type} {index}):");
                    if (type == "строки")
                    {
                        for (int j = 0; j < n; j++)
                            sw.Write(Matr1[index, j] + "  ");
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                            sw.Write(Matr1[i, index] + "  ");
                    }
                    sw.WriteLine();

                    sw.WriteLine($"Матрица 2 ({type} {index}):");
                    if (type == "строки")
                    {
                        for (int j = 0; j < n; j++)
                            sw.Write(Matr2[index, j] + "  ");
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                            sw.Write(Matr2[i, index] + "  ");
                    }
                    sw.WriteLine();
                    sw.WriteLine("------------------------");
                }

                MessageBox.Show("Результат добавлен в файл Res_Matr.txt на рабочем столе");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 1. Проверка, введены ли данные в матрице
            if (!(f1 == true)) return;

            // 2. Вычисление транспонирование матрицы. Результат в Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[i, j] = Matr1[j, i];
                }

            // 3. Внесение данных в MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;

                    // 3.2. Перевести число в строку
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }

            // 4. Вывод формы
            form2.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (f1 == false)
            {
                MessageBox.Show("Сначала введите вектор в первую матрицу!", "Ошибка ввода",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool hasNonZeroInFirstRow = false;
            bool hasNonZeroInFirstCol = false;
            bool hasNonZeroElsewhere = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Matr1[i, j] != 0)
                    {
                        if (i == 0) hasNonZeroInFirstRow = true;
                        if (j == 0) hasNonZeroInFirstCol = true;
                        if (i > 0 && j > 0) hasNonZeroElsewhere = true;
                    }
                }
            }

            bool isVector = !hasNonZeroElsewhere && (hasNonZeroInFirstRow || hasNonZeroInFirstCol);
            if (!isVector && n > 1)
            {
                MessageBox.Show("Для вычисления модуля матрица должна быть вектором (1×n или n×1)!\n" +
                               "Заполните только первую строку ИЛИ только первый столбец.",
                               "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double sumSquares = 0;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    sumSquares += Matr1[i, j] * Matr1[i, j];

            double magnitude = Math.Sqrt(sumSquares);

            Clear_MatrText();
            MatrText[0, 0].Text = magnitude.ToString("F4");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Visible = (i == 0 && j == 0);
                }

            form2.Text = "Результат: |v| = " + magnitude.ToString("F4");
            form2.ShowDialog();

        }

        private void button11_Click(object sender, EventArgs e)
        {
        //    if (!(fVector == true && fVector1 == true))
        //    {
        //        MessageBox.Show("Сначала введите оба вектора!", "Ошибка ввода",
        //                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

            if (n != 3)
            {
                MessageBox.Show("Векторное произведение определено только для 3D-векторов!\n" +
                               "Установите размерность n = 3", "Ошибка размерности",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            double ax = Convert.ToDouble (MatrText[0, 0].Text);
            double ay = Convert.ToDouble(MatrText[1, 0].Text);
            double az = Convert.ToDouble(MatrText[2, 0].Text);

            double bx = Convert.ToDouble(MatrText1[0, 0].Text);
            double by = Convert.ToDouble(MatrText1[1, 0].Text);
            double bz = Convert.ToDouble(MatrText1[2, 0].Text);

            // Формула векторного произведения
            double cx = ay * bz - az * by;
            double cy = az * bx - ax * bz;
            double cz = ax * by - ay * bx;

            Clear_MatrText();

            // Записываем результат
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Matr3[i, j] = 0;

            Matr3[0, 0] = cx;
            Matr3[1, 0] = cy;  // Результат тоже в столбец
            Matr3[2, 0] = cz;

            // Вывод результата
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    MatrText[i, j].Visible = true;
                    MatrText[i, j].Text = Matr3[i, j].ToString("F4");
                }

            form2.Text = "Векторное произведение: [" + cx.ToString("F2") + ", " +
                                      cy.ToString("F2") + ", " + cz.ToString("F2") + "]";
            form2.ShowDialog();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            // 1. Проверка, введены ли данные
            if (!(f1 == true && fVector == true))
            {
                MessageBox.Show("Сначала введите матрицу 1 и вектор!",
                               "Ошибка",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // 2. Проверка размерности
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            // 3. Вычисление умножения матрицы на вектор
            for (int i = 0; i < n; i++)
            {
                VectorResult[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    VectorResult[i] += Matr1[i, j] * Vector[j];
                }
            }

            // 4. Вывод результата
            string result = "Результат умножения матрицы на вектор:\n\n";

            result += "Матрица A:\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result += Matr1[i, j].ToString("F2") + "\t";
                }
                result += "\n";
            }

            result += "\nВектор B:\n";
            for (int i = 0; i < n; i++)
            {
                result += Vector[i].ToString("F2") + "\n";
            }

            result += "\nРезультат C = A * B:\n";
            for (int i = 0; i < n; i++)
            {
                result += VectorResult[i].ToString("F2") + "\n";
            }

            MessageBox.Show(result, "Результат умножения");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // 1. Чтение размерности
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            // 2. Обнуление ячеек для вектора
            Clear_VectorText();

            // 3. Устанавливаем режим вектора
            isVectorMode = true;

            // 4. Скрываем все ячейки, потом покажем только первый столбец
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Visible = false;

            // 5. Настройка свойств ячеек для вектора (первый столбец)
            for (int i = 0; i < n; i++)
            {
                // Показываем только первый столбец
                MatrText[i, 0].Visible = true;
                MatrText[i, 0].TabIndex = i + 1;

                // Добавляем подписи
                Label lbl = new Label();
                lbl.Text = "x" + (i + 1) + ":";
                lbl.Location = new System.Drawing.Point(10 + i * dx - 30, 10 + 0 * dy + 5);
                lbl.Size = new System.Drawing.Size(30, 20);
                lbl.Name = "lblVector_" + i;

                // Проверяем, нет ли уже такого Label
                bool labelExists = false;
                foreach (Control ctrl in form2.Controls)
                {
                    if (ctrl is Label && ctrl.Name == "lblVector_" + i)
                    {
                        labelExists = true;
                        break;
                    }
                }

                if (!labelExists)
                {
                    form2.Controls.Add(lbl);
                }
            }

            // 6. Корректировка размеров формы (для одной строки)
            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + 1 * dy + form2.button1.Height + 50;

            // 7. Корректировка позиции и размеров кнопки
            form2.button1.Left = 10;
            form2.button1.Top = 10 + 1 * dy + 10;
            form2.button1.Width = form2.Width - 30;
            form2.button1.Text = "Ввести вектор";

            // 8. Вызов формы Form2
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // 9. Перенос строк в вектор
                for (int i = 0; i < n; i++)
                {
                    if (MatrText[i, 0].Text != "")
                        Vector[i] = Double.Parse(MatrText[i, 0].Text);
                    else
                        Vector[i] = 0;
                }

                // 10. Данные в вектор внесены
                fVector = true;
                label4.Text = "true";
            }

            // 11. Удаляем созданные Label
            for (int i = 0; i < n; i++)
            {
                foreach (Control ctrl in form2.Controls)
                {
                    if (ctrl is Label && ctrl.Name == "lblVector_" + i)
                    {
                        form2.Controls.Remove(ctrl);
                        ctrl.Dispose();
                        break;
                    }
                }
            }

            // 12. Скрываем все ячейки
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Visible = false;

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            // 1. Чтение размерности
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            // 2. Обнуление ячеек для вектора
            Clear_VectorText();

            // 3. Устанавливаем режим вектора
            isVectorMode = true;

            // 4. Скрываем все ячейки, потом покажем только первый столбец
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Visible = false;

            // 5. Настройка свойств ячеек для вектора (первый столбец)
            for (int i = 0; i < n; i++)
            {
                // Показываем только первый столбец
                MatrText[i, 0].Visible = true;
                MatrText[i, 0].TabIndex = i + 1;

                // Добавляем подписи
                Label lbl = new Label();
                lbl.Text = "x" + (i + 1) + ":";
                lbl.Location = new System.Drawing.Point(10 + i * dx - 30, 10 + 0 * dy + 5);
                lbl.Size = new System.Drawing.Size(30, 20);
                lbl.Name = "lblVector_" + i;

                // Проверяем, нет ли уже такого Label
                bool labelExists = false;
                foreach (Control ctrl in form2.Controls)
                {
                    if (ctrl is Label && ctrl.Name == "lblVector_" + i)
                    {
                        labelExists = true;
                        break;
                    }
                }

                if (!labelExists)
                {
                    form2.Controls.Add(lbl);
                }
            }

            // 6. Корректировка размеров формы (для одной строки)
            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + 1 * dy + form2.button1.Height + 50;

            // 7. Корректировка позиции и размеров кнопки
            form2.button1.Left = 10;
            form2.button1.Top = 10 + 1 * dy + 10;
            form2.button1.Width = form2.Width - 30;
            form2.button1.Text = "Ввести вектор";

            // 8. Вызов формы Form2
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // 9. Перенос строк в вектор
                for (int i = 0; i < n; i++)
                {
                    if (MatrText[i, 0].Text != "")
                        Vector[i] = Double.Parse(MatrText[i, 0].Text);
                    else
                        Vector[i] = 0;
                }

                // 10. Данные в вектор внесены
                fVector1 = true;
                label4.Text = "true";
            }

            // 11. Удаляем созданные Label
            for (int i = 0; i < n; i++)
            {
                foreach (Control ctrl in form2.Controls)
                {
                    if (ctrl is Label && ctrl.Name == "lblVector_" + i)
                    {
                        form2.Controls.Remove(ctrl);
                        ctrl.Dispose();
                        break;
                    }
                }
            }

            // 12. Скрываем все ячейки
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Visible = false;
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            // 1. Чтение размерности
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);

            // 2. Обнуление ячеек для вектора
            Clear_VectorText();

            // 3. Устанавливаем режим вектора
            isVectorMode1 = true;

            // 4. Скрываем все ячейки, потом покажем только первый столбец
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText1[i, j].Visible = false;

            // 5. Настройка свойств ячеек для вектора (первый столбец)
            for (int i = 0; i < n; i++)
            {
                // Показываем только первый столбец
                MatrText1[i, 0].Visible = true;
                MatrText1[i, 0].TabIndex = i + 1;

                //// Добавляем подписи
                Label lbl = new Label();
                lbl.Text = "x" + (i + 1) + ":";
                lbl.Location = new System.Drawing.Point(10 + i * dx - 30, 10 + 0 * dy + 5);
                lbl.Size = new System.Drawing.Size(30, 20);
                lbl.Name = "lblVector_" + i;

                // Проверяем, нет ли уже такого Label
                bool labelExists = false;
                foreach (Control ctrl in form2.Controls)
                {
                    if (ctrl is Label && ctrl.Name == "lblVector_" + i)
                    {
                        labelExists = true;
                        break;
                    }
                }

                if (!labelExists)
                {
                    form2.Controls.Add(lbl);
                }
            }

            // 6. Корректировка размеров формы (для одной строки)
            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + 1 * dy + form2.button1.Height + 50;

            // 7. Корректировка позиции и размеров кнопки
            form2.button1.Left = 10;
            form2.button1.Top = 10 + 1 * dy + 10;
            form2.button1.Width = form2.Width - 30;
            form2.button1.Text = "Ввести вектор";

            // 8. Вызов формы Form2
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // 9. Перенос строк в вектор
                for (int i = 0; i < n; i++)
                {
                    if (MatrText1[i, 0].Text != "")
                        Vector[i] = Double.Parse(MatrText1[i, 0].Text);
                    else
                        Vector[i] = 0;
                }

                // 10. Данные в вектор внесены
                fVector = true;
                label5.Text = "true";

            }
            // 12. Скрываем все ячейки
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText1[i, j].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
