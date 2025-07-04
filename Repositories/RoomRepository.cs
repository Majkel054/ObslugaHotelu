using Hotel_Management_App.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace Hotel_Management_App.Repositories
{
    public class RoomRepository : SqliteRepository, IRepository<Room>
    {
        public void Add(Room item)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Rooms (Number, Type, PricePerNight, IsAvailable) VALUES (@number, @type, @price, @available)";
                cmd.Parameters.AddWithValue("@number", item.Number);
                cmd.Parameters.AddWithValue("@type", (int)item.Type);
                cmd.Parameters.AddWithValue("@price", item.PricePerNight);
                cmd.Parameters.AddWithValue("@available", item.IsAvailable);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Room item)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Rooms SET Number=@number, Type=@type, PricePerNight=@price, IsAvailable=@available WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@number", item.Number);
                cmd.Parameters.AddWithValue("@type", (int)item.Type);
                cmd.Parameters.AddWithValue("@price", item.PricePerNight);
                cmd.Parameters.AddWithValue("@available", item.IsAvailable);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Rooms WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Room? Get(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Number, Type, PricePerNight, IsAvailable FROM Rooms WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Room
                        {
                            Id = rdr.GetInt32(0),
                            Number = rdr.GetString(1),
                            Type = (RoomType)rdr.GetInt32(2),
                            PricePerNight = rdr.GetDecimal(3),
                            IsAvailable = rdr.GetBoolean(4)
                        };
                    }
                }
            }
            return null;
        }

        public List<Room> GetAll()
        {
            var rooms = new List<Room>();
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Number, Type, PricePerNight, IsAvailable FROM Rooms";

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        rooms.Add(new Room
                        {
                            Id = rdr.GetInt32(0),
                            Number = rdr.GetString(1),
                            Type = (RoomType)rdr.GetInt32(2),
                            PricePerNight = rdr.GetDecimal(3),
                            IsAvailable = rdr.GetBoolean(4)
                        });
                    }
                }
            }
            return rooms;
        }
    }
}