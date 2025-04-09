namespace WinFormsApp2
{
    partial class klienci
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
            listBox1 = new ListBox();
            wybierzKlienta = new Label();
            imie = new Label();
            nazwisko = new Label();
            numerMail = new Label();
            pokoj = new Label();
            iloscOsob = new Label();
            terminOd = new Label();
            terminDo = new Label();
            zamknij = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 90);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(97, 19);
            listBox1.TabIndex = 0;
            // 
            // wybierzKlienta
            // 
            wybierzKlienta.AutoSize = true;
            wybierzKlienta.Location = new Point(12, 54);
            wybierzKlienta.Name = "wybierzKlienta";
            wybierzKlienta.Size = new Size(87, 15);
            wybierzKlienta.TabIndex = 1;
            wybierzKlienta.Text = "Wybierz klienta";
            // 
            // imie
            // 
            imie.AutoSize = true;
            imie.Location = new Point(151, 54);
            imie.Name = "imie";
            imie.Size = new Size(30, 15);
            imie.TabIndex = 2;
            imie.Text = "Imie";
            // 
            // nazwisko
            // 
            nazwisko.AutoSize = true;
            nazwisko.Location = new Point(221, 54);
            nazwisko.Name = "nazwisko";
            nazwisko.Size = new Size(57, 15);
            nazwisko.TabIndex = 3;
            nazwisko.Text = "Nazwisko";
            nazwisko.Click += label3_Click;
            // 
            // numerMail
            // 
            numerMail.AutoSize = true;
            numerMail.Location = new Point(309, 54);
            numerMail.Name = "numerMail";
            numerMail.Size = new Size(72, 15);
            numerMail.TabIndex = 4;
            numerMail.Text = "Numer/Mail";
            // 
            // pokoj
            // 
            pokoj.AutoSize = true;
            pokoj.Location = new Point(409, 54);
            pokoj.Name = "pokoj";
            pokoj.Size = new Size(122, 15);
            pokoj.TabIndex = 5;
            pokoj.Text = "Zarezerwowany pokój";
            // 
            // iloscOsob
            // 
            iloscOsob.AutoSize = true;
            iloscOsob.Location = new Point(551, 54);
            iloscOsob.Name = "iloscOsob";
            iloscOsob.Size = new Size(60, 15);
            iloscOsob.TabIndex = 6;
            iloscOsob.Text = "Ilość osób";
            // 
            // terminOd
            // 
            terminOd.AutoSize = true;
            terminOd.Location = new Point(638, 54);
            terminOd.Name = "terminOd";
            terminOd.Size = new Size(116, 15);
            terminOd.TabIndex = 7;
            terminOd.Text = "Termin rezerwacji od";
            // 
            // terminDo
            // 
            terminDo.AutoSize = true;
            terminDo.Location = new Point(775, 54);
            terminDo.Name = "terminDo";
            terminDo.Size = new Size(116, 15);
            terminDo.TabIndex = 8;
            terminDo.Text = "Termin rezerwacji do";
            // 
            // zamknij
            // 
            zamknij.Location = new Point(409, 155);
            zamknij.Name = "zamknij";
            zamknij.Size = new Size(75, 23);
            zamknij.TabIndex = 9;
            zamknij.Text = "Zamknij";
            zamknij.UseVisualStyleBackColor = true;
            // 
            // klienci
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 201);
            Controls.Add(zamknij);
            Controls.Add(terminDo);
            Controls.Add(terminOd);
            Controls.Add(iloscOsob);
            Controls.Add(pokoj);
            Controls.Add(numerMail);
            Controls.Add(nazwisko);
            Controls.Add(imie);
            Controls.Add(wybierzKlienta);
            Controls.Add(listBox1);
            Name = "klienci";
            Text = "klienci";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label wybierzKlienta;
        private Label imie;
        private Label nazwisko;
        private Label numerMail;
        private Label pokoj;
        private Label iloscOsob;
        private Label terminOd;
        private Label terminDo;
        private Button zamknij;
    }
}