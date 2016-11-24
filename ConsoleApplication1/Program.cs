using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaExpertoLib.MotorDeInferencia;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AccesoBaseConocimiento acceso = new AccesoBaseConocimiento();
            EncadenamientoHaciaAtras inferencia = new EncadenamientoHaciaAtras();
            inferencia.evento_consultar_variable += inferencia_evento_consultar_variable;
            Console.WriteLine("Iniciando inferencia");
            inferencia.inferencia();
            Console.WriteLine("inferencia terminada");
            Console.ReadKey();
        }

        static System.Collections.ArrayList inferencia_evento_consultar_variable(string id_variable)
        {
            Console.WriteLine("Escriba algo por favor");
            string resp = Console.ReadLine();
            System.Collections.ArrayList a = new System.Collections.ArrayList();
            a.Add(resp);
            return a;
        }


        

    }
}
