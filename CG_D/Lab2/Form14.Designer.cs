namespace Lab2
{
    partial class Form14
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnDrawOsi = new System.Windows.Forms.Button();
            this.btnDrawFigure = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReflectX = new System.Windows.Forms.Button();
            this.btnReflectY = new System.Windows.Forms.Button();
            this.btnReflectZ = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnScaleUp = new System.Windows.Forms.Button();
            this.btnScaleDown = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.radioRotate = new System.Windows.Forms.RadioButton();
            this.radioScale = new System.Windows.Forms.RadioButton();
            this.radioMove = new System.Windows.Forms.RadioButton();
            this.btnAnimation = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarMoveX = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarMoveZ = new System.Windows.Forms.TrackBar();
            this.trackBarMoveY = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.trackBarRotY = new System.Windows.Forms.TrackBar();
            this.trackBarRotZ = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.trackBarRotX = new System.Windows.Forms.TrackBar();
            this.btnFunction = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotX)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDrawOsi
            // 
            this.btnDrawOsi.Location = new System.Drawing.Point(734, 29);
            this.btnDrawOsi.Name = "btnDrawOsi";
            this.btnDrawOsi.Size = new System.Drawing.Size(110, 42);
            this.btnDrawOsi.TabIndex = 0;
            this.btnDrawOsi.Text = "Нарисовать оси";
            this.btnDrawOsi.UseVisualStyleBackColor = true;
            this.btnDrawOsi.Click += new System.EventHandler(this.btnDrawOsi_Click);
            // 
            // btnDrawFigure
            // 
            this.btnDrawFigure.Location = new System.Drawing.Point(890, 29);
            this.btnDrawFigure.Name = "btnDrawFigure";
            this.btnDrawFigure.Size = new System.Drawing.Size(110, 42);
            this.btnDrawFigure.TabIndex = 2;
            this.btnDrawFigure.Text = "Нарисовать фигуру";
            this.btnDrawFigure.UseVisualStyleBackColor = true;
            this.btnDrawFigure.Click += new System.EventHandler(this.btnDrawFigure_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1038, 29);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 42);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(909, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Сдвиг";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(882, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Отражение";
            // 
            // btnReflectX
            // 
            this.btnReflectX.Location = new System.Drawing.Point(774, 243);
            this.btnReflectX.Name = "btnReflectX";
            this.btnReflectX.Size = new System.Drawing.Size(95, 42);
            this.btnReflectX.TabIndex = 12;
            this.btnReflectX.Text = "Плоскость YOZ";
            this.btnReflectX.UseVisualStyleBackColor = true;
            this.btnReflectX.Click += new System.EventHandler(this.btnReflectX_Click);
            // 
            // btnReflectY
            // 
            this.btnReflectY.Location = new System.Drawing.Point(890, 243);
            this.btnReflectY.Name = "btnReflectY";
            this.btnReflectY.Size = new System.Drawing.Size(95, 42);
            this.btnReflectY.TabIndex = 13;
            this.btnReflectY.Text = "ПлоскостьXOZ";
            this.btnReflectY.UseVisualStyleBackColor = true;
            this.btnReflectY.Click += new System.EventHandler(this.btnReflectY_Click);
            // 
            // btnReflectZ
            // 
            this.btnReflectZ.Location = new System.Drawing.Point(1002, 243);
            this.btnReflectZ.Name = "btnReflectZ";
            this.btnReflectZ.Size = new System.Drawing.Size(95, 42);
            this.btnReflectZ.TabIndex = 14;
            this.btnReflectZ.Text = "Плоскость XOY";
            this.btnReflectZ.UseVisualStyleBackColor = true;
            this.btnReflectZ.Click += new System.EventHandler(this.btnReflectZ_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(892, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Масштаб";
            // 
            // btnScaleUp
            // 
            this.btnScaleUp.Location = new System.Drawing.Point(830, 362);
            this.btnScaleUp.Name = "btnScaleUp";
            this.btnScaleUp.Size = new System.Drawing.Size(95, 45);
            this.btnScaleUp.TabIndex = 16;
            this.btnScaleUp.Text = "Увеличить";
            this.btnScaleUp.UseVisualStyleBackColor = true;
            this.btnScaleUp.Click += new System.EventHandler(this.btnScaleUp_Click);
            // 
            // btnScaleDown
            // 
            this.btnScaleDown.Location = new System.Drawing.Point(949, 362);
            this.btnScaleDown.Name = "btnScaleDown";
            this.btnScaleDown.Size = new System.Drawing.Size(95, 45);
            this.btnScaleDown.TabIndex = 17;
            this.btnScaleDown.Text = "Уменьшить";
            this.btnScaleDown.UseVisualStyleBackColor = true;
            this.btnScaleDown.Click += new System.EventHandler(this.btnScaleDown_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(886, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Вращение";
            // 
            // radioRotate
            // 
            this.radioRotate.AutoSize = true;
            this.radioRotate.Location = new System.Drawing.Point(931, 607);
            this.radioRotate.Name = "radioRotate";
            this.radioRotate.Size = new System.Drawing.Size(85, 20);
            this.radioRotate.TabIndex = 28;
            this.radioRotate.TabStop = true;
            this.radioRotate.Text = "Поворот";
            this.radioRotate.UseVisualStyleBackColor = true;
            // 
            // radioScale
            // 
            this.radioScale.AutoSize = true;
            this.radioScale.Location = new System.Drawing.Point(839, 607);
            this.radioScale.Name = "radioScale";
            this.radioScale.Size = new System.Drawing.Size(86, 20);
            this.radioScale.TabIndex = 27;
            this.radioScale.TabStop = true;
            this.radioScale.Text = "Масштаб";
            this.radioScale.UseVisualStyleBackColor = true;
            // 
            // radioMove
            // 
            this.radioMove.AutoSize = true;
            this.radioMove.Location = new System.Drawing.Point(766, 607);
            this.radioMove.Name = "radioMove";
            this.radioMove.Size = new System.Drawing.Size(67, 20);
            this.radioMove.TabIndex = 26;
            this.radioMove.TabStop = true;
            this.radioMove.Text = "Сдвиг";
            this.radioMove.UseVisualStyleBackColor = true;
            // 
            // btnAnimation
            // 
            this.btnAnimation.Location = new System.Drawing.Point(1022, 603);
            this.btnAnimation.Name = "btnAnimation";
            this.btnAnimation.Size = new System.Drawing.Size(75, 29);
            this.btnAnimation.TabIndex = 25;
            this.btnAnimation.Text = "Старт";
            this.btnAnimation.UseVisualStyleBackColor = true;
            this.btnAnimation.Click += new System.EventHandler(this.btnAnimation_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(705, 686);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // trackBarMoveX
            // 
            this.trackBarMoveX.Location = new System.Drawing.Point(723, 145);
            this.trackBarMoveX.Minimum = -10;
            this.trackBarMoveX.Name = "trackBarMoveX";
            this.trackBarMoveX.Size = new System.Drawing.Size(141, 56);
            this.trackBarMoveX.TabIndex = 30;
            this.trackBarMoveX.Scroll += new System.EventHandler(this.trackBarMoveX_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(731, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "по оси OX";
            // 
            // trackBarMoveZ
            // 
            this.trackBarMoveZ.Location = new System.Drawing.Point(1017, 145);
            this.trackBarMoveZ.Minimum = -10;
            this.trackBarMoveZ.Name = "trackBarMoveZ";
            this.trackBarMoveZ.Size = new System.Drawing.Size(141, 56);
            this.trackBarMoveZ.TabIndex = 30;
            this.trackBarMoveZ.Scroll += new System.EventHandler(this.trackBarMoveZ_Scroll);
            // 
            // trackBarMoveY
            // 
            this.trackBarMoveY.Location = new System.Drawing.Point(870, 145);
            this.trackBarMoveY.Minimum = -10;
            this.trackBarMoveY.Name = "trackBarMoveY";
            this.trackBarMoveY.Size = new System.Drawing.Size(141, 56);
            this.trackBarMoveY.TabIndex = 30;
            this.trackBarMoveY.Scroll += new System.EventHandler(this.trackBarMoveY_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(878, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 34;
            this.label6.Text = "по оси OY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1026, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 35;
            this.label7.Text = "по оси OZ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1026, 496);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 42;
            this.label8.Text = "по оси OZ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(878, 496);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 41;
            this.label9.Text = "по оси OY";
            // 
            // trackBarRotY
            // 
            this.trackBarRotY.Location = new System.Drawing.Point(870, 515);
            this.trackBarRotY.Maximum = 72;
            this.trackBarRotY.Minimum = -72;
            this.trackBarRotY.Name = "trackBarRotY";
            this.trackBarRotY.Size = new System.Drawing.Size(141, 56);
            this.trackBarRotY.TabIndex = 30;
            this.trackBarRotY.Scroll += new System.EventHandler(this.trackBarRotY_Scroll);
            // 
            // trackBarRotZ
            // 
            this.trackBarRotZ.Location = new System.Drawing.Point(1017, 515);
            this.trackBarRotZ.Maximum = 72;
            this.trackBarRotZ.Minimum = -72;
            this.trackBarRotZ.Name = "trackBarRotZ";
            this.trackBarRotZ.Size = new System.Drawing.Size(141, 56);
            this.trackBarRotZ.TabIndex = 30;
            this.trackBarRotZ.Scroll += new System.EventHandler(this.trackBarRotZ_Scroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(731, 496);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 38;
            this.label10.Text = "по оси OX";
            // 
            // trackBarRotX
            // 
            this.trackBarRotX.Location = new System.Drawing.Point(723, 515);
            this.trackBarRotX.Maximum = 72;
            this.trackBarRotX.Minimum = -72;
            this.trackBarRotX.Name = "trackBarRotX";
            this.trackBarRotX.Size = new System.Drawing.Size(141, 56);
            this.trackBarRotX.TabIndex = 30;
            this.trackBarRotX.Scroll += new System.EventHandler(this.trackBarRotX_Scroll);
            // 
            // btnFunction
            // 
            this.btnFunction.Location = new System.Drawing.Point(890, 656);
            this.btnFunction.Name = "btnFunction";
            this.btnFunction.Size = new System.Drawing.Size(95, 42);
            this.btnFunction.TabIndex = 43;
            this.btnFunction.Text = "Вариант 2.7";
            this.btnFunction.UseVisualStyleBackColor = true;
            this.btnFunction.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // Form14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 710);
            this.Controls.Add(this.btnFunction);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trackBarRotY);
            this.Controls.Add(this.trackBarRotZ);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.trackBarRotX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBarMoveY);
            this.Controls.Add(this.trackBarMoveZ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBarMoveX);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radioRotate);
            this.Controls.Add(this.radioScale);
            this.Controls.Add(this.radioMove);
            this.Controls.Add(this.btnAnimation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnScaleDown);
            this.Controls.Add(this.btnScaleUp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReflectZ);
            this.Controls.Add(this.btnReflectY);
            this.Controls.Add(this.btnReflectX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDrawFigure);
            this.Controls.Add(this.btnDrawOsi);
            this.Name = "Form14";
            this.Text = "Form14";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDrawOsi;
        private System.Windows.Forms.Button btnDrawFigure;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReflectX;
        private System.Windows.Forms.Button btnReflectY;
        private System.Windows.Forms.Button btnReflectZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnScaleUp;
        private System.Windows.Forms.Button btnScaleDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioRotate;
        private System.Windows.Forms.RadioButton radioScale;
        private System.Windows.Forms.RadioButton radioMove;
        private System.Windows.Forms.Button btnAnimation;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBarMoveX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBarMoveZ;
        private System.Windows.Forms.TrackBar trackBarMoveY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackBarRotY;
        private System.Windows.Forms.TrackBar trackBarRotZ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBarRotX;
        private System.Windows.Forms.Button btnFunction;
    }
}

