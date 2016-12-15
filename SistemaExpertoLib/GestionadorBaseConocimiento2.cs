using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib.GestionDelConocimiento
{
    public partial class GestionadorBaseConocimiento
    {
        //***************************************************************************************
        //     Struct
        //***************************************************************************************

        struct InfoVariable
        {
            public string id_variable;
            public string nombre_variable;
            public List<string> variables_asociadas; //Variables hijas de la variable
            public List<string> reglas_relacionadas; //Variables que se relacionan directa o recursivamente con la variable
            public List<string> reglas_en_conflicto; //Reglas con problema de ambiguedad con la variable

            public bool buscarEnVariablesAsociadas(string id_variable)
            {
                foreach (string item in variables_asociadas)
                    if (item.Equals(id_variable))
                        return true;
                return false;
            }


            public void agregarElementoAReglasRelacionadas(List<string> reglas)
            {
                foreach (string item in reglas)
                    agregarElementoAReglasRelacionadas(item);
            }

            public void agregarElementoAReglasRelacionadas(string id_regla)
            {
                foreach (string item in reglas_relacionadas)
                    if (item.Equals(id_regla))
                        return;
                reglas_relacionadas.Add(id_regla);
            }

            public void agregarElementoAReglasEnConflicto(List<string> reglas)
            {
                foreach (string item in reglas)
                    agregarElementoAReglasEnConflicto(item);
            }

            public void agregarElementoAReglasEnConflicto(string id_regla)
            {
                foreach (string item in reglas_en_conflicto)
                    if (item.Equals(id_regla))
                        return;
                reglas_en_conflicto.Add(id_regla);
            }
        }
        //***************************************************************************************
        //     Métodos
        //***************************************************************************************
        public List<string> comprobarBaseDeConocimiento()
        {
            List<string> errores_comprobacion = new List<string>();
            limpiarHechosNoUtilizadosBaseDeConociento();
            try
            {
                errores_comprobacion.AddRange(comprobarIntegridadVariables());
                errores_comprobacion.AddRange(comprobarIntegridadReglas());

                if (errores_comprobacion.Count == 0)
                    errores_comprobacion.AddRange(comprobarAmbiguedadRecursivaEnReglas());
                //La unicidad de las reglas se comprueba cuando se ingresan las reglas a la base conocimiento
            }
            catch (Exception)
            {
                errores_comprobacion = new List<string>();
                errores_comprobacion.Add("Base de conocimiento corrupta, crear una nueva.");
                return errores_comprobacion;
            }

            if (errores_comprobacion.Count == 0)
            {
                metadatosCambiarChequeoBaseConocimiento(true);
                return null;
            }
            metadatosCambiarChequeoBaseConocimiento(false);
            
            return errores_comprobacion;
        }

        /// <summary>
        /// método que comprueba la integridad de las variables
        /// </summary>
        /// <returns>Lista de errores encontrados</returns>
        private List<string> comprobarIntegridadVariables()
        {
            List<string> errores_comprobacion = new List<string>();
            string[] variables = this.manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.VARIABLE);
            for (int i = 0; i < variables.Length; i++)
            {
                Variable variable = manejador_archivos.extraerVariable(variables[i]);
                if (!variable.chequeo_de_consistencia)
                    errores_comprobacion.Add("Variable no chequeada : "+ variable.id_variable + ":(" + variable.nombre_variable + ")");
                if (!variable.id_variable.Equals(variables[i]))
                {
                    errores_comprobacion.Add("Variable corrupta(Eliminada): " + variable.id_variable + ":(" + variable.nombre_variable + ")");
                    manejador_archivos.eliminarVariable(variables[i]);
                }
            }
            return errores_comprobacion;
        }

        /// <summary>
        /// método que comprueba la integridad de las reglas
        /// </summary>
        /// <returns>Lista de errores encontrados</returns>
        private List<string> comprobarIntegridadReglas()
        {
            List<string> errores_comprobacion = new List<string>();
            string[] reglas = this.manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.REGLA);
            for (int i = 0; i < reglas.Length; i++)
            {
                Regla regla = manejador_archivos.extraerRegla(reglas[i]);
                if (!regla.chequeo_de_consistencia)
                    errores_comprobacion.Add("Regla no chequeada "+regla.id_regla+" : "+regla);
                if (!regla.id_regla.Equals(reglas[i]))
                {
                    errores_comprobacion.Add("Regla corrupta (Eliminada)" + regla.id_regla + " : " + regla);
                    manejador_archivos.eliminarRegla(reglas[i]);
                }
                    
            }
            return errores_comprobacion;
        }

      
        /// <summary>
        /// Método que comprueba la ambiguedad recursiva de las reglas
        /// </summary>
        /// <returns></returns>
        private List<string> comprobarAmbiguedadRecursivaEnReglas(){
            List<string> errores_comprobacion = new List<string>();
            List<InfoVariable> info_variables = new List<InfoVariable>();
            
            //Inicio rellenado inicial info_variables
            string[] reglas = this.manejador_archivos.listarArchivosEnDirectorio(AccesoDatos.REGLA);
            for (int i = 0; i < reglas.Length; i++)
            {
                Regla regla = manejador_archivos.extraerRegla(reglas[i]);
                Hecho hecho_consecuente = manejador_archivos.extraerHecho(regla.id_hecho_consecuente);
                bool variable_encontrada_en_info_variables = false;
                for (int j = 0; j < info_variables.Count; j++)
                {
                    InfoVariable info_actual = info_variables[j];
                    string[] antecedentes = regla.listarAntecedentes();
                    string variable_consecuente = hecho_consecuente.id_variable;
                    string[] variables_antecedente = new string[antecedentes.Length];
                    for (int h = 0; h < antecedentes.Length; h++)//completamos la ids de las variables antecedente
                    {
                        Hecho hecho_antecedente = manejador_archivos.extraerHecho(antecedentes[h]);
                        variables_antecedente[h] = hecho_antecedente.id_variable;
                    }
                    if (info_actual.id_variable.Equals(variable_consecuente))//si variable asociada al consecuente ya se encuentra en el analisis, agregamos las variables antecedentes a variable asociada
                    {
                        //info_actual.reglas_relacionadas.Add(regla.id_regla);
                        info_actual.agregarElementoAReglasRelacionadas(regla.id_regla);
                        variable_encontrada_en_info_variables = true;
                        for (int k = 0; k < variables_antecedente.Length; k++)
                            if (!info_actual.buscarEnVariablesAsociadas(variables_antecedente[k]))//si no esta la variable la agregamos a las variables asociadas
                                info_actual.variables_asociadas.Add(variables_antecedente[k]);
                    }
                    else//Si el consecuente no esta en la variable principal, la buscamos en las asociadas
                    {
                        if (info_actual.buscarEnVariablesAsociadas(variable_consecuente))
                        {
                            //info_actual.reglas_relacionadas.Add(regla.id_regla);
                            info_actual.agregarElementoAReglasRelacionadas(regla.id_regla);
                            bool conflicto_regla = false;
                            for (int k = 0; k < variables_antecedente.Length; k++)//Comprobamos que el antecedente de la regla no contega la variable - lo cual provocaria ambiguedad
                                if (variables_antecedente[k].Equals(info_actual.id_variable))
                                {
                                    conflicto_regla = true;
                                    info_actual.agregarElementoAReglasEnConflicto(regla.id_regla);
                                    //info_actual.reglas_en_conflicto.Add(regla.id_regla);
                                }
                            if (!conflicto_regla) //si no hubo conflicto de reglas agregamos las variables no repetidas a las variables asociadas
                            {
                                for (int k = 0; k < variables_antecedente.Length; k++)
                                    if (!info_actual.buscarEnVariablesAsociadas(variables_antecedente[k]))//si no esta la variable la agregamos a las variables asociadas
                                        info_actual.variables_asociadas.Add(variables_antecedente[k]);
                            }
                        }
                    }
                    info_variables[j] = info_actual;
                }//end analisis info variables
                if (!variable_encontrada_en_info_variables)
                {
                    Variable variable = manejador_archivos.extraerVariable(hecho_consecuente.id_variable);
                    InfoVariable info           = new InfoVariable();
                    info.id_variable            = variable.id_variable;
                    info.nombre_variable        = variable.nombre_variable;
                    info.variables_asociadas    = new List<string>(); 
                    string[] antecedentes       = regla.listarAntecedentes();
                    for (int x = 0; x < antecedentes.Length; x++)
                    {
                        Hecho h = manejador_archivos.extraerHecho(antecedentes[x]);
                        info.variables_asociadas.Add(h.id_variable);
                    }
                    info.reglas_relacionadas = new List<string>();  //Variables que se relacionan directa o recursivamente con la variable
                    info.reglas_relacionadas.Add(regla.id_regla);
                    info.reglas_en_conflicto = new List<string>(); ; //Reglas con problema de ambiguedad con la variable
                    info_variables.Add(info);
                }
            }//end analisis de reglas
            
            //end rellenado inicial info_variables

            //Proceso iterativo para que todas la variables se comparen con todas
            bool flag_cambios = true;
            while (flag_cambios) 
            {
                flag_cambios = false;
                for (int i = 0; i < info_variables.Count; i++)
                {
                    for (int j = 0; j < info_variables.Count; j++)
                    {
                        if (i!=j)
                        {
                            InfoVariable info_a = info_variables[i];
                            InfoVariable info_b = info_variables[j];

                            if (info_a.buscarEnVariablesAsociadas(info_b.id_variable))//si la variable b esta en las variables asociadas agregamos y analizamos las que falten
                            {
                                bool conflicto_regla = false;
                                for (int k = 0; k < info_b.variables_asociadas.Count; k++)//Comprobamos que el antecedente de la regla no contega la variable - lo cual provocaria ambiguedad
                                    if (info_b.variables_asociadas[k].Equals(info_a.id_variable))
                                    {
                                        conflicto_regla = true;
                                        
                                    }
                                if (!conflicto_regla) //si no hubo conflicto de reglas agregamos las variables no repetidas a las variables asociadas
                                {
                                    for (int k = 0; k < info_b.variables_asociadas.Count; k++)
                                        if (!info_a.buscarEnVariablesAsociadas(info_b.variables_asociadas[k]))//si no esta la variable la agregamos a las variables asociadas
                                        {
                                            info_a.variables_asociadas.Add(info_b.variables_asociadas[k]);
                                            flag_cambios = true;
                                        }    
                                            
                                }
                                else//si hubo conflicto de reglas
                                {
                                    info_a.agregarElementoAReglasEnConflicto(info_b.reglas_relacionadas);
                                    info_a.agregarElementoAReglasRelacionadas(info_b.reglas_relacionadas);
                                }
                            }
                            info_variables[i] = info_a;
                            info_variables[j] = info_b;
                        }
                    }
                }
            }

            //Rellenando reglas con errores
            foreach (InfoVariable info in info_variables)
            {
                if (info.reglas_en_conflicto.Count > 0)
                {
                    Variable variable = manejador_archivos.extraerVariable(info.id_variable);
                    string error = "";
                    error = "Variable "+variable.id_variable+" ("+variable.nombre_variable+") Conflicto de ambiguedad \n\tReglas con conflicto : ";
                    for (int q = 0; q < info.reglas_en_conflicto.Count; q++)
                    {
                        if (q != 0)
                            error += "|";
                        error += info.reglas_en_conflicto[q];
                    }
                    error += "\n\t reglas relacionadas : ";
                    for (int q = 0; q < info.reglas_relacionadas.Count; q++)
                    {
                        if (q != 0)
                            error += "|";
                        error += info.reglas_relacionadas[q];
                    }
                    errores_comprobacion.Add(error);
                }
            }
            return errores_comprobacion;
        }

        /// <summary>
        /// Método que limpia los hechos no utilizados de la base de conocimiento
        /// </summary>
        private void limpiarHechosNoUtilizadosBaseDeConociento()
        {
            string[] lista_de_hechos = listarHechos();
            for (int i = 0; i < lista_de_hechos.Length; i++)
			{
			    string[] reglas_con_hecho = listarReglasConHecho(lista_de_hechos[i]);
                if (reglas_con_hecho == null)
                    eliminarHecho(lista_de_hechos[i]);
			}
        }
    }
}
