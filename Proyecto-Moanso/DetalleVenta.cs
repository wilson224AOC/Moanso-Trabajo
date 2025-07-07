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
    public partial class DetalleVenta : Form
    {
        public DetalleVenta()
        {
            InitializeComponent();
            CargarTiposVenta();
            ListarDetalleVenta();
            groupBox1.Enabled = false;
        }

        private void CargarTiposVenta()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Directa");
            comboBox1.Items.Add("Credito");
            comboBox1.SelectedIndex = 0;
        }

        private void ListarDetalleVenta()
        {
            dataGridView2.DataSource = LOGDetalleVenta.Instancia.ListarDetalleVenta();
        }

        private void Limpiar()
        {
            txtidventa.Clear();
            txtproducto.Clear();
            txtcantidad.Clear();
            txtsubtotal.Clear();
            txtobservaciones.Clear();
            dtpfecharegistro.Value = DateTime.Now;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string tipoVenta = comboBox1.SelectedItem.ToString();

                if (tipoVenta == "Directa")
                {
                    dataGridView1.DataSource = LOGVentaDirecta.Instancia.ListarVentaDirecta();
                }
                else if (tipoVenta == "Credito")
                {
                    dataGridView1.DataSource = LOGVentaCredito.Instancia.ListarVentaCredito();
                }
            }
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    string tipoVenta = comboBox1.SelectedItem?.ToString();

                    if (tipoVenta == "Directa")
                    {
                        int idVenta = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdVenta"].Value);
                        txtidventa.Text = idVenta.ToString();

                        txtsubtotal.Text = dataGridView1.CurrentRow.Cells["MontoTotal"].Value.ToString();
                    }
                    else if (tipoVenta == "Credito")
                    {
                        int idVentaCredito = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdVentaCredito"].Value);
                        txtidventa.Text = idVentaCredito.ToString();

                        txtsubtotal.Text = dataGridView1.CurrentRow.Cells["MontoCredito"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Tipo de venta no reconocido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtproducto.Text = dataGridView1.CurrentRow.Cells["IdProducto"].Value.ToString();
                    txtcantidad.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();

                    MessageBox.Show("Datos cargados correctamente", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un detalle de venta de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtidventa.Text))
                {
                    MessageBox.Show("Debe cargar datos de una venta primero usando el botón Aceptar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ENTDetalleVenta detalle = new ENTDetalleVenta
                {
                    TipoVenta = comboBox1.SelectedItem.ToString(),
                    Cantidad = Convert.ToInt32(txtcantidad.Text),
                    Subtotal = Convert.ToDecimal(txtsubtotal.Text),
                    Observaciones = txtobservaciones.Text,
                    FechaRegistro = dtpfecharegistro.Value
                };

                if (comboBox1.SelectedItem.ToString() == "Directa")
                {
                    detalle.IdVenta = Convert.ToInt32(txtidventa.Text);
                }
                else
                {
                    detalle.IdVentaCredito = Convert.ToInt32(txtidventa.Text);
                }

                if (dataGridView1.CurrentRow != null)
                {
                    detalle.IdProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdProducto"].Value);
                }

                LOGDetalleVenta.Instancia.InsertarDetalleVenta(detalle);
                MessageBox.Show("Detalle de venta registrado correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar detalle de venta: " + ex.Message);
            }

            Limpiar();
            groupBox1.Enabled = false;
            ListarDetalleVenta();
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            Limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnagregar.Visible = true;
            Limpiar();
        }

        private void btndeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar este detalle de venta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idDetalle = Convert.ToInt32(dataGridView2.CurrentRow.Cells["IdDetalle"].Value);
                        LOGDetalleVenta.Instancia.EliminarDetalleVenta(idDetalle);
                        MessageBox.Show("Detalle de venta eliminado correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarDetalleVenta();

                        comboBox1_SelectedIndexChanged(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un detalle de venta para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetalleVenta_Load(object sender, EventArgs e)
        {

        }
    }
}
