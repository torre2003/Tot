
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib
{

    public class GestionadorBaseConocimiento
    {
        int cantidad_de_reglas = 0;
        int cantidad_de_hechos = 0;

        int ultima_id_hecho = 0;
        int ultima_id_regla = 0;
        
        public string ruta_carpeta_archivos;
        AccesoDatos manejador_archivos;

        public GestionadorBaseConocimiento()
        {
            manejador_archivos = new AccesoDatos();
            actualizarEstadisticas();
        }


        public GestionadorBaseConocimiento(string ruta_carpeta_archivos)
        {
            manejador_archivos = new AccesoDatos(ruta_carpeta_archivos);
            actualizarEstadisticas();
        }

        private void actualizarEstadisticas()
        {
            string[] lista_de_hechos = manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.HECHO);
            string[] lista_de_reglas = manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.REGLA);
            cantidad_de_hechos = lista_de_hechos.Length;
            cantidad_de_reglas = lista_de_reglas.Length;
            
            for (int i = 0; i < lista_de_hechos.Length; i++)
            {
                try 
	            {	        
                    int numero_hecho = Int32.Parse(lista_de_hechos[i].Split('_')[1]);
                    if (ultima_id_hecho < numero_hecho)
                        ultima_id_hecho = numero_hecho;
	            }
	            catch (Exception){}
            }
            
            for (int i = 0; i < lista_de_reglas.Length; i++)
            {
                try
                {
                    int numero_regla = Int32.Parse(lista_de_reglas[i].Split('_')[1]);
                    if (ultima_id_regla < numero_regla)
                        ultima_id_regla = numero_regla;
                }
                catch (Exception) { }
            }
        }
        

        public string agregarHecho(string nombre_hecho)
        {
            ultima_id_hecho ++;
            string id_hecho = "H_" + ultima_id_hecho;
            Hecho hecho = new Hecho(id_hecho, nombre_hecho);
            manejador_archivos.ingresarNuevoHecho(hecho);
            return id_hecho;
        }

        public Hecho leerHecho(string id_hecho)
        {
            return manejador_archivos.extraerHecho(id_hecho);
        }


        public void eliminarHecho(string id_hecho)
        {
            manejador_archivos.eliminarHecho(id_hecho);
        }

        public string[] listarHechos()
        {
            return manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.HECHO);
        }

        public string[] listarReglas()
        {
            return manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.REGLA);
        }

        public string agregarRegla(string[] antecedentes, string[] consecuentes)
        {
            ultima_id_regla++;
            string id_regla = "R_" + ultima_id_regla;
            Regla regla = new Regla(id_regla);
            for (int i = 0; i < antecedentes.Length; i++)
                regla.agregarHechoAlAntecedente(antecedentes[i]);
            for (int i = 0; i < consecuentes.Length; i++)
                regla.agregarHechoAlConsecuente(consecuentes[i]);
            manejador_archivos.ingresarNuevaRegla(regla);
            return id_regla;
        }

        public Regla leerRegla(string id_regla)
        {
            return manejador_archivos.extraerRegla(id_regla);
        }

        
        public void eliminarRegla(string id_regla)
        {
            manejador_archivos.eliminarRegla(id_regla);
        }

    }
}
