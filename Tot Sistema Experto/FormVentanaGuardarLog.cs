using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tot_Sistema_Experto
{
    public partial class FormVentanaGuardarLog : Form
    {
        //*******************************************************************************
        // Atributos
        //*******************************************************************************
        public const int GUARDADO_NORMAL    = 1;
        public const int GUARDADO_COMPLETO  = 2;

        public int tipo_de_guardado
        {
            get
            {
                if (radioButton_normal.Checked)
                    return GUARDADO_NORMAL;
                else
                if (radioButton_completo.Checked)
                    return GUARDADO_COMPLETO;
                return -1;
            }
        }

        public string ruta_guardado
        {
            get
            {
                return saveFileDialog_guardar_log.FileName;
            }
        }
        public bool guardar_variables
        {
            get { return checkBox_guardar_variables.Checked; }
        }
        public bool guardar_hechos
        {
            get { return checkBox_guardar_hechos.Checked; }
        }
        public bool guardar_reglas
        {
            get { return checkBox_guardar_reglas.Checked; }
        }

        //*******************************************************************************
        //   Métodos
        //*******************************************************************************

        public FormVentanaGuardarLog()
        {
            InitializeComponent();
        }


        //*******************************************************************************
        //  Eventos
        //*******************************************************************************
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.DialogResult = saveFileDialog_guardar_log.ShowDialog();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormVentanaGuardarLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            if (this.DialogResult != DialogResult.OK)
                this.DialogResult = DialogResult.Cancel;
            //e.Cancel = true;
        }
    }
}
