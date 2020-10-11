using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuzgarOguz
{
    public partial class magazalistele : Form
    {
        public magazalistele()
        {
            InitializeComponent();
        }

        private void magazalistele_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'ruzgarDataSet1.magaza' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.magazaTableAdapter.Fill(this.ruzgarDataSet1.magaza);

        }
    }
}
