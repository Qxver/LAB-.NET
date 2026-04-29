using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace Zadanie_03
{
    public partial class Service1 : ServiceBase
    {
        private Timer _timer;
        private string _logFilePath = @"C:\Temp\MojaUslugaLog.txt";

        public Service1()
        {
            // Nazwa naszej usługi (musi zgadzać się z instalatorem)
            this.ServiceName = "Service1";
        }

        protected override void OnStart(string[] args)
        {
            WriteLog("Usługa Service1 została pomyślnie uruchomiona.");

            // Ustawiamy timer na 5 sekund (5000 ms)
            _timer = new Timer();
            _timer.Interval = 5000;
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WriteLog("Usługa Service1 działa i wykonuje swoje zadanie w tle...");
        }

        protected override void OnStop()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
            WriteLog("Usługa Service1 została zatrzymana.");
        }

        private void WriteLog(string message)
        {
            try
            {
                // Tworzymy folder, jeśli nie istnieje
                Directory.CreateDirectory(@"C:\Temp");

                string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
                File.AppendAllText(_logFilePath, logLine);
            }
            catch
            {
                // Ignorujemy błędy zapisu, żeby usługa nie uległa awarii
            }
        }
    }
}