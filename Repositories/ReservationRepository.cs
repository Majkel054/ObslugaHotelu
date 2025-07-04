using Hotel_Management_App.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq; // Potrzebne do .Any()

namespace Hotel_Management_App.Repositories
{
    public class ReservationRepository : SqliteRepository, IRepository<Reservation>
    {
        public void Add(Reservation item)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Reservations (ClientId, RoomId, StartDate, EndDate) VALUES (@clientId, @roomId, @startDate, @endDate)";
                cmd.Parameters.AddWithValue("@clientId", item.ClientId);
                cmd.Parameters.AddWithValue("@roomId", item.RoomId);
                cmd.Parameters.AddWithValue("@startDate", item.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", item.EndDate.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Reservation item)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Reservations SET ClientId=@clientId, RoomId=@roomId, StartDate=@startDate, EndDate=@endDate WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@clientId", item.ClientId);
                cmd.Parameters.AddWithValue("@roomId", item.RoomId);
                cmd.Parameters.AddWithValue("@startDate", item.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", item.EndDate.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Reservations WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Reservation? Get(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, ClientId, RoomId, StartDate, EndDate FROM Reservations WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Reservation
                        {
                            Id = rdr.GetInt32(0),
                            ClientId = rdr.GetInt32(1),
                            RoomId = rdr.GetInt32(2),
                            StartDate = DateTime.Parse(rdr.GetString(3)),
                            EndDate = DateTime.Parse(rdr.GetString(4))
                        };
                    }
                }
            }
            return null;
        }

        public List<Reservation> GetAll()
        {
            var reservations = new List<Reservation>();
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, ClientId, RoomId, StartDate, EndDate FROM Reservations";

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        reservations.Add(new Reservation
                        {
                            Id = rdr.GetInt32(0),
                            ClientId = rdr.GetInt32(1),
                            RoomId = rdr.GetInt32(2),
                            StartDate = DateTime.Parse(rdr.GetString(3)),
                            EndDate = DateTime.Parse(rdr.GetString(4))
                        });
                    }
                }
            }
            return reservations;
        }

        // Nowa metoda do sprawdzania konfliktów rezerwacji
        public List<Reservation> GetConflictingReservations(int roomId, DateTime startDate, DateTime endDate, int? excludeReservationId = null)
        {
            var conflictingReservations = new List<Reservation>();
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT Id, ClientId, RoomId, StartDate, EndDate
                    FROM Reservations
                    WHERE RoomId = @roomId
                      AND (
                            (StartDate <= @endDate AND EndDate >= @startDate) -- Okresy się nakładają
                          )";
                if (excludeReservationId.HasValue)
                {
                    cmd.CommandText += " AND Id != @excludeId"; // Wyklucz aktualnie edytowaną rezerwację
                    cmd.Parameters.AddWithValue("@excludeId", excludeReservationId.Value);
                }

                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        conflictingReservations.Add(new Reservation
                        {
                            Id = rdr.GetInt32(0),
                            ClientId = rdr.GetInt32(1),
                            RoomId = rdr.GetInt32(2),
                            StartDate = DateTime.Parse(rdr.GetString(3)),
                            EndDate = DateTime.Parse(rdr.GetString(4))
                        });
                    }
                }
            }
            return conflictingReservations;
        }
    }
}