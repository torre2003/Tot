
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib
{
    [Serializable()]
    class AccesoDatos
    {


        //*************************************************************************
        // Atributos
        //*************************************************************************
        
        public const int VARIABLE = 1;
        public const int HECHO = 2;
        public const int REGLA = 3;

        public string ruta_carpeta_archivos
        {
            get
            {
                return _ruta_carpeta_archivos;
            }
            set
            {
                _ruta_carpeta_archivos = value;
                _existe_base_conocimiento = System.IO.Directory.Exists(_ruta_carpeta_archivos);
            }
        }
        string _ruta_carpeta_archivos = "base conocimiento\\";
        private string carpeta_configuracion = "configuracion\\";
        private string carpeta_archivos_rtf = "rtf\\";
        private string archivo_configuracion = "confTot";

        /// <summary>
        /// Obtiene la ruta del archivo de configuracion
        /// </summary>
        public string ruta_archivo_configuracion
        {
            get
            {
                return ruta_carpeta_archivos + carpeta_configuracion + archivo_configuracion;
            }
        }

        /// <summary>
        /// Obtiene la ruta de la carpeta de configuracion
        /// </summary>
        public string ruta_carpeta_configuracion
        {
            get
            {
                return ruta_carpeta_archivos + carpeta_configuracion;
            }
        }

        /// <summary>
        /// Obtiene la ruta de archivo rtf
        /// </summary>
        public string ruta_carpeta_rtf
        {
            get
            {
                return ruta_carpeta_archivos + carpeta_archivos_rtf;
            }
        }
        
        /// <summary>
        /// Obtiene si existe la base de conocimiento
        /// </summary>
        public bool existe_base_conocimiento
        {
            get { return _existe_base_conocimiento; }
        }

        bool _existe_base_conocimiento = false;
        //*************************************************************************
        // Métodos
        //*************************************************************************
        /// <summary>
        /// Constructor
        /// </summary>
        public AccesoDatos()
        {
            if (System.IO.Directory.Exists(ruta_carpeta_archivos))
                _existe_base_conocimiento = true;
            
        }
            
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="ruta_carpeta_archivos">Ruta del repositorio de la base de conocimiento</param>
        public AccesoDatos(string ruta_carpeta_archivos)
        {
            this.ruta_carpeta_archivos = ruta_carpeta_archivos;
            if (System.IO.Directory.Exists(ruta_carpeta_archivos))
                _existe_base_conocimiento = true;
        }

        /// <summary>
        /// Método para inicializar la carpeta de la base de conocimiento y la de configuracion
        /// </summary>
        public void inicializarCarpetaArchivos()
        {
            if (!System.IO.Directory.Exists(ruta_carpeta_archivos))
            {
                System.IO.Directory.CreateDirectory(ruta_carpeta_archivos);
                System.IO.Directory.CreateDirectory(ruta_carpeta_archivos + carpeta_configuracion);
                System.IO.Directory.CreateDirectory(ruta_carpeta_archivos + carpeta_archivos_rtf);
                _existe_base_conocimiento = true;
            }
        }

        /// <summary>
        /// Método que elimina la carpeta completa asociada a la base de conocimiento
        /// </summary>
        public void eliminarCarpetaBaseConocimiento()
        {
            if (System.IO.Directory.Exists(ruta_carpeta_archivos))
            {
                System.IO.Directory.Delete(ruta_carpeta_archivos,true);
            }
            _existe_base_conocimiento = false;
        }

        /// <summary>
        /// Método que lista los arhcivos disponibles en el repositorio
        /// </summary>
        /// <param name="tipo_de_archivos">Constante del tipo de archivo a listar, VARIABLE,HECHO,REGLA</param>
        /// <returns></returns>
        public string[] listarArchivosEnDirectorio(int tipo_de_archivos)
        {

            string tipo = "";
            switch (tipo_de_archivos)
            {
                case VARIABLE:
                    tipo = "V_*";
                    break;
                case HECHO:
                    tipo = "H_*";
                    break;
                case REGLA:
                    tipo = "R_*";
                    break;
                default:
                    break;
            }

            DirectoryInfo directorios_de_datos = new DirectoryInfo(this.ruta_carpeta_archivos);
            FileInfo[] archivos_directorios = directorios_de_datos.GetFiles(tipo);
            string[] lista_de_archivos = new string[archivos_directorios.Length];
            for (int i = 0; i < lista_de_archivos.Length; i++)
            {
                lista_de_archivos[i] = archivos_directorios[i].Name;
            }
            return lista_de_archivos;
        }

        /// <summary>
        /// Utilitario comprueba la existencia de un archivo
        /// </summary>
        /// <param name="ruta">ruta del archivo a comprobar</param>
        /// <returns>true si el archivo existe | False en caso contrario</returns>
        public bool comprobarArchivo(string ruta)
        {
            return File.Exists(ruta);
        }
        /// <summary>
        /// utilitario comprueba la existencia de una carpeta
        /// </summary>
        /// <param name="ruta">ruta de la carpeta a comprobar</param>
        /// <returns>true si la carpeta existe | False en caso contrario</returns>
        public bool comprobarCarpeta(string ruta)
        {
            return Directory.Exists(ruta_carpeta_archivos);
        }
        #region Variable
        /// <summary>
        /// Método para ingresar una nueva variable al repositorio
        /// </summary>
        /// <param name="variable">Objeto Variable a ingresar</param>
        public void ingresarNuevaVariable(Variable variable)
        {
            string id_variable = "";
            if (variable != null)
            {
                id_variable = variable.id_variable;
            }

            if (File.Exists(ruta_carpeta_archivos + id_variable))
                File.Delete(ruta_carpeta_archivos + id_variable);
            using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_variable))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, variable);
                stream.Close();
            }
        }
        /// <summary>
        /// Extrae la variable indicada desde el repositorio
        /// </summary>
        /// <param name="id_variable">Id de la variable a extraer</param>
        /// <returns>Objeto variable encontrado</returns>
        public Variable extraerVariable(string id_variable)
        {
            Variable encontrado;
            string path = ruta_carpeta_archivos + id_variable;
            if (File.Exists(path))
            {
                using (Stream stream = File.OpenRead(ruta_carpeta_archivos + id_variable))
                {
                    try
                    {
                        BinaryFormatter deserializer = new BinaryFormatter();
                        encontrado = (Variable)deserializer.Deserialize(stream);
                        stream.Close();
                    }
                    catch (Exception)
                    {
                        stream.Close();
                        return null;
                    }
                }
                return encontrado;
            }
            return null;
        }

        /// <summary>
        /// Método para actualizar una varaible del repositorio de datos
        /// </summary>
        /// <param name="variable">Objeto de tipo varaible a actualizar</param>
        public void actualizarVariable(Variable variable)
        {
            string id_variable = "";
            if (variable != null)
            {
                id_variable = variable.id_variable;
            }
            if (File.Exists(ruta_carpeta_archivos + id_variable))
                using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_variable))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(stream, variable);
                    stream.Close();
                }
        }


        /// <summary>
        /// Método que elimina las variables del repositorio
        /// </summary>
        /// <param name="id_variable">Objeto de tipo variable a eliminar</param>
        public void eliminarVariable(string id_variable)
        {
            if (File.Exists(ruta_carpeta_archivos + id_variable))
                File.Delete(ruta_carpeta_archivos + id_variable);
        }
        #endregion

        #region Hecho


        /// <summary>
        /// Método para ingresar una nueva hecho al repositorio
        /// </summary>
        /// <param name="hecho"></param>
        public void ingresarNuevoHecho(Hecho hecho)
        {
            string id_hecho = "";
            if (hecho != null)
            {
                id_hecho = hecho.id_hecho;
            }

            if (File.Exists(ruta_carpeta_archivos + id_hecho))
                File.Delete(ruta_carpeta_archivos + id_hecho);
            using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_hecho))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, hecho);
                stream.Close();
            }
        }

        /// <summary>
        ///  Extrae el hecho indicada desde el repositorio
        /// </summary>
        /// <param name="id_hecho">id hecho a extraer</param>
        /// <returns>Objeto de tipo hecho encontrado</returns>
        public Hecho extraerHecho(string id_hecho)
        {
            Hecho encontrado;
            string path = ruta_carpeta_archivos + id_hecho;
            if (File.Exists(path))
            {
                using (Stream stream = File.OpenRead(ruta_carpeta_archivos + id_hecho))
                {
                    try
                    {
                        BinaryFormatter deserializer = new BinaryFormatter();
                        encontrado = (Hecho)deserializer.Deserialize(stream);
                        stream.Close();
                    }
                    catch (Exception)
                    {
                        stream.Close();
                        return null;
                    }
                }
                return encontrado;
            }
            return null;
        }

        /// <summary>
        /// Método para actualizar un hecho del repositorio de datos
        /// </summary>
        /// <param name="hecho">Hecho a actualizar</param>
        public void actualizarHecho(Hecho hecho)
        {
            string id_hecho = "";
            if (hecho != null)
            {
                id_hecho = hecho.id_hecho;
            }
            if (File.Exists(ruta_carpeta_archivos + id_hecho))
                using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_hecho))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(stream, hecho);
                    stream.Close();
                }
        }


        /// <summary>
        /// Método que elimina el id_hecho del repositorio
        /// </summary>
        /// <param name="id_hecho">id del hecho a eliminar</param>
        public void eliminarHecho(string id_hecho)
        {
            
            if (File.Exists(ruta_carpeta_archivos + id_hecho))
                File.Delete(ruta_carpeta_archivos + id_hecho);
        }

        #endregion

        #region Regla
        /// <summary>
        /// Método para ingresar nueva regla al repositorio
        /// </summary>
        /// <param name="regla">Objetod e tipo regla a ingresar</param>
        public void ingresarNuevaRegla(Regla regla)
        {
            string id_regla = "";
            if (regla != null)
            {
                id_regla = regla.id_regla;
            }

            if (File.Exists(ruta_carpeta_archivos + id_regla))
                File.Delete(ruta_carpeta_archivos + id_regla);
            using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_regla))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, regla);
                stream.Close();
            }
        }


        /// <summary>
        ///  Extrae el hecho indicada desde el repositorio
        /// </summary>
        /// <param name="id_regla">Id de la regla a extraer</param>
        /// <returns></returns>
        public Regla extraerRegla(string id_regla)
        {
            Regla encontrado;
            string path = ruta_carpeta_archivos + id_regla;
            if (File.Exists(path))
            {
                using (Stream stream = File.OpenRead(ruta_carpeta_archivos + id_regla))
                {
                    try
                    {
                        BinaryFormatter deserializer = new BinaryFormatter();
                        encontrado = (Regla)deserializer.Deserialize(stream);
                        stream.Close();
                    }
                    catch (Exception)
                    {
                        stream.Close();
                        return null;
                    }
                }
                return encontrado;
            }
            return null;
        }

        /// <summary>
        /// Método para actualizar una regla del repositorio de datos
        /// </summary>
        /// <param name="regla"></param>
        public void actualizarRegla(Regla regla)
        {
            string id_regla = "";
            if (regla != null)
            {
                id_regla = regla.id_regla;
            }
            if (File.Exists(ruta_carpeta_archivos + id_regla))
                using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_regla))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(stream, regla);
                    stream.Close();
                }
        }

        /// <summary>
        /// Método que elimina un regla del repositorio
        /// </summary>
        /// <param name="id_regla">id de la regla a eliminar</param>
        public void eliminarRegla(string id_regla)
        {
            if (File.Exists(ruta_carpeta_archivos + id_regla))
                File.Delete(ruta_carpeta_archivos + id_regla);
        }

        #endregion


        #region MetadatosBaseDeConocimiento
        /// <summary>
        /// Metodo para ingresar un archivo de metadatos a la base de conocimiento
        /// </summary>
        /// <param name="metadatos"></param>
        public void ingresarObjetoMetadatos(MetadatosBaseDeConocimiento metadatos)
        {
            
            
            if (File.Exists(ruta_archivo_configuracion))
                File.Delete(ruta_archivo_configuracion);
            using (Stream stream = File.OpenWrite(ruta_archivo_configuracion))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, metadatos);
                stream.Close();
            }
        }


        /// <summary>
        /// Extraer los metadatos de la base de conocimiento
        /// </summary>
        /// <returns>Objeto MetadaDatosBase</returns>
        public MetadatosBaseDeConocimiento extraerMetadatosBaseConocimiento()
        {
            MetadatosBaseDeConocimiento meta = null;
            
            if (File.Exists(ruta_archivo_configuracion))
            {
                using (Stream stream = File.OpenRead(ruta_archivo_configuracion))
                {
                    try
                    {
                        BinaryFormatter deserializer = new BinaryFormatter();
                        meta = (MetadatosBaseDeConocimiento)deserializer.Deserialize(stream);
                        stream.Close();
                    }
                    catch (Exception)
                    {
                        stream.Close();
                        return null;
                    }
                }
                return meta;
            }
            return null;
        }

        /// <summary>
        /// Método para actualizar los metadatos de una base de conocimiento
        /// </summary>
        /// <param name="metadatos">Objeto MetadatosBaseConocimiento a ingresar</param>
        public void actualizarMetadatos(MetadatosBaseDeConocimiento metadatos)
        {
            if (File.Exists(ruta_archivo_configuracion))
                using (Stream stream = File.OpenWrite(ruta_archivo_configuracion))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(stream, metadatos);
                    stream.Close();
                }
        }

        /// <summary>
        /// Método para eliminar el archivo de configuracion de la base de conocimiento,
        /// ALERTA! LA BASE DE CONOCIMIENTO NO PUEDE QUEDAR SIN ARCHIVO DE CONFIGURACIÓN
        /// </summary>
        public void eliminarArchivoDeConfiguracion()
        {
            if (File.Exists(ruta_archivo_configuracion))
                File.Delete(ruta_archivo_configuracion);
        }

        #endregion
    }
}
