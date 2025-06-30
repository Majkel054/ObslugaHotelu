using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ObslugaHotelu.Forms
{
    public class DodajRezerwacjeForm : BaseForm
    {
        private ComboBox cmbKlient;
        private ComboBox cmbPokoj;
        private DateTimePicker dtpDataOd;
        private DateTimePicker dtpDataDo;
        private Button btnZapisz;

        private readonly string plikKlientow = "klienci.txt";
        private readonly string plikPokoi = "pokoje.txt";
        private readonly string plikRezerwacji = "rezerwacje.txt";

        private List<string[]> klienci;
        private List<string[]> pokoje;

        public DodajRezerwacjeForm()
        {
            InitializeComponents();
            WczytajDane();
        }

        private void InitializeComponents()
        {
            this.Text = "Dodaj Rezerwację";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            var lblKlient = new Label { Text = "Klient:", Top = 30, Left = 30, Width = 100 };
            cmbKlient = new ComboBox { Top = 30, Left = 140, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblPokoj = new Label { Text = "Pokój:", Top = 80, Left = 30, Width = 100 };
            cmbPokoj = new ComboBox { Top = 80, Left = 140, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblDataOd = new Label { Text = "Data od:", Top = 130, Left = 30, Width = 100 };
            dtpDataOd = new DateTimePicker { Top = 130, Left = 140, Width = 200, Format = DateTimePickerFormat.Short };

            var lblDataDo = new Label { Text = "Data do:", Top = 180, Left = 30, Width = 100 };
            dtpDataDo = new DateTimePicker { Top = 180, Left = 140, Width = 200, Format = DateTimePickerFormat.Short };

            btnZapisz = new Button
            {
                Text = "Zapisz Rezerwację",
                Top = 250,
                Left = 80,
                Width = 220,
                Height = 40,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnZapisz.Click += BtnZapisz_Click;

            this.Controls.Add(lblKlient);
            this.Controls.Add(cmbKlient);
            this.Controls.Add(lblPokoj);
            this.Controls.Add(cmbPokoj);
            this.Controls.Add(lblDataOd);
            this.Controls.Add(dtpDataOd);
            this.Controls.Add(lblDataDo);
            this.Controls.Add(dtpDataDo);
            this.Controls.Add(btnZapisz);
        }

        private void WczytajDane()
        {
            if (File.Exists(plikKlientow))
            {
                klienci = File.ReadAllLines(plikKlientow, Encoding.UTF8)
                    .Select(l => l.Split(';'))
                    .Where(dane => dane.Length >= 3)
                    .ToList();

                foreach (var klient in klienci)
                {
                    cmbKlient.Items.Add($"{klient[0]} {klient[1]} ({klient[2]})"); // Imię Nazwisko (Telefon)
                }
            }

            if (File.Exists(plikPokoi))
            {
                pokoje = File.ReadAllLines(plikPokoi, Encoding.UTF8)
                    .Select(l => l.Split(';'))
                    .Where(dane => dane.Length >= 1)
                    .ToList();

                foreach (var pokoj in pokoje)
                {
                    cmbPokoj.Items.Add(pokoj[0]); // Numer pokoju
                }
            }
        }

        private void BtnZapisz_Click(object sender, EventArgs e)
        {
            if (cmbKlient.SelectedIndex == -1 || cmbPokoj.SelectedIndex == -1)
            {
                MessageBox.Show("Proszę wybrać klienta i pokój.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDataOd.Value.Date > dtpDataDo.Value.Date)
            {
                MessageBox.Show("Data od nie może być po dacie do.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var klient = klienci[cmbKlient.SelectedIndex];
            var pokoj = pokoje[cmbPokoj.SelectedIndex];

            string nowaRezerwacja = $"{pokoj[0]};{klient[2]};{dtpDataOd.Value:yyyy-MM-dd};{dtpDataDo.Value:yyyy-MM-dd}";

            File.AppendAllText(plikRezerwacji, nowaRezerwacja + Environment.NewLine, Encoding.UTF8);

            MessageBox.Show("Rezerwacja została zapisana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
