using System;
using System.Windows.Forms;

namespace Zadanie_04
{
    public partial class Form1 : Form
    {
        private double wartoscWyniku = 0;
        private string wykonanaOperacja = "";
        private bool czyWykonanoOperacje = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void przycisk_cyfry_Click(object sender, EventArgs e)
        {
            if ((wyswietlacz.Text == "0") || czyWykonanoOperacje)
            {
                wyswietlacz.Clear();
            }

            czyWykonanoOperacje = false;
            Button przycisk = (Button)sender;

            if (przycisk.Text == ",")
            {
                if (!wyswietlacz.Text.Contains(","))
                {
                    wyswietlacz.Text += przycisk.Text;
                }
            }
            else
            {
                wyswietlacz.Text += przycisk.Text;
            }
        }

        private void przycisk_operatora_Click(object sender, EventArgs e)
        {
            Button przycisk = (Button)sender;

            if (wykonanaOperacja != "" && !czyWykonanoOperacje)
            {
                przyciskRownaSie.PerformClick();
                wykonanaOperacja = przycisk.Text;
                etykietaObecnaOperacja.Text = wartoscWyniku + " " + wykonanaOperacja;
                czyWykonanoOperacje = true;
            }
            else
            {
                wykonanaOperacja = przycisk.Text;
                if (double.TryParse(wyswietlacz.Text, out double parseResult))
                {
                    wartoscWyniku = parseResult;
                }
                etykietaObecnaOperacja.Text = wartoscWyniku + " " + wykonanaOperacja;
                czyWykonanoOperacje = true;
            }
        }

        private void przycisk_C_Click(object sender, EventArgs e)
        {
            wyswietlacz.Text = "0";
            wartoscWyniku = 0;
            etykietaObecnaOperacja.Text = "";
            wykonanaOperacja = "";
        }

        private void przycisk_CE_Click(object sender, EventArgs e)
        {
            wyswietlacz.Text = "0";
        }

        private void przycisk_rowna_sie_Click(object sender, EventArgs e)
        {
            if (double.TryParse(wyswietlacz.Text, out double obecnaWartosc))
            {
                switch (wykonanaOperacja)
                {
                    case "+":
                        wyswietlacz.Text = (wartoscWyniku + obecnaWartosc).ToString();
                        break;
                    case "-":
                        wyswietlacz.Text = (wartoscWyniku - obecnaWartosc).ToString();
                        break;
                    case "*":
                        wyswietlacz.Text = (wartoscWyniku * obecnaWartosc).ToString();
                        break;
                    case "/":
                        if (obecnaWartosc == 0)
                        {
                            MessageBox.Show("Nie można dzielić przez zero!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            wyswietlacz.Text = "0";
                        }
                        else
                        {
                            wyswietlacz.Text = (wartoscWyniku / obecnaWartosc).ToString();
                        }
                        break;
                    default:
                        break;
                }

                if (double.TryParse(wyswietlacz.Text, out double nowyWynik))
                {
                    wartoscWyniku = nowyWynik;
                }

                etykietaObecnaOperacja.Text = "";
                wykonanaOperacja = "";
                czyWykonanoOperacje = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}