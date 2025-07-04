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

            // Inicjalizacja bazy danych (tworzy tabele, jeœli nie istniej¹)
            Database.Initialize();

            // SprawdŸ, czy istnieje u¿ytkownik 'admin'. Jeœli nie, utwórz go.
            // WA¯NE: Ten blok kodu jest przeznaczony do wykonanie tylko raz, przy pierwszym uruchomieniu aplikacji.
            // Po utworzeniu domyœlnego admina, najlepiej ZAKOMENTUJ PONI¯SZY BLOK KODU,
            // aby unikn¹æ prób ponownego tworzenia u¿ytkownika przy ka¿dym uruchomieniu.
            var authService = new AuthService(); // Tworzymy instancjê AuthService, bo nie jest statyczne
            var userRepository = new UserRepository(); // Tworzymy instancjê UserRepository

            if (userRepository.GetByUsername("admin") == null) // SprawdŸ, czy u¿ytkownik 'admin' ju¿ istnieje w bazie
            {
                // Rejestrujemy domyœlnego admina z has³em, imieniem i nazwiskiem
                authService.RegisterUser("admin", "admin123", "Super", "Admin", "Admin");
                MessageBox.Show("Domyœlny u¿ytkownik 'admin' z has³em 'admin123' (Imiê: Super, Nazwisko: Admin) zosta³ utworzony. Pamiêtaj, aby zmieniæ has³o po zalogowaniu!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // KONIEC BLOKU DO ZAKOMENTOWANIA PO PIERWSZYM URUCHOMIENIU

            // Uruchomienie formularza logowania jako pierwszego
            Application.Run(new LoginForm());
        }
    }
}