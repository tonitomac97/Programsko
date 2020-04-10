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
    public partial class Racun : Form
    {
        public Racun()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            var konekcija = SQLConnect.Connection();
            konekcija.Open();

            string spremi = " Insert into Racun(vrsta,datum,kolicina,cijena) values ('" + comboBox1.Text + "','" + this.dateTimePicker1.Text + "', "+this.numericUpDown1.Text+","+this.numericUpDown2.Text+")";
            SqlCommand unesi = new SqlCommand(spremi, konekcija);
            unesi.ExecuteNonQuery();
            MessageBox.Show("Uspjesno izdan racun");

            konekcija.Close();

            update_med();
        }


        private void update_med()
        {
            var konekcija = SQLConnect.Connection();
            konekcija.Open();

            string update = " Update Skladiste_Meda set kolicina = kolicina-" + this.numericUpDown1.Text + " where vrsta = '" + this.comboBox1.Text + "'";
            SqlCommand promjeni = new SqlCommand(update, konekcija);
            promjeni.ExecuteNonQuery();
            konekcija.Close();

            


        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int a;
            int b;
            a = Convert.ToInt32(numericUpDown2.Value);
            b = Convert.ToInt32(numericUpDown1.Value);
            int konacna = a * b;
            textBox1.Text =konacna.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int a;
            int b;
            a = Convert.ToInt32(numericUpDown2.Value);
            b = Convert.ToInt32(numericUpDown1.Value);
            int konacna = a * b;
            textBox1.Text = konacna.ToString();

        }
    }
}
