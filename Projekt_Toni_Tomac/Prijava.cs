using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Projekt_Toni_Tomac
{
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registracija registriraj = new Registracija();
            registriraj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
     
            var prijavi = SQLConnect.Connection();
            prijavi.Open();

            string prijava = "select count(*) from Korisnik where lozinka='" + this.textBox2.Text + "'and korisnicko_ime = '" + this.textBox1.Text + "'";
            SqlDataAdapter prijava_ = new SqlDataAdapter(prijava,prijavi);

            DataTable provjera = new DataTable();
            prijava_.Fill(provjera);

            if (provjera.Rows[0][0].ToString() == "1")
            {
                Izbornik udji = new Izbornik();
                udji.Show();
                this.Hide();
            }
            else MessageBox.Show("Nepostojeća lozinka ili korisničko ime!");

        }
    }
}
