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

namespace ControlesModuloConsulta
{
    public delegate void DelegadoRespuestaLista();
    public partial class ControlPreguntarVariable : UserControl
    {
        //******************************************************************************
        // Atributos
        //******************************************************************************

        public string titulo
        {
            get
            {
                return label_titulo.Text;
            }
            set 
            {
                label_titulo.Text = value;
            }
        }

        public string rango
        {
            get
            {
                return label_rango.Text;
            }
            set
            {
                label_rango.Text = value;
            }
        }


        public string pregunta
        {
            get
            {
                return textBox_pregunta.Text;
            }
            set
            {
                textBox_pregunta.Text = value;
            }
        }

        public bool ingreso_chequeado = false;
        
        public bool valor_variable_booleano = false;
        public string valor_variable_lista = "";
        public double valor_variable_numerica = -9999999;




        public event DelegadoRespuestaLista evento_respuesta_lista;

        Variable variable_actual;


        //******************************************************************************
        // Metodos
        //******************************************************************************

        public ControlPreguntarVariable()
        {
            InitializeComponent();
        }

        public void limpiarVentana()
        {
            marcarControl(false);
            ingreso_chequeado = false;
            variable_actual = null;
            valor_variable_booleano = false;
            valor_variable_lista = "";
            valor_variable_numerica = -9999999;
            titulo = "";
            rango = "";
            pregunta = "";
            richTextBox_descripcion_variable.Clear();
            richTextBox_descripcion_variable.Text = "";
            textBox_numero_real.Text = "";
            textBox_numero_real.Visible = false;
            numericUpDown_numero_cardinal.Value = numericUpDown_numero_cardinal.Minimum;
            numericUpDown_numero_cardinal.Visible = false;
            this.panel_respuesta.Controls.Remove(this.comboBox_lista_opciones);
            comboBox_lista_opciones = null;
         
            
          
            
        }

        private void crearComboBox()
        {
            comboBox_lista_opciones = new ComboBox();
            comboBox_lista_opciones.FormattingEnabled = true;
            comboBox_lista_opciones.Location = new System.Drawing.Point(178, 22);
            comboBox_lista_opciones.Name = "comboBox_lista_opciones";
            comboBox_lista_opciones.Size = new System.Drawing.Size(200, 21);
            this.panel_respuesta.Controls.Add(this.comboBox_lista_opciones);
        }


        public void consultarVariable(Variable variable)
        {
            limpiarVentana();
            variable_actual = variable;
            titulo = variable_actual.nombre_variable;
            pregunta= variable.texto_consulta_variable;
            if (variable.ruta_texto_descriptivo != null && !variable.ruta_texto_descriptivo.Equals(""))
            {
                mostrarRTFDescripcion(variable.ruta_texto_descriptivo);
            }
            //mostrando opciones variable
            switch (variable.tipo_variable)
            {
                case Variable.BOOLEANO:
                    crearComboBox();
                    comboBox_lista_opciones.Visible = true;
                    comboBox_lista_opciones.Items.Add("Si");
                    comboBox_lista_opciones.Items.Add("No");
                    break;
                case Variable.LISTA:
                    crearComboBox();
                    comboBox_lista_opciones.Visible = true;
                    string[] opciones = variable.listarOpciones();
                    for (int i = 0; i < opciones.Length; i++)
                        comboBox_lista_opciones.Items.Add(opciones[i]);    
                    break;
                case Variable.NUMERICO:
                    if (variable.cardinal)
                    {
                        numericUpDown_numero_cardinal.Visible = true;
                        int min = -99999999;
                        int max = 99999999;
                        if (variable.rango_limitado)
                        {
                            label_rango.Visible = true;
                            min = (int)variable.rango_limite_inferior;
                            max = (int)variable.rango_limite_superior;
                            label_rango.Text = "Rango posible  [ " + min + " : " + max + " ]";
                        }
                        numericUpDown_numero_cardinal.Maximum = (decimal)max;
                        numericUpDown_numero_cardinal.Minimum = (decimal)min;
                        if (min < 0 && 0 < max)
                            numericUpDown_numero_cardinal.Value = (decimal)0;
                        else
                            numericUpDown_numero_cardinal.Value = (decimal)((int)((min + max) / 2));
                    }
                    else
                    {
                        textBox_numero_real.Visible = true;
                        if (variable.rango_limitado)
                        {
                            label_rango.Visible = true;
                            label_rango.Text = "Rango posible [ "
                                               + variable.rango_limite_inferior
                                               + " : "
                                               + variable.rango_limite_superior
                                               + " ]";
                        }
                    }
                    break;
            }
        }
        

