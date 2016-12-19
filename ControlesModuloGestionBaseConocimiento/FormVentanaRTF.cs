using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextRuler;
using TextRuler.AdvancedTextEditorControl;
namespace Tot
{
    public partial class FormVentanaRTF : Form
    {
        //*************************************************************************
        //       Atributos
        //*************************************************************************

        AdvancedTextEditor editor_avanzado_rtf = new AdvancedTextEditor();
        public string ruta_archivo
        {
            get { return editor_avanzado_rtf._ruta_obligatoria_guardado; }
            set { editor_avanzado_rtf._ruta_obligatoria_guardado = value; }
        }
        public bool cancelar_apertura_archivo = false;

        public bool modo_lectura = false;


        //*************************************************************************
        //         Métodos
        //*************************************************************************
        public FormVentanaRTF()
        {
            InitializeComponent();
            iniciarEditorAvanzado();
        }

        public FormVentanaRTF(bool modo_lectura)
        {
            InitializeComponent();
            iniciarEditorAvanzado(modo_lectura);
            this.modo_lectura = modo_lectura;
        }



        public void iniciarEditorAvanzado(bool modo_lectura = false)
        {
            editor_avanzado_rtf.Dock = System.Windows.Forms.DockStyle.Fill;
            editor_avanzado_rtf.Location = new System.Drawing.Point(0, 0);
            editor_avanzado_rtf.Name = "advancedTextEditor1";
            editor_avanzado_rtf.Size = new System.Drawing.Size(745, 562);
            editor_avanzado_rtf.TabIndex = 0;
            editor_avanzado_rtf.modo_lectura = modo_lectura;
            this.Controls.Add(editor_avanzado_rtf);
            
        }


        public void abrirArchivo(string ruta)
        {
            editor_avanzado_rtf.abrirArchivo(ruta);
        }

        private void FormVentanaRTF_Shown(object sender, EventArgs e)
        {
            if (!cancelar_apertura_archivo)
                editor_avanzado_rtf.abrirArchivo(ruta_archivo);
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

        private void FormVentanaRTF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!modo_lectura)
            {
                int opcion = preguntasSiNoCancelar("Editor de texto", "Guardar cambios documento?");
                switch (opcion)
                {

                    case 1:
                        editor_avanzado_rtf.GuardadoObligatorio();
                        break;
                    case 2:

                        break;
                    case -1:
                        e.Cancel = true;
                        break;
                }
            }
            
        }

    }
}
