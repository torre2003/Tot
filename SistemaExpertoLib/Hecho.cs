﻿using System;
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
        public static string[] OPCIONES_BOOLEANO = new string[] {"FALSO","VERDADERO"};
        /// <summary>
        /// Opciones de condición para tipo de hecho NUMERICO
        /// ["MENOR","MENOR O IGUAL","IGUAL","MAYOR O IGUAL", "MAYOR"]
        /// </summary>
        public static string[] OPCIONES_NUMERICO = new string[] {"MENOR","MENOR O IGUAL","IGUAL","MAYOR O IGUAL", "MAYOR"};
        /// <summary>
        /// Opciones de condición para tipo de hecho LISTA
        /// {"ES","NO ES"};
        /// </summary>
        public static string[] OPCIONES_LISTA = new string[] {"ES","NO ES"};
       
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
        /// Valor booleano del hecho en la condición
        /// </summary>
        public bool valor_booleano
        {
            get { return _valor_booleano_hecho; }
        }

        /// <summary>
        /// Valor Lista del hecho en la condición
        /// </summary>
        public string valor_lista_hecho
        {
            get { return _valor_lista_hecho; }
        }

        /// <summary>
        /// Valor Numerico del hecho en la condición
        /// </summary>
        public double valor_numerico
        {
            get { return _valor_numerico_hecho; }
        }
        
        /// <summary>
        /// Valor del hecho en la condicion
        /// </summary>
        bool _valor_booleano_hecho;
        /// <summary>
        /// Valor del hecho en la condicion
        /// </summary>
        double _valor_numerico_hecho;
        /// <summary>
        /// Valor del hecho en la condicion
        /// </summary>
        string _valor_lista_hecho;
               

        /// <summary>
        /// Obtiene si el hecho es preguntable al usuario
        /// </summary>
        public bool hecho_preguntable_al_usuario
        {
            get{return _hecho_preguntable_al_usuario;}
        
        }
        bool _hecho_preguntable_al_usuario = false;

        /// <summary>
        /// Obtiene si el hecho es obejtivo del encadenamiento hacia atrás
        /// </summary>
        public bool hecho_objetivo
        {
            get { return _hecho_objetivo; }

        }
        bool _hecho_objetivo = false;
        /// <summary>
        /// Indica si el hecho fue evaluado en su condición, por la inferencia 
        /// </summary>
        public bool hecho_evaluado
        {
            get { return _hecho_evaluado; }
            //set { _hecho_evaluado = value; }
        }
        bool _hecho_evaluado = false;

        /// <summary>
        /// Si el hecho esta evaluado, indica TRUE si cumple la condición FALSE en caso contrario
        /// </summary>
        public bool estado_hecho
        {
            get { return _estado_hecho; }
            //set { _estado_hecho = value; }
        }
        bool _estado_hecho = false;

        /// <summary>
        /// Atributo que indica si el hecho es consistente en la base de conocimiento
        /// </summary>
        public bool chequeo_de_consistencia
        {
            get { return _chequeo_de_consistencia;}
            set { _chequeo_de_consistencia = value; }
        }
        bool _chequeo_de_consistencia = true;



        
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
            this._hecho_preguntable_al_usuario = variable_hecho.variable_preguntable_al_usuario;
            this._hecho_objetivo = variable_hecho.variable_objetivo;
        }


        /// <summary>
        /// Método que actualiza los parametros del hecho en caso de que cambios en la variable
        /// </summary>
        /// <param name="variable_hecho">Objeto tipo variable actualizado correspondiente al hecho</param>
        public void actualizarParametrosVariableHecho(Variable variable_hecho)
        {
            if (variable_hecho.id_variable.Equals(_id_variable))
            {
                if (this._tipo_variable == variable_hecho.tipo_variable)
                {
                    this._nombre_variable = variable_hecho.nombre_variable;
                    this._hecho_preguntable_al_usuario = variable_hecho.variable_preguntable_al_usuario;
                    this._hecho_objetivo = variable_hecho.variable_objetivo;
                }
                else
                {
                    string exception ="TIPO Variable hecho :"+ _tipo_variable + " !=  TIPO Variable nueva :" + variable_hecho.tipo_variable;
                    exception = exception.Replace("" + Variable.BOOLEANO," BOOLEANO ");
                    exception = exception.Replace("" + Variable.NUMERICO, " NUMERICO ");
                    exception = exception.Replace("" + Variable.LISTA, " LISTA ");
                    throw new System.ArgumentException("El tipo de variable es distinta a la del hecho", exception);
                }
            }
            else
            {
                throw new System.ArgumentException("La variable no corresponde a la del hecho", "ID Variable hecho :" + id_variable + " !=  ID variable nueva :" + variable_hecho.id_variable);
            }
        }


        /// <summary>
        /// Establece la condición para el tipo de hecho BOOLEANO
        /// </summary>
        /// <param name="opcion_condicion">Opcion a cotejar según CONSTANTE OPCIONES_BOOLEANO {VERDADERO , FALSO}</param>
        public void establecerCondicion(string opcion_condicion)
        {
            if (comprobarCondicion(opcion_condicion))
            {
                _condicion = opcion_condicion;
                if (opcion_condicion.Equals(OPCIONES_BOOLEANO[0]))
                    _valor_booleano_hecho = false;
                else
                    _valor_booleano_hecho = true;
            }
            else
            {
                throw new System.ArgumentException("Opcion no coincide con el tipo de hecho o no reconocida", opcion_condicion);
            }
        }

        /// <summary>
        /// Establece la condición para el tipo de hecho NUMERICO
        /// </summary>
        /// <param name="opcion_condicion">Opcion de de la condición según constante OPCIONES_NUMERICO {"MENOR","MENOR O IGUAL","IGUAL","MAYOR O IGUAL", "MAYOR"}</param>
        /// <param name="valor">Valor a comparar según corresponda la condicion impuesta</param>
        public void establecerCondicion(string opcion_condicion, double valor)
        {
            if (comprobarCondicion(opcion_condicion))
            {
                _condicion = opcion_condicion;
                _valor_numerico_hecho = valor;
            }
            else
            {
                throw new System.ArgumentException("Opcion no coincide con el tipo de hecho o no reconocida", opcion_condicion);
            }
        }

        /// <summary>
        /// Establece la condición para el tipo de hecho LISTA
        /// </summary>
        /// <param name="opcion_condicion">Opción de la condición según constante OPCIONES_LISTA {"ES","NO ES"}</param>
        /// <param name="valor_en_variable">Valor a comparar según corresponda la condicion impuesta</param>
        public void establecerCondicion(string opcion_condicion, string valor_en_variable)
        {
            if (comprobarCondicion(opcion_condicion))
            {
                _condicion = opcion_condicion;
                _valor_lista_hecho = valor_en_variable;
            }
            else
            {
                throw new System.ArgumentException("Opcion no coincide con el tipo de hecho o no reconocida", opcion_condicion);
            }
        }


        /// <summary>
        /// Método que comprueba la condicion según el tipo de variable del objeto
        /// </summary>
        /// <param name="opcion_condicion">condicion según los valores de las constantes OPCIONES_BOOLEANO,OPCIONES_NUMERICO,OPCIONES_LISTA</param>
        /// <returns>TRUE si el hecho concuerda con el tipo de variable</returns>
        public bool comprobarCondicion(string opcion_condicion)
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
            
            return flag;
        }


        /// <summary>
        /// Método para evaluar el estado de un hecho
        /// </summary>
        /// <param name="estado_variable">estado de la variable a comparar en el hecho</param>
        /// <returns>TRUE si la condición se cumple, FALSE en caso contrario. Exception si no corresponde al tipo de hecho</returns>
        public bool evaluarHecho(object estado_variable)
        {
            string tipo_valor = estado_variable.GetType() + "";
            if (tipo_valor.Equals("System.Boolean"))
            {
                return evaluarHechoBooleano((bool)estado_variable);
            }
            else
            if (tipo_valor.Equals("System.String"))
            {
                return evaluarHechoLista((string)estado_variable);
            }
            else
            if (tipo_valor.Equals("System.Double") || tipo_valor.Equals("System.Decimal"))
            {
                return evaluarHechoNumerico((double)estado_variable);
            }
            throw new System.ArgumentException("El tipo de estado variable no corresponde", "evaluarHecho");
        }

        /// <summary>
        /// Metodo para evaluar tipo de hecho con variable booleana
        /// </summary>
        /// <param name="estado_variable">Estado de la variable a evaluar</param>
        /// <returns>TRUE si la condición se cumple, FALSE en caso contrario. Exception si no corresponde al tipo de hecho</returns>
        public bool evaluarHechoBooleano(bool estado_variable)
        {
            if (this.condicion == null)
            {
                throw new System.ArgumentException("La condición del hecho no ha sido establecida", "");
            }
            if (tipo_variable != BOOLEANO)
            {
                throw new System.ArgumentException("El hecho no es BOOLEANO", "");
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
        public bool evaluarHechoNumerico(double estado_variable)
        {
            if (this.condicion == null)
            {
                throw new System.ArgumentException("La condición del hecho no ha sido establecida", "");
            }
            if (tipo_variable != NUMERICO)
            {
                throw new System.ArgumentException("El hecho no es NUMERICO", "");
            }
            else
            {
                _estado_hecho = false;
                _hecho_evaluado = true;
                switch (_condicion)
                {
                    case "MENOR":
                        if (estado_variable < _valor_numerico_hecho)
                            _estado_hecho = true;
                        break;
                    case "MENOR O IGUAL":
                        if (estado_variable <= _valor_numerico_hecho)
                            _estado_hecho = true;
                        break;
                    case "IGUAL":
                        if (estado_variable == _valor_numerico_hecho)
                            _estado_hecho = true;
                        break;
                    case "MAYOR O IGUAL":
                        if (estado_variable >= _valor_numerico_hecho)
                            _estado_hecho = true;
                        break;
                    case "MAYOR":
                        if (estado_variable > _valor_numerico_hecho)
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
        public bool evaluarHechoLista(string estado_variable)
        {
            estado_variable = estado_variable.ToLower();
            if (this.condicion == null)
            {
                throw new System.ArgumentException("La condición del hecho no ha sido establecida", "");
            }
            if (tipo_variable != LISTA)
            {
                throw new System.ArgumentException("El hecho no es de tipo LISTA", "");
            }
            else
            {
                _estado_hecho = false;
                _hecho_evaluado = true;
                switch (_condicion)
                {
                    case "ES":
                        if (estado_variable.Equals(_valor_lista_hecho))
                            _estado_hecho = true;
                        break;
                    case "NO ES":
                        if (!estado_variable.Equals(_valor_lista_hecho))
                            _estado_hecho = true;
                        break;
                }
            }
            return this.estado_hecho;
        }

        /// <summary>
        /// Método que limpiar los atributos del hecho utilizados en la influencia
        /// </summary>
        public void limpiarEstadoHechoParaInferencia ()
        {
            _estado_hecho = false;
            _hecho_evaluado = false;

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
                    retorno += " " + _valor_numerico_hecho;
                else
                if (tipo_variable == LISTA)
                    retorno += " " + _valor_lista_hecho;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo Equals modificado para comparar en base a Variable, condición y valor en la condición
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            string tipo_obj = ""+obj.GetType();
            if (!tipo_obj.Equals("SistemaExpertoLib.Hecho"))
                return false;
            Hecho hecho = (Hecho)obj;
            if (!this.id_variable.Equals(hecho.id_variable))
                return false;
            if (this.tipo_variable != hecho.tipo_variable)
                return false;
            if (!this.condicion.Equals(hecho.condicion))
                return false;
            switch (this.tipo_variable)
            {
                case Variable.LISTA:
                    if (!this._valor_lista_hecho.Equals(hecho.valor_lista_hecho))
                        return false;
                    break;
                case Variable.NUMERICO:
                    if (this.valor_numerico != hecho.valor_numerico)
                        return false;
                    break;
            }
            return true;    
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
