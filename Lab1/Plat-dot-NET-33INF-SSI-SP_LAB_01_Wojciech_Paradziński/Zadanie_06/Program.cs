using System;
using MojaBiblioteka; 

Console.WriteLine("Program konsolowy Z użyciem DLL");

Matematyka kalkulator = new Matematyka();

string info = kalkulator.PobierzInfo();
Console.WriteLine($"Info z DLL: {info}\n");

Console.Write("Podaj liczbę: ");
if (double.TryParse(Console.ReadLine(), out double liczba))
{
    Console.Write("Podaj potęgę: ");
    if (double.TryParse(Console.ReadLine(), out double potega))
    {
        double wynik = kalkulator.ObliczPotege(liczba, potega);
        Console.WriteLine($"\nWynik obliczony w bibliotece: {wynik}");
    }
    else
    {
        Console.WriteLine("Błędna potęga.");
    }
}
else
{
    Console.WriteLine("Błędna liczba.");
}

Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
Console.ReadKey();