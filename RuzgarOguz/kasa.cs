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
    public partial class kasa : Form
    {
        public kasa()
        {
            InitializeComponent();
        }
        SqlConnection sc = new SqlConnection(ConfigurationSettings.AppSettings["connection_string"]);
        private void kasa_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'ruzgarDataSet4.kasa' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kasaTableAdapter.Fill(this.ruzgarDataSet4.kasa);

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand komut = new SqlCommand("insert into kasa (toplamtahsilat,kasa,pos,kentkart,tarih) values (@p1,@p2,@p3,@p4,@p5)", sc);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.Parameters.AddWithValue("@p5", DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            sc.Close();
            textBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Eklendi!");
            this.kasaTableAdapter.Fill(this.ruzgarDataSet4.kasa);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand komut = new SqlCommand("delete from kasa where no=@p1", sc);
            komut.Parameters.AddWithValue("@p1", textBox5.Text);
            komut.ExecuteNonQuery();
            sc.Close();
            textBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Silindi!");
            this.kasaTableAdapter.Fill(this.ruzgarDataSet4.kasa);
        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

            textBox5.Text = id;
        }
    }
}
