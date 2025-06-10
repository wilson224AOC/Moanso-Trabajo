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
    public partial class Incidencias : Form
    {
        public Incidencias()
        {
            InitializeComponent();
            CargarIncidenciass();
            CargarEstados();
            ListarIncidencias();
            groupBox1.Enabled = false;
        }

        private void CargarEstados()
        {
            cbxestado.Items.Clear();
            cbxestado.Items.Add("ABIERTA");
            cbxestado.Items.Add("RESUELTA");
            cbxestado.Items.Add("CERRADA");
            cbxestado.SelectedIndex = 0;
        }

        private void CargarIncidenciass()
        {
            cbxnotaingreso.DataSource = LOGNotaEntrada.Instancia.ListarNotaIngreso();
            cbxnotaingreso.DisplayMember = "IdNotaIngreso";
            cbxnotaingreso.ValueMember = "IdNotaIngreso";
        }

        private void ListarIncidencias()
        {
            dataGridView1.DataSource = LOGIncidencias.Instancia.ListarIncidencias();
        }

        private void Limpiar()
        {
            txttipoincidencia.Clear();
            txtdescripcion.Clear();
            dtpincidencia.Value = DateTime.Now;
            dtpregistro.Value = DateTime.Now.AddDays(3);
            cbxestado.SelectedIndex = 0;
            txtobservaciones.Clear();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENTIncidencias inc = new ENTIncidencias
                {
                    IdNotaIngreso = (int)cbxnotaingreso.SelectedValue,
                    TipoIncidencia  = txttipoincidencia.Text,
                    Descripcion = txtdescripcion.Text,
                    FechaIncidencia = dtpincidencia.Value,
                    Estado = cbxestado.SelectedItem.ToString(),
                    Observaciones = txtobservaciones.Text,
                    FechaRegistro = dtpregistro.Value
                };

                LOGIncidencias.Instancia.InsertarIncidencias(inc);
                MessageBox.Show("Incidencias registrada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar Incidencias: " + ex.Message);
            }

            Limpiar();
            groupBox1.Enabled = false;
            ListarIncidencias();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            Limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnagregar.Visible = true;
            Limpiar();
        }

        private void btndeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar esta Incidencia?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int Idincidencias = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdIncidencia"].Value);
                        LOGIncidencias.Instancia.EliminarIncidencias(Idincidencias);
                        MessageBox.Show("Incidencia eliminada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarIncidencias();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una Incidencia para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
