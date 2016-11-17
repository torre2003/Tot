using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib
{
    [Serializable()]
    public class Regla
    {
        //**********************************************************************************************
        //   Atributos
        //**********************************************************************************************
        /// <summary>
        /// Identificador unico de la regla
        /// </summary>
        public string id_regla
        {
            get
            {
                return _id_regla;
            }
            set
            {
                _id_regla = value;
            }
        }
        string _id_regla = "";
        /// <summary>
        /// Lista de hechos antecedentes de la regla
        /// </summary>
        ArrayList antecedentes = new ArrayList();
        /// <summary>
        /// Hecho consecuente de la regla
        /// </summary>
        DatosHechos consecuente = new DatosHechos();
        /// <summary>
        /// ID del hecho consecuente de la regla
        /// </summary>
        public string id_consecuente   { get {return consecuente.id_hecho;}}


        /// <summary>
        /// Atributo que indica si la regla es consistene en la base de conocimiento
        /// </summary>
        public bool chequeo_de_consistencia
        {
            get { return _chequeo_de_consistencia; }
            set { _chequeo_de_consistencia = value; }
        }
        bool _chequeo_de_consistencia = true;

        //**********************************************************************************************
        //   Métodos
        //**********************************************************************************************
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id_regla">identificador unico de la regla</param>
        public Regla(string id_regla)
        {
            this.id_regla = id_regla;
        }

        /// <summary>
        /// Se agrega un nuevo Hecho a lista de antecedentes
        /// </summary>
        /// <param name="hecho">Objeto tipo hecho que se va a agregar</param>
        public bool agregarHechoAlAntecedente(Hecho hecho) 
        {
            //tod comprobar hecho no existente
            if (consultarAntecendente(hecho.id_hecho))
                return false;
            DatosHechos datos_hecho = new DatosHechos ()
            {
                id_hecho = hecho.id_hecho,
                nombre_hecho = ""+hecho,
                hecho_verdadero = false
            };
            antecedentes.Add(datos_hecho);
            return true;
        }
        
        /// <summary>
        /// Estaqblece un  nuevo Hecho en el consecuentes
        /// </summary>
        /// <param name="hecho">Objeto tipo hecho que se va a agregar</param>
        public void agregarHechoAlConsecuente(Hecho hecho)
        {
            consecuente = new DatosHechos()
            {
                id_hecho = hecho.id_hecho,
                nombre_hecho = "" + hecho,
                hecho_verdadero = false
            };
        }

        /// <summary>
        /// Método que muestra si el Hecho se encuentra en la lista de antecedentes
        /// </summary>
        /// <param name="id_hecho">Hecho a revisar</param>
        /// <returns>True si existe| False en caso contrario</returns>
        public bool consultarAntecendente(string id_hecho)
        {
            foreach (DatosHechos item in antecedentes)
                if (item.id_hecho.Equals(id_hecho))
                    return true;
            return false;
        }

        /// <summary>
        /// Método que cambia el estado del hecho en la regla ya sea en antecedente o consecuente 
        /// </summary>
        /// <param name="id_hecho">id del Hecho a modificar</param>
        /// <param name="estado_hecho">Estado del hecho</param>
        public void cambiarEstadoHecho(string id_hecho, bool estado_hecho)
        {
            if (consecuente.id_hecho.Equals(id_hecho))
            {
                consecuente.hecho_verdadero = estado_hecho;
                return;
            }

            for (int i = 0; i < antecedentes.Count; i++)
            {
                DatosHechos aux = (DatosHechos)antecedentes[i];
                if (aux.id_hecho.Equals(id_hecho))
                {
                    aux.hecho_verdadero = estado_hecho;
                    return;
                }
            }
        }


        /// <summary>
        /// Método que consulta si el hecho es el antecedente
        /// </summary>
        /// <param name="id_hecho">Hecho a revisar</param>
        /// <returns>True si existe| False en caso contrario</returns>
        public bool consultarConsecuente(string id_hecho)
        {
            if (!consecuente.id_hecho.Equals(""))
                if (consecuente.id_hecho.Equals(""))
                    return true;
            return false;
        }

        /// <summary>
        /// Método que elimina un hecho de los antecedentes
        /// </summary>
        /// <param name="id_hecho">id del hecho a eliminar</param>
        public void eliminarAntecedente(string id_hecho)
        {
            object encontrado = null;
            foreach (object item in antecedentes)
            {
                DatosHechos datos_hecho = (DatosHechos)item;
                if (datos_hecho.id_hecho.Equals(id_hecho))
                {
                    encontrado = item;
                }
            }
            if (encontrado != null)
            {
                antecedentes.Remove(encontrado);
            }
        }

        /// <summary>
        /// Método que elimina el hecho consecuente de la regla
        /// </summary>
        public void eliminarConsecuente()
        {
            consecuente = new DatosHechos();
        }

        /// <summary>
        /// Método que lista los hechos antecedentes
        /// </summary>
        /// <returns>Array con las ID de los hechos antecedentes</returns>
        public string[] listarAntecedentes()
        {
            string[] retorno = new string[this.antecedentes.Count];
            int i = 0;
            foreach (DatosHechos item in antecedentes)
            {
                retorno[i] = item.id_hecho;
                i++;
            }
            return retorno;
        }

        /// <summary>
        /// Método que marca como falso todos los Hechos en la Regla , antecedentes y consecuente.
        /// </summary>
        public void limpiarEstadoHechosRegla()
        {
            consecuente.hecho_verdadero = false;
            for (int i = 0; i < antecedentes.Count; i++)
            {
                DatosHechos aux = (DatosHechos)antecedentes[i];
                aux.hecho_verdadero = false;
            }
        }

        /// <summary>
        /// ToString modificado
        /// </summary>
        /// <returns>Regla</returns>
        public override string ToString()
        {
            string retorno = "SI ";
            for (int i = 0; i < antecedentes.Count; i++)
            {
                if (i != 0)
                    retorno += " Y ";
                DatosHechos datos = (DatosHechos)antecedentes[i];
                retorno += datos.nombre_hecho;
            }
            retorno += " ENTONCES " + consecuente.nombre_hecho;
            return retorno;
        }

        /// <summary>
        /// Equals modificado, compara dos reglas en base a sus hechos sin importar la ID
        /// </summary>
        /// <param name="obj">Objeto de tipo regla</param>
        /// <returns>TRUE si todos sus hechos son iguales, FALSE en caso contrario</returns>
        public override bool Equals(object obj)
        {
            string tipo_obj = obj.GetType()+"";
            if (!tipo_obj.Equals("SistemaExpertoLib.Regla"))
                return false;
            Regla regla = (Regla)obj;
            if (this.antecedentes.Count != regla.antecedentes.Count)
                return false;
            if (!this.consecuente.id_hecho.Equals(regla.consecuente.id_hecho))
                return false;
            string[] lista_de_hechos_regla = regla.listarAntecedentes();
            bool flag = true;
            for (int i = 0; i < lista_de_hechos_regla.Length && flag; i++)
                flag = this.consultarAntecendente(lista_de_hechos_regla[i]);
            return flag;
        }

        [Serializable()]
        struct DatosHechos 
        {
            //**********************************************************************************************
            //   Atributos
            //**********************************************************************************************
            /// <summary>
            /// Identificador unico del hecho
            /// </summary>
            public string id_hecho;
            /// <summary>
            ///  descripcion del hecho ej. "var MENOR  1"
            /// </summary>
            public string nombre_hecho;
            /// <summary>
            /// Especifica si el hecho ha sido validado como verdadero
            /// </summary>
            public bool hecho_verdadero;
        }

    }
}
