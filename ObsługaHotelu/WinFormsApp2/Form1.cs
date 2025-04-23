namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wolne_pokoje noweOkno = new wolne_pokoje();
            noweOkno.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            klienci noweOkno = new klienci();
            noweOkno.Show();
        }

        private void pokoje_Click(object sender, EventArgs e)
        {
            okno_pokoje noweOkno = new okno_pokoje();
            noweOkno.Show();
        }

        private void dodajKlienta_Click(object sender, EventArgs e)
        {
            dodaj_klienta noweOkno = new dodaj_klienta();
            noweOkno.Show();
        }

        private void terminy_Click(object sender, EventArgs e)
        {
            termin_rezerwacji noweOkno = new termin_rezerwacji();
            noweOkno.Show();
        }

        private void zarezerwuj_Click(object sender, EventArgs e)
        {
            zarezerwuj noweOkno = new zarezerwuj();
            noweOkno.Show();
        }
    }
}