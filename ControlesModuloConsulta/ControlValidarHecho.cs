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
using System.Collections;

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

        public string id_regla
        {
            get { return label_id_regla.Text; }
            set { label_id_regla.Text = value; }
        }


        public bool consulta_lista = false;
        public bool se_soluciono_el_problema = false;
        public bool hecho_validado = false;
        public bool continuar_inferencia = false;

        int y_inicial = 10;
        int x_inicial = 10;
        int ultimo_y = 10;
        int espacio_control = 30;
        ArrayList lista_de_antecedentes = new ArrayList();


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
            id_regla = "";
            titulo = "";
            hecho_a_validar = "";
            button_validar_no.Enabled = false;
            button_validar_si.Enabled = false;
            button_solucion_si.Enabled = false;
            button_solucion_no.Enabled = false;
            button_continuar.Enabled = false;
            button_detener.Enabled = false;
            consulta_lista = false;
            ultimo_y = y_inicial;

            foreach (TextBox item in lista_de_antecedentes)
                panel_antecedentes_int.Controls.Remove(item);
            lista_de_antecedentes = new ArrayList();
        }

        /// <summary>
        /// Método que inicia la consulta para comprobar un hecho
        /// </summary>
        /// <param name="hecho_a_validar">Hecho a comprobar</param>
        /// <param name="ruta_rtf_descripcion">ruta de rtf a mostrar en pantalla, (Rtf correspondiente a la varaible del hecho)</param>
        public void inciarConsultaHecho(string id_regla,Hecho hecho_a_validar,Hecho[] antecedentes, string ruta_rtf_descripcion)
        {
            limpiarControl();
            this.id_regla = id_regla;
            this.ruta_rtf_descriptivo = ruta_rtf_descripcion;
            if (ruta_rtf_descriptivo != null && !ruta_rtf_descriptivo.Equals(""))
            {
                mostrarRTFDescripcion(ruta_rtf_descriptivo);
            }
            titulo = hecho_a_validar.nombre_variable;
            for (int i = 0; i < antecedentes.Length; i++)
                agregarAntecedentes(antecedentes[i]);
            this.hecho_a_validar = hecho_a_validar + "";
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




        private void agregarAntecedentes(Hecho hecho)
        {
            TextBox textBox_aux = new TextBox();
            textBox_aux.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            textBox_aux.Location = new System.Drawing.Point(x_inicial, ultimo_y);
            textBox_aux.Name = "textBox";
            textBox_aux.ReadOnly = true;
            textBox_aux.Size = new System.Drawing.Size(390, 26);
            textBox_aux.TabIndex = 16;
            textBox_aux.Text = "" + hecho;
            ultimo_y += espacio_control;
            lista_de_antecedentes.Add(textBox_aux);
            this.panel_antecedentes_int.Controls.Add(textBox_aux);
            this.panel_antecedentes_int.Size = new System.Drawing.Size(400, ultimo_y);
            /**/
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
