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
        //*************************************************************************************************
        //  Atributos
        //*************************************************************************************************

        /// <summary>
        /// Objeto para gestión la base de conocimiento
        /// </summary>
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


        //*************************************************************************************************
        //  Métodos
        //*************************************************************************************************
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ControlGestionReglas()
        {
            InitializeComponent();
            control_edicion_de_reglas.Visible = false;
            control_edicion_de_reglas.evento_cambio_reglas += new DelegadoCambioEnReglas(actualizarListaDeReglas);
            control_edicion_de_reglas.evento_habilitar_controles += control_edicion_de_reglas_evento_habilitar_controles;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="base_conocimiento">Objeto base conocimiento a trabajar en el control</param>
        public ControlGestionReglas(GestionadorBaseConocimiento base_conocimiento)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
            actualizarListaDeReglas();
        }

        /// <summary>
        /// Método que actualiza la lista de variables en el listbox
        /// </summary>
        public void actualizarListaDeReglas()
        {
            listBox_reglas.Items.Clear();
            string[] id_reglas = base_conocimiento.listarReglas();
            if (id_reglas != null)
            {
                for (int i = 0; i < id_reglas.Length; i++)
                {
                    Regla regla = base_conocimiento.leerRegla(id_reglas[i]);
                    ElementoListBox elemento = new ElementoListBox()
                    {
                        id = regla.id_regla,
                        nombre = ""+regla
                    };
                    string aux = "";
                    if (!regla.chequeo_de_consistencia)
                        aux += "\t(No Chequeado)";
                    elemento.sufijo = aux;
                    listBox_reglas.Items.Add(elemento);
                }
            }
            listBox_reglas.Refresh();
        }

        /// <summary>
        /// Método que habilita o desabilita los controles
        /// </summary>
        /// <param name="habilitar">Estable la habilitacion de los controles</param>
        public void habilitarControles(bool habilitar)
        {
            button_agregar.Enabled = habilitar;
            button_modificar.Enabled = habilitar;
            button_eliminar.Enabled = habilitar;
        }

        //*************************************************************************************************
        //  Eventos
        //*************************************************************************************************

        

        private void button_agregar_Click(object sender, EventArgs e)
        {
            if (control_edicion_de_reglas.tipo_tarea == ControlEdicionReglas.DESABILITADO)
            {
                listBox_reglas.SelectedItem = null;
                control_edicion_de_reglas.iniciarTareaAgregado();
                habilitarControles(false);
            }
        }

        private void actualizarListaReglas()
        {
            actualizarListaDeReglas();
        }

       

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            if (listBox_reglas.SelectedItem != null && control_edicion_de_reglas.tipo_tarea == ControlEdicionReglas.DESABILITADO)
            {
                habilitarControles(false);
                ElementoListBox elemento = (ElementoListBox)listBox_reglas.SelectedItem;
                control_edicion_de_reglas.iniciarTareaEliminarRegla(elemento.id);
                listBox_reglas.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna regla.", "Gestión de reglas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox_reglas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_reglas.SelectedItem != null && control_edicion_de_reglas.tipo_tarea == ControlEdicionReglas.DESABILITADO)
            {
                ElementoListBox elemento = (ElementoListBox)listBox_reglas.SelectedItem;
                control_edicion_de_reglas.mostrarRegla(elemento.id);
            }
        }
        void control_edicion_de_reglas_evento_habilitar_controles(bool habilitar)
        {
            habilitarControles(habilitar);
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            if (listBox_reglas.SelectedItem != null && control_edicion_de_reglas.tipo_tarea == ControlEdicionReglas.DESABILITADO)
            {
                habilitarControles(false);
                ElementoListBox elemento = (ElementoListBox)listBox_reglas.SelectedItem;
                control_edicion_de_reglas.iniciarTareaModificaciónRegla(elemento.id);
                listBox_reglas.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna regla.", "Gestión de reglas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
