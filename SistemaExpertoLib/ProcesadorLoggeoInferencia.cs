using SistemaExpertoLib.MotorDeInferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib
{
    [Serializable()]
    public class ProcesadorLoggeoInferencia
    {
        //--------------------------------------------------------------------------------------------
        //     Atributos
        //--------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Se muestra solo la id del atributo en cuestión
        /// </summary>
        public const int FORMATO_SOLO_ID = 1;
        /// <summary>
        /// Se muestra la id y el contenido del atributo en cuestión
        /// </summary>
        public const int FORMATO_ID_MAS_CONTENIDO = 2;
        /// <summary>
        /// Se muestra solo el contenido del atributo en cuestión
        /// </summary>
        public const int FORMATO_SOLO_CONTENIDO = 3;

        #region FORMATOS
        /// <summary>
        /// Obtiene o establece el formato con que se mostrar las variables al ser procesada, según constantes FORMATO
        /// (FORMATO_SOLO_ID , FORMATO_ID_MAS_CONTENIDO, FORMATO_SOLO_CONTENIDO)
        /// </summary>
        public int formato_variables
        {
            get
            {
                return _formato_variables;
            }
            set
            {
                if (!(value == FORMATO_SOLO_ID || value == FORMATO_SOLO_CONTENIDO || value == FORMATO_ID_MAS_CONTENIDO))
                    throw new System.ArgumentException("Argumentos de formato INVALIDO", "formato variables");
                _formato_variables = value;
            }
        }
        int _formato_variables = FORMATO_SOLO_ID;

        /// <summary>
        /// Obtiene o establece el formato con que se mostrar los hechos al ser procesada, según constantes FORMATO
        /// (FORMATO_SOLO_ID , FORMATO_ID_MAS_CONTENIDO, FORMATO_SOLO_CONTENIDO)
        /// </summary>
        public int formato_hechos
        {
            get
            {
                return _formato_hecho;
            }
            set
            {
                if (!(value == FORMATO_SOLO_ID || value == FORMATO_SOLO_CONTENIDO || value == FORMATO_ID_MAS_CONTENIDO))
                    throw new System.ArgumentException("Argumentos de formato INVALIDO", "formato hechos");
                _formato_hecho = value;
            }
        }
        int _formato_hecho = FORMATO_SOLO_ID;

        /// <summary>
        /// Obtiene o establece el formato con que se mostrarar las reglas al ser procesada, según constantes FORMATO
        /// (FORMATO_SOLO_ID , FORMATO_ID_MAS_CONTENIDO, FORMATO_SOLO_CONTENIDO)
        /// </summary>
        public int formato_reglas
        {
            get
            {
                return _formato_reglas;
            }
            set
            {
                if (!(value == FORMATO_SOLO_ID || value == FORMATO_SOLO_CONTENIDO || value == FORMATO_ID_MAS_CONTENIDO))
                    throw new System.ArgumentException("Argumentos de formato INVALIDO", "formato variables");
                _formato_reglas = value;
            }
        }
        int _formato_reglas = FORMATO_SOLO_ID;
        #endregion
        #region TEXTOS
        //Textos a utilizar

        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_reglas_disponibles { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_reglas_candidatas { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_reglas_eliminadas { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_hechos_disponibles { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_hechos_verdaderos { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_hechos_falsos { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_log_info { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_log_variable { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_log_hecho { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_log_regla { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log 
        /// </summary>
        public string texto_log_nivel_hecho { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_central TIPO_LISTA texto_final TIPO_LISTA
        /// </summary>
        public string texto_log_accion_mover_hecho_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_central TIPO_LISTA texto_final TIPO_LISTA
        /// </summary>
        public string texto_log_accion_mover_hecho_central { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_central TIPO_LISTA texto_final TIPO_LISTA
        /// </summary>
        public string texto_log_accion_mover_hecho_final { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial REGLA texto_central TIPO_LISTA texto_final TIPO_LISTA
        /// </summary>
        public string texto_log_accion_mover_regla_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial REGLA texto_central TIPO_LISTA texto_final TIPO_LISTA
        /// </summary>
        public string texto_log_accion_mover_regla_central { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial REGLA texto_central TIPO_LISTA texto_final TIPO_LISTA
        /// </summary>
        public string texto_log_accion_mover_regla_final { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial VARIABLE texto_final
        /// </summary>
        public string texto_log_accion_ingresando_a_variables_conocidas_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial VARIABLE texto_final
        /// </summary>
        public string texto_log_accion_ingresando_a_variables_conocidas_final { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial REGLA texto_final
        /// </summary>
        public string texto_log_accion_elegida_mejor_regla_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial REGLA texto_final
        /// </summary>
        public string texto_log_accion_elegida_mejor_regla_final { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_final
        /// </summary>
        public string texto_log_accion_consultando_hechos_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_final
        /// </summary>
        public string texto_log_accion_consultando_hechos_final { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_final
        /// </summary>
        public string texto_log_accion_ingresando_hecho_a_pila_objetivos_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_final
        /// </summary>
        public string texto_log_accion_ingresando_hecho_a_pila_objetivos_final { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto final
        /// si mostrar nivel, se corre el texto con tabulaciones según le nivel
        /// </summary>
        public string texto_log_accion_hecho_objetivo_principal_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto final
        /// si mostrar nivel, se corre el texto con tabulaciones según le nivel
        /// </summary>
        public string texto_log_accion_hecho_objetivo_principal_final { get; set; }        
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto final
        /// si mostrar nivel, se corre el texto con tabulaciones según le nivel
        /// </summary>
        public string texto_log_accion_hecho_objetivo_actual_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto final
        /// si mostrar nivel, se corre el texto con tabulaciones según le nivel
        /// </summary>
        public string texto_log_accion_hecho_objetivo_actual_final { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_final
        /// </summary>
        public string texto_log_accion_quitando_hecho_de_pila_objetivos_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_final
        /// </summary>
        public string texto_log_accion_quitando_hecho_de_pila_objetivos_final { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_incial VARIABLE texto_medio VALOR
        /// </summary>
        public string texto_log_accion_procesando_respuesta_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_incial VARIABLE texto_medio VALOR
        /// </summary>
        public string texto_log_accion_procesando_respuesta_medio { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial REGLA texto_final
        /// </summary>
        public string texto_log_accion_validando_regla_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial REGLA texto_final
        /// </summary>
        public string texto_log_accion_validando_regla_final { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_final
        /// </summary>
        public string texto_log_info_sin_reglas_para_inferir_hecho_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial HECHO texto_final
        /// </summary>
        public string texto_log_info_sin_reglas_para_inferir_hecho_final { get; set; }
        //-----------------------------------------------------------------------
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial VARIABLE texto_final
        /// </summary>
        public string texto_log_info_variable_conocida_inicial { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto_inicial VARIABLE texto_final
        /// </summary>
        public string texto_log_info_variable_conocida_final { get; set; }
        //-----------------------------------------------------------------------

        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_consultando_hechos { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_analizando_hechos_inferidos_regla { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_regla_validada { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_regla_no_validada { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_descartando_reglas_de_igual_consecuente { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_problema_solucionado { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_problema_no_solucionado { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_continuando_proceso { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_proceso_detenido { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_termino_de_inferencia_reglas_agotadas { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_consultando_variables_de_inicio { get; set; }
        /// <summary>
        /// Obtiene o establece
        /// texto log info info
        /// </summary>
        public string texto_log_info_procesando_hechos_asociados { get; set; }


        #endregion 
        //Establece que información se muestra en el procesamiento 
        #region MOSTRAR INFO
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_variable { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_hecho { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_regla { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_nivel_hecho { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_mover_hecho { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_mover_regla { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_ingresando_a_variables_conocidas { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_elegida_mejor_regla { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_consultando_hecho { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_ingresando_hecho_a_pila_objetivos { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_hecho_objetivo_principal { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_hecho_objetivo_actual { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_quitando_hecho_de_pila_objetivos { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_procesando_respuesta { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_accion_validando_regla { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_sin_reglas_para_inferir_hecho { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_variable_conocida { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_consultando_hechos { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_analizando_hechos_inferidos_regla { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_regla_validada { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_regla_no_validada { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_descartando_reglas_de_igual_consecuente { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_problema_solucionado { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_problema_no_solucionado { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_continuando_proceso { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_proceso_detenido { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_termino_de_inferencia_reglas_agotadas { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_consultando_variables_de_inicio { get; set; }
        /// <summary>
        /// Obtiene o establece si el tipo de loggeo debe mostrarse al procesarse
        /// </summary>
        public bool mostrar_log_info_procesando_hechos_asociados { get; set; }

        
        
        #endregion
        public MotorDeInferencia.LecturaBaseConocimiento base_conocimiento;

        /// <summary>
        /// Ruta de la base conocimiento especificada
        /// </summary>
        public string ruta_base_conocimiento
        {
            get
            {
                return base_conocimiento.ruta_base_conocimiento;
            }
            set
            {
                base_conocimiento.ruta_base_conocimiento = value;
            }
        }
        //--------------------------------------------------------------------------------------------
        //     Métodos
        //--------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ProcesadorLoggeoInferencia()
        {
            textoLogPorDefecto();
            mostrarInfosPorDefecto();
            base_conocimiento = new MotorDeInferencia.LecturaBaseConocimiento();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ruta_base_conocimiento">Ruta de la base de conocimiento</param>
        public ProcesadorLoggeoInferencia(string ruta_base_conocimiento)
        {
            textoLogPorDefecto();
            mostrarInfosPorDefecto();
            base_conocimiento = new MotorDeInferencia.LecturaBaseConocimiento(ruta_base_conocimiento);
        }
        
        /// <summary>
        /// Método que establece los atributos texto a su valor por defecto.
        /// </summary>
        public void textoLogPorDefecto()
        {

            texto_reglas_disponibles        = "Reglas Disponibles";
            texto_reglas_candidatas         = "Reglas Candidatas";
            texto_reglas_eliminadas         = "Reglas Eliminadas";
            texto_hechos_disponibles        = "Hechos Disponibles";
            texto_hechos_verdaderos         = "Hechos Verdaderos";
            texto_hechos_falsos             = "Hechos Falsos";

            texto_log_info                  = "información";
            texto_log_variable              = "Variable";
            texto_log_hecho                 = "Hecho";
            texto_log_regla                 = "Regla";
            texto_log_nivel_hecho           = "Nivel";
            
            texto_log_accion_mover_hecho_inicial    = "Moviendo hecho";
            texto_log_accion_mover_hecho_central    = " de ";
            texto_log_accion_mover_hecho_final      = "a";

            texto_log_accion_mover_regla_inicial    = "Moviendo regla";
            texto_log_accion_mover_regla_central    = " de ";
            texto_log_accion_mover_regla_final      = "a";
            
            texto_log_accion_ingresando_a_variables_conocidas_inicial   = "Ingresando";
            texto_log_accion_ingresando_a_variables_conocidas_final     = "a variables conocidas";

            texto_log_accion_elegida_mejor_regla_inicial                = "";
            texto_log_accion_elegida_mejor_regla_final                  = "elegida mejor regla.";

            texto_log_accion_consultando_hechos_inicial                 = "Consultando hecho";
            texto_log_accion_consultando_hechos_final                   = "";
            
            texto_log_accion_ingresando_hecho_a_pila_objetivos_inicial  = "Ingresando hecho";
            texto_log_accion_ingresando_hecho_a_pila_objetivos_final    = "a pila";

            texto_log_accion_hecho_objetivo_principal_inicial           = "Se ha seleccionado el hecho";
            texto_log_accion_hecho_objetivo_principal_final             = "como objetivo principal";

            texto_log_accion_hecho_objetivo_actual_inicial              = "Se ha seleccionado el hecho";
            texto_log_accion_hecho_objetivo_actual_final                = "como objetivo actual";
            
            texto_log_accion_quitando_hecho_de_pila_objetivos_inicial   = "Quitando hecho";
            texto_log_accion_quitando_hecho_de_pila_objetivos_final     = " de la pila de objetivos";

            texto_log_accion_procesando_respuesta_inicial               = "Procesando respuesta variable ";
            texto_log_accion_procesando_respuesta_medio                 = "valor = ";

            texto_log_accion_validando_regla_inicial                    = "Validando la regla";
            texto_log_accion_validando_regla_final                      = "";


            texto_log_info_sin_reglas_para_inferir_hecho_inicial        = "Sin reglas para inferir hecho";
            texto_log_info_sin_reglas_para_inferir_hecho_final          = "";
            
            texto_log_info_variable_conocida_inicial                    = "Variable";
            texto_log_info_variable_conocida_final                      = "conocida";
            
            
            texto_log_info_consultando_hechos                           = "Consultando hechos";
            texto_log_info_analizando_hechos_inferidos_regla            = "Analizando hechos inferidos";
            texto_log_info_regla_validada                               = "La regla ha sido validada por el usuario ";
            texto_log_info_regla_no_validada                            = "La regla NO fue validada por el usuario";
            texto_log_info_descartando_reglas_de_igual_consecuente      = "Descartando reglas de igual consecuente";
            texto_log_info_problema_solucionado                         = "El problema se soluciono satisfactoriamente";
            texto_log_info_problema_no_solucionado                      = "El problema NO se ha solucionado";
            texto_log_info_continuando_proceso                          = "continuando proceso de inferencia";
            texto_log_info_proceso_detenido                             = "proceso detenido por usuario";
            texto_log_info_termino_de_inferencia_reglas_agotadas        = "Proceso terminado, no existen mas reglas en la base de conocimiento.";
            texto_log_info_consultando_variables_de_inicio              = "Consultando variables de inicio.";
            texto_log_info_procesando_hechos_asociados                  = "Procesando hechos asociados";
        }

        /// <summary>
        /// Método que establece los atributs de infos a mostrar a sus valores por defecto
        /// </summary>
        public void mostrarInfosPorDefecto()
        {

            mostrar_log_info = true;
            mostrar_log_variable = true;
            mostrar_log_hecho = true;
            mostrar_log_regla = true;
            mostrar_log_nivel_hecho = true;
            mostrar_log_accion_mover_hecho = true;
            mostrar_log_accion_mover_regla = true;
            mostrar_log_accion_ingresando_a_variables_conocidas = true;
            mostrar_log_accion_elegida_mejor_regla = true;
            mostrar_log_accion_consultando_hecho = true;
            mostrar_log_accion_ingresando_hecho_a_pila_objetivos = true;
            mostrar_log_accion_hecho_objetivo_principal = true;
            mostrar_log_accion_hecho_objetivo_actual = true;
            mostrar_log_accion_quitando_hecho_de_pila_objetivos = true;
            mostrar_log_accion_procesando_respuesta = true;
            mostrar_log_accion_validando_regla = true;
            mostrar_log_info_sin_reglas_para_inferir_hecho = true;
            mostrar_log_info_variable_conocida = true;
            mostrar_log_info_consultando_hechos = true;
            mostrar_log_info_analizando_hechos_inferidos_regla = true;
            mostrar_log_info_regla_validada = true;
            mostrar_log_info_regla_no_validada = true;
            mostrar_log_info_descartando_reglas_de_igual_consecuente = true;
            mostrar_log_info_problema_solucionado = true;
            mostrar_log_info_problema_no_solucionado = true;
            mostrar_log_info_continuando_proceso = true;
            mostrar_log_info_proceso_detenido = true;
            mostrar_log_info_termino_de_inferencia_reglas_agotadas = true;
            mostrar_log_info_consultando_variables_de_inicio = true;
            mostrar_log_info_procesando_hechos_asociados = true;

        }
        
        /// <summary>
        /// Método que procesa una linea de loggeo en base al formato establecido internamente en la inferencia
        /// </summary>
        /// <param name="texto">Linea extraida del loggeo de la inferencia</param>
        /// <returns>cadena procesada</returns>
        public string ProcesarLineaDeLoggeo(string texto)
        {
            string[] log = texto.Split('|');
            int opcion = Int16.Parse(log[0]);
            if (mostrarInfo(opcion))//a1
            {
                switch (opcion)
                {
                    case ConstantesShell.LOG_VARIABLE:
                        Variable variable = base_conocimiento.leerVariable(log[1]);
                        opcion = Int16.Parse(log[2]);
                        if (mostrarInfo(opcion))
                        {
                            switch (opcion)
                            {
                                case ConstantesShell.LOG_INFO_VARIABLE_CONOCIDA:
                                    return texto_log_info_variable_conocida_inicial + " " + formatearAtributo(variable) + " " + texto_log_info_variable_conocida_final;
                                case ConstantesShell.LOG_ACCION_PROCESANDO_RESPUESTA:
                                    return texto_log_accion_procesando_respuesta_inicial + " " + formatearAtributo(variable) + " " + texto_log_accion_procesando_respuesta_medio + " " + log[3];
                                case ConstantesShell.LOG_ACCION_INGRESANDO_A_VARIABLES_CONOCIDAS:
                                    return texto_log_accion_ingresando_a_variables_conocidas_inicial + " " + formatearAtributo(variable) + " " + texto_log_accion_ingresando_a_variables_conocidas_final;
                            }
                        }
                        else
                            return null;
                        break;
                    case ConstantesShell.LOG_HECHO:
                        Hecho hecho = base_conocimiento.leerHecho(log[1]);
                        opcion = Int16.Parse(log[2]);
                        if (mostrarInfo(opcion))
                        {
                            switch (opcion)
                            {
                                case ConstantesShell.LOG_ACCION_HECHO_OBJETIVO_PRINCIPAL:
                                    return texto_log_accion_hecho_objetivo_principal_inicial + " " + formatearAtributo(hecho) + " " + texto_log_accion_hecho_objetivo_principal_final;
                                case ConstantesShell.LOG_ACCION_HECHO_OBJETIVO_ACTUAL:
                                    string nivel  = "";
                                    if (mostrar_log_nivel_hecho && log.Length > 4)
                                    {
                                        int numero = Int16.Parse(log[4]);
                                        for (int i = 0; i < numero; i++)
                                            nivel += "\t";
                                    }
                                    return nivel + texto_log_accion_hecho_objetivo_actual_inicial + " "+ formatearAtributo(hecho) + " "+ texto_log_accion_hecho_objetivo_actual_final;
                                case ConstantesShell.LOG_ACCION_QUITANDO_HECHO_DE_PILA_OBJETIVOS:
                                    return texto_log_accion_quitando_hecho_de_pila_objetivos_inicial + " "+ formatearAtributo(hecho) + " "+ texto_log_accion_quitando_hecho_de_pila_objetivos_final;
                                case ConstantesShell.LOG_ACCION_MOVER_HECHO:
                                    return texto_log_accion_mover_hecho_inicial + " "+ formatearAtributo(hecho) + " "+ texto_log_accion_mover_hecho_central + " "+ nombreLista(log[3]) + " "+ texto_log_accion_mover_hecho_final + " "+ nombreLista(log[4]);
                                case ConstantesShell.LOG_INFO_SIN_REGLAS_PARA_INFERIR_HECHO:
                                    return texto_log_info_sin_reglas_para_inferir_hecho_inicial + " "+ formatearAtributo(hecho) + " "+ texto_log_info_sin_reglas_para_inferir_hecho_final;
                                case ConstantesShell.LOG_ACCION_CONSULTANDO_HECHO:
                                    return texto_log_accion_consultando_hechos_inicial + " "+ formatearAtributo(hecho) + " "+ texto_log_accion_consultando_hechos_final;
                                case ConstantesShell.LOG_ACCION_INGRESANDO_HECHO_A_PILA_OBJETIVOS:
                                    return texto_log_accion_ingresando_hecho_a_pila_objetivos_inicial + " " + formatearAtributo(hecho) + " " + texto_log_accion_ingresando_hecho_a_pila_objetivos_final;
                            }
                        }
                        else
                            return null;
                        break;
                    case ConstantesShell.LOG_REGLA:
                        Regla regla = base_conocimiento.leerRegla(log[1]);
                        opcion = Int16.Parse(log[2]);
                        if (mostrarInfo(opcion))
                        {
                            switch (opcion)
                            {
                                case ConstantesShell.LOG_ACCION_ELEGIDA_MEJOR_REGLA:
                                    return texto_log_accion_elegida_mejor_regla_inicial + " " + formatearAtributo(regla) + " " + texto_log_accion_elegida_mejor_regla_final;
                                case ConstantesShell.LOG_ACCION_MOVER_REGLA:
                                    return texto_log_accion_mover_regla_inicial + " " + formatearAtributo(regla) + " " + texto_log_accion_mover_regla_central + " " + nombreLista(log[3]) + " " + texto_log_accion_mover_regla_final + " " + nombreLista(log[4]);
                                case ConstantesShell.LOG_ACCION_VALIDANDO_REGLA:
                                    return texto_log_accion_validando_regla_inicial + " " + formatearAtributo(regla) + " " + texto_log_accion_validando_regla_final;
                            }
                        }
                        else
                            return null;
                        break;
                    case  ConstantesShell.LOG_INFO:
                        opcion = Int16.Parse(log[1]);
                        if (mostrarInfo(opcion))
                        {
                            switch (opcion)
                            {
                                case ConstantesShell.LOG_INFO_CONSULTANDO_HECHOS:
                                    return texto_log_info_consultando_hechos;
                                case ConstantesShell.LOG_INFO_ANALIZANDO_HECHOS_INFERIDOS_REGLA:
                                    return texto_log_info_analizando_hechos_inferidos_regla;
                                case ConstantesShell.LOG_INFO_REGLA_VALIDADA:
                                    return texto_log_info_regla_validada;
                                case ConstantesShell.LOG_INFO_REGLA_NO_VALIDADA:
                                    return texto_log_info_regla_no_validada;
                                case ConstantesShell.LOG_INFO_DESCARTANDO_REGLAS_DE_IGUAL_CONSECUENTE:
                                    return texto_log_info_descartando_reglas_de_igual_consecuente;
                                case ConstantesShell.LOG_INFO_PROBLEMA_SOLUCIONADO:
                                    return texto_log_info_problema_solucionado;
                                case ConstantesShell.LOG_INFO_PROBLEMA_NO_SOLUCIONADO:
                                    return texto_log_info_problema_no_solucionado;
                                case ConstantesShell.LOG_INFO_CONTINUANDO_PROCESO:
                                    return texto_log_info_continuando_proceso;
                                case ConstantesShell.LOG_INFO_PROCESO_DETENIDO:
                                    return texto_log_info_proceso_detenido;
                                case ConstantesShell.LOG_INFO_TERMINO_DE_INFERENCIA_REGLAS_AGOTADAS:
                                    return texto_log_info_termino_de_inferencia_reglas_agotadas;
                                case ConstantesShell.LOG_INFO_CONSULTANDO_VARIABLES_DE_INICIO:
                                    return texto_log_info_consultando_variables_de_inicio;
                                case ConstantesShell.LOG_INFO_PROCESANDO_HECHOS_ASOCIADOS:
                                    return texto_log_info_procesando_hechos_asociados;
                            }
                        }
                        else
                            return null;
                        break;
                }
            }//a1
            else
                return null;
            
            return null;
        }

        /// <summary>
        /// Método que obtiene si la opcion de log  debe mostrarse o omitirse
        /// </summary>
        /// <param name="opcion_log">opcion log </param>
        /// <returns></returns>
        private bool mostrarInfo(int opcion_log)
        {
            switch (opcion_log)
            {
                case ConstantesShell.LOG_INFO: return mostrar_log_info;
                case ConstantesShell.LOG_VARIABLE: return mostrar_log_variable;
                case ConstantesShell.LOG_HECHO: return mostrar_log_hecho;
                case ConstantesShell.LOG_REGLA: return mostrar_log_regla;
                case ConstantesShell.LOG_NIVEL_HECHO: return mostrar_log_nivel_hecho;
                case ConstantesShell.LOG_ACCION_MOVER_HECHO: return mostrar_log_accion_mover_hecho;
                case ConstantesShell.LOG_ACCION_MOVER_REGLA: return mostrar_log_accion_mover_regla;
                case ConstantesShell.LOG_ACCION_ELEGIDA_MEJOR_REGLA: return mostrar_log_accion_elegida_mejor_regla;
                case ConstantesShell.LOG_ACCION_CONSULTANDO_HECHO: return mostrar_log_info_consultando_hechos;
                case ConstantesShell.LOG_ACCION_INGRESANDO_HECHO_A_PILA_OBJETIVOS: return mostrar_log_accion_ingresando_hecho_a_pila_objetivos;
                case ConstantesShell.LOG_ACCION_HECHO_OBJETIVO_PRINCIPAL: return mostrar_log_accion_hecho_objetivo_principal;
                case ConstantesShell.LOG_ACCION_HECHO_OBJETIVO_ACTUAL: return mostrar_log_accion_hecho_objetivo_actual;
                case ConstantesShell.LOG_ACCION_QUITANDO_HECHO_DE_PILA_OBJETIVOS: return mostrar_log_accion_quitando_hecho_de_pila_objetivos;
                case ConstantesShell.LOG_ACCION_PROCESANDO_RESPUESTA: return mostrar_log_accion_procesando_respuesta;
                case ConstantesShell.LOG_ACCION_VALIDANDO_REGLA: return mostrar_log_accion_validando_regla;
                case ConstantesShell.LOG_INFO_SIN_REGLAS_PARA_INFERIR_HECHO: return mostrar_log_info_sin_reglas_para_inferir_hecho;
                case ConstantesShell.LOG_INFO_VARIABLE_CONOCIDA: return mostrar_log_info_variable_conocida;
                case ConstantesShell.LOG_INFO_CONSULTANDO_HECHOS: return mostrar_log_info_consultando_hechos;
                case ConstantesShell.LOG_INFO_ANALIZANDO_HECHOS_INFERIDOS_REGLA: return mostrar_log_info_analizando_hechos_inferidos_regla;
                case ConstantesShell.LOG_INFO_REGLA_VALIDADA: return mostrar_log_info_regla_validada;
                case ConstantesShell.LOG_INFO_REGLA_NO_VALIDADA: return mostrar_log_info_regla_no_validada;
                case ConstantesShell.LOG_INFO_DESCARTANDO_REGLAS_DE_IGUAL_CONSECUENTE: return mostrar_log_info_descartando_reglas_de_igual_consecuente;
                case ConstantesShell.LOG_INFO_PROBLEMA_SOLUCIONADO: return mostrar_log_info_problema_solucionado;
                case ConstantesShell.LOG_INFO_PROBLEMA_NO_SOLUCIONADO: return mostrar_log_info_problema_no_solucionado;
                case ConstantesShell.LOG_INFO_CONTINUANDO_PROCESO: return mostrar_log_info_continuando_proceso;
                case ConstantesShell.LOG_INFO_PROCESO_DETENIDO: return mostrar_log_info_proceso_detenido;
                case ConstantesShell.LOG_INFO_TERMINO_DE_INFERENCIA_REGLAS_AGOTADAS: return mostrar_log_info_termino_de_inferencia_reglas_agotadas;
                case ConstantesShell.LOG_ACCION_INGRESANDO_A_VARIABLES_CONOCIDAS: return mostrar_log_accion_ingresando_a_variables_conocidas;
                case ConstantesShell.LOG_INFO_CONSULTANDO_VARIABLES_DE_INICIO: return mostrar_log_info_consultando_variables_de_inicio;
                case ConstantesShell.LOG_INFO_PROCESANDO_HECHOS_ASOCIADOS: return mostrar_log_info_procesando_hechos_asociados; 
            }
            throw new System.ArgumentException("Opcion de loggeo invalida", "omitir info");
        }
        
        /// <summary>
        /// Método que devuelve el nombre de la lista especificada según el codigo de loggeo
        /// </summary>
        /// <param name="texto_opcion">texto con el codigo</param>
        /// <returns>nombre de la lista</returns>
        private string nombreLista(string texto_opcion)
        {
            int opcion = Int16.Parse(texto_opcion);
            return nombreLista(opcion);
        }
        /// <summary>
        /// Método que devuelve el nombre de la lista especificada según el codigo de loggeo
        /// </summary>
        /// <param name="opcion">Número opcion del codigo</param>
        /// <returns>nombre d ela lista</returns>
        private string nombreLista(int opcion)
        {
            switch (opcion)
	        {
		        case ConstantesShell.REGLAS_DISPONIBLES:
                    return texto_reglas_disponibles;
                case ConstantesShell.REGLAS_CANDIDATAS:
                    return texto_reglas_candidatas;
                case ConstantesShell.REGLAS_ELIMINADAS:
                    return texto_reglas_eliminadas;
                case ConstantesShell.HECHOS_DISPONIBLES:
                    return texto_hechos_disponibles;
                case ConstantesShell.HECHOS_VERDADEROS:
                    return texto_hechos_verdaderos;
                case ConstantesShell.HECHOS_FALSOS:
                    return texto_hechos_falsos;
            }
            throw new System.ArgumentException("Opcion invalida", "nombre lista");
        }

        /// <summary>
        /// Método que formatea como se muestra la info del atributo
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        private string formatearAtributo(Variable variable)
        {
            switch (formato_variables)
            {
                case FORMATO_SOLO_ID:
                    return variable.id_variable;
                case FORMATO_SOLO_CONTENIDO:
                    return variable.nombre_variable;
                case FORMATO_ID_MAS_CONTENIDO:
                    return variable.id_variable +" "+variable.nombre_variable;
            }
            throw new System.ArgumentException("Opcion invalida", "formatearAtributo");
        }
        /// <summary>
        /// Método que formatea como se muestra la info del atributo
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        private string formatearAtributo(Hecho hecho)
        {
            switch (formato_hechos)
            {
                case FORMATO_SOLO_ID:
                    return hecho.id_hecho;
                case FORMATO_SOLO_CONTENIDO:
                    return ""+hecho;
                case FORMATO_ID_MAS_CONTENIDO:
                    return hecho.id_hecho + " " + hecho;
            }
            throw new System.ArgumentException("Opcion invalida", "formatearAtributo");
        }
        /// <summary>
        /// Método que formatea como se muestra la info del atributo
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        private string formatearAtributo(Regla regla)
        {
            switch (formato_reglas)
            {
                case FORMATO_SOLO_ID:
                    return regla.id_regla;
                case FORMATO_SOLO_CONTENIDO:
                    return regla+"";
                case FORMATO_ID_MAS_CONTENIDO:
                    return regla.id_regla + "  " + regla;
            }
            throw new System.ArgumentException("Opcion invalida", "formatearAtributo");
        }
    }
}
