namespace Tot
{
    partial class FormVentanaConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVentanaConfiguracion));
            this.buttonInformación_configuracion = new Tot.ButtonInformación();
            this.SuspendLayout();
            // 
            // buttonInformación_configuracion
            // 
            this.buttonInformación_configuracion.Location = new System.Drawing.Point(436, 12);
            this.buttonInformación_configuracion.Name = "buttonInformación_configuracion";
            this.buttonInformación_configuracion.ruta_rtf_ayuda = "files\\\\ayuda\\\\configuracion_base_de_conocimiento.rtf";
            this.buttonInformación_configuracion.Size = new System.Drawing.Size(32, 32);
            this.buttonInformación_configuracion.TabIndex = 0;
            // 
            // FormVentanaConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 442);
            this.Controls.Add(this.buttonInformación_configuracion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(730, 480);
            this.MinimumSize = new System.Drawing.Size(730, 480);
            this.Name = "FormVentanaConfiguracion";
            this.Text = "Configuración";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVentanaConfiguracion_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormVentanaConfiguracion_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonInformación buttonInformación_configuracion;

    }
}