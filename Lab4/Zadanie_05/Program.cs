using System;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        Osoba osoba = new Osoba("Jan", "Kowalski", 25);

        XmlSerializer serializer = new XmlSerializer(typeof(Osoba));

        using (FileStream fs = new FileStream("osoba.xml", FileMode.Create))
        {
            serializer.Serialize(fs, osoba);
        }

        Console.WriteLine("Zapisano XML.");
    }
}