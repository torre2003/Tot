using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SistemaExpertoLib.MotorDeInferencia
{
    public class EncadenamientoHaciaAtras
    {
        //********************************************************************************************************
        //    Estructuras
        //********************************************************************************************************
        struct InfoRegla :IComparer<InfoRegla>
        {
            public string id_regla;
            public bool validada;
            public int tiempo_regla;
            public int numero_de_antecedentes;
            public int antecedentes_preguntables_al_usuario;
            public int antecedentes_preguntables_al_usuario_conocidos;
            public int antecedentes_inferidos;
            public int antecedentes_inferidos_conocidos;
            public int puntaje_regla
            {
                get
                {
                    int puntaje = numero_de_antecedentes;
                    puntaje -= antecedentes_preguntables_al_usuario_conocidos;
                    puntaje -= antecedentes_inferidos_conocidos;
                    return puntaje;
                }
            }



            public int Compare(InfoRegla x, InfoRegla y)
            {
                InfoRegla a = x;
                InfoRegla b = y;

                //1°Privilegio a las variables con menor puntaje
                if (a.puntaje_regla < b.puntaje_regla)
                    return -1;
                if (a.puntaje_regla > b.puntaje_regla)
                    return 1;

                //2° Privilegio a las variables preguntadas por el usuario
                if (a.antecedentes_preguntables_al_usuario > b.antecedentes_preguntables_al_usuario)
                    return -1;
                if (a.antecedentes_preguntables_al_usuario < b.antecedentes_preguntables_al_usuario)
                    return 1;

                //3° Privilegio a la regla mas nueva
                if (a.tiempo_regla > b.tiempo_regla)
                    return -1;
                if (a.tiempo_regla < b.tiempo_regla)
                    return 1;
                return 0;
            }

            public override string ToString()
            {
                return this.id_regla + " | " + this.puntaje_regla;
            }

        }

        struct HechoPila
        {
            public string hecho_buscado;
            public int nivel;

            public override string ToString()
            {
                return this.hecho_buscado + " | " + nivel;
            }
        }
        
        //********************************************************************************************************
        //    Atributos
        //********************************************************************************************************
        /*
        private const int REGLAS_DISPONIBLES    = 10;
        private const int REGLAS_CANDIDATAS     = 11;
        private const int REGLAS_ELIMINADAS     = 12;

        private const int HECHOS_DISPONIBLES    = 20;
        private const int HECHOS_VERDADEROS     = 21;
        private const int HECHOS_FALSOS         = 22;

        public const int HECHO_CONFIRMADO           = 31;
        public const int HECHO_DESCARTADO           = 32;
        public const int PROBLEMA_SOLUCIONADO       = 33;
        public const int PROBLEMA_NO_SOLUCIONADO    = 34;
        public const int CONTINUAR_PROCESO          = 35;
        public const int DETENER_PROCESO            = 36;

        public const int INFERENCIA_DETENIDA_POR_EL_USUARIO                             = 41;
        public const int INFERENCIA_DETENIDA_PROBLEMA_SOLUCIONADO                       = 42;
        public const int INFERENCIA_DETENIDA_PROBLEMA_NO_SOLUCIONADO                    = 43;
        public const int INFERENCIA_TERMINADA_PROBLEMA_NO_SOLUCIONADO_REGLAS_FALTANTES  = 44;

         */ 
        List<InfoRegla> lista_reglas_disponibles   = new List<InfoRegla>();
        List<InfoRegla> lista_reglas_candidatas    = new List<InfoRegla>();
        List<InfoRegla> lista_reglas_eliminadas    = new List<InfoRegla>();
        
        Stack<HechoPila> pila_hechos_a_verificar   = new Stack<HechoPila>();

        List<string> lista_hechos_disponibles   = new List<string>();
        List<string> lista_hechos_verdaderos    = new List<string>();
        List<string> lista_hechos_falsos        = new List<string>();

        List<string> lista_variables_disponibles = new List<string>();
        List<string> lista_variables_objetivos = new List<string>();
        List<string> lista_variables_conocidas = new List<string>();
        ArrayList lista_hechos_consecuente_con_variables_objetivo = new ArrayList();//string[] = {"id_variable","id_hecho"}
        
        List<string> log = new List<string>();

        public List<string> loggeo_inferencia
        {
            get { return log; }
        }


        AccesoDatos base_conocimiento;


        /// <summary>
        /// Evento de consulta variable
        /// Se debe retornar un ArrayList de la siguiente forma
        /// BOOLEANO {(string)id_,variable,(bool)  valor}
        /// NUEMRICO {(string)id_,variable,(double) valor}
        /// LISTA    {(string)id_,variable,(string) opcion}
        /// </summary>
        public event DelegadoConsultarVariable evento_consultar_variable;

        /// <summary>
        /// Evento para confirmar hecho segun constantes de control se retorna un int con las opciones segun constates [HECHO_VALIDADO,PROBLEMA_SOLUCIONADO,CONTINUAR_PROCESO]
        /// </summary>
        public event DelegadoConfirmarHecho evento_confimar_hecho;

        /// <summary>
        /// Evento que muestra información al usuario acerca de la inferencia
        /// </summary>
        public event DelegadoInformacionInferencia evento_informacion_inferencia;

        /// <summary>
        /// Variable que indica si el objeto ha sido inicializado
        /// </summary>
        public bool encadenamiento_inicializado
        {
            get { return _encadenamiento_inicializado; }
        }
        private bool _encadenamiento_inicializado = false;

        /// <summary>
        /// Indica si el hecho objetivo ha sido establecido para la inferencia 
        /// </summary>
        public bool hecho_objetivo_establecido
        {
            get { return _hecho_objetivo_establecido; }
        }
        private bool _hecho_objetivo_establecido = false;

        /// <summary>
        /// Obtiene la forma de termino del proceso de inferencia 
        /// </summary>
        public int codigo_de_salida_proceso
        {
            get { return _codigo_de_salida_proceso; }
        }
        private int _codigo_de_salida_proceso = -1;
        private int tiempo_regla = 0;

        //********************************************************************************************************
        //    Métodos
        //********************************************************************************************************

        /// <summary>
        /// Constructor
        /// </summary>
        public EncadenamientoHaciaAtras()
        {
            base_conocimiento = new AccesoDatos();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public EncadenamientoHaciaAtras(string ruta_base_conocimiento)
        {
            base_conocimiento = new AccesoDatos(ruta_base_conocimiento);
        }

        #region Pre Proceso Encadenamiento
        /// <summary>
        /// Método que inicializa la base de conocimiento y los atributos del encadenamiento para su inferencia
        /// </summary>
        /// <returns>Un texto con los errores encontrados|null si esta todo correcto</returns>
        public string inicializarEncadenamiento()
        {
            string texto_retorno = "";
            if (!base_conocimiento._existe_base_conocimiento)
                return "No existe la base de conocimiento";

            lista_reglas_disponibles = new List<InfoRegla>();
            lista_reglas_candidatas = new List<InfoRegla>();
            lista_reglas_eliminadas = new List<InfoRegla>();

            pila_hechos_a_verificar = new Stack<HechoPila>();

            lista_hechos_disponibles    = new List<string>();
            lista_hechos_verdaderos     = new List<string>();
            lista_hechos_falsos         = new List<string>();

            lista_variables_disponibles = new List<string>();
            lista_variables_conocidas = new List<string>();
            lista_variables_objetivos = new List<string>();
            lista_hechos_consecuente_con_variables_objetivo = new ArrayList();//string[] = {"id_variable","id_hecho"}

            log = new List<string>();

            _hecho_objetivo_establecido = false;

            tiempo_regla = 0;
            _codigo_de_salida_proceso = -1;


            int numero_de_reglas = base_conocimiento.listarArchivosEnDirectorio(AccesoDatos.REGLA).Length;
            if (numero_de_reglas == 0)
                return "La base de conocimiento esta vacia";
            
            if (!base_conocimiento.extraerMetadatosBaseConocimiento().base_conocimiento_chequeada)
                return "La base de conocimiento no ha sido chequeada";

            inicializarReglas();
            inicializacionVariables();
            inicializarHechos();
            
            if (lista_variables_objetivos.Count == 0)
                return "No existen variables objetivo en la base conocimiento";
            if (lista_hechos_consecuente_con_variables_objetivo.Count == 0)
                return "No existen hechos objetivos en el consecuente";
            if (texto_retorno.Equals(""))
            {
                _encadenamiento_inicializado = true;
                return null;
            }
            return texto_retorno;
        }

        /// <summary>
        /// Método que inicializa las varaibles de la  base de conocimiento para la inferencia
        /// </summary>
        private void inicializacionVariables()
        {
            string[] variables = base_conocimiento.listarArchivosEnDirectorio(AccesoDatos.VARIABLE);
            for (int i = 0; i < variables.Length; i++)
            {
                Variable variable = base_conocimiento.extraerVariable(variables[i]);
                variable.limpiarVariableParaInferencia();
                base_conocimiento.actualizarVariable(variable);
                lista_variables_disponibles.Add(variable.id_variable);
            }
        }

        
        /// <summary>
        /// Método que inicializa los hechos de la base de conocimiento para la inferencia
        /// </summary>
        private void inicializarHechos()
        {
            string[] hechos = base_conocimiento.listarArchivosEnDirectorio(AccesoDatos.HECHO);
            for (int i = 0; i < hechos.Length; i++)
            {
                Hecho hecho = base_conocimiento.extraerHecho(hechos[i]);
                hecho.limpiarEstadoHechoParaInferencia();
                base_conocimiento.actualizarHecho(hecho);
                lista_hechos_disponibles.Add(hecho.id_hecho);
                if (hecho.hecho_objetivo)
                {
                    if (buscarReglasConHechoEnConsecuentes(hecho.id_hecho, ConstantesShell.REGLAS_DISPONIBLES) != null)
                    {
                        string[] aux = new string[2];
                        aux[0] = hecho.id_variable;
                        aux[1] = hecho.id_hecho;
                        lista_hechos_consecuente_con_variables_objetivo.Add(aux);
                        lista_variables_objetivos.Add(hecho.id_variable);
                    }
                    
                }
            }
            

        }

        /// <summary>
        /// Método que inicializa los hechos de la base de conocimiento para la inferencia
        /// </summary>
        private void inicializarReglas()
        {
            string[] reglas = base_conocimiento.listarArchivosEnDirectorio(AccesoDatos.REGLA);
            for (int i = 0; i < reglas.Length; i++)
            {
                Regla regla = base_conocimiento.extraerRegla(reglas[i]);
                regla.limpiarReglaParaInferencia();
                base_conocimiento.actualizarRegla(regla);
                InfoRegla info_regla = new InfoRegla() 
                { 
                    validada = false,
                    tiempo_regla = 0,
                    antecedentes_preguntables_al_usuario_conocidos = 0 ,
                    antecedentes_inferidos_conocidos =0

                };
                info_regla.id_regla = regla.id_regla;
                string[] antecedentes = regla.listarAntecedentes();
                for (int j = 0; j < antecedentes.Length; j++)
		        {
			        Hecho hecho = base_conocimiento.extraerHecho(antecedentes[j]);
                    if (hecho.hecho_preguntable_al_usuario)
                        info_regla.antecedentes_preguntables_al_usuario++;
                    else
                        info_regla.antecedentes_inferidos++;
                    info_regla.numero_de_antecedentes++;
                }
                lista_reglas_disponibles.Add(info_regla);
            }
        }

        /// <summary>
        /// Método que devuelve las posibles variables objetivos para la inferencia.
        /// </summary>
        /// <returns>Ids Variables objetivos, null si no existen</returns>
        public string[] obtenerPosiblesVariablesObjetivos()
        {
            return lista_variables_objetivos.Count == 0 ? null : lista_variables_objetivos.ToArray();
        }

        /// <summary>
        /// Método que devuelve los posibles hechos objetivo en funcion de la varaible escogida
        /// </summary>
        /// <param name="id_variable">Id variable, perteneciente a las posibles varaibles objetivos</param>
        /// <returns>Lista de IDs hechos objetivos asociados a la variable| null si no existe</returns>
        public string[] obtenertPosibleHechosObjetivos(string id_variable)
        {
            List<string> hechos_objetivos = new List<string>();
            bool flag = false;
            foreach (string item in lista_variables_objetivos)
                if (item.Equals(id_variable))
                    flag = true;
            if (!flag)
                throw new System.ArgumentException("La variable no pertence a las posibles varaibles objetivo", "");
            foreach (string[] hecho_actual in lista_hechos_consecuente_con_variables_objetivo)
            {
                if (hecho_actual[0].Equals(id_variable))
                    hechos_objetivos.Add(hecho_actual[1]);
            }
            return hechos_objetivos.Count == 0 ? null : hechos_objetivos.ToArray();
        }

        /// <summary>
        /// Método que establece el hecho objetivo del encadenamiento
        /// </summary>
        /// <param name="id_hecho">Id del hecho objetivo, debe pertenecer a la lsita de hechos objetivos posibles</param>
        public void establecerHechoObjetivo(string id_hecho)
        {
            bool flag = false;
            foreach (string[] item in lista_hechos_consecuente_con_variables_objetivo)
                if (item[1].Equals(id_hecho))
                    flag = true;
            if (!flag)
                throw new System.ArgumentException("El hecho no pertenece a los hechos objetivo", "");
            pila_hechos_a_verificar.Push(new HechoPila() {
                hecho_buscado = id_hecho,
                nivel = 0
            });
            agregarLog(id_hecho + ":OBJETIVO PRINCIPAL", 0);
            _hecho_objetivo_establecido = true;
        }
        #endregion  


        #region Inferencia
        /// <summary>
        /// Método que realiza la inferencia del sistema experto
        /// </summary>
        public void inferencia()
        {
            while (pila_hechos_a_verificar.Count>0)
            {
                HechoPila top_hecho_pila = pila_hechos_a_verificar.Peek();
                Hecho hecho_objetivo_actual = base_conocimiento.extraerHecho(top_hecho_pila.hecho_buscado);
                agregarLog(top_hecho_pila.hecho_buscado + "(" + base_conocimiento.extraerHecho(top_hecho_pila.hecho_buscado) + ")" + " Objetivo Actual", top_hecho_pila.nivel);
                if (variableConocida(hecho_objetivo_actual.id_variable))
                {
                    agregarLog("Variable   " + hecho_objetivo_actual.id_variable +"  asociada al hecho objetivo conocida.");
                    procesarHecho(hecho_objetivo_actual.id_hecho,false);
                    agregarLog("Quitando hecho de la pila: " + pila_hechos_a_verificar.Pop());
                }
                else // si el hecho no es conocido A1
                {
                    string[] id_reglas_con_hecho_en_consecuente = buscarReglasConHechoEnConsecuentes(hecho_objetivo_actual.id_hecho, ConstantesShell.REGLAS_DISPONIBLES);
                    if (id_reglas_con_hecho_en_consecuente != null)
                        moverRegla(id_reglas_con_hecho_en_consecuente, ConstantesShell.REGLAS_DISPONIBLES, ConstantesShell.REGLAS_CANDIDATAS);
                    string id_mejor_regla_candidata = elegirMejorReglaCandidata(hecho_objetivo_actual.id_hecho);
                    if (id_mejor_regla_candidata == null)//Si no hay reglas candidatas elminamos el ultimo hecho objetivo de la pila
                    {
                        HechoPila hecho_top = pila_hechos_a_verificar.Pop();
                        agregarLog("El HECHO " + hecho_top.hecho_buscado + "(" + base_conocimiento.extraerHecho(hecho_top.hecho_buscado) + ")" + " no cuenta con reglas para inferirlo");
                        moverHecho(hecho_top.hecho_buscado, ConstantesShell.HECHOS_DISPONIBLES, ConstantesShell.HECHOS_FALSOS);
                        eliminarReglasConHechoEnElAntecedente(hecho_top.hecho_buscado);
                        if (evento_informacion_inferencia != null)
                        {
                            Hecho hecho = base_conocimiento.extraerHecho(hecho_top.hecho_buscado);
                            string info = "No quedan reglas para inferir " + hecho.id_hecho + " : " + hecho + "";
                            evento_informacion_inferencia(info);
                        }
                    }
                    else//Trabajando la regla
                    {
                        InfoRegla info_mejor_regla = rescatarInformacionRegla(id_mejor_regla_candidata, ConstantesShell.REGLAS_CANDIDATAS);
                        Regla mejor_regla = base_conocimiento.extraerRegla(info_mejor_regla.id_regla);
                        agregarLog("Regla elegida:   " + mejor_regla.id_regla);
                        //si existen antecedentes desconocidos
                        if ((info_mejor_regla.antecedentes_preguntables_al_usuario_conocidos != info_mejor_regla.antecedentes_preguntables_al_usuario) || (info_mejor_regla.antecedentes_inferidos != info_mejor_regla.antecedentes_inferidos_conocidos))
                        {
                            string[] ids_hechos_desconocidos = mejor_regla.listarAntecedentesNoEstablecidos();
                            if (ids_hechos_desconocidos != null)//trabajando hechos desconocidos
                            {
                                Stack<string> ids_hechos_a_preguntar = new Stack<string>();
                                Stack<string> ids_hechos_objetivo_temporales = new Stack<string>();
                                for (int i = 0; i < ids_hechos_desconocidos.Length; i++)
                                {
                                    Hecho hecho_desconocido = base_conocimiento.extraerHecho(ids_hechos_desconocidos[i]);
                                    if (hecho_desconocido.hecho_preguntable_al_usuario)
                                        ids_hechos_a_preguntar.Push(hecho_desconocido.id_hecho);
                                    else
                                        ids_hechos_objetivo_temporales.Push(hecho_desconocido.id_hecho);
                                }
                                bool flag_hecho_falso = false;
                                if (ids_hechos_a_preguntar.Count > 0)
                                {
                                    agregarLog("Preguntando hechos al usuario ");
                                    while (ids_hechos_a_preguntar.Count > 0)//Consultando hechos
                                    {
                                        string id_hecho_consultado = ids_hechos_a_preguntar.Pop();
                                        Hecho hecho_actual = base_conocimiento.extraerHecho(id_hecho_consultado);

                                        //Si no se conoce la variable se pregunta al usuario
                                        if (!variableConocida(hecho_actual.id_variable))
                                        {
                                            ArrayList respuesta = evento_consultar_variable(hecho_actual.id_variable);
                                            if (respuesta == null)
                                            {
                                                _codigo_de_salida_proceso = ConstantesShell.INFERENCIA_DETENIDA_POR_EL_USUARIO;
                                                return;
                                            }
                                            procesarRespuestaVariable(hecho_actual.id_variable, respuesta);
                                            //agregamos al variable a variables conocidas
                                            lista_variables_conocidas.Add(hecho_actual.id_variable);
                                        }
                                        else
                                        {
                                            agregarLog("Variable " + hecho_actual.id_variable + " conocida -> " + hecho_actual.id_hecho + " conocido");
                                        }
                                        //Si la regla tiene un hecho evaluado como falso, se descartan todas las reglas que contienen el hecho en el antecedente
                                        //Se pasa el hecho de disponible a falso
                                        if (!procesarHecho(hecho_actual.id_hecho,true))//si el hecho es evaluado como falso
                                            flag_hecho_falso = true;
                                    }//end consulta de variables al usuario
                                }

                                //Analizando los hechos inferidos, para ver si la variable asociada ya es conocida
                                if (ids_hechos_objetivo_temporales.Count > 0)
                                {
                                    agregarLog("Analizando posibles hechos objetivo");
                                    Stack<string> aux_objetivo = new Stack<string>();
                                    while (ids_hechos_objetivo_temporales.Count > 0)
                                    {
                                        string id_hecho_objetivo = ids_hechos_objetivo_temporales.Pop();
                                        Hecho hecho_actual = base_conocimiento.extraerHecho(id_hecho_objetivo);

                                        //Si la variable asociada al objetivo es concocida se procesa el hecho
                                        if (variableConocida(hecho_actual.id_variable))
                                        {
                                            agregarLog("Variable " + hecho_actual.id_variable + " conocida -> " + hecho_actual.id_hecho + " conocido");
                                            if (!procesarHecho(hecho_actual.id_hecho,false))//si el hecho es evaluado como falso
                                                flag_hecho_falso = false;
                                        }
                                        else
                                        {
                                            aux_objetivo.Push(id_hecho_objetivo);
                                        }
                                    }//end while pre proceso objetivos
                                    while (aux_objetivo.Count > 0)//Agregando los hechos objetivos que quedaron desconocidos
                                        ids_hechos_objetivo_temporales.Push(aux_objetivo.Pop());
                                }
                                if (!flag_hecho_falso)//Si la regla no tuvo ningun hecho falso
                                {
                                    //Ingresamos los hechos inferidos temporales a la pila general de hechos buscados.
                                    while (ids_hechos_objetivo_temporales.Count > 0)
                                    {
                                        string id_hecho = ids_hechos_objetivo_temporales.Pop();
                                        HechoPila nuevo_hecho_pila = new HechoPila()
                                        {
                                            hecho_buscado = id_hecho,
                                            nivel = top_hecho_pila.nivel + 1
                                        };
                                        pila_hechos_a_verificar.Push(nuevo_hecho_pila);
                                        agregarLog(nuevo_hecho_pila.hecho_buscado + "(" + base_conocimiento.extraerHecho(nuevo_hecho_pila.hecho_buscado) + ") Agregando hecho a pila ", nuevo_hecho_pila.nivel);
                                    }
                                }
                            }//End if trabajando Hechos desconocidos
                        }//End if si existen hechos desconosidos
                        else//Si todos los hechos son conocidos en la regla
                        {
                            int[] respuesta_validacion_regla = evento_confimar_hecho(mejor_regla.id_hecho_consecuente);

                            // Analizando confirmaciones de hecho
                            if (respuesta_validacion_regla[0] == ConstantesShell.HECHO_CONFIRMADO)//Si el hecho es validado por el usuario
                            {
                                actualizarVariableHechoInferido(mejor_regla.id_hecho_consecuente);//actualizamos la variable asocidada al hecho inferido
                                if (!actualizarEvaluacionHecho(mejor_regla.id_hecho_consecuente))
                                    throw new System.ArgumentException("La validaciond e un hecho, deberia dar un hecho verdadero", "Validadción de Hecho Usuario");
                                agregarLog("REGLA " + mejor_regla.id_regla + " VALIDADA");
                                moverHecho(mejor_regla.id_hecho_consecuente, ConstantesShell.HECHOS_DISPONIBLES, ConstantesShell.HECHOS_VERDADEROS);
                                agregarLog("Descartando REGLAS con el mismo consecuente");
                                actualizarReglasConHechoConsecuente(mejor_regla.id_regla, mejor_regla.id_hecho_consecuente, true);//Actualizamos regla y elimamos las reglas que tengan el hecho en el consecuente
                                actualizarReglasConHechoVerdaderoAntecedente(mejor_regla.id_hecho_consecuente, false);
                                HechoPila pop = pila_hechos_a_verificar.Pop();//Eliminamos de la pila el hecho buscado
                                agregarLog("Quitando hecho de la pila: " + pop.hecho_buscado);

                            }
                            else
                            if (respuesta_validacion_regla[0] == ConstantesShell.HECHO_DESCARTADO)//Si el hecho es no validado por el usuario
                            {
                                agregarLog("REGLA " + mejor_regla.id_regla + "NO VALIDADA  ->  " + mejor_regla.id_hecho_consecuente);
                                //Como se esta en la validacion de hechos por el usuario, el Hecho NO se marca como falso o se eliminia de la lista de hechos disponibles
                                actualizarReglasConHechoConsecuente(mejor_regla.id_regla, mejor_regla.id_hecho_consecuente, false);//Actualizamos regla y elimamos la regla de las reglas Candidatas
                            }
                            else//si el hecho no es validado
                            {
                                throw new System.ArgumentException("Argumentos invalidos VALIDACION", "Confirmacion de Hecho Usuario");
                            }

                            if (respuesta_validacion_regla[0] == ConstantesShell.HECHO_CONFIRMADO)
                            {
                                // Analizando solución de problemas
                                if (respuesta_validacion_regla[1] == ConstantesShell.PROBLEMA_SOLUCIONADO)//Si el problema solucionadp
                                {
                                    agregarLog("El problema se SOLUCIONO");
                                    _codigo_de_salida_proceso = ConstantesShell.INFERENCIA_DETENIDA_PROBLEMA_SOLUCIONADO;
                                    return;
                                }
                                else
                                if (respuesta_validacion_regla[1] == ConstantesShell.PROBLEMA_NO_SOLUCIONADO)//Si el problema no se soluciono
                                {
                                    agregarLog("El problema se NO SE SOLUCIONO");
                                }
                                else
                                {
                                    throw new System.ArgumentException("Argumentos invalidos SOLUCION", "Confirmacion de Hecho Usuario");
                                }
                            }

                            // Analizando continuar proceso
                            if (respuesta_validacion_regla[2] == ConstantesShell.CONTINUAR_PROCESO)//Si el problema solucionadp
                            {
                                agregarLog("CONTINUANDO PROCESO...");
                            }
                            else
                            if (respuesta_validacion_regla[2] == ConstantesShell.DETENER_PROCESO)//Si el problema no se soluciono
                            {
                                agregarLog("PROCESO DETENIDO...");
                                _codigo_de_salida_proceso = ConstantesShell.INFERENCIA_DETENIDA_PROBLEMA_NO_SOLUCIONADO;
                                return;
                            }
                            else
                            {
                                throw new System.ArgumentException("Argumentos invalidos PROCESO", "Confirmacion de Hecho Usuario");
                            }
                        }//End else todos los hechos conocidos
                    }//End else trabajando regla
                }// si el hecho no es conocido   A1
                
            } //End while inferencia
            /**/
            agregarLog("PROCESO INFERENCIA TERMINADO SIN SOLUCIONAR PROBLEMA (NO HAY MAS REGLAS APLICABLES EN LA BASE DE CONOCIMIENTO)");
            _codigo_de_salida_proceso = ConstantesShell.INFERENCIA_DETENIDA_PROBLEMA_NO_SOLUCIONADO;
        }

        /// <summary>
        /// método que acutaliza el hecho en base a su varaible y las reglas asociadas
        /// </summary>
        /// <param name="id_hecho">id del hecho a procesar</param>
        /// <returns>estado de la evaluacion del hecho</returns>
        public bool procesarHecho(string id_hecho, bool ingresado_por_usuario)
        {
            bool estado_hecho = true;
            if (!actualizarEvaluacionHecho(id_hecho))//FALSE si el estado del hecho es falso
            {
                moverHecho(id_hecho, ConstantesShell.HECHOS_DISPONIBLES, ConstantesShell.HECHOS_FALSOS);
                eliminarReglasConHechoEnElAntecedente(id_hecho);
                estado_hecho = false;
            }//Sino se pasa el hecho de disponible a verdadero y actualizamos la informacion del hecho en la regla
            else
            {
                moverHecho(id_hecho, ConstantesShell.HECHOS_DISPONIBLES, ConstantesShell.HECHOS_VERDADEROS);
                actualizarReglasConHechoVerdaderoAntecedente(id_hecho, ingresado_por_usuario);
            }
            return estado_hecho;
        }


        /// <summary>
        /// Método que actualiza la varaible asociada al hehco inferido
        /// </summary>
        /// <param name="id_hecho">id del hecho inferido</param>
        public void actualizarVariableHechoInferido(string id_hecho)
        {
            Hecho hecho = base_conocimiento.extraerHecho(id_hecho);
            Variable variable = base_conocimiento.extraerVariable(hecho.id_variable);
            switch (variable.tipo_variable)
            {
                case Variable.BOOLEANO:
                    variable.valor_booleano_actual  = hecho.valor_booleano;
                    break;
                case Variable.NUMERICO:
                    variable.valor_numerico_actual  = hecho.valor_numerico;
                    break;
                case Variable.LISTA:
                    variable.valor_lista_actual     = hecho.valor_lista_hecho;
                    break;
            }
            base_conocimiento.actualizarVariable(variable);
            lista_variables_conocidas.Add(hecho.id_variable);
        }


        /// <summary>
        /// Método que devuelve si la variable esta en la lista de variables conocidas
        /// </summary>
        /// <param name="id_variable">Id de la variable a buscar</param>
        /// <returns>True|False según corresponda</returns>
        public bool variableConocida(string id_variable)
        {
            foreach (string item in lista_variables_conocidas)
            {
                if (item.Equals(id_variable))
                    return true;
            }
            return false;
        }



        /// <summary>
        /// Método para actualizar la validacion de las reglas, con cambios en su hecho consecuente
        /// </summary>
        /// <param name="id_regla_validada">Id regla validada</param>
        /// <param name="id_hecho_consecuente">Id del hecho</param>
        /// <param name="regla_validada">Establece si la regla fue validada por el usuario</param>
        public void actualizarReglasConHechoConsecuente(string id_regla_validada, string id_hecho_consecuente, bool regla_validada)
        {
            if (regla_validada)//Si la regla se valida
            {
                actualizarValidacionInfoRegla(id_regla_validada, ConstantesShell.REGLAS_CANDIDATAS, regla_validada);//validamos la regla candidata
                string[] reglas_con_hecho_en_el_consecuente = buscarReglasConHechoEnConsecuentes(id_hecho_consecuente, ConstantesShell.REGLAS_CANDIDATAS);
                for (int i = 0; i < reglas_con_hecho_en_el_consecuente.Length; i++)//limpiamos las reglas que no se utilizaran
                {
                    moverRegla(reglas_con_hecho_en_el_consecuente[i], ConstantesShell.REGLAS_CANDIDATAS, ConstantesShell.REGLAS_ELIMINADAS);
                }
                Regla regla = base_conocimiento.extraerRegla(id_regla_validada);
                regla.regla_validada = true;
                base_conocimiento.actualizarRegla(regla);
            }
            else//Si la regla no es validada
            {
                actualizarValidacionInfoRegla(id_regla_validada, ConstantesShell.REGLAS_CANDIDATAS, regla_validada);//validamos la regla candidata
                moverRegla(id_regla_validada, ConstantesShell.REGLAS_CANDIDATAS, ConstantesShell.REGLAS_ELIMINADAS);//eliminamos la regla de las reglas candidatas
            }
        }

        /// <summary>
        /// Método que actualiza el hecho verdadero en REGLAS_DISPONIBLES y REGLAS_CANDIDATAS,
        /// </summary>
        /// <param name="id_hecho"></param>
        /// <param name="ingresado_por_usuario"></param>
        public void actualizarReglasConHechoVerdaderoAntecedente(string id_hecho, bool ingresado_por_usuario)
        {
            Hecho hecho = base_conocimiento.extraerHecho(id_hecho);
            if (!hecho.estado_hecho)
                throw new System.ArgumentException("El hecho no es verdadero", "");
            //actualizando en reglas disponibles
            for (int i = 0; i < lista_reglas_disponibles.Count; i++)
            {
                Regla regla = base_conocimiento.extraerRegla(lista_reglas_disponibles[i].id_regla);
                if (regla.consultarAntecendente(id_hecho))
                {
                    regla.cambiarEstadoHecho(id_hecho, true);
                    base_conocimiento.actualizarRegla(regla);
                    if (ingresado_por_usuario)
                        aumentarConteoInfoRegla(regla.id_regla, ConstantesShell.REGLAS_DISPONIBLES, sumar_a_antecedentes_conocidos_ingresados_por_usuario: 1);
                    else
                        aumentarConteoInfoRegla(regla.id_regla, ConstantesShell.REGLAS_DISPONIBLES, sumar_a_antecedentes_conocidos_inferidos: 1);
                }

            }
            // actualizando reglas candidatas
            for (int i = 0; i < lista_reglas_candidatas.Count; i++)
            {
                Regla regla = base_conocimiento.extraerRegla(lista_reglas_candidatas[i].id_regla);
                if (regla.consultarAntecendente(id_hecho))
                {
                    regla.cambiarEstadoHecho(id_hecho, true);
                    base_conocimiento.actualizarRegla(regla);
                    if (ingresado_por_usuario)//al aumentar la regla queda al final del arreglo
                        aumentarConteoInfoRegla(regla.id_regla, ConstantesShell.REGLAS_CANDIDATAS, sumar_a_antecedentes_conocidos_ingresados_por_usuario: 1);
                    else
                        aumentarConteoInfoRegla(regla.id_regla, ConstantesShell.REGLAS_CANDIDATAS, sumar_a_antecedentes_conocidos_inferidos: 1);
                }
            }
        }

        /// <summary>
        /// Método que modifica los contadores de las listas de reglas
        /// </summary>
        /// <param name="id_regla">id de la regla a modificar</param>
        /// <param name="tipo_de_regla">Lista en donde se modificara la regla </param>
        /// <param name="sumar_a_antecedentes_conocidos_ingresados_por_usuario">cantidad a sumar en el contador de hechos conocidos ingresados por usuario</param>
        /// <param name="sumar_a_antecedentes_conocidos_inferidos">cantidad a sumar en el contador de hechos conocidos inferidos</param>
        public void aumentarConteoInfoRegla(string id_regla,int tipo_de_regla, int sumar_a_antecedentes_conocidos_ingresados_por_usuario = 0, int sumar_a_antecedentes_conocidos_inferidos = 0)
        {
            List<InfoRegla> lista = new List<InfoRegla>();
            switch (tipo_de_regla)
            {
                case ConstantesShell.REGLAS_DISPONIBLES:
                    lista = lista_reglas_disponibles;
                    break;
                case ConstantesShell.REGLAS_CANDIDATAS:
                    lista = lista_reglas_candidatas;
                    break;
                case ConstantesShell.REGLAS_ELIMINADAS:
                    lista = lista_reglas_eliminadas;
                    break;
            }
            
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].id_regla.Equals(id_regla))
                {
                    InfoRegla info = lista[i];
                    info.antecedentes_preguntables_al_usuario_conocidos += sumar_a_antecedentes_conocidos_ingresados_por_usuario;
                    info.antecedentes_inferidos_conocidos += sumar_a_antecedentes_conocidos_inferidos;
                    lista[i] = info;
                    return;
                }
            }
            throw new System.ArgumentException("La regla no existe en la lista", "");
        }


        /// <summary>
        /// Método que marca la validadcion de la regla por el usuario
        /// </summary>
        /// <param name="id_regla">Id de la regla a validar</param>
        /// <param name="tipo_de_regla">Lista de reglas a buscar</param>
        /// <param name="regla_validada">Id de la egla a validar</param>
        public void actualizarValidacionInfoRegla(string id_regla, int tipo_de_regla, bool regla_validada)
        {
            List<InfoRegla> lista = new List<InfoRegla>();
            switch (tipo_de_regla)
            {
                case ConstantesShell.REGLAS_DISPONIBLES:
                    lista = lista_reglas_disponibles;
                    break;
                case ConstantesShell.REGLAS_CANDIDATAS:
                    lista = lista_reglas_candidatas;
                    break;
                case ConstantesShell.REGLAS_ELIMINADAS:
                    lista = lista_reglas_eliminadas;
                    break;
            }
            bool flag = false;
            for (int i = 0; i < lista.Count && !flag; i++)
            {
                if (lista[i].id_regla.Equals(id_regla))
                {
                    InfoRegla info = lista[i];
                    lista.Remove(info);
                    info.validada = regla_validada;
                    lista.Add(info);
                    flag = true;
                    return;
                }
            }
            /**/
            throw new System.ArgumentException("La regla no existe en la lista", "");
        }



        /// <summary>
        /// Método que mueve las reglas con el hecho de DISPONIBLES y CANDIDATAS a ELIMINADA,
        /// </summary>
        /// <param name="id_hecho">Id del hecho a buscar</param>
        public void eliminarReglasConHechoEnElAntecedente(string id_hecho)
        {
            //actualizando reglas disponibles
            List<string> reglas_disponibles_con_hecho = new List<string>();
            foreach (InfoRegla info_regla in lista_reglas_disponibles)
            {
                Regla regla = base_conocimiento.extraerRegla(info_regla.id_regla);
                regla.cambiarEstadoHecho(id_hecho, false);
                if (regla.consultarAntecendente(id_hecho))
                    reglas_disponibles_con_hecho.Add(regla.id_regla);
            }
            //moviendo de disponibles -> eliminadas
            foreach (string item in reglas_disponibles_con_hecho)
                moverRegla(item, ConstantesShell.REGLAS_DISPONIBLES, ConstantesShell.REGLAS_ELIMINADAS);

            //actualizando reglas candidatas
            List<string> reglas_candidatas_con_hecho = new List<string>();
            foreach (InfoRegla info_regla in lista_reglas_candidatas)
            {
                Regla regla = base_conocimiento.extraerRegla(info_regla.id_regla);
                regla.cambiarEstadoHecho(id_hecho, false);
                if (regla.consultarAntecendente(id_hecho))
                    reglas_candidatas_con_hecho.Add(regla.id_regla);
            }
            //moviendo de candidatas -> eliminadas
            foreach (string item in reglas_candidatas_con_hecho)
                moverRegla(item, ConstantesShell.REGLAS_CANDIDATAS, ConstantesShell.REGLAS_ELIMINADAS);
        }


        /// <summary>
        /// Método para actualizar la evaluación del hecho
        /// </summary>
        /// <param name="id_hecho">Id del hecho a evaluar</param>
        /// <returns>Evalucion del hecho (true|false)</returns>
        public bool actualizarEvaluacionHecho (string id_hecho)
        {
            Hecho hecho = base_conocimiento.extraerHecho(id_hecho);
            Variable variable = base_conocimiento.extraerVariable(hecho.id_variable);
            switch (variable.tipo_variable)
            {
                case Variable.BOOLEANO:
                    hecho.evaluarHechoBooleano(variable.valor_booleano_actual);
                    break;
                case Variable.NUMERICO:
                    hecho.evaluarHechoNumerico(variable.valor_numerico_actual);
                    break;
                case Variable.LISTA:
                    hecho.evaluarHechoLista(variable.valor_lista_actual);
                    break;
            }
            base_conocimiento.actualizarHecho(hecho);
            return hecho.estado_hecho;
        }


        /// <summary>
        /// Método para procesar la respuesta de una variable
        /// </summary>
        /// <param name="id_variable"></param>
        /// <param name="respuesta"></param>
        public void procesarRespuestaVariable(string id_variable, ArrayList respuesta)
        {
            string id_variable_respuesta = (string)respuesta[0];
            if (!id_variable_respuesta.Equals(id_variable))
                throw new System.ArgumentException("La variable de respuesta no corresponde a la variable procesada", "PrcesarRespuestaVariable");
            Variable variable = base_conocimiento.extraerVariable(id_variable);
            agregarLog("Procesando variable : " + id_variable + " - " + variable.nombre_variable);
            string tipo_valor = respuesta[1].GetType()+"";
            
            if (tipo_valor.Equals("System.Boolean"))
            {
                bool valor_respuesta = (bool)respuesta[1];
                if(variable.tipo_variable != Variable.BOOLEANO)
                    throw new System.ArgumentException("tipos de variable incompatibles", "PrcesarRespuestaVariable");
                variable.valor_booleano_actual = valor_respuesta;
                base_conocimiento.actualizarVariable(variable);
                return;
            }
            else
            if (tipo_valor.Equals("System.String"))
            {
                string valor_respuesta = (string)respuesta[1];
                if (variable.tipo_variable != Variable.LISTA)
                    throw new System.ArgumentException("tipos de variable incompatibles", "PrcesarRespuestaVariable");
                variable.valor_lista_actual = valor_respuesta;
                base_conocimiento.actualizarVariable(variable);
                return;
            }
            else
            if (tipo_valor.Equals("System.Double") || tipo_valor.Equals("System.Decimal"))
            {
                double valor_respuesta = (double)respuesta[1];
                if (variable.tipo_variable != Variable.NUMERICO)
                    throw new System.ArgumentException("tipos de variable incompatibles", "PrcesarRespuestaVariable");
                variable.valor_numerico_actual = valor_respuesta;
                base_conocimiento.actualizarVariable(variable);
                return;
            }
            throw new System.ArgumentException("El tipo de respuesta no corresponde", "PrcesarRespuestaVariable");
        }
        
        /// <summary>
        /// Método que elige la mejor REGLA CANDIDATA 
        /// </summary>
        /// <returns>Id regla candidata</returns>
        public string elegirMejorReglaCandidata(string id_hecho)
        {
            lista_reglas_candidatas.Sort(new InfoRegla());
            if (lista_reglas_candidatas.Count == 0)
                return null;
            Hecho hecho_buscado = base_conocimiento.extraerHecho(id_hecho);
            for (int i = 0; i < lista_reglas_candidatas.Count; i++)
            {
                Regla regla = base_conocimiento.extraerRegla(lista_reglas_candidatas[i].id_regla);
                Hecho hecho_consecuente = base_conocimiento.extraerHecho(regla.id_hecho_consecuente);
                if (compararAfinidadDeHechos(hecho_buscado, hecho_consecuente))
                    return regla.id_regla;
            }
            return null;
        }

        //utilitarios

        /// <summary>
        /// Método para rescartar la informacion de una regla en la lista de reglas
        /// </summary>
        /// <param name="id_regla">Id de regla a buscar</param>
        /// <param name="tipo_de_regla">Tipo de lista en donde buscar</param>
        /// <returns>InfoRegla de la regla buscada</returns>
        private InfoRegla rescatarInformacionRegla(string id_regla,int tipo_de_regla)
        {
            List<InfoRegla> lista = new List<InfoRegla>();
            switch (tipo_de_regla)
            {
                case ConstantesShell.REGLAS_DISPONIBLES:
                    lista = lista_reglas_disponibles;
                    break;
                case ConstantesShell.REGLAS_CANDIDATAS:
                    lista = lista_reglas_candidatas;
                    break;
                case ConstantesShell.REGLAS_ELIMINADAS:
                    lista = lista_reglas_eliminadas;
                    break;
            }
            foreach (InfoRegla info in lista)
            {
                if (info.id_regla.Equals(id_regla))
                    return info;
            }
            throw new System.ArgumentException("La regla no existe en la lista", "");
            
        }


        /// <summary>
        /// Método que devuelve las reglas que contengan el hecho en el consecuente
        /// </summary>
        /// <param name="id_hecho"></param>
        /// <param name="tipo_de_reglas"></param>
        /// <returns>Ids regals encontradas</returns>
        private string[] buscarReglasConHechoEnConsecuentes(string id_hecho, int tipo_de_reglas)
        {
            Hecho hecho_buscado = base_conocimiento.extraerHecho(id_hecho);
            List<string> reglas_encontradas = new List<string>();
            if (!(tipo_de_reglas == ConstantesShell.REGLAS_CANDIDATAS || tipo_de_reglas == ConstantesShell.REGLAS_DISPONIBLES))
                throw new System.ArgumentException("No existe la opción de lista de reglas", "");
            List<InfoRegla> reglas_a_buscar = tipo_de_reglas == ConstantesShell.REGLAS_CANDIDATAS ? lista_reglas_candidatas : lista_reglas_disponibles;
            foreach (InfoRegla info_regla in reglas_a_buscar)
            {
                Regla regla = base_conocimiento.extraerRegla(info_regla.id_regla);
                Hecho hecho_consecuente = base_conocimiento.extraerHecho(regla.id_hecho_consecuente);
                if (compararAfinidadDeHechos(hecho_buscado, hecho_consecuente))
                    reglas_encontradas.Add(regla.id_regla);
            }
            return reglas_encontradas.Count == 0 ? null : reglas_encontradas.ToArray();
        }

        /// <summary>
        /// Método que compara la afinidad de los hechos 
        /// </summary>
        /// <param name="hecho_buscado">Hecho buscado por la pila</param>
        /// <param name="hecho_candidato">Hecho candidato a agregar</param>
        /// <returns>TRUE si los hechos son afines| FALSE en caso contrario</returns>
        public bool compararAfinidadDeHechos(Hecho hecho_buscado, Hecho hecho_candidato)
        {
            if ((hecho_buscado.tipo_variable == Variable.BOOLEANO) ||                                                           // si el hecho es booleano
                        (hecho_buscado.tipo_variable == Variable.LISTA && hecho_buscado.condicion.Equals(Hecho.OPCIONES_LISTA[0])))//Si el hecho es lista y su condicion es "ES"
            {//Casos en que la busqueda de hechos es normal
                if (hecho_buscado.id_hecho.Equals(hecho_candidato.id_hecho))
                    return true;
            }
            else
            if (hecho_buscado.tipo_variable == Variable.LISTA && hecho_buscado.condicion.Equals(Hecho.OPCIONES_LISTA[1])) // si el hecho es de tipo lista y su condicion "NO ES", se deben buscar los hechos alternativos en donde se valide una opcion distinta de la establecida en el hecho
            {
                if (hecho_buscado.id_variable.Equals(hecho_candidato.id_variable))
                    if (!hecho_buscado.valor_lista_hecho.Equals(hecho_candidato.valor_lista_hecho))
                        return true;
            }                                                                   //0
            else // public static string[] OPCIONES_NUMERICO = new string[] {,,,, };
            if (hecho_buscado.tipo_variable == Variable.NUMERICO)
            {
                if (hecho_buscado.id_variable.Equals(hecho_candidato.id_variable))
                    switch (hecho_buscado.condicion)
                    {
                        case "MENOR":
                            if ( hecho_candidato.valor_numerico < hecho_buscado.valor_numerico)
                                return true; 
                            break;
                        case "MENOR O IGUAL":
                            if (hecho_candidato.valor_numerico <= hecho_buscado.valor_numerico)
                                return true; 
                            break;
                        case "IGUAL":
                            if (hecho_candidato.valor_numerico == hecho_buscado.valor_numerico)
                                return true; 
                            break;
                        case "MAYOR O IGUAL":
                            if (hecho_candidato.valor_numerico >= hecho_buscado.valor_numerico)
                                return true; 
                            break;
                        case "MAYOR":
                            if (hecho_candidato.valor_numerico > hecho_buscado.valor_numerico)
                                return true; 
                            break;
                    }
                if (hecho_buscado.id_hecho.Equals(hecho_candidato.id_hecho))
                    return true;
            }
            else
            {
                throw new System.ArgumentException("Error en las opciones de buscar reglas", "");
            }
            return false;
        }


        /// <summary>
        /// Método para mover de lista la regla ingresada
        /// </summary>
        /// <param name="ids_regla">Ids del lote de reglas a mover</param>
        /// <param name="desde">Lista origen</param>
        /// <param name="hacia">Lista Destino</param>
        /// <param name="marcar_tiempo_regla">Establece si se debe marcar el tiempo regla en Info_regla</param>
        private void moverRegla(string[] ids_regla, int desde, int hacia, bool marcar_tiempo_regla = false)
        {
            for (int i = 0; i < ids_regla.Length; i++)
                moverRegla(ids_regla[i], desde, hacia,marcar_tiempo_regla);
        }

        /// <summary>
        /// Método para mover de lista la regla ingresada
        /// </summary>
        /// <param name="id_regla">Id de la regla a mover</param>
        /// <param name="desde">Lista origen</param>
        /// <param name="hacia">Lista Destino</param>
        /// <param name="marcar_tiempo_regla">Establece si se debe marcar el tiempo regla en Info_regla</param>
        private void moverRegla(string id_regla, int desde, int hacia,bool marcar_tiempo_regla = false)
        {
            if (desde == hacia)
                throw new System.ArgumentException("El destino no puede ser igual al origen", "Mover regla, motor de inferencia");
            List<InfoRegla> lista_desde = new List<InfoRegla>();
            List<InfoRegla> lista_hacia = new List<InfoRegla>();
            InfoRegla regla_buscada = new InfoRegla();
            string tipo_lista_desde = "";
            string tipo_lista_hacia = "";
            switch (desde)
            {
                case ConstantesShell.REGLAS_DISPONIBLES:
                    lista_desde = lista_reglas_disponibles;
                    tipo_lista_desde = "REGLAS DISPONBLES";
                    break;
                case ConstantesShell.REGLAS_CANDIDATAS:
                    lista_desde = lista_reglas_candidatas;
                    tipo_lista_desde = "REGLAS CANDIDATAS";
                    break;
                case ConstantesShell.REGLAS_ELIMINADAS:
                    lista_desde = lista_reglas_eliminadas;
                    tipo_lista_desde = "REGLAS ELIMINADAS";
                    break;
            }
            switch (hacia)
            {
                case ConstantesShell.REGLAS_DISPONIBLES:
                    lista_hacia = lista_reglas_disponibles;
                    tipo_lista_hacia = "REGLAS DISPONIBLES";
                    break;
                case ConstantesShell.REGLAS_CANDIDATAS:
                    lista_hacia = lista_reglas_candidatas;
                    tipo_lista_hacia = "REGLAS CANDIDATAS";
                    break;
                case ConstantesShell.REGLAS_ELIMINADAS:
                    lista_hacia = lista_reglas_eliminadas;
                    tipo_lista_hacia = "REGLAS ELIMINADAS";
                    break;
            }
            
            foreach (InfoRegla info_regla in lista_desde)
            {
                if (info_regla.id_regla.Equals(id_regla))
                {
                    regla_buscada = info_regla;
                    break;
                }
            }
            if (regla_buscada.id_regla == null || regla_buscada.id_regla.Equals(""))
                throw new System.ArgumentException("La regla no se encuentra en la lista de origen ("+desde+") "+id_regla, "Mover regla, motor de inferencia");
            foreach (InfoRegla info_regla in lista_hacia)
            {
                if (info_regla.id_regla.Equals(id_regla))
                {
                    throw new System.ArgumentException("La regla ya se encuentra en la lista destino (" + desde + ") "+id_regla, "Mover regla, motor de inferencia");
                }
            }
            
            lista_desde.Remove(regla_buscada);
            if (marcar_tiempo_regla)
            {
                regla_buscada.tiempo_regla = this.tiempo_regla;
                this.tiempo_regla++;
            }
            lista_hacia.Add(regla_buscada);
            
            string log = id_regla+":De "+tipo_lista_desde+" a "+tipo_lista_hacia;
            agregarLog(log);
        }

        /// <summary>
        /// Método para mover un elemento entre las listas de hechos
        /// </summary>
        /// <param name="id_hecho">Id del hecho a mover</param>
        /// <param name="desde">Lista origen</param>
        /// <param name="hacia">Lista Destino</param>
        private void moverHecho(string id_hecho, int desde, int hacia)
        {
            if (desde == hacia)
                throw new System.ArgumentException("El destino no puede ser igual al origen", "Mover hecho, motor de inferencia");
            List<string> lista_desde = new List<string>();
            List<string> lista_hacia = new List<string>();
            string tipo_lista_desde = "";
            string tipo_lista_hacia = "";
            switch (desde)
            {
                case ConstantesShell.HECHOS_DISPONIBLES:
                    lista_desde = lista_hechos_disponibles;
                    tipo_lista_desde = "HECHOS DISPONBLES";
                    break;
                case ConstantesShell.HECHOS_VERDADEROS:
                    lista_desde = lista_hechos_verdaderos;
                    tipo_lista_desde = "HECHOS VERDADEROS";
                    break;
                case ConstantesShell.HECHOS_FALSOS:
                    lista_desde = lista_hechos_falsos;
                    tipo_lista_desde = "HECHOS FALSOS";
                    break;
            }
            switch (hacia)
            {
                case ConstantesShell.HECHOS_DISPONIBLES:
                    lista_hacia = lista_hechos_disponibles;
                    tipo_lista_hacia = "HECHOS DISPONBLES";
                    break;
                case ConstantesShell.HECHOS_VERDADEROS:
                    lista_hacia = lista_hechos_verdaderos;
                    tipo_lista_hacia = "HECHOS VERDADEROS";
                    break;
                case ConstantesShell.HECHOS_FALSOS:
                    lista_hacia = lista_hechos_falsos;
                    tipo_lista_hacia = "HECHOS FALSOS";
                    break;
            }
            string hecho_buscado = null;
            foreach (string item_hecho in lista_desde)
                if (item_hecho.Equals(id_hecho))
                {
                    hecho_buscado = item_hecho;
                    break;
                }

            if (hecho_buscado == null || hecho_buscado.Equals(""))
                throw new System.ArgumentException("El hecho no se encuentra en la lista de origen (" + desde + ") " + id_hecho, "Mover hecho, motor de inferencia");
            
            foreach (string item_hecho in lista_hacia)
                if (item_hecho.Equals(id_hecho))
                {
                    throw new System.ArgumentException("El hecho ya se encuentra en la lista destino (" + desde + ") " + id_hecho, "Mover hecho, motor de inferencia");
                }
            lista_desde.Remove(hecho_buscado);
            lista_hacia.Add(hecho_buscado);

            string log = id_hecho + ":De " + tipo_lista_desde + " a " + tipo_lista_hacia;
            agregarLog(log);
        }

        /// <summary>
        /// Método que agrega un nuevo registro de log del la inferencia 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="nivel"></param>
        private void agregarLog(string log, int nivel = -1)
        {
            for (int i = 0; i < nivel; i++)
                log = "\t" + log;
            this.log.Add(log);
        }
        #endregion

    }//End class
}//End  namespace