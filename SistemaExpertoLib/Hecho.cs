using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib
{
    [Serializable()]
    public class Hecho
    {
        //********************************************************************************************
        //   Atributos
        //********************************************************************************************

        /// <summary>
        /// Tipo de hecho asociado a la variable 
        /// </summary>
        public const int BOOLEANO = 1;
        /// <summary>
        /// Tipo de hecho asociado a la variable
        /// </summary>
        public const int NUMERICO = 2;
        /// <summary>
        /// Tipo de hecho asociado a la variable
        /// </summary>
        public const int LISTA = 3;
        
        /// <summary>
        /// Opciones de condición para tipo de hecho BOOLEANO
        /// {"FALSO","VERDADERO"};
        /// </summary>
        public const string[] OPCIONES_BOOLEANO  = new string[] {"FALSO","VERDADERO"};
        /// <summary>
        /// Opciones de condición para tipo de hecho NUMERICO
        /// ["MENOR","MENOR O IGUAL","IGUAL","MAYOR O IGUAL", "MAYOR"]
        /// </summary>
        public const string[] OPCIONES_NUMERICO  = new string[] {"MENOR","MENOR O IGUAL","IGUAL","MAYOR O IGUAL", "MAYOR"};
        /// <summary>
        /// Opciones de condición para tipo de hecho LISTA
        /// {"ES","NO ES"};
        /// </summary>
        public const string[] OPCIONES_LISTA  = new string[] {"ES","NO ES"};
       
        /// <summary>
        /// string identificador del Hecho
        /// </summary>
        public string id_hecho
        {
            get{return _id_hecho;}
            set{_id_hecho = value;}
        }
        string _id_hecho;

        /// <summary>
        /// identificador de la variable utilizada en el hecho
        /// </summary>
        public string id_variable
        {
            get{return _id_variable;}
            //set{_id_variable = value;}
        }
        string _id_variable;

        /// <summary>
        /// Tipo de variable según constantes BOOL,NUMERICO, LISTA
        /// </summary>
        public int tipo_variable
        {
            get{return _tipo_variable;}
            //set{_tipo_variable = value;}
        }
        int _tipo_variable;

        /// <summary>
        /// nombre de la variable
        /// </summary>
        public string nombre_variable
        {
            get { return _nombre_variable; }
            //set{_tipo_variable = value;}
        }
        string _nombre_variable;


        /// <summary>
        /// identificador de la variable utilizada en el hecho
        /// </summary>
        public string condicion
        {
            get{return _condicion;}
        }
        string _condicion = null;

        /// <summary>
        /// Valor del hecho en la condicion
        /// </summary>
        bool valor_booleano_hecho;
        /// <summary>
        /// Valor del hecho en la condicion
        /// </summary>
        int valor_numerico_hecho;
        /// <summary>
        /// Valor del hecho en la condicion
        /// </summary>
        string valor_lista_hecho;
               

        /// <summary>
        /// Establece si el hecho es preguntable al usuario
        /// </summary>
        bool hecho_preguntable_al_usuario
        {
            get{return _hecho_preguntable_al_usuario;}
            set{_hecho_preguntable_al_usuario = value;}
        }
        bool _hecho_preguntable_al_usuario = false;

        /// <summary>
        /// Indica si el hecho fue evaluado en su condición
        /// </summary>
        bool hecho_evaluado
        {
            get { return _hecho_evaluado; }
            //set { _hecho_evaluado = value; }
        }
        bool _hecho_evaluado = false;

        /// <summary>
        /// Si el hecho esta evaluado, indica TRUE si cumple la condición FALSE en caso contrario
        /// </summary>
        bool estado_hecho
        {
            get { return _estado_hecho; }
            //set { _estado_hecho = value; }
        }
        bool _estado_hecho = false;

        //todo para el comprobador de concordancia, preguntar si el hecho es accesible desde las reglas, al acmbiar variables revizar hechos
        //********************************************************************************************
        //   Métodos
        //********************************************************************************************
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id_hecho">Identficador unico del hecho</param>
        /// <param name="variable_hecho">Variable con que va a trabajar el hecho</param>
        public Hecho(string id_hecho, Variable variable_hecho) 
        {
            this.id_hecho = id_hecho;
            this._id_variable = variable_hecho.id_variable;
            this._tipo_variable = variable_hecho.tipo_variable;
            this._nombre_variable = variable_hecho.nombre_variable;
        }


        /// <summary>
        /// Método para establecer la condición del hecho
        /// </summary>
        /// <param name="opcion_condicion">condicion según los valores de las constantes OPCIONES_BOOLEANO,OPCIONES_NUMERICO,OPCIONES_LISTA</param>
        public void establecerCondicion(string opcion_condicion)
        {
            string[] condiciones = null;
            switch (_tipo_variable)
            {
                case BOOLEANO:
                    condiciones = OPCIONES_BOOLEANO;
                    break;
                case NUMERICO:
                    condiciones = OPCIONES_NUMERICO;
                    break;
                case LISTA:
                    condiciones = OPCIONES_LISTA;
                    break;
            }
            bool flag = false;
            for (int i = 0; i < condiciones.Length && !flag; i++)
            {
                if (condiciones[i].Equals(opcion_condicion))
                    flag = true;
            }
            if (!flag)
            {
                try { }
                catch (Exception e)
                { e = new Exception("Opcion no coincide con el tipo de hecho o no reconocida"); throw; }
            }

        }




        /// <summary>
        /// Metodo para evaluar tipo de hecho con variable booleana
        /// </summary>
        /// <param name="estado_variable">Estado de la variable a evaluar</param>
        /// <returns>TRUE si la condición se cumple, FALSE en caso contrario. Exception si no corresponde al tipo de hecho</returns>
        public bool evaluarHechoBoleano(bool estado_variable)
        {
            if (this.condicion == null)
            {
                try { }
                catch (Exception e)
                { e = new Exception("La condición del hecho no ha sido establecida"); throw; }
            }
            if (tipo_variable != BOOLEANO)
            {
                try { }
                catch (Exception e)
                { e = new Exception("El hecho no es BOOLEANO"); throw; }    
            }
            else
            {
                bool condicion = false;
                if (this.condicion.Equals(OPCIONES_BOOLEANO[1]))
                    condicion = true;
                if (estado_variable == condicion)
                {
                    this._estado_hecho = true;
                }
                else
                {
                    this._estado_hecho = false;
                }
                this._hecho_evaluado = true;
            }
            
            
            return this.estado_hecho;
        }




        /// <summary>
        /// Método para evaluar tipo de hecho con variable numerica
        /// </summary>
        /// <param name="estado_variable">Estado de la variable a evaluar</param>
        /// <returns>TRUE si la condición se cumple, FALSE en caso contrario. Exception si no corresponde al tipo de hecho</returns>
        public bool evaluarHechoNumerico(int estado_variable)
        {
            if (this.condicion == null)
            {
                try { }
                catch (Exception e)
                { e = new Exception("La condición del hecho no ha sido establecida"); throw; }
            }
            if (tipo_variable != NUMERICO)
            {
                try { }
                catch (Exception e)
                { e = new Exception("El hecho no es NUMERICO"); throw; }
            }
            else
            {
                _estado_hecho = false;
                _hecho_evaluado = true;
                switch (_condicion)
                {
                    case "MENOR":
                        if (estado_variable < valor_numerico_hecho)
                            _estado_hecho = true;
                        break;
                    case "MENOR O IGUAL":
                        if (estado_variable <= valor_numerico_hecho)
                            _estado_hecho = true;
                        break;
                    case "IGUAL":
                        if (estado_variable == valor_numerico_hecho)
                            _estado_hecho = true;
                        break;
                    case "MAYOR O IGUAL":
                        if (estado_variable >= valor_numerico_hecho)
                            _estado_hecho = true;
                        break;
                    case "MAYOR":
                        if (estado_variable > valor_numerico_hecho)
                            _estado_hecho = true;
                        break;
                }
            }
            return this.estado_hecho;
        }

        /// <summary>
        /// Método para evaluar un hecho con tipo de variable LISTA
        /// </summary>
        /// <param name="estado_variable">Estado de la variable a evaluar</param>
        /// <returns>TRUE si la condición se cumple, FALSE en caso contrario. Exception si no corresponde al tipo de hecho</returns>
        public bool evaluarHechoNumerico(string estado_variable)
        {
            estado_variable = estado_variable.ToLower();
            if (this.condicion == null)
            {
                try { }
                catch (Exception e)
                { e = new Exception("La condición del hecho no ha sido establecida"); throw; }
            }
            if (tipo_variable != LISTA)
            {
                try { }
                catch (Exception e)
                { e = new Exception("El hecho no es de tipo LISTA"); throw; }
            }
            else
            {
                _estado_hecho = false;
                _hecho_evaluado = true;
                switch (_condicion)
                {
                    case "ES":
                        if (estado_variable.Equals(valor_lista_hecho))
                            _estado_hecho = true;
                        break;
                    case "NO ES":
                        if (!estado_variable.Equals(valor_lista_hecho))
                            _estado_hecho = true;
                        break;
                }
            }
            return this.estado_hecho;
        }




        /// <summary>
        /// Override toString
        /// </summary>
        /// <returns>VARIABLE + CONDICION + VALOR</returns>
        public override string ToString()
        {
            string retorno = "  "+ nombre_variable;
            if (condicion == null)
            {
                retorno += " CONDICIÓN NO ESTABLECIDA";
            }
            else
            {
                retorno += " " + condicion;
                if (tipo_variable == NUMERICO)
                    retorno += " " + valor_numerico_hecho;
                else
                    if (tipo_variable == LISTA)
                        retorno += " " + valor_lista_hecho;
            }
            return retorno;
        }



    }
}
