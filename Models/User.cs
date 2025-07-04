namespace Hotel_Management_App.Models
{
    // Klasa User dziedziczy z Person, odziedziczając Id, Name i Surname.
    // Dodaje specyficzne dla użytkownika pola: Username, PasswordHash i Role.
    public class User : Person
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; // Domyślna rola to "User"

        public override string ToString()
        {
            // Możesz wybrać, co ma być wyświetlane. Używam Username i Role.
            return $"{Username} ({Role})";
        }
    }
}