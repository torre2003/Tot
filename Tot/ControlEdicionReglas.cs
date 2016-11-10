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

namespace Tot
{
    public partial class ControlEdicionReglas : UserControl
    {
        //getType(): obtiene el tipo de la instancia actual
        //Type.GetType(“tipo de objeto”): lo usamos para obtener una referencia con la que comparar
        //if(auxiliar.GetType() == Type.GetType("System.Int32"))

        struct ElementoComboBox
        {
            public string id;
            public string nombre;

            public override string ToString()
            {
                return nombre;
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

        int ultima_id_interna = 0;
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

        /// <summary>
        /// Actualiza la lista de variables a colocar en el combo box
        /// </summary>
        public void actualizarListaDeVariables()
        {
            string[] lista_de_id_variable = base_conocimiento.listarVariables();
            lista_de_variables = new ElementoComboBox[lista_de_id_variable.Length];
            for (int i = 0; i < lista_de_id_variable.Length; i++)
            {
                Variable variable = base_conocimiento.leerVariable(lista_de_id_variable[i]);
                ElementoComboBox elemento = new ElementoComboBox()
                {
                    id = variable.id_variable,
                    nombre = variable.nombre_variable
                };
                lista_de_variables[i] = elemento;
            }
        }

        /// <summary>
        /// Metodo que agrega un nuevo combobox de seleccion de variable y su respectivo boton de eliminado
        /// </summary>
        private void agregarComboBoxVariable()
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
            boton_eliminar.Image = global::Tot.Properties.Resources.basurero_32x32;
            boton_eliminar.Name = ultima_id_interna + "";
            boton_eliminar.Size = new System.Drawing.Size(30, 30);
            boton_eliminar.TabIndex = 11;
            boton_eliminar.UseVisualStyleBackColor = false;
            boton_eliminar.Click += button_eliminar_fila_controles_Click;
            lista_de_button_eliminar.Add(boton_eliminar);

            ultima_id_interna++;
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
                    if (variable.rango_limitado)
                    {
                        Label label_rango = new Label();
                        label_rango.AutoSize = false;
                        label_rango.Name = id_controles;
                        label_rango.Size = new System.Drawing.Size(140, 13);
                        label_rango.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        label_rango.Text = "[ "+
                                            variable.rango_limite_inferior
                                           + " : " 
                                           + variable.rango_limite_superior
                                           +" ]";
                        lista_label_rangos.Add(label_rango);
                    }
                    lista_de_object_valor_condicion.Add(text_box);
                }
            }
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
            if(aux_elim != null)
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
                item.Location   = new System.Drawing.Point(40,ultima_posicion_y);
                item.Size       = new System.Drawing.Size(230, 21);
                item.Refresh();
                this.Controls.Add(item);

                Label label = new Label();
                label.AutoSize = false;
                label.Size = new System.Drawing.Size(16, 13);
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                if(primero)
                    label.Text = "Si";
                else
                    label.Text = "Y";
                label.Location = new System.Drawing.Point(20, ultima_posicion_y+5);
                label.Refresh();
                this.Controls.Add(label);
                lista_labels_iniciales.Add(label);





                ultima_posicion_y += 35;
                primero = false;
            }

            this.panel_entonces.Location = new System.Drawing.Point(16, ultima_posicion_y+20);
            this.panel_entonces.Refresh();

            this.Size = new System.Drawing.Size(678, ultima_posicion_y+140);

            this.button_aceptar.Location = new System.Drawing.Point(537, ultima_posicion_y+20 + 86);
            this.button_cancelar.Location = new System.Drawing.Point(411, ultima_posicion_y + 20 + 86);
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
                    item.Location = new System.Drawing.Point(430, ultima_posicion_y +20);
                    item.Refresh();
                    this.Controls.Add(item);
                }

            }
            //boton de eliminar
            foreach (Button item in lista_de_button_eliminar)
            {
                if (item.Name.Equals(id))
                {
                    item.Location = new System.Drawing.Point(580, ultima_posicion_y-5);
                    item.Refresh();
                    this.Controls.Add(item);
                }
                
            }
        }

        //getType(): obtiene el tipo de la instancia actual
        //Type.GetType(“tipo de objeto”): lo usamos para obtener una referencia con la que comparar
        //if(auxiliar.GetType() == Type.GetType("System.Int32"))        


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

    }
}
