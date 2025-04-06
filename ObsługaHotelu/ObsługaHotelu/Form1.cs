using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObsługaHotelu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pokoje_Click(object sender, EventArgs e)
        {
            Pokoje noweOkno = new Pokoje();
            noweOkno.Show();
        }

        private void wolnePokoje_Click(object sender, EventArgs e)
        {
            WolnePokoje noweOkno = new WolnePokoje();
            noweOkno.ShowDialog();
        }

        private void klienci_Click(object sender, EventArgs e)
        {
            Klienci noweOkno = new Klienci();
            noweOkno.Show();
        }

        private void dodajKlienta_Click(object sender, EventArgs e)
        {
            DodajKlienta noweOkno = new DodajKlienta();
            noweOkno.ShowDialog();
        }

        private void terminRezerwacji_Click(object sender, EventArgs e)
        {
            TerminRezerwacji noweOkno = new TerminRezerwacji();
            noweOkno.Show();
        }

        private void zarezerwuj_Click(object sender, EventArgs e)
        {
            Zarezerwuj noweOkno = new Zarezerwuj();
            noweOkno.ShowDialog();
        }
    }
}
