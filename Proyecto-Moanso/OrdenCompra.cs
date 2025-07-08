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
    public partial class OrdenCompra : Form
    {
        public OrdenCompra()
        {
            InitializeComponent();
            CargarCotizaciones();
            CargarEstados();
            ListarOrdenCompra();
            groupBox1.Enabled = false;
        }

        private void ListarOrdenCompra()
        {
            dataGridView1.DataSource = LOGOrdenCompra.Instancia.ListarOrdenCompra();
        }

        private void CargarCotizaciones()
        {
            cbxcotizacion.DataSource = LOGCotizaciones.Instancia.ListarCotizaciones();
            cbxcotizacion.DisplayMember = "IdCotizacion";
            cbxcotizacion.ValueMember = "IdCotizacion";
        }
        private void CargarEstados()
        {
            cbxestados.Items.Clear();
            cbxestados.Items.Add("PENDIENTE");
            cbxestados.Items.Add("RECIBIDA");
            cbxestados.Items.Add("CANCELADA");
            cbxestados.SelectedIndex = 0;
        }
        private void Limpiar()
        {
            cbxcotizacion.SelectedItem = 0;
            txtproveedor.Clear();
            txtmontototal.Clear();
            dtpfechaorden.Value = DateTime.Now;
            dtpfechaentrega.Value = DateTime.Now.AddDays(3);
            cbxestados.SelectedIndex = 0;
            txtobservaciones.Clear();
            dtpfecharegistro.Value = DateTime.Now;
        }

        private void cbxcotizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxcotizacion.SelectedItem != null)
            {
                ENTCotizaciones cotiSeleccionada = (ENTCotizaciones)cbxcotizacion.SelectedItem;
                txtmontototal.Text = cotiSeleccionada.MontoTotal.ToString("0.00");
                txtproveedor.Text = cotiSeleccionada.IdProveedor.ToString();
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENTOrdenCompra ordC = new ENTOrdenCompra
                {
                    IdCotizacion = (int)cbxcotizacion.SelectedValue,
                    IdProveedor = ((ENTCotizaciones)cbxcotizacion.SelectedItem).IdProveedor,
                    FechaOrden = dtpfechaorden.Value,
                    FechaEntrega = dtpfechaentrega.Value,
                    MontoTotal = decimal.Parse(txtmontototal.Text),
                    Estado = cbxestados.SelectedItem.ToString(),
                    Observaciones = txtobservaciones.Text,
                    FechaRegistro = dtpfecharegistro.Value
                };

                LOGOrdenCompra.Instancia.InsertarOrdenCompra(ordC);
                MessageBox.Show("Orden Compra registrada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar Orden Compra: " + ex.Message);
            }

            Limpiar();
            groupBox1.Enabled = false;
            ListarOrdenCompra();
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
                DialogResult result = MessageBox.Show("¿Deseas eliminar esta Orden Compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idOrdencompra = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOrdenCompra"].Value);
                        LOGOrdenCompra.Instancia.EliminarOrdenCompra(idOrdencompra);
                        MessageBox.Show("Orden Compra eliminada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarOrdenCompra();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una Orden Compra para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
