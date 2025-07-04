using Hotel_Management_App.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace Hotel_Management_App.Repositories
{
    public class UserRepository : SqliteRepository, IRepository<User>
    {
        public void Add(User item)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Dodano Name i Surname do zapytania INSERT
                cmd.CommandText = "INSERT INTO Users (Name, Surname, Username, PasswordHash, Role) VALUES (@name, @surname, @username, @passwordHash, @role)";
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@surname", item.Surname);
                cmd.Parameters.AddWithValue("@username", item.Username);
                cmd.Parameters.AddWithValue("@passwordHash", item.PasswordHash);
                cmd.Parameters.AddWithValue("@role", item.Role);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(User item)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Dodano Name i Surname do zapytania UPDATE
                cmd.CommandText = "UPDATE Users SET Name=@name, Surname=@surname, Username=@username, PasswordHash=@passwordHash, Role=@role WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@surname", item.Surname);
                cmd.Parameters.AddWithValue("@username", item.Username);
                cmd.Parameters.AddWithValue("@passwordHash", item.PasswordHash);
                cmd.Parameters.AddWithValue("@role", item.Role);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Users WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public User? Get(int id)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Dodano Name i Surname do zapytania SELECT
                cmd.CommandText = "SELECT Id, Name, Surname, Username, PasswordHash, Role FROM Users WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new User
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.GetString(1),      // Odczyt imienia
                            Surname = rdr.GetString(2),   // Odczyt nazwiska
                            Username = rdr.GetString(3),
                            PasswordHash = rdr.GetString(4),
                            Role = rdr.GetString(5)
                        };
                    }
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            var users = new List<User>();
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Dodano Name i Surname do zapytania SELECT
                cmd.CommandText = "SELECT Id, Name, Surname, Username, PasswordHash, Role FROM Users";

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        users.Add(new User
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.GetString(1),      // Odczyt imienia
                            Surname = rdr.GetString(2),   // Odczyt nazwiska
                            Username = rdr.GetString(3),
                            PasswordHash = rdr.GetString(4),
                            Role = rdr.GetString(5)
                        });
                    }
                }
            }
            return users;
        }

        public User? GetByUsername(string username)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                // Dodano Name i Surname do zapytania SELECT
                cmd.CommandText = "SELECT Id, Name, Surname, Username, PasswordHash, Role FROM Users WHERE Username=@username";
                cmd.Parameters.AddWithValue("@username", username);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new User
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.GetString(1),      // Odczyt imienia
                            Surname = rdr.GetString(2),   // Odczyt nazwiska
                            Username = rdr.GetString(3),
                            PasswordHash = rdr.GetString(4),
                            Role = rdr.GetString(5)
                        };
                    }
                }
            }
            return null;
        }
    }
}