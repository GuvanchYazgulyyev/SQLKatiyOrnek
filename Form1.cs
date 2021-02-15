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

namespace kayıt_Programı_ders_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=GUGA\\SQLEXPRESS;Initial Catalog=kayitlar;Integrated Security=True");

        private void verileirigoster()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Gelenler", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Adsoyad"].ToString();
                ekle.SubItems.Add(oku["Firma"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Semt"].ToString());
                listView1.Items.Add(ekle);

            }
            baglan.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            verileirigoster();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into Gelenler(Adsoyad,Firma,Telefon,Semt) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileirigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
