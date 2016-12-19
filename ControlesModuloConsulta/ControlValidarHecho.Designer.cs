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
            this.richTextBox_descripcion = new System.Windows.Forms.RichTextBox();
            this.button_continuar = new System.Windows.Forms.Button();
            this.button_solucion_si = new System.Windows.Forms.Button();
            this.button_solucion_no = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_hecho_a_validar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_detener = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_validar_no = new System.Windows.Forms.Button();
            this.button_validar_si = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_antededentes_ext = new System.Windows.Forms.Panel();
            this.panel_antecedentes_int = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label_id_regla = new System.Windows.Forms.Label();
            this.panel_antededentes_ext.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_titulo
            // 
            this.label_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_titulo.Location = new System.Drawing.Point(23, 0);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(552, 42);
            this.label_titulo.TabIndex = 4;
            this.label_titulo.Text = "nombre variable";
            this.label_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox_descripcion
            // 
            this.richTextBox_descripcion.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox_descripcion.Location = new System.Drawing.Point(27, 45);
            this.richTextBox_descripcion.Name = "richTextBox_descripcion";
            this.richTextBox_descripcion.ReadOnly = true;
            this.richTextBox_descripcion.Size = new System.Drawing.Size(548, 144);
            this.richTextBox_descripcion.TabIndex = 5;
            this.richTextBox_descripcion.Text = "";
            // 
            // button_continuar
            // 
            this.button_continuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_continuar.Location = new System.Drawing.Point(305, 490);
            this.button_continuar.Name = "button_continuar";
            this.button_continuar.Size = new System.Drawing.Size(270, 40);
            this.button_continuar.TabIndex = 12;
            this.button_continuar.Text = "Continuar Inferencia";
            this.button_continuar.UseVisualStyleBackColor = true;
            this.button_continuar.Click += new System.EventHandler(this.button_continuar_Click);
            // 
            // button_solucion_si
            // 
            this.button_solucion_si.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_solucion_si.Location = new System.Drawing.Point(27, 449);
            this.button_solucion_si.Name = "button_solucion_si";
            this.button_solucion_si.Size = new System.Drawing.Size(270, 40);
            this.button_solucion_si.TabIndex = 11;
            this.button_solucion_si.Text = "Si";
            this.button_solucion_si.UseVisualStyleBackColor = true;
            this.button_solucion_si.Click += new System.EventHandler(this.button_solucion_si_Click);
            // 
            // button_solucion_no
            // 
            this.button_solucion_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_solucion_no.Location = new System.Drawing.Point(305, 449);
            this.button_solucion_no.Name = "button_solucion_no";
            this.button_solucion_no.Size = new System.Drawing.Size(270, 40);
            this.button_solucion_no.TabIndex = 13;
            this.button_solucion_no.Text = "No";
            this.button_solucion_no.UseVisualStyleBackColor = true;
            this.button_solucion_no.Click += new System.EventHandler(this.button_solucion_no_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(20, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 42);
            this.label1.TabIndex = 14;
            this.label1.Text = "Se infiere que : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_hecho_a_validar
            // 
            this.textBox_hecho_a_validar.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_hecho_a_validar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_hecho_a_validar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_hecho_a_validar.Location = new System.Drawing.Point(149, 313);
            this.textBox_hecho_a_validar.Name = "textBox_hecho_a_validar";
            this.textBox_hecho_a_validar.ReadOnly = true;
            this.textBox_hecho_a_validar.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_hecho_a_validar.Size = new System.Drawing.Size(426, 26);
            this.textBox_hecho_a_validar.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(168, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 29);
            this.label2.TabIndex = 16;
            this.label2.Text = "¿Se solucionó el problema?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_detener
            // 
            this.button_detener.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_detener.Location = new System.Drawing.Point(27, 490);
            this.button_detener.Name = "button_detener";
            this.button_detener.Size = new System.Drawing.Size(270, 40);
            this.button_detener.TabIndex = 17;
            this.button_detener.Text = "Detener Inferencia";
            this.button_detener.UseVisualStyleBackColor = true;
            this.button_detener.Click += new System.EventHandler(this.button_detener_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(168, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 29);
            this.label3.TabIndex = 20;
            this.label3.Text = "¿Validar afirmación?";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_validar_no
            // 
            this.button_validar_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_validar_no.Location = new System.Drawing.Point(303, 374);
            this.button_validar_no.Name = "button_validar_no";
            this.button_validar_no.Size = new System.Drawing.Size(270, 40);
            this.button_validar_no.TabIndex = 19;
            this.button_validar_no.Text = "No";
            this.button_validar_no.UseVisualStyleBackColor = true;
            this.button_validar_no.Click += new System.EventHandler(this.button_validar_no_Click);
            // 
            // button_validar_si
            // 
            this.button_validar_si.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_validar_si.Location = new System.Drawing.Point(27, 374);
            this.button_validar_si.Name = "button_validar_si";
            this.button_validar_si.Size = new System.Drawing.Size(270, 40);
            this.button_validar_si.TabIndex = 18;
            this.button_validar_si.Text = "Si";
            this.button_validar_si.UseVisualStyleBackColor = true;
            this.button_validar_si.Click += new System.EventHandler(this.button_validar_si_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(60, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 42);
            this.label4.TabIndex = 21;
            this.label4.Text = "Como: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_antededentes_ext
            // 
            this.panel_antededentes_ext.AutoScroll = true;
            this.panel_antededentes_ext.BackColor = System.Drawing.SystemColors.Window;
            this.panel_antededentes_ext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_antededentes_ext.Controls.Add(this.panel_antecedentes_int);
            this.panel_antededentes_ext.Location = new System.Drawing.Point(149, 202);
            this.panel_antededentes_ext.Name = "panel_antededentes_ext";
            this.panel_antededentes_ext.Size = new System.Drawing.Size(426, 100);
            this.panel_antededentes_ext.TabIndex = 22;
            // 
            // panel_antecedentes_int
            // 
            this.panel_antecedentes_int.AutoSize = true;
            this.panel_antecedentes_int.Location = new System.Drawing.Point(3, 3);
            this.panel_antecedentes_int.Name = "panel_antecedentes_int";
            this.panel_antecedentes_int.Size = new System.Drawing.Size(421, 65);
            this.panel_antecedentes_int.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(20, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 42);
            this.label5.TabIndex = 23;
            this.label5.Text = "Según ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_id_regla
            // 
            this.label_id_regla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_id_regla.Location = new System.Drawing.Point(79, 192);
            this.label_id_regla.Name = "label_id_regla";
            this.label_id_regla.Size = new System.Drawing.Size(64, 42);
            this.label_id_regla.TabIndex = 24;
            this.label_id_regla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ControlValidarHecho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label_id_regla);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel_antededentes_ext);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_validar_no);
            this.Controls.Add(this.button_validar_si);
            this.Controls.Add(this.button_detener);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_hecho_a_validar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_solucion_no);
            this.Controls.Add(this.button_continuar);
            this.Controls.Add(this.button_solucion_si);
            this.Controls.Add(this.richTextBox_descripcion);
            this.Controls.Add(this.label_titulo);
            this.MaximumSize = new System.Drawing.Size(600, 550);
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "ControlValidarHecho";
            this.Size = new System.Drawing.Size(600, 550);
            this.panel_antededentes_ext.ResumeLayout(false);
            this.panel_antededentes_ext.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.RichTextBox richTextBox_descripcion;
        public System.Windows.Forms.Button button_continuar;
        public System.Windows.Forms.Button button_solucion_si;
        public System.Windows.Forms.Button button_solucion_no;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_hecho_a_validar;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button_detener;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button_validar_no;
        public System.Windows.Forms.Button button_validar_si;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_antededentes_ext;
        private System.Windows.Forms.Panel panel_antecedentes_int;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_id_regla;
    }
}
