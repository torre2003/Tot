namespace Tot
{
    partial class ControlEdicionReglas
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
            this.label_enton = new System.Windows.Forms.Label();
            this.comboBox_var_entonces = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_condicion_entonces = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_lista_entonces = new System.Windows.Forms.ComboBox();
            this.button_agregar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.panel_entonces = new System.Windows.Forms.Panel();
            this.label_rango_entonces = new System.Windows.Forms.Label();
            this.numericUpDown_entonces = new System.Windows.Forms.NumericUpDown();
            this.textBox_entonces = new System.Windows.Forms.TextBox();
            this.panel_entonces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entonces)).BeginInit();
            this.SuspendLayout();
            // 
            // label_enton
            // 
            this.label_enton.AutoSize = true;
            this.label_enton.Location = new System.Drawing.Point(9, 17);
            this.label_enton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_enton.Name = "label_enton";
            this.label_enton.Size = new System.Drawing.Size(67, 17);
            this.label_enton.TabIndex = 1;
            this.label_enton.Text = "Entonces";
            // 
            // comboBox_var_entonces
            // 
            this.comboBox_var_entonces.FormattingEnabled = true;
            this.comboBox_var_entonces.Location = new System.Drawing.Point(87, 14);
            this.comboBox_var_entonces.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_var_entonces.Name = "comboBox_var_entonces";
            this.comboBox_var_entonces.Size = new System.Drawing.Size(288, 24);
            this.comboBox_var_entonces.TabIndex = 3;
            this.comboBox_var_entonces.SelectedIndexChanged += new System.EventHandler(this.comboBox_var_entonces_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Variable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Condición";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_condicion_entonces
            // 
            this.comboBox_condicion_entonces.FormattingEnabled = true;
            this.comboBox_condicion_entonces.Location = new System.Drawing.Point(416, 17);
            this.comboBox_condicion_entonces.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_condicion_entonces.Name = "comboBox_condicion_entonces";
            this.comboBox_condicion_entonces.Size = new System.Drawing.Size(103, 24);
            this.comboBox_condicion_entonces.TabIndex = 7;
            this.comboBox_condicion_entonces.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Valor Condición";
            // 
            // comboBox_lista_entonces
            // 
            this.comboBox_lista_entonces.FormattingEnabled = true;
            this.comboBox_lista_entonces.Location = new System.Drawing.Point(549, 17);
            this.comboBox_lista_entonces.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_lista_entonces.Name = "comboBox_lista_entonces";
            this.comboBox_lista_entonces.Size = new System.Drawing.Size(185, 24);
            this.comboBox_lista_entonces.TabIndex = 10;
            this.comboBox_lista_entonces.Visible = false;
            // 
            // button_agregar
            // 
            this.button_agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_agregar.Location = new System.Drawing.Point(827, 28);
            this.button_agregar.Margin = new System.Windows.Forms.Padding(4);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.Size = new System.Drawing.Size(52, 159);
            this.button_agregar.TabIndex = 12;
            this.button_agregar.Text = "Agregar";
            this.button_agregar.UseVisualStyleBackColor = true;
            this.button_agregar.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancelar.Location = new System.Drawing.Point(551, 194);
            this.button_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(160, 28);
            this.button_cancelar.TabIndex = 13;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_aceptar.Location = new System.Drawing.Point(719, 194);
            this.button_aceptar.Margin = new System.Windows.Forms.Padding(4);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(160, 28);
            this.button_aceptar.TabIndex = 15;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // panel_entonces
            // 
            this.panel_entonces.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel_entonces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_entonces.Controls.Add(this.label_rango_entonces);
            this.panel_entonces.Controls.Add(this.numericUpDown_entonces);
            this.panel_entonces.Controls.Add(this.textBox_entonces);
            this.panel_entonces.Controls.Add(this.label_enton);
            this.panel_entonces.Controls.Add(this.comboBox_var_entonces);
            this.panel_entonces.Controls.Add(this.comboBox_condicion_entonces);
            this.panel_entonces.Controls.Add(this.comboBox_lista_entonces);
            this.panel_entonces.Location = new System.Drawing.Point(21, 122);
            this.panel_entonces.Margin = new System.Windows.Forms.Padding(4);
            this.panel_entonces.Name = "panel_entonces";
            this.panel_entonces.Size = new System.Drawing.Size(796, 64);
            this.panel_entonces.TabIndex = 16;
            // 
            // label_rango_entonces
            // 
            this.label_rango_entonces.Location = new System.Drawing.Point(546, 43);
            this.label_rango_entonces.Name = "label_rango_entonces";
            this.label_rango_entonces.Size = new System.Drawing.Size(188, 17);
            this.label_rango_entonces.TabIndex = 13;
            this.label_rango_entonces.Text = "label4";
            this.label_rango_entonces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_rango_entonces.Visible = false;
            // 
            // numericUpDown_entonces
            // 
            this.numericUpDown_entonces.Location = new System.Drawing.Point(549, 17);
            this.numericUpDown_entonces.Name = "numericUpDown_entonces";
            this.numericUpDown_entonces.Size = new System.Drawing.Size(185, 22);
            this.numericUpDown_entonces.TabIndex = 12;
            this.numericUpDown_entonces.Visible = false;
            // 
            // textBox_entonces
            // 
            this.textBox_entonces.Location = new System.Drawing.Point(549, 18);
            this.textBox_entonces.Name = "textBox_entonces";
            this.textBox_entonces.Size = new System.Drawing.Size(185, 22);
            this.textBox_entonces.TabIndex = 11;
            this.textBox_entonces.Visible = false;
            // 
            // ControlEdicionReglas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_entonces);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_agregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ControlEdicionReglas";
            this.Size = new System.Drawing.Size(907, 247);
            this.panel_entonces.ResumeLayout(false);
            this.panel_entonces.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_entonces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_enton;
        private System.Windows.Forms.ComboBox comboBox_var_entonces;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_condicion_entonces;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_lista_entonces;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Panel panel_entonces;
        private System.Windows.Forms.TextBox textBox_entonces;
        private System.Windows.Forms.NumericUpDown numericUpDown_entonces;
        private System.Windows.Forms.Label label_rango_entonces;
    }
}
