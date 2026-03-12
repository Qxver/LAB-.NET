using System;
// Rozszerzenie - wybór języka i wyświetlenie odpowiedniego powitania

Console.WriteLine("Wybierz język:");
Console.WriteLine("1. Polski");
Console.WriteLine("2. Angielski");
Console.WriteLine("3. Niemiecki");

Console.Write("Twój wybór:");
string choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.WriteLine("Witaj, Świecie!");
        break;
    case "2":
        Console.WriteLine("Hello, World!");
        break;
    case "3":
        Console.WriteLine("Hallo, Welt!");
        break;
    default:
        Console.WriteLine("Nieznany wybór");
        break;
}