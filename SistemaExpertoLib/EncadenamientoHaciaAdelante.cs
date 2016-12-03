using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SistemaExpertoLib.MotorDeInferencia
{


    public class EncadenamientoHaciaAdelante
    {
        //********************************************************************************************************
        //    Estructuras
        //********************************************************************************************************
        struct InfoRegla : IComparer<InfoRegla>
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

            public int porcentaje_conocidas
            {
                get
                {
                    double porcentaje = (antecedentes_inferidos_conocidos + antecedentes_preguntables_al_usuario_conocidos)/numero_de_antecedentes;
                    porcentaje *= 100;
                    return (int)porcentaje;
                }
            }
            public int antecedentes_conocidos
            {
                get
                {
                    return antecedentes_preguntables_al_usuario_conocidos + antecedentes_inferidos_conocidos;
                }
            }

            //todo revisar ordenamiento reglas
            public int Compare(InfoRegla x, InfoRegla y)
            {
                InfoRegla a = x;
                InfoRegla b = y;

                //1°Privilegio a las variables con mayor porcentaje de antecedentes conocidos
                if (a.porcentaje_conocidas > b.porcentaje_conocidas)
                    return -1;
                if (a.porcentaje_conocidas < b.porcentaje_conocidas)
                    return 1;

                //2° Privilegio a las variables preguntadas por el usuario
                if (a.antecedentes_conocidos > b.antecedentes_conocidos)
                    return -1;
                if (a.antecedentes_conocidos < b.antecedentes_conocidos) 
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

        //********************************************************************************************************
        //    Atributos
        //********************************************************************************************************

        List<InfoRegla> lista_reglas_disponibles = new List<InfoRegla>();
        List<InfoRegla> lista_reglas_candidatas = new List<InfoRegla>();
        List<InfoRegla> lista_reglas_eliminadas = new List<InfoRegla>();

        List<string> lista_hechos_disponibles = new List<string>();
        List<string> lista_hechos_verdaderos = new List<string>();
        List<string> lista_hechos_falsos = new List<string>();

        List<string> lista_variables_disponibles = new List<string>();
        List<string> lista_variables_conocidas = new List<string>();

        List<string> lista_variables_de_inicio = new List<string>();

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
        public EncadenamientoHaciaAdelante()
        {
            base_conocimiento = new AccesoDatos();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public EncadenamientoHaciaAdelante(string ruta_base_conocimiento)
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

            lista_hechos_disponibles = new List<string>();
            lista_hechos_verdaderos = new List<string>();
            lista_hechos_falsos = new List<string>();

            lista_variables_disponibles = new List<string>();
            lista_variables_conocidas = new List<string>();

            lista_variables_de_inicio = new List<string>();

            log = new List<string>();

            tiempo_regla = 0;
            _codigo_de_salida_proceso = -1;

            int numero_de_reglas = base_conocimiento.listarArchivosEnDirectorio(AccesoDatos.REGLA).Length;
            if (numero_de_reglas == 0)
                return "La base de conocimiento esta vacia";

            inicializarReglas();
            inicializacionVariables();
            inicializarHechos();

            //todo comprobar que existen variables preguntables al usuario
            if (lista_variables_de_inicio.Count == 0)
            {
                return "No existen variables preguntables al usuario en la base de conocimiento";
            }
            //todo falta comprobador de integridad de las reglas
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
                if (variable.variable_de_inicio)
                    lista_variables_de_inicio.Add(variable.id_variable);
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
                    antecedentes_preguntables_al_usuario_conocidos = 0,
                    antecedentes_inferidos_conocidos = 0

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


     #endregion


        #region Inferencia
        /// <summary>
        /// Método que realiza la inferencia del sistema experto
        /// </summary>
        public void inferencia()
        {
            //Procesando las variables de inicio
            agregarLog("Consultando variables de inicio al usuario");
            foreach (string id_variable_de_inicio in lista_variables_de_inicio)
            {
                ArrayList respuesta = evento_consultar_variable(id_variable_de_inicio);
                if (respuesta == null)
                {
                    _codigo_de_salida_proceso = ConstantesShell.INFERENCIA_DETENIDA_POR_EL_USUARIO;
                    return;
                }
                procesarRespuestaVariable(id_variable_de_inicio, respuesta);
                string[] hechos_asociados = buscarHechosConVariable(id_variable_de_inicio);
                if(hechos_asociados != null)
                    for (int i = 0; i < hechos_asociados.Length; i++)
                        procesarHecho(hechos_asociados[i],true);
            }
            //Proceso de encadenamiento hacia adelante
            string id_mejor_regla = elegirMejorReglaCandidata();
            agregarLog("Regla elegida = "+id_mejor_regla);
            while (id_mejor_regla != null)
            {
                InfoRegla info_regla = rescatarInformacionRegla(id_mejor_regla, ConstantesShell.REGLAS_CANDIDATAS);
                Regla mejor_regla = base_conocimiento.extraerRegla(info_regla.id_regla);
                if (info_regla.puntaje_regla == 0)//Indica que todos los antecedentes son conocidos
                {
                    int[] respuesta_validacion_regla = evento_confimar_hecho(mejor_regla.id_hecho_consecuente);

                    // Analizando confirmaciones de hecho
                    if (respuesta_validacion_regla[0] == ConstantesShell.HECHO_CONFIRMADO)//Si el hecho es validado por el usuario
                    {
                        actualizarVariableHechoInferido(mejor_regla.id_hecho_consecuente);//actualizamos la variable asocidada al hecho inferido
                        actualizarValidaciónDeRegla(mejor_regla.id_regla, true);//Actualizamos la validación de la regla regla
                        agregarLog("REGLA " + mejor_regla.id_regla + " VALIDADA");
                        Hecho hecho_validado = base_conocimiento.extraerHecho(mejor_regla.id_hecho_consecuente);
                        string id_variable_hecho_inferido = hecho_validado.id_variable;
                        string[] hechos_asociados = buscarHechosConVariable(id_variable_hecho_inferido);
                        agregarLog("Procesando hechos asociados a la variable   "+hecho_validado.nombre_variable+"   del hecho consecuente");
                        if (hechos_asociados != null)
                            for (int i = 0; i < hechos_asociados.Length; i++)
                                procesarHecho(hechos_asociados[i], false);
                        
                    }
                    else
                    if (respuesta_validacion_regla[0] == ConstantesShell.HECHO_DESCARTADO)//Si el hecho no es validado por el usuario
                    {
                        agregarLog("REGLA " + mejor_regla.id_regla + "NO VALIDADA  ->  " + mejor_regla.id_hecho_consecuente);
                        //Como se esta en la validacion de hechos por el usuario, el Hecho NO se marca como falso o se eliminia de la lista de hechos disponibles
                        actualizarValidaciónDeRegla(mejor_regla.id_regla, false);//Actualizamos la validación de la regla regla y elimamos la regla de las reglas Candidatas
                    }
                    else//si el respuesta no es valida
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
                }//end if todos los hechos conocidos 
                else//Si faltan hechos por conocer
                {
                    string[] ids_hechos_desconocidos = mejor_regla.listarAntecedentesNoEstablecidos();
                    List<string> ids_hechos_a_preguntar = new List<string>();
                    for (int i = 0; i < ids_hechos_desconocidos.Length; i++)
                    {
                        Hecho hecho_desconocido = base_conocimiento.extraerHecho(ids_hechos_desconocidos[i]);
                        if (hecho_desconocido.hecho_preguntable_al_usuario)
                            ids_hechos_a_preguntar.Add(hecho_desconocido.id_hecho);
                    }
                    //preguntado los hechos al usuario
                    agregarLog("Preguntando hechos al usuario ");
                    foreach (string id_hecho_consultado in ids_hechos_a_preguntar)
                    {
                        Hecho hecho_actual = base_conocimiento.extraerHecho(id_hecho_consultado);

                        //Si no se conoce la variable asociada al hecho se pregunta al usuario
                        if (!variableConocida(hecho_actual.id_variable))
                        {
                            ArrayList respuesta = evento_consultar_variable(hecho_actual.id_variable);
                            if (respuesta == null)
                            {
                                _codigo_de_salida_proceso = ConstantesShell.INFERENCIA_DETENIDA_POR_EL_USUARIO;
                                return;
                            }
                            procesarRespuestaVariable(hecho_actual.id_variable, respuesta);
                            //Actualizando todos los hechos asociados a la variable
                            string[] hechos_asociados = buscarHechosConVariable(hecho_actual.id_variable);
                            agregarLog("Procesando hechos asociados a la variable del hecho consecuente");
                            if (hechos_asociados != null)
                                for (int i = 0; i < hechos_asociados.Length; i++)
                                    procesarHecho(hechos_asociados[i], true);
                        }
                        else
                        {
                            agregarLog("Variable " + hecho_actual.id_variable + " conocida -> " + hecho_actual.id_hecho + " conocido");
                        }
                    }
                }
                //Selecionamos la mejor regla despues del proceso de encadenamiento
                id_mejor_regla = elegirMejorReglaCandidata();
                agregarLog("Regla elegida = " + id_mejor_regla);
            }
            agregarLog("PROCESO INFERENCIA TERMINADO SIN SOLUCIONAR PROBLEMA (NO HAY MAS REGLAS APLICABLES EN LA BASE DE CONOCIMIENTO)");
            _codigo_de_salida_proceso = ConstantesShell.INFERENCIA_DETENIDA_PROBLEMA_NO_SOLUCIONADO;
        }

        /// <summary>
        /// Método que procesa la evaluación y los efectos en las reglas de un hecho
        /// </summary>
        /// <param name="id_hecho">Id del hecho a evaluar</param>
        /// <param name="ingresado_por_usuario">Establece si el hecho fue ingresado por el usuario</param>
        /// <returns></returns>
        public bool procesarHecho(string id_hecho,bool ingresado_por_usuario)
        {
            //Actualizando Hecho
            Hecho hecho = base_conocimiento.extraerHecho(id_hecho);
            Variable variable = base_conocimiento.extraerVariable(hecho.id_variable);
            hecho.evaluarHecho(variable.valor_variable);
            base_conocimiento.actualizarHecho(hecho);
            if (hecho.estado_hecho)//Si hecho evaluado VERDADERO
            {
                agregarLog("Procesando hecho : " + id_hecho + " : (" + hecho + ") -->VERDADERO");
                moverHecho(id_hecho, ConstantesShell.HECHOS_DISPONIBLES, ConstantesShell.HECHOS_VERDADEROS);
                actualizarReglasConHechoVerdaderoAntecedente(hecho.id_hecho, ingresado_por_usuario,true);
            }
            else//Si el hecho es evaluado FALSO
            {
                agregarLog("Procesando hecho : " + id_hecho + " : (" + hecho + ") -->FALSO");
                moverHecho(id_hecho, ConstantesShell.HECHOS_DISPONIBLES, ConstantesShell.HECHOS_FALSOS);
                eliminarReglasConHechoFalsoEnElAntecedente(id_hecho);
            }
            descartarReglasConHechoConsecuente(id_hecho);//se descartan las reglas que tengan el hecho en el consecuente
            return true;
        }

        /// <summary>
        /// Método que actualiza el valor de la variable asociada a un Hecho inferido validado por el usuario
        /// </summary>
        /// <param name="id_hecho">Id del hecho inferido</param>
        private void actualizarVariableHechoInferido(string id_hecho)
        {
            Hecho hecho = base_conocimiento.extraerHecho(id_hecho);
            switch (hecho.tipo_variable)
            {
                case Variable.BOOLEANO:
                    actualizarVariable(hecho.id_variable, hecho.valor_booleano);
                    break;
                case Variable.NUMERICO:
                    actualizarVariable(hecho.id_variable, hecho.valor_numerico);
                    break;
                case Variable.LISTA:
                    actualizarVariable(hecho.id_variable, hecho.valor_lista_hecho);
                    break;
            }
        }



        /// <summary>
        /// Método que actualiza la variable segun su valor 
        /// </summary>
        /// <param name="id_variable">id de la variable a actualizar</param>
        /// <param name="valor">Valor Booleano(bool) de la variable</param>
        private void actualizarVariable(string id_variable, bool valor)
        {
            Variable variable = base_conocimiento.extraerVariable(id_variable);
            variable.valor_booleano_actual = valor;
            base_conocimiento.actualizarVariable(variable);
            lista_variables_conocidas.Add(id_variable);
            agregarLog("Variable" +id_variable + " conocida");
        }

        /// <summary>
        /// Método que actualiza la variable segun su valor 
        /// </summary>
        /// <param name="id_variable">id de la variable a actualizar</param>
        /// <param name="valor">Valor numerico(double) de la variable</param>
        private void actualizarVariable(string id_variable, double valor)
        {
            Variable variable = base_conocimiento.extraerVariable(id_variable);
            variable.valor_numerico_actual = valor;
            base_conocimiento.actualizarVariable(variable);
            lista_variables_conocidas.Add(id_variable);
            agregarLog("Variable" + id_variable + " conocida");
        }
        /// <summary>
        /// Método que actualiza la variable segun su valor 
        /// </summary>
        /// <param name="id_variable">id de la variable a actualizar</param>
        /// <param name="valor">Valor Lista (string) de la variable</param>
        private void actualizarVariable(string id_variable, string valor)
        {
            Variable variable = base_conocimiento.extraerVariable(id_variable);
            variable.valor_lista_actual = valor;
            base_conocimiento.actualizarVariable(variable);
            lista_variables_conocidas.Add(id_variable);
            agregarLog("Variable" + id_variable + " conocida");
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
        /// <param name="regla_validada">Establece si la regla fue validada por el usuario</param>
        public void actualizarValidaciónDeRegla(string id_regla_validada, bool regla_validada)
        {
            if (regla_validada)//Si la regla se valida
            {
                actualizarValidacionInfoRegla(id_regla_validada,ConstantesShell.REGLAS_CANDIDATAS, regla_validada);//validamos la regla candidata
                Regla regla = base_conocimiento.extraerRegla(id_regla_validada);
                regla.regla_validada = true;
                base_conocimiento.actualizarRegla(regla);
            }
            else//Si la regla no es validada
            {
                actualizarValidacionInfoRegla(id_regla_validada,ConstantesShell.REGLAS_CANDIDATAS, regla_validada);//validamos la regla candidata
                moverRegla(id_regla_validada, ConstantesShell.REGLAS_CANDIDATAS, ConstantesShell.REGLAS_ELIMINADAS);//eliminamos la regla de las reglas candidatas
            }
        }

        /// <summary>
        /// Método que descarta las reglas que contengan al hecho en el consecuente de las listas CANDIDATAS y DISPONIBLES
        /// </summary>
        /// <param name="id_hecho_consecuente"></param>
        public void descartarReglasConHechoConsecuente(string id_hecho_consecuente)
        {
            bool flag = false;
            string[] reglas_con_hecho_en_el_consecuente = null;
            //Buscando en candidatas
            reglas_con_hecho_en_el_consecuente = buscarReglasConHechoEnConsecuentes(id_hecho_consecuente, ConstantesShell.REGLAS_CANDIDATAS);
            if (reglas_con_hecho_en_el_consecuente != null)
            {
                flag = true;
                agregarLog(id_hecho_consecuente + " : Eliminado las reglas con el hecho en consecuente");
                for (int i = 0; i < reglas_con_hecho_en_el_consecuente.Length; i++)
                    moverRegla(reglas_con_hecho_en_el_consecuente[i], ConstantesShell.REGLAS_CANDIDATAS, ConstantesShell.REGLAS_ELIMINADAS);
            }
                
            //Buscado en disponibles
            reglas_con_hecho_en_el_consecuente = buscarReglasConHechoEnConsecuentes(id_hecho_consecuente, ConstantesShell.REGLAS_DISPONIBLES);
            if (reglas_con_hecho_en_el_consecuente != null)
            {
                if (!flag)
                    agregarLog(id_hecho_consecuente + " : Eliminado las reglas con el hecho en consecuente");
                for (int i = 0; i < reglas_con_hecho_en_el_consecuente.Length; i++)
                    moverRegla(reglas_con_hecho_en_el_consecuente[i], ConstantesShell.REGLAS_DISPONIBLES, ConstantesShell.REGLAS_ELIMINADAS);
            }
                
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
        /// Método que actualiza el hecho verdadero en REGLAS_DISPONIBLES y REGLAS_CANDIDATAS 
        /// y mueve las reglas pertinentes de DISPONIBLES a CANDIDATAS
        /// </summary>
        /// <param name="id_hecho">Id del hecho verdadero a actualizar</param>
        /// <param name="ingresado_por_usuario">Establece si el hecho es ingresado por el usuario o inferido</param>
        /// <param name="mover_reglas_disponibles_a_candidatas">Establece si las reglas encontradas con en el hecho en la lista de DISPONIBLES debe ser movida a CANDIDATAS</param>
        private void actualizarReglasConHechoVerdaderoAntecedente(string id_hecho, bool ingresado_por_usuario, bool mover_reglas_disponibles_a_candidatas)
        {
            Hecho hecho = base_conocimiento.extraerHecho(id_hecho);
            if(!hecho.estado_hecho)//Excepcion si el hecho esta evaluado como falso
                throw new System.ArgumentException("El hecho no es verdadero", "");
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
            //actualizando en reglas disponibles
            List<string> temporal_mover_de_disponibles_a_candidatas = new List<string>();
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
                    if (mover_reglas_disponibles_a_candidatas)
                        temporal_mover_de_disponibles_a_candidatas.Add(regla.id_regla);
                }
            }

            foreach (string item in temporal_mover_de_disponibles_a_candidatas)
                moverRegla(item, ConstantesShell.REGLAS_DISPONIBLES, ConstantesShell.REGLAS_CANDIDATAS, true);//todo arregalr moder un elemento mientras se analiza la lista trae problemas
        }

        /// <summary>
        /// Método que modifica los contadores de las listas de reglas
        /// </summary>
        /// <param name="id_regla">id de la regla a modificar</param>
        /// <param name="tipo_de_regla">Lista en donde se modificara la regla </param>
        /// <param name="sumar_a_antecedentes_conocidos_ingresados_por_usuario">cantidad a sumar en el contador de hechos conocidos ingresados por usuario</param>
        /// <param name="sumar_a_antecedentes_conocidos_inferidos">cantidad a sumar en el contador de hechos conocidos inferidos</param>
        public void aumentarConteoInfoRegla(string id_regla, int tipo_de_regla, int sumar_a_antecedentes_conocidos_ingresados_por_usuario = 0, int sumar_a_antecedentes_conocidos_inferidos = 0)
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
        /// Método que mueve las reglas con el hecho FALSO en el antecedente de DISPONIBLES y CANDIDATAS a ELIMINADA,
        /// </summary>
        /// <param name="id_hecho">Id del hecho FALSO a buscar</param>
        public void eliminarReglasConHechoFalsoEnElAntecedente(string id_hecho)
        {
            Hecho hecho = base_conocimiento.extraerHecho(id_hecho);
            if (hecho.estado_hecho)
                throw new System.ArgumentException("El hecho no es falso", "");
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
        public bool actualizarEvaluacionHecho(string id_hecho)
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
        /// Método para procesar la respuesta de una variable y la agrega a las variables conoccidas
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
            string tipo_valor = respuesta[1].GetType() + "";
            if (tipo_valor.Equals("System.Boolean"))
            {
                bool valor_respuesta = (bool)respuesta[1];
                if (variable.tipo_variable != Variable.BOOLEANO)
                    throw new System.ArgumentException("tipos de variable incompatibles", "ProcesarRespuestaVariable");
                variable.valor_booleano_actual = valor_respuesta;
                base_conocimiento.actualizarVariable(variable);
                lista_variables_conocidas.Add(id_variable);
                return;
            }
            else
            if (tipo_valor.Equals("System.String"))
            {
                string valor_respuesta = (string)respuesta[1];
                if (variable.tipo_variable != Variable.LISTA)
                    throw new System.ArgumentException("tipos de variable incompatibles", "ProcesarRespuestaVariable");
                variable.valor_lista_actual = valor_respuesta;
                base_conocimiento.actualizarVariable(variable);
                lista_variables_conocidas.Add(id_variable);
                return;
            }
            else
            if (tipo_valor.Equals("System.Double") || tipo_valor.Equals("System.Decimal"))
            {
                double valor_respuesta = (double)respuesta[1];
                if (variable.tipo_variable != Variable.NUMERICO)
                    throw new System.ArgumentException("tipos de variable incompatibles", "ProcesarRespuestaVariable");
                variable.valor_numerico_actual = valor_respuesta;
                base_conocimiento.actualizarVariable(variable);
                lista_variables_conocidas.Add(id_variable);
                return;
            }
            throw new System.ArgumentException("El tipo de respuesta no corresponde", "ProcesarRespuestaVariable");
        }

        /// <summary>
        /// Método que elige la mejor REGLA CANDIDATA 
        /// </summary>
        /// <returns>Id regla candidata</returns>
        public string elegirMejorReglaCandidata()
        {
            lista_reglas_candidatas.Sort(new InfoRegla());
            if (lista_reglas_candidatas.Count == 0)
                return null;
            for (int i = 0; i < lista_reglas_candidatas.Count; i++)
                if ( (lista_reglas_candidatas[i].puntaje_regla == 0) || 
                     (lista_reglas_candidatas[i].antecedentes_preguntables_al_usuario_conocidos < lista_reglas_candidatas[i].antecedentes_preguntables_al_usuario )  )
                    return lista_reglas_candidatas[i].id_regla;
            return null;
        }
        //utilitarios

        /// <summary>
        /// Método para rescartar la informacion de una regla en la lista de reglas
        /// </summary>
        /// <param name="id_regla">Id de regla a buscar</param>
        /// <param name="tipo_de_regla">Tipo de lista en donde buscar</param>
        /// <returns>InfoRegla de la regla buscada</returns>
        private InfoRegla rescatarInformacionRegla(string id_regla, int tipo_de_regla)
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
            List<string> reglas_encontradas = new List<string>();
            if (  !(tipo_de_reglas == ConstantesShell.REGLAS_CANDIDATAS || tipo_de_reglas == ConstantesShell.REGLAS_DISPONIBLES)  )
                throw new System.ArgumentException("No existe la opción de lista de reglas", "");
            List<InfoRegla> reglas_a_buscar = tipo_de_reglas == ConstantesShell.REGLAS_CANDIDATAS ? lista_reglas_candidatas : lista_reglas_disponibles;
            foreach (InfoRegla info_regla in reglas_a_buscar)
            {
                Regla regla = base_conocimiento.extraerRegla(info_regla.id_regla);
                if (regla.consultarConsecuente(id_hecho))
                    reglas_encontradas.Add(regla.id_regla);
            }
            return reglas_encontradas.Count == 0 ? null : reglas_encontradas.ToArray();
        }

        /// <summary>
        /// Método para buscar los hechos asociados a la variable en las listas HECHOS DISPONIBLES
        /// </summary>
        /// <param name="id_variable">id de la varaible a buscar</param>
        /// <returns></returns>
        private string[] buscarHechosConVariable(string id_variable)
        {
            List<string> hechos_asociados = new List<string>();
            foreach (string id_hecho_disponible in lista_hechos_disponibles)
            {
                Hecho hecho = base_conocimiento.extraerHecho(id_hecho_disponible);
                if (hecho.id_variable.Equals(id_variable))
                    hechos_asociados.Add(id_hecho_disponible);
            }
            if(hechos_asociados.Count != 0)
                return hechos_asociados.ToArray();
            return null;
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
                moverRegla(ids_regla[i], desde, hacia, marcar_tiempo_regla);
        }

        /// <summary>
        /// Método para mover de lista la regla ingresada
        /// </summary>
        /// <param name="id_regla">Id de la regla a mover</param>
        /// <param name="desde">Lista origen</param>
        /// <param name="hacia">Lista Destino</param>
        /// <param name="marcar_tiempo_regla">Establece si se debe marcar el tiempo regla en Info_regla</param>
        private void moverRegla(string id_regla, int desde, int hacia, bool marcar_tiempo_regla = false)
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
                throw new System.ArgumentException("La regla no se encuentra en la lista de origen (" + desde + ") " + id_regla, "Mover regla, motor de inferencia");
            foreach (InfoRegla info_regla in lista_hacia)
            {
                if (info_regla.id_regla.Equals(id_regla))
                {
                    throw new System.ArgumentException("La regla ya se encuentra en la lista destino (" + desde + ") " + id_regla, "Mover regla, motor de inferencia");
                }
            }

            lista_desde.Remove(regla_buscada);
            if (marcar_tiempo_regla)
            {
                regla_buscada.tiempo_regla = this.tiempo_regla;
                this.tiempo_regla++;
            }
            lista_hacia.Add(regla_buscada);

            string log = id_regla + ":De " + tipo_lista_desde + " a " + tipo_lista_hacia;
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
                    throw new System.ArgumentException("El hecho ya se encuentra en la lista destino (" + desde + ") " + id_hecho, "Mover hecho, motor de inferencia");
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