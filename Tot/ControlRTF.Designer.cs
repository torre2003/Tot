namespace Tot
{
    partial class ControlRTF
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
            this.richTextBox_principal = new System.Windows.Forms.RichTextBox();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_insertar_imagen = new System.Windows.Forms.Button();
            this.button_deshacer = new System.Windows.Forms.Button();
            this.button_rehacer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_principal
            // 
            this.richTextBox_principal.Location = new System.Drawing.Point(30, 35);
            this.richTextBox_principal.Name = "richTextBox_principal";
            this.richTextBox_principal.Size = new System.Drawing.Size(492, 418);
            this.richTextBox_principal.TabIndex = 0;
            this.richTextBox_principal.Text = "";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(544, 401);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 23);
            this.button_aceptar.TabIndex = 1;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(544, 430);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 2;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            // 
            // button_insertar_imagen
            // 
            this.button_insertar_imagen.Location = new System.Drawing.Point(544, 35);
            this.button_insertar_imagen.Name = "button_insertar_imagen";
            this.button_insertar_imagen.Size = new System.Drawing.Size(75, 23);
            this.button_insertar_imagen.TabIndex = 3;
            this.button_insertar_imagen.Text = "Insertar Imagen";
            this.button_insertar_imagen.UseVisualStyleBackColor = true;
            this.button_insertar_imagen.Click += new System.EventHandler(this.button_insertar_imagen_Click);
            // 
            // button_deshacer
            // 
            this.button_deshacer.Location = new System.Drawing.Point(544, 65);
            this.button_deshacer.Name = "button_deshacer";
            this.button_deshacer.Size = new System.Drawing.Size(75, 23);
            this.button_deshacer.TabIndex = 4;
            this.button_deshacer.Text = "Deshacer";
            this.button_deshacer.UseVisualStyleBackColor = true;
            this.button_deshacer.Click += new System.EventHandler(this.button_deshacer_Click);
            // 
            // button_rehacer
            // 
            this.button_rehacer.Location = new System.Drawing.Point(544, 95);
            this.button_rehacer.Name = "button_rehacer";
            this.button_rehacer.Size = new System.Drawing.Size(75, 23);
            this.button_rehacer.TabIndex = 5;
            this.button_rehacer.Text = "Rehacer";
            this.button_rehacer.UseVisualStyleBackColor = true;
            this.button_rehacer.Click += new System.EventHandler(this.button_rehacer_Click);
            // 
            // ControlRTF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_rehacer);
            this.Controls.Add(this.button_deshacer);
            this.Controls.Add(this.button_insertar_imagen);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.richTextBox_principal);
            this.Name = "ControlRTF";
            this.Size = new System.Drawing.Size(640, 497);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_principal;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_insertar_imagen;
        private System.Windows.Forms.Button button_deshacer;
        private System.Windows.Forms.Button button_rehacer;
    }
}
