using SistemaExpertoLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Tot
{
    public class GestionConfiguracionInternaTot
    {
        public string ruta_archivos_configuracion   = "files\\";
        public string archivo_configuracion_log     = "log.conf";
        public bool existe_archivo_configuracion
        {
            get { return File.Exists(ruta_archivos_configuracion + archivo_configuracion_log); }
        }
        /// <summary>
        /// Método para ingresar un nuevo procesador de logeo a la carpeta de configuración
        /// </summary>
        /// <param name="regla">Objetod e tipo regla a ingresar</param>
        public void ingresarProcesadorDeLoggeo(ProcesadorLogInferencia procesador)
        {
            if (File.Exists(ruta_archivos_configuracion + archivo_configuracion_log))
                File.Delete(ruta_archivos_configuracion + archivo_configuracion_log);
            using (Stream stream = File.OpenWrite(ruta_archivos_configuracion + archivo_configuracion_log))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, procesador);
                stream.Close();
            }
        }


        /// <summary>
        ///  Extrae el procesador de loggeo
        /// </summary>
        /// <returns></returns>
        public ProcesadorLogInferencia extraerProcesadorDeLoggeo()
        {
            ProcesadorLogInferencia encontrado;
            string path = ruta_archivos_configuracion + archivo_configuracion_log;
            if (File.Exists(path))
            {
                using (Stream stream = File.OpenRead(path))
                {
                    try
                    {
                        
                        BinaryFormatter deserializer = new BinaryFormatter();
                        encontrado = (ProcesadorLogInferencia)deserializer.Deserialize(stream);
                        stream.Close();
                    }
                    catch (Exception e)
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
        /// Método que elimina un regla del repositorio
        /// </summary>
        public void eliminarProcesadorLoggeo()
        {
            if (File.Exists(ruta_archivos_configuracion + archivo_configuracion_log))
                File.Delete(ruta_archivos_configuracion + archivo_configuracion_log);
        }




    }
}
