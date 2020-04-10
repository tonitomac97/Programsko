using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Projekt_Toni_Tomac
{
    public partial class PravljenjeMeda : Form
    {

        public string vrsta;
        public int kolicina;
        public PravljenjeMeda()
        {
            InitializeComponent();
            combo();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void combo()
        {
            var konekcija = SQLConnect.Connection();
            konekcija.Open();

            string izvadi = " SELECT * FROM KOSNICA";

            SqlCommand vadi = new SqlCommand(izvadi, konekcija);
            SqlDataReader reader;
            reader = vadi.ExecuteReader();

            while (reader.Read())
            {

                string Kosnica = reader.GetString(0);
                comboBox1.Items.Add(Kosnica);

            }
        }



    private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Izbornik otvori = new Izbornik();
            otvori.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var konekcija = SQLConnect.Connection();
            konekcija.Open();
            bool zastava = false;
            int a;
            int b;
            a = Convert.ToInt32(numericUpDown2.Value);
            b = Convert.ToInt32(numericUpDown1.Value);
            
                if (a <= b) { MessageBox.Show("Nemoguće je izvući " + a + " kilograma meda iz" + b + " kilograma saća"); }
                else zastava = true;
            if (zastava == true)
            {
                string update = " UPDATE Kosnica set broj_saca = broj_saca-" + this.numericUpDown2.Text + " where oznaka = '" + this.comboBox1.Text + "' ";
                SqlCommand azuriraj = new SqlCommand(update, konekcija);
                azuriraj.ExecuteNonQuery();
                konekcija.Close();

                unesi_med();

                MessageBox.Show("Stanje skladišta meda i saća primjenjeno");
            }
        }
        private void unesi_med()
        {
            var konekcija = SQLConnect.Connection();
            konekcija.Open();

            string update = " UPDATE  Skladiste_Meda set kolicina = " + this.numericUpDown1.Text + " where vrsta = '" + this.comboBox2.Text + "' ";
            SqlCommand azuriraj = new SqlCommand(update, konekcija);
            azuriraj.ExecuteNonQuery();
            konekcija.Close();
        }

        private void PravljenjeMeda_Load(object sender, EventArgs e)
        {

        }
    }
}
