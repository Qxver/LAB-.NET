namespace Zad2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dodaj = new System.Windows.Forms.Button();
            this.odejmij = new System.Windows.Forms.Button();
            this.pomnoz = new System.Windows.Forms.Button();
            this.podziel = new System.Windows.Forms.Button();
            this.liczbaA = new System.Windows.Forms.TextBox();
            this.LiczbaB = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wynik = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dodaj
            // 
            this.dodaj.Location = new System.Drawing.Point(317, 243);
            this.dodaj.Name = "dodaj";
            this.dodaj.Size = new System.Drawing.Size(75, 23);
            this.dodaj.TabIndex = 0;
            this.dodaj.Text = "dodaj";
            this.dodaj.UseVisualStyleBackColor = true;
            this.dodaj.Click += new System.EventHandler(this.dodaj_Click);
            // 
            // odejmij
            // 
            this.odejmij.Location = new System.Drawing.Point(398, 243);
            this.odejmij.Name = "odejmij";
            this.odejmij.Size = new System.Drawing.Size(75, 23);
            this.odejmij.TabIndex = 1;
            this.odejmij.Text = "odejmij";
            this.odejmij.UseVisualStyleBackColor = true;
            this.odejmij.Click += new System.EventHandler(this.odejmij_Click);
            // 
            // pomnoz
            // 
            this.pomnoz.Location = new System.Drawing.Point(317, 272);
            this.pomnoz.Name = "pomnoz";
            this.pomnoz.Size = new System.Drawing.Size(75, 23);
            this.pomnoz.TabIndex = 2;
            this.pomnoz.Text = "pomnoz";
            this.pomnoz.UseVisualStyleBackColor = true;
            this.pomnoz.Click += new System.EventHandler(this.pomnoz_Click);
            // 
            // podziel
            // 
            this.podziel.Location = new System.Drawing.Point(398, 272);
            this.podziel.Name = "podziel";
            this.podziel.Size = new System.Drawing.Size(75, 23);
            this.podziel.TabIndex = 3;
            this.podziel.Text = "podziel";
            this.podziel.UseVisualStyleBackColor = true;
            this.podziel.Click += new System.EventHandler(this.podziel_Click);
            // 
            // liczbaA
            // 
            this.liczbaA.Location = new System.Drawing.Point(317, 191);
            this.liczbaA.Name = "liczbaA";
            this.liczbaA.Size = new System.Drawing.Size(75, 20);
            this.liczbaA.TabIndex = 4;
            this.liczbaA.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LiczbaB
            // 
            this.LiczbaB.Location = new System.Drawing.Point(398, 191);
            this.LiczbaB.Name = "LiczbaB";
            this.LiczbaB.Size = new System.Drawing.Size(75, 20);
            this.LiczbaB.TabIndex = 6;
            this.LiczbaB.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Liczba A";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Liczba B";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // wynik
            // 
            this.wynik.Location = new System.Drawing.Point(342, 217);
            this.wynik.Name = "wynik";
            this.wynik.Size = new System.Drawing.Size(100, 20);
            this.wynik.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wynik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LiczbaB);
            this.Controls.Add(this.liczbaA);
            this.Controls.Add(this.podziel);
            this.Controls.Add(this.pomnoz);
            this.Controls.Add(this.odejmij);
            this.Controls.Add(this.dodaj);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dodaj;
        private System.Windows.Forms.Button odejmij;
        private System.Windows.Forms.Button pomnoz;
        private System.Windows.Forms.Button podziel;
        private System.Windows.Forms.TextBox liczbaA;
        private System.Windows.Forms.TextBox LiczbaB;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox wynik;
    }
}

