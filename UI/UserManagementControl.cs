using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // Dla metody .Count()
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Management_App.Models;
using Hotel_Management_App.Repositories;
using Hotel_Management_App.Services; // Potrzebne dla AuthService

namespace Hotel_Management_App.UI
{
    public partial class UserManagementControl : UserControl
    {
        private UserRepository _userRepository;
        private AuthService _authService; // Potrzebne do operacji, np. dodawania użytkowników

        public UserManagementControl()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            _authService = new AuthService();
            LoadUsers(); // Wczytaj użytkowników przy starcie kontrolki
            UpdateButtonsState(); // Zaktualizuj stan przycisków
        }

        // Właściwość do łatwego dostępu do wybranego użytkownika
        public User? SelectedUser => listBoxUsers.SelectedItem as User;

        private void LoadUsers()
        {
            listBoxUsers.Items.Clear();
            var users = _userRepository.GetAll();
            foreach (var user in users)
            {
                // Do ListBox dodajemy cały obiekt User. Metoda ToString() klasy User będzie wyświetlana.
                listBoxUsers.Items.Add(user);
            }
        }

        private void UpdateButtonsState()
        {
            // Przyciski "Edytuj" i "Usuń" są aktywne tylko, gdy jakiś użytkownik jest wybrany
            bool enabled = SelectedUser != null;
            buttonEditUser.Enabled = enabled;
            buttonDeleteUser.Enabled = enabled;
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsState(); // Zaktualizuj stan przycisków po zmianie wyboru
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            using (var dlg = new UserEditForm()) // Otwórz formularz dodawania nowego użytkownika
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers(); // Odśwież listę po dodaniu
                }
            }
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            if (SelectedUser == null) return; // Jeśli nic nie wybrano, zakończ

            using (var dlg = new UserEditForm(SelectedUser)) // Otwórz formularz edycji dla wybranego użytkownika
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers(); // Odśwież listę po edycji
                }
            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            if (SelectedUser == null) return; // Jeśli nic nie wybrano, zakończ

            // Dodatkowa logika: Nie pozwalaj na usunięcie ostatniego administratora
            var allUsers = _userRepository.GetAll();
            if (allUsers.Count(u => u.Role == "Admin") == 1 && SelectedUser.Role == "Admin")
            {
                MessageBox.Show("Nie można usunąć ostatniego administratora systemu.", "Błąd operacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var res = MessageBox.Show($"Czy na pewno usunąć użytkownika: {SelectedUser.Username} ({SelectedUser.Name} {SelectedUser.Surname})?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                _userRepository.Delete(SelectedUser.Id); // Usuń użytkownika z bazy
                LoadUsers(); // Odśwież listę
            }
            UpdateButtonsState(); // Zaktualizuj stan przycisków
        }
    }
}