using System;
using Microsoft.Data.Sqlite;
using Hotel_Management_App.Services; // Potrzebne do użycia AuthService
using Hotel_Management_App.Repositories; // Potrzebne do użycia UserRepository

namespace Hotel_Management_App.Repositories
{
    public static class Database
    {
        public static void Initialize()
        {
            string connectionString = "Data Source=hotel.db";

            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                // Tworzenie tabeli Users - teraz zgodne z modelem User, który dziedziczy z Person (ma Name i Surname)
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,       -- Dodane pole Name
                        Surname TEXT NOT NULL,    -- Dodane pole Surname
                        Username TEXT NOT NULL UNIQUE,
                        PasswordHash TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );";
                cmd.ExecuteNonQuery();

                // Tworzenie tabeli Clients
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Clients (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Surname TEXT NOT NULL,
                        Phone TEXT,
                        Email TEXT
                    );";
                cmd.ExecuteNonQuery();

                // Tworzenie tabeli Rooms
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Rooms (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Number TEXT NOT NULL UNIQUE,
                        Type TEXT NOT NULL,
                        PricePerNight REAL NOT NULL,
                        IsAvailable INTEGER NOT NULL
                    );";
                cmd.ExecuteNonQuery();

                // Tworzenie tabeli Reservations
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Reservations (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClientId INTEGER NOT NULL,
                        RoomId INTEGER NOT NULL,
                        StartDate TEXT NOT NULL,
                        EndDate TEXT NOT NULL,
                        FOREIGN KEY (ClientId) REFERENCES Clients(Id),
                        FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
                    );";
                cmd.ExecuteNonQuery();


                // Dodawanie pierwszego użytkownika 'admin' tylko jeśli tabela Users jest pusta
                cmd.CommandText = "SELECT COUNT(*) FROM Users";
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                {
                    var authService = new AuthService(); // Tworzymy instancję AuthService
                    // Rejestrujemy admina z imieniem i nazwiskiem
                    authService.RegisterUser("admin", "admin123", "Super", "Admin", "Admin");
                }
            }
        }
    }
}