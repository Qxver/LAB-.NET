using System;
using System.Xml;
using System.Xml.Schema;

class Program
{
    static void Main()
    {
        XmlReaderSettings settings = new XmlReaderSettings();

        settings.Schemas.Add(null, "baza.xsd");
        settings.ValidationType = ValidationType.Schema;

        settings.ValidationEventHandler += ValidationCallback;

        XmlReader reader = XmlReader.Create("baza.xml", settings);

        try
        {
            while (reader.Read()) { }

            Console.WriteLine("XML poprawny.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ValidationCallback(object sender, ValidationEventArgs e)
    {
        Console.WriteLine("Błąd walidacji:");
        Console.WriteLine(e.Message);
    }
}