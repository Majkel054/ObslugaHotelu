using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ObslugaHotelu.Forms
{
    public class ListaRezerwacjiForm : BaseForm
    {
        private DataGridView dgvRezerwacje;
        private readonly string plikRezerwacji = "rezerwacje.txt";
        private readonly string plikKlientow = "klienci.txt";
        private readonly string plikPokoi = "pokoje.txt";

        public ListaRezerwacjiForm()
        {
            InitializeComponents();
            WczytajRezerwacje();
        }

        private void InitializeComponents()
        {
            this.Text = "Lista Rezerwacji";
            this.Size = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            dgvRezerwacje = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            };

            dgvRezerwacje.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvRezerwacje.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRezerwacje.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvRezerwacje.EnableHeadersVisualStyles = false;
            dgvRezerwacje.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvRezerwacje.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvRezerwacje.DefaultCellStyle.SelectionForeColor = Color.Black;

            this.Controls.Add(dgvRezerwacje);
        }

        private void WczytajRezerwacje()
        {
            if (!File.Exists(plikRezerwacji))
            {
                MessageBox.Show("Brak zapisanych rezerwacji.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvRezerwacje.Columns.Add("Pokoj", "Numer Pokoju");
            dgvRezerwacje.Columns.Add("Klient", "Klient");
            dgvRezerwacje.Columns.Add("Telefon", "Telefon");
            dgvRezerwacje.Columns.Add("DataOd", "Data Od");
            dgvRezerwacje.Columns.Add("DataDo", "Data Do");

            var klienci = File.Exists(plikKlientow)
                ? File.ReadAllLines(plikKlientow, Encoding.UTF8).Select(l => l.Split(';')).ToList()
                : new List<string[]>();

            var rezerwacje = File.ReadAllLines(plikRezerwacji, Encoding.UTF8);
            foreach (var linia in rezerwacje)
            {
                var dane = linia.Split(';');
                if (dane.Length == 4)
                {
                    string pokoj = dane[0];
                    string telefon = dane[1];
                    string dataOd = dane[2];
                    string dataDo = dane[3];

                    var klient = klienci.FirstOrDefault(k => k.Length >= 3 && k[2] == telefon);
                    string klientNazwisko = klient != null ? $"{klient[0]} {klient[1]}" : "Nieznany";

                    dgvRezerwacje.Rows.Add(pokoj, klientNazwisko, telefon, dataOd, dataDo);
                }
            }
        }
    }
}
