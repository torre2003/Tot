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
            button_validar.Enabled = false;
            button_si.Enabled = false;
            button_no.Enabled = false;
            button_continuar.Enabled = false;
            button_detener.Enabled = false;
        }


        //***********************************************************************************
        // Evento
        //***********************************************************************************
    }
}
