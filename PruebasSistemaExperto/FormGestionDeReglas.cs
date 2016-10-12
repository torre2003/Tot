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

namespace PruebasSistemaExperto
{
    public partial class FormGestionDeReglas : Form
    {
        GestionadorBaseConocimiento base_conocimiento;

        struct ElementosListBox
        {
            public string id;
            public string info;

            public override string ToString()
            {
                return id + "  " + info;
            }

        }


        public FormGestionDeReglas(GestionadorBaseConocimiento base_conocimiento)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
            inicializarReglas();
        }


        public void inicializarReglas()
        {
            string[] lista_de_reglas = base_conocimiento.listarReglas();
            for (int i = 0; i < lista_de_reglas.Length; i++)
            {
                listBox_reglas.Items.Add(new ElementosListBox()
                {
                    id = lista_de_reglas[i],
                    info = formarCadenaRegla(base_conocimiento.leerRegla(lista_de_reglas[i]))
                });
            }
        }

        public string formarCadenaRegla(Regla regla)
        {
            string retorno = "";
            retorno += "SI ";

            string[] antecedentes = regla.listarAntecedentes();
            string[] consecuentes = regla.listarConsecuentes();

            for (int i = 0; i < antecedentes.Length; i++)
            {
                if (i != 0)
                    retorno += " Y ";
                Hecho hecho = base_conocimiento.leerHecho(antecedentes[i]);
                retorno += hecho.hecho;
            }

            retorno += " ENTONCES ";
            for (int i = 0; i < consecuentes.Length; i++)
            {
                if (i != 0)
                    retorno += " Y ";
                Hecho hecho = base_conocimiento.leerHecho(consecuentes[i]);
                retorno += hecho.hecho;
            }
            return retorno;
        }

        private void button_agregar_regla_Click(object sender, EventArgs e)
        {
            new FormModificacionDeReglas(base_conocimiento).ShowDialog(this);
            listBox_reglas.Items.Clear();
            inicializarReglas();
        }

        private void FormGestionDeReglas_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void button_eliminar_regla_Click(object sender, EventArgs e)
        {
            if (listBox_reglas.SelectedItem != null)
            {
                ElementosListBox elemento = (ElementosListBox)listBox_reglas.SelectedItem;
                base_conocimiento.eliminarRegla(elemento.id);
                listBox_reglas.Items.Remove(elemento);
            }
        }
    }
}
