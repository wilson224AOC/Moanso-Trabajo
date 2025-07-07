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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Proyecto_Moanso
{
    public partial class Ingreso_Financiero : Form
    {
        #region Variables
        private List<ENTDetalleVenta> listaCompleta = new List<ENTDetalleVenta>();
        List<ENTIngresoFinanciero> listaIngresos = new List<ENTIngresoFinanciero>();

        #endregion

        #region Eventos de Carga
        public Ingreso_Financiero()
        {
            InitializeComponent();
            ConfigurarAutocompletado();
            ListarIngresoFinanciero();
            CargarIngresosFinancieros();
        }

        private void CargarIngresosFinancieros()
        {
            try
            {
                listaIngresos = DATIngresoFinanciero.Instancia.ListarIngresoFinanciero(); // o desde la capa lógica si usas LOGIngresoFinanciero
                dgvingresosEliminar.DataSource = listaIngresos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ingresos: " + ex.Message);
            }
        }
        private void ListarIngresoFinanciero()
        {
            dgvIngresosAgregar.DataSource = LOGIngresoFinanciero.Instancia.ListarIngresoFinanciero();
            dgvingresosEliminar.DataSource = LOGIngresoFinanciero.Instancia.ListarIngresoFinanciero();
        }

        private void Ingreso_Financiero_Load(object sender, EventArgs e)
        {
            CargarDetallesVenta();
        }
        #endregion
        #region Métodos de Configuración
        private void ConfigurarAutocompletado()
        {
            try
            {
                AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

                List<ENTDetalleVenta> detalles = DATDetalleVenta.Instancia.ListarDetalleVenta();

                foreach (var detalle in detalles)
                {
                    autoComplete.Add(detalle.IdDetalle.ToString());
                    autoComplete.Add(detalle.Subtotal.ToString());
                }

                txtbuscardetalle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtbuscardetalle.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtbuscardetalle.AutoCompleteCustomSource = autoComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar autocompletado: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Métodos de Carga de Datos
        private void CargarDetallesVenta()
        {
            try
            {
                listaCompleta = DATDetalleVenta.Instancia.ListarDetalleVenta();

                dgvDetalles.DataSource = listaCompleta;

                ConfigurarColumnasDataGridView();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles de venta: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarColumnasDataGridView()
        {
            if (dgvDetalles.Columns.Count > 0)
            {
                dgvDetalles.Columns["IdDetalle"].HeaderText = "ID Detalle";
                dgvDetalles.Columns["IdDetalle"].Width = 80;

                dgvDetalles.Columns["IdProducto"].HeaderText = "Producto";
                dgvDetalles.Columns["IdProducto"].Width = 200;

                dgvDetalles.Columns["Subtotal"].HeaderText = "Subtotal";
                dgvDetalles.Columns["Subtotal"].Width = 100;
                dgvDetalles.Columns["Subtotal"].DefaultCellStyle.Format = "C2"; 

                dgvDetalles.Columns["FechaRegistro"].HeaderText = "FechaRegistro";
                dgvDetalles.Columns["FechaRegistro"].Width = 120;
                dgvDetalles.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgvDetalles.Columns.Contains("Observaciones"))
                {
                    dgvDetalles.Columns["Observaciones"].HeaderText = "Observaciones";
                    dgvDetalles.Columns["Observaciones"].Width = 250;
                }

                dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDetalles.MultiSelect = false;
            }
        }
        #endregion
        #region Eventos de Búsqueda
        private void txtbuscardetalle_TextChanged(object sender, EventArgs e)
        {
            FiltrarDetalles();
        }
        private void FiltrarDetalles()
        {
            try
            {
                string filtro = txtbuscardetalle.Text.ToLower().Trim();

                if (string.IsNullOrEmpty(filtro))
                {
                    dgvDetalles.DataSource = listaCompleta;
                }
                else
                {
                    var listaFiltrada = listaCompleta.Where(d =>
                        d.IdDetalle.ToString().Contains(filtro) ||
                        d.IdProducto.ToString().Contains(filtro) ||
                        (!string.IsNullOrEmpty(d.Observaciones) && d.Observaciones.ToLower().Contains(filtro)) ||
                        d.Subtotal.ToString().Contains(filtro)
                    ).ToList();

                    dgvDetalles.DataSource = listaFiltrada;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void vtnbuscar_Click(object sender, EventArgs e)
        {
            FiltrarDetalles();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                try
                {

                    txtdetalleventa.Text = dgvDetalles.CurrentRow.Cells["IdDetalle"].Value.ToString();
                    txtmonto.Text = dgvDetalles.CurrentRow.Cells["Subtotal"].Value.ToString();

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
                ENTIngresoFinanciero ingreso = new ENTIngresoFinanciero();

                ingreso.IdDetalle = Convert.ToInt32(txtdetalleventa.Text.Trim());
                ingreso.FechaIngreso = dtpfechaingreso.Value;
                ingreso.Monto = decimal.Parse(txtmonto.Text);
                ingreso.Concepto = txtconcepto.Text;
                ingreso.Observaciones = txtobservaciones.Text;
                ingreso.FechaRegistro = dtpfecharegistro.Value;

                LOGIngresoFinanciero.Instancia.InsertarIngresoFinanciero(ingreso);
                MessageBox.Show("Egreso registrada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar Egreso: " + ex.Message);
            }

            ListarIngresoFinanciero();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = textBox6.Text.Trim();

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    dgvingresosEliminar.DataSource = listaIngresos;
                }
                else if (int.TryParse(filtro, out int idFiltrado))
                {
                    var resultado = listaIngresos
                        .Where(i => i.IdIngreso.ToString().Contains(filtro)) 
                        .ToList();

                    dgvingresosEliminar.DataSource = resultado;
                }
                else
                {
                    dgvingresosEliminar.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar ingresos: " + ex.Message);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvingresosEliminar.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar este ingreso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idIngreso = Convert.ToInt32(dgvingresosEliminar.CurrentRow.Cells["IdIngreso"].Value);
                        LOGIngresoFinanciero.Instancia.EliminarIngresoFinanciero(idIngreso);
                        MessageBox.Show("Ingreso eliminada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarIngresoFinanciero();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un ingreso para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
