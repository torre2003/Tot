using ControlesModuloConsulta;
using SistemaExpertoLib;
using SistemaExpertoLib.MotorDeInferencia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tot_Sistema_Experto
{
    public class GestionMotorInferencia
{
        //**************************************************************************************
        //  Atributos
        //**************************************************************************************
        
        public string ruta_base_conocimiento = "";
        public ProcesadorLogInferencia procesador_log_inferencia
        {
            set
            {
                _procesador_log_inferencia = value;
                _procesador_log_inferencia.ruta_base_conocimiento = this.ruta_base_conocimiento;
            }
        }
        ProcesadorLogInferencia _procesador_log_inferencia = new ProcesadorLogInferencia();
        
        ControlPantallaInicial ventana_inicial = new ControlPantallaInicial();
        ControlSeleccionObjetivo ventana_selecion_de_objetivo = new ControlSeleccionObjetivo();
        ControlPreguntarVariable ventana_preguntar_variable = new ControlPreguntarVariable();
        ControlValidarHecho ventana_validar_hecho = new ControlValidarHecho();
        ControlJustificación ventana_justificacion = new ControlJustificación();
        
        
        FormDialogoPanel dialogo;

        IWin32Window ventana_padre;

        private bool evento_interno = false;
        private bool terminar_inferencia = false;
        private int tipo_de_encadenamiento = 0;


        private const int ENCADENAMIENTO_HACIA_ATRAS = 1;
        private const int ENCADENAMIENTO_HACIA_ADELANTE = 2;

        private LecturaBaseConocimiento base_conocimiento;
        private EncadenamientoHaciaAtras motor_atras;
        private EncadenamientoHaciaAdelante motor_adelante;
        private MetadatosBaseDeConocimiento metadatos;


        //**************************************************************************************
        // Métodos
        //**************************************************************************************
        public GestionMotorInferencia(string ruta_base_conocimiento, IWin32Window ventana_padre)
        {
            this.ventana_padre = ventana_padre;
            this.ruta_base_conocimiento = ruta_base_conocimiento;
        }

        /// <summary>
        /// Método que inicia el proceso de inferencia según el tipo de encadenamiento
        /// </summary>
        public void iniciarProceso()
        {
            base_conocimiento = new LecturaBaseConocimiento();
            if (base_conocimiento.existe_base_conocimiento)
            {
                metadatos = base_conocimiento.leerMetadatos();
                if (metadatos == null)
                {
                    MessageBox.Show("Error en la configuración de la base de conocimiento", "Proceso de inferencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(!metadatos.base_conocimiento_chequeada)
                {
                    MessageBox.Show("La base conocimiento no esta chequeada", "Proceso de inferencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tipo_de_encadenamiento = metadatos.tipo_de_encadenamiento;
                iniciarVentana();
            }
            else
            {
                terminar_inferencia = true;
                MessageBox.Show("La base de conocimiento no existe", "Proceso de inferencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!terminar_inferencia)
            {
                if (tipo_de_encadenamiento == ENCADENAMIENTO_HACIA_ATRAS)
                    iniciarSeleccionDeObjetivo();
            }

            if (!terminar_inferencia)
            {
                if (tipo_de_encadenamiento == ENCADENAMIENTO_HACIA_ATRAS)
                {
                    if (motor_atras.hecho_objetivo_establecido)
                        iniciarInferenciaEncadenamientoHaciaAtras();
                    else
                        MessageBox.Show("No se ha selecciónado la variable objetivo", "Inferencia, Encadenamiento hacia atrás", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                if (tipo_de_encadenamiento == ENCADENAMIENTO_HACIA_ADELANTE)
                {
                    iniciarInferenciaEncadenamientoHaciaAdelante();
                }
                else
                {
                    throw new System.ArgumentException("Opción invalida de encadenamiento", "GestorMotorInferencia - iniciar proceso");
                }
            }
        }

        /// <summary>
        /// Método que inicializa en motor de inferencia y muestra la ventana inicial
        /// </summary>
        private void iniciarVentana()
        {
            
            if (tipo_de_encadenamiento == ENCADENAMIENTO_HACIA_ATRAS)
            {
                motor_atras = new EncadenamientoHaciaAtras();
                string errores = motor_atras.inicializarEncadenamiento();
                if (errores != null)
                {
                    MessageBox.Show(errores,"Proceso de inferencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminar_inferencia = true;
                    return;
                }
            }
            else
            if (tipo_de_encadenamiento == ENCADENAMIENTO_HACIA_ADELANTE)
            {
                motor_adelante = new EncadenamientoHaciaAdelante();
                string errores = motor_adelante.inicializarEncadenamiento();
                if (errores != null)
                {
                    MessageBox.Show(errores, "Proceso de inferencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminar_inferencia = true;
                    return;
                }
            }
            else
            {
                throw new System.ArgumentException("Opción invalida de encadenamiento", "GestorMotorInferencia - iniciarVentana");
            }
            ventana_inicial.tiulo_sistema_experto = metadatos.titulo_sistema_experto;
            ventana_inicial.ruta_rtf_descripcion = metadatos.ruta_rtf_descripcion_sistema_experto;
            ventana_inicial.ruta_imagen_logo = metadatos.ruta_imagen_logo_sistema_experto;

            dialogo = new FormDialogoPanel(ventana_inicial);
            ventana_inicial.evento_continuar += pantalla_inicial_evento_continuar;
            dialogo.FormClosing += dialogo_FormClosing;
            dialogo.ShowDialog(ventana_padre);
            ventana_inicial.liberarRecursosImagenLogo();
            dialogo = null;
        }

        /// <summary>
        /// Método que muestra la selección del objetivo a buscar en el encadenaiento hacia atrás
        /// </summary>
        private void iniciarSeleccionDeObjetivo()
        {
            dialogo = new FormDialogoPanel(ventana_selecion_de_objetivo);
            dialogo.FormClosing += dialogo_FormClosing;
            ventana_selecion_de_objetivo.evento_comenzar += ventana_selecion_de_objetivo_evento_comenzar;
            ventana_selecion_de_objetivo.evento_cambio_en_seleccion_variable += ventana_selecion_de_objetivo_evento_cambio_en_seleccion_variable;
            string[] id_variables_objetivo = motor_atras.obtenerPosiblesVariablesObjetivos();
            for (int i = 0; i < id_variables_objetivo.Length; i++)
            {
                Variable variable = base_conocimiento.leerVariable(id_variables_objetivo[i]);
                ventana_selecion_de_objetivo.agregarOpcionPanelVariables(variable.id_variable, variable.nombre_variable);
            }
            ventana_selecion_de_objetivo.titulo = metadatos.titulo_sistema_experto;
            dialogo.ShowDialog(ventana_padre);
            dialogo = null;
            if(!terminar_inferencia)
                motor_atras.establecerHechoObjetivo(ventana_selecion_de_objetivo.id_estado_chequeada);
        }

        /// <summary>
        /// Método que inicia la inferencia con encadenaiento hacia atrás
        /// </summary>
        private void iniciarInferenciaEncadenamientoHaciaAtras()
        {
            motor_atras.evento_consultar_variable += motor_inferencia_evento_consultar_variable;
            motor_atras.evento_confimar_hecho += motor_inferencia_evento_confimar_hecho;
            motor_atras.evento_informacion_inferencia += motor_atras_evento_informacion_inferencia;
            motor_atras.inferencia();
            mostrarModuloDeJustificación();
        }

        /// <summary>
        /// Método que inicia la inferencia con encadenaiento hacia adelante
        /// </summary>
        private void iniciarInferenciaEncadenamientoHaciaAdelante()
        {
            motor_adelante.evento_consultar_variable += motor_inferencia_evento_consultar_variable;
            motor_adelante.evento_confimar_hecho += motor_inferencia_evento_confimar_hecho;
            motor_adelante.evento_informacion_inferencia += motor_atras_evento_informacion_inferencia;
            motor_adelante.inferencia();
            mostrarModuloDeJustificación();
        }

        /// <summary>
        /// Método para mostrar el modulo de justificación de la inferencia
        /// </summary>
        private void mostrarModuloDeJustificación()
        {
            dialogo = new FormDialogoPanel(ventana_justificacion);
            List<string> log = new List<string>();
            if (tipo_de_encadenamiento == ENCADENAMIENTO_HACIA_ATRAS)
                log = motor_atras.loggeo_inferencia;
            else
                log = motor_adelante.loggeo_inferencia;
            for (int i = 0; i < log.Count; i++)
            {
                string texto = _procesador_log_inferencia.ProcesarLineaDeLoggeo(log[i]);
                if (texto != null)
                    ventana_justificacion.agregarLineaLog(texto);
            }
                
               // ventana_justificacion.agregarLineaLog(log[i]);
            dialogo.FormClosing += dialogo_justificacion_FormClosing;
            ventana_justificacion.evento_guardar += ventana_justificacion_evento_guardar;
            ventana_justificacion.evento_ventana_lista += evento_ventana_respuesta_lista;
            dialogo.ShowDialog(ventana_padre);
            dialogo = null;
        }


        private bool escribirLogEnArchivo(List<string> log, ProcesadorLogInferencia procesador, bool guardar_variables, bool guardar_hechos, bool guardar_reglas, string ruta_archivo)
        {
            StringBuilder texto_archivo = new StringBuilder();
            for (int i = 0; i < log.Count; i++)
            {
                string linea_log = procesador.ProcesarLineaDeLoggeo(log[i]);
                if (linea_log != null)
                    texto_archivo.AppendLine(linea_log);
            }
            if (guardar_reglas)
            {
                texto_archivo.AppendLine("");
                texto_archivo.AppendLine("");
                texto_archivo.AppendLine("-----------------------------------------------------");
                texto_archivo.AppendLine("-----------   Reglas     ----------------------------");
                texto_archivo.AppendLine("-----------------------------------------------------");
                string[] lista_de_reglas = base_conocimiento.listarReglas();
                for (int i = 0; i < lista_de_reglas.Length; i++)
                {
                    Regla regla = base_conocimiento.leerRegla(lista_de_reglas[i]);
                    texto_archivo.AppendLine("ID " + regla.id_regla + " | " + regla);
                }
            }
            if (guardar_hechos)
            {
                texto_archivo.AppendLine("");
                texto_archivo.AppendLine("");
                texto_archivo.AppendLine("-----------------------------------------------------");
                texto_archivo.AppendLine("-----------  Hechos      ----------------------------");
                texto_archivo.AppendLine("-----------------------------------------------------");
                string[] lista_de_hechos = base_conocimiento.listarHechos();
                for (int i = 0; i < lista_de_hechos.Length; i++)
                {
                    Hecho hecho = base_conocimiento.leerHecho(lista_de_hechos[i]);
                    texto_archivo.AppendLine("ID " + hecho.id_hecho + "  (ID variable " + hecho.id_variable + ") | " + hecho);
                }
            }
            if (guardar_variables)
            {
                texto_archivo.AppendLine("");
                texto_archivo.AppendLine("");
                texto_archivo.AppendLine("-----------------------------------------------------");
                texto_archivo.AppendLine("-----------  Variables   ----------------------------");
                texto_archivo.AppendLine("-----------------------------------------------------");
                string[] lista_de_variables = base_conocimiento.listarVariables();
                for (int i = 0; i < lista_de_variables.Length; i++)
                    texto_archivo.AppendLine(extraerDetalleVariable(base_conocimiento.leerVariable(lista_de_variables[i])));
            }
            return generarArchivoDeTexto(texto_archivo, ruta_archivo);
        }

        private string extraerDetalleVariable(Variable variable)
        {
            string texto_retorno = "ID: " + variable.id_variable + " | Nombre : " + variable.nombre_variable;
            switch (variable.tipo_variable)
            {
                case Variable.BOOLEANO:
                    texto_retorno += " | Tipo: BOOLEANO";
                    break;
                case Variable.NUMERICO:
                    texto_retorno += " | Tipo: NUMERICO";
                    if (variable.cardinal)
                        texto_retorno += "-CARDINAL";
                    else
                        texto_retorno += "-REAL";
                    if (variable.rango_limitado)
                        texto_retorno += " | Rango [  "+variable.rango_limite_inferior+" : "+variable.rango_limite_superior+"  ]";
                    break;
                case Variable.LISTA:
                    texto_retorno += " | Tipo: LISTA";
                    string[] opciones = variable.listarOpciones();
                    texto_retorno += " | Opciones:  ";
                    for (int i = 0; i < opciones.Length; i++)
                    {
                        if (i!=0)
                            texto_retorno += " , ";
                        texto_retorno += opciones[i];
                    }
                    break;
            }
            return texto_retorno;
        }



        private bool generarArchivoDeTexto(StringBuilder texto, string full_path_destino)
        {
            if (File.Exists(full_path_destino))
                File.Delete(full_path_destino);
            using (StreamWriter stream_writer = new StreamWriter(full_path_destino, false))
            {
                stream_writer.Write(texto);
                stream_writer.Close();
            }
            if (File.Exists(full_path_destino))
                return true;
            return false;
        }
        /// <summary>
        /// Método para realizar una pregunta de tipo si no cancelar
        /// </summary>
        /// <param name="titulo">Titulo en el cuadro</param>
        /// <param name="pregunta">Pregunta a realizar</param>
        /// <returns>1 = si, 0 = no, -1 cancel</returns>
        private int preguntasSiNoCancelar(string titulo, string pregunta)
        {
            DialogResult result = MessageBox.Show(pregunta, titulo, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return 1;
            if (result == DialogResult.No)
                return 0;
            return -1;
        }


        //**************************************************************************************
        // Eventos
        //**************************************************************************************
        void dialogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!evento_interno)
            {
                int opcion = preguntasSiNoCancelar("Inferencia", "¿Desea terminar con el proceso de inferencia?");
                if (opcion != 1)
                    e.Cancel = true;
                else
                    terminar_inferencia = true;
            }
            evento_interno = false;
        }
                
        void pantalla_inicial_evento_continuar()
        {
            evento_interno = true;
            dialogo.Dispose();
          //  iniciarSeleccionDeObjetivo();
        }
        void ventana_selecion_de_objetivo_evento_comenzar()
        {
            evento_interno = true;
            dialogo.Dispose();
        }

        void ventana_selecion_de_objetivo_evento_cambio_en_seleccion_variable(string id_variable)
        {
            ventana_selecion_de_objetivo.limpiarPanelEstados();
            string[] id_hechos = motor_atras.obtenertPosibleHechosObjetivos(id_variable);
            for (int i = 0; i < id_hechos.Length; i++)
            {
                Hecho hecho = base_conocimiento.leerHecho(id_hechos[i]);
                ventana_selecion_de_objetivo.agregarOpcionPanelEstados(hecho.id_hecho, hecho + "");
            }
        }

        ArrayList motor_inferencia_evento_consultar_variable(string id_variable)
        {
            Variable variable = base_conocimiento.leerVariable(id_variable);
            dialogo = new FormDialogoPanel(ventana_preguntar_variable);
            dialogo.FormClosing += dialogo_FormClosing;
            ventana_preguntar_variable.evento_respuesta_lista += evento_ventana_respuesta_lista;
            ventana_preguntar_variable.consultarVariable(variable);
            dialogo.ShowDialog(ventana_padre);
            if (terminar_inferencia)
                return null;
            ArrayList respuesta_pregunta = ventana_preguntar_variable.obtenerResultadosPregunta();
            //Limpiando dialogo
            //evento_interno = true;
            //dialogo.Dispose();
            dialogo = null;
            
            

            return respuesta_pregunta;
        }

        void evento_ventana_respuesta_lista()
        {
            evento_interno = true;
            dialogo.Visible = false;
        }


        int[] motor_inferencia_evento_confimar_hecho(string id_hecho, string id_regla)
        {
            Regla regla = base_conocimiento.leerRegla(id_regla);
            Hecho hecho = base_conocimiento.leerHecho(id_hecho);
            Variable variable = base_conocimiento.leerVariable(hecho.id_variable);
            string[] lista_de_antecedentes = regla.listarAntecedentes();
            Hecho[] hechos_antecedente = new Hecho[lista_de_antecedentes.Length];
            for (int i = 0; i < lista_de_antecedentes.Length; i++)
                hechos_antecedente[i] = base_conocimiento.leerHecho(lista_de_antecedentes[i]);
            
        
        
            dialogo = new FormDialogoPanel(ventana_validar_hecho);
            dialogo.FormClosing += dialogo_FormClosing;
            ventana_validar_hecho.evento_respuesta_lista += evento_ventana_respuesta_lista;
            ventana_validar_hecho.inciarConsultaHecho(id_regla,hecho,hechos_antecedente, variable.ruta_texto_descriptivo);
            dialogo.ShowDialog(ventana_padre);
            if (terminar_inferencia)
                return null;
            int[] respuestas = new int[3];
            if (ventana_validar_hecho.hecho_validado)
                respuestas[0] = ConstantesShell.HECHO_CONFIRMADO;
            else
                respuestas[0] = ConstantesShell.HECHO_DESCARTADO;

            if (ventana_validar_hecho.se_soluciono_el_problema)
                respuestas[1] = ConstantesShell.PROBLEMA_SOLUCIONADO;
            else
                respuestas[1] = ConstantesShell.PROBLEMA_NO_SOLUCIONADO;

            if (ventana_validar_hecho.continuar_inferencia)
                respuestas[2] = ConstantesShell.CONTINUAR_PROCESO;
            else
                respuestas[2] = ConstantesShell.DETENER_PROCESO;
            return respuestas;
        }


        void motor_atras_evento_informacion_inferencia(string info)
        {
            MessageBox.Show(info, "Inferencia encadenamiento hacia atrás", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        void dialogo_justificacion_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!evento_interno)
            {
                int opcion = preguntasSiNoCancelar("Inferencia", "¿Está seguro de cerrar la ventana?");
                if (opcion != 1)
                    e.Cancel = true;
            }
            evento_interno = false;
        }

        void ventana_justificacion_evento_guardar()
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog_guardar_log = new SaveFileDialog();
            saveFileDialog_guardar_log.DefaultExt = "txt";
            saveFileDialog_guardar_log.Filter = "Archivos de texto |*.txt;";
            saveFileDialog_guardar_log.InitialDirectory = "Environment.SpecialFolder.Desktop";

            if (saveFileDialog_guardar_log.ShowDialog() == DialogResult.OK)
            {
                _procesador_log_inferencia.mostrarInfosPorDefecto();
                List<string> log = new List<string>();
                if (tipo_de_encadenamiento == ENCADENAMIENTO_HACIA_ATRAS)
                    log = motor_atras.loggeo_inferencia;
                else
                    log = motor_adelante.loggeo_inferencia;
                bool flag = escribirLogEnArchivo(log, _procesador_log_inferencia,true,true,true,saveFileDialog_guardar_log.FileName);
                if (flag)
                    MessageBox.Show("El archivo ha sido guardado satisfactoriamente.", "Guardando Log de inferencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Problemas con la creación del archivo", "Guardando Log de inferencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
            
            /*
            FormVentanaGuardarLog ventana_guardar_log = new FormVentanaGuardarLog();
            ventana_guardar_log.ShowDialog(ventana_padre);
            if (ventana_guardar_log.DialogResult == DialogResult.OK)
            {
                if (ventana_guardar_log.tipo_de_guardado == FormVentanaGuardarLog.GUARDADO_COMPLETO)
                    _procesador_log_inferencia.mostrarInfosPorDefecto();
                List<string> log = new List<string>();
                if (tipo_de_encadenamiento == ENCADENAMIENTO_HACIA_ATRAS)
                    log = motor_atras.loggeo_inferencia;
                else
                    log = motor_adelante.loggeo_inferencia;
                bool flag = escribirLogEnArchivo(log, _procesador_log_inferencia, ventana_guardar_log.guardar_variables, ventana_guardar_log.guardar_hechos, ventana_guardar_log.guardar_reglas, ventana_guardar_log.ruta_guardado);
                if (flag)
                    MessageBox.Show("El archivo ha sido guardado satisfactoriamente.", "Guardando Log de inferencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Problemas con la creación del archivo", "Guardando Log de inferencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /**/ 
            
        }
    }
}
