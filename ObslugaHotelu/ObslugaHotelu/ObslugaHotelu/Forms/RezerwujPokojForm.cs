using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ObslugaHotelu.Forms
{
    public class RezerwujPokojForm : BaseForm
    {
        private ComboBox cmbKlienci;
        private ComboBox cmbPokoje;
        private DateTimePicker dtpDataOd;
        private DateTimePicker dtpDataDo;
        private Button btnRezerwuj;

        private readonly string plikKlientow = "klienci.txt";
        private readonly string plikPokoi = "pokoje.txt";
        private readonly string plikRezerwacji = "rezerwacje.txt";

        public RezerwujPokojForm()
        {
            InitializeComponents();
            WczytajKlientow();
            WczytajPokoje();
        }

        private void InitializeComponents()
        {
            this.Text = "Rezerwacja Pokoju";
            this.Size = new Size(450, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblKlient = new Label { Text = "Klient:", Left = 30, Top = 30, Width = 120 };
            cmbKlienci = new ComboBox { Left = 150, Top = 30, Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblPokoj = new Label { Text = "Pokój:", Left = 30, Top = 80, Width = 120 };
            cmbPokoje = new ComboBox { Left = 150, Top = 80, Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblDataOd = new Label { Text = "Data od:", Left = 30, Top = 130, Width = 120 };
            dtpDataOd = new DateTimePicker { Left = 150, Top = 130, Width = 250, Format = DateTimePickerFormat.Short };

            Label lblDataDo = new Label { Text = "Data do:", Left = 30, Top = 180, Width = 120 };
            dtpDataDo = new DateTimePicker { Left = 150, Top = 180, Width = 250, Format = DateTimePickerFormat.Short };

            btnRezerwuj = new Button
            {
                Text = "Zarezerwuj",
                Left = 100,
                Top = 250,
                Width = 250,
                Height = 40,
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnRezerwuj.Click += BtnRezerwuj_Click;

            this.Controls.Add(lblKlient);
            this.Controls.Add(cmbKlienci);
            this.Controls.Add(lblPokoj);
            this.Controls.Add(cmbPokoje);
            this.Controls.Add(lblDataOd);
            this.Controls.Add(dtpDataOd);
            this.Controls.Add(lblDataDo);
            this.Controls.Add(dtpDataDo);
            this.Controls.Add(btnRezerwuj);
        }

        private void WczytajKlientow()
        {
            if (File.Exists(plikKlientow))
            {
                var linie = File.ReadAllLines(plikKlientow, Encoding.UTF8);
                foreach (var linia in linie)
                {
                    var dane = linia.Split(';');
                    if (dane.Length == 4)
                    {
                        cmbKlienci.Items.Add($"{dane[0]} {dane[1]} ({dane[2]})"); // Imię Nazwisko (Telefon)
                    }
                }
            }
        }

        private void WczytajPokoje()
        {
            if (File.Exists(plikPokoi))
            {
                var linie = File.ReadAllLines(plikPokoi, Encoding.UTF8);
                foreach (var linia in linie)
                {
                    cmbPokoje.Items.Add(linia); // np. Pokój 1;2 miejsca;1x pojedyncze;0x podwójne
                }
            }
        }

        private void BtnRezerwuj_Click(object sender, EventArgs e)
        {
            if (cmbKlienci.SelectedItem == null || cmbPokoje.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać klienta i pokój.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDataOd.Value.Date >= dtpDataDo.Value.Date)
            {
                MessageBox.Show("Data końcowa musi być po dacie początkowej.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string wybranyPokoj = cmbPokoje.SelectedItem.ToString();
            string numerPokoju = wybranyPokoj.Split(';')[0].Replace("Pokój ", "").Trim();

            // Sprawdzenie dostępności pokoju
            if (File.Exists(plikRezerwacji))
            {
                var rezerwacje = File.ReadAllLines(plikRezerwacji, Encoding.UTF8);
                foreach (var rez in rezerwacje)
                {
                    var dane = rez.Split(';');
                    if (dane.Length == 4 && dane[1] == numerPokoju)
                    {
                        var dataOd = DateTime.Parse(dane[2]);
                        var dataDo = DateTime.Parse(dane[3]);
                        if (dtpDataOd.Value.Date <= dataDo && dtpDataDo.Value.Date >= dataOd)
                        {
                            MessageBox.Show("Ten pokój jest już zarezerwowany w wybranym terminie!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            // Zapisz nową rezerwację
            var klient = cmbKlienci.SelectedItem.ToString();
            var nowaRezerwacja = $"{klient};{numerPokoju};{dtpDataOd.Value:yyyy-MM-dd};{dtpDataDo.Value:yyyy-MM-dd}";
            File.AppendAllText(plikRezerwacji, nowaRezerwacja + Environment.NewLine, Encoding.UTF8);

            MessageBox.Show("Pokój został zarezerwowany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
