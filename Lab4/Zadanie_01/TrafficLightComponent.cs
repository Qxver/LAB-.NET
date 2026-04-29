using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zadanie_01
{
    public class TrafficLightComponent : UserControl
    {
        private Button changeStateButton;

        // 0 = Czerwone, 1 = Żółte, 2 = Zielone
        private int _currentState = 0;

        public TrafficLightComponent()
        {
            // Podstawowa konfiguracja kontrolki
            this.Width = 100;
            this.Height = 250;
            this.DoubleBuffered = true; // Zapobiega migotaniu podczas rysowania

            // Konfiguracja przycisku
            changeStateButton = new Button();
            changeStateButton.Text = "Zmień stan";
            changeStateButton.Width = 80;
            changeStateButton.Height = 30;
            changeStateButton.Location = new Point(10, 210);
            changeStateButton.BackColor = Color.LightGray;

            // Podpięcie zdarzenia kliknięcia
            changeStateButton.Click += ChangeStateButton_Click;

            // Dodanie przycisku do kontrolki
            this.Controls.Add(changeStateButton);
        }

        private void ChangeStateButton_Click(object sender, EventArgs e)
        {
            // Przejście do następnego stanu (0 -> 1 -> 2 -> 0...)
            _currentState = (_currentState + 1) % 3;

            // Wymuszenie ponownego narysowania kontrolki
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Włączenie wygładzania krawędzi (żeby kółka były ładne i okrągłe)
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Ustalenie kolorów
            Color redColor = _currentState == 0 ? Color.Red : Color.DarkRed;
            Color yellowColor = _currentState == 1 ? Color.Yellow : Color.Olive;
            Color greenColor = _currentState == 2 ? Color.LimeGreen : Color.DarkGreen;

            // Rysowanie poszczególnych świateł
            using (SolidBrush redBrush = new SolidBrush(redColor))
            {
                g.FillEllipse(redBrush, 20, 10, 60, 60);
            }

            using (SolidBrush yellowBrush = new SolidBrush(yellowColor))
            {
                g.FillEllipse(yellowBrush, 20, 75, 60, 60);
            }

            using (SolidBrush greenBrush = new SolidBrush(greenColor))
            {
                g.FillEllipse(greenBrush, 20, 140, 60, 60);
            }
        }
    }
}