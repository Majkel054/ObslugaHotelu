using Hotel_Management_App.Models; // Upewnij się, że jest ten using

namespace Hotel_Management_App.Models
{
    // Klasa Client dziedziczy z Person, odziedziczając Id, Name i Surname.
    // Dodaje specyficzne dla klienta pola: Phone i Email.
    public class Client : Person // Client dziedziczy z Person, a Person z BaseEntity, więc Id jest dziedziczone
    {
        public string? Phone { get; set; } // Użyj '?' dla nullability
        public string? Email { get; set; } // Użyj '?' dla nullability

        public override string ToString() => $"{Name} {Surname}";
    }
}