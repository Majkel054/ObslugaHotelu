namespace Hotel_Management_App.UI
{
    partial class ReservationsControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Deklaracje kontrolek używanych w tym UserControl
        private System.Windows.Forms.ListBox listBoxReservations;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Inicjalizacja kontrolek
            this.listBoxReservations = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();

            // Ustawienia dla listBoxReservations
            this.listBoxReservations.Location = new System.Drawing.Point(10, 10);
            this.listBoxReservations.Size = new System.Drawing.Size(400, 200);
            this.listBoxReservations.TabIndex = 0;
            this.listBoxReservations.SelectedIndexChanged += new System.EventHandler(this.listBoxReservations_SelectedIndexChanged);

            // Ustawienia dla buttonAdd
            this.buttonAdd.Text = "Dodaj";
            this.buttonAdd.Location = new System.Drawing.Point(420, 10);
            this.buttonAdd.Size = new System.Drawing.Size(80, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            // Ustawienia dla buttonEdit
            this.buttonEdit.Text = "Edytuj";
            this.buttonEdit.Location = new System.Drawing.Point(420, 40);
            this.buttonEdit.Size = new System.Drawing.Size(80, 23);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            this.buttonEdit.Enabled = false; // Domyślnie wyłączony, dopóki coś nie zostanie wybrane

            // Ustawienia dla buttonDelete
            this.buttonDelete.Text = "Usuń";
            this.buttonDelete.Location = new System.Drawing.Point(420, 70);
            this.buttonDelete.Size = new System.Drawing.Size(80, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            this.buttonDelete.Enabled = false; // Domyślnie wyłączony, dopóki coś nie zostanie wybrane

            // Dodaj wszystkie kontrolki do tego UserControl
            this.Controls.Add(this.listBoxReservations);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Size = new System.Drawing.Size(520, 220); // Ustaw domyślny rozmiar kontrolki
        }

        #endregion
    }
}