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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Moanso
{
    public partial class RegistroContable : Form
    {
        List<ENTRegistroContable> listarregistro = new List<ENTRegistroContable>();

        public RegistroContable()
        {
            InitializeComponent();
            CargarTipoMovimiento();
            ListarRegistroContable();
        }

        private void ListarRegistroContable()
        {
            dgvregistro.DataSource = LOGRegistroContable.Instancia.ListarRegistrosContables();
            dgvregistroEliminar.DataSource = LOGRegistroContable.Instancia.ListarRegistrosContables();
        }

        private void CargarTipoMovimiento()
        {
            cbxtipomovimiento.Items.Clear();
            cbxtipomovimiento.Items.Add("Egreso");
            cbxtipomovimiento.Items.Add("Ingreso");
            cbxtipomovimiento.SelectedIndex = 0;
        }

        private void cbxtipomovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxtipomovimiento.SelectedItem != null)
            {
                string tipomovimiento = cbxtipomovimiento.SelectedItem.ToString();

                if (tipomovimiento == "Egreso")
                {
                    dgvmovimiento.DataSource = LOGEgresoFinanciero.Instancia.ListarEgresoFinanciero();
                }
                else if (tipomovimiento == "Ingreso")
                {
                    dgvmovimiento.DataSource = LOGIngresoFinanciero.Instancia.ListarIngresoFinanciero();
                }
            }
        }

        private void btnseleccionar_Click(object sender, EventArgs e)
        {
            if (dgvmovimiento.CurrentRow == null)
            {
                MessageBox.Show("Por favor selecciona un movimiento de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tipoSeleccionado = cbxtipomovimiento.SelectedItem?.ToString() ?? "";

                DataGridViewRow filaSeleccionada = dgvmovimiento.CurrentRow;

                switch (tipoSeleccionado)
                {
                    case "Ingreso":
                        txtid.Text = filaSeleccionada.Cells["IdIngreso"].Value?.ToString() ?? "";
                        txtmonto.Text = filaSeleccionada.Cells["Monto"].Value?.ToString() ?? "";
                        break;

                    case "Egreso":
                        txtid.Text = filaSeleccionada.Cells["IdEgreso"].Value?.ToString() ?? "";
                        txtmonto.Text = filaSeleccionada.Cells["Monto"].Value?.ToString() ?? "";
                        break;

                    default:
                        MessageBox.Show("Selecciona un tipo de movimiento válido en el ComboBox.", "Tipo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }


                MessageBox.Show("Datos cargados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al obtener los datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtmonto.Text))
                {
                    MessageBox.Show("Debe cargar datos de un movimiento primero usando el botón Seleccionar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ENTRegistroContable reg = new ENTRegistroContable
                {
                    TipoMovimiento = cbxtipomovimiento.SelectedItem.ToString(),
                    Descripcion = txtobservaciones.Text,
                    Fecha = dtpfecha.Value,
                    FechaRegistro = dtpfecharegistro.Value
                };

                if (cbxtipomovimiento.SelectedItem.ToString() == "Egreso")
                {
                    reg.IdEgreso = Convert.ToInt32(txtid.Text);
                }
                else
                {
                    reg.IdIngreso = Convert.ToInt32(txtid.Text);
                }

                LOGRegistroContable.Instancia.InsertarRegistroContable(reg);
                MessageBox.Show("Detalle de venta registrado correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar detalle de venta: " + ex.Message);
            }

            ListarRegistroContable();
        }

        private void txtidregistro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtidregistro.Text.Trim();

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    dgvregistroEliminar.DataSource = listarregistro;
                }
                else if (int.TryParse(filtro, out int idFiltrado))
                {
                    var resultado = listarregistro
                        .Where(i => i.IdIngreso.ToString().Contains(filtro))
                        .ToList();

                    dgvregistroEliminar.DataSource = resultado;
                }
                else
                {
                    dgvregistroEliminar.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar registro: " + ex.Message);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvregistroEliminar.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar este Registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idRegistro = Convert.ToInt32(dgvregistroEliminar.CurrentRow.Cells["IdRegistro"].Value);
                        LOGIngresoFinanciero.Instancia.EliminarIngresoFinanciero(idRegistro);
                        MessageBox.Show("Ingreso eliminada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarRegistroContable();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un registro para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
