using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing; // Wymagane do drukowania
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;         // Wymagane do obsługi plików XML

namespace Zadanie_09
{
    public partial class Form1 : Form
    {
        // Deklaracja naszych kontrolek
        private ListView listView;
        private Button btnLoadXml;
        private Button btnPrintPreview;
        private Button btnPrint;

        // Komponenty do drukowania
        private PrintDocument printDoc;
        private PrintPreviewDialog printPreviewDialog;

        // Zmienne pomocnicze do drukowania
        private List<ListViewItem> itemsToPrint;
        private int currentItemIndex;

        public Form1()
        {
            InitializeComponent(); // Twoja standardowa metoda (zostawiamy ją)

            // Wywołujemy nasze metody konfiguracyjne
            InitializeCustomUI();
            InitializePrinting();
        }

        // --- KONFIGURACJA INTERFEJSU ---
        private void InitializeCustomUI()
        {
            this.Text = "Zadanie 09 - Druk XML";
            this.Size = new Size(500, 400);

            // Konfiguracja ListView
            listView = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(12, 12),
                Size = new Size(460, 250),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
            listView.Columns.Add("Nazwa Produktu", 250);
            listView.Columns.Add("Cena (PLN)", 150);

            // Przycisk: Wczytaj XML
            btnLoadXml = new Button { Text = "Wczytaj XML", Location = new Point(12, 280), Size = new Size(100, 40), Anchor = AnchorStyles.Bottom | AnchorStyles.Left };
            btnLoadXml.Click += BtnLoadXml_Click;

            // Przycisk: Podgląd wydruku
            btnPrintPreview = new Button { Text = "Podgląd wydruku", Location = new Point(236, 280), Size = new Size(120, 40), Anchor = AnchorStyles.Bottom | AnchorStyles.Right };
            btnPrintPreview.Click += BtnPrintPreview_Click;

            // Przycisk: Drukuj
            btnPrint = new Button { Text = "Drukuj", Location = new Point(372, 280), Size = new Size(100, 40), Anchor = AnchorStyles.Bottom | AnchorStyles.Right };
            btnPrint.Click += BtnPrint_Click;

            // Dodanie kontrolek do okna
            this.Controls.Add(listView);
            this.Controls.Add(btnLoadXml);
            this.Controls.Add(btnPrintPreview);
            this.Controls.Add(btnPrint);
        }

        // --- KONFIGURACJA DRUKOWANIA ---
        private void InitializePrinting()
        {
            printDoc = new PrintDocument();
            printDoc.BeginPrint += PrintDoc_BeginPrint;
            printDoc.PrintPage += PrintDoc_PrintPage;

            printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 600,
                Height = 600,
                ShowIcon = false,
                Text = "Podgląd wydruku"
            };
        }

        // --- ZDARZENIA PRZYCISKÓW ---
        private void BtnLoadXml_Click(object sender, EventArgs e)
        {
            try
            {
                listView.Items.Clear();
                // Wczytanie pliku XML
                XDocument doc = XDocument.Load("dane.xml");

                foreach (XElement element in doc.Descendants("Produkt"))
                {
                    string nazwa = element.Attribute("Nazwa")?.Value;
                    string cena = element.Attribute("Cena")?.Value;

                    ListViewItem item = new ListViewItem(nazwa);
                    item.SubItems.Add(cena);
                    listView.Items.Add(item);
                }
                MessageBox.Show("Dane zostały załadowane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: Upewnij się, że plik dane.xml istnieje w folderze z aplikacją (bin/Debug).\n\nSzczegóły: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrintPreview_Click(object sender, EventArgs e)
        {
            if (listView.Items.Count == 0) return;
            printPreviewDialog.ShowDialog();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (listView.Items.Count == 0) return;
            printDoc.Print();
        }

        // --- LOGIKA DRUKOWANIA ---
        private void PrintDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            itemsToPrint = new List<ListViewItem>();

            // Logika wyboru: zaznaczone vs wszystkie
            if (listView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView.SelectedItems)
                    itemsToPrint.Add(item);
            }
            else
            {
                foreach (ListViewItem item in listView.Items)
                    itemsToPrint.Add(item);
            }

            currentItemIndex = 0;
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Color.Black);

            float yPos = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;

            if (currentItemIndex == 0)
            {
                g.DrawString("Raport XML z Zadania 09", titleFont, brush, leftMargin, yPos);
                yPos += titleFont.GetHeight(g) + 20;
            }

            while (currentItemIndex < itemsToPrint.Count)
            {
                ListViewItem item = itemsToPrint[currentItemIndex];
                string textToPrint = $"- {item.Text} | Cena: {item.SubItems[1].Text} PLN";

                g.DrawString(textToPrint, regularFont, brush, leftMargin, yPos);
                yPos += regularFont.GetHeight(g) + 10;

                currentItemIndex++;

                if (yPos > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }
    }
}