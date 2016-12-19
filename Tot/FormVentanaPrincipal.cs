using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using SistemaExpertoLib;
using SistemaExpertoLib.GestionDelConocimiento;
using Ionic.Zip;
using System.IO;
using System.Threading;

namespace Tot
{
    public partial class FormVentanaPrincipal : Form
    {
        //*******************************************************************************************
        // Atributos
        //*******************************************************************************************
        
        GestionadorBaseConocimiento base_conocimiento;
        GestionConfiguracionInternaTot configuracion_interna;
        FormVentanaConfiguracion ventana_configuracion;
        FormVentanaConfiguracionLogInferencia ventana_configuracion_log; 
        FormVentanaGestiónBaseConocimiento ventana_gestion_de_conocimiento;
        FormVentanaCargando ventana_cargando = new FormVentanaCargando();

        //*******************************************************************************************
        // Métodos
        //*******************************************************************************************
        public FormVentanaPrincipal()
        {

           // new FormVentanaAcercaDe().ShowDialog();
          //  System.Environment.Exit(0);
            
            InitializeComponent();

            base_conocimiento = new GestionadorBaseConocimiento();
            configuracion_interna = new GestionConfiguracionInternaTot();

            ventana_configuracion = new FormVentanaConfiguracion(base_conocimiento);
            ventana_configuracion.MdiParent = this;

            ventana_configuracion_log = new FormVentanaConfiguracionLogInferencia(configuracion_interna);
            ventana_configuracion_log.MdiParent = this;

            if (!base_conocimiento.existe_base_de_conocimiento)
            {
                base_conocimiento.iniciarNuevaBaseDeConocimiento();
                ventana_configuracion.inicializarArchivosDeConfiguracionBaseDeConocimiento();
                MessageBox.Show("La base de conocimiento no ha sido creada.\n Se ha creado una nueva base de conocimiento vacia", "Gestión Base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ventana_configuracion.completarVentana();
                ventana_configuracion.Show();
            }

            if (!configuracion_interna.existe_archivo_configuracion)
                configuracion_interna.ingresarProcesadorDeLoggeo(new ProcesadorLogInferencia());
            
            ventana_gestion_de_conocimiento = new FormVentanaGestiónBaseConocimiento(base_conocimiento);
            ventana_gestion_de_conocimiento.MdiParent = this;
           // ventana_cargando.Visible = false;

        }

        /// <summary>
        /// Método que gestiona la importación de la base de conocimiento
        /// </summary>
        private void importar()
        {
            if (MessageBox.Show("Se perderá la base de conocimiento actual.\n ¿Usted desea continuar?", "Importación base de conocimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (openFileDialog_importar.ShowDialog() == DialogResult.OK)
                {
                    
                    string ruta_zip = openFileDialog_importar.FileName;
                    // ZipFile.CreateFromDirectory(startPath, zipPath);
                    // TextWriter t = new TextWriter();
                    ReadOptions options = new ReadOptions { StatusMessageWriter = System.Console.Out };
                    using (ZipFile zip = ZipFile.Read(ruta_zip, options))
                    {
                        DirectoryInfo directorio_base_conocimiento = new DirectoryInfo(base_conocimiento.ruta_carpeta_base_conocimiento);

                        if (directorio_base_conocimiento.Exists)
                        {
                            try
                            {
                                string ruta_absoluta = directorio_base_conocimiento.FullName;
                                directorio_base_conocimiento.Delete(true);
                                zip.ExtractAll(ruta_absoluta);
                                base_conocimiento.actualizarEstadisticas();
                                MessageBox.Show("Se ha importado correctamente la base de conocimiento", "Importando base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception e )
                            {
                                MessageBox.Show("Error en la importación de datos\n", "Importando base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }//End using
                }//End if fileDialog
            mostrarVentanaCargandoDesdeHilo(false);
        }

        /// <summary>
        /// Método que gestiona la ixportación de la base de conocimiento
        /// </summary>
        private void exportar()
        {
            if (saveFileDialog_exportar.ShowDialog() == DialogResult.OK)
            {
                string ruta_exportacion = saveFileDialog_exportar.FileName;
                try
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        zip.StatusMessageTextWriter = System.Console.Out;
                        zip.AddDirectory(base_conocimiento.ruta_carpeta_base_conocimiento); // recurses subdirectories
                        zip.Save(ruta_exportacion);
                        MessageBox.Show("Se ha importado correctamente la base de conocimiento\n" + ruta_exportacion, "Importando base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception ex1)
                {
                    MessageBox.Show("Problemas con la exportación de la base de conocimiento", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        //*******************************************************************************************
        // Eventos
        //*******************************************************************************************
        private void iniciarInferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionMotorInferencia gestion_inferencia = new GestionMotorInferencia(base_conocimiento.ruta_carpeta_base_conocimiento, this);
            gestion_inferencia.procesador_log_inferencia = configuracion_interna.extraerProcesadorDeLoggeo();
            gestion_inferencia.iniciarProceso();
        }

        private void ToolStripMenuItem_editor_base_conocimiento_Click(object sender, EventArgs e)
        {
            ventana_gestion_de_conocimiento.Visible = true;
        }

        private void ToolStripMenuItem_salir_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventana_configuracion.completarVentana();
            ventana_configuracion.Visible = true;
        }

        private void ToolStripMenuItemimportarBaseDeConocimiento_Click(object sender, EventArgs e)
        {
            ventana_configuracion.Visible = false;
            ventana_gestion_de_conocimiento.Visible = false;
            ventana_cargando.Show();
            System.Threading.ThreadStart metodo = new System.Threading.ThreadStart(importar);
            metodo.Invoke();
        }

        private void ToolStripMenuItemexportarBaseDeConocimiento_Click(object sender, EventArgs e)
        {
            ventana_configuracion.Visible = false;
            ventana_gestion_de_conocimiento.Visible = false;
            ventana_cargando.Show();
            System.Threading.ThreadStart metodo = new System.Threading.ThreadStart(exportar);
            metodo.Invoke();
        }

        private void nuevaBaseDeConocimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Se perderá la base de conocimiento actual.\n ¿Usted desea continuar?", "Crear nueva base de conocimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ventana_configuracion.Visible = false;
                ventana_gestion_de_conocimiento.Visible = false;
                base_conocimiento.iniciarNuevaBaseDeConocimiento();
                base_conocimiento.actualizarEstadisticas();
                ventana_configuracion.inicializarArchivosDeConfiguracionBaseDeConocimiento();
                MessageBox.Show("La nueva base de conocimiento ha sido creada correctamente", "Gestión Base de conocimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ventana_configuracion.completarVentana();
                ventana_configuracion.Show();
            }
        }

        private void configuraciónLogInferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventana_configuracion_log.Visible = true;
            ventana_configuracion_log.mostrarConfiguracionProcesadorLoggeo(configuracion_interna.extraerProcesadorDeLoggeo());
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormVentanaIndiceDeAyudas().ShowDialog();
        }

        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FormVentanaAcercaDe().ShowDialog();
        }



    }

}
