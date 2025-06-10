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
    public partial class MantenedorClientes : Form
    {
        private int idClienteSeleccionado = -1;

        public MantenedorClientes()
        {
            InitializeComponent();
            ListarCliente();
            groupBox1.Enabled = false;
        }
        private void ListarCliente()
        {
            dataGridView1.DataSource = LOGClientes.Instancia.ListarCliente();
        }
        private void LimpiarVariables()
        {
            cbxtipodocumento.SelectedIndex = -1;
            txtnumerodocumento.Clear();
            txttelefono.Clear();
            txtgmail.Clear();
            txtdireccion.Clear();
            dtpregistro.Value = DateTime.Now;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
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
                ENTClientes cli = new ENTClientes();
                cli.TipoDocumento = cbxtipodocumento.Text;
                cli.NumeroDocumento = txtnumerodocumento.Text.Trim();
                cli.Telefono = txttelefono.Text.Trim();
                cli.Gmail = txtgmail.Text.Trim();
                cli.Direccion = txtdireccion.Text.Trim();
                cli.FechaRegistro = dtpregistro.Value;

                LOGClientes.Instancia.InsertaCliente(cli);
                MessageBox.Show("Se registró correctamente el cliente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            LimpiarVariables();
            groupBox1.Enabled = false;
            ListarCliente();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idClienteSeleccionado == -1)
                {
                    MessageBox.Show("Debe seleccionar un cliente para modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ENTClientes cli = new ENTClientes();
                cli.IdCliente = idClienteSeleccionado;
                cli.TipoDocumento = cbxtipodocumento.Text;
                cli.NumeroDocumento = txtnumerodocumento.Text.Trim();
                cli.Telefono = txttelefono.Text.Trim();
                cli.Gmail = txtgmail.Text.Trim();
                cli.Direccion = txtdireccion.Text.Trim();
                cli.FechaRegistro = dtpregistro.Value;

                LOGClientes.Instancia.EditaCliente(cli);
                MessageBox.Show("Se modificó correctamente el cliente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            LimpiarVariables();
            groupBox1.Enabled = false;
            ListarCliente();

            idClienteSeleccionado = -1; 
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
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idCliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idCliente"].Value);

                        LOGClientes.Instancia.DeshabilitarCliente(idCliente);
                        MessageBox.Show("Cliente eliminado correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ListarCliente(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un cliente para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow fila = dataGridView1.CurrentRow;

                idClienteSeleccionado = Convert.ToInt32(fila.Cells["idCliente"].Value); 

                cbxtipodocumento.Text = fila.Cells["TipoDocumento"].Value.ToString();
                txtnumerodocumento.Text = fila.Cells["NumeroDocumento"].Value.ToString();
                txttelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtgmail.Text = fila.Cells["Gmail"].Value.ToString();
                txtdireccion.Text = fila.Cells["Direccion"].Value.ToString();
                dtpregistro.Value = Convert.ToDateTime(fila.Cells["FechaRegistro"].Value);

                groupBox1.Enabled = true;
                btnagregar.Visible = false;
                btnmodificar.Visible = true;
            }
        }
    }
}
