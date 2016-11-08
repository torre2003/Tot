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

namespace Tot
{
    public partial class FormVentanaGestiónBaseConocimiento : Form
    {

        public GestionadorBaseConocimiento base_conocimiento;

        public FormVentanaGestiónBaseConocimiento(GestionadorBaseConocimiento base_conocimiento)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
            control_gestion_variables.base_conocimiento = this.base_conocimiento;
            control_gestion_variables.actualizarListaDeVariables();
        }


    }
}
