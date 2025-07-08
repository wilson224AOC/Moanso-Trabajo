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
    public partial class MantenedorProductos : Form
    {
        private int idProductoSeleccionado = -1;

        public MantenedorProductos()
        {
            InitializeComponent();
            ListarProductos();
            groupBox1.Enabled = false;
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            cbxcategoria.DataSource = LOGCategoria.Instancia.ListarCategoria();
            cbxcategoria.DisplayMember = "NombreCategoria";
            cbxcategoria.ValueMember = "IdCategoria";
        }

        private void ListarProductos()
        {
            dataGridView1.DataSource = LOGProductos.Instancia.ListarProducto();
        }
        private void LimpiarVariables()
        {
            txtnombreproducto.Clear();
            txtdescripcion.Clear();
            txtcodigo.Clear();
            txtpreciocompra.Clear();
            txtprecioventa.Clear();
            txtstock.Clear();
            txtstockminimo.Clear();
            dtpfecharegistro.Value = DateTime.Now;
        }
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnagregar.Visible = true;
            btnmodificar.Visible = false;
            LimpiarVariables();
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENTProductos prod = new ENTProductos();
                prod.Nombre = txtnombreproducto.Text;
                prod.Descripcion = txtdescripcion.Text.Trim();
                prod.IdCategoria = Convert.ToInt32(cbxcategoria.SelectedValue);
                prod.Codigo = txtcodigo.Text.Trim();
                prod.PrecioCompra = Convert.ToDecimal(txtpreciocompra.Text.Trim());
                prod.PrecioVenta = Convert.ToDecimal(txtprecioventa.Text.Trim());
                prod.Stock = Convert.ToInt32(txtstock.Text.Trim());
                prod.StockMinimo = Convert.ToInt32(txtstockminimo.Text.Trim());
                prod.FechaRegistro = dtpfecharegistro.Value;

                LOGProductos.Instancia.InsertarProducto(prod);
                MessageBox.Show("Se registró correctamente el Producto", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            LimpiarVariables();
            groupBox1.Enabled = false;
            ListarProductos();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idProductoSeleccionado == -1)
                {
                    MessageBox.Show("Debe seleccionar un Producto para modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ENTProductos prod = new ENTProductos();
                prod.IdProducto = idProductoSeleccionado;
                prod.Nombre = txtnombreproducto.Text;
                prod.Descripcion = txtdescripcion.Text.Trim();
                prod.IdCategoria = Convert.ToInt32(cbxcategoria.SelectedValue);
                prod.Codigo = txtcodigo.Text.Trim();
                prod.PrecioCompra = Convert.ToDecimal(txtpreciocompra.Text.Trim());
                prod.PrecioVenta = Convert.ToDecimal(txtprecioventa.Text.Trim());
                prod.Stock = Convert.ToInt32(txtstock.Text.Trim());
                prod.StockMinimo = Convert.ToInt32(txtstockminimo.Text.Trim());
                prod.FechaRegistro = dtpfecharegistro.Value;

                LOGProductos.Instancia.EditarProducto(prod);
                MessageBox.Show("Se modificó correctamente el Producto", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            LimpiarVariables();
            groupBox1.Enabled = false;
            ListarProductos();

            idProductoSeleccionado = -1;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            LimpiarVariables();
        }

        private void btndeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idProducto"].Value);

                        LOGProductos.Instancia.EliminarProducto(idProducto);
                        MessageBox.Show("Producto eliminado correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ListarProductos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar producto: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow fila = dataGridView1.CurrentRow;

                idProductoSeleccionado = Convert.ToInt32(fila.Cells["IdProducto"].Value);
                txtnombreproducto.Text = fila.Cells["Nombre"].Value.ToString();
                txtdescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                cbxcategoria.SelectedItem = Convert.ToInt32(fila.Cells["IdCategoria"].Value);
                txtcodigo.Text = fila.Cells["Codigo"].Value.ToString();
                txtpreciocompra.Text = fila.Cells["PrecioCompra"].Value.ToString();
                txtprecioventa.Text = fila.Cells["PrecioVenta"].Value.ToString();
                txtstock.Text = fila.Cells["Stock"].Value.ToString();
                txtstockminimo.Text = fila.Cells["StockMinimo"].Value.ToString();
                dtpfecharegistro.Value = Convert.ToDateTime(fila.Cells["FechaRegistro"].Value);

                groupBox1.Enabled = true;
                btnagregar.Visible = false;
                btnmodificar.Visible = true;
            }
        }
    }
}
