using Ionic.Zip;
using SistemaExpertoLib;
using SistemaExpertoLib.GestionDelConocimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tot_Sistema_Experto
{
    public partial class FormVentanaPrincipal : Form
    {
        //*******************************************************************************************
        // Atributos
        //*******************************************************************************************

        GestionConfiguracionInternaTot configuracion_interna;
        GestionadorBaseConocimiento base_conocimiento;
        FormVentanaCargando ventana_cargando = new FormVentanaCargando();
        FormVentanaConfiguracionLogInferencia ventana_configuracion_log; 
        bool base_de_conocimiento_checkeada = false;


        bool check_base_de_conocimiento
        {
            get
            {
                return base_de_conocimiento_checkeada;
            }
            set
            {
                if (value)
                {
                    pictureBox_check_bae_de_conocimiento.Image = imageList_check_base_conocimiento.Images[1];
                    label_info.Text = "Información: Base de conocimiento correcta";
                }
                else
                {
                    pictureBox_check_bae_de_conocimiento.Image = imageList_check_base_conocimiento.Images[0];
                    label_info.Text = "Información: Base de conocimiento no esta chequeada.";
                }
                base_de_conocimiento_checkeada = value;
                button_iniciar.Enabled = value;
            }
        }
        //*******************************************************************************************
        // Métodos
        //*******************************************************************************************
        public FormVentanaPrincipal()
        {
            InitializeComponent();
            base_conocimiento = new GestionadorBaseConocimiento();
            try
            {
                if (!base_conocimiento.existe_base_de_conocimiento)
                {
                    MessageBox.Show("No se ha establecido una base de conocimiento para la inferencia", "Base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label_info.Text = "Información: Base de conocimiento no establecida";
                }
                else
                {
                    mostrarMetadatos();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("La base de conocimiento esta corrupta.\n Se debe volver a importar", "Base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_info.Text = "Información: Base de conocimiento no establecida";
                DirectoryInfo directorio_base_conocimiento = new DirectoryInfo(base_conocimiento.ruta_carpeta_base_conocimiento);
                string ruta_absoluta = directorio_base_conocimiento.FullName;
                if (directorio_base_conocimiento.Exists)
                    directorio_base_conocimiento.Delete(true);
            }
            configuracion_interna = new GestionConfiguracionInternaTot();
            if (!configuracion_interna.existe_archivo_configuracion)
                configuracion_interna.ingresarProcesadorDeLoggeo(new ProcesadorLogInferencia());
            ventana_configuracion_log = new FormVentanaConfiguracionLogInferencia(); 
        }

        /// <summary>
        /// Método que gestiona la importación de la base de conocimiento
        /// </summary>
        private void importar()
        {
            if (MessageBox.Show("Se perderá la base de conocimiento actual.\n ¿Usted desea continuar?", "Importación base de conocimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (openFileDialog_importar.ShowDialog() == DialogResult.OK)
                {
                    liberarRecursosImagenLogo();
                    string ruta_zip = openFileDialog_importar.FileName;
                    // ZipFile.CreateFromDirectory(startPath, zipPath);
                    // TextWriter t = new TextWriter();
                    ReadOptions options = new ReadOptions { StatusMessageWriter = System.Console.Out };
                    using (ZipFile zip = ZipFile.Read(ruta_zip, options))
                    {
                        DirectoryInfo directorio_base_conocimiento = new DirectoryInfo(base_conocimiento.ruta_carpeta_base_conocimiento);
                            try
                            {
                                string ruta_absoluta = directorio_base_conocimiento.FullName;
                                if (directorio_base_conocimiento.Exists)
                                    directorio_base_conocimiento.Delete(true);
                                zip.ExtractAll(ruta_absoluta);
                                base_conocimiento.actualizarEstadisticas();
                                MessageBox.Show("Se ha importado correctamente la base de conocimiento", "Importando base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                mostrarMetadatos();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Error en la importación de datos\n", "Importando base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        
                    }//End using
                }//End if fileDialog
            mostrarVentanaCargandoDesdeHilo(false);
        }


        /// <summary>
        /// Método para ser utilizado ocultar la ventana en los thread
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        private int mostrarVentanaCargandoDesdeHilo(bool visible = false)
        {
            //Hacemos la sincronizacion de hilos.
            //Si no estamos en el Hilo Principal.
            if (ventana_cargando.InvokeRequired)
            {
                //Invocamos el hilo principal.
                Func<bool, int> delegado = new Func<bool, int>(mostrarVentanaCargandoDesdeHilo);
                ventana_cargando.Invoke(delegado, visible);
            }
            else
            {
                ventana_cargando.Visible = visible;
            }
            return 0;
        }

        private void mostrarMetadatos()
        {
            MetadatosBaseDeConocimiento metadatos = base_conocimiento.leerMetadatos();
            textBox_titulo.Text = metadatos.titulo_sistema_experto;
            if (metadatos.tipo_de_encadenamiento == MetadatosBaseDeConocimiento.ENCADENAMIENTO_HACIA_ATRAS)
            {
                label_tipo_de_encadenamiento.Text = "Hacia atrás";
            }
            else
            {
                label_tipo_de_encadenamiento.Text = "Hacia adelante";
            }
            check_base_de_conocimiento = metadatos.base_conocimiento_chequeada;
            mostrarImagen(metadatos.ruta_imagen_logo_sistema_experto);

        }

        private void mostrarImagen(string ruta)
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
        private void liberarRecursosImagenLogo()
        {
            if (pictureBox_logo.Image != null)
                pictureBox_logo.Image.Dispose();
        }
        //*******************************************************************************************
        // Eventos
        //*******************************************************************************************
        private void button_importar_Click(object sender, EventArgs e)
        {
            ventana_cargando.Show();
            System.Threading.ThreadStart metodo = new System.Threading.ThreadStart(importar);
            metodo.Invoke();
        }

        private void button_iniciar_Click(object sender, EventArgs e)
        {
            GestionMotorInferencia gestion_inferencia = new GestionMotorInferencia(base_conocimiento.ruta_carpeta_base_conocimiento, this);
            gestion_inferencia.procesador_log_inferencia = configuracion_interna.extraerProcesadorDeLoggeo();
            gestion_inferencia.iniciarProceso();
        }

        int mostrar_configuracion = 0;

        private void FormVentanaPrincipal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mostrar_configuracion++;
            if (mostrar_configuracion > 3)
                button_configuracion_log.Visible = true;
            
        }

        private void button_configuracion_log_Click(object sender, EventArgs e)
        {
            ventana_configuracion_log.mostrarConfiguracionProcesadorLoggeo(configuracion_interna.extraerProcesadorDeLoggeo());
            ventana_configuracion_log.ShowDialog();
        }





    }
}
