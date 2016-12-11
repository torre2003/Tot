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
        public string tiulo_sistema_experto
        {
            get { return label_titulo_sistema_experto.Text; }
            set { label_titulo_sistema_experto.Text = value; }
        }

        /// <summary>
        /// Ruta del archivo descriptivo a mostrar en la descripción
        /// </summary>
        public string ruta_rtf_descripcion
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
        public string ruta_imagen_logo
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

        /// <summary>
        /// Metodo que muestr a la imagen de logo en base a la ruta especifica
        /// </summary>
        private void mostrarImagenEnLogo()
        {
            try
            {
                Image img = Image.FromFile(_ruta_imagen);
                pictureBox_logo.Image = img;
            }
            catch (Exception)
            {
                MessageBox.Show("La Imagen no existe");
            }
            
        }

        /// <summary>
        /// Método que libera los recursos asocioados a la imagen de logo
        /// </summary>
        public void liberarRecursosImagenLogo()
        {
            if (pictureBox_logo.Image != null)
                pictureBox_logo.Image.Dispose();
        }

        private void button_iniciar_Click(object sender, EventArgs e)
        {
            if (evento_continuar != null)
                evento_continuar();
        }


    }
}
