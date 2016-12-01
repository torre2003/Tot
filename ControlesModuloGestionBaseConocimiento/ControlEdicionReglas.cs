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
using System.Collections;
using SistemaExpertoLib.GestionDelConocimiento;

namespace Tot
{
    public delegate void DelegadoHabilitarControles(bool habilitar);
    public delegate void DelegadoCambioEnReglas ();

    public partial class ControlEdicionReglas : UserControl
    {
        struct ElementoComboBox :IComparer
        {
            public string id;
            public string nombre;

            public override string ToString()
            {
                return nombre;
            }



            public int Compare(object x, object y)
            {
                ElementoComboBox a = (ElementoComboBox)x;
                ElementoComboBox b = (ElementoComboBox)y;
                return a.nombre.CompareTo(b.nombre);

            }
        }

        //*************************************************************************
        // Atributos
        //*************************************************************************
        ElementoComboBox[] lista_de_variables;

        public GestionadorBaseConocimiento base_conocimiento;
        ArrayList lista_labels_iniciales = new ArrayList();
        ArrayList lista_de_combo_box_variable = new ArrayList();
        ArrayList lista_de_combo_box_condicion = new ArrayList();
        ArrayList lista_de_object_valor_condicion = new ArrayList();
        ArrayList lista_label_rangos = new ArrayList();
        ArrayList lista_de_button_eliminar = new ArrayList();

        int posicion_base_y = 40;
        int ultima_posicion_y = 40;

        public const int DESABILITADO = 0;
        public const int AGREGANDO = 1;
        public const int MODIFICANDO = 2;
        public const int ELIMINANDO = 3;

        public int tipo_tarea = 0;

        int ultima_id_interna = 0;

        public event DelegadoCambioEnReglas evento_cambio_reglas;
        public event DelegadoHabilitarControles evento_habilitar_controles;
        //*************************************************************************
        // Métodos
        //*************************************************************************
        /// <summary>
        /// Constructor
        /// </summary>
        public ControlEdicionReglas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="base_conocimiento">Objeto para consultar la base de conocimiento</param>
        public ControlEdicionReglas(GestionadorBaseConocimiento base_conocimiento)
        {
            InitializeComponent();
            this.base_conocimiento = base_conocimiento;
        }

        #region Gestion controles

        /// <summary>
        /// Método que desmarca todos los controles en la regla 
        /// </summary>
        public void desmarcarControles()
        {
            //antecedentes
            foreach (ComboBox combo in lista_de_combo_box_variable)
                marcarControl(combo, false);
            foreach (ComboBox combo in lista_de_combo_box_condicion)
                marcarControl(combo, false);
            foreach (object aux in lista_de_object_valor_condicion)
                marcarControl(aux, false);
            //consecuente
            marcarControl(comboBox_var_entonces, false);
            marcarControl(comboBox_lista_entonces, false);
            marcarControl(comboBox_condicion_entonces, false);
            marcarControl(textBox_entonces, false);
            marcarControl(numericUpDown_entonces, false);
        }

        /// <summary>
        /// Método que marca el control
        /// </summary>
        /// <param name="id_variable">id de la variable seleccionado en el control</param>
        /// <param name="marcado">TRUE para marcar el control, FALSE para desmarcar</param>
        public void marcarControlByID(string id_variable, bool marcado)
        {
            foreach (ComboBox combo in lista_de_combo_box_variable)
            {
                if (combo.SelectedItem != null)
                {
                    ElementoComboBox elemento = (ElementoComboBox)combo.SelectedItem;
                    if (elemento.id.Equals(id_variable))
                    {
                        marcarControl(combo, true);
                    }
                }
            }
        }
        
