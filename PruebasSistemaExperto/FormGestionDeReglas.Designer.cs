namespace PruebasSistemaExperto
{
    partial class FormGestionDeReglas
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
            this.listBox_reglas = new System.Windows.Forms.ListBox();
            this.button_agregar_regla = new System.Windows.Forms.Button();
            this.button_eliminar_regla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_reglas
            // 
            this.listBox_reglas.FormattingEnabled = true;
            this.listBox_reglas.Location = new System.Drawing.Point(30, 84);
            this.listBox_reglas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox_reglas.Name = "listBox_reglas";
            this.listBox_reglas.Size = new System.Drawing.Size(540, 225);
            this.listBox_reglas.TabIndex = 0;
            // 
            // button_agregar_regla
            // 
            this.button_agregar_regla.Location = new System.Drawing.Point(30, 50);
            this.button_agregar_regla.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_agregar_regla.Name = "button_agregar_regla";
            this.button_agregar_regla.Size = new System.Drawing.Size(169, 21);
            this.button_agregar_regla.TabIndex = 1;
            this.button_agregar_regla.Text = "Agregar regla";
            this.button_agregar_regla.UseVisualStyleBackColor = true;
            this.button_agregar_regla.Click += new System.EventHandler(this.button_agregar_regla_Click);
            // 
            // button_eliminar_regla
            // 
            this.button_eliminar_regla.Location = new System.Drawing.Point(223, 50);
            this.button_eliminar_regla.Name = "button_eliminar_regla";
            this.button_eliminar_regla.Size = new System.Drawing.Size(170, 23);
            this.button_eliminar_regla.TabIndex = 2;
            this.button_eliminar_regla.Text = "Eliminar regla";
            this.button_eliminar_regla.UseVisualStyleBackColor = true;
            this.button_eliminar_regla.Click += new System.EventHandler(this.button_eliminar_regla_Click);
            // 
            // FormGestionDeReglas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 558);
            this.Controls.Add(this.button_eliminar_regla);
            this.Controls.Add(this.button_agregar_regla);
            this.Controls.Add(this.listBox_reglas);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormGestionDeReglas";
            this.Text = "FormGestionDeReglas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGestionDeReglas_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_reglas;
        private System.Windows.Forms.Button button_agregar_regla;
        private System.Windows.Forms.Button button_eliminar_regla;
    }
}