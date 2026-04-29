using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zadanie_02
{
    public class ClockComponent : UserControl
    {
        private Timer _timer;

        public ClockComponent()
        {
            this.Size = new Size(200, 250); // Wymiary kontrolki
            this.DoubleBuffered = true;     // Żeby nie mrugało

            // Odpalamy zegar, żeby tykał co sekundę
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += (s, e) => this.Invalidate(); // Odśwież ekran przy każdym "tyknięciu"
            _timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 1. ZEGAR CYFROWY
            DateTime now = DateTime.Now;
            string timeText = now.ToString("HH:mm:ss");
            g.DrawString(timeText, new Font("Arial", 16, FontStyle.Bold), Brushes.Black, 50, 210);

            // 2. ZEGAR ANALOGOWY (Tarcza)
            g.DrawEllipse(Pens.Black, 10, 10, 180, 180); // Kółko na tarczę
            g.FillEllipse(Brushes.Black, 95, 95, 10, 10); // Środek tarczy (punkt 100, 100)

            // Zmienne ułatwiające rysowanie
            int centerX = 100;
            int centerY = 100;
            double mathPi = Math.PI;

            // --- WSKAZÓWKA SEKUNDOWA ---
            // Ułamki z PI i podział przez 30/60 to zamiana czasu na kąt w radianach
            double secAngle = (now.Second * mathPi / 30) - (mathPi / 2);
            int secX = centerX + (int)(70 * Math.Cos(secAngle)); // 70 to długość wskazówki
            int secY = centerY + (int)(70 * Math.Sin(secAngle));
            g.DrawLine(Pens.Red, centerX, centerY, secX, secY);

            // --- WSKAZÓWKA MINUTOWA ---
            double minAngle = (now.Minute * mathPi / 30) - (mathPi / 2);
            int minX = centerX + (int)(60 * Math.Cos(minAngle));
            int minY = centerY + (int)(60 * Math.Sin(minAngle));
            g.DrawLine(new Pen(Color.Black, 2), centerX, centerY, minX, minY);

            // --- WSKAZÓWKA GODZINOWA ---
            double hourAngle = ((now.Hour % 12) * mathPi / 6) - (mathPi / 2);
            int hourX = centerX + (int)(40 * Math.Cos(hourAngle));
            int hourY = centerY + (int)(40 * Math.Sin(hourAngle));
            g.DrawLine(new Pen(Color.Black, 4), centerX, centerY, hourX, hourY);
        }
    }
}