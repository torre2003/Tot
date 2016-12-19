using SistemaExpertoLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tot
{
    public partial class FormVentanaConfiguracionLogInferencia : Form
    {
        GestionConfiguracionInternaTot configuracion_interna = new GestionConfiguracionInternaTot();
        ProcesadorLogInferencia procesador_historico = new ProcesadorLogInferencia();
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

        public void mostrarConfiguracionProcesadorLoggeo(ProcesadorLogInferencia procesador)
        {
            procesador_historico = procesador;
            switch (procesador.formato_variables)
            {
                case ProcesadorLogInferencia.FORMATO_SOLO_ID:
                    radioButton_variable_id.Checked = true;
                    break;
                case ProcesadorLogInferencia.FORMATO_SOLO_CONTENIDO:
                    radioButton_variable_contenido.Checked = true;
                    break;
                case ProcesadorLogInferencia.FORMATO_ID_MAS_CONTENIDO:
                    radioButton_variable_id_contenido.Checked = true;
                    break;
            }
            
            switch (procesador.formato_hechos)
            {
                case ProcesadorLogInferencia.FORMATO_SOLO_ID:
                    radioButton_hecho_id.Checked = true;
                    break;
                case ProcesadorLogInferencia.FORMATO_SOLO_CONTENIDO:
                    radioButton_hecho_contenido.Checked = true;
                    break;
                case ProcesadorLogInferencia.FORMATO_ID_MAS_CONTENIDO:
                    radioButton_hecho_id_contenido.Checked = true;
                    break;
            }

            switch (procesador.formato_reglas)
            {
                case ProcesadorLogInferencia.FORMATO_SOLO_ID:
                    radioButton_regla_id.Checked = true;
                    break;
                case ProcesadorLogInferencia.FORMATO_SOLO_CONTENIDO:
                    radioButton_regla_contenido.Checked = true;
                    break;
                case ProcesadorLogInferencia.FORMATO_ID_MAS_CONTENIDO:
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
            textBox_info_consultando_variables_inicio.Text = procesador.texto_log_info_consultando_variables_de_inicio;
            textBox_info_procesando_hechos_asociados.Text = procesador.texto_log_info_procesando_hechos_asociados;
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
            checkBox_info_consultando_variables_inicio.Checked = procesador.mostrar_log_info_consultando_variables_de_inicio;
            checkBox_info_procesando_hechos_asociados.Checked = procesador.mostrar_log_info_procesando_hechos_asociados;

        }
        
        public ProcesadorLogInferencia extraerConfiguracionLoggeo()
        {
            ProcesadorLogInferencia procesador = new ProcesadorLogInferencia();
            if(radioButton_variable_id.Checked)
                procesador.formato_variables = ProcesadorLogInferencia.FORMATO_SOLO_ID;
            else
            if(radioButton_variable_contenido.Checked)
                procesador.formato_variables = ProcesadorLogInferencia.FORMATO_SOLO_CONTENIDO;
            else
             
            if(radioButton_variable_id_contenido.Checked)
                procesador.formato_variables = ProcesadorLogInferencia.FORMATO_ID_MAS_CONTENIDO;
            
 
            if(radioButton_hecho_id.Checked)
                procesador.formato_hechos = ProcesadorLogInferencia.FORMATO_SOLO_ID;
            else
            if(radioButton_hecho_contenido.Checked)
                procesador.formato_hechos = ProcesadorLogInferencia.FORMATO_SOLO_CONTENIDO;
            else
            if(radioButton_hecho_id_contenido.Checked)
                procesador.formato_hechos = ProcesadorLogInferencia.FORMATO_ID_MAS_CONTENIDO;

            
            if(radioButton_regla_id.Checked)
                procesador.formato_reglas = ProcesadorLogInferencia.FORMATO_SOLO_ID;
            else
            if(radioButton_regla_contenido.Checked)
                procesador.formato_reglas = ProcesadorLogInferencia.FORMATO_SOLO_CONTENIDO;
            else
            if(radioButton_regla_id_contenido.Checked)
                procesador.formato_reglas = ProcesadorLogInferencia.FORMATO_ID_MAS_CONTENIDO;
                        
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
            procesador.texto_log_info_consultando_variables_de_inicio = textBox_info_consultando_variables_inicio.Text;
            procesador.texto_log_info_procesando_hechos_asociados = textBox_info_procesando_hechos_asociados.Text;
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
            procesador.mostrar_log_info_consultando_variables_de_inicio = checkBox_info_consultando_variables_inicio.Checked;
            procesador.mostrar_log_info_procesando_hechos_asociados = checkBox_info_procesando_hechos_asociados.Checked;
            return procesador;
        }

        private void FormVentanaConfiguracionLogInferencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (procesador_historico != null)
                if (!procesador_historico.Equals(extraerConfiguracionLoggeo()))
                {
                    DialogResult result = MessageBox.Show("Usted desea guardar los cambios realizados?", "Configuración de loggeo inferencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        configuracion_interna.ingresarProcesadorDeLoggeo(extraerConfiguracionLoggeo());
                        this.Visible = false;
                        procesador_historico = null;
                    }
                    else
                        if (result == DialogResult.No)
                        {
                            this.Visible = false;
                            procesador_historico = null;
                        }
                }
                else
                {
                    this.Visible = false;
                    procesador_historico = null;
                }
            e.Cancel = true;
        }

        private void button_por_defecto_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se volveran los campos a sus valores por defecto\n Usted desea continuar?", "Configuración de loggeo inferencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                mostrarConfiguracionProcesadorLoggeo(new ProcesadorLogInferencia());
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (!procesador_historico.Equals(extraerConfiguracionLoggeo()))
            {
                DialogResult result = MessageBox.Show("Usted desea guardar los cambios realizados?", "Configuración de loggeo inferencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    configuracion_interna.ingresarProcesadorDeLoggeo(extraerConfiguracionLoggeo());
                    this.Visible = false;
                    procesador_historico = null;
                }
                else
                    if (result == DialogResult.No)
                    {
                        this.Visible = false;
                        procesador_historico = null;
                    }
            }
            else
            {
                this.Visible = false;
                procesador_historico = null;
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            procesador_historico = null;
        }

        private void button_importar_Click(object sender, EventArgs e)
        {
            string archivo_configuracion = configuracion_interna.ruta_archivos_configuracion + configuracion_interna.archivo_configuracion_log;
            System.Windows.Forms.OpenFileDialog openFileDialog_guardar_log = new OpenFileDialog();
            openFileDialog_guardar_log.DefaultExt = "conf";
            openFileDialog_guardar_log.Filter = "Archivos de configuración |*.conf;";
            openFileDialog_guardar_log.InitialDirectory = "Environment.SpecialFolder.Desktop";

            if (openFileDialog_guardar_log.ShowDialog() == DialogResult.OK)
            {
                File.Copy(openFileDialog_guardar_log.FileName, archivo_configuracion, true);
                mostrarConfiguracionProcesadorLoggeo(configuracion_interna.extraerProcesadorDeLoggeo());
                MessageBox.Show("Configuracíón importada y guardada correctamente.", "Importando configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_exportar_Click(object sender, EventArgs e)
        {
            if (configuracion_interna.existe_archivo_configuracion)
            {
                string archivo_configuracion = configuracion_interna.ruta_archivos_configuracion + configuracion_interna.archivo_configuracion_log;
                System.Windows.Forms.SaveFileDialog saveFileDialog_guardar_log = new SaveFileDialog();
                saveFileDialog_guardar_log.DefaultExt = "conf";
                saveFileDialog_guardar_log.Filter = "Archivos de configuración |*.conf;";
                saveFileDialog_guardar_log.InitialDirectory = "Environment.SpecialFolder.Desktop";

                if (saveFileDialog_guardar_log.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(archivo_configuracion, saveFileDialog_guardar_log.FileName, true);
                    MessageBox.Show("Configuracíón exportada correctamente.", "Exportando configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


    }
}
