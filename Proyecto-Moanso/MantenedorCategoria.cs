using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Moanso
{
    public partial class MantenedorCategoria : Form
    {
        private int idCategoriaSeleccionado = -1;   

        public MantenedorCategoria()
        {
            InitializeComponent();
            Listarcategoria();
            LimpiarVariales();
        }

        private void LimpiarVariales()
        {
            txtNombreCategoria.Clear();
            txtDescripcion.Clear();
            ckhEstado.Checked = false;
            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaRegistro.Value = DateTime.Now;

        }

        private void Listarcategoria()
        {
            dataGridView1.DataSource = LOGCategoria.Instancia.ListarCategoria();


        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENTCategoria cat = new ENTCategoria();


                cat.NombreCategoria = txtNombreCategoria.Text;
                cat.Descripcion = txtDescripcion.Text;
                cat.Estado = ckhEstado.Checked;
                cat.FechaCreacion = dtpFechaCreacion.Value;
                cat.FechaRegistro = dtpFechaRegistro.Value;

                LOGCategoria.Instancia.InsertarCategoria(cat);
                MessageBox.Show("Se agrego categoria correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
            }

            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            LimpiarVariales();
            groupBox1.Enabled = false;
            Listarcategoria();

        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {

            try
            {
                if (idCategoriaSeleccionado == -1)
                {
                    MessageBox.Show("Debe seleccionar una Categoria para modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ENTCategoria cat = new ENTCategoria();
                cat.NombreCategoria = txtNombreCategoria.Text;
                cat.Descripcion = txtDescripcion.Text;
                cat.Estado = ckhEstado.Checked;
                cat.FechaCreacion = dtpFechaCreacion.Value;
                cat.FechaRegistro = dtpFechaRegistro.Value;

                LOGCategoria.Instancia.EditarCategoria(cat);
                MessageBox.Show("Se modificó correctamente la categoria n", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            LimpiarVariales();
            groupBox1.Enabled = false;
            Listarcategoria();

            idCategoriaSeleccionado = -1;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            LimpiarVariales();
        }

        private void btndeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este Categoria?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int idCategoria = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdCategoria"].Value);

                        LOGCategoria.Instancia.EliminarCategoria(idCategoria);
                        MessageBox.Show("Categoria eliminado correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Listarcategoria();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar Categoria: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una Categoria para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow fila = dataGridView1.CurrentRow;

                idCategoriaSeleccionado = Convert.ToInt32(fila.Cells["idCategoria"]);
                txtNombreCategoria.Text = fila.Cells["NombreCategoria"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                ckhEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);
                dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
                dtpFechaRegistro.Value = Convert.ToDateTime(fila.Cells["FechaRegistro"].Value);

                groupBox1.Enabled = true;
                btnagregar.Visible = false;
                btnmodificar.Visible = true;
            }
        }
    }
}

