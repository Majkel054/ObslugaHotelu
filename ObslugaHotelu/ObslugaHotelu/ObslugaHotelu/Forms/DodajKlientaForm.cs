using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ObslugaHotelu.Forms
{
    public class DodajKlientaForm : BaseForm
    {
        private TextBox txtImie;
        private TextBox txtNazwisko;
        private TextBox txtTelefon;
        private TextBox txtEmail;
        private Button btnZapisz;

        private readonly string plikKlientow = "klienci.txt";

        public DodajKlientaForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Dodaj klienta";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblImie = new Label { Text = "Imię:", Left = 30, Top = 30, Width = 100 };
            txtImie = new TextBox { Left = 150, Top = 30, Width = 200 };

            Label lblNazwisko = new Label { Text = "Nazwisko:", Left = 30, Top = 80, Width = 100 };
            txtNazwisko = new TextBox { Left = 150, Top = 80, Width = 200 };

            Label lblTelefon = new Label { Text = "Telefon:", Left = 30, Top = 130, Width = 100 };
            txtTelefon = new TextBox { Left = 150, Top = 130, Width = 200 };

            Label lblEmail = new Label { Text = "Email:", Left = 30, Top = 180, Width = 100 };
            txtEmail = new TextBox { Left = 150, Top = 180, Width = 200 };

            btnZapisz = new Button
            {
                Text = "Zapisz",
                Left = 100,
                Top = 250,
                Width = 200,
                Height = 40,
                BackColor = Color.LightSkyBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnZapisz.Click += BtnZapisz_Click;

            this.Controls.Add(lblImie);
            this.Controls.Add(txtImie);
            this.Controls.Add(lblNazwisko);
            this.Controls.Add(txtNazwisko);
            this.Controls.Add(lblTelefon);
            this.Controls.Add(txtTelefon);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(btnZapisz);
        }

        private void BtnZapisz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImie.Text) || string.IsNullOrWhiteSpace(txtNazwisko.Text) ||
                string.IsNullOrWhiteSpace(txtTelefon.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Wszystkie pola są wymagane!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sprawdza, czy klient już istnieje (po numerze telefonu lub e-mailu)
            if (File.Exists(plikKlientow))
            {
                var linie = File.ReadAllLines(plikKlientow, Encoding.UTF8);
                foreach (var linia in linie)
                {
                    var dane = linia.Split(';');
                    if (dane.Length >= 4)
                    {
                        if (dane[2] == txtTelefon.Text || dane[3] == txtEmail.Text)
                        {
                            MessageBox.Show("Klient z takim numerem telefonu lub e-mailem już istnieje!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            // Zapisuje nowego klienta
            var nowyKlient = $"{txtImie.Text};{txtNazwisko.Text};{txtTelefon.Text};{txtEmail.Text}";
            File.AppendAllText(plikKlientow, nowyKlient + Environment.NewLine, Encoding.UTF8);

            MessageBox.Show("Klient został dodany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
