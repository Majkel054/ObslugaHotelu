namespace Hotel_Management_App.UI
{
    partial class ReservationEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.ComboBox comboBoxRoom;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
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
            this.labelClient = new System.Windows.Forms.Label();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.labelRoom = new System.Windows.Forms.Label();
            this.comboBoxRoom = new System.Windows.Forms.ComboBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.buttonSave = new System.Windows.Forms.Button();

            // labelClient
            this.labelClient.Text = "Klient:";
            this.labelClient.Location = new System.Drawing.Point(10, 15);
            this.labelClient.AutoSize = true;

            // comboBoxClient
            this.comboBoxClient.Location = new System.Drawing.Point(100, 10);
            this.comboBoxClient.Size = new System.Drawing.Size(200, 21);
            this.comboBoxClient.DropDownStyle = ComboBoxStyle.DropDownList;

            // labelRoom
            this.labelRoom.Text = "Pokój:";
            this.labelRoom.Location = new System.Drawing.Point(10, 45);
            this.labelRoom.AutoSize = true;

            // comboBoxRoom
            this.comboBoxRoom.Location = new System.Drawing.Point(100, 40);
            this.comboBoxRoom.Size = new System.Drawing.Size(200, 21);
            this.comboBoxRoom.DropDownStyle = ComboBoxStyle.DropDownList;

            // labelStartDate
            this.labelStartDate.Text = "Data od:";
            this.labelStartDate.Location = new System.Drawing.Point(10, 75);
            this.labelStartDate.AutoSize = true;

            // dateTimePickerStartDate
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(100, 70);
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDate.Format = DateTimePickerFormat.Short;
            this.dateTimePickerStartDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);


            // labelEndDate
            this.labelEndDate.Text = "Data do:";
            this.labelEndDate.Location = new System.Drawing.Point(10, 105);
            this.labelEndDate.AutoSize = true;

            // dateTimePickerEndDate
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(100, 100);
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDate.Format = DateTimePickerFormat.Short;
            this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);


            // buttonSave
            this.buttonSave.Text = "Zapisz";
            this.buttonSave.Location = new System.Drawing.Point(10, 140);
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // Dodaj kontrolki do formularza
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.labelRoom);
            this.Controls.Add(this.comboBoxRoom);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.buttonSave);

            this.ClientSize = new System.Drawing.Size(320, 180); // Dostosuj rozmiar formularza
            this.Text = "Edytuj Rezerwację";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AcceptButton = this.buttonSave;
            this.CancelButton = new Button { DialogResult = DialogResult.Cancel };
        }

        #endregion
    }
}