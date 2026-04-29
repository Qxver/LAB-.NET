using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zadanie_02 // Pamiętaj o dopasowaniu nazwy namespace!
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Ustawienia okna
            this.Text = "Zegar Analogowo-Cyfrowy";
            this.Size = new Size(300, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // Tworzymy nasz komponent zegara
            ClockComponent myClock = new ClockComponent();

            // Ustawiamy go na środku
            myClock.Location = new Point(40, 20);

            // Dodajemy do okna
            this.Controls.Add(myClock);
        }
    }
}