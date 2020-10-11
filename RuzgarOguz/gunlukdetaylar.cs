using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuzgarOguz
{
    public partial class gunlukdetaylar : Form
    {
        public gunlukdetaylar()
        {
            InitializeComponent();
            gunlukToplamGoster();
            gunlukToplamGoster2();
        }
        SqlConnection sc = new SqlConnection(ConfigurationSettings.AppSettings["connection_string"]);
        private void gunlukToplamGoster2()
        {
            try
            {
                sc.Open();
                SqlCommand komut = new SqlCommand("select CONVERT(VARCHAR(15), CAST(sum(toplamtahsilat) AS MONEY)),CONVERT(VARCHAR(15), CAST(sum(kasa) AS MONEY)),CONVERT(VARCHAR(15), CAST(sum(pos) AS MONEY)),CONVERT(VARCHAR(15), CAST(sum(kalankentkart) AS MONEY)) from toplam WHERE tarih like '%" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "%'", sc);
                SqlDataReader sdr = komut.ExecuteReader();
                while (sdr.Read())
                {
                    label4.Text = sdr[0].ToString();
                    label3.Text = sdr[1].ToString();
                    label2.Text = sdr[2].ToString();
                    label1.Text = sdr[3].ToString();
                }
                sdr.Close();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("gunlukToplamGoster: " + ex.Message);
            }
        }
        private void gunlukToplamGoster()
        {
            try
            {
                sc.Open();
                SqlCommand komut = new SqlCommand("select CONVERT(VARCHAR(15), CAST(sum(toplamtahsilat) AS MONEY)),CONVERT(VARCHAR(15), CAST(sum(kasa) AS MONEY)),CONVERT(VARCHAR(15), CAST(sum(pos) AS MONEY)),CONVERT(VARCHAR(15), CAST(sum(kalankentkart) AS MONEY)) from toplam", sc);
                SqlDataReader sdr = komut.ExecuteReader();
                while (sdr.Read())
                {
                    label17.Text = sdr[0].ToString();
                    label18.Text = sdr[1].ToString();
                    label19.Text = sdr[2].ToString();
                    label20.Text = sdr[3].ToString();
                }
                sdr.Close();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("gunlukToplamGoster: " + ex.Message);
            }
        }

        private void gunlukdetaylar_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'ruzgarDataSet5.toplam' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.toplamTableAdapter.Fill(this.ruzgarDataSet5.toplam);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox1.Text == null)
                {
                    MessageBox.Show("Silinecek veri seçin!");
                }
                else
                {

                    sc.Open();
                    SqlCommand komut = new SqlCommand("delete from toplam where no=@p1", sc);
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.ExecuteNonQuery();
                    sc.Close();
                    textBox1.Text = "";
                    MessageBox.Show("Silindi!");
                    this.toplamTableAdapter.Fill(this.ruzgarDataSet5.toplam);
                    gunlukToplamGoster();
                    gunlukToplamGoster2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinirken hata oluştu! HATA: button2_Click: " + ex.Message);
            }
        }

        int secilen;
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id;
            secilen = dataGridView4.SelectedCells[0].RowIndex;
            id = dataGridView4.Rows[secilen].Cells[0].Value.ToString();
            textBox1.Text = id;
        }
    }
}
