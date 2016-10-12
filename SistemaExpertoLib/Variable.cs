using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib
{
    class Variable
    {

        //********************************************************************************************
        //   Atributos
        //********************************************************************************************
        /// <summary>
        /// Tipo de variable BOOLEANO
        /// </summary>
        public const int BOOLEANO = 1;
        /// <summary>
        /// Tipo de variable NUMERICO
        /// </summary>
        public const int NUMERICO = 2;
        /// <summary>
        /// Tipo de variable LISTA
        /// </summary>
        public const int LISTA = 3;

        /// <summary>
        /// Id de la variable
        /// </summary>
        public string id_variable
        {
            get
            {
                return _id_variable;
            }
            set
            {
                _id_variable = value;
            }
        }
        string _id_variable;

        /// <summary>
        /// Nombre de la variable
        /// </summary>
        public string nombre_variable
        {
            get
            {
                return _nombre_variable;
            }
            set
            {
                _nombre_variable = value;
            }
        }
        string _nombre_variable;

        /// <summary>
        /// Tipo de variable según constantes BOOL,NUMERICO, LISTA
        /// </summary>
        public int tipo_variable
        {
            get
            {
                return _tipo_variable;
            }
            set
            {
                _tipo_variable = value;
            }
        }
        int _tipo_variable;

        /// <summary>
        /// Valor BOOLEANO actual en la memoria de trabajo
        /// </summary>
        bool valor_booleano_actual
        {
            get
            {
                return _valor_booleano_actual;
            }
            set
            {
                _valor_booleano_actual = value;
            }
        }
        bool _valor_booleano_actual;
        /// <summary>
        /// Valor NUMERICO actual en la memoria de trabajo
        /// </summary>
        int valor_numerico_actual
        {
            get
            {
                return _valor_numerico_actual;
            }
            set
            {
                _valor_numerico_actual = value;
            }
        }
        int _valor_numerico_actual;
        /// <summary>
        /// Valor LISTA actual en la memoria de trabajo
        /// </summary>
        string valor_lista_actual
        {
            get
            {
                return _valor_lista_actual;
            }
            set
            {
                _valor_lista_actual = value;
            }
        }
        string _valor_lista_actual;

        /// <summary>
        /// ArrayList con las opciones posibles para la variable
        /// </summary>
        ArrayList lista_de_opciones = new ArrayList();

        /// <summary>
        /// Texto con el cual se consultara la variable del sistema experto
        /// </summary>
        string texto_consulta_variable
        {
            get
            {
                return _texto_consulta_variable;
            }
            set
            {
                _texto_consulta_variable = value;
            }
        }
        string _texto_consulta_variable = "";
        
        /// <summary>
        /// Ruta Texto descriptivo de la variable
        /// </summary>
        string ruta_texto_descriptivo
        {
            get
            {
                return _ruta_texto_descriptivo;
            }
            set
            {
                _ruta_texto_descriptivo = value;
            }
        }
        string _ruta_texto_descriptivo = "";

        /// <summary>
        /// Ruta Imagen descriptiva de la variable
        /// </summary>
        string ruta_imagen_descriptiva
        {
            get
            {
                return _ruta_imagen_descriptiva;
            }
            set
            {
                _ruta_imagen_descriptiva = value;
            }
        }
        string _ruta_imagen_descriptiva = "";

        /// <summary>
        /// Establece si la variable es solicitado al inicio de la inferencia 
        /// </summary>
        bool variable_de_inicio
        {
            get
            {
                return _variable_de_inicio;
            }
            set
            {
                _variable_de_inicio = value;
            }
        }
        bool _variable_de_inicio = false;

        //********************************************************************************************
        //   Métodos
        //********************************************************************************************


        /// <summary>
        /// Constructor
        /// </summary>
        public Variable (){

        }

        /// <summary>
        /// Metodo para agregar elementos a las opciones de la variable
        /// </summary>
        /// <param name="elemento">Texto a agregar</param>
        public void agregarElementoALista(string elemento)
        {
            elemento = elemento.ToLower();
            if (tipo_variable == LISTA)
            {
                if (!elementoExistente(elemento))
                    lista_de_opciones.Add(elemento);
            }
            else
            {
                try{}
                catch (Exception e)
                {e = new Exception("El tipo de variable no corresponde a LISTA");throw;}
            }
        }

        /// <summary>
        /// Metodo para eliminar un elemento de la lista de opciones 
        /// </summary>
        /// <param name="elemento">Elemento a eliminar</param>
        public void eliminarElemento(string elemento)
        {
            foreach (string item in lista_de_opciones)
            {
                if (item.Equals(elemento))
                    lista_de_opciones.Remove(item);
            }
        }


        /// <summary>
        /// Metodo que comprueba la existencia de un elemento en la lista de opciones
        /// </summary>
        /// <param name="elemento">elemento a chequear</param>
        /// <returns>TRUE en caso de existir el elemento| FALSE en caso contrario</returns>
        public bool elementoExistente (string elemento)
        {
            elemento = elemento.ToLower();
            bool flag = false;
            foreach (string item in lista_de_opciones)
            {
                if (item.Equals(elemento))
                    flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Opciones posible de la variable
        /// </summary>
        /// <returns>Arreglo con las opciones posibles de la variable</returns>
        public string[] listarOpciones()
        {
            string[] opciones = new string[lista_de_opciones.Count];
            int i = 0;
            foreach (string item in lista_de_opciones)
            {
                opciones[i] = item;
                i++;
            }
            return opciones;
        }

    }
}
