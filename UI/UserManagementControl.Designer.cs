namespace Hotel_Management_App.UI
{
    partial class UserManagementControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonEditUser;
        private System.Windows.Forms.Button buttonDeleteUser;

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
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonEditUser = new System.Windows.Forms.Button();
            this.buttonDeleteUser = new System.Windows.Forms.Button();

            // listBoxUsers
            this.listBoxUsers.Location = new System.Drawing.Point(10, 10);
            this.listBoxUsers.Size = new System.Drawing.Size(300, 200);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);

            // buttonAddUser
            this.buttonAddUser.Text = "Dodaj Użytkownika";
            this.buttonAddUser.Location = new System.Drawing.Point(320, 10);
            this.buttonAddUser.Size = new System.Drawing.Size(120, 23);
            this.buttonAddUser.TabIndex = 1;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);

            // buttonEditUser
            this.buttonEditUser.Text = "Edytuj Użytkownika";
            this.buttonEditUser.Location = new System.Drawing.Point(320, 40);
            this.buttonEditUser.Size = new System.Drawing.Size(120, 23);
            this.buttonEditUser.TabIndex = 2;
            this.buttonEditUser.Click += new System.EventHandler(this.buttonEditUser_Click);
            this.buttonEditUser.Enabled = false; // Domyślnie wyłączony

            // buttonDeleteUser
            this.buttonDeleteUser.Text = "Usuń Użytkownika";
            this.buttonDeleteUser.Location = new System.Drawing.Point(320, 70);
            this.buttonDeleteUser.Size = new System.Drawing.Size(120, 23);
            this.buttonDeleteUser.TabIndex = 3;
            this.buttonDeleteUser.Click += new System.EventHandler(this.buttonDeleteUser_Click);
            this.buttonDeleteUser.Enabled = false; // Domyślnie wyłączony

            // Dodaj kontrolki do UserControl
            this.Controls.Add(this.listBoxUsers);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.buttonEditUser);
            this.Controls.Add(this.buttonDeleteUser);

            this.Size = new System.Drawing.Size(450, 220); // Dostosuj rozmiar UserControl
        }

        #endregion
    }
}