using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogica;

namespace Proyecto_Moanso
{
    public partial class EgresoFrinanciero : Form
    {
        public EgresoFrinanciero()
        {
            InitializeComponent();
            CargarOrdenCompra();
            ListarEgreso();
            groupBox1.Enabled = false;
        }

        private void ListarEgreso()
        {
            dataGridView1.DataSource = LOGEgresoFinanciero.Instancia.ListarEgresoFinanciero();
        }

        private void CargarOrdenCompra()
        {
            cbxordencompra.DataSource = LOGOrdenCompra.Instancia.ListarOrdenCompra();
            cbxordencompra.DisplayMember = "IdOrdenCompra";
            cbxordencompra.ValueMember = "IdOrdenCompra";
        }
        private void Limpiar()
        {
            cbxordencompra.SelectedIndex = 0;
            txtconcepto.Clear();
            txtobservaciones.Clear();
            dtpfechaegreso.Value = DateTime.Now;
            txttipoegreso.Clear();
            txtmonto.Clear();
            txtobservaciones.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void cbxordencompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxordencompra.SelectedItem != null)
            {
                ENTOrdenCompra ordenSeleccionada = (ENTOrdenCompra)cbxordencompra.SelectedItem;
                txtmonto.Text = ordenSeleccionada.MontoTotal.ToString("0.00");
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENTEgresoFinanciero egr = new ENTEgresoFinanciero
                {
                    IdOrdenCompra = (int)cbxordencompra.SelectedValue,
                    Concepto = txtconcepto.Text,
                    FechaEgreso = dtpfechaegreso.Value,
                    Monto = decimal.Parse(txtmonto.Text),
                    TipoEgreso = txttipoegreso.Text,
                    Observaciones = txtobservaciones.Text,
                    FechaRegistro = dateTimePicker1.Value
                };

                LOGEgresoFinanciero.Instancia.InsertarEgresoFinanciero(egr);
                MessageBox.Show("Egreso registrada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar Egreso: " + ex.Message);
            }

            Limpiar();
            groupBox1.Enabled = false;
            ListarEgreso();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            Limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnagregar.Visible = true;
            Limpiar();
        }

        private void btndeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar este Egreso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idEgreso = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdEgreso"].Value);
                        LOGEgresoFinanciero.Instancia.EliminarEgresoFinanciero(idEgreso);
                        MessageBox.Show("Egreso eliminado correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarEgreso();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un Egreso para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
