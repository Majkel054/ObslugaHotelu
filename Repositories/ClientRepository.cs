using Hotel_Management_App.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace Hotel_Management_App.Repositories
{
    public class ClientRepository : SqliteRepository, IRepository<Client>
    {
        public void Add(Client item)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Clients (Name, Surname, Phone, Email) VALUES (@name, @surname, @phone, @email)";
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@surname", item.Surname);
                cmd.Parameters.AddWithValue("@phone", (object?)item.Phone ?? DBNull.Value); // Użyj (object?) i DBNull.Value dla nullable string
                cmd.Parameters.AddWithValue("@email", (object?)item.Email ?? DBNull.Value); // Użyj (object?) i DBNull.Value dla nullable string
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Client item)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Clients SET Name=@name, Surname=@surname, Phone=@phone, Email=@email WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@surname", item.Surname);
                cmd.Parameters.AddWithValue("@phone", (object?)item.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object?)item.Email ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Clients WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public Client? Get(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Surname, Phone, Email FROM Clients WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Client
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.GetString(1),
                            Surname = rdr.GetString(2),
                            Phone = rdr.IsDBNull(3) ? null : rdr.GetString(3), // Obsługa wartości null z bazy danych
                            Email = rdr.IsDBNull(4) ? null : rdr.GetString(4)   // Obsługa wartości null z bazy danych
                        };
                    }
                }
            }
            return null;
        }

        public List<Client> GetAll()
        {
            var clients = new List<Client>();
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Surname, Phone, Email FROM Clients";

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        clients.Add(new Client
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.GetString(1),
                            Surname = rdr.GetString(2),
                            Phone = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                            Email = rdr.IsDBNull(4) ? null : rdr.GetString(4)
                        });
                    }
                }
            }
            return clients;
        }
    }
}