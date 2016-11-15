namespace Tot
{
    partial class ControlGestionReglas
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
            this.listBox_reglas = new System.Windows.Forms.ListBox();
            this.button_agregar = new System.Windows.Forms.Button();
            this.button_modificar = new System.Windows.Forms.Button();
            this.button_eliminar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.control_edicion_de_reglas = new Tot.ControlEdicionReglas();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_reglas
            // 
            this.listBox_reglas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_reglas.FormattingEnabled = true;
            this.listBox_reglas.Location = new System.Drawing.Point(43, 44);
            this.listBox_reglas.Name = "listBox_reglas";
            this.listBox_reglas.Size = new System.Drawing.Size(563, 173);
            this.listBox_reglas.TabIndex = 0;
            this.listBox_reglas.SelectedIndexChanged += new System.EventHandler(this.listBox_reglas_SelectedIndexChanged);
            // 
            // button_agregar
            // 
            this.button_agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_agregar.Location = new System.Drawing.Point(323, 243);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.Size = new System.Drawing.Size(75, 23);
            this.button_agregar.TabIndex = 7;
            this.button_agregar.Text = "Agregar ";
            this.button_agregar.UseVisualStyleBackColor = true;
            this.button_agregar.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_modificar.Location = new System.Drawing.Point(433, 243);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(75, 23);
            this.button_modificar.TabIndex = 6;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            // 
            // button_eliminar
            // 
            this.button_eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_eliminar.Location = new System.Drawing.Point(539, 243);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(75, 23);
            this.button_eliminar.TabIndex = 5;
            this.button_eliminar.Text = "Eliminar";
            this.button_eliminar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.control_edicion_de_reglas);
            this.panel2.Location = new System.Drawing.Point(17, 284);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 291);
            this.panel2.TabIndex = 10;
            // 
            // control_edicion_de_reglas
            // 
            this.control_edicion_de_reglas.Location = new System.Drawing.Point(3, 3);
            this.control_edicion_de_reglas.Name = "control_edicion_de_reglas";
            this.control_edicion_de_reglas.Size = new System.Drawing.Size(696, 201);
            this.control_edicion_de_reglas.TabIndex = 0;
            // 
            // ControlGestionReglas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button_agregar);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_eliminar);
            this.Controls.Add(this.listBox_reglas);
            this.Name = "ControlGestionReglas";
            this.Size = new System.Drawing.Size(740, 589);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_reglas;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.Button button_eliminar;
        private System.Windows.Forms.Panel panel2;
        private ControlEdicionReglas control_edicion_de_reglas;
    }
}
