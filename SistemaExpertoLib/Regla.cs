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
        //todo regla inicial
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

        ArrayList antecedentes = new ArrayList();
        ArrayList consecuentes = new ArrayList();

        public Regla(string id_regla)
        {
            this.id_regla = id_regla;
        }

        public void agregarHechoAlAntecedente(string id_hecho)
        {
            antecedentes.Add(id_hecho);
        }
        
        public void agregarHechoAlConsecuente(string id_hecho)
        {
            consecuentes.Add(id_hecho);
        }

        public bool consultarAntecendente(string id_hecho)
        {
            foreach (string item in antecedentes)
                if (item.Equals(id_hecho))
                    return true;
            return false;
        }

        public bool consultarConsecuente(string id_hecho)
        {
            foreach (string item in consecuentes)
                if (item.Equals(id_hecho))
                    return true;
            return false;
        }

        public void eliminarAntecedente(string id_hecho)
        {
            object encontrado = null;
            foreach (object item in antecedentes)
            {
                string aux = (string)item;
                if (aux.Equals(id_hecho))
                {
                    encontrado = item;
                }
            }
            if (encontrado != null)
            {
                antecedentes.Remove(encontrado);
            }
        }

        public void eliminarConsecuente(string id_hecho)
        {
            object encontrado = null;
            foreach (object item in consecuentes)
            {
                string aux = (string)item;
                if (aux.Equals(id_hecho))
                {
                    encontrado = item;
                }
            }
            if (encontrado != null)
            {
                consecuentes.Remove(encontrado);
            }
        }


        public string[] listarAntecedentes()
        {
            string[] retorno = new string[this.antecedentes.Count];
            int i = 0;
            foreach (string item in antecedentes)
            {
                retorno[i] = item;
                i++;
            }
            return retorno;
        }

        public string[] listarConsecuentes()
        {
            string[] retorno = new string[this.consecuentes.Count];
            int i = 0;
            foreach (string item in consecuentes)
            {
                retorno[i] = item;
                i++;
            }
            return retorno;
        }
    }
}
