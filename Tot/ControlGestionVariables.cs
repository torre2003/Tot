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
using System.IO;
using System.Collections;
namespace Tot
{
    public partial class ControlGestionVariables : UserControl
    {
        struct ElementoListBox : IComparer
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

            public int Compare(object x, object y)
            {
                ElementoListBox a = (ElementoListBox)x;
                ElementoListBox b = (ElementoListBox)y;
                return a.nombre.CompareTo(b.nombre);
            }
        }




        //*************************************************************************
        // Atributos
        //*************************************************************************

        public GestionadorBaseConocimiento base_conocimiento;

        /// <summary>
        /// Obtiene o establece la ID de la variable
        /// </summary>
        public string id
        {
            get
            {
                return textBox_id_variable.Text;
            }
            set
            {
                textBox_id_variable.Text = value;
            }
        }
        /// <summary>
        /// Obtiene o establece nombre de la variable
        /// </summary>
        public string nombre
        {
            get
            {
                return textBox_nombre.Text;
            }
            set
            {
                textBox_nombre.Text = value;
            }
        }

        /// <summary>
        /// Obtiene o establece texto de consulta de la variable
        /// </summary>
        public string texto_consulta
        {
            get
            {
                return textBox_texto_consulta.Text;
            }
            set
            {
                textBox_texto_consulta.Text = value;
            }
        }
        /// <summary>
        /// Obtiene o establece ruta del archivo RTF de la variable
        /// </summary>
        public string ruta_archivo_rtf
        {
            get
            {
                return _ruta_archivo_rtf;
            }
            set
            {
                _ruta_archivo_rtf = value;
            }
        }
        string _ruta_archivo_rtf ="";
        /// <summary>
        /// Obtiene o establece la ruta del archvo de imagen de la varaible
        /// </summary>
        public string ruta_archivo_imagen
        {
            get
            {
                return _ruta_archivo_imagen;
            }
            set
            {
                _ruta_archivo_imagen = value;
            }
        }
        string _ruta_archivo_imagen = "";

        /// <summary>
        /// Obtiene o establece si la variable de tipo numerica tiene un rango limitado
        /// </summary>
        public bool rango_limitado
        {
            get
            {
                return checkBox_rango.Checked;
            }
            set
            {
                checkBox_rango.Checked = value;
            }
        }
        /// <summary>
        /// Obtiene o establece si la variable es de inicio
        /// </summary>
        public bool variable_de_inicio
        {
            get
            {
                return checkBox_variable_de_inicio.Checked;
            }
            set
            {
                checkBox_variable_de_inicio.Checked = value;
            }
        }
        /// <summary>
        /// obtiene o estable si al varaible es preguntable al usuario
        /// </summary>
        public bool variable_preguntable_al_usuario
        {
            get
            {
                return checkBox_variable_preguntable_al_usuario.Checked;
            }
            set
            {
                checkBox_variable_preguntable_al_usuario.Checked = value;
            }
        }
        /// <summary>
        /// Obtiene o establece el valor minimo de una variable NUMERICA
        /// </summary>
        public string rango_min
        {
            get
            {
                return textBox_min_rango.Text;
            }
            set
            {
                textBox_min_rango.Text = value;
            }
        }
        /// <summary>
        /// Obtiene o establece el valor maximo de una variable de tipo NUMERICA
        /// </summary>
        public string rango_max
        {
            get
            {
                return textBox_max_rango.Text;
            }
            set
            {
                textBox_max_rango.Text = value;
            }
        }
        /// <summary>
        /// Establece la ruta por defecto del FileChoser
        /// </summary>
        public string directorio_inicial_OpenFileChooser
        {
            set
            {
                openFileDialog_archivos_RTF.InitialDirectory = value;
                openFileDialog_imagenes.InitialDirectory = value;
            }
        }

       
        const int DESABILITADO = 0;
        const int AGREGANDO = 1;
        const int MODIFICANDO = 2;
        const int ELIMINANDO = 3;

        int tipo_tarea = DESABILITADO;
        string id_variable_en_tarea = null;
        string nombre_variable_en_tarea = "";
        string ruta_rtf_actual = null;

        //*************************************************************************
        // Métodos
        //*************************************************************************

        /// <summary>
        /// Constructor
        /// </summary>        
        public ControlGestionVariables()
        {
            InitializeComponent();
            controlesHabilitados(false);
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="base_conocimiento">Objeto necesario para gestionar la base de conocimiento</param>
        public ControlGestionVariables(GestionadorBaseConocimiento base_conocimiento)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
            controlesHabilitados(false);
            actualizarListaDeVariables();
            
        }





