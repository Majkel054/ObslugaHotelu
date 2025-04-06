using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// ShowDialog() - otwiera okno dodatkowego, które trzeba zamknąć żeby wrócić do głównego (przyciski dodawania)
//Show() - otwiera okno dodatkowego, można skakać między głównym a dodatkowym (przyciski tylko do podglądu)

namespace ObsługaHotelu
{
    public class Pokoj
    {
        public int numer;
        public int IloscMiejsc;
        public int nrRezerwacji;
    }

    public class Klient
    {
        public string Imie;
        public string Nazwisko;
        public string Kontakt;

        public void Dane()
        {
            Console.WriteLine("Podaj Imię: ");
            Imie = Console.ReadLine();

            Console.WriteLine("Podaj Nazwisko: ");
            Nazwisko = Console.ReadLine();

            Console.WriteLine("Podaj nr telefonu lub e-mail: ");
            Kontakt = Console.ReadLine();
        }

        public void PokazDane()
        {
            Console.WriteLine($"Imię: {Imie}");
        }
    }
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
