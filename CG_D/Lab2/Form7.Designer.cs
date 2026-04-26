namespace Lab2
{
    partial class Form7
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
            this.components = new System.ComponentModel.Container();
            this.btnShip2Slower = new System.Windows.Forms.Button();
            this.btnShip2Faster = new System.Windows.Forms.Button();
            this.btnShip1Slower = new System.Windows.Forms.Button();
            this.btnShip1Faster = new System.Windows.Forms.Button();
            this.btnStartShips = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShip2Slower
            // 
            this.btnShip2Slower.Location = new System.Drawing.Point(612, 278);
            this.btnShip2Slower.Name = "btnShip2Slower";
            this.btnShip2Slower.Size = new System.Drawing.Size(159, 43);
            this.btnShip2Slower.TabIndex = 51;
            this.btnShip2Slower.Text = "Корабль 2\r\nМедленнее";
            this.btnShip2Slower.UseVisualStyleBackColor = true;
            this.btnShip2Slower.Click += new System.EventHandler(this.btnShip2Slower_Click);
            // 
            // btnShip2Faster
            // 
            this.btnShip2Faster.Location = new System.Drawing.Point(612, 203);
            this.btnShip2Faster.Name = "btnShip2Faster";
            this.btnShip2Faster.Size = new System.Drawing.Size(159, 43);
            this.btnShip2Faster.TabIndex = 50;
            this.btnShip2Faster.Text = "Корабль 2\r\nБыстрее";
            this.btnShip2Faster.UseVisualStyleBackColor = true;
            this.btnShip2Faster.Click += new System.EventHandler(this.btnShip2Faster_Click);
            // 
            // btnShip1Slower
            // 
            this.btnShip1Slower.Location = new System.Drawing.Point(394, 278);
            this.btnShip1Slower.Name = "btnShip1Slower";
            this.btnShip1Slower.Size = new System.Drawing.Size(159, 43);
            this.btnShip1Slower.TabIndex = 49;
            this.btnShip1Slower.Text = "Корабль 1\r\nМедленнее";
            this.btnShip1Slower.UseVisualStyleBackColor = true;
            this.btnShip1Slower.Click += new System.EventHandler(this.btnShip1Slower_Click);
            // 
            // btnShip1Faster
            // 
            this.btnShip1Faster.Location = new System.Drawing.Point(394, 203);
            this.btnShip1Faster.Name = "btnShip1Faster";
            this.btnShip1Faster.Size = new System.Drawing.Size(159, 43);
            this.btnShip1Faster.TabIndex = 48;
            this.btnShip1Faster.Text = "Корабль 1\r\nБыстрее";
            this.btnShip1Faster.UseVisualStyleBackColor = true;
            this.btnShip1Faster.Click += new System.EventHandler(this.btnShip1Faster_Click);
            // 
            // btnStartShips
            // 
            this.btnStartShips.Location = new System.Drawing.Point(499, 118);
            this.btnStartShips.Name = "btnStartShips";
            this.btnStartShips.Size = new System.Drawing.Size(159, 43);
            this.btnStartShips.TabIndex = 47;
            this.btnStartShips.Text = "Страт анимации";
            this.btnStartShips.UseVisualStyleBackColor = true;
            this.btnStartShips.Click += new System.EventHandler(this.btnStartShips_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-4, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(366, 453);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(431, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 58);
            this.label1.TabIndex = 52;
            this.label1.Text = "Полет 2-х космических \r\nкораблей вокруг Земли";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShip2Slower);
            this.Controls.Add(this.btnShip2Faster);
            this.Controls.Add(this.btnShip1Slower);
            this.Controls.Add(this.btnShip1Faster);
            this.Controls.Add(this.btnStartShips);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form7";
            this.Text = "Корабли";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShip2Slower;
        private System.Windows.Forms.Button btnShip2Faster;
        private System.Windows.Forms.Button btnShip1Slower;
        private System.Windows.Forms.Button btnShip1Faster;
        private System.Windows.Forms.Button btnStartShips;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}