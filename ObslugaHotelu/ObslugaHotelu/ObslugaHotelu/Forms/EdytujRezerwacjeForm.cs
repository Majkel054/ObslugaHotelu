using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ObslugaHotelu.Forms
{
    public class EdytujRezerwacjeForm : Form
    {
        private TextBox txtPokoj;
        private DateTimePicker dtpDataOd;
        private DateTimePicker dtpDataDo;
        private Button btnZapisz;

        private readonly string plikRezerwacji = "rezerwacje.txt";
        private string klient;
        private string staryPokoj;
        private string staraDataOd;
        private string staraDataDo;

        public EdytujRezerwacjeForm(string klient, string pokoj, string dataOd, string dataDo)
        {
            this.klient = klient;
            this.staryPokoj = pokoj.Replace("Pokój ", "");
            this.staraDataOd = dataOd;
            this.staraDataDo = dataDo;

            InitializeComponents();

            txtPokoj.Text = staryPokoj;
            dtpDataOd.Value = DateTime.Parse(staraDataOd);
            dtpDataDo.Value = DateTime.Parse(staraDataDo);
        }

        private void InitializeComponents()
        {
            this.Text = "Edytuj Rezerwację";
            this.Size = new Size(350, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblPokoj = new Label { Text = "Numer pokoju:", Left = 20, Top = 30, Width = 120 };
            txtPokoj = new TextBox { Left = 150, Top = 30, Width = 150 };

            Label lblDataOd = new Label { Text = "Data od:", Left = 20, Top = 80, Width = 120 };
            dtpDataOd = new DateTimePicker { Left = 150, Top = 80, Width = 150, Format = DateTimePickerFormat.Short };

            Label lblDataDo = new Label { Text = "Data do:", Left = 20, Top = 130, Width = 120 };
            dtpDataDo = new DateTimePicker { Left = 150, Top = 130, Width = 150, Format = DateTimePickerFormat.Short };

            btnZapisz = new Button
            {
                Text = "Zapisz zmiany",
                Left = 80,
                Top = 200,
                Width = 180,
                Height = 40,
                BackColor = Color.LightSkyBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnZapisz.Click += BtnZapisz_Click;

            this.Controls.Add(lblPokoj);
            this.Controls.Add(txtPokoj);
            this.Controls.Add(lblDataOd);
            this.Controls.Add(dtpDataOd);
            this.Controls.Add(lblDataDo);
            this.Controls.Add(dtpDataDo);
            this.Controls.Add(btnZapisz);
        }

        private void BtnZapisz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPokoj.Text))
            {
                MessageBox.Show("Numer pokoju nie może być pusty!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDataDo.Value < dtpDataOd.Value)
            {
                MessageBox.Show("Data do nie może być wcześniejsza niż data od!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var linie = File.ReadAllLines(plikRezerwacji, Encoding.UTF8).ToList();
            for (int i = 0; i < linie.Count; i++)
            {
                var dane = linie[i].Split(';');
                if (dane.Length == 4 &&
                    dane[0] == klient &&
                    dane[1] == staryPokoj &&
                    DateTime.Parse(dane[2]).ToShortDateString() == staraDataOd &&
                    DateTime.Parse(dane[3]).ToShortDateString() == staraDataDo)
                {
                    linie[i] = $"{klient};{txtPokoj.Text};{dtpDataOd.Value.ToShortDateString()};{dtpDataDo.Value.ToShortDateString()}";
                    break;
                }
            }

            File.WriteAllLines(plikRezerwacji, linie, Encoding.UTF8);

            MessageBox.Show("Rezerwacja została zaktualizowana!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
