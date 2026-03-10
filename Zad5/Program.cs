using System;

class Program {
    static void Main(string[] args) {
        if (args.Length != 2) {
            Console.Error.WriteLine("Użycie: progZ4 słowo1 słowo2");
            return;
        }

        string word1 = args[0];
        string word2 = args[1];

        string line;
        
        while ((line = Console.ReadLine()) != null) {
            string modified = line.Replace(word1, word2);
            Console.WriteLine(modified);
        }
    }
}