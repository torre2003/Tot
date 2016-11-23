using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib.Shell
{
   
    public class EncadenamientoHaciaAtras
    {
        //********************************************************************************************************
        //    Variables
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


        List<InfoRegla> lista_reglas_disponibles   = new List<InfoRegla>();
        List<InfoRegla> lista_reglas_candidatas    = new List<InfoRegla>();
        List<InfoRegla> lista_reglas_eliminadas    = new List<InfoRegla>();
        
        Stack<string> pila_hechos_a_verificar   = new Stack<string>();
        
        ArrayList lista_hechos_disponibles  = new ArrayList();
        ArrayList lista_hechos_verdaderos   = new ArrayList();
        ArrayList lista_hechos_falsos       = new ArrayList();

        List<string> lista_variables_disponibles = new List<string>();
        List<string> lista_variables_objetivos = new List<string>();
        ArrayList lista_hechos_antecedente_con_variables_objetivo = new ArrayList();//string[] = {"id_variable","id_hecho"}
        
        List<string> log = new List<string>();


        AccesoDatos base_conocimiento;


        /// <summary>
        /// Variable que indica si el objeto ha sido inicializado
        /// </summary>
        public bool encadenamiento_inicializado
        {
            get { return _encadenamiento_inicializado; }
        }
        private bool _encadenamiento_inicializado = false;


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
        

        public string inicializarEncadenamiento()
        {
            string retorno = "";
            if (!base_conocimiento._existe_base_conocimiento)
                return "No existe la base de conocimiento";
            int numero_de_reglas = base_conocimiento.listarArchivosEnDirectorio(AccesoDatos.REGLA).Length;
            if (numero_de_reglas == 0)
                return "La base de conocimiento esta vacia";
            inicializacionVariables();
            if (lista_variables_objetivos.Count == 0)
                return "No existen variables objetivo en la base conocimiento";
            inicializarHechos();
            inicializarReglas();
            //todo falta comprobador de integridad de las reglas
            return retorno;
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
                if (variable.variable_objetivo)
                    lista_variables_objetivos.Add(variable.id_variable);
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
                    string[] aux = new string[2];
                    aux[0] = hecho.id_variable;
                    aux[1] = hecho.id_hecho;
                    lista_hechos_antecedente_con_variables_objetivo.Add(aux);
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
                InfoRegla info_regla = new InfoRegla();
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


        //********************************************************************************************************
        //    Eventos
        //********************************************************************************************************



    }//End class




    


    //todo limpiarObjeto  variable, hecho y regla
}