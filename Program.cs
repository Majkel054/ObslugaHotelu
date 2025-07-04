using System;
using System.Windows.Forms;
using Hotel_Management_App.Repositories; // Potrzebne do Database i UserRepository
using Hotel_Management_App.Services; // Potrzebne do AuthService
using Hotel_Management_App.UI; // DODAJ TEN USING DLA LoginForm

namespace Hotel_Management_App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicjalizacja bazy danych (tworzy tabele, je�li nie istniej�)
            Database.Initialize();

            // Sprawd�, czy istnieje u�ytkownik 'admin'. Je�li nie, utw�rz go.
            // WA�NE: Ten blok kodu jest przeznaczony do wykonanie tylko raz, przy pierwszym uruchomieniu aplikacji.
            // Po utworzeniu domy�lnego admina, najlepiej ZAKOMENTUJ PONI�SZY BLOK KODU,
            // aby unikn�� pr�b ponownego tworzenia u�ytkownika przy ka�dym uruchomieniu.
            var authService = new AuthService(); // Tworzymy instancj� AuthService, bo nie jest statyczne
            var userRepository = new UserRepository(); // Tworzymy instancj� UserRepository

            if (userRepository.GetByUsername("admin") == null) // Sprawd�, czy u�ytkownik 'admin' ju� istnieje w bazie
            {
                // Rejestrujemy domy�lnego admina z has�em, imieniem i nazwiskiem
                authService.RegisterUser("admin", "admin123", "Super", "Admin", "Admin");
                MessageBox.Show("Domy�lny u�ytkownik 'admin' z has�em 'admin123' (Imi�: Super, Nazwisko: Admin) zosta� utworzony. Pami�taj, aby zmieni� has�o po zalogowaniu!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // KONIEC BLOKU DO ZAKOMENTOWANIA PO PIERWSZYM URUCHOMIENIU

            // Uruchomienie formularza logowania jako pierwszego
            Application.Run(new LoginForm());
        }
    }
}