using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Zadanie_10
{
    public partial class Form1 : Form
    {
        // Komponenty menu (stworzymy je w kodzie)
        private MenuStrip mainMenuStrip;

        public Form1()
        {
            InitializeComponent();

            // 1. Ustawienie tego okna jako rodzica MDI
            this.IsMdiContainer = true;
            this.Text = "Przeglądarka Obrazów MDI (XML + GIF)";
            this.WindowState = FormWindowState.Maximized;

            // 2. Inicjalizacja menu
            SetupMenu();
        }

        private void SetupMenu()
        {
            mainMenuStrip = new MenuStrip();

            // Menu PLIK
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Plik");
            fileMenu.DropDownItems.Add("Wczytaj Galerię XML", null, OpenXml_Click);
            fileMenu.DropDownItems.Add("Otwórz pojedynczy plik", null, OpenSingle_Click);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add("Wyjście", null, (s, e) => Application.Exit());

            // Menu OKNA (do zarządzania widokiem)
            ToolStripMenuItem windowsMenu = new ToolStripMenuItem("Okna");
            windowsMenu.DropDownItems.Add("Kaskada", null, (s, e) => this.LayoutMdi(MdiLayout.Cascade));
            windowsMenu.DropDownItems.Add("Pionowo", null, (s, e) => this.LayoutMdi(MdiLayout.TileVertical));
            windowsMenu.DropDownItems.Add("Poziomo", null, (s, e) => this.LayoutMdi(MdiLayout.TileHorizontal));

            mainMenuStrip.Items.Add(fileMenu);
            mainMenuStrip.Items.Add(windowsMenu);

            this.MainMenuStrip = mainMenuStrip;
            this.Controls.Add(mainMenuStrip);
        }

        // --- OBSŁUGA ZDARZEŃ ---

        private void OpenXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Pliki XML (*.xml)|*.xml",
                Title = "Wybierz plik konfiguracyjny galerii"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadImagesFromXml(ofd.FileName);
            }
        }

        private void OpenSingle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                // Dodaliśmy obsługę gifa!
                Filter = "Obrazy|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Wybierz obrazek"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                CreateChildForm(ofd.FileName, Path.GetFileName(ofd.FileName));
            }
        }

        // --- LOGIKA XML I MDI ---

        private void LoadImagesFromXml(string path)
        {
            try
            {
                XDocument doc = XDocument.Load(path);
                var zdjecia = doc.Descendants("Zdjecie");

                foreach (var z in zdjecia)
                {
                    string sPath = z.Attribute("Sciezka")?.Value;
                    string sTytul = z.Attribute("Tytul")?.Value ?? "Obraz";

                    if (File.Exists(sPath))
                    {
                        CreateChildForm(sPath, sTytul);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd XML: " + ex.Message);
            }
        }

        private void CreateChildForm(string imagePath, string title)
        {
            // Tworzymy nowe okno podrzędne
            Form child = new Form();
            child.MdiParent = this; // To czyni okno częścią MDI
            child.Text = title;
            child.Size = new Size(500, 400);

            // Dodajemy PictureBox do wyświetlania obrazu/gifa
            PictureBox pb = new PictureBox();
            pb.ImageLocation = imagePath;
            pb.SizeMode = PictureBoxSizeMode.Zoom; // Zachowuje proporcje
            pb.Dock = DockStyle.Fill; // Wypełnia całe okno

            child.Controls.Add(pb);
            child.Show();
        }
    }
}