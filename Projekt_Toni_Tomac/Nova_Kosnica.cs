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
    public partial class Nova_Kosnica : Form
    {
        public Nova_Kosnica()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var konekcija = SQLConnect.Connection();
            konekcija.Open();


            string spremi = "INSERT INTO KOSNICA VALUES ('"+this.textBox1.Text+"','"+this.textBox2.Text+"',"+this.numericUpDown1.Text+","+this.numericUpDown2.Text+",'bez napomene' )";
            SqlCommand komanda = new SqlCommand(spremi, konekcija);
            komanda.ExecuteNonQuery();
            konekcija.Close();
            MessageBox.Show("Uspjesno spremljena kosnica");

            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Izbornik otvori = new Izbornik();
            otvori.Show();
            this.Hide();
        }
    }
}
