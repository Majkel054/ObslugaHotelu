using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ObslugaHotelu.Models;

namespace ObslugaHotelu.Managers
{
    public static class KlientManager
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "klienci.txt");

        static KlientManager()
        {
            var dir = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        public static void DodajKlienta(Klient klient)
        {
            var klienci = PobierzWszystkich();
            if (klienci.Any(k => k.Telefon == klient.Telefon || k.Email.Equals(klient.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Klient z takim numerem telefonu lub adresem email już istnieje.");
            }

            File.AppendAllText(FilePath, klient.ToString() + Environment.NewLine);
        }

        public static List<Klient> PobierzWszystkich()
        {
            if (!File.Exists(FilePath))
                return new List<Klient>();

            var lines = File.ReadAllLines(FilePath);
            return lines.Select(Klient.FromString).Where(k => k != null).ToList();
        }
    }
}
