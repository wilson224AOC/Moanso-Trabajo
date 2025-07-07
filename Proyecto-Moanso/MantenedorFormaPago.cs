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
    public partial class MantenedorFormaPago : Form
    {
        private int idformapagoseleccionado = -1;

        public MantenedorFormaPago()
        {
            InitializeComponent();
            ListarFormaPago();
            groupBox1.Enabled = false;
            txtdatosbancarios.Enabled = false;
        }

        private void ListarFormaPago()
        {
            dataGridView1.DataSource = LOGFormaPago.Instancia.ListarFormaPago();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnagregar.Visible = true;
            btnmodificar.Visible = false;
        }

        private void cbxdatosb_CheckedChanged(object sender, EventArgs e)
        {
            txtdatosbancarios.Enabled = chkdatos.Checked;

            if (!chkdatos.Checked)
                txtdatosbancarios.Text = "";
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENTFormaPago fp = new ENTFormaPago();
                fp.Nombre = txtnombre.Text.Trim();
                fp.Descripcion = txtdescripcion.Text.Trim();
                fp.DatosBancarios = chkdatos.Checked;
                fp.DatosBa = txtdatosbancarios.Text.Trim();
                fp.Estado = chkEstado.Checked;
                fp.FechaCreacion = dateTimePicker1  .Value;

                LOGFormaPago.Instancia.InsertarFormaPago(fp);

                MessageBox.Show("Se registró correctamente la forma de pago", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            txtnombre.Clear();
            txtdescripcion.Clear();
            txtdatosbancarios.Clear();
            chkdatos.Checked = false;
            chkEstado.Checked = false;
            dateTimePicker1.Value = DateTime.Now;

            groupBox1.Enabled = false;
            ListarFormaPago();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idformapagoseleccionado == -1)
                {
                    MessageBox.Show("Debe seleccionar una forma de pago para modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ENTFormaPago fp = new ENTFormaPago();
                fp.Nombre = txtnombre.Text.Trim();
                fp.Descripcion = txtdescripcion.Text.Trim();
                fp.DatosBancarios = chkdatos.Checked;
                fp.DatosBa = txtdatosbancarios.Text.Trim();
                fp.Estado = chkEstado.Checked;
                fp.FechaCreacion = dateTimePicker1.Value;

                LOGFormaPago.Instancia.InsertarFormaPago(fp);

                MessageBox.Show("Se modifico correctamente la forma de pago", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            txtnombre.Clear();
            txtdescripcion.Clear();
            txtdatosbancarios.Clear();
            chkdatos.Checked = false;
            chkEstado.Checked = false;
            dateTimePicker1.Value = DateTime.Now;

            groupBox1.Enabled = false;
            ListarFormaPago();
            idformapagoseleccionado = -1;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
        }

        private void btndeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta formapago?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idFormapago = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idFormapago"].Value);

                        LOGProductos.Instancia.EliminarProducto(idFormapago);
                        MessageBox.Show("forma de pago eliminado correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ListarFormaPago();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar forma de pago: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una forma de pago para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow fila = dataGridView1.CurrentRow;

                idformapagoseleccionado = Convert.ToInt32(fila.Cells["IdFormaPago"].Value);
                txtnombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtdescripcion.Text = fila.Cells["Descripcion"].Value.ToString();

                string datosB = fila.Cells["DatosBancarios"].Value.ToString();
                if (!string.IsNullOrWhiteSpace(datosB))
                {
                    chkdatos.Checked = true;
                    txtdatosbancarios.Text = datosB;
                    txtdatosbancarios.Enabled = true;
                }
                else
                {
                    chkdatos.Checked = false;
                    txtdatosbancarios.Text = "";
                    txtdatosbancarios.Enabled = false;
                }

                chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);
                dateTimePicker1.Value = Convert.ToDateTime(fila.Cells["FechaRegistro"].Value);

                groupBox1.Enabled = true;
                btnagregar.Visible = false;
                btnmodificar.Visible = true;
            }
        }
    }
}
