namespace Hotel_Management_App.Models
{
    // Klasa Room dziedziczy z BaseEntity, co oznacza, że ma właściwość Id.
    public class Room : BaseEntity // Room dziedziczy Id z BaseEntity
    {
        public string Number { get; set; } = string.Empty;
        public RoomType Type { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; } = true; // Domyślnie pokój jest dostępny

        public override string ToString() => $"Pokój {Number} ({Type})";
    }

    public enum RoomType { Single, Double, Suite } // Typy pokoi
}