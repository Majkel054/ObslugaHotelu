using System;
using System.Windows.Forms;
using Hotel_Management_App.Services; // Potrzebne do AuthService
using Hotel_Management_App.Models; // Potrzebne do User

namespace Hotel_Management_App.UI
{
    public partial class LoginForm : Form
    {
        private AuthService _authService; // Deklaracja niestatycznej instancji AuthService

        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService(); // Inicjalizacja instancji AuthService
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Użycie niestatycznej instancji _authService do uwierzytelniania
            User? user = _authService.Authenticate(usernameBox.Text, passwordBox.Text);
            if (user != null)
            {
                this.Hide(); // Ukryj formularz logowania
                // Utwórz i pokaż główny formularz aplikacji, przekazując zalogowanego użytkownika
                new MainForm(user).Show();
            }
            else
            {
                MessageBox.Show("Błędny login lub hasło", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}