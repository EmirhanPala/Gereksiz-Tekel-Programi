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
using System.Configuration;

namespace RuzgarOguz
{
    public partial class magazaekle : Form
    {
        public magazaekle()
        {
            InitializeComponent();
        }
        SqlConnection sc = new SqlConnection(ConfigurationSettings.AppSettings["connection_string"]);
        private void button1_Click(object sender, EventArgs e)
        {
            sc.Close();
            sc.Open();
            SqlCommand komut = new SqlCommand("select magaza from magaza where magaza='" + textBox1.Text + "'", sc);
            SqlDataReader sdr = komut.ExecuteReader();
            if (sdr.Read())
            {
                sdr.Close();
                MessageBox.Show("Bu mağaza ismi kullanılıyor!");
            }
            else
            {
                sdr.Close();
                SqlCommand komut2 = new SqlCommand("insert into magaza (magaza) values (@p1)", sc);
                komut2.Parameters.AddWithValue("@p1", textBox1.Text);
                komut2.ExecuteNonQuery();
                sc.Close();
                MessageBox.Show("Mağaza eklendi!");
            }
        }
    }
}
