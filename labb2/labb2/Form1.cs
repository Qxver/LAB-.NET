using System;
using System.Drawing;
using System.Media; // Potrzebne do odtworzenia dźwięku alarmu
using System.Windows.Forms;

namespace labb2
{
    public partial class Form1 : Form
    {
        private Label timeLabel;
        private Timer updateTimer;

        // Nowe elementy dla alarmu
        private DateTimePicker alarmPicker;
        private Button setAlarmButton;
        private bool isAlarmSet = false;
        private DateTime alarmTime;

        public Form1()
        {
            InitializeComponent();

            // 1. Konfiguracja głównego okna
            this.Text = "Aktualny Czas i Data ze Zegarem";
            this.Size = new Size(400, 320); // Zwiększyłem wysokość, by zmieścić przyciski
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;

            // 2. Konfiguracja etykiety tekstowej (Label)
            timeLabel = new Label();
            timeLabel.Dock = DockStyle.Top; // Zmienione z Fill na Top, by zostawić dół wolny
            timeLabel.Height = 160;
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            timeLabel.Font = new Font("Consolas", 26, FontStyle.Bold);
            timeLabel.ForeColor = Color.LimeGreen;
            this.Controls.Add(timeLabel);

            // 3. Konfiguracja kontrolki wyboru czasu (DateTimePicker)
            alarmPicker = new DateTimePicker();
            alarmPicker.Format = DateTimePickerFormat.Time; // Ustawiamy na sam czas (bez daty)
            alarmPicker.ShowUpDown = true; // Pojawią się strzałki zamiast kalendarza
            alarmPicker.Location = new Point(80, 180);
            alarmPicker.Width = 110;
            alarmPicker.Font = new Font("Arial", 14);
            this.Controls.Add(alarmPicker);

            // 4. Konfiguracja przycisku do ustawienia alarmu
            setAlarmButton = new Button();
            setAlarmButton.Text = "Ustaw Alarm";
            setAlarmButton.Location = new Point(200, 178);
            setAlarmButton.Size = new Size(120, 32);
            setAlarmButton.BackColor = Color.White;
            setAlarmButton.Font = new Font("Arial", 10, FontStyle.Bold);
            setAlarmButton.Click += SetAlarmButton_Click; // Podpięcie zdarzenia kliknięcia
            this.Controls.Add(setAlarmButton);

            // 5. Konfiguracja zegara (Timer)
            updateTimer = new Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();

            UpdateTime();
        }

        // Metoda wywoływana po kliknięciu przycisku
        private void SetAlarmButton_Click(object sender, EventArgs e)
        {
            if (!isAlarmSet)
            {
                // Włączanie alarmu
                alarmTime = alarmPicker.Value;

                // Jeśli wybrana godzina już minęła, ustawiamy alarm na jutro
                if (alarmTime < DateTime.Now)
                {
                    alarmTime = alarmTime.AddDays(1);
                }

                isAlarmSet = true;
                setAlarmButton.Text = "Anuluj Alarm";
                setAlarmButton.BackColor = Color.LightCoral; // Przycisk zmienia kolor na czerwony
            }
            else
            {
                // Wyłączanie alarmu
                isAlarmSet = false;
                setAlarmButton.Text = "Ustaw Alarm";
                setAlarmButton.BackColor = Color.White;
            }

            // Odświeżamy czas od razu, by pokazać informację o alarmie na ekranie
            UpdateTime();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateTime();

            // Sprawdzanie, czy wybiła godzina alarmu
            if (isAlarmSet && DateTime.Now >= alarmTime)
            {
                isAlarmSet = false; // Wyłączamy alarm, by nie dzwonił co sekundę
                setAlarmButton.Text = "Ustaw Alarm";
                setAlarmButton.BackColor = Color.White;

                SystemSounds.Asterisk.Play(); // Odtworzenie systemowego dźwięku

                // Wyświetlenie okienka (blokuje na chwilę program, ale pokazuje komunikat)
                MessageBox.Show("Twój alarm właśnie dzwoni!", "ALARM", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateTime(); // Odświeżamy tekst po zamknięciu okienka
            }
        }

        private void UpdateTime()
        {
            string currentTime = DateTime.Now.ToString("dd MMMM yyyy\nHH:mm:ss");

            // Jeśli alarm jest ustawiony, dopisujemy o tym informację pod zegarem
            if (isAlarmSet)
            {
                timeLabel.Font = new Font("Consolas", 20, FontStyle.Bold); // Zmniejszamy czcionkę, by wszystko się zmieściło
                timeLabel.Text = currentTime + $"\n\n⏰ Alarm: {alarmTime.ToString("HH:mm")}";
                timeLabel.ForeColor = Color.Cyan; // Zmiana koloru czasu, gdy alarm jest aktywny
            }
            else
            {
                timeLabel.Font = new Font("Consolas", 26, FontStyle.Bold); // Standardowa wielkość
                timeLabel.Text = currentTime;
                timeLabel.ForeColor = Color.LimeGreen; // Powrót do zielonego koloru
            }
        }
    }
}