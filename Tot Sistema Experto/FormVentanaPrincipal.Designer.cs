namespace Tot_Sistema_Experto
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVentanaPrincipal));
            this.imageList_check_base_conocimiento = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_titulo = new System.Windows.Forms.TextBox();
            this.button_iniciar = new System.Windows.Forms.Button();
            this.button_importar = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.openFileDialog_importar = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_tipo_de_encadenamiento = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_configuracion_log = new System.Windows.Forms.Button();
            this.pictureBox_check_bae_de_conocimiento = new System.Windows.Forms.PictureBox();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_check_bae_de_conocimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList_check_base_conocimiento
            // 
            this.imageList_check_base_conocimiento.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_check_base_conocimiento.ImageStream")));
            this.imageList_check_base_conocimiento.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_check_base_conocimiento.Images.SetKeyName(0, "conocimiento_error.png");
            this.imageList_check_base_conocimiento.Images.SetKeyName(1, "conocimiento_ok.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Bienvenido a la aplicación de consultas de Tot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "La base de conocimiento actual es:";
            // 
            // textBox_titulo
            // 
            this.textBox_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_titulo.Location = new System.Drawing.Point(24, 100);
            this.textBox_titulo.Multiline = true;
            this.textBox_titulo.Name = "textBox_titulo";
            this.textBox_titulo.ReadOnly = true;
            this.textBox_titulo.Size = new System.Drawing.Size(279, 70);
            this.textBox_titulo.TabIndex = 17;
            // 
            // button_iniciar
            // 
            this.button_iniciar.Enabled = false;
            this.button_iniciar.Location = new System.Drawing.Point(21, 357);
            this.button_iniciar.Name = "button_iniciar";
            this.button_iniciar.Size = new System.Drawing.Size(282, 46);
            this.button_iniciar.TabIndex = 18;
            this.button_iniciar.Text = "Iniciar Proceso de inferencia";
            this.button_iniciar.UseVisualStyleBackColor = true;
            this.button_iniciar.Click += new System.EventHandler(this.button_iniciar_Click);
            // 
            // button_importar
            // 
            this.button_importar.Location = new System.Drawing.Point(159, 176);
            this.button_importar.Name = "button_importar";
            this.button_importar.Size = new System.Drawing.Size(144, 50);
            this.button_importar.TabIndex = 19;
            this.button_importar.Text = "Importar nueva base de conocimiento";
            this.button_importar.UseVisualStyleBackColor = true;
            this.button_importar.Click += new System.EventHandler(this.button_importar_Click);
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(21, 325);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(65, 13);
            this.label_info.TabIndex = 20;
            this.label_info.Text = "Información:";
            // 
            // openFileDialog_importar
            // 
            this.openFileDialog_importar.Filter = "Base de conocimiento|*.Tot;";
            this.openFileDialog_importar.InitialDirectory = "Environment.SpecialFolder.Desktop";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_tipo_de_encadenamiento);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(160, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 75);
            this.panel1.TabIndex = 21;
            // 
            // label_tipo_de_encadenamiento
            // 
            this.label_tipo_de_encadenamiento.Location = new System.Drawing.Point(6, 26);
            this.label_tipo_de_encadenamiento.Name = "label_tipo_de_encadenamiento";
            this.label_tipo_de_encadenamiento.Size = new System.Drawing.Size(132, 42);
            this.label_tipo_de_encadenamiento.TabIndex = 1;
            this.label_tipo_de_encadenamiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tipo de encadenamiento:";
            // 
            // button_configuracion_log
            // 
            this.button_configuracion_log.Image = global::Tot_Sistema_Experto.Properties.Resources._1481793263_Settings;
            this.button_configuracion_log.Location = new System.Drawing.Point(258, 13);
            this.button_configuracion_log.Name = "button_configuracion_log";
            this.button_configuracion_log.Size = new System.Drawing.Size(45, 40);
            this.button_configuracion_log.TabIndex = 22;
            this.button_configuracion_log.UseVisualStyleBackColor = true;
            this.button_configuracion_log.Visible = false;
            this.button_configuracion_log.Click += new System.EventHandler(this.button_configuracion_log_Click);
            // 
            // pictureBox_check_bae_de_conocimiento
            // 
            this.pictureBox_check_bae_de_conocimiento.Location = new System.Drawing.Point(21, 176);
            this.pictureBox_check_bae_de_conocimiento.Name = "pictureBox_check_bae_de_conocimiento";
            this.pictureBox_check_bae_de_conocimiento.Size = new System.Drawing.Size(132, 132);
            this.pictureBox_check_bae_de_conocimiento.TabIndex = 14;
            this.pictureBox_check_bae_de_conocimiento.TabStop = false;
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Image = global::Tot_Sistema_Experto.Properties.Resources.logo_default1;
            this.pictureBox_logo.Location = new System.Drawing.Point(319, 3);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(200, 400);
            this.pictureBox_logo.TabIndex = 6;
            this.pictureBox_logo.TabStop = false;
            // 
            // FormVentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 410);
            this.Controls.Add(this.button_configuracion_log);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.button_importar);
            this.Controls.Add(this.button_iniciar);
            this.Controls.Add(this.textBox_titulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_check_bae_de_conocimiento);
            this.Controls.Add(this.pictureBox_logo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(542, 448);
            this.MinimumSize = new System.Drawing.Size(542, 448);
            this.Name = "FormVentanaPrincipal";
            this.Text = "Tot Sistema Experto";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormVentanaPrincipal_MouseDoubleClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_check_bae_de_conocimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.PictureBox pictureBox_check_bae_de_conocimiento;
        private System.Windows.Forms.ImageList imageList_check_base_conocimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_titulo;
        private System.Windows.Forms.Button button_iniciar;
        private System.Windows.Forms.Button button_importar;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.OpenFileDialog openFileDialog_importar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_tipo_de_encadenamiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_configuracion_log;
    }
}