        /// <summary>
        /// Metodo para mostrar el archivo rtf en la descripción del control
        /// </summary>
        public void mostrarRTFDescripcion(string ruta_richText)
        {
            richTextBox_descripcion_variable.Clear();
            try
            {
                this.richTextBox_descripcion_variable.Rtf = System.IO.File.ReadAllText(ruta_richText, System.Text.Encoding.Default);
            }
            catch (Exception e) //error occured, that means we loaded invalid RTF, so load as plain text
            {
                this.richTextBox_descripcion_variable.Text = System.IO.File.ReadAllText(ruta_richText, System.Text.Encoding.Default);
            } 
        }

        public void marcarControl (bool marcado)
        {

            if (marcado)
                panel_respuesta.BackColor = System.Drawing.Color.Yellow;
            else
                panel_respuesta.BackColor = System.Drawing.SystemColors.Window;
        
        }

        public void comprobarIngreso()
        {
            string errores = "";
            marcarControl(false);
            switch (variable_actual.tipo_variable)
            {
                case Variable.BOOLEANO:
                    if (comboBox_lista_opciones.SelectedItem == null)
                    {
                        if (!errores.Equals(""))
                            errores += "\n";
                        errores += "No se ha selecionado opción";
                        marcarControl(true);
                    }
                    else
                    {
                        string opcion = comboBox_lista_opciones.SelectedItem+"";
                        if (opcion.Equals("Si"))
                            valor_variable_booleano = true;
                        else
                        {
                            valor_variable_booleano = false;
                        }
                    }
                    break;
                case Variable.LISTA:
                    if (comboBox_lista_opciones.SelectedItem == null)
                    {
                        if (!errores.Equals(""))
                            errores += "\n";
                        errores += "No se ha selecionado opción";
                        marcarControl(true);
                    }
                    valor_variable_lista = comboBox_lista_opciones.SelectedItem + "";
                    break;
                case Variable.NUMERICO:
                    if (variable_actual.cardinal)
                    {
                        valor_variable_numerica = (double)numericUpDown_numero_cardinal.Value;
                    }
                    else
                    {//real
                        if (textBox_numero_real.Text.Equals(""))
                        {
                            if (!errores.Equals(""))
                                errores += "\n";
                            errores += "No se ha ingresado un valor";
                            marcarControl(true);
                        }
                        else
                        {
                            try
                            {
                                double numero = Double.Parse(textBox_numero_real.Text);
                                if (variable_actual.rango_limitado)
                                {
                                    if (!(variable_actual.rango_limite_inferior <= numero && numero <= variable_actual.rango_limite_superior))
                                    {
                                        if (!errores.Equals(""))
                                            errores += "\n";
                                        errores += "El valor excede el rango";
                                        marcarControl(true);
                                    }
                                    else
                                    {
                                        valor_variable_numerica = numero;
                                    }

                                }
                                else
                                {
                                    valor_variable_numerica = numero;
                                }
                            }
                            catch (Exception)
                            {
                                if (!errores.Equals(""))
                                    errores += "\n";
                                errores += "Error en el ingreso de la variable";
                                marcarControl(true);
                            }
                        }
                    }
                    break;
            }

            if (errores.Equals(""))
            {
                ingreso_chequeado = true;
                if (evento_respuesta_lista != null)
                    evento_respuesta_lista();
            }
            
            else
            {
                MessageBox.Show(errores, "Consulta variable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public ArrayList obtenerResultadosPregunta()
        {
            ArrayList retorno = new ArrayList();
            retorno.Add(variable_actual.id_variable);
            switch (variable_actual.tipo_variable)
            {
                case Variable.BOOLEANO:
                    retorno.Add(valor_variable_booleano);
                    break;
                case Variable.LISTA:
                    retorno.Add(valor_variable_lista);
                    break;
                case Variable.NUMERICO:
                    retorno.Add(valor_variable_numerica);
                    break;
            }
            return retorno;
        }

        //******************************************************************************
        // Eventos 
        //******************************************************************************

        private void textBox_numero_real_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = ((System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture).NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
                string[] n = textBox_numero_real.Text.Split(e.KeyChar);
                if (n.Length>1)
                    e.Handled = true;
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

        private void numericUpDown_numero_cardinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.Handled = true;
            }
        }

        private void button_continuar_Click(object sender, EventArgs e)
        {
            comprobarIngreso();
        }
    }
}
