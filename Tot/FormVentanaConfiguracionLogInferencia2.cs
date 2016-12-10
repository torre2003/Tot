using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tot
{
    public partial class FormVentanaConfiguracionLogInferencia : Form
    {
        int ultimo_y = 160 + 12;
        
        public void inicializarComponentes()
        {
            //Inicializando paneles
            //----------------------------------------------------------
            inicializar_log_variable();
            inicializar_info_var_conocida();
            inicializar_accion_procesando_respuesta();
            inicializar_ingresando_a_var_conocida();
            inicializar_log_hecho();
            inicializar_accion_hecho_objetivo_principal();
            inicializar_accion_hecho_objetivo_actual();
            inicializar_accion_quitando_hecho_pila_objetivos();
            inicializar_info_sin_reglas_para_inferir_hecho();
            inicializar_accion_consultando_hechos();
            inicializar_accion_ingresando_hecho_a_pila_de_objetivos();
            inicializar_log_regla();
            inicializar_accion_elegida_mejor_regla();
            inicializar_accion_validando_regla();
            
            
            //------------------------------------------------------------
            
            Label l = new Label();
            l.Location = new System.Drawing.Point(15, ultimo_y);
            l.Size = new System.Drawing.Size(48, 13);
            l.Text = "";
            this.Controls.Add(l);
        }




        private System.Windows.Forms.Panel panel_log_variable;
        private System.Windows.Forms.Label label_log_variable_3;
        private System.Windows.Forms.Label label_tipo_log_variable;
        private System.Windows.Forms.CheckBox checkBox_log_variable;

        void inicializar_log_variable()
        {
            this.panel_log_variable = new System.Windows.Forms.Panel();
            this.checkBox_log_variable = new System.Windows.Forms.CheckBox();
            this.label_tipo_log_variable = new System.Windows.Forms.Label();
            this.label_log_variable_3 = new System.Windows.Forms.Label();
            this.panel_log_variable.SuspendLayout();

            // 
            // panel_log_variable
            // 
            this.panel_log_variable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_log_variable.Controls.Add(this.label_log_variable_3);
            this.panel_log_variable.Controls.Add(this.label_tipo_log_variable);
            this.panel_log_variable.Controls.Add(this.checkBox_log_variable);
            this.panel_log_variable.Location = new System.Drawing.Point(12, ultimo_y);
            ultimo_y += 70;
            this.panel_log_variable.Name = "panel_log_variable";
            this.panel_log_variable.Size = new System.Drawing.Size(550, 60);
            this.panel_log_variable.TabIndex = 0;
            // 
            // checkBox_log_variable
            // 
            this.checkBox_log_variable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_log_variable.Location = new System.Drawing.Point(15, 34);
            this.checkBox_log_variable.Name = "checkBox_log_variable";
            this.checkBox_log_variable.Size = new System.Drawing.Size(81, 24);
            this.checkBox_log_variable.TabIndex = 0;
            this.checkBox_log_variable.Text = "Mostrar";
            this.checkBox_log_variable.UseVisualStyleBackColor = true;
            // 
            // label_tipo_log_variable
            // 
            this.label_tipo_log_variable.AutoSize = true;
            this.label_tipo_log_variable.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_log_variable.Name = "label_tipo_log_variable";
            this.label_tipo_log_variable.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_log_variable.TabIndex = 6;
            this.label_tipo_log_variable.Text = "LOG_VARIABLE";
            // 
            // label_log_variable_3
            // 
            this.label_log_variable_3.AutoSize = true;
            this.label_log_variable_3.Location = new System.Drawing.Point(15, 15);
            this.label_log_variable_3.Name = "label3";
            this.label_log_variable_3.Size = new System.Drawing.Size(48, 13);
            this.label_log_variable_3.TabIndex = 7;
            this.label_log_variable_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_log_variable);
        }

        private System.Windows.Forms.Panel panel_info_var_conocida;
        private System.Windows.Forms.Label label_info_var_conocida_3;
        private System.Windows.Forms.Label label_tipo_info_var_conocida;
        private System.Windows.Forms.TextBox textBox_medio_info_var_conocida;
        private System.Windows.Forms.TextBox textBox_inicial_info_var_conocida;
        private System.Windows.Forms.Label label_info_var_conocida_2;
        private System.Windows.Forms.Label label_info_var_conocida_1;
        private System.Windows.Forms.Label label_formato_info_var_conocida;
        private System.Windows.Forms.CheckBox checkBox_info_var_conocida;
        

        void inicializar_info_var_conocida()
        {
            this.panel_info_var_conocida = new System.Windows.Forms.Panel();
            this.checkBox_info_var_conocida = new System.Windows.Forms.CheckBox();
            this.label_formato_info_var_conocida = new System.Windows.Forms.Label();
            this.label_info_var_conocida_1 = new System.Windows.Forms.Label();
            this.label_info_var_conocida_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_info_var_conocida = new System.Windows.Forms.TextBox();
            this.textBox_medio_info_var_conocida = new System.Windows.Forms.TextBox();
            this.label_tipo_info_var_conocida = new System.Windows.Forms.Label();
            this.label_info_var_conocida_3 = new System.Windows.Forms.Label();
            this.panel_info_var_conocida.SuspendLayout();

            // 
            // panel_info_var_conocida
            // 
            this.panel_info_var_conocida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_info_var_conocida.Controls.Add(this.label_info_var_conocida_3);
            this.panel_info_var_conocida.Controls.Add(this.label_tipo_info_var_conocida);
            this.panel_info_var_conocida.Controls.Add(this.textBox_medio_info_var_conocida);
            this.panel_info_var_conocida.Controls.Add(this.textBox_inicial_info_var_conocida);
            this.panel_info_var_conocida.Controls.Add(this.label_info_var_conocida_2);
            this.panel_info_var_conocida.Controls.Add(this.label_info_var_conocida_1);
            this.panel_info_var_conocida.Controls.Add(this.label_formato_info_var_conocida);
            this.panel_info_var_conocida.Controls.Add(this.checkBox_info_var_conocida);
            this.panel_info_var_conocida.Location = new System.Drawing.Point(12, ultimo_y);
            this.panel_info_var_conocida.Name = "panel_info_var_conocida";
            this.panel_info_var_conocida.Size = new System.Drawing.Size(550, 110);
            ultimo_y += 120;
            this.panel_info_var_conocida.TabIndex = 0;
            // 
            // checkBox_info_var_conocida
            // 
            this.checkBox_info_var_conocida.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_info_var_conocida.Location = new System.Drawing.Point(15, 34);
            this.checkBox_info_var_conocida.Name = "checkBox_info_var_conocida";
            this.checkBox_info_var_conocida.Size = new System.Drawing.Size(81, 24);
            this.checkBox_info_var_conocida.TabIndex = 0;
            this.checkBox_info_var_conocida.Text = "Mostrar";
            this.checkBox_info_var_conocida.UseVisualStyleBackColor = true;
            // 
            // label_formato_info_var_conocida
            // 
            this.label_formato_info_var_conocida.Location = new System.Drawing.Point(102, 32);
            this.label_formato_info_var_conocida.Name = "label_formato_info_var_conocida";
            this.label_formato_info_var_conocida.Size = new System.Drawing.Size(395, 23);
            this.label_formato_info_var_conocida.TabIndex = 1;
            this.label_formato_info_var_conocida.Text = "texto_inicial VARIABLE texto_final";
            this.label_formato_info_var_conocida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_info_var_conocida_1
            // 
            this.label_info_var_conocida_1.AutoSize = true;
            this.label_info_var_conocida_1.Location = new System.Drawing.Point(12, 61);
            this.label_info_var_conocida_1.Name = "label1";
            this.label_info_var_conocida_1.Size = new System.Drawing.Size(66, 13);
            this.label_info_var_conocida_1.TabIndex = 2;
            this.label_info_var_conocida_1.Text = "Texto inicial:";
            // 
            // label_info_var_conocida_2
            // 
            this.label_info_var_conocida_2.AutoSize = true;
            this.label_info_var_conocida_2.Location = new System.Drawing.Point(12, 87);
            this.label_info_var_conocida_2.Name = "label2";
            this.label_info_var_conocida_2.Size = new System.Drawing.Size(68, 13);
            this.label_info_var_conocida_2.TabIndex = 3;
            this.label_info_var_conocida_2.Text = "Texto final:";
            // 
            // textBox_inicial_info_var_conocida
            // 
            this.textBox_inicial_info_var_conocida.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_info_var_conocida.Name = "textBox_inicial_info_var_conocida";
            this.textBox_inicial_info_var_conocida.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_info_var_conocida.TabIndex = 4;
            // 
            // textBox_medio_info_var_conocida
            // 
            this.textBox_medio_info_var_conocida.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_info_var_conocida.Name = "textBox_medio_info_var_conocida";
            this.textBox_medio_info_var_conocida.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_info_var_conocida.TabIndex = 5;
            // 
            // label_tipo_info_var_conocida
            // 
            this.label_tipo_info_var_conocida.AutoSize = true;
            this.label_tipo_info_var_conocida.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_info_var_conocida.Name = "label_tipo_info_var_conocida";
            this.label_tipo_info_var_conocida.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_info_var_conocida.TabIndex = 6;
            this.label_tipo_info_var_conocida.Text = "LOG_INFO_VARIABLE_CONOCIDA";
            // 
            // label_info_var_conocida_3
            // 
            this.label_info_var_conocida_3.AutoSize = true;
            this.label_info_var_conocida_3.Location = new System.Drawing.Point(15, 15);
            this.label_info_var_conocida_3.Name = "label3";
            this.label_info_var_conocida_3.Size = new System.Drawing.Size(48, 13);
            this.label_info_var_conocida_3.TabIndex = 7;
            this.label_info_var_conocida_3.Text = "Tipo log:";
            //agregando a form
            this.Controls.Add(panel_info_var_conocida);

        }


        private System.Windows.Forms.Panel panel_accion_procesando_respuesta;
        private System.Windows.Forms.Label label_accion_procesando_respuesta_3;
        private System.Windows.Forms.Label label_tipo_accion_procesando_respuesta;
        private System.Windows.Forms.TextBox textBox_medio_accion_procesando_respuesta;
        private System.Windows.Forms.TextBox textBox_inicial_accion_procesando_respuesta;
        private System.Windows.Forms.Label label_accion_procesando_respuesta_2;
        private System.Windows.Forms.Label label_accion_procesando_respuesta_1;
        private System.Windows.Forms.Label label_formato_accion_procesando_respuesta;
        private System.Windows.Forms.CheckBox checkBox_accion_procesando_respuesta;
        
        

        void inicializar_accion_procesando_respuesta()
        {
            this.panel_accion_procesando_respuesta = new System.Windows.Forms.Panel();
            this.checkBox_accion_procesando_respuesta = new System.Windows.Forms.CheckBox();
            this.label_formato_accion_procesando_respuesta = new System.Windows.Forms.Label();
            this.label_accion_procesando_respuesta_1 = new System.Windows.Forms.Label();
            this.label_accion_procesando_respuesta_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_accion_procesando_respuesta = new System.Windows.Forms.TextBox();
            this.textBox_medio_accion_procesando_respuesta = new System.Windows.Forms.TextBox();
            this.label_tipo_accion_procesando_respuesta = new System.Windows.Forms.Label();
            this.label_accion_procesando_respuesta_3 = new System.Windows.Forms.Label();
            this.panel_accion_procesando_respuesta.SuspendLayout();

            // 
            // panel_accion_procesando_respuesta
            // 
            this.panel_accion_procesando_respuesta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_accion_procesando_respuesta.Controls.Add(this.label_accion_procesando_respuesta_3);
            this.panel_accion_procesando_respuesta.Controls.Add(this.label_tipo_accion_procesando_respuesta);
            this.panel_accion_procesando_respuesta.Controls.Add(this.textBox_medio_accion_procesando_respuesta);
            this.panel_accion_procesando_respuesta.Controls.Add(this.textBox_inicial_accion_procesando_respuesta);
            this.panel_accion_procesando_respuesta.Controls.Add(this.label_accion_procesando_respuesta_2);
            this.panel_accion_procesando_respuesta.Controls.Add(this.label_accion_procesando_respuesta_1);
            this.panel_accion_procesando_respuesta.Controls.Add(this.label_formato_accion_procesando_respuesta);
            this.panel_accion_procesando_respuesta.Controls.Add(this.checkBox_accion_procesando_respuesta);
            this.panel_accion_procesando_respuesta.Location = new System.Drawing.Point(12, ultimo_y);
            this.panel_accion_procesando_respuesta.Name = "panel_accion_procesando_respuesta";
            ultimo_y += 120;
            this.panel_accion_procesando_respuesta.Size = new System.Drawing.Size(550,110);
            this.panel_accion_procesando_respuesta.TabIndex = 0;
            // 
            // checkBox_accion_procesando_respuesta
            // 
            this.checkBox_accion_procesando_respuesta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_procesando_respuesta.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_procesando_respuesta.Name = "checkBox_accion_procesando_respuesta";
            this.checkBox_accion_procesando_respuesta.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_procesando_respuesta.TabIndex = 0;
            this.checkBox_accion_procesando_respuesta.Text = "Mostrar";
            this.checkBox_accion_procesando_respuesta.UseVisualStyleBackColor = true;
            // 
            // label_formato_accion_procesando_respuesta
            // 
            this.label_formato_accion_procesando_respuesta.Location = new System.Drawing.Point(102, 32);
            this.label_formato_accion_procesando_respuesta.Name = "label_formato_accion_procesando_respuesta";
            this.label_formato_accion_procesando_respuesta.Size = new System.Drawing.Size(395, 23);
            this.label_formato_accion_procesando_respuesta.TabIndex = 1;
            this.label_formato_accion_procesando_respuesta.Text = "texto_inicial VARIABLE texto_medio VALOR";
            this.label_formato_accion_procesando_respuesta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_accion_procesando_respuesta_1
            // 
            this.label_accion_procesando_respuesta_1.AutoSize = true;
            this.label_accion_procesando_respuesta_1.Location = new System.Drawing.Point(12, 61);
            this.label_accion_procesando_respuesta_1.Name = "label1";
            this.label_accion_procesando_respuesta_1.Size = new System.Drawing.Size(66, 13);
            this.label_accion_procesando_respuesta_1.TabIndex = 2;
            this.label_accion_procesando_respuesta_1.Text = "Texto inicial:";
            // 
            // label_accion_procesando_respuesta_2
            // 
            this.label_accion_procesando_respuesta_2.AutoSize = true;
            this.label_accion_procesando_respuesta_2.Location = new System.Drawing.Point(12, 87);
            this.label_accion_procesando_respuesta_2.Name = "label2";
            this.label_accion_procesando_respuesta_2.Size = new System.Drawing.Size(68, 13);
            this.label_accion_procesando_respuesta_2.TabIndex = 3;
            this.label_accion_procesando_respuesta_2.Text = "Texto medio:";
            // 
            // textBox_inicial_accion_procesando_respuesta
            // 
            this.textBox_inicial_accion_procesando_respuesta.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_accion_procesando_respuesta.Name = "textBox_inicial_accion_procesando_respuesta";
            this.textBox_inicial_accion_procesando_respuesta.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_accion_procesando_respuesta.TabIndex = 4;
            // 
            // textBox_medio_accion_procesando_respuesta
            // 
            this.textBox_medio_accion_procesando_respuesta.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_accion_procesando_respuesta.Name = "textBox_medio_accion_procesando_respuesta";
            this.textBox_medio_accion_procesando_respuesta.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_accion_procesando_respuesta.TabIndex = 5;
            // 
            // label_tipo_accion_procesando_respuesta
            // 
            this.label_tipo_accion_procesando_respuesta.AutoSize = true;
            this.label_tipo_accion_procesando_respuesta.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_accion_procesando_respuesta.Name = "label_tipo_accion_procesando_respuesta";
            this.label_tipo_accion_procesando_respuesta.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_accion_procesando_respuesta.TabIndex = 6;
            this.label_tipo_accion_procesando_respuesta.Text = "LOG_ACCION_PROCESANDO_RESPUESTA";
            // 
            // label_accion_procesando_respuesta_3
            // 
            this.label_accion_procesando_respuesta_3.AutoSize = true;
            this.label_accion_procesando_respuesta_3.Location = new System.Drawing.Point(15, 15);
            this.label_accion_procesando_respuesta_3.Name = "label3";
            this.label_accion_procesando_respuesta_3.Size = new System.Drawing.Size(48, 13);
            this.label_accion_procesando_respuesta_3.TabIndex = 7;
            this.label_accion_procesando_respuesta_3.Text = "Tipo log:";
            
            //agregando a form 
            this.Controls.Add(panel_accion_procesando_respuesta);
        }


        private System.Windows.Forms.Panel panel_ingresando_a_var_conocida;
        private System.Windows.Forms.Label label_ingresando_a_var_conocida_3;
        private System.Windows.Forms.Label label_tipo_ingresando_a_var_conocida;
        private System.Windows.Forms.TextBox textBox_medio_ingresando_a_var_conocida;
        private System.Windows.Forms.TextBox textBox_inicial_ingresando_a_var_conocida;
        private System.Windows.Forms.Label label_ingresando_a_var_conocida_2;
        private System.Windows.Forms.Label label_ingresando_a_var_conocida_1;
        private System.Windows.Forms.Label label_formato_ingresando_a_var_conocida;
        private System.Windows.Forms.CheckBox checkBox_ingresando_a_var_conocida;

        void inicializar_ingresando_a_var_conocida()
        {
            this.panel_ingresando_a_var_conocida = new System.Windows.Forms.Panel();
            this.checkBox_ingresando_a_var_conocida = new System.Windows.Forms.CheckBox();
            this.label_formato_ingresando_a_var_conocida = new System.Windows.Forms.Label();
            this.label_ingresando_a_var_conocida_1 = new System.Windows.Forms.Label();
            this.label_ingresando_a_var_conocida_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_ingresando_a_var_conocida = new System.Windows.Forms.TextBox();
            this.textBox_medio_ingresando_a_var_conocida = new System.Windows.Forms.TextBox();
            this.label_tipo_ingresando_a_var_conocida = new System.Windows.Forms.Label();
            this.label_ingresando_a_var_conocida_3 = new System.Windows.Forms.Label();
            this.panel_ingresando_a_var_conocida.SuspendLayout();

            // 
            // panel_ingresando_a_var_conocida
            // 
            this.panel_ingresando_a_var_conocida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_ingresando_a_var_conocida.Controls.Add(this.label_ingresando_a_var_conocida_3);
            this.panel_ingresando_a_var_conocida.Controls.Add(this.label_tipo_ingresando_a_var_conocida);
            this.panel_ingresando_a_var_conocida.Controls.Add(this.textBox_medio_ingresando_a_var_conocida);
            this.panel_ingresando_a_var_conocida.Controls.Add(this.textBox_inicial_ingresando_a_var_conocida);
            this.panel_ingresando_a_var_conocida.Controls.Add(this.label_ingresando_a_var_conocida_2);
            this.panel_ingresando_a_var_conocida.Controls.Add(this.label_ingresando_a_var_conocida_1);
            this.panel_ingresando_a_var_conocida.Controls.Add(this.label_formato_ingresando_a_var_conocida);
            this.panel_ingresando_a_var_conocida.Controls.Add(this.checkBox_ingresando_a_var_conocida);
            this.panel_ingresando_a_var_conocida.Location = new System.Drawing.Point(12, ultimo_y);
            ultimo_y += 120;
            this.panel_ingresando_a_var_conocida.Name = "panel_ingresando_a_var_conocida";
            this.panel_ingresando_a_var_conocida.Size = new System.Drawing.Size(550, 110);
            this.panel_ingresando_a_var_conocida.TabIndex = 0;
            // 
            // checkBox_ingresando_a_var_conocida
            // 
            this.checkBox_ingresando_a_var_conocida.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_ingresando_a_var_conocida.Location = new System.Drawing.Point(15, 34);
            this.checkBox_ingresando_a_var_conocida.Name = "checkBox_ingresando_a_var_conocida";
            this.checkBox_ingresando_a_var_conocida.Size = new System.Drawing.Size(81, 24);
            this.checkBox_ingresando_a_var_conocida.TabIndex = 0;
            this.checkBox_ingresando_a_var_conocida.Text = "Mostrar";
            this.checkBox_ingresando_a_var_conocida.UseVisualStyleBackColor = true;
            // 
            // label_formato_ingresando_a_var_conocida
            // 
            this.label_formato_ingresando_a_var_conocida.Location = new System.Drawing.Point(102, 32);
            this.label_formato_ingresando_a_var_conocida.Name = "label_formato_ingresando_a_var_conocida";
            this.label_formato_ingresando_a_var_conocida.Size = new System.Drawing.Size(395, 23);
            this.label_formato_ingresando_a_var_conocida.TabIndex = 1;
            this.label_formato_ingresando_a_var_conocida.Text = "texto_inicial VARIABLE texto_final";
            this.label_formato_ingresando_a_var_conocida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_ingresando_a_var_conocida_1
            // 
            this.label_ingresando_a_var_conocida_1.AutoSize = true;
            this.label_ingresando_a_var_conocida_1.Location = new System.Drawing.Point(12, 61);
            this.label_ingresando_a_var_conocida_1.Name = "label1";
            this.label_ingresando_a_var_conocida_1.Size = new System.Drawing.Size(66, 13);
            this.label_ingresando_a_var_conocida_1.TabIndex = 2;
            this.label_ingresando_a_var_conocida_1.Text = "Texto inicial:";
            // 
            // label_ingresando_a_var_conocida_2
            // 
            this.label_ingresando_a_var_conocida_2.AutoSize = true;
            this.label_ingresando_a_var_conocida_2.Location = new System.Drawing.Point(12, 87);
            this.label_ingresando_a_var_conocida_2.Name = "label2";
            this.label_ingresando_a_var_conocida_2.Size = new System.Drawing.Size(68, 13);
            this.label_ingresando_a_var_conocida_2.TabIndex = 3;
            this.label_ingresando_a_var_conocida_2.Text = "Texto final:";
            // 
            // textBox_inicial_ingresando_a_var_conocida
            // 
            this.textBox_inicial_ingresando_a_var_conocida.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_ingresando_a_var_conocida.Name = "textBox_inicial_ingresando_a_var_conocida";
            this.textBox_inicial_ingresando_a_var_conocida.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_ingresando_a_var_conocida.TabIndex = 4;
            // 
            // textBox_medio_ingresando_a_var_conocida
            // 
            this.textBox_medio_ingresando_a_var_conocida.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_ingresando_a_var_conocida.Name = "textBox_medio_ingresando_a_var_conocida";
            this.textBox_medio_ingresando_a_var_conocida.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_ingresando_a_var_conocida.TabIndex = 5;
            // 
            // label_tipo_ingresando_a_var_conocida
            // 
            this.label_tipo_ingresando_a_var_conocida.AutoSize = true;
            this.label_tipo_ingresando_a_var_conocida.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_ingresando_a_var_conocida.Name = "label_tipo_ingresando_a_var_conocida";
            this.label_tipo_ingresando_a_var_conocida.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_ingresando_a_var_conocida.TabIndex = 6;
            this.label_tipo_ingresando_a_var_conocida.Text = "LOG_ACCION_INGRESANDO_A_VARIABLES_CONOCIDAS";
            // 
            // label_ingresando_a_var_conocida_3
            // 
            this.label_ingresando_a_var_conocida_3.AutoSize = true;
            this.label_ingresando_a_var_conocida_3.Location = new System.Drawing.Point(15, 15);
            this.label_ingresando_a_var_conocida_3.Name = "label3";
            this.label_ingresando_a_var_conocida_3.Size = new System.Drawing.Size(48, 13);
            this.label_ingresando_a_var_conocida_3.TabIndex = 7;
            this.label_ingresando_a_var_conocida_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_ingresando_a_var_conocida);
        }

        private System.Windows.Forms.Panel panel_log_hecho;
        private System.Windows.Forms.Label label_log_hecho_3;
        private System.Windows.Forms.Label label_tipo_log_hecho;
        private System.Windows.Forms.Label label_log_hecho_1;
        private System.Windows.Forms.CheckBox checkBox_log_hecho;

        void inicializar_log_hecho()
        {
            this.panel_log_hecho = new System.Windows.Forms.Panel();
            this.checkBox_log_hecho = new System.Windows.Forms.CheckBox();
            this.label_log_hecho_1 = new System.Windows.Forms.Label();
            this.label_tipo_log_hecho = new System.Windows.Forms.Label();
            this.label_log_hecho_3 = new System.Windows.Forms.Label();
            this.panel_log_hecho.SuspendLayout();

            // 
            // panel_log_hecho
            // 
            this.panel_log_hecho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_log_hecho.Controls.Add(this.label_log_hecho_3);
            this.panel_log_hecho.Controls.Add(this.label_tipo_log_hecho);
            this.panel_log_hecho.Controls.Add(this.label_log_hecho_1);
            this.panel_log_hecho.Controls.Add(this.checkBox_log_hecho);
            this.panel_log_hecho.Location = new System.Drawing.Point(12, ultimo_y);
            this.panel_log_hecho.Name = "panel_log_hecho";
            this.panel_log_hecho.Size = new System.Drawing.Size(550, 60);
            ultimo_y += 70;
            this.panel_log_hecho.TabIndex = 0;
            // 
            // checkBox_log_hecho
            // 
            this.checkBox_log_hecho.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_log_hecho.Location = new System.Drawing.Point(15, 34);
            this.checkBox_log_hecho.Name = "checkBox_log_hecho";
            this.checkBox_log_hecho.Size = new System.Drawing.Size(81, 24);
            this.checkBox_log_hecho.TabIndex = 0;
            this.checkBox_log_hecho.Text = "Mostrar";
            this.checkBox_log_hecho.UseVisualStyleBackColor = true;
            // 
            // label_log_hecho_1
            // 
            this.label_log_hecho_1.AutoSize = true;
            this.label_log_hecho_1.Location = new System.Drawing.Point(12, 61);
            this.label_log_hecho_1.Name = "label1";
            this.label_log_hecho_1.Size = new System.Drawing.Size(66, 13);
            this.label_log_hecho_1.TabIndex = 2;
            this.label_log_hecho_1.Text = "Texto inicial:";
            // 
            // label_tipo_log_hecho
            // 
            this.label_tipo_log_hecho.AutoSize = true;
            this.label_tipo_log_hecho.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_log_hecho.Name = "label_tipo_log_hecho";
            this.label_tipo_log_hecho.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_log_hecho.TabIndex = 6;
            this.label_tipo_log_hecho.Text = "LOG_HECHO";
            // 
            // label_log_hecho_3
            // 
            this.label_log_hecho_3.AutoSize = true;
            this.label_log_hecho_3.Location = new System.Drawing.Point(15, 15);
            this.label_log_hecho_3.Name = "label3";
            this.label_log_hecho_3.Size = new System.Drawing.Size(48, 13);
            this.label_log_hecho_3.TabIndex = 7;
            this.label_log_hecho_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_log_hecho);
        }


        private System.Windows.Forms.Panel panel_accion_hecho_objetivo_principal;
        private System.Windows.Forms.Label label_accion_hecho_objetivo_principal_3;
        private System.Windows.Forms.Label label_tipo_accion_hecho_objetivo_principal;
        private System.Windows.Forms.TextBox textBox_medio_accion_hecho_objetivo_principal;
        private System.Windows.Forms.TextBox textBox_inicial_accion_hecho_objetivo_principal;
        private System.Windows.Forms.Label label_accion_hecho_objetivo_principal_2;
        private System.Windows.Forms.Label label_accion_hecho_objetivo_principal_1;
        private System.Windows.Forms.Label label_formato_accion_hecho_objetivo_principal;
        private System.Windows.Forms.CheckBox checkBox_accion_hecho_objetivo_principal;

        void inicializar_accion_hecho_objetivo_principal()
        {
            this.panel_accion_hecho_objetivo_principal = new System.Windows.Forms.Panel();
            this.checkBox_accion_hecho_objetivo_principal = new System.Windows.Forms.CheckBox();
            this.label_formato_accion_hecho_objetivo_principal = new System.Windows.Forms.Label();
            this.label_accion_hecho_objetivo_principal_1 = new System.Windows.Forms.Label();
            this.label_accion_hecho_objetivo_principal_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_accion_hecho_objetivo_principal = new System.Windows.Forms.TextBox();
            this.textBox_medio_accion_hecho_objetivo_principal = new System.Windows.Forms.TextBox();
            this.label_tipo_accion_hecho_objetivo_principal = new System.Windows.Forms.Label();
            this.label_accion_hecho_objetivo_principal_3 = new System.Windows.Forms.Label();
            this.panel_accion_hecho_objetivo_principal.SuspendLayout();

            // 
            // panel_accion_hecho_objetivo_principal
            // 
            this.panel_accion_hecho_objetivo_principal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_accion_hecho_objetivo_principal.Controls.Add(this.label_accion_hecho_objetivo_principal_3);
            this.panel_accion_hecho_objetivo_principal.Controls.Add(this.label_tipo_accion_hecho_objetivo_principal);
            this.panel_accion_hecho_objetivo_principal.Controls.Add(this.textBox_medio_accion_hecho_objetivo_principal);
            this.panel_accion_hecho_objetivo_principal.Controls.Add(this.textBox_inicial_accion_hecho_objetivo_principal);
            this.panel_accion_hecho_objetivo_principal.Controls.Add(this.label_accion_hecho_objetivo_principal_2);
            this.panel_accion_hecho_objetivo_principal.Controls.Add(this.label_accion_hecho_objetivo_principal_1);
            this.panel_accion_hecho_objetivo_principal.Controls.Add(this.label_formato_accion_hecho_objetivo_principal);
            this.panel_accion_hecho_objetivo_principal.Controls.Add(this.checkBox_accion_hecho_objetivo_principal);
            this.panel_accion_hecho_objetivo_principal.Location = new System.Drawing.Point(12, ultimo_y);
            ultimo_y += 120;
            this.panel_accion_hecho_objetivo_principal.Name = "panel_accion_hecho_objetivo_principal";
            this.panel_accion_hecho_objetivo_principal.Size = new System.Drawing.Size(550, 110);
            this.panel_accion_hecho_objetivo_principal.TabIndex = 0;
            // 
            // checkBox_accion_hecho_objetivo_principal
            // 
            this.checkBox_accion_hecho_objetivo_principal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_hecho_objetivo_principal.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_hecho_objetivo_principal.Name = "checkBox_accion_hecho_objetivo_principal";
            this.checkBox_accion_hecho_objetivo_principal.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_hecho_objetivo_principal.TabIndex = 0;
            this.checkBox_accion_hecho_objetivo_principal.Text = "Mostrar";
            this.checkBox_accion_hecho_objetivo_principal.UseVisualStyleBackColor = true;
            // 
            // label_formato_accion_hecho_objetivo_principal
            // 
            this.label_formato_accion_hecho_objetivo_principal.Location = new System.Drawing.Point(102, 32);
            this.label_formato_accion_hecho_objetivo_principal.Name = "label_formato_accion_hecho_objetivo_principal";
            this.label_formato_accion_hecho_objetivo_principal.Size = new System.Drawing.Size(395, 23);
            this.label_formato_accion_hecho_objetivo_principal.TabIndex = 1;
            this.label_formato_accion_hecho_objetivo_principal.Text = "texto_inicial HECHO texto_final";
            this.label_formato_accion_hecho_objetivo_principal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_accion_hecho_objetivo_principal_1
            // 
            this.label_accion_hecho_objetivo_principal_1.AutoSize = true;
            this.label_accion_hecho_objetivo_principal_1.Location = new System.Drawing.Point(12, 61);
            this.label_accion_hecho_objetivo_principal_1.Name = "label1";
            this.label_accion_hecho_objetivo_principal_1.Size = new System.Drawing.Size(66, 13);
            this.label_accion_hecho_objetivo_principal_1.TabIndex = 2;
            this.label_accion_hecho_objetivo_principal_1.Text = "Texto inicial:";
            // 
            // label_accion_hecho_objetivo_principal_2
            // 
            this.label_accion_hecho_objetivo_principal_2.AutoSize = true;
            this.label_accion_hecho_objetivo_principal_2.Location = new System.Drawing.Point(12, 87);
            this.label_accion_hecho_objetivo_principal_2.Name = "label2";
            this.label_accion_hecho_objetivo_principal_2.Size = new System.Drawing.Size(68, 13);
            this.label_accion_hecho_objetivo_principal_2.TabIndex = 3;
            this.label_accion_hecho_objetivo_principal_2.Text = "Texto final:";
            // 
            // textBox_inicial_accion_hecho_objetivo_principal
            // 
            this.textBox_inicial_accion_hecho_objetivo_principal.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_accion_hecho_objetivo_principal.Name = "textBox_inicial_accion_hecho_objetivo_principal";
            this.textBox_inicial_accion_hecho_objetivo_principal.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_accion_hecho_objetivo_principal.TabIndex = 4;
            // 
            // textBox_medio_accion_hecho_objetivo_principal
            // 
            this.textBox_medio_accion_hecho_objetivo_principal.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_accion_hecho_objetivo_principal.Name = "textBox_medio_accion_hecho_objetivo_principal";
            this.textBox_medio_accion_hecho_objetivo_principal.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_accion_hecho_objetivo_principal.TabIndex = 5;
            // 
            // label_tipo_accion_hecho_objetivo_principal
            // 
            this.label_tipo_accion_hecho_objetivo_principal.AutoSize = true;
            this.label_tipo_accion_hecho_objetivo_principal.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_accion_hecho_objetivo_principal.Name = "label_tipo_accion_hecho_objetivo_principal";
            this.label_tipo_accion_hecho_objetivo_principal.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_accion_hecho_objetivo_principal.TabIndex = 6;
            this.label_tipo_accion_hecho_objetivo_principal.Text = "LOG_ACCION_HECHO_OBJETIVO_PRINCIPAL";
            // 
            // label_accion_hecho_objetivo_principal_3
            // 
            this.label_accion_hecho_objetivo_principal_3.AutoSize = true;
            this.label_accion_hecho_objetivo_principal_3.Location = new System.Drawing.Point(15, 15);
            this.label_accion_hecho_objetivo_principal_3.Name = "label3";
            this.label_accion_hecho_objetivo_principal_3.Size = new System.Drawing.Size(48, 13);
            this.label_accion_hecho_objetivo_principal_3.TabIndex = 7;
            this.label_accion_hecho_objetivo_principal_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_accion_hecho_objetivo_principal);
        }


        private System.Windows.Forms.Panel panel_accion_hecho_objetivo_actual;
        private System.Windows.Forms.Label label_accion_hecho_objetivo_actual_3;
        private System.Windows.Forms.Label label_tipo_accion_hecho_objetivo_actual;
        private System.Windows.Forms.TextBox textBox_medio_accion_hecho_objetivo_actual;
        private System.Windows.Forms.TextBox textBox_inicial_accion_hecho_objetivo_actual;
        private System.Windows.Forms.Label label_accion_hecho_objetivo_actual_2;
        private System.Windows.Forms.Label label_accion_hecho_objetivo_actual_1;
        private System.Windows.Forms.Label label_formato_accion_hecho_objetivo_actual;
        private System.Windows.Forms.CheckBox checkBox_accion_hecho_objetivo_actual;
        private System.Windows.Forms.CheckBox checkBox_niveles;

        void inicializar_accion_hecho_objetivo_actual()
        {
            this.panel_accion_hecho_objetivo_actual = new System.Windows.Forms.Panel();
            this.checkBox_accion_hecho_objetivo_actual = new System.Windows.Forms.CheckBox();
            this.checkBox_niveles = new System.Windows.Forms.CheckBox();
            this.label_formato_accion_hecho_objetivo_actual = new System.Windows.Forms.Label();
            this.label_accion_hecho_objetivo_actual_1 = new System.Windows.Forms.Label();
            this.label_accion_hecho_objetivo_actual_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_accion_hecho_objetivo_actual = new System.Windows.Forms.TextBox();
            this.textBox_medio_accion_hecho_objetivo_actual = new System.Windows.Forms.TextBox();
            this.label_tipo_accion_hecho_objetivo_actual = new System.Windows.Forms.Label();
            this.label_accion_hecho_objetivo_actual_3 = new System.Windows.Forms.Label();
            this.panel_accion_hecho_objetivo_actual.SuspendLayout();

            // 
            // panel_accion_hecho_objetivo_actual
            // 
            this.panel_accion_hecho_objetivo_actual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_accion_hecho_objetivo_actual.Controls.Add(this.label_accion_hecho_objetivo_actual_3);
            this.panel_accion_hecho_objetivo_actual.Controls.Add(this.label_tipo_accion_hecho_objetivo_actual);
            this.panel_accion_hecho_objetivo_actual.Controls.Add(this.textBox_medio_accion_hecho_objetivo_actual);
            this.panel_accion_hecho_objetivo_actual.Controls.Add(this.textBox_inicial_accion_hecho_objetivo_actual);
            this.panel_accion_hecho_objetivo_actual.Controls.Add(this.label_accion_hecho_objetivo_actual_2);
            this.panel_accion_hecho_objetivo_actual.Controls.Add(this.label_accion_hecho_objetivo_actual_1);
            this.panel_accion_hecho_objetivo_actual.Controls.Add(this.label_formato_accion_hecho_objetivo_actual);
            this.panel_accion_hecho_objetivo_actual.Controls.Add(this.checkBox_accion_hecho_objetivo_actual);
            this.panel_accion_hecho_objetivo_actual.Controls.Add(this.checkBox_niveles);
            this.panel_accion_hecho_objetivo_actual.Location = new System.Drawing.Point(12, ultimo_y);
            ultimo_y += 145;
            this.panel_accion_hecho_objetivo_actual.Name = "panel_accion_hecho_objetivo_actual";
            this.panel_accion_hecho_objetivo_actual.Size = new System.Drawing.Size(550, 135);
            this.panel_accion_hecho_objetivo_actual.TabIndex = 0;
            // 
            // checkBox_accion_hecho_objetivo_actual
            // 
            this.checkBox_accion_hecho_objetivo_actual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_hecho_objetivo_actual.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_hecho_objetivo_actual.Name = "checkBox_accion_hecho_objetivo_actual";
            this.checkBox_accion_hecho_objetivo_actual.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_hecho_objetivo_actual.TabIndex = 0;
            this.checkBox_accion_hecho_objetivo_actual.Text = "Mostrar";
            this.checkBox_accion_hecho_objetivo_actual.UseVisualStyleBackColor = true;
            // 
            // checkBox_niveles
            // 
            this.checkBox_niveles.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_niveles.Location = new System.Drawing.Point(15, 61);
            this.checkBox_niveles.Name = "checkBox_accion_hecho_objetivo_actual";
            this.checkBox_niveles.Size = new System.Drawing.Size(160, 24);
            this.checkBox_niveles.TabIndex = 0;
            this.checkBox_niveles.Text = "Mostrar tabulación por nivel";
            this.checkBox_niveles.UseVisualStyleBackColor = true;
            // 
            // label_formato_accion_hecho_objetivo_actual
            // 
            this.label_formato_accion_hecho_objetivo_actual.Location = new System.Drawing.Point(102, 32);
            this.label_formato_accion_hecho_objetivo_actual.Name = "label_formato_accion_hecho_objetivo_actual";
            this.label_formato_accion_hecho_objetivo_actual.Size = new System.Drawing.Size(395, 23);
            this.label_formato_accion_hecho_objetivo_actual.TabIndex = 1;
            this.label_formato_accion_hecho_objetivo_actual.Text = "(tabulaciones de nivel) texto_incial HECHO texto_final";
            this.label_formato_accion_hecho_objetivo_actual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_accion_hecho_objetivo_actual_1
            // 
            this.label_accion_hecho_objetivo_actual_1.AutoSize = true;
            this.label_accion_hecho_objetivo_actual_1.Location = new System.Drawing.Point(12, 87);
            this.label_accion_hecho_objetivo_actual_1.Name = "label1";
            this.label_accion_hecho_objetivo_actual_1.Size = new System.Drawing.Size(66, 13);
            this.label_accion_hecho_objetivo_actual_1.TabIndex = 2;
            this.label_accion_hecho_objetivo_actual_1.Text = "Texto inicial:";
            // 
            // label_accion_hecho_objetivo_actual_2
            // 
            this.label_accion_hecho_objetivo_actual_2.AutoSize = true;
            this.label_accion_hecho_objetivo_actual_2.Location = new System.Drawing.Point(12, 110);
            this.label_accion_hecho_objetivo_actual_2.Name = "label2";
            this.label_accion_hecho_objetivo_actual_2.Size = new System.Drawing.Size(68, 13);
            this.label_accion_hecho_objetivo_actual_2.TabIndex = 3;
            this.label_accion_hecho_objetivo_actual_2.Text = "Texto final:";
            // 
            // textBox_inicial_accion_hecho_objetivo_actual
            // 
            this.textBox_inicial_accion_hecho_objetivo_actual.Location = new System.Drawing.Point(84, 84);
            this.textBox_inicial_accion_hecho_objetivo_actual.Name = "textBox_inicial_accion_hecho_objetivo_actual";
            this.textBox_inicial_accion_hecho_objetivo_actual.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_accion_hecho_objetivo_actual.TabIndex = 4;
            // 
            // textBox_medio_accion_hecho_objetivo_actual
            // 
            this.textBox_medio_accion_hecho_objetivo_actual.Location = new System.Drawing.Point(84, 107);
            this.textBox_medio_accion_hecho_objetivo_actual.Name = "textBox_medio_accion_hecho_objetivo_actual";
            this.textBox_medio_accion_hecho_objetivo_actual.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_accion_hecho_objetivo_actual.TabIndex = 5;
            // 
            // label_tipo_accion_hecho_objetivo_actual
            // 
            this.label_tipo_accion_hecho_objetivo_actual.AutoSize = true;
            this.label_tipo_accion_hecho_objetivo_actual.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_accion_hecho_objetivo_actual.Name = "label_tipo_accion_hecho_objetivo_actual";
            this.label_tipo_accion_hecho_objetivo_actual.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_accion_hecho_objetivo_actual.TabIndex = 6;
            this.label_tipo_accion_hecho_objetivo_actual.Text = "LOG_ACCION_HECHO_OBJETIVO_ACTUAL";
            // 
            // label_accion_hecho_objetivo_actual_3
            // 
            this.label_accion_hecho_objetivo_actual_3.AutoSize = true;
            this.label_accion_hecho_objetivo_actual_3.Location = new System.Drawing.Point(15, 15);
            this.label_accion_hecho_objetivo_actual_3.Name = "label3";
            this.label_accion_hecho_objetivo_actual_3.Size = new System.Drawing.Size(48, 13);
            this.label_accion_hecho_objetivo_actual_3.TabIndex = 7;
            this.label_accion_hecho_objetivo_actual_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_accion_hecho_objetivo_actual);
        }


        private System.Windows.Forms.Panel panel_accion_quitando_hecho_pila_objetivos;
        private System.Windows.Forms.Label label_accion_quitando_hecho_pila_objetivos_3;
        private System.Windows.Forms.Label label_tipo_accion_quitando_hecho_pila_objetivos;
        private System.Windows.Forms.TextBox textBox_medio_accion_quitando_hecho_pila_objetivos;
        private System.Windows.Forms.TextBox textBox_inicial_accion_quitando_hecho_pila_objetivos;
        private System.Windows.Forms.Label label_accion_quitando_hecho_pila_objetivos_2;
        private System.Windows.Forms.Label label_accion_quitando_hecho_pila_objetivos_1;
        private System.Windows.Forms.Label label_formato_accion_quitando_hecho_pila_objetivos;
        private System.Windows.Forms.CheckBox checkBox_accion_quitando_hecho_pila_objetivos;

        void inicializar_accion_quitando_hecho_pila_objetivos()
        {
            this.panel_accion_quitando_hecho_pila_objetivos = new System.Windows.Forms.Panel();
            this.checkBox_accion_quitando_hecho_pila_objetivos = new System.Windows.Forms.CheckBox();
            this.label_formato_accion_quitando_hecho_pila_objetivos = new System.Windows.Forms.Label();
            this.label_accion_quitando_hecho_pila_objetivos_1 = new System.Windows.Forms.Label();
            this.label_accion_quitando_hecho_pila_objetivos_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_accion_quitando_hecho_pila_objetivos = new System.Windows.Forms.TextBox();
            this.textBox_medio_accion_quitando_hecho_pila_objetivos = new System.Windows.Forms.TextBox();
            this.label_tipo_accion_quitando_hecho_pila_objetivos = new System.Windows.Forms.Label();
            this.label_accion_quitando_hecho_pila_objetivos_3 = new System.Windows.Forms.Label();
            this.panel_accion_quitando_hecho_pila_objetivos.SuspendLayout();

            // 
            // panel_accion_quitando_hecho_pila_objetivos
            // 
            this.panel_accion_quitando_hecho_pila_objetivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_accion_quitando_hecho_pila_objetivos.Controls.Add(this.label_accion_quitando_hecho_pila_objetivos_3);
            this.panel_accion_quitando_hecho_pila_objetivos.Controls.Add(this.label_tipo_accion_quitando_hecho_pila_objetivos);
            this.panel_accion_quitando_hecho_pila_objetivos.Controls.Add(this.textBox_medio_accion_quitando_hecho_pila_objetivos);
            this.panel_accion_quitando_hecho_pila_objetivos.Controls.Add(this.textBox_inicial_accion_quitando_hecho_pila_objetivos);
            this.panel_accion_quitando_hecho_pila_objetivos.Controls.Add(this.label_accion_quitando_hecho_pila_objetivos_2);
            this.panel_accion_quitando_hecho_pila_objetivos.Controls.Add(this.label_accion_quitando_hecho_pila_objetivos_1);
            this.panel_accion_quitando_hecho_pila_objetivos.Controls.Add(this.label_formato_accion_quitando_hecho_pila_objetivos);
            this.panel_accion_quitando_hecho_pila_objetivos.Controls.Add(this.checkBox_accion_quitando_hecho_pila_objetivos);
            this.panel_accion_quitando_hecho_pila_objetivos.Location = new System.Drawing.Point(12, ultimo_y);
            ultimo_y += 120;
            this.panel_accion_quitando_hecho_pila_objetivos.Name = "panel_accion_quitando_hecho_pila_objetivos";
            this.panel_accion_quitando_hecho_pila_objetivos.Size = new System.Drawing.Size(550, 110);
            this.panel_accion_quitando_hecho_pila_objetivos.TabIndex = 0;
            // 
            // checkBox_accion_quitando_hecho_pila_objetivos
            // 
            this.checkBox_accion_quitando_hecho_pila_objetivos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_quitando_hecho_pila_objetivos.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_quitando_hecho_pila_objetivos.Name = "checkBox_accion_quitando_hecho_pila_objetivos";
            this.checkBox_accion_quitando_hecho_pila_objetivos.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_quitando_hecho_pila_objetivos.TabIndex = 0;
            this.checkBox_accion_quitando_hecho_pila_objetivos.Text = "Mostrar";
            this.checkBox_accion_quitando_hecho_pila_objetivos.UseVisualStyleBackColor = true;
            // 
            // label_formato_accion_quitando_hecho_pila_objetivos
            // 
            this.label_formato_accion_quitando_hecho_pila_objetivos.Location = new System.Drawing.Point(102, 32);
            this.label_formato_accion_quitando_hecho_pila_objetivos.Name = "label_formato_accion_quitando_hecho_pila_objetivos";
            this.label_formato_accion_quitando_hecho_pila_objetivos.Size = new System.Drawing.Size(395, 23);
            this.label_formato_accion_quitando_hecho_pila_objetivos.TabIndex = 1;
            this.label_formato_accion_quitando_hecho_pila_objetivos.Text = "texto_incial HECHO texto_final";
            this.label_formato_accion_quitando_hecho_pila_objetivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_accion_quitando_hecho_pila_objetivos_1
            // 
            this.label_accion_quitando_hecho_pila_objetivos_1.AutoSize = true;
            this.label_accion_quitando_hecho_pila_objetivos_1.Location = new System.Drawing.Point(12, 61);
            this.label_accion_quitando_hecho_pila_objetivos_1.Name = "label1";
            this.label_accion_quitando_hecho_pila_objetivos_1.Size = new System.Drawing.Size(66, 13);
            this.label_accion_quitando_hecho_pila_objetivos_1.TabIndex = 2;
            this.label_accion_quitando_hecho_pila_objetivos_1.Text = "Texto inicial:";
            // 
            // label_accion_quitando_hecho_pila_objetivos_2
            // 
            this.label_accion_quitando_hecho_pila_objetivos_2.AutoSize = true;
            this.label_accion_quitando_hecho_pila_objetivos_2.Location = new System.Drawing.Point(12, 87);
            this.label_accion_quitando_hecho_pila_objetivos_2.Name = "label2";
            this.label_accion_quitando_hecho_pila_objetivos_2.Size = new System.Drawing.Size(68, 13);
            this.label_accion_quitando_hecho_pila_objetivos_2.TabIndex = 3;
            this.label_accion_quitando_hecho_pila_objetivos_2.Text = "Texto final:";
            // 
            // textBox_inicial_accion_quitando_hecho_pila_objetivos
            // 
            this.textBox_inicial_accion_quitando_hecho_pila_objetivos.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_accion_quitando_hecho_pila_objetivos.Name = "textBox_inicial_accion_quitando_hecho_pila_objetivos";
            this.textBox_inicial_accion_quitando_hecho_pila_objetivos.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_accion_quitando_hecho_pila_objetivos.TabIndex = 4;
            // 
            // textBox_medio_accion_quitando_hecho_pila_objetivos
            // 
            this.textBox_medio_accion_quitando_hecho_pila_objetivos.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_accion_quitando_hecho_pila_objetivos.Name = "textBox_medio_accion_quitando_hecho_pila_objetivos";
            this.textBox_medio_accion_quitando_hecho_pila_objetivos.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_accion_quitando_hecho_pila_objetivos.TabIndex = 5;
            // 
            // label_tipo_accion_quitando_hecho_pila_objetivos
            // 
            this.label_tipo_accion_quitando_hecho_pila_objetivos.AutoSize = true;
            this.label_tipo_accion_quitando_hecho_pila_objetivos.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_accion_quitando_hecho_pila_objetivos.Name = "label_tipo_accion_quitando_hecho_pila_objetivos";
            this.label_tipo_accion_quitando_hecho_pila_objetivos.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_accion_quitando_hecho_pila_objetivos.TabIndex = 6;
            this.label_tipo_accion_quitando_hecho_pila_objetivos.Text = "LOG_ACCION_QUITANDO_HECHO_DE_PILA_OBJETIVOS";
            // 
            // label_accion_quitando_hecho_pila_objetivos_3
            // 
            this.label_accion_quitando_hecho_pila_objetivos_3.AutoSize = true;
            this.label_accion_quitando_hecho_pila_objetivos_3.Location = new System.Drawing.Point(15, 15);
            this.label_accion_quitando_hecho_pila_objetivos_3.Name = "label3";
            this.label_accion_quitando_hecho_pila_objetivos_3.Size = new System.Drawing.Size(48, 13);
            this.label_accion_quitando_hecho_pila_objetivos_3.TabIndex = 7;
            this.label_accion_quitando_hecho_pila_objetivos_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_accion_quitando_hecho_pila_objetivos);
        }


        private System.Windows.Forms.Panel panel_info_sin_reglas_para_inferir_hecho;
        private System.Windows.Forms.Label label_info_sin_reglas_para_inferir_hecho_3;
        private System.Windows.Forms.Label label_tipo_info_sin_reglas_para_inferir_hecho;
        private System.Windows.Forms.TextBox textBox_medio_info_sin_reglas_para_inferir_hecho;
        private System.Windows.Forms.TextBox textBox_inicial_info_sin_reglas_para_inferir_hecho;
        private System.Windows.Forms.Label label_info_sin_reglas_para_inferir_hecho_2;
        private System.Windows.Forms.Label label_info_sin_reglas_para_inferir_hecho_1;
        private System.Windows.Forms.Label label_formato_info_sin_reglas_para_inferir_hecho;
        private System.Windows.Forms.CheckBox checkBox_info_sin_reglas_para_inferir_hecho;

        void inicializar_info_sin_reglas_para_inferir_hecho()
        {
            this.panel_info_sin_reglas_para_inferir_hecho = new System.Windows.Forms.Panel();
            this.checkBox_info_sin_reglas_para_inferir_hecho = new System.Windows.Forms.CheckBox();
            this.label_formato_info_sin_reglas_para_inferir_hecho = new System.Windows.Forms.Label();
            this.label_info_sin_reglas_para_inferir_hecho_1 = new System.Windows.Forms.Label();
            this.label_info_sin_reglas_para_inferir_hecho_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_info_sin_reglas_para_inferir_hecho = new System.Windows.Forms.TextBox();
            this.textBox_medio_info_sin_reglas_para_inferir_hecho = new System.Windows.Forms.TextBox();
            this.label_tipo_info_sin_reglas_para_inferir_hecho = new System.Windows.Forms.Label();
            this.label_info_sin_reglas_para_inferir_hecho_3 = new System.Windows.Forms.Label();
            this.panel_info_sin_reglas_para_inferir_hecho.SuspendLayout();

            // 
            // panel_info_sin_reglas_para_inferir_hecho
            // 
            this.panel_info_sin_reglas_para_inferir_hecho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_info_sin_reglas_para_inferir_hecho.Controls.Add(this.label_info_sin_reglas_para_inferir_hecho_3);
            this.panel_info_sin_reglas_para_inferir_hecho.Controls.Add(this.label_tipo_info_sin_reglas_para_inferir_hecho);
            this.panel_info_sin_reglas_para_inferir_hecho.Controls.Add(this.textBox_medio_info_sin_reglas_para_inferir_hecho);
            this.panel_info_sin_reglas_para_inferir_hecho.Controls.Add(this.textBox_inicial_info_sin_reglas_para_inferir_hecho);
            this.panel_info_sin_reglas_para_inferir_hecho.Controls.Add(this.label_info_sin_reglas_para_inferir_hecho_2);
            this.panel_info_sin_reglas_para_inferir_hecho.Controls.Add(this.label_info_sin_reglas_para_inferir_hecho_1);
            this.panel_info_sin_reglas_para_inferir_hecho.Controls.Add(this.label_formato_info_sin_reglas_para_inferir_hecho);
            this.panel_info_sin_reglas_para_inferir_hecho.Controls.Add(this.checkBox_info_sin_reglas_para_inferir_hecho);
            this.panel_info_sin_reglas_para_inferir_hecho.Location = new System.Drawing.Point(12, ultimo_y);
            ultimo_y += 120;
            this.panel_info_sin_reglas_para_inferir_hecho.Name = "panel_info_sin_reglas_para_inferir_hecho";
            this.panel_info_sin_reglas_para_inferir_hecho.Size = new System.Drawing.Size(550, 110);
            this.panel_info_sin_reglas_para_inferir_hecho.TabIndex = 0;
            // 
            // checkBox_info_sin_reglas_para_inferir_hecho
            // 
            this.checkBox_info_sin_reglas_para_inferir_hecho.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_info_sin_reglas_para_inferir_hecho.Location = new System.Drawing.Point(15, 34);
            this.checkBox_info_sin_reglas_para_inferir_hecho.Name = "checkBox_info_sin_reglas_para_inferir_hecho";
            this.checkBox_info_sin_reglas_para_inferir_hecho.Size = new System.Drawing.Size(81, 24);
            this.checkBox_info_sin_reglas_para_inferir_hecho.TabIndex = 0;
            this.checkBox_info_sin_reglas_para_inferir_hecho.Text = "Mostrar";
            this.checkBox_info_sin_reglas_para_inferir_hecho.UseVisualStyleBackColor = true;
            // 
            // label_formato_info_sin_reglas_para_inferir_hecho
            // 
            this.label_formato_info_sin_reglas_para_inferir_hecho.Location = new System.Drawing.Point(102, 32);
            this.label_formato_info_sin_reglas_para_inferir_hecho.Name = "label_formato_info_sin_reglas_para_inferir_hecho";
            this.label_formato_info_sin_reglas_para_inferir_hecho.Size = new System.Drawing.Size(395, 23);
            this.label_formato_info_sin_reglas_para_inferir_hecho.TabIndex = 1;
            this.label_formato_info_sin_reglas_para_inferir_hecho.Text = "texto_inicial HECHO texto_final";
            this.label_formato_info_sin_reglas_para_inferir_hecho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_info_sin_reglas_para_inferir_hecho_1
            // 
            this.label_info_sin_reglas_para_inferir_hecho_1.AutoSize = true;
            this.label_info_sin_reglas_para_inferir_hecho_1.Location = new System.Drawing.Point(12, 61);
            this.label_info_sin_reglas_para_inferir_hecho_1.Name = "label1";
            this.label_info_sin_reglas_para_inferir_hecho_1.Size = new System.Drawing.Size(66, 13);
            this.label_info_sin_reglas_para_inferir_hecho_1.TabIndex = 2;
            this.label_info_sin_reglas_para_inferir_hecho_1.Text = "Texto inicial:";
            // 
            // label_info_sin_reglas_para_inferir_hecho_2
            // 
            this.label_info_sin_reglas_para_inferir_hecho_2.AutoSize = true;
            this.label_info_sin_reglas_para_inferir_hecho_2.Location = new System.Drawing.Point(12, 87);
            this.label_info_sin_reglas_para_inferir_hecho_2.Name = "label2";
            this.label_info_sin_reglas_para_inferir_hecho_2.Size = new System.Drawing.Size(68, 13);
            this.label_info_sin_reglas_para_inferir_hecho_2.TabIndex = 3;
            this.label_info_sin_reglas_para_inferir_hecho_2.Text = "Texto final:";
            // 
            // textBox_inicial_info_sin_reglas_para_inferir_hecho
            // 
            this.textBox_inicial_info_sin_reglas_para_inferir_hecho.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_info_sin_reglas_para_inferir_hecho.Name = "textBox_inicial_info_sin_reglas_para_inferir_hecho";
            this.textBox_inicial_info_sin_reglas_para_inferir_hecho.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_info_sin_reglas_para_inferir_hecho.TabIndex = 4;
            // 
            // textBox_medio_info_sin_reglas_para_inferir_hecho
            // 
            this.textBox_medio_info_sin_reglas_para_inferir_hecho.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_info_sin_reglas_para_inferir_hecho.Name = "textBox_medio_info_sin_reglas_para_inferir_hecho";
            this.textBox_medio_info_sin_reglas_para_inferir_hecho.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_info_sin_reglas_para_inferir_hecho.TabIndex = 5;
            // 
            // label_tipo_info_sin_reglas_para_inferir_hecho
            // 
            this.label_tipo_info_sin_reglas_para_inferir_hecho.AutoSize = true;
            this.label_tipo_info_sin_reglas_para_inferir_hecho.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_info_sin_reglas_para_inferir_hecho.Name = "label_tipo_info_sin_reglas_para_inferir_hecho";
            this.label_tipo_info_sin_reglas_para_inferir_hecho.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_info_sin_reglas_para_inferir_hecho.TabIndex = 6;
            this.label_tipo_info_sin_reglas_para_inferir_hecho.Text = "LOG_INFO_SIN_REGLAS_PARA_INFERIR_HECHO";
            // 
            // label_info_sin_reglas_para_inferir_hecho_3
            // 
            this.label_info_sin_reglas_para_inferir_hecho_3.AutoSize = true;
            this.label_info_sin_reglas_para_inferir_hecho_3.Location = new System.Drawing.Point(15, 15);
            this.label_info_sin_reglas_para_inferir_hecho_3.Name = "label3";
            this.label_info_sin_reglas_para_inferir_hecho_3.Size = new System.Drawing.Size(48, 13);
            this.label_info_sin_reglas_para_inferir_hecho_3.TabIndex = 7;
            this.label_info_sin_reglas_para_inferir_hecho_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_info_sin_reglas_para_inferir_hecho);
        }


        private System.Windows.Forms.Panel panel_accion_consultando_hechos;
        private System.Windows.Forms.Label label_accion_consultando_hechos_3;
        private System.Windows.Forms.Label label_tipo_accion_consultando_hechos;
        private System.Windows.Forms.TextBox textBox_medio_accion_consultando_hechos;
        private System.Windows.Forms.TextBox textBox_inicial_accion_consultando_hechos;
        private System.Windows.Forms.Label label_accion_consultando_hechos_2;
        private System.Windows.Forms.Label label_accion_consultando_hechos_1;
        private System.Windows.Forms.Label label_formato_accion_consultando_hechos;
        private System.Windows.Forms.CheckBox checkBox_accion_consultando_hechos;

        void inicializar_accion_consultando_hechos()
        {
            this.panel_accion_consultando_hechos = new System.Windows.Forms.Panel();
            this.checkBox_accion_consultando_hechos = new System.Windows.Forms.CheckBox();
            this.label_formato_accion_consultando_hechos = new System.Windows.Forms.Label();
            this.label_accion_consultando_hechos_1 = new System.Windows.Forms.Label();
            this.label_accion_consultando_hechos_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_accion_consultando_hechos = new System.Windows.Forms.TextBox();
            this.textBox_medio_accion_consultando_hechos = new System.Windows.Forms.TextBox();
            this.label_tipo_accion_consultando_hechos = new System.Windows.Forms.Label();
            this.label_accion_consultando_hechos_3 = new System.Windows.Forms.Label();
            this.panel_accion_consultando_hechos.SuspendLayout();

            // 
            // panel_accion_consultando_hechos
            // 
            this.panel_accion_consultando_hechos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_accion_consultando_hechos.Controls.Add(this.label_accion_consultando_hechos_3);
            this.panel_accion_consultando_hechos.Controls.Add(this.label_tipo_accion_consultando_hechos);
            this.panel_accion_consultando_hechos.Controls.Add(this.textBox_medio_accion_consultando_hechos);
            this.panel_accion_consultando_hechos.Controls.Add(this.textBox_inicial_accion_consultando_hechos);
            this.panel_accion_consultando_hechos.Controls.Add(this.label_accion_consultando_hechos_2);
            this.panel_accion_consultando_hechos.Controls.Add(this.label_accion_consultando_hechos_1);
            this.panel_accion_consultando_hechos.Controls.Add(this.label_formato_accion_consultando_hechos);
            this.panel_accion_consultando_hechos.Controls.Add(this.checkBox_accion_consultando_hechos);
            this.panel_accion_consultando_hechos.Location = new System.Drawing.Point(12, ultimo_y);
            ultimo_y += 120;
            this.panel_accion_consultando_hechos.Name = "panel_accion_consultando_hechos";
            this.panel_accion_consultando_hechos.Size = new System.Drawing.Size(550, 110);
            this.panel_accion_consultando_hechos.TabIndex = 0;
            // 
            // checkBox_accion_consultando_hechos
            // 
            this.checkBox_accion_consultando_hechos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_consultando_hechos.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_consultando_hechos.Name = "checkBox_accion_consultando_hechos";
            this.checkBox_accion_consultando_hechos.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_consultando_hechos.TabIndex = 0;
            this.checkBox_accion_consultando_hechos.Text = "Mostrar";
            this.checkBox_accion_consultando_hechos.UseVisualStyleBackColor = true;
            // 
            // label_formato_accion_consultando_hechos
            // 
            this.label_formato_accion_consultando_hechos.Location = new System.Drawing.Point(102, 32);
            this.label_formato_accion_consultando_hechos.Name = "label_formato_accion_consultando_hechos";
            this.label_formato_accion_consultando_hechos.Size = new System.Drawing.Size(395, 23);
            this.label_formato_accion_consultando_hechos.TabIndex = 1;
            this.label_formato_accion_consultando_hechos.Text = "texto_inicial HECHO texto_final";
            this.label_formato_accion_consultando_hechos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_accion_consultando_hechos_1
            // 
            this.label_accion_consultando_hechos_1.AutoSize = true;
            this.label_accion_consultando_hechos_1.Location = new System.Drawing.Point(12, 61);
            this.label_accion_consultando_hechos_1.Name = "label1";
            this.label_accion_consultando_hechos_1.Size = new System.Drawing.Size(66, 13);
            this.label_accion_consultando_hechos_1.TabIndex = 2;
            this.label_accion_consultando_hechos_1.Text = "Texto inicial:";
            // 
            // label_accion_consultando_hechos_2
            // 
            this.label_accion_consultando_hechos_2.AutoSize = true;
            this.label_accion_consultando_hechos_2.Location = new System.Drawing.Point(12, 87);
            this.label_accion_consultando_hechos_2.Name = "label2";
            this.label_accion_consultando_hechos_2.Size = new System.Drawing.Size(68, 13);
            this.label_accion_consultando_hechos_2.TabIndex = 3;
            this.label_accion_consultando_hechos_2.Text = "Texto final:";
            // 
            // textBox_inicial_accion_consultando_hechos
            // 
            this.textBox_inicial_accion_consultando_hechos.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_accion_consultando_hechos.Name = "textBox_inicial_accion_consultando_hechos";
            this.textBox_inicial_accion_consultando_hechos.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_accion_consultando_hechos.TabIndex = 4;
            // 
            // textBox_medio_accion_consultando_hechos
            // 
            this.textBox_medio_accion_consultando_hechos.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_accion_consultando_hechos.Name = "textBox_medio_accion_consultando_hechos";
            this.textBox_medio_accion_consultando_hechos.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_accion_consultando_hechos.TabIndex = 5;
            // 
            // label_tipo_accion_consultando_hechos
            // 
            this.label_tipo_accion_consultando_hechos.AutoSize = true;
            this.label_tipo_accion_consultando_hechos.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_accion_consultando_hechos.Name = "label_tipo_accion_consultando_hechos";
            this.label_tipo_accion_consultando_hechos.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_accion_consultando_hechos.TabIndex = 6;
            this.label_tipo_accion_consultando_hechos.Text = "LOG_ACCION_CONSULTANDO_HECHOS";
            // 
            // label_accion_consultando_hechos_3
            // 
            this.label_accion_consultando_hechos_3.AutoSize = true;
            this.label_accion_consultando_hechos_3.Location = new System.Drawing.Point(15, 15);
            this.label_accion_consultando_hechos_3.Name = "label3";
            this.label_accion_consultando_hechos_3.Size = new System.Drawing.Size(48, 13);
            this.label_accion_consultando_hechos_3.TabIndex = 7;
            this.label_accion_consultando_hechos_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_accion_consultando_hechos);
        }



        private System.Windows.Forms.Panel panel_accion_ingresando_hecho_a_pila_de_objetivos;
        private System.Windows.Forms.Label label_accion_ingresando_hecho_a_pila_de_objetivos_3;
        private System.Windows.Forms.Label label_tipo_accion_ingresando_hecho_a_pila_de_objetivos;
        private System.Windows.Forms.TextBox textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos;
        private System.Windows.Forms.TextBox textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos;
        private System.Windows.Forms.Label label_accion_ingresando_hecho_a_pila_de_objetivos_2;
        private System.Windows.Forms.Label label_accion_ingresando_hecho_a_pila_de_objetivos_1;
        private System.Windows.Forms.Label label_formato_accion_ingresando_hecho_a_pila_de_objetivos;
        private System.Windows.Forms.CheckBox checkBox_accion_ingresando_hecho_a_pila_de_objetivos;

        void inicializar_accion_ingresando_hecho_a_pila_de_objetivos()
        {
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos = new System.Windows.Forms.Panel();
            this.checkBox_accion_ingresando_hecho_a_pila_de_objetivos = new System.Windows.Forms.CheckBox();
            this.label_formato_accion_ingresando_hecho_a_pila_de_objetivos = new System.Windows.Forms.Label();
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_1 = new System.Windows.Forms.Label();
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos = new System.Windows.Forms.TextBox();
            this.textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos = new System.Windows.Forms.TextBox();
            this.label_tipo_accion_ingresando_hecho_a_pila_de_objetivos = new System.Windows.Forms.Label();
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_3 = new System.Windows.Forms.Label();
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.SuspendLayout();

            // 
            // panel_accion_ingresando_hecho_a_pila_de_objetivos
            // 
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Controls.Add(this.label_accion_ingresando_hecho_a_pila_de_objetivos_3);
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Controls.Add(this.label_tipo_accion_ingresando_hecho_a_pila_de_objetivos);
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Controls.Add(this.textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos);
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Controls.Add(this.textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos);
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Controls.Add(this.label_accion_ingresando_hecho_a_pila_de_objetivos_2);
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Controls.Add(this.label_accion_ingresando_hecho_a_pila_de_objetivos_1);
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Controls.Add(this.label_formato_accion_ingresando_hecho_a_pila_de_objetivos);
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Controls.Add(this.checkBox_accion_ingresando_hecho_a_pila_de_objetivos);
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Location = new System.Drawing.Point(12, ultimo_y);
            ultimo_y += 120;
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Name = "panel_accion_ingresando_hecho_a_pila_de_objetivos";
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Size = new System.Drawing.Size(550, 110);
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.TabIndex = 0;
            // 
            // checkBox_accion_ingresando_hecho_a_pila_de_objetivos
            // 
            this.checkBox_accion_ingresando_hecho_a_pila_de_objetivos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_ingresando_hecho_a_pila_de_objetivos.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_ingresando_hecho_a_pila_de_objetivos.Name = "checkBox_accion_ingresando_hecho_a_pila_de_objetivos";
            this.checkBox_accion_ingresando_hecho_a_pila_de_objetivos.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_ingresando_hecho_a_pila_de_objetivos.TabIndex = 0;
            this.checkBox_accion_ingresando_hecho_a_pila_de_objetivos.Text = "Mostrar";
            this.checkBox_accion_ingresando_hecho_a_pila_de_objetivos.UseVisualStyleBackColor = true;
            // 
            // label_formato_accion_ingresando_hecho_a_pila_de_objetivos
            // 
            this.label_formato_accion_ingresando_hecho_a_pila_de_objetivos.Location = new System.Drawing.Point(102, 32);
            this.label_formato_accion_ingresando_hecho_a_pila_de_objetivos.Name = "label_formato_accion_ingresando_hecho_a_pila_de_objetivos";
            this.label_formato_accion_ingresando_hecho_a_pila_de_objetivos.Size = new System.Drawing.Size(395, 23);
            this.label_formato_accion_ingresando_hecho_a_pila_de_objetivos.TabIndex = 1;
            this.label_formato_accion_ingresando_hecho_a_pila_de_objetivos.Text = "texto_inicial HECHO texto_final";
            this.label_formato_accion_ingresando_hecho_a_pila_de_objetivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_accion_ingresando_hecho_a_pila_de_objetivos_1
            // 
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_1.AutoSize = true;
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_1.Location = new System.Drawing.Point(12, 61);
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_1.Name = "label1";
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_1.Size = new System.Drawing.Size(66, 13);
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_1.TabIndex = 2;
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_1.Text = "Texto inicial:";
            // 
            // label_accion_ingresando_hecho_a_pila_de_objetivos_2
            // 
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_2.AutoSize = true;
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_2.Location = new System.Drawing.Point(12, 87);
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_2.Name = "label2";
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_2.Size = new System.Drawing.Size(68, 13);
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_2.TabIndex = 3;
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_2.Text = "Texto final:";
            // 
            // textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos
            // 
            this.textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos.Name = "textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos";
            this.textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos.TabIndex = 4;
            // 
            // textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos
            // 
            this.textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos.Name = "textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos";
            this.textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos.TabIndex = 5;
            // 
            // label_tipo_accion_ingresando_hecho_a_pila_de_objetivos
            // 
            this.label_tipo_accion_ingresando_hecho_a_pila_de_objetivos.AutoSize = true;
            this.label_tipo_accion_ingresando_hecho_a_pila_de_objetivos.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_accion_ingresando_hecho_a_pila_de_objetivos.Name = "label_tipo_accion_ingresando_hecho_a_pila_de_objetivos";
            this.label_tipo_accion_ingresando_hecho_a_pila_de_objetivos.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_accion_ingresando_hecho_a_pila_de_objetivos.TabIndex = 6;
            this.label_tipo_accion_ingresando_hecho_a_pila_de_objetivos.Text = "LOG_ACCION_INGRESANDO_HECHO_A_PILA_OBJETIVOS";
            // 
            // label_accion_ingresando_hecho_a_pila_de_objetivos_3
            // 
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_3.AutoSize = true;
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_3.Location = new System.Drawing.Point(15, 15);
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_3.Name = "label3";
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_3.Size = new System.Drawing.Size(48, 13);
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_3.TabIndex = 7;
            this.label_accion_ingresando_hecho_a_pila_de_objetivos_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_accion_ingresando_hecho_a_pila_de_objetivos);
        }

        private System.Windows.Forms.Panel panel_log_regla;
        private System.Windows.Forms.Label label_log_regla_3;
        private System.Windows.Forms.Label label_tipo_log_regla;
        private System.Windows.Forms.Label label_log_regla_1;
        private System.Windows.Forms.CheckBox checkBox_log_regla;

        void inicializar_log_regla()
        {
            this.panel_log_regla = new System.Windows.Forms.Panel();
            this.checkBox_log_regla = new System.Windows.Forms.CheckBox();
            this.label_log_regla_1 = new System.Windows.Forms.Label();
            this.label_tipo_log_regla = new System.Windows.Forms.Label();
            this.label_log_regla_3 = new System.Windows.Forms.Label();
            this.panel_log_regla.SuspendLayout();

            // 
            // panel_log_regla
            // 
            this.panel_log_regla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_log_regla.Controls.Add(this.label_log_regla_3);
            this.panel_log_regla.Controls.Add(this.label_tipo_log_regla);
            this.panel_log_regla.Controls.Add(this.label_log_regla_1);
            this.panel_log_regla.Controls.Add(this.checkBox_log_regla);
            this.panel_log_regla.Location = new System.Drawing.Point(12, ultimo_y);
            this.panel_log_regla.Name = "panel_log_regla";
            this.panel_log_regla.Size = new System.Drawing.Size(550, 60);
            ultimo_y += 70;
            this.panel_log_regla.TabIndex = 0;
            // 
            // checkBox_log_regla
            // 
            this.checkBox_log_regla.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_log_regla.Location = new System.Drawing.Point(15, 34);
            this.checkBox_log_regla.Name = "checkBox_log_regla";
            this.checkBox_log_regla.Size = new System.Drawing.Size(81, 24);
            this.checkBox_log_regla.TabIndex = 0;
            this.checkBox_log_regla.Text = "Mostrar";
            this.checkBox_log_regla.UseVisualStyleBackColor = true;
            // 
            // label_log_regla_1
            // 
            this.label_log_regla_1.AutoSize = true;
            this.label_log_regla_1.Location = new System.Drawing.Point(12, 61);
            this.label_log_regla_1.Name = "label1";
            this.label_log_regla_1.Size = new System.Drawing.Size(66, 13);
            this.label_log_regla_1.TabIndex = 2;
            this.label_log_regla_1.Text = "Texto inicial:";
            // 
            // label_tipo_log_regla
            // 
            this.label_tipo_log_regla.AutoSize = true;
            this.label_tipo_log_regla.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_log_regla.Name = "label_tipo_log_regla";
            this.label_tipo_log_regla.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_log_regla.TabIndex = 6;
            this.label_tipo_log_regla.Text = "LOG_REGLA";
            // 
            // label_log_regla_3
            // 
            this.label_log_regla_3.AutoSize = true;
            this.label_log_regla_3.Location = new System.Drawing.Point(15, 15);
            this.label_log_regla_3.Name = "label3";
            this.label_log_regla_3.Size = new System.Drawing.Size(48, 13);
            this.label_log_regla_3.TabIndex = 7;
            this.label_log_regla_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_log_regla);
        }


        private System.Windows.Forms.Panel panel_accion_elegida_mejor_regla;
        private System.Windows.Forms.Label label_accion_elegida_mejor_regla_3;
        private System.Windows.Forms.Label label_tipo_accion_elegida_mejor_regla;
        private System.Windows.Forms.TextBox textBox_medio_accion_elegida_mejor_regla;
        private System.Windows.Forms.TextBox textBox_inicial_accion_elegida_mejor_regla;
        private System.Windows.Forms.Label label_accion_elegida_mejor_regla_2;
        private System.Windows.Forms.Label label_accion_elegida_mejor_regla_1;
        private System.Windows.Forms.Label label_formato_accion_elegida_mejor_regla;
        private System.Windows.Forms.CheckBox checkBox_accion_elegida_mejor_regla;

        void inicializar_accion_elegida_mejor_regla()
        {
            this.panel_accion_elegida_mejor_regla = new System.Windows.Forms.Panel();
            this.checkBox_accion_elegida_mejor_regla = new System.Windows.Forms.CheckBox();
            this.label_formato_accion_elegida_mejor_regla = new System.Windows.Forms.Label();
            this.label_accion_elegida_mejor_regla_1 = new System.Windows.Forms.Label();
            this.label_accion_elegida_mejor_regla_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_accion_elegida_mejor_regla = new System.Windows.Forms.TextBox();
            this.textBox_medio_accion_elegida_mejor_regla = new System.Windows.Forms.TextBox();
            this.label_tipo_accion_elegida_mejor_regla = new System.Windows.Forms.Label();
            this.label_accion_elegida_mejor_regla_3 = new System.Windows.Forms.Label();
            this.panel_accion_elegida_mejor_regla.SuspendLayout();

            // 
            // panel_accion_elegida_mejor_regla
            // 
            this.panel_accion_elegida_mejor_regla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_accion_elegida_mejor_regla.Controls.Add(this.label_accion_elegida_mejor_regla_3);
            this.panel_accion_elegida_mejor_regla.Controls.Add(this.label_tipo_accion_elegida_mejor_regla);
            this.panel_accion_elegida_mejor_regla.Controls.Add(this.textBox_medio_accion_elegida_mejor_regla);
            this.panel_accion_elegida_mejor_regla.Controls.Add(this.textBox_inicial_accion_elegida_mejor_regla);
            this.panel_accion_elegida_mejor_regla.Controls.Add(this.label_accion_elegida_mejor_regla_2);
            this.panel_accion_elegida_mejor_regla.Controls.Add(this.label_accion_elegida_mejor_regla_1);
            this.panel_accion_elegida_mejor_regla.Controls.Add(this.label_formato_accion_elegida_mejor_regla);
            this.panel_accion_elegida_mejor_regla.Controls.Add(this.checkBox_accion_elegida_mejor_regla);
            this.panel_accion_elegida_mejor_regla.Location = new System.Drawing.Point(12, ultimo_y);
            ultimo_y += 120;
            this.panel_accion_elegida_mejor_regla.Name = "panel_accion_elegida_mejor_regla";
            this.panel_accion_elegida_mejor_regla.Size = new System.Drawing.Size(550, 110);
            this.panel_accion_elegida_mejor_regla.TabIndex = 0;
            // 
            // checkBox_accion_elegida_mejor_regla
            // 
            this.checkBox_accion_elegida_mejor_regla.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_elegida_mejor_regla.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_elegida_mejor_regla.Name = "checkBox_accion_elegida_mejor_regla";
            this.checkBox_accion_elegida_mejor_regla.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_elegida_mejor_regla.TabIndex = 0;
            this.checkBox_accion_elegida_mejor_regla.Text = "Mostrar";
            this.checkBox_accion_elegida_mejor_regla.UseVisualStyleBackColor = true;
            // 
            // label_formato_accion_elegida_mejor_regla
            // 
            this.label_formato_accion_elegida_mejor_regla.Location = new System.Drawing.Point(102, 32);
            this.label_formato_accion_elegida_mejor_regla.Name = "label_formato_accion_elegida_mejor_regla";
            this.label_formato_accion_elegida_mejor_regla.Size = new System.Drawing.Size(395, 23);
            this.label_formato_accion_elegida_mejor_regla.TabIndex = 1;
            this.label_formato_accion_elegida_mejor_regla.Text = "texto_inicial REGLA texto_final";
            this.label_formato_accion_elegida_mejor_regla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_accion_elegida_mejor_regla_1
            // 
            this.label_accion_elegida_mejor_regla_1.AutoSize = true;
            this.label_accion_elegida_mejor_regla_1.Location = new System.Drawing.Point(12, 61);
            this.label_accion_elegida_mejor_regla_1.Name = "label1";
            this.label_accion_elegida_mejor_regla_1.Size = new System.Drawing.Size(66, 13);
            this.label_accion_elegida_mejor_regla_1.TabIndex = 2;
            this.label_accion_elegida_mejor_regla_1.Text = "Texto inicial:";
            // 
            // label_accion_elegida_mejor_regla_2
            // 
            this.label_accion_elegida_mejor_regla_2.AutoSize = true;
            this.label_accion_elegida_mejor_regla_2.Location = new System.Drawing.Point(12, 87);
            this.label_accion_elegida_mejor_regla_2.Name = "label2";
            this.label_accion_elegida_mejor_regla_2.Size = new System.Drawing.Size(68, 13);
            this.label_accion_elegida_mejor_regla_2.TabIndex = 3;
            this.label_accion_elegida_mejor_regla_2.Text = "Texto final:";
            // 
            // textBox_inicial_accion_elegida_mejor_regla
            // 
            this.textBox_inicial_accion_elegida_mejor_regla.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_accion_elegida_mejor_regla.Name = "textBox_inicial_accion_elegida_mejor_regla";
            this.textBox_inicial_accion_elegida_mejor_regla.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_accion_elegida_mejor_regla.TabIndex = 4;
            // 
            // textBox_medio_accion_elegida_mejor_regla
            // 
            this.textBox_medio_accion_elegida_mejor_regla.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_accion_elegida_mejor_regla.Name = "textBox_medio_accion_elegida_mejor_regla";
            this.textBox_medio_accion_elegida_mejor_regla.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_accion_elegida_mejor_regla.TabIndex = 5;
            // 
            // label_tipo_accion_elegida_mejor_regla
            // 
            this.label_tipo_accion_elegida_mejor_regla.AutoSize = true;
            this.label_tipo_accion_elegida_mejor_regla.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_accion_elegida_mejor_regla.Name = "label_tipo_accion_elegida_mejor_regla";
            this.label_tipo_accion_elegida_mejor_regla.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_accion_elegida_mejor_regla.TabIndex = 6;
            this.label_tipo_accion_elegida_mejor_regla.Text = "LOG_ACCION_ELEGIDA_MEJOR_REGLA";
            // 
            // label_accion_elegida_mejor_regla_3
            // 
            this.label_accion_elegida_mejor_regla_3.AutoSize = true;
            this.label_accion_elegida_mejor_regla_3.Location = new System.Drawing.Point(15, 15);
            this.label_accion_elegida_mejor_regla_3.Name = "label3";
            this.label_accion_elegida_mejor_regla_3.Size = new System.Drawing.Size(48, 13);
            this.label_accion_elegida_mejor_regla_3.TabIndex = 7;
            this.label_accion_elegida_mejor_regla_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_accion_elegida_mejor_regla);
        }


        private System.Windows.Forms.Panel panel_accion_validando_regla;
        private System.Windows.Forms.Label label_accion_validando_regla_3;
        private System.Windows.Forms.Label label_tipo_accion_validando_regla;
        private System.Windows.Forms.TextBox textBox_medio_accion_validando_regla;
        private System.Windows.Forms.TextBox textBox_inicial_accion_validando_regla;
        private System.Windows.Forms.Label label_accion_validando_regla_2;
        private System.Windows.Forms.Label label_accion_validando_regla_1;
        private System.Windows.Forms.Label label_formato_accion_validando_regla;
        private System.Windows.Forms.CheckBox checkBox_accion_validando_regla;

        void inicializar_accion_validando_regla()
        {
            this.panel_accion_validando_regla = new System.Windows.Forms.Panel();
            this.checkBox_accion_validando_regla = new System.Windows.Forms.CheckBox();
            this.label_formato_accion_validando_regla = new System.Windows.Forms.Label();
            this.label_accion_validando_regla_1 = new System.Windows.Forms.Label();
            this.label_accion_validando_regla_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_accion_validando_regla = new System.Windows.Forms.TextBox();
            this.textBox_medio_accion_validando_regla = new System.Windows.Forms.TextBox();
            this.label_tipo_accion_validando_regla = new System.Windows.Forms.Label();
            this.label_accion_validando_regla_3 = new System.Windows.Forms.Label();
            this.panel_accion_validando_regla.SuspendLayout();

            // 
            // panel_accion_validando_regla
            // 
            this.panel_accion_validando_regla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_accion_validando_regla.Controls.Add(this.label_accion_validando_regla_3);
            this.panel_accion_validando_regla.Controls.Add(this.label_tipo_accion_validando_regla);
            this.panel_accion_validando_regla.Controls.Add(this.textBox_medio_accion_validando_regla);
            this.panel_accion_validando_regla.Controls.Add(this.textBox_inicial_accion_validando_regla);
            this.panel_accion_validando_regla.Controls.Add(this.label_accion_validando_regla_2);
            this.panel_accion_validando_regla.Controls.Add(this.label_accion_validando_regla_1);
            this.panel_accion_validando_regla.Controls.Add(this.label_formato_accion_validando_regla);
            this.panel_accion_validando_regla.Controls.Add(this.checkBox_accion_validando_regla);
            this.panel_accion_validando_regla.Location = new System.Drawing.Point(12, ultimo_y);
            ultimo_y += 120;
            this.panel_accion_validando_regla.Name = "panel_accion_validando_regla";
            this.panel_accion_validando_regla.Size = new System.Drawing.Size(550, 110);
            this.panel_accion_validando_regla.TabIndex = 0;
            // 
            // checkBox_accion_validando_regla
            // 
            this.checkBox_accion_validando_regla.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_validando_regla.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_validando_regla.Name = "checkBox_accion_validando_regla";
            this.checkBox_accion_validando_regla.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_validando_regla.TabIndex = 0;
            this.checkBox_accion_validando_regla.Text = "Mostrar";
            this.checkBox_accion_validando_regla.UseVisualStyleBackColor = true;
            // 
            // label_formato_accion_validando_regla
            // 
            this.label_formato_accion_validando_regla.Location = new System.Drawing.Point(102, 32);
            this.label_formato_accion_validando_regla.Name = "label_formato_accion_validando_regla";
            this.label_formato_accion_validando_regla.Size = new System.Drawing.Size(395, 23);
            this.label_formato_accion_validando_regla.TabIndex = 1;
            this.label_formato_accion_validando_regla.Text = "texto_inicial REGLA texto_final";
            this.label_formato_accion_validando_regla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_accion_validando_regla_1
            // 
            this.label_accion_validando_regla_1.AutoSize = true;
            this.label_accion_validando_regla_1.Location = new System.Drawing.Point(12, 61);
            this.label_accion_validando_regla_1.Name = "label1";
            this.label_accion_validando_regla_1.Size = new System.Drawing.Size(66, 13);
            this.label_accion_validando_regla_1.TabIndex = 2;
            this.label_accion_validando_regla_1.Text = "Texto inicial:";
            // 
            // label_accion_validando_regla_2
            // 
            this.label_accion_validando_regla_2.AutoSize = true;
            this.label_accion_validando_regla_2.Location = new System.Drawing.Point(12, 87);
            this.label_accion_validando_regla_2.Name = "label2";
            this.label_accion_validando_regla_2.Size = new System.Drawing.Size(68, 13);
            this.label_accion_validando_regla_2.TabIndex = 3;
            this.label_accion_validando_regla_2.Text = "Texto final:";
            // 
            // textBox_inicial_accion_validando_regla
            // 
            this.textBox_inicial_accion_validando_regla.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_accion_validando_regla.Name = "textBox_inicial_accion_validando_regla";
            this.textBox_inicial_accion_validando_regla.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_accion_validando_regla.TabIndex = 4;
            // 
            // textBox_medio_accion_validando_regla
            // 
            this.textBox_medio_accion_validando_regla.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_accion_validando_regla.Name = "textBox_medio_accion_validando_regla";
            this.textBox_medio_accion_validando_regla.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_accion_validando_regla.TabIndex = 5;
            // 
            // label_tipo_accion_validando_regla
            // 
            this.label_tipo_accion_validando_regla.AutoSize = true;
            this.label_tipo_accion_validando_regla.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_accion_validando_regla.Name = "label_tipo_accion_validando_regla";
            this.label_tipo_accion_validando_regla.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_accion_validando_regla.TabIndex = 6;
            this.label_tipo_accion_validando_regla.Text = "LOG_ACCION_VALIDANDO_REGLA";
            // 
            // label_accion_validando_regla_3
            // 
            this.label_accion_validando_regla_3.AutoSize = true;
            this.label_accion_validando_regla_3.Location = new System.Drawing.Point(15, 15);
            this.label_accion_validando_regla_3.Name = "label3";
            this.label_accion_validando_regla_3.Size = new System.Drawing.Size(48, 13);
            this.label_accion_validando_regla_3.TabIndex = 7;
            this.label_accion_validando_regla_3.Text = "Tipo log:";

            //agregando a form
            this.Controls.Add(panel_accion_validando_regla);
        }
        
    }
}
