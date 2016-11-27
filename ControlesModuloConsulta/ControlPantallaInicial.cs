using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesModuloConsulta
{
    public partial class ControlPantallaInicial : UserControl
    {
        /// <summary>
        /// Titulo del sistema experto
        /// </summary>
        string tiulo_sistema_experto
        {
            get { return label_titulo_sistema_experto.Text; }
            set { label_titulo_sistema_experto.Text = value; }
        }

        /// <summary>
        /// Ruta del archivo descriptivo a mostrar en la descripción
        /// </summary>
        string ruta_rtf_descripcion
        {
            get { return _ruta_rtf_descripcion; }
            set 
            { 
                _ruta_rtf_descripcion = value;
                mostrarRTFDescripcion();
            }
        }
        string _ruta_rtf_descripcion = "";

        /// <summary>
        /// Ruta de la imagen de 200 x 400 a mostrar en el logo
        /// </summary>
        string ruta_imagen
        {
            get { return _ruta_imagen; }
            set
            {
                _ruta_imagen = value;
                mostrarImagenEnLogo();
            }
        }
        string _ruta_imagen = "";

        /// <summary>
        /// Button para captar evento de iniciar proceso
        /// </summary>
        public Button boton_inicial
        {
            get { return button_iniciar; }
        }

        public event DelegadoRespuestaLista evento_continuar;

        public ControlPantallaInicial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo para mostrar el archivo rtf en la descripción del control
        /// </summary>
        public void mostrarRTFDescripcion()
        {
            richTextBox_descripcion.Clear();

            try
            {
                this.richTextBox_descripcion.Rtf = System.IO.File.ReadAllText(_ruta_rtf_descripcion, System.Text.Encoding.Default);
            }
            catch (Exception) //error occured, that means we loaded invalid RTF, so load as plain text
            {
                this.richTextBox_descripcion.Text = System.IO.File.ReadAllText(_ruta_rtf_descripcion, System.Text.Encoding.Default);
            }
        }


        public void mostrarImagenEnLogo()
        {
            try
            {
                Image img = Image.FromFile(_ruta_imagen);
            }
            catch (Exception)
            {
                MessageBox.Show("La Imagen no existe");
            }
            
        }

        private void button_iniciar_Click(object sender, EventArgs e)
        {
            if (evento_continuar != null)
                evento_continuar();
        }


    }
}
