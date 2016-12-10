using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExpertoLib.MotorDeInferencia
{
    public delegate ArrayList DelegadoConsultarVariable(string id_variable);
    public delegate int[] DelegadoConfirmarHecho(string id_hecho, string id_regla);
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

        public const int LOG_INFO                                           = 100;
        public const int LOG_VARIABLE                                       = 101;
        public const int LOG_HECHO                                          = 102;
        public const int LOG_REGLA                                          = 103;
        public const int LOG_NIVEL_HECHO                                    = 104;
        public const int LOG_ACCION_MOVER                                   = 105;
        public const int LOG_ACCION_ELEGIDA_MEJOR_REGLA                     = 106;
        public const int LOG_ACCION_CONSULTANDO_HECHOS                      = 107;
        public const int LOG_ACCION_HECHO_OBJETIVO_PRINCIPAL                = 108;
        public const int LOG_ACCION_HECHO_OBJETIVO_ACTUAL                   = 109;
        public const int LOG_ACCION_INGRESANDO_HECHO_A_PILA_OBJETIVOS       = 110;
        public const int LOG_ACCION_QUITANDO_HECHO_DE_PILA_OBJETIVOS        = 111;
        public const int LOG_ACCION_VALIDANDO_REGLA                         = 112;
        public const int LOG_ACCION_INGRESANDO_A_VARIABLES_CONOCIDAS        = 113;
        public const int LOG_ACCION_PROCESANDO_RESPUESTA                    = 114;
        public const int LOG_INFO_CONSULTANDO_HECHOS                        = 115;
        public const int LOG_INFO_ANALIZANDO_HECHOS_INFERIDOS_REGLA         = 116;
        public const int LOG_INFO_REGLA_VALIDADA                            = 117;
        public const int LOG_INFO_REGLA_NO_VALIDADA                         = 118;
        public const int LOG_INFO_DESCARTANDO_REGLAS_DE_IGUAL_CONSECUENTE   = 119;
        public const int LOG_INFO_PROBLEMA_SOLUCIONADO                      = 120;
        public const int LOG_INFO_PROBLEMA_NO_SOLUCIONADO                   = 121;
        public const int LOG_INFO_CONTINUANDO_PROCESO                       = 122;
        public const int LOG_INFO_PROCESO_DETENIDO                          = 123;
        public const int LOG_INFO_TERMINO_DE_INFERENCIA_REGLAS_AGOTADAS     = 124;
        public const int LOG_INFO_SIN_REGLAS_PARA_INFERIR_HECHO             = 125;
        public const int LOG_INFO_VARIABLE_CONOCIDA                         = 126;

        /*   
        public const int LOG_REGLAS_DISPONIBLES                         = 110;
        public const int LOG_REGLAS_CANDIDATAS                          = 111;
        public const int LOG_REGLAS_ELIMINADAS                          = 112;
        public const int LOG_VARIABLES_DISPONIBLES                      = 113;
        public const int LOG_VARIABLES_CONOCIDAS                        = 114;
        public const int LOG_HECHOS_DISPONIBLES                         = 115;
        public const int LOG_HECHOS_VERDADEROS                          = 116;
        public const int LOG_HECHOS_FALSOS                              = 117;
        */
        

    }
}
