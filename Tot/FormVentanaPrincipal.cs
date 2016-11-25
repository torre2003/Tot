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
        FormVentanaGestiónBaseConocimiento ventana_gestion_de_usuario;
        GestionadorBaseConocimiento base_conocimiento;
        
        public FormVentanaPrincipal()
        {
            base_conocimiento = new GestionadorBaseConocimiento();
            ventana_gestion_de_usuario = new FormVentanaGestiónBaseConocimiento(base_conocimiento);
            InitializeComponent();
            ventana_gestion_de_usuario.MdiParent = this;
            ventana_gestion_de_usuario.Visible = true;

        }
    }
}
