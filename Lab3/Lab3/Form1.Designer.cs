namespace Lab3
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
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtBoxDni = new System.Windows.Forms.TextBox();
            this.buttonOblRoz = new System.Windows.Forms.Button();
            this.txtBoxGodz = new System.Windows.Forms.TextBox();
            this.txtBoxSek = new System.Windows.Forms.TextBox();
            this.labelDni = new System.Windows.Forms.Label();
            this.labelGodz = new System.Windows.Forms.Label();
            this.labelSek = new System.Windows.Forms.Label();
            this.labelData1 = new System.Windows.Forms.Label();
            this.labelData2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd:MM:yyyy       HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(454, 110);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd:MM:yyyy       HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(187, 110);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // txtBoxDni
            // 
            this.txtBoxDni.Location = new System.Drawing.Point(187, 214);
            this.txtBoxDni.Name = "txtBoxDni";
            this.txtBoxDni.Size = new System.Drawing.Size(107, 20);
            this.txtBoxDni.TabIndex = 3;
            this.txtBoxDni.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonOblRoz
            // 
            this.buttonOblRoz.Location = new System.Drawing.Point(371, 151);
            this.buttonOblRoz.Name = "buttonOblRoz";
            this.buttonOblRoz.Size = new System.Drawing.Size(93, 28);
            this.buttonOblRoz.TabIndex = 4;
            this.buttonOblRoz.Text = "Oblicz różnice ";
            this.buttonOblRoz.UseVisualStyleBackColor = true;
            this.buttonOblRoz.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBoxGodz
            // 
            this.txtBoxGodz.Location = new System.Drawing.Point(371, 214);
            this.txtBoxGodz.Name = "txtBoxGodz";
            this.txtBoxGodz.Size = new System.Drawing.Size(93, 20);
            this.txtBoxGodz.TabIndex = 5;
            this.txtBoxGodz.TextChanged += new System.EventHandler(this.txtBoxGodz_TextChanged);
            // 
            // txtBoxSek
            // 
            this.txtBoxSek.Location = new System.Drawing.Point(538, 214);
            this.txtBoxSek.Name = "txtBoxSek";
            this.txtBoxSek.Size = new System.Drawing.Size(116, 20);
            this.txtBoxSek.TabIndex = 6;
            this.txtBoxSek.TextChanged += new System.EventHandler(this.txtBoxSek_TextChanged);
            // 
            // labelDni
            // 
            this.labelDni.AutoSize = true;
            this.labelDni.Location = new System.Drawing.Point(231, 198);
            this.labelDni.Name = "labelDni";
            this.labelDni.Size = new System.Drawing.Size(23, 13);
            this.labelDni.TabIndex = 7;
            this.labelDni.Text = "Dni";
            // 
            // labelGodz
            // 
            this.labelGodz.AutoSize = true;
            this.labelGodz.Location = new System.Drawing.Point(397, 198);
            this.labelGodz.Name = "labelGodz";
            this.labelGodz.Size = new System.Drawing.Size(45, 13);
            this.labelGodz.TabIndex = 8;
            this.labelGodz.Text = "Godziny";
            // 
            // labelSek
            // 
            this.labelSek.AutoSize = true;
            this.labelSek.Location = new System.Drawing.Point(571, 198);
            this.labelSek.Name = "labelSek";
            this.labelSek.Size = new System.Drawing.Size(49, 13);
            this.labelSek.TabIndex = 9;
            this.labelSek.Text = "Sekundy";
            // 
            // labelData1
            // 
            this.labelData1.AutoSize = true;
            this.labelData1.Location = new System.Drawing.Point(255, 94);
            this.labelData1.Name = "labelData1";
            this.labelData1.Size = new System.Drawing.Size(39, 13);
            this.labelData1.TabIndex = 10;
            this.labelData1.Text = "Data 1";
            // 
            // labelData2
            // 
            this.labelData2.AutoSize = true;
            this.labelData2.Location = new System.Drawing.Point(535, 94);
            this.labelData2.Name = "labelData2";
            this.labelData2.Size = new System.Drawing.Size(39, 13);
            this.labelData2.TabIndex = 11;
            this.labelData2.Text = "Data 2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelData2);
            this.Controls.Add(this.labelData1);
            this.Controls.Add(this.labelSek);
            this.Controls.Add(this.labelGodz);
            this.Controls.Add(this.labelDni);
            this.Controls.Add(this.txtBoxSek);
            this.Controls.Add(this.txtBoxGodz);
            this.Controls.Add(this.buttonOblRoz);
            this.Controls.Add(this.txtBoxDni);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtBoxDni;
        private System.Windows.Forms.Button buttonOblRoz;
        private System.Windows.Forms.TextBox txtBoxGodz;
        private System.Windows.Forms.TextBox txtBoxSek;
        private System.Windows.Forms.Label labelDni;
        private System.Windows.Forms.Label labelGodz;
        private System.Windows.Forms.Label labelSek;
        private System.Windows.Forms.Label labelData1;
        private System.Windows.Forms.Label labelData2;
    }
}

