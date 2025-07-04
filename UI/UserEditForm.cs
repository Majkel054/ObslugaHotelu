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
using Hotel_Management_App.Services;
using Hotel_Management_App.Repositories; // Potrzebne do UserRepository
using BCrypt.Net; // Potrzebne do hashowania hasła

namespace Hotel_Management_App.UI
{
    public partial class UserEditForm : Form
    {
        private User? _user; // Użytkownik do edycji (null, jeśli dodajemy nowego)
        private AuthService _authService;
        private UserRepository _userRepository;

        public UserEditForm()
        {
            InitializeComponent();
            _user = null; // Nowy użytkownik
            _authService = new AuthService();
            _userRepository = new UserRepository();
            this.Text = "Dodaj Nowego Użytkownika";
            PopulateRolesComboBox();
        }

        public UserEditForm(User user)
        {
            InitializeComponent();
            _user = user; // Edycja istniejącego użytkownika
            _authService = new AuthService();
            _userRepository = new UserRepository();
            this.Text = $"Edytuj Użytkownika: {user.Username}";

            // Wypełnienie pól formularza danymi użytkownika
            textBoxName.Text = _user.Name;
            textBoxSurname.Text = _user.Surname;
            textBoxUsername.Text = _user.Username;
            textBoxUsername.ReadOnly = true; // Nazwa użytkownika nie powinna być zmieniana przy edycji

            textBoxPassword.Text = ""; // Hasła nie wyświetlamy - zostawiamy puste do ewentualnej zmiany
            textBoxConfirmPassword.Text = "";

            PopulateRolesComboBox();
            // Ustawienie aktualnej roli użytkownika
            comboBoxRole.SelectedItem = _user.Role;
        }

        private void PopulateRolesComboBox()
        {
            comboBoxRole.Items.Add("User");
            comboBoxRole.Items.Add("Receptionist");
            comboBoxRole.Items.Add("Admin");

            if (comboBoxRole.Items.Count > 0)
            {
                comboBoxRole.SelectedIndex = 0; // Domyślnie wybierz pierwszą rolę
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string surname = textBoxSurname.Text.Trim();
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;
            string role = comboBoxRole.SelectedItem?.ToString() ?? "User";

            // Walidacja pól tekstowych
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Imię nie może być puste.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                MessageBox.Show("Nazwisko nie może być puste.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Nazwa użytkownika nie może być pusta.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Walidacja hasła (wymagane dla nowego użytkownika lub gdy podano nowe hasło do zmiany)
            if (_user == null || !string.IsNullOrEmpty(password))
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Hasło nie może być puste.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (password != confirmPassword)
                {
                    Show("Hasła nie pasują do siebie.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (password.Length < 6)
                {
                    MessageBox.Show("Hasło musi mieć co najmniej 6 znaków.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            if (_user == null) // Dodawanie nowego użytkownika
            {
                // Sprawdź, czy nazwa użytkownika jest unikalna
                if (_userRepository.GetByUsername(username) != null)
                {
                    MessageBox.Show("Użytkownik o takiej nazwie już istnieje.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Rejestruj nowego użytkownika za pomocą AuthService (który hashuje hasło)
                bool success = _authService.RegisterUser(username, password, name, surname, role);
                if (success)
                {
                    this.DialogResult = DialogResult.OK; // Ustaw wynik dialogu na OK
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas rejestracji użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Edycja istniejącego użytkownika
            {
                // Aktualizuj imię, nazwisko i rolę
                _user.Name = name;
                _user.Surname = surname;
                _user.Role = role;

                // Zmień hasło, jeśli podano nowe (AuthService załatwi hashowanie)
                if (!string.IsNullOrEmpty(password))
                {
                    _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
                }

                // Zapisz zaktualizowanego użytkownika w repozytorium
                _userRepository.Update(_user);

                this.DialogResult = DialogResult.OK; // Ustaw wynik dialogu na OK
                this.Close();
            }
        }

        private void Show(string v1, string v2, MessageBoxButtons oK, MessageBoxIcon error)
        {
            throw new NotImplementedException();
        }
    }
}