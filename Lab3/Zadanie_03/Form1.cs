using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Zadanie_03
{
    public partial class Form1 : Form
    {
        private BigInteger n, e_key, d;

        public Form1()
        {
            InitializeComponent();

            txtP.Text = "857504083339712752489993810777";
            txtQ.Text = "1029224947942998075080348647219";
            txtE.Text = "65537";
        }

        private void btnGenerujKlucze_Click(object sender, EventArgs e)
        {
            try
            {
                // Konwersja tekstu na BigInteger za pomocą BigInteger.Parse()
                BigInteger p = BigInteger.Parse(txtP.Text);
                BigInteger q = BigInteger.Parse(txtQ.Text);
                e_key = BigInteger.Parse(txtE.Text);

                // n = p * q
                n = p * q;

                // phi = (p - 1) * (q - 1)
                BigInteger phi = (p - 1) * (q - 1);

                // Obliczanie klucza prywatnego (d) za pomocą Rozszerzonego Algorytmu Euklidesa
                d = ModInverse(e_key, phi);

                // Wyświetlanie wyników
                txtN.Text = n.ToString();
                txtD.Text = d.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd generowania kluczy. Upewnij się, że wpisano poprawne liczby.\n" + ex.Message);
            }
        }

        private BigInteger ModInverse(BigInteger a, BigInteger n)
        {
            BigInteger i = n, v = 0, d = 1;
            while (a > 0)
            {
                BigInteger t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }

        private void btnSzyfruj_Click(object sender, EventArgs e)
        {
            try
            {
                string wiadomosc = txtWiadomosc.Text;

                // Zamiana tekstu na tablicę bajtów. 
                // Dodajemy pusty bajt na końcu, aby wymusić liczbę dodatnią dla BigInteger.
                byte[] bytes = Encoding.UTF8.GetBytes(wiadomosc);
                byte[] positiveBytes = new byte[bytes.Length + 1];
                Array.Copy(bytes, positiveBytes, bytes.Length);

                // Tworzymy BigInteger z wiadomości
                BigInteger m = new BigInteger(positiveBytes);

                // Szyfrowanie: c = m^e mod n. Klasa BigInteger ma do tego gotową, zoptymalizowaną metodę!
                BigInteger c = BigInteger.ModPow(m, e_key, n);

                txtSzyfrogram.Text = c.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd szyfrowania: " + ex.Message);
            }
        }

        private void btnDeszyfruj_Click(object sender, EventArgs e)
        {
            try
            {
                BigInteger c = BigInteger.Parse(txtSzyfrogram.Text);

                // Deszyfrowanie: m = c^d mod n
                BigInteger m = BigInteger.ModPow(c, d, n);

                // Zamiana z powrotem z BigInteger na tekst
                byte[] bytes = m.ToByteArray();
                string zdeszyfrowanaWiadomosc = Encoding.UTF8.GetString(bytes).TrimEnd('\0');

                txtZdeszyfrowane.Text = zdeszyfrowanaWiadomosc;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd deszyfrowania: " + ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
