using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Management_App.Models;
using Microsoft.Data.Sqlite;

namespace Hotel_Management_App.UI
{
    public partial class ClientsControl : UserControl
    {
        public ClientsControl()
        {
            InitializeComponent();
            LoadClients();
            listBoxClients.SelectedIndexChanged += (_, _) => UpdateButtonsState();
            UpdateButtonsState();
        }

        private Client? SelectedClient => listBoxClients.SelectedItem as Client;

        private void LoadClients()
        {
            listBoxClients.Items.Clear();
            using var conn = new SqliteConnection("Data Source=hotel.db");
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Name, Surname, Phone, Email FROM Clients";
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                listBoxClients.Items.Add(new Client
                {
                    Id = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Surname = rdr.GetString(2),
                    Phone = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                    Email = rdr.IsDBNull(4) ? null : rdr.GetString(4)
                });
            }
        }

        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            var dlg = new ClientEditForm();
            if (dlg.ShowDialog() == DialogResult.OK) LoadClients();
        }

        private void buttonEdit_Click(object? sender, EventArgs e)
        {
            if (SelectedClient == null) return;
            var dlg = new ClientEditForm(SelectedClient);
            if (dlg.ShowDialog() == DialogResult.OK) LoadClients();
        }

        private void buttonDelete_Click(object? sender, EventArgs e)
        {
            if (SelectedClient == null) return;
            var res = MessageBox.Show($"Usuń klienta {SelectedClient}?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes) return;
            using var conn = new SqliteConnection("Data Source=hotel.db");
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Clients WHERE Id=@id";
            cmd.Parameters.AddWithValue("@id", SelectedClient.Id);
            cmd.ExecuteNonQuery();
            LoadClients();
        }

        private void UpdateButtonsState()
        {
            var enabled = SelectedClient != null;
            buttonEdit.Enabled = enabled;
            buttonDelete.Enabled = enabled;
        }
    }
}
