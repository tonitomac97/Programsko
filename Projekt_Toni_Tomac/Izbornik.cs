using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Toni_Tomac
{
    public partial class Izbornik : Form
    {
        public Izbornik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nova_Kosnica otvori = new Nova_Kosnica();
            otvori.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Briga otvori = new Briga();
            otvori.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Prijava otvori = new Prijava();
            otvori.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PravljenjeMeda otvori = new PravljenjeMeda();
            otvori.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Racun otvori = new Racun();
            otvori.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Skladiste otvori = new Skladiste();
            otvori.Show();
            
        }
    }
}
