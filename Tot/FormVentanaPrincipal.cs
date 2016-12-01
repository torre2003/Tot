using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaExpertoLib;
using SistemaExpertoLib.GestionDelConocimiento;

namespace Tot
{
    public partial class FormVentanaPrincipal : Form
    {
        //*******************************************************************************************
        // Atributos
        //*******************************************************************************************
        
        GestionadorBaseConocimiento base_conocimiento;

        FormVentanaConfiguracion ventana_configuracion;
        FormVentanaGestiónBaseConocimiento ventana_gestion_de_conocimiento;

        //*******************************************************************************************
        // Métodos
        //*******************************************************************************************
        public FormVentanaPrincipal()
        {

            InitializeComponent(); 
            base_conocimiento = new GestionadorBaseConocimiento();

            ventana_configuracion = new FormVentanaConfiguracion(base_conocimiento);
            ventana_configuracion.MdiParent = this;

            if (!base_conocimiento.existe_base_de_conocimiento)
            {
                base_conocimiento.iniciarNuevaBaseDeConocimiento();
                ventana_configuracion.inicializarArchivosDeConfiguracionBaseDeConocimiento();
                MessageBox.Show("La base de conocimiento no ha sido creada.\n Se ha creado una nueva base de conocimiento vacia", "Gestión Base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ventana_configuracion.completarVentana();
                ventana_configuracion.Show();
            }
            ventana_gestion_de_conocimiento = new FormVentanaGestiónBaseConocimiento(base_conocimiento);
            ventana_gestion_de_conocimiento.MdiParent = this;
        }

        //*******************************************************************************************
        // Eventos
        //*******************************************************************************************
        private void iniciarInferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GestionMotorInferencia(base_conocimiento.ruta_carpeta_base_conocimiento, this).iniciarProceso();
        }

        private void ToolStripMenuItem_editor_base_conocimiento_Click(object sender, EventArgs e)
        {
            ventana_gestion_de_conocimiento.Visible = true;
        }

        private void ToolStripMenuItem_salir_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventana_configuracion.completarVentana();
            ventana_configuracion.Visible = true;
        }
    }

}
