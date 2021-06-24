using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PpaiImplementacion.IU
{
    public partial class Pant_Principal : Form
    {
        public Pant_Principal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Venta_Entradas obj = new Venta_Entradas();
            obj.Show();
            
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Venta_Entradas obj = new Venta_Entradas();
            obj.Show();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
