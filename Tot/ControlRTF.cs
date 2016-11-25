using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tot
{
    public partial class ControlRTF : UserControl
    {
        public ControlRTF()
        {
            InitializeComponent();
        }

        private void button_insertar_imagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK) //Seleccionamos la imagen
            {
                Bitmap imagen = new Bitmap(file.FileName); //La cargamos en un objeto
                Clipboard.SetDataObject(imagen); //La cargamos en el portapapeles
                DataFormats.Format formato = DataFormats.GetFormat(DataFormats.Bitmap); //Obtenemos el formato
                richTextBox_principal.Paste(formato); //Pegamos lo que este en el portapapeles con el formato de la imagen.
            }
        
        }

        private void button_deshacer_Click(object sender, EventArgs e)
        {
            richTextBox_principal.Undo();
        }

        private void button_rehacer_Click(object sender, EventArgs e)
        {
            richTextBox_principal.Redo();
        }
    }
}
