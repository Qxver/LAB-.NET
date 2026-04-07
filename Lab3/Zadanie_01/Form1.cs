using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime data1 = dateTimePicker1.Value;
            DateTime data2 = dateTimePicker2.Value;

            TimeSpan roznica = data1 > data2 ? data1 - data2 : data2 - data1;

            txtBoxDni.Text = roznica.Days.ToString();
            txtBoxGodz.Text = roznica.Hours.ToString();
            txtBoxSek.Text = roznica.Minutes.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxGodz_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxSek_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
