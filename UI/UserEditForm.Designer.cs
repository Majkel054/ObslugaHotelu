namespace Hotel_Management_App.UI
{
    partial class UserEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Deklaracje nowych kontrolek dla Imienia i Nazwiska
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.TextBox textBoxSurname;

        // Istniejące deklaracje kontrolek
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Button buttonSave;

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
            // Inicjalizacja nowych kontrolek
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelSurname = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();

            // Inicjalizacja istniejących kontrolek
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();

            // Ustawienia dla labelName
            this.labelName.Text = "Imię:";
            this.labelName.Location = new System.Drawing.Point(10, 15);
            this.labelName.AutoSize = true;

            // Ustawienia dla textBoxName
            this.textBoxName.Location = new System.Drawing.Point(140, 10);
            this.textBoxName.Size = new System.Drawing.Size(150, 20);

            // Ustawienia dla labelSurname
            this.labelSurname.Text = "Nazwisko:";
            this.labelSurname.Location = new System.Drawing.Point(10, 45);
            this.labelSurname.AutoSize = true;

            // Ustawienia dla textBoxSurname
            this.textBoxSurname.Location = new System.Drawing.Point(140, 40);
            this.textBoxSurname.Size = new System.Drawing.Size(150, 20);

            // Ustawienia dla labelUsername (przesunięte w dół)
            this.labelUsername.Text = "Nazwa użytkownika:";
            this.labelUsername.Location = new System.Drawing.Point(10, 75);
            this.labelUsername.AutoSize = true;

            // Ustawienia dla textBoxUsername (przesunięte w dół)
            this.textBoxUsername.Location = new System.Drawing.Point(140, 70);
            this.textBoxUsername.Size = new System.Drawing.Size(150, 20);

            // Ustawienia dla labelPassword (przesunięte w dół)
            this.labelPassword.Text = "Hasło:";
            this.labelPassword.Location = new System.Drawing.Point(10, 105);
            this.labelPassword.AutoSize = true;

            // Ustawienia dla textBoxPassword (przesunięte w dół)
            this.textBoxPassword.Location = new System.Drawing.Point(140, 100);
            this.textBoxPassword.Size = new System.Drawing.Size(150, 20);
            this.textBoxPassword.UseSystemPasswordChar = true; // Ukrywa hasło

            // Ustawienia dla labelConfirmPassword (przesunięte w dół)
            this.labelConfirmPassword.Text = "Potwierdź hasło:";
            this.labelConfirmPassword.Location = new System.Drawing.Point(10, 135);
            this.labelConfirmPassword.AutoSize = true;

            // Ustawienia dla textBoxConfirmPassword (przesunięte w dół)
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(140, 130);
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(150, 20);
            this.textBoxConfirmPassword.UseSystemPasswordChar = true; // Ukrywa hasło

            // Ustawienia dla labelRole (przesunięte w dół)
            this.labelRole.Text = "Rola:";
            this.labelRole.Location = new System.Drawing.Point(10, 165);
            this.labelRole.AutoSize = true;

            // Ustawienia dla comboBoxRole (przesunięte w dół)
            this.comboBoxRole.Location = new System.Drawing.Point(140, 160);
            this.comboBoxRole.Size = new System.Drawing.Size(150, 21);
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // Zapobiega edycji tekstu

            // Ustawienia dla buttonSave (przesunięte w dół)
            this.buttonSave.Text = "Zapisz";
            this.buttonSave.Location = new System.Drawing.Point(10, 200);
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // Dodaj wszystkie kontrolki do formularza
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.buttonSave);

            // Ustawienia formularza
            this.ClientSize = new System.Drawing.Size(310, 240); // Zwiększona wysokość
            this.Text = "Edytuj Użytkownika";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Brak możliwości zmiany rozmiaru
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; // Wyśrodkowanie względem rodzica
            this.MaximizeBox = false; // Brak przycisku maksymalizacji
            this.MinimizeBox = false; // Brak przycisku minimalizacji
            this.AcceptButton = this.buttonSave; // Enter klika Zapisz
            // Poniższa linia dodaje niewidzialny przycisk "Anuluj" dla klawisza ESC
            this.CancelButton = new System.Windows.Forms.Button { DialogResult = System.Windows.Forms.DialogResult.Cancel };
        }

        #endregion
    }
}