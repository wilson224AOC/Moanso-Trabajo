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
    public partial class MantenedorProveedor : Form
    {
        private int idProveedorSeleccionado = -1;
        public MantenedorProveedor()
        {
            InitializeComponent();
            ListarProveedor();
            groupBox1.Enabled = false;
        }

        private void ListarProveedor()
        {
            dataGridView1.DataSource = LOGProveedor.Instancia.ListarProveedor();
        }
        private void LimpiarVariables()
        {
            txtrazonsocial.Clear();
            txtruc.Clear();
            txttelefono.Clear();
            txtgmail.Clear();
            txtdireccion.Clear();
            dtpfecharegistro.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
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
                ENTProveedor prov = new ENTProveedor();
                prov.RazonSocial = txtrazonsocial.Text;
                prov.RUC = txtruc.Text.Trim();
                prov.Telefono = txttelefono.Text.Trim();
                prov.Gmail = txtgmail.Text.Trim();
                prov.Direccion = txtdireccion.Text.Trim();
                prov.FechaRegistro = dtpfecharegistro.Value;

                LOGProveedor.Instancia.InsertarProveedor(prov);
                MessageBox.Show("Se registró correctamente el proveedor", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            LimpiarVariables();
            groupBox1.Enabled = false;
            ListarProveedor();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idProveedorSeleccionado == -1)
                {
                    MessageBox.Show("Debe seleccionar un proveedor para modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ENTProveedor prov = new ENTProveedor();
                prov.IdProveedor = idProveedorSeleccionado;
                prov.RazonSocial = txtrazonsocial.Text;
                prov.RUC = txtruc.Text.Trim();
                prov.Telefono = txttelefono.Text.Trim();
                prov.Gmail = txtgmail.Text.Trim();
                prov.Direccion = txtdireccion.Text.Trim();
                prov.FechaRegistro = dtpfecharegistro.Value;

                LOGProveedor.Instancia.EditarProveedor(prov);
                MessageBox.Show("Se modificó correctamente el poveedor", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            LimpiarVariables();
            groupBox1.Enabled = false;
            ListarProveedor();

            idProveedorSeleccionado = -1;
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
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idProveedor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idProveedor"].Value);

                        LOGProveedor.Instancia.EliminarProveedor(idProveedor);
                        MessageBox.Show("Proveedor eliminado correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ListarProveedor();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar proveedor: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un proveedor para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow fila = dataGridView1.CurrentRow;

                idProveedorSeleccionado = Convert.ToInt32(fila.Cells["IdProveedor"].Value);
                txtrazonsocial.Text = fila.Cells["RazonSocial"].Value.ToString();
                txtruc.Text = fila.Cells["RUC"].Value.ToString();
                txttelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtgmail.Text = fila.Cells["Gmail"].Value.ToString();
                txtdireccion.Text = fila.Cells["Direccion"].Value.ToString();
                dtpfecharegistro.Value = Convert.ToDateTime(fila.Cells["FechaRegistro"].Value);

                groupBox1.Enabled = true;
                btnagregar.Visible = false;
                btnmodificar.Visible = true;
            }
        }
    }
}
