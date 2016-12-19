using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib
{
    [Serializable()]
    public class MetadatosBaseDeConocimiento
    {
        /// <summary>
        /// Constante que indica el tipo de encadenamiento a utilizar en la base de conociento
        /// </summary>
        public const int ENCADENAMIENTO_HACIA_ATRAS     = 1;
        /// <summary>
        /// Constante que indica el tipo de encadenamiento a utilizar en la base de conociento
        /// </summary>
        public const int ENCADENAMIENTO_HACIA_ADELANTE  = 2;
        
        /// <summary>
        /// Obtiene o establece el titulo del sistema experto
        /// </summary>
        public string titulo_sistema_experto
        {
            get { return _titulo_sistema_experto;}
            set 
            {
                if (value == null || value.Equals(""))
                    _titulo_sistema_experto = "Sistema experto";
                else
                    _titulo_sistema_experto = value;
            }
        }
        string _titulo_sistema_experto = "Sistema experto";

        /// <summary>
        /// Obtiene o establece la ruta del archivo rtf descriptivo del sistema experto
        /// </summary>
        public string ruta_rtf_descripcion_sistema_experto
        {
            get { return _ruta_rtf_descripcion_sistema_experto; }
            set
            {
                if (value == null)
                    _ruta_rtf_descripcion_sistema_experto = "";
                else
                    _ruta_rtf_descripcion_sistema_experto = value;
            }
        }
        string _ruta_rtf_descripcion_sistema_experto = "";

        /// <summary>
        /// Obtiene o establece la ruta del logo del sistema experto
        /// </summary>
        public string ruta_imagen_logo_sistema_experto
        {
            get { return _ruta_imagen_logo_sistema_experto; }
            set
            {
                if (value == null)
                    _ruta_imagen_logo_sistema_experto = "";
                else
                    _ruta_imagen_logo_sistema_experto = value;
            }
        }
        string _ruta_imagen_logo_sistema_experto = "";

        /// <summary>
        /// Obtiene o establece el tipo de encadenamiento de la base de conocimiento segun las constantes ENCADENAMIENTO_HACIA_ATRAS ,ENCADENAMIENTO_HACIA_ADELANTE
        /// </summary>
        public int tipo_de_encadenamiento
        {
            get{return _tipo_de_encadenamiento;}
            set
            {
                if (value != ENCADENAMIENTO_HACIA_ATRAS && value != ENCADENAMIENTO_HACIA_ADELANTE)
                    throw new System.ArgumentException("Tipo de encadenamiento invalido","Metadatos base de conocimiento");
                _tipo_de_encadenamiento = value; 
            }
            
        }  
        int _tipo_de_encadenamiento = ENCADENAMIENTO_HACIA_ATRAS;
        /// <summary>
        /// Obtiene o estable si la base de conocimiento fue chequeda por el gestor encargado
        /// </summary>
        public bool base_conocimiento_chequeada
        {
            get { return _base_conocimiento_chequeada; }
            set { _base_conocimiento_chequeada = value;  }
        }
        bool _base_conocimiento_chequeada = false;
    }
}