        /// <summary>
        /// Método que habilita o deshabilita los controles de edición
        /// </summary>
        /// <param name="habilitado">Estado de los controles</param>
        public void controlesHabilitados(bool habilitado, bool modificando = false)
        {
            checkBox_variable_de_inicio.Enabled = habilitado;
            checkBox_variable_preguntable_al_usuario.Enabled = habilitado;
            textBox_nombre.Enabled = habilitado;
            radioButton_tipo_booleano.Enabled = habilitado;
            radioButton_tipo_numerico.Enabled = habilitado;
            radioButton_tipo_lista.Enabled = habilitado;

            radioButton_cardinal.Enabled = habilitado;
            radioButton_Continuo.Enabled = habilitado;
            button_agregar_elemento_lista_a_variable.Enabled = habilitado;
            button_eliminar_elemento_lista_variable.Enabled = habilitado;
            textBox_ingreso_elemento_lista_variable.Enabled = habilitado;
            if (modificando)
            {
                radioButton_tipo_booleano.Enabled = !habilitado;
                radioButton_tipo_numerico.Enabled = !habilitado;
                radioButton_tipo_lista.Enabled = !habilitado;
            }
            listBox_lista_de_elementos_variables.Enabled = habilitado;
            button_seleccion_documento.Enabled = habilitado;
            textBox_texto_consulta.Enabled = habilitado;

            button_aceptar.Visible = habilitado;
            button_cancelar.Visible = habilitado;

            button_agregar_variable.Enabled = !habilitado;
            button_modificar_variable.Enabled = !habilitado;
            button_eliminar_variable.Enabled = !habilitado;

            checkBox_rango.Enabled = habilitado;
            if (modificando)
            {
                textBox_max_rango.Enabled = checkBox_rango.Checked;
                textBox_min_rango.Enabled = checkBox_rango.Checked;
            }
            else
            {
                textBox_max_rango.Enabled = false;
                textBox_min_rango.Enabled = false;
            }
        }

        /// <summary>
        /// Método que limpia todos los campos del control
        /// </summary>
        public void limpiarCampos()
        {
            textBox_id_variable.Text = "";
            textBox_nombre.Text = "";
            textBox_min_rango.Text = "";
            textBox_max_rango.Text = "";
            textBox_texto_consulta.Text = "";
            textBox_ingreso_elemento_lista_variable.Text = "";
            listBox_lista_de_elementos_variables.Items.Clear();
            listBox_lista_de_elementos_variables.Refresh();

            radioButton_tipo_booleano.Checked = false;
            radioButton_tipo_numerico.Checked = false;
            radioButton_tipo_lista.Checked = false;
            rango_limitado = false;
            variable_de_inicio = false;
            variable_preguntable_al_usuario = false;
            radioButton_cardinal.Checked = false;
            radioButton_Continuo.Checked = false;
            cambiarEstadoPanelesTipoVariable();

        }

        /// <summary>
        /// Método que desmarca todos los campos del control
        /// </summary>
        public void desmarcarCampos()
        {
            marcarControl(NOMBRE, false);
            marcarControl(TIPOS_DE_VARIABLE, false);
            marcarControl(TEXTO_CONSULTA, false);
            marcarControl(TIPO_NUMERICO, false);
            marcarControl(RANGOS, false);
            marcarControl(INGRESO_ELEMENTO, false);
            marcarControl(LISTA_DE_ELEMENTOS, false);
        }


        const int NOMBRE = 1;
        const int TIPOS_DE_VARIABLE = 2;
        const int TEXTO_CONSULTA = 3;
        const int TIPO_NUMERICO = 4;
        const int RANGOS = 5;
        const int INGRESO_ELEMENTO = 6;
        const int LISTA_DE_ELEMENTOS = 7;
        /// <summary>
        /// Método que resalta los controles 
        /// </summary>
        /// <param name="tipo_de_control">Constante con el tipo de control</param>
        /// <param name="marcado">TRUE para amrcar el control y FALSE para estado normal</param>
        public void marcarControl(int tipo_de_control, bool marcado)
        {
            switch (tipo_de_control)
            {
                case NOMBRE:
                    if (marcado)
                        this.textBox_nombre.BackColor = System.Drawing.Color.Yellow;
                    else
                        this.textBox_nombre.BackColor = System.Drawing.SystemColors.Window;
                    break;
                case TIPOS_DE_VARIABLE:
                    if (marcado)
                    {
                        this.radioButton_tipo_booleano.BackColor = System.Drawing.Color.Yellow;
                        this.radioButton_tipo_numerico.BackColor = System.Drawing.Color.Yellow;
                        this.radioButton_tipo_lista.BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        this.radioButton_tipo_booleano.BackColor = System.Drawing.SystemColors.Window;
                        this.radioButton_tipo_numerico.BackColor = System.Drawing.SystemColors.Window;
                        this.radioButton_tipo_lista.BackColor = System.Drawing.SystemColors.Window;
                    }
                    break;
                case TEXTO_CONSULTA:
                    if (marcado)
                        this.textBox_texto_consulta.BackColor = System.Drawing.Color.Yellow;
                    else
                        this.textBox_texto_consulta.BackColor = System.Drawing.SystemColors.Window;
                    break;
                case TIPO_NUMERICO:
                    if (marcado)
                    {
                        this.radioButton_cardinal.BackColor = System.Drawing.Color.Yellow;
                        this.radioButton_Continuo.BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        this.radioButton_cardinal.BackColor = System.Drawing.SystemColors.Window;
                        this.radioButton_Continuo.BackColor = System.Drawing.SystemColors.Window;
                    }
                    break;
                case RANGOS:
                    if (marcado)
                    {
                        this.textBox_min_rango.BackColor = System.Drawing.Color.Yellow;
                        this.textBox_max_rango.BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        this.textBox_min_rango.BackColor = System.Drawing.SystemColors.Window;
                        this.textBox_max_rango.BackColor = System.Drawing.SystemColors.Window;
                    }
                    break;
                case INGRESO_ELEMENTO:
                    if (marcado)
                        this.textBox_ingreso_elemento_lista_variable.BackColor = System.Drawing.Color.Yellow;
                    else
                        this.textBox_ingreso_elemento_lista_variable.BackColor = System.Drawing.SystemColors.Window;
                    break;
                case LISTA_DE_ELEMENTOS:
                    if (marcado)
                        this.listBox_lista_de_elementos_variables.BackColor = System.Drawing.Color.Yellow;
                    else
                        this.listBox_lista_de_elementos_variables.BackColor = System.Drawing.SystemColors.Window;
                    break;
            }
        }


