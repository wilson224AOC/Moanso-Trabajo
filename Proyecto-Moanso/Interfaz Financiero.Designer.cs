namespace Proyecto_Moanso
{
    partial class Interfaz_Financiero
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
            this.btncotizaciones = new System.Windows.Forms.Button();
            this.btnegreso = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(165, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 585);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Financiero";
            // 
            // btncotizaciones
            // 
            this.btncotizaciones.Location = new System.Drawing.Point(27, 218);
            this.btncotizaciones.Name = "btncotizaciones";
            this.btncotizaciones.Size = new System.Drawing.Size(114, 31);
            this.btncotizaciones.TabIndex = 1;
            this.btncotizaciones.Text = "Cotizaciones";
            this.btncotizaciones.UseVisualStyleBackColor = true;
            this.btncotizaciones.Click += new System.EventHandler(this.btncotizaciones_Click);
            // 
            // btnegreso
            // 
            this.btnegreso.Location = new System.Drawing.Point(27, 283);
            this.btnegreso.Name = "btnegreso";
            this.btnegreso.Size = new System.Drawing.Size(114, 40);
            this.btnegreso.TabIndex = 2;
            this.btnegreso.Text = "Egreso Financiero";
            this.btnegreso.UseVisualStyleBackColor = true;
            this.btnegreso.Click += new System.EventHandler(this.btnegreso_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(27, 355);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 42);
            this.button3.TabIndex = 3;
            this.button3.Text = "Ingreso Financiero";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(27, 431);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 43);
            this.button4.TabIndex = 4;
            this.button4.Text = "Registro Contable";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Interfaz_Financiero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 600);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnegreso);
            this.Controls.Add(this.btncotizaciones);
            this.Controls.Add(this.groupBox1);
            this.Name = "Interfaz_Financiero";
            this.Text = "Interfaz_Financiero";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btncotizaciones;
        private System.Windows.Forms.Button btnegreso;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}