using System;
using System.Text.RegularExpressions;

// Rozszerzenie - sprawdzenie poprawnosci numeru telefonu

class Program
{
    static bool IsValidIP(string ip)
    {
        string pattern = @"^(\d{1,3}\.){3}\d{1,3}$";
        Regex regex = new Regex(pattern);
        if (regex.IsMatch(ip))
        {
            string[] parts = ip.Split('.');
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int num) && (num < 0 || num > 255))
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    static bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    static bool IsValidPhoneNumber(string phoneNumber)
    {
        string pattern = @"^(\+48[-\s]?)?(\d{3}[-\s]?\d{3}[-\s]?\d{3})$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(phoneNumber);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Wprowadź adres IP do sprawdzenia:");
        string ipInput = Console.ReadLine();

        if (IsValidIP(ipInput))
        {
            Console.WriteLine("Adres IP jest poprawny.");
        }
        else
        {
            Console.WriteLine("Adres IP jest niepoprawny.");
        }

        Console.WriteLine("Wprowadź adres e-mail do sprawdzenia:");
        string emailInput = Console.ReadLine();

        if (IsValidEmail(emailInput))
        {
            Console.WriteLine("Adres e-mail jest poprawny.");
        }
        else
        {
            Console.WriteLine("Adres e-mail jest niepoprawny.");
        }

        Console.WriteLine("Wprowadź numer telefonu do sprawdzenia:");
        string phoneInput = Console.ReadLine();

        if (IsValidPhoneNumber(phoneInput))
        {
            Console.WriteLine("Numer telefonu jest poprawny.");
        }
        else
        {
            Console.WriteLine("Numer telefonu jest niepoprawny.");
        }
    }
}