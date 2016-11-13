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

namespace Tot
{
    public partial class ControlGestionReglas : UserControl
    {
        public GestionadorBaseConocimiento base_conocimiento
        {
            get
            {
                return _base_conocimiento;
            }
            set
            {
                control_edicion_de_reglas.base_conocimiento = value;
                _base_conocimiento = value;
            }
        }
        GestionadorBaseConocimiento _base_conocimiento;

        public ControlGestionReglas()
        {
            InitializeComponent();
            control_edicion_de_reglas.Visible = false;
        }

        public ControlGestionReglas(GestionadorBaseConocimiento base_conocimiento)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            control_edicion_de_reglas.actualizarListaDeVariables();
            control_edicion_de_reglas.Visible = true;

        }


    }
}
