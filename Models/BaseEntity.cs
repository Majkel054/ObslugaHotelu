namespace Hotel_Management_App.Models
{
    // Abstrakcyjna klasa bazowa dla wszystkich encji z identyfikatorem Id
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}