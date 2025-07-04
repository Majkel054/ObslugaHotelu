namespace Hotel_Management_App.UI
{
    partial class ClientEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Deklaracje kontrolek
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonSave;

        // Dodatkowe etykiety (Labels) dla czytelności formularza
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelEmail;


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
            // Inicjalizacja kontrolek
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();

            // Inicjalizacja etykiet
            this.labelName = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();


            // Ustawienia dla labelName
            this.labelName.Text = "Imię:";
            this.labelName.Location = new System.Drawing.Point(10, 15);
            this.labelName.AutoSize = true;

            // Ustawienia dla textBoxName
            this.textBoxName.Location = new System.Drawing.Point(100, 10);
            this.textBoxName.Size = new System.Drawing.Size(200, 20);
            this.textBoxName.TabIndex = 0; // Ustawienie kolejności tabulacji

            // Ustawienia dla labelSurname
            this.labelSurname.Text = "Nazwisko:";
            this.labelSurname.Location = new System.Drawing.Point(10, 45);
            this.labelSurname.AutoSize = true;

            // Ustawienia dla textBoxSurname
            this.textBoxSurname.Location = new System.Drawing.Point(100, 40);
            this.textBoxSurname.Size = new System.Drawing.Size(200, 20);
            this.textBoxSurname.TabIndex = 1;

            // Ustawienia dla labelPhone
            this.labelPhone.Text = "Telefon:";
            this.labelPhone.Location = new System.Drawing.Point(10, 75);
            this.labelPhone.AutoSize = true;

            // Ustawienia dla textBoxPhone
            this.textBoxPhone.Location = new System.Drawing.Point(100, 70);
            this.textBoxPhone.Size = new System.Drawing.Size(200, 20);
            this.textBoxPhone.TabIndex = 2;

            // Ustawienia dla labelEmail
            this.labelEmail.Text = "Email:";
            this.labelEmail.Location = new System.Drawing.Point(10, 105);
            this.labelEmail.AutoSize = true;

            // Ustawienia dla textBoxEmail
            this.textBoxEmail.Location = new System.Drawing.Point(100, 100);
            this.textBoxEmail.Size = new System.Drawing.Size(200, 20);
            this.textBoxEmail.TabIndex = 3;

            // Ustawienia dla buttonSave
            this.buttonSave.Text = "Zapisz";
            this.buttonSave.Location = new System.Drawing.Point(10, 140);
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // Dodaj wszystkie kontrolki do formularza
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.buttonSave);

            // Ustawienia formularza
            this.ClientSize = new System.Drawing.Size(320, 180); // Rozmiar formularza
            this.Text = "Edytuj Klienta";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Brak możliwości zmiany rozmiaru
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; // Wyśrodkowanie względem rodzica
            this.MaximizeBox = false; // Brak przycisku maksymalizacji
            this.MinimizeBox = false; // Brak przycisku minimalizacji
            this.AcceptButton = this.buttonSave; // Enter klika Zapisz
        }

        #endregion
    }
}