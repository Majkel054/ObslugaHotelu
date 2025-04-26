namespace ObslugaHotelu.Models
{
    public class Klient
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public Klient() { }

        public Klient(string imie, string nazwisko, string telefon, string email)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Telefon = telefon;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Imie},{Nazwisko},{Telefon},{Email}";
        }

        public static Klient FromString(string data)
        {
            var parts = data.Split(',');
            if (parts.Length != 4) return null;

            return new Klient(parts[0], parts[1], parts[2], parts[3]);
        }
    }
}
