using SistemaExpertoLib.GestionDelConocimiento;
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
    public partial class FormVentanaConfiguracion : Form
    {
        //********************************************************************************
        // Atributos
        //********************************************************************************
        GestionadorBaseConocimiento base_conocimiento;
        private ControlConfiguracionBaseDeConocimiento control_configuracion;

        //********************************************************************************
        // Métodos
        //********************************************************************************
        public FormVentanaConfiguracion(GestionadorBaseConocimiento base_conocimiento)
        {
            this.base_conocimiento = base_conocimiento;
            InitializeComponent();
            
            this.control_configuracion = new Tot.ControlConfiguracionBaseDeConocimiento(base_conocimiento);
            this.control_configuracion.Location = new System.Drawing.Point(0, 0);
            this.control_configuracion.Name = "control_configuracion";
            this.control_configuracion.Size = new System.Drawing.Size(713, 448);
            this.control_configuracion.TabIndex = 0;

            this.control_configuracion.evento_aceptar += control_configuracion_evento_aceptar;
            this.control_configuracion.evento_cancelar += control_configuracion_evento_aceptar;
            this.Controls.Add(this.control_configuracion);
            
        }

        void control_configuracion_evento_aceptar()
        {
            this.Visible = false;
        }

        /// <summary>
        /// Método que completa la ventana según los metadatos de la base de conocimieno
        /// </summary>
        public void completarVentana()
        {
            control_configuracion.mostrarMetadatos();
        }

        /// <summary>
        /// Método que inicializa los archivos de la base de conocimiento
        /// </summary>
        public void inicializarArchivosDeConfiguracionBaseDeConocimiento()
        {
            control_configuracion.inicializarArchivosMetadatos();
        }


        //********************************************************************************
        // Eventos
        //********************************************************************************

        private void FormVentanaConfiguracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (control_configuracion.cambios)
            {
                DialogResult result = MessageBox.Show("Se perderán los cambios realizados\n¿Usted desea cerrar la ventana?", "Configuración base de conocimiento", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Visible = false;
                }
            }
            else
            {
                this.Visible = false;
            }
            e.Cancel = true;
        }

        private void FormVentanaConfiguracion_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                control_configuracion.liberarRecursosImagenLogo();
            }
        }
    }
}
