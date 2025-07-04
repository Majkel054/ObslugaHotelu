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
    public partial class RoomEditForm : Form
    {
        private Room? _room;
        private RoomRepository _roomRepository; // Deklaracja repozytorium

        public RoomEditForm()
        {
            InitializeComponent();
            _room = new Room();
            _roomRepository = new RoomRepository(); // Inicjalizacja repozytorium
            textBoxNumber.Text = string.Empty;
            comboBoxType.SelectedIndex = 0;
            textBoxPricePerNight.Text = "0.00";
            checkBoxIsAvailable.Checked = true;
        }

        public RoomEditForm(Room room)
        {
            InitializeComponent();
            _room = room;
            _roomRepository = new RoomRepository(); // Inicjalizacja repozytorium

            textBoxNumber.Text = _room.Number;
            comboBoxType.SelectedItem = _room.Type.ToString();
            textBoxPricePerNight.Text = _room.PricePerNight.ToString();
            checkBoxIsAvailable.Checked = _room.IsAvailable;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNumber.Text))
            {
                MessageBox.Show("Numer pokoju nie może być pusty.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(textBoxPricePerNight.Text, out decimal pricePerNight))
            {
                MessageBox.Show("Cena za noc musi być liczbą.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxType.SelectedItem == null)
            {
                MessageBox.Show("Wybierz typ pokoju.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _room.Number = textBoxNumber.Text;
            _room.Type = (RoomType)Enum.Parse(typeof(RoomType), comboBoxType.SelectedItem.ToString());
            _room.PricePerNight = pricePerNight;
            _room.IsAvailable = checkBoxIsAvailable.Checked;

            if (_room.Id == 0)
            {
                _roomRepository.Add(_room); // Użyj repozytorium
            }
            else
            {
                _roomRepository.Update(_room); // Użyj repozytorium
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}