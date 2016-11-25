using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace ControlesModuloConsulta
{
    public delegate void DelegadoCambioEnOpcionVariable (string id_variable);
    public partial class ControlSeleccionObjetivo : UserControl
    {
        //**************************************************************************
        //      Atributos
        //**************************************************************************
        public string titulo
        {
            get { return label_titulo.Text; }
            set { label_titulo.Text = value; }
        }

        public string pregunta_1
        {
            get { return label_pregunta_1.Text; }
            set { label_pregunta_1.Text = value; }
        }

        public string pregunta_2
        {
            get { return label_pregunta_2.Text; }
            set { label_pregunta_2.Text = value; }
        }

        public string id_variable_chequeada = null;
        public string id_estado_chequeada = null;

        
        public Button button_iniciar
        {
            get { return this.button_iniciar_inferencia; }
        }
        
        int ultimo_y = 15;
        int alto_control = 25;
        ArrayList opciones_variable = new ArrayList();
        ArrayList opciones_estado   = new ArrayList();

        public event DelegadoCambioEnOpcionVariable evento_cambio_en_seleccion_variable;

        //**************************************************************************
        // Métodos
        //**************************************************************************

        public ControlSeleccionObjetivo()
        {
            InitializeComponent();
        }


        public void agregarOpcionPanelVariables(string id_variable, string nombre_variable)
        {
            RadioButton radio = new RadioButton();
            radio.AutoSize = true;
            radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            radio.Location = new System.Drawing.Point(20, opciones_variable.Count*alto_control);
            radio.Name = id_variable;
            radio.Size = new System.Drawing.Size(107, 21);
            radio.TabIndex = 0;
            radio.TabStop = true;
            radio.Text = nombre_variable;
            radio.UseVisualStyleBackColor = true;
            radio.CheckedChanged += radio_variables_CheckedChanged;
            ultimo_y += alto_control;
            opciones_variable.Add(radio);
            this.panel_interno_variable.Controls.Add(radio);
            this.panel_interno_variable.Size = new System.Drawing.Size(494, opciones_variable.Count * alto_control);
            
        }


        public void agregarOpcionPanelEstados(string id_hecho, string texto_hecho)
        {
            RadioButton radio = new RadioButton();
            radio.AutoSize = true;
            radio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            radio.Location = new System.Drawing.Point(20, opciones_estado.Count * alto_control);
            radio.Name = id_hecho;
            radio.Size = new System.Drawing.Size(107, 21);
            radio.TabIndex = 0;
            radio.TabStop = true;
            radio.Text = texto_hecho;
            radio.UseVisualStyleBackColor = true;
            radio.CheckedChanged += radio_estados_CheckedChanged;
            opciones_estado.Add(radio);
            this.panel_interno_estados.Controls.Add(radio);
            this.panel_interno_estados.Size = new System.Drawing.Size(494, opciones_estado.Count * alto_control);
        }


        public void limpiarPanelVariable()
        {
            foreach (RadioButton item in opciones_variable)
                panel_interno_variable.Controls.Remove(item);
            this.panel_interno_variable.Size = new System.Drawing.Size(494,0);
            opciones_variable.Clear();
            opciones_variable = new ArrayList();
        }

        public void limpiarPanelEstados()
        {
            foreach (RadioButton item in opciones_estado)
                panel_interno_estados.Controls.Remove(item);
            this.panel_interno_estados.Size = new System.Drawing.Size(494, 0);
            opciones_estado.Clear();
            opciones_estado = new ArrayList();
        }

        //**************************************************************************
        //     Eventos
        //**************************************************************************


        void radio_variables_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                id_variable_chequeada = radio.Name;
                if (evento_cambio_en_seleccion_variable != null)
                    evento_cambio_en_seleccion_variable(id_variable_chequeada);
            }
        }

        void radio_estados_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                id_estado_chequeada = radio.Name;
            }
        }
    }
}
