using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib.MotorDeInferencia
{
   
    public delegate ArrayList DelegadoConsultarVariable(string id_variable);
    public class EncadenamientoHaciaAtras
    {
        //********************************************************************************************************
        //    Estructuras
        //********************************************************************************************************
        struct InfoRegla
        {
            public string id_regla;
            public bool validada;
            public int numero_de_antecedentes;
            public int antecedentes_preguntables_al_usuario;
            public int antecedentes_preguntables_al_usuario_conocidos;
            public int antecedentes_inferidos;
            public int antecedentes_inferidos_conocidos;
        }

        struct HechoPila
        {
            public string hecho_buscado;
            public int nivel;
        }
        
        //********************************************************************************************************
        //    Variables
        //********************************************************************************************************

        private const int REGLAS_DISPONIBLES    = 0;
        private const int REGLAS_CANDIDATAS     = 1;


        List<InfoRegla> lista_reglas_disponibles   = new List<InfoRegla>();
        List<InfoRegla> lista_reglas_candidatas    = new List<InfoRegla>();
        List<InfoRegla> lista_reglas_eliminadas    = new List<InfoRegla>();
        
        Stack<HechoPila> pila_hechos_a_verificar   = new Stack<HechoPila>();
        
        ArrayList lista_hechos_disponibles  = new ArrayList();
        ArrayList lista_hechos_verdaderos   = new ArrayList();
        ArrayList lista_hechos_falsos       = new ArrayList();

        List<string> lista_variables_disponibles = new List<string>();
        List<string> lista_variables_objetivos = new List<string>();
        ArrayList lista_hechos_consecuente_con_variables_objetivo = new ArrayList();//string[] = {"id_variable","id_hecho"}
        
        List<string> log = new List<string>();

        AccesoDatos base_conocimiento;


        /// <summary>
        /// Evento de consulta variable
        /// Se debe retornar un ArrayList de la siguiente forma
        /// BOOLEANO {(string)id_,variable,(string)condicion}
        /// NUEMRICO {(string)id_,variable,(string)condicion,(double o int) valor}
        /// LISTA    {(string)id_,variable,(string)condicion,(string) opcion}
        /// </summary>
        public event DelegadoConsultarVariable evento_consultar_variable;


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

            lista_hechos_disponibles = new ArrayList();
            lista_hechos_verdaderos = new ArrayList();
            lista_hechos_falsos = new ArrayList();

            lista_variables_disponibles = new List<string>();
            lista_variables_objetivos = new List<string>();
            lista_hechos_consecuente_con_variables_objetivo = new ArrayList();//string[] = {"id_variable","id_hecho"}

            log = new List<string>();

            _hecho_objetivo_establecido = false;
            int numero_de_reglas = base_conocimiento.listarArchivosEnDirectorio(AccesoDatos.REGLA).Length;
            if (numero_de_reglas == 0)
                return "La base de conocimiento esta vacia";
            inicializarReglas();
            
            inicializacionVariables();
            inicializarHechos();
            if (lista_variables_objetivos.Count == 0)
                return "No existen variables objetivo en la base conocimiento";
            if (lista_hechos_consecuente_con_variables_objetivo.Count == 0)
                return "No existen hechos objetivos en el consecuente";
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
                    if (buscarHechoEnConsecuentesDeReglas(hecho.id_hecho,REGLAS_DISPONIBLES) != null)
                    {
                        string[] aux = new string[2];
                        aux[0] = hecho.id_variable;
                        aux[1] = hecho.id_hecho;
                        lista_hechos_consecuente_con_variables_objetivo.Add(aux);
                        lista_variables_objetivos.Add(hecho.id_hecho);
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
            _hecho_objetivo_establecido = true;
        }

#endregion  


        #region Inferencia


        public void inferencia()
        {
            string mostrar = "texto sin retorno delegado";
            if (evento_consultar_variable != null)
            {
                ArrayList a = evento_consultar_variable("id");
                mostrar = (string)a[0];
            }

            Console.WriteLine(mostrar);
        }









        /// <summary>
        /// Método que busca un hecho es el consecuente de la lista de reglas
        /// </summary>
        /// <param name="id_hecho">Identificador del hecho a buscar</param>
        /// <param name="tipo_de_reglas">Constante con el tipo de  lista donde se va a buscar el hecho, REGLAS_CANDIDATAS o REGLAS DISPONIBLES</param>
        /// <returns></returns>
        private string[] buscarHechoEnConsecuentesDeReglas(string id_hecho, int tipo_de_reglas)
        {
            List<string> hechos_encontrados = new List<string>();
            if (!(tipo_de_reglas == REGLAS_CANDIDATAS || tipo_de_reglas == REGLAS_DISPONIBLES))
                throw new System.ArgumentException("No existe la opción de lista de reglas", "");
            List<InfoRegla> reglas_a_buscar = tipo_de_reglas == REGLAS_CANDIDATAS ? lista_reglas_candidatas : lista_reglas_disponibles;
            foreach (InfoRegla info_regla in reglas_a_buscar)
            {
                Regla regla = base_conocimiento.extraerRegla(info_regla.id_regla);
                if (regla.consultarConsecuente(id_hecho))
                    hechos_encontrados.Add(regla.id_regla);
            }
            return hechos_encontrados.Count == 0 ? null : hechos_encontrados.ToArray();
        }


        #endregion



        //********************************************************************************************************
        //    Eventos
        //********************************************************************************************************



    }//End class




    


    //todo limpiarObjeto  variable, hecho y regla
}