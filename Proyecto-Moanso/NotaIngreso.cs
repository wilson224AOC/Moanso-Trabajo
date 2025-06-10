using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using CapaLogica;

namespace Proyecto_Moanso
{
    public partial class NotaIngreso : Form
    {
        public NotaIngreso()
        {
            InitializeComponent();
            CargarOrdenCompra();
            CargarTipoIngreso();
            ListarNotaIngreso();
        }

        private void ListarNotaIngreso()
        {
            dataGridView1.DataSource = LOGNotaEntrada.Instancia.ListarNotaIngreso();
        }

        private void CargarTipoIngreso()
        {
            cbxtipoingreso.Items.Clear();
            cbxtipoingreso.Items.Add("COMPRA");
            cbxtipoingreso.Items.Add("DEVOLUCION");
            cbxtipoingreso.Items.Add("AJUSTE");
            cbxtipoingreso.SelectedIndex = 0;
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
            dtpfechaingreso.Value = DateTime.Now;
            dtpfecharegistro.Value = DateTime.Now.AddDays(7);
            cbxtipoingreso.SelectedIndex = 0;
            txtobservaciones.Clear();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENTNotaEntrada notE = new ENTNotaEntrada
                {
                    IdOrdenCompra = Convert.ToInt32(cbxordencompra.SelectedValue),
                    FechaIngreso = dtpfechaingreso.Value,
                    TipoIngreso = cbxtipoingreso.SelectedItem.ToString(),
                    Observaciones = txtobservaciones.Text,
                    FechaRegistro = dtpfecharegistro.Value
                };

                LOGNotaEntrada.Instancia.InsertarNotaIngreso(notE);
                MessageBox.Show("Nota Ingreso registrada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar Nota Ingreso: " + ex.Message);
            }

            Limpiar();
            groupBox1.Enabled = false;
            ListarNotaIngreso();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            Limpiar();
        }

        private void btndeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar esta Nota Ingreso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idNotaentrada = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdNotaIngreso"].Value);
                        LOGNotaEntrada.Instancia.EliminarNotaIngreso(idNotaentrada);
                        MessageBox.Show("Nota Ingreso eliminada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarNotaIngreso();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una cotización para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnagregar.Visible = true;
            Limpiar();
        }
    }
}
