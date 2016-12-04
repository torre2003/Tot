using ControlesModuloConsulta;
using SistemaExpertoLib.MotorDeInferencia;
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
using System.Collections;
using System.Threading;

namespace Tot
{
    public partial class FormVentanaInferencia : Form
    {
        //**************************************************************************************
        //  Atributos
        //**************************************************************************************
        
        public string ruta_base_conocimiento = "";
        ControlPantallaInicial ventana_inicial = new ControlPantallaInicial();
        ControlSeleccionObjetivo ventana_selecion_de_objetivo = new ControlSeleccionObjetivo();
        ControlPreguntarVariable ventana_preguntar_variable = new ControlPreguntarVariable();
        ControlValidarHecho ventana_validar_hecho = new ControlValidarHecho();
        ControlJustificación ventana_justificacion = new ControlJustificación();
        FormDialogoPanel dialogo;



        private bool evento_interno = false;
        private bool terminar_inferencia = false;
        private int tipo_de_encadenamiento = 0;


        private const int ENCADENAMIENTO_HACIA_ATRAS = 1;
        private const int ENCADENAMIENTO_HACIA_ADELANTE = 2;

        private LecturaBaseConocimiento base_conocimiento;
        private EncadenamientoHaciaAtras motor_atras;
        private MetadatosBaseDeConocimiento metadatos;


        //**************************************************************************************
        // Métodos
        //**************************************************************************************
        public FormVentanaInferencia()
        {
            InitializeComponent();
        }

        public FormVentanaInferencia(string ruta_base_conocimiento)
        {
            InitializeComponent();
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
                    if (motor_atras.hecho_objetivo_establecido)
                        iniciarInferenciaEncadenamientoHaciaAtras();
                    else
                        MessageBox.Show("No se ha selecciónado la variable objetivo", "Inferencia, Encadenamiento hacia atrás", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Visible = false;
        }

        /// <summary>
        /// Método que inicializa en motor de inferencia y muestra la ventana inicial
        /// </summary>
        public void iniciarVentana()
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
            ventana_inicial.tiulo_sistema_experto = metadatos.titulo_sistema_experto;
            ventana_inicial.ruta_rtf_descripcion = metadatos.ruta_rtf_descripcion_sistema_experto;
            ventana_inicial.ruta_imagen_logo = metadatos.ruta_imagen_logo_sistema_experto;


            dialogo = new FormDialogoPanel(ventana_inicial);
            ventana_inicial.evento_continuar += pantalla_inicial_evento_continuar;
            dialogo.FormClosing += dialogo_FormClosing;
            dialogo.ShowDialog(this);
            ventana_inicial.liberarRecursosImagenLogo();
            dialogo = null;
        }

        /// <summary>
        /// Método que muestra la selección del objetivo a buscar en el encadenaiento hacia atrás
        /// </summary>
        public void iniciarSeleccionDeObjetivo()
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
            dialogo.ShowDialog(this);
            dialogo = null;
            motor_atras.establecerHechoObjetivo(ventana_selecion_de_objetivo.id_estado_chequeada);
        }

        /// <summary>
        /// Método que inicia la inferencia con encadenaiento hacia atrás
        /// </summary>
        public void iniciarInferenciaEncadenamientoHaciaAtras()
        {
            motor_atras.evento_consultar_variable += motor_atras_evento_consultar_variable;
            motor_atras.evento_confimar_hecho += motor_atras_evento_confimar_hecho;
            motor_atras.evento_informacion_inferencia += motor_atras_evento_informacion_inferencia;
            motor_atras.inferencia();
            mostrarModuloDeJustificación();
        }
        
        /// <summary>
        /// Método para mostrar el modulo de justificación de la inferencia
        /// </summary>
        public void mostrarModuloDeJustificación()
        {
            dialogo = new FormDialogoPanel(ventana_justificacion);
            ventana_justificacion.mostrarLog(motor_atras.loggeo_inferencia);
            dialogo.FormClosing += dialogo_justificacion_FormClosing;
            ventana_justificacion.evento_guardar += ventana_justificacion_evento_guardar;
            ventana_justificacion.evento_ventana_lista += evento_ventana_respuesta_lista;
            dialogo.ShowDialog(this);
            dialogo = null;
        }


        /// <summary>
        /// Método para realizar una pregunta de tipo si no cancelar
        /// </summary>
        /// <param name="titulo">Titulo en el cuadro</param>
        /// <param name="pregunta">Pregunta a realizar</param>
        /// <returns>1 = si, 0 = no, -1 cancel</returns>
        public int preguntasSiNoCancelar(string titulo, string pregunta)
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

        ArrayList motor_atras_evento_consultar_variable(string id_variable)
        {
            Variable variable = base_conocimiento.leerVariable(id_variable);
            dialogo = new FormDialogoPanel(ventana_preguntar_variable);
            dialogo.FormClosing += dialogo_FormClosing;
            ventana_preguntar_variable.evento_respuesta_lista += evento_ventana_respuesta_lista;
            ventana_preguntar_variable.consultarVariable(variable);
            dialogo.ShowDialog(this);
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

        
        int[] motor_atras_evento_confimar_hecho(string id_hecho)
        {
            Hecho hecho = base_conocimiento.leerHecho(id_hecho);
            Variable variable = base_conocimiento.leerVariable(hecho.id_variable);

            dialogo = new FormDialogoPanel(ventana_validar_hecho);
            dialogo.FormClosing += dialogo_FormClosing;
            ventana_validar_hecho.evento_respuesta_lista += evento_ventana_respuesta_lista;
            ventana_validar_hecho.inciarConsultaHecho(hecho, variable.ruta_texto_descriptivo);
            dialogo.ShowDialog(this);
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
            MessageBox.Show("implementar");
        }


        private void FormVentanaInferencia_Activated(object sender, System.EventArgs e)
        {
            
        }

    }
}
