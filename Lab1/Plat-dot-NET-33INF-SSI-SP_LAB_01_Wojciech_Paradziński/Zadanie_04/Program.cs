using System;
using System.IO;

// Rozszerzenie - sortowanie alfabetycznie lub po dacie

class Program {
    static void Main(string[] args) {
        string path;
        string sortMode = "name";

        if (args.Length > 0) {
            path = args[0];
        }
        else {
            path = Directory.GetCurrentDirectory();
        }

        if (args.Length > 1) {
            sortMode = args[1].ToLower();
        }

        if (!Directory.Exists(path)) {
            Console.WriteLine("Podany katalog nie istnieje.");
            return;
        }

        Console.WriteLine($"Zawartość katalogu: {path}\n");

        DirectoryInfo dir = new DirectoryInfo(path);

        DirectoryInfo[] directories = dir.GetDirectories();
        FileInfo[] files = dir.GetFiles();
        
        if (sortMode == "date") {
            Array.Sort(directories, (a, b) => DateTime.Compare(a.LastWriteTime, b.LastWriteTime));
            Array.Sort(files, (a, b) => DateTime.Compare(a.LastWriteTime, b.LastWriteTime));
        }
        else {
            Array.Sort(directories, (a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            Array.Sort(files, (a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
        }

        Console.WriteLine("Katalogi:");
        foreach (DirectoryInfo d in directories) {
            Console.WriteLine($"<DIR>\t{d.Name}\t{d.LastWriteTime}");
        }

        Console.WriteLine("\nPliki:");
        foreach (FileInfo f in files) {
            Console.WriteLine($"{f.Length}\t{f.Name}\t{f.LastWriteTime}");
        }
    }
}