        /// <summary>
        /// Método que chequea los atributos de ingreso de una variable a la base de conocimiento
        /// </summary>
        /// <param name="chequear_nombre">Debe chequearse el nombre de la variable en el porceso</param>
        /// <returns>NULL si el chequeo es correcto o lista de errores</returns>
        public string[] chequeoVariable(bool chequear_nombre)
        {
            string retorno = "";
            if (nombre.Equals(""))
            {
                marcarControl(NOMBRE, true);
                retorno += "No se ha especificado el nombre de la variable";
            }
            if (chequear_nombre)
            {
                nombre = procesarTexto(nombre);
            }
            if (base_conocimiento.comprobarNombreVariable(nombre) && chequear_nombre)
            {

                marcarControl(NOMBRE, true);
                if (!retorno.Equals(""))
                    retorno += "|";
                retorno += "El nombre ya se encuentra en la base de conocimiento";
            }
            if (radioButton_tipo_booleano.Checked == false && radioButton_tipo_numerico.Checked == false && radioButton_tipo_lista.Checked == false)
            {
                if (!retorno.Equals(""))
                    retorno += "|";
                retorno += "No se ha selecionado el tipo de variable";
                marcarControl(TIPOS_DE_VARIABLE, true);
            }
            if ((variable_de_inicio || variable_preguntable_al_usuario) && texto_consulta.Equals(""))
            {
                if (!retorno.Equals(""))
                    retorno += "|";
                retorno += "El texto para la consulta de la variable no ha sido completado";
                marcarControl(TEXTO_CONSULTA, true);
            }
            if (radioButton_tipo_numerico.Checked && (!radioButton_cardinal.Checked && !radioButton_Continuo.Checked))
            {
                if (!retorno.Equals(""))
                    retorno += "|";
                retorno += "No se ha selecionado el tipo de variable NUMERICA";
                marcarControl(TIPO_NUMERICO, true);
            }
            if (rango_limitado)
            {
                try
                {
                    rango_min = rango_min.Replace('.', ',');
                    rango_max = rango_max.Replace('.', ',');

                    double min = Double.Parse(rango_min);
                    double max = Double.Parse(rango_max);

                    if (radioButton_Continuo.Checked && min >= max)
                    {
                        if (!retorno.Equals(""))
                            retorno += "|";
                        retorno += "El rango minimo es mayor o igual al maximo";
                        marcarControl(RANGOS, true);
                    }
                    else
                        if (radioButton_cardinal.Checked)
                        {
                            int min_int = (int)min;
                            int max_int = (int)max;
                            rango_min = "" + min_int;
                            rango_max = "" + max_int;
                            if (min_int >= max_int)
                            {
                                if (!retorno.Equals(""))
                                    retorno += "|";
                                retorno += "El rango minimo es mayor o igual al maximo";
                                marcarControl(RANGOS, true);
                            }
                        }
                }
                catch (Exception)
                {
                    if (!retorno.Equals(""))
                        retorno += "|";
                    retorno += "Rango mal escrito o faltante";
                    marcarControl(RANGOS, true);
                }
            }
            if (radioButton_tipo_lista.Checked && listBox_lista_de_elementos_variables.Items.Count == 0)
            {
                if (!retorno.Equals(""))
                    retorno += "|";
                retorno += "La lista de elementos esta vacia";
                marcarControl(LISTA_DE_ELEMENTOS, true);
            }
          
            if (retorno.Equals(""))
                return null;
            return retorno.Split('|');
        }


        /// <summary>
        /// Método que elimina el espaciones en blanco demás, tabulaciones, y saltos de linea de la cadena
        /// </summary>
        /// <param name="texto_a_procesar">Cadena a procesar</param>
        /// <returns>Texto procesado</returns>
        public string procesarTexto(string texto_a_procesar)
        {
            string texto = texto_a_procesar;
            texto = texto.ToLower();
            texto = texto.Replace('\t', ' ');
            texto = texto.Replace('\r', ' ');
            texto = texto.Replace('\n', ' ');
            //texto = texto.Replace('\"', ' ');
            string[] palabras = texto.Split(' ');
            string texto_de_retorno = "";
            for (int i = 0; i < palabras.Length; i++)
            {
                if (!palabras[i].Equals(""))
                {
                    if (texto_de_retorno != "")
                        texto_de_retorno += " ";
                    texto_de_retorno += palabras[i];
                }
            }
            return texto_de_retorno;
        }

