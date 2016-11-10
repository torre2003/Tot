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
            this.label_entonces = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.button_agregar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.panel_entonces = new System.Windows.Forms.Panel();
            this.panel_entonces.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_entonces
            // 
            this.label_entonces.AutoSize = true;
            this.label_entonces.Location = new System.Drawing.Point(7, 14);
            this.label_entonces.Name = "label_entonces";
            this.label_entonces.Size = new System.Drawing.Size(52, 13);
            this.label_entonces.TabIndex = 1;
            this.label_entonces.Text = "Entonces";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(65, 14);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(217, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Variable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Condición";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(312, 14);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(78, 21);
            this.comboBox4.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Valor Condición";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(412, 14);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(140, 21);
            this.comboBox6.TabIndex = 10;
            // 
            // button_agregar
            // 
            this.button_agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_agregar.Location = new System.Drawing.Point(620, 23);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.Size = new System.Drawing.Size(39, 129);
            this.button_agregar.TabIndex = 12;
            this.button_agregar.Text = "Agregar";
            this.button_agregar.UseVisualStyleBackColor = true;
            this.button_agregar.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancelar.Location = new System.Drawing.Point(413, 158);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(120, 23);
            this.button_cancelar.TabIndex = 13;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_aceptar.Location = new System.Drawing.Point(539, 158);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(120, 23);
            this.button_aceptar.TabIndex = 15;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            // 
            // panel_entonces
            // 
            this.panel_entonces.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel_entonces.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_entonces.Controls.Add(this.label_entonces);
            this.panel_entonces.Controls.Add(this.comboBox2);
            this.panel_entonces.Controls.Add(this.comboBox4);
            this.panel_entonces.Controls.Add(this.comboBox6);
            this.panel_entonces.Location = new System.Drawing.Point(16, 99);
            this.panel_entonces.Name = "panel_entonces";
            this.panel_entonces.Size = new System.Drawing.Size(598, 53);
            this.panel_entonces.TabIndex = 16;
            // 
            // ControlEdicionReglas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_entonces);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_agregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ControlEdicionReglas";
            this.Size = new System.Drawing.Size(680, 201);
            this.panel_entonces.ResumeLayout(false);
            this.panel_entonces.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_entonces;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Panel panel_entonces;
    }
}
