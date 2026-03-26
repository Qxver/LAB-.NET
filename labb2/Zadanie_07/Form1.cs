using System;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace Zadanie_07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ZaladujKodery();
        }

        private void ZaladujKodery()
        {
            ImageCodecInfo[] kodery = ImageCodecInfo.GetImageEncoders();

            listBoxKoderzy.DataSource = kodery;
            listBoxKoderzy.DisplayMember = "CodecName";
        }

        private void listBoxKoderzy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxKoderzy.SelectedItem is ImageCodecInfo wybranyKoder)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SZCZEGÓŁOWE INFORMACJE O KODERZE:");
                sb.AppendLine("-----------------------------------");
                sb.AppendLine($"Nazwa kodera:\t{wybranyKoder.CodecName}");
                sb.AppendLine($"Opis formatu:\t{wybranyKoder.FormatDescription}");
                sb.AppendLine($"Typ MIME:\t{wybranyKoder.MimeType}");
                sb.AppendLine($"Rozszerzenia:\t{wybranyKoder.FilenameExtension}");
                sb.AppendLine($"Wersja formatu:\t{wybranyKoder.Version}");
                sb.AppendLine($"ID formatu:\t{wybranyKoder.FormatID}");

                textBoxSzczegoly.Text = sb.ToString();
            }
        }
    }
}
