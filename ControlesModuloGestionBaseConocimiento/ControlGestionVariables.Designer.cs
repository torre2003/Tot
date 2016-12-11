namespace Tot
{
    partial class ControlGestionVariables
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_agregar_variable = new System.Windows.Forms.Button();
            this.panel_1 = new System.Windows.Forms.Panel();
            this.listBox_variables = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_eliminar_variable = new System.Windows.Forms.Button();
            this.button_modificar_variable = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox_variable_objetivo = new System.Windows.Forms.CheckBox();
            this.checkBox_variable_preguntable_al_usuario = new System.Windows.Forms.CheckBox();
            this.checkBox_variable_de_inicio = new System.Windows.Forms.CheckBox();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_seleccion_documento = new System.Windows.Forms.Button();
            this.textBox_texto_consulta = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel_opciones_lista = new System.Windows.Forms.Panel();
            this.button_agregar_elemento_lista_a_variable = new System.Windows.Forms.Button();
            this.button_eliminar_elemento_lista_variable = new System.Windows.Forms.Button();
            this.textBox_ingreso_elemento_lista_variable = new System.Windows.Forms.TextBox();
            this.listBox_lista_de_elementos_variables = new System.Windows.Forms.ListBox();
            this.panel_opciones_numerico = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_max_rango = new System.Windows.Forms.TextBox();
            this.textBox_min_rango = new System.Windows.Forms.TextBox();
            this.checkBox_rango = new System.Windows.Forms.CheckBox();
            this.radioButton_cardinal = new System.Windows.Forms.RadioButton();
            this.radioButton_Continuo = new System.Windows.Forms.RadioButton();
            this.radioButton_tipo_lista = new System.Windows.Forms.RadioButton();
            this.radioButton_tipo_numerico = new System.Windows.Forms.RadioButton();
            this.radioButton_tipo_booleano = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_id_variable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog_archivos_RTF = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_imagenes = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_opciones_lista.SuspendLayout();
            this.panel_opciones_numerico.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.button_agregar_variable, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel_1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 640);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_agregar_variable
            // 
            this.button_agregar_variable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_agregar_variable.Location = new System.Drawing.Point(3, 603);
            this.button_agregar_variable.Name = "button_agregar_variable";
            this.button_agregar_variable.Size = new System.Drawing.Size(294, 34);
            this.button_agregar_variable.TabIndex = 2;
            this.button_agregar_variable.Text = "Agregar Variable";
            this.button_agregar_variable.UseVisualStyleBackColor = true;
            this.button_agregar_variable.Click += new System.EventHandler(this.button_agregar_variable_Click);
            // 
            // panel_1
            // 
            this.panel_1.Controls.Add(this.listBox_variables);
            this.panel_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_1.Location = new System.Drawing.Point(3, 33);
            this.panel_1.Name = "panel_1";
            this.panel_1.Size = new System.Drawing.Size(294, 564);
            this.panel_1.TabIndex = 0;
            // 
            // listBox_variables
            // 
            this.listBox_variables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_variables.FormattingEnabled = true;
            this.listBox_variables.HorizontalExtent = 1400;
            this.listBox_variables.HorizontalScrollbar = true;
            this.listBox_variables.Location = new System.Drawing.Point(0, 0);
            this.listBox_variables.Name = "listBox_variables";
            this.listBox_variables.Size = new System.Drawing.Size(294, 564);
            this.listBox_variables.TabIndex = 1;
            this.listBox_variables.SelectedIndexChanged += new System.EventHandler(this.listBox_variables_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 24);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de variables";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel2.Controls.Add(this.button_eliminar_variable);
            this.panel2.Controls.Add(this.button_modificar_variable);
            this.panel2.Location = new System.Drawing.Point(303, 603);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 34);
            this.panel2.TabIndex = 4;
            // 
            // button_eliminar_variable
            // 
            this.button_eliminar_variable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_eliminar_variable.Location = new System.Drawing.Point(21, 0);
            this.button_eliminar_variable.Name = "button_eliminar_variable";
            this.button_eliminar_variable.Size = new System.Drawing.Size(222, 34);
            this.button_eliminar_variable.TabIndex = 1;
            this.button_eliminar_variable.Text = "Eliminar Variable";
            this.button_eliminar_variable.UseVisualStyleBackColor = true;
            this.button_eliminar_variable.Click += new System.EventHandler(this.button_eliminar_variable_Click);
            // 
            // button_modificar_variable
            // 
            this.button_modificar_variable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_modificar_variable.AutoSize = true;
            this.button_modificar_variable.Location = new System.Drawing.Point(249, 0);
            this.button_modificar_variable.Name = "button_modificar_variable";
            this.button_modificar_variable.Size = new System.Drawing.Size(222, 34);
            this.button_modificar_variable.TabIndex = 0;
            this.button_modificar_variable.Text = "Modificar Variable";
            this.button_modificar_variable.UseVisualStyleBackColor = true;
            this.button_modificar_variable.Click += new System.EventHandler(this.button_modificar_variable_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox_variable_objetivo);
            this.panel3.Controls.Add(this.checkBox_variable_preguntable_al_usuario);
            this.panel3.Controls.Add(this.checkBox_variable_de_inicio);
            this.panel3.Controls.Add(this.button_cancelar);
            this.panel3.Controls.Add(this.button_aceptar);
            this.panel3.Controls.Add(this.button_seleccion_documento);
            this.panel3.Controls.Add(this.textBox_texto_consulta);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.textBox_nombre);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBox_id_variable);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(303, 3);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(471, 594);
            this.panel3.TabIndex = 5;
            // 
            // checkBox_variable_objetivo
            // 
            this.checkBox_variable_objetivo.AutoSize = true;
            this.checkBox_variable_objetivo.Location = new System.Drawing.Point(99, 144);
            this.checkBox_variable_objetivo.Name = "checkBox_variable_objetivo";
            this.checkBox_variable_objetivo.Size = new System.Drawing.Size(250, 17);
            this.checkBox_variable_objetivo.TabIndex = 19;
            this.checkBox_variable_objetivo.Text = "Variable Objetivo (Encadenamiento hacia atrás)";
            this.checkBox_variable_objetivo.UseVisualStyleBackColor = true;
            // 
            // checkBox_variable_preguntable_al_usuario
            // 
            this.checkBox_variable_preguntable_al_usuario.AutoSize = true;
            this.checkBox_variable_preguntable_al_usuario.Location = new System.Drawing.Point(100, 98);
            this.checkBox_variable_preguntable_al_usuario.Name = "checkBox_variable_preguntable_al_usuario";
            this.checkBox_variable_preguntable_al_usuario.Size = new System.Drawing.Size(171, 17);
            this.checkBox_variable_preguntable_al_usuario.TabIndex = 18;
            this.checkBox_variable_preguntable_al_usuario.Text = "Variable preguntable al usuario";
            this.checkBox_variable_preguntable_al_usuario.UseVisualStyleBackColor = true;
            // 
            // checkBox_variable_de_inicio
            // 
            this.checkBox_variable_de_inicio.AutoSize = true;
            this.checkBox_variable_de_inicio.Location = new System.Drawing.Point(99, 121);
            this.checkBox_variable_de_inicio.Name = "checkBox_variable_de_inicio";
            this.checkBox_variable_de_inicio.Size = new System.Drawing.Size(268, 17);
            this.checkBox_variable_de_inicio.TabIndex = 17;
            this.checkBox_variable_de_inicio.Text = "Variable de inicio (Encadenamiento hacia adelante)";
            this.checkBox_variable_de_inicio.UseVisualStyleBackColor = true;
            this.checkBox_variable_de_inicio.CheckedChanged += new System.EventHandler(this.checkBox_variable_de_inicio_CheckedChanged);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(169, 568);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(137, 23);
            this.button_cancelar.TabIndex = 16;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(312, 568);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(137, 23);
            this.button_aceptar.TabIndex = 15;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_seleccion_documento
            // 
            this.button_seleccion_documento.Image = global::ControlesModuloGestionBaseConocimiento.Properties.Resources.lupa_documentos___32_x_32;
            this.button_seleccion_documento.Location = new System.Drawing.Point(223, 493);
            this.button_seleccion_documento.Name = "button_seleccion_documento";
            this.button_seleccion_documento.Size = new System.Drawing.Size(46, 37);
            this.button_seleccion_documento.TabIndex = 13;
            this.button_seleccion_documento.UseVisualStyleBackColor = true;
            this.button_seleccion_documento.Click += new System.EventHandler(this.button_seleccion_documento_Click);
            // 
            // textBox_texto_consulta
            // 
            this.textBox_texto_consulta.Location = new System.Drawing.Point(21, 416);
            this.textBox_texto_consulta.Multiline = true;
            this.textBox_texto_consulta.Name = "textBox_texto_consulta";
            this.textBox_texto_consulta.Size = new System.Drawing.Size(420, 60);
            this.textBox_texto_consulta.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 505);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Descripción especifica de la variable";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Texto consulta";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.radioButton_tipo_lista);
            this.panel4.Controls.Add(this.radioButton_tipo_numerico);
            this.panel4.Controls.Add(this.radioButton_tipo_booleano);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(13, 167);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(455, 212);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel_opciones_lista);
            this.panel5.Controls.Add(this.panel_opciones_numerico);
            this.panel5.Location = new System.Drawing.Point(138, 14);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(296, 179);
            this.panel5.TabIndex = 8;
            // 
            // panel_opciones_lista
            // 
            this.panel_opciones_lista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_opciones_lista.Controls.Add(this.button_agregar_elemento_lista_a_variable);
            this.panel_opciones_lista.Controls.Add(this.button_eliminar_elemento_lista_variable);
            this.panel_opciones_lista.Controls.Add(this.textBox_ingreso_elemento_lista_variable);
            this.panel_opciones_lista.Controls.Add(this.listBox_lista_de_elementos_variables);
            this.panel_opciones_lista.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_opciones_lista.Location = new System.Drawing.Point(0, 0);
            this.panel_opciones_lista.Name = "panel_opciones_lista";
            this.panel_opciones_lista.Size = new System.Drawing.Size(296, 179);
            this.panel_opciones_lista.TabIndex = 9;
            this.panel_opciones_lista.Visible = false;
            // 
            // button_agregar_elemento_lista_a_variable
            // 
            this.button_agregar_elemento_lista_a_variable.BackColor = System.Drawing.Color.White;
            this.button_agregar_elemento_lista_a_variable.Image = global::ControlesModuloGestionBaseConocimiento.Properties.Resources.add60x60;
            this.button_agregar_elemento_lista_a_variable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_agregar_elemento_lista_a_variable.Location = new System.Drawing.Point(158, 3);
            this.button_agregar_elemento_lista_a_variable.Name = "button_agregar_elemento_lista_a_variable";
            this.button_agregar_elemento_lista_a_variable.Size = new System.Drawing.Size(129, 74);
            this.button_agregar_elemento_lista_a_variable.TabIndex = 3;
            this.button_agregar_elemento_lista_a_variable.Text = "Agregar Elemento";
            this.button_agregar_elemento_lista_a_variable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_agregar_elemento_lista_a_variable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_agregar_elemento_lista_a_variable.UseVisualStyleBackColor = false;
            this.button_agregar_elemento_lista_a_variable.Click += new System.EventHandler(this.button_agregar_elemento_lista_a_variable_Click);
            // 
            // button_eliminar_elemento_lista_variable
            // 
            this.button_eliminar_elemento_lista_variable.BackColor = System.Drawing.Color.White;
            this.button_eliminar_elemento_lista_variable.Image = global::ControlesModuloGestionBaseConocimiento.Properties.Resources.remove60x60;
            this.button_eliminar_elemento_lista_variable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_eliminar_elemento_lista_variable.Location = new System.Drawing.Point(158, 93);
            this.button_eliminar_elemento_lista_variable.Name = "button_eliminar_elemento_lista_variable";
            this.button_eliminar_elemento_lista_variable.Size = new System.Drawing.Size(129, 72);
            this.button_eliminar_elemento_lista_variable.TabIndex = 2;
            this.button_eliminar_elemento_lista_variable.Text = "Eliminar Elemento";
            this.button_eliminar_elemento_lista_variable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_eliminar_elemento_lista_variable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_eliminar_elemento_lista_variable.UseVisualStyleBackColor = false;
            this.button_eliminar_elemento_lista_variable.Click += new System.EventHandler(this.button_eliminar_elemento_lista_variable_Click);
            // 
            // textBox_ingreso_elemento_lista_variable
            // 
            this.textBox_ingreso_elemento_lista_variable.Location = new System.Drawing.Point(3, 5);
            this.textBox_ingreso_elemento_lista_variable.Name = "textBox_ingreso_elemento_lista_variable";
            this.textBox_ingreso_elemento_lista_variable.Size = new System.Drawing.Size(149, 20);
            this.textBox_ingreso_elemento_lista_variable.TabIndex = 1;
            this.textBox_ingreso_elemento_lista_variable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ingreso_elemento_lista_variable_KeyPress);
            // 
            // listBox_lista_de_elementos_variables
            // 
            this.listBox_lista_de_elementos_variables.FormattingEnabled = true;
            this.listBox_lista_de_elementos_variables.Location = new System.Drawing.Point(3, 32);
            this.listBox_lista_de_elementos_variables.Name = "listBox_lista_de_elementos_variables";
            this.listBox_lista_de_elementos_variables.Size = new System.Drawing.Size(149, 134);
            this.listBox_lista_de_elementos_variables.TabIndex = 0;
            // 
            // panel_opciones_numerico
            // 
            this.panel_opciones_numerico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_opciones_numerico.Controls.Add(this.label8);
            this.panel_opciones_numerico.Controls.Add(this.label7);
            this.panel_opciones_numerico.Controls.Add(this.label6);
            this.panel_opciones_numerico.Controls.Add(this.textBox_max_rango);
            this.panel_opciones_numerico.Controls.Add(this.textBox_min_rango);
            this.panel_opciones_numerico.Controls.Add(this.checkBox_rango);
            this.panel_opciones_numerico.Controls.Add(this.radioButton_cardinal);
            this.panel_opciones_numerico.Controls.Add(this.radioButton_Continuo);
            this.panel_opciones_numerico.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_opciones_numerico.Location = new System.Drawing.Point(0, 0);
            this.panel_opciones_numerico.Name = "panel_opciones_numerico";
            this.panel_opciones_numerico.Size = new System.Drawing.Size(222, 179);
            this.panel_opciones_numerico.TabIndex = 9;
            this.panel_opciones_numerico.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(105, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "MAX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "MIN";
            // 
            // textBox_max_rango
            // 
            this.textBox_max_rango.Location = new System.Drawing.Point(121, 116);
            this.textBox_max_rango.Name = "textBox_max_rango";
            this.textBox_max_rango.Size = new System.Drawing.Size(59, 20);
            this.textBox_max_rango.TabIndex = 4;
            // 
            // textBox_min_rango
            // 
            this.textBox_min_rango.Location = new System.Drawing.Point(40, 116);
            this.textBox_min_rango.Name = "textBox_min_rango";
            this.textBox_min_rango.Size = new System.Drawing.Size(59, 20);
            this.textBox_min_rango.TabIndex = 3;
            // 
            // checkBox_rango
            // 
            this.checkBox_rango.AutoSize = true;
            this.checkBox_rango.Location = new System.Drawing.Point(19, 70);
            this.checkBox_rango.Name = "checkBox_rango";
            this.checkBox_rango.Size = new System.Drawing.Size(58, 17);
            this.checkBox_rango.TabIndex = 2;
            this.checkBox_rango.Text = "Rango";
            this.checkBox_rango.UseVisualStyleBackColor = true;
            this.checkBox_rango.CheckedChanged += new System.EventHandler(this.checkBox_rango_CheckedChanged);
            // 
            // radioButton_cardinal
            // 
            this.radioButton_cardinal.AutoSize = true;
            this.radioButton_cardinal.Location = new System.Drawing.Point(121, 25);
            this.radioButton_cardinal.Name = "radioButton_cardinal";
            this.radioButton_cardinal.Size = new System.Drawing.Size(63, 17);
            this.radioButton_cardinal.TabIndex = 1;
            this.radioButton_cardinal.TabStop = true;
            this.radioButton_cardinal.Text = "Cardinal";
            this.radioButton_cardinal.UseVisualStyleBackColor = true;
            // 
            // radioButton_Continuo
            // 
            this.radioButton_Continuo.AutoSize = true;
            this.radioButton_Continuo.Location = new System.Drawing.Point(40, 25);
            this.radioButton_Continuo.Name = "radioButton_Continuo";
            this.radioButton_Continuo.Size = new System.Drawing.Size(47, 17);
            this.radioButton_Continuo.TabIndex = 0;
            this.radioButton_Continuo.TabStop = true;
            this.radioButton_Continuo.Text = "Real";
            this.radioButton_Continuo.UseVisualStyleBackColor = true;
            // 
            // radioButton_tipo_lista
            // 
            this.radioButton_tipo_lista.AutoSize = true;
            this.radioButton_tipo_lista.Location = new System.Drawing.Point(19, 142);
            this.radioButton_tipo_lista.Name = "radioButton_tipo_lista";
            this.radioButton_tipo_lista.Size = new System.Drawing.Size(113, 17);
            this.radioButton_tipo_lista.TabIndex = 7;
            this.radioButton_tipo_lista.TabStop = true;
            this.radioButton_tipo_lista.Text = "Lista de elementos";
            this.radioButton_tipo_lista.UseVisualStyleBackColor = true;
            this.radioButton_tipo_lista.CheckedChanged += new System.EventHandler(this.radioButton_tipo_lista_CheckedChanged);
            // 
            // radioButton_tipo_numerico
            // 
            this.radioButton_tipo_numerico.AutoSize = true;
            this.radioButton_tipo_numerico.Location = new System.Drawing.Point(19, 93);
            this.radioButton_tipo_numerico.Name = "radioButton_tipo_numerico";
            this.radioButton_tipo_numerico.Size = new System.Drawing.Size(70, 17);
            this.radioButton_tipo_numerico.TabIndex = 6;
            this.radioButton_tipo_numerico.TabStop = true;
            this.radioButton_tipo_numerico.Text = "Númerico";
            this.radioButton_tipo_numerico.UseVisualStyleBackColor = true;
            this.radioButton_tipo_numerico.CheckedChanged += new System.EventHandler(this.radioButton_tipo_numerico_CheckedChanged);
            // 
            // radioButton_tipo_booleano
            // 
            this.radioButton_tipo_booleano.AutoSize = true;
            this.radioButton_tipo_booleano.Location = new System.Drawing.Point(19, 48);
            this.radioButton_tipo_booleano.Name = "radioButton_tipo_booleano";
            this.radioButton_tipo_booleano.Size = new System.Drawing.Size(70, 17);
            this.radioButton_tipo_booleano.TabIndex = 5;
            this.radioButton_tipo_booleano.TabStop = true;
            this.radioButton_tipo_booleano.Text = "Booleano";
            this.radioButton_tipo_booleano.UseVisualStyleBackColor = true;
            this.radioButton_tipo_booleano.CheckedChanged += new System.EventHandler(this.radioButton_tipo_booleano_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo de Variable";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_nombre.Location = new System.Drawing.Point(99, 72);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(350, 20);
            this.textBox_nombre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre";
            // 
            // textBox_id_variable
            // 
            this.textBox_id_variable.Enabled = false;
            this.textBox_id_variable.Location = new System.Drawing.Point(99, 46);
            this.textBox_id_variable.Name = "textBox_id_variable";
            this.textBox_id_variable.Size = new System.Drawing.Size(70, 20);
            this.textBox_id_variable.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detalle Variable";
            // 
            // openFileDialog_archivos_RTF
            // 
            this.openFileDialog_archivos_RTF.Filter = "\"Archivos de texto (*.rtf)|*.rtf|Archivos de texto (*.rtf)|*.rtf\"";
            // 
            // openFileDialog_imagenes
            // 
            this.openFileDialog_imagenes.Filter = "\"Archivo de imagen JPEG (*.jpeg)|*.jpeg|Archivo de imagen JPG(*.jpg)|*.jpg|Archiv" +
    "o de imagen PNG(*.png)|*.png\"";
            // 
            // ControlGestionVariables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(780, 640);
            this.Name = "ControlGestionVariables";
            this.Size = new System.Drawing.Size(780, 640);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel_opciones_lista.ResumeLayout(false);
            this.panel_opciones_lista.PerformLayout();
            this.panel_opciones_numerico.ResumeLayout(false);
            this.panel_opciones_numerico.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_agregar_variable;
        private System.Windows.Forms.Panel panel_1;
        private System.Windows.Forms.ListBox listBox_variables;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_eliminar_variable;
        private System.Windows.Forms.Button button_modificar_variable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_id_variable;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel_opciones_lista;
        private System.Windows.Forms.Button button_agregar_elemento_lista_a_variable;
        private System.Windows.Forms.Button button_eliminar_elemento_lista_variable;
        private System.Windows.Forms.TextBox textBox_ingreso_elemento_lista_variable;
        private System.Windows.Forms.ListBox listBox_lista_de_elementos_variables;
        private System.Windows.Forms.Panel panel_opciones_numerico;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_max_rango;
        private System.Windows.Forms.TextBox textBox_min_rango;
        private System.Windows.Forms.CheckBox checkBox_rango;
        private System.Windows.Forms.RadioButton radioButton_cardinal;
        private System.Windows.Forms.RadioButton radioButton_Continuo;
        private System.Windows.Forms.RadioButton radioButton_tipo_lista;
        private System.Windows.Forms.RadioButton radioButton_tipo_numerico;
        private System.Windows.Forms.RadioButton radioButton_tipo_booleano;
        private System.Windows.Forms.Button button_seleccion_documento;
        private System.Windows.Forms.TextBox textBox_texto_consulta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.OpenFileDialog openFileDialog_archivos_RTF;
        private System.Windows.Forms.OpenFileDialog openFileDialog_imagenes;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.CheckBox checkBox_variable_de_inicio;
        private System.Windows.Forms.CheckBox checkBox_variable_preguntable_al_usuario;
        private System.Windows.Forms.CheckBox checkBox_variable_objetivo;


    }
}
