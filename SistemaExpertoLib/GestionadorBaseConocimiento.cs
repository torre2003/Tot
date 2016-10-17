﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib
{

    public class GestionadorBaseConocimiento
    {
        //*************************************************************************
        // Atributos
        //*************************************************************************
        public const int VARIABLE = 1;
        public const int HECHO = 2;
        public const int REGLA = 3;
        
        int cantidad_de_variables = 0; 
        int cantidad_de_hechos = 0;
        int cantidad_de_reglas = 0;

        int ultima_id_variables = 0;
        int ultima_id_hecho = 0;
        int ultima_id_regla = 0;
        
        public string ruta_carpeta_archivos;
        AccesoDatos manejador_archivos;
        

        //*************************************************************************
        // Métodos
        //*************************************************************************
        /// <summary>
        /// Constructor
        /// </summary>
        public GestionadorBaseConocimiento()
        {
            manejador_archivos = new AccesoDatos();
            actualizarEstadisticas();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ruta_carpeta_archivos">Ruta del repositorio de la base de conocimiento</param>
        public GestionadorBaseConocimiento(string ruta_carpeta_archivos)
        {
            manejador_archivos = new AccesoDatos(ruta_carpeta_archivos);
            actualizarEstadisticas();
        }

        /// <summary>
        /// Método que actualiza las varaibles internas del objeto
        /// </summary>
        private void actualizarEstadisticas()
        {
            string[] lista_de_variables     = manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.VARIABLE);
            string[] lista_de_hechos        = manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.HECHO);
            string[] lista_de_reglas        = manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.REGLA);

            cantidad_de_variables = lista_de_variables.Length;
            cantidad_de_hechos = lista_de_hechos.Length;
            cantidad_de_reglas = lista_de_reglas.Length;


            for (int i = 0; i < lista_de_variables.Length; i++)
            {
                try
                {
                    int numero_variable = Int32.Parse(lista_de_variables[i].Split('_')[1]);
                    if (ultima_id_variables < numero_variable)
                        ultima_id_variables = numero_variable;
                }
                catch (Exception) { }
            }
            
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

        #region VARIABLE


        /// <summary>
        /// Método para leer una Variable de la base de conocimiento
        /// </summary>
        /// <param name="id_variable">ID de la variable a leer</param>
        /// <returns>Objeto con la variable encontrada, NULL si no encuentra la variable</returns>
        public Variable leerVariable(string id_variable)
        {
            return manejador_archivos.extraerVariable(id_variable);
        }


        /// <summary>
        /// Método para agregar una nueva variable a la base de conocimiento
        /// </summary>
        /// <param name="nombre_variable">Nombre de la variable a ingresar</param>
        /// <param name="tipo_de_variable">Tipo de la variable a ingresar según constantes BOOLEANO,NUMERICO,LISTA</param>
        /// <param name="lista_de_opciones">En caso de ser de tipo LISTA, opciones a guardar en la variable</param>
        /// <returns>Id de la variable si se agrego correctamente la variable, NULL si el nombre ya existe</returns>
        public string agregarNuevaVariable(string nombre_variable, int tipo_de_variable, string[] lista_de_opciones = null)
        {
            nombre_variable = nombre_variable.ToLower();
            if (tipo_de_variable == Variable.LISTA)
                if (lista_de_opciones == null || lista_de_opciones.Length == 0)
                    throw new System.ArgumentException("Lista de opciones vacia o NULA", nombre_variable);
            if (!(tipo_de_variable == Variable.BOOLEANO || tipo_de_variable == Variable.NUMERICO || tipo_de_variable == Variable.LISTA))
                throw new System.ArgumentException("Tipo de variable invalida", nombre_variable);
            if (comprobarNombreVariable(nombre_variable))
                return null;
            
            ultima_id_variables++;
            string id_nueva_variable = "V_" + ultima_id_variables;
            Variable variable= new Variable(id_nueva_variable);
            variable.tipo_variable = tipo_de_variable;
            if (tipo_de_variable == Variable.LISTA)
                for (int i = 0; i < lista_de_opciones.Length; i++)
                    variable.agregarElementoALista(lista_de_opciones[i]);
            manejador_archivos.ingresarNuevaVariable(variable);
            return id_nueva_variable;
        }

        /// <summary>
        /// Método que comprueba en todoas las variables de la base de conocimiento si el nombre existe
        /// </summary>
        /// <param name="nombre_variable">Nombre a comprobar</param>
        /// <returns></returns>
        public bool comprobarNombreVariable(string nombre_variable)
        {
            string[] lista_de_variable = manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.VARIABLE);
            bool flag = false;
            for (int i = 0; i < lista_de_variable.Length  && !flag ; i++)
            {
                Variable variable = manejador_archivos.extraerVariable(lista_de_variable[i]);
                if (nombre_variable.Equals(variable.nombre_variable))
                    flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Método para modificar los metadatos de un Objeto Variable
        /// </summary>
        /// <param name="id_variable">identificador de la variable</param>
        /// <param name="texto_consulta">Texto con el cual se va a mostrar la variable</param>
        /// <param name="ruta_texto_descriptivo">ruta del archivo con la descripcion de la variable</param>
        /// <param name="ruta_imagen_descriptiva">ruta de la imagen descriptiva de la variable</param>
        /// <returns></returns>
        public bool modificarMetadatosVariable(string id_variable, string texto_consulta = null, string ruta_texto_descriptivo = null,string ruta_imagen_descriptiva = null)
        {
            Variable variable = manejador_archivos.extraerVariable(id_variable);
            if (variable == null)
                return false;
            if (texto_consulta != null)
            variable.texto_consulta_variable = texto_consulta;
            if (ruta_imagen_descriptiva != null)
                variable.ruta_texto_descriptivo = ruta_texto_descriptivo;
            if (ruta_imagen_descriptiva != null)
                variable.ruta_imagen_descriptiva = ruta_imagen_descriptiva;
            manejador_archivos.actualizarVariable(variable);
            return true;
        }


        /// <summary>
        /// Método para eliminar una varaible de la base de conocimiento,
        /// </summary>
        /// <param name="id_variable">ID de la variable a eliminar</param>
        public void eliminarVariable(string id_variable)
        {
            manejador_archivos.eliminarVariable(id_variable);
            //Todas los hecho y reglas afectadas deben ser maracadas 
            desmarcarChequeoDeConsistenciaEnHechosYReglas(id_variable, true);
        }

        /// <summary>
        /// Método para agregar un nuevo elemento a lista de una variable TIPO LISTA
        /// </summary>
        /// <param name="id_variable">ID de la varaible a modificar</param>
        /// <param name="elemento_variable">elemento a agregar</param>
        public void agregarElementoListaVariable(string id_variable, string elemento_variable)
        {
            Variable variable = manejador_archivos.extraerVariable(id_variable);
            if (variable.tipo_variable != Variable.LISTA)
            {
                throw new System.ArgumentException("La variable no es de tipo LISTA", id_variable);  
            }
            variable.agregarElementoALista(elemento_variable);
            manejador_archivos.actualizarVariable(variable);
        }

        /// <summary>
        /// Método para eliminar un elemento de la lista de una Variable TIPO LISTA
        /// </summary>
        /// <param name="id_variable">ID de la varaible a modifcar</param>
        /// <param name="elemento_variable">Elemento a eliminar de la variable</param>
        public void eliminarElementoListaVariable(string id_variable, string elemento_variable)
        {
            Variable variable = manejador_archivos.extraerVariable(id_variable);
            if (variable.tipo_variable != Variable.LISTA)
            {
                throw new System.ArgumentException("La variable no es de tipo LISTA", id_variable);
            }
            desmarcarChequeoDeConsistenciaEnHechosYReglas(id_variable,false,elemento_variable);
            variable.eliminarElemento(elemento_variable);
            manejador_archivos.actualizarVariable(variable);
        }


        /// <summary>
        /// Método que busca los hechos y reglas en que influye la variable y cambia su estado de chequeo
        /// </summary>
        /// <param name="id_variable">ID de la variable a buscar</param>
        /// <param name="eliminar_hecho">Indica si los hechos encontrados deben ser eliminados en el proceso</param>
        public void desmarcarChequeoDeConsistenciaEnHechosYReglas(string id_variable,bool eliminar_hecho = false, string valor_lista_especifico = null)
        {
            //Todas los hecho y reglas afectadas deben ser maracadas 
            string[] hechos_que_contienen_la_variable = listarHechosConVariable(id_variable,valor_lista_especifico);
            for (int i = 0; i < hechos_que_contienen_la_variable.Length; i++)
            {
                if (eliminar_hecho)
                    manejador_archivos.eliminarHecho(hechos_que_contienen_la_variable[i]);
                else
                {
                    Hecho hecho = manejador_archivos.extraerHecho(hechos_que_contienen_la_variable[i]);
                    hecho.chequeo_de_consistencia = false;
                    manejador_archivos.actualizarHecho(hecho);
                }
                string[] reglas_que_contienen_al_hecho = listarReglasConHecho(hechos_que_contienen_la_variable[i]);
                for (int j = 0; j < reglas_que_contienen_al_hecho.Length; j++)
                {
                    Regla regla = manejador_archivos.extraerRegla(reglas_que_contienen_al_hecho[j]);
                    regla.chequeo_de_consistencia = false;
                    if (eliminar_hecho)
                    {
                        if (regla.consultarConsecuente(hechos_que_contienen_la_variable[i]))
                            regla.eliminarConsecuente();
                        else
                            regla.eliminarAntecedente(hechos_que_contienen_la_variable[i]);
                    }
                    manejador_archivos.actualizarRegla(regla);
                }
            }
        }

        #endregion
        #region HECHO

        /// <summary>
        /// Método para leer un hecho de la base de conocimiento
        /// </summary>
        /// <param name="id_hecho">Id del hecho a extraer</param>
        /// <returns>Objeto Hecho encontrado, NULL si no encuentra en la base de conocimientop</returns>
        public Hecho leerHecho(string id_hecho)
        {
            return manejador_archivos.extraerHecho(id_hecho);
        }

        /// <summary>
        /// Agrega un nuevo hecho de tipo BOLEANO a la base de conocimiento
        /// </summary>
        /// <param name="id_variable">Id de la variable a ingresar en el hecho</param>
        /// <param name="condicion">Opcion a cotejar según CONSTANTE OPCIONES_BOOLEANO {VERDADERO , FALSO}</param>
        /// <returns>Id del hecho creado</returns>
        public string agregarNuevoHecho(string id_variable,string condicion)
        {
            ultima_id_hecho++;
            string id_nuevo_hecho = "H_" + ultima_id_hecho;
            Variable variable = manejador_archivos.extraerVariable(id_variable);
            Hecho nuevo_hecho = new Hecho(""+ultima_id_hecho, variable);
            nuevo_hecho.establecerCondicion(condicion);
            manejador_archivos.ingresarNuevoHecho(nuevo_hecho);
            return id_nuevo_hecho;
        }


        /// <summary>
        /// Agrega un nuevo hecho de tipo NUMERICO a la base de conocimiento
        /// </summary>
        /// <param name="id_variable">Id de la variable a ingresar en el hecho</param>
        /// <param name="condicion">Opcion de de la condición según constante OPCIONES_NUMERICO {"MENOR","MENOR O IGUAL","IGUAL","MAYOR O IGUAL", "MAYOR"}</param>
        /// <param name="valor">Valor a comparar según corresponda la condicion impuesta</param>
        public void agregarNuevoHecho(string id_variable, string condicion, int valor)
        {
            ultima_id_hecho++;
            string id_nuevo_hecho = "H_" + ultima_id_hecho;
            Variable variable = manejador_archivos.extraerVariable(id_variable);
            Hecho nuevo_hecho = new Hecho("" + ultima_id_hecho, variable);
            nuevo_hecho.establecerCondicion(condicion, valor);
            manejador_archivos.ingresarNuevoHecho(nuevo_hecho);
        }

        /// <summary>
        /// Agrega un nuevo hecho de tipo LISTA a la base de conocimiento 
        /// </summary>
        /// <param name="id_variable">Id de la variable a ingresar en el hecho</param>
        /// <param name="condicion">Opción de la condición según constante OPCIONES_LISTA {"ES","NO ES"}</param>
        /// <param name="valor_lista_variable">Valor a comparar según corresponda la condicion impuesta</param>
        public void agregarNuevoHecho(string id_variable, string condicion, string valor_lista_variable)
        {
            ultima_id_hecho++;
            string id_nuevo_hecho = "H_" + ultima_id_hecho;
            Variable variable = manejador_archivos.extraerVariable(id_variable);
            Hecho nuevo_hecho = new Hecho("" + ultima_id_hecho, variable);
            nuevo_hecho.establecerCondicion(condicion,valor_lista_variable);
            manejador_archivos.ingresarNuevoHecho(nuevo_hecho);
        }

        /// <summary>
        /// Método que elimina un hecho especifico de una regla
        /// </summary>
        /// <param name="id_hecho">Id del hecho a eliminar de la regla</param>
        /// <param name="id_regla">Id de la regla a modificar</param>
        public void eliminarHechoDeRegla(string id_hecho, string id_regla)
        {
            Regla regla = manejador_archivos.extraerRegla(id_regla);
            if (regla == null)
                throw new System.ArgumentException("Regla no encontrada en la base de hecho", id_regla);
            regla.eliminarAntecedente(id_hecho);
            manejador_archivos.actualizarRegla(regla);
        }

        #endregion


        #region REGLA

       /// <summary>
        /// Método que agrega una nueva regla vacia a la base de conosimiento
       /// </summary>
       /// <returns>Id de la regla creada</returns>
        public string agregarNuevaRegla()
        {
            ultima_id_regla++;
            string id_nueva_regla = "R_"+ultima_id_regla;
            Regla regla = new Regla(id_nueva_regla);
            manejador_archivos.ingresarNuevaRegla(regla);
            return id_nueva_regla;
        }

        /// <summary>
        /// Método para eliminar una regla de la base de conocimiento
        /// </summary>
        /// <param name="id_regla">Id de la regla a eliminar</param>
        public void eliminarRegla(string id_regla)
        {
            manejador_archivos.eliminarRegla(id_regla);
        }

        /// <summary>
        /// Método que ingresa un nuevo hecho al antecedente de la regla
        /// </summary>
        /// <param name="id_regla">Id de la regla a modificar</param>
        /// <param name="id_hecho">Id del hecho a ingresar</param>
        public void agregarHechoAlAntecedenteDeRegla(string id_regla, string id_hecho)
        {
            Regla regla = manejador_archivos.extraerRegla(id_regla);
            Hecho hecho = manejador_archivos.extraerHecho(id_hecho);
            regla.agregarHechoAlAntecedente(hecho);
            manejador_archivos.actualizarRegla(regla);
        }

        /// <summary>
        /// Método que ingresa un nuevo hecho al consecuente de la regla
        /// </summary>
        /// <param name="id_regla">Id de la regla a modificar</param>
        /// <param name="id_hecho">Id del hecho a ingresar</param>
        public void agregarHechoAlConsecuente(string id_regla, string id_hecho)
        {
            Regla regla = manejador_archivos.extraerRegla(id_regla);
            Hecho hecho = manejador_archivos.extraerHecho(id_hecho);
            regla.agregarHechoAlConsecuente(hecho);
            manejador_archivos.actualizarRegla(regla);
        }


        /// <summary>
        /// Método para eliminar un hecho del antecedente de una regla
        /// </summary>
        /// <param name="id_regla">Id de la regla a modificar</param>
        /// <param name="id_hecho">Id del hecho a eliminar de la regla</param>
        public void eliminarHechoDeAntecedenteDeRegla(string id_regla, string id_hecho)
        {
            Regla regla = manejador_archivos.extraerRegla(id_regla);
            regla.eliminarAntecedente(id_hecho);
            manejador_archivos.actualizarRegla(regla);
        }

        /// <summary>
        /// Método para eliminar el consecuente de una regla
        /// </summary>
        /// <param name="id_regla">Id de la regla a modificar</param>
        public void eliminarHechoDeConsecuenteDeRegla(string id_regla)
        {
            Regla regla = manejador_archivos.extraerRegla(id_regla);
            regla.eliminarConsecuente();
            manejador_archivos.actualizarRegla(regla);
        }
        
        
        #endregion


        /// <summary>
        /// Método que lista todos los hechos que contegan la variable
        /// </summary>
        /// <param name="id_variable">Id de la varaible a buscar</param>
        /// <param name="valor_lista_especifico">Si la variable es de tipo lista, especifica el valor de la variable en el momento</param>
        /// <returns>lista de ID de los hechos que contienen la variable especificada</returns>
        public string[] listarHechosConVariable(string id_variable, string valor_lista_especifico = null)
        {
            string[] lista_de_hechos = manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.HECHO);
            ArrayList hechos_encontrados = new ArrayList();
            for (int i = 0; i < lista_de_hechos.Length; i++)
            {
                Hecho hecho = manejador_archivos.extraerHecho(lista_de_hechos[i]);
                if (hecho.id_variable.Equals(id_variable))
                {
                    if(valor_lista_especifico != null && hecho.tipo_variable == Hecho.LISTA)
                    {
                       if(hecho.valor_lista.Equals(valor_lista_especifico))
                           hechos_encontrados.Add(lista_de_hechos[i]);
                    }
                    else
                    {
                        hechos_encontrados.Add(lista_de_hechos[i]);
                    }
                    
                }
                
            }
            if (hechos_encontrados.Count == 0)
                return null;
            return (string[])hechos_encontrados.ToArray(typeof(string));
        }

        /// <summary>
        /// Método que devuelve todas las reglas que contienen el hecho
        /// </summary>
        /// <param name="id_hecho">Id del hecho a buscar</param>
        /// <returns>Arreglo con las Id de las reglas que contienen el hecho especificado</returns>
        public string[] listarReglasConHecho(string id_hecho)
        {
            string[] lista_de_reglas = manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.REGLA);
            ArrayList reglas_encontradas = new ArrayList();
            for (int i = 0; i < lista_de_reglas.Length; i++)
            {
                Regla regla = manejador_archivos.extraerRegla(lista_de_reglas[i]);
                if (regla.consultarAntecendente(id_hecho) || regla.consultarConsecuente(id_hecho))
                    reglas_encontradas.Add(lista_de_reglas[i]);
            }
            if (reglas_encontradas.Count == 0)
                return null;
            return (string[])reglas_encontradas.ToArray(typeof(string));
        }






        /*
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
        */
    }
}
//todo forma de evaluar variable de tipo falsas