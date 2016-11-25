namespace ControlesModuloConsulta
{
    partial class ControlValidarHecho
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_titulo = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_validar = new System.Windows.Forms.Button();
            this.button_continuar = new System.Windows.Forms.Button();
            this.button_si = new System.Windows.Forms.Button();
            this.button_no = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_hecho_a_validar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_detener = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_titulo
            // 
            this.label_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_titulo.Location = new System.Drawing.Point(23, 16);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(552, 42);
            this.label_titulo.TabIndex = 4;
            this.label_titulo.Text = "nomrbe variable";
            this.label_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(27, 74);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(548, 188);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // button_validar
            // 
            this.button_validar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_validar.Location = new System.Drawing.Point(27, 338);
            this.button_validar.Name = "button_validar";
            this.button_validar.Size = new System.Drawing.Size(548, 45);
            this.button_validar.TabIndex = 10;
            this.button_validar.Text = "Validar afirmación";
            this.button_validar.UseVisualStyleBackColor = true;
            // 
            // button_continuar
            // 
            this.button_continuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_continuar.Location = new System.Drawing.Point(305, 467);
            this.button_continuar.Name = "button_continuar";
            this.button_continuar.Size = new System.Drawing.Size(270, 45);
            this.button_continuar.TabIndex = 12;
            this.button_continuar.Text = "Continuar Inferencia";
            this.button_continuar.UseVisualStyleBackColor = true;
            // 
            // button_si
            // 
            this.button_si.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_si.Location = new System.Drawing.Point(27, 416);
            this.button_si.Name = "button_si";
            this.button_si.Size = new System.Drawing.Size(270, 45);
            this.button_si.TabIndex = 11;
            this.button_si.Text = "Si";
            this.button_si.UseVisualStyleBackColor = true;
            // 
            // button_no
            // 
            this.button_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_no.Location = new System.Drawing.Point(305, 416);
            this.button_no.Name = "button_no";
            this.button_no.Size = new System.Drawing.Size(270, 45);
            this.button_no.TabIndex = 13;
            this.button_no.Text = "No";
            this.button_no.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(23, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 42);
            this.label1.TabIndex = 14;
            this.label1.Text = "Se infiere que : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_hecho_a_validar
            // 
            this.textBox_hecho_a_validar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_hecho_a_validar.Location = new System.Drawing.Point(91, 301);
            this.textBox_hecho_a_validar.Name = "textBox_hecho_a_validar";
            this.textBox_hecho_a_validar.Size = new System.Drawing.Size(426, 26);
            this.textBox_hecho_a_validar.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(168, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 29);
            this.label2.TabIndex = 16;
            this.label2.Text = "¿Se solucionó el problema?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_detener
            // 
            this.button_detener.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_detener.Location = new System.Drawing.Point(27, 467);
            this.button_detener.Name = "button_detener";
            this.button_detener.Size = new System.Drawing.Size(270, 45);
            this.button_detener.TabIndex = 17;
            this.button_detener.Text = "Detener Inferencia";
            this.button_detener.UseVisualStyleBackColor = true;
            // 
            // ControlValidarHecho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_detener);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_hecho_a_validar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_no);
            this.Controls.Add(this.button_continuar);
            this.Controls.Add(this.button_si);
            this.Controls.Add(this.button_validar);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label_titulo);
            this.MaximumSize = new System.Drawing.Size(600, 550);
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "ControlValidarHecho";
            this.Size = new System.Drawing.Size(600, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Button button_validar;
        public System.Windows.Forms.Button button_continuar;
        public System.Windows.Forms.Button button_si;
        public System.Windows.Forms.Button button_no;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_hecho_a_validar;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button_detener;
    }
}
