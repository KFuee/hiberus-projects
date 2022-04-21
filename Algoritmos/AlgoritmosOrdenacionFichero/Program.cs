using System;
using System.IO;
using System.Diagnostics;

namespace AlgoritmosOrdenacionFichero
{
    class Program
    {
        static Stopwatch timerLectura = new Stopwatch();

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

        static void Main(string[] args)
        {
            // Lee los números del fichero numbers.txt
            int[] numeros = leerNumerosDeFichero();

            // Imprime el tiempo tomado en ejecutar leerNumerosDeFichero
            Console.WriteLine(
                string.Format("Números del fichero leídos en {0}ms", timerLectura.ElapsedMilliseconds));
        }
    }
}
