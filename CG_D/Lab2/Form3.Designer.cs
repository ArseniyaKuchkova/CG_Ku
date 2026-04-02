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
            this.button5 = new System.Windows.Forms.Button();
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
            this.radioButton3 = new System.Windows.Forms.RadioButton();
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
            this.panel1.Location = new System.Drawing.Point(716, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 714);
            this.panel1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(18, 456);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(216, 72);
            this.button5.TabIndex = 10;
            this.button5.Text = "Генерация окружности";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonRecursive);
            this.groupBox4.Controls.Add(this.radioButtonIterative);
            this.groupBox4.Location = new System.Drawing.Point(6, 139);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(819, 78);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Тип заливки";
            // 
            // radioButtonRecursive
            // 
            this.radioButtonRecursive.AutoSize = true;
            this.radioButtonRecursive.Location = new System.Drawing.Point(10, 33);
            this.radioButtonRecursive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonRecursive.Name = "radioButtonRecursive";
            this.radioButtonRecursive.Size = new System.Drawing.Size(259, 29);
            this.radioButtonRecursive.TabIndex = 3;
            this.radioButtonRecursive.TabStop = true;
            this.radioButtonRecursive.Text = "Рекурсивная заливка";
            this.radioButtonRecursive.UseVisualStyleBackColor = true;
            // 
            // radioButtonIterative
            // 
            this.radioButtonIterative.AutoSize = true;
            this.radioButtonIterative.Location = new System.Drawing.Point(300, 33);
            this.radioButtonIterative.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonIterative.Name = "radioButtonIterative";
            this.radioButtonIterative.Size = new System.Drawing.Size(282, 29);
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
            this.groupBox3.Location = new System.Drawing.Point(358, 228);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(470, 122);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ввод отрезка";
            // 
            // buttonDrawLine
            // 
            this.buttonDrawLine.Location = new System.Drawing.Point(286, 34);
            this.buttonDrawLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDrawLine.Name = "buttonDrawLine";
            this.buttonDrawLine.Size = new System.Drawing.Size(164, 36);
            this.buttonDrawLine.TabIndex = 19;
            this.buttonDrawLine.Text = "Нарисовать";
            this.buttonDrawLine.UseVisualStyleBackColor = true;
            this.buttonDrawLine.Click += new System.EventHandler(this.buttonDrawLine_Click);
            // 
            // textBoxY2
            // 
            this.textBoxY2.Location = new System.Drawing.Point(186, 72);
            this.textBoxY2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxY2.Name = "textBoxY2";
            this.textBoxY2.Size = new System.Drawing.Size(73, 31);
            this.textBoxY2.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "X1";
            // 
            // textBoxX2
            // 
            this.textBoxX2.Location = new System.Drawing.Point(186, 34);
            this.textBoxX2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(73, 31);
            this.textBoxX2.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Y1";
            // 
            // textBoxY1
            // 
            this.textBoxY1.Location = new System.Drawing.Point(52, 72);
            this.textBoxY1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxY1.Name = "textBoxY1";
            this.textBoxY1.Size = new System.Drawing.Size(73, 31);
            this.textBoxY1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "X2";
            // 
            // textBoxX1
            // 
            this.textBoxX1.Location = new System.Drawing.Point(52, 34);
            this.textBoxX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(73, 31);
            this.textBoxX1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Y2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonSolid);
            this.groupBox2.Controls.Add(this.radioButtonDashed);
            this.groupBox2.Controls.Add(this.labelDashStep);
            this.groupBox2.Controls.Add(this.textBoxDashStep);
            this.groupBox2.Location = new System.Drawing.Point(6, 227);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(346, 123);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Стиль линии";
            // 
            // radioButtonSolid
            // 
            this.radioButtonSolid.AutoSize = true;
            this.radioButtonSolid.Checked = true;
            this.radioButtonSolid.Location = new System.Drawing.Point(10, 28);
            this.radioButtonSolid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonSolid.Name = "radioButtonSolid";
            this.radioButtonSolid.Size = new System.Drawing.Size(146, 29);
            this.radioButtonSolid.TabIndex = 7;
            this.radioButtonSolid.TabStop = true;
            this.radioButtonSolid.Text = "Сплошная";
            this.radioButtonSolid.UseVisualStyleBackColor = true;
            this.radioButtonSolid.CheckedChanged += new System.EventHandler(this.radioButtonSolid_CheckedChanged);
            // 
            // radioButtonDashed
            // 
            this.radioButtonDashed.AutoSize = true;
            this.radioButtonDashed.Location = new System.Drawing.Point(10, 70);
            this.radioButtonDashed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonDashed.Name = "radioButtonDashed";
            this.radioButtonDashed.Size = new System.Drawing.Size(161, 29);
            this.radioButtonDashed.TabIndex = 8;
            this.radioButtonDashed.TabStop = true;
            this.radioButtonDashed.Text = "Пунктирная";
            this.radioButtonDashed.UseVisualStyleBackColor = true;
            this.radioButtonDashed.CheckedChanged += new System.EventHandler(this.radioButtonDashed_CheckedChanged);
            // 
            // labelDashStep
            // 
            this.labelDashStep.AutoSize = true;
            this.labelDashStep.Location = new System.Drawing.Point(189, 31);
            this.labelDashStep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDashStep.Name = "labelDashStep";
            this.labelDashStep.Size = new System.Drawing.Size(160, 25);
            this.labelDashStep.TabIndex = 9;
            this.labelDashStep.Text = "Шаг  пунктира:";
            // 
            // textBoxDashStep
            // 
            this.textBoxDashStep.Location = new System.Drawing.Point(194, 73);
            this.textBoxDashStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDashStep.Name = "textBoxDashStep";
            this.textBoxDashStep.Size = new System.Drawing.Size(58, 31);
            this.textBoxDashStep.TabIndex = 10;
            this.textBoxDashStep.Text = "5";
            this.textBoxDashStep.TextChanged += new System.EventHandler(this.textBoxDashStep_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(824, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбирете алгоритм";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(270, 77);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(190, 29);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Толстая линия";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(10, 77);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(126, 29);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Заливка";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 34);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(188, 29);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Обычный ЦДА";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 538);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(218, 36);
            this.button3.TabIndex = 5;
            this.button3.Text = "Цвет линии";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 664);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 664);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(216, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "Выполнить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 584);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(218, 36);
            this.button4.TabIndex = 6;
            this.button4.Text = "Цвет заливки";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(712, 709);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(270, 32);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(466, 29);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Двумерный алгоритм Коэна - Сазерленда";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 714);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form3";
            this.Text = "Растровые алгоритмы";
            this.Load += new System.EventHandler(this.Form3_Load);
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
        private System.Windows.Forms.RadioButton radioButton3;
    }
}