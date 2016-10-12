namespace PruebasSistemaExperto
{
    partial class FormVentanaPrincipal
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
            this.button_gestion_de_hechos = new System.Windows.Forms.Button();
            this.button_gestion_de_reglas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_gestion_de_hechos
            // 
            this.button_gestion_de_hechos.Location = new System.Drawing.Point(91, 58);
            this.button_gestion_de_hechos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_gestion_de_hechos.Name = "button_gestion_de_hechos";
            this.button_gestion_de_hechos.Size = new System.Drawing.Size(249, 28);
            this.button_gestion_de_hechos.TabIndex = 0;
            this.button_gestion_de_hechos.Text = "Gestíón de Hechos";
            this.button_gestion_de_hechos.UseVisualStyleBackColor = true;
            this.button_gestion_de_hechos.Click += new System.EventHandler(this.button_gestion_de_hechos_Click);
            // 
            // button_gestion_de_reglas
            // 
            this.button_gestion_de_reglas.Location = new System.Drawing.Point(91, 103);
            this.button_gestion_de_reglas.Name = "button_gestion_de_reglas";
            this.button_gestion_de_reglas.Size = new System.Drawing.Size(249, 23);
            this.button_gestion_de_reglas.TabIndex = 1;
            this.button_gestion_de_reglas.Text = "Gestión de reglas";
            this.button_gestion_de_reglas.UseVisualStyleBackColor = true;
            this.button_gestion_de_reglas.Click += new System.EventHandler(this.button_gestion_de_reglas_Click);
            // 
            // FormVentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 796);
            this.Controls.Add(this.button_gestion_de_reglas);
            this.Controls.Add(this.button_gestion_de_hechos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormVentanaPrincipal";
            this.Text = "FormVentanaPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_gestion_de_hechos;
        private System.Windows.Forms.Button button_gestion_de_reglas;
    }
}