namespace Proyecto_Moanso
{
    partial class RegistroContable
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbxtipomovimiento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvmovimiento = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.Button();
            this.txtmonto = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.txtobservaciones = new System.Windows.Forms.TextBox();
            this.dtpfecharegistro = new System.Windows.Forms.DateTimePicker();
            this.dgvregistro = new System.Windows.Forms.DataGridView();
            this.btnagregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btneliminar = new System.Windows.Forms.Button();
            this.dgvregistroEliminar = new System.Windows.Forms.DataGridView();
            this.txtidregistro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmovimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvregistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvregistroEliminar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1106, 545);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnagregar);
            this.tabPage1.Controls.Add(this.dgvregistro);
            this.tabPage1.Controls.Add(this.dtpfecharegistro);
            this.tabPage1.Controls.Add(this.txtobservaciones);
            this.tabPage1.Controls.Add(this.dtpfecha);
            this.tabPage1.Controls.Add(this.txtid);
            this.tabPage1.Controls.Add(this.txtmonto);
            this.tabPage1.Controls.Add(this.btnseleccionar);
            this.tabPage1.Controls.Add(this.dgvmovimiento);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbxtipomovimiento);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1098, 516);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Registrar Movimiento";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btneliminar);
            this.tabPage2.Controls.Add(this.dgvregistroEliminar);
            this.tabPage2.Controls.Add(this.txtidregistro);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1098, 516);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Eliminar Registro ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbxtipomovimiento
            // 
            this.cbxtipomovimiento.FormattingEnabled = true;
            this.cbxtipomovimiento.Location = new System.Drawing.Point(54, 56);
            this.cbxtipomovimiento.Name = "cbxtipomovimiento";
            this.cbxtipomovimiento.Size = new System.Drawing.Size(167, 24);
            this.cbxtipomovimiento.TabIndex = 0;
            this.cbxtipomovimiento.SelectedIndexChanged += new System.EventHandler(this.cbxtipomovimiento_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Movimiento:";
            // 
            // dgvmovimiento
            // 
            this.dgvmovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmovimiento.Location = new System.Drawing.Point(54, 99);
            this.dgvmovimiento.Name = "dgvmovimiento";
            this.dgvmovimiento.RowHeadersWidth = 51;
            this.dgvmovimiento.RowTemplate.Height = 24;
            this.dgvmovimiento.Size = new System.Drawing.Size(798, 150);
            this.dgvmovimiento.TabIndex = 2;
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.Location = new System.Drawing.Point(252, 56);
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.Size = new System.Drawing.Size(123, 23);
            this.btnseleccionar.TabIndex = 3;
            this.btnseleccionar.Text = "Seleccionar";
            this.btnseleccionar.UseVisualStyleBackColor = true;
            this.btnseleccionar.Click += new System.EventHandler(this.btnseleccionar_Click);
            // 
            // txtmonto
            // 
            this.txtmonto.Location = new System.Drawing.Point(45, 371);
            this.txtmonto.Name = "txtmonto";
            this.txtmonto.Size = new System.Drawing.Size(142, 22);
            this.txtmonto.TabIndex = 4;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(45, 299);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(142, 22);
            this.txtid.TabIndex = 5;
            // 
            // dtpfecha
            // 
            this.dtpfecha.Location = new System.Drawing.Point(45, 447);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(200, 22);
            this.dtpfecha.TabIndex = 6;
            // 
            // txtobservaciones
            // 
            this.txtobservaciones.Location = new System.Drawing.Point(269, 299);
            this.txtobservaciones.Name = "txtobservaciones";
            this.txtobservaciones.Size = new System.Drawing.Size(200, 22);
            this.txtobservaciones.TabIndex = 7;
            // 
            // dtpfecharegistro
            // 
            this.dtpfecharegistro.Location = new System.Drawing.Point(269, 371);
            this.dtpfecharegistro.Name = "dtpfecharegistro";
            this.dtpfecharegistro.Size = new System.Drawing.Size(200, 22);
            this.dtpfecharegistro.TabIndex = 8;
            // 
            // dgvregistro
            // 
            this.dgvregistro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvregistro.Location = new System.Drawing.Point(488, 299);
            this.dgvregistro.Name = "dgvregistro";
            this.dgvregistro.RowHeadersWidth = 51;
            this.dgvregistro.RowTemplate.Height = 24;
            this.dgvregistro.Size = new System.Drawing.Size(582, 193);
            this.dgvregistro.TabIndex = 9;
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(284, 437);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(91, 32);
            this.btnagregar.TabIndex = 10;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Monto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Observaciones:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Fecha Registro:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Fecha:";
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(74, 177);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(75, 23);
            this.btneliminar.TabIndex = 10;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // dgvregistroEliminar
            // 
            this.dgvregistroEliminar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvregistroEliminar.Location = new System.Drawing.Point(74, 223);
            this.dgvregistroEliminar.Name = "dgvregistroEliminar";
            this.dgvregistroEliminar.RowHeadersWidth = 51;
            this.dgvregistroEliminar.RowTemplate.Height = 24;
            this.dgvregistroEliminar.Size = new System.Drawing.Size(720, 239);
            this.dgvregistroEliminar.TabIndex = 9;
            // 
            // txtidregistro
            // 
            this.txtidregistro.Location = new System.Drawing.Point(74, 129);
            this.txtidregistro.Name = "txtidregistro";
            this.txtidregistro.Size = new System.Drawing.Size(146, 22);
            this.txtidregistro.TabIndex = 8;
            this.txtidregistro.TextChanged += new System.EventHandler(this.txtidregistro_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "ID de Registro a Eliminar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 27);
            this.label8.TabIndex = 6;
            this.label8.Text = "Eliminar Registro Contable";
            // 
            // RegistroContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 569);
            this.Controls.Add(this.tabControl1);
            this.Name = "RegistroContable";
            this.Text = "RegistroContable";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmovimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvregistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvregistroEliminar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvmovimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxtipomovimiento;
        private System.Windows.Forms.TextBox txtmonto;
        private System.Windows.Forms.Button btnseleccionar;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.DataGridView dgvregistro;
        private System.Windows.Forms.DateTimePicker dtpfecharegistro;
        private System.Windows.Forms.TextBox txtobservaciones;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.DataGridView dgvregistroEliminar;
        private System.Windows.Forms.TextBox txtidregistro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}