        /// <summary>
        /// Método que marca el control
        /// </summary>
        /// <param name="control">El control a marcar</param>
        /// <param name="marcado">TRUE para marcar el control, FALSE para desmarcar</param>
        public void marcarControl(object control, bool marcado)
        {
            if (control == null)
                return;
            string tipo_elemento = "" + control.GetType();
            if (tipo_elemento.Equals("System.Windows.Forms.ComboBox"))
            {
                ComboBox aux = (ComboBox)control;
                if (marcado)
                    aux.BackColor = System.Drawing.Color.Yellow;
                else
                    aux.BackColor = System.Drawing.SystemColors.Window;
            }
            else
                if (tipo_elemento.Equals("System.Windows.Forms.TextBox"))
                {
                    TextBox aux = (TextBox)control;
                    if (marcado)
                        aux.BackColor = System.Drawing.Color.Yellow;
                    else
                        aux.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                    if (tipo_elemento.Equals("System.Windows.Forms.NumericUpDown"))
                    {
                        NumericUpDown aux = (NumericUpDown)control;
                        if (marcado)
                            aux.BackColor = System.Drawing.Color.Yellow;
                        else
                            aux.BackColor = System.Drawing.SystemColors.Window;
                    }
        }

        /// <summary>
        /// Metodo que agrega un nuevo combobox de seleccion de variable y su respectivo boton de eliminado
        /// </summary>
        /// <returns>Id interna del control</returns>
        private string agregarComboBoxVariable()
        {
            ComboBox combo_box = new ComboBox();
            combo_box.Name = ultima_id_interna + "";
            combo_box.FormattingEnabled = true;
            combo_box.SelectedIndexChanged += seleccionDeVariableComboBox_SelectedIndexChanged;
            combo_box.TabIndex = (lista_de_combo_box_variable.Count * 3) + 1;
            for (int i = 0; i < lista_de_variables.Length; i++)
                combo_box.Items.Add(lista_de_variables[i]);
            lista_de_combo_box_variable.Add(combo_box);

            Button boton_eliminar = new Button();
            boton_eliminar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            boton_eliminar.Image = global::ControlesModuloGestionBaseConocimiento.Properties.Resources.basurero_32x32;
            boton_eliminar.Name = ultima_id_interna + "";
            boton_eliminar.Size = new System.Drawing.Size(30, 30);
            boton_eliminar.TabIndex = 11;
            boton_eliminar.UseVisualStyleBackColor = false;
            boton_eliminar.Click += button_eliminar_fila_controles_Click;
            lista_de_button_eliminar.Add(boton_eliminar);

            ultima_id_interna++;
            return combo_box.Name;
        }
        
        /// <summary>
        /// Método que agrega los controles adiciones para le manejo de la variable
        /// </summary>
        /// <param name="id_variable">Id de la variable selecionada</param>
        /// <param name="id_controles">Id a inscribir en los controles</param>
        public void agregarControlesTipoVariable(string id_variable, string id_controles)
        {
            Variable variable = base_conocimiento.leerVariable(id_variable);
            if (variable.tipo_variable == Variable.BOOLEANO)
            {
                ComboBox combo_box = new ComboBox();
                combo_box.Size = new System.Drawing.Size(110, 21);
                combo_box.Name = id_controles;
                combo_box.FormattingEnabled = true;
                combo_box.TabIndex = (lista_de_combo_box_variable.Count * 3) + 2;
                for (int i = 0; i < Hecho.OPCIONES_BOOLEANO.Length; i++)
                    combo_box.Items.Add(Hecho.OPCIONES_BOOLEANO[i]);
                lista_de_combo_box_condicion.Add(combo_box);
            }
            if (variable.tipo_variable == Variable.LISTA)
            {
                ComboBox combo_box = new ComboBox();
                combo_box.Size = new System.Drawing.Size(110, 21);
                combo_box.Name = id_controles;
                combo_box.FormattingEnabled = true;
                combo_box.TabIndex = (lista_de_combo_box_variable.Count * 3) + 2;
                for (int i = 0; i < Hecho.OPCIONES_LISTA.Length; i++)
                    combo_box.Items.Add(Hecho.OPCIONES_LISTA[i]);
                lista_de_combo_box_condicion.Add(combo_box);

                ComboBox combo_box_elementos_variable = new ComboBox();
                combo_box_elementos_variable.Size = new System.Drawing.Size(140, 21);
                combo_box_elementos_variable.Name = id_controles;
                combo_box_elementos_variable.FormattingEnabled = true;
                combo_box_elementos_variable.TabIndex = (lista_de_combo_box_variable.Count * 3) + 3;
                string[] opciones_variable = variable.listarOpciones();
                for (int i = 0; i < opciones_variable.Length; i++)
                    combo_box_elementos_variable.Items.Add(opciones_variable[i]);
                lista_de_object_valor_condicion.Add(combo_box_elementos_variable);
            }

            if (variable.tipo_variable == Variable.NUMERICO)
            {
                ComboBox combo_box = new ComboBox();
                combo_box.Size = new System.Drawing.Size(110, 21);
                combo_box.Name = id_controles;
                combo_box.FormattingEnabled = true;
                combo_box.TabIndex = (lista_de_combo_box_variable.Count * 3) + 2;
                for (int i = 0; i < Hecho.OPCIONES_NUMERICO.Length; i++)
                    combo_box.Items.Add(Hecho.OPCIONES_NUMERICO[i]);
                lista_de_combo_box_condicion.Add(combo_box);
                if (variable.cardinal)
                {
                    NumericUpDown numeric = new NumericUpDown();
                    int min = -99999999;
                    int max = 99999999;
                    if (variable.rango_limitado)
                    {
                        min = (int)variable.rango_limite_inferior;
                        max = (int)variable.rango_limite_superior;
                        Label label_rango = new Label();
                        label_rango.AutoSize = false;
                        label_rango.Name = id_controles;
                        label_rango.Size = new System.Drawing.Size(140, 13);
                        label_rango.Text = "[ " + min + " : " + max + " ]";
                        label_rango.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        lista_label_rangos.Add(label_rango);
                    }
                    numeric.Location = new System.Drawing.Point(430, 44);
                    numeric.Maximum = (decimal)max;
                    numeric.Minimum = (decimal)min;
                    numeric.Name = id_controles;
                    numeric.Size = new System.Drawing.Size(140, 20);
                    numeric.TabIndex = (lista_de_combo_box_variable.Count * 3) + 3;
                    numeric.KeyPress +=numeric_KeyPress;
                    if (min < 0 && 0 < max)
                        numeric.Value = (decimal)0;
                    else
                        numeric.Value = (decimal)((int)((min + max) / 2));
                    lista_de_object_valor_condicion.Add(numeric);
                }
                else
                {
                    TextBox text_box = new TextBox();
                    text_box.Name = id_controles;
                    text_box.Size = new System.Drawing.Size(140, 20);
                    text_box.TabIndex = (lista_de_combo_box_variable.Count * 3) + 3;
                    text_box.KeyPress += texfield_real_KeyPress;
                    if (variable.rango_limitado)
                    {
                        Label label_rango = new Label();
                        label_rango.AutoSize = false;
                        label_rango.Name = id_controles;
                        label_rango.Size = new System.Drawing.Size(140, 13);
                        label_rango.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        label_rango.Text = "[ " +
                                            variable.rango_limite_inferior
                                           + " : "
                                           + variable.rango_limite_superior
                                           + " ]";
                        lista_label_rangos.Add(label_rango);
                    }
                    lista_de_object_valor_condicion.Add(text_box);
                }
            }
        }

        /// <summary>
        /// Método que agrega una fila de controles en base a lectura de un hecho
        /// </summary>
        /// <param name="id_hecho">Identificador del hecho a mostrar</param>
        public void agregarFilaDeControlesEstablecidaAntecedentes(string id_hecho)
        {
            Hecho hecho = base_conocimiento.leerHecho(id_hecho);
            if (hecho == null)
                return;
            string id_controles = agregarComboBoxVariable();
            agregarControlesTipoVariable(hecho.id_variable, id_controles);
            
            foreach (ComboBox combo in lista_de_combo_box_variable)
                if (combo.Name.Equals(id_controles))
                    foreach (ElementoComboBox elemento in combo.Items)
                        if (hecho.id_variable.Equals(elemento.id))
                            combo.SelectedItem = elemento;
            foreach (ComboBox combo in lista_de_combo_box_condicion)
                if (combo.Name.Equals(id_controles))
                    foreach (string elemento in combo.Items)
                        if (hecho.condicion.Equals(elemento))
                            combo.SelectedItem = elemento;
            if (hecho.tipo_variable == Variable.LISTA || hecho.tipo_variable == Variable.NUMERICO)
            {
                foreach (object control in lista_de_object_valor_condicion)
                {
                    string tipo_control = ""+control.GetType();
                    if (tipo_control.Equals("System.Windows.Forms.TextBox"))
                    {
                        TextBox text_box = (TextBox)control;
                        if (text_box.Name.Equals(id_controles))
                            text_box.Text = "" + hecho.valor_numerico;
                    }
                    else
                    if (tipo_control.Equals("System.Windows.Forms.NumericUpDown"))
                    {
                        NumericUpDown numeric_up_down = (NumericUpDown)control;
                        if (numeric_up_down.Name.Equals(id_controles))
                             if (numeric_up_down.Minimum <= (decimal)hecho.valor_numerico && (decimal)hecho.valor_numerico <= numeric_up_down.Maximum)
                                numeric_up_down.Value = (decimal)hecho.valor_numerico;
                    }
                    else
                    if (tipo_control.Equals("System.Windows.Forms.ComboBox"))
                    {
                        ComboBox combo_box = (ComboBox)control;
                        if (combo_box.Name.Equals(id_controles))
                            foreach (string elemento in combo_box.Items)
                                if (hecho.valor_lista_hecho.Equals(elemento))
                                    combo_box.SelectedItem = elemento;
                    }
                }
            }
                     
        }

        /// <summary>
        /// Método que agrega los controles al antecedente en base a hecho
        /// </summary>
        /// <param name="id_hecho">Identificador del hecho a mostrar</param>
        public void agregarFilaDeControlesEstablecidaConsecuente(string id_hecho)
        {
            Hecho hecho = base_conocimiento.leerHecho(id_hecho);
            if (hecho == null)
                return;
            mostrarControlesTipoEntonces(hecho.id_variable);
            foreach (ElementoComboBox elemento in comboBox_var_entonces.Items)
                if (hecho.id_variable.Equals(elemento.id))
                    comboBox_var_entonces.SelectedItem = elemento;

            foreach (string elemento in comboBox_condicion_entonces.Items)
                if (hecho.condicion.Equals(elemento))
                    comboBox_condicion_entonces.SelectedItem = elemento;

            if (hecho.tipo_variable == Variable.LISTA)
                foreach (string elemento in comboBox_lista_entonces.Items)
                    if (hecho.valor_lista_hecho.Equals(elemento))
                        comboBox_lista_entonces.SelectedItem = elemento;
            
            if (hecho.tipo_variable == Variable.NUMERICO)
            {
                if (textBox_entonces != null)
                {
                    textBox_entonces.Text = "" + hecho.valor_numerico;
                }
                else
                if (numericUpDown_entonces != null)
                {
                    if (numericUpDown_entonces.Minimum <= (decimal)hecho.valor_numerico && (decimal)hecho.valor_numerico <= numericUpDown_entonces.Maximum)
                         numericUpDown_entonces.Value = (decimal)hecho.valor_numerico;
                }
            }
        }

        /// <summary>
        /// Método que mmuestra la regla de la base de conocimiento
        /// </summary>
        /// <param name="id_regla">Id de la regla a mostrar</param>
        /// <param name="controles_habilitados">establece si los controles estaran habilitados para su edición</param>
        public void mostrarRegla(string id_regla, bool controles_habilitados = false)
        {
            limpiarControles();
            this.Visible = true;
            actualizarListaDeVariables();
            completarControlEntonces();

            Regla regla = base_conocimiento.leerRegla(id_regla);
            if (regla == null)
            {
                MessageBox.Show("La regla no existe", "Gestión de reglas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBox_id_regla.Text = regla.id_regla;
            string[] antecedentes = regla.listarAntecedentes();
            for (int i = 0; i < antecedentes.Length; i++)
                agregarFilaDeControlesEstablecidaAntecedentes(antecedentes[i]);
            agregarFilaDeControlesEstablecidaConsecuente(regla.id_hecho_consecuente);
            habilitarEdicionDeControles(controles_habilitados);
        }
        /// <summary>
        /// Metodo para eliminar una fila de controles pertenenciente a una varaible
        /// </summary>
        /// <param name="id">Id de la fila de controles</param>
        public void eliminarFilaDeControlesVariable(string id)
        {
            object aux_elim = null;
            foreach (ComboBox item in lista_de_combo_box_variable)
            {
                if (item.Name.Equals(id))
                {
                    aux_elim = item;
                    this.Controls.Remove(item);
                }
            }
            if (aux_elim != null)
                lista_de_combo_box_variable.Remove(aux_elim);
            aux_elim = null;

            foreach (Button item in lista_de_button_eliminar)
            {
                if (item.Name.Equals(id))
                {
                    aux_elim = item;
                    this.Controls.Remove(item);
                }
            }
            if (aux_elim != null)
                lista_de_button_eliminar.Remove(aux_elim);
            aux_elim = null;

            eliminarControlesTipoVariable(id);
        }
        
        /// <summary>
        /// Metodo para eliminar los controles tipo de una variable  (condicion y valor condicion)
        /// </summary>
        /// <param name="id">Id de la fila de controles</param>
        public void eliminarControlesTipoVariable(string id)
        {
            object aux_elim = null;
            foreach (ComboBox item in lista_de_combo_box_condicion)
            {
                if (item.Name.Equals(id))
                {
                    aux_elim = item;
                    this.Controls.Remove(item);
                }
            }
            if (aux_elim != null)
                lista_de_combo_box_condicion.Remove(aux_elim);
            aux_elim = null;

            foreach (object item in lista_de_object_valor_condicion)
            {
                string tipo_elemento = "" + item.GetType();
                if (tipo_elemento.Equals("System.Windows.Forms.ComboBox"))
                {
                    ComboBox aux = (ComboBox)item;
                    if (aux.Name.Equals(id))
                    {
                        aux_elim = aux;
                        this.Controls.Remove(aux);
                    }
                }
                else
                    if (tipo_elemento.Equals("System.Windows.Forms.TextBox"))
                    {
                        TextBox aux = (TextBox)item;
                        if (aux.Name.Equals(id))
                        {
                            aux_elim = aux;
                            this.Controls.Remove(aux);
                        }
                    }
                    else
                        if (tipo_elemento.Equals("System.Windows.Forms.NumericUpDown"))
                        {
                            NumericUpDown aux = (NumericUpDown)item;
                            if (aux.Name.Equals(id))
                            {
                                aux_elim = aux;
                                this.Controls.Remove(aux);
                            }
                        }
            }
            if (aux_elim != null)
                lista_de_object_valor_condicion.Remove(aux_elim);
            aux_elim = null;

            foreach (Label item in lista_label_rangos)
            {
                if (item.Name.Equals(id))
                {
                    aux_elim = item;
                    this.Controls.Remove(item);
                }
            }
            if (aux_elim != null)
                lista_label_rangos.Remove(aux_elim);
            aux_elim = null;
        }
        /// <summary>
        /// Metodo que dibuja los controles en el control
        /// </summary>
        public void dibujarControles()
        {
            ultima_posicion_y = posicion_base_y;
            foreach (Label item in lista_labels_iniciales)
                this.Controls.Remove(item);
            lista_labels_iniciales.Clear();
            this.Refresh();
            bool primero = true;
            foreach (ComboBox item in lista_de_combo_box_variable)
            {
                dibujarDetalleControl(item.Name);
                item.Location = new System.Drawing.Point(40, ultima_posicion_y);
                item.Size = new System.Drawing.Size(230, 21);
                item.Refresh();
                this.Controls.Add(item);

                Label label = new Label();
                label.AutoSize = false;
                label.Size = new System.Drawing.Size(16, 13);
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                if (primero)
                    label.Text = "Si";
                else
                    label.Text = "Y";
                label.Location = new System.Drawing.Point(20, ultima_posicion_y + 5);
                label.Refresh();
                this.Controls.Add(label);
                lista_labels_iniciales.Add(label);





                ultima_posicion_y += 35;
                primero = false;
            }

            this.panel_entonces.Location = new System.Drawing.Point(16, ultima_posicion_y + 20);
            this.panel_entonces.Refresh();

            this.Size = new System.Drawing.Size(678, ultima_posicion_y + 140);

            this.button_aceptar.Location = new System.Drawing.Point(507, ultima_posicion_y + 20 + 86);
            this.button_cancelar.Location = new System.Drawing.Point(381, ultima_posicion_y + 20 + 86);
        }

        /// <summary>
        /// Método que dibuja los controles adicionales al combobox de varaible
        /// </summary>
        /// <param name="id"></param>
        public void dibujarDetalleControl(string id)
        {
            //Condicion
            foreach (ComboBox item in lista_de_combo_box_condicion)
            {
                if (item.Name.Equals(id))
                {
                    item.Location = new System.Drawing.Point(300, ultima_posicion_y);
                    item.Refresh();
                    this.Controls.Add(item);
                }
            }

            //Valor Condicion
            foreach (object item in lista_de_object_valor_condicion)
            {
                string tipo_elemento = "" + item.GetType();
                if (tipo_elemento.Equals("System.Windows.Forms.ComboBox"))
                {
                    ComboBox aux = (ComboBox)item;
                    if (aux.Name.Equals(id))
                    {
                        aux.Location = new System.Drawing.Point(430, ultima_posicion_y);
                        aux.Refresh();
                        this.Controls.Add(aux);
                    }
                }
                else
                if (tipo_elemento.Equals("System.Windows.Forms.TextBox"))
                {
                    TextBox aux = (TextBox)item;
                    if (aux.Name.Equals(id))
                    {
                        aux.Location = new System.Drawing.Point(430, ultima_posicion_y);
                        aux.Refresh();
                        this.Controls.Add(aux);
                    }
                }
                else
                if (tipo_elemento.Equals("System.Windows.Forms.NumericUpDown"))
                {
                    NumericUpDown aux = (NumericUpDown)item;
                    if (aux.Name.Equals(id))
                    {
                        aux.Location = new System.Drawing.Point(430, ultima_posicion_y);
                        aux.Refresh();
                        this.Controls.Add(aux);
                    }
                }
            }
            //label rango
            foreach (Label item in lista_label_rangos)
            {
                if (item.Name.Equals(id))
                {
                    item.Location = new System.Drawing.Point(430, ultima_posicion_y + 20);
                    item.Refresh();
                    this.Controls.Add(item);
                }

            }
            //boton de eliminar
            foreach (Button item in lista_de_button_eliminar)
            {
                if (item.Name.Equals(id))
                {
                    item.Location = new System.Drawing.Point(580, ultima_posicion_y - 5);
                    item.Refresh();
                    this.Controls.Add(item);
                }

            }
        }

        //getType(): obtiene el tipo de la instancia actual
        //Type.GetType(“tipo de objeto”): lo usamos para obtener una referencia con la que comparar
        //if(auxiliar.GetType() == Type.GetType("System.Int32"))        


        /// <summary>
        /// Actualiza la lista de variables a colocar en el combo box
        /// </summary>
        public void actualizarListaDeVariables()
        {
            string[] lista_de_id_variable = base_conocimiento.listarVariables();
            lista_de_variables = new ElementoComboBox[lista_de_id_variable.Length];
            ArrayList aux_lista_variables = new ArrayList();
            for (int i = 0; i < lista_de_id_variable.Length; i++)
            {
                Variable variable = base_conocimiento.leerVariable(lista_de_id_variable[i]);
                ElementoComboBox elemento = new ElementoComboBox()
                {
                    id = variable.id_variable,
                    nombre = variable.nombre_variable
                };
            //    lista_de_variables[i] = elemento;
                aux_lista_variables.Add(elemento);
            }
            aux_lista_variables.Sort(new ElementoComboBox());
            int j = 0;
            foreach (ElementoComboBox item in aux_lista_variables)
            {
                lista_de_variables[j] = item;
                j++;
            }

        }

        /// <summary>
        /// Actualiza las varaibles del comboBox Entoces
        /// </summary>
        public void actualizarListaComboBoxEntonces()
        {
            //combo_box.SelectedIndexChanged += seleccionDeVariableComboBox_SelectedIndexChanged;
            comboBox_var_entonces.Items.Clear();
            for (int i = 0; i < lista_de_variables.Length; i++)
                comboBox_var_entonces.Items.Add(lista_de_variables[i]);
        }


        public void completarControlEntonces()
        {
            if (comboBox_var_entonces == null)
            {
                this.comboBox_var_entonces = new ComboBox();
                this.comboBox_var_entonces.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                this.comboBox_var_entonces.FormattingEnabled = true;
                this.comboBox_var_entonces.Location = new System.Drawing.Point(65, 11);
                this.comboBox_var_entonces.Name = "comboBox_var_entonces";
                this.comboBox_var_entonces.Size = new System.Drawing.Size(217, 21);
                this.comboBox_var_entonces.TabIndex = 3;
                this.comboBox_var_entonces.SelectedIndexChanged += new System.EventHandler(this.comboBox_var_entonces_SelectedIndexChanged);
                this.panel_entonces.Controls.Add(this.comboBox_var_entonces);
            }
            actualizarListaComboBoxEntonces();
        }

        /// <summary>
        /// Metodo para mostrar los controles de Entonces segun el tipo de variable seleccionada
        /// </summary>
        /// <param name="id_variable"></param>
        public void mostrarControlesTipoEntonces(string id_variable)
        {


            this.panel_entonces.Controls.Remove(comboBox_lista_entonces);
            this.panel_entonces.Controls.Remove(textBox_entonces);
            this.panel_entonces.Controls.Remove(numericUpDown_entonces);
            label_rango_entonces.Visible = false;
            this.panel_entonces.Controls.Remove(comboBox_condicion_entonces);


            if (comboBox_lista_entonces != null)
                comboBox_lista_entonces.Dispose();
            if (textBox_entonces != null)
                textBox_entonces.Dispose();
            if (numericUpDown_entonces != null)
                numericUpDown_entonces.Dispose();
            if (comboBox_condicion_entonces != null)
                comboBox_condicion_entonces.Dispose();
            comboBox_lista_entonces = null;
            textBox_entonces = null;
            numericUpDown_entonces = null;
            comboBox_condicion_entonces = null;

            Variable variable = base_conocimiento.leerVariable(id_variable);
            if (variable.tipo_variable == Variable.BOOLEANO)
            {
                comboBox_condicion_entonces = new ComboBox();
                comboBox_condicion_entonces.FormattingEnabled = true;
                comboBox_condicion_entonces.Location = new System.Drawing.Point(292, 10);
                comboBox_condicion_entonces.Margin = new System.Windows.Forms.Padding(4);
                comboBox_condicion_entonces.Name = "comboBox_condicion_entonces";
                comboBox_condicion_entonces.Size = new System.Drawing.Size(149, 24);
                comboBox_condicion_entonces.Visible = true;
                this.panel_entonces.Controls.Add(comboBox_condicion_entonces);
                for (int i = 0; i < Hecho.OPCIONES_BOOLEANO.Length; i++)
                    comboBox_condicion_entonces.Items.Add(Hecho.OPCIONES_BOOLEANO[i]);
            }
            if (variable.tipo_variable == Variable.LISTA)
            {
                comboBox_condicion_entonces = new ComboBox();
                comboBox_condicion_entonces.FormattingEnabled = true;
                comboBox_condicion_entonces.Location = new System.Drawing.Point(292, 10);
                comboBox_condicion_entonces.Margin = new System.Windows.Forms.Padding(4);
                comboBox_condicion_entonces.Name = "comboBox_condicion_entonces";
                comboBox_condicion_entonces.Size = new System.Drawing.Size(149, 24);
                comboBox_condicion_entonces.Visible = true;
                this.panel_entonces.Controls.Add(comboBox_condicion_entonces);
                comboBox_condicion_entonces.Items.Add("ES");
                comboBox_condicion_entonces.SelectedIndex = 0;
                //for (int i = 0; i < Hecho.OPCIONES_LISTA.Length; i++)
                //    comboBox_condicion_entonces.Items.Add(Hecho.OPCIONES_LISTA[i]);

                this.comboBox_lista_entonces = new ComboBox();
                this.comboBox_lista_entonces.FormattingEnabled = true;
                this.comboBox_lista_entonces.Location = new System.Drawing.Point(449, 10);
                this.comboBox_lista_entonces.Margin = new System.Windows.Forms.Padding(4);
                this.comboBox_lista_entonces.Name = "comboBox_lista_entonces";
                this.comboBox_lista_entonces.Size = new System.Drawing.Size(140, 24);
                this.comboBox_lista_entonces.TabIndex = 10;
                this.comboBox_lista_entonces.Visible = false;
                this.panel_entonces.Controls.Add(comboBox_lista_entonces);

                comboBox_lista_entonces.Items.Clear();
                comboBox_lista_entonces.Visible = true;
                string[] opciones_variable = variable.listarOpciones();
                for (int i = 0; i < opciones_variable.Length; i++)
                    comboBox_lista_entonces.Items.Add(opciones_variable[i]);

            }
            if (variable.tipo_variable == Variable.NUMERICO)
            {
                this.label_rango_entonces.Location = new System.Drawing.Point(449, 30);
                comboBox_condicion_entonces = new ComboBox();
                comboBox_condicion_entonces.FormattingEnabled = true;
                comboBox_condicion_entonces.Location = new System.Drawing.Point(292, 10);
                comboBox_condicion_entonces.Margin = new System.Windows.Forms.Padding(4);
                comboBox_condicion_entonces.Name = "comboBox_condicion_entonces";
                comboBox_condicion_entonces.Size = new System.Drawing.Size(149, 24);
                comboBox_condicion_entonces.Visible = true;
                this.panel_entonces.Controls.Add(comboBox_condicion_entonces);
                comboBox_condicion_entonces.Items.Add("IGUAL");
                comboBox_condicion_entonces.SelectedIndex = 0;
                //for (int i = 0; i < Hecho.OPCIONES_NUMERICO.Length; i++)
                //    comboBox_condicion_entonces.Items.Add(Hecho.OPCIONES_NUMERICO[i]);


                if (variable.cardinal)
                {
                    numericUpDown_entonces = new NumericUpDown();
                    this.numericUpDown_entonces.Location = new System.Drawing.Point(449, 10);
                    this.numericUpDown_entonces.Name = "numericUpDown_entonces";
                    this.numericUpDown_entonces.Size = new System.Drawing.Size(140, 22);
                    this.numericUpDown_entonces.TabIndex = 12;
                    this.numericUpDown_entonces.Visible = false;
                    numericUpDown_entonces.Visible = true;
                    numericUpDown_entonces.KeyPress += numeric_KeyPress;
                    int min = -99999999;
                    int max = 99999999;
                    if (variable.rango_limitado)
                    {
                        label_rango_entonces.Visible = true;
                        min = (int)variable.rango_limite_inferior;
                        max = (int)variable.rango_limite_superior;
                        label_rango_entonces.Text = "[ " + min + " : " + max + " ]";
                    }
                    numericUpDown_entonces.Maximum = (decimal)max;
                    numericUpDown_entonces.Minimum = (decimal)min;
                    if (min < 0 && 0 < max)
                        numericUpDown_entonces.Value = (decimal)0;
                    else
                        numericUpDown_entonces.Value = (decimal)((int)((min + max) / 2));
                    this.panel_entonces.Controls.Add(numericUpDown_entonces);
                }
                else
                {
                    this.textBox_entonces = new TextBox();
                    this.textBox_entonces.Location = new System.Drawing.Point(449, 10);
                    this.textBox_entonces.Name = "textBox_entonces";
                    this.textBox_entonces.Size = new System.Drawing.Size(140, 22);
                    this.textBox_entonces.TabIndex = 11;
                    this.textBox_entonces.Visible = true;
                    this.textBox_entonces.KeyPress += texfield_real_KeyPress;
                    this.panel_entonces.Controls.Add(textBox_entonces);
                    if (variable.rango_limitado)
                    {
                        label_rango_entonces.Visible = true;
                        label_rango_entonces.Text = "[ "
                                           + variable.rango_limite_inferior
                                           + " : "
                                           + variable.rango_limite_superior
                                           + " ]";
                    }
                }
            }

        }

        /// <summary>
        /// Método que elimina los controles asociados a entonces
        /// </summary>
        public void eliminarControlesEntonces()
        {
            this.panel_entonces.Controls.Remove(comboBox_var_entonces);
            this.panel_entonces.Controls.Remove(comboBox_lista_entonces);
            this.panel_entonces.Controls.Remove(textBox_entonces);
            this.panel_entonces.Controls.Remove(numericUpDown_entonces);
            label_rango_entonces.Visible = false;
            this.panel_entonces.Controls.Remove(comboBox_condicion_entonces);

            if (comboBox_var_entonces != null)
                comboBox_var_entonces.Dispose();
            if (comboBox_lista_entonces != null)
                comboBox_lista_entonces.Dispose();
            if (textBox_entonces != null)
                textBox_entonces.Dispose();
            if (numericUpDown_entonces != null)
                numericUpDown_entonces.Dispose();
            if (comboBox_condicion_entonces != null)
                comboBox_condicion_entonces.Dispose();
            comboBox_var_entonces = null;
            comboBox_lista_entonces = null;
            textBox_entonces = null;
            numericUpDown_entonces = null;
            comboBox_condicion_entonces = null;
        }


        /// <summary>
        /// Método que habilita o desabilita los controles para edicion
        /// </summary>
        /// <param name="habilitado">True para habilitar controles</param>
        public void habilitarEdicionDeControles(bool habilitado)
        {
            button_aceptar.Visible = habilitado;
            button_cancelar.Visible = habilitado;
            button_agregar.Visible = habilitado;

            foreach (ComboBox combo in lista_de_combo_box_variable)
                combo.Enabled = habilitado;
            foreach (ComboBox combo in lista_de_combo_box_condicion)
                combo.Enabled = habilitado;
            foreach (object control in lista_de_object_valor_condicion)
            {
                string tipo_control = control.GetType()+"";
                if (tipo_control.Equals("System.Windows.Forms.ComboBox"))
                {
                    ComboBox aux = (ComboBox)control;
                    aux.Enabled = habilitado;
                }
                else
                if (tipo_control.Equals("System.Windows.Forms.TextBox"))
                {
                    TextBox aux = (TextBox)control;
                    aux.Enabled = habilitado;
                }
                else
                if (tipo_control.Equals("System.Windows.Forms.NumericUpDown"))
                {
                    NumericUpDown aux = (NumericUpDown)control;
                    aux.Enabled = habilitado;
                }
            }
            foreach (Button button in lista_de_button_eliminar)
                button.Visible = habilitado;
            if (comboBox_var_entonces != null)
                comboBox_var_entonces.Enabled = habilitado;
            if (comboBox_condicion_entonces != null)
                comboBox_condicion_entonces.Enabled = habilitado;
            if (comboBox_lista_entonces != null)
                comboBox_lista_entonces.Enabled = habilitado;
            if (textBox_entonces != null)
                textBox_entonces.Enabled = habilitado;
            if (numericUpDown_entonces != null)
                numericUpDown_entonces.Enabled = habilitado;
        }



        /// <summary>
        /// método que limpia el control de todos los controles generados por las variables
        /// </summary>
        public void limpiarControles()
        {
            textBox_id_regla.Text = "";
            ArrayList ids_controles = new ArrayList();
            foreach (ComboBox item in lista_de_combo_box_variable)
	            ids_controles.Add(item.Name);
            foreach (string item in ids_controles)
                eliminarFilaDeControlesVariable(item);
            eliminarControlesEntonces();
            ultima_id_interna = 0;
            dibujarControles();
        }


        #endregion

        #region comprobadores de internos

        /*
         
         
         * debe existir a lo menos 1 varaible en el antecedente                         ------
         * no debe haber un combo box sin variable asignada                             ------
         * todas su variables deben tener un valor asignado                             ------
         * entonces debe tener una variable de salida                                   ------
         * entonces no debe repetir una variable del antecedente                        ------
         * 
         * bool
         * cada variable booleano solo debe estar una vez en el antecedente             ------
         * 
         * lista 
         * la variable si esta en positivo solo puede estar una vez                     ------
         * si la variable esta en falso puede estar n-2 veces en el antecedente         ------
         * no se puede repetir la opcion de la variable mas de una vez                  ------
         * comprobar que no estes selecionadas todas las opciones de la variable        ------
         * 
         * comprobacion de rangos para la variable                                      ------
         * si esta en igual solo puede aparecer una vez                                 ------
         * si esta en los otros puede establecer solo rangos hacia ->| |<-              ------
         * no puede aparecer mas de 2 veces                                             -----
         */


        /// <summary>
        /// Método que hace las comprobaciones pertinentes de la regla especificada
        /// </summary>
        /// <returns>Texto con los errores encontrados</returns>
        public string comprobacionesRegla()
        {
            string texto_retorno = "";
            if (lista_de_combo_box_variable.Count == 0)
                texto_retorno += "No se han especificado variables en el antecedente";
            {
                string aux = comprobarVariablesEnBlanco();
                if (!aux.Equals(""))
                {
                    if (!texto_retorno.Equals(""))
                        texto_retorno += "\n";
                    texto_retorno += aux;
                }
            }
            {
                string aux = comprobarCondicionesEnBlanco();
                if (!aux.Equals(""))
                {
                    if (!texto_retorno.Equals(""))
                        texto_retorno += "\n";
                    texto_retorno += aux;
                }
            }
            bool flag_valores_en_blanco = false;
            {
                string aux = comprobarValoresEnBlanco();
                if (!aux.Equals(""))
                {
                    if (!texto_retorno.Equals(""))
                        texto_retorno += "\n";
                    texto_retorno += aux;
                    flag_valores_en_blanco = true;
                }
            }
            {
                string aux = comprobarVariableAntecedente();
                if (!aux.Equals(""))
                {
                    if (!texto_retorno.Equals(""))
                        texto_retorno += "\n";
                    texto_retorno += aux;
                }
            }
            bool flag_variables__numericas = false;
            {
                string aux = comprobarEscrituraVariablesNumericas();
                if (!aux.Equals(""))
                {
                    if (!texto_retorno.Equals(""))
                        texto_retorno += "\n";
                    texto_retorno += aux;
                    flag_variables__numericas = true;
                }
            }
            if (!flag_variables__numericas && !flag_valores_en_blanco)
            {
                string aux = comprobadorDeCoherenciaDeVariablesRepetidas();
                if (!aux.Equals(""))
                {
                    if (!texto_retorno.Equals(""))
                        texto_retorno += "\n";
                    texto_retorno += aux;
                }
            }
            return texto_retorno;
        }



        /// <summary>
        /// Método que comprueba si algun combobox no tiene una variable asignada
        /// </summary>
        /// <returns>una cadena vacia si todo esta correcto, texto de error en caso contrario</returns>
        public string comprobarVariablesEnBlanco()
        {
            string texto_retorno = "";
            //comprobaciones para antecedentes
            bool flag_seleccion_de_variables = false;
            foreach (ComboBox combo in lista_de_combo_box_variable)
            {
                if (combo.SelectedItem == null)
                {
                    if (!flag_seleccion_de_variables)
                        flag_seleccion_de_variables = true;
                    marcarControl(combo, true);
                }
            }
            //comprobaciones para antecedente
            if (comboBox_var_entonces.SelectedItem == null)
            {
                if (!flag_seleccion_de_variables)
                    flag_seleccion_de_variables = true;
                marcarControl(comboBox_var_entonces, true);
            }
            if (flag_seleccion_de_variables)
                texto_retorno += "- No se han especificado todas la variables";
            return texto_retorno;
        }



        /// <summary>
        /// Método que compruueba la asignación de condiciones a las variables 
        /// </summary>
        /// <returns>una cadena vacia si todo esta correcto, texto de error en caso contrario</returns>
        public string comprobarCondicionesEnBlanco()
        {
            string texto_retorno = "";
            //comprobaciones para antecedentes
            bool flag_seleccion_de_variables = false;
            foreach (ComboBox combo in lista_de_combo_box_condicion)
            {
                if (combo.SelectedItem == null)
                {
                    if (!flag_seleccion_de_variables)
                        flag_seleccion_de_variables = true;
                    marcarControl(combo, true);
                }
            }
            //comprobaciones para antecedente
            if (comboBox_var_entonces.SelectedItem != null)
            {
                if (comboBox_condicion_entonces.SelectedItem == null)
                {
                    if (!flag_seleccion_de_variables)
                        flag_seleccion_de_variables = true;
                    marcarControl(comboBox_condicion_entonces, true);
                }
            }
            if (flag_seleccion_de_variables)
                texto_retorno += "- No se han especificado condiciones en todas la variables";
            return texto_retorno;
        }



        /// <summary>
        /// Método que compruueba la asignación valores a las variables de tipo LISTA y NUMERICO
        /// </summary>
        /// <returns>una cadena vacia si todo esta correcto, texto de error en caso contrario</returns>
        public string comprobarValoresEnBlanco()
        {
            string texto_retorno = "";
            //comprobaciones para antecedentes
            bool flag_seleccion_de_variables = false;
            foreach (object control in lista_de_object_valor_condicion)
            {
                string tipo_elemento = "" + control.GetType();
                if (tipo_elemento.Equals("System.Windows.Forms.ComboBox"))
                {
                    ComboBox aux = (ComboBox)control;
                    if (aux.SelectedItem == null)
                    {
                        if (!flag_seleccion_de_variables)
                            flag_seleccion_de_variables = true;
                        marcarControl(aux, true);
                    }
                }
                else
                    if (tipo_elemento.Equals("System.Windows.Forms.TextBox"))
                    {
                        TextBox aux = (TextBox)control;
                        if (aux.Text.Equals(""))
                        {
                            if (!flag_seleccion_de_variables)
                                flag_seleccion_de_variables = true;
                            marcarControl(aux, true);
                        }
                    }
            }
            //comprobaciones para antecedente
            if (comboBox_var_entonces.SelectedItem != null)
            {
                if (comboBox_lista_entonces != null)
                {
                    if (comboBox_lista_entonces.SelectedItem == null)
                    {
                        if (!flag_seleccion_de_variables)
                            flag_seleccion_de_variables = true;
                        marcarControl(comboBox_lista_entonces, true);
                    }
                }
                if (textBox_entonces != null)
                {
                    if (textBox_entonces.Text.Equals(""))
                    {
                        if (!flag_seleccion_de_variables)
                            flag_seleccion_de_variables = true;
                        marcarControl(textBox_entonces, true);
                    }
                }
            }
            if (flag_seleccion_de_variables)
                texto_retorno += "- No se han especificado los valores en todas la variables";
            return texto_retorno;
        }

        
        /// <summary>
        /// Método que comprueba el ingreso de las variables numericas
        /// </summary>
        /// <returns>una cadena vacia si todo esta correcto, texto de error en caso contrario</returns>
        public string comprobarEscrituraVariablesNumericas()
        {
            //antecedentes
            string texto_retorno = "";
            foreach (object control in lista_de_object_valor_condicion)
            {
                string tipo_control = "" + control.GetType();
                if (tipo_control.Equals("System.Windows.Forms.TextBox"))
                {
                    TextBox text_box = (TextBox)control;
                    if (!text_box.Text.Equals(""))
                    {
                        string id_variable = extraerIdVariable(text_box.Name);
                        Variable variable = base_conocimiento.leerVariable(id_variable);

                        try
                        {
                            string texto = text_box.Text.Replace('.', ',');
                            double valor = Double.Parse(texto);
                            if (variable.rango_limitado)
                            {
                                if (valor < variable.rango_limite_inferior || variable.rango_limite_superior < valor)
                                {
                                    marcarControl(text_box, true);
                                    if (!texto_retorno.Equals(""))
                                        texto_retorno += "\n";
                                    texto_retorno += "- El valor de la variable \"" + variable.nombre_variable + "\" no esta dentro del rango";
                                }
                                foreach (ComboBox combo_condicion in lista_de_combo_box_condicion)
                                {
                                    if (combo_condicion.Name.Equals(text_box.Name))
                                    {
                                        if (combo_condicion.SelectedItem != null)
                                        {
                                            string condicion = (string)combo_condicion.SelectedItem;
                                            if (condicion.Equals("MENOR") && (valor <= variable.rango_limite_inferior))
                                            {
                                                marcarControl(text_box, true);
                                                if (!texto_retorno.Equals(""))
                                                    texto_retorno += "\n";
                                                texto_retorno += "- En la condición MENOR el valor de la variable \"" + variable.nombre_variable + "\" debe ser mayor al límite inferior del rango";
                                            }
                                            if (condicion.Equals("MAYOR") && variable.rango_limite_superior <= valor)
                                            {
                                                marcarControl(text_box, true);
                                                if (!texto_retorno.Equals(""))
                                                    texto_retorno += "\n";
                                                texto_retorno += "- En la condición MAYOR el valor de la variable \"" + variable.nombre_variable + "\" debe ser menor al límite superior del rango";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            marcarControl(text_box, true);
                            if (!texto_retorno.Equals(""))
                                texto_retorno += "\n";
                            texto_retorno += "- El valor de la variable \"" + variable.nombre_variable + "\" esta mal ingresada";
                        }
                    }
                }
                else
                    if (tipo_control.Equals("System.Windows.Forms.NumericUpDown"))
                    {
                        NumericUpDown numeric_updown = (NumericUpDown)control;
                        string id_variable = extraerIdVariable(numeric_updown.Name);
                        Variable variable = base_conocimiento.leerVariable(id_variable);
                        try
                        {
                            int valor = (int)numeric_updown.Value;
                            double parte_decimal = (double)numeric_updown.Value - valor;
                            if (parte_decimal >= 0.5)
                                valor++;
                            numeric_updown.Value = valor;
                            if (variable.rango_limitado)
                            {
                                int inf = (int)variable.rango_limite_inferior;
                                int sup = (int)variable.rango_limite_superior;
                                if (valor < inf || sup < valor)
                                {
                                    marcarControl(numeric_updown, true);
                                    if (!texto_retorno.Equals(""))
                                        texto_retorno += "\n";
                                    texto_retorno += "- El valor de la variable \"" + variable.nombre_variable + "\" no esta dentro del rango";
                                }
                                foreach (ComboBox combo_condicion in lista_de_combo_box_condicion)
                                {
                                    if (combo_condicion.Name.Equals(numeric_updown.Name))
                                    {
                                        if (combo_condicion.SelectedItem != null)
                                        {
                                            string condicion = (string)combo_condicion.SelectedItem;
                                            if (condicion.Equals("MENOR") && (valor <= variable.rango_limite_inferior))
                                            {
                                                marcarControl(numeric_updown, true);
                                                if (!texto_retorno.Equals(""))
                                                    texto_retorno += "\n";
                                                texto_retorno += "- En la condición MENOR el valor de la variable \"" + variable.nombre_variable + "\" debe ser mayor al límite inferior del rango";
                                            }
                                            if (condicion.Equals("MAYOR") && variable.rango_limite_superior <= valor)
                                            {
                                                marcarControl(numeric_updown, true);
                                                if (!texto_retorno.Equals(""))
                                                    texto_retorno += "\n";
                                                texto_retorno += "- En la condición MAYOR el valor de la variable \"" + variable.nombre_variable + "\" debe ser menor al límite superior del rango";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            marcarControl(numeric_updown, true);
                            if (!texto_retorno.Equals(""))
                                texto_retorno += "\n";
                            texto_retorno += "- El valor de la variable \"" + variable.nombre_variable + "\" esta mal ingresada";
                        }

                    }
            }
            //consecuente
            if (comboBox_var_entonces.SelectedItem != null)
            {
                if (textBox_entonces != null)
                {
                    if (!textBox_entonces.Text.Equals(""))
                    {
                        ElementoComboBox elemento = (ElementoComboBox)comboBox_var_entonces.SelectedItem;
                        string id_variable = elemento.id;
                        Variable variable = base_conocimiento.leerVariable(id_variable);
                        try
                        {
                            string texto = textBox_entonces.Text.Replace('.', ',');
                            double valor = Double.Parse(texto);
                            if (variable.rango_limitado)
                            {
                                if (valor < variable.rango_limite_inferior || variable.rango_limite_superior < valor)
                                {
                                    marcarControl(textBox_entonces, true);
                                    if (!texto_retorno.Equals(""))
                                        texto_retorno += "\n";
                                    texto_retorno += "- El valor de la variable \"" + variable.nombre_variable + "\" no esta dentro del rango";
                                }
                            }
                        }
                        catch (Exception)
                        {
                            marcarControl(textBox_entonces, true);
                            if (!texto_retorno.Equals(""))
                                texto_retorno += "\n";
                            texto_retorno += "- El valor de la variable \"" + variable.nombre_variable + "\" esta mal ingresada";
                        }
                    }
                }
            }
            return texto_retorno;
        }

        /// <summary>
        /// Método que extraer la id de la variable correspondiente a una fila de controles
        /// </summary>
        /// <param name="id_interna">Id interna del control (Control.Name)</param>
        /// <returns>id de la variable</returns>
        public string extraerIdVariable(string id_interna)
        {
            foreach (ComboBox combo in lista_de_combo_box_variable)
            {
                if (combo.Name.Equals(id_interna))
                {
                    if (combo.SelectedItem != null)
                    {
                        ElementoComboBox elemento = (ElementoComboBox)combo.SelectedItem;
                        return elemento.id;
                    }
                    else
                        return null;
                }

            }
            return null;
        }

        /// <summary>
        /// Método que comprueba que la variable del consecuente no se encuentre en el antecedente
        /// </summary>
        /// <returns>una cadena vacia si todo esta correcto, texto de error en caso contrario</returns>
        public string comprobarVariableAntecedente()
        {
            string texto_retorno = "";
            bool flag = false;
            if (comboBox_var_entonces.SelectedItem != null)
            {
                ElementoComboBox elemento_entonces = (ElementoComboBox)comboBox_var_entonces.SelectedItem;
                foreach (ComboBox combo in lista_de_combo_box_variable)
                {
                    if (combo.SelectedItem != null)
                    {
                        ElementoComboBox elemento_antecedente = (ElementoComboBox)combo.SelectedItem;
                        if (elemento_antecedente.Equals(elemento_entonces))
                        {
                            flag = true;
                            marcarControl(combo, true);
                        }
                    }
                }
            }
            if (flag)
            {
                texto_retorno += "- Se ha utilizado la variable del consecuente en el antecedente";
                marcarControl(comboBox_var_entonces, true);
            }
            return texto_retorno;
        }

        /// <summary>
        /// Método que comprueba la coherencia de las variables repetidas
        /// </summary>
        /// <returns>una cadena vacia si todo esta correcto, texto de error en caso contrario</returns>
        public string comprobadorDeCoherenciaDeVariablesRepetidas()
        {
            string texto_retorno = "";
            bool flag_variables_ingresadas = true;
            ArrayList ids_distintas = new ArrayList();
            foreach (ComboBox combo in lista_de_combo_box_variable)
            {
                if (combo.SelectedItem != null)
                {
                    bool flag = false;
                    ElementoComboBox elemento = (ElementoComboBox)combo.SelectedItem;
                    foreach (string[] item in ids_distintas)
                        if (item[0].Equals(elemento.id))
                        {
                            item[1] += "+";
                            flag = true;
                        }
                    if (!flag)
                    {
                        string[] aux = new string[] { elemento.id, "+" };
                        ids_distintas.Add(aux);
                    }
                }
                else
                {
                    flag_variables_ingresadas = false;
                }
            }

            if (flag_variables_ingresadas)
                if (ids_distintas.Count != lista_de_combo_box_variable.Count)
                {
                    foreach (string[] item in ids_distintas)
                    {
                        Variable variable = base_conocimiento.leerVariable(item[0]);
                        if (Variable.BOOLEANO == variable.tipo_variable)
                        {
                            string aux = comprobadorDeVariablesBooleanas(variable.id_variable, variable.nombre_variable, item[1].Length);
                            if (!texto_retorno.Equals(""))
                                texto_retorno += "\n";
                            texto_retorno += aux;
                        }
                        else
                            if (Variable.LISTA == variable.tipo_variable)
                            {
                                if (item[1].Length > 0)
                                {
                                    string aux = comprobadorDeVariablesLista(variable.id_variable, variable.nombre_variable, item[1].Length);
                                    if (!texto_retorno.Equals(""))
                                        texto_retorno += "\n";
                                    texto_retorno += aux;
                                }
                            }
                            else
                                if (Variable.NUMERICO == variable.tipo_variable)
                                {
                                    if (item[1].Length > 1)
                                    {
                                        string aux = comprobadorDeVariablesNumerica(variable.id_variable, variable.nombre_variable, item[1].Length);
                                        if (!texto_retorno.Equals(""))
                                            texto_retorno += "\n";
                                        texto_retorno += aux;
                                    }

                                }
                    }
                    //texto_retorno += comprobadorDeVariablesBooleanas()
                }
            return texto_retorno;
        }

        /// <summary>
        /// Método que comprueba las variables de tipo booleanas
        /// </summary>
        /// <param name="id_variable">Identificador de la variable de tipo BOOLEANO</param>
        /// <param name="nombre_variable">Nombre de la variable a analizar</param>
        /// <param name="conteo_variable">Nuemro de veces que la varaible apararece en los antecedentes</param>
        /// <returns></returns>
        public string comprobadorDeVariablesBooleanas(string id_variable, string nombre_variable, int conteo_variable)
        {
            if (conteo_variable > 1)
            {
                marcarControlByID(id_variable, true);
                return "- La variable BOOLEANA \"" + nombre_variable + "\" se encuentra mas de una vez";
            }
            return "";
        }

        /// <summary>
        /// Método que comprueba las variables de tipo LISTA
        /// </summary>
        /// <param name="id_variable">Identificador de la variable de tipo BOOLEANO</param>
        /// <param name="nombre_variable">Nombre de la variable a analizar</param>
        /// <param name="conteo_variable">Nuemro de veces que la varaible apararece en los antecedentes</param>
        /// <returns></returns>
        public string comprobadorDeVariablesLista(string id_variable, string nombre_variable, int conteo_variable)
        {
            ArrayList lista_de_instancias = new ArrayList();
            foreach (ComboBox combo_variable in lista_de_combo_box_variable)
            {
                if (combo_variable.SelectedItem != null)
                {
                    ElementoComboBox elemento = (ElementoComboBox)combo_variable.SelectedItem;
                    if (elemento.id.Equals(id_variable))
                    {
                        string aux = id_variable + "|";
                        //buscando la condicion de la variable
                        foreach (ComboBox combo_condicion in lista_de_combo_box_condicion)
                        {
                            if (combo_variable.Name.Equals(combo_condicion.Name))
                            {
                                if (combo_condicion.SelectedItem != null)
                                {
                                    string elemento_condicion = (string)combo_condicion.SelectedItem;
                                    aux += elemento_condicion + "|";
                                }
                                else
                                {
                                    return "";
                                }
                                continue;
                            }
                        }
                        //buscando el valor de la variable
                        foreach (object control in lista_de_object_valor_condicion)
                        {
                            string tipo_elemento = "" + control.GetType();
                            if (tipo_elemento.Equals("System.Windows.Forms.ComboBox"))
                            {
                                ComboBox combo_valor = (ComboBox)control;
                                if (combo_variable.Name.Equals(combo_valor.Name))
                                {
                                    if (combo_valor.SelectedItem != null)
                                    {
                                        string elemento_condicion = (string)combo_valor.SelectedItem;
                                        aux += elemento_condicion;
                                    }
                                    else
                                    {
                                        return "";
                                    }
                                }
                            }
                        }
                        lista_de_instancias.Add(aux);
                    }
                }
                else
                {
                    return "";
                }
            }
            //Comprobando que no haya condiciones es
            bool flag_condiciones_es = false;
            foreach (string item in lista_de_instancias)
            {
                if (item.Split('|')[1].Equals("ES"))
                {
                    flag_condiciones_es = true;
                    continue;
                }
            }
            if (flag_condiciones_es)
            {
                foreach (string item in lista_de_instancias)
                    marcarControlByID(item.Split('|')[0], true);
                return "- Una variable de tipo LISTA(" + nombre_variable + "), si se encuentra en mas de un antecedente no puede tener condiciones \"ES\"";
            }

            bool flag_repeticion = false;
            //comprobando repeticion de valores
            for (int i = 0; i < lista_de_instancias.Count; i++)
            {
                for (int j = 0; j < lista_de_instancias.Count; j++)
                {
                    if (i != j)
                    {
                        string a = (string)lista_de_instancias[i];
                        string b = (string)lista_de_instancias[j];
                        if (a.Equals(b))
                        {
                            flag_repeticion = true;
                        }
                    }
                }
            }
            if (flag_repeticion)
            {
                foreach (string item in lista_de_instancias)
                    marcarControlByID(item.Split('|')[0], true);
                return "- La variable \"" + nombre_variable + "\", tiene valores repetidos";
            }

            Variable variable = base_conocimiento.leerVariable(id_variable);
            int numero_de_opciones = variable.listarOpciones().Length;

            if (conteo_variable == numero_de_opciones)
            {
                foreach (string item in lista_de_instancias)
                    marcarControlByID(item.Split('|')[0], true);
                return "- Se han especificado todos las opciones de la variable \"" + nombre_variable + "\"";
            }

            if (conteo_variable >= numero_de_opciones - 2)
            {
                foreach (string item in lista_de_instancias)
                    marcarControlByID(item.Split('|')[0], true);
                return "- Se deben cambiar  los antecedes con la variable \"" + nombre_variable + "\", a un solo antecedentes con la condición \"ES\"";
            }
            return "";
        }


        /// <summary>
        /// Método que comprueba las variables de tipo numericos
        /// </summary>
        /// <param name="id_variable">Identificador de la variable de tipo NUMERICA</param>
        /// <param name="nombre_variable">Nombre de la variable a analizar</param>
        /// <param name="conteo_variable">Nuemro de veces que la varaible apararece en los antecedentes</param>
        /// <returns></returns>
        public string comprobadorDeVariablesNumerica(string id_variable, string nombre_variable, int conteo_variable)
        {
            string condicion_a = null;
            string condicion_b = null;
            double valor_a = -666666666;
            double valor_b = -666666666;


            if (conteo_variable > 2)
            {
                return "- Una variable (" + nombre_variable + ") de tipo NUMERICA no puede estar mas de 2 veces en el antecedente";
            }

            bool flag_condicion_igual = false;
            foreach (ComboBox combo_variable in lista_de_combo_box_variable)
            {
                ElementoComboBox elemento = (ElementoComboBox)combo_variable.SelectedItem;
                if (elemento.id.Equals(id_variable))
                {
                    foreach (ComboBox combo_condicion in lista_de_combo_box_condicion)
                    {
                        if (combo_condicion.Name.Equals(combo_variable.Name))
                        {
                            string condicion = (string)combo_condicion.SelectedItem;
                            if (condicion.Equals(""))
                            {
                                return "";
                            }
                            else
                                if (condicion.Equals("IGUAL"))
                                {
                                    flag_condicion_igual = true;
                                }
                                else
                                {
                                    if (condicion_a == null)
                                        condicion_a = condicion;
                                    else
                                        condicion_b = condicion;
                                    foreach (object control in lista_de_object_valor_condicion)
                                    {
                                        string tipo_control = "" + control.GetType();
                                        double valor = -666666666;
                                        if (tipo_control.Equals("System.Windows.Forms.TextBox"))
                                        {
                                            TextBox aux = (TextBox)control;
                                            if (aux.Name.Equals(combo_variable.Name))
                                            {
                                                valor = Double.Parse(aux.Text);
                                            }
                                        }
                                        else
                                            if (tipo_control.Equals("System.Windows.Forms.NumericUpDown"))
                                            {
                                                NumericUpDown aux = (NumericUpDown)control;
                                                if (aux.Name.Equals(combo_variable.Name))
                                                {
                                                    valor = (double)aux.Value;
                                                }
                                            }
                                        if (valor != -666666666)
                                        {
                                            if (condicion_b == null)
                                                valor_a = valor;
                                            else
                                                valor_b = valor;
                                        }
                                    }
                                }
                        }
                    }
                }
            }
            if (flag_condicion_igual)
            {
                marcarControlByID(id_variable, true);
                return " -  Si la variable \"" + nombre_variable + "\", aparece mas de una vez, no puede contener la condición IGUAL";
            }

            bool flag_interseccion = false;
            //comprobando interseccion
            if (
                   (
                       (
                           condicion_a.Equals("MENOR") || condicion_a.Equals("MENOR O IGUAL")
                       )
                       &&
                       (
                           condicion_b.Equals("MAYOR O IGUAL") || condicion_b.Equals("MAYOR")
                       )
                   )
                   ||
                   (
                       (
                           condicion_b.Equals("MENOR") || condicion_b.Equals("MENOR O IGUAL")
                       )
                       &&
                       (
                           condicion_a.Equals("MAYOR O IGUAL") || condicion_a.Equals("MAYOR")
                       )
                   )
               )
                flag_interseccion = true;
            if (!flag_interseccion)
            {
                marcarControlByID(id_variable, true);
                return " - Las condiciones para una variable \"" + nombre_variable + "\"tipo NUMERICA repetida deben ser MENOR, MENOR O IGUAL en una y MAYOR, MAYOR O IGUAL en la otra, sin importar el orden.";
            }

            if (valor_a == valor_b)
            {
                marcarControlByID(id_variable, true);
                return " - Los valores de las variable \"" + nombre_variable + "\" deben establecer un RANGO no pueden ser iguales";
            }

            if (valor_a == -666666666 || valor_b == -666666666)
            {
                marcarControlByID(id_variable, true);
                MessageBox.Show("Error en la comprobación de errores");
                return " - Error en la comprobación de errores \"" + nombre_variable + "\"";
            }

            bool flag_valores = false;
            if (condicion_a.Equals("MENOR") || condicion_a.Equals("MENOR O IGUAL"))
            {
                if (!(valor_a > valor_b))
                    flag_valores = true;
            }
            else
            {
                if (!(valor_b > valor_a))
                    flag_valores = true;
            }
            if (flag_valores)
            {
                marcarControlByID(id_variable, true);
                return " - Las valores de \"" + nombre_variable + "\" deben establecer un conjunto cerrado \nEjemplo var MAYOR que 2 y var MENOR que 5   (2 < var < 5)";
            }
            return "";
        }
        #endregion  

        /// <summary>
        /// Método que agrupa todos los hechos declarados como antecedente en un arraylist de arraylist{id_variable,condicion,valor} 
        /// </summary>
        /// <returns>ArrayList con la agrupacion de hechos</returns>
        public ArrayList agruparHechosAntecedenteEnArrayList()
        {
            ArrayList lista_de_hechos = new ArrayList();
            foreach (ComboBox combo_variable in lista_de_combo_box_variable)
            {
                ArrayList hecho = new ArrayList();
                ElementoComboBox elemento_variable = (ElementoComboBox)combo_variable.SelectedItem;
                hecho.Add(elemento_variable.id);
                foreach (ComboBox combo_condicion in lista_de_combo_box_condicion)
                {
                    if (combo_variable.Name.Equals(combo_condicion.Name))
                    {
                        string opcion = (string)combo_condicion.SelectedItem;
                        hecho.Add(opcion);
                    }
                }
                foreach (object control in lista_de_object_valor_condicion)
                {
                    string tipo_control = ""+control.GetType();
                    if (tipo_control.Equals("System.Windows.Forms.ComboBox"))
                    {
                        ComboBox combo_valor = (ComboBox)control;
                        if (combo_variable.Name.Equals(combo_valor.Name))
                        {
                            string opcion = (string)combo_valor.SelectedItem;
                            hecho.Add(opcion);
                        }
                    }
                    else
                    if (tipo_control.Equals("System.Windows.Forms.TextBox"))
                    {
                        TextBox textbox_valor = (TextBox)control;
                        if (combo_variable.Name.Equals(textbox_valor.Name))
                        {
                            double valor = Double.Parse(textbox_valor.Text);
                            hecho.Add(valor);
                        }
                    }
                    else
                    if (tipo_control.Equals("System.Windows.Forms.NumericUpDown"))
                    {
                         NumericUpDown numericupdown_valor = (NumericUpDown)control;
                         if (combo_variable.Name.Equals(numericupdown_valor.Name))
                         {
                             double valor = (double)numericupdown_valor.Value;
                             hecho.Add(valor);
                         }        
                    }
                }
                lista_de_hechos.Add(hecho);
            }
            return lista_de_hechos;
        }


        /// <summary>
        /// Método que agrupa el hecho consecuente en un ArrayList{id_variable,condicion,valor} 
        /// </summary>
        /// <returns>ArrayList con la agrupacion del hecho consecuente</returns>
        public ArrayList agruparHechoConsecuenteEnArrayList()
        {
            ArrayList consecuente = new ArrayList();

            ElementoComboBox elemento = (ElementoComboBox)comboBox_var_entonces.SelectedItem;
            string id_variable  = elemento.id;
            consecuente.Add(id_variable);
            string condicion = (string)comboBox_condicion_entonces.SelectedItem;
            consecuente.Add(condicion);

            if (comboBox_lista_entonces != null)
            {
                string opcion = (string)comboBox_lista_entonces.SelectedItem;
                consecuente.Add(opcion);
            }
            if (textBox_entonces != null)
            {
                double valor = Double.Parse(textBox_entonces.Text);
                consecuente.Add(valor);
            }
            if (numericUpDown_entonces != null)
            {
                consecuente.Add(numericUpDown_entonces.Value);
            }
            return consecuente;
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
        /// Método que inicia el control para agregar una nueva regla
        /// </summary>
        public void iniciarTareaAgregado()
        {
            limpiarControles();
            actualizarListaDeVariables();
            completarControlEntonces();
            habilitarEdicionDeControles(true);
            Visible = true;
            tipo_tarea = ControlEdicionReglas.AGREGANDO;

        }

        public void iniciarTareaModificaciónRegla(string id_regla)
        {
            tipo_tarea = ControlEdicionReglas.MODIFICANDO;
            mostrarRegla(id_regla, true);

        }
        
        /// <summary>
        /// Método que inicia el control para agregar una nueva regla
        /// </summary>
        /// <param name="id_regla">Identificador de la regla a eliminar</param>
        public void iniciarTareaEliminarRegla(string id_regla)
        {
            tipo_tarea = ControlEdicionReglas.ELIMINANDO;
            Regla regla = base_conocimiento.leerRegla(id_regla);
            if (preguntasSiNoCancelar("Gestión de reglas", "Esta seguro de elminar la regla ID:" + id_regla + "\n" + regla) == 1)
            {
                base_conocimiento.eliminarRegla(id_regla);
                limpiarControles();
                Visible = false;
                MessageBox.Show("La regla se ha eliminado correctamente.", "Gestión de reglas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (evento_cambio_reglas != null)
                    evento_cambio_reglas();
            }
            tipo_tarea = ControlEdicionReglas.DESABILITADO;
            if (evento_habilitar_controles != null)
                evento_habilitar_controles(true);
        }
        //*************************************************************************
        // Eventos
        //*************************************************************************
        private void button_agregar_Click(object sender, EventArgs e)
        {
            agregarComboBoxVariable();
            dibujarControles();
        }

        private void button_eliminar_fila_controles_Click(object sender, EventArgs e)
        {
            Button boton_eliminar = (Button)sender;
            eliminarFilaDeControlesVariable(boton_eliminar.Name);
            dibujarControles();
        }


        private void seleccionDeVariableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            string id_combo_box = combo.Name + "";
            ElementoComboBox elemento = (ElementoComboBox)combo.SelectedItem;
            string id_variable_seleccionada = elemento.id;
            eliminarControlesTipoVariable(id_combo_box);
            agregarControlesTipoVariable(id_variable_seleccionada, id_combo_box);
            dibujarControles();
        }

        private void comboBox_var_entonces_SelectedIndexChanged(object sender, EventArgs e)
        {
            ElementoComboBox elemento = (ElementoComboBox)comboBox_var_entonces.SelectedItem;
            mostrarControlesTipoEntonces(elemento.id);
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            desmarcarControles();
            string errores = comprobacionesRegla();
            if (!errores.Equals(""))
            {
                MessageBox.Show(errores, "Gestión de reglas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tipo_tarea == AGREGANDO)
            {
                ArrayList antecedentes = agruparHechosAntecedenteEnArrayList();
                ArrayList consecuente = agruparHechoConsecuenteEnArrayList();
                string id_regla = base_conocimiento.agregarNuevaRegla(antecedentes,consecuente);
                if (id_regla == null)
                {
                    if (preguntasSiNoCancelar("Gestión de Reglas", "La regla ya existe en la base de conocimiento\n Desea buscar la regla en la base de conocimiento? ") == 1)
                    {
                        string aux = base_conocimiento.comprobarReglaExistente(antecedentes, consecuente);
                        Regla regla = base_conocimiento.leerRegla(aux);
                        MessageBox.Show("Id regla: \""+regla.id_regla+"\"\n"+regla, "Gestión de reglas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("La regla fue ingresada correctamente.\n (Id regla: \""+id_regla+"\")", "Gestión de reglas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (evento_cambio_reglas != null)
                        evento_cambio_reglas();
                    limpiarControles();
                    tipo_tarea = DESABILITADO;
                    this.Visible = false;
                }
                if (evento_habilitar_controles != null)
                    evento_habilitar_controles(true);
            }
            if (tipo_tarea == MODIFICANDO)
            {
                ArrayList antecedentes = agruparHechosAntecedenteEnArrayList();
                ArrayList consecuente = agruparHechoConsecuenteEnArrayList();
                string id_regla = textBox_id_regla.Text;
                string aux_id_regla = base_conocimiento.modificarRegla(id_regla,antecedentes, consecuente);
                if (!aux_id_regla.Equals(""))
                {
                    Regla aux_regla = base_conocimiento.leerRegla(aux_id_regla);
                    MessageBox.Show("La regla ya existe en la base de conocimiento\n ID regla: " + aux_id_regla + "\n" + aux_regla, "Gestión de reglas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Regla regla = base_conocimiento.leerRegla(id_regla);
                    MessageBox.Show("La regla fue ingresada correctamente.\n (Id regla: " + id_regla + "\n"+regla, "Gestión de reglas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (evento_cambio_reglas != null)
                        evento_cambio_reglas();
                    limpiarControles();
                    tipo_tarea = DESABILITADO;
                    this.Visible = false;
                    if (evento_habilitar_controles != null)
                        evento_habilitar_controles(true);
                }
            }
        }
        private void numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.Handled = true;
            }
        }
        private void texfield_real_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = ((System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture).NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
            else
            if (
                    !(
                    e.KeyChar.Equals('0') || 
                    e.KeyChar.Equals('1') || 
                    e.KeyChar.Equals('2') || 
                    e.KeyChar.Equals('3') || 
                    e.KeyChar.Equals('4') || 
                    e.KeyChar.Equals('5') || 
                    e.KeyChar.Equals('6') || 
                    e.KeyChar.Equals('7') || 
                    e.KeyChar.Equals('8') ||
                    e.KeyChar.Equals('9') ||
                    e.KeyChar.Equals('-') ||
                    ((int)e.KeyChar == (int)Keys.Back)
                    )
                )
            {
                e.Handled = true;
            }
            
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            this.Visible = false;
            tipo_tarea = DESABILITADO;
            if (evento_habilitar_controles != null)
                evento_habilitar_controles(true);
        }
    }
}
