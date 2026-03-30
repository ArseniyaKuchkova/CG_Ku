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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void heartButton1_Click(object sender, EventArgs e)
        {
            
            this.Hide();

            Form1 form1 = new Form1();
            form1.ShowDialog(); // или Show() — зависит от логики

            // Когда лабораторная закроется, снова показываем меню
            this.Show();
        }
    }
}
