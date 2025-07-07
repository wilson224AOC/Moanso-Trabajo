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
    public partial class Interfaz_Ventas : Form
    {
        public Interfaz_Ventas()
        {
            InitializeComponent();
        }

        private void btnventacredito_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            VentaCredito formHijocredito = new VentaCredito();
            formHijocredito.TopLevel = false;
            formHijocredito.FormBorderStyle = FormBorderStyle.None;
            formHijocredito.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijocredito);
            formHijocredito.Show();
        }

        private void btnventadirecta_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            VentaDirecta formHijodirecta = new VentaDirecta();
            formHijodirecta.TopLevel = false;
            formHijodirecta.FormBorderStyle = FormBorderStyle.None;
            formHijodirecta.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijodirecta);
            formHijodirecta.Show();
        }

        private void btnempleado_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            MantenedorEmpleado formHijoempleado = new MantenedorEmpleado();
            formHijoempleado.TopLevel = false;
            formHijoempleado.FormBorderStyle = FormBorderStyle.None;
            formHijoempleado.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijoempleado);
            formHijoempleado.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            DetalleVenta formhijodetalle = new DetalleVenta();
            formhijodetalle.TopLevel = false;
            formhijodetalle.FormBorderStyle = FormBorderStyle.None;
            formhijodetalle.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formhijodetalle);
            formhijodetalle.Show();
        }

        private void btnformapago_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            MantenedorFormaPago formhijoformapago = new MantenedorFormaPago();
            formhijoformapago.TopLevel = false;
            formhijoformapago.FormBorderStyle = FormBorderStyle.None;
            formhijoformapago.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formhijoformapago);
            formhijoformapago.Show();
        }
    }
}
