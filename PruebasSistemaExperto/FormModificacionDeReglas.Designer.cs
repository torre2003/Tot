namespace PruebasSistemaExperto
{
    partial class FormModificacionDeReglas
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
            this.listBox_hechos = new System.Windows.Forms.ListBox();
            this.listBox_antecedentes = new System.Windows.Forms.ListBox();
            this.listBox_consecuentes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_agregar_hecho_antecedente = new System.Windows.Forms.Button();
            this.button_agregar_hecho_concecuente = new System.Windows.Forms.Button();
            this.button_quitar_hecho_antecedente = new System.Windows.Forms.Button();
            this.button_quitar_hecho_consecuente = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_hechos
            // 
            this.listBox_hechos.FormattingEnabled = true;
            this.listBox_hechos.ItemHeight = 16;
            this.listBox_hechos.Location = new System.Drawing.Point(40, 86);
            this.listBox_hechos.Name = "listBox_hechos";
            this.listBox_hechos.Size = new System.Drawing.Size(254, 372);
            this.listBox_hechos.TabIndex = 0;
            // 
            // listBox_antecedentes
            // 
            this.listBox_antecedentes.FormattingEnabled = true;
            this.listBox_antecedentes.ItemHeight = 16;
            this.listBox_antecedentes.Location = new System.Drawing.Point(403, 86);
            this.listBox_antecedentes.Name = "listBox_antecedentes";
            this.listBox_antecedentes.Size = new System.Drawing.Size(254, 148);
            this.listBox_antecedentes.TabIndex = 1;
            // 
            // listBox_consecuentes
            // 
            this.listBox_consecuentes.FormattingEnabled = true;
            this.listBox_consecuentes.ItemHeight = 16;
            this.listBox_consecuentes.Location = new System.Drawing.Point(403, 310);
            this.listBox_consecuentes.Name = "listBox_consecuentes";
            this.listBox_consecuentes.Size = new System.Drawing.Size(254, 148);
            this.listBox_consecuentes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lista de hechos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Antecedentes ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Consecuentes";
            // 
            // button_agregar_hecho_antecedente
            // 
            this.button_agregar_hecho_antecedente.Location = new System.Drawing.Point(315, 97);
            this.button_agregar_hecho_antecedente.Name = "button_agregar_hecho_antecedente";
            this.button_agregar_hecho_antecedente.Size = new System.Drawing.Size(64, 49);
            this.button_agregar_hecho_antecedente.TabIndex = 6;
            this.button_agregar_hecho_antecedente.Text = ">>>";
            this.button_agregar_hecho_antecedente.UseVisualStyleBackColor = true;
            this.button_agregar_hecho_antecedente.Click += new System.EventHandler(this.button_agregar_hecho_antecedente_Click);
            // 
            // button_agregar_hecho_concecuente
            // 
            this.button_agregar_hecho_concecuente.Location = new System.Drawing.Point(315, 310);
            this.button_agregar_hecho_concecuente.Name = "button_agregar_hecho_concecuente";
            this.button_agregar_hecho_concecuente.Size = new System.Drawing.Size(64, 49);
            this.button_agregar_hecho_concecuente.TabIndex = 7;
            this.button_agregar_hecho_concecuente.Text = ">>>";
            this.button_agregar_hecho_concecuente.UseVisualStyleBackColor = true;
            this.button_agregar_hecho_concecuente.Click += new System.EventHandler(this.button_agregar_hecho_concecuente_Click);
            // 
            // button_quitar_hecho_antecedente
            // 
            this.button_quitar_hecho_antecedente.Location = new System.Drawing.Point(315, 175);
            this.button_quitar_hecho_antecedente.Name = "button_quitar_hecho_antecedente";
            this.button_quitar_hecho_antecedente.Size = new System.Drawing.Size(64, 49);
            this.button_quitar_hecho_antecedente.TabIndex = 8;
            this.button_quitar_hecho_antecedente.Text = "<<<";
            this.button_quitar_hecho_antecedente.UseVisualStyleBackColor = true;
            this.button_quitar_hecho_antecedente.Click += new System.EventHandler(this.button_quitar_hecho_antecedente_Click);
            // 
            // button_quitar_hecho_consecuente
            // 
            this.button_quitar_hecho_consecuente.Location = new System.Drawing.Point(315, 390);
            this.button_quitar_hecho_consecuente.Name = "button_quitar_hecho_consecuente";
            this.button_quitar_hecho_consecuente.Size = new System.Drawing.Size(64, 49);
            this.button_quitar_hecho_consecuente.TabIndex = 9;
            this.button_quitar_hecho_consecuente.Text = "<<<";
            this.button_quitar_hecho_consecuente.UseVisualStyleBackColor = true;
            this.button_quitar_hecho_consecuente.Click += new System.EventHandler(this.button_quitar_hecho_consecuente_Click);
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(215, 487);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(254, 23);
            this.Aceptar.TabIndex = 10;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // FormModificacionDeReglas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 544);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.button_quitar_hecho_consecuente);
            this.Controls.Add(this.button_quitar_hecho_antecedente);
            this.Controls.Add(this.button_agregar_hecho_concecuente);
            this.Controls.Add(this.button_agregar_hecho_antecedente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_consecuentes);
            this.Controls.Add(this.listBox_antecedentes);
            this.Controls.Add(this.listBox_hechos);
            this.Name = "FormModificacionDeReglas";
            this.Text = "FormModificacionDeReglas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_hechos;
        private System.Windows.Forms.ListBox listBox_antecedentes;
        private System.Windows.Forms.ListBox listBox_consecuentes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_agregar_hecho_antecedente;
        private System.Windows.Forms.Button button_agregar_hecho_concecuente;
        private System.Windows.Forms.Button button_quitar_hecho_antecedente;
        private System.Windows.Forms.Button button_quitar_hecho_consecuente;
        private System.Windows.Forms.Button Aceptar;
    }
}