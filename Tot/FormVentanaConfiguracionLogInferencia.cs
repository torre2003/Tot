using SistemaExpertoLib;
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
        GestionConfiguracionInternaTot configuracion_interna = new GestionConfiguracionInternaTot();
        
        public FormVentanaConfiguracionLogInferencia()
        {
            InitializeComponent();
            inicializarComponentes();
        }

        public FormVentanaConfiguracionLogInferencia(GestionConfiguracionInternaTot configuracion_interna)
        {
            InitializeComponent();
            inicializarComponentes();
            this.configuracion_interna = configuracion_interna;
        }

        public void mostrarConfiguracionProcesadorLoggeo(ProcesadorLoggeoInferencia procesador)
        {
            switch (procesador.formato_variables)
            {
                case ProcesadorLoggeoInferencia.FORMATO_SOLO_ID:
                    radioButton_variable_id.Checked = true;
                    break;
                case ProcesadorLoggeoInferencia.FORMATO_SOLO_CONTENIDO:
                    radioButton_variable_contenido.Checked = true;
                    break;
                case ProcesadorLoggeoInferencia.FORMATO_ID_MAS_CONTENIDO:
                    radioButton_variable_id_contenido.Checked = true;
                    break;
            }
            
            switch (procesador.formato_hechos)
            {
                case ProcesadorLoggeoInferencia.FORMATO_SOLO_ID:
                    radioButton_hecho_id.Checked = true;
                    break;
                case ProcesadorLoggeoInferencia.FORMATO_SOLO_CONTENIDO:
                    radioButton_hecho_contenido.Checked = true;
                    break;
                case ProcesadorLoggeoInferencia.FORMATO_ID_MAS_CONTENIDO:
                    radioButton_hecho_id_contenido.Checked = true;
                    break;
            }

            switch (procesador.formato_reglas)
            {
                case ProcesadorLoggeoInferencia.FORMATO_SOLO_ID:
                    radioButton_regla_id.Checked = true;
                    break;
                case ProcesadorLoggeoInferencia.FORMATO_SOLO_CONTENIDO:
                    radioButton_regla_contenido.Checked = true;
                    break;
                case ProcesadorLoggeoInferencia.FORMATO_ID_MAS_CONTENIDO:
                    radioButton_regla_id_contenido.Checked = true;
                    break;
            }
            
            //Mostrando textos 

            textBox_texto_reglas_disponibles.Text = procesador.texto_reglas_disponibles;
            textBox_texto_reglas_candidatas.Text = procesador.texto_reglas_candidatas;
            textBox_texto_reglas_eliminadas.Text = procesador.texto_reglas_eliminadas;
            textBox_texto_hechos_disponibles.Text = procesador.texto_hechos_disponibles;
            textBox_texto_hechos_verdaderos.Text = procesador.texto_hechos_verdaderos;
            textBox_texto_hechos_falsos.Text = procesador.texto_hechos_falsos;
                       
            textBox_inicial_mover_hecho.Text = procesador.texto_log_accion_mover_hecho_inicial;
            textBox_medio_mover_hecho.Text = procesador.texto_log_accion_mover_hecho_central;
            textBox_final_mover_hecho.Text = procesador.texto_log_accion_mover_hecho_final;

            textBox_inicial_mover_regla.Text = procesador.texto_log_accion_mover_regla_inicial;
            textBox_medio_mover_regla.Text = procesador.texto_log_accion_mover_regla_central;
            textBox_final_mover_regla.Text = procesador.texto_log_accion_mover_regla_final;

            textBox_inicial_ingresando_a_var_conocida.Text = procesador.texto_log_accion_ingresando_a_variables_conocidas_inicial;
            textBox_medio_ingresando_a_var_conocida.Text = procesador.texto_log_accion_ingresando_a_variables_conocidas_final;

            textBox_inicial_accion_elegida_mejor_regla.Text = procesador.texto_log_accion_elegida_mejor_regla_inicial;
            textBox_medio_accion_elegida_mejor_regla.Text = procesador.texto_log_accion_elegida_mejor_regla_final;

            textBox_inicial_accion_consultando_hechos.Text = procesador.texto_log_accion_consultando_hechos_inicial;
            textBox_medio_accion_consultando_hechos.Text = procesador.texto_log_accion_consultando_hechos_final;

            textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos.Text = procesador.texto_log_accion_ingresando_hecho_a_pila_objetivos_inicial;
            textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos.Text = procesador.texto_log_accion_ingresando_hecho_a_pila_objetivos_final;

            textBox_inicial_accion_hecho_objetivo_principal.Text = procesador.texto_log_accion_hecho_objetivo_principal_inicial;
            textBox_medio_accion_hecho_objetivo_principal.Text = procesador.texto_log_accion_hecho_objetivo_principal_final;

            textBox_inicial_accion_hecho_objetivo_actual.Text = procesador.texto_log_accion_hecho_objetivo_actual_inicial;
            textBox_medio_accion_hecho_objetivo_actual.Text = procesador.texto_log_accion_hecho_objetivo_actual_final;

            textBox_inicial_accion_quitando_hecho_pila_objetivos.Text = procesador.texto_log_accion_quitando_hecho_de_pila_objetivos_inicial;
            textBox_medio_accion_quitando_hecho_pila_objetivos.Text = procesador.texto_log_accion_quitando_hecho_de_pila_objetivos_final;

            textBox_inicial_accion_procesando_respuesta.Text = procesador.texto_log_accion_procesando_respuesta_inicial;
            textBox_medio_accion_procesando_respuesta.Text = procesador.texto_log_accion_procesando_respuesta_medio;

            textBox_inicial_accion_validando_regla.Text = procesador.texto_log_accion_validando_regla_inicial;
            textBox_medio_accion_validando_regla.Text = procesador.texto_log_accion_validando_regla_final;

            textBox_inicial_info_sin_reglas_para_inferir_hecho.Text = procesador.texto_log_info_sin_reglas_para_inferir_hecho_inicial;
            textBox_medio_info_sin_reglas_para_inferir_hecho.Text = procesador.texto_log_info_sin_reglas_para_inferir_hecho_final;

            textBox_inicial_info_var_conocida.Text = procesador.texto_log_info_variable_conocida_inicial;
            textBox_medio_info_var_conocida.Text = procesador.texto_log_info_variable_conocida_final;


            textBox_info_consultando_hechos.Text = procesador.texto_log_info_consultando_hechos;
            textBox_info_analizando_hechos_inferidos_regla.Text = procesador.texto_log_info_analizando_hechos_inferidos_regla;
            textBox_info_regla_validada.Text = procesador.texto_log_info_regla_validada;
            textBox_info_regla_no_validada.Text = procesador.texto_log_info_regla_no_validada;
            textBox_info_descartando_reglas_de_igual_consecuente.Text = procesador.texto_log_info_descartando_reglas_de_igual_consecuente;
            textBox_info_problema_solucionado.Text = procesador.texto_log_info_problema_solucionado;
            textBox_info_problema_no_solucionado.Text = procesador.texto_log_info_problema_no_solucionado;
            textBox_info_continuando_proceso.Text = procesador.texto_log_info_continuando_proceso;
            textBox_info_proceso_detenido.Text = procesador.texto_log_info_proceso_detenido;
            textBox_info_termino_inferencia_reglas_agotadas.Text = procesador.texto_log_info_termino_de_inferencia_reglas_agotadas;

            //Mostrando checks

            checkBox_log_info.Checked =  procesador.mostrar_log_info ;
            checkBox_log_variable.Checked = procesador.mostrar_log_variable;
            checkBox_log_hecho.Checked = procesador.mostrar_log_hecho;
            checkBox_log_regla.Checked = procesador.mostrar_log_regla;
            checkBox_nivel_hecho.Checked = procesador.mostrar_log_nivel_hecho;
            checkBox_accion_mover_hecho.Checked = procesador.mostrar_log_accion_mover_hecho;
            checkBox_accion_mover_regla.Checked = procesador.mostrar_log_accion_mover_regla;
            checkBox_accion_ingresando_a_var_conocida.Checked = procesador.mostrar_log_accion_ingresando_a_variables_conocidas;
            checkBox_accion_elegida_mejor_regla.Checked = procesador.mostrar_log_accion_elegida_mejor_regla;
            checkBox_accion_consultando_hecho.Checked = procesador.mostrar_log_accion_consultando_hecho;
            checkBox_accion_ingresando_hecho_a_pila_de_objetivos.Checked = procesador.mostrar_log_accion_ingresando_hecho_a_pila_objetivos;
            checkBox_accion_hecho_objetivo_principal.Checked = procesador.mostrar_log_accion_hecho_objetivo_principal;
            checkBox_accion_hecho_objetivo_actual.Checked = procesador.mostrar_log_accion_hecho_objetivo_actual;
            checkBox_accion_quitando_hecho_pila_objetivos.Checked = procesador.mostrar_log_accion_quitando_hecho_de_pila_objetivos;
            checkBox_accion_procesando_respuesta.Checked = procesador.mostrar_log_accion_procesando_respuesta;
            checkBox_accion_validando_regla.Checked = procesador.mostrar_log_accion_validando_regla;
            checkBox_info_sin_reglas_para_inferir_hecho.Checked = procesador.mostrar_log_info_sin_reglas_para_inferir_hecho;
            checkBox_info_var_conocida.Checked = procesador.mostrar_log_info_variable_conocida;
            checkBox_info_consultando_hechos.Checked = procesador.mostrar_log_info_consultando_hechos;
            checkBox_info_analizando_hechos_inferidos_regla.Checked = procesador.mostrar_log_info_analizando_hechos_inferidos_regla;
            checkBox_info_regla_validada.Checked = procesador.mostrar_log_info_regla_validada;
            checkBox_info_regla_no_validada.Checked = procesador.mostrar_log_info_regla_no_validada;
            checkBox_info_descartando_reglas_de_igual_consecuente.Checked = procesador.mostrar_log_info_descartando_reglas_de_igual_consecuente;
            checkBox_info_problema_solucionado.Checked = procesador.mostrar_log_info_problema_solucionado;
            checkBox_info_problema_no_solucionado.Checked = procesador.mostrar_log_info_problema_no_solucionado;
            checkBox_info_continuando_proceso.Checked = procesador.mostrar_log_info_continuando_proceso;
            checkBox_info_proceso_detenido.Checked = procesador.mostrar_log_info_proceso_detenido;
            checkBox_info_termino_inferencia_reglas_agotadas.Checked = procesador.mostrar_log_info_termino_de_inferencia_reglas_agotadas;

        }
        
        public ProcesadorLoggeoInferencia extraerConfiguracionLoggeo()
        {
            ProcesadorLoggeoInferencia procesador = new ProcesadorLoggeoInferencia();
            if(radioButton_variable_id.Checked)
                procesador.formato_variables = ProcesadorLoggeoInferencia.FORMATO_SOLO_ID;
            else
            if(radioButton_variable_contenido.Checked)
                procesador.formato_variables = ProcesadorLoggeoInferencia.FORMATO_SOLO_CONTENIDO;
            else
             
            if(radioButton_variable_id_contenido.Checked)
                procesador.formato_variables = ProcesadorLoggeoInferencia.FORMATO_ID_MAS_CONTENIDO;
            
 
            if(radioButton_hecho_id.Checked)
                procesador.formato_hechos = ProcesadorLoggeoInferencia.FORMATO_SOLO_ID;
            else
            if(radioButton_hecho_contenido.Checked)
                procesador.formato_hechos = ProcesadorLoggeoInferencia.FORMATO_SOLO_CONTENIDO;
            else
            if(radioButton_hecho_id_contenido.Checked)
                procesador.formato_hechos = ProcesadorLoggeoInferencia.FORMATO_ID_MAS_CONTENIDO;

            
            if(radioButton_regla_id.Checked)
                procesador.formato_reglas = ProcesadorLoggeoInferencia.FORMATO_SOLO_ID;
            else
            if(radioButton_regla_contenido.Checked)
                procesador.formato_reglas = ProcesadorLoggeoInferencia.FORMATO_SOLO_CONTENIDO;
            else
            if(radioButton_regla_id_contenido.Checked)
                procesador.formato_reglas = ProcesadorLoggeoInferencia.FORMATO_ID_MAS_CONTENIDO;
                        
            //Mostrando textos 

            procesador.texto_reglas_disponibles = textBox_texto_reglas_disponibles.Text ;	
            procesador.texto_reglas_candidatas = textBox_texto_reglas_candidatas.Text ;
            procesador.texto_reglas_eliminadas = textBox_texto_reglas_eliminadas.Text ;
            procesador.texto_hechos_disponibles = textBox_texto_hechos_disponibles.Text ;
            procesador.texto_hechos_verdaderos = textBox_texto_hechos_verdaderos.Text ;			
            procesador.texto_hechos_falsos = textBox_texto_hechos_falsos.Text ;	
                       
            procesador.texto_log_accion_mover_hecho_inicial = textBox_inicial_mover_hecho.Text ;
            procesador.texto_log_accion_mover_hecho_central = textBox_medio_mover_hecho.Text ;				
            procesador.texto_log_accion_mover_hecho_final = textBox_final_mover_hecho.Text ;			

            procesador.texto_log_accion_mover_regla_inicial = textBox_inicial_mover_regla.Text ;
            procesador.texto_log_accion_mover_regla_central = textBox_medio_mover_regla.Text ;				
            procesador.texto_log_accion_mover_regla_final = textBox_final_mover_regla.Text ;			

            procesador.texto_log_accion_ingresando_a_variables_conocidas_inicial = textBox_inicial_ingresando_a_var_conocida.Text ;			
            procesador.texto_log_accion_ingresando_a_variables_conocidas_final = textBox_medio_ingresando_a_var_conocida.Text ;

            procesador.texto_log_accion_elegida_mejor_regla_inicial = textBox_inicial_accion_elegida_mejor_regla.Text ;		
            procesador.texto_log_accion_elegida_mejor_regla_final = textBox_medio_accion_elegida_mejor_regla.Text ;				 

            procesador.texto_log_accion_consultando_hechos_inicial = textBox_inicial_accion_consultando_hechos.Text ;
            procesador.texto_log_accion_consultando_hechos_final = textBox_medio_accion_consultando_hechos.Text ;				 

            procesador.texto_log_accion_ingresando_hecho_a_pila_objetivos_inicial = textBox_inicial_accion_ingresando_hecho_a_pila_de_objetivos.Text ;
            procesador.texto_log_accion_ingresando_hecho_a_pila_objetivos_final = textBox_medio_accion_ingresando_hecho_a_pila_de_objetivos.Text ;				 

            procesador.texto_log_accion_hecho_objetivo_principal_inicial = textBox_inicial_accion_hecho_objetivo_principal.Text ;
            procesador.texto_log_accion_hecho_objetivo_principal_final = textBox_medio_accion_hecho_objetivo_principal.Text ;				 

            procesador.texto_log_accion_hecho_objetivo_actual_inicial = textBox_inicial_accion_hecho_objetivo_actual.Text ;			
            procesador.texto_log_accion_hecho_objetivo_actual_final = textBox_medio_accion_hecho_objetivo_actual.Text ;				 

            procesador.texto_log_accion_quitando_hecho_de_pila_objetivos_inicial = textBox_inicial_accion_quitando_hecho_pila_objetivos.Text ;
            procesador.texto_log_accion_quitando_hecho_de_pila_objetivos_final = textBox_medio_accion_quitando_hecho_pila_objetivos.Text ;				 

            procesador.texto_log_accion_procesando_respuesta_inicial = textBox_inicial_accion_procesando_respuesta.Text ;	
            procesador.texto_log_accion_procesando_respuesta_medio = textBox_medio_accion_procesando_respuesta.Text ;				 

            procesador.texto_log_accion_validando_regla_inicial = textBox_inicial_accion_validando_regla.Text ;			
            procesador.texto_log_accion_validando_regla_final = textBox_medio_accion_validando_regla.Text ;				

            procesador.texto_log_info_sin_reglas_para_inferir_hecho_inicial = textBox_inicial_info_sin_reglas_para_inferir_hecho.Text ;
            procesador.texto_log_info_sin_reglas_para_inferir_hecho_final = textBox_medio_info_sin_reglas_para_inferir_hecho.Text ;				

            procesador.texto_log_info_variable_conocida_inicial = textBox_inicial_info_var_conocida.Text ;			
            procesador.texto_log_info_variable_conocida_final = textBox_medio_info_var_conocida.Text ;				


            procesador.texto_log_info_consultando_hechos = textBox_info_consultando_hechos.Text ;				 
            procesador.texto_log_info_analizando_hechos_inferidos_regla = textBox_info_analizando_hechos_inferidos_regla.Text ;
            procesador.texto_log_info_regla_validada = textBox_info_regla_validada.Text ;				 
            procesador.texto_log_info_regla_no_validada = textBox_info_regla_no_validada.Text ;		
            procesador.texto_log_info_descartando_reglas_de_igual_consecuente = textBox_info_descartando_reglas_de_igual_consecuente.Text ;
            procesador.texto_log_info_problema_solucionado = textBox_info_problema_solucionado.Text ;				 
            procesador.texto_log_info_problema_no_solucionado = textBox_info_problema_no_solucionado.Text ;	
            procesador.texto_log_info_continuando_proceso = textBox_info_continuando_proceso.Text ;				
            procesador.texto_log_info_proceso_detenido = textBox_info_proceso_detenido.Text ;		
            procesador.texto_log_info_termino_de_inferencia_reglas_agotadas = textBox_info_termino_inferencia_reglas_agotadas.Text ;

            //Mostrando checks

            procesador.mostrar_log_info  = checkBox_log_info.Checked ;				  
            procesador.mostrar_log_variable = checkBox_log_variable.Checked ;
            procesador.mostrar_log_hecho = checkBox_log_hecho.Checked ;	
            procesador.mostrar_log_regla = checkBox_log_regla.Checked ;				
            procesador.mostrar_log_nivel_hecho = checkBox_nivel_hecho.Checked ;	
            procesador.mostrar_log_accion_mover_hecho = checkBox_accion_mover_hecho.Checked ;				
            procesador.mostrar_log_accion_mover_regla = checkBox_accion_mover_regla.Checked ;		
            procesador.mostrar_log_accion_ingresando_a_variables_conocidas = checkBox_accion_ingresando_a_var_conocida.Checked ;	
            procesador.mostrar_log_accion_elegida_mejor_regla = checkBox_accion_elegida_mejor_regla.Checked ;			
            procesador.mostrar_log_accion_consultando_hecho = checkBox_accion_consultando_hecho.Checked ;				
            procesador.mostrar_log_accion_ingresando_hecho_a_pila_objetivos = checkBox_accion_ingresando_hecho_a_pila_de_objetivos.Checked ;
            procesador.mostrar_log_accion_hecho_objetivo_principal = checkBox_accion_hecho_objetivo_principal.Checked ;			
            procesador.mostrar_log_accion_hecho_objetivo_actual = checkBox_accion_hecho_objetivo_actual.Checked ;				
            procesador.mostrar_log_accion_quitando_hecho_de_pila_objetivos = checkBox_accion_quitando_hecho_pila_objetivos.Checked ;	
            procesador.mostrar_log_accion_procesando_respuesta = checkBox_accion_procesando_respuesta.Checked ;		
            procesador.mostrar_log_accion_validando_regla = checkBox_accion_validando_regla.Checked ;			
            procesador.mostrar_log_info_sin_reglas_para_inferir_hecho = checkBox_info_sin_reglas_para_inferir_hecho.Checked ;		
            procesador.mostrar_log_info_variable_conocida = checkBox_info_var_conocida.Checked ;				 
            procesador.mostrar_log_info_consultando_hechos = checkBox_info_consultando_hechos.Checked ;		
            procesador.mostrar_log_info_analizando_hechos_inferidos_regla = checkBox_info_analizando_hechos_inferidos_regla.Checked ;
            procesador.mostrar_log_info_regla_validada = checkBox_info_regla_validada.Checked ;				
            procesador.mostrar_log_info_regla_no_validada = checkBox_info_regla_no_validada.Checked ;		
            procesador.mostrar_log_info_descartando_reglas_de_igual_consecuente = checkBox_info_descartando_reglas_de_igual_consecuente.Checked ;
            procesador.mostrar_log_info_problema_solucionado = checkBox_info_problema_solucionado.Checked ;				
            procesador.mostrar_log_info_problema_no_solucionado = checkBox_info_problema_no_solucionado.Checked ;		
            procesador.mostrar_log_info_continuando_proceso = checkBox_info_continuando_proceso.Checked ;				
            procesador.mostrar_log_info_proceso_detenido = checkBox_info_proceso_detenido.Checked ;
            procesador.mostrar_log_info_termino_de_inferencia_reglas_agotadas = checkBox_info_termino_inferencia_reglas_agotadas.Checked;


            return procesador;
        }

        private void FormVentanaConfiguracionLogInferencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Usted desea guardar los cambios realizados?", "Configuración de loggeo inferencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                configuracion_interna.ingresarProcesadorDeLoggeo(extraerConfiguracionLoggeo());
                this.Visible = false;
            }
            else
            if (result == DialogResult.No)
            {
                this.Visible = false;
            }
            e.Cancel = true;
        }

        private void button_por_defecto_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se volveran los campos a sus valores por defecto\n Usted desea continuar?", "Configuración de loggeo inferencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                mostrarConfiguracionProcesadorLoggeo(new ProcesadorLoggeoInferencia());
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Usted desea guardar los cambios realizados?", "Configuración de loggeo inferencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                configuracion_interna.ingresarProcesadorDeLoggeo(extraerConfiguracionLoggeo());
                this.Visible = false;
            }
            else
            if (result == DialogResult.No)
            {
                this.Visible = false;
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            
        }


    }
}
