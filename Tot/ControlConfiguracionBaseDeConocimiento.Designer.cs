namespace Tot
{
    partial class ControlConfiguracionBaseDeConocimiento
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlConfiguracionBaseDeConocimiento));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_titulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_tipo_encadenamiento = new System.Windows.Forms.Panel();
            this.radioButton_encadenamiento_hacia_adelante = new System.Windows.Forms.RadioButton();
            this.radioButton_encadenamiento_hacia_atras = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_chequeo_base_de_conocimiento = new System.Windows.Forms.CheckBox();
            this.button_chequear_base_de_conocimiento = new System.Windows.Forms.Button();
            this.button_seleccion_de_imagen = new System.Windows.Forms.Button();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.button_descripcion_sistema_experto = new System.Windows.Forms.Button();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.openFileDialog_imagen_logo = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.imageList_check_base_conocimiento = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox_check_bae_de_conocimiento = new System.Windows.Forms.PictureBox();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.panel_tipo_encadenamiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_check_bae_de_conocimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titulo sistema experto";
            // 
            // textBox_titulo
            // 
            this.textBox_titulo.Location = new System.Drawing.Point(25, 48);
            this.textBox_titulo.Name = "textBox_titulo";
            this.textBox_titulo.Size = new System.Drawing.Size(447, 20);
            this.textBox_titulo.TabIndex = 1;
            this.textBox_titulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_titulo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción sistema experto";
            // 
            // panel_tipo_encadenamiento
            // 
            this.panel_tipo_encadenamiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_tipo_encadenamiento.Controls.Add(this.radioButton_encadenamiento_hacia_adelante);
            this.panel_tipo_encadenamiento.Controls.Add(this.radioButton_encadenamiento_hacia_atras);
            this.panel_tipo_encadenamiento.Controls.Add(this.label3);
            this.panel_tipo_encadenamiento.Location = new System.Drawing.Point(29, 143);
            this.panel_tipo_encadenamiento.Name = "panel_tipo_encadenamiento";
            this.panel_tipo_encadenamiento.Size = new System.Drawing.Size(443, 79);
            this.panel_tipo_encadenamiento.TabIndex = 4;
            // 
            // radioButton_encadenamiento_hacia_adelante
            // 
            this.radioButton_encadenamiento_hacia_adelante.AutoSize = true;
            this.radioButton_encadenamiento_hacia_adelante.Location = new System.Drawing.Point(224, 39);
            this.radioButton_encadenamiento_hacia_adelante.Name = "radioButton_encadenamiento_hacia_adelante";
            this.radioButton_encadenamiento_hacia_adelante.Size = new System.Drawing.Size(178, 17);
            this.radioButton_encadenamiento_hacia_adelante.TabIndex = 7;
            this.radioButton_encadenamiento_hacia_adelante.Text = "Encadenamiento hacia adelante";
            this.radioButton_encadenamiento_hacia_adelante.UseVisualStyleBackColor = true;
            this.radioButton_encadenamiento_hacia_adelante.CheckedChanged += new System.EventHandler(this.radioButton_encadenamiento_hacia_adelante_CheckedChanged);
            // 
            // radioButton_encadenamiento_hacia_atras
            // 
            this.radioButton_encadenamiento_hacia_atras.AutoSize = true;
            this.radioButton_encadenamiento_hacia_atras.Checked = true;
            this.radioButton_encadenamiento_hacia_atras.Location = new System.Drawing.Point(37, 39);
            this.radioButton_encadenamiento_hacia_atras.Name = "radioButton_encadenamiento_hacia_atras";
            this.radioButton_encadenamiento_hacia_atras.Size = new System.Drawing.Size(160, 17);
            this.radioButton_encadenamiento_hacia_atras.TabIndex = 6;
            this.radioButton_encadenamiento_hacia_atras.TabStop = true;
            this.radioButton_encadenamiento_hacia_atras.Text = "Encadenamiento hacia atrás";
            this.radioButton_encadenamiento_hacia_atras.UseVisualStyleBackColor = true;
            this.radioButton_encadenamiento_hacia_atras.CheckedChanged += new System.EventHandler(this.radioButton_encadenamiento_hacia_atras_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de encadenamiento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Seleccionar imagen logo:";
            // 
            // checkBox_chequeo_base_de_conocimiento
            // 
            this.checkBox_chequeo_base_de_conocimiento.AutoSize = true;
            this.checkBox_chequeo_base_de_conocimiento.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_chequeo_base_de_conocimiento.Enabled = false;
            this.checkBox_chequeo_base_de_conocimiento.Location = new System.Drawing.Point(29, 250);
            this.checkBox_chequeo_base_de_conocimiento.Name = "checkBox_chequeo_base_de_conocimiento";
            this.checkBox_chequeo_base_de_conocimiento.Size = new System.Drawing.Size(191, 17);
            this.checkBox_chequeo_base_de_conocimiento.TabIndex = 9;
            this.checkBox_chequeo_base_de_conocimiento.Text = "Base de conocimiento chequeada:";
            this.checkBox_chequeo_base_de_conocimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_chequeo_base_de_conocimiento.UseVisualStyleBackColor = true;
            // 
            // button_chequear_base_de_conocimiento
            // 
            this.button_chequear_base_de_conocimiento.Location = new System.Drawing.Point(254, 246);
            this.button_chequear_base_de_conocimiento.Name = "button_chequear_base_de_conocimiento";
            this.button_chequear_base_de_conocimiento.Size = new System.Drawing.Size(218, 23);
            this.button_chequear_base_de_conocimiento.TabIndex = 10;
            this.button_chequear_base_de_conocimiento.Text = "Chequear base de conocimiento";
            this.button_chequear_base_de_conocimiento.UseVisualStyleBackColor = true;
            this.button_chequear_base_de_conocimiento.Click += new System.EventHandler(this.button_chequear_base_de_conocimiento_Click);
            // 
            // button_seleccion_de_imagen
            // 
            this.button_seleccion_de_imagen.Image = global::Tot.Properties.Resources.lupa_imagenes___32x_32;
            this.button_seleccion_de_imagen.Location = new System.Drawing.Point(415, 83);
            this.button_seleccion_de_imagen.Name = "button_seleccion_de_imagen";
            this.button_seleccion_de_imagen.Size = new System.Drawing.Size(45, 45);
            this.button_seleccion_de_imagen.TabIndex = 6;
            this.button_seleccion_de_imagen.UseVisualStyleBackColor = true;
            this.button_seleccion_de_imagen.Click += new System.EventHandler(this.button_seleccion_de_imagen_Click);
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Location = new System.Drawing.Point(490, 25);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(200, 400);
            this.pictureBox_logo.TabIndex = 5;
            this.pictureBox_logo.TabStop = false;
            // 
            // button_descripcion_sistema_experto
            // 
            this.button_descripcion_sistema_experto.Image = global::Tot.Properties.Resources.lupa_documentos___32_x_32;
            this.button_descripcion_sistema_experto.Location = new System.Drawing.Point(171, 83);
            this.button_descripcion_sistema_experto.Name = "button_descripcion_sistema_experto";
            this.button_descripcion_sistema_experto.Size = new System.Drawing.Size(57, 41);
            this.button_descripcion_sistema_experto.TabIndex = 3;
            this.button_descripcion_sistema_experto.UseVisualStyleBackColor = true;
            this.button_descripcion_sistema_experto.Click += new System.EventHandler(this.button_descripcion_sistema_experto_Click);
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(355, 402);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(117, 23);
            this.button_aceptar.TabIndex = 11;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // openFileDialog_imagen_logo
            // 
            this.openFileDialog_imagen_logo.Filter = "Images|*.jpg;";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "(200 x 400 Pixeles)";
            // 
            // imageList_check_base_conocimiento
            // 
            this.imageList_check_base_conocimiento.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_check_base_conocimiento.ImageStream")));
            this.imageList_check_base_conocimiento.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_check_base_conocimiento.Images.SetKeyName(0, "conocimiento_error.png");
            this.imageList_check_base_conocimiento.Images.SetKeyName(1, "conocimiento_ok.png");
            // 
            // pictureBox_check_bae_de_conocimiento
            // 
            this.pictureBox_check_bae_de_conocimiento.Location = new System.Drawing.Point(45, 273);
            this.pictureBox_check_bae_de_conocimiento.Name = "pictureBox_check_bae_de_conocimiento";
            this.pictureBox_check_bae_de_conocimiento.Size = new System.Drawing.Size(132, 132);
            this.pictureBox_check_bae_de_conocimiento.TabIndex = 13;
            this.pictureBox_check_bae_de_conocimiento.TabStop = false;
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(232, 402);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(117, 23);
            this.button_cancelar.TabIndex = 14;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Visible = false;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // ControlConfiguracionBaseDeConocimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.pictureBox_check_bae_de_conocimiento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_chequear_base_de_conocimiento);
            this.Controls.Add(this.checkBox_chequeo_base_de_conocimiento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_seleccion_de_imagen);
            this.Controls.Add(this.pictureBox_logo);
            this.Controls.Add(this.panel_tipo_encadenamiento);
            this.Controls.Add(this.button_descripcion_sistema_experto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_titulo);
            this.Controls.Add(this.label1);
            this.Name = "ControlConfiguracionBaseDeConocimiento";
            this.Size = new System.Drawing.Size(713, 448);
            this.panel_tipo_encadenamiento.ResumeLayout(false);
            this.panel_tipo_encadenamiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_check_bae_de_conocimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_titulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_descripcion_sistema_experto;
        private System.Windows.Forms.Panel panel_tipo_encadenamiento;
        private System.Windows.Forms.RadioButton radioButton_encadenamiento_hacia_adelante;
        private System.Windows.Forms.RadioButton radioButton_encadenamiento_hacia_atras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.Button button_seleccion_de_imagen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_chequeo_base_de_conocimiento;
        private System.Windows.Forms.Button button_chequear_base_de_conocimiento;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.OpenFileDialog openFileDialog_imagen_logo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ImageList imageList_check_base_conocimiento;
        private System.Windows.Forms.PictureBox pictureBox_check_bae_de_conocimiento;
        private System.Windows.Forms.Button button_cancelar;
    }
}
