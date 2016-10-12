using PruebasSistemaExperto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib
{
    class AccesoDatos
    {
        public const int HECHO = 1;
        public const int REGLA = 2;

        string ruta_carpeta_archivos = "base conocimiento\\";


        public AccesoDatos()
        {
            inicializarCarpetaArchivos();
        }
            

        public AccesoDatos(string ruta_carpeta_archivos)
        {
            this.ruta_carpeta_archivos = ruta_carpeta_archivos;
            inicializarCarpetaArchivos();
        }


        public void inicializarCarpetaArchivos()
        {
            if (!System.IO.Directory.Exists(ruta_carpeta_archivos))
                System.IO.Directory.CreateDirectory(ruta_carpeta_archivos);
        }


        //*************************************************************************
        // Ingresar nuevo Hecho
        //*************************************************************************
        
        /// <summary>
        /// 
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


        //*************************************************************************
        // Extraer Hecho
        //*************************************************************************

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

        //*************************************************************************
        // Actualizar Hecho
        //*************************************************************************

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


        //*************************************************************************
        // Eliminiar Hecho
        //*************************************************************************

        public void eliminarHecho(string id_hecho)
        {
            
            if (File.Exists(ruta_carpeta_archivos + id_hecho))
                File.Delete(ruta_carpeta_archivos + id_hecho);
        }




        //*************************************************************************
        // Ingresar nueva regla
        //*************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="regla"></param>
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


        //*************************************************************************
        // Extraer regla
        //*************************************************************************

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

        //*************************************************************************
        // Actualizar Regla
        //*************************************************************************

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

        //*************************************************************************
        // Eliminiar Regla
        //*************************************************************************

        public void eliminarRegla(string id_regla)
        {
            if (File.Exists(ruta_carpeta_archivos + id_regla))
                File.Delete(ruta_carpeta_archivos + id_regla);
        }

        //*************************************************************************
        // listar Archivos en directorio
        //*************************************************************************
        public string[] listarArchivosEnDirectorio(int tipo_de_archivos)
        {

            string tipo = "";
            switch (tipo_de_archivos)
            {
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
    }
}
