using System;
using System.IO;
using System.Diagnostics;
using System.Linq;

// using métodos de ordenación
using AlgoritmosOrdenacionLib.Metodos;

namespace AlgoritmosOrdenacionFichero
{
    class Program
    {
        static Stopwatch timerLectura = new Stopwatch();
        
        // Timer BubbleSort
        static Stopwatch timerBubbleSort = new Stopwatch();
        static long[] tiemposBubbleSort = new long[10];

        private static int[] leerNumerosDeFichero()
        {
            // Empieza a contar el tiempo de ejecución
            timerLectura.Start();

            string fichero = File.ReadAllText("numbers.txt");
            string[] numeros = fichero.Split(' ');

            int[] numerosParsed = new int[numeros.Length];
            for (int i = 0; i < numeros.Length - 1; i++)
            {
                numerosParsed[i] = int.Parse(numeros[i]);
            }

            // Para de contar el tiempo de ejecución
            timerLectura.Stop();

            return numerosParsed;
        }

        private static void ordenarBubbleSort(int[] vector)
        {
            for (int i = 0; i < 10; i++)
            {
                // Empieza a contar el tiempo de ejecución
                timerBubbleSort.Start();

                new BubbleSort().algoritmo(vector);

                // Para de contar el tiempo de ejecución
                timerBubbleSort.Stop();

                // Añade el tiempo de ejecución de la iteración al vector
                tiemposBubbleSort[i] = timerBubbleSort.ElapsedMilliseconds;
                // Resetea el contador
                timerBubbleSort.Reset();
            }
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
        }

        // TODO: Al finalizar las iteracione obtener el que ha tardado menos y utilizarlo para escribir en el txt
        static void Main(string[] args)
        {
            // Lee los números del fichero numbers.txt
            int[] numeros = leerNumerosDeFichero();

            // Ejecuta los métodos de ordenación
            ordenarBubbleSort(numeros);

            // Imprime los tiempos de ejecución
            Console.WriteLine(
                string.Format("Números del fichero leídos en {0}ms", timerLectura.ElapsedMilliseconds));
            imprimirResultado("Bubble Sort", tiemposBubbleSort);
            
        }
    }
}
