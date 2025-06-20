namespace Proyecto_Moanso
{
    partial class Incidencias
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnsalir = new System.Windows.Forms.Button();
            this.btndeshabilitar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            this.btnagregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxnotaingreso = new System.Windows.Forms.ComboBox();
            this.txttipoincidencia = new System.Windows.Forms.TextBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.dtpfechaincidencia = new System.Windows.Forms.DateTimePicker();
            this.cbxestado = new System.Windows.Forms.ComboBox();
            this.txtobservaciones = new System.Windows.Forms.TextBox();
            this.dtpfecharegistro = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpfecharegistro);
            this.groupBox1.Controls.Add(this.txtobservaciones);
            this.groupBox1.Controls.Add(this.cbxestado);
            this.groupBox1.Controls.Add(this.dtpfechaincidencia);
            this.groupBox1.Controls.Add(this.txtdescripcion);
            this.groupBox1.Controls.Add(this.txttipoincidencia);
            this.groupBox1.Controls.Add(this.cbxnotaingreso);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnagregar);
            this.groupBox1.Controls.Add(this.btncancelar);
            this.groupBox1.Location = new System.Drawing.Point(31, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(867, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incidencias";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(51, 311);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(731, 231);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnsalir
            // 
            this.btnsalir.Location = new System.Drawing.Point(809, 472);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(75, 23);
            this.btnsalir.TabIndex = 37;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            // 
            // btndeshabilitar
            // 
            this.btndeshabilitar.Location = new System.Drawing.Point(809, 418);
            this.btndeshabilitar.Name = "btndeshabilitar";
            this.btndeshabilitar.Size = new System.Drawing.Size(89, 25);
            this.btndeshabilitar.TabIndex = 36;
            this.btndeshabilitar.Text = "Deshabilitar";
            this.btndeshabilitar.UseVisualStyleBackColor = true;
            this.btndeshabilitar.Click += new System.EventHandler(this.btndeshabilitar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(809, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Nuevo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.Location = new System.Drawing.Point(764, 165);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(75, 23);
            this.btncancelar.TabIndex = 13;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(764, 75);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(75, 23);
            this.btnagregar.TabIndex = 14;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nota Ingreso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tipo Incidencia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Fecha Incidencia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Estado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(376, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Observaciones";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(376, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Fecha Registro:";
            // 
            // cbxnotaingreso
            // 
            this.cbxnotaingreso.FormattingEnabled = true;
            this.cbxnotaingreso.Location = new System.Drawing.Point(170, 38);
            this.cbxnotaingreso.Name = "cbxnotaingreso";
            this.cbxnotaingreso.Size = new System.Drawing.Size(173, 24);
            this.cbxnotaingreso.TabIndex = 16;
            // 
            // txttipoincidencia
            // 
            this.txttipoincidencia.Location = new System.Drawing.Point(170, 108);
            this.txttipoincidencia.Name = "txttipoincidencia";
            this.txttipoincidencia.Size = new System.Drawing.Size(173, 22);
            this.txttipoincidencia.TabIndex = 17;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(170, 175);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(173, 22);
            this.txtdescripcion.TabIndex = 18;
            // 
            // dtpfechaincidencia
            // 
            this.dtpfechaincidencia.Location = new System.Drawing.Point(494, 41);
            this.dtpfechaincidencia.Name = "dtpfechaincidencia";
            this.dtpfechaincidencia.Size = new System.Drawing.Size(187, 22);
            this.dtpfechaincidencia.TabIndex = 19;
            // 
            // cbxestado
            // 
            this.cbxestado.FormattingEnabled = true;
            this.cbxestado.Location = new System.Drawing.Point(494, 89);
            this.cbxestado.Name = "cbxestado";
            this.cbxestado.Size = new System.Drawing.Size(187, 24);
            this.cbxestado.TabIndex = 20;
            // 
            // txtobservaciones
            // 
            this.txtobservaciones.Location = new System.Drawing.Point(494, 144);
            this.txtobservaciones.Name = "txtobservaciones";
            this.txtobservaciones.Size = new System.Drawing.Size(187, 22);
            this.txtobservaciones.TabIndex = 21;
            // 
            // dtpfecharegistro
            // 
            this.dtpfecharegistro.Location = new System.Drawing.Point(494, 200);
            this.dtpfecharegistro.Name = "dtpfecharegistro";
            this.dtpfecharegistro.Size = new System.Drawing.Size(187, 22);
            this.dtpfecharegistro.TabIndex = 22;
            // 
            // Incidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 567);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.btndeshabilitar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Incidencias";
            this.Text = "Incidencias";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btndeshabilitar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.TextBox txttipoincidencia;
        private System.Windows.Forms.ComboBox cbxnotaingreso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.DateTimePicker dtpfecharegistro;
        private System.Windows.Forms.TextBox txtobservaciones;
        private System.Windows.Forms.ComboBox cbxestado;
        private System.Windows.Forms.DateTimePicker dtpfechaincidencia;
        private System.Windows.Forms.TextBox txtdescripcion;
    }
}