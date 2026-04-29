using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zadanie_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Ta metoda ładuje to, co (ewentualnie) wyklikałeś w Designerze
            InitializeComponent();

            // Ustawienia głównego okna
            this.Text = "Zadanie 1 - Sygnalizator";
            this.Size = new Size(300, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tworzymy nasz sygnalizator prosto z kodu
            TrafficLightComponent trafficLight = new TrafficLightComponent();

            // Ustawiamy go na środku okna
            trafficLight.Location = new Point(90, 50);

            // Dodajemy komponent do okna, żeby był widoczny
            this.Controls.Add(trafficLight);
        }
    }
}