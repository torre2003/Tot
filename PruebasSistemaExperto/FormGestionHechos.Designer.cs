namespace PruebasSistemaExperto
{
    partial class FormGestionHechos
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
            this.button_agregar_hecho = new System.Windows.Forms.Button();
            this.textBox_hecho = new System.Windows.Forms.TextBox();
            this.button_eliminar_hecho = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_hechos
            // 
            this.listBox_hechos.FormattingEnabled = true;
            this.listBox_hechos.ItemHeight = 16;
            this.listBox_hechos.Location = new System.Drawing.Point(40, 159);
            this.listBox_hechos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox_hechos.Name = "listBox_hechos";
            this.listBox_hechos.Size = new System.Drawing.Size(381, 420);
            this.listBox_hechos.TabIndex = 0;
            // 
            // button_agregar_hecho
            // 
            this.button_agregar_hecho.Location = new System.Drawing.Point(291, 57);
            this.button_agregar_hecho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_agregar_hecho.Name = "button_agregar_hecho";
            this.button_agregar_hecho.Size = new System.Drawing.Size(132, 28);
            this.button_agregar_hecho.TabIndex = 1;
            this.button_agregar_hecho.Text = "Agregar Hecho";
            this.button_agregar_hecho.UseVisualStyleBackColor = true;
            this.button_agregar_hecho.Click += new System.EventHandler(this.button_agregar_hecho_Click);
            // 
            // textBox_hecho
            // 
            this.textBox_hecho.Location = new System.Drawing.Point(40, 57);
            this.textBox_hecho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_hecho.Name = "textBox_hecho";
            this.textBox_hecho.Size = new System.Drawing.Size(241, 22);
            this.textBox_hecho.TabIndex = 2;
            // 
            // button_eliminar_hecho
            // 
            this.button_eliminar_hecho.Location = new System.Drawing.Point(291, 101);
            this.button_eliminar_hecho.Name = "button_eliminar_hecho";
            this.button_eliminar_hecho.Size = new System.Drawing.Size(132, 23);
            this.button_eliminar_hecho.TabIndex = 3;
            this.button_eliminar_hecho.Text = "Elimnar Hecho";
            this.button_eliminar_hecho.UseVisualStyleBackColor = true;
            this.button_eliminar_hecho.Click += new System.EventHandler(this.button_eliminar_hecho_Click);
            // 
            // FormGestionHechos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 757);
            this.Controls.Add(this.button_eliminar_hecho);
            this.Controls.Add(this.textBox_hecho);
            this.Controls.Add(this.button_agregar_hecho);
            this.Controls.Add(this.listBox_hechos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormGestionHechos";
            this.Text = "FormGestionHechos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGestionHechos_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_hechos;
        private System.Windows.Forms.Button button_agregar_hecho;
        private System.Windows.Forms.TextBox textBox_hecho;
        private System.Windows.Forms.Button button_eliminar_hecho;
    }
}