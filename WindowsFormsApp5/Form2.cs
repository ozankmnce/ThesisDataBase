using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==0)
            {
                Form4 f4 = new Form4();
                f4.Show();
            }

            if(comboBox1.SelectedIndex==1)
            {
                Form3 f3 = new Form3();
                f3.Show();

            }

            if(comboBox1.SelectedIndex==2)
            {
                Form5 f5 = new Form5();
                f5.Show();

            }

            if (comboBox1.SelectedIndex == 3)
            {
                Form6 f6 = new Form6();
                f6.Show();

            }

            if (comboBox1.SelectedIndex == 4)
            {
                Form7 f7 = new Form7();
                f7.Show();

            }

            if (comboBox1.SelectedIndex == 5)
            {
                Form8 f8 = new Form8();
                f8.Show();

            }

            if (comboBox1.SelectedIndex == 6)
            {
                Form9 f9 = new Form9();
                f9.Show();

            }
            if (comboBox1.SelectedIndex == 7)
            {
                Form10 f10 = new Form10();
                f10.Show();

            }
            if (comboBox1.SelectedIndex == 8)
            {
                Form11 f11 = new Form11();
                f11.Show();

            }

            if (comboBox1.SelectedIndex == 9)
            {
                Form12 f12 = new Form12();
                f12.Show();

            }
        }
    }
}
