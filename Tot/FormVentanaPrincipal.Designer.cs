namespace Tot
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_salir = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDelConocimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_editor_base_conocimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.motorDeInferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarInferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaBaseDeConocimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.gestiónDelConocimientoToolStripMenuItem,
            this.motorDeInferenciaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaBaseDeConocimientoToolStripMenuItem,
            this.configuraciónToolStripMenuItem,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_salir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // ToolStripMenuItem_salir
            // 
            this.ToolStripMenuItem_salir.Name = "ToolStripMenuItem_salir";
            this.ToolStripMenuItem_salir.Size = new System.Drawing.Size(228, 22);
            this.ToolStripMenuItem_salir.Text = "Salir";
            this.ToolStripMenuItem_salir.Click += new System.EventHandler(this.ToolStripMenuItem_salir_Click);
            // 
            // gestiónDelConocimientoToolStripMenuItem
            // 
            this.gestiónDelConocimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_editor_base_conocimiento});
            this.gestiónDelConocimientoToolStripMenuItem.Name = "gestiónDelConocimientoToolStripMenuItem";
            this.gestiónDelConocimientoToolStripMenuItem.Size = new System.Drawing.Size(155, 20);
            this.gestiónDelConocimientoToolStripMenuItem.Text = "Gestión del conocimiento";
            // 
            // ToolStripMenuItem_editor_base_conocimiento
            // 
            this.ToolStripMenuItem_editor_base_conocimiento.Name = "ToolStripMenuItem_editor_base_conocimiento";
            this.ToolStripMenuItem_editor_base_conocimiento.Size = new System.Drawing.Size(208, 22);
            this.ToolStripMenuItem_editor_base_conocimiento.Text = "Editar base conocimiento";
            this.ToolStripMenuItem_editor_base_conocimiento.Click += new System.EventHandler(this.ToolStripMenuItem_editor_base_conocimiento_Click);
            // 
            // motorDeInferenciaToolStripMenuItem
            // 
            this.motorDeInferenciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarInferenciaToolStripMenuItem});
            this.motorDeInferenciaToolStripMenuItem.Name = "motorDeInferenciaToolStripMenuItem";
            this.motorDeInferenciaToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.motorDeInferenciaToolStripMenuItem.Text = "Motor de inferencia";
            // 
            // iniciarInferenciaToolStripMenuItem
            // 
            this.iniciarInferenciaToolStripMenuItem.Name = "iniciarInferenciaToolStripMenuItem";
            this.iniciarInferenciaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.iniciarInferenciaToolStripMenuItem.Text = "Iniciar inferencia";
            this.iniciarInferenciaToolStripMenuItem.Click += new System.EventHandler(this.iniciarInferenciaToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // nuevaBaseDeConocimientoToolStripMenuItem
            // 
            this.nuevaBaseDeConocimientoToolStripMenuItem.Name = "nuevaBaseDeConocimientoToolStripMenuItem";
            this.nuevaBaseDeConocimientoToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.nuevaBaseDeConocimientoToolStripMenuItem.Text = "Nueva base de conocimiento";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // FormVentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 747);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "FormVentanaPrincipal";
            this.Text = "FormVentanaPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDelConocimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_editor_base_conocimiento;
        private System.Windows.Forms.ToolStripMenuItem motorDeInferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarInferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_salir;
        private System.Windows.Forms.ToolStripMenuItem nuevaBaseDeConocimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}