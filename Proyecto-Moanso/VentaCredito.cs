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
    public partial class VentaCredito : Form
    {
        private Dictionary<int, decimal> productosDiccionario = new Dictionary<int, decimal>();

        public VentaCredito()
        {
            InitializeComponent();
            CargarProductos();
            CargarEmpleados();
            CargarEstados();
            groupBox1.Enabled = false;
            ListarVentasCredito();
        }
        private void CargarProductos()
        {
            cbxIdProducto.DataSource = LOGProductos.Instancia.ListarProducto(); // Retorna lista de ENTProducto
            cbxIdProducto.DisplayMember = "Nombre";
            cbxIdProducto.ValueMember = "IdProducto";

            productosDiccionario.Clear();
            foreach (ENTProductos prod in cbxIdProducto.Items)
            {
                productosDiccionario[prod.IdProducto] = prod.PrecioVenta;
            }
        }
        private void CargarEmpleados()
        {
            cbxempleado.DataSource = LOGEmpleado.Instancia.ListarEmpleado(); // Asumiendo que tienes esta clase
            cbxempleado.DisplayMember = "NombreEmpleado"; // o el campo que corresponda
            cbxempleado.ValueMember = "IdEmpleado";
        }
        private void CargarEstados()
        {
            cbxEstado.Items.Clear();
            cbxEstado.Items.Add("Pendiente");
            cbxEstado.Items.Add("Pagado");
            cbxEstado.Items.Add("Vencido");
            cbxEstado.SelectedIndex = 0; 
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cbxIdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularMontos();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularMontos();
        }

        private void txtMontoPagado_TextChanged(object sender, EventArgs e)
        {
            CalcularSaldoPendiente();
        }
        private void CalcularMontos()
        {
            if (cbxIdProducto.SelectedItem != null && int.TryParse(txtCantidad.Text, out int cantidad))
            {
                ENTProductos producto = (ENTProductos)cbxIdProducto.SelectedItem;
                decimal precio = producto.PrecioVenta;
                decimal montoCredito = precio * cantidad;

                txtMontoCredito.Text = montoCredito.ToString("0.00");
                CalcularSaldoPendiente();
                ActualizarListBox();
            }
        }
        private void CalcularSaldoPendiente()
        {
            if (decimal.TryParse(txtMontoCredito.Text, out decimal montoCredito) &&
                decimal.TryParse(txtMontoPagado.Text, out decimal montoPagado))
            {
                decimal saldoPendiente = montoCredito - montoPagado;
                txtSaldoPendiente.Text = saldoPendiente.ToString("0.00");

                // Actualizar estado automáticamente según el saldo
                if (saldoPendiente <= 0)
                {
                    cbxEstado.SelectedItem = "Pagado";
                }
                else if (dtpFechaVencimiento.Value < DateTime.Now && saldoPendiente > 0)
                {
                    cbxEstado.SelectedItem = "Vencido";
                }
                else
                {
                    cbxEstado.SelectedItem = "Pendiente";
                }
            }
        }
        private void ActualizarListBox()
        {
            if (cbxIdProducto.SelectedItem != null && int.TryParse(txtCantidad.Text, out int cantidad))
            {
                ENTProductos producto = (ENTProductos)cbxIdProducto.SelectedItem;
                decimal montoCredito = decimal.Parse(txtMontoCredito.Text);
                decimal montoPagado = string.IsNullOrEmpty(txtMontoPagado.Text) ? 0 : decimal.Parse(txtMontoPagado.Text);
                decimal saldoPendiente = decimal.Parse(txtSaldoPendiente.Text);

                listBox1.Items.Clear();
                listBox1.Items.Add($"Producto: {producto.Nombre}");
                listBox1.Items.Add($"Cantidad: {cantidad}");
                listBox1.Items.Add($"Monto Crédito: S/ {montoCredito:0.00}");
                listBox1.Items.Add($"Monto Pagado: S/ {montoPagado:0.00}");
                listBox1.Items.Add($"Saldo Pendiente: S/ {saldoPendiente:0.00}");
                listBox1.Items.Add($"Estado: {cbxEstado.SelectedItem}");
                listBox1.Items.Add($"Vencimiento: {dtpFechaVencimiento.Value.ToShortDateString()}");
            }
        }

        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            CalcularSaldoPendiente();
            ActualizarListBox();
        }

        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarListBox();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                MessageBox.Show("Verifica los datos ingresados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ENTProductos producto = (ENTProductos)cbxIdProducto.SelectedItem;
            ENTEmpleado empleado = (ENTEmpleado)cbxempleado.SelectedItem;

            int cantidad = int.Parse(txtCantidad.Text);
            decimal montoCredito = decimal.Parse(txtMontoCredito.Text);
            decimal montoPagado = string.IsNullOrEmpty(txtMontoPagado.Text) ? 0 : decimal.Parse(txtMontoPagado.Text);
            decimal saldoPendiente = decimal.Parse(txtSaldoPendiente.Text);

            try
            {
                ENTVentaCredito ventaCredito = new ENTVentaCredito
                {
                    IdProducto = producto.IdProducto,
                    Cantidad = cantidad,
                    MontoCredito = montoCredito,
                    FechaVencimiento = dtpFechaVencimiento.Value,
                    MontoPagado = montoPagado,
                    SaldoPendiente = saldoPendiente,
                    Estado = cbxEstado.SelectedItem.ToString(),
                    FechaRegistro = dtpFechaRegistro.Value,
                    IdEmpleado = empleado.IdEmpleado
                };

                bool resultado = DATVentaCredito.Instancia.InsertarVentaCredito(ventaCredito);

                if (resultado)
                {
                    MessageBox.Show("Venta a crédito registrada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    ListarVentasCredito();
                }
                else
                {
                    MessageBox.Show("Error al registrar la venta a crédito", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar venta a crédito: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarDatos()
        {
            if (cbxIdProducto.SelectedItem == null)
                return false;

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                return false;

            if (cbxempleado.SelectedItem == null)
                return false;

            if (dtpFechaVencimiento.Value <= DateTime.Now)
            {
                MessageBox.Show("La fecha de vencimiento debe ser posterior a la fecha actual", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Limpiar()
        {
            txtCantidad.Clear();
            txtMontoCredito.Clear();
            txtMontoPagado.Clear();
            txtSaldoPendiente.Clear();
            listBox1.Items.Clear();
            dtpFechaVencimiento.Value = DateTime.Now.AddDays(30); 
            dtpFechaRegistro.Value = DateTime.Now;
            cbxEstado.SelectedIndex = 0; 

            if (cbxIdProducto.Items.Count > 0)
                cbxIdProducto.SelectedIndex = 0;
            if (cbxempleado.Items.Count > 0)
                cbxempleado.SelectedIndex = 0;
        }

        private void ListarVentasCredito()
        {
            try
            {
                dataGridView1.DataSource = DATVentaCredito.Instancia.ListarVentaCredito();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ventas a crédito: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnagregar.Visible = true;
            Limpiar();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            Limpiar();
        }

        private void btndeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de deshabilitar esta venta a crédito?",
                    "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idVentaCredito = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdVentaCredito"].Value);
                        DATVentaCredito.Instancia.DeshabilitaVentaCredito(idVentaCredito);
                        MessageBox.Show("Venta a crédito deshabilitada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarVentasCredito();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al deshabilitar la venta: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una venta para deshabilitar", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];   
            }
        }
        private void VentaCredito_Load(object sender, EventArgs e)
        {
            // Configuración inicial del formulario
            dtpFechaRegistro.Value = DateTime.Now;
            dtpFechaVencimiento.Value = DateTime.Now.AddDays(30);
        }
    }
}
