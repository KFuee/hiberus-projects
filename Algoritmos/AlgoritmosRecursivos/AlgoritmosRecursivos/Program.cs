using System;
using System.Collections.Generic;

namespace AlgoritmosRecursivos
{
    class Program
    {
        static Dictionary<int, Action> ejercicios = new Dictionary<int, Action>
        {
            { 1, () => Ejercicios.Ejercicio1.ejecutar() },
            { 2, () => Ejercicios.Ejercicio2.ejecutar() },
            { 3, () => Ejercicios.Ejercicio3.ejecutar() },
            { 4, () => Ejercicios.Ejercicio4.ejecutar() },
            { 5, () => Ejercicios.Ejercicio5.ejecutar() },
            { 6, () => Ejercicios.Ejercicio6.ejecutar() },
            { 7, () => Ejercicios.Ejercicio7.ejecutar() },
            { 8, () => Ejercicios.Ejercicio8.ejecutar() },
            { 9, () => Ejercicios.Ejercicio9.ejecutar() },
            { 10, () => Ejercicios.Ejercicio10.ejecutar() }
        };

        static void Main(string[] args)
        {
            foreach (int i in ejercicios.Keys)
            {
                Console.WriteLine(string.Format("{0}. Ejercicio {0}", i));
            }

            int numeroEjercicio = Utils.pedirNumero();

            // Limpia la consola antes de ejecutar el ejercicio
            Console.Clear();

            ejercicios[numeroEjercicio]();
        }
    }
}
