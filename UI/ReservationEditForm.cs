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
using Hotel_Management_App.Repositories;

namespace Hotel_Management_App.UI
{
    public partial class ReservationEditForm : Form
    {
        private Reservation? _reservation;
        private ReservationRepository _reservationRepository;
        private ClientRepository _clientRepository;
        private RoomRepository _roomRepository;

        // Klasy pomocnicze do wyświetlania w ComboBox
        private class DisplayClientItem
        {
            public Client Client { get; }
            public DisplayClientItem(Client client) => Client = client;
            public override string ToString() => $"{Client.Name} {Client.Surname} (ID: {Client.Id})";
        }

        private class DisplayRoomItem
        {
            public Room Room { get; }
            public DisplayRoomItem(Room room) => Room = room;
            public override string ToString() => $"Nr: {Room.Number}, Typ: {Room.Type}, Cena: {Room.PricePerNight:C}";
        }


        public ReservationEditForm()
        {
            InitializeComponent();
            _reservation = new Reservation();
            _reservationRepository = new ReservationRepository();
            _clientRepository = new ClientRepository();
            _roomRepository = new RoomRepository();

            LoadClients();
            // LoadRooms() będzie wywoływane po zmianie dat, na razie załaduj wszystkie
            LoadRooms(null, null); // Ładujemy wszystkie pokoje na początek
            dateTimePickerStartDate.Value = DateTime.Today;
            dateTimePickerEndDate.Value = DateTime.Today.AddDays(1);
        }

        public ReservationEditForm(Reservation reservation)
        {
            InitializeComponent();
            _reservation = reservation;
            _reservationRepository = new ReservationRepository();
            _clientRepository = new ClientRepository();
            _roomRepository = new RoomRepository();

            LoadClients();
            LoadRooms(null, null); // Na początku załaduj wszystkie pokoje, potem będziemy filtrować

            // Wypełnienie pól formularza danymi z obiektu Reservation
            dateTimePickerStartDate.Value = _reservation.StartDate;
            dateTimePickerEndDate.Value = _reservation.EndDate;

            // Ustawienie wybranego klienta
            var selectedClientItem = comboBoxClient.Items.OfType<DisplayClientItem>()
                                     .FirstOrDefault(item => item.Client.Id == _reservation.ClientId);
            if (selectedClientItem != null)
            {
                comboBoxClient.SelectedItem = selectedClientItem;
            }

            // Ustawienie wybranego pokoju
            var selectedRoomItem = comboBoxRoom.Items.OfType<DisplayRoomItem>()
                                   .FirstOrDefault(item => item.Room.Id == _reservation.RoomId);
            if (selectedRoomItem != null)
            {
                comboBoxRoom.SelectedItem = selectedRoomItem;
            }
        }

        private void LoadClients()
        {
            comboBoxClient.Items.Clear();
            var clients = _clientRepository.GetAll();
            foreach (var client in clients)
            {
                comboBoxClient.Items.Add(new DisplayClientItem(client));
            }
            if (comboBoxClient.Items.Count > 0)
            {
                comboBoxClient.SelectedIndex = 0;
            }
        }

        private void LoadRooms(DateTime? startDate, DateTime? endDate)
        {
            comboBoxRoom.Items.Clear();
            var rooms = _roomRepository.GetAll();

            // Jeśli daty są podane, filtruj pokoje, aby pokazać tylko dostępne
            if (startDate.HasValue && endDate.HasValue && startDate.Value <= endDate.Value)
            {
                var availableRooms = new List<Room>();
                foreach (var room in rooms)
                {
                    if (IsRoomAvailable(room.Id, startDate.Value, endDate.Value, _reservation?.Id))
                    {
                        availableRooms.Add(room);
                    }
                }
                rooms = availableRooms; // Użyj przefiltrowanej listy
            }

            foreach (var room in rooms)
            {
                comboBoxRoom.Items.Add(new DisplayRoomItem(room));
            }

            if (comboBoxRoom.Items.Count > 0)
            {
                comboBoxRoom.SelectedIndex = 0;
            }
        }


        private bool IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate, int? currentReservationId = null)
        {
            // Sprawdza, czy są jakieś rezerwacje dla danego pokoju, które kolidują z podanym terminem
            var conflictingReservations = _reservationRepository.GetConflictingReservations(roomId, startDate, endDate, currentReservationId);
            return !conflictingReservations.Any();
        }


        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Zmieniamy daty, więc próbujemy ponownie załadować dostępne pokoje
            if (dateTimePickerStartDate.Value > dateTimePickerEndDate.Value)
            {
                // Automatycznie ustaw endDate na startDate, jeśli startDate jest późniejsza
                dateTimePickerEndDate.Value = dateTimePickerStartDate.Value;
            }
            LoadRooms(dateTimePickerStartDate.Value, dateTimePickerEndDate.Value);
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxClient.SelectedItem == null)
            {
                MessageBox.Show("Wybierz klienta.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxRoom.SelectedItem == null)
            {
                MessageBox.Show("Wybierz pokój.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePickerStartDate.Value > dateTimePickerEndDate.Value)
            {
                MessageBox.Show("Data rozpoczęcia nie może być późniejsza niż data zakończenia.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sprawdzamy dostępność pokoju jeszcze raz przed zapisem
            var selectedRoom = (comboBoxRoom.SelectedItem as DisplayRoomItem)?.Room;
            if (selectedRoom == null) return; // Powinno być obsłużone przez walidację powyżej

            if (!IsRoomAvailable(selectedRoom.Id, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, _reservation?.Id))
            {
                MessageBox.Show("Wybrany pokój jest niedostępny w podanym terminie.", "Błąd dostępności", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _reservation.ClientId = (comboBoxClient.SelectedItem as DisplayClientItem).Client.Id;
            _reservation.RoomId = (comboBoxRoom.SelectedItem as DisplayRoomItem).Room.Id;
            _reservation.StartDate = dateTimePickerStartDate.Value.Date; // Tylko data, bez czasu
            _reservation.EndDate = dateTimePickerEndDate.Value.Date; // Tylko data, bez czasu

            if (_reservation.Id == 0) // Dodawanie nowego
            {
                _reservationRepository.Add(_reservation);
            }
            else // Edycja istniejącego
            {
                _reservationRepository.Update(_reservation);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}