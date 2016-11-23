using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib
{
    [Serializable()]
    public class Variable
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
                _variable_modificada = true;
            }
        }
        bool _valor_booleano_actual;
        /// <summary>
        /// Valor NUMERICO actual en la memoria de trabajo
        /// </summary>
        double valor_numerico_actual
        {
            get
            {
                return _valor_numerico_actual;
            }
            set
            {
                _valor_numerico_actual = value;
                _variable_modificada = true;
            }
        }
        double _valor_numerico_actual;
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
                if (!elementoExistente(value))
                    throw new System.ArgumentException("La cadena no pertenece a la lista de la variable", value);
                _valor_lista_actual = value;
                _variable_modificada = true;
            }
        }
        string _valor_lista_actual;

        /// <summary>
        /// Indica si el valor de la variable ha sido modificado
        /// </summary>
        bool variable_modificada
        {
            get
            {
                return _variable_modificada;
            }
        }
        private bool _variable_modificada;


        /// <summary>
        /// Valor que establece la Variable como Cardinal (solo si la variable es de tipo numerica)
        /// </summary>
        public bool cardinal
        {
            get
            {
                return _cardinal;
            }
            set
            {
                _cardinal = value;
            }
        }
        bool _cardinal = false;
        
        /// <summary>
        /// Si la variable es de tipo numerica, la propiedad especifica si tiene un rango limitado
        /// </summary>
        public bool rango_limitado
        {   
            get
            {
                return _rango_limitado;
            }
        }
        bool _rango_limitado = false;

        /// <summary>
        /// Numero menor que puede tomar la variable (Si la variable es numerica y con rango limitado)
        /// </summary>
        public double rango_limite_inferior
        {
            get
            {
                return _rango_limite_inferior;
            }
        }
        double _rango_limite_inferior;

        /// <summary>
        /// Numero mayor que puede tomar la variable (Si la variable es numerica y con rango limitado)
        /// </summary>
        public double rango_limite_superior
        {
            get
            {
                return _rango_limite_superior;
            }
        }
        double _rango_limite_superior;
        
        /// <summary>
        /// ArrayList con las opciones posibles para la variable
        /// </summary>
        ArrayList lista_de_opciones = new ArrayList();

        /// <summary>
        /// Texto con el cual se consultara la variable del sistema experto
        /// </summary>
        public string texto_consulta_variable
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
        public string ruta_texto_descriptivo
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
        public string ruta_imagen_descriptiva
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
        public bool variable_de_inicio
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

        /// <summary>
        /// Establece si el variable es preguntable al usuario
        /// </summary>
        public bool variable_preguntable_al_usuario
        {
            get { return _variable_preguntable_al_usuario; }
            set { _variable_preguntable_al_usuario = value; }
        }
        bool _variable_preguntable_al_usuario = false;

        /// <summary>
        /// Establece si el variable es objetivo inicial del encadenamiento hacia atrás
        /// </summary>
        public bool variable_objetivo
        {
            get { return _variable_objetivo; }
            set { _variable_objetivo = value; }
        }
        bool _variable_objetivo = false;
        /// <summary>
        /// Atributo que indica si la variable es consistene en la base de conocimiento
        /// </summary>
        public bool chequeo_de_consistencia
        {
            get { return _chequeo_de_consistencia; }
            set { _chequeo_de_consistencia = value; }
        }
        bool _chequeo_de_consistencia = true;

        //********************************************************************************************
        //   Métodos
        //********************************************************************************************

        /// <summary>
        /// Constructor
        /// </summary>
        public Variable()
        {

        }


        /// <summary>
        /// Constructor
        /// </summary>
        public Variable (string id_variable){
            this.id_variable = id_variable;
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
                throw new System.ArgumentException("El tipo de variable no corresponde a LISTA", "");
            }
        }

        /// <summary>
        /// Metodo para eliminar un elemento de la lista de opciones 
        /// </summary>
        /// <param name="elemento">Elemento a eliminar</param>
        public void eliminarElemento(string elemento)
        {
            object aux_eliminacion = null;
            foreach (object item in lista_de_opciones)
            {
                string aux = (string)item;
                if (aux.Equals(elemento))
                    aux_eliminacion = aux;
            }
            if (aux_eliminacion != null)
                lista_de_opciones.Remove(aux_eliminacion);
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
        /// Método que establece un rango a la variable de tipo NUMERICO
        /// </summary>
        /// <param name="limite_inferior">Limite inferior de la variable</param>
        /// <param name="limite_superior">Limite mayor de la variable</param>
        public void limitarRangoVariable(double limite_inferior, double limite_superior)
        {
            if (tipo_variable ==  NUMERICO)
            {
                if (limite_inferior <= limite_superior)
                {
                    _rango_limitado = true;
                    _rango_limite_inferior = limite_inferior;
                    _rango_limite_superior = limite_superior;
                }
                else
                {
                    throw new System.ArgumentException("Limite inferior mayor a limite superior", "");
                }
            }
            else
            {
                throw new System.ArgumentException("El tipo de variable no corresponde a NUMERICO", "");
            }
        }

        /// <summary>
        /// Método que quita el rango establecio para la variable
        /// </summary>
        public void quitarRangosVariables()
        {
            if (tipo_variable == NUMERICO)
            {
                _rango_limitado = false;
            }
            else
            {
                throw new System.ArgumentException("El tipo de variable no corresponde a NUMERICO", "");
            }
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

        /// <summary>
        /// Método que limpia los atributos asociados al proceso de inferencia 
        /// </summary>
        public void limpiarVariableParaInferencia()
        {

            _valor_booleano_actual = false ;
            _valor_numerico_actual = -999999;
            _valor_lista_actual = "";
            _variable_modificada = false;
        }




    }
}
