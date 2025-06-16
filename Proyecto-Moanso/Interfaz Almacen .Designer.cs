namespace Proyecto_Moanso
{
    partial class Interfaz_Almacen
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
            this.btnordencompra = new System.Windows.Forms.Button();
            this.btnproveedor = new System.Windows.Forms.Button();
            this.btnincidencias = new System.Windows.Forms.Button();
            this.btnnotaentrada = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnrequerimiento = new System.Windows.Forms.Button();
            this.btnproducto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(143, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 588);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Almacen";
            // 
            // btnordencompra
            // 
            this.btnordencompra.Location = new System.Drawing.Point(11, 102);
            this.btnordencompra.Name = "btnordencompra";
            this.btnordencompra.Size = new System.Drawing.Size(112, 47);
            this.btnordencompra.TabIndex = 1;
            this.btnordencompra.Text = "Orden Compra";
            this.btnordencompra.UseVisualStyleBackColor = true;
            this.btnordencompra.Click += new System.EventHandler(this.btnordencompra_Click);
            // 
            // btnproveedor
            // 
            this.btnproveedor.Location = new System.Drawing.Point(11, 176);
            this.btnproveedor.Name = "btnproveedor";
            this.btnproveedor.Size = new System.Drawing.Size(112, 41);
            this.btnproveedor.TabIndex = 2;
            this.btnproveedor.Text = "Proveedor";
            this.btnproveedor.UseVisualStyleBackColor = true;
            this.btnproveedor.Click += new System.EventHandler(this.btnproveedor_Click);
            // 
            // btnincidencias
            // 
            this.btnincidencias.Location = new System.Drawing.Point(11, 248);
            this.btnincidencias.Name = "btnincidencias";
            this.btnincidencias.Size = new System.Drawing.Size(112, 40);
            this.btnincidencias.TabIndex = 3;
            this.btnincidencias.Text = "Incidencias";
            this.btnincidencias.UseVisualStyleBackColor = true;
            this.btnincidencias.Click += new System.EventHandler(this.btnincidencias_Click);
            // 
            // btnnotaentrada
            // 
            this.btnnotaentrada.Location = new System.Drawing.Point(11, 322);
            this.btnnotaentrada.Name = "btnnotaentrada";
            this.btnnotaentrada.Size = new System.Drawing.Size(112, 42);
            this.btnnotaentrada.TabIndex = 4;
            this.btnnotaentrada.Text = "Nota Entrada";
            this.btnnotaentrada.UseVisualStyleBackColor = true;
            this.btnnotaentrada.Click += new System.EventHandler(this.btnnotaentrada_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 395);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 39);
            this.button5.TabIndex = 5;
            this.button5.Text = "Nota Salida";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnrequerimiento
            // 
            this.btnrequerimiento.Location = new System.Drawing.Point(12, 467);
            this.btnrequerimiento.Name = "btnrequerimiento";
            this.btnrequerimiento.Size = new System.Drawing.Size(111, 45);
            this.btnrequerimiento.TabIndex = 6;
            this.btnrequerimiento.Text = "Requerimiento Productos";
            this.btnrequerimiento.UseVisualStyleBackColor = true;
            this.btnrequerimiento.Click += new System.EventHandler(this.btnrequerimiento_Click);
            // 
            // btnproducto
            // 
            this.btnproducto.Location = new System.Drawing.Point(12, 29);
            this.btnproducto.Name = "btnproducto";
            this.btnproducto.Size = new System.Drawing.Size(111, 43);
            this.btnproducto.TabIndex = 7;
            this.btnproducto.Text = "Producto";
            this.btnproducto.UseVisualStyleBackColor = true;
            this.btnproducto.Click += new System.EventHandler(this.btnproducto_Click);
            // 
            // Interfaz_Almacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 612);
            this.Controls.Add(this.btnproducto);
            this.Controls.Add(this.btnrequerimiento);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnnotaentrada);
            this.Controls.Add(this.btnincidencias);
            this.Controls.Add(this.btnproveedor);
            this.Controls.Add(this.btnordencompra);
            this.Controls.Add(this.groupBox1);
            this.Name = "Interfaz_Almacen";
            this.Text = "Interfaz_Almacen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnordencompra;
        private System.Windows.Forms.Button btnproveedor;
        private System.Windows.Forms.Button btnincidencias;
        private System.Windows.Forms.Button btnnotaentrada;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnrequerimiento;
        private System.Windows.Forms.Button btnproducto;
    }
}