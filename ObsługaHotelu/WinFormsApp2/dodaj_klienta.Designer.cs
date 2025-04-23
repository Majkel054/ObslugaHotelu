namespace WinFormsApp2
{
    partial class dodaj_klienta
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
            imie = new Label();
            nazwisko = new Label();
            kontakt = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            zamknij = new Button();
            dodaj = new Button();
            ilosc = new Label();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // imie
            // 
            imie.AutoSize = true;
            imie.Location = new Point(12, 17);
            imie.Name = "imie";
            imie.Size = new Size(63, 15);
            imie.TabIndex = 0;
            imie.Text = "Podaj imię";
            imie.Click += label1_Click;
            // 
            // nazwisko
            // 
            nazwisko.AutoSize = true;
            nazwisko.Location = new Point(12, 66);
            nazwisko.Name = "nazwisko";
            nazwisko.Size = new Size(88, 15);
            nazwisko.TabIndex = 1;
            nazwisko.Text = "Podaj nazwisko";
            // 
            // kontakt
            // 
            kontakt.AutoSize = true;
            kontakt.Location = new Point(12, 118);
            kontakt.Name = "kontakt";
            kontakt.Size = new Size(109, 15);
            kontakt.TabIndex = 2;
            kontakt.Text = "Podaj numer/maila";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(81, 14);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(130, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(106, 63);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(130, 23);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(127, 115);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(130, 23);
            textBox3.TabIndex = 5;
            // 
            // zamknij
            // 
            zamknij.Location = new Point(94, 246);
            zamknij.Name = "zamknij";
            zamknij.Size = new Size(75, 23);
            zamknij.TabIndex = 6;
            zamknij.Text = "Zakończ";
            zamknij.UseVisualStyleBackColor = true;
            // 
            // dodaj
            // 
            dodaj.Location = new Point(94, 217);
            dodaj.Name = "dodaj";
            dodaj.Size = new Size(75, 23);
            dodaj.TabIndex = 7;
            dodaj.Text = "Dodaj";
            dodaj.UseVisualStyleBackColor = true;
            // 
            // ilosc
            // 
            ilosc.AutoSize = true;
            ilosc.Location = new Point(12, 161);
            ilosc.Name = "ilosc";
            ilosc.Size = new Size(95, 15);
            ilosc.TabIndex = 8;
            ilosc.Text = "Podaj ilość gości";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(127, 159);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 9;
            // 
            // dodaj_klienta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 281);
            Controls.Add(numericUpDown1);
            Controls.Add(ilosc);
            Controls.Add(dodaj);
            Controls.Add(zamknij);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(kontakt);
            Controls.Add(nazwisko);
            Controls.Add(imie);
            Name = "dodaj_klienta";
            Text = "dodaj_klienta";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label imie;
        private Label nazwisko;
        private Label kontakt;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button zamknij;
        private Button dodaj;
        private Label ilosc;
        private NumericUpDown numericUpDown1;
    }
}