using System;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace Zadanie_06
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _port;
        private readonly string _senderEmail;
        private readonly string _senderPassword;

        public EmailService(string smtpServer, int port, string senderEmail, string senderPassword)
        {
            _smtpServer = smtpServer;
            _port = port;
            _senderEmail = senderEmail;
            _senderPassword = senderPassword;
        }

        public void SendEmail(string recipientEmail, string subject, string body, string[] attachmentPaths = null)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(_senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = false;

                    if (attachmentPaths != null)
                    {
                        foreach (string path in attachmentPaths)
                        {
                            if (File.Exists(path))
                            {
                                Attachment attachment = new Attachment(path);
                                mail.Attachments.Add(attachment);
                            }
                            else
                            {
                                Console.WriteLine($"Ostrzeżenie: Nie znaleziono pliku: {path}");
                            }
                        }
                    }

                    // 3. Konfiguracja klienta SMTP
                    using (SmtpClient smtp = new SmtpClient(_smtpServer, _port))
                    {
                        smtp.Credentials = new NetworkCredential(_senderEmail, _senderPassword);
                        smtp.EnableSsl = true;

                        Console.WriteLine("Wysyłanie wiadomości...");
                        smtp.Send(mail);
                        Console.WriteLine("E-mail został wysłany pomyślnie!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas wysyłki: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // KONFIGURACJA EMAILA
            string smtpServer = "smtp.gmail.com";
            int port = 587;
            string myEmail = "jakisemail@gmail.com";
            string myPassword = "haslo do aplikacji w koncie google";

            EmailService emailService = new EmailService(smtpServer, port, myEmail, myPassword);

            // Dane odbiorcy
            string to = "odbiorca@gmail.com";
            string subject = "Temat emaila";
            string body = "Wiadomosc testowa";

            // Załączniki
            string[] files = {
                @"C:\Users\User\Downloads\cat.jpg"
            };

            emailService.SendEmail(to, subject, body, files);

            Console.WriteLine("\nNaciśnij dowolny klawisz...");
            Console.ReadKey();
        }
    }
}