namespace Tot
{
    partial class FormVentanaGuardarLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVentanaGuardarLog));
            this.radioButton_normal = new System.Windows.Forms.RadioButton();
            this.radioButton_completo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_guardar_reglas = new System.Windows.Forms.CheckBox();
            this.checkBox_guardar_hechos = new System.Windows.Forms.CheckBox();
            this.checkBox_guardar_variables = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.saveFileDialog_guardar_log = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton_normal
            // 
            this.radioButton_normal.AutoSize = true;
            this.radioButton_normal.Checked = true;
            this.radioButton_normal.Location = new System.Drawing.Point(20, 34);
            this.radioButton_normal.Name = "radioButton_normal";
            this.radioButton_normal.Size = new System.Drawing.Size(325, 17);
            this.radioButton_normal.TabIndex = 0;
            this.radioButton_normal.TabStop = true;
            this.radioButton_normal.Text = "Normal (Se guarda solo los eventos configurados por el usuario)";
            this.radioButton_normal.UseVisualStyleBackColor = true;
            // 
            // radioButton_completo
            // 
            this.radioButton_completo.AutoSize = true;
            this.radioButton_completo.Location = new System.Drawing.Point(20, 57);
            this.radioButton_completo.Name = "radioButton_completo";
            this.radioButton_completo.Size = new System.Drawing.Size(251, 17);
            this.radioButton_completo.TabIndex = 1;
            this.radioButton_completo.Text = "Completo (Se guardan todos los eventos de log)";
            this.radioButton_completo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButton_normal);
            this.panel1.Controls.Add(this.radioButton_completo);
            this.panel1.Location = new System.Drawing.Point(25, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 96);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione el tipo de guardado";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.checkBox_guardar_reglas);
            this.panel2.Controls.Add(this.checkBox_guardar_hechos);
            this.panel2.Controls.Add(this.checkBox_guardar_variables);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(25, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 75);
            this.panel2.TabIndex = 3;
            // 
            // checkBox_guardar_reglas
            // 
            this.checkBox_guardar_reglas.AutoSize = true;
            this.checkBox_guardar_reglas.Checked = true;
            this.checkBox_guardar_reglas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_guardar_reglas.Location = new System.Drawing.Point(283, 36);
            this.checkBox_guardar_reglas.Name = "checkBox_guardar_reglas";
            this.checkBox_guardar_reglas.Size = new System.Drawing.Size(100, 17);
            this.checkBox_guardar_reglas.TabIndex = 6;
            this.checkBox_guardar_reglas.Text = "Guardar Reglas";
            this.checkBox_guardar_reglas.UseVisualStyleBackColor = true;
            // 
            // checkBox_guardar_hechos
            // 
            this.checkBox_guardar_hechos.AutoSize = true;
            this.checkBox_guardar_hechos.Checked = true;
            this.checkBox_guardar_hechos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_guardar_hechos.Location = new System.Drawing.Point(154, 36);
            this.checkBox_guardar_hechos.Name = "checkBox_guardar_hechos";
            this.checkBox_guardar_hechos.Size = new System.Drawing.Size(104, 17);
            this.checkBox_guardar_hechos.TabIndex = 5;
            this.checkBox_guardar_hechos.Text = "Guardar Hechos";
            this.checkBox_guardar_hechos.UseVisualStyleBackColor = true;
            // 
            // checkBox_guardar_variables
            // 
            this.checkBox_guardar_variables.AutoSize = true;
            this.checkBox_guardar_variables.Checked = true;
            this.checkBox_guardar_variables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_guardar_variables.Location = new System.Drawing.Point(17, 36);
            this.checkBox_guardar_variables.Name = "checkBox_guardar_variables";
            this.checkBox_guardar_variables.Size = new System.Drawing.Size(109, 17);
            this.checkBox_guardar_variables.TabIndex = 4;
            this.checkBox_guardar_variables.Text = "Guardar variables";
            this.checkBox_guardar_variables.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Base de conocimiento";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(247, 209);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(208, 35);
            this.button_aceptar.TabIndex = 4;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(26, 209);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(208, 35);
            this.button_cancelar.TabIndex = 5;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // saveFileDialog_guardar_log
            // 
            this.saveFileDialog_guardar_log.DefaultExt = "txt";
            this.saveFileDialog_guardar_log.Filter = "Archivos de texto |*.txt;";
            this.saveFileDialog_guardar_log.InitialDirectory = "Environment.SpecialFolder.Desktop";
            // 
            // FormVentanaGuardarLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 256);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVentanaGuardarLog";
            this.Text = "Guardar Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVentanaGuardarLog_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_normal;
        private System.Windows.Forms.RadioButton radioButton_completo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox_guardar_reglas;
        private System.Windows.Forms.CheckBox checkBox_guardar_hechos;
        private System.Windows.Forms.CheckBox checkBox_guardar_variables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_guardar_log;
    }
}