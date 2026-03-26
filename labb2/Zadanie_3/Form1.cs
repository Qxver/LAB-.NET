using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Nie klikaj mnie znowu",
                "Informacja",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult odpowiedz = MessageBox.Show(
                "Czy na pewno chcesz kliknąć ten przycisk?",
                "Wymagana decyzja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (odpowiedz == DialogResult.Yes)
            {
                MessageBox.Show("Gratulacje użytkowniku! Zostałeś wybrany jako dzisiejszy zwycięzca darmowego IPhone 6s, Playstation 4 lub Samsung Galaxy S6. Kliknj OK aby wybrać nagrodę zanim zdobędzie ją ktoś inny.", "Wynik", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Anulowano akcję. Wybrano NIE.", "Wynik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}