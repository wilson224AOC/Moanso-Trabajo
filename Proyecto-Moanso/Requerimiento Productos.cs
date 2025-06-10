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
    public partial class Requerimiento_Productos : Form
    {
        public Requerimiento_Productos()
        {
            InitializeComponent();
            CargarProductos();
            ListarRequerimiento();
            Limpiar();
        }

        private void Limpiar()
        {
            cbxproducto.SelectedIndex = 0;
            txtcantidad.Clear();
            txtsubtotal.Clear();
            txtcantidadrecibida.Clear();

        }

        private void ListarRequerimiento()
        {
            dataGridView1.DataSource = LOGRequerimientoProductos.Instancia.ListarRequerimientoProducto();
        }

        private void CargarProductos()
        {
            cbxproducto.DataSource = LOGProductos.Instancia.ListarProducto();
            cbxproducto.DisplayMember = "Codigo";
            cbxproducto.ValueMember = "IdProducto";
        }

        private void Requerimiento_Productos_Load(object sender, EventArgs e)
        {

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENTRequerimientoProductos req = new ENTRequerimientoProductos
                {
                    IdProducto = Convert.ToInt32(cbxproducto.SelectedValue),
                    Cantidad = Convert.ToInt32(txtcantidad.Text),
                    Subtotal = Convert.ToDecimal(txtsubtotal.Text),
                    CantidadRecibida = Convert.ToInt32(txtcantidadrecibida.Text),
                    Estado = chkestadorequerimiento.Checked
                };

                LOGRequerimientoProductos.Instancia.InsertarRequerimientoProducto(req);
                MessageBox.Show("Requerimiento registrada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar Requerimiento: " + ex.Message);
            }

            Limpiar();
            groupBox1.Enabled = false;
            ListarRequerimiento();
        }

        private void cbxproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxproducto.SelectedItem != null)
            {
                ENTProductos productoSeleccionado = (ENTProductos)cbxproducto.SelectedItem;
                textBox1.Text = productoSeleccionado.Nombre;
                txtsubtotal.Text = productoSeleccionado.PrecioVenta.ToString("0.00"); 
            }
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();

        }
        private void CalcularSubtotal()
        {
            if (cbxproducto.SelectedItem is ENTProductos productoSeleccionado &&
                int.TryParse(txtcantidad.Text, out int cantidad))
            {
                decimal subtotal = productoSeleccionado.PrecioVenta * cantidad;
                txtsubtotal.Text = subtotal.ToString("0.00");
            }
            else
            {
                txtsubtotal.Clear(); 
            }
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
                        int IdRequerimiento = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdRequerimiento"].Value);
                        LOGRequerimientoProductos.Instancia.DeshabilitaRequerimientoProducto(IdRequerimiento);
                        MessageBox.Show("Requerimiento eliminada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarRequerimiento();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un Requerimiento para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
