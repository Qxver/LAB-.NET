using System;
using System.IO;

class Program {
    static void Main(string[] args) {
        string path;
        
        if (args.Length > 0) {
            path = args[0];
        }
        else {
            path = Directory.GetCurrentDirectory();
        }

        if (!Directory.Exists(path)) {
            Console.WriteLine("Podany katalog nie istnieje.");
            return;
        }

        Console.WriteLine($"Zawartość katalogu: {path}\n");

        DirectoryInfo dir = new DirectoryInfo(path);
        
        Console.WriteLine("Katalogi:");
        DirectoryInfo[] directories = dir.GetDirectories();
        foreach (DirectoryInfo d in directories) {
            Console.WriteLine($"<DIR>\t{d.Name}");
        }
        
        Console.WriteLine("\nPliki:");
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo f in files) {
            Console.WriteLine($"{f.Length}\t{f.Name}");
        }
    }
}