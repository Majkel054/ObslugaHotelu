namespace Hotel_Management_App.UI
{
    partial class RoomEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxPricePerNight; // Możesz użyć NumericUpDown dla lepszej walidacji
        private System.Windows.Forms.CheckBox checkBoxIsAvailable;
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
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxPricePerNight = new System.Windows.Forms.TextBox(); // Zmienimy na NumericUpDown
            this.checkBoxIsAvailable = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();

            // textBoxNumber
            this.textBoxNumber.PlaceholderText = "Numer pokoju";
            this.textBoxNumber.Location = new System.Drawing.Point(10, 10);
            this.textBoxNumber.Size = new System.Drawing.Size(200, 20);

            // comboBoxType
            this.comboBoxType.Location = new System.Drawing.Point(10, 40);
            this.comboBoxType.Size = new System.Drawing.Size(200, 21);
            this.comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList; // Upewnij się, że nie można wpisywać ręcznie
            this.comboBoxType.Items.AddRange(System.Enum.GetNames(typeof(Hotel_Management_App.Models.RoomType))); // Wypełnienie enumem

            // textBoxPricePerNight (zamiast tego polecam System.Windows.Forms.NumericUpDown)
            this.textBoxPricePerNight.PlaceholderText = "Cena za noc";
            this.textBoxPricePerNight.Location = new System.Drawing.Point(10, 70);
            this.textBoxPricePerNight.Size = new System.Drawing.Size(200, 20);
            // Możesz dodać walidację, aby akceptował tylko liczby.

            // checkBoxIsAvailable
            this.checkBoxIsAvailable.Text = "Dostępny";
            this.checkBoxIsAvailable.Location = new System.Drawing.Point(10, 100);
            this.checkBoxIsAvailable.AutoSize = true;

            // buttonSave
            this.buttonSave.Text = "Zapisz";
            this.buttonSave.Location = new System.Drawing.Point(10, 130);
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // Dodaj kontrolki do formularza
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxPricePerNight);
            this.Controls.Add(this.checkBoxIsAvailable);
            this.Controls.Add(this.buttonSave);

            this.ClientSize = new System.Drawing.Size(220, 170); // Dostosuj rozmiar formularza
            this.Text = "Edytuj Pokój";
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Brak możliwości zmiany rozmiaru
            this.StartPosition = FormStartPosition.CenterParent; // Pośrodku rodzica
            this.MaximizeBox = false; // Brak przycisku maksymalizacji
            this.MinimizeBox = false; // Brak przycisku minimalizacji
            this.AcceptButton = this.buttonSave; // Enter akceptuje
            this.CancelButton = new Button { DialogResult = DialogResult.Cancel }; // ESC anuluje
        }

        #endregion
    }
}