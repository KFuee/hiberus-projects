using System;
using System.IO;
using System.Diagnostics;
using System.Linq;

// using métodos de ordenación
using AlgoritmosOrdenacionLib;
using AlgoritmosOrdenacionLib.Metodos;

namespace AlgoritmosOrdenacionFichero
{
    class Program
    {
        static Stopwatch timer = new Stopwatch();

        private static int[] leerNumerosDeFichero()
        {
            // Empieza a contar el tiempo de ejecución
            timer.Start();

            string fichero = File.ReadAllText("numbers.txt");
            string[] numeros = fichero.Split(' ');

            int[] numerosParsed = new int[numeros.Length];
            for (int i = 0; i < numeros.Length - 1; i++)
            {
                numerosParsed[i] = int.Parse(numeros[i]);
            }

            // Para de contar el tiempo de ejecución
            timer.Stop();

            return numerosParsed;
        }

        static void imprimirResultado(string tipo, long[] tiempos)
        {
            Console.Write(string.Format("Números ordenados con {0} en: ", tipo));
            foreach (var ms in tiempos)
            {
                Console.Write(ms + "ms ");
            }

            // Espacio en blanco
            Console.WriteLine();

            Console.WriteLine("Media de las 10 iteraciones con {0}: {1}ms", tipo, tiempos.Sum() / 10);

            // Espacio en blanco
            Console.WriteLine();
        }

        private static long[] obtenerTiemposDeEjecucion(Metodo Metodo, int[] numeros)
        {
            long[] tiemposEjecucion = new long[10];
            for (int i = 0; i < 10; i++)
            {
                // Empieza a contar el tiempo de ejecución
                timer.Start();

                // Ordena el vector de números
                Metodo.algoritmo(numeros);

                // Para de contar el tiempo de ejecución
                timer.Stop();

                // Añade el tiempo de ejecución de la iteración al vector
                tiemposEjecucion[i] = timer.ElapsedMilliseconds;
                // Resetea el contador
                timer.Reset();
            }

            return tiemposEjecucion;
        }

        // TODO: Al finalizar las iteracione obtener el que ha tardado menos y utilizarlo para escribir en el txt
        static void Main(string[] args)
        {
            // Lee los números del fichero numbers.txt
            int[] numeros = leerNumerosDeFichero();

            //Ejecuta los métodos de ordenación
            long[] tiemposEjecucionBubbleSort = obtenerTiemposDeEjecucion(new BubbleSort(), numeros);
            long[] tiemposEjecucionQuickSort = obtenerTiemposDeEjecucion(new QuickSort(), numeros);
            long[] tiemposEjecucionSelectionSort = obtenerTiemposDeEjecucion(new SelectionSort(), numeros);

            //Imprime los tiempos de ejecución
            Console.WriteLine(
                string.Format("Números del fichero leídos en {0}ms", timer.ElapsedMilliseconds));
            //Resetea el contador
            timer.Reset();

            //Espacio en blanco
            Console.WriteLine();
            imprimirResultado("BubbleSort", tiemposEjecucionBubbleSort);
            imprimirResultado("QuickSort", tiemposEjecucionQuickSort);
            imprimirResultado("SelectionSort", tiemposEjecucionSelectionSort);
        }
    }
}
