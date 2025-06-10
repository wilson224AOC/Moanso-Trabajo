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
    public partial class MantenedorEmpleado : Form
    {
        private int idEmpleadoSeleccionado = -1;

        public MantenedorEmpleado()
        {
            InitializeComponent();
            ListarEmpleado();
            groupBox1.Enabled = false;
        }

        private void ListarEmpleado()
        {
            dataGridView1.DataSource = LOGEmpleado.Instancia.ListarEmpleado();
        }
        private void LimpiarVariables()
        {
            txtcargoempleado.Clear();
            txtgmail.Clear();
            txtnombreempleado.Clear();
            txtnumerodocumento.Clear();
            txttelefono.Clear();
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
                ENTEmpleado emp = new ENTEmpleado();
                emp.NombreEmpleado = txtnombreempleado.Text;
                emp.NumeroDocumento = txtnumerodocumento.Text.Trim();
                emp.CargoEmpleado = txtcargoempleado.Text.Trim();
                emp.Telefono = Convert.ToInt32(txttelefono.Text.Trim());
                emp.Gmail = txtgmail.Text.Trim();
                emp.FechaRegistro = dtpfecharegistro.Value;

                LOGEmpleado.Instancia.InsertarEmpleado(emp);
                MessageBox.Show("Se registró correctamente el Empleado", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            LimpiarVariables();
            groupBox1.Enabled = false;
            ListarEmpleado();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idEmpleadoSeleccionado == -1)
                {
                    MessageBox.Show("Debe seleccionar un Empleado para modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ENTEmpleado emp = new ENTEmpleado();
                emp.IdEmpleado = idEmpleadoSeleccionado;
                emp.NombreEmpleado = txtnombreempleado.Text;
                emp.NumeroDocumento = txtnumerodocumento.Text;
                emp.CargoEmpleado = txtcargoempleado.Text.Trim();
                emp.Gmail = txtgmail.Text.Trim();
                emp.Telefono = Convert.ToInt32(txttelefono.Text.Trim());
                emp.FechaRegistro = dtpfecharegistro.Value;

                LOGEmpleado.Instancia.EditarEmpleado(emp);
                MessageBox.Show("Se modificó correctamente el Empleado", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            LimpiarVariables();
            groupBox1.Enabled = false;
            ListarEmpleado();

            idEmpleadoSeleccionado = -1;
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
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idEmpleado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdEmpleado"].Value);

                        LOGEmpleado.Instancia.DeshabilitarEmpleado(idEmpleado);
                        MessageBox.Show("Empleado eliminado correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ListarEmpleado();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar Empleado: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un Empleado para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow fila = dataGridView1.CurrentRow;

                idEmpleadoSeleccionado = Convert.ToInt32(fila.Cells["IdEmpleado"].Value);
                txtnombreempleado.Text = fila.Cells["NombreEmpleado"].Value.ToString();
                txtnumerodocumento.Text = fila.Cells["NumeroDocumento"].Value.ToString();
                txtcargoempleado.Text = fila.Cells["CargoEmpleado"].Value.ToString();
                txtgmail.Text = fila.Cells["Gmail"].Value.ToString();
                txttelefono.Text = fila.Cells["Telefono"].Value.ToString();
                dtpfecharegistro.Value = Convert.ToDateTime(fila.Cells["FechaRegistro"].Value);

                groupBox1.Enabled = true;
                btnagregar.Visible = false;
                btnmodificar.Visible = true;
            }
        }
    }
}
