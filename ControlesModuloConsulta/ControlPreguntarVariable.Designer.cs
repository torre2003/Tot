namespace ControlesModuloConsulta
{
    partial class ControlPreguntarVariable
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
            this.textBox_pregunta = new System.Windows.Forms.TextBox();
            this.richTextBox_descripcion_variable = new System.Windows.Forms.RichTextBox();
            this.panel_respuesta = new System.Windows.Forms.Panel();
            this.label_rango = new System.Windows.Forms.Label();
            this.textBox_numero_real = new System.Windows.Forms.TextBox();
            this.numericUpDown_numero_cardinal = new System.Windows.Forms.NumericUpDown();
            this.comboBox_lista_opciones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_continuar = new System.Windows.Forms.Button();
            this.panel_respuesta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numero_cardinal)).BeginInit();
            this.SuspendLayout();
            // 
            // label_titulo
            // 
            this.label_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_titulo.Location = new System.Drawing.Point(24, 19);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(552, 42);
            this.label_titulo.TabIndex = 4;
            this.label_titulo.Text = "Nombre  variable";
            this.label_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_pregunta
            // 
            this.textBox_pregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_pregunta.Location = new System.Drawing.Point(39, 87);
            this.textBox_pregunta.Multiline = true;
            this.textBox_pregunta.Name = "textBox_pregunta";
            this.textBox_pregunta.ReadOnly = true;
            this.textBox_pregunta.Size = new System.Drawing.Size(511, 77);
            this.textBox_pregunta.TabIndex = 5;
            // 
            // richTextBox_descripcion_variable
            // 
            this.richTextBox_descripcion_variable.Location = new System.Drawing.Point(39, 187);
            this.richTextBox_descripcion_variable.Name = "richTextBox_descripcion_variable";
            this.richTextBox_descripcion_variable.ReadOnly = true;
            this.richTextBox_descripcion_variable.Size = new System.Drawing.Size(511, 184);
            this.richTextBox_descripcion_variable.TabIndex = 6;
            this.richTextBox_descripcion_variable.Text = "";
            // 
            // panel_respuesta
            // 
            this.panel_respuesta.Controls.Add(this.label_rango);
            this.panel_respuesta.Controls.Add(this.textBox_numero_real);
            this.panel_respuesta.Controls.Add(this.numericUpDown_numero_cardinal);
            this.panel_respuesta.Controls.Add(this.comboBox_lista_opciones);
            this.panel_respuesta.Controls.Add(this.label1);
            this.panel_respuesta.Location = new System.Drawing.Point(39, 389);
            this.panel_respuesta.Name = "panel_respuesta";
            this.panel_respuesta.Size = new System.Drawing.Size(511, 87);
            this.panel_respuesta.TabIndex = 7;
            // 
            // label_rango
            // 
            this.label_rango.AutoSize = true;
            this.label_rango.Location = new System.Drawing.Point(146, 46);
            this.label_rango.Name = "label_rango";
            this.label_rango.Size = new System.Drawing.Size(42, 13);
            this.label_rango.TabIndex = 4;
            this.label_rango.Text = "Rango:";
            // 
            // textBox_numero_real
            // 
            this.textBox_numero_real.Location = new System.Drawing.Point(178, 23);
            this.textBox_numero_real.Name = "textBox_numero_real";
            this.textBox_numero_real.Size = new System.Drawing.Size(200, 20);
            this.textBox_numero_real.TabIndex = 3;
            this.textBox_numero_real.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_numero_real_KeyPress);
            // 
            // numericUpDown_numero_cardinal
            // 
            this.numericUpDown_numero_cardinal.Location = new System.Drawing.Point(178, 22);
            this.numericUpDown_numero_cardinal.Name = "numericUpDown_numero_cardinal";
            this.numericUpDown_numero_cardinal.Size = new System.Drawing.Size(200, 20);
            this.numericUpDown_numero_cardinal.TabIndex = 2;
            this.numericUpDown_numero_cardinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown_numero_cardinal_KeyPress);
            // 
            // comboBox_lista_opciones
            // 
            this.comboBox_lista_opciones.FormattingEnabled = true;
            this.comboBox_lista_opciones.Location = new System.Drawing.Point(178, 22);
            this.comboBox_lista_opciones.Name = "comboBox_lista_opciones";
            this.comboBox_lista_opciones.Size = new System.Drawing.Size(200, 21);
            this.comboBox_lista_opciones.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese estado variable:";
            // 
            // button_continuar
            // 
            this.button_continuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_continuar.Location = new System.Drawing.Point(362, 482);
            this.button_continuar.Name = "button_continuar";
            this.button_continuar.Size = new System.Drawing.Size(188, 45);
            this.button_continuar.TabIndex = 8;
            this.button_continuar.Text = "Continuar";
            this.button_continuar.UseVisualStyleBackColor = true;
            this.button_continuar.Click += new System.EventHandler(this.button_continuar_Click);
            // 
            // ControlPreguntarVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_continuar);
            this.Controls.Add(this.panel_respuesta);
            this.Controls.Add(this.richTextBox_descripcion_variable);
            this.Controls.Add(this.textBox_pregunta);
            this.Controls.Add(this.label_titulo);
            this.MaximumSize = new System.Drawing.Size(600, 550);
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "ControlPreguntarVariable";
            this.Size = new System.Drawing.Size(600, 550);
            this.panel_respuesta.ResumeLayout(false);
            this.panel_respuesta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numero_cardinal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.TextBox textBox_pregunta;
        private System.Windows.Forms.RichTextBox richTextBox_descripcion_variable;
        private System.Windows.Forms.Panel panel_respuesta;
        private System.Windows.Forms.Label label_rango;
        private System.Windows.Forms.TextBox textBox_numero_real;
        private System.Windows.Forms.NumericUpDown numericUpDown_numero_cardinal;
        private System.Windows.Forms.ComboBox comboBox_lista_opciones;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button_continuar;


    }
}
