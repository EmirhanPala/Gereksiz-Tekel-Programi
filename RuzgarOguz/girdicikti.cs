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
    public partial class girdicikti : Form
    {
        public girdicikti()
        {
            InitializeComponent();
        }

        SqlConnection sc = new SqlConnection(ConfigurationSettings.AppSettings["connection_string"]);
        bool eklemeKontrol = false;
        private void girdicikti_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'ruzgarDataSet3.toplam' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.toplamTableAdapter.Fill(this.ruzgarDataSet3.toplam);

            dataGridView2.Enabled = false;
            // TODO: Bu kod satırı 'ruzgarDataSet.detay' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.detayTableAdapter.Fill(this.ruzgarDataSet.detay);
            // TODO: Bu kod satırı 'ruzgarDataSet2.magaza' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.magazaTableAdapter.Fill(this.ruzgarDataSet2.magaza);
            sc.Open();
            SqlCommand komut = new SqlCommand("select magaza from magaza", sc);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0].ToString());
            }
            oku.Close();
            sc.Close();

            toplamGosterKasa();
            toplamGosterKart();
            toplamGosterCep();
            kasaKartTopla();
            
        }

        

        private void kasaKartTopla()
        {
            try
            {
                sc.Open();
                SqlCommand komut = new SqlCommand("select CONVERT(VARCHAR(15), CAST(sum(odenenmiktar) AS MONEY)) from detay where odemeturu='Kasa' or odemeturu='Kart'", sc);
                SqlDataReader sdr = komut.ExecuteReader();
                while (sdr.Read())
                {
                    label12.Text = sdr[0].ToString();
                }
                sdr.Close();
                sc.Close();
            }
            catch (Exception ex)
            {
                label12.Text = "Girdi yok!";
            }
        }

        private void toplamGosterKasa()
        {
            try
            {
                sc.Open();
                SqlCommand komut = new SqlCommand("select CONVERT(VARCHAR(15), CAST(sum(odenenmiktar) AS MONEY)) from detay where odemeturu='Kasa'", sc);
                SqlDataReader sdr = komut.ExecuteReader();
                while (sdr.Read())
                {
                    label9.Text = sdr[0].ToString();
                }
                sdr.Close();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("toplamGosterKasa:" + ex.Message);
            }
        }
        private void toplamGosterKart()
        {
            try
            {
                sc.Open();
                SqlCommand komut = new SqlCommand("select CONVERT(VARCHAR(15), CAST(sum(odenenmiktar) AS MONEY)) from detay where odemeturu='Kart'", sc);
                SqlDataReader sdr = komut.ExecuteReader();
                while (sdr.Read())
                {
                    label10.Text = sdr[0].ToString();
                }
                sdr.Close();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("toplamGosterKart:" + ex.Message);
            }
        }
        private void toplamGosterCep()
        {
            try
            {
                sc.Open();
                SqlCommand komut = new SqlCommand("select CONVERT(VARCHAR(15), CAST(sum(odenenmiktar) AS MONEY)) from detay where odemeturu='Cep'", sc);
                SqlDataReader sdr = komut.ExecuteReader();
                while (sdr.Read())
                {
                    label11.Text = sdr[0].ToString();
                }
                sdr.Close();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("toplamGosterCep:" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || comboBox1.Text == null)
                {
                    MessageBox.Show("Mağaza seçilmedi!");
                    label5.Text = "Mağaza adı seçme hatası!";
                    label5.ForeColor = Color.Black;
                }
                else if (comboBox1.Text == "" || comboBox1.Text == null)
                {
                    MessageBox.Show("Ödeme türü seçilmedi!");
                    label5.Text = "Ödeme türü seçme hatası!";
                    label5.ForeColor = Color.Black;
                }
                else if (numericUpDown1.Value == 0)
                {
                    MessageBox.Show("Alınan adet girilmedi!");
                    label5.Text = "Alınan adet girilmedi hatası!";
                    label5.ForeColor = Color.Black;
                }
                else if (textBox4.Text == "" || textBox4.Text == null)
                {
                    MessageBox.Show("Ödenen tutar girilmedi!");
                    label5.Text = "Ödenen tutar girilmedi hatası!";
                    label5.ForeColor = Color.Black;
                }
                else
                {
                    label5.Text = "Ekleme başlatıldı!";
                    label5.ForeColor = Color.DarkGreen;

                    sc.Open();
                    SqlCommand komut = new SqlCommand("insert into detay (magaza,alinanadet,odemeturu,odenenmiktar,tarih,guncellemetarihi) values (@p1,@p2,@p3,@p4,@p5,@p6)", sc);
                    komut.Parameters.AddWithValue("@p1", comboBox1.Text);
                    komut.Parameters.AddWithValue("@p2", numericUpDown1.Value);
                    komut.Parameters.AddWithValue("@p3", comboBox2.Text);
                    komut.Parameters.AddWithValue("@p4", textBox4.Text);
                    komut.Parameters.AddWithValue("@p5", DateTime.Now.ToString());
                    komut.Parameters.AddWithValue("@p6", DateTime.Now.ToString());
                    komut.ExecuteNonQuery();
                    sc.Close();
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    numericUpDown1.Value = 0;
                    textBox4.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Eklendi!");
                    this.detayTableAdapter.Fill(this.ruzgarDataSet.detay);
                    label5.Text = "Ekleme yapıldı!";
                    label5.ForeColor = Color.DarkGreen;

                    toplamGosterKasa();
                    toplamGosterKart();
                    toplamGosterCep();
                    kasaKartTopla();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eklenirken hata oluştu! button1_Click:" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox1.Text == null)
                {
                    MessageBox.Show("Güncellenecek veri seçin!");
                }
                else
                {
                    label5.Text = "Güncelleme başlatıldı!";
                    label5.ForeColor = Color.DarkOrange;

                    sc.Open();
                    SqlCommand komut = new SqlCommand("update detay set magaza=@p1,alinanadet=@p2,odemeturu=@p3,odenenmiktar=@p4,guncellemetarihi=@p5 where no=@id", sc);
                    komut.Parameters.AddWithValue("@id", textBox1.Text);
                    komut.Parameters.AddWithValue("@p1", comboBox1.Text);
                    komut.Parameters.AddWithValue("@p3", comboBox2.Text);
                    komut.Parameters.AddWithValue("@p2", numericUpDown1.Value);
                    komut.Parameters.AddWithValue("@p4", textBox4.Text);
                    komut.Parameters.AddWithValue("@p5", DateTime.Now.ToString());
                    komut.ExecuteNonQuery();
                    sc.Close();
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    numericUpDown1.Value = 0;
                    textBox4.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Güncellendi!");
                    this.detayTableAdapter.Fill(this.ruzgarDataSet.detay);
                    label5.Text = "Güncelleme yapıldı!";
                    label5.ForeColor = Color.DarkOrange;
                    toplamGosterKasa();
                    toplamGosterKart();
                    toplamGosterCep();
                    kasaKartTopla();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncellenirken hata oluştu! button3_Click:");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox1.Text == null)
                {
                    MessageBox.Show("Silinecek veri seçin!");
                }
                else
                {
                    label5.Text = "Silme başlatıldı!";
                    label5.ForeColor = Color.Red;

                    sc.Open();
                    SqlCommand komut = new SqlCommand("delete from detay where no=@p1", sc);
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.ExecuteNonQuery();
                    sc.Close();
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    numericUpDown1.Value = 0;
                    textBox4.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    MessageBox.Show("Silindi!");
                    this.detayTableAdapter.Fill(this.ruzgarDataSet.detay);
                    label5.Text = "Silme yapıldı!";
                    label5.ForeColor = Color.Red;
                    toplamGosterKasa();
                    toplamGosterKart();
                    toplamGosterCep();
                    kasaKartTopla();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silinirken hata oluştu! HATA: button2_Click: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                Width = 750;
                checkBox1.Text = "Genişlet >";
            }
            else
            {
                Width = 1040;
                checkBox1.Text = "Genişlet <";
            }
        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id, magaza, tur, tarih, gtarih, odenen;
                int alinan;
                secilen = dataGridView1.SelectedCells[0].RowIndex;
                id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                magaza = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                alinan = int.Parse(dataGridView1.Rows[secilen].Cells[2].Value.ToString());
                tur = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                odenen = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                tarih = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                gtarih = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

                textBox1.Text = id;
                comboBox1.Text = magaza;
                comboBox2.Text = tur;
                numericUpDown1.Value = alinan;
                textBox4.Text = odenen.ToString();
                textBox2.Text = tarih;
                textBox3.Text = gtarih;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CELLCLICK HATA: " + ex);
            }
        }

        int secilenGoster;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                string gosterAd;
                secilenGoster = dataGridView2.SelectedCells[0].RowIndex;
                gosterAd = dataGridView2.Rows[secilenGoster].Cells[1].Value.ToString();

                sc.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select magaza,alinanadet,odemeturu,odenenmiktar,tarih from detay where magaza='" + gosterAd + "'", sc);
                DataSet ds = new DataSet();
                sda.Fill(ds, "magaza");
                dataGridView3.DataSource = ds.Tables["magaza"];
                sc.Close();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {

                dataGridView2.Enabled = false;
                dataGridView3.Hide();
                dataGridView1.Show();
            }
            else
            {

                dataGridView2.Enabled = true;
                dataGridView1.Hide();
                dataGridView3.Show();
            }
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            sc.Open();
            SqlCommand komut = new SqlCommand("insert into toplam (toplamtahsilat,kasa,pos,kalankentkart,tarih) values (@p1,@p2,@p3,@p4,@p5)", sc);
            komut.Parameters.AddWithValue("@p1", textBox5.Text);
            komut.Parameters.AddWithValue("@p2", textBox6.Text);
            komut.Parameters.AddWithValue("@p3", textBox7.Text);
            komut.Parameters.AddWithValue("@p4", textBox8.Text);
            komut.Parameters.AddWithValue("@p5", DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            sc.Close();
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            MessageBox.Show("Eklendi!");
            this.detayTableAdapter.Fill(this.ruzgarDataSet.detay);
            label5.Text = "Ekleme yapıldı!";
            label5.ForeColor = Color.DarkGreen;
            this.toplamTableAdapter.Fill(this.ruzgarDataSet3.toplam);
            toplamGosterKasa();
            toplamGosterKart();
            toplamGosterCep();
            kasaKartTopla();
            
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                gunlukdetaylar gd = new gunlukdetaylar();
                if (checkBox3.Checked == false)
                {
                    gd.Hide();
                    checkBox3.Text = "Genişlet2 >";
                }
                else
                {
                    gd.Show();
                    checkBox3.Text = "Genişlet2 <";
                }
            }
            else
            {
                checkBox3.Checked = false;
                MessageBox.Show("Genişletici 1 aktif değil!");
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            gunlukharcamalar gh = new gunlukharcamalar();
            if (checkBox4.Checked == false)
            {
                gh.Hide();
                checkBox4.Text = "G.D.T >";
            }
            else
            {
                gh.Show();
                checkBox4.Text = "G.D.T <";
            }
        }
    }
}
