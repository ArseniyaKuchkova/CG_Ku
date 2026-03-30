namespace Lab2
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.heartButton1 = new CG.HeartButton();
            this.heartButton2 = new CG.HeartButton();
            this.heartButton3 = new CG.HeartButton();
            this.heartButton4 = new CG.HeartButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // heartButton1
            // 
            this.heartButton1.BackColor = System.Drawing.Color.MistyRose;
            this.heartButton1.Font = new System.Drawing.Font("Georgia", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heartButton1.Location = new System.Drawing.Point(86, 118);
            this.heartButton1.Name = "heartButton1";
            this.heartButton1.Size = new System.Drawing.Size(275, 216);
            this.heartButton1.TabIndex = 0;
            this.heartButton1.Text = "\r\nЛабораторная \r\n  работа №1";
            this.heartButton1.UseVisualStyleBackColor = false;
            this.heartButton1.Click += new System.EventHandler(this.heartButton1_Click);
            // 
            // heartButton2
            // 
            this.heartButton2.BackColor = System.Drawing.Color.MistyRose;
            this.heartButton2.Font = new System.Drawing.Font("Georgia", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heartButton2.Location = new System.Drawing.Point(396, 118);
            this.heartButton2.Name = "heartButton2";
            this.heartButton2.Size = new System.Drawing.Size(269, 216);
            this.heartButton2.TabIndex = 1;
            this.heartButton2.Text = "\r\n\r\nЛабораторная \r\n  работа №2\r\n";
            this.heartButton2.UseVisualStyleBackColor = false;
            // 
            // heartButton3
            // 
            this.heartButton3.BackColor = System.Drawing.Color.MistyRose;
            this.heartButton3.Font = new System.Drawing.Font("Georgia", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heartButton3.Location = new System.Drawing.Point(86, 312);
            this.heartButton3.Name = "heartButton3";
            this.heartButton3.Size = new System.Drawing.Size(275, 218);
            this.heartButton3.TabIndex = 2;
            this.heartButton3.Text = "\r\n\r\nЛабораторная \r\n  работа №3\r\n";
            this.heartButton3.UseVisualStyleBackColor = false;
            // 
            // heartButton4
            // 
            this.heartButton4.BackColor = System.Drawing.Color.MistyRose;
            this.heartButton4.Font = new System.Drawing.Font("Georgia", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heartButton4.Location = new System.Drawing.Point(396, 312);
            this.heartButton4.Name = "heartButton4";
            this.heartButton4.Size = new System.Drawing.Size(269, 218);
            this.heartButton4.TabIndex = 3;
            this.heartButton4.Text = "\r\n\r\nЛабораторная \r\n  работа №4\r\n";
            this.heartButton4.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(277, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 75);
            this.label1.TabIndex = 4;
            this.label1.Text = "             584-1\r\nДударева  Клочкова   \r\nКучкова  Плотникова\r\n";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 586);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.heartButton4);
            this.Controls.Add(this.heartButton3);
            this.Controls.Add(this.heartButton2);
            this.Controls.Add(this.heartButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CG.HeartButton heartButton1;
        private CG.HeartButton heartButton2;
        private CG.HeartButton heartButton3;
        private CG.HeartButton heartButton4;
        private System.Windows.Forms.Label label1;
    }
}