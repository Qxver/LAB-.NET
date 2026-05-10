using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("BazaOsob")]
public class BazaOsob
{
    [XmlElement("Osoba")]
    public List<Osoba> Osoby { get; set; } = new List<Osoba>();
}