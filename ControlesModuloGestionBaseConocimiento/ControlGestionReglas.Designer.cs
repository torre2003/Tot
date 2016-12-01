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
            this.label1 = new System.Windows.Forms.Label();
            this.control_edicion_de_reglas = new Tot.ControlEdicionReglas();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_reglas
            // 
            this.listBox_reglas.FormattingEnabled = true;
            this.listBox_reglas.HorizontalExtent = 1400;
            this.listBox_reglas.HorizontalScrollbar = true;
            this.listBox_reglas.Location = new System.Drawing.Point(43, 44);
            this.listBox_reglas.Name = "listBox_reglas";
            this.listBox_reglas.Size = new System.Drawing.Size(678, 173);
            this.listBox_reglas.TabIndex = 0;
            this.listBox_reglas.SelectedIndexChanged += new System.EventHandler(this.listBox_reglas_SelectedIndexChanged);
            // 
            // button_agregar
            // 
            this.button_agregar.Location = new System.Drawing.Point(425, 241);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.Size = new System.Drawing.Size(75, 23);
            this.button_agregar.TabIndex = 7;
            this.button_agregar.Text = "Agregar ";
            this.button_agregar.UseVisualStyleBackColor = true;
            this.button_agregar.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.Location = new System.Drawing.Point(535, 241);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(75, 23);
            this.button_modificar.TabIndex = 6;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // button_eliminar
            // 
            this.button_eliminar.Location = new System.Drawing.Point(641, 241);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(75, 23);
            this.button_eliminar.TabIndex = 5;
            this.button_eliminar.Text = "Eliminar";
            this.button_eliminar.UseVisualStyleBackColor = true;
            this.button_eliminar.Click += new System.EventHandler(this.button_eliminar_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.control_edicion_de_reglas);
            this.panel2.Location = new System.Drawing.Point(17, 284);
            this.panel2.MinimumSize = new System.Drawing.Size(714, 271);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(714, 271);
            this.panel2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Lista de reglas:";
            // 
            // control_edicion_de_reglas
            // 
            this.control_edicion_de_reglas.Location = new System.Drawing.Point(14, 22);
            this.control_edicion_de_reglas.Margin = new System.Windows.Forms.Padding(4);
            this.control_edicion_de_reglas.Name = "control_edicion_de_reglas";
            this.control_edicion_de_reglas.Size = new System.Drawing.Size(696, 201);
            this.control_edicion_de_reglas.TabIndex = 0;
            // 
            // ControlGestionReglas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button_agregar);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_eliminar);
            this.Controls.Add(this.listBox_reglas);
            this.MaximumSize = new System.Drawing.Size(789, 584);
            this.MinimumSize = new System.Drawing.Size(789, 584);
            this.Name = "ControlGestionReglas";
            this.Size = new System.Drawing.Size(789, 584);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_reglas;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.Button button_eliminar;
        private System.Windows.Forms.Panel panel2;
        private ControlEdicionReglas control_edicion_de_reglas;
        private System.Windows.Forms.Label label1;
    }
}
