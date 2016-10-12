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
    public partial class FormModificacionDeReglas : Form
    {
        struct ElementosListBox
        {
            public string id;
            public string info;

            public override string ToString()
            {
                return id + "  " + info;
            }
        }


        Regla regla_actual = null;
        bool es_nueva_regla = false;

        GestionadorBaseConocimiento base_conocimiento;
        public FormModificacionDeReglas(GestionadorBaseConocimiento base_conocimiento)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
            inicializarTextBoxHechos();
            es_nueva_regla = true;
        }


        public FormModificacionDeReglas(GestionadorBaseConocimiento base_conocimiento, string id_regla)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
            inicializarTextBoxHechos();
            regla_actual = base_conocimiento.leerRegla(id_regla);
            inicializarTextBoxAntecedentes();
            inicializarTextBoxConsecuentes();
        }


        public void inicializarTextBoxHechos()
        {
            string[] lista_de_hechos = base_conocimiento.listarHechos();
            for (int i = 0; i < lista_de_hechos.Length; i++)
            {
                Hecho hecho = base_conocimiento.leerHecho(lista_de_hechos[i]);
                listBox_hechos.Items.Add(new ElementosListBox()
                {
                    id = hecho.id_hecho,
                    info = hecho.hecho
                });
            }
        }

        public void inicializarTextBoxAntecedentes()
        {
            string[] lista_de_hechos = regla_actual.listarAntecedentes();
            for (int i = 0; i < lista_de_hechos.Length; i++)
            {
                Hecho hecho = base_conocimiento.leerHecho(lista_de_hechos[i]);
                listBox_hechos.Items.Add(new ElementosListBox()
                {
                    id = hecho.id_hecho,
                    info = hecho.hecho
                });
            }
        }

        public void inicializarTextBoxConsecuentes()
        {
            string[] lista_de_hechos = regla_actual.listarConsecuentes();
            for (int i = 0; i < lista_de_hechos.Length; i++)
            {
                Hecho hecho = base_conocimiento.leerHecho(lista_de_hechos[i]);
                listBox_hechos.Items.Add(new ElementosListBox()
                {
                    id = hecho.id_hecho,
                    info = hecho.hecho
                });
            }
        }


        public void ingresarNuevaRegla()
        {
            string[] antecedentes = new string[listBox_antecedentes.Items.Count];
            string[] consecuentes = new string[listBox_consecuentes.Items.Count];
            
            for (int i = 0; i < listBox_antecedentes.Items.Count; i++)
            {
                ElementosListBox elemento = (ElementosListBox)listBox_antecedentes.Items[i];
                antecedentes[i] = elemento.id;
            }
            for (int i = 0; i < listBox_consecuentes.Items.Count; i++)
            {
                ElementosListBox elemento = (ElementosListBox)listBox_consecuentes.Items[i];
                consecuentes[i] = elemento.id;
            }
            base_conocimiento.agregarRegla(antecedentes, consecuentes);
            MessageBox.Show("Regla ingresada");
        }


        private void Aceptar_Click(object sender, EventArgs e)
        {
            ingresarNuevaRegla();
            Dispose();
        }

        private void button_agregar_hecho_antecedente_Click(object sender, EventArgs e)
        {
            if (listBox_hechos.SelectedItem != null)
            {
                ElementosListBox elemento = (ElementosListBox)listBox_hechos.SelectedItem;
                listBox_antecedentes.Items.Add(elemento);
                listBox_hechos.Items.Remove(elemento);
            }
        }

        private void button_quitar_hecho_antecedente_Click(object sender, EventArgs e)
        {
            if (listBox_antecedentes.SelectedItem != null)
            {
                ElementosListBox elemento = (ElementosListBox)listBox_antecedentes.SelectedItem;
                listBox_antecedentes.Items.Remove(elemento);
                listBox_hechos.Items.Add(elemento);
            }
        }

        private void button_agregar_hecho_concecuente_Click(object sender, EventArgs e)
        {
            if (listBox_hechos.SelectedItem != null)
            {
                ElementosListBox elemento = (ElementosListBox)listBox_hechos.SelectedItem;
                listBox_consecuentes.Items.Add(elemento);
                listBox_hechos.Items.Remove(elemento);
            }
        }

        private void button_quitar_hecho_consecuente_Click(object sender, EventArgs e)
        {
            if (listBox_consecuentes.SelectedItem != null)
            {
                ElementosListBox elemento = (ElementosListBox)listBox_consecuentes.SelectedItem;
                listBox_consecuentes.Items.Remove(elemento);
                listBox_hechos.Items.Add(elemento);
            }
        }


    }




}
