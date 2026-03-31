namespace Lab2
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonRecursive = new System.Windows.Forms.RadioButton();
            this.radioButtonIterative = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDrawLine = new System.Windows.Forms.Button();
            this.textBoxY2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxX2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxY1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxX1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonSolid = new System.Windows.Forms.RadioButton();
            this.radioButtonDashed = new System.Windows.Forms.RadioButton();
            this.labelDashStep = new System.Windows.Forms.Label();
            this.textBoxDashStep = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Location = new System.Drawing.Point(477, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 457);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonRecursive);
            this.groupBox4.Controls.Add(this.radioButtonIterative);
            this.groupBox4.Location = new System.Drawing.Point(4, 89);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(546, 50);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Тип заливки";
            // 
            // radioButtonRecursive
            // 
            this.radioButtonRecursive.AutoSize = true;
            this.radioButtonRecursive.Location = new System.Drawing.Point(7, 21);
            this.radioButtonRecursive.Name = "radioButtonRecursive";
            this.radioButtonRecursive.Size = new System.Drawing.Size(172, 20);
            this.radioButtonRecursive.TabIndex = 3;
            this.radioButtonRecursive.TabStop = true;
            this.radioButtonRecursive.Text = "Рекурсивная заливка";
            this.radioButtonRecursive.UseVisualStyleBackColor = true;
            // 
            // radioButtonIterative
            // 
            this.radioButtonIterative.AutoSize = true;
            this.radioButtonIterative.Location = new System.Drawing.Point(200, 21);
            this.radioButtonIterative.Name = "radioButtonIterative";
            this.radioButtonIterative.Size = new System.Drawing.Size(188, 20);
            this.radioButtonIterative.TabIndex = 4;
            this.radioButtonIterative.TabStop = true;
            this.radioButtonIterative.Text = "Интерактивная заливка";
            this.radioButtonIterative.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDrawLine);
            this.groupBox3.Controls.Add(this.textBoxY2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxX2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxY1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxX1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(239, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 78);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ввод отрезка";
            // 
            // buttonDrawLine
            // 
            this.buttonDrawLine.Location = new System.Drawing.Point(191, 22);
            this.buttonDrawLine.Name = "buttonDrawLine";
            this.buttonDrawLine.Size = new System.Drawing.Size(109, 23);
            this.buttonDrawLine.TabIndex = 19;
            this.buttonDrawLine.Text = "Нарисовать";
            this.buttonDrawLine.UseVisualStyleBackColor = true;
            this.buttonDrawLine.Click += new System.EventHandler(this.buttonDrawLine_Click);
            // 
            // textBoxY2
            // 
            this.textBoxY2.Location = new System.Drawing.Point(124, 46);
            this.textBoxY2.Name = "textBoxY2";
            this.textBoxY2.Size = new System.Drawing.Size(50, 22);
            this.textBoxY2.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "X1";
            // 
            // textBoxX2
            // 
            this.textBoxX2.Location = new System.Drawing.Point(124, 22);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(50, 22);
            this.textBoxX2.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Y1";
            // 
            // textBoxY1
            // 
            this.textBoxY1.Location = new System.Drawing.Point(35, 46);
            this.textBoxY1.Name = "textBoxY1";
            this.textBoxY1.Size = new System.Drawing.Size(50, 22);
            this.textBoxY1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "X2";
            // 
            // textBoxX1
            // 
            this.textBoxX1.Location = new System.Drawing.Point(35, 22);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(50, 22);
            this.textBoxX1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Y2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonSolid);
            this.groupBox2.Controls.Add(this.radioButtonDashed);
            this.groupBox2.Controls.Add(this.labelDashStep);
            this.groupBox2.Controls.Add(this.textBoxDashStep);
            this.groupBox2.Location = new System.Drawing.Point(4, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 79);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Стиль линии";
            // 
            // radioButtonSolid
            // 
            this.radioButtonSolid.AutoSize = true;
            this.radioButtonSolid.Checked = true;
            this.radioButtonSolid.Location = new System.Drawing.Point(7, 18);
            this.radioButtonSolid.Name = "radioButtonSolid";
            this.radioButtonSolid.Size = new System.Drawing.Size(93, 20);
            this.radioButtonSolid.TabIndex = 7;
            this.radioButtonSolid.TabStop = true;
            this.radioButtonSolid.Text = "Сплошная";
            this.radioButtonSolid.UseVisualStyleBackColor = true;
            this.radioButtonSolid.CheckedChanged += new System.EventHandler(this.radioButtonSolid_CheckedChanged);
            // 
            // radioButtonDashed
            // 
            this.radioButtonDashed.AutoSize = true;
            this.radioButtonDashed.Location = new System.Drawing.Point(7, 45);
            this.radioButtonDashed.Name = "radioButtonDashed";
            this.radioButtonDashed.Size = new System.Drawing.Size(107, 20);
            this.radioButtonDashed.TabIndex = 8;
            this.radioButtonDashed.TabStop = true;
            this.radioButtonDashed.Text = "Пунктирная";
            this.radioButtonDashed.UseVisualStyleBackColor = true;
            this.radioButtonDashed.CheckedChanged += new System.EventHandler(this.radioButtonDashed_CheckedChanged);
            // 
            // labelDashStep
            // 
            this.labelDashStep.AutoSize = true;
            this.labelDashStep.Location = new System.Drawing.Point(126, 20);
            this.labelDashStep.Name = "labelDashStep";
            this.labelDashStep.Size = new System.Drawing.Size(103, 16);
            this.labelDashStep.TabIndex = 9;
            this.labelDashStep.Text = "Шаг  пунктира:";
            // 
            // textBoxDashStep
            // 
            this.textBoxDashStep.Location = new System.Drawing.Point(129, 47);
            this.textBoxDashStep.Name = "textBoxDashStep";
            this.textBoxDashStep.Size = new System.Drawing.Size(40, 22);
            this.textBoxDashStep.TabIndex = 10;
            this.textBoxDashStep.Text = "5";
            this.textBoxDashStep.TextChanged += new System.EventHandler(this.textBoxDashStep_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(4, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбирете алгоритм";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(182, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 20);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Толстая линия";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 49);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Заливка";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(118, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Обычный ЦДА";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 344);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Цвет линии";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(412, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Выполнить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(11, 374);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Цвет заливки";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(475, 454);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 292);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 46);
            this.button5.TabIndex = 10;
            this.button5.Text = "Генерация окружности";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 457);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Растровые алгоритмы";
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxDashStep;
        private System.Windows.Forms.Label labelDashStep;
        private System.Windows.Forms.RadioButton radioButtonDashed;
        private System.Windows.Forms.RadioButton radioButtonSolid;
        private System.Windows.Forms.TextBox textBoxX2;
        private System.Windows.Forms.TextBox textBoxY1;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxY2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDrawLine;
        private System.Windows.Forms.RadioButton radioButtonRecursive;
        private System.Windows.Forms.RadioButton radioButtonIterative;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button5;
    }
}