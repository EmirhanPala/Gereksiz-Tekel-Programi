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
    public partial class gunlukharcamalar : Form
    {
        SqlConnection sc = new SqlConnection(ConfigurationSettings.AppSettings["connection_string"]);
        public gunlukharcamalar()
        {
            InitializeComponent();
            detayCek();
            toplamGosterKasa();
            toplamGosterKart();
            toplamGosterCep();
        }

        private void detayCek()
        {
            try
            {
                sc.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select magaza,alinanadet,odemeturu,odenenmiktar,tarih from detay where tarih like '%" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "%'", sc);
                DataSet ds = new DataSet();
                sda.Fill(ds, "magaza");
                dataGridView1.DataSource = ds.Tables["magaza"];
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void toplamGosterKasa()
        {
            try
            {
                sc.Open();
                SqlCommand komut = new SqlCommand("select CONVERT(VARCHAR(15), CAST(sum(odenenmiktar) AS MONEY)) from detay where odemeturu='Kasa' AND tarih like '%" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "%'", sc);
                SqlDataReader sdr = komut.ExecuteReader();
                while (sdr.Read())
                {
                    label1.Text = sdr[0].ToString();
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
                SqlCommand komut = new SqlCommand("select CONVERT(VARCHAR(15), CAST(sum(odenenmiktar) AS MONEY)) from detay where odemeturu='Kart' AND tarih like '%" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "%'", sc);
                SqlDataReader sdr = komut.ExecuteReader();
                while (sdr.Read())
                {
                    label2.Text = sdr[0].ToString();
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
                SqlCommand komut = new SqlCommand("select CONVERT(VARCHAR(15), CAST(sum(odenenmiktar) AS MONEY)) from detay where odemeturu='Cep' AND tarih like '%" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "%'", sc);
                SqlDataReader sdr = komut.ExecuteReader();
                while (sdr.Read())
                {
                    label3.Text = sdr[0].ToString();
                }
                sdr.Close();
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("toplamGosterCep:" + ex.Message);
            }
        }
    }
}
