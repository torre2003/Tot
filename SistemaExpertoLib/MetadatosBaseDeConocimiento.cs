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
        public const int ENCADENAMIENTO_HACIA_ATRAS     = 1;
        public const int ENCADENAMIENTO_HACIA_ADELANTE  = 2;
        
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

        public bool base_conocimiento_chequeada
        {
            get { return _base_conocimiento_chequeada; }
            set { _base_conocimiento_chequeada = value;  }
        }
        bool _base_conocimiento_chequeada = false;
    }
}
