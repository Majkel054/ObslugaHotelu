using System;
using System.Drawing;
using System.Windows.Forms;
using ObslugaHotelu.Forms;

namespace ObslugaHotelu
{
    public partial class MenuGlowneForm : Form
    {
        public MenuGlowneForm()
        {
            this.Text = "Obsługa Hotelu - Menu Główne";
            this.Size = new Size(400, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            InitializeMenu();
        }

        private void InitializeMenu()
        {
            var btnDodajKlienta = TworzPrzycisk("➕ Dodaj Klienta", 30);
            btnDodajKlienta.Click += (s, e) => new DodajKlientaForm().ShowDialog();
            this.Controls.Add(btnDodajKlienta);

            var btnListaKlientow = TworzPrzycisk("📋 Lista Klientów", 100);
            btnListaKlientow.Click += (s, e) => new ListaKlientowForm().ShowDialog();
            this.Controls.Add(btnListaKlientow);

            var btnDodajRezerwacje = TworzPrzycisk("➕ Dodaj Rezerwację", 170);
            btnDodajRezerwacje.Click += (s, e) => new DodajRezerwacjeForm().ShowDialog();
            this.Controls.Add(btnDodajRezerwacje);

            btnListaRezerwacji = new Button
            {
                Text = "📋 Lista Rezerwacji",
                Width = 300,
                Height = 50,
                Top = 240,
                Left = (this.ClientSize.Width - 300) / 2,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnListaRezerwacji.Click += BtnListaRezerwacji_Click;
            this.Controls.Add(btnListaRezerwacji);

            var btnWolnePokoje = TworzPrzycisk("📖 Wolne Pokoje", 310);
            btnWolnePokoje.Click += (s, e) => new WolnePokojeForm().ShowDialog();
            this.Controls.Add(btnWolnePokoje);

            var BtnDodajPokoj = TworzPrzycisk("➕ Dodaj Pokój", 380);
            BtnDodajPokoj.Click += (s, e) => new DodajPokojForm().ShowDialog();
            this.Controls.Add(BtnDodajPokoj);
        }


        private Button btnListaRezerwacji;

        private Button TworzPrzycisk(string tekst, int top)
        {
            return new Button
            {
                Text = tekst,
                Width = 300,
                Height = 50,
                Top = top,
                Left = (this.ClientSize.Width - 300) / 2,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
        }

        private void BtnListaRezerwacji_Click(object sender, EventArgs e)
        {
            var listaRezerwacjiForm = new ListaRezerwacjiForm();
            listaRezerwacjiForm.ShowDialog();
        }

        private void BtnDodajPokoj_Click(object sender, EventArgs e)
        {
            DodajPokojForm dodajPokojForm = new DodajPokojForm();
            dodajPokojForm.ShowDialog();
        }

    }
}
