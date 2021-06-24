using PpaiImplementacion.IU.Entidades;
using PpaiImplementacion.IU.Logica;
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
    public partial class Venta_Entradas : Form
    {
        public Venta_Entradas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cambia a solapa
            this.tabControl1.SelectedIndex = 1;
            //metodo auxiliar
            CargarGrilla();
            txtFecha.Text = GestorVentasEntradas.obtenerFechaHoraActual().ToString("yyyy/MM/dd");
            txtHora.Text = DateTime.Now.ToString("hh:mm:ss");

        }

        private void CargarGrilla()
        {
            grillaTarifas.DataSource = GestorVentasEntradas.opcionVentaEntradas();
        }
        private void Btn_Salir_1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 2;
        }

        private void Venta_Entradas_Load(object sender, EventArgs e)
        {
            
        }

        private void grillaTarifas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indice = e.RowIndex;
                DataGridViewRow filaSelecionada = grillaTarifas.Rows[indice];
                String Cod = filaSelecionada.Cells["idTarifa"].Value.ToString();
                Tarifa te = Tarifa.ObtenerDatosParaMonto(Cod);
                cargarLabel(te);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos" + ex.Message);
            }
        }

        private void cargarLabel(Tarifa unObjeto)
        {
            txtTarifa.Text = unObjeto.idTarifas.ToString();
            lblMontoAdicional.Text = unObjeto.montoAdiGuia.ToString();
            lblMontoTarifa.Text = unObjeto.montoTarifa.ToString();
            string total = GestorVentasEntradas.buscarExposicionVigente();
            lblDuracion.Text = total;
            lblCantidadAsistentes.Text = GestorVentasEntradas.validarLimitesVisitantes().ToString();

        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void Btn_Validar_Click(object sender, EventArgs e)
        {
            if (checkMontoGuia.Checked == true)
            {
                lblPrecio.Text = (int.Parse(lblMontoAdicional.Text) + int.Parse(lblMontoTarifa.Text)).ToString();
            }
            else
            {
                lblPrecio.Text = lblMontoTarifa.Text;
            }
            int cantEntra = int.Parse(txtEntradas.Text);
            int validado = GestorVentasEntradas.cantidadEntradasAEmitir(cantEntra);
            if (validado != -1)
            {
                //lblCantidadAsistentes.Text = validado.ToString();
                lblcantVenta.Text = txtEntradas.Text;
                
                lblTotalPagar.Text = GestorVentasEntradas.calcularTotalVenta(int.Parse(txtEntradas.Text), int.Parse(lblPrecio.Text)).ToString();

            }
            else
            {
                MessageBox.Show("Se supero la capacidad de la sede");
            }
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {

            GestorVentasEntradas.tomarConfirmacionVenta(int.Parse(txtEntradas.Text),txtFecha.Text,txtHora.Text,int.Parse(lblPrecio.Text),1,int.Parse(txtTarifa.Text));
            MessageBox.Show("Se crearon las entradas con éxito");
            lblCantidadAsistentes.Text = GestorVentasEntradas.actualizarVisitantesEnPantallas(); 
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
