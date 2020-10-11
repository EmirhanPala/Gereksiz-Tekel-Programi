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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            magazaekle me = new magazaekle();
            me.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            magazalistele ml = new magazalistele();
            ml.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            girdicikti gc = new girdicikti();
            gc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kasa k = new kasa();
            k.Show();
        }
    }
}
