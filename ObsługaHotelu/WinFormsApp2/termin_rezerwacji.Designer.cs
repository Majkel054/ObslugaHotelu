namespace WinFormsApp2
{
    partial class termin_rezerwacji
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
            TerminRez = new Label();
            WybranyPokoj = new Label();
            Klient = new Label();
            KontaktKlient = new Label();
            SuspendLayout();
            // 
            // TerminRez
            // 
            TerminRez.BorderStyle = BorderStyle.FixedSingle;
            TerminRez.Location = new Point(43, 48);
            TerminRez.Name = "TerminRez";
            TerminRez.Size = new Size(105, 55);
            TerminRez.TabIndex = 0;
            TerminRez.Text = "Termin Rezerwacji";
            TerminRez.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WybranyPokoj
            // 
            WybranyPokoj.BorderStyle = BorderStyle.FixedSingle;
            WybranyPokoj.Location = new Point(216, 48);
            WybranyPokoj.Name = "WybranyPokoj";
            WybranyPokoj.Size = new Size(105, 55);
            WybranyPokoj.TabIndex = 1;
            WybranyPokoj.Text = "Wybrany Pokój";
            WybranyPokoj.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Klient
            // 
            Klient.BorderStyle = BorderStyle.FixedSingle;
            Klient.Location = new Point(398, 48);
            Klient.Name = "Klient";
            Klient.Size = new Size(105, 55);
            Klient.TabIndex = 2;
            Klient.Text = "Klient";
            Klient.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // KontaktKlient
            // 
            KontaktKlient.BorderStyle = BorderStyle.FixedSingle;
            KontaktKlient.Location = new Point(586, 48);
            KontaktKlient.Name = "KontaktKlient";
            KontaktKlient.Size = new Size(105, 55);
            KontaktKlient.TabIndex = 3;
            KontaktKlient.Text = "Kontakt do Klienta";
            KontaktKlient.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // termin_rezerwacji
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(KontaktKlient);
            Controls.Add(Klient);
            Controls.Add(WybranyPokoj);
            Controls.Add(TerminRez);
            Name = "termin_rezerwacji";
            Text = "termin_rezerwacji";
            ResumeLayout(false);
        }

        #endregion

        private Label TerminRez;
        private Label WybranyPokoj;
        private Label Klient;
        private Label KontaktKlient;
    }
}