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
        }
        
        /// <summary>
        /// Método que actualiz la lista de variables en el listbox
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

        //*************************************************************************************************
        //  Eventos
        //*************************************************************************************************

        public ControlGestionReglas(GestionadorBaseConocimiento base_conocimiento)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
            actualizarListaDeReglas();
        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            control_edicion_de_reglas.actualizarListaDeVariables();
            control_edicion_de_reglas.Visible = true;
            control_edicion_de_reglas.tipo_tarea = ControlEdicionReglas.AGREGANDO;
        }

        private void actualizarListaReglas()
        {
            actualizarListaDeReglas();
        }
    }
}
