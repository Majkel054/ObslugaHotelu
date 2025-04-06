
namespace ObsługaHotelu
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
            this.pokoje = new System.Windows.Forms.Button();
            this.wolnePokoje = new System.Windows.Forms.Button();
            this.klienci = new System.Windows.Forms.Button();
            this.dodajKlienta = new System.Windows.Forms.Button();
            this.terminRezerwacji = new System.Windows.Forms.Button();
            this.zarezerwuj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pokoje
            // 
            this.pokoje.Location = new System.Drawing.Point(348, 62);
            this.pokoje.Name = "pokoje";
            this.pokoje.Size = new System.Drawing.Size(90, 38);
            this.pokoje.TabIndex = 0;
            this.pokoje.Text = "Pokoje";
            this.pokoje.UseVisualStyleBackColor = true;
            this.pokoje.Click += new System.EventHandler(this.pokoje_Click);
            // 
            // wolnePokoje
            // 
            this.wolnePokoje.Location = new System.Drawing.Point(348, 115);
            this.wolnePokoje.Name = "wolnePokoje";
            this.wolnePokoje.Size = new System.Drawing.Size(90, 32);
            this.wolnePokoje.TabIndex = 1;
            this.wolnePokoje.Text = "Wolne Pokoje";
            this.wolnePokoje.UseVisualStyleBackColor = true;
            this.wolnePokoje.Click += new System.EventHandler(this.wolnePokoje_Click);
            // 
            // klienci
            // 
            this.klienci.Location = new System.Drawing.Point(348, 167);
            this.klienci.Name = "klienci";
            this.klienci.Size = new System.Drawing.Size(90, 30);
            this.klienci.TabIndex = 2;
            this.klienci.Text = "Klienci";
            this.klienci.UseVisualStyleBackColor = true;
            this.klienci.Click += new System.EventHandler(this.klienci_Click);
            // 
            // dodajKlienta
            // 
            this.dodajKlienta.Location = new System.Drawing.Point(348, 217);
            this.dodajKlienta.Name = "dodajKlienta";
            this.dodajKlienta.Size = new System.Drawing.Size(93, 36);
            this.dodajKlienta.TabIndex = 3;
            this.dodajKlienta.Text = "Dodaj Klienta";
            this.dodajKlienta.UseVisualStyleBackColor = true;
            this.dodajKlienta.Click += new System.EventHandler(this.dodajKlienta_Click);
            // 
            // terminRezerwacji
            // 
            this.terminRezerwacji.Location = new System.Drawing.Point(348, 271);
            this.terminRezerwacji.Name = "terminRezerwacji";
            this.terminRezerwacji.Size = new System.Drawing.Size(90, 41);
            this.terminRezerwacji.TabIndex = 4;
            this.terminRezerwacji.Text = "Termin Rezerwacji";
            this.terminRezerwacji.UseVisualStyleBackColor = true;
            this.terminRezerwacji.Click += new System.EventHandler(this.terminRezerwacji_Click);
            // 
            // zarezerwuj
            // 
            this.zarezerwuj.Location = new System.Drawing.Point(348, 332);
            this.zarezerwuj.Name = "zarezerwuj";
            this.zarezerwuj.Size = new System.Drawing.Size(90, 33);
            this.zarezerwuj.TabIndex = 5;
            this.zarezerwuj.Text = "Zarezerwuj";
            this.zarezerwuj.UseVisualStyleBackColor = true;
            this.zarezerwuj.Click += new System.EventHandler(this.zarezerwuj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 460);
            this.Controls.Add(this.zarezerwuj);
            this.Controls.Add(this.terminRezerwacji);
            this.Controls.Add(this.dodajKlienta);
            this.Controls.Add(this.klienci);
            this.Controls.Add(this.wolnePokoje);
            this.Controls.Add(this.pokoje);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pokoje;
        private System.Windows.Forms.Button wolnePokoje;
        private System.Windows.Forms.Button klienci;
        private System.Windows.Forms.Button dodajKlienta;
        private System.Windows.Forms.Button terminRezerwacji;
        private System.Windows.Forms.Button zarezerwuj;
    }
}

