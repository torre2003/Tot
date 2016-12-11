namespace ControlesModuloConsulta
{
    partial class ControlSeleccionObjetivo
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
            this.panel_externo_variable = new System.Windows.Forms.Panel();
            this.panel_interno_variable = new System.Windows.Forms.Panel();
            this.label_pregunta_1 = new System.Windows.Forms.Label();
            this.label_pregunta_2 = new System.Windows.Forms.Label();
            this.label_titulo = new System.Windows.Forms.Label();
            this.panel_externo_estados = new System.Windows.Forms.Panel();
            this.panel_interno_estados = new System.Windows.Forms.Panel();
            this.button_iniciar_inferencia = new System.Windows.Forms.Button();
            this.panel_externo_variable.SuspendLayout();
            this.panel_externo_estados.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_externo_variable
            // 
            this.panel_externo_variable.AutoScroll = true;
            this.panel_externo_variable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_externo_variable.Controls.Add(this.panel_interno_variable);
            this.panel_externo_variable.Location = new System.Drawing.Point(45, 100);
            this.panel_externo_variable.Name = "panel_externo_variable";
            this.panel_externo_variable.Size = new System.Drawing.Size(500, 130);
            this.panel_externo_variable.TabIndex = 0;
            // 
            // panel_interno_variable
            // 
            this.panel_interno_variable.Location = new System.Drawing.Point(3, 3);
            this.panel_interno_variable.Name = "panel_interno_variable";
            this.panel_interno_variable.Size = new System.Drawing.Size(450, 78);
            this.panel_interno_variable.TabIndex = 0;
            // 
            // label_pregunta_1
            // 
            this.label_pregunta_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_pregunta_1.Location = new System.Drawing.Point(21, 55);
            this.label_pregunta_1.Name = "label_pregunta_1";
            this.label_pregunta_1.Size = new System.Drawing.Size(552, 42);
            this.label_pregunta_1.TabIndex = 1;
            this.label_pregunta_1.Text = "Eliga objetivo encadenamiento";
            this.label_pregunta_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_pregunta_2
            // 
            this.label_pregunta_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_pregunta_2.Location = new System.Drawing.Point(21, 249);
            this.label_pregunta_2.Name = "label_pregunta_2";
            this.label_pregunta_2.Size = new System.Drawing.Size(552, 42);
            this.label_pregunta_2.TabIndex = 2;
            this.label_pregunta_2.Text = "Seleccione el estado a comprobar";
            this.label_pregunta_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_titulo
            // 
            this.label_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_titulo.Location = new System.Drawing.Point(21, 1);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(552, 42);
            this.label_titulo.TabIndex = 3;
            this.label_titulo.Text = "Titulo sistema experto";
            this.label_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_externo_estados
            // 
            this.panel_externo_estados.AutoScroll = true;
            this.panel_externo_estados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_externo_estados.Controls.Add(this.panel_interno_estados);
            this.panel_externo_estados.Location = new System.Drawing.Point(45, 304);
            this.panel_externo_estados.Name = "panel_externo_estados";
            this.panel_externo_estados.Size = new System.Drawing.Size(500, 130);
            this.panel_externo_estados.TabIndex = 4;
            // 
            // panel_interno_estados
            // 
            this.panel_interno_estados.Location = new System.Drawing.Point(3, 4);
            this.panel_interno_estados.Name = "panel_interno_estados";
            this.panel_interno_estados.Size = new System.Drawing.Size(450, 80);
            this.panel_interno_estados.TabIndex = 0;
            // 
            // button_iniciar_inferencia
            // 
            this.button_iniciar_inferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_iniciar_inferencia.Location = new System.Drawing.Point(158, 453);
            this.button_iniciar_inferencia.Name = "button_iniciar_inferencia";
            this.button_iniciar_inferencia.Size = new System.Drawing.Size(289, 66);
            this.button_iniciar_inferencia.TabIndex = 5;
            this.button_iniciar_inferencia.Text = "Iniciar Inferencia";
            this.button_iniciar_inferencia.UseVisualStyleBackColor = true;
            this.button_iniciar_inferencia.Click += new System.EventHandler(this.button_iniciar_inferencia_Click);
            // 
            // ControlSeleccionObjetivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_iniciar_inferencia);
            this.Controls.Add(this.panel_externo_estados);
            this.Controls.Add(this.label_titulo);
            this.Controls.Add(this.label_pregunta_2);
            this.Controls.Add(this.label_pregunta_1);
            this.Controls.Add(this.panel_externo_variable);
            this.MaximumSize = new System.Drawing.Size(600, 550);
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "ControlSeleccionObjetivo";
            this.Size = new System.Drawing.Size(600, 550);
            this.panel_externo_variable.ResumeLayout(false);
            this.panel_externo_estados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_externo_variable;
        private System.Windows.Forms.Label label_pregunta_1;
        private System.Windows.Forms.Label label_pregunta_2;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.Panel panel_externo_estados;
        private System.Windows.Forms.Panel panel_interno_variable;
        private System.Windows.Forms.Panel panel_interno_estados;
        public System.Windows.Forms.Button button_iniciar_inferencia;
    }
}
