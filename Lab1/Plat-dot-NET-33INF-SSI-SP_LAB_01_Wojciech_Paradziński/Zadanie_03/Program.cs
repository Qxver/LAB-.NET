using System;
using System.Collections;

// Rozszerzenie - sortowanie po nazwie

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Parametry wejściowe");

        if (args.Length == 0) {
            Console.WriteLine("Brak parametrów.");
        }
        else {
            for (int i = 0; i < args.Length; i++) {
                Console.WriteLine($"Parametr {i}: {args[i]}");
            }
        }

        Console.WriteLine("\n=== Wybrane zmienne środowiskowe ===");

        string path = Environment.GetEnvironmentVariable("PATH");
        string user = Environment.GetEnvironmentVariable("USERNAME");

        Console.WriteLine($"USERNAME: {user}");
        Console.WriteLine($"PATH: {path}");

        Console.WriteLine("\n=== Wszystkie zmienne środowiskowe ===");

        var variables = Environment.GetEnvironmentVariables();
        
        object[] keys = new object[variables.Keys.Count];
        variables.Keys.CopyTo(keys, 0);
        
        Array.Sort(keys, StringComparer.OrdinalIgnoreCase);
        
        foreach (var key in keys) {
            Console.WriteLine($"{key} = {variables[key]}");
        }
    }
}