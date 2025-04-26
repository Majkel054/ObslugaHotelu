using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ObslugaHotelu.Forms
{
    public class WolnePokojeForm : Form
    {
        private DataGridView dgvWolnePokoje;
        private readonly string plikPokoi = "pokoje.txt";
        private readonly string plikRezerwacji = "rezerwacje.txt";

        public WolnePokojeForm()
        {
            InitializeComponents();
            WczytajWolnePokoje();
        }

        private void InitializeComponents()
        {
            this.Text = "Wolne Pokoje";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            dgvWolnePokoje = new DataGridView
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

            dgvWolnePokoje.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvWolnePokoje.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvWolnePokoje.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvWolnePokoje.EnableHeadersVisualStyles = false;
            dgvWolnePokoje.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvWolnePokoje.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvWolnePokoje.DefaultCellStyle.SelectionForeColor = Color.Black;

            this.Controls.Add(dgvWolnePokoje);
        }

        private void WczytajWolnePokoje()
        {
            if (!File.Exists(plikPokoi))
            {
                MessageBox.Show("Brak danych o pokojach.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvWolnePokoje.Columns.Add("NumerPokoju", "Numer Pokoju");

            var wszystkiePokoje = File.ReadAllLines(plikPokoi, Encoding.UTF8);
            var zajetePokoje = new HashSet<string>();

            if (File.Exists(plikRezerwacji))
            {
                var rezerwacje = File.ReadAllLines(plikRezerwacji, Encoding.UTF8);
                foreach (var linia in rezerwacje)
                {
                    var dane = linia.Split(';');
                    if (dane.Length >= 1)
                    {
                        zajetePokoje.Add(dane[0]);
                    }
                }
            }

            foreach (var linia in wszystkiePokoje)
            {
                var danePokoju = linia.Split(';');
                if (danePokoju.Length >= 1)
                {
                    string numerPokoju = danePokoju[0];
                    bool czyZajety = zajetePokoje.Contains(numerPokoju);

                    if (!czyZajety) // tylko wolne pokoje
                    {
                        dgvWolnePokoje.Rows.Add(numerPokoju);
                    }
                }
            }
        }
    }
}
