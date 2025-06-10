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
    public partial class Login : Form
    {
        private CheckBox chkMostrarPassword;
        private Dictionary<string, UsuarioInfo> usuarios = new Dictionary<string, UsuarioInfo>
        {
            //Financiero
            {"financiero@gmail.com", new UsuarioInfo("financiero", "financiero")},
            {"financiero2@gmail.com", new UsuarioInfo("financiero", "financiero")},
            
            //Almacén
            {"almacen@gmail.com", new UsuarioInfo("almacen", "almacen")},
            {"almacen2@gmail.com", new UsuarioInfo("almacen", "almacen")},
            
            //Ventas
            {"ventas@gmail.com", new UsuarioInfo("ventas", "ventas")},
            {"ventas2@gmail.com", new UsuarioInfo("ventas", "ventas")},
        };

        public Login()
        {
            InitializeComponent();
            ConfigurarPasswordYCheckBox();
        }

        private void ConfigurarPasswordYCheckBox()
        {
            textBox2.PasswordChar = '*';

            chkMostrarPassword = new CheckBox();
            chkMostrarPassword.Text = "Mostrar contraseña";
            chkMostrarPassword.Location = new Point(250, 270);
            chkMostrarPassword.Size = new Size(150, 20);
            chkMostrarPassword.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular);
            chkMostrarPassword.BackColor = Color.Transparent;
            chkMostrarPassword.ForeColor = Color.Black; // Asegurar que el texto sea visible

            chkMostrarPassword.Checked = false;

            chkMostrarPassword.CheckedChanged += cbxmostrarcontraseña_CheckedChanged;

            this.Controls.Add(chkMostrarPassword);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string correo = textBox1.Text.Trim().ToLower();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos Vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!correo.Contains("@") || !correo.Contains("."))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Formato de Email Incorrecto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuarios.ContainsKey(correo) && usuarios[correo].Password == password)
            {
                string modulo = usuarios[correo].Modulo;
                MessageBox.Show($"¡Bienvenido! Accediendo al módulo {modulo.ToUpper()}", "Login Exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                AbrirInterfazCorrespondiente(modulo);
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.\nVerifique sus credenciales.",
                    "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBox2.Clear();
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }

        private void AbrirInterfazCorrespondiente(string modulo)
        {
            try
            {
                Form interfazDestino = null;

                switch (modulo.ToLower())
                {
                    case "financiero":
                        interfazDestino = new Interfaz_Financiero();
                        break;
                    case "almacen":
                        interfazDestino = new Interfaz_Almacen();
                        break;
                    case "ventas":
                        interfazDestino = new Interfaz_Ventas();
                        break;
                    default:
                        MessageBox.Show("Módulo no encontrado.", "Error de Sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                this.Hide();
                interfazDestino.ShowDialog();

                this.Show();

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la interfaz: {ex.Message}\n\nDetalles técnicos:\n{ex.StackTrace}",
                    "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();

            if (chkMostrarPassword != null)
            {
                chkMostrarPassword.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea salir de la aplicación?",
                "Confirmar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cbxmostrarcontraseña_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus(); 
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e); 
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

            this.Text = "Login - Sistema Moanso";

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(textBox1, "Usuarios de prueba:\nfinanciero@gmail.com\nalmacen@gmail.com\nventas@gmail.com");
        }

        public class UsuarioInfo
        {
            public string Password { get; set; }
            public string Modulo { get; set; }

            public UsuarioInfo(string password, string modulo)
            {
                Password = password;
                Modulo = modulo;
            }
        }
    }
}