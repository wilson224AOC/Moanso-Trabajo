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
    public partial class NotaSalida : Form
    {
        public NotaSalida()
        {
            InitializeComponent();
            CargarDetalleVenta();
            CargarTipoSalida();
            ListarNotaSalida();
            groupBox1.Enabled = false;
        }

        private void ListarNotaSalida()
        {
            dataGridView1.DataSource = LOGNotaSalida.Instancia.ListarNotaSalida();
        }

        private void CargarTipoSalida()
        {
            cbxtiposalida.Items.Clear();
            cbxtiposalida.Items.Add("VENTA");
            cbxtiposalida.Items.Add("DEVOLUCION");
            cbxtiposalida.Items.Add("AJUSTE");
            cbxtiposalida.SelectedIndex = 0;
        }

        private void CargarDetalleVenta()
        {
            cbxdetallesalida.DataSource = LOGDetalleVenta.Instancia.ListarDetalleVenta();
            cbxdetallesalida.DisplayMember = "IdDetalle";
            cbxdetallesalida.ValueMember = "IdDetalle";
        }
        private void Limpiar()
        {
            cbxdetallesalida.SelectedIndex = 0;
            dtpfechaSalida.Value = DateTime.Now;
            dtpfecharegistro.Value = DateTime.Now.AddDays(7);
            cbxtiposalida.SelectedIndex = 0;
            txtobservaciones.Clear();
        }
        private void label3_Click(object sender, EventArgs e)
        {

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
                DialogResult result = MessageBox.Show("¿Deseas eliminar esta Nota Salida?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idNotasalida = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdNotaSalida"].Value);
                        LOGNotaSalida.Instancia.EliminarNotaSalida(idNotasalida);
                        MessageBox.Show("Nota Salida eliminada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarNotaSalida();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnagregar.Visible = true;
            Limpiar();
        }

        private void btnagregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                ENTNotaSalida notS = new ENTNotaSalida
                {
                    IdDetalle = Convert.ToInt32(cbxdetallesalida.SelectedValue),
                    FechaSalida = dtpfechaSalida.Value,
                    TipoSalida = cbxtiposalida.SelectedItem.ToString(),
                    Observaciones = txtobservaciones.Text,
                    FechaRegistro = dtpfecharegistro.Value
                };

                LOGNotaSalida.Instancia.InsertarNotaSalida(notS);
                MessageBox.Show("Nota salida registrada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar Nota Salida: " + ex.Message);
            }

            Limpiar();
            groupBox1.Enabled = false;
            ListarNotaSalida();
        }
    }
}
