namespace Tot
{
    partial class FormVentanaGestiónBaseConocimiento
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
            this.tabControl_gestion_conocimiento = new System.Windows.Forms.TabControl();
            this.tabPage_variables = new System.Windows.Forms.TabPage();
            this.control_gestion_variables = new Tot.ControlGestionVariables();
            this.tabPage_hechos = new System.Windows.Forms.TabPage();
            this.button_update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_hechos = new System.Windows.Forms.ListBox();
            this.tabPage_reglas = new System.Windows.Forms.TabPage();
            this.control_gestion_de_reglas = new Tot.ControlGestionReglas();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl_gestion_conocimiento.SuspendLayout();
            this.tabPage_variables.SuspendLayout();
            this.tabPage_hechos.SuspendLayout();
            this.tabPage_reglas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_gestion_conocimiento
            // 
            this.tabControl_gestion_conocimiento.Controls.Add(this.tabPage_variables);
            this.tabControl_gestion_conocimiento.Controls.Add(this.tabPage_hechos);
            this.tabControl_gestion_conocimiento.Controls.Add(this.tabPage_reglas);
            this.tabControl_gestion_conocimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_gestion_conocimiento.Location = new System.Drawing.Point(0, 0);
            this.tabControl_gestion_conocimiento.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl_gestion_conocimiento.Name = "tabControl_gestion_conocimiento";
            this.tabControl_gestion_conocimiento.SelectedIndex = 0;
            this.tabControl_gestion_conocimiento.Size = new System.Drawing.Size(1052, 826);
            this.tabControl_gestion_conocimiento.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_gestion_conocimiento.TabIndex = 0;
            // 
            // tabPage_variables
            // 
            this.tabPage_variables.Controls.Add(this.control_gestion_variables);
            this.tabPage_variables.Location = new System.Drawing.Point(4, 25);
            this.tabPage_variables.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_variables.Name = "tabPage_variables";
            this.tabPage_variables.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_variables.Size = new System.Drawing.Size(1044, 797);
            this.tabPage_variables.TabIndex = 0;
            this.tabPage_variables.Text = "Variables";
            this.tabPage_variables.UseVisualStyleBackColor = true;
            this.tabPage_variables.Enter += new System.EventHandler(this.tabPage_variables_Enter);
            // 
            // control_gestion_variables
            // 
            this.control_gestion_variables.AutoSize = true;
            this.control_gestion_variables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control_gestion_variables.id = "";
            this.control_gestion_variables.Location = new System.Drawing.Point(4, 4);
            this.control_gestion_variables.Margin = new System.Windows.Forms.Padding(5);
            this.control_gestion_variables.MinimumSize = new System.Drawing.Size(1040, 788);
            this.control_gestion_variables.Name = "control_gestion_variables";
            this.control_gestion_variables.nombre = "";
            this.control_gestion_variables.rango_limitado = false;
            this.control_gestion_variables.rango_max = "";
            this.control_gestion_variables.rango_min = "";
            this.control_gestion_variables.ruta_archivo_imagen = "";
            this.control_gestion_variables.ruta_archivo_rtf = "";
            this.control_gestion_variables.Size = new System.Drawing.Size(1040, 789);
            this.control_gestion_variables.TabIndex = 0;
            this.control_gestion_variables.texto_consulta = "";
            this.control_gestion_variables.variable_de_inicio = false;
            this.control_gestion_variables.variable_preguntable_al_usuario = false;
            // 
            // tabPage_hechos
            // 
            this.tabPage_hechos.Controls.Add(this.button_update);
            this.tabPage_hechos.Controls.Add(this.label1);
            this.tabPage_hechos.Controls.Add(this.listBox_hechos);
            this.tabPage_hechos.Location = new System.Drawing.Point(4, 25);
            this.tabPage_hechos.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_hechos.Name = "tabPage_hechos";
            this.tabPage_hechos.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_hechos.Size = new System.Drawing.Size(1044, 797);
            this.tabPage_hechos.TabIndex = 1;
            this.tabPage_hechos.Text = "Hechos";
            this.tabPage_hechos.UseVisualStyleBackColor = true;
            this.tabPage_hechos.Enter += new System.EventHandler(this.tabPage_hechos_Enter);
            // 
            // button_update
            // 
            this.button_update.Image = global::Tot.Properties.Resources.update_256x256;
            this.button_update.Location = new System.Drawing.Point(531, 173);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(384, 374);
            this.button_update.TabIndex = 2;
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de hechos";
            // 
            // listBox_hechos
            // 
            this.listBox_hechos.FormattingEnabled = true;
            this.listBox_hechos.ItemHeight = 16;
            this.listBox_hechos.Location = new System.Drawing.Point(30, 35);
            this.listBox_hechos.Name = "listBox_hechos";
            this.listBox_hechos.Size = new System.Drawing.Size(375, 708);
            this.listBox_hechos.TabIndex = 0;
            // 
            // tabPage_reglas
            // 
            this.tabPage_reglas.Controls.Add(this.control_gestion_de_reglas);
            this.tabPage_reglas.Location = new System.Drawing.Point(4, 25);
            this.tabPage_reglas.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_reglas.Name = "tabPage_reglas";
            this.tabPage_reglas.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_reglas.Size = new System.Drawing.Size(1044, 797);
            this.tabPage_reglas.TabIndex = 2;
            this.tabPage_reglas.Text = "Reglas";
            this.tabPage_reglas.UseVisualStyleBackColor = true;
            this.tabPage_reglas.Enter += new System.EventHandler(this.tabPage_reglas_Enter);
            // 
            // control_gestion_de_reglas
            // 
            this.control_gestion_de_reglas.AutoScroll = true;
            this.control_gestion_de_reglas.AutoSize = true;
            this.control_gestion_de_reglas.base_conocimiento = null;
            this.control_gestion_de_reglas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.control_gestion_de_reglas.Location = new System.Drawing.Point(4, 4);
            this.control_gestion_de_reglas.Margin = new System.Windows.Forms.Padding(5);
            this.control_gestion_de_reglas.Name = "control_gestion_de_reglas";
            this.control_gestion_de_reglas.Size = new System.Drawing.Size(1036, 789);
            this.control_gestion_de_reglas.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(763, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(11, 10);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormVentanaGestiónBaseConocimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 826);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl_gestion_conocimiento);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1067, 863);
            this.Name = "FormVentanaGestiónBaseConocimiento";
            this.Text = "Gestión Base de Conocimiento";
            this.tabControl_gestion_conocimiento.ResumeLayout(false);
            this.tabPage_variables.ResumeLayout(false);
            this.tabPage_variables.PerformLayout();
            this.tabPage_hechos.ResumeLayout(false);
            this.tabPage_hechos.PerformLayout();
            this.tabPage_reglas.ResumeLayout(false);
            this.tabPage_reglas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_gestion_conocimiento;
        private System.Windows.Forms.TabPage tabPage_variables;
        private System.Windows.Forms.TabPage tabPage_hechos;
        private System.Windows.Forms.TabPage tabPage_reglas;
        private System.Windows.Forms.Button button1;
        private ControlGestionVariables control_gestion_variables;
        private ControlGestionReglas control_gestion_de_reglas;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_hechos;

    }
}