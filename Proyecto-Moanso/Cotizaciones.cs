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

namespace Proyecto_Moanso
{
    public partial class Cotizaciones : Form
    {
        public Cotizaciones()
        {
            InitializeComponent();
            CargarProveedores();
            CargarRequerimientos();
            CargarEstados();
            ListarCotizaciones();
            groupBox1.Enabled = false;
        }

        private void CargarRequerimientos()
        {
            cbxrequerimiento.DataSource = LOGRequerimientoProductos.Instancia.ListarRequerimientoProducto();
            cbxrequerimiento.DisplayMember = "IdRequerimiento";
            cbxrequerimiento.ValueMember = "IdRequerimiento";
        }

        private void CargarProveedores()
        {
            cbxproveedor.DataSource = LOGProveedor.Instancia.ListarProveedor();
            cbxproveedor.DisplayMember = "RazonSocial";
            cbxproveedor.ValueMember = "IdProveedor";
        }
        private void CargarEstados()
        {
            cbxestado.Items.Clear();
            cbxestado.Items.Add("PENDIENTE");
            cbxestado.Items.Add("APROBADA");
            cbxestado.Items.Add("RECHAZADA");
            cbxestado.SelectedIndex = 0;
        }
        private void ListarCotizaciones()
        {
            dataGridView1.DataSource = LOGCotizaciones.Instancia.ListarCotizaciones();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxrequerimiento.SelectedItem != null)
            {
                ENTRequerimientoProductos requerimientoSeleccionado = (ENTRequerimientoProductos)cbxrequerimiento.SelectedItem;
                txtmontototal.Text = requerimientoSeleccionado.Subtotal.ToString("0.00");
            }
        }
        private void Limpiar()
        {
            cbxproveedor.SelectedIndex = 0;
            dtpcotizaciones.Value = DateTime.Now;
            dtpvencimiento.Value = DateTime.Now.AddDays(7);
            txtmontototal.Clear();
            cbxestado.SelectedIndex = 0;
            txtobservaciones.Clear();
            dtpregistro.Value = DateTime.Now;
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENTCotizaciones cot = new ENTCotizaciones
                {
                    IdProveedor = Convert.ToInt32(cbxproveedor.SelectedValue),
                    IdRequerimiento = Convert.ToInt32(cbxrequerimiento.SelectedValue),
                    FechaCotizacion = dtpcotizaciones.Value,
                    FechaVencimiento = dtpvencimiento.Value,
                    MontoTotal = decimal.Parse(txtmontototal.Text),
                    Estado = cbxestado.SelectedItem.ToString(),
                    Observaciones = txtobservaciones.Text,
                    FechaRegistro = dtpregistro.Value
                };

                LOGCotizaciones.Instancia.InsertarCotizaciones(cot);
                MessageBox.Show("Cotización registrada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar cotización: " + ex.Message);
            }

            Limpiar();
            groupBox1.Enabled = false;
            ListarCotizaciones();
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
                DialogResult result = MessageBox.Show("¿Deseas eliminar esta cotización?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idCotizacion = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdCotizacion"].Value);
                        LOGCotizaciones.Instancia.EliminarCotizaciones(idCotizacion);
                        MessageBox.Show("Cotización eliminada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarCotizaciones();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una cotización para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnagregar.Visible = true;
            Limpiar();
        }
    }
}
