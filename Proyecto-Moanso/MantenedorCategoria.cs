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
        public MantenedorCategoria()
        {
            InitializeComponent();
            Listarcategoria();
        }

        private void Listarcategoria()
        {
            dataGridView1.DataSource = LOGCategoria.Instancia.ListarCategoria();


        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                ENTCategoria cat = new ENTCategoria

                {
                    NombreCategoria = txtNombreCategoria.Text,
                    Estado = ckhEstado.Checked

                }
            }

        }
    }
}
