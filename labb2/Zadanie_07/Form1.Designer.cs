namespace Zadanie_07
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxKoderzy = new System.Windows.Forms.ListBox();
            this.textBoxSzczegoly = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxKoderzy
            // 
            this.listBoxKoderzy.FormattingEnabled = true;
            this.listBoxKoderzy.Location = new System.Drawing.Point(461, 12);
            this.listBoxKoderzy.Name = "listBoxKoderzy";
            this.listBoxKoderzy.Size = new System.Drawing.Size(327, 433);
            this.listBoxKoderzy.TabIndex = 0;
            this.listBoxKoderzy.SelectedIndexChanged += new System.EventHandler(this.listBoxKoderzy_SelectedIndexChanged);
            // 
            // textBoxSzczegoly
            // 
            this.textBoxSzczegoly.Location = new System.Drawing.Point(12, 12);
            this.textBoxSzczegoly.Multiline = true;
            this.textBoxSzczegoly.Name = "textBoxSzczegoly";
            this.textBoxSzczegoly.ReadOnly = true;
            this.textBoxSzczegoly.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSzczegoly.Size = new System.Drawing.Size(326, 433);
            this.textBoxSzczegoly.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxSzczegoly);
            this.Controls.Add(this.listBoxKoderzy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxKoderzy;
        private System.Windows.Forms.TextBox textBoxSzczegoly;
    }
}

