using SistemaExpertoLib;
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
    public partial class FormVentanaGestiónBaseConocimiento : Form
    {
        struct ElementoListBox
        {
            public string id;
            public string nombre;
            public string prefijo;
            public string sufijo;

            public override string ToString()
            {
                string retorno = "";
                retorno += prefijo;
                if (prefijo != null && !prefijo.Equals(""))
                    retorno += "\t";
                retorno += id;
                if (id != null && !id.Equals(""))
                    retorno += "\t";
                retorno += nombre;
                if (nombre != null && !nombre.Equals(""))
                    retorno += "\t";
                if (sufijo != null)
                    retorno += sufijo;
                return retorno;
            }
        }

        public GestionadorBaseConocimiento base_conocimiento;

        public FormVentanaGestiónBaseConocimiento(GestionadorBaseConocimiento base_conocimiento)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
            //Gestion de variables
            control_gestion_variables.base_conocimiento = this.base_conocimiento;
            control_gestion_variables.actualizarListaDeVariables();
            


            // Gestión de reglas
            control_gestion_de_reglas.base_conocimiento = base_conocimiento;
            control_gestion_de_reglas.actualizarListaDeReglas();
        }

        public void editarVariable(string id_variable, string nombre_variable){
        	control_gestion_variables.setearVariableAModificar(id_variable,nombre_variable);
        }
        
        public void listarHechos()
        {
            listBox_hechos.Items.Clear();
            string[] ids_hechos = base_conocimiento.listarHechos();
            for (int i = 0; i < ids_hechos.Length; i++)
            {
                Hecho hecho = base_conocimiento.leerHecho(ids_hechos[i]);
                ElementoListBox elemento = new ElementoListBox()
                {
                    id = hecho.id_hecho,
                    nombre = hecho + ""
                };
                listBox_hechos.Items.Add(elemento);
            }
            listBox_hechos.Refresh();
        }


        private void button_update_Click(object sender, EventArgs e)
        {
            listarHechos();
        }

        private void tabPage_reglas_Enter(object sender, EventArgs e)
        {
            control_gestion_de_reglas.actualizarListaDeReglas();
        }

        private void tabPage_hechos_Enter(object sender, EventArgs e)
        {
            listarHechos();
        }

        private void tabPage_variables_Enter(object sender, EventArgs e)
        {
            control_gestion_variables.actualizarListaDeVariables();

        }

        private void button_cheuquear_hechos_Click(object sender, EventArgs e)
        {
            string[] id_hechos = base_conocimiento.listarHechos();
            for (int i = 0; i < id_hechos.Length; i++)
            {
                base_conocimiento.actualizarAtributosHecho(id_hechos[i]);
            }
            MessageBox.Show("Los hechos fueron chequeados", "Gestión base conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormVentanaGestiónBaseConocimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void FormVentanaGestiónBaseConocimiento_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                control_gestion_variables.limpiarControlGestionVariables();
                control_gestion_de_reglas.limpiarControlGestionRegla();
            }
                
        }
        



    }
}
