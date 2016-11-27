﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib.MotorDeInferencia
{
    public class AccesoBaseConocimiento
    {
        AccesoDatos base_conocimiento;
        public bool existe_base_conocimiento
        {
            get { return base_conocimiento._existe_base_conocimiento; }
        }
        
        public AccesoBaseConocimiento()
        {
            base_conocimiento = new AccesoDatos();
        }
            
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="ruta_carpeta_archivos">Ruta del repositorio de la base de conocimiento</param>
        public AccesoBaseConocimiento(string ruta_carpeta_archivos)
        {
            base_conocimiento = new AccesoDatos(ruta_carpeta_archivos);
        }

        /// <summary>
        /// Método para leer una variable de la base de conocimiento
        /// </summary>
        /// <param name="id_variable">Id de la variable requerida</param>
        /// <returns>Objeto tipo Variable| null si no existe</returns>
        public Variable leerVariable(string id_variable)
        {
            return base_conocimiento.extraerVariable(id_variable);
        }

        /// <summary>
        /// Método para leer un hecho de la base de conocimiento
        /// </summary>
        /// <param name="id_hecho">Id del hecho requerida</param>
        /// <returns>Objeto tipo hecho| null si no existe</returns>
        public Hecho leerHecho(string id_hecho)
        {
            return base_conocimiento.extraerHecho(id_hecho);
        }
        /// <summary>
        /// Método para leer un regla de la base de conocimiento
        /// </summary>
        /// <param name="id_regla">Id del hecho requerida</param>
        /// <returns>Objeto tipo hecho| null si no existe</returns>
        public Regla leerRegla(string id_regla)
        {
            return base_conocimiento.extraerRegla(id_regla);
        }

    }
}