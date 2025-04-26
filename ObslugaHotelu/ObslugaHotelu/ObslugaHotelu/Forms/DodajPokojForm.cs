using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ObslugaHotelu.Forms
{
    public class DodajPokojForm : Form
    {
        private TextBox txtNumer, txtMiejsca, txtLozkaPojedyncze, txtLozkaPodwojne;
        private Button btnZapisz;
        private readonly string plikPokoi = "pokoje.txt";

        public DodajPokojForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Dodaj pokój";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblNumer = new Label { Text = "Numer pokoju:", Left = 30, Top = 30, Width = 120 };
            txtNumer = new TextBox { Left = 180, Top = 30, Width = 150 };

            Label lblMiejsca = new Label { Text = "Liczba miejsc:", Left = 30, Top = 80, Width = 120 };
            txtMiejsca = new TextBox { Left = 180, Top = 80, Width = 150 };

            Label lblLozkaPojedyncze = new Label { Text = "Łóżka pojedyncze:", Left = 30, Top = 130, Width = 120 };
            txtLozkaPojedyncze = new TextBox { Left = 180, Top = 130, Width = 150 };

            Label lblLozkaPodwojne = new Label { Text = "Łóżka podwójne:", Left = 30, Top = 180, Width = 120 };
            txtLozkaPodwojne = new TextBox { Left = 180, Top = 180, Width = 150 };

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

            this.Controls.Add(lblNumer);
            this.Controls.Add(txtNumer);
            this.Controls.Add(lblMiejsca);
            this.Controls.Add(txtMiejsca);
            this.Controls.Add(lblLozkaPojedyncze);
            this.Controls.Add(txtLozkaPojedyncze);
            this.Controls.Add(lblLozkaPodwojne);
            this.Controls.Add(txtLozkaPodwojne);
            this.Controls.Add(btnZapisz);
        }

        private void BtnZapisz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumer.Text) ||
                string.IsNullOrWhiteSpace(txtMiejsca.Text) ||
                string.IsNullOrWhiteSpace(txtLozkaPojedyncze.Text) ||
                string.IsNullOrWhiteSpace(txtLozkaPodwojne.Text))
            {
                MessageBox.Show("Wszystkie pola są wymagane!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nowyPokoj = $"{txtNumer.Text};{txtMiejsca.Text};{txtLozkaPojedyncze.Text};{txtLozkaPodwojne.Text}";
            File.AppendAllText(plikPokoi, nowyPokoj + Environment.NewLine, Encoding.UTF8);

            MessageBox.Show("Pokój został dodany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