        /// <summary>
        /// Método que ingresa la nueva variable a la base de conocimiento
        /// </summary>
        /// <returns>Id de la variable si la varaible fue agregada correctamente, null en caso contrario</returns>
        public string agregarNuevaVariable()
        {
            int tipo_variable = 0;
            if (radioButton_tipo_booleano.Checked)
                tipo_variable = Variable.BOOLEANO;
            if (radioButton_tipo_numerico.Checked)
                tipo_variable = Variable.NUMERICO;
            if (radioButton_tipo_lista.Checked)
                tipo_variable = Variable.LISTA;
            string[] lista_opciones = null;
            if (radioButton_tipo_lista.Checked)
            {
                lista_opciones = new string[listBox_lista_de_elementos_variables.Items.Count];
                int i = 0;
                foreach (ElementoListBox item in listBox_lista_de_elementos_variables.Items)
                {
                    lista_opciones[i] = item.nombre;
                    i++;
                }
            }

            try
            {
                string id_nueva_variable = base_conocimiento.agregarNuevaVariable(nombre, tipo_variable, lista_opciones);
                if (id_nueva_variable == null)
                    MessageBox.Show("Problemas al ingresar la variable ", "Agregando variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (radioButton_tipo_numerico.Checked)
                    {
                        if (radioButton_cardinal.Checked)
                        {
                            base_conocimiento.modificarAtributosVariableNumerica(id_nueva_variable, true);
                        }
                        if (rango_limitado)
                        {
                            double min = Double.Parse(rango_min);
                            double max = Double.Parse(rango_max);
                            base_conocimiento.modificarAtributosVariableNumerica(id_nueva_variable, true, min, max);
                        }
                    }
                    string texto_consulta = null;
                    string ruta_rtf = null;
                    string ruta_imagen = null;

                    if (!this.texto_consulta.Equals(""))
                        texto_consulta = this.texto_consulta;
                    if (!this.ruta_archivo_rtf.Equals(""))
                        ruta_rtf = this.ruta_archivo_rtf;
                    if (!this.ruta_archivo_imagen.Equals(""))
                        ruta_imagen = this.ruta_archivo_imagen;

                    base_conocimiento.modificarMetadatosVariable(id_nueva_variable, variable_de_inicio, variable_preguntable_al_usuario, texto_consulta: texto_consulta, ruta_texto_descriptivo: ruta_archivo_rtf, ruta_imagen_descriptiva: ruta_imagen);
                    MessageBox.Show("Variable Agregada correctamente", "Agregando variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return id_nueva_variable;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Problemas al ingresar la variable \n" + e, "Agregando variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return null;
        }

        /// <summary>
        /// Métod que agrega elementos a la lista de elementos de la variable
        /// </summary>
        public void agregarElementoALista()
        {
            marcarControl(INGRESO_ELEMENTO, false);
            marcarControl(LISTA_DE_ELEMENTOS, false);
            if (textBox_ingreso_elemento_lista_variable.Text.Equals(""))
            {
                MessageBox.Show("El campo se encuentra vacio", "Agregando elemento a lista variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                marcarControl(INGRESO_ELEMENTO, true);
                return;
            }
            bool flag = true;
            string elemento_a_ingresar = textBox_ingreso_elemento_lista_variable.Text;
            elemento_a_ingresar = procesarTexto(elemento_a_ingresar);
            foreach (ElementoListBox item in listBox_lista_de_elementos_variables.Items)
            {
                if (item.nombre.Equals(elemento_a_ingresar))
                    flag = false;
            }
            if (!flag)
            {
                MessageBox.Show("El elemento ya existe en la lista", "Agregando elemento a lista variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                marcarControl(INGRESO_ELEMENTO, true);
                return;
            }
            ElementoListBox elemento = new ElementoListBox()
            {
                nombre = elemento_a_ingresar
            };
            listBox_lista_de_elementos_variables.Items.Add(elemento);
            listBox_lista_de_elementos_variables.Refresh();
            textBox_ingreso_elemento_lista_variable.Text = "";
        }

        /// <summary>
        /// Método para eliminar un elemento de la lista de elementos de la variable
        /// </summary>
        public void eliminarElementoALista()
        {
            marcarControl(INGRESO_ELEMENTO, false);
            marcarControl(LISTA_DE_ELEMENTOS, false);
            if (listBox_lista_de_elementos_variables.SelectedItem == null)
            {
                MessageBox.Show("No se ha seleccionado elemento en la lista", "Eliminando elemento a lista variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                marcarControl(LISTA_DE_ELEMENTOS, true);
                return;
            }
            else
            {
                object elemento_seleciondado = listBox_lista_de_elementos_variables.SelectedItem;
                if (tipo_tarea == AGREGANDO)
                {
                    listBox_lista_de_elementos_variables.Items.Remove(elemento_seleciondado);
                }
                if (tipo_tarea == MODIFICANDO)
                {
                    ElementoListBox aux = (ElementoListBox)elemento_seleciondado;
                    string[] hechos_que_contienen_el_elemento_de_la_varaible = base_conocimiento.listarHechosConVariable(id, aux.nombre);
                    if (hechos_que_contienen_el_elemento_de_la_varaible != null)
                    {
                        if (preguntasSiNoCancelar("Eliminando elemento en variable", "El elemento de la variable se encuentra seleccionado en una o varias reglas\n ¿Usted desea continuar?") == 1)
                        {
                            listBox_lista_de_elementos_variables.Items.Remove(elemento_seleciondado);
                            
                            MessageBox.Show("Los cambios se concretaran al apretar aceptar", "Eliminando elemento a lista variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        listBox_lista_de_elementos_variables.Items.Remove(elemento_seleciondado);
                    }
                }

            }
        }

        /// <summary>
        /// Método que muestra la información de una variable en el control
        /// </summary>
        /// <param name="id_variable"></param>
        public void mostrarInformaciónVariable(string id_variable)
        {
            limpiarCampos();
            Variable variable = base_conocimiento.leerVariable(id_variable);

            id = variable.id_variable;
            nombre = variable.nombre_variable;
            variable_de_inicio = variable.variable_de_inicio;
            variable_preguntable_al_usuario = variable.variable_preguntable_al_usuario;
            switch (variable.tipo_variable)
            {
                case Variable.BOOLEANO:
                    radioButton_tipo_booleano.Checked = true;
                    break;
                case Variable.NUMERICO:
                    radioButton_tipo_numerico.Checked = true;
                    if (variable.cardinal)
                        radioButton_cardinal.Checked = true;
                    else
                        radioButton_Continuo.Checked = true;

                    rango_limitado = variable.rango_limitado;
                    if (rango_limitado)
                    {
                        rango_min = "" + variable.rango_limite_inferior;
                        rango_max = "" + variable.rango_limite_superior;
                        textBox_max_rango.Enabled = false;
                        textBox_min_rango.Enabled = false;
                    }
                    break;
                case Variable.LISTA:
                    radioButton_tipo_lista.Checked = true;
                    string[] elementos = variable.listarOpciones();
                    for (int i = 0; i < elementos.Length; i++)
                    {
                        ElementoListBox elemento = new ElementoListBox()
                        {
                            nombre = elementos[i]
                        };
                        listBox_lista_de_elementos_variables.Items.Add(elemento);
                    }
                    break;
            }
            if (variable.texto_consulta_variable != null && !variable.texto_consulta_variable.Equals(""))
                texto_consulta = variable.texto_consulta_variable;
            if (variable.ruta_texto_descriptivo != null && !variable.ruta_texto_descriptivo.Equals(""))
                ruta_archivo_rtf = variable.ruta_texto_descriptivo;
            if (variable.ruta_imagen_descriptiva != null && !variable.ruta_imagen_descriptiva.Equals(""))
                ruta_archivo_imagen = variable.ruta_imagen_descriptiva;
        }

        /// <summary>
        /// método para la eliminacion de la varaible de la base de conocimiento 
        /// </summary>
        /// <param name="id_variable"></param>
        /// <returns>TRUE si la varaible fue eliminada, FALSE en caso contrario</returns>
        private bool eliminarVariable(string id_variable)
        {
            string[] listaDeHechosConVariable = base_conocimiento.listarHechosConVariable(id_variable);
            if (listaDeHechosConVariable == null)
            {
                base_conocimiento.eliminarVariable(id_variable);
                MessageBox.Show("La variable fue eliminada correctamente", "Eliminando varaible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                eliminarRTF(id_variable);
                return true;
            }
            else
            {
                if (1 == preguntasSiNoCancelar("Elimando variable", "La eliminación afectara algunas reglas y hechos de la base de conocimiento.\n ¿Usted desea continuar?"))
                {
                    base_conocimiento.desmarcarChequeoDeConsistenciaEnHechosYReglas(id_variable, true);
                    base_conocimiento.eliminarVariable(id_variable);
                    MessageBox.Show("La variable ha sido eliminada correctamente,\n Se han marcado las reglas afectadas", "Eliminando variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    eliminarRTF(id_variable);
                    return true;
                    /*
                    int opcion = preguntasSiNoCancelar("Eliminando variables", "¿Desea eliminar los hechos asociados a la variable?");
                    if (opcion == 1)
                    {
                        base_conocimiento.desmarcarChequeoDeConsistenciaEnHechosYReglas(id_variable, true);
                        base_conocimiento.eliminarVariable(id_variable);
                        MessageBox.Show("La variable ha sido eliminada correctamente,\n Se han marcado las reglas afectadas", "Eliminando variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                        if (opcion == 0)
                        {
                            base_conocimiento.desmarcarChequeoDeConsistenciaEnHechosYReglas(id_variable);
                            base_conocimiento.eliminarVariable(id_variable);
                            MessageBox.Show("La variable ha sido eliminada correctamente,\n Se han marcado las reglas afectadas", "Eliminando variable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                     */ 
                }
            }
            return false;
        }

        /// <summary>
        /// Método que actualiza la modificacion de la variable
        /// </summary>
        /// <returns>TRUE si la variable fue modificada, FALSE en caso contrario</returns>
        private bool modificandoVariable(string id_variable)
        {
            Variable variable = base_conocimiento.leerVariable(id_variable);
            bool flag = false;
            string[] opciones_nuevas = null;
            string[] opciones_antiguas = null;
            if (variable.tipo_variable == Variable.NUMERICO)
            {
                if (variable.cardinal == false && radioButton_cardinal.Checked)//si la variable a cambiado de real a cardinal
                {
                    string[] lista_de_hechos = base_conocimiento.listarHechosConVariable(id_variable);
                    if (lista_de_hechos != null)
                        flag = true;
                }
                if (variable.rango_limitado == false && rango_limitado)//si se ha establecido un rango a la variable
                {
                    double min = Double.Parse(rango_min);
                    double max = Double.Parse(rango_max);
                    string[] lista_de_hechos = base_conocimiento.listarHechosConVariable(id_variable, min, max);
                    if (lista_de_hechos != null)
                        flag = true;
                }
                if (variable.rango_limitado)//si han cambiado los rangos de la variable
                {
                    double min = Double.Parse(rango_min);
                    double max = Double.Parse(rango_max);
                    if (variable.rango_limite_inferior == min || variable.rango_limite_superior == max)
                    {
                        string[] lista_de_hechos = base_conocimiento.listarHechosConVariable(id_variable, min, max);
                        if (lista_de_hechos != null)
                            flag = true;
                    }
                }
            }
            else
                if (variable.tipo_variable == Variable.LISTA)
                {
                    opciones_nuevas = new string[listBox_lista_de_elementos_variables.Items.Count];
                    int i = 0;
                    foreach (ElementoListBox item in listBox_lista_de_elementos_variables.Items)
                    {
                        opciones_nuevas[i] = item.nombre;
                        i++;
                    }
                    opciones_antiguas = variable.listarOpciones();
                    for (int j = 0; j < opciones_antiguas.Length; j++)//buscando las opciones eliminadas
                    {
                        bool flag_2 = false;
                        for (int k = 0; k < opciones_nuevas.Length; k++)
                        {
                            if (opciones_antiguas[j].Equals(opciones_nuevas[k]))
                            {
                                flag_2 = true;
                                opciones_nuevas[k] = "";
                            }

                        }
                        if (flag_2)
                            opciones_antiguas[j] = "";
                    }//solo quedan las opciones agregadas en opciones nuevas y eliminadas en opciones antiguas

                    for (int q = 0; q < opciones_antiguas.Length && !flag; q++) //buscando si algun elemento eliminado influye en un hecho
                    {
                        if (!opciones_antiguas.Equals(""))
                        {
                            string[] lista_de_hechos_con_elemento = base_conocimiento.listarHechosConVariable(id_variable, opciones_antiguas[q]);
                            if (lista_de_hechos_con_elemento != null)
                                flag = true;
                        }
                    }
                }


            if (flag)
            {
                if (1 != preguntasSiNoCancelar("Modificando variable", "Las modificaciones afectarán hechos y reglas,\n ¿Usted desea continuar?"))
                    return false;
            }
            else
                if (1 != preguntasSiNoCancelar("Modificando variable", "Se modificara la variable,\n ¿Usted desea continuar?"))
                    return false;
            base_conocimiento.modificarMetadatosVariable(id_variable, variable_de_inicio, variable_preguntable_al_usuario, nombre, texto_consulta, ruta_archivo_rtf, ruta_archivo_imagen);
            if (variable.tipo_variable == Variable.NUMERICO)
            {
                base_conocimiento.modificarAtributosVariableNumerica(id_variable, radioButton_cardinal.Checked);

                if (variable.cardinal == false && radioButton_cardinal.Checked)//si la variable a cambiado de real a cardinal
                {
                    base_conocimiento.desmarcarChequeoDeConsistenciaEnHechosYReglas(id_variable);
                }
                if (rango_limitado)
                {
                    double min = Double.Parse(rango_min);
                    double max = Double.Parse(rango_max);
                    base_conocimiento.modificarAtributosVariableNumerica(id_variable, rango_limitado, min, max);
                    base_conocimiento.desmarcarChequeoDeConsistenciaEnHechosYReglas(id_variable, min, max);
                }
                else
                {
                    base_conocimiento.modificarAtributosVariableNumerica(id_variable, rango_limitado);
                }
            }
            else
                if (variable.tipo_variable == Variable.LISTA)
                {
                    for (int i = 0; i < opciones_nuevas.Length; i++)
                    {
                        if (!opciones_nuevas[i].Equals(""))
                            base_conocimiento.agregarElementoListaVariable(id_variable, opciones_nuevas[i]);
                    }
                    for (int i = 0; i < opciones_antiguas.Length; i++)
                    {
                        if (!opciones_antiguas[i].Equals(""))
                        {
                            base_conocimiento.eliminarElementoListaVariable(id_variable, opciones_antiguas[i]);
                            base_conocimiento.desmarcarChequeoDeConsistenciaEnHechosYReglas(id_variable, false, opciones_antiguas[i]);
                        }

                    }
                }
            return true;
        }


        /// <summary>
        /// Método que actualiz la lista de variables en el listbox
        /// </summary>
        public void actualizarListaDeVariables()
        {
            listBox_variables.Items.Clear();
            string[] id_variables = base_conocimiento.listarVariables();
            ArrayList lista_de_elementos =  new ArrayList();
            if (id_variables != null)
            {
                for (int i = 0; i < id_variables.Length; i++)
                {
                    Variable variable = base_conocimiento.leerVariable(id_variables[i]);
                    ElementoListBox elemento = new ElementoListBox()
                    {
                        id = variable.id_variable,
                        nombre = variable.nombre_variable
                    };
                    string aux = "";
                    if (!variable.chequeo_de_consistencia)
                        aux += " (No Chequeado)";
                    if (variable.variable_de_inicio)
                        aux += " [Inicial]";
                    if (variable.variable_preguntable_al_usuario)
                        aux += " [¿?]";
                    elemento.sufijo = aux;
                    lista_de_elementos.Add(elemento);
                   // listBox_variables.Items.Add(elemento);
                }
            }
            lista_de_elementos.Sort(new ElementoListBox());
            foreach (ElementoListBox item in lista_de_elementos)
            {
                listBox_variables.Items.Add(item);
            }
            
            listBox_variables.Refresh();

            
        }


        /// <summary>
        /// Método para realizar una pregunta de tipo si no cancelar
        /// </summary>
        /// <param name="titulo">Titulo en el cuadro</param>
        /// <param name="pregunta">Pregunta a realizar</param>
        /// <returns>1 = si, 0 = no, -1 cancel</returns>
        public int preguntasSiNoCancelar(string titulo, string pregunta)
        {
            DialogResult result = MessageBox.Show(pregunta, titulo, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return 1;
            if (result == DialogResult.No)
                return 0;
            return -1;
        }

        /// <summary>
        /// Método que limpia las marcas de los campos en el control
        /// </summary>
        public void limpiarMarcasControl()
        {
            marcarControl(NOMBRE, false);
            marcarControl(TIPOS_DE_VARIABLE, false);
            marcarControl(TEXTO_CONSULTA, false);
            marcarControl(TIPO_NUMERICO, false);
            marcarControl(RANGOS, false);
            marcarControl(INGRESO_ELEMENTO, false);
            marcarControl(LISTA_DE_ELEMENTOS, false);
        }


        private void eliminarRTF(string nombre)
        {
            string ruta_rtf_temporal = base_conocimiento.ruta_carpeta_archivos + "rtf" + "\\"+nombre+".rtf";
            if (File.Exists(ruta_rtf_temporal))
            {
                try
                {
                    File.Delete(ruta_rtf_temporal);
                }
                catch (Exception) { }
            }
            ruta_rtf_actual = null;
        }



        private void limpiarArchivoTemporalRTF()
        {
            string ruta_rtf_temporal = base_conocimiento.ruta_carpeta_archivos + "rtf"+"\\temporal.rtf";
            if (File.Exists(ruta_rtf_temporal))
            {
                try
                {
                    File.Delete(ruta_rtf_temporal);
                }
                catch (Exception){}
            }
            ruta_rtf_actual = null;
        }
        private void renombrarRTFTemporal(string id_variable)
        {
            string ruta_rtf_temporal = base_conocimiento.ruta_carpeta_archivos + "rtf" + "\\temporal.rtf";
            if (ruta_rtf_actual != null)
                if (ruta_rtf_actual.Equals(ruta_rtf_temporal))
                {
                    string ruta_archivo_variable  = base_conocimiento.ruta_carpeta_archivos + "rtf" + "\\" + id_variable + ".rtf";
                    if (!File.Exists(ruta_archivo_variable))
                    {
                        if (File.Exists(ruta_rtf_temporal))
                            File.Move(ruta_rtf_temporal, ruta_archivo_variable); 
                    }
                    else
                    {
                        //todo eliminar
                        MessageBox.Show("El archivo ya existe");
                    }
                }
        }

        //*************************************************************************
        // Eventos
        //*************************************************************************

        private void radioButton_tipo_numerico_CheckedChanged(object sender, EventArgs e)
        {
            cambiarEstadoPanelesTipoVariable();
        }

        private void radioButton_tipo_lista_CheckedChanged(object sender, EventArgs e)
        {
            cambiarEstadoPanelesTipoVariable();
        }


        private void radioButton_tipo_booleano_CheckedChanged(object sender, EventArgs e)
        {
            cambiarEstadoPanelesTipoVariable();
        }


        public void cambiarEstadoPanelesTipoVariable()
        {
            if (radioButton_tipo_booleano.Checked)
            {
                panel_opciones_lista.Visible = false;
                panel_opciones_numerico.Visible = false;
            }
            else
                if (radioButton_tipo_numerico.Checked)
                {
                    panel_opciones_lista.Visible = false;
                    panel_opciones_numerico.Visible = true;
                }
                else
                    if (radioButton_tipo_lista.Checked)
                    {
                        panel_opciones_lista.Visible = true;
                        panel_opciones_numerico.Visible = false;
                    }
                    else
                    {
                        panel_opciones_lista.Visible = false;
                        panel_opciones_numerico.Visible = false;

                    }
        }

        private void button_seleccion_documento_Click(object sender, EventArgs e)
        {
            FormVentanaRTF ventana_editor_rtf = new FormVentanaRTF();
            if (ruta_rtf_actual == null)
            {
                ruta_rtf_actual = base_conocimiento.ruta_carpeta_archivos + "rtf";
                if (id_variable_en_tarea == null)
                    ruta_rtf_actual += "\\temporal.rtf";
                else
                    ruta_rtf_actual += "\\" + id_variable_en_tarea + ".rtf";
            }
            ventana_editor_rtf.ruta_archivo = ruta_rtf_actual;
            if (!File.Exists(ruta_rtf_actual))
                ventana_editor_rtf.cancelar_apertura_archivo  = true;
            ventana_editor_rtf.ShowDialog(this);
        }


        private void button_agregar_variable_Click(object sender, EventArgs e)
        {

            controlesHabilitados(true);
            limpiarCampos();
            desmarcarCampos();
            tipo_tarea = AGREGANDO;
            id_variable_en_tarea = null;
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            desmarcarCampos();
            limpiarCampos();
            controlesHabilitados(false);
            tipo_tarea = DESABILITADO;
            id_variable_en_tarea = null;
            limpiarArchivoTemporalRTF();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (tipo_tarea == AGREGANDO)
            {
                limpiarMarcasControl();
                string[] errores_de_chequeo = chequeoVariable(true);
                if (errores_de_chequeo == null)
                {
                    string id_nueva_variable = agregarNuevaVariable();
                    if (id_nueva_variable != null)
                    {
                        limpiarCampos();
                        controlesHabilitados(false);
                        tipo_tarea = DESABILITADO;
                        actualizarListaDeVariables();
                        renombrarRTFTemporal(id_nueva_variable);
                        ruta_rtf_actual = null;
                        limpiarArchivoTemporalRTF();
                    }
                }
                else
                {
                    string mensaje = "";
                    for (int i = 0; i < errores_de_chequeo.Length; i++)
                    {
                        if (i != 0)
                            mensaje += "\n";
                        mensaje += errores_de_chequeo[i];
                    }
                    MessageBox.Show(mensaje, "Agregando variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                if (tipo_tarea == MODIFICANDO)
                {
                    string[] errores_de_chequeo = null;
                    if (nombre_variable_en_tarea.Equals(nombre))
                        errores_de_chequeo = chequeoVariable(false);
                    else
                        errores_de_chequeo = chequeoVariable(true);
                    if (errores_de_chequeo == null)
                    {
                        if (modificandoVariable(id_variable_en_tarea))
                        {
                            limpiarCampos();
                            limpiarMarcasControl();
                            controlesHabilitados(false);
                            tipo_tarea = DESABILITADO;
                            actualizarListaDeVariables();
                            renombrarRTFTemporal(id_variable_en_tarea);
                            ruta_rtf_actual = null;
                            limpiarArchivoTemporalRTF();
                            id_variable_en_tarea = null;
                        }
                    }
                    else
                    {
                        string mensaje = "";
                        for (int i = 0; i < errores_de_chequeo.Length; i++)
                        {
                            if (i != 0)
                                mensaje += "\n";
                            mensaje += errores_de_chequeo[i];
                        }
                        MessageBox.Show(mensaje, "Modificando variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }


        private void checkBox_rango_CheckedChanged(object sender, EventArgs e)
        {
            if (rango_limitado == true)
            {
                textBox_min_rango.Text = "";
                textBox_min_rango.Enabled = true;
                textBox_max_rango.Text = "";
                textBox_max_rango.Enabled = true;
            }
            else
            {
                {
                    textBox_min_rango.Text = "";
                    textBox_min_rango.Enabled = false;
                    textBox_max_rango.Text = "";
                    textBox_max_rango.Enabled = false;
                }
            }

        }

        private void button_agregar_elemento_lista_a_variable_Click(object sender, EventArgs e)
        {
            agregarElementoALista();
        }

        private void button_eliminar_elemento_lista_variable_Click(object sender, EventArgs e)
        {
            eliminarElementoALista();
        }

        private void button_eliminar_variable_Click(object sender, EventArgs e)
        {
            if (tipo_tarea == DESABILITADO && id_variable_en_tarea != null)
            {
                if (eliminarVariable(id_variable_en_tarea))
                {
                    id_variable_en_tarea = null;
                    limpiarCampos();
                    limpiarMarcasControl();
                    actualizarListaDeVariables();
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna variable", "Eliminando variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_modificar_variable_Click(object sender, EventArgs e)
        {
            if (tipo_tarea == DESABILITADO && id_variable_en_tarea != null)
            {
                tipo_tarea = MODIFICANDO;
                controlesHabilitados(true, true);
                limpiarMarcasControl();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna variable", "Eliminando variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_variable_de_inicio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_variable_de_inicio.Checked)
            {
                checkBox_variable_preguntable_al_usuario.Checked = true;
            }
        }

        private void listBox_variables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_variables.SelectedItem != null && tipo_tarea == DESABILITADO)
            {
                ElementoListBox elemento = (ElementoListBox)listBox_variables.SelectedItem;
                mostrarInformaciónVariable(elemento.id);
                id_variable_en_tarea = elemento.id;
                nombre_variable_en_tarea = elemento.nombre;
            }
        }

        private void textBox_ingreso_elemento_lista_variable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                agregarElementoALista();
            }

        }





    }
}
