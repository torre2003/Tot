namespace Tot
{
    partial class FormVentanaConfiguracionLogInferencia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_formato_variable = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_variable_id = new System.Windows.Forms.RadioButton();
            this.radioButton_variable_contenido = new System.Windows.Forms.RadioButton();
            this.radioButton_variable_id_contenido = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton_hecho_id_contenido = new System.Windows.Forms.RadioButton();
            this.radioButton_hecho_contenido = new System.Windows.Forms.RadioButton();
            this.radioButton_hecho_id = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton_regla_id_contenido = new System.Windows.Forms.RadioButton();
            this.radioButton_regla_contenido = new System.Windows.Forms.RadioButton();
            this.radioButton_regla_id = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_formato_variable.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_formato_variable
            // 
            this.panel_formato_variable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_formato_variable.Controls.Add(this.panel3);
            this.panel_formato_variable.Controls.Add(this.panel2);
            this.panel_formato_variable.Controls.Add(this.panel1);
            this.panel_formato_variable.Controls.Add(this.label1);
            this.panel_formato_variable.Location = new System.Drawing.Point(12, 12);
            this.panel_formato_variable.Name = "panel_formato_variable";
            this.panel_formato_variable.Size = new System.Drawing.Size(550, 150);
            this.panel_formato_variable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eliga el formato a mostrar en el log de inferencia:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButton_variable_id_contenido);
            this.panel1.Controls.Add(this.radioButton_variable_contenido);
            this.panel1.Controls.Add(this.radioButton_variable_id);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(23, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 103);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Variables:";
            // 
            // radioButton_variable_id
            // 
            this.radioButton_variable_id.AutoSize = true;
            this.radioButton_variable_id.Location = new System.Drawing.Point(17, 21);
            this.radioButton_variable_id.Name = "radioButton_variable_id";
            this.radioButton_variable_id.Size = new System.Drawing.Size(36, 17);
            this.radioButton_variable_id.TabIndex = 1;
            this.radioButton_variable_id.TabStop = true;
            this.radioButton_variable_id.Text = "ID";
            this.radioButton_variable_id.UseVisualStyleBackColor = true;
            // 
            // radioButton_variable_contenido
            // 
            this.radioButton_variable_contenido.AutoSize = true;
            this.radioButton_variable_contenido.Location = new System.Drawing.Point(17, 44);
            this.radioButton_variable_contenido.Name = "radioButton_variable_contenido";
            this.radioButton_variable_contenido.Size = new System.Drawing.Size(72, 17);
            this.radioButton_variable_contenido.TabIndex = 2;
            this.radioButton_variable_contenido.TabStop = true;
            this.radioButton_variable_contenido.Text = "NOMBRE";
            this.radioButton_variable_contenido.UseVisualStyleBackColor = true;
            // 
            // radioButton_variable_id_contenido
            // 
            this.radioButton_variable_id_contenido.AutoSize = true;
            this.radioButton_variable_id_contenido.Location = new System.Drawing.Point(17, 67);
            this.radioButton_variable_id_contenido.Name = "radioButton_variable_id_contenido";
            this.radioButton_variable_id_contenido.Size = new System.Drawing.Size(95, 17);
            this.radioButton_variable_id_contenido.TabIndex = 3;
            this.radioButton_variable_id_contenido.TabStop = true;
            this.radioButton_variable_id_contenido.Text = "ID + NOMBRE";
            this.radioButton_variable_id_contenido.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radioButton_hecho_id_contenido);
            this.panel2.Controls.Add(this.radioButton_hecho_contenido);
            this.panel2.Controls.Add(this.radioButton_hecho_id);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(201, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 103);
            this.panel2.TabIndex = 4;
            // 
            // radioButton_hecho_id_contenido
            // 
            this.radioButton_hecho_id_contenido.AutoSize = true;
            this.radioButton_hecho_id_contenido.Location = new System.Drawing.Point(17, 67);
            this.radioButton_hecho_id_contenido.Name = "radioButton_hecho_id_contenido";
            this.radioButton_hecho_id_contenido.Size = new System.Drawing.Size(108, 17);
            this.radioButton_hecho_id_contenido.TabIndex = 3;
            this.radioButton_hecho_id_contenido.TabStop = true;
            this.radioButton_hecho_id_contenido.Text = "ID + CONDICIÓN";
            this.radioButton_hecho_id_contenido.UseVisualStyleBackColor = true;
            // 
            // radioButton_hecho_contenido
            // 
            this.radioButton_hecho_contenido.AutoSize = true;
            this.radioButton_hecho_contenido.Location = new System.Drawing.Point(17, 44);
            this.radioButton_hecho_contenido.Name = "radioButton_hecho_contenido";
            this.radioButton_hecho_contenido.Size = new System.Drawing.Size(85, 17);
            this.radioButton_hecho_contenido.TabIndex = 2;
            this.radioButton_hecho_contenido.TabStop = true;
            this.radioButton_hecho_contenido.Text = "CONDICIÓN";
            this.radioButton_hecho_contenido.UseVisualStyleBackColor = true;
            // 
            // radioButton_hecho_id
            // 
            this.radioButton_hecho_id.AutoSize = true;
            this.radioButton_hecho_id.Location = new System.Drawing.Point(17, 21);
            this.radioButton_hecho_id.Name = "radioButton_hecho_id";
            this.radioButton_hecho_id.Size = new System.Drawing.Size(36, 17);
            this.radioButton_hecho_id.TabIndex = 1;
            this.radioButton_hecho_id.TabStop = true;
            this.radioButton_hecho_id.Text = "ID";
            this.radioButton_hecho_id.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hechos:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.radioButton_regla_id_contenido);
            this.panel3.Controls.Add(this.radioButton_regla_contenido);
            this.panel3.Controls.Add(this.radioButton_regla_id);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(376, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(139, 103);
            this.panel3.TabIndex = 4;
            // 
            // radioButton_regla_id_contenido
            // 
            this.radioButton_regla_id_contenido.AutoSize = true;
            this.radioButton_regla_id_contenido.Location = new System.Drawing.Point(17, 67);
            this.radioButton_regla_id_contenido.Name = "radioButton_regla_id_contenido";
            this.radioButton_regla_id_contenido.Size = new System.Drawing.Size(84, 17);
            this.radioButton_regla_id_contenido.TabIndex = 3;
            this.radioButton_regla_id_contenido.TabStop = true;
            this.radioButton_regla_id_contenido.Text = "ID + REGLA";
            this.radioButton_regla_id_contenido.UseVisualStyleBackColor = true;
            // 
            // radioButton_regla_contenido
            // 
            this.radioButton_regla_contenido.AutoSize = true;
            this.radioButton_regla_contenido.Location = new System.Drawing.Point(17, 44);
            this.radioButton_regla_contenido.Name = "radioButton_regla_contenido";
            this.radioButton_regla_contenido.Size = new System.Drawing.Size(61, 17);
            this.radioButton_regla_contenido.TabIndex = 2;
            this.radioButton_regla_contenido.TabStop = true;
            this.radioButton_regla_contenido.Text = "REGLA";
            this.radioButton_regla_contenido.UseVisualStyleBackColor = true;
            // 
            // radioButton_regla_id
            // 
            this.radioButton_regla_id.AutoSize = true;
            this.radioButton_regla_id.Location = new System.Drawing.Point(17, 21);
            this.radioButton_regla_id.Name = "radioButton_regla_id";
            this.radioButton_regla_id.Size = new System.Drawing.Size(36, 17);
            this.radioButton_regla_id.TabIndex = 1;
            this.radioButton_regla_id.TabStop = true;
            this.radioButton_regla_id.Text = "ID";
            this.radioButton_regla_id.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Reglas:";
            // 
            // FormVentanaConfiguracionLogInferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(584, 532);
            this.Controls.Add(this.panel_formato_variable);
            this.MaximumSize = new System.Drawing.Size(600, 570);
            this.MinimumSize = new System.Drawing.Size(600, 570);
            this.Name = "FormVentanaConfiguracionLogInferencia";
            this.Text = "FormVentanaConfiguracionLogInferencia";
            this.panel_formato_variable.ResumeLayout(false);
            this.panel_formato_variable.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_formato_variable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton_regla_id_contenido;
        private System.Windows.Forms.RadioButton radioButton_regla_contenido;
        private System.Windows.Forms.RadioButton radioButton_regla_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton_hecho_id_contenido;
        private System.Windows.Forms.RadioButton radioButton_hecho_contenido;
        private System.Windows.Forms.RadioButton radioButton_hecho_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton_variable_id_contenido;
        private System.Windows.Forms.RadioButton radioButton_variable_contenido;
        private System.Windows.Forms.RadioButton radioButton_variable_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}