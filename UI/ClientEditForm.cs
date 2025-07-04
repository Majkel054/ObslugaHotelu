using System;
using System.Windows.Forms;
using Hotel_Management_App.Models;
using Hotel_Management_App.Repositories; // Potrzebne dla ClientRepository

namespace Hotel_Management_App.UI
{
    public partial class ClientEditForm : Form
    {
        private Client? _client; // Klient do edycji (null, jeśli dodajemy nowego)
        private ClientRepository _clientRepository; // Repozytorium do zapisu/odczytu klientów

        public ClientEditForm()
        {
            InitializeComponent();
            _client = null; // Oznacza, że dodajemy nowego klienta
            _clientRepository = new ClientRepository();
            this.Text = "Dodaj Nowego Klienta"; // Zmiana tytułu formularza
        }

        public ClientEditForm(Client selectedClient)
        {
            InitializeComponent();
            _client = selectedClient; // Oznacza, że edytujemy istniejącego klienta
            _clientRepository = new ClientRepository();
            this.Text = $"Edytuj Klienta: {_client.Name} {_client.Surname}"; // Zmiana tytułu formularza

            // Wypełnienie pól formularza danymi wybranego klienta
            textBoxName.Text = _client.Name;
            textBoxSurname.Text = _client.Surname;
            textBoxPhone.Text = _client.Phone;
            textBoxEmail.Text = _client.Email;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Pobierz dane z pól tekstowych
            string name = textBoxName.Text.Trim();
            string surname = textBoxSurname.Text.Trim();
            string phone = textBoxPhone.Text.Trim(); // Możliwe, że jest puste
            string email = textBoxEmail.Text.Trim(); // Możliwe, że jest puste

            // Prosta walidacja (imię i nazwisko są obowiązkowe)
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Imię klienta nie może być puste.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                MessageBox.Show("Nazwisko klienta nie może być puste.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_client == null) // Dodawanie nowego klienta
            {
                _client = new Client
                {
                    Name = name,
                    Surname = surname,
                    Phone = string.IsNullOrEmpty(phone) ? null : phone, // Zapisz jako null, jeśli puste
                    Email = string.IsNullOrEmpty(email) ? null : email  // Zapisz jako null, jeśli puste
                };
                _clientRepository.Add(_client); // Dodaj do repozytorium
            }
            else // Edycja istniejącego klienta
            {
                _client.Name = name;
                _client.Surname = surname;
                _client.Phone = string.IsNullOrEmpty(phone) ? null : phone;
                _client.Email = string.IsNullOrEmpty(email) ? null : email;
                _clientRepository.Update(_client); // Zaktualizuj w repozytorium
            }

            this.DialogResult = DialogResult.OK; // Ustaw wynik dialogu na OK
            this.Close(); // Zamknij formularz
        }
    }
}