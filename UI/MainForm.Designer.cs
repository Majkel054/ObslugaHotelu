namespace Hotel_Management_App.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.TabPage tabRooms;
        private System.Windows.Forms.TabPage tabReservations;
        private System.Windows.Forms.TabPage tabUserManagement; // Dodano zakładkę dla zarządzania użytkownikami

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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabClients = new System.Windows.Forms.TabPage();
            this.tabRooms = new System.Windows.Forms.TabPage();
            this.tabReservations = new System.Windows.Forms.TabPage();
            this.tabUserManagement = new System.Windows.Forms.TabPage(); // Inicjalizacja nowej zakładki

            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();

            // tabControlMain
            this.tabControlMain.Controls.Add(this.tabClients);
            this.tabControlMain.Controls.Add(this.tabRooms);
            this.tabControlMain.Controls.Add(this.tabReservations);
            this.tabControlMain.Controls.Add(this.tabUserManagement); // Dodaj nową zakładkę
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(800, 450); // Dostosuj rozmiar
            this.tabControlMain.TabIndex = 0;

            // tabClients
            this.tabClients.Controls.Add(new ClientsControl()); // Dodaj instancję ClientsControl
            this.tabClients.Location = new System.Drawing.Point(4, 22);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabClients.Size = new System.Drawing.Size(792, 424); // Dostosuj rozmiar
            this.tabClients.TabIndex = 0;
            this.tabClients.Text = "Klienci";
            this.tabClients.UseVisualStyleBackColor = true;

            // tabRooms
            this.tabRooms.Controls.Add(new RoomsControl()); // Dodaj instancję RoomsControl
            this.tabRooms.Location = new System.Drawing.Point(4, 22);
            this.tabRooms.Name = "tabRooms";
            this.tabRooms.Padding = new System.Windows.Forms.Padding(3);
            this.tabRooms.Size = new System.Drawing.Size(792, 424); // Dostosuj rozmiar
            this.tabRooms.TabIndex = 1;
            this.tabRooms.Text = "Pokoje";
            this.tabRooms.UseVisualStyleBackColor = true;

            // tabReservations
            this.tabReservations.Controls.Add(new ReservationsControl()); // Dodaj instancję ReservationsControl
            this.tabReservations.Location = new System.Drawing.Point(4, 22);
            this.tabReservations.Name = "tabReservations";
            this.tabReservations.Padding = new System.Windows.Forms.Padding(3);
            this.tabReservations.Size = new System.Drawing.Size(792, 424); // Dostosuj rozmiar
            this.tabReservations.TabIndex = 2;
            this.tabReservations.Text = "Rezerwacje";
            this.tabReservations.UseVisualStyleBackColor = true;

            // tabUserManagement (nowa zakładka)
            this.tabUserManagement.Controls.Add(new UserManagementControl()); // Dodaj instancję UserManagementControl
            this.tabUserManagement.Location = new System.Drawing.Point(4, 22);
            this.tabUserManagement.Name = "tabUserManagement";
            this.tabUserManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserManagement.Size = new System.Drawing.Size(792, 424); // Dostosuj rozmiar
            this.tabUserManagement.TabIndex = 3;
            this.tabUserManagement.Text = "Zarządzanie Użytkownikami";
            this.tabUserManagement.UseVisualStyleBackColor = true;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450); // Dostosuj rozmiar
            this.Controls.Add(this.tabControlMain);
            this.Name = "MainForm";
            this.Text = "Hotel Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized; // Otwórz zmaksymalizowane
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}