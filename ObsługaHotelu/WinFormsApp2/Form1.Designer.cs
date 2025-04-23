namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pokoje = new Button();
            wolnePokoje = new Button();
            klienci = new Button();
            dodajKlienta = new Button();
            terminy = new Button();
            zarezerwuj = new Button();
            zamknij = new Button();
            SuspendLayout();
            // 
            // pokoje
            // 
            pokoje.Location = new Point(50, 48);
            pokoje.Name = "pokoje";
            pokoje.Size = new Size(154, 23);
            pokoje.TabIndex = 0;
            pokoje.Text = "Pokoje";
            pokoje.UseVisualStyleBackColor = true;
            pokoje.Click += pokoje_Click;
            // 
            // wolnePokoje
            // 
            wolnePokoje.Location = new Point(50, 77);
            wolnePokoje.Name = "wolnePokoje";
            wolnePokoje.Size = new Size(154, 23);
            wolnePokoje.TabIndex = 1;
            wolnePokoje.Text = "Wolne Pokoje";
            wolnePokoje.UseVisualStyleBackColor = true;
            wolnePokoje.Click += button2_Click;
            // 
            // klienci
            // 
            klienci.Location = new Point(50, 106);
            klienci.Name = "klienci";
            klienci.Size = new Size(154, 23);
            klienci.TabIndex = 2;
            klienci.Text = "Klienci";
            klienci.UseVisualStyleBackColor = true;
            klienci.Click += button3_Click;
            // 
            // dodajKlienta
            // 
            dodajKlienta.Location = new Point(50, 135);
            dodajKlienta.Name = "dodajKlienta";
            dodajKlienta.Size = new Size(154, 23);
            dodajKlienta.TabIndex = 3;
            dodajKlienta.Text = "Dodaj Klienta";
            dodajKlienta.UseVisualStyleBackColor = true;
            dodajKlienta.Click += dodajKlienta_Click;
            // 
            // terminy
            // 
            terminy.Location = new Point(50, 164);
            terminy.Name = "terminy";
            terminy.Size = new Size(154, 23);
            terminy.TabIndex = 4;
            terminy.Text = "Terminy rezerwacji";
            terminy.UseVisualStyleBackColor = true;
            terminy.Click += terminy_Click;
            // 
            // zarezerwuj
            // 
            zarezerwuj.Location = new Point(50, 193);
            zarezerwuj.Name = "zarezerwuj";
            zarezerwuj.Size = new Size(154, 24);
            zarezerwuj.TabIndex = 5;
            zarezerwuj.Text = "Zarezerwuj";
            zarezerwuj.UseVisualStyleBackColor = true;
            zarezerwuj.Click += zarezerwuj_Click;
            // 
            // zamknij
            // 
            zamknij.Location = new Point(83, 270);
            zamknij.Name = "zamknij";
            zamknij.Size = new Size(75, 23);
            zamknij.TabIndex = 6;
            zamknij.Text = "Zakończ";
            zamknij.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 331);
            Controls.Add(zamknij);
            Controls.Add(zarezerwuj);
            Controls.Add(terminy);
            Controls.Add(dodajKlienta);
            Controls.Add(klienci);
            Controls.Add(wolnePokoje);
            Controls.Add(pokoje);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button pokoje;
        private Button wolnePokoje;
        private Button klienci;
        private Button dodajKlienta;
        private Button terminy;
        private Button zarezerwuj;
        private Button zamknij;
    }
}