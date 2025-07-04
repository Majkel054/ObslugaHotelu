using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // Dla Linq, np. do OrderBy, Count itp.
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Management_App.Models;
using Hotel_Management_App.Repositories;

namespace Hotel_Management_App.UI
{
    public partial class ReservationsControl : UserControl
    {
        private ReservationRepository _reservationRepository;
        private ClientRepository _clientRepository;
        private RoomRepository _roomRepository;

        public ReservationsControl()
        {
            InitializeComponent();
            _reservationRepository = new ReservationRepository();
            _clientRepository = new ClientRepository();
            _roomRepository = new RoomRepository();
            LoadReservations(); // Wczytaj rezerwacje przy starcie kontrolki
            UpdateButtonsState(); // Zaktualizuj stan przycisków
        }

        // Właściwość do łatwego dostępu do wybranej rezerwacji
        public Reservation? SelectedReservation
        {
            get
            {
                // Jeśli wybrany element jest typu DisplayReservationItem, zwróć jego właściwość Reservation
                if (listBoxReservations.SelectedItem is DisplayReservationItem displayItem)
                {
                    return displayItem.Reservation;
                }
                return null; // W przeciwnym razie zwróć null
            }
        }

        private void LoadReservations()
        {
            listBoxReservations.Items.Clear(); // Wyczyść ListBox
            var allReservations = _reservationRepository.GetAll(); // Pobierz wszystkie rezerwacje

            foreach (var res in allReservations)
            {
                var client = _clientRepository.Get(res.ClientId); // Pobierz klienta dla rezerwacji
                var room = _roomRepository.Get(res.RoomId);     // Pobierz pokój dla rezerwacji

                // Dodaj specjalny obiekt do ListBox, aby wyświetlał czytelne informacje
                listBoxReservations.Items.Add(new DisplayReservationItem(res, client, room));
            }
        }

        // Klasa pomocnicza (nested class) do formatowania wyświetlania rezerwacji w ListBox
        private class DisplayReservationItem
        {
            public Reservation Reservation { get; }
            public Client? Client { get; } // Może być null, jeśli klient został usunięty
            public Room? Room { get; }     // Może być null, jeśli pokój został usunięty

            public DisplayReservationItem(Reservation reservation, Client? client, Room? room)
            {
                Reservation = reservation;
                Client = client;
                Room = room;
            }

            public override string ToString()
            {
                // Tworzenie czytelnego ciągu tekstowego do wyświetlenia
                string clientName = Client != null ? $"{Client.Name} {Client.Surname}" : $"Klient ID: {Reservation.ClientId} (nieznany)";
                string roomInfo = Room != null ? $"Pokój {Room.Number} ({Room.Type})" : $"Pokój ID: {Reservation.RoomId} (nieznany)";
                return $"{clientName} - {roomInfo} od {Reservation.StartDate.ToShortDateString()} do {Reservation.EndDate.ToShortDateString()}";
            }
        }

        private void UpdateButtonsState()
        {
            // Przyciski "Edytuj" i "Usuń" są aktywne tylko, gdy jakaś rezerwacja jest wybrana
            bool enabled = SelectedReservation != null;
            buttonEdit.Enabled = enabled;
            buttonDelete.Enabled = enabled;
        }

        private void listBoxReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsState(); // Zaktualizuj stan przycisków po zmianie wyboru
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new ReservationEditForm()) // Otwórz formularz dodawania nowej rezerwacji
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadReservations(); // Odśwież listę po dodaniu
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (SelectedReservation == null) return; // Jeśli nic nie wybrano, zakończ

            using (var dlg = new ReservationEditForm(SelectedReservation)) // Otwórz formularz edycji dla wybranej rezerwacji
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadReservations(); // Odśwież listę po edycji
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (SelectedReservation == null) return; // Jeśli nic nie wybrano, zakończ

            var res = MessageBox.Show($"Czy na pewno usunąć rezerwację ID: {SelectedReservation.Id}?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                _reservationRepository.Delete(SelectedReservation.Id); // Usuń rezerwację z bazy
                LoadReservations(); // Odśwież listę
            }
            UpdateButtonsState(); // Zaktualizuj stan przycisków
        }
    }
}