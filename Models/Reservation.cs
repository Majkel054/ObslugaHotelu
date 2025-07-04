using System;

namespace Hotel_Management_App.Models
{
    // Klasa Reservation dziedziczy z BaseEntity.
    public class Reservation : BaseEntity // Reservation dziedziczy Id z BaseEntity
    {
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}