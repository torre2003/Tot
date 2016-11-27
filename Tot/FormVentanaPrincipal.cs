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
        FormVentanaGestiónBaseConocimiento ventana_gestion_de_conocimiento;
        GestionadorBaseConocimiento base_conocimiento;
        
        public FormVentanaPrincipal()
        {
            base_conocimiento = new GestionadorBaseConocimiento();
            ventana_gestion_de_conocimiento = new FormVentanaGestiónBaseConocimiento(base_conocimiento);
            InitializeComponent();
            ventana_gestion_de_conocimiento.MdiParent = this;
        }

        private void iniciarInferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVentanaInferencia ventana_inferencia = new FormVentanaInferencia(base_conocimiento.ruta_carpeta_archivos);
            ventana_inferencia.ShowDialog(this);
        }

        private void ToolStripMenuItem_editor_base_conocimiento_Click(object sender, EventArgs e)
        {
            ventana_gestion_de_conocimiento.Visible = true;
        }

        private void ToolStripMenuItem_salir_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }

}
