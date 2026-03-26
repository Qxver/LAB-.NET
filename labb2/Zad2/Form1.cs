using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void WykonajDzialanie(char operatorMatematyczny)
        {
            if (double.TryParse(liczbaA.Text, out double valA) &&
                double.TryParse(LiczbaB.Text, out double valB))
            {
                double rezultat = 0;

                switch (operatorMatematyczny)
                {
                    case '+':
                        rezultat = valA + valB;
                        break;
                    case '-':
                        rezultat = valA - valB;
                        break;
                    case '*':
                        rezultat = valA * valB;
                        break;
                    case '/':
                        if (valB == 0)
                        {
                            MessageBox.Show("Nie można dzielić przez zero!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        rezultat = valA / valB;
                        break;
                }

                wynik.Text = rezultat.ToString();
            }
            else
            {
                MessageBox.Show("Proszę wpisać poprawne liczby!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dodaj_Click(object sender, EventArgs e)
        {
            WykonajDzialanie('+');
        }

        private void odejmij_Click(object sender, EventArgs e)
        {
            WykonajDzialanie('-');
        }

        private void pomnoz_Click(object sender, EventArgs e)
        {
            WykonajDzialanie('*');
        }

        private void podziel_Click(object sender, EventArgs e)
        {
            WykonajDzialanie('/');
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}