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
        

        //*************************************************************************
        //         Métodos
        //*************************************************************************
        public FormVentanaRTF()
        {
            InitializeComponent();
            iniciarEditorAvanzado();
        }

        public void iniciarEditorAvanzado()
        {
            editor_avanzado_rtf.Dock = System.Windows.Forms.DockStyle.Fill;
            editor_avanzado_rtf.Location = new System.Drawing.Point(0, 0);
            editor_avanzado_rtf.Name = "advancedTextEditor1";
            editor_avanzado_rtf.Size = new System.Drawing.Size(745, 562);
            editor_avanzado_rtf.TabIndex = 0;
            this.Controls.Add(editor_avanzado_rtf);
            
        }

    }
}
