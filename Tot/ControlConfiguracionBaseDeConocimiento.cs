using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaExpertoLib.GestionDelConocimiento;
using SistemaExpertoLib;
using System.IO;

namespace Tot
{
    public delegate void DelegadoAceptar();
    public delegate void DelegadoCancelar();
    public partial class ControlConfiguracionBaseDeConocimiento : UserControl
    {

        //*****************************************************************************************
        // Atributos
        //*****************************************************************************************
        GestionadorBaseConocimiento base_conocimiento;
        MetadatosBaseDeConocimiento metadatos;
        string path_temporal_imagen = null;

        public event DelegadoAceptar evento_aceptar;
        public event DelegadoCancelar evento_cancelar;


        public bool cambios
        {
            get { return _cambios; }
            set 
            { 
                _cambios = value;
                button_cancelar.Visible = value;
            }
        }
        bool _cambios = false;


        bool check_base_de_conocimiento
        {
            get
            {
                return checkBox_chequeo_base_de_conocimiento.Checked;
            }
            set
            {
                if (value)
                {
                    pictureBox_check_bae_de_conocimiento.Image = imageList_check_base_conocimiento.Images[1];
                }
                else
                {
                    pictureBox_check_bae_de_conocimiento.Image = imageList_check_base_conocimiento.Images[0];
                }
                checkBox_chequeo_base_de_conocimiento.Checked = value;
            }
        }

        //*****************************************************************************************
        // Métodos
        //*****************************************************************************************
        public ControlConfiguracionBaseDeConocimiento()
        {
            InitializeComponent();
        }

        public ControlConfiguracionBaseDeConocimiento(GestionadorBaseConocimiento base_conocimiento)
        {
            this.base_conocimiento = base_conocimiento;
            this.metadatos = base_conocimiento.leerMetadatos();
            InitializeComponent();
        }

        /// <summary>
        /// Método para mostrar la configuracion actual de la baes de conocimiento
        /// </summary>
        public void mostrarMetadatos()
        {
            this.metadatos = base_conocimiento.leerMetadatos();
            this.path_temporal_imagen = null;
            textBox_titulo.Text = metadatos.titulo_sistema_experto;
            if (metadatos.tipo_de_encadenamiento == MetadatosBaseDeConocimiento.ENCADENAMIENTO_HACIA_ATRAS)
            {
                radioButton_encadenamiento_hacia_atras.Checked = true;
                radioButton_encadenamiento_hacia_adelante.Checked = false;
            }
            else
            {
                radioButton_encadenamiento_hacia_atras.Checked = false;
                radioButton_encadenamiento_hacia_adelante.Checked = true;
            }
            check_base_de_conocimiento = metadatos.base_conocimiento_chequeada;
            mostrarImagen(metadatos.ruta_imagen_logo_sistema_experto);
            cambios = false;
        }
        
        /// <summary>
        /// Método para mostrar la imagen de metadatos en el contrl
        /// </summary>
        /// <param name="ruta">ruta de la imagen</param>
        public void mostrarImagen(string ruta)
        {
            if (pictureBox_logo.Image != null)
                pictureBox_logo.Image.Dispose();
            if (File.Exists(ruta))
            {
                pictureBox_logo.Image = Image.FromFile(ruta);
            }
            else
            {
                MessageBox.Show("La imagen de logo no existe", "Configuración base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inicializando los arhivos por defecto de la base de conocimiento
        /// </summary>
        public void inicializarArchivosMetadatos()
        {
            this.metadatos = base_conocimiento.leerMetadatos();
            string ruta_logo = base_conocimiento.ruta_carpeta_configuracion+"logo.jpg";
            if (pictureBox_logo.Image != null)
                pictureBox_logo.Image.Dispose();
            File.Copy("files\\logo_default.jpg", ruta_logo,true);
            base_conocimiento.metadatosCambiarRutaImageLogo(ruta_logo);

            string ruta_archivo_rtf_descriptivo = base_conocimiento.ruta_carpeta_configuracion + "descripcion.rtf";
            File.Copy("files\\descripcion.rtf", ruta_archivo_rtf_descriptivo,true);
            base_conocimiento.metadatosCambiarRutaRtfDescrptivo(ruta_archivo_rtf_descriptivo);
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
        /// Método que ingresa los cambios realizados en la configuracion a la base de conocimiento
        /// </summary>
        public void ingresarCambiosMetadatosBaseDeConocimiento()
        {
            base_conocimiento.metadatosCambiarTitulo(textBox_titulo.Text);
            //copianod imagen logo si se ha cambiado
            if (path_temporal_imagen != null)
            {
                pictureBox_logo.Image.Dispose();
                string ruta_logo = base_conocimiento.ruta_carpeta_configuracion + "logo.jpg";
                File.Copy(path_temporal_imagen, ruta_logo,true);
                base_conocimiento.metadatosCambiarRutaImageLogo(ruta_logo);
            }
            if (radioButton_encadenamiento_hacia_adelante.Checked)
            {
                base_conocimiento.metadatosCambiarEncadenamiento(GestionadorBaseConocimiento.ENCADENAMIENTO_HACIA_ADELANTE);
            }
            else
            if (radioButton_encadenamiento_hacia_atras.Checked)
            {
                base_conocimiento.metadatosCambiarEncadenamiento(GestionadorBaseConocimiento.ENCADENAMIENTO_HACIA_ATRAS);
            }
            MessageBox.Show("Cambios realizados correctamente","Configuración base de conocimiento",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        //*****************************************************************************************
        // Eventos
        //*****************************************************************************************
        private void button_seleccion_de_imagen_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog_imagen_logo.ShowDialog(this))
            {
                path_temporal_imagen = openFileDialog_imagen_logo.FileName;
                mostrarImagen(path_temporal_imagen);
                cambios = true;
            }
        }

        private void radioButton_encadenamiento_hacia_adelante_CheckedChanged(object sender, EventArgs e)
        {
            cambios = true;
        }

        private void radioButton_encadenamiento_hacia_atras_CheckedChanged(object sender, EventArgs e)
        {
            cambios = true;
        }

        private void button_chequear_base_de_conocimiento_Click(object sender, EventArgs e)
        {
            MessageBox.Show("implementar comrobacion");
            check_base_de_conocimiento = base_conocimiento.comprobarBaseDeConocimiento();
        }

        private void button_descripcion_sistema_experto_Click(object sender, EventArgs e)
        {
            FormVentanaRTF ventana_editor_rtf = new FormVentanaRTF();
            string ruta_rtf = metadatos.ruta_rtf_descripcion_sistema_experto;
            ventana_editor_rtf.ruta_archivo = ruta_rtf;
            ventana_editor_rtf.ShowDialog(this);
            cambios = true;
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (!cambios)
            {
                if (evento_aceptar != null)
                    evento_aceptar();
            }
            else
            {
                if (preguntasSiNoCancelar("Configuración base de conocimiento","Se modificaran la configuración de la base de conocimiento,\n¿Usted desea continuar?") == 1)
                {
                    ingresarCambiosMetadatosBaseDeConocimiento();
                    if (evento_aceptar != null)
                        evento_aceptar();
                }
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            if (cambios)
                if(preguntasSiNoCancelar("Configuración base de conocimiento","Se perderan los cambios realizados a la configuración,\n¿Está seguro de cancelar la edición?") == 1)
                    if (evento_cancelar != null)
                        evento_cancelar();
        }

        private void textBox_titulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            cambios = true;
        }


    }
}
