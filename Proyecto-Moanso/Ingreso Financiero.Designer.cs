namespace Proyecto_Moanso
{
    partial class Ingreso_Financiero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.vtnbuscar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbuscardetalle = new System.Windows.Forms.TextBox();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnagregar = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.dgvIngresosAgregar = new System.Windows.Forms.DataGridView();
            this.dtpfechaingreso = new System.Windows.Forms.DateTimePicker();
            this.dtpfecharegistro = new System.Windows.Forms.DateTimePicker();
            this.txtobservaciones = new System.Windows.Forms.TextBox();
            this.txtconcepto = new System.Windows.Forms.TextBox();
            this.txtmonto = new System.Windows.Forms.TextBox();
            this.txtdetalleventa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btneliminar = new System.Windows.Forms.Button();
            this.dgvingresosEliminar = new System.Windows.Forms.DataGridView();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresosAgregar)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvingresosEliminar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(930, 510);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.vtnbuscar);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtbuscardetalle);
            this.tabPage1.Controls.Add(this.dgvDetalles);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(922, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Buscar Detalle";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // vtnbuscar
            // 
            this.vtnbuscar.Location = new System.Drawing.Point(76, 102);
            this.vtnbuscar.Name = "vtnbuscar";
            this.vtnbuscar.Size = new System.Drawing.Size(75, 23);
            this.vtnbuscar.TabIndex = 4;
            this.vtnbuscar.Text = "Buscar";
            this.vtnbuscar.UseVisualStyleBackColor = true;
            this.vtnbuscar.Click += new System.EventHandler(this.vtnbuscar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Detalle";
            // 
            // txtbuscardetalle
            // 
            this.txtbuscardetalle.Location = new System.Drawing.Point(16, 74);
            this.txtbuscardetalle.Name = "txtbuscardetalle";
            this.txtbuscardetalle.Size = new System.Drawing.Size(164, 22);
            this.txtbuscardetalle.TabIndex = 1;
            this.txtbuscardetalle.TextChanged += new System.EventHandler(this.txtbuscardetalle_TextChanged);
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(204, 32);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.RowHeadersWidth = 51;
            this.dgvDetalles.RowTemplate.Height = 24;
            this.dgvDetalles.Size = new System.Drawing.Size(672, 414);
            this.dgvDetalles.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnagregar);
            this.tabPage2.Controls.Add(this.btnsalir);
            this.tabPage2.Controls.Add(this.btnnuevo);
            this.tabPage2.Controls.Add(this.dgvIngresosAgregar);
            this.tabPage2.Controls.Add(this.dtpfechaingreso);
            this.tabPage2.Controls.Add(this.dtpfecharegistro);
            this.tabPage2.Controls.Add(this.txtobservaciones);
            this.tabPage2.Controls.Add(this.txtconcepto);
            this.tabPage2.Controls.Add(this.txtmonto);
            this.tabPage2.Controls.Add(this.txtdetalleventa);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(922, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Agregar Ingreso Financiero";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(805, 56);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(75, 23);
            this.btnagregar.TabIndex = 11;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.Location = new System.Drawing.Point(805, 335);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(75, 23);
            this.btnsalir.TabIndex = 10;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            // 
            // btnnuevo
            // 
            this.btnnuevo.Location = new System.Drawing.Point(805, 256);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(75, 23);
            this.btnnuevo.TabIndex = 9;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = true;
            // 
            // dgvIngresosAgregar
            // 
            this.dgvIngresosAgregar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresosAgregar.Location = new System.Drawing.Point(47, 215);
            this.dgvIngresosAgregar.Name = "dgvIngresosAgregar";
            this.dgvIngresosAgregar.RowHeadersWidth = 51;
            this.dgvIngresosAgregar.RowTemplate.Height = 24;
            this.dgvIngresosAgregar.Size = new System.Drawing.Size(729, 245);
            this.dgvIngresosAgregar.TabIndex = 8;
            // 
            // dtpfechaingreso
            // 
            this.dtpfechaingreso.Location = new System.Drawing.Point(513, 42);
            this.dtpfechaingreso.Name = "dtpfechaingreso";
            this.dtpfechaingreso.Size = new System.Drawing.Size(200, 22);
            this.dtpfechaingreso.TabIndex = 7;
            // 
            // dtpfecharegistro
            // 
            this.dtpfecharegistro.Location = new System.Drawing.Point(513, 96);
            this.dtpfecharegistro.Name = "dtpfecharegistro";
            this.dtpfecharegistro.Size = new System.Drawing.Size(200, 22);
            this.dtpfecharegistro.TabIndex = 6;
            // 
            // txtobservaciones
            // 
            this.txtobservaciones.Location = new System.Drawing.Point(513, 153);
            this.txtobservaciones.Name = "txtobservaciones";
            this.txtobservaciones.Size = new System.Drawing.Size(154, 22);
            this.txtobservaciones.TabIndex = 5;
            // 
            // txtconcepto
            // 
            this.txtconcepto.Location = new System.Drawing.Point(141, 153);
            this.txtconcepto.Name = "txtconcepto";
            this.txtconcepto.Size = new System.Drawing.Size(192, 22);
            this.txtconcepto.TabIndex = 4;
            // 
            // txtmonto
            // 
            this.txtmonto.Location = new System.Drawing.Point(141, 96);
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.Size = new System.Drawing.Size(115, 22);
            this.txtmonto.TabIndex = 3;
            // 
            // txtdetalleventa
            // 
            this.txtdetalleventa.Location = new System.Drawing.Point(141, 42);
            this.txtdetalleventa.Name = "txtdetalleventa";
            this.txtdetalleventa.Size = new System.Drawing.Size(115, 22);
            this.txtdetalleventa.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Concepto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Monto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(405, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Observaciones:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Fecha Registro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fecha Ingreso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detalle Venta:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btneliminar);
            this.tabPage3.Controls.Add(this.dgvingresosEliminar);
            this.tabPage3.Controls.Add(this.textBox6);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(922, 481);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Deshabilitar Ingreso";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(71, 159);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(75, 23);
            this.btneliminar.TabIndex = 5;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // dgvingresosEliminar
            // 
            this.dgvingresosEliminar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvingresosEliminar.Location = new System.Drawing.Point(71, 205);
            this.dgvingresosEliminar.Name = "dgvingresosEliminar";
            this.dgvingresosEliminar.RowHeadersWidth = 51;
            this.dgvingresosEliminar.RowTemplate.Height = 24;
            this.dgvingresosEliminar.Size = new System.Drawing.Size(720, 239);
            this.dgvingresosEliminar.TabIndex = 3;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(71, 111);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(146, 22);
            this.textBox6.TabIndex = 2;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "ID de Ingreso a Eliminar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(286, 27);
            this.label8.TabIndex = 0;
            this.label8.Text = "Eliminar Ingreso Financiero";
            // 
            // Ingreso_Financiero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 534);
            this.Controls.Add(this.tabControl1);
            this.Name = "Ingreso_Financiero";
            this.Text = "Ingreso_Financiero";
            this.Load += new System.EventHandler(this.Ingreso_Financiero_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresosAgregar)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvingresosEliminar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuscardetalle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.DataGridView dgvIngresosAgregar;
        private System.Windows.Forms.DateTimePicker dtpfechaingreso;
        private System.Windows.Forms.DateTimePicker dtpfecharegistro;
        private System.Windows.Forms.TextBox txtobservaciones;
        private System.Windows.Forms.TextBox txtconcepto;
        private System.Windows.Forms.TextBox txtmonto;
        private System.Windows.Forms.TextBox txtdetalleventa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.DataGridView dgvingresosEliminar;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button vtnbuscar;
    }
}