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
            this.nuevaBaseDeConocimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónLogInferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemimportarBaseDeConocimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemexportarBaseDeConocimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_salir = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDelConocimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_editor_base_conocimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónBaseDeConocimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorDeInferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarInferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónLogDeInferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog_importar = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_exportar = new System.Windows.Forms.SaveFileDialog();
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
            this.configuraciónLogInferenciaToolStripMenuItem,
            this.toolStripSeparator2,
            this.ToolStripMenuItemimportarBaseDeConocimiento,
            this.ToolStripMenuItemexportarBaseDeConocimiento,
            this.toolStripSeparator3,
            this.ToolStripMenuItem_salir});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevaBaseDeConocimientoToolStripMenuItem
            // 
            this.nuevaBaseDeConocimientoToolStripMenuItem.Name = "nuevaBaseDeConocimientoToolStripMenuItem";
            this.nuevaBaseDeConocimientoToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.nuevaBaseDeConocimientoToolStripMenuItem.Text = "Nueva base de conocimiento";
            this.nuevaBaseDeConocimientoToolStripMenuItem.Click += new System.EventHandler(this.nuevaBaseDeConocimientoToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.configuraciónToolStripMenuItem.Text = "Configuración base de conocimiento";
            this.configuraciónToolStripMenuItem.Visible = false;
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // configuraciónLogInferenciaToolStripMenuItem
            // 
            this.configuraciónLogInferenciaToolStripMenuItem.Name = "configuraciónLogInferenciaToolStripMenuItem";
            this.configuraciónLogInferenciaToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.configuraciónLogInferenciaToolStripMenuItem.Text = "Configuración log inferencia";
            this.configuraciónLogInferenciaToolStripMenuItem.Visible = false;
            this.configuraciónLogInferenciaToolStripMenuItem.Click += new System.EventHandler(this.configuraciónLogInferenciaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(267, 6);
            // 
            // ToolStripMenuItemimportarBaseDeConocimiento
            // 
            this.ToolStripMenuItemimportarBaseDeConocimiento.Name = "ToolStripMenuItemimportarBaseDeConocimiento";
            this.ToolStripMenuItemimportarBaseDeConocimiento.Size = new System.Drawing.Size(270, 22);
            this.ToolStripMenuItemimportarBaseDeConocimiento.Text = "Importar base de conocimiento";
            this.ToolStripMenuItemimportarBaseDeConocimiento.Click += new System.EventHandler(this.ToolStripMenuItemimportarBaseDeConocimiento_Click);
            // 
            // ToolStripMenuItemexportarBaseDeConocimiento
            // 
            this.ToolStripMenuItemexportarBaseDeConocimiento.Name = "ToolStripMenuItemexportarBaseDeConocimiento";
            this.ToolStripMenuItemexportarBaseDeConocimiento.Size = new System.Drawing.Size(270, 22);
            this.ToolStripMenuItemexportarBaseDeConocimiento.Text = "Exportar base de conocimiento";
            this.ToolStripMenuItemexportarBaseDeConocimiento.Click += new System.EventHandler(this.ToolStripMenuItemexportarBaseDeConocimiento_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(267, 6);
            // 
            // ToolStripMenuItem_salir
            // 
            this.ToolStripMenuItem_salir.Name = "ToolStripMenuItem_salir";
            this.ToolStripMenuItem_salir.Size = new System.Drawing.Size(270, 22);
            this.ToolStripMenuItem_salir.Text = "Salir";
            this.ToolStripMenuItem_salir.Click += new System.EventHandler(this.ToolStripMenuItem_salir_Click);
            // 
            // gestiónDelConocimientoToolStripMenuItem
            // 
            this.gestiónDelConocimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_editor_base_conocimiento,
            this.configuraciónBaseDeConocimientoToolStripMenuItem});
            this.gestiónDelConocimientoToolStripMenuItem.Name = "gestiónDelConocimientoToolStripMenuItem";
            this.gestiónDelConocimientoToolStripMenuItem.Size = new System.Drawing.Size(155, 20);
            this.gestiónDelConocimientoToolStripMenuItem.Text = "Gestión del conocimiento";
            // 
            // ToolStripMenuItem_editor_base_conocimiento
            // 
            this.ToolStripMenuItem_editor_base_conocimiento.Name = "ToolStripMenuItem_editor_base_conocimiento";
            this.ToolStripMenuItem_editor_base_conocimiento.Size = new System.Drawing.Size(270, 22);
            this.ToolStripMenuItem_editor_base_conocimiento.Text = "Editar base conocimiento";
            this.ToolStripMenuItem_editor_base_conocimiento.Click += new System.EventHandler(this.ToolStripMenuItem_editor_base_conocimiento_Click);
            // 
            // configuraciónBaseDeConocimientoToolStripMenuItem
            // 
            this.configuraciónBaseDeConocimientoToolStripMenuItem.Name = "configuraciónBaseDeConocimientoToolStripMenuItem";
            this.configuraciónBaseDeConocimientoToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.configuraciónBaseDeConocimientoToolStripMenuItem.Text = "Configuración base de conocimiento";
            this.configuraciónBaseDeConocimientoToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // motorDeInferenciaToolStripMenuItem
            // 
            this.motorDeInferenciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarInferenciaToolStripMenuItem,
            this.configuraciónLogDeInferenciaToolStripMenuItem});
            this.motorDeInferenciaToolStripMenuItem.Name = "motorDeInferenciaToolStripMenuItem";
            this.motorDeInferenciaToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.motorDeInferenciaToolStripMenuItem.Text = "Motor de inferencia";
            // 
            // iniciarInferenciaToolStripMenuItem
            // 
            this.iniciarInferenciaToolStripMenuItem.Name = "iniciarInferenciaToolStripMenuItem";
            this.iniciarInferenciaToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.iniciarInferenciaToolStripMenuItem.Text = "Iniciar inferencia";
            this.iniciarInferenciaToolStripMenuItem.Click += new System.EventHandler(this.iniciarInferenciaToolStripMenuItem_Click);
            // 
            // configuraciónLogDeInferenciaToolStripMenuItem
            // 
            this.configuraciónLogDeInferenciaToolStripMenuItem.Name = "configuraciónLogDeInferenciaToolStripMenuItem";
            this.configuraciónLogDeInferenciaToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.configuraciónLogDeInferenciaToolStripMenuItem.Text = "Configuración log de inferencia";
            this.configuraciónLogDeInferenciaToolStripMenuItem.Click += new System.EventHandler(this.configuraciónLogInferenciaToolStripMenuItem_Click);
            // 
            // openFileDialog_importar
            // 
            this.openFileDialog_importar.Filter = "Base de conocimiento|*.Tot;";
            this.openFileDialog_importar.InitialDirectory = "Environment.SpecialFolder.Desktop";
            // 
            // saveFileDialog_exportar
            // 
            this.saveFileDialog_exportar.DefaultExt = "Tot";
            this.saveFileDialog_exportar.Filter = "Base de conocimiento|*.Tot;";
            // 
            // FormVentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 747);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "FormVentanaPrincipal";
            this.Text = "Tot ";
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemimportarBaseDeConocimiento;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemexportarBaseDeConocimiento;
        private System.Windows.Forms.OpenFileDialog openFileDialog_importar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_exportar;
        private System.Windows.Forms.ToolStripMenuItem configuraciónLogInferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem configuraciónBaseDeConocimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónLogDeInferenciaToolStripMenuItem;
    }
}