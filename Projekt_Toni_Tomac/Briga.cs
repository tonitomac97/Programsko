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
    public partial class Briga : Form
    {
        public Briga()
        {
            InitializeComponent();
            ComboBox1();
        }

        private void Briga_Load(object sender, EventArgs e)
        {

        }

        private void ComboBox1()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var konekcija = SQLConnect.Connection();
            konekcija.Open();

            string preUpdate = " Select * from Kosnica where oznaka = '" + this.comboBox1.Text + "'";
            SqlCommand vadi = new SqlCommand(preUpdate, konekcija);
            SqlDataReader reader;
            reader = vadi.ExecuteReader();

            while (reader.Read())
            {
                textBox1.Text = (reader["dimenzije"].ToString());
                numericUpDown1.Text = (reader["broj_saca"].ToString());
                numericUpDown2.Text = (reader["broj_pcela"].ToString());
                textBox2.Text = (reader["napomena"].ToString());
            }

            konekcija.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Izbornik otvori = new Izbornik();
            otvori.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var konekcija = SQLConnect.Connection();
            konekcija.Open();

            string update = " UPDATE Kosnica set dimenzije = '"+this.textBox1.Text+"',broj_saca="+this.numericUpDown1.Text+",broj_pcela="+this.numericUpDown2.Text+" ,napomena='"+this.textBox2.Text+"' where oznaka = '"+this.comboBox1.Text+"' ";
            SqlCommand azuriraj = new SqlCommand(update, konekcija);
            azuriraj.ExecuteNonQuery();
            konekcija.Close();
            MessageBox.Show("Uspješno ažurirano");

        }
    }
}
