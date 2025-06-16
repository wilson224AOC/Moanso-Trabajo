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
    public partial class Interfaz_Almacen : Form
    {
        public Interfaz_Almacen()
        {
            InitializeComponent();
        }

        private void btnproducto_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            MantenedorProductos formHijoproducto = new MantenedorProductos();
            formHijoproducto.TopLevel = false;
            formHijoproducto.FormBorderStyle = FormBorderStyle.None;
            formHijoproducto.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijoproducto);
            formHijoproducto.Show();
        }

        private void btnordencompra_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            OrdenCompra formHijoordenc = new OrdenCompra();
            formHijoordenc.TopLevel = false;
            formHijoordenc.FormBorderStyle = FormBorderStyle.None;
            formHijoordenc.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijoordenc);
            formHijoordenc.Show();
        }

        private void btnproveedor_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            MantenedorProveedor formHijoproveedor = new MantenedorProveedor();
            formHijoproveedor.TopLevel = false;
            formHijoproveedor.FormBorderStyle = FormBorderStyle.None;
            formHijoproveedor.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijoproveedor);
            formHijoproveedor.Show();
        }

        private void btnincidencias_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            Incidencias formHijoincidencias = new Incidencias();
            formHijoincidencias.TopLevel = false;
            formHijoincidencias.FormBorderStyle = FormBorderStyle.None;
            formHijoincidencias.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijoincidencias);
            formHijoincidencias.Show();
        }

        private void btnnotaentrada_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            NotaIngreso formHijonotaingreso = new NotaIngreso();
            formHijonotaingreso.TopLevel = false;
            formHijonotaingreso.FormBorderStyle = FormBorderStyle.None;
            formHijonotaingreso.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijonotaingreso);
            formHijonotaingreso.Show();
        }

        private void btnrequerimiento_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            Requerimiento_Productos formHijorequerimiento = new Requerimiento_Productos();
            formHijorequerimiento.TopLevel = false;
            formHijorequerimiento.FormBorderStyle = FormBorderStyle.None;
            formHijorequerimiento.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijorequerimiento);
            formHijorequerimiento.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            NotaSalida formHijonotasalida = new NotaSalida();
            formHijonotasalida.TopLevel = false;
            formHijonotasalida.FormBorderStyle = FormBorderStyle.None;
            formHijonotasalida.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijonotasalida);
            formHijonotasalida.Show();
        }
    }
}
