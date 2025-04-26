using System;
using System.Drawing;
using System.Windows.Forms;

namespace ObslugaHotelu.Forms
{
    public class MainForm : Form
    {
        private Button btnDodajKlienta;
        private Button btnListaKlientow;
        private Button btnListaPokoi;
        private Button btnWolnePokoje;
        private Button btnRezerwujPokoj;
        private Button btnListaRezerwacji;

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Obsługa Hotelu - Menu Główne";
            this.Size = new Size(400, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            int buttonWidth = 250;
            int buttonHeight = 50;
            int margin = 20;
            int topPosition = 30;

            btnDodajKlienta = CreateButton("Dodaj klienta", topPosition);
            btnDodajKlienta.Click += (s, e) => new DodajKlientaForm().ShowDialog();

            btnListaKlientow = CreateButton("Lista klientów", topPosition += buttonHeight + margin);
            btnListaKlientow.Click += (s, e) => new ListaKlientowForm().ShowDialog();

            btnListaPokoi = CreateButton("Lista pokoi", topPosition += buttonHeight + margin);
            btnListaPokoi.Click += (s, e) => new ListaPokoiForm().ShowDialog();

            btnWolnePokoje = CreateButton("Wolne pokoje", topPosition += buttonHeight + margin);
            btnWolnePokoje.Click += (s, e) => new WolnePokojeForm().ShowDialog();

            btnRezerwujPokoj = CreateButton("Zarezerwuj pokój", topPosition += buttonHeight + margin);
            btnRezerwujPokoj.Click += (s, e) => new RezerwujPokojForm().ShowDialog();

            btnListaRezerwacji = CreateButton("Lista rezerwacji", topPosition += buttonHeight + margin);
            btnListaRezerwacji.Click += (s, e) => new ListaRezerwacjiForm().ShowDialog();

            this.Controls.AddRange(new Control[]
            {
                btnDodajKlienta,
                btnListaKlientow,
                btnListaPokoi,
                btnWolnePokoje,
                btnRezerwujPokoj,
                btnListaRezerwacji
            });
        }

        private Button CreateButton(string text, int top)
        {
            return new Button
            {
                Text = text,
                Size = new Size(250, 50),
                Location = new Point((this.ClientSize.Width - 250) / 2, top),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                BackColor = Color.LightSkyBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
        }
    }
}
