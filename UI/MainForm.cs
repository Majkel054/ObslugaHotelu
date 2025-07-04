using System;
using System.Windows.Forms;
using Hotel_Management_App.Models; // Potrzebne do User

namespace Hotel_Management_App.UI
{
    public partial class MainForm : Form
    {
        private readonly User _loggedInUser; // Przechowujemy referencję do zalogowanego użytkownika

        public MainForm(User loggedInUser) // Konstruktor przyjmujący zalogowanego użytkownika
        {
            _loggedInUser = loggedInUser;
            InitializeComponent();
            // Ustaw tekst paska tytułu formularza, aby pokazać zalogowanego użytkownika i jego rolę
            this.Text = $"Hotel Manager - Zalogowany jako: {_loggedInUser.Username} ({_loggedInUser.Role})";

            // Dodaj logikę ukrywania/pokazywania zakładek (tab pages)
            // w zależności od roli użytkownika (_loggedInUser.Role).
            // zakładka zarządzania użytkownikami (`tabUserManagement`) powinna być dostępna tylko dla Admina.
            if (_loggedInUser.Role != "Admin")
            {
                // Znajdź zakładkę zarządzania użytkownikami po nazwie i usuń ją
                foreach (TabPage tab in tabControlMain.TabPages)
                {
                    if (tab.Name == "tabUserManagement") // Upewnij się, że tak nazywa się Twoja zakładka
                    {
                        tabControlMain.TabPages.Remove(tab);
                        break;
                    }
                }
            }
            // Możesz dodać podobną logikę dla innych ról i zakładek
            // np. dla Recepcjonisty dostęp do zarządzania rezerwacjami i pokojami
        }
    }
}