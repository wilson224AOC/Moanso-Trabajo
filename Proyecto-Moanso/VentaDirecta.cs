﻿using System;
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
    public partial class VentaDirecta : Form
    {
        private Dictionary<int, decimal> productosDiccionario = new Dictionary<int, decimal>();

        public VentaDirecta()
        {
            InitializeComponent();
            CargarProductos();
            CargarFormaPago();
            GenerarNumeroVenta();
            groupBox1.Enabled = false;
            ListarVentas();
        }

        private void CargarFormaPago()
        {
            cbxformapago.DataSource = LOGFormaPago.Instancia.ListarFormaPago();
            cbxformapago.DisplayMember = "Nombre";
            cbxformapago.ValueMember = "IdFormaPago";
        }
        private void GenerarNumeroVenta()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var codigo = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            txtnumeroventa.Text = codigo;
        }
        private void CargarProductos()
        {
            cbxproducto.DataSource = LOGProductos.Instancia.ListarProducto(); // Retorna lista de ENTProducto
            cbxproducto.DisplayMember = "Nombre";
            cbxproducto.ValueMember = "IdProducto";

            productosDiccionario.Clear();
            foreach (ENTProductos prod in cbxproducto.Items)
            {
                productosDiccionario[prod.IdProducto] = prod.PrecioVenta;
            }
        }

        private void cbxproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularMontoTotal();
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularMontoTotal();
        }
        private void CalcularMontoTotal()
        {
            if (cbxproducto.SelectedItem != null && int.TryParse(txtcantidad.Text, out int cantidad))
            {
                ENTProductos producto = (ENTProductos)cbxproducto.SelectedItem;
                decimal precio = producto.PrecioVenta;
                decimal montoTotal = precio * cantidad;

                txtmontototal.Text = montoTotal.ToString("0.00");

                listBox1.Items.Clear();
                listBox1.Items.Add($"Producto: {producto.Nombre}");
                listBox1.Items.Add($"Cantidad: {cantidad}");
                listBox1.Items.Add($"Monto Total: S/ {montoTotal:0.00}");
                listBox1.Items.Add($"Forma Pago: S/ {cbxformapago.SelectedItem}");
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (cbxproducto.SelectedItem == null || !int.TryParse(txtcantidad.Text, out int cantidad))
            {
                MessageBox.Show("Verifica los datos ingresados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ENTProductos producto = (ENTProductos)cbxproducto.SelectedItem;
            ENTFormaPago formapago = (ENTFormaPago)cbxformapago.SelectedItem;
            decimal precio = producto.PrecioVenta;
            decimal montoTotal = precio * cantidad;

            try
            {
                ENTVentaDirecta venta = new ENTVentaDirecta
                {
                    IdProducto = producto.IdProducto,
                    IdFormaPago = formapago.IdFormaPago,
                    Cantidad = cantidad,
                    NumeroVenta = txtnumeroventa.Text,
                    FechaVenta = dateTimePicker1.Value,
                    MontoTotal = montoTotal,
                    Observaciones = textBox2.Text,
                    FechaRegistro = dateTimePicker2.Value
                };

                LOGVentaDirecta.Instancia.InsertarVentaDirecta(venta);

                dataGridView1.Rows.Add(
                    venta.NumeroVenta,
                    producto.IdProducto,
                    producto.Nombre,
                    cantidad,
                    precio.ToString("0.00"),
                    montoTotal.ToString("0.00")
                );

                MessageBox.Show("Venta registrada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                ListarVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar venta: " + ex.Message);
            }
        }
        private void Limpiar()
        {
            txtcantidad.Clear();
            txtmontototal.Clear();
            textBox2.Clear();
            listBox1.Items.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            if (cbxformapago.Items.Count > 0)
                cbxformapago.SelectedIndex = 0;
            GenerarNumeroVenta();
        }
        private void ListarVentas()
        {
            dataGridView1.DataSource = LOGVentaDirecta.Instancia.ListarVentaDirecta(); 
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

        private void cbxformapago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btndeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de deshabilitar esta venta?",
                    "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int Idventa = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdVenta"].Value);
                        DATVentaDirecta.Instancia.DeshabilitaVentaDirecta(Idventa);
                        MessageBox.Show("Venta deshabilitada correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarVentas();
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
    }
}
