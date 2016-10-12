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

namespace PruebasSistemaExperto
{
    public partial class FormGestionHechos : Form
    {
             struct ElementosListBox
            {
                public string id ;
                public string info ;

                public override string ToString()
                {
                    return id +"  "+info;
                }

            }
        GestionadorBaseConocimiento base_conocimiento;
        
        public FormGestionHechos(GestionadorBaseConocimiento base_conocimiento)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
            inicializarTextBox();
        }

        public void inicializarTextBox()
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

        private void FormGestionHechos_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

        }

        private void button_agregar_hecho_Click(object sender, EventArgs e)
        {
            string id_hecho = base_conocimiento.agregarHecho(textBox_hecho.Text);

            listBox_hechos.Items.Add(new ElementosListBox() { 
                                                    id = id_hecho, 
                                                    info = textBox_hecho.Text 
                                                    } );
            textBox_hecho.Text = "";
        }

        private void button_eliminar_hecho_Click(object sender, EventArgs e)
        {
            if (listBox_hechos.SelectedItem != null)
            {
                ElementosListBox elemento_seleccionado = (ElementosListBox)listBox_hechos.SelectedItem;
                base_conocimiento.eliminarHecho(elemento_seleccionado.id);
                listBox_hechos.Items.Remove(elemento_seleccionado);
                MessageBox.Show("Elemento eliminado");
            }
        }






    }




}
