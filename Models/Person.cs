namespace Hotel_Management_App.Models
{
    // Klasa Person dziedziczy z BaseEntity, dodając pola Name i Surname
    public abstract class Person : BaseEntity // Person dziedziczy Id z BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public override string ToString() => $"{Name} {Surname}";
    }
}