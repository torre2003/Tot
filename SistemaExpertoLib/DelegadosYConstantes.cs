using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib.MotorDeInferencia
{
    public delegate ArrayList DelegadoConsultarVariable(string id_variable);
    public delegate int[] DelegadoConfirmarHecho(string id_hecho);
    public delegate void DelegadoInformacionInferencia(string info);

    public static class ConstantesShell
    {
        public const int REGLAS_DISPONIBLES = 10;
        public const int REGLAS_CANDIDATAS = 11;
        public const int REGLAS_ELIMINADAS = 12;

        public const int HECHOS_DISPONIBLES = 20;
        public const int HECHOS_VERDADEROS = 21;
        public const int HECHOS_FALSOS = 22;

        public const int HECHO_CONFIRMADO = 31;
        public const int HECHO_DESCARTADO = 32;
        public const int PROBLEMA_SOLUCIONADO = 33;
        public const int PROBLEMA_NO_SOLUCIONADO = 34;
        public const int CONTINUAR_PROCESO = 35;
        public const int DETENER_PROCESO = 36;

        public const int INFERENCIA_DETENIDA_POR_EL_USUARIO = 41;
        public const int INFERENCIA_DETENIDA_PROBLEMA_SOLUCIONADO = 42;
        public const int INFERENCIA_DETENIDA_PROBLEMA_NO_SOLUCIONADO = 43;
        public const int INFERENCIA_TERMINADA_PROBLEMA_NO_SOLUCIONADO_REGLAS_FALTANTES = 44;
    }
}
