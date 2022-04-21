using System;
using System.Collections.Generic;
using Algoritmos = AlgoritmosOrdenacionLib;

namespace AlgoritmosOrdenacionMenu
{
    class Program
    {
        static Dictionary<int, Algoritmos.Metodo> metodos = 
            new Dictionary<int, Algoritmos.Metodo>
        {
            { 1, new Algoritmos.Metodos.BubbleSort() },
            { 2, new Algoritmos.Metodos.QuickSort() },
            { 3, new Algoritmos.Metodos.SelectionSort() },
            { 4, new Algoritmos.Metodos.InsertionSort() }
        };

        static void Main(string[] args)
        {
            foreach (KeyValuePair<int, Algoritmos.Metodo> metodo in metodos)
            {
                Console.WriteLine(string.Format("{0}. {1}", metodo.Key, metodo.Value.nombre));
            }

            // Pregunta al usuario la acción que desea ejecutar
            int metodoUsuario = Algoritmos.Utils.pedirNumero("Selecciona la acción a ejecutar: ");

            int sizeVector = Algoritmos.Utils.pedirNumero("Introduce el tamaño del vector: ");
            int[] vectorUsuario = new int[sizeVector];

            // Pregunta al usuario por los números que quiere introducir en el vector
            for (int i = 0; i < sizeVector; i++)
            {
                vectorUsuario[i] = Algoritmos.Utils.pedirNumero(
                    string.Format("Introduce el número de la posición {0}: ", i));
            }

            // Limpia la consola
            Console.Clear();

            // Ejecuta el método seleccionado
            metodos[metodoUsuario].ejecutar(vectorUsuario);
        }
    }
}
