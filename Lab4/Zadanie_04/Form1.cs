using System;
using System.Drawing;
using System.Windows.Forms;
using SharpDX.DirectInput; //Biblioteka do obsługi 

namespace Zadanie_04
{
    public partial class Form1 : Form
    {
        // Główne obiekty do obsługi pada
        private DirectInput directInput = new DirectInput();
        private Joystick joystick;
        private JoystickState stan;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.ClientSize = new Size(500, 440);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var devices = directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices);

            if (devices.Count > 0)
            {
                joystick = new Joystick(directInput, devices[0].InstanceGuid);
                joystick.Acquire();
            }
            else
            {
                MessageBox.Show("Nie wykryto pada! Podłącz pada");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (joystick != null)
            {
                try
                {
                    joystick.Poll();
                    stan = joystick.GetCurrentState();
                    this.Invalidate();
                }
                catch
                {
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (stan == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Font fontNaglowek = new Font("Arial", 16, FontStyle.Bold);
            Font fontSekcja = new Font("Arial", 10, FontStyle.Bold);

            StringFormat sfSrodek = new StringFormat();
            sfSrodek.Alignment = StringAlignment.Center;

            g.DrawString("Pad od PS5", fontNaglowek, Brushes.MidnightBlue, new RectangleF(0, 10, this.ClientSize.Width, 30), sfSrodek);

            // L1, R1
            RysujPrzycisk(g, "L1", stan.Buttons[4], 85, 50, 50, 30);
            RysujPrzycisk(g, "R1", stan.Buttons[5], 315, 50, 50, 30);

            // Lewa gałka
            g.DrawEllipse(Pens.Black, 50, 90, 120, 120);
            float lX = (stan.X - 32767) / 32767f * 60f;
            float lY = (stan.Y - 32767) / 32767f * 60f;
            g.FillEllipse(Brushes.RoyalBlue, 110 + lX - 15, 150 + lY - 15, 30, 30);
            RysujPrzycisk(g, "L3", stan.Buttons[10], 90, 220, 40, 30);

            // Prawa gałka
            g.DrawEllipse(Pens.Black, 280, 90, 120, 120);
            float rX = (stan.Z - 32767) / 32767f * 60f;
            float rY = (stan.RotationZ - 32767) / 32767f * 60f;
            g.FillEllipse(Brushes.Crimson, 340 + rX - 15, 150 + rY - 15, 30, 30);
            RysujPrzycisk(g, "R3", stan.Buttons[11], 320, 220, 40, 30);

            // Przyciski kształtów
            RysujPrzycisk(g, "□", stan.Buttons[0], 280, 330, 40, 40, true);
            RysujPrzycisk(g, "X", stan.Buttons[1], 330, 380, 40, 40, true);
            RysujPrzycisk(g, "○", stan.Buttons[2], 380, 330, 40, 40, true);
            RysujPrzycisk(g, "△", stan.Buttons[3], 330, 280, 40, 40, true);

            // Touchpad
            RysujPrzycisk(g, "TOUCHPAD CLICK", stan.Buttons[13], 155, 230, 140, 30);

            // Strzałki
            int pov = stan.PointOfViewControllers[0];
            RysujPrzycisk(g, "↑", pov == 0, 90, 285, 35, 35);
            RysujPrzycisk(g, "←", pov == 27000, 50, 320, 35, 35);
            RysujPrzycisk(g, "→", pov == 9000, 130, 320, 35, 35);
            RysujPrzycisk(g, "↓", pov == 18000, 90, 355, 35, 35);

            // L2, R2
            g.DrawString("L2", fontSekcja, Brushes.Black, 20, 100);
            g.DrawRectangle(Pens.Black, 25, 120, 10, 100);
            float l2 = (stan.RotationX / 65535f) * 100f;
            g.FillRectangle(Brushes.Orange, 26, 120 + (100 - l2), 9, l2);

            g.DrawString("R2", fontSekcja, Brushes.Black, 440, 100);
            g.DrawRectangle(Pens.Black, 445, 120, 10, 100);
            float r2 = (stan.RotationY / 65535f) * 100f;
            g.FillRectangle(Brushes.Orange, 446, 120 + (100 - r2), 9, r2);
        }

        private void RysujPrzycisk(Graphics g, string tekst, bool wcisniety, int x, int y, int w = 40, int h = 40, bool jestKolem = false)
        {
            Brush kolorTla = wcisniety ? Brushes.LimeGreen : Brushes.WhiteSmoke;
            Pen ramka = new Pen(Color.Black, 1);

            if (jestKolem)
            {
                g.FillEllipse(kolorTla, x, y, w, h);
                g.DrawEllipse(ramka, x, y, w, h);
            }
            else
            {
                g.FillRectangle(kolorTla, x, y, w, h);
                g.DrawRectangle(ramka, x, y, w, h);
            }

            Font f = new Font("Arial", 10, FontStyle.Bold);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(tekst, f, Brushes.Black, new RectangleF(x, y, w, h), sf);
        }
    }
}