using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ObslugaHotelu.Forms
{
    public class ListaKlientowForm : Form
    {
        private DataGridView dgvKlienci;
        private readonly string plikKlientow = "klienci.txt";

        public ListaKlientowForm()
        {
            InitializeComponents();
            WczytajKlientow();
        }

        private void InitializeComponents()
        {
            this.Text = "Lista Klientów";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            dgvKlienci = new DataGridView
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

            // Nowoczesny wygląd DataGridView
            dgvKlienci.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvKlienci.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKlienci.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvKlienci.EnableHeadersVisualStyles = false;
            dgvKlienci.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvKlienci.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvKlienci.DefaultCellStyle.SelectionForeColor = Color.Black;

            this.Controls.Add(dgvKlienci);

            var btnUsunKlienta = new Button
            {
                Text = "Usuń zaznaczonego klienta",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnUsunKlienta.Click += BtnUsunKlienta_Click;

            this.Controls.Add(btnUsunKlienta);
        }

        private void WczytajKlientow()
        {
            if (!File.Exists(plikKlientow))
            {
                MessageBox.Show("Brak zapisanych klientów.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvKlienci.Columns.Add("Imie", "Imię");
            dgvKlienci.Columns.Add("Nazwisko", "Nazwisko");
            dgvKlienci.Columns.Add("Telefon", "Telefon");
            dgvKlienci.Columns.Add("Email", "E-mail");

            var linie = File.ReadAllLines(plikKlientow, Encoding.UTF8);
            foreach (var linia in linie)
            {
                var dane = linia.Split(';');
                if (dane.Length == 4)
                {
                    dgvKlienci.Rows.Add(dane[0], dane[1], dane[2], dane[3]);
                }
            }
        }
        private void BtnUsunKlienta_Click(object sender, EventArgs e)
        {
            if (dgvKlienci.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę zaznaczyć klienta do usunięcia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var potwierdzenie = MessageBox.Show("Czy na pewno chcesz usunąć zaznaczonego klienta?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (potwierdzenie != DialogResult.Yes)
                return;

            var wybranyWiersz = dgvKlienci.SelectedRows[0];
            var telefon = wybranyWiersz.Cells["Telefon"].Value.ToString();

            // Usuń klienta z pliku
            var linie = File.ReadAllLines(plikKlientow).ToList();
            linie = linie.Where(linia => !linia.Contains(telefon)).ToList();
            File.WriteAllLines(plikKlientow, linie, Encoding.UTF8);

            // Usuń klienta z DataGridView
            dgvKlienci.Rows.Remove(wybranyWiersz);

            MessageBox.Show("Klient został usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
