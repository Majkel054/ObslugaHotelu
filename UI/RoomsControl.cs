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
using Hotel_Management_App.Repositories; // Dodaj to using

namespace Hotel_Management_App.UI
{
    public partial class RoomsControl : UserControl
    {
        private RoomRepository _roomRepository; // Deklaracja repozytorium

        public RoomsControl()
        {
            InitializeComponent();
            _roomRepository = new RoomRepository(); // Inicjalizacja repozytorium
            LoadRooms();
            UpdateButtonsState();
        }

        public Room? SelectedRoom => listBoxRooms.SelectedItem as Room;

        private void LoadRooms()
        {
            listBoxRooms.Items.Clear();
            var rooms = _roomRepository.GetAll(); // Użyj repozytorium
            foreach (var room in rooms)
            {
                listBoxRooms.Items.Add(room);
            }
        }

        private void UpdateButtonsState()
        {
            bool enabled = SelectedRoom != null;
            buttonEdit.Enabled = enabled;
            buttonDelete.Enabled = enabled;
        }

        private void listBoxRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new RoomEditForm())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (SelectedRoom == null) return;

            using (var dlg = new RoomEditForm(SelectedRoom))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (SelectedRoom == null) return;

            var res = MessageBox.Show($"Czy na pewno usunąć pokój {SelectedRoom}?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                _roomRepository.Delete(SelectedRoom.Id); // Użyj repozytorium
                LoadRooms();
            }
            UpdateButtonsState();
        }
    }
}