using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaExpertoLib;

namespace ControlesModuloConsulta
{
    
    public partial class ControlValidarHecho : UserControl
    {
        //***********************************************************************************
        // Atributos
        //***********************************************************************************

        public string titulo
        {
            get{ return label_titulo.Text;}
            set{ label_titulo.Text = value;}
        }

        public string ruta_rtf_descriptivo = "";

        public string hecho_a_validar
        {
            get { return textBox_hecho_a_validar.Text; }
            set { textBox_hecho_a_validar.Text = value; }
        }

        public bool consulta_lista = false;
        public bool se_soluciono_el_problema = false;
        public bool hecho_validado = false;
        public bool continuar_inferencia = false;


        public event DelegadoRespuestaLista evento_respuesta_lista;

        //***********************************************************************************
        // Método
        //***********************************************************************************
        public ControlValidarHecho()
        {
            InitializeComponent();
        }



        public void limpiarControl()
        {
            titulo = "";
            hecho_a_validar = "";
            button_validar_no.Enabled = false;
            button_validar_si.Enabled = false;
            button_solucion_si.Enabled = false;
            button_solucion_no.Enabled = false;
            button_continuar.Enabled = false;
            button_detener.Enabled = false;
            consulta_lista = false;
        }

        /// <summary>
        /// Método que inicia la consulta para comprobar un hecho
        /// </summary>
        /// <param name="hecho">Hecho a comprobar</param>
        /// <param name="ruta_rtf_descripcion">rutda de rtf a mostrar en pantalla, (Rtf correspondiente a la varaible del hecho)</param>
        public void inciarConsultaHecho(Hecho hecho, string ruta_rtf_descripcion)
        {
            limpiarControl();
            this.ruta_rtf_descriptivo = ruta_rtf_descripcion;
            if (ruta_rtf_descriptivo != null && !ruta_rtf_descriptivo.Equals(""))
            {
                mostrarRTFDescripcion(ruta_rtf_descriptivo);
            }
            titulo = hecho.nombre_variable;
            hecho_a_validar = hecho + "";
            button_validar_si.Enabled = true;
            button_validar_no.Enabled = true;

        }


        /// <summary>
        /// Metodo para mostrar el archivo rtf en la descripción del control
        /// </summary>
        public void mostrarRTFDescripcion(string ruta_richText)
        {
            richTextBox_descripcion.Clear();
            try
            {
                this.richTextBox_descripcion.Rtf = System.IO.File.ReadAllText(ruta_richText, System.Text.Encoding.Default);
            }
            catch (Exception) //error occured, that means we loaded invalid RTF, so load as plain text
            {
                this.richTextBox_descripcion.Text = System.IO.File.ReadAllText(ruta_richText, System.Text.Encoding.Default);
            }
        }
        

        //***********************************************************************************
        // Evento
        //***********************************************************************************
        private void button_validar_si_Click(object sender, EventArgs e)
        {
            button_solucion_si.Enabled = true;
            button_solucion_no.Enabled = true;
            button_continuar.Enabled = false;
            button_detener.Enabled = false;

            hecho_validado = true;
            consulta_lista = false;
        }

        private void button_validar_no_Click(object sender, EventArgs e)
        {
            button_solucion_si.Enabled = false;
            button_solucion_no.Enabled = false;
            button_continuar.Enabled = true;
            button_detener.Enabled = true;

            hecho_validado = false;
            se_soluciono_el_problema = false;
            consulta_lista = false;
        }

        private void button_solucion_si_Click(object sender, EventArgs e)
        {
            button_continuar.Enabled = true;
            button_detener.Enabled = true;

            se_soluciono_el_problema = true;
            consulta_lista = false;
        }

        private void button_solucion_no_Click(object sender, EventArgs e)
        {
            button_continuar.Enabled = true;
            button_detener.Enabled = true;

            se_soluciono_el_problema = false;
            consulta_lista = false;
        }

        private void button_continuar_Click(object sender, EventArgs e)
        {
            consulta_lista = true;
            continuar_inferencia = true;
            if (evento_respuesta_lista != null)
                evento_respuesta_lista();
        }

        private void button_detener_Click(object sender, EventArgs e)
        {
            consulta_lista = true;
            continuar_inferencia = false;
            if (evento_respuesta_lista != null)
                evento_respuesta_lista();
        }





    }
}
