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
            if (dgvmovimiento.CurrentRow != null)
            {
                try
                {
                    string tipomovimiento = cbxtipomovimiento.SelectedItem?.ToString();

                    if (tipomovimiento == "Directa")
                    {
                        int idEgreso = Convert.ToInt32(dgvmovimiento.CurrentRow.Cells["IdEgreso"].Value);
                        txtid.Text = idEgreso.ToString();

                        txtmonto.Text = dgvmovimiento.CurrentRow.Cells["Monto"].Value.ToString();
                    }
                    else if (tipomovimiento == "Credito")
                    {
                        int idIngreso = Convert.ToInt32(dgvmovimiento.CurrentRow.Cells["IdIngreso"].Value);
                        txtid.Text = idIngreso.ToString();

                        txtmonto.Text = dgvmovimiento.CurrentRow.Cells["Monto"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Tipo de movimiento no reconocido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


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
