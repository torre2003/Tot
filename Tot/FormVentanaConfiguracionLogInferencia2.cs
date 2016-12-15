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
            inicializar_textos_listas();
            inicializar_log_variable();
            inicializar_info_var_conocida();
            inicializar_accion_procesando_respuesta();
            inicializar_ingresando_a_var_conocida();
            inicializar_log_hecho();
            inicializar_mover_hecho();
            inicializar_accion_hecho_objetivo_principal();
            inicializar_accion_hecho_objetivo_actual();
            inicializar_accion_quitando_hecho_pila_objetivos();
            inicializar_info_sin_reglas_para_inferir_hecho();
            inicializar_accion_consultando_hechos();
            inicializar_accion_ingresando_hecho_a_pila_de_objetivos();
            inicializar_log_regla();
            inicializar_mover_regla();
            inicializar_accion_elegida_mejor_regla();
            inicializar_accion_validando_regla();
            inicializar_log_info();
            inicializar_info_consultando_hechos();
            inicializar_info_analizando_hechos_inferidos_regla();
            inicializar_info_regla_validada();
            inicializar_info_regla_no_validada();
            inicializar_info_descartando_reglas_de_igual_consecuente();
            inicializar_info_problema_solucionado();
            inicializar_info_problema_no_solucionado();
            inicializar_info_continuando_proceso();
            inicializar_proceso_detenido();
            inicializar_info_termino_inferencia_reglas_agotadas();
            inicializar_info_consultando_variables_inicio();
            inicializar_info_procesando_hechos_asociados();
            //------------------------------------------------------------
            
            
            panel_interno_controles.Size = new System.Drawing.Size(563, ultimo_y);
        }

        private System.Windows.Forms.Panel panel_textos_listas;
        private System.Windows.Forms.Label label_textos_listas_3;

        private System.Windows.Forms.TextBox textBox_texto_reglas_disponibles;
        private System.Windows.Forms.Label label_textos_reglas_disponibles;

        private System.Windows.Forms.TextBox textBox_texto_reglas_candidatas;
        private System.Windows.Forms.Label label_textos_reglas_candidatas;

        private System.Windows.Forms.TextBox textBox_texto_reglas_eliminadas;
        private System.Windows.Forms.Label label_textos_reglas_eliminadas;

        private System.Windows.Forms.TextBox textBox_texto_hechos_disponibles;
        private System.Windows.Forms.Label label_textos_hechos_disponibles;

        private System.Windows.Forms.TextBox textBox_texto_hechos_verdaderos;
        private System.Windows.Forms.Label label_textos_hechos_verdaderos;
        
        private System.Windows.Forms.TextBox textBox_texto_hechos_falsos;
        private System.Windows.Forms.Label label_textos_hechos_falsos;

        void inicializar_textos_listas()
        {
            this.panel_textos_listas = new System.Windows.Forms.Panel();

            this.label_textos_reglas_disponibles = new System.Windows.Forms.Label();
            this.textBox_texto_reglas_disponibles = new System.Windows.Forms.TextBox();

            this.label_textos_reglas_candidatas = new System.Windows.Forms.Label();
            this.textBox_texto_reglas_candidatas = new System.Windows.Forms.TextBox();

            this.label_textos_reglas_eliminadas = new System.Windows.Forms.Label();
            this.textBox_texto_reglas_eliminadas = new System.Windows.Forms.TextBox();

            this.label_textos_hechos_disponibles = new System.Windows.Forms.Label();
            this.textBox_texto_hechos_disponibles = new System.Windows.Forms.TextBox();

            this.label_textos_hechos_verdaderos = new System.Windows.Forms.Label();
            this.textBox_texto_hechos_verdaderos = new System.Windows.Forms.TextBox();

            this.label_textos_hechos_falsos = new System.Windows.Forms.Label();
            this.textBox_texto_hechos_falsos = new System.Windows.Forms.TextBox();

            this.label_textos_listas_3 = new System.Windows.Forms.Label();
            this.panel_textos_listas.SuspendLayout();

            // 
            // panel_textos_listas
            // 
            this.panel_textos_listas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_textos_listas.Controls.Add(this.label_textos_listas_3);

            this.panel_textos_listas.Controls.Add(this.textBox_texto_reglas_disponibles);
            this.panel_textos_listas.Controls.Add(this.label_textos_reglas_disponibles);

            this.panel_textos_listas.Controls.Add(this.textBox_texto_reglas_candidatas);
            this.panel_textos_listas.Controls.Add(this.label_textos_reglas_candidatas);

            this.panel_textos_listas.Controls.Add(this.textBox_texto_reglas_eliminadas);
            this.panel_textos_listas.Controls.Add(this.label_textos_reglas_eliminadas);

            this.panel_textos_listas.Controls.Add(this.textBox_texto_hechos_disponibles);
            this.panel_textos_listas.Controls.Add(this.label_textos_hechos_disponibles);

            this.panel_textos_listas.Controls.Add(this.textBox_texto_hechos_verdaderos);
            this.panel_textos_listas.Controls.Add(this.label_textos_hechos_verdaderos);

            this.panel_textos_listas.Controls.Add(this.textBox_texto_hechos_falsos);
            this.panel_textos_listas.Controls.Add(this.label_textos_hechos_falsos);

            this.panel_textos_listas.Location = new System.Drawing.Point(3, ultimo_y);
            
            this.panel_textos_listas.Name = "panel_textos_listas";
            this.panel_textos_listas.Size = new System.Drawing.Size(550, 85);
            this.panel_textos_listas.TabIndex = 0;
            // 
            // label_textos_listas_3
            // 
            this.label_textos_listas_3.AutoSize = true;
            this.label_textos_listas_3.Location = new System.Drawing.Point(15, 15);
            this.label_textos_listas_3.Name = "label3";
            this.label_textos_listas_3.Size = new System.Drawing.Size(48, 13);
            this.label_textos_listas_3.TabIndex = 7;
            this.label_textos_listas_3.Text = "Configuración de nombre de listas:";

            int y = 40;
            // 
            // reglas disponibles
            // 
            this.label_textos_reglas_disponibles.AutoSize = true;
            this.label_textos_reglas_disponibles.Location = new System.Drawing.Point(12, y+1);
            this.label_textos_reglas_disponibles.Name = "label1";
            this.label_textos_reglas_disponibles.Size = new System.Drawing.Size(66, 13);
            this.label_textos_reglas_disponibles.TabIndex = 2;
            this.label_textos_reglas_disponibles.Text = "Reglas disponibles:";
            

            this.textBox_texto_reglas_disponibles.Location = new System.Drawing.Point(120, y-2);
            this.textBox_texto_reglas_disponibles.Name = "textBox_inicial_textos_listas";
            this.textBox_texto_reglas_disponibles.Size = new System.Drawing.Size(400, 20);
            this.textBox_texto_reglas_disponibles.TabIndex = 4;
            y += 25;
            // 
            // reglas candidatas
            // 
            this.label_textos_reglas_candidatas.AutoSize = true;
            this.label_textos_reglas_candidatas.Location = new System.Drawing.Point(12, y + 1);
            this.label_textos_reglas_candidatas.Name = "label1";
            this.label_textos_reglas_candidatas.Size = new System.Drawing.Size(66, 13);
            this.label_textos_reglas_candidatas.TabIndex = 2;
            this.label_textos_reglas_candidatas.Text = "Reglas candidatas:";


            this.textBox_texto_reglas_candidatas.Location = new System.Drawing.Point(120, y - 2);
            this.textBox_texto_reglas_candidatas.Name = "textBox_inicial_textos_listas";
            this.textBox_texto_reglas_candidatas.Size = new System.Drawing.Size(400, 20);
            this.textBox_texto_reglas_candidatas.TabIndex = 4;

            y += 25;
            // 
            // reglas eliminadas
            // 
            this.label_textos_reglas_eliminadas.AutoSize = true;
            this.label_textos_reglas_eliminadas.Location = new System.Drawing.Point(12, y + 1);
            this.label_textos_reglas_eliminadas.Name = "label1";
            this.label_textos_reglas_eliminadas.Size = new System.Drawing.Size(66, 13);
            this.label_textos_reglas_eliminadas.TabIndex = 2;
            this.label_textos_reglas_eliminadas.Text = "Reglas eliminadas:";


            this.textBox_texto_reglas_eliminadas.Location = new System.Drawing.Point(120, y - 2);
            this.textBox_texto_reglas_eliminadas.Name = "textBox_inicial_textos_listas";
            this.textBox_texto_reglas_eliminadas.Size = new System.Drawing.Size(400, 20);
            this.textBox_texto_reglas_eliminadas.TabIndex = 4;

            y += 25;

            // 
            // hechos disponibles
            // 
            this.label_textos_hechos_disponibles.AutoSize = true;
            this.label_textos_hechos_disponibles.Location = new System.Drawing.Point(12, y + 1);
            this.label_textos_hechos_disponibles.Name = "label1";
            this.label_textos_hechos_disponibles.Size = new System.Drawing.Size(66, 13);
            this.label_textos_hechos_disponibles.TabIndex = 2;
            this.label_textos_hechos_disponibles.Text = "Hechos disponibles:";


            this.textBox_texto_hechos_disponibles.Location = new System.Drawing.Point(120, y - 2);
            this.textBox_texto_hechos_disponibles.Name = "textBox_inicial_textos_listas";
            this.textBox_texto_hechos_disponibles.Size = new System.Drawing.Size(400, 20);
            this.textBox_texto_hechos_disponibles.TabIndex = 4;

            y += 25;
            
            // 
            // hechos verdaderos
            // 
            this.label_textos_hechos_verdaderos.AutoSize = true;
            this.label_textos_hechos_verdaderos.Location = new System.Drawing.Point(12, y + 1);
            this.label_textos_hechos_verdaderos.Name = "label1";
            this.label_textos_hechos_verdaderos.Size = new System.Drawing.Size(66, 13);
            this.label_textos_hechos_verdaderos.TabIndex = 2;
            this.label_textos_hechos_verdaderos.Text = "Hechos verdaderos:";


            this.textBox_texto_hechos_verdaderos.Location = new System.Drawing.Point(120, y - 2);
            this.textBox_texto_hechos_verdaderos.Name = "textBox_inicial_textos_listas";
            this.textBox_texto_hechos_verdaderos.Size = new System.Drawing.Size(400, 20);
            this.textBox_texto_hechos_verdaderos.TabIndex = 4;

            y += 25;
            
            // 
            // hechos falsos
            // 
            this.label_textos_hechos_falsos.AutoSize = true;
            this.label_textos_hechos_falsos.Location = new System.Drawing.Point(12, y + 1);
            this.label_textos_hechos_falsos.Name = "label1";
            this.label_textos_hechos_falsos.Size = new System.Drawing.Size(66, 13);
            this.label_textos_hechos_falsos.TabIndex = 2;
            this.label_textos_hechos_falsos.Text = "Hechos falsos:";


            this.textBox_texto_hechos_falsos.Location = new System.Drawing.Point(120, y - 2);
            this.textBox_texto_hechos_falsos.Name = "textBox_inicial_textos_listas";
            this.textBox_texto_hechos_falsos.Size = new System.Drawing.Size(400, 20);
            this.textBox_texto_hechos_falsos.TabIndex = 4;

            y += 25;

            this.panel_textos_listas.Size = new System.Drawing.Size(550, y);
            ultimo_y += y + 10;
            //agregando a form
            this.panel_interno_controles.Controls.Add(panel_textos_listas);
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
            this.panel_log_variable.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_log_variable);
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
            this.panel_info_var_conocida.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_info_var_conocida);

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
            this.panel_accion_procesando_respuesta.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_accion_procesando_respuesta);
        }


        private System.Windows.Forms.Panel panel_ingresando_a_var_conocida;
        private System.Windows.Forms.Label label_ingresando_a_var_conocida_3;
        private System.Windows.Forms.Label label_tipo_ingresando_a_var_conocida;
        private System.Windows.Forms.TextBox textBox_medio_ingresando_a_var_conocida;
        private System.Windows.Forms.TextBox textBox_inicial_ingresando_a_var_conocida;
        private System.Windows.Forms.Label label_ingresando_a_var_conocida_2;
        private System.Windows.Forms.Label label_ingresando_a_var_conocida_1;
        private System.Windows.Forms.Label label_formato_ingresando_a_var_conocida;
        private System.Windows.Forms.CheckBox checkBox_accion_ingresando_a_var_conocida;

        void inicializar_ingresando_a_var_conocida()
        {
            this.panel_ingresando_a_var_conocida = new System.Windows.Forms.Panel();
            this.checkBox_accion_ingresando_a_var_conocida = new System.Windows.Forms.CheckBox();
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
            this.panel_ingresando_a_var_conocida.Controls.Add(this.checkBox_accion_ingresando_a_var_conocida);
            this.panel_ingresando_a_var_conocida.Location = new System.Drawing.Point(3, ultimo_y);
            ultimo_y += 120;
            this.panel_ingresando_a_var_conocida.Name = "panel_ingresando_a_var_conocida";
            this.panel_ingresando_a_var_conocida.Size = new System.Drawing.Size(550, 110);
            this.panel_ingresando_a_var_conocida.TabIndex = 0;
            // 
            // checkBox_ingresando_a_var_conocida
            // 
            this.checkBox_accion_ingresando_a_var_conocida.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_ingresando_a_var_conocida.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_ingresando_a_var_conocida.Name = "checkBox_ingresando_a_var_conocida";
            this.checkBox_accion_ingresando_a_var_conocida.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_ingresando_a_var_conocida.TabIndex = 0;
            this.checkBox_accion_ingresando_a_var_conocida.Text = "Mostrar";
            this.checkBox_accion_ingresando_a_var_conocida.UseVisualStyleBackColor = true;
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
            this.panel_interno_controles.Controls.Add(panel_ingresando_a_var_conocida);
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
            this.panel_log_hecho.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_log_hecho);
        }

                    private System.Windows.Forms.Panel panel_mover_hecho;
            private System.Windows.Forms.Label label_mover_hecho_3;
            private System.Windows.Forms.Label label_tipo_mover_hecho;
            private System.Windows.Forms.TextBox textBox_medio_mover_hecho;
            private System.Windows.Forms.TextBox textBox_inicial_mover_hecho;
            private System.Windows.Forms.Label label_mover_hecho_2;
            private System.Windows.Forms.Label label_mover_hecho_1;
            private System.Windows.Forms.Label label_formato_mover_hecho;
            private System.Windows.Forms.CheckBox checkBox_accion_mover_hecho;
            private System.Windows.Forms.TextBox textBox_final_mover_hecho;
            private System.Windows.Forms.Label label_mover_hecho_4;
         
            void inicializar_mover_hecho()
            {
            this.panel_mover_hecho = new System.Windows.Forms.Panel();
            this.checkBox_accion_mover_hecho = new System.Windows.Forms.CheckBox();
            this.label_formato_mover_hecho = new System.Windows.Forms.Label();
            this.label_mover_hecho_1 = new System.Windows.Forms.Label();
            this.label_mover_hecho_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_mover_hecho = new System.Windows.Forms.TextBox();
            this.textBox_medio_mover_hecho = new System.Windows.Forms.TextBox();
            this.label_tipo_mover_hecho = new System.Windows.Forms.Label();
            this.label_mover_hecho_3 = new System.Windows.Forms.Label();
            this.textBox_final_mover_hecho = new System.Windows.Forms.TextBox();
            this.label_mover_hecho_4 = new System.Windows.Forms.Label();
            this.panel_mover_hecho.SuspendLayout();
            
            // 
            // panel_mover_hecho
            // 
            this.panel_mover_hecho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_mover_hecho.Controls.Add(this.textBox_final_mover_hecho);
            this.panel_mover_hecho.Controls.Add(this.label_mover_hecho_4);
            this.panel_mover_hecho.Controls.Add(this.label_mover_hecho_3);
            this.panel_mover_hecho.Controls.Add(this.label_tipo_mover_hecho);
            this.panel_mover_hecho.Controls.Add(this.textBox_medio_mover_hecho);
            this.panel_mover_hecho.Controls.Add(this.textBox_inicial_mover_hecho);
            this.panel_mover_hecho.Controls.Add(this.label_mover_hecho_2);
            this.panel_mover_hecho.Controls.Add(this.label_mover_hecho_1);
            this.panel_mover_hecho.Controls.Add(this.label_formato_mover_hecho);
            this.panel_mover_hecho.Controls.Add(this.checkBox_accion_mover_hecho);
            this.panel_mover_hecho.Location = new System.Drawing.Point(3, ultimo_y);
            ultimo_y += 150;
            this.panel_mover_hecho.Name = "panel_mover_hecho";
            this.panel_mover_hecho.Size = new System.Drawing.Size(550, 140);
            this.panel_mover_hecho.TabIndex = 0;
            // 
            // checkBox_mover_hecho
            // 
            this.checkBox_accion_mover_hecho.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_mover_hecho.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_mover_hecho.Name = "checkBox_mover_hecho";
            this.checkBox_accion_mover_hecho.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_mover_hecho.TabIndex = 0;
            this.checkBox_accion_mover_hecho.Text = "Mostrar";
            this.checkBox_accion_mover_hecho.UseVisualStyleBackColor = true;
            // 
            // label_formato_mover_hecho
            // 
            this.label_formato_mover_hecho.Location = new System.Drawing.Point(102, 32);
            this.label_formato_mover_hecho.Name = "label_formato_mover_hecho";
            this.label_formato_mover_hecho.Size = new System.Drawing.Size(395, 23);
            this.label_formato_mover_hecho.TabIndex = 1;
            this.label_formato_mover_hecho.Text = "texto_incial HECHO texto_medio LISTA_DESDE texto_final HACIA";
            this.label_formato_mover_hecho.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_mover_hecho_1
            // 
            this.label_mover_hecho_1.AutoSize = true;
            this.label_mover_hecho_1.Location = new System.Drawing.Point(12, 61);
            this.label_mover_hecho_1.Name = "label1";
            this.label_mover_hecho_1.Size = new System.Drawing.Size(66, 13);
            this.label_mover_hecho_1.TabIndex = 2;
            this.label_mover_hecho_1.Text = "Texto inicial:";
            // 
            // label_mover_hecho_2
            // 
            this.label_mover_hecho_2.AutoSize = true;
            this.label_mover_hecho_2.Location = new System.Drawing.Point(12, 87);
            this.label_mover_hecho_2.Name = "label2";
            this.label_mover_hecho_2.Size = new System.Drawing.Size(68, 13);
            this.label_mover_hecho_2.TabIndex = 3;
            this.label_mover_hecho_2.Text = "Texto medio:";
            // 
            // textBox_inicial_mover_hecho
            // 
            this.textBox_inicial_mover_hecho.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_mover_hecho.Name = "textBox_inicial_mover_hecho";
            this.textBox_inicial_mover_hecho.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_mover_hecho.TabIndex = 4;
            // 
            // textBox_medio_mover_hecho
            // 
            this.textBox_medio_mover_hecho.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_mover_hecho.Name = "textBox_medio_mover_hecho";
            this.textBox_medio_mover_hecho.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_mover_hecho.TabIndex = 5;
            // 
            // label_tipo_mover_hecho
            // 
            this.label_tipo_mover_hecho.AutoSize = true;
            this.label_tipo_mover_hecho.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_mover_hecho.Name = "label_tipo_mover_hecho";
            this.label_tipo_mover_hecho.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_mover_hecho.TabIndex = 6;
            this.label_tipo_mover_hecho.Text = "LOG_ACCION_MOVER_HECHO";
            // 
            // label_mover_hecho_3
            // 
            this.label_mover_hecho_3.AutoSize = true;
            this.label_mover_hecho_3.Location = new System.Drawing.Point(15, 15);
            this.label_mover_hecho_3.Name = "label3";
            this.label_mover_hecho_3.Size = new System.Drawing.Size(48, 13);
            this.label_mover_hecho_3.TabIndex = 7;
            this.label_mover_hecho_3.Text = "Tipo log:";
            // 
            // textBox_final_mover_hecho
            // 
            this.textBox_final_mover_hecho.Location = new System.Drawing.Point(84, 110);
            this.textBox_final_mover_hecho.Name = "textBox_final_mover_hecho";
            this.textBox_final_mover_hecho.Size = new System.Drawing.Size(413, 20);
            this.textBox_final_mover_hecho.TabIndex = 9;
            // 
            // label_mover_hecho_4
            // 
            this.label_mover_hecho_4.AutoSize = true;
            this.label_mover_hecho_4.Location = new System.Drawing.Point(12, 113);
            this.label_mover_hecho_4.Name = "label4";
            this.label_mover_hecho_4.Size = new System.Drawing.Size(59, 13);
            this.label_mover_hecho_4.TabIndex = 8;
            this.label_mover_hecho_4.Text = "Texto final:";
            //agregando a form
            this.panel_interno_controles.Controls.Add(panel_mover_hecho);
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
            this.panel_accion_hecho_objetivo_principal.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_accion_hecho_objetivo_principal);
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
        private System.Windows.Forms.CheckBox checkBox_nivel_hecho;

        void inicializar_accion_hecho_objetivo_actual()
        {
            this.panel_accion_hecho_objetivo_actual = new System.Windows.Forms.Panel();
            this.checkBox_accion_hecho_objetivo_actual = new System.Windows.Forms.CheckBox();
            this.checkBox_nivel_hecho = new System.Windows.Forms.CheckBox();
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
            this.panel_accion_hecho_objetivo_actual.Controls.Add(this.checkBox_nivel_hecho);
            this.panel_accion_hecho_objetivo_actual.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.checkBox_nivel_hecho.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_nivel_hecho.Location = new System.Drawing.Point(15, 61);
            this.checkBox_nivel_hecho.Name = "checkBox_accion_hecho_objetivo_actual";
            this.checkBox_nivel_hecho.Size = new System.Drawing.Size(160, 24);
            this.checkBox_nivel_hecho.TabIndex = 0;
            this.checkBox_nivel_hecho.Text = "Mostrar tabulación por nivel";
            this.checkBox_nivel_hecho.UseVisualStyleBackColor = true;
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
            this.panel_interno_controles.Controls.Add(panel_accion_hecho_objetivo_actual);
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
            this.panel_accion_quitando_hecho_pila_objetivos.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_accion_quitando_hecho_pila_objetivos);
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
            this.panel_info_sin_reglas_para_inferir_hecho.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_info_sin_reglas_para_inferir_hecho);
        }


        private System.Windows.Forms.Panel panel_accion_consultando_hechos;
        private System.Windows.Forms.Label label_accion_consultando_hechos_3;
        private System.Windows.Forms.Label label_tipo_accion_consultando_hechos;
        private System.Windows.Forms.TextBox textBox_medio_accion_consultando_hechos;
        private System.Windows.Forms.TextBox textBox_inicial_accion_consultando_hechos;
        private System.Windows.Forms.Label label_accion_consultando_hechos_2;
        private System.Windows.Forms.Label label_accion_consultando_hechos_1;
        private System.Windows.Forms.Label label_formato_accion_consultando_hechos;
        private System.Windows.Forms.CheckBox checkBox_accion_consultando_hecho;

        void inicializar_accion_consultando_hechos()
        {
            this.panel_accion_consultando_hechos = new System.Windows.Forms.Panel();
            this.checkBox_accion_consultando_hecho = new System.Windows.Forms.CheckBox();
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
            this.panel_accion_consultando_hechos.Controls.Add(this.checkBox_accion_consultando_hecho);
            this.panel_accion_consultando_hechos.Location = new System.Drawing.Point(3, ultimo_y);
            ultimo_y += 120;
            this.panel_accion_consultando_hechos.Name = "panel_accion_consultando_hechos";
            this.panel_accion_consultando_hechos.Size = new System.Drawing.Size(550, 110);
            this.panel_accion_consultando_hechos.TabIndex = 0;
            // 
            // checkBox_accion_consultando_hechos
            // 
            this.checkBox_accion_consultando_hecho.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_consultando_hecho.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_consultando_hecho.Name = "checkBox_accion_consultando_hechos";
            this.checkBox_accion_consultando_hecho.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_consultando_hecho.TabIndex = 0;
            this.checkBox_accion_consultando_hecho.Text = "Mostrar";
            this.checkBox_accion_consultando_hecho.UseVisualStyleBackColor = true;
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
            this.panel_interno_controles.Controls.Add(panel_accion_consultando_hechos);
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
            this.panel_accion_ingresando_hecho_a_pila_de_objetivos.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_accion_ingresando_hecho_a_pila_de_objetivos);
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
            this.panel_log_regla.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_log_regla);
        }

                    private System.Windows.Forms.Panel panel_mover_regla;
            private System.Windows.Forms.Label label_mover_regla_3;
            private System.Windows.Forms.Label label_tipo_mover_regla;
            private System.Windows.Forms.TextBox textBox_medio_mover_regla;
            private System.Windows.Forms.TextBox textBox_inicial_mover_regla;
            private System.Windows.Forms.Label label_mover_regla_2;
            private System.Windows.Forms.Label label_mover_regla_1;
            private System.Windows.Forms.Label label_formato_mover_regla;
            private System.Windows.Forms.CheckBox checkBox_accion_mover_regla;
            private System.Windows.Forms.TextBox textBox_final_mover_regla;
            private System.Windows.Forms.Label label_mover_regla_4;
         
            void inicializar_mover_regla()
            {
            this.panel_mover_regla = new System.Windows.Forms.Panel();
            this.checkBox_accion_mover_regla = new System.Windows.Forms.CheckBox();
            this.label_formato_mover_regla = new System.Windows.Forms.Label();
            this.label_mover_regla_1 = new System.Windows.Forms.Label();
            this.label_mover_regla_2 = new System.Windows.Forms.Label();
            this.textBox_inicial_mover_regla = new System.Windows.Forms.TextBox();
            this.textBox_medio_mover_regla = new System.Windows.Forms.TextBox();
            this.label_tipo_mover_regla = new System.Windows.Forms.Label();
            this.label_mover_regla_3 = new System.Windows.Forms.Label();
            this.textBox_final_mover_regla = new System.Windows.Forms.TextBox();
            this.label_mover_regla_4 = new System.Windows.Forms.Label();
            this.panel_mover_regla.SuspendLayout();
            
            // 
            // panel_mover_regla
            // 
            this.panel_mover_regla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_mover_regla.Controls.Add(this.textBox_final_mover_regla);
            this.panel_mover_regla.Controls.Add(this.label_mover_regla_4);
            this.panel_mover_regla.Controls.Add(this.label_mover_regla_3);
            this.panel_mover_regla.Controls.Add(this.label_tipo_mover_regla);
            this.panel_mover_regla.Controls.Add(this.textBox_medio_mover_regla);
            this.panel_mover_regla.Controls.Add(this.textBox_inicial_mover_regla);
            this.panel_mover_regla.Controls.Add(this.label_mover_regla_2);
            this.panel_mover_regla.Controls.Add(this.label_mover_regla_1);
            this.panel_mover_regla.Controls.Add(this.label_formato_mover_regla);
            this.panel_mover_regla.Controls.Add(this.checkBox_accion_mover_regla);
            this.panel_mover_regla.Location = new System.Drawing.Point(3, ultimo_y);
            ultimo_y += 150;
            this.panel_mover_regla.Name = "panel_mover_regla";
            this.panel_mover_regla.Size = new System.Drawing.Size(550, 140);
            this.panel_mover_regla.TabIndex = 0;
            // 
            // checkBox_mover_regla
            // 
            this.checkBox_accion_mover_regla.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_accion_mover_regla.Location = new System.Drawing.Point(15, 34);
            this.checkBox_accion_mover_regla.Name = "checkBox_mover_regla";
            this.checkBox_accion_mover_regla.Size = new System.Drawing.Size(81, 24);
            this.checkBox_accion_mover_regla.TabIndex = 0;
            this.checkBox_accion_mover_regla.Text = "Mostrar";
            this.checkBox_accion_mover_regla.UseVisualStyleBackColor = true;
            // 
            // label_formato_mover_regla
            // 
            this.label_formato_mover_regla.Location = new System.Drawing.Point(102, 32);
            this.label_formato_mover_regla.Name = "label_formato_mover_regla";
            this.label_formato_mover_regla.Size = new System.Drawing.Size(395, 23);
            this.label_formato_mover_regla.TabIndex = 1;
            this.label_formato_mover_regla.Text = "texto_inicial REGLA texto_medio LISTA_DESDE texto_final LISTA_HACIA";
            this.label_formato_mover_regla.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_mover_regla_1
            // 
            this.label_mover_regla_1.AutoSize = true;
            this.label_mover_regla_1.Location = new System.Drawing.Point(12, 61);
            this.label_mover_regla_1.Name = "label1";
            this.label_mover_regla_1.Size = new System.Drawing.Size(66, 13);
            this.label_mover_regla_1.TabIndex = 2;
            this.label_mover_regla_1.Text = "Texto inicial:";
            // 
            // label_mover_regla_2
            // 
            this.label_mover_regla_2.AutoSize = true;
            this.label_mover_regla_2.Location = new System.Drawing.Point(12, 87);
            this.label_mover_regla_2.Name = "label2";
            this.label_mover_regla_2.Size = new System.Drawing.Size(68, 13);
            this.label_mover_regla_2.TabIndex = 3;
            this.label_mover_regla_2.Text = "Texto medio:";
            // 
            // textBox_inicial_mover_regla
            // 
            this.textBox_inicial_mover_regla.Location = new System.Drawing.Point(84, 58);
            this.textBox_inicial_mover_regla.Name = "textBox_inicial_mover_regla";
            this.textBox_inicial_mover_regla.Size = new System.Drawing.Size(413, 20);
            this.textBox_inicial_mover_regla.TabIndex = 4;
            // 
            // textBox_medio_mover_regla
            // 
            this.textBox_medio_mover_regla.Location = new System.Drawing.Point(84, 84);
            this.textBox_medio_mover_regla.Name = "textBox_medio_mover_regla";
            this.textBox_medio_mover_regla.Size = new System.Drawing.Size(413, 20);
            this.textBox_medio_mover_regla.TabIndex = 5;
            // 
            // label_tipo_mover_regla
            // 
            this.label_tipo_mover_regla.AutoSize = true;
            this.label_tipo_mover_regla.Location = new System.Drawing.Point(81, 15);
            this.label_tipo_mover_regla.Name = "label_tipo_mover_regla";
            this.label_tipo_mover_regla.Size = new System.Drawing.Size(60, 13);
            this.label_tipo_mover_regla.TabIndex = 6;
            this.label_tipo_mover_regla.Text = "LOG_ACCION_MOVER_REGLA";
            // 
            // label_mover_regla_3
            // 
            this.label_mover_regla_3.AutoSize = true;
            this.label_mover_regla_3.Location = new System.Drawing.Point(15, 15);
            this.label_mover_regla_3.Name = "label3";
            this.label_mover_regla_3.Size = new System.Drawing.Size(48, 13);
            this.label_mover_regla_3.TabIndex = 7;
            this.label_mover_regla_3.Text = "Tipo log:";
            // 
            // textBox_final_mover_regla
            // 
            this.textBox_final_mover_regla.Location = new System.Drawing.Point(84, 110);
            this.textBox_final_mover_regla.Name = "textBox_final_mover_regla";
            this.textBox_final_mover_regla.Size = new System.Drawing.Size(413, 20);
            this.textBox_final_mover_regla.TabIndex = 9;
            // 
            // label_mover_regla_4
            // 
            this.label_mover_regla_4.AutoSize = true;
            this.label_mover_regla_4.Location = new System.Drawing.Point(12, 113);
            this.label_mover_regla_4.Name = "label4";
            this.label_mover_regla_4.Size = new System.Drawing.Size(59, 13);
            this.label_mover_regla_4.TabIndex = 8;
            this.label_mover_regla_4.Text = "Texto final:";

            //agregando a form
            this.panel_interno_controles.Controls.Add(panel_mover_regla);
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
            this.panel_accion_elegida_mejor_regla.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_accion_elegida_mejor_regla);
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
            this.panel_accion_validando_regla.Location = new System.Drawing.Point(3, ultimo_y);
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
            this.panel_interno_controles.Controls.Add(panel_accion_validando_regla);
        }
        



            private System.Windows.Forms.Panel panel_log_info;
            private System.Windows.Forms.Label label_log_info_3;
            private System.Windows.Forms.Label label_tipo_log_info;
            private System.Windows.Forms.CheckBox checkBox_log_info;

            void inicializar_log_info()
            {
                this.panel_log_info = new System.Windows.Forms.Panel();
                this.checkBox_log_info = new System.Windows.Forms.CheckBox();
                this.label_tipo_log_info = new System.Windows.Forms.Label();
                this.label_log_info_3 = new System.Windows.Forms.Label();
                this.panel_log_info.SuspendLayout();
                // 
                // panel_log_info
                // 
                this.panel_log_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_log_info.Controls.Add(this.label_log_info_3);
                this.panel_log_info.Controls.Add(this.label_tipo_log_info);
                this.panel_log_info.Controls.Add(this.checkBox_log_info);
                this.panel_log_info.Location = new System.Drawing.Point(3, ultimo_y);
                this.panel_log_info.Name = "panel_log_info";
                this.panel_log_info.Size = new System.Drawing.Size(550, 60);
                ultimo_y += 70;
                this.panel_log_info.TabIndex = 0;
                // 
                // checkBox_log_info
                // 
                this.checkBox_log_info.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_log_info.Location = new System.Drawing.Point(15, 34);
                this.checkBox_log_info.Name = "checkBox_log_info";
                this.checkBox_log_info.Size = new System.Drawing.Size(81, 24);
                this.checkBox_log_info.TabIndex = 0;
                this.checkBox_log_info.Text = "Mostrar";
                this.checkBox_log_info.UseVisualStyleBackColor = true;
                // 
                // label_tipo_log_info
                // 
                this.label_tipo_log_info.AutoSize = true;
                this.label_tipo_log_info.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_log_info.Name = "label_tipo_log_info";
                this.label_tipo_log_info.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_log_info.TabIndex = 6;
                this.label_tipo_log_info.Text = "LOG_INFO";
                // 
                // label_log_info_3
                // 
                this.label_log_info_3.AutoSize = true;
                this.label_log_info_3.Location = new System.Drawing.Point(15, 15);
                this.label_log_info_3.Name = "label3";
                this.label_log_info_3.Size = new System.Drawing.Size(48, 13);
                this.label_log_info_3.TabIndex = 7;
                this.label_log_info_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_log_info);
            }


            private System.Windows.Forms.Panel panel_info_consultando_hechos;
            private System.Windows.Forms.Label label_info_consultando_hechos_3;
            private System.Windows.Forms.Label label_tipo_info_consultando_hechos;
            private System.Windows.Forms.TextBox textBox_info_consultando_hechos;
            private System.Windows.Forms.Label label_info_consultando_hechos_1;
            private System.Windows.Forms.CheckBox checkBox_info_consultando_hechos;

            void inicializar_info_consultando_hechos()
            {
                this.panel_info_consultando_hechos = new System.Windows.Forms.Panel();
                this.checkBox_info_consultando_hechos = new System.Windows.Forms.CheckBox();
                this.label_info_consultando_hechos_1 = new System.Windows.Forms.Label();
                this.textBox_info_consultando_hechos = new System.Windows.Forms.TextBox();
                this.label_tipo_info_consultando_hechos = new System.Windows.Forms.Label();
                this.label_info_consultando_hechos_3 = new System.Windows.Forms.Label();
                this.panel_info_consultando_hechos.SuspendLayout();

                // 
                // panel_info_consultando_hechos
                // 
                this.panel_info_consultando_hechos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_consultando_hechos.Controls.Add(this.label_info_consultando_hechos_3);
                this.panel_info_consultando_hechos.Controls.Add(this.label_tipo_info_consultando_hechos);
                this.panel_info_consultando_hechos.Controls.Add(this.textBox_info_consultando_hechos);
                this.panel_info_consultando_hechos.Controls.Add(this.label_info_consultando_hechos_1);
                this.panel_info_consultando_hechos.Controls.Add(this.checkBox_info_consultando_hechos);
                this.panel_info_consultando_hechos.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_consultando_hechos.Name = "panel_info_consultando_hechos";
                this.panel_info_consultando_hechos.Size = new System.Drawing.Size(550, 85);
                this.panel_info_consultando_hechos.TabIndex = 0;
                // 
                // checkBox_info_consultando_hechos
                // 
                this.checkBox_info_consultando_hechos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_consultando_hechos.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_consultando_hechos.Name = "checkBox_info_consultando_hechos";
                this.checkBox_info_consultando_hechos.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_consultando_hechos.TabIndex = 0;
                this.checkBox_info_consultando_hechos.Text = "Mostrar";
                this.checkBox_info_consultando_hechos.UseVisualStyleBackColor = true;
                // 
                // label_info_consultando_hechos_1
                // 
                this.label_info_consultando_hechos_1.AutoSize = true;
                this.label_info_consultando_hechos_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_consultando_hechos_1.Name = "label1";
                this.label_info_consultando_hechos_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_consultando_hechos_1.TabIndex = 2;
                this.label_info_consultando_hechos_1.Text = "Texto :";
                // 
                // textBox_inicial_info_consultando_hechos
                // 
                this.textBox_info_consultando_hechos.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_consultando_hechos.Name = "textBox_inicial_info_consultando_hechos";
                this.textBox_info_consultando_hechos.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_consultando_hechos.TabIndex = 4;
                // 
                // label_tipo_info_consultando_hechos
                // 
                this.label_tipo_info_consultando_hechos.AutoSize = true;
                this.label_tipo_info_consultando_hechos.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_consultando_hechos.Name = "label_tipo_info_consultando_hechos";
                this.label_tipo_info_consultando_hechos.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_consultando_hechos.TabIndex = 6;
                this.label_tipo_info_consultando_hechos.Text = "LOG_INFO_CONSULTANDO_HECHOS";
                // 
                // label_info_consultando_hechos_3
                // 
                this.label_info_consultando_hechos_3.AutoSize = true;
                this.label_info_consultando_hechos_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_consultando_hechos_3.Name = "label3";
                this.label_info_consultando_hechos_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_consultando_hechos_3.TabIndex = 7;
                this.label_info_consultando_hechos_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_consultando_hechos);
            }


            private System.Windows.Forms.Panel panel_info_analizando_hechos_inferidos_regla;
            private System.Windows.Forms.Label label_info_analizando_hechos_inferidos_regla_3;
            private System.Windows.Forms.Label label_tipo_info_analizando_hechos_inferidos_regla;
            private System.Windows.Forms.TextBox textBox_info_analizando_hechos_inferidos_regla;
            private System.Windows.Forms.Label label_info_analizando_hechos_inferidos_regla_1;
            private System.Windows.Forms.CheckBox checkBox_info_analizando_hechos_inferidos_regla;

            void inicializar_info_analizando_hechos_inferidos_regla()
            {
                this.panel_info_analizando_hechos_inferidos_regla = new System.Windows.Forms.Panel();
                this.checkBox_info_analizando_hechos_inferidos_regla = new System.Windows.Forms.CheckBox();
                this.label_info_analizando_hechos_inferidos_regla_1 = new System.Windows.Forms.Label();
                this.textBox_info_analizando_hechos_inferidos_regla = new System.Windows.Forms.TextBox();
                this.label_tipo_info_analizando_hechos_inferidos_regla = new System.Windows.Forms.Label();
                this.label_info_analizando_hechos_inferidos_regla_3 = new System.Windows.Forms.Label();
                this.panel_info_analizando_hechos_inferidos_regla.SuspendLayout();

                // 
                // panel_info_analizando_hechos_inferidos_regla
                // 
                this.panel_info_analizando_hechos_inferidos_regla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_analizando_hechos_inferidos_regla.Controls.Add(this.label_info_analizando_hechos_inferidos_regla_3);
                this.panel_info_analizando_hechos_inferidos_regla.Controls.Add(this.label_tipo_info_analizando_hechos_inferidos_regla);
                this.panel_info_analizando_hechos_inferidos_regla.Controls.Add(this.textBox_info_analizando_hechos_inferidos_regla);
                this.panel_info_analizando_hechos_inferidos_regla.Controls.Add(this.label_info_analizando_hechos_inferidos_regla_1);
                this.panel_info_analizando_hechos_inferidos_regla.Controls.Add(this.checkBox_info_analizando_hechos_inferidos_regla);
                this.panel_info_analizando_hechos_inferidos_regla.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_analizando_hechos_inferidos_regla.Name = "panel_info_analizando_hechos_inferidos_regla";
                this.panel_info_analizando_hechos_inferidos_regla.Size = new System.Drawing.Size(550, 85);
                this.panel_info_analizando_hechos_inferidos_regla.TabIndex = 0;
                // 
                // checkBox_info_analizando_hechos_inferidos_regla
                // 
                this.checkBox_info_analizando_hechos_inferidos_regla.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_analizando_hechos_inferidos_regla.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_analizando_hechos_inferidos_regla.Name = "checkBox_info_analizando_hechos_inferidos_regla";
                this.checkBox_info_analizando_hechos_inferidos_regla.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_analizando_hechos_inferidos_regla.TabIndex = 0;
                this.checkBox_info_analizando_hechos_inferidos_regla.Text = "Mostrar";
                this.checkBox_info_analizando_hechos_inferidos_regla.UseVisualStyleBackColor = true;
                // 
                // label_info_analizando_hechos_inferidos_regla_1
                // 
                this.label_info_analizando_hechos_inferidos_regla_1.AutoSize = true;
                this.label_info_analizando_hechos_inferidos_regla_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_analizando_hechos_inferidos_regla_1.Name = "label1";
                this.label_info_analizando_hechos_inferidos_regla_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_analizando_hechos_inferidos_regla_1.TabIndex = 2;
                this.label_info_analizando_hechos_inferidos_regla_1.Text = "Texto :";
                // 
                // textBox_inicial_info_analizando_hechos_inferidos_regla
                // 
                this.textBox_info_analizando_hechos_inferidos_regla.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_analizando_hechos_inferidos_regla.Name = "textBox_inicial_info_analizando_hechos_inferidos_regla";
                this.textBox_info_analizando_hechos_inferidos_regla.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_analizando_hechos_inferidos_regla.TabIndex = 4;
                // 
                // label_tipo_info_analizando_hechos_inferidos_regla
                // 
                this.label_tipo_info_analizando_hechos_inferidos_regla.AutoSize = true;
                this.label_tipo_info_analizando_hechos_inferidos_regla.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_analizando_hechos_inferidos_regla.Name = "label_tipo_info_analizando_hechos_inferidos_regla";
                this.label_tipo_info_analizando_hechos_inferidos_regla.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_analizando_hechos_inferidos_regla.TabIndex = 6;
                this.label_tipo_info_analizando_hechos_inferidos_regla.Text = "LOG_INFO_ANALIZANDO_HECHOS_INFERIDOS_REGLA";
                // 
                // label_info_analizando_hechos_inferidos_regla_3
                // 
                this.label_info_analizando_hechos_inferidos_regla_3.AutoSize = true;
                this.label_info_analizando_hechos_inferidos_regla_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_analizando_hechos_inferidos_regla_3.Name = "label3";
                this.label_info_analizando_hechos_inferidos_regla_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_analizando_hechos_inferidos_regla_3.TabIndex = 7;
                this.label_info_analizando_hechos_inferidos_regla_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_analizando_hechos_inferidos_regla);
            }


            private System.Windows.Forms.Panel panel_info_regla_validada;
            private System.Windows.Forms.Label label_info_regla_validada_3;
            private System.Windows.Forms.Label label_tipo_info_regla_validada;
            private System.Windows.Forms.TextBox textBox_info_regla_validada;
            private System.Windows.Forms.Label label_info_regla_validada_1;
            private System.Windows.Forms.CheckBox checkBox_info_regla_validada;

            void inicializar_info_regla_validada()
            {
                this.panel_info_regla_validada = new System.Windows.Forms.Panel();
                this.checkBox_info_regla_validada = new System.Windows.Forms.CheckBox();
                this.label_info_regla_validada_1 = new System.Windows.Forms.Label();
                this.textBox_info_regla_validada = new System.Windows.Forms.TextBox();
                this.label_tipo_info_regla_validada = new System.Windows.Forms.Label();
                this.label_info_regla_validada_3 = new System.Windows.Forms.Label();
                this.panel_info_regla_validada.SuspendLayout();

                // 
                // panel_info_regla_validada
                // 
                this.panel_info_regla_validada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_regla_validada.Controls.Add(this.label_info_regla_validada_3);
                this.panel_info_regla_validada.Controls.Add(this.label_tipo_info_regla_validada);
                this.panel_info_regla_validada.Controls.Add(this.textBox_info_regla_validada);
                this.panel_info_regla_validada.Controls.Add(this.label_info_regla_validada_1);
                this.panel_info_regla_validada.Controls.Add(this.checkBox_info_regla_validada);
                this.panel_info_regla_validada.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_regla_validada.Name = "panel_info_regla_validada";
                this.panel_info_regla_validada.Size = new System.Drawing.Size(550, 85);
                this.panel_info_regla_validada.TabIndex = 0;
                // 
                // checkBox_info_regla_validada
                // 
                this.checkBox_info_regla_validada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_regla_validada.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_regla_validada.Name = "checkBox_info_regla_validada";
                this.checkBox_info_regla_validada.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_regla_validada.TabIndex = 0;
                this.checkBox_info_regla_validada.Text = "Mostrar";
                this.checkBox_info_regla_validada.UseVisualStyleBackColor = true;
                // 
                // label_info_regla_validada_1
                // 
                this.label_info_regla_validada_1.AutoSize = true;
                this.label_info_regla_validada_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_regla_validada_1.Name = "label1";
                this.label_info_regla_validada_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_regla_validada_1.TabIndex = 2;
                this.label_info_regla_validada_1.Text = "Texto :";
                // 
                // textBox_inicial_info_regla_validada
                // 
                this.textBox_info_regla_validada.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_regla_validada.Name = "textBox_inicial_info_regla_validada";
                this.textBox_info_regla_validada.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_regla_validada.TabIndex = 4;
                // 
                // label_tipo_info_regla_validada
                // 
                this.label_tipo_info_regla_validada.AutoSize = true;
                this.label_tipo_info_regla_validada.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_regla_validada.Name = "label_tipo_info_regla_validada";
                this.label_tipo_info_regla_validada.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_regla_validada.TabIndex = 6;
                this.label_tipo_info_regla_validada.Text = "LOG_INFO_REGLA_VALIDADA";
                // 
                // label_info_regla_validada_3
                // 
                this.label_info_regla_validada_3.AutoSize = true;
                this.label_info_regla_validada_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_regla_validada_3.Name = "label3";
                this.label_info_regla_validada_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_regla_validada_3.TabIndex = 7;
                this.label_info_regla_validada_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_regla_validada);
            }



            private System.Windows.Forms.Panel panel_info_regla_no_validada;
            private System.Windows.Forms.Label label_info_regla_no_validada_3;
            private System.Windows.Forms.Label label_tipo_info_regla_no_validada;
            private System.Windows.Forms.TextBox textBox_info_regla_no_validada;
            private System.Windows.Forms.Label label_info_regla_no_validada_1;
            private System.Windows.Forms.CheckBox checkBox_info_regla_no_validada;

            void inicializar_info_regla_no_validada()
            {
                this.panel_info_regla_no_validada = new System.Windows.Forms.Panel();
                this.checkBox_info_regla_no_validada = new System.Windows.Forms.CheckBox();
                this.label_info_regla_no_validada_1 = new System.Windows.Forms.Label();
                this.textBox_info_regla_no_validada = new System.Windows.Forms.TextBox();
                this.label_tipo_info_regla_no_validada = new System.Windows.Forms.Label();
                this.label_info_regla_no_validada_3 = new System.Windows.Forms.Label();
                this.panel_info_regla_no_validada.SuspendLayout();

                // 
                // panel_info_regla_no_validada
                // 
                this.panel_info_regla_no_validada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_regla_no_validada.Controls.Add(this.label_info_regla_no_validada_3);
                this.panel_info_regla_no_validada.Controls.Add(this.label_tipo_info_regla_no_validada);
                this.panel_info_regla_no_validada.Controls.Add(this.textBox_info_regla_no_validada);
                this.panel_info_regla_no_validada.Controls.Add(this.label_info_regla_no_validada_1);
                this.panel_info_regla_no_validada.Controls.Add(this.checkBox_info_regla_no_validada);
                this.panel_info_regla_no_validada.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_regla_no_validada.Name = "panel_info_regla_no_validada";
                this.panel_info_regla_no_validada.Size = new System.Drawing.Size(550, 85);
                this.panel_info_regla_no_validada.TabIndex = 0;
                // 
                // checkBox_info_regla_no_validada
                // 
                this.checkBox_info_regla_no_validada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_regla_no_validada.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_regla_no_validada.Name = "checkBox_info_regla_no_validada";
                this.checkBox_info_regla_no_validada.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_regla_no_validada.TabIndex = 0;
                this.checkBox_info_regla_no_validada.Text = "Mostrar";
                this.checkBox_info_regla_no_validada.UseVisualStyleBackColor = true;
                // 
                // label_info_regla_no_validada_1
                // 
                this.label_info_regla_no_validada_1.AutoSize = true;
                this.label_info_regla_no_validada_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_regla_no_validada_1.Name = "label1";
                this.label_info_regla_no_validada_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_regla_no_validada_1.TabIndex = 2;
                this.label_info_regla_no_validada_1.Text = "Texto :";
                // 
                // textBox_inicial_info_regla_no_validada
                // 
                this.textBox_info_regla_no_validada.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_regla_no_validada.Name = "textBox_inicial_info_regla_no_validada";
                this.textBox_info_regla_no_validada.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_regla_no_validada.TabIndex = 4;
                // 
                // label_tipo_info_regla_no_validada
                // 
                this.label_tipo_info_regla_no_validada.AutoSize = true;
                this.label_tipo_info_regla_no_validada.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_regla_no_validada.Name = "label_tipo_info_regla_no_validada";
                this.label_tipo_info_regla_no_validada.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_regla_no_validada.TabIndex = 6;
                this.label_tipo_info_regla_no_validada.Text = "LOG_INFO_REGLA_NO_VALIDADA";
                // 
                // label_info_regla_no_validada_3
                // 
                this.label_info_regla_no_validada_3.AutoSize = true;
                this.label_info_regla_no_validada_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_regla_no_validada_3.Name = "label3";
                this.label_info_regla_no_validada_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_regla_no_validada_3.TabIndex = 7;
                this.label_info_regla_no_validada_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_regla_no_validada);
            }

            private System.Windows.Forms.Panel panel_info_descartando_reglas_de_igual_consecuente;
            private System.Windows.Forms.Label label_info_descartando_reglas_de_igual_consecuente_3;
            private System.Windows.Forms.Label label_tipo_info_descartando_reglas_de_igual_consecuente;
            private System.Windows.Forms.TextBox textBox_info_descartando_reglas_de_igual_consecuente;
            private System.Windows.Forms.Label label_info_descartando_reglas_de_igual_consecuente_1;
            private System.Windows.Forms.CheckBox checkBox_info_descartando_reglas_de_igual_consecuente;

            void inicializar_info_descartando_reglas_de_igual_consecuente()
            {
                this.panel_info_descartando_reglas_de_igual_consecuente = new System.Windows.Forms.Panel();
                this.checkBox_info_descartando_reglas_de_igual_consecuente = new System.Windows.Forms.CheckBox();
                this.label_info_descartando_reglas_de_igual_consecuente_1 = new System.Windows.Forms.Label();
                this.textBox_info_descartando_reglas_de_igual_consecuente = new System.Windows.Forms.TextBox();
                this.label_tipo_info_descartando_reglas_de_igual_consecuente = new System.Windows.Forms.Label();
                this.label_info_descartando_reglas_de_igual_consecuente_3 = new System.Windows.Forms.Label();
                this.panel_info_descartando_reglas_de_igual_consecuente.SuspendLayout();

                // 
                // panel_info_descartando_reglas_de_igual_consecuente
                // 
                this.panel_info_descartando_reglas_de_igual_consecuente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_descartando_reglas_de_igual_consecuente.Controls.Add(this.label_info_descartando_reglas_de_igual_consecuente_3);
                this.panel_info_descartando_reglas_de_igual_consecuente.Controls.Add(this.label_tipo_info_descartando_reglas_de_igual_consecuente);
                this.panel_info_descartando_reglas_de_igual_consecuente.Controls.Add(this.textBox_info_descartando_reglas_de_igual_consecuente);
                this.panel_info_descartando_reglas_de_igual_consecuente.Controls.Add(this.label_info_descartando_reglas_de_igual_consecuente_1);
                this.panel_info_descartando_reglas_de_igual_consecuente.Controls.Add(this.checkBox_info_descartando_reglas_de_igual_consecuente);
                this.panel_info_descartando_reglas_de_igual_consecuente.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_descartando_reglas_de_igual_consecuente.Name = "panel_info_descartando_reglas_de_igual_consecuente";
                this.panel_info_descartando_reglas_de_igual_consecuente.Size = new System.Drawing.Size(550, 85);
                this.panel_info_descartando_reglas_de_igual_consecuente.TabIndex = 0;
                // 
                // checkBox_info_descartando_reglas_de_igual_consecuente
                // 
                this.checkBox_info_descartando_reglas_de_igual_consecuente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_descartando_reglas_de_igual_consecuente.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_descartando_reglas_de_igual_consecuente.Name = "checkBox_info_descartando_reglas_de_igual_consecuente";
                this.checkBox_info_descartando_reglas_de_igual_consecuente.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_descartando_reglas_de_igual_consecuente.TabIndex = 0;
                this.checkBox_info_descartando_reglas_de_igual_consecuente.Text = "Mostrar";
                this.checkBox_info_descartando_reglas_de_igual_consecuente.UseVisualStyleBackColor = true;
                // 
                // label_info_descartando_reglas_de_igual_consecuente_1
                // 
                this.label_info_descartando_reglas_de_igual_consecuente_1.AutoSize = true;
                this.label_info_descartando_reglas_de_igual_consecuente_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_descartando_reglas_de_igual_consecuente_1.Name = "label1";
                this.label_info_descartando_reglas_de_igual_consecuente_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_descartando_reglas_de_igual_consecuente_1.TabIndex = 2;
                this.label_info_descartando_reglas_de_igual_consecuente_1.Text = "Texto :";
                // 
                // textBox_inicial_info_descartando_reglas_de_igual_consecuente
                // 
                this.textBox_info_descartando_reglas_de_igual_consecuente.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_descartando_reglas_de_igual_consecuente.Name = "textBox_inicial_info_descartando_reglas_de_igual_consecuente";
                this.textBox_info_descartando_reglas_de_igual_consecuente.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_descartando_reglas_de_igual_consecuente.TabIndex = 4;
                // 
                // label_tipo_info_descartando_reglas_de_igual_consecuente
                // 
                this.label_tipo_info_descartando_reglas_de_igual_consecuente.AutoSize = true;
                this.label_tipo_info_descartando_reglas_de_igual_consecuente.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_descartando_reglas_de_igual_consecuente.Name = "label_tipo_info_descartando_reglas_de_igual_consecuente";
                this.label_tipo_info_descartando_reglas_de_igual_consecuente.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_descartando_reglas_de_igual_consecuente.TabIndex = 6;
                this.label_tipo_info_descartando_reglas_de_igual_consecuente.Text = "LOG_INFO_DESCARTANDO_REGLAS_DE_IGUAL_CONSECUENTE";
                // 
                // label_info_descartando_reglas_de_igual_consecuente_3
                // 
                this.label_info_descartando_reglas_de_igual_consecuente_3.AutoSize = true;
                this.label_info_descartando_reglas_de_igual_consecuente_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_descartando_reglas_de_igual_consecuente_3.Name = "label3";
                this.label_info_descartando_reglas_de_igual_consecuente_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_descartando_reglas_de_igual_consecuente_3.TabIndex = 7;
                this.label_info_descartando_reglas_de_igual_consecuente_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_descartando_reglas_de_igual_consecuente);
            }


            private System.Windows.Forms.Panel panel_info_problema_solucionado;
            private System.Windows.Forms.Label label_info_problema_solucionado_3;
            private System.Windows.Forms.Label label_tipo_info_problema_solucionado;
            private System.Windows.Forms.TextBox textBox_info_problema_solucionado;
            private System.Windows.Forms.Label label_info_problema_solucionado_1;
            private System.Windows.Forms.CheckBox checkBox_info_problema_solucionado;

            void inicializar_info_problema_solucionado()
            {
                this.panel_info_problema_solucionado = new System.Windows.Forms.Panel();
                this.checkBox_info_problema_solucionado = new System.Windows.Forms.CheckBox();
                this.label_info_problema_solucionado_1 = new System.Windows.Forms.Label();
                this.textBox_info_problema_solucionado = new System.Windows.Forms.TextBox();
                this.label_tipo_info_problema_solucionado = new System.Windows.Forms.Label();
                this.label_info_problema_solucionado_3 = new System.Windows.Forms.Label();
                this.panel_info_problema_solucionado.SuspendLayout();

                // 
                // panel_info_problema_solucionado
                // 
                this.panel_info_problema_solucionado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_problema_solucionado.Controls.Add(this.label_info_problema_solucionado_3);
                this.panel_info_problema_solucionado.Controls.Add(this.label_tipo_info_problema_solucionado);
                this.panel_info_problema_solucionado.Controls.Add(this.textBox_info_problema_solucionado);
                this.panel_info_problema_solucionado.Controls.Add(this.label_info_problema_solucionado_1);
                this.panel_info_problema_solucionado.Controls.Add(this.checkBox_info_problema_solucionado);
                this.panel_info_problema_solucionado.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_problema_solucionado.Name = "panel_info_problema_solucionado";
                this.panel_info_problema_solucionado.Size = new System.Drawing.Size(550, 85);
                this.panel_info_problema_solucionado.TabIndex = 0;
                // 
                // checkBox_info_problema_solucionado
                // 
                this.checkBox_info_problema_solucionado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_problema_solucionado.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_problema_solucionado.Name = "checkBox_info_problema_solucionado";
                this.checkBox_info_problema_solucionado.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_problema_solucionado.TabIndex = 0;
                this.checkBox_info_problema_solucionado.Text = "Mostrar";
                this.checkBox_info_problema_solucionado.UseVisualStyleBackColor = true;
                // 
                // label_info_problema_solucionado_1
                // 
                this.label_info_problema_solucionado_1.AutoSize = true;
                this.label_info_problema_solucionado_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_problema_solucionado_1.Name = "label1";
                this.label_info_problema_solucionado_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_problema_solucionado_1.TabIndex = 2;
                this.label_info_problema_solucionado_1.Text = "Texto :";
                // 
                // textBox_inicial_info_problema_solucionado
                // 
                this.textBox_info_problema_solucionado.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_problema_solucionado.Name = "textBox_inicial_info_problema_solucionado";
                this.textBox_info_problema_solucionado.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_problema_solucionado.TabIndex = 4;
                // 
                // label_tipo_info_problema_solucionado
                // 
                this.label_tipo_info_problema_solucionado.AutoSize = true;
                this.label_tipo_info_problema_solucionado.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_problema_solucionado.Name = "label_tipo_info_problema_solucionado";
                this.label_tipo_info_problema_solucionado.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_problema_solucionado.TabIndex = 6;
                this.label_tipo_info_problema_solucionado.Text = "LOG_INFO_PROBLEMA_SOLUCIONADO";
                // 
                // label_info_problema_solucionado_3
                // 
                this.label_info_problema_solucionado_3.AutoSize = true;
                this.label_info_problema_solucionado_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_problema_solucionado_3.Name = "label3";
                this.label_info_problema_solucionado_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_problema_solucionado_3.TabIndex = 7;
                this.label_info_problema_solucionado_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_problema_solucionado);
            }

            private System.Windows.Forms.Panel panel_info_problema_no_solucionado;
            private System.Windows.Forms.Label label_info_problema_no_solucionado_3;
            private System.Windows.Forms.Label label_tipo_info_problema_no_solucionado;
            private System.Windows.Forms.TextBox textBox_info_problema_no_solucionado;
            private System.Windows.Forms.Label label_info_problema_no_solucionado_1;
            private System.Windows.Forms.CheckBox checkBox_info_problema_no_solucionado;

            void inicializar_info_problema_no_solucionado()
            {
                this.panel_info_problema_no_solucionado = new System.Windows.Forms.Panel();
                this.checkBox_info_problema_no_solucionado = new System.Windows.Forms.CheckBox();
                this.label_info_problema_no_solucionado_1 = new System.Windows.Forms.Label();
                this.textBox_info_problema_no_solucionado = new System.Windows.Forms.TextBox();
                this.label_tipo_info_problema_no_solucionado = new System.Windows.Forms.Label();
                this.label_info_problema_no_solucionado_3 = new System.Windows.Forms.Label();
                this.panel_info_problema_no_solucionado.SuspendLayout();

                // 
                // panel_info_problema_no_solucionado
                // 
                this.panel_info_problema_no_solucionado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_problema_no_solucionado.Controls.Add(this.label_info_problema_no_solucionado_3);
                this.panel_info_problema_no_solucionado.Controls.Add(this.label_tipo_info_problema_no_solucionado);
                this.panel_info_problema_no_solucionado.Controls.Add(this.textBox_info_problema_no_solucionado);
                this.panel_info_problema_no_solucionado.Controls.Add(this.label_info_problema_no_solucionado_1);
                this.panel_info_problema_no_solucionado.Controls.Add(this.checkBox_info_problema_no_solucionado);
                this.panel_info_problema_no_solucionado.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_problema_no_solucionado.Name = "panel_info_problema_no_solucionado";
                this.panel_info_problema_no_solucionado.Size = new System.Drawing.Size(550, 85);
                this.panel_info_problema_no_solucionado.TabIndex = 0;
                // 
                // checkBox_info_problema_no_solucionado
                // 
                this.checkBox_info_problema_no_solucionado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_problema_no_solucionado.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_problema_no_solucionado.Name = "checkBox_info_problema_no_solucionado";
                this.checkBox_info_problema_no_solucionado.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_problema_no_solucionado.TabIndex = 0;
                this.checkBox_info_problema_no_solucionado.Text = "Mostrar";
                this.checkBox_info_problema_no_solucionado.UseVisualStyleBackColor = true;
                // 
                // label_info_problema_no_solucionado_1
                // 
                this.label_info_problema_no_solucionado_1.AutoSize = true;
                this.label_info_problema_no_solucionado_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_problema_no_solucionado_1.Name = "label1";
                this.label_info_problema_no_solucionado_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_problema_no_solucionado_1.TabIndex = 2;
                this.label_info_problema_no_solucionado_1.Text = "Texto :";
                // 
                // textBox_inicial_info_problema_no_solucionado
                // 
                this.textBox_info_problema_no_solucionado.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_problema_no_solucionado.Name = "textBox_inicial_info_problema_no_solucionado";
                this.textBox_info_problema_no_solucionado.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_problema_no_solucionado.TabIndex = 4;
                // 
                // label_tipo_info_problema_no_solucionado
                // 
                this.label_tipo_info_problema_no_solucionado.AutoSize = true;
                this.label_tipo_info_problema_no_solucionado.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_problema_no_solucionado.Name = "label_tipo_info_problema_no_solucionado";
                this.label_tipo_info_problema_no_solucionado.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_problema_no_solucionado.TabIndex = 6;
                this.label_tipo_info_problema_no_solucionado.Text = "LOG_INFO_PROBLEMA_NO_SOLUCIONADO";
                // 
                // label_info_problema_no_solucionado_3
                // 
                this.label_info_problema_no_solucionado_3.AutoSize = true;
                this.label_info_problema_no_solucionado_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_problema_no_solucionado_3.Name = "label3";
                this.label_info_problema_no_solucionado_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_problema_no_solucionado_3.TabIndex = 7;
                this.label_info_problema_no_solucionado_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_problema_no_solucionado);
            }


            private System.Windows.Forms.Panel panel_info_continuando_proceso;
            private System.Windows.Forms.Label label_info_continuando_proceso_3;
            private System.Windows.Forms.Label label_tipo_info_continuando_proceso;
            private System.Windows.Forms.TextBox textBox_info_continuando_proceso;
            private System.Windows.Forms.Label label_info_continuando_proceso_1;
            private System.Windows.Forms.CheckBox checkBox_info_continuando_proceso;

            void inicializar_info_continuando_proceso()
            {
                this.panel_info_continuando_proceso = new System.Windows.Forms.Panel();
                this.checkBox_info_continuando_proceso = new System.Windows.Forms.CheckBox();
                this.label_info_continuando_proceso_1 = new System.Windows.Forms.Label();
                this.textBox_info_continuando_proceso = new System.Windows.Forms.TextBox();
                this.label_tipo_info_continuando_proceso = new System.Windows.Forms.Label();
                this.label_info_continuando_proceso_3 = new System.Windows.Forms.Label();
                this.panel_info_continuando_proceso.SuspendLayout();

                // 
                // panel_info_continuando_proceso
                // 
                this.panel_info_continuando_proceso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_continuando_proceso.Controls.Add(this.label_info_continuando_proceso_3);
                this.panel_info_continuando_proceso.Controls.Add(this.label_tipo_info_continuando_proceso);
                this.panel_info_continuando_proceso.Controls.Add(this.textBox_info_continuando_proceso);
                this.panel_info_continuando_proceso.Controls.Add(this.label_info_continuando_proceso_1);
                this.panel_info_continuando_proceso.Controls.Add(this.checkBox_info_continuando_proceso);
                this.panel_info_continuando_proceso.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_continuando_proceso.Name = "panel_info_continuando_proceso";
                this.panel_info_continuando_proceso.Size = new System.Drawing.Size(550, 85);
                this.panel_info_continuando_proceso.TabIndex = 0;
                // 
                // checkBox_info_continuando_proceso
                // 
                this.checkBox_info_continuando_proceso.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_continuando_proceso.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_continuando_proceso.Name = "checkBox_info_continuando_proceso";
                this.checkBox_info_continuando_proceso.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_continuando_proceso.TabIndex = 0;
                this.checkBox_info_continuando_proceso.Text = "Mostrar";
                this.checkBox_info_continuando_proceso.UseVisualStyleBackColor = true;
                // 
                // label_info_continuando_proceso_1
                // 
                this.label_info_continuando_proceso_1.AutoSize = true;
                this.label_info_continuando_proceso_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_continuando_proceso_1.Name = "label1";
                this.label_info_continuando_proceso_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_continuando_proceso_1.TabIndex = 2;
                this.label_info_continuando_proceso_1.Text = "Texto :";
                // 
                // textBox_inicial_info_continuando_proceso
                // 
                this.textBox_info_continuando_proceso.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_continuando_proceso.Name = "textBox_inicial_info_continuando_proceso";
                this.textBox_info_continuando_proceso.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_continuando_proceso.TabIndex = 4;
                // 
                // label_tipo_info_continuando_proceso
                // 
                this.label_tipo_info_continuando_proceso.AutoSize = true;
                this.label_tipo_info_continuando_proceso.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_continuando_proceso.Name = "label_tipo_info_continuando_proceso";
                this.label_tipo_info_continuando_proceso.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_continuando_proceso.TabIndex = 6;
                this.label_tipo_info_continuando_proceso.Text = "LOG_INFO_CONTINUANDO_PROCESO";
                // 
                // label_info_continuando_proceso_3
                // 
                this.label_info_continuando_proceso_3.AutoSize = true;
                this.label_info_continuando_proceso_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_continuando_proceso_3.Name = "label3";
                this.label_info_continuando_proceso_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_continuando_proceso_3.TabIndex = 7;
                this.label_info_continuando_proceso_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_continuando_proceso);
            }


            private System.Windows.Forms.Panel panel_proceso_detenido;
            private System.Windows.Forms.Label label_proceso_detenido_3;
            private System.Windows.Forms.Label label_tipo_proceso_detenido;
            private System.Windows.Forms.TextBox textBox_info_proceso_detenido;
            private System.Windows.Forms.Label label_proceso_detenido_1;
            private System.Windows.Forms.CheckBox checkBox_info_proceso_detenido;

            void inicializar_proceso_detenido()
            {
                this.panel_proceso_detenido = new System.Windows.Forms.Panel();
                this.checkBox_info_proceso_detenido = new System.Windows.Forms.CheckBox();
                this.label_proceso_detenido_1 = new System.Windows.Forms.Label();
                this.textBox_info_proceso_detenido = new System.Windows.Forms.TextBox();
                this.label_tipo_proceso_detenido = new System.Windows.Forms.Label();
                this.label_proceso_detenido_3 = new System.Windows.Forms.Label();
                this.panel_proceso_detenido.SuspendLayout();

                // 
                // panel_proceso_detenido
                // 
                this.panel_proceso_detenido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_proceso_detenido.Controls.Add(this.label_proceso_detenido_3);
                this.panel_proceso_detenido.Controls.Add(this.label_tipo_proceso_detenido);
                this.panel_proceso_detenido.Controls.Add(this.textBox_info_proceso_detenido);
                this.panel_proceso_detenido.Controls.Add(this.label_proceso_detenido_1);
                this.panel_proceso_detenido.Controls.Add(this.checkBox_info_proceso_detenido);
                this.panel_proceso_detenido.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_proceso_detenido.Name = "panel_proceso_detenido";
                this.panel_proceso_detenido.Size = new System.Drawing.Size(550, 85);
                this.panel_proceso_detenido.TabIndex = 0;
                // 
                // checkBox_proceso_detenido
                // 
                this.checkBox_info_proceso_detenido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_proceso_detenido.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_proceso_detenido.Name = "checkBox_proceso_detenido";
                this.checkBox_info_proceso_detenido.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_proceso_detenido.TabIndex = 0;
                this.checkBox_info_proceso_detenido.Text = "Mostrar";
                this.checkBox_info_proceso_detenido.UseVisualStyleBackColor = true;
                // 
                // label_proceso_detenido_1
                // 
                this.label_proceso_detenido_1.AutoSize = true;
                this.label_proceso_detenido_1.Location = new System.Drawing.Point(12, 61);
                this.label_proceso_detenido_1.Name = "label1";
                this.label_proceso_detenido_1.Size = new System.Drawing.Size(66, 13);
                this.label_proceso_detenido_1.TabIndex = 2;
                this.label_proceso_detenido_1.Text = "Texto :";
                // 
                // textBox_inicial_proceso_detenido
                // 
                this.textBox_info_proceso_detenido.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_proceso_detenido.Name = "textBox_inicial_proceso_detenido";
                this.textBox_info_proceso_detenido.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_proceso_detenido.TabIndex = 4;
                // 
                // label_tipo_proceso_detenido
                // 
                this.label_tipo_proceso_detenido.AutoSize = true;
                this.label_tipo_proceso_detenido.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_proceso_detenido.Name = "label_tipo_proceso_detenido";
                this.label_tipo_proceso_detenido.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_proceso_detenido.TabIndex = 6;
                this.label_tipo_proceso_detenido.Text = "LOG_INFO_PROCESO_DETENIDO";
                // 
                // label_proceso_detenido_3
                // 
                this.label_proceso_detenido_3.AutoSize = true;
                this.label_proceso_detenido_3.Location = new System.Drawing.Point(15, 15);
                this.label_proceso_detenido_3.Name = "label3";
                this.label_proceso_detenido_3.Size = new System.Drawing.Size(48, 13);
                this.label_proceso_detenido_3.TabIndex = 7;
                this.label_proceso_detenido_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_proceso_detenido);
            }


            private System.Windows.Forms.Panel panel_info_termino_inferencia_reglas_agotadas;
            private System.Windows.Forms.Label label_info_termino_inferencia_reglas_agotadas_3;
            private System.Windows.Forms.Label label_tipo_info_termino_inferencia_reglas_agotadas;
            private System.Windows.Forms.TextBox textBox_info_termino_inferencia_reglas_agotadas;
            private System.Windows.Forms.Label label_info_termino_inferencia_reglas_agotadas_1;
            private System.Windows.Forms.CheckBox checkBox_info_termino_inferencia_reglas_agotadas;

            void inicializar_info_termino_inferencia_reglas_agotadas()
            {
                this.panel_info_termino_inferencia_reglas_agotadas = new System.Windows.Forms.Panel();
                this.checkBox_info_termino_inferencia_reglas_agotadas = new System.Windows.Forms.CheckBox();
                this.label_info_termino_inferencia_reglas_agotadas_1 = new System.Windows.Forms.Label();
                this.textBox_info_termino_inferencia_reglas_agotadas = new System.Windows.Forms.TextBox();
                this.label_tipo_info_termino_inferencia_reglas_agotadas = new System.Windows.Forms.Label();
                this.label_info_termino_inferencia_reglas_agotadas_3 = new System.Windows.Forms.Label();
                this.panel_info_termino_inferencia_reglas_agotadas.SuspendLayout();

                // 
                // panel_info_termino_inferencia_reglas_agotadas
                // 
                this.panel_info_termino_inferencia_reglas_agotadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_termino_inferencia_reglas_agotadas.Controls.Add(this.label_info_termino_inferencia_reglas_agotadas_3);
                this.panel_info_termino_inferencia_reglas_agotadas.Controls.Add(this.label_tipo_info_termino_inferencia_reglas_agotadas);
                this.panel_info_termino_inferencia_reglas_agotadas.Controls.Add(this.textBox_info_termino_inferencia_reglas_agotadas);
                this.panel_info_termino_inferencia_reglas_agotadas.Controls.Add(this.label_info_termino_inferencia_reglas_agotadas_1);
                this.panel_info_termino_inferencia_reglas_agotadas.Controls.Add(this.checkBox_info_termino_inferencia_reglas_agotadas);
                this.panel_info_termino_inferencia_reglas_agotadas.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_termino_inferencia_reglas_agotadas.Name = "panel_info_termino_inferencia_reglas_agotadas";
                this.panel_info_termino_inferencia_reglas_agotadas.Size = new System.Drawing.Size(550, 85);
                this.panel_info_termino_inferencia_reglas_agotadas.TabIndex = 0;
                // 
                // checkBox_info_termino_inferencia_reglas_agotadas
                // 
                this.checkBox_info_termino_inferencia_reglas_agotadas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_termino_inferencia_reglas_agotadas.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_termino_inferencia_reglas_agotadas.Name = "checkBox_info_termino_inferencia_reglas_agotadas";
                this.checkBox_info_termino_inferencia_reglas_agotadas.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_termino_inferencia_reglas_agotadas.TabIndex = 0;
                this.checkBox_info_termino_inferencia_reglas_agotadas.Text = "Mostrar";
                this.checkBox_info_termino_inferencia_reglas_agotadas.UseVisualStyleBackColor = true;
                // 
                // label_info_termino_inferencia_reglas_agotadas_1
                // 
                this.label_info_termino_inferencia_reglas_agotadas_1.AutoSize = true;
                this.label_info_termino_inferencia_reglas_agotadas_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_termino_inferencia_reglas_agotadas_1.Name = "label1";
                this.label_info_termino_inferencia_reglas_agotadas_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_termino_inferencia_reglas_agotadas_1.TabIndex = 2;
                this.label_info_termino_inferencia_reglas_agotadas_1.Text = "Texto :";
                // 
                // textBox_inicial_info_termino_inferencia_reglas_agotadas
                // 
                this.textBox_info_termino_inferencia_reglas_agotadas.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_termino_inferencia_reglas_agotadas.Name = "textBox_inicial_info_termino_inferencia_reglas_agotadas";
                this.textBox_info_termino_inferencia_reglas_agotadas.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_termino_inferencia_reglas_agotadas.TabIndex = 4;
                // 
                // label_tipo_info_termino_inferencia_reglas_agotadas
                // 
                this.label_tipo_info_termino_inferencia_reglas_agotadas.AutoSize = true;
                this.label_tipo_info_termino_inferencia_reglas_agotadas.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_termino_inferencia_reglas_agotadas.Name = "label_tipo_info_termino_inferencia_reglas_agotadas";
                this.label_tipo_info_termino_inferencia_reglas_agotadas.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_termino_inferencia_reglas_agotadas.TabIndex = 6;
                this.label_tipo_info_termino_inferencia_reglas_agotadas.Text = "LOG_INFO_TERMINO_DE_INFERENCIA_REGLAS_AGOTADAS";
                // 
                // label_info_termino_inferencia_reglas_agotadas_3
                // 
                this.label_info_termino_inferencia_reglas_agotadas_3.AutoSize = true;
                this.label_info_termino_inferencia_reglas_agotadas_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_termino_inferencia_reglas_agotadas_3.Name = "label3";
                this.label_info_termino_inferencia_reglas_agotadas_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_termino_inferencia_reglas_agotadas_3.TabIndex = 7;
                this.label_info_termino_inferencia_reglas_agotadas_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_termino_inferencia_reglas_agotadas);
            }



            private System.Windows.Forms.Panel panel_info_consultando_variables_inicio;
            private System.Windows.Forms.Label label_info_consultando_variables_inicio_3;
            private System.Windows.Forms.Label label_tipo_info_consultando_variables_inicio;
            private System.Windows.Forms.TextBox textBox_info_consultando_variables_inicio;
            private System.Windows.Forms.Label label_info_consultando_variables_inicio_1;
            private System.Windows.Forms.CheckBox checkBox_info_consultando_variables_inicio;

            void inicializar_info_consultando_variables_inicio()
            {
                this.panel_info_consultando_variables_inicio = new System.Windows.Forms.Panel();
                this.checkBox_info_consultando_variables_inicio = new System.Windows.Forms.CheckBox();
                this.label_info_consultando_variables_inicio_1 = new System.Windows.Forms.Label();
                this.textBox_info_consultando_variables_inicio = new System.Windows.Forms.TextBox();
                this.label_tipo_info_consultando_variables_inicio = new System.Windows.Forms.Label();
                this.label_info_consultando_variables_inicio_3 = new System.Windows.Forms.Label();
                this.panel_info_consultando_variables_inicio.SuspendLayout();

                // 
                // panel_info_consultando_variables_inicio
                // 
                this.panel_info_consultando_variables_inicio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_consultando_variables_inicio.Controls.Add(this.label_info_consultando_variables_inicio_3);
                this.panel_info_consultando_variables_inicio.Controls.Add(this.label_tipo_info_consultando_variables_inicio);
                this.panel_info_consultando_variables_inicio.Controls.Add(this.textBox_info_consultando_variables_inicio);
                this.panel_info_consultando_variables_inicio.Controls.Add(this.label_info_consultando_variables_inicio_1);
                this.panel_info_consultando_variables_inicio.Controls.Add(this.checkBox_info_consultando_variables_inicio);
                this.panel_info_consultando_variables_inicio.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_consultando_variables_inicio.Name = "panel_info_consultando_variables_inicio";
                this.panel_info_consultando_variables_inicio.Size = new System.Drawing.Size(550, 85);
                this.panel_info_consultando_variables_inicio.TabIndex = 0;
                // 
                // checkBox_info_consultando_variables_inicio
                // 
                this.checkBox_info_consultando_variables_inicio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_consultando_variables_inicio.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_consultando_variables_inicio.Name = "checkBox_info_consultando_variables_inicio";
                this.checkBox_info_consultando_variables_inicio.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_consultando_variables_inicio.TabIndex = 0;
                this.checkBox_info_consultando_variables_inicio.Text = "Mostrar";
                this.checkBox_info_consultando_variables_inicio.UseVisualStyleBackColor = true;
                // 
                // label_info_consultando_variables_inicio_1
                // 
                this.label_info_consultando_variables_inicio_1.AutoSize = true;
                this.label_info_consultando_variables_inicio_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_consultando_variables_inicio_1.Name = "label1";
                this.label_info_consultando_variables_inicio_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_consultando_variables_inicio_1.TabIndex = 2;
                this.label_info_consultando_variables_inicio_1.Text = "Texto :";
                // 
                // textBox_inicial_info_consultando_variables_inicio
                // 
                this.textBox_info_consultando_variables_inicio.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_consultando_variables_inicio.Name = "textBox_inicial_info_consultando_variables_inicio";
                this.textBox_info_consultando_variables_inicio.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_consultando_variables_inicio.TabIndex = 4;
                // 
                // label_tipo_info_consultando_variables_inicio
                // 
                this.label_tipo_info_consultando_variables_inicio.AutoSize = true;
                this.label_tipo_info_consultando_variables_inicio.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_consultando_variables_inicio.Name = "label_tipo_info_consultando_variables_inicio";
                this.label_tipo_info_consultando_variables_inicio.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_consultando_variables_inicio.TabIndex = 6;
                this.label_tipo_info_consultando_variables_inicio.Text = "LOG_INFO_CONSULTANDO_VARIABLES_DE_INICIO";
                // 
                // label_info_consultando_variables_inicio_3
                // 
                this.label_info_consultando_variables_inicio_3.AutoSize = true;
                this.label_info_consultando_variables_inicio_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_consultando_variables_inicio_3.Name = "label3";
                this.label_info_consultando_variables_inicio_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_consultando_variables_inicio_3.TabIndex = 7;
                this.label_info_consultando_variables_inicio_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_consultando_variables_inicio);
            }

            private System.Windows.Forms.Panel panel_info_procesando_hechos_asociados;
            private System.Windows.Forms.Label label_info_procesando_hechos_asociados_3;
            private System.Windows.Forms.Label label_tipo_info_procesando_hechos_asociados;
            private System.Windows.Forms.TextBox textBox_info_procesando_hechos_asociados;
            private System.Windows.Forms.Label label_info_procesando_hechos_asociados_1;
            private System.Windows.Forms.CheckBox checkBox_info_procesando_hechos_asociados;

            void inicializar_info_procesando_hechos_asociados()
            {
                this.panel_info_procesando_hechos_asociados = new System.Windows.Forms.Panel();
                this.checkBox_info_procesando_hechos_asociados = new System.Windows.Forms.CheckBox();
                this.label_info_procesando_hechos_asociados_1 = new System.Windows.Forms.Label();
                this.textBox_info_procesando_hechos_asociados = new System.Windows.Forms.TextBox();
                this.label_tipo_info_procesando_hechos_asociados = new System.Windows.Forms.Label();
                this.label_info_procesando_hechos_asociados_3 = new System.Windows.Forms.Label();
                this.panel_info_procesando_hechos_asociados.SuspendLayout();

                // 
                // panel_info_procesando_hechos_asociados
                // 
                this.panel_info_procesando_hechos_asociados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel_info_procesando_hechos_asociados.Controls.Add(this.label_info_procesando_hechos_asociados_3);
                this.panel_info_procesando_hechos_asociados.Controls.Add(this.label_tipo_info_procesando_hechos_asociados);
                this.panel_info_procesando_hechos_asociados.Controls.Add(this.textBox_info_procesando_hechos_asociados);
                this.panel_info_procesando_hechos_asociados.Controls.Add(this.label_info_procesando_hechos_asociados_1);
                this.panel_info_procesando_hechos_asociados.Controls.Add(this.checkBox_info_procesando_hechos_asociados);
                this.panel_info_procesando_hechos_asociados.Location = new System.Drawing.Point(3, ultimo_y);
                ultimo_y += 95;
                this.panel_info_procesando_hechos_asociados.Name = "panel_info_procesando_hechos_asociados";
                this.panel_info_procesando_hechos_asociados.Size = new System.Drawing.Size(550, 85);
                this.panel_info_procesando_hechos_asociados.TabIndex = 0;
                // 
                // checkBox_info_procesando_hechos_asociados
                // 
                this.checkBox_info_procesando_hechos_asociados.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.checkBox_info_procesando_hechos_asociados.Location = new System.Drawing.Point(15, 34);
                this.checkBox_info_procesando_hechos_asociados.Name = "checkBox_info_procesando_hechos_asociados";
                this.checkBox_info_procesando_hechos_asociados.Size = new System.Drawing.Size(81, 24);
                this.checkBox_info_procesando_hechos_asociados.TabIndex = 0;
                this.checkBox_info_procesando_hechos_asociados.Text = "Mostrar";
                this.checkBox_info_procesando_hechos_asociados.UseVisualStyleBackColor = true;
                // 
                // label_info_procesando_hechos_asociados_1
                // 
                this.label_info_procesando_hechos_asociados_1.AutoSize = true;
                this.label_info_procesando_hechos_asociados_1.Location = new System.Drawing.Point(12, 61);
                this.label_info_procesando_hechos_asociados_1.Name = "label1";
                this.label_info_procesando_hechos_asociados_1.Size = new System.Drawing.Size(66, 13);
                this.label_info_procesando_hechos_asociados_1.TabIndex = 2;
                this.label_info_procesando_hechos_asociados_1.Text = "Texto :";
                // 
                // textBox_inicial_info_procesando_hechos_asociados
                // 
                this.textBox_info_procesando_hechos_asociados.Location = new System.Drawing.Point(84, 58);
                this.textBox_info_procesando_hechos_asociados.Name = "textBox_inicial_info_procesando_hechos_asociados";
                this.textBox_info_procesando_hechos_asociados.Size = new System.Drawing.Size(413, 20);
                this.textBox_info_procesando_hechos_asociados.TabIndex = 4;
                // 
                // label_tipo_info_procesando_hechos_asociados
                // 
                this.label_tipo_info_procesando_hechos_asociados.AutoSize = true;
                this.label_tipo_info_procesando_hechos_asociados.Location = new System.Drawing.Point(81, 15);
                this.label_tipo_info_procesando_hechos_asociados.Name = "label_tipo_info_procesando_hechos_asociados";
                this.label_tipo_info_procesando_hechos_asociados.Size = new System.Drawing.Size(60, 13);
                this.label_tipo_info_procesando_hechos_asociados.TabIndex = 6;
                this.label_tipo_info_procesando_hechos_asociados.Text = "LOG_INFO_PROCESANDO_HECHOS_ASOCIADOS";
                // 
                // label_info_procesando_hechos_asociados_3
                // 
                this.label_info_procesando_hechos_asociados_3.AutoSize = true;
                this.label_info_procesando_hechos_asociados_3.Location = new System.Drawing.Point(15, 15);
                this.label_info_procesando_hechos_asociados_3.Name = "label3";
                this.label_info_procesando_hechos_asociados_3.Size = new System.Drawing.Size(48, 13);
                this.label_info_procesando_hechos_asociados_3.TabIndex = 7;
                this.label_info_procesando_hechos_asociados_3.Text = "Tipo log:";

                //agregando a form
                this.panel_interno_controles.Controls.Add(panel_info_procesando_hechos_asociados);
            }
    }
}
