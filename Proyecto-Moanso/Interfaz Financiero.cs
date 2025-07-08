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
    public partial class Interfaz_Financiero : Form
    {
        public Interfaz_Financiero()
        {
            InitializeComponent();
        }

        private void btncotizaciones_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            Cotizaciones formHijocotizaciones = new Cotizaciones();
            formHijocotizaciones.TopLevel = false;
            formHijocotizaciones.FormBorderStyle = FormBorderStyle.None;
            formHijocotizaciones.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijocotizaciones);
            formHijocotizaciones.Show();
        }

        private void btnegreso_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            EgresoFrinanciero formHijoegreso = new EgresoFrinanciero();
            formHijoegreso.TopLevel = false;
            formHijoegreso.FormBorderStyle = FormBorderStyle.None;
            formHijoegreso.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijoegreso);
            formHijoegreso.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            Ingreso_Financiero formHijoingreso = new Ingreso_Financiero();
            formHijoingreso.TopLevel = false;
            formHijoingreso.FormBorderStyle = FormBorderStyle.None;
            formHijoingreso.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijoingreso);
            formHijoingreso.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            RegistroContable formHijoregistro = new RegistroContable();
            formHijoregistro.TopLevel = false;
            formHijoregistro.FormBorderStyle = FormBorderStyle.None;
            formHijoregistro.Dock = DockStyle.Fill;

            groupBox1.Controls.Add(formHijoregistro);
            formHijoregistro.Show();
        }
    }
}
