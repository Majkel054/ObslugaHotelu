using Hotel_Management_App.Models;
using Hotel_Management_App.Repositories;
using BCrypt.Net; // Upewnij się, że masz zainstalowany pakiet NuGet BCrypt.Net-Next
using System.Linq;

namespace Hotel_Management_App.Services
{
    // Klasa AuthService nie jest już statyczna, co pozwala na wstrzykiwanie zależności (chociaż tutaj tworzymy instancję ręcznie)
    public class AuthService
    {
        private readonly UserRepository _userRepository;

        public AuthService()
        {
            _userRepository = new UserRepository();
        }

        // Metoda do uwierzytelniania użytkownika
        public User? Authenticate(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }

        // Metoda do rejestracji nowego użytkownika, teraz z imieniem i nazwiskiem
        public bool RegisterUser(string username, string password, string name, string surname, string role = "User")
        {
            // Sprawdź, czy użytkownik o takiej nazwie już istnieje
            if (_userRepository.GetByUsername(username) != null)
            {
                return false; // Użytkownik już istnieje
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var newUser = new User
            {
                Username = username,
                PasswordHash = hashedPassword,
                Name = name,         // Ustawienie imienia
                Surname = surname,   // Ustawienie nazwiska
                Role = role
            };

            _userRepository.Add(newUser);
            return true;
        }

        // Metoda do zmiany hasła użytkownika
        public bool ChangePassword(int userId, string newPassword)
        {
            var user = _userRepository.Get(userId);
            if (user == null)
            {
                return false;
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            _userRepository.Update(user);
            return true;
        }

        // Metoda do zmiany roli użytkownika
        public bool ChangeUserRole(int userId, string newRole)
        {
            var user = _userRepository.Get(userId);
            if (user == null)
            {
                return false;
            }

            user.Role = newRole;
            _userRepository.Update(user);
            return true;
        }
    }
}