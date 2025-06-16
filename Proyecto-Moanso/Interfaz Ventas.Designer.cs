namespace Proyecto_Moanso
{
    partial class Interfaz_Ventas
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
            this.btnventacredito = new System.Windows.Forms.Button();
            this.btnventadirecta = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnempleado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(134, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1121, 599);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ventas";
            // 
            // btnventacredito
            // 
            this.btnventacredito.Location = new System.Drawing.Point(12, 242);
            this.btnventacredito.Name = "btnventacredito";
            this.btnventacredito.Size = new System.Drawing.Size(107, 39);
            this.btnventacredito.TabIndex = 1;
            this.btnventacredito.Text = "Venta Credito";
            this.btnventacredito.UseVisualStyleBackColor = true;
            this.btnventacredito.Click += new System.EventHandler(this.btnventacredito_Click);
            // 
            // btnventadirecta
            // 
            this.btnventadirecta.Location = new System.Drawing.Point(12, 325);
            this.btnventadirecta.Name = "btnventadirecta";
            this.btnventadirecta.Size = new System.Drawing.Size(107, 39);
            this.btnventadirecta.TabIndex = 2;
            this.btnventadirecta.Text = "Venta Directa";
            this.btnventadirecta.UseVisualStyleBackColor = true;
            this.btnventadirecta.Click += new System.EventHandler(this.btnventadirecta_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 416);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 37);
            this.button3.TabIndex = 3;
            this.button3.Text = "Detalle Venta";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnempleado
            // 
            this.btnempleado.Location = new System.Drawing.Point(12, 150);
            this.btnempleado.Name = "btnempleado";
            this.btnempleado.Size = new System.Drawing.Size(107, 44);
            this.btnempleado.TabIndex = 4;
            this.btnempleado.Text = "Empleado";
            this.btnempleado.UseVisualStyleBackColor = true;
            this.btnempleado.Click += new System.EventHandler(this.btnempleado_Click);
            // 
            // Interfaz_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 620);
            this.Controls.Add(this.btnempleado);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnventadirecta);
            this.Controls.Add(this.btnventacredito);
            this.Controls.Add(this.groupBox1);
            this.Name = "Interfaz_Ventas";
            this.Text = "Interfaz_Ventas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnventacredito;
        private System.Windows.Forms.Button btnventadirecta;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnempleado;
    }
}