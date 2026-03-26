using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Zadanie_06
{
    public partial class Form1 : Form
    {
        private int kolumnaSortowania = -1;
        private List<ListViewItem> wszystkieKontakty;

        public Form1()
        {
            InitializeComponent();

            wszystkieKontakty = new List<ListViewItem>();

            listViewKontakty.View = View.Details;
            listViewKontakty.FullRowSelect = true;
            listViewKontakty.GridLines = true;

            if (listViewKontakty.Columns.Count == 0)
            {
                listViewKontakty.Columns.Add("Imię", 120);
                listViewKontakty.Columns.Add("Nazwisko", 150);
                listViewKontakty.Columns.Add("Telefon", 120);
                listViewKontakty.Columns.Add("Data urodzenia", 150);
            }

            buttonDodaj.Click += buttonDodaj_Click;
            textBoxSzukaj.TextChanged += textBoxSzukaj_TextChanged;
            listViewKontakty.ColumnClick += listViewKontakty_ColumnClick;

            DodajNowyKontakt("Wojtek", "Gola", "254678390", "13.02.1975");
            DodajNowyKontakt("Michał", "Adam", "576385710", "06.10.2000");
            DodajNowyKontakt("Grzegorz", "Floryda", "234654008", "11.11.2011");
            DodajNowyKontakt("Kamil", "Gala", "668345221", "28.05.1997");
            DodajNowyKontakt("Leszek", "Ołowski", "223778001", "17.06.2001");
            DodajNowyKontakt("Dżordżo", "Automaty", "666777888", "14.01.2003");
        }

        private void DodajNowyKontakt(string imie, string nazwisko, string telefon, string dataUrodzenia)
        {
            var element = new ListViewItem(new[] { imie, nazwisko, telefon, dataUrodzenia });
            wszystkieKontakty.Add(element);
            listViewKontakty.Items.Add(element);
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxImie.Text) || string.IsNullOrWhiteSpace(textBoxNazwisko.Text))
            {
                MessageBox.Show("Podaj przynajmniej imię i nazwisko.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DodajNowyKontakt(textBoxImie.Text, textBoxNazwisko.Text, textBoxTelefon.Text, dateTimePickerDataUrodzenia.Value.ToShortDateString());

            textBoxImie.Clear();
            textBoxNazwisko.Clear();
            textBoxTelefon.Clear();
            textBoxSzukaj.Clear();
        }

        private void textBoxSzukaj_TextChanged(object sender, EventArgs e)
        {
            string fraza = textBoxSzukaj.Text.ToLower();
            listViewKontakty.Items.Clear();

            if (string.IsNullOrWhiteSpace(fraza))
            {
                listViewKontakty.Items.AddRange(wszystkieKontakty.ToArray());
            }
            else
            {
                var przefiltrowane = wszystkieKontakty.Where(item =>
                    item.SubItems.Cast<ListViewItem.ListViewSubItem>()
                        .Any(sub => sub.Text.ToLower().Contains(fraza))).ToArray();

                listViewKontakty.Items.AddRange(przefiltrowane);
            }
        }

        private void listViewKontakty_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != kolumnaSortowania)
            {
                kolumnaSortowania = e.Column;
                listViewKontakty.Sorting = SortOrder.Ascending;
            }
            else
            {
                listViewKontakty.Sorting = listViewKontakty.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }

            listViewKontakty.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewKontakty.Sorting);
            listViewKontakty.Sort();
        }
    }

    class ListViewItemComparer : IComparer
    {
        private int kolumna;
        private SortOrder kierunek;

        public ListViewItemComparer(int kolumna, SortOrder kierunek)
        {
            this.kolumna = kolumna;
            this.kierunek = kierunek;
        }

        public int Compare(object x, object y)
        {
            int wynik;
            string tekstX = ((ListViewItem)x).SubItems[kolumna].Text;
            string tekstY = ((ListViewItem)y).SubItems[kolumna].Text;

            if (DateTime.TryParse(tekstX, out DateTime dataX) && DateTime.TryParse(tekstY, out DateTime dataY))
            {
                wynik = DateTime.Compare(dataX, dataY);
            }
            else
            {
                wynik = string.Compare(tekstX, tekstY);
            }

            if (kierunek == SortOrder.Descending)
                wynik *= -1;

            return wynik;
        }
    }
}