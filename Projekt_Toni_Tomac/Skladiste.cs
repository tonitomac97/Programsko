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
    public partial class Skladiste : Form
    {

        List<PravljenjeMeda> med = new List<PravljenjeMeda>();
        public Skladiste()
        {
            InitializeComponent();
            Ispuni_listu();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }


        private void Ispuni_listu()
        {
            var konekcija = SQLConnect.Connection();
            konekcija.Open();
            string uzmi = "Select * from Skladiste_Meda";
            SqlCommand preuzmi = new SqlCommand(uzmi, konekcija);
            SqlDataReader reader;
            reader = preuzmi.ExecuteReader();

            while (reader.Read())
            {

                PravljenjeMeda trenutni=new PravljenjeMeda();
                trenutni.vrsta = (string)reader["vrsta"];
                trenutni.kolicina = (int)reader["kolicina"];

                med.Add(trenutni);
            }

            foreach(var m in med)
            {

                string[] linija = { m.vrsta, m.kolicina.ToString() };
                var red_ = new ListViewItem(linija);
                listView1.Items.Add(red_);
            }

            konekcija.Close();
            
        }
    }
}
