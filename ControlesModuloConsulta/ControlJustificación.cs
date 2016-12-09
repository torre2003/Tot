using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesModuloConsulta
{
    public delegate void DelegadoGuardar ();

    public partial class ControlJustificación : UserControl
    {
        //*************************************************************************
        // Atributos
        //*************************************************************************
        
        public event DelegadoRespuestaLista evento_ventana_lista;
        public event DelegadoGuardar evento_guardar;

        public bool guardar_habilitado
        {
            get
            {
                return button_guardar.Enabled;
            }
            set
            {
                button_guardar.Enabled = value;
            }
        }



        //*************************************************************************
        // métodos
        //*************************************************************************
        public ControlJustificación()
        {
            InitializeComponent();
        }

        public void limpiarPantalla()
        {
            textBox_log.Text = "";
        }

        /// <summary>
        /// Método para mostrar el log de inferencia en pantalla
        /// </summary>
        /// <param name="log"></param>
        public void mostrarLog(List<string> log)
        {
            limpiarPantalla();
            foreach (string item in log)
            {
                textBox_log.AppendText(item+"\n");
            }
        }





        //*************************************************************************
        // Eventos
        //*************************************************************************
        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (evento_guardar != null)
                evento_guardar();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (evento_ventana_lista != null)
                evento_ventana_lista();
        }
    }
}
