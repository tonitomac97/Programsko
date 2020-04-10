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
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prijava odustani = new Prijava();
            odustani.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection registracija = new SqlConnection();
            var registrijaraj = SQLConnect.Connection();

            registrijaraj.Open();

            string spremi = " INSERT INTO KORISNIK VALUES ('" + this.textBox3.Text + "', '"+this.textBox4.Text+"' ,'"+this.textBox1.Text+"', '"+this.textBox2.Text+"' )";
            SqlCommand dovrsi = new SqlCommand(spremi, registrijaraj);
            dovrsi.ExecuteNonQuery();
            registrijaraj.Close();

            MessageBox.Show("Uspješno ste se registrirali");
            this.Hide();
            button2_Click(sender,e);

        }
    }
}
