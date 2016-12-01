namespace ControlesModuloConsulta
{
    partial class ControlPantallaInicial
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
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.richTextBox_descripcion = new System.Windows.Forms.RichTextBox();
            this.button_iniciar = new System.Windows.Forms.Button();
            this.label_titulo_sistema_experto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Location = new System.Drawing.Point(32, 57);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(200, 400);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logo.TabIndex = 0;
            this.pictureBox_logo.TabStop = false;
            // 
            // richTextBox_descripcion
            // 
            this.richTextBox_descripcion.Location = new System.Drawing.Point(240, 57);
            this.richTextBox_descripcion.Name = "richTextBox_descripcion";
            this.richTextBox_descripcion.ReadOnly = true;
            this.richTextBox_descripcion.Size = new System.Drawing.Size(319, 400);
            this.richTextBox_descripcion.TabIndex = 1;
            this.richTextBox_descripcion.Text = "";
            // 
            // button_iniciar
            // 
            this.button_iniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_iniciar.Location = new System.Drawing.Point(122, 463);
            this.button_iniciar.Name = "button_iniciar";
            this.button_iniciar.Size = new System.Drawing.Size(371, 57);
            this.button_iniciar.TabIndex = 2;
            this.button_iniciar.Text = "Continuar";
            this.button_iniciar.UseVisualStyleBackColor = true;
            this.button_iniciar.Click += new System.EventHandler(this.button_iniciar_Click);
            // 
            // label_titulo_sistema_experto
            // 
            this.label_titulo_sistema_experto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_titulo_sistema_experto.Location = new System.Drawing.Point(32, 16);
            this.label_titulo_sistema_experto.Name = "label_titulo_sistema_experto";
            this.label_titulo_sistema_experto.Size = new System.Drawing.Size(527, 23);
            this.label_titulo_sistema_experto.TabIndex = 3;
            this.label_titulo_sistema_experto.Text = "Titulo sistema experto";
            this.label_titulo_sistema_experto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ControlPantallaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_titulo_sistema_experto);
            this.Controls.Add(this.button_iniciar);
            this.Controls.Add(this.richTextBox_descripcion);
            this.Controls.Add(this.pictureBox_logo);
            this.MaximumSize = new System.Drawing.Size(600, 550);
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "ControlPantallaInicial";
            this.Size = new System.Drawing.Size(600, 550);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button_iniciar;
        private System.Windows.Forms.RichTextBox richTextBox_descripcion;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.Label label_titulo_sistema_experto;
    }
}
