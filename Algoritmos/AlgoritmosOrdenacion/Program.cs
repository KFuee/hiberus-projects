using System;
using System.Collections.Generic;

namespace AlgoritmosOrdenacion
{
    class Program
    {
        static Dictionary<int, Metodo> metodos = new Dictionary<int, Metodo>
        {
            { 1, new Metodos.BubbleSort() },
            { 2, new Metodos.QuickSort() },
            { 3, new Metodos.SelectionSort() }
        };

        static void Main(string[] args)
        {
            foreach (KeyValuePair<int, Metodo> metodo in metodos)
            {
                Console.WriteLine(string.Format("{0}. {1}", metodo.Key, metodo.Value.nombre));
            }

            // Pregunta al usuario la acción que desea ejecutar
            int metodoUsuario = Utils.pedirNumero("Selecciona la acción a ejecutar: ");

            int sizeVector = Utils.pedirNumero("Introduce el tamaño del vector: ");
            int[] vectorUsuario = new int[sizeVector];

            // Pregunta al usuario por los números que quiere introducir en el vector
            for (int i = 0; i < sizeVector; i++)
            {
                vectorUsuario[i] = Utils.pedirNumero(
                    string.Format("Introduce el número de la posición {0}: ", i));
            }

            // Limpia la consola
            Console.Clear();

            // Ejecuta el método seleccionado
            metodos[metodoUsuario].ejecutar(vectorUsuario);
        }
    }
}
