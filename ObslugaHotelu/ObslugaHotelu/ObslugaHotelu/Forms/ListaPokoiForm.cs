using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ObslugaHotelu.Forms
{
    public class ListaPokoiForm : BaseForm
    {
        private DataGridView dgvPokoje;
        private Button btnDodajPokoj;
        private readonly string plikPokoi = "pokoje.txt";

        public ListaPokoiForm()
        {
            InitializeComponents();
            WczytajPokoje();
        }

        private void InitializeComponents()
        {
            this.Text = "Lista Pokoi";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            dgvPokoje = new DataGridView
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

            dgvPokoje.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvPokoje.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPokoje.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPokoje.EnableHeadersVisualStyles = false;
            dgvPokoje.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPokoje.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvPokoje.DefaultCellStyle.SelectionForeColor = Color.Black;

            this.Controls.Add(dgvPokoje);

            btnDodajPokoj = new Button
            {
                Text = "Dodaj nowy pokój",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.LightGreen,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnDodajPokoj.Click += BtnDodajPokoj_Click;

            this.Controls.Add(btnDodajPokoj);
        }

        private void WczytajPokoje()
        {
            if (!File.Exists(plikPokoi))
            {
                UtworzPoczatkowePokoje();
            }

            dgvPokoje.Columns.Clear();
            dgvPokoje.Columns.Add("Numer", "Numer pokoju");
            dgvPokoje.Columns.Add("Miejsca", "Liczba miejsc");
            dgvPokoje.Columns.Add("LozkaPojedyncze", "Łóżka pojedyncze");
            dgvPokoje.Columns.Add("LozkaPodwojne", "Łóżka podwójne");

            dgvPokoje.Rows.Clear();
            var linie = File.ReadAllLines(plikPokoi, Encoding.UTF8);
            foreach (var linia in linie)
            {
                var dane = linia.Split(';');
                if (dane.Length == 4)
                {
                    dgvPokoje.Rows.Add(dane[0], dane[1], dane[2], dane[3]);
                }
            }
        }

        private void UtworzPoczatkowePokoje()
        {
            var pokoje = new[]
            {
                "1;2;2;0",
                "2;3;1;1",
                "3;4;2;1",
                "4;1;1;0",
                "5;2;2;0",
                "6;2;0;1",
                "7;3;3;0",
                "8;1;1;0",
                "9;4;2;1",
                "10;2;2;0"
            };

            File.WriteAllLines(plikPokoi, pokoje, Encoding.UTF8);
        }

        private void BtnDodajPokoj_Click(object sender, EventArgs e)
        {
            var formDodaj = new DodajPokojForm();
            if (formDodaj.ShowDialog() == DialogResult.OK)
            {
                WczytajPokoje();
            }
        }
    }
}
