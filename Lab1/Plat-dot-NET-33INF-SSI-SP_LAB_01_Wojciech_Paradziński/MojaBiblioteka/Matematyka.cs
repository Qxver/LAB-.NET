namespace MojaBiblioteka
{
    public class Matematyka
    {
        public double ObliczPotege(double liczba, double wykladnik)
        {
            return System.Math.Pow(liczba, wykladnik);
        }

        public string PobierzInfo()
        {
            return "Biblioteka Matematyczna v1.0 - stworzona dla Zadania 06.";
        }
    }
}