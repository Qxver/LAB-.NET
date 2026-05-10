using System;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        BazaOsob baza = new BazaOsob();

        baza.Osoby.Add(new Osoba("Jan", "Kowalski", 30));
        baza.Osoby.Add(new Osoba("Anna", "Nowak", 22));

        XmlSerializer serializer = new XmlSerializer(typeof(BazaOsob));

        using (FileStream fs = new FileStream("baza.xml", FileMode.Create))
        {
            serializer.Serialize(fs, baza);
        }

        Console.WriteLine("Baza zapisana.");
    